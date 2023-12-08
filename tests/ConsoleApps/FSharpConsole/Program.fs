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
    Chart.Line(
        x = [1; 2; 3; 4],
        y = [1; 1; 2; 3], 
        UseDefaults = false
    )
    |> Chart.withXAxis(
        LinearAxis.init(
            Anchor = StyleParam.LinearAxisId.Y 1,
            Ticks = StyleParam.TickOptions.Inside,
            TickLabelPosition = StyleParam.TickLabelPosition.Inside
        )
    )
    |> Chart.withYAxis(
        LinearAxis.init(
            Anchor = StyleParam.LinearAxisId.X 1,
            InsideRange = StyleParam.Range.ofMinMax(1, 3)
        )
    )
    |> Chart.show
    Chart.Line(
        x = [1; 2; 3; 4],
        y = [1; 1; 2; 3], 
        UseDefaults = false
    )
    |> Chart.withXAxis(
        LinearAxis.init(
            Anchor = StyleParam.LinearAxisId.Y 1,
            InsideRange = StyleParam.Range.ofMinMax(1, 3)
        )
    )
    |> Chart.withYAxis(
        LinearAxis.init(
            Anchor = StyleParam.LinearAxisId.X 1,
            Ticks = StyleParam.TickOptions.Inside,
            TickLabelPosition = StyleParam.TickLabelPosition.Inside
        )
    )
    |> Chart.show
    0