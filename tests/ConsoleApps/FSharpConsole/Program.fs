open System
open Plotly.NET

[<EntryPoint>]
let main _ =

    let pointCount = 500
    let xs = [| for i in 0 .. pointCount - 1 -> float i * 2.0 * Math.PI / float (pointCount - 1) |]
    let ys = xs |> Array.map sin

    let chartScatterEncodedPoC =
        Chart.Scatter(
            XEncoded = EncodedTypedArray.ofFloat64Array xs,
            YEncoded = EncodedTypedArray.ofFloat64Array ys,
            Mode = StyleParam.Mode.Lines_Markers,
            Name = "sin(x) via Chart.Scatter",
            UseDefaults = true
        )
        |> Chart.withTitle "H1 PoC: Chart.Scatter with encoded x/y"

    chartScatterEncodedPoC |> Chart.show

    0
