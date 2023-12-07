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
    Chart.Point([1,2], UseDefaults = false)
    |> Chart.withXAxis(
        LinearAxis.init(
            ScaleAnchor = StyleParam.ScaleAnchor.False
        )
    )
    |> Chart.show
    0