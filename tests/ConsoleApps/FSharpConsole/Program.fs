open System
open Deedle
open System.IO
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open Plotly.NET.ConfigObjects
open DynamicObj
open Giraffe.ViewEngine
open Newtonsoft.Json

let getZeroCollection n : float []=
    Array.zeroCreate n 

[<EntryPoint>]
let main argv =
    Chart.Histogram2DContour(
        MultiX = [["A";"A";"A";"B";"B"];["AA"; "AA"; "AB"; "BA"; "BB"]],
        MultiY = [["A";"A";"A";"B";"B"];["AA"; "AA"; "AB"; "BA"; "BB"]],
        UseDefaults = false
    )
    |> Chart.show
    0