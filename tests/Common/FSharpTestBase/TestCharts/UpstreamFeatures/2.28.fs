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

module ``Encoded typed arrays on chart helper constructors`` =

    let ``Point encoded constructor`` =
        Chart.Point(
            xEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
            yEncoded = EncodedTypedArray.ofFloat64Array [| 4.0; 5.0; 6.0 |],
            Name = "encoded point",
            UseDefaults = false
        )

    let ``Line encoded constructor`` =
        Chart.Line(
            xEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0 |],
            yEncoded = EncodedTypedArray.ofFloat64Array [| 3.0; 4.0 |],
            Name = "encoded line",
            UseDefaults = false
        )

    let ``Spline encoded constructor`` =
        Chart.Spline(
            xEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
            yEncoded = EncodedTypedArray.ofFloat64Array [| 3.0; 1.0; 4.0 |],
            Name = "encoded spline",
            Smoothing = 0.7,
            UseDefaults = false
        )

    let ``Bubble encoded constructor`` =
        Chart.Bubble(
            xEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
            yEncoded = EncodedTypedArray.ofFloat64Array [| 6.0; 5.0; 4.0 |],
            sizes = [ 10; 20; 30 ],
            Name = "encoded bubble",
            UseDefaults = false
        )

    let ``Area encoded constructor`` =
        Chart.Area(
            xEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
            yEncoded = EncodedTypedArray.ofFloat64Array [| 2.0; 4.0; 3.0 |],
            Name = "encoded area",
            UseDefaults = false
        )

    let ``SplineArea encoded constructor`` =
        Chart.SplineArea(
            xEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
            yEncoded = EncodedTypedArray.ofFloat64Array [| 3.0; 2.0; 5.0 |],
            Name = "encoded spline area",
            Smoothing = 0.6,
            UseDefaults = false
        )

    let ``StackedArea encoded constructor`` =
        Chart.StackedArea(
            xEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
            yEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 3.0; 2.0 |],
            Name = "encoded stacked area",
            UseDefaults = false
        )

    let ``Range encoded constructor`` =
        Chart.Range(
            xEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0 |],
            yEncoded = EncodedTypedArray.ofFloat64Array [| 3.0; 4.0 |],
            upperEncoded = EncodedTypedArray.ofFloat64Array [| 4.0; 5.0 |],
            lowerEncoded = EncodedTypedArray.ofFloat64Array [| 2.0; 3.0 |],
            mode = StyleParam.Mode.Lines,
            Name = "encoded range",
            UseDefaults = false
        )

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

module ``Encoded typed arrays on 1-D trace families`` =

    let ``Histogram with encoded arrays`` =
        Trace2D.initHistogram (
            Trace2DStyle.Histogram(
                Name = "encoded histogram",
                XEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 2.0; 3.0 |],
                YEncoded = EncodedTypedArray.ofFloat64Array [| 5.0; 6.0; 7.0; 8.0 |],
                IdsEncoded = EncodedTypedArray.ofInt32Array [| 1; 2; 3; 4 |],
                CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 10.0; 20.0; 30.0; 40.0 |],
                SelectedPointsEncoded = EncodedTypedArray.ofInt32Array [| 0; 3 |],
                MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 9.0; 8.0; 7.0; 6.0 |]
            )
        )
        |> GenericChart.ofTraceObject true

    let ``BoxPlot with encoded arrays`` =
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

    let ``Violin with encoded arrays`` =
        Trace2D.initViolin (
            Trace2DStyle.Violin(
                Name = "encoded violin",
                XEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 1.0; 2.0; 2.0 |],
                YEncoded = EncodedTypedArray.ofFloat64Array [| 3.0; 4.0; 5.0; 6.0 |],
                IdsEncoded = EncodedTypedArray.ofInt32Array [| 51; 52; 53; 54 |],
                CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 61.0; 62.0; 63.0; 64.0 |],
                SelectedPointsEncoded = EncodedTypedArray.ofInt32Array [| 0; 2 |],
                MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 71.0; 72.0; 73.0; 74.0 |]
            )
        )
        |> GenericChart.ofTraceObject true

    let ``OHLC with encoded arrays`` =
        Trace2D.initOHLC (
            Trace2DStyle.OHLC(
                Name = "encoded ohlc",
                XEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
                IdsEncoded = EncodedTypedArray.ofInt32Array [| 81; 82; 83 |],
                CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 91.0; 92.0; 93.0 |],
                SelectedPointsEncoded = EncodedTypedArray.ofInt32Array [| 1 |],
                MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 101.0; 102.0; 103.0 |],
                OpenEncoded = EncodedTypedArray.ofFloat64Array [| 10.0; 11.0; 12.0 |],
                HighEncoded = EncodedTypedArray.ofFloat64Array [| 15.0; 16.0; 17.0 |],
                LowEncoded = EncodedTypedArray.ofFloat64Array [| 8.0; 9.0; 10.0 |],
                CloseEncoded = EncodedTypedArray.ofFloat64Array [| 12.0; 13.0; 14.0 |]
            )
        )
        |> GenericChart.ofTraceObject true

    let ``Candlestick with encoded arrays`` =
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

    let ``Splom with encoded arrays`` =
        Trace2D.initSplom (
            Trace2DStyle.Splom(
                Name = "encoded splom",
                Dimensions = [
                    Dimension.initSplom(Label = "A", Values = [ 1.0; 2.0; 3.0 ])
                    Dimension.initSplom(Label = "B", Values = [ 4.0; 5.0; 6.0 ])
                ],
                IdsEncoded = EncodedTypedArray.ofInt32Array [| 141; 142; 143 |],
                CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 151.0; 152.0; 153.0 |],
                SelectedPointsEncoded = EncodedTypedArray.ofInt32Array [| 2 |],
                MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 161.0; 162.0; 163.0 |]
            )
        )
        |> GenericChart.ofTraceObject true

