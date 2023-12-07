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
        Chart.Point([1,2], UseDefaults = false)
        Chart.Point([3,4], UseDefaults = false)
    ]
    |> Chart.combine
    |> Chart.withLegendStyle(
        Title = Title.init(
            Text = "Legend title (top right)",
            Side = StyleParam.Side.TopRight
        ),
        Orientation = StyleParam.Orientation.Horizontal
    )
    |> Chart.show
    0