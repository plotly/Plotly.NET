namespace Plotly.NET.Verso.IntegrationTests

open System
open System.Collections.Generic
open System.IO
open System.Text.Json
open System.Threading.Tasks
open System.Xml.Linq
open Infrastructure

module Program =
    [<Literal>]
    let HostVersion = "1.2.3"

    let private prepare repository artifacts =
        let run = Path.Combine(artifacts, "runs", DateTime.UtcNow.ToString("yyyyMMddTHHmmss") + "-" + Guid.NewGuid().ToString("N").Substring(0, 8))
        Directory.CreateDirectory(run) |> ignore
        let variables = new Dictionary<string, string>()
        for key, folder in
            [ "NUGET_PACKAGES", "packages"; "NUGET_HTTP_CACHE_PATH", "http-cache"; "NUGET_PLUGINS_CACHE_PATH", "plugins-cache"
              "DOTNET_CLI_HOME", "dotnet-home"; "TEMP", "temp"; "TMP", "temp"; "TMPDIR", "temp"
              "APPDATA", "appdata"; "LOCALAPPDATA", "localappdata"; "XDG_CONFIG_HOME", "config"; "XDG_CACHE_HOME", "cache" ] do
            let directory = Path.Combine(run, folder)
            Directory.CreateDirectory(directory) |> ignore
            variables[key] <- directory
        variables["DOTNET_NOLOGO"] <- "1"
        variables["DOTNET_CLI_TELEMETRY_OPTOUT"] <- "1"
        variables["DOTNET_SKIP_FIRST_TIME_EXPERIENCE"] <- "1"
        let manifest = JsonSerializer.Deserialize<PackageManifest>(File.ReadAllText(Path.Combine(artifacts, "packages.json")))
        let environment = { Repository = repository; Artifacts = artifacts; RunDirectory = run; Variables = variables; Manifest = manifest }
        Notebook.validatePackages environment
        let config =
            XDocument(XElement(XName.Get "configuration",
                XElement(XName.Get "packageSources",
                    XElement(XName.Get "clear"),
                    XElement(XName.Get "add", XAttribute(XName.Get "key", "local"), XAttribute(XName.Get "value", Path.Combine(run, "feed"))),
                    XElement(XName.Get "add", XAttribute(XName.Get "key", "nuget.org"), XAttribute(XName.Get "value", "https://api.nuget.org/v3/index.json")))))
        config.Save(Path.Combine(run, "NuGet.Config"))
        File.Copy(Path.Combine(artifacts, "packages.json"), Path.Combine(run, "packages.json"))
        environment

    let private execute repository artifacts = task {
        let environment = prepare repository artifacts
        printfn "Verso %s packaged integration; diagnostics: %s" HostVersion environment.RunDirectory
        let tools = Path.Combine(environment.RunDirectory, "tools")
        let! _ = runProcess environment "install-cli" "dotnet"
                    [ "tool"; "install"; "Verso.Cli"; "--version"; HostVersion; "--tool-path"; tools
                      "--configfile"; Path.Combine(environment.RunDirectory, "NuGet.Config") ] (TimeSpan.FromMinutes(5.))
        let cli = Path.Combine(tools, if OperatingSystem.IsWindows() then "verso.exe" else "verso")
        let! version = runProcess environment "cli-version" cli [ "--version" ] (TimeSpan.FromSeconds(30.))
        require (version.Contains(HostVersion)) $"Unexpected CLI version: {version}"
        let online, offline = Notebook.createFixtures environment
        for name, notebook, charts in [ "online", online, 2; "offline", offline, 1 ] do
            let output = Path.Combine(environment.RunDirectory, name + "-result.json")
            let! _ = runProcess environment (name + "-run") cli
                        [ "run"; notebook; "--output"; "json"; "--output-file"; output; "--save"; "--fail-fast"; "--timeout"; "300" ]
                        (TimeSpan.FromMinutes(6.))
            Notebook.validateResult environment output charts
            printfn "PASS packaged CLI: %s (all cells, formatter discovery, local assembly hashes, saved output)" name
        do! BrowserTests.run environment cli online offline
    }

    [<EntryPoint>]
    let main arguments =
        try
            require (arguments.Length = 2) "Usage: VersoIntegrationTests <repository-root> <artifacts-directory>. Run through the FAKE RunVersoIntegrationTests target."
            execute (Path.GetFullPath(arguments[0])) (Path.GetFullPath(arguments[1])) |> fun work -> work.GetAwaiter().GetResult()
            0
        with ex ->
            eprintfn "%O" ex
            1
