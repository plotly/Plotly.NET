module CoreTests.UpstreamFeatures.PlotlyJS_2_23

open Expecto
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects


open TestUtils.HtmlCodegen
open PlotlyJS_2_23_TestCharts

module ``Colorbar X and Y ref`` = 
    
    [<Tests>]
    let ``Colorbar X/YRef HTML codegeneration tests`` =
        testList "UpstreamFeatures.PlotlyJS_2_23" [
            testList "Colorbar X/YRef" [
                testCase "Heatmap with horizontal colorbar with x/yref = container data" ( fun () ->
                    """var data = [{"type":"heatmap","z":[[1,2,3],[3,2,1]],"colorbar":{"orientation":"h","title":{"text":"Colorbar 1"},"x":0.5,"xref":"container","y":0.1,"yref":"container"}}];"""
                    |> chartGeneratedContains ``Colorbar X and Y ref``.``Heatmap with horizontal colorbar with x/yref = container``
                )
                testCase "Heatmap with horizontal colorbar with x/yref = container layout" ( fun () ->
                    emptyLayout ``Colorbar X and Y ref``.``Heatmap with horizontal colorbar with x/yref = container``
                )
            ]
        ]

module ``Legend X and Y ref`` = 
    
    [<Tests>]
    let ``Legend X/YRef HTML codegeneration tests`` =
        testList "UpstreamFeatures.PlotlyJS_2_23" [
            testList "Legend X/YRef" [
                testCase "Point chart with horizontal legend with x/yref = container data" ( fun () ->
                    """var data = [{"type":"scatter","showlegend":true,"mode":"markers","x":[1],"y":[2],"marker":{},"line":{}}];"""
                    |> chartGeneratedContains ``Legend X and Y ref``.``Point chart with horizontal legend with x/yref = container``
                )
                testCase "Point chart with horizontal legend with x/yref = container layout" ( fun () ->
                    """var layout = {"legend":{"bordercolor":"rgba(0, 0, 255, 1.0)","borderwidth":2.0,"orientation":"h","title":{"text":"Legend 1"},"x":0.5,"xref":"container","y":0.1,"yref":"container"}};"""
                    |> chartGeneratedContains ``Legend X and Y ref``.``Point chart with horizontal legend with x/yref = container``
                )
            ]
        ]