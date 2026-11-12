namespace Plotly.NET.Verso.IntegrationTests

open System
open System.IO
open System.IO.Compression
open System.Text.Json
open System.Text.Json.Nodes
open System.Xml.Linq
open Infrastructure

module Notebook =
    let private node (value: string) : JsonNode = JsonValue.Create(value)

    let cell source =
        let result = new JsonObject()
        result["id"] <- node (Guid.NewGuid().ToString())
        result["type"] <- node "code"
        result["language"] <- node "fsharp"
        result["source"] <- node source
        result["outputs"] <- new JsonArray()
        result

    let document (cells: JsonObject list) =
        let metadata = new JsonObject()
        metadata["title"] <- node "Plotly.NET.Verso packaged integration"
        metadata["defaultKernel"] <- node "fsharp"
        let result = new JsonObject()
        result["verso"] <- node "1.0"
        result["metadata"] <- metadata
        result["cells"] <- new JsonArray(cells |> List.map (fun c -> c :> JsonNode) |> List.toArray)
        result

    let write path (doc: JsonNode) =
        File.WriteAllText(path, doc.ToJsonString(JsonSerializerOptions(WriteIndented = true)))

    let validatePackages (environment: TestEnvironment) =
        let manifest = environment.Manifest
        let feed = Path.Combine(environment.RunDirectory, "feed")
        Directory.CreateDirectory(feed) |> ignore
        for name, version, tfm, expected in
            [ "Plotly.NET", manifest.coreVersion, "netstandard2.0", manifest.coreSha256
              "Plotly.NET.Verso", manifest.versoVersion, "net8.0", manifest.versoSha256 ] do
            let filename = $"{name}.{version}.nupkg"
            let destination = Path.Combine(feed, filename)
            File.Copy(Path.Combine(environment.Artifacts, "feed", filename), destination)
            use package = ZipFile.OpenRead(destination)
            let entry = package.GetEntry($"lib/{tfm}/{name}.dll")
            require (not (isNull entry)) $"{filename} lacks its expected lib/{tfm} assembly."
            use content = entry.Open()
            use buffer = new MemoryStream()
            content.CopyTo(buffer)
            require (sha256(buffer.ToArray()) = expected) $"{filename} does not contain the locally built assembly."
            let nuspec = package.Entries |> Seq.find (fun e -> e.FullName.EndsWith(".nuspec", StringComparison.Ordinal))
            use nuspecStream = nuspec.Open()
            let metadata = XDocument.Load(nuspecStream).Root.Elements() |> Seq.find (fun e -> e.Name.LocalName = "metadata")
            let property key = metadata.Elements() |> Seq.find (fun e -> e.Name.LocalName = key) |> fun e -> e.Value
            require (property "id" = name && property "version" = version) $"Unexpected package identity in {filename}."
            if name = "Plotly.NET.Verso" then
                let deps = metadata.Descendants() |> Seq.filter (fun e -> e.Name.LocalName = "dependency") |> Seq.toArray
                require (deps |> Array.exists (fun e -> e.Attribute(XName.Get "id").Value = "Verso.Abstractions" && e.Attribute(XName.Get "version").Value.Contains("1.2.3"))) "Verso.Abstractions 1.2.3 is missing from the package."
                require (deps |> Array.exists (fun e -> e.Attribute(XName.Get "id").Value = "Plotly.NET" && e.Attribute(XName.Get "version").Value = "[6.0.0, 7.0.0)")) "Plotly.NET package dependency must advertise the supported [6.0.0, 7.0.0) range."
                require (deps |> Array.forall (fun e -> e.Attribute(XName.Get "id").Value <> "Verso.Testing")) "Test dependencies leaked into the shipping package."

    let createFixtures (environment: TestEnvironment) =
        let setup = $"#!extension Plotly.NET.Verso {environment.Manifest.versoVersion}\nopen Plotly.NET"
        let provenance = """open System
open System.IO
open System.Security.Cryptography
let hashFile path = Convert.ToHexString(SHA256.HashData(File.ReadAllBytes(path)))
for name in [ "Plotly.NET"; "Plotly.NET.Verso" ] do
    let assemblies = AppDomain.CurrentDomain.GetAssemblies() |> Array.filter (fun a -> a.GetName().Name = name)
    if assemblies.Length = 0 then failwith ("Missing assembly: " + name)
    for assembly in assemblies do
        printfn "ASSEMBLY|%s|%s|%s" name (hashFile assembly.Location) assembly.Location
"""
        let sources =
            [ "Chart.Line([1;2;3], [4;6;5], UseDefaults = false)"
              "Chart.combine [ Chart.Line([1;2;3], [1;2;3], UseDefaults = false); Chart.Point([1;2;3], [3;1;2], UseDefaults = false) ]" ]
        let online = Path.Combine(environment.RunDirectory, "online.verso")
        document ([ cell setup; cell provenance ] @ (sources |> List.map cell)) |> write online
        let offline = Path.Combine(environment.RunDirectory, "offline.verso")
        let full = "Chart.Line([1;2;3], [4;6;5], UseDefaults = false)\n|> Chart.withDisplayOptions (DisplayOptions.init(PlotlyJSReference = Full))"
        document [ cell setup; cell provenance; cell full ] |> write offline
        online, offline

    let validateProvenance (environment: TestEnvironment) (provenance: string) =
        for name, expected in [ "Plotly.NET", environment.Manifest.coreSha256; "Plotly.NET.Verso", environment.Manifest.versoSha256 ] do
            let lines = provenance.Split('\n') |> Array.map (fun l -> l.TrimEnd('\r')) |> Array.filter (fun l -> l.StartsWith("ASSEMBLY|" + name + "|", StringComparison.Ordinal))
            require (lines.Length > 0) $"The real kernel did not report {name} provenance."
            for line in lines do
                let parts = line.Split('|', 4)
                require (parts[2] = expected) $"Kernel loaded a stale or public {name} assembly: {line}"
                require (Path.GetFullPath(parts[3]).StartsWith(environment.RunDirectory + string Path.DirectorySeparatorChar, StringComparison.OrdinalIgnoreCase)) $"Kernel loaded {name} outside the isolated run: {line}"

    let validateResult (environment: TestEnvironment) resultPath expectedCharts =
        let root = JsonNode.Parse(File.ReadAllText(resultPath))
        let summary = root["summary"]
        require (summary["failed"].GetValue<int>() = 0) $"Verso reported failed cells in {resultPath}."
        require (summary["succeeded"].GetValue<int>() = summary["total"].GetValue<int>()) $"Verso did not execute every fixture cell in {resultPath}."
        let outputs =
            root["cells"].AsArray()
            |> Seq.collect (fun c -> c["outputs"].AsArray())
            |> Seq.toArray
        for output in outputs do
            let error = output["isError"]
            require (isNull error || not (error.GetValue<bool>())) $"Verso emitted an error in {resultPath}."
        let contents = outputs |> Array.map (fun o -> o["content"].GetValue<string>())
        let charts = contents |> Array.filter (fun s -> s.Contains("plotly-net-verso"))
        require (charts.Length = expectedCharts) $"Expected {expectedCharts} formatted charts, found {charts.Length} in {resultPath}."
        contents |> String.concat "\n" |> validateProvenance environment
