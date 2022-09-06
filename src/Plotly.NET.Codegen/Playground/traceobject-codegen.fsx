#load "../Common.fs"
#load "../TraceObjects.fs"
open Common
open Plotly.NET.TraceObjects
open System.Text
open System.Text.RegularExpressions
open System.IO


let indicator = TraceObjectAbstraction.parseSourceFile @"C:\Users\schne\source\repos\plotly\Plotly.NET\src\Plotly.NET\Traces\ObjectAbstractions\Indicator.fs"

TraceObjectAbstraction.createCSharpSourceFile indicator

let sourceFiles =
    Directory.EnumerateFiles @"C:\Users\schne\source\repos\plotly\Plotly.NET\src\Plotly.NET\Traces\ObjectAbstractions\"
    |> Seq.cast<string>
    |> Array.ofSeq

let targetFiles = 
    sourceFiles
    |> Array.map (fun path -> 
        path
            .Replace(@"C:\Users\schne\source\repos\plotly\Plotly.NET\src\Plotly.NET\Traces\ObjectAbstractions\", @"C:\Users\schne\source\repos\plotly\Plotly.NET\src\Plotly.NET.CSharp\ObjectAbstractions\TraceObjects\")
            .Replace(".fs", ".cs")
    )
Array.zip sourceFiles targetFiles
|> Array.iter (fun (source, target) ->
    let classes = TraceObjectAbstraction.parseSourceFile source
    let targetFile = TraceObjectAbstraction.createCSharpSourceFile classes
    File.WriteAllText(target, targetFile)
)