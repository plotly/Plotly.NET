namespace Plotly.NET.Verso.IntegrationTests

open System
open System.Collections.Generic
open System.Diagnostics
open System.IO
open System.Net
open System.Net.Http
open System.Net.Sockets
open System.Security.Cryptography
open System.Text
open System.Threading.Tasks

[<CLIMutable>]
type PackageManifest =
    { coreVersion: string
      versoVersion: string
      configuration: string
      coreAssembly: string
      versoAssembly: string
      coreSha256: string
      versoSha256: string }

type TestEnvironment =
    { Repository: string
      Artifacts: string
      RunDirectory: string
      Variables: IReadOnlyDictionary<string, string>
      Manifest: PackageManifest }

/// Each child has its own log and lifetime. A failed assertion must never leave a server running.
type ChildProcess(command: string, arguments: string list, directory: string, variables: IReadOnlyDictionary<string, string>, logPath: string) =
    let log = new StringBuilder()
    let writer = new StreamWriter(logPath, false, UTF8Encoding(false), AutoFlush = true)
    let start = ProcessStartInfo(command, WorkingDirectory = directory, UseShellExecute = false,
                                 RedirectStandardOutput = true, RedirectStandardError = true,
                                 CreateNoWindow = true, WindowStyle = ProcessWindowStyle.Hidden)
    let child = new Process(StartInfo = start)
    do
        for argument in arguments do start.ArgumentList.Add(argument)
        for KeyValue(key, value) in variables do start.Environment[key] <- value
        let capture (line: string) =
            if not (isNull line) then
                lock log (fun () ->
                    log.AppendLine(line) |> ignore
                    writer.WriteLine(line))
        child.OutputDataReceived.Add(fun e -> capture e.Data)
        child.ErrorDataReceived.Add(fun e -> capture e.Data)
        if not (child.Start()) then failwith $"Could not start {command}."
        child.BeginOutputReadLine()
        child.BeginErrorReadLine()

    member _.HasExited = child.HasExited
    member _.Log = lock log (fun () -> log.ToString())
    member this.WaitAsync(timeout: TimeSpan) = task {
        try
            do! child.WaitForExitAsync().WaitAsync(timeout)
            // Drain the asynchronous stdout/stderr callbacks before reading the log.
            child.WaitForExit()
            if child.ExitCode <> 0 then
                failwith $"{command} exited with {child.ExitCode}. See {logPath}\n{this.Log}"
        with :? TimeoutException ->
            if not child.HasExited then child.Kill(true)
            failwith $"{command} exceeded {timeout}. See {logPath}\n{this.Log}"
    }
    interface IDisposable with
        member _.Dispose() =
            if not child.HasExited then
                child.Kill(true)
                child.WaitForExit(15000) |> ignore
            child.Dispose()
            writer.Dispose()

module Infrastructure =
    let require condition message = if not condition then failwith message

    let sha256 (bytes: byte[]) = SHA256.HashData(bytes) |> Convert.ToHexString

    let runProcess (environment: TestEnvironment) name command arguments timeout = task {
        use child = new ChildProcess(command, arguments, environment.RunDirectory, environment.Variables,
                                     Path.Combine(environment.RunDirectory, name + ".log"))
        do! child.WaitAsync(timeout)
        return child.Log
    }

    let freePort () =
        let listener = new TcpListener(IPAddress.Loopback, 0)
        listener.Start()
        let port = (listener.LocalEndpoint :?> IPEndPoint).Port
        listener.Stop()
        port

    let waitForServer (server: ChildProcess) (url: string) = task {
        use client = new HttpClient(Timeout = TimeSpan.FromSeconds(3.))
        let watch = Stopwatch.StartNew()
        let mutable ready = false
        while not ready && watch.Elapsed < TimeSpan.FromSeconds(90.) do
            require (not server.HasExited) $"Verso exited before HTTP startup.\n{server.Log}"
            try
                use! response = client.GetAsync(url)
                ready <- response.IsSuccessStatusCode
            with
            | :? HttpRequestException -> ()
            | :? TaskCanceledException -> ()
            if not ready then do! Task.Delay(250)
        require ready $"Verso did not answer within 90 seconds.\n{server.Log}"
    }
