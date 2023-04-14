module Tests.SmithCharts

open Expecto
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open Plotly.NET.GenericChart
open System

open TestUtils.HtmlCodegen

let scatterSmithChart =
    Chart.ScatterSmith(
        real = [0.5; 1.; 2.; 3.],
        imag = [0.5; 1.; 2.; 3.],
        mode = StyleParam.Mode.Lines_Markers_Text,
        MultiText = ["Pretty"; "Cool"; "Plot"; "Huh?"],
        TextPosition = StyleParam.TextPosition.TopCenter,
        UseDefaults = false
    )

let pointSmithChart =
    Chart.PointSmith(
        real = [0.5; 1.; 2.; 3.],
        imag = [0.5; 1.; 2.; 3.],
        UseDefaults = false
    )

let lineSmithChart =
    Chart.LineSmith(
        real = [0.5; 1.; 2.; 3.],
        imag = [0.5; 1.; 2.; 3.],
        LineDash = StyleParam.DrawingStyle.DashDot,
        LineColor = Color.fromKeyword Purple,
        UseDefaults = false
    )

let bubbleSmithChart =
    Chart.BubbleSmith(
        real = [0.5; 1.; 2.; 3.],
        imag = [0.5; 1.; 2.; 3.],
        sizes = [10;20;30;40],
        MultiText=["one";"two";"three";"four";"five";"six";"seven"],
        TextPosition=StyleParam.TextPosition.TopCenter,
        UseDefaults = false
    )


[<Tests>]
let ``Smith Scatter charts`` =
    testList "SmithCharts.Scatter charts" [
        testCase "Scatter data" ( fun () ->
            """var data = [{"type":"scattersmith","mode":"lines+markers+text","imag":[0.5,1.0,2.0,3.0],"real":[0.5,1.0,2.0,3.0],"text":["Pretty","Cool","Plot","Huh?"],"textposition":"top center","marker":{},"line":{}}];"""
            |> chartGeneratedContains scatterSmithChart
        )
        testCase "Scatter layout" ( fun () ->
            emptyLayout scatterSmithChart
        )
    ]

[<Tests>]
let ``Smith Point charts`` =
    testList "SmithCharts.Point charts" [
        testCase "Point data" ( fun () ->
            """var data = [{"type":"scattersmith","mode":"markers","imag":[0.5,1.0,2.0,3.0],"real":[0.5,1.0,2.0,3.0],"marker":{},"line":{}}];"""
            |> chartGeneratedContains pointSmithChart
        )
        testCase "Point layout" ( fun () ->
            emptyLayout pointSmithChart
        )
    ]

[<Tests>]
let ``Smith Line charts`` =
    testList "SmithCharts.Line charts" [
        testCase "Line data" ( fun () ->
            """var data = [{"type":"scattersmith","mode":"lines","imag":[0.5,1.0,2.0,3.0],"real":[0.5,1.0,2.0,3.0],"marker":{},"line":{"color":"rgba(128, 0, 128, 1.0)","dash":"dashdot"}}];"""
            |> chartGeneratedContains lineSmithChart
        )
        testCase "Line layout" ( fun () ->
            emptyLayout lineSmithChart 
        )
    ]

[<Tests>]
let ``Smith Bubble charts`` =
    testList "SmithCharts.Bubble charts" [
        testCase "Bubble data" ( fun () ->
            """var data = [{"type":"scattersmith","mode":"markers+text","imag":[0.5,1.0,2.0,3.0],"real":[0.5,1.0,2.0,3.0],"text":["one","two","three","four","five","six","seven"],"textposition":"top center","marker":{"size":[10,20,30,40]},"line":{}}];"""
            |> chartGeneratedContains bubbleSmithChart
        )
        testCase "Bubble layout" ( fun () ->
            emptyLayout bubbleSmithChart 
        )
    ]