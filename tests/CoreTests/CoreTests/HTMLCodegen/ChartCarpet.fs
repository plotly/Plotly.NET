module CoreTests.HTMLCodegen.ChartCarpet

open Expecto
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects


open TestUtils.HtmlCodegen
open ChartCarpetTestCharts

module Carpet = 

    [<Tests>]
    let ``Carpet chart HTML codegeneration tests`` =
        testList "HTMLCodegen.ChartCarpet" [
            testList "Carpet" [
            ]
        ]

module ScatterCarpet = 

    [<Tests>]
    let ``ScatterCarpet chart HTML codegeneration tests`` =
        testList "HTMLCodegen.ChartCarpet" [
            testList "ScatterCarpet" [
                testCase "ScatterCarpet data" ( fun () ->
                    """var data = [{"type":"carpet","y":[2.0,3.5,4.0,3.0,4.5,5.0,5.5,6.5,7.5,8.0,8.5,10.0],"a":[4.0,4.0,4.0,4.5,4.5,4.5,5.0,5.0,5.0,6.0,6.0,6.0],"b":[1.0,2.0,3.0,1.0,2.0,3.0,1.0,2.0,3.0,1.0,2.0,3.0],"carpet":"carpet1"},{"type":"scattercarpet","name":"Scatter","mode":"lines+markers","a":[4.0,5.0,5.0,6.0],"b":[1.0,1.0,2.0,3.0],"marker":{"color":["rgba(255, 0, 0, 1.0)","rgba(0, 0, 255, 1.0)","rgba(0, 128, 0, 1.0)","rgba(255, 255, 0, 1.0)"],"symbol":["46","12","32","15"]},"line":{},"carpet":"carpet1"}];"""
                    |> chartGeneratedContains ScatterCarpet.``Simple carpet scatter chart``
                );
                testCase "ScatterCarpet layout" ( fun () ->
                    emptyLayout ScatterCarpet.``Simple carpet scatter chart``
                );
            ]
        ]

module PointCarpet = 

    [<Tests>]
    let ``PointCarpet chart HTML codegeneration tests`` =
        testList "HTMLCodegen.ChartCarpet" [
            testList "PointCarpet" [
                testCase "PointCarpet data" ( fun () ->
                    """var data = [{"type":"carpet","y":[12.0,13.5,14.0,13.0,14.5,15.0,15.5,16.5,17.5,18.0,18.5,20.0],"a":[6.0,6.0,6.0,5.0,5.0,5.0,4.5,4.5,4.5,4.0,4.0,4.0],"b":[3.0,2.0,1.0,3.0,2.0,1.0,3.0,2.0,1.0,3.0,2.0,1.0],"carpet":"carpet2"},{"type":"scattercarpet","name":"Point","mode":"markers","a":[4.0,5.0,5.0,6.0],"b":[1.0,1.0,2.0,3.0],"marker":{},"line":{},"carpet":"carpet2"}];"""
                    |> chartGeneratedContains PointCarpet.``Simple carpet point chart``
                );
                testCase "PointCarpet layout" ( fun () ->
                    emptyLayout PointCarpet.``Simple carpet point chart``
                );
            ]
        ]

module LineCarpet = 

    [<Tests>]
    let ``LineCarpet chart HTML codegeneration tests`` =
        testList "HTMLCodegen.ChartCarpet" [
            testList "LineCarpet" [
                testCase "LineCarpet data" ( fun () ->
                    """var data = [{"type":"carpet","y":[22.0,23.5,24.0,23.0,24.5,25.0,25.5,26.5,27.5,28.0,28.5,30.0],"a":[4.0,4.0,4.0,4.5,4.5,4.5,5.0,5.0,5.0,6.0,6.0,6.0],"b":[1.0,2.0,3.0,1.0,2.0,3.0,1.0,2.0,3.0,1.0,2.0,3.0],"carpet":"carpet3"},{"type":"scattercarpet","name":"Line","mode":"lines","a":[4.0,5.0,5.0,6.0],"b":[1.0,1.0,2.0,3.0],"marker":{},"line":{},"carpet":"carpet3"}];"""
                    |> chartGeneratedContains LineCarpet.``Simple carpet line chart``
                );
                testCase "LineCarpet layout" ( fun () ->
                    emptyLayout LineCarpet.``Simple carpet line chart``
                );
            ]
        ]

