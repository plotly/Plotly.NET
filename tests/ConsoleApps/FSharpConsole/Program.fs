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
    Chart.Point([1,2], UseDefaults = false, ShowLegend = true)
    |> Chart.withLayout(
        Layout.init(
            DragMode = StyleParam.DragMode.DrawRect,
            NewShape = (
                NewShape.init(
                    DrawDirection = StyleParam.DrawDirection.Diagonal,
                    Visible = StyleParam.Visible.True,
                    ShowLegend = true
                )
                |> NewShape.setLegendAnchor(2)
            )
        )
    )
    |> Chart.withLegend (
        Legend.init (
            X = 0.25,
            Y = 0.25
        ),
        Id = 1
    )
    |> Chart.withLegend (
        Legend.init (
            X = 0.75,
            Y = 0.75
        ),
        Id = 2
    )
    |> Chart.show
    0