module CoreTests.UpstreamFeatures.PlotlyJS_2_28

open Expecto

open TestUtils.HtmlCodegen
open PlotlyJS_2_28_TestCharts

module ``Encoded typed arrays`` =

    [<Tests>]
    let ``Encoded typed array tests`` =
        testList "UpstreamFeatures.PlotlyJS_2_28" [
            testList "Encoded typed arrays" [
                testCase "x is serialized as an encoded object" (fun () ->
                    """"x":{"bdata":"AAAAAAAA8D8AAAAAAAAAQA==","dtype":"f8"}"""
                    |> chartGeneratedContains ``Encoded typed arrays``.``Scatter x/y encoded``
                )
                testCase "y is serialized as an encoded object" (fun () ->
                    """"y":{"bdata":"AAAAAAAACEAAAAAAAAAQQA==","dtype":"f8"}"""
                    |> chartGeneratedContains ``Encoded typed arrays``.``Scatter x/y encoded``
                )
                testCase "scatter additional data-array fields are serialized as encoded objects" (fun () ->
                    [
                        "\"ids\":{\"bdata\":"
                        "\"customdata\":{\"bdata\":"
                        "\"selectedpoints\":{\"bdata\":"
                        "\"text\":{\"bdata\":"
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays``.``Scatter fully encoded with error bars``)
                )
                testCase "encoded error_x array is serialized under error_x.array" (fun () ->
                    """"error_x":{"type":"data","array":{"bdata":"""
                    |> chartGeneratedContains ``Encoded typed arrays``.``Scatter fully encoded with error bars``
                )
                testCase "encoded error_y array and arrayminus are serialized under error_y" (fun () ->
                    [
                        "\"error_y\":{\"type\":\"data\",\"array\":{\"bdata\":"
                        "\"arrayminus\":{\"bdata\":"
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays``.``Scatter fully encoded with error bars``)
                )
            ]
        ]

module ``Encoded typed arrays on bar-family traces`` =

    [<Tests>]
    let ``Encoded typed array tests`` =
        testList "UpstreamFeatures.PlotlyJS_2_28" [
            testList "Encoded typed arrays on bar-family traces" [
                testCase "bar trace serializes encoded x/y/width/offset" (fun () ->
                    [
                        "\"x\":{\"bdata\":"
                        "\"y\":{\"bdata\":"
                        "\"width\":{\"bdata\":"
                        "\"offset\":{\"bdata\":"
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on bar-family traces``.``Bar with encoded arrays``)
                )
                testCase "bar trace serializes encoded ids/customdata/selectedpoints/text" (fun () ->
                    [
                        "\"ids\":{\"bdata\":"
                        "\"customdata\":{\"bdata\":"
                        "\"selectedpoints\":{\"bdata\":"
                        "\"text\":{\"bdata\":"
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on bar-family traces``.``Bar with encoded arrays``)
                )
                testCase "funnel trace serializes encoded standard data-array fields" (fun () ->
                    [
                        "\"x\":{\"bdata\":"
                        "\"y\":{\"bdata\":"
                        "\"ids\":{\"bdata\":"
                        "\"customdata\":{\"bdata\":"
                        "\"selectedpoints\":{\"bdata\":"
                        "\"text\":{\"bdata\":"
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on bar-family traces``.``Funnel with encoded arrays``)
                )
                testCase "waterfall trace serializes encoded x/y/offset" (fun () ->
                    [
                        "\"x\":{\"bdata\":"
                        "\"y\":{\"bdata\":"
                        "\"offset\":{\"bdata\":"
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on bar-family traces``.``Waterfall with encoded arrays``)
                )
                testCase "waterfall trace serializes encoded ids/customdata/selectedpoints/text" (fun () ->
                    [
                        "\"ids\":{\"bdata\":"
                        "\"customdata\":{\"bdata\":"
                        "\"selectedpoints\":{\"bdata\":"
                        "\"text\":{\"bdata\":"
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on bar-family traces``.``Waterfall with encoded arrays``)
                )
            ]
        ]

