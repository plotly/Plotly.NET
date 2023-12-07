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

[<EntryPoint>]
let main argv =
    Chart.BoxPlot(
        data = [-20; 1; 2; 3; 1; 2; 3; 3; 3; 3; 3; 1; 5; 20],
        orientation = StyleParam.Orientation.Vertical,
        SizeMode = StyleParam.BoxSizeMode.SD,
        UseDefaults = false
    )
    |> GenericChart.mapTrace (
        Trace2DStyle.BoxPlot(
            SDMultiple = 2.
        )
    )
    |> Chart.show
    0