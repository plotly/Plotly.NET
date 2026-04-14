open System
open Plotly.NET

[<EntryPoint>]
let main args =

    // Low-level demo: construct a scatter trace whose x/y come from base64-encoded
    // typed arrays (plotly.js >= 2.28.0 "data_array" form).
    let n = 500
    let xs = [| for i in 0 .. n - 1 -> float i * 2.0 * Math.PI / float (n - 1) |]
    let ys = xs |> Array.map sin

    let xEncoded = EncodedTypedArray.ofFloat64Array xs
    let yEncoded = EncodedTypedArray.ofFloat64Array ys

    Trace2D.initScatter (
        Trace2DStyle.Scatter(
            Name     = "sin (encoded)",
            Mode     = StyleParam.Mode.Lines_Markers,
            XEncoded = xEncoded,
            YEncoded = yEncoded
        )
    )
    |> GenericChart.ofTraceObject true
    |> Chart.show

    0