module ``Encoded typed arrays on matrix trace families`` =

    let ``Histogram2D with encoded arrays`` =
        Trace2D.initHistogram2D (
            Trace2DStyle.Histogram2D(
                Name = "encoded histogram2d",
                XEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
                YEncoded = EncodedTypedArray.ofFloat64Array [| 4.0; 5.0; 6.0 |],
                ZEncoded = EncodedTypedArray.ofFloat64Array([| 1.0; 2.0; 3.0; 4.0; 5.0; 6.0 |], shape = [ 2; 3 ]),
                IdsEncoded = EncodedTypedArray.ofInt32Array [| 11; 12; 13 |],
                CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 21.0; 22.0; 23.0 |]
            )
        )
        |> GenericChart.ofTraceObject true

    let ``Histogram2DContour with encoded arrays`` =
        Trace2D.initHistogram2DContour (
            Trace2DStyle.Histogram2DContour(
                Name = "encoded histogram2dcontour",
                XEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
                YEncoded = EncodedTypedArray.ofFloat64Array [| 4.0; 5.0; 6.0 |],
                ZEncoded = EncodedTypedArray.ofFloat64Array([| 1.0; 2.0; 3.0; 4.0 |], shape = [ 2; 2 ]),
                IdsEncoded = EncodedTypedArray.ofInt32Array [| 31; 32; 33 |],
                CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 41.0; 42.0; 43.0 |]
            )
        )
        |> GenericChart.ofTraceObject true

    let ``Heatmap with encoded arrays`` =
        Trace2D.initHeatmap (
            Trace2DStyle.Heatmap(
                Name = "encoded heatmap",
                XEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
                YEncoded = EncodedTypedArray.ofFloat64Array [| 10.0; 20.0 |],
                ZEncoded = EncodedTypedArray.ofFloat64Array([| 1.0; 2.0; 3.0; 4.0; 5.0; 6.0 |], shape = [ 2; 3 ]),
                IdsEncoded = EncodedTypedArray.ofInt32Array [| 51; 52 |],
                MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 61.0; 62.0; 63.0; 64.0; 65.0; 66.0 |],
                CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 71.0; 72.0 |]
            )
        )
        |> GenericChart.ofTraceObject true

    let ``Contour with encoded arrays`` =
        Trace2D.initContour (
            Trace2DStyle.Contour(
                Name = "encoded contour",
                XEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
                YEncoded = EncodedTypedArray.ofFloat64Array [| 10.0; 20.0 |],
                ZEncoded = EncodedTypedArray.ofFloat64Array([| 1.0; 2.0; 3.0; 4.0; 5.0; 6.0 |], shape = [ 2; 3 ]),
                IdsEncoded = EncodedTypedArray.ofInt32Array [| 81; 82 |],
                MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 91.0; 92.0; 93.0; 94.0; 95.0; 96.0 |],
                CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 101.0; 102.0 |]
            )
        )
        |> GenericChart.ofTraceObject true

    let ``Image with encoded metadata arrays`` =
        Trace2D.initImage (
            Trace2DStyle.Image(
                Name = "encoded image metadata",
                Z = [
                    [ [ 255; 0; 0 ]; [ 0; 255; 0 ] ]
                    [ [ 0; 0; 255 ]; [ 255; 255; 0 ] ]
                ],
                IdsEncoded = EncodedTypedArray.ofInt32Array [| 111; 112 |],
                MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 121.0; 122.0 |],
                CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 131.0; 132.0 |]
            )
        )
        |> GenericChart.ofTraceObject true

