module CoreTests.UpstreamFeatures.PlotlyJS_2_25

open Expecto
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects


open TestUtils.HtmlCodegen
open PlotlyJS_2_25_TestCharts

module ``EqualEarth Geo Projection`` =

    [<Tests>]
    let ``EqualEarth Geo Projection HTML codegeneration tests`` =
        testList "UpstreamFeatures.PlotlyJS_2_25" [
            testList "EqualEarth Geo Projection" [
                testCase "EqualEarth Geo Projection data" ( fun () ->
                    """var data = [{"type":"scattergeo","mode":"markers","lat":[2],"lon":[1],"marker":{},"line":{}}];"""
                    |> chartGeneratedContains ``EqualEarth Geo Projection``.``PointGeo chart with EqualEarth projection type``
                )
                testCase "EqualEarth Geo Projection layout" ( fun () ->
                    """var layout = {"geo":{"projection":{"type":"equal earth"}}};"""
                    |> chartGeneratedContains``EqualEarth Geo Projection``.``PointGeo chart with EqualEarth projection type``
                )
            ]
        ]

module ``Legends for shapes and newshape`` =

    [<Tests>]
    let ``Legends for shapes and newshape HTML codegeneration tests`` =
        testList "UpstreamFeatures.PlotlyJS_2_25" [
            testList "Legends for shapes" [
                testCase "data" ( fun () ->
                    """var data = [{"type":"scatter","mode":"markers","x":[1],"y":[2],"marker":{},"line":{}}];"""
                    |> chartGeneratedContains ``Legends for shapes and newshape``.``Point chart with 2 shapes anchored to 2 legends``
                )
                testCase "layout" ( fun () ->
                    """var layout = {"shapes":[{"showlegend":true,"x0":0.5,"x1":1.0,"xref":"x","y0":0.5,"y1":1.0,"yref":"y","legend":"legend"},{"showlegend":true,"x0":1.0,"x1":2.0,"xref":"x","y0":1.0,"y1":2.0,"yref":"y","legend":"legend2"}],"legend":{"x":0.25,"y":0.25},"legend2":{"x":0.75,"y":0.75}};"""
                    |> chartGeneratedContains ``Legends for shapes and newshape``.``Point chart with 2 shapes anchored to 2 legends``
                )
            ]
            testList "Legends for newshape" [
                testCase "data" ( fun () ->
                    """var data = [{"type":"scatter","showlegend":true,"mode":"markers","x":[1],"y":[2],"marker":{},"line":{}}];"""
                    |> chartGeneratedContains ``Legends for shapes and newshape``.``Point chart with dragmode = drawrect with new shapes added to legend 2``
                )
                testCase "layout" ( fun () ->
                    """var layout = {"dragmode":"drawrect","newshape":{"drawdirection":"diagonal","showlegend":true,"visible":true,"legend":"legend2"},"legend":{"x":0.25,"y":0.25},"legend2":{"x":0.75,"y":0.75}};"""
                    |> chartGeneratedContains ``Legends for shapes and newshape``.``Point chart with dragmode = drawrect with new shapes added to legend 2``
                )
            ]
    ]