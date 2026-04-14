open System
open Plotly.NET
open Plotly.NET.TraceObjects

[<EntryPoint>]
let main args =

    // Low-level demo: construct a scatter trace whose x/y come from base64-encoded
    // typed arrays (plotly.js >= 2.28.0 "data_array" form).
    let n = 500
    let xs = [| for i in 0 .. n - 1 -> float i * 2.0 * Math.PI / float (n - 1) |]
    let ys = xs |> Array.map sin

    let simpleEncodedScatter =
        Trace2D.initScatter (
            Trace2DStyle.Scatter(
                Name = "sin (encoded)",
                Mode = StyleParam.Mode.Lines_Markers,
                XEncoded = EncodedTypedArray.ofFloat64Array xs,
                YEncoded = EncodedTypedArray.ofFloat64Array ys
            )
        )
        |> GenericChart.ofTraceObject true
        |> Chart.withTitle "Encoded scatter x/y"

    let fullyEncodedScatterWithErrorBars =
        Trace2D.initScatter (
            Trace2DStyle.Scatter(
                Name = "encoded scatter + error bars",
                Mode = StyleParam.Mode.Lines_Markers,
                XEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
                YEncoded = EncodedTypedArray.ofFloat64Array [| 4.0; 5.0; 6.0 |],
                IdsEncoded = EncodedTypedArray.ofInt32Array [| 101; 102; 103 |],
                CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 10.0; 20.0; 30.0 |],
                SelectedPointsEncoded = EncodedTypedArray.ofInt32Array [| 0; 2 |],
                MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 7.0; 8.0; 9.0 |],
                XError =
                    Error.init(
                        Type = StyleParam.ErrorType.Data,
                        ArrayEncoded = EncodedTypedArray.ofFloat64Array [| 0.1; 0.2; 0.3 |]
                    ),
                YError =
                    Error.init(
                        Type = StyleParam.ErrorType.Data,
                        ArrayEncoded = EncodedTypedArray.ofFloat64Array [| 0.4; 0.5; 0.6 |],
                        ArrayminusEncoded = EncodedTypedArray.ofFloat64Array [| 0.3; 0.2; 0.1 |]
                    )
            )
        )
        |> GenericChart.ofTraceObject true
        |> Chart.withTitle "Fully encoded scatter with error bars"

    let fullyEncodedBar =
        Trace2D.initBar (
            Trace2DStyle.Bar(
                Name = "encoded bar",
                XEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
                YEncoded = EncodedTypedArray.ofFloat64Array [| 4.0; 5.0; 6.0 |],
                IdsEncoded = EncodedTypedArray.ofInt32Array [| 101; 102; 103 |],
                CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 10.0; 20.0; 30.0 |],
                SelectedPointsEncoded = EncodedTypedArray.ofInt32Array [| 0; 2 |],
                MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 7.0; 8.0; 9.0 |],
                MultiWidthEncoded = EncodedTypedArray.ofFloat64Array [| 0.3; 0.4; 0.5 |],
                MultiOffsetEncoded = EncodedTypedArray.ofFloat64Array [| -0.1; 0.0; 0.1 |]
            )
        )
        |> GenericChart.ofTraceObject true
        |> Chart.withTitle "Fully encoded bar"

    simpleEncodedScatter |> Chart.show
    fullyEncodedScatterWithErrorBars |> Chart.show
    fullyEncodedBar |> Chart.show

    0
