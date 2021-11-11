module Tests.PolarCharts

open Expecto
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open Plotly.NET.GenericChart
open System

open TestUtils.HtmlCodegen

//radial coordinates
let radial  = [ 1; 2; 3; 4; 5; 6; 7;]
// angular coordinates
let theta  = [0; 45; 90; 135; 200; 320; 184;]


let pointPolar = Chart.PointPolar(radial,theta, UseDefaults = false)

let linePolar = 
    Chart.LinePolar(radial,theta, UseDefaults = false)
    |> Chart.withLineStyle(Color=Color.fromString "purple",Dash=StyleParam.DrawingStyle.DashDot)

let splinePolar = 
    Chart.SplinePolar(
        radial,
        theta,
        Labels=["one";"two";"three";"four";"five";"six";"seven"],
        TextPosition=StyleParam.TextPosition.TopCenter,
        ShowMarkers=true, 
        UseDefaults = false
    )

[<Tests>]
let ``Polar charts`` =
    testList "PolarCharts.Polar charts" [
        testCase "Polar Point data" ( fun () ->
            """var data = [{"type":"scatterpolar","mode":"markers","r":[1,2,3,4,5,6,7],"theta":[0,45,90,135,200,320,184],"marker":{}}];"""
            |> chartGeneratedContains pointPolar
        );
        testCase "Polar Point layout" ( fun () ->
            emptyLayout pointPolar
        );        
        testCase "Polar Line data" ( fun () ->
            """var data = [{"type":"scatterpolar","mode":"lines","r":[1,2,3,4,5,6,7],"theta":[0,45,90,135,200,320,184],"line":{"color":"purple","dash":"dashdot"},"marker":{}}];"""
            |> chartGeneratedContains linePolar
        );
        testCase "Polar Line layout" ( fun () ->
            emptyLayout linePolar
        );        
        testCase "Polar Spline data" ( fun () ->
            """var data = [{"type":"scatterpolar","mode":"lines+markers+text","r":[1,2,3,4,5,6,7],"theta":[0,45,90,135,200,320,184],"line":{"shape":"spline"},"marker":{},"text":["one","two","three","four","five","six","seven"],"textposition":"top center"}];"""
            |> chartGeneratedContains splinePolar
        );
        testCase "Polar Spline layout" ( fun () ->
            emptyLayout splinePolar
        );
    ]


//let windrose1Chart =
//    let r    = [77.5; 72.5; 70.0; 45.0; 22.5; 42.5; 40.0; 62.5]
//    let r'   = [57.5; 50.0; 45.0; 35.0; 20.0; 22.5; 37.5; 55.0]
//    let r''  = [40.0; 30.0; 30.0; 35.0; 7.5; 7.5; 32.5; 40.0]
//    let r''' = [20.0; 7.5; 15.0; 22.5; 2.5; 2.5; 12.5; 22.5]
    
//    let t = ["North"; "N-E"; "East"; "S-E"; "South"; "S-W"; "West"; "N-W"]
//    [
//        Chart.WindRose (r   ,t,Name="11-14 m/s")
//        Chart.WindRose (r'  ,t,Name="8-11 m/s")
//        Chart.WindRose (r'' ,t,Name="5-8 m/s")
//        Chart.WindRose (r''',t,Name="< 5 m/s")
//    ]
//    |> Chart.combine

//[<Tests>]
//let ``Windrose charts`` =
//    testList "PolarCharts.Windrose charts" [
//        testCase "Windrose data" ( fun () ->
//            "var data = [{\"type\":\"area\",\"r\":[77.5,72.5,70.0,45.0,22.5,42.5,40.0,62.5],\"t\":[\"North\",\"N-E\",\"East\",\"S-E\",\"South\",\"S-W\",\"West\",\"N-W\"],\"name\":\"11-14 m/s\",\"line\":{},\"marker\":{}},{\"type\":\"area\",\"r\":[57.5,50.0,45.0,35.0,20.0,22.5,37.5,55.0],\"t\":[\"North\",\"N-E\",\"East\",\"S-E\",\"South\",\"S-W\",\"West\",\"N-W\"],\"name\":\"8-11 m/s\",\"line\":{},\"marker\":{}},{\"type\":\"area\",\"r\":[40.0,30.0,30.0,35.0,7.5,7.5,32.5,40.0],\"t\":[\"North\",\"N-E\",\"East\",\"S-E\",\"South\",\"S-W\",\"West\",\"N-W\"],\"name\":\"5-8 m/s\",\"line\":{},\"marker\":{}},{\"type\":\"area\",\"r\":[20.0,7.5,15.0,22.5,2.5,2.5,12.5,22.5],\"t\":[\"North\",\"N-E\",\"East\",\"S-E\",\"South\",\"S-W\",\"West\",\"N-W\"],\"name\":\"< 5 m/s\",\"line\":{},\"marker\":{}}];"
//            |> chartGeneratedContains windrose1Chart
//        );
//        testCase "Windrose layout" ( fun () ->
//            emptyLayout windrose1Chart
//        );
//    ]