module ``Encoded typed arrays on Trace3D families`` =

    let ``Scatter3D with encoded arrays`` =
        Trace3D.initScatter3D (
            Trace3DStyle.Scatter3D(
                Name = "encoded scatter3d",
                IdsEncoded = EncodedTypedArray.ofInt32Array [| 1; 2; 3 |],
                XEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
                YEncoded = EncodedTypedArray.ofFloat64Array [| 4.0; 5.0; 6.0 |],
                ZEncoded = EncodedTypedArray.ofFloat64Array [| 7.0; 8.0; 9.0 |],
                MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 10.0; 11.0; 12.0 |],
                CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 13.0; 14.0; 15.0 |]
            )
        )
        |> GenericChart.ofTraceObject true

    let ``Surface with encoded arrays`` =
        Trace3D.initSurface (
            Trace3DStyle.Surface(
                Name = "encoded surface",
                IdsEncoded = EncodedTypedArray.ofInt32Array [| 21; 22 |],
                XEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0 |],
                YEncoded = EncodedTypedArray.ofFloat64Array [| 10.0; 20.0 |],
                ZEncoded = EncodedTypedArray.ofFloat64Array([| 1.0; 2.0; 3.0; 4.0 |], shape = [ 2; 2 ]),
                MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 31.0; 32.0; 33.0; 34.0 |],
                CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 41.0; 42.0 |],
                OpacityScaleEncoded = EncodedTypedArray.ofFloat64Array([| 0.0; 1.0; 1.0; 0.2 |], shape = [ 2; 2 ])
            )
        )
        |> GenericChart.ofTraceObject true

    let ``Mesh3D with encoded arrays`` =
        Trace3D.initMesh3D (
            Trace3DStyle.Mesh3D(
                Name = "encoded mesh3d",
                IdsEncoded = EncodedTypedArray.ofInt32Array [| 51; 52; 53 |],
                XEncoded = EncodedTypedArray.ofFloat64Array [| 0.0; 1.0; 0.0 |],
                YEncoded = EncodedTypedArray.ofFloat64Array [| 0.0; 0.0; 1.0 |],
                ZEncoded = EncodedTypedArray.ofFloat64Array [| 0.0; 0.0; 0.0 |],
                IEncoded = EncodedTypedArray.ofInt32Array [| 0 |],
                JEncoded = EncodedTypedArray.ofInt32Array [| 1 |],
                KEncoded = EncodedTypedArray.ofInt32Array [| 2 |],
                IntensityEncoded = EncodedTypedArray.ofFloat64Array [| 0.1; 0.2; 0.3 |],
                MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 61.0; 62.0; 63.0 |],
                CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 71.0; 72.0; 73.0 |]
            )
        )
        |> GenericChart.ofTraceObject true

    let ``Cone with encoded arrays`` =
        Trace3D.initCone (
            Trace3DStyle.Cone(
                Name = "encoded cone",
                IdsEncoded = EncodedTypedArray.ofInt32Array [| 81; 82 |],
                XEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0 |],
                YEncoded = EncodedTypedArray.ofFloat64Array [| 3.0; 4.0 |],
                ZEncoded = EncodedTypedArray.ofFloat64Array [| 5.0; 6.0 |],
                UEncoded = EncodedTypedArray.ofFloat64Array [| 0.1; 0.2 |],
                VEncoded = EncodedTypedArray.ofFloat64Array [| 0.3; 0.4 |],
                WEncoded = EncodedTypedArray.ofFloat64Array [| 0.5; 0.6 |],
                MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 91.0; 92.0 |],
                CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 93.0; 94.0 |]
            )
        )
        |> GenericChart.ofTraceObject true

    let ``StreamTube with encoded arrays`` =
        Trace3D.initStreamTube (
            Trace3DStyle.StreamTube(
                Name = "encoded streamtube",
                IdsEncoded = EncodedTypedArray.ofInt32Array [| 101; 102 |],
                XEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0 |],
                YEncoded = EncodedTypedArray.ofFloat64Array [| 3.0; 4.0 |],
                ZEncoded = EncodedTypedArray.ofFloat64Array [| 5.0; 6.0 |],
                UEncoded = EncodedTypedArray.ofFloat64Array [| 0.1; 0.2 |],
                VEncoded = EncodedTypedArray.ofFloat64Array [| 0.3; 0.4 |],
                WEncoded = EncodedTypedArray.ofFloat64Array [| 0.5; 0.6 |],
                MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 111.0; 112.0 |],
                CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 113.0; 114.0 |]
            )
        )
        |> GenericChart.ofTraceObject true

    let ``Volume with encoded arrays`` =
        Trace3D.initVolume (
            Trace3DStyle.Volume(
                Name = "encoded volume",
                IdsEncoded = EncodedTypedArray.ofInt32Array [| 121; 122; 123 |],
                XEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
                YEncoded = EncodedTypedArray.ofFloat64Array [| 4.0; 5.0; 6.0 |],
                ZEncoded = EncodedTypedArray.ofFloat64Array [| 7.0; 8.0; 9.0 |],
                ValueEncoded = EncodedTypedArray.ofFloat64Array [| 0.1; 0.2; 0.3 |],
                MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 131.0; 132.0; 133.0 |],
                CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 141.0; 142.0; 143.0 |],
                OpacityScaleEncoded = EncodedTypedArray.ofFloat64Array([| 0.0; 1.0; 0.5; 0.2; 1.0; 1.0 |], shape = [ 3; 2 ])
            )
        )
        |> GenericChart.ofTraceObject true

    let ``IsoSurface with encoded arrays`` =
        Trace3D.initIsoSurface (
            Trace3DStyle.IsoSurface(
                Name = "encoded isosurface",
                IdsEncoded = EncodedTypedArray.ofInt32Array [| 151; 152; 153 |],
                XEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
                YEncoded = EncodedTypedArray.ofFloat64Array [| 4.0; 5.0; 6.0 |],
                ZEncoded = EncodedTypedArray.ofFloat64Array [| 7.0; 8.0; 9.0 |],
                ValueEncoded = EncodedTypedArray.ofFloat64Array [| 0.1; 0.2; 0.3 |],
                MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 161.0; 162.0; 163.0 |],
                CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 171.0; 172.0; 173.0 |],
                OpacityScaleEncoded = EncodedTypedArray.ofFloat64Array([| 0.0; 1.0; 0.5; 0.2; 1.0; 1.0 |], shape = [ 3; 2 ])
            )
        )
        |> GenericChart.ofTraceObject true

