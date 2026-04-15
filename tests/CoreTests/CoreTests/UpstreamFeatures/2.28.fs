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

module ``Encoded typed arrays on chart helper constructors`` =

    [<Tests>]
    let ``Encoded typed array tests`` =
        testList "UpstreamFeatures.PlotlyJS_2_28" [
            testList "Encoded typed arrays on chart helper constructors" [
                testCase "point constructor serializes encoded x/y and marker mode" (fun () ->
                    [
                        "\"x\":{\"bdata\":"
                        "\"y\":{\"bdata\":"
                        "\"mode\":\"markers\""
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on chart helper constructors``.``Point encoded constructor``)
                )
                testCase "line constructor serializes encoded x/y and line mode" (fun () ->
                    [
                        "\"x\":{\"bdata\":"
                        "\"y\":{\"bdata\":"
                        "\"mode\":\"lines\""
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on chart helper constructors``.``Line encoded constructor``)
                )
                testCase "spline constructor serializes encoded x/y and spline smoothing" (fun () ->
                    [
                        "\"x\":{\"bdata\":"
                        "\"y\":{\"bdata\":"
                        "\"shape\":\"spline\""
                        "\"smoothing\":0.7"
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on chart helper constructors``.``Spline encoded constructor``)
                )
                testCase "bubble constructor serializes encoded x/y and marker sizes" (fun () ->
                    [
                        "\"x\":{\"bdata\":"
                        "\"y\":{\"bdata\":"
                        "\"size\":[10,20,30]"
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on chart helper constructors``.``Bubble encoded constructor``)
                )
                testCase "area constructor serializes encoded x/y with tozeroy fill" (fun () ->
                    [
                        "\"x\":{\"bdata\":"
                        "\"y\":{\"bdata\":"
                        "\"fill\":\"tozeroy\""
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on chart helper constructors``.``Area encoded constructor``)
                )
                testCase "spline area constructor serializes encoded x/y with spline shape and tozeroy fill" (fun () ->
                    [
                        "\"x\":{\"bdata\":"
                        "\"y\":{\"bdata\":"
                        "\"shape\":\"spline\""
                        "\"fill\":\"tozeroy\""
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on chart helper constructors``.``SplineArea encoded constructor``)
                )
                testCase "stacked area constructor serializes encoded x/y with stackgroup and tonexty fill" (fun () ->
                    [
                        "\"x\":{\"bdata\":"
                        "\"y\":{\"bdata\":"
                        "\"stackgroup\":\"stackedarea\""
                        "\"fill\":\"tonexty\""
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on chart helper constructors``.``StackedArea encoded constructor``)
                )
                testCase "range constructor serializes encoded x/y across all traces and tonexty fill" (fun () ->
                    [
                        "\"x\":{\"bdata\":"
                        "\"y\":{\"bdata\":"
                        "\"fill\":\"tonexty\""
                        "\"legendgroup\":\"Range\""
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on chart helper constructors``.``Range encoded constructor``)
                )
            ]
        ]

module ``Encoded typed arrays on chart scatter root`` =

    [<Tests>]
    let ``Encoded typed array tests`` =
        testList "UpstreamFeatures.PlotlyJS_2_28" [
            testList "Encoded typed arrays on chart scatter root" [
                testCase "scatter constructor serializes encoded x/y and scatter mode" (fun () ->
                    [
                        "\"x\":{\"bdata\":"
                        "\"y\":{\"bdata\":"
                        "\"mode\":\"lines+markers\""
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on chart scatter root``.``Scatter encoded constructor``)
                )
            ]
        ]

module ``Encoded typed arrays on chart bar-family roots`` =

    [<Tests>]
    let ``Encoded typed array tests`` =
        testList "UpstreamFeatures.PlotlyJS_2_28" [
            testList "Encoded typed arrays on chart bar-family roots" [
                testCase "bar constructor serializes encoded values keys widths and orientation" (fun () ->
                    [
                        "\"x\":{\"bdata\":"
                        "\"y\":{\"bdata\":"
                        "\"width\":{\"bdata\":"
                        "\"orientation\":\"h\""
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on chart bar-family roots``.``Bar encoded constructor``)
                )
                testCase "funnel constructor serializes encoded x/y" (fun () ->
                    [
                        "\"x\":{\"bdata\":"
                        "\"y\":{\"bdata\":"
                        "\"type\":\"funnel\""
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on chart bar-family roots``.``Funnel encoded constructor``)
                )
                testCase "waterfall constructor serializes encoded x/y/width" (fun () ->
                    [
                        "\"x\":{\"bdata\":"
                        "\"y\":{\"bdata\":"
                        "\"width\":{\"bdata\":"
                        "\"type\":\"waterfall\""
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on chart bar-family roots``.``Waterfall encoded constructor``)
                )
            ]
        ]

