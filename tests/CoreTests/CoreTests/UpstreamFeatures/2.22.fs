module CoreTests.UpstreamFeatures.PlotlyJS_2_22

open Expecto
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects


open TestUtils.HtmlCodegen
open PlotlyJS_2_22_TestCharts

module MultiLegends = 

    [<Tests>]
    let ``Multi legend chart HTML codegeneration tests`` =
        testList "UpstreamFeatures.PlotlyJS_2_22" [
            testList "Multi Legends" [
                testCase "Two Line traces with one styled legend each data" ( fun () ->
                    """var data = [{"type":"scatter","mode":"markers","x":[1],"y":[2],"marker":{},"line":{},"legend":"legend"},{"type":"scatter","mode":"markers","x":[100],"y":[200],"marker":{},"line":{},"legend":"legend2"}];"""
                    |> chartGeneratedContains MultiLegends.``Two Line traces with one styled legend each``
                )
                testCase "Two Line traces with one styled legend each layout" ( fun () ->
                    """var layout = {"legend":{"bordercolor":"rgba(0, 0, 255, 1.0)","borderwidth":2.0,"title":{"text":"Legend 1"},"x":0.25,"y":0.25},"legend2":{"bordercolor":"rgba(255, 0, 0, 1.0)","borderwidth":2.0,"title":{"text":"Legend 2"},"x":0.75,"y":0.75}};"""
                    |> chartGeneratedContains MultiLegends.``Two Line traces with one styled legend each``
                )
            ]
        ]