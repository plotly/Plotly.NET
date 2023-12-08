module CoreTests.UpstreamFeatures.PlotlyJS_2_26

open Expecto
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects

open TestUtils.HtmlCodegen
open PlotlyJS_2_26_TestCharts

module ``AutoRangeOptions`` = 

    [<Tests>]
    let ``new AutoRangeOptions tests`` =
        testList "UpstreamFeatures.PlotlyJS_2_26" [
            testList "new AutoRangeOptions" [
                testCase "autorange options on x and y axes data" ( fun () ->
                    """var data = [{"type":"scatter","showlegend":true,"mode":"markers","x":[0,1,2,3,4,5,6,7,8,9,10],"y":[0,1,2,3,4,5,6,7,8,9,10],"marker":{},"line":{}}];"""
                    |> chartGeneratedContains AutoRangeOptions.``Point chart with autorange options on x and y axes``
                )
                testCase "autorange options on x and y axes layout" ( fun () ->
                    """var layout = {"xaxis":{"autorangeoptions":{"clipmax":8,"minallowed":4}},"yaxis":{"autorangeoptions":{"clipmax":8,"minallowed":4}}};"""
                    |> chartGeneratedContains AutoRangeOptions.``Point chart with autorange options on x and y axes``
                )
                testCase "autorange options on 3D x, y, and z axes data" ( fun () ->
                    """var data = [{"type":"scatter3d","showlegend":true,"mode":"markers","x":[0,1,2,3,4,5,6,7,8,9,10],"y":[0,1,2,3,4,5,6,7,8,9,10],"z":[0,1,2,3,4,5,6,7,8,9,10],"marker":{},"line":{}}];"""
                    |> chartGeneratedContains AutoRangeOptions.``Point3D chart with autorange options on x, y, and z axes``
                )
                testCase "autorange options on 3D x, y, and z axes layout" ( fun () ->
                    """var layout = {"scene":{"camera":{"projection":{"type":"orthographic"}},"xaxis":{"autorangeoptions":{"clipmax":8,"minallowed":4}},"yaxis":{"autorangeoptions":{"clipmax":8,"minallowed":4}},"zaxis":{"autorangeoptions":{"clipmax":8,"minallowed":4}}}};"""
                    |> chartGeneratedContains AutoRangeOptions.``Point3D chart with autorange options on x, y, and z axes``
                )
                testCase "autorange options polar radial axis data" ( fun () ->
                    """var data = [{"type":"scatterpolar","showlegend":true,"mode":"markers","r":[0,1,2,3,4,5,6,7,8,9,10],"theta":[0,10,20,30,40,50,60,70,80,90,100],"marker":{}}];"""
                    |> chartGeneratedContains AutoRangeOptions.``PointPolar chart with autorange options on radial axis``
                )
                testCase "autorange options polar radial axis layout" ( fun () ->
                    """var layout = {"polar":{"radialaxis":{"autorangeoptions":{"maxallowed":8,"minallowed":4}}}};"""
                    |> chartGeneratedContains AutoRangeOptions.``PointPolar chart with autorange options on radial axis``
                )
            ]
            testList "minallowed maxallowed on axes" [
                testCase "minallowed maxallowed on x and y axes data" ( fun () ->
                    """var data = [{"type":"scatter","showlegend":true,"mode":"markers","x":[0,1,2,3,4,5,6,7,8,9,10],"y":[0,1,2,3,4,5,6,7,8,9,10],"marker":{},"line":{}}];"""
                    |> chartGeneratedContains AutoRangeOptions.``Point chart with minallowed and maxallowed on x and y axes``
                )
                testCase "minallowed maxallowed on x and y axes layout" ( fun () ->
                    """var layout = {"xaxis":{"maxallowed":8,"minallowed":4},"yaxis":{"maxallowed":8,"minallowed":4}};"""
                    |> chartGeneratedContains AutoRangeOptions.``Point chart with minallowed and maxallowed on x and y axes``
                )
                testCase "minallowed maxallowed on 3D x, y, and z axes data" ( fun () ->
                    """var data = [{"type":"scatter3d","showlegend":true,"mode":"markers","x":[0,1,2,3,4,5,6,7,8,9,10],"y":[0,1,2,3,4,5,6,7,8,9,10],"z":[0,1,2,3,4,5,6,7,8,9,10],"marker":{},"line":{}}];"""
                    |> chartGeneratedContains AutoRangeOptions.``Point3D chart with minallowed and maxallowed on x, y, and z axes``
                )
                testCase "minallowed maxallowed on 3D x, y, and z axes layout" ( fun () ->
                    """var layout = {"scene":{"camera":{"projection":{"type":"orthographic"}},"xaxis":{"maxallowed":8,"minallowed":4},"yaxis":{"maxallowed":8,"minallowed":4},"zaxis":{"maxallowed":8,"minallowed":4}}};"""
                    |> chartGeneratedContains AutoRangeOptions.``Point3D chart with minallowed and maxallowed on x, y, and z axes``
                )
                testCase "minallowed maxallowed polar radial axis data" ( fun () ->
                    """var data = [{"type":"scatterpolar","showlegend":true,"mode":"markers","r":[0,1,2,3,4,5,6,7,8,9,10],"theta":[0,10,20,30,40,50,60,70,80,90,100],"marker":{}}];"""
                    |> chartGeneratedContains AutoRangeOptions.``PointPolar chart with minallowed and maxallowed on radial axis``
                )
                // note that this currently fails on the js side (bug: https://github.com/plotly/plotly.js/issues/6765)
                testCase "minallowed maxallowed polar radial axis layout" ( fun () ->
                    """var layout = {"polar":{"radialaxis":{"maxallowed":8,"minallowed":4}}};"""
                    |> chartGeneratedContains AutoRangeOptions.``PointPolar chart with minallowed and maxallowed on radial axis``
                )
            ]
        ]

