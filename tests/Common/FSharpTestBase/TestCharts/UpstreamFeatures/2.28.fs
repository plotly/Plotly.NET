module PlotlyJS_2_28_TestCharts

open Plotly.NET
open Plotly.NET.TraceObjects

module ``Encoded typed arrays`` =

    let ``Scatter x/y encoded`` =
        let xEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0 |]
        let yEncoded = EncodedTypedArray.ofFloat64Array [| 3.0; 4.0 |]

        Trace2D.initScatter (
            Trace2DStyle.Scatter(
                Name = "encoded scatter",
                Mode = StyleParam.Mode.Lines_Markers,
                XEncoded = xEncoded,
                YEncoded = yEncoded
            )
        )
        |> GenericChart.ofTraceObject true

    let ``Scatter fully encoded with error bars`` =
        let xEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |]
        let yEncoded = EncodedTypedArray.ofFloat64Array [| 4.0; 5.0; 6.0 |]
        let idsEncoded = EncodedTypedArray.ofInt32Array [| 101; 102; 103 |]
        let customDataEncoded = EncodedTypedArray.ofFloat64Array [| 10.0; 20.0; 30.0 |]
        let selectedPointsEncoded = EncodedTypedArray.ofInt32Array [| 0; 2 |]
        let multiTextEncoded = EncodedTypedArray.ofFloat64Array [| 7.0; 8.0; 9.0 |]
        let xErrorEncoded = EncodedTypedArray.ofFloat64Array [| 0.1; 0.2; 0.3 |]
        let yErrorEncoded = EncodedTypedArray.ofFloat64Array [| 0.4; 0.5; 0.6 |]
        let yErrorMinusEncoded = EncodedTypedArray.ofFloat64Array [| 0.3; 0.2; 0.1 |]

        Trace2D.initScatter (
            Trace2DStyle.Scatter(
                Name = "encoded scatter + error bars",
                Mode = StyleParam.Mode.Lines_Markers,
                XEncoded = xEncoded,
                YEncoded = yEncoded,
                IdsEncoded = idsEncoded,
                CustomDataEncoded = customDataEncoded,
                SelectedPointsEncoded = selectedPointsEncoded,
                MultiTextEncoded = multiTextEncoded,
                XError =
                    Error.init(
                        Type = StyleParam.ErrorType.Data,
                        ArrayEncoded = xErrorEncoded
                    ),
                YError =
                    Error.init(
                        Type = StyleParam.ErrorType.Data,
                        ArrayEncoded = yErrorEncoded,
                        ArrayminusEncoded = yErrorMinusEncoded
                    )
            )
        )
        |> GenericChart.ofTraceObject true

module ``Encoded typed arrays on bar-family traces`` =

    let ``Bar with encoded arrays`` =
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

    let ``Funnel with encoded arrays`` =
        Trace2D.initFunnel (
            Trace2DStyle.Funnel(
                Name = "encoded funnel",
                XEncoded = EncodedTypedArray.ofFloat64Array [| 5.0; 4.0; 3.0 |],
                YEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
                IdsEncoded = EncodedTypedArray.ofInt32Array [| 11; 12; 13 |],
                CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 21.0; 22.0; 23.0 |],
                SelectedPointsEncoded = EncodedTypedArray.ofInt32Array [| 0; 2 |],
                MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 31.0; 32.0; 33.0 |]
            )
        )
        |> GenericChart.ofTraceObject true

    let ``Waterfall with encoded arrays`` =
        Trace2D.initWaterfall (
            Trace2DStyle.Waterfall(
                Name = "encoded waterfall",
                XEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
                YEncoded = EncodedTypedArray.ofFloat64Array [| 4.0; 5.0; 6.0 |],
                IdsEncoded = EncodedTypedArray.ofInt32Array [| 101; 102; 103 |],
                CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 10.0; 20.0; 30.0 |],
                SelectedPointsEncoded = EncodedTypedArray.ofInt32Array [| 0; 2 |],
                MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 7.0; 8.0; 9.0 |],
                MultiOffsetEncoded = EncodedTypedArray.ofFloat64Array [| -0.1; 0.0; 0.1 |]
            )
        )
        |> GenericChart.ofTraceObject true