module ``Encoded typed arrays on 1-D trace families`` =

    [<Tests>]
    let ``Encoded typed array tests`` =
        testList "UpstreamFeatures.PlotlyJS_2_28" [
            testList "Encoded typed arrays on 1-D trace families" [
                testCase "histogram trace serializes encoded standard data-array fields" (fun () ->
                    [
                        "\"x\":{\"bdata\":"
                        "\"y\":{\"bdata\":"
                        "\"ids\":{\"bdata\":"
                        "\"customdata\":{\"bdata\":"
                        "\"selectedpoints\":{\"bdata\":"
                        "\"text\":{\"bdata\":"
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on 1-D trace families``.``Histogram with encoded arrays``)
                )
                testCase "boxplot trace serializes encoded sample and computed-stat fields" (fun () ->
                    [
                        "\"x\":{\"bdata\":"
                        "\"ids\":{\"bdata\":"
                        "\"customdata\":{\"bdata\":"
                        "\"selectedpoints\":{\"bdata\":"
                        "\"text\":{\"bdata\":"
                        "\"q1\":{\"bdata\":"
                        "\"median\":{\"bdata\":"
                        "\"q3\":{\"bdata\":"
                        "\"lowerfence\":{\"bdata\":"
                        "\"upperfence\":{\"bdata\":"
                        "\"notchspan\":{\"bdata\":"
                        "\"mean\":{\"bdata\":"
                        "\"sd\":{\"bdata\":"
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on 1-D trace families``.``BoxPlot with encoded arrays``)
                )
                testCase "violin trace serializes encoded standard data-array fields" (fun () ->
                    [
                        "\"x\":{\"bdata\":"
                        "\"y\":{\"bdata\":"
                        "\"ids\":{\"bdata\":"
                        "\"customdata\":{\"bdata\":"
                        "\"selectedpoints\":{\"bdata\":"
                        "\"text\":{\"bdata\":"
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on 1-D trace families``.``Violin with encoded arrays``)
                )
                testCase "ohlc trace serializes encoded finance arrays" (fun () ->
                    [
                        "\"x\":{\"bdata\":"
                        "\"ids\":{\"bdata\":"
                        "\"customdata\":{\"bdata\":"
                        "\"selectedpoints\":{\"bdata\":"
                        "\"text\":{\"bdata\":"
                        "\"open\":{\"bdata\":"
                        "\"high\":{\"bdata\":"
                        "\"low\":{\"bdata\":"
                        "\"close\":{\"bdata\":"
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on 1-D trace families``.``OHLC with encoded arrays``)
                )
                testCase "candlestick trace serializes encoded finance arrays" (fun () ->
                    [
                        "\"x\":{\"bdata\":"
                        "\"ids\":{\"bdata\":"
                        "\"customdata\":{\"bdata\":"
                        "\"selectedpoints\":{\"bdata\":"
                        "\"text\":{\"bdata\":"
                        "\"open\":{\"bdata\":"
                        "\"high\":{\"bdata\":"
                        "\"low\":{\"bdata\":"
                        "\"close\":{\"bdata\":"
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on 1-D trace families``.``Candlestick with encoded arrays``)
                )
                testCase "splom trace serializes encoded metadata arrays" (fun () ->
                    [
                        "\"ids\":{\"bdata\":"
                        "\"customdata\":{\"bdata\":"
                        "\"selectedpoints\":{\"bdata\":"
                        "\"text\":{\"bdata\":"
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on 1-D trace families``.``Splom with encoded arrays``)
                )
            ]
        ]

module ``Encoded typed arrays on matrix trace families`` =

    [<Tests>]
    let ``Encoded typed array tests`` =
        testList "UpstreamFeatures.PlotlyJS_2_28" [
            testList "Encoded typed arrays on matrix trace families" [
                testCase "histogram2d trace serializes encoded standard matrix data-array fields" (fun () ->
                    [
                        "\"x\":{\"bdata\":"
                        "\"y\":{\"bdata\":"
                        "\"z\":{\"bdata\":"
                        "\"shape\":\"2,3\""
                        "\"ids\":{\"bdata\":"
                        "\"customdata\":{\"bdata\":"
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on matrix trace families``.``Histogram2D with encoded arrays``)
                )
                testCase "histogram2dcontour trace serializes encoded standard matrix data-array fields" (fun () ->
                    [
                        "\"x\":{\"bdata\":"
                        "\"y\":{\"bdata\":"
                        "\"z\":{\"bdata\":"
                        "\"shape\":\"2,2\""
                        "\"ids\":{\"bdata\":"
                        "\"customdata\":{\"bdata\":"
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on matrix trace families``.``Histogram2DContour with encoded arrays``)
                )
                testCase "heatmap trace serializes encoded x y z text and customdata" (fun () ->
                    [
                        "\"x\":{\"bdata\":"
                        "\"y\":{\"bdata\":"
                        "\"z\":{\"bdata\":"
                        "\"shape\":\"2,3\""
                        "\"ids\":{\"bdata\":"
                        "\"text\":{\"bdata\":"
                        "\"customdata\":{\"bdata\":"
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on matrix trace families``.``Heatmap with encoded arrays``)
                )
                testCase "contour trace serializes encoded x y z text and customdata" (fun () ->
                    [
                        "\"x\":{\"bdata\":"
                        "\"y\":{\"bdata\":"
                        "\"z\":{\"bdata\":"
                        "\"shape\":\"2,3\""
                        "\"ids\":{\"bdata\":"
                        "\"text\":{\"bdata\":"
                        "\"customdata\":{\"bdata\":"
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on matrix trace families``.``Contour with encoded arrays``)
                )
                testCase "image trace serializes encoded metadata arrays" (fun () ->
                    [
                        "\"ids\":{\"bdata\":"
                        "\"text\":{\"bdata\":"
                        "\"customdata\":{\"bdata\":"
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on matrix trace families``.``Image with encoded metadata arrays``)
                )
            ]
        ]