module ``N-sigma box plots`` =
    [<Tests>]
    let ``Sigma boxplots`` =
        testList "UpstreamFeatures.PlotlyJS_2_26" [
            testList "N-sigma box plots" [
                testCase "2-Sigma box plot data" ( fun () -> 
                    """var data = [{"type":"box","marker":{},"line":{},"sizemode":"sd","y":[-20,1,2,3,1,2,3,3,3,3,3,1,5,20],"sdmultiple":2.0}];"""
                    |> chartGeneratedContains ``N-sigma (std deviations) box plots``.``2-sigma BoxPlot``
                )
                testCase "2-Sigma box plot layout" ( fun () -> 
                    emptyLayout ``N-sigma (std deviations) box plots``.``2-sigma BoxPlot``
                )
            ]
        ]

module ``New Side options for legend titles`` =
    [<Tests>]
    let ``New Title Side options`` =
        testList "UpstreamFeatures.PlotlyJS_2_26" [
            testList "New Side options for legend titles" [
                testCase "top left data" ( fun () -> 
                    """var data = [{"type":"scatter","mode":"markers","x":[1],"y":[2],"marker":{},"line":{}},{"type":"scatter","mode":"markers","x":[3],"y":[4],"marker":{},"line":{}}];"""
                    |> chartGeneratedContains ``New Side options for (legend) titles``.``Point charts with horizontal legend title top left``
                )
                testCase "top left layout" ( fun () -> 
                    """var layout = {"legend":{"orientation":"h","title":{"text":"Legend title (top left)","side":"top left"}}};"""
                    |> chartGeneratedContains ``New Side options for (legend) titles``.``Point charts with horizontal legend title top left``
                )
                testCase "top center data" ( fun () -> 
                    """var data = [{"type":"scatter","mode":"markers","x":[1],"y":[2],"marker":{},"line":{}},{"type":"scatter","mode":"markers","x":[3],"y":[4],"marker":{},"line":{}}];"""
                    |> chartGeneratedContains ``New Side options for (legend) titles``.``Point charts with horizontal legend title top center``
                )
                testCase "top center layout" ( fun () -> 
                    """var layout = {"legend":{"orientation":"h","title":{"text":"Legend title (top center)","side":"top center"}}};"""
                    |> chartGeneratedContains ``New Side options for (legend) titles``.``Point charts with horizontal legend title top center``
                )
                testCase "top right data" ( fun () -> 
                    """var data = [{"type":"scatter","mode":"markers","x":[1],"y":[2],"marker":{},"line":{}},{"type":"scatter","mode":"markers","x":[3],"y":[4],"marker":{},"line":{}}];"""
                    |> chartGeneratedContains ``New Side options for (legend) titles``.``Point charts with horizontal legend title top right``
                )
                testCase "top right layout" ( fun () -> 
                    """var layout = {"legend":{"orientation":"h","title":{"text":"Legend title (top right)","side":"top right"}}};"""
                    |> chartGeneratedContains ``New Side options for (legend) titles``.``Point charts with horizontal legend title top right``
                )
            ]
        ]

module ``New scaleanchor option for linear axes`` =
    [<Tests>]
    let ``New ScaleAnchor option`` =
        testList "UpstreamFeatures.PlotlyJS_2_26" [
            testList "New scaleanchor option for linear axes" [
                testCase "scaleanchor=false data" ( fun () -> 
                    """var data = [{"type":"scatter","mode":"markers","x":[1],"y":[2],"marker":{},"line":{}}];"""
                    |> chartGeneratedContains ``New scaleanchor option for linear axes``.``Point chart with scaleanchor=false``
                )
                testCase "scaleanchor=false layout" ( fun () -> 
                    """var layout = {"xaxis":{"scaleanchor":false}};"""
                    |> chartGeneratedContains ``New scaleanchor option for linear axes``.``Point chart with scaleanchor=false``
                )
            ]
        ]