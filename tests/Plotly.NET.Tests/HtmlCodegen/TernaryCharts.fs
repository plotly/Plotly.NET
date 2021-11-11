module Tests.TernaryCharts

open Expecto
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open Plotly.NET.GenericChart
open System

open TestUtils.HtmlCodegen

let pointTernary =
    Chart.PointTernary([1,2,3], UseDefaults = false)
    |> Chart.withAAxis(LinearAxis.init(Title = Title.init("A"), Color = Color.fromKeyword ColorKeyword.DarkOrchid))
    |> Chart.withBAxis(LinearAxis.init(Title = Title.init("B"), Color = Color.fromKeyword ColorKeyword.DarkRed))
    |> Chart.withCAxis(LinearAxis.init(Title = Title.init("C"), Color = Color.fromKeyword ColorKeyword.DarkCyan))

let lineTernary = 
    Chart.LineTernary(
        A = [10; 20; 30; 40; 50; 60; 70; 80;],
        B = ([10; 20; 30; 40; 50; 60; 70; 80;] |> List.rev),
        Sum = 100,
        ShowMarkers = true,
        Dash = StyleParam.DrawingStyle.DashDot, 
        UseDefaults = false
    )
    |> Chart.withTernary(
        Ternary.init(
            AAxis = LinearAxis.init(Color = Color.fromKeyword ColorKeyword.DarkOrchid),
            BAxis = LinearAxis.init(Color = Color.fromKeyword ColorKeyword.DarkRed),
            CAxis = LinearAxis.init(Color = Color.fromKeyword ColorKeyword.DarkCyan)
        )
    )

[<Tests>]
let ``Ternary Point charts`` =
    testList "TernaryCharts.Line charts" [
        testCase "Point data" ( fun () ->
            """var data = [{"type":"scatterternary","mode":"markers","a":[1],"b":[2],"c":[3],"marker":{}}];"""
            |> chartGeneratedContains pointTernary
        )
        testCase "Point layout" ( fun () ->
            """var layout = {"ternary":{"aaxis":{"color":"rgba(153, 50, 204, 1.0)","title":{"text":"A"}},"baxis":{"color":"rgba(139, 0, 0, 1.0)","title":{"text":"B"}},"caxis":{"color":"rgba(0, 139, 139, 1.0)","title":{"text":"C"}}}};"""
            |> chartGeneratedContains pointTernary
        )
    ]

[<Tests>]
let ``Ternary Line charts`` =
    testList "TernaryCharts.Line charts" [
        testCase "Line data" ( fun () ->
            """var data = [{"type":"scatterternary","mode":"lines+markers","a":[10,20,30,40,50,60,70,80],"b":[80,70,60,50,40,30,20,10],"sum":100,"line":{"dash":"dashdot"},"marker":{}}];"""
            |> chartGeneratedContains lineTernary
        )
        testCase "Line layout" ( fun () ->
            """var layout = {"ternary":{"aaxis":{"color":"rgba(153, 50, 204, 1.0)"},"baxis":{"color":"rgba(139, 0, 0, 1.0)"},"caxis":{"color":"rgba(0, 139, 139, 1.0)"}}};"""
            |> chartGeneratedContains lineTernary 
        )
    ]