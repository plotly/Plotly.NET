open System
open System.IO
open System.Text.RegularExpressions

type Section =
    | All
    | Data
    | Layout
    | Config
    | PlotlyCall

let usage () =
    failwith
        "Usage: dotnet fsi .codex/skills/chart-baseline-generation/scripts/extract-chart-segments.fsx -- <input-file> [all|data|layout|config|plotly-call]"

let parseSection =
    function
    | None -> All
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

let argv =
    fsi.CommandLineArgs
    |> Array.skip 1
    |> Array.toList
    |> function
        | "--" :: rest -> rest
        | rest -> rest

let inputFile, requestedSection =
    match argv with
    | [ inputFile ] -> inputFile, All
    | [ inputFile; section ] -> inputFile, parseSection (Some section)
    | _ -> usage ()

if not (File.Exists inputFile) then
    failwith $"Input file not found: {inputFile}"

let html = File.ReadAllText inputFile
let sections = extractSections html

let printSection key =
    sections.[key] |> printfn "%s"

match requestedSection with
| All ->
    [ "data"; "layout"; "config"; "plotly-call" ]
    |> List.iter printSection
| Data -> printSection "data"
| Layout -> printSection "layout"
| Config -> printSection "config"
| PlotlyCall -> printSection "plotly-call"