module ``Encoded typed arrays on remaining subplot traces`` =

    let ``ScatterPolar with encoded arrays`` =
        TracePolar.initScatterPolar (
            TracePolarStyle.ScatterPolar(
                Name = "encoded scatterpolar",
                Mode = StyleParam.Mode.Lines_Markers,
                IdsEncoded = EncodedTypedArray.ofInt32Array [| 401; 402; 403 |],
                REncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 1.5 |],
                ThetaEncoded = EncodedTypedArray.ofFloat64Array [| 0.0; 120.0; 240.0 |],
                MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 11.0; 12.0; 13.0 |],
                CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 21.0; 22.0; 23.0 |],
                SelectedPointsEncoded = EncodedTypedArray.ofInt32Array [| 1 |]
            )
        )
        |> GenericChart.ofTraceObject true

    let ``ScatterGeo with encoded arrays`` =
        TraceGeo.initScatterGeo (
            TraceGeoStyle.ScatterGeo(
                Name = "encoded scattergeo",
                Mode = StyleParam.Mode.Markers_Text,
                IdsEncoded = EncodedTypedArray.ofInt32Array [| 501; 502; 503 |],
                LatEncoded = EncodedTypedArray.ofFloat64Array [| 52.52; 48.85; 41.90 |],
                LonEncoded = EncodedTypedArray.ofFloat64Array [| 13.40; 2.35; 12.49 |],
                MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 31.0; 32.0; 33.0 |],
                CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 41.0; 42.0; 43.0 |],
                SelectedPointsEncoded = EncodedTypedArray.ofInt32Array [| 0; 2 |]
            )
        )
        |> GenericChart.ofTraceObject true

