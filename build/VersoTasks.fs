module VersoTasks

open System
open System.IO
open System.Security.Cryptography
open System.Text.Json
open System.Text.Json.Nodes
open System.Xml.Linq
open BlackFox.Fake
open Fake.Core
open Fake.DotNet
open ProjectInfo

let private artifacts = Path.GetFullPath("tests/VersoTests/artifacts")
let private feed = Path.Combine(artifacts, "feed")

let private versionProperties (project: ProjectInfo) =
    [
        "Version", project.PackageVersionTag
        "PackageVersion", project.PackageVersionTag
        "AssemblyVersion", project.AssemblyVersion
        "InformationalVersion", project.AssemblyInformationalVersion
        "TargetsForTfmSpecificContentInPackage", ""
    ]

/// A noninteractive package preparation path, independent of Pack/RunTestsAll.
/// Versions and configuration must agree between build, pack, and the host fixtures.
let packVersoIntegrationPackages = BuildTask.create "PackVersoIntegrationPackages" [] {
    Directory.CreateDirectory(feed) |> ignore
    let packageProjects = [ CoreProject; VersoProject ]

    for project in packageProjects do
        DotNet.build
            (fun options ->
                { options with
                    Configuration = DotNet.BuildConfiguration.fromString configuration
                    MSBuildParams =
                        { options.MSBuildParams with
                            Properties = versionProperties project
                            DisableInternalBinLog = true } }
                |> DotNet.Options.withCustomParams (Some "--no-dependencies"))
            project.ProjFile

        DotNet.pack
            (fun options ->
                { options with
                    Configuration = DotNet.BuildConfiguration.fromString configuration
                    NoBuild = true
                    OutputPath = Some feed
                    MSBuildParams =
                        { options.MSBuildParams with
                            Properties = versionProperties project
                            DisableInternalBinLog = true } })
            project.ProjFile

    let assemblyPath (project: ProjectInfo) tfm =
        Path.GetFullPath(Path.Combine(Path.GetDirectoryName(project.ProjFile), "bin", configuration, tfm, project.Name + ".dll"))
    let sha path = File.ReadAllBytes(path) |> SHA256.HashData |> Convert.ToHexString
    let coreAssembly = assemblyPath CoreProject "netstandard2.0"
    let versoAssembly = assemblyPath VersoProject "net8.0"
    let manifest =
        {| coreVersion = CoreProject.PackageVersionTag
           versoVersion = VersoProject.PackageVersionTag
           configuration = configuration
           coreAssembly = coreAssembly
           versoAssembly = versoAssembly
           coreSha256 = sha coreAssembly
           versoSha256 = sha versoAssembly |}
    File.WriteAllText(Path.Combine(artifacts, "packages.json"), JsonSerializer.Serialize(manifest, JsonSerializerOptions(WriteIndented = true)))

    // The same directory can be opened manually; no machine-specific path is committed.
    let config =
        XDocument(
            XElement(XName.Get "configuration",
                XElement(XName.Get "packageSources",
                    XElement(XName.Get "clear"),
                    XElement(XName.Get "add", XAttribute(XName.Get "key", "local"), XAttribute(XName.Get "value", feed)),
                    XElement(XName.Get "add", XAttribute(XName.Get "key", "nuget.org"), XAttribute(XName.Get "value", "https://api.nuget.org/v3/index.json")))))
    config.Save(Path.Combine(artifacts, "NuGet.Config"))
    let notebook = JsonNode.Parse(File.ReadAllText("tests/VersoTests/test.verso"))
    let cells = notebook["cells"].AsArray()
    cells[1]["source"] <- JsonValue.Create($"#!extension Plotly.NET.Verso {VersoProject.PackageVersionTag}\nopen Plotly.NET")
    let sourceCell = JsonObject()
    sourceCell["id"] <- JsonValue.Create(Guid.NewGuid().ToString())
    sourceCell["type"] <- JsonValue.Create("code")
    // Register the feed explicitly with the shared extension resolver.
    // This fixture choice is not a restriction on F# notebook setup.
    sourceCell["language"] <- JsonValue.Create("csharp")
    sourceCell["source"] <- JsonValue.Create("#i \"nuget: " + feed.Replace('\\', '/') + "\"")
    sourceCell["outputs"] <- JsonArray()
    cells.Insert(1, sourceCell)
    File.WriteAllText(Path.Combine(artifacts, "test.verso"), notebook.ToJsonString(JsonSerializerOptions(WriteIndented = true)))
    Trace.trace $"Verso integration packages and provenance: {artifacts}"
}

let runVersoIntegrationTests = BuildTask.create "RunVersoIntegrationTests" [packVersoIntegrationPackages] {
    DotNet.build
        (fun options ->
            { options with
                Configuration = DotNet.BuildConfiguration.fromString configuration
                MSBuildParams = { options.MSBuildParams with DisableInternalBinLog = true } })
        VersoIntegrationTestProject.ProjFile

    // ProcessStartInfo.ArgumentList avoids shell quoting across Windows and Unix.
    let executable = Path.GetFullPath($"tests/VersoTests/Integration/bin/{configuration}/net10.0/VersoIntegrationTests.dll")
    let start = Diagnostics.ProcessStartInfo("dotnet", UseShellExecute = false)
    start.ArgumentList.Add(executable)
    start.ArgumentList.Add(Path.GetFullPath("."))
    start.ArgumentList.Add(artifacts)
    use integrationProcess = Diagnostics.Process.Start(start)
    if not (integrationProcess.WaitForExit(20 * 60 * 1000)) then
        integrationProcess.Kill(true)
        failwith "Verso integration exceeded its 20 minute outer timeout."
    if integrationProcess.ExitCode <> 0 then
        failwith $"Verso integration failed with exit code {integrationProcess.ExitCode}. Inspect {artifacts}/runs."
}
