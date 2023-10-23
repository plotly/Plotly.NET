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
    [
        Chart.Point([1,20], UseDefaults = false)
        |> Chart.withLegendAnchor 1
        Chart.Point([1,30], UseDefaults = false)
        |> Chart.withLegendAnchor 2
    ]
    |> Chart.combine
    |> Chart.withLegend(
        Legend.init(
            X = 0,
            Y = 1
        ),
        Id = 1
    )
    |> Chart.withLegend(
        Legend.init(
            X = 0,
            Y = 0
        ),
        Id = 2
    )
    |> Chart.show
    0