module ``Encoded typed arrays on carpet and domain traces`` =

    let ``Carpet with encoded arrays`` =
        TraceCarpet.initCarpet (
            TraceCarpetStyle.Carpet(
                Name = "encoded carpet",
                IdsEncoded = EncodedTypedArray.ofInt32Array [| 1; 2; 3 |],
                XEncoded = EncodedTypedArray.ofFloat64Array [| 10.0; 20.0; 30.0 |],
                YEncoded = EncodedTypedArray.ofFloat64Array [| 40.0; 50.0; 60.0 |],
                AEncoded = EncodedTypedArray.ofFloat64Array [| 0.0; 1.0; 2.0 |],
                BEncoded = EncodedTypedArray.ofFloat64Array [| 0.0; 1.0; 2.0 |],
                CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 7.0; 8.0; 9.0 |]
            )
        )
        |> GenericChart.ofTraceObject true

    let ``Pie with encoded arrays`` =
        TraceDomain.initPie (
            TraceDomainStyle.Pie(
                Name = "encoded pie",
                IdsEncoded = EncodedTypedArray.ofInt32Array [| 31; 32; 33 |],
                ValuesEncoded = EncodedTypedArray.ofFloat64Array [| 10.0; 20.0; 30.0 |],
                LabelsEncoded = EncodedTypedArray.ofInt32Array [| 1; 2; 3 |],
                MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 61.0; 62.0; 63.0 |],
                MetaEncoded = EncodedTypedArray.ofFloat64Array [| 71.0; 72.0; 73.0 |],
                CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 81.0; 82.0; 83.0 |]
            )
        )
        |> GenericChart.ofTraceObject true

    let ``Sunburst with encoded arrays`` =
        TraceDomain.initSunburst (
            TraceDomainStyle.Sunburst(
                Name = "encoded sunburst",
                IdsEncoded = EncodedTypedArray.ofInt32Array [| 41; 42; 43 |],
                ParentsEncoded = EncodedTypedArray.ofInt32Array [| 0; 41; 41 |],
                ValuesEncoded = EncodedTypedArray.ofFloat64Array [| 10.0; 6.0; 4.0 |],
                LabelsEncoded = EncodedTypedArray.ofInt32Array [| 1; 2; 3 |],
                MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 91.0; 92.0; 93.0 |],
                MetaEncoded = EncodedTypedArray.ofFloat64Array [| 101.0; 102.0; 103.0 |],
                CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 111.0; 112.0; 113.0 |]
            )
        )
        |> GenericChart.ofTraceObject true

    let ``ParallelCoord with encoded arrays`` =
        TraceDomain.initParallelCoord (
            TraceDomainStyle.ParallelCoord(
                Name = "encoded parallelcoord",
                IdsEncoded = EncodedTypedArray.ofInt32Array [| 51; 52; 53 |],
                Dimensions = [
                    Dimension.initParallel(Label = "A", Values = [ 1.0; 2.0; 3.0 ])
                    Dimension.initParallel(Label = "B", Values = [ 4.0; 5.0; 6.0 ])
                ],
                MetaEncoded = EncodedTypedArray.ofFloat64Array [| 121.0; 122.0; 123.0 |],
                CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 131.0; 132.0; 133.0 |]
            )
        )
        |> GenericChart.ofTraceObject true

    let ``Sankey with encoded arrays`` =
        TraceDomain.initSankey (
            TraceDomainStyle.Sankey(
                Name = "encoded sankey",
                IdsEncoded = EncodedTypedArray.ofInt32Array [| 61; 62 |],
                MetaEncoded = EncodedTypedArray.ofFloat64Array [| 141.0; 142.0 |],
                CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 151.0; 152.0 |],
                SelectedPointsEncoded = EncodedTypedArray.ofInt32Array [| 1 |]
            )
        )
        |> GenericChart.ofTraceObject true