module ``Encoded typed arrays on Trace3D families`` =

    [<Tests>]
    let ``Encoded typed array tests`` =
        testList "UpstreamFeatures.PlotlyJS_2_28" [
            testList "Encoded typed arrays on Trace3D families" [
                testCase "scatter3d trace serializes encoded xyz text and customdata arrays" (fun () ->
                    [ "\"ids\":{\"bdata\":"; "\"x\":{\"bdata\":"; "\"y\":{\"bdata\":"; "\"z\":{\"bdata\":"; "\"text\":{\"bdata\":"; "\"customdata\":{\"bdata\":" ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on Trace3D families``.``Scatter3D with encoded arrays``)
                )
                testCase "surface trace serializes encoded matrix z and opacityscale arrays" (fun () ->
                    [ "\"ids\":{\"bdata\":"; "\"x\":{\"bdata\":"; "\"y\":{\"bdata\":"; "\"z\":{\"bdata\":"; "\"shape\":\"2,2\""; "\"text\":{\"bdata\":"; "\"customdata\":{\"bdata\":"; "\"opacityscale\":{\"bdata\":" ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on Trace3D families``.``Surface with encoded arrays``)
                )
                testCase "mesh3d trace serializes encoded topology and intensity arrays" (fun () ->
                    [ "\"ids\":{\"bdata\":"; "\"x\":{\"bdata\":"; "\"y\":{\"bdata\":"; "\"z\":{\"bdata\":"; "\"i\":{\"bdata\":"; "\"j\":{\"bdata\":"; "\"k\":{\"bdata\":"; "\"intensity\":{\"bdata\":"; "\"text\":{\"bdata\":"; "\"customdata\":{\"bdata\":" ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on Trace3D families``.``Mesh3D with encoded arrays``)
                )
                testCase "cone trace serializes encoded vector-field arrays" (fun () ->
                    [ "\"ids\":{\"bdata\":"; "\"x\":{\"bdata\":"; "\"y\":{\"bdata\":"; "\"z\":{\"bdata\":"; "\"u\":{\"bdata\":"; "\"v\":{\"bdata\":"; "\"w\":{\"bdata\":"; "\"text\":{\"bdata\":"; "\"customdata\":{\"bdata\":" ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on Trace3D families``.``Cone with encoded arrays``)
                )
                testCase "streamtube trace serializes encoded vector-field arrays" (fun () ->
                    [ "\"ids\":{\"bdata\":"; "\"x\":{\"bdata\":"; "\"y\":{\"bdata\":"; "\"z\":{\"bdata\":"; "\"u\":{\"bdata\":"; "\"v\":{\"bdata\":"; "\"w\":{\"bdata\":"; "\"text\":{\"bdata\":"; "\"customdata\":{\"bdata\":" ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on Trace3D families``.``StreamTube with encoded arrays``)
                )
                testCase "volume trace serializes encoded value and opacityscale arrays" (fun () ->
                    [ "\"ids\":{\"bdata\":"; "\"x\":{\"bdata\":"; "\"y\":{\"bdata\":"; "\"z\":{\"bdata\":"; "\"value\":{\"bdata\":"; "\"text\":{\"bdata\":"; "\"customdata\":{\"bdata\":"; "\"opacityscale\":{\"bdata\":"; "\"shape\":\"3,2\"" ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on Trace3D families``.``Volume with encoded arrays``)
                )
                testCase "isosurface trace serializes encoded value and opacityscale arrays" (fun () ->
                    [ "\"ids\":{\"bdata\":"; "\"x\":{\"bdata\":"; "\"y\":{\"bdata\":"; "\"z\":{\"bdata\":"; "\"value\":{\"bdata\":"; "\"text\":{\"bdata\":"; "\"customdata\":{\"bdata\":"; "\"opacityscale\":{\"bdata\":"; "\"shape\":\"3,2\"" ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on Trace3D families``.``IsoSurface with encoded arrays``)
                )
            ]
        ]
