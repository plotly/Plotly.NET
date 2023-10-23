module CoreTests.HTMLCodegen.ChartSmith

open Expecto
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects


open TestUtils.HtmlCodegen
open ChartSmithTestCharts

module ScatterSmith =
    [<Tests>]
    let ``ScatterSmith chart HTML codegeneration tests`` =
        testList "HTMLCodegen.ChartSmith" [
            testList "ScatterSmith" [
                testCase "Scatter data" ( fun () ->
                    """var data = [{"type":"scattersmith","mode":"lines+markers+text","imag":[0.5,1.0,2.0,3.0],"real":[0.5,1.0,2.0,3.0],"text":["Pretty","Cool","Plot","Huh?"],"textposition":"top center","marker":{},"line":{}}];"""
                    |> chartGeneratedContains ScatterSmith.``Simple smith scatter chart``
                )
                testCase "Scatter layout" ( fun () ->
                    emptyLayout ScatterSmith.``Simple smith scatter chart``
                )
            ]
        ]


module PointSmith =
    [<Tests>]
    let ``PointSmith chart HTML codegeneration tests`` =
        testList "HTMLCodegen.ChartSmith" [
            testList "PointSmith" [
                testCase "Point data" ( fun () ->
                    """var data = [{"type":"scattersmith","mode":"markers","imag":[0.5,1.0,2.0,3.0],"real":[0.5,1.0,2.0,3.0],"marker":{},"line":{}}];"""
                    |> chartGeneratedContains PointSmith.``Simple smith point chart``
                )
                testCase "Point layout" ( fun () ->
                    emptyLayout PointSmith.``Simple smith point chart``
                )
            ]
        ]

module LineSmith =
    [<Tests>]
    let ``LineSmith chart HTML codegeneration tests`` =
        testList "HTMLCodegen.ChartSmith" [
            testList "LineSmith" [
                testCase "Line data" ( fun () ->
                    """var data = [{"type":"scattersmith","mode":"lines","imag":[0.5,1.0,2.0,3.0],"real":[0.5,1.0,2.0,3.0],"marker":{},"line":{"color":"rgba(128, 0, 128, 1.0)","dash":"dashdot"}}];"""
                    |> chartGeneratedContains LineSmith.``Simple smith line chart``
                )
                testCase "Line layout" ( fun () ->
                    emptyLayout LineSmith.``Simple smith line chart`` 
                )
            ]
        ]

module BubbleSmith =
    [<Tests>]
    let ``BubbleSmith chart HTML codegeneration tests`` =
        testList "HTMLCodegen.ChartSmith" [
            testList "BubbleSmith" [
                testCase "Bubble data" ( fun () ->
                    """var data = [{"type":"scattersmith","mode":"markers+text","imag":[0.5,1.0,2.0,3.0],"real":[0.5,1.0,2.0,3.0],"text":["one","two","three","four","five","six","seven"],"textposition":"top center","marker":{"size":[10,20,30,40]},"line":{}}];"""
                    |> chartGeneratedContains BubbleSmith.``Simple smith bubble chart``
                )
                testCase "Bubble layout" ( fun () ->
                    emptyLayout BubbleSmith.``Simple smith bubble chart`` 
                )
            ]
        ]