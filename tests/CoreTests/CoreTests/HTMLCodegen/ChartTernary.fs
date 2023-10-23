module CoreTests.HTMLCodegen.ChartTernary

open Expecto
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects


open TestUtils.HtmlCodegen
open ChartTernaryTestCharts

module ScatterTernary = 
    [<Tests>]
    let ``ScatterTernary chart HTML codegeneration tests`` =
        testList "HTMLCodegen.ChartTernary" [
            testList "ScatterTernary" [
            ]
        ]

module PointTernary = 
    [<Tests>]
    let ``PointTernary chart HTML codegeneration tests`` =
        testList "HTMLCodegen.ChartTernary" [
            testList "PointTernary" [
                testCase "Point data" ( fun () ->
                    """var data = [{"type":"scatterternary","mode":"markers","a":[1],"b":[2],"c":[3],"marker":{},"line":{}}];"""
                    |> chartGeneratedContains PointTernary.``Styled ternary point chart``
                )
                testCase "Point layout" ( fun () ->
                    """var layout = {"ternary":{"aaxis":{"color":"rgba(153, 50, 204, 1.0)","title":{"text":"A"}},"baxis":{"color":"rgba(139, 0, 0, 1.0)","title":{"text":"B"}},"caxis":{"color":"rgba(0, 139, 139, 1.0)","title":{"text":"C"}}}};"""
                    |> chartGeneratedContains PointTernary.``Styled ternary point chart``
                )
            ]
        ]

module LineTernary = 
    [<Tests>]
    let ``LineTernary chart HTML codegeneration tests`` =
        testList "HTMLCodegen.ChartTernary" [
            testList "LineTernary" [
                testCase "Line data" ( fun () ->
                    """var data = [{"type":"scatterternary","mode":"lines+markers","a":[10,20,30,40,50,60,70,80],"b":[80,70,60,50,40,30,20,10],"marker":{},"line":{"dash":"dashdot"},"sum":100}];"""
                    |> chartGeneratedContains LineTernary.``Styled ternary line chart``
                )
                testCase "Line layout" ( fun () ->
                    """var layout = {"ternary":{"aaxis":{"color":"rgba(153, 50, 204, 1.0)"},"baxis":{"color":"rgba(139, 0, 0, 1.0)"},"caxis":{"color":"rgba(0, 139, 139, 1.0)"}}};"""
                    |> chartGeneratedContains LineTernary.``Styled ternary line chart`` 
                )
            ]
        ]

module BubbleTernary = 
    [<Tests>]
    let ``BubbleTernary chart HTML codegeneration tests`` =
        testList "HTMLCodegen.ChartTernary" [
            testList "BubbleTernary" [
            ]
        ]