module ``Encoded typed arrays on chart distribution and finance roots`` =

    [<Tests>]
    let ``Encoded typed array tests`` =
        testList "UpstreamFeatures.PlotlyJS_2_28" [
            testList "Encoded typed arrays on chart distribution and finance roots" [
                testCase "histogram constructor serializes encoded sample data" (fun () ->
                    [
                        "\"x\":{\"bdata\":"
                        "\"orientation\":\"v\""
                        "\"type\":\"histogram\""
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on chart distribution and finance roots``.``Histogram encoded constructor``)
                )
                testCase "boxplot constructor serializes encoded sample data" (fun () ->
                    [
                        "\"y\":{\"bdata\":"
                        "\"type\":\"box\""
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on chart distribution and finance roots``.``BoxPlot encoded constructor``)
                )
                testCase "violin constructor serializes encoded sample data" (fun () ->
                    [
                        "\"y\":{\"bdata\":"
                        "\"type\":\"violin\""
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on chart distribution and finance roots``.``Violin encoded constructor``)
                )
                testCase "ohlc constructor serializes encoded finance arrays" (fun () ->
                    [
                        "\"x\":{\"bdata\":"
                        "\"open\":{\"bdata\":"
                        "\"high\":{\"bdata\":"
                        "\"low\":{\"bdata\":"
                        "\"close\":{\"bdata\":"
                        "\"type\":\"ohlc\""
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on chart distribution and finance roots``.``OHLC encoded constructor``)
                )
                testCase "candlestick constructor serializes encoded finance arrays" (fun () ->
                    [
                        "\"x\":{\"bdata\":"
                        "\"open\":{\"bdata\":"
                        "\"high\":{\"bdata\":"
                        "\"low\":{\"bdata\":"
                        "\"close\":{\"bdata\":"
                        "\"type\":\"candlestick\""
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on chart distribution and finance roots``.``Candlestick encoded constructor``)
                )
            ]
        ]

module ``Encoded typed arrays on chart splom root`` =

    [<Tests>]
    let ``Encoded typed array tests`` =
        testList "UpstreamFeatures.PlotlyJS_2_28" [
            testList "Encoded typed arrays on chart splom root" [
                testCase "splom constructor serializes encoded dimension values" (fun () ->
                    [
                        "\"dimensions\":[{\"label\":\"A\",\"values\":{\"bdata\":"
                        "\"label\":\"B\",\"values\":{\"bdata\":"
                        "\"label\":\"C\",\"values\":{\"bdata\":"
                        "\"type\":\"splom\""
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on chart splom root``.``Splom encoded constructor``)
                )
                testCase "splom constructor preserves chart-specific options" (fun () ->
                    [
                        "\"name\":\"encoded chart splom\""
                        "\"showlowerhalf\":false"
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on chart splom root``.``Splom encoded constructor``)
                )
            ]
        ]

module ``Encoded typed arrays on chart matrix roots`` =

    [<Tests>]
    let ``Encoded typed array tests`` =
        testList "UpstreamFeatures.PlotlyJS_2_28" [
            testList "Encoded typed arrays on chart matrix roots" [
                testCase "histogram2d constructor serializes encoded x y and z" (fun () ->
                    [
                        "\"x\":{\"bdata\":"
                        "\"y\":{\"bdata\":"
                        "\"z\":{\"bdata\":"
                        "\"shape\":\"2,2\""
                        "\"type\":\"histogram2d\""
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on chart matrix roots``.``Histogram2D encoded constructor``)
                )
                testCase "histogram2dcontour constructor serializes encoded x y and z" (fun () ->
                    [
                        "\"x\":{\"bdata\":"
                        "\"y\":{\"bdata\":"
                        "\"z\":{\"bdata\":"
                        "\"shape\":\"2,2\""
                        "\"type\":\"histogram2dcontour\""
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on chart matrix roots``.``Histogram2DContour encoded constructor``)
                )
                testCase "heatmap constructor serializes encoded axes z and layout reversal" (fun () ->
                    [
                        "\"x\":{\"bdata\":"
                        "\"y\":{\"bdata\":"
                        "\"z\":{\"bdata\":"
                        "\"shape\":\"2,3\""
                        "\"autorange\":\"reversed\""
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on chart matrix roots``.``Heatmap encoded constructor``)
                )
                testCase "contour constructor serializes encoded axes and z" (fun () ->
                    [
                        "\"x\":{\"bdata\":"
                        "\"y\":{\"bdata\":"
                        "\"z\":{\"bdata\":"
                        "\"shape\":\"2,2\""
                        "\"type\":\"contour\""
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on chart matrix roots``.``Contour encoded constructor``)
                )
            ]
        ]

module ``Encoded typed arrays on chart 3D roots`` =

    [<Tests>]
    let ``Encoded typed array tests`` =
        testList "UpstreamFeatures.PlotlyJS_2_28" [
            testList "Encoded typed arrays on chart 3D roots" [
                testCase "scatter3d constructor serializes encoded xyz arrays" (fun () ->
                    [
                        "\"x\":{\"bdata\":"
                        "\"y\":{\"bdata\":"
                        "\"z\":{\"bdata\":"
                        "\"type\":\"scatter3d\""
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on chart 3D roots``.``Scatter3D encoded constructor``)
                )
                testCase "surface constructor serializes encoded z matrix and axes" (fun () ->
                    [
                        "\"x\":{\"bdata\":"
                        "\"y\":{\"bdata\":"
                        "\"z\":{\"bdata\":"
                        "\"shape\":\"2,2\""
                        "\"type\":\"surface\""
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on chart 3D roots``.``Surface encoded constructor``)
                )
                testCase "mesh3d constructor serializes encoded xyz topology and intensity arrays" (fun () ->
                    [
                        "\"x\":{\"bdata\":"
                        "\"y\":{\"bdata\":"
                        "\"z\":{\"bdata\":"
                        "\"i\":{\"bdata\":"
                        "\"j\":{\"bdata\":"
                        "\"k\":{\"bdata\":"
                        "\"intensity\":{\"bdata\":"
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on chart 3D roots``.``Mesh3D encoded constructor``)
                )
                testCase "cone constructor serializes encoded vector-field arrays" (fun () ->
                    [
                        "\"x\":{\"bdata\":"
                        "\"y\":{\"bdata\":"
                        "\"z\":{\"bdata\":"
                        "\"u\":{\"bdata\":"
                        "\"v\":{\"bdata\":"
                        "\"w\":{\"bdata\":"
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on chart 3D roots``.``Cone encoded constructor``)
                )
                testCase "streamtube constructor serializes encoded vector-field arrays" (fun () ->
                    [
                        "\"x\":{\"bdata\":"
                        "\"y\":{\"bdata\":"
                        "\"z\":{\"bdata\":"
                        "\"u\":{\"bdata\":"
                        "\"v\":{\"bdata\":"
                        "\"w\":{\"bdata\":"
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on chart 3D roots``.``StreamTube encoded constructor``)
                )
                testCase "volume constructor serializes encoded value and opacityscale arrays" (fun () ->
                    [
                        "\"x\":{\"bdata\":"
                        "\"y\":{\"bdata\":"
                        "\"z\":{\"bdata\":"
                        "\"value\":{\"bdata\":"
                        "\"opacityscale\":{\"bdata\":"
                        "\"shape\":\"2,2\""
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on chart 3D roots``.``Volume encoded constructor``)
                )
                testCase "isosurface constructor serializes encoded value arrays" (fun () ->
                    [
                        "\"x\":{\"bdata\":"
                        "\"y\":{\"bdata\":"
                        "\"z\":{\"bdata\":"
                        "\"value\":{\"bdata\":"
                        "\"type\":\"isosurface\""
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on chart 3D roots``.``IsoSurface encoded constructor``)
                )
            ]
        ]

