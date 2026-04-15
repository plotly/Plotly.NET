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

    let fullyEncodedBoxPlot =
        Trace2D.initBoxPlot (
            Trace2DStyle.BoxPlot(
                Name = "encoded boxplot",
                XEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0 |],
                IdsEncoded = EncodedTypedArray.ofInt32Array [| 21; 22 |],
                CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 31.0; 32.0 |],
                SelectedPointsEncoded = EncodedTypedArray.ofInt32Array [| 1 |],
                MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 41.0; 42.0 |],
                Q1Encoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0 |],
                MedianEncoded = EncodedTypedArray.ofFloat64Array [| 1.5; 2.5 |],
                Q3Encoded = EncodedTypedArray.ofFloat64Array [| 2.0; 3.0 |],
                LowerFenceEncoded = EncodedTypedArray.ofFloat64Array [| 0.5; 1.5 |],
                UpperFenceEncoded = EncodedTypedArray.ofFloat64Array [| 2.5; 3.5 |],
                NotchSpanEncoded = EncodedTypedArray.ofFloat64Array [| 0.2; 0.3 |],
                MeanEncoded = EncodedTypedArray.ofFloat64Array [| 1.6; 2.6 |],
                SDEncoded = EncodedTypedArray.ofFloat64Array [| 0.4; 0.5 |]
            )
        )
        |> GenericChart.ofTraceObject true
        |> Chart.withTitle "Fully encoded boxplot"

    let fullyEncodedCandlestick =
        Trace2D.initCandlestick (
            Trace2DStyle.Candlestick(
                Name = "encoded candlestick",
                XEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
                IdsEncoded = EncodedTypedArray.ofInt32Array [| 111; 112; 113 |],
                CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 121.0; 122.0; 123.0 |],
                SelectedPointsEncoded = EncodedTypedArray.ofInt32Array [| 0; 2 |],
                MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 131.0; 132.0; 133.0 |],
                OpenEncoded = EncodedTypedArray.ofFloat64Array [| 20.0; 21.0; 22.0 |],
                HighEncoded = EncodedTypedArray.ofFloat64Array [| 25.0; 26.0; 27.0 |],
                LowEncoded = EncodedTypedArray.ofFloat64Array [| 18.0; 19.0; 20.0 |],
                CloseEncoded = EncodedTypedArray.ofFloat64Array [| 22.0; 23.0; 24.0 |]
            )
        )
        |> GenericChart.ofTraceObject true
        |> Chart.withTitle "Fully encoded candlestick"

    let fullyEncodedHeatmap =
        Trace2D.initHeatmap (
            Trace2DStyle.Heatmap(
                Name = "encoded heatmap",
                XEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
                YEncoded = EncodedTypedArray.ofFloat64Array [| 10.0; 20.0 |],
                ZEncoded = EncodedTypedArray.ofFloat64Array([| 1.0; 2.0; 3.0; 4.0; 5.0; 6.0 |], shape = [ 2; 3 ]),
                IdsEncoded = EncodedTypedArray.ofInt32Array [| 201; 202 |],
                MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 11.0; 12.0; 13.0; 14.0; 15.0; 16.0 |],
                CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 21.0; 22.0 |]
            )
        )
        |> GenericChart.ofTraceObject true
        |> Chart.withTitle "Fully encoded heatmap"

    simpleEncodedScatter |> Chart.show
    fullyEncodedScatterWithErrorBars |> Chart.show
    fullyEncodedBar |> Chart.show
    fullyEncodedBoxPlot |> Chart.show
    fullyEncodedCandlestick |> Chart.show
    fullyEncodedHeatmap |> Chart.show

    0
