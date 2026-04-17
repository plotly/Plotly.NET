#I "../../../../tests/ConsoleApps/CSharpConsole/bin/Debug/net10.0"
#r "DynamicObj.dll"
#r "Fable.Core.dll"
#r "Giraffe.ViewEngine.dll"
#r "Newtonsoft.Json.dll"
#r "Plotly.NET.dll"
#r "Plotly.NET.CSharp.dll"

open System
open System.IO
open System.Text.RegularExpressions
open Plotly.NET

type Section =
    | Html
    | All
    | Data
    | Layout
    | Config
    | PlotlyCall

let rawArgs =
    fsi.CommandLineArgs
    |> Array.skip 1
    |> Array.filter (fun arg -> arg <> "--")

let printUsage () =
    eprintfn
        "Usage: dotnet fsi .claude/skills/chart-baseline-generation/scripts/generate-chart-markup.fsx -- [html|all|data|layout|config|plotly-call] [--write-html <output-path>]"

let parseSection =
    function
    | None -> All
    | Some "html" -> Html
    | Some "all" -> All
    | Some "data" -> Data
    | Some "layout" -> Layout
    | Some "config" -> Config
    | Some "plotly-call" -> PlotlyCall
    | Some value -> failwith $"Unknown section: {value}"

let formatSection name value =
    $"=== {name} ===\n{value}"

let findSection (html: string) name pattern =
    let matchResult = Regex.Match(html, pattern, RegexOptions.Singleline)

    if matchResult.Success then
        formatSection name (matchResult.Value.Trim())
    else
        formatSection name "<not found>"

let extractSections (html: string) =
    [
        "data", @"var data = .*?;"
        "layout", @"var layout = .*?;"
        "config", @"var config = .*?;"
        "plotly-call", @"Plotly\.newPlot\(.*?\);"
    ]
    |> List.map (fun (name, pattern) -> name, findSection html name pattern)
    |> Map.ofList

let parseArgs (args: string array) =
    let rec loop remaining requestedSection outputPath =
        match remaining with
        | [||] -> parseSection requestedSection, outputPath
        | [| "--write-html" |] -> failwith "Missing output path after --write-html"
        | [| "--write-html"; path |] ->
            parseSection requestedSection, Some path
        | _ when remaining[0] = "--write-html" ->
            loop remaining[2..] requestedSection (Some remaining[1])
        | _ when requestedSection.IsSome ->
            failwith $"Unexpected argument: {remaining[0]}"
        | _ ->
            loop remaining[1..] (Some remaining[0]) outputPath

    loop args None None

let createChart () : GenericChart =
    // Replace this chart while investigating a specific baseline.
    //
    // For F# tests, prefer the core F# API:
    // Chart.Point(x = [ 0.0; 1.0 ], y = [ 1.0; 4.0 ], UseDefaults = false)
    //
    // For C# tests, use the C# wrapper in this same script:
    // Plotly.NET.CSharp.Chart.Point<double, double, string>(
    //     x = [| 0.0; 1.0 |],
    //     y = [| 1.0; 4.0 |],
    //     Name = "points",
    //     UseDefaults = false
    // )
    Chart.Point(
        x = [ 0.0; 1.0; 2.0; 3.0 ],
        y = [ 1.0; 4.0; 9.0; 16.0 ],
        Name = "points",
        UseDefaults = false
    )

try
    let requestedSection, outputPath = parseArgs rawArgs
    let markup = createChart () |> GenericChart.toChartHTML
    let sections = extractSections markup

    match outputPath with
    | Some path ->
        let fullOutputPath = Path.GetFullPath(path)
        let outputDirectory = Path.GetDirectoryName(fullOutputPath)

        if not (String.IsNullOrWhiteSpace(outputDirectory)) then
            Directory.CreateDirectory(outputDirectory) |> ignore

        File.WriteAllText(fullOutputPath, markup)
        eprintfn "Wrote chart markup to %s" fullOutputPath
    | None -> ()

    let printSection key =
        sections.[key] |> printfn "%s"

    match requestedSection with
    | Html -> printfn "%s" markup
    | All ->
        [ "data"; "layout"; "config"; "plotly-call" ]
        |> List.iter printSection
    | Data -> printSection "data"
    | Layout -> printSection "layout"
    | Config -> printSection "config"
    | PlotlyCall -> printSection "plotly-call"
with ex ->
    printUsage ()
    eprintfn "%s" ex.Message
    exit 1