module ``Encoded typed arrays on chart subplot and domain roots`` =

    [<Tests>]
    let ``Encoded typed array tests`` =
        testList "UpstreamFeatures.PlotlyJS_2_28" [
            testList "Encoded typed arrays on chart subplot and domain roots" [
                testCase "barpolar constructor serializes encoded r/theta/width arrays" (fun () ->
                    [
                        "\"r\":{\"bdata\":"
                        "\"theta\":{\"bdata\":"
                        "\"width\":{\"bdata\":"
                        "\"type\":\"barpolar\""
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on chart subplot and domain roots``.``BarPolar encoded constructor``)
                )
                testCase "choropleth constructor serializes encoded z and keeps locations plain" (fun () ->
                    [
                        "\"locations\":[\"DEU\",\"FRA\",\"ITA\"]"
                        "\"z\":{\"bdata\":"
                        "\"type\":\"choropleth\""
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on chart subplot and domain roots``.``ChoroplethMap encoded constructor``)
                )
                testCase "scatterpolar constructor serializes encoded r/theta arrays" (fun () ->
                    [
                        "\"r\":{\"bdata\":"
                        "\"theta\":{\"bdata\":"
                        "\"type\":\"scatterpolar\""
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on chart subplot and domain roots``.``ScatterPolar encoded constructor``)
                )
                testCase "scattergeo constructor serializes encoded lon/lat arrays" (fun () ->
                    [
                        "\"lon\":{\"bdata\":"
                        "\"lat\":{\"bdata\":"
                        "\"type\":\"scattergeo\""
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on chart subplot and domain roots``.``ScatterGeo encoded constructor``)
                )
                testCase "scattermapbox constructor serializes encoded lon/lat arrays" (fun () ->
                    [
                        "\"lon\":{\"bdata\":"
                        "\"lat\":{\"bdata\":"
                        "\"type\":\"scattermapbox\""
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on chart subplot and domain roots``.``ScatterMapbox encoded constructor``)
                )
                testCase "choroplethmapbox constructor serializes encoded z and keeps locations plain" (fun () ->
                    [
                        "\"locations\":[\"A\",\"B\",\"C\"]"
                        "\"z\":{\"bdata\":"
                        "\"type\":\"choroplethmapbox\""
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on chart subplot and domain roots``.``ChoroplethMapbox encoded constructor``)
                )
                testCase "densitymapbox constructor serializes encoded lon/lat/z arrays" (fun () ->
                    [
                        "\"lon\":{\"bdata\":"
                        "\"lat\":{\"bdata\":"
                        "\"z\":{\"bdata\":"
                        "\"type\":\"densitymapbox\""
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on chart subplot and domain roots``.``DensityMapbox encoded constructor``)
                )
                testCase "scatterternary constructor serializes encoded a/b/c arrays" (fun () ->
                    [
                        "\"a\":{\"bdata\":"
                        "\"b\":{\"bdata\":"
                        "\"c\":{\"bdata\":"
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on chart subplot and domain roots``.``ScatterTernary encoded constructor``)
                )
                testCase "scattersmith constructor serializes encoded real/imag arrays" (fun () ->
                    [
                        "\"real\":{\"bdata\":"
                        "\"imag\":{\"bdata\":"
                        "\"type\":\"scattersmith\""
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on chart subplot and domain roots``.``ScatterSmith encoded constructor``)
                )
                testCase "carpet constructor serializes encoded a/b/x/y arrays" (fun () ->
                    [
                        "\"a\":{\"bdata\":"
                        "\"b\":{\"bdata\":"
                        "\"x\":{\"bdata\":"
                        "\"y\":{\"bdata\":"
                        "\"type\":\"carpet\""
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on chart subplot and domain roots``.``Carpet encoded constructor``)
                )
                testCase "scattercarpet constructor serializes encoded a/b arrays" (fun () ->
                    [
                        "\"a\":{\"bdata\":"
                        "\"b\":{\"bdata\":"
                        "\"type\":\"scattercarpet\""
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on chart subplot and domain roots``.``ScatterCarpet encoded constructor``)
                )
                testCase "contourcarpet constructor serializes encoded z/a/b arrays" (fun () ->
                    [
                        "\"z\":{\"bdata\":"
                        "\"a\":{\"bdata\":"
                        "\"b\":{\"bdata\":"
                        "\"type\":\"contourcarpet\""
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on chart subplot and domain roots``.``ContourCarpet encoded constructor``)
                )
                testCase "pie constructor serializes encoded values and labels" (fun () ->
                    [
                        "\"values\":{\"bdata\":"
                        "\"labels\":{\"bdata\":"
                        "\"type\":\"pie\""
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on chart subplot and domain roots``.``Pie encoded constructor``)
                )
                testCase "funnelarea constructor serializes encoded values and labels" (fun () ->
                    [
                        "\"values\":{\"bdata\":"
                        "\"labels\":{\"bdata\":"
                        "\"type\":\"funnelarea\""
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on chart subplot and domain roots``.``FunnelArea encoded constructor``)
                )
                testCase "sunburst constructor serializes encoded labels parents and values" (fun () ->
                    [
                        "\"labels\":{\"bdata\":"
                        "\"parents\":{\"bdata\":"
                        "\"values\":{\"bdata\":"
                        "\"type\":\"sunburst\""
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on chart subplot and domain roots``.``Sunburst encoded constructor``)
                )
                testCase "treemap constructor serializes encoded labels parents and values" (fun () ->
                    [
                        "\"labels\":{\"bdata\":"
                        "\"parents\":{\"bdata\":"
                        "\"values\":{\"bdata\":"
                        "\"type\":\"treemap\""
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on chart subplot and domain roots``.``Treemap encoded constructor``)
                )
                testCase "icicle constructor serializes encoded labels parents and values" (fun () ->
                    [
                        "\"labels\":{\"bdata\":"
                        "\"parents\":{\"bdata\":"
                        "\"values\":{\"bdata\":"
                        "\"type\":\"icicle\""
                    ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on chart subplot and domain roots``.``Icicle encoded constructor``)
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
                testCase "waterfall trace serializes encoded x/y/width/offset" (fun () ->
                    [
                        "\"x\":{\"bdata\":"
                        "\"y\":{\"bdata\":"
                        "\"width\":{\"bdata\":"
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
                        "\"dimensions\":[{\"label\":\"A\",\"values\":{\"bdata\":"
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

module ``Encoded typed arrays on remaining subplot traces`` =

    [<Tests>]
    let ``Encoded typed array tests`` =
        testList "UpstreamFeatures.PlotlyJS_2_28" [
            testList "Encoded typed arrays on remaining subplot traces" [
                testCase "scatterpolar trace serializes encoded polar and metadata arrays" (fun () ->
                    [ "\"ids\":{\"bdata\":"; "\"r\":{\"bdata\":"; "\"theta\":{\"bdata\":"; "\"text\":{\"bdata\":"; "\"customdata\":{\"bdata\":"; "\"selectedpoints\":{\"bdata\":" ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on remaining subplot traces``.``ScatterPolar with encoded arrays``)
                )
                testCase "scattergeo trace serializes encoded lat lon and metadata arrays" (fun () ->
                    [ "\"ids\":{\"bdata\":"; "\"lat\":{\"bdata\":"; "\"lon\":{\"bdata\":"; "\"text\":{\"bdata\":"; "\"customdata\":{\"bdata\":"; "\"selectedpoints\":{\"bdata\":" ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on remaining subplot traces``.``ScatterGeo with encoded arrays``)
                )
            ]
        ]

module ``Encoded typed arrays on carpet and domain traces`` =

    [<Tests>]
    let ``Encoded typed array tests`` =
        testList "UpstreamFeatures.PlotlyJS_2_28" [
            testList "Encoded typed arrays on carpet and domain traces" [
                testCase "carpet trace serializes encoded coordinate and metadata arrays" (fun () ->
                    [ "\"ids\":{\"bdata\":"; "\"x\":{\"bdata\":"; "\"y\":{\"bdata\":"; "\"a\":{\"bdata\":"; "\"b\":{\"bdata\":"; "\"customdata\":{\"bdata\":" ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on carpet and domain traces``.``Carpet with encoded arrays``)
                )
                testCase "pie trace serializes encoded values labels text meta and customdata arrays" (fun () ->
                    [ "\"ids\":{\"bdata\":"; "\"values\":{\"bdata\":"; "\"labels\":{\"bdata\":"; "\"text\":{\"bdata\":"; "\"meta\":{\"bdata\":"; "\"customdata\":{\"bdata\":" ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on carpet and domain traces``.``Pie with encoded arrays``)
                )
                testCase "sunburst trace serializes encoded hierarchy arrays" (fun () ->
                    [ "\"ids\":{\"bdata\":"; "\"parents\":{\"bdata\":"; "\"values\":{\"bdata\":"; "\"labels\":{\"bdata\":"; "\"text\":{\"bdata\":"; "\"meta\":{\"bdata\":"; "\"customdata\":{\"bdata\":" ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on carpet and domain traces``.``Sunburst with encoded arrays``)
                )
                testCase "parallelcoord trace serializes encoded metadata arrays" (fun () ->
                    [ "\"dimensions\":[{\"label\":\"A\",\"values\":{\"bdata\":"; "\"ids\":{\"bdata\":"; "\"meta\":{\"bdata\":"; "\"customdata\":{\"bdata\":" ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on carpet and domain traces``.``ParallelCoord with encoded arrays``)
                )
                testCase "sankey trace serializes encoded metadata arrays" (fun () ->
                    [ "\"ids\":{\"bdata\":"; "\"meta\":{\"bdata\":"; "\"customdata\":{\"bdata\":"; "\"selectedpoints\":{\"bdata\":" ]
                    |> List.iter (chartGeneratedContains ``Encoded typed arrays on carpet and domain traces``.``Sankey with encoded arrays``)
                )
            ]
        ]