module SplineCarpet = 

    [<Tests>]
    let ``SplineCarpet chart HTML codegeneration tests`` =
        testList "HTMLCodegen.ChartCarpet" [
            testList "SplineCarpet" [
                testCase "SplineCarpet data" ( fun () ->
                    """var data = [{"type":"carpet","y":[32.0,33.5,34.0,33.0,34.5,35.0,35.5,36.5,37.5,38.0,38.5,40.0],"a":[6.0,6.0,6.0,5.0,5.0,5.0,4.5,4.5,4.5,4.0,4.0,4.0],"b":[3.0,2.0,1.0,3.0,2.0,1.0,3.0,2.0,1.0,3.0,2.0,1.0],"carpet":"carpet4"},{"type":"scattercarpet","name":"Spline","mode":"lines","a":[4.0,5.0,5.0,6.0],"b":[1.0,1.0,2.0,3.0],"marker":{},"line":{"shape":"spline"},"carpet":"carpet4"}];"""
                    |> chartGeneratedContains SplineCarpet.``Simple carpet spline chart``
                );
                testCase "SplineCarpet layout" ( fun () ->
                    emptyLayout SplineCarpet.``Simple carpet spline chart``
                );
            ]
        ]

module BubbleCarpet = 

    [<Tests>]
    let ``BubbleCarpet chart HTML codegeneration tests`` =
        testList "HTMLCodegen.ChartCarpet" [
            testList "BubbleCarpet" [
                testCase "BubbleCarpet data" ( fun () ->
                    """var data = [{"type":"carpet","y":[42.0,43.5,44.0,43.0,44.5,45.0,45.5,46.5,47.5,48.0,48.5,50.0],"a":[4.0,4.0,4.0,4.5,4.5,4.5,5.0,5.0,5.0,6.0,6.0,6.0],"b":[1.0,2.0,3.0,1.0,2.0,3.0,1.0,2.0,3.0,1.0,2.0,3.0],"carpet":"carpet5"},{"type":"scattercarpet","name":"Bubble","mode":"markers","a":[4.0,5.0,5.0,6.0],"b":[1.0,1.0,2.0,3.0],"marker":{"size":[5,10,15,20]},"line":{},"carpet":"carpet5"}];"""
                    |> chartGeneratedContains BubbleCarpet.``Simple carpet bubble chart``
                );
                testCase "BubbleCarpet layout" ( fun () ->
                    emptyLayout BubbleCarpet.``Simple carpet bubble chart``
                );
            ]
        ]

module ContourCarpet = 

    [<Tests>]
    let ``ContourCarpet chart HTML codegeneration tests`` =
        testList "HTMLCodegen.ChartCarpet" [
            testList "ContourCarpet" [
                testCase "ContourCarpet data" ( fun () ->
                    """var data = [{"type":"carpet","opacity":0.75,"x":[2.0,3.0,4.0,5.0,2.2,3.1,4.1,5.1,1.5,2.5,3.5,4.5],"y":[1.0,1.4,1.6,1.75,2.0,2.5,2.7,2.75,3.0,3.5,3.7,3.75],"a":[0.0,1.0,2.0,3.0,0.0,1.0,2.0,3.0,0.0,1.0,2.0,3.0],"b":[4.0,4.0,4.0,4.0,5.0,5.0,5.0,5.0,6.0,6.0,6.0,6.0],"aaxis":{"type":"linear","tickprefix":"a = ","minorgridcount":9,"smoothing":0.0},"baxis":{"type":"linear","tickprefix":"b = ","minorgridcount":9,"smoothing":0.0},"carpet":"contour"},{"type":"contourcarpet","z":[1.0,1.96,2.56,3.0625,4.0,5.0625,1.0,7.5625,9.0,12.25,15.21,14.0625],"a":[0,1,2,3,0,1,2,3,0,1,2,3],"b":[4,4,4,4,5,5,5,5,6,6,6,6],"line":{"color":"rgba(255, 255, 255, 1.0)"},"carpet":"contour","contours":{"showlabels":true}}];"""
                    |> chartGeneratedContains ContourCarpet.``Styled carpet contour chart``
                );
                testCase "ScatterCarpet layout" ( fun () ->
                    emptyLayout ContourCarpet.``Styled carpet contour chart``
                );
            ]
        ]
    
