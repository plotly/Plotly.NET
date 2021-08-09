module Tests.PolarCharts

open Expecto
open Plotly.NET
open TestUtils
open Plotly.NET.GenericChart
open System

let polar1Chart =
    let r  = [ 1; 2; 3; 4; 5; 6; 7;]
    let r2 = [ 5; 6; 7; 1; 2; 3; 4;]
    let r3 = [ 3; 1; 5; 2; 8; 7; 5;]
    
    let t  = [0; 45; 90; 135; 200; 320; 184;]
    [
        Chart.ScatterPolar(r,t,StyleParam.Mode.Markers,Name="1")
        Chart.ScatterPolar(r2,t,StyleParam.Mode.Markers,Name="2")
        Chart.ScatterPolar(r3,t,StyleParam.Mode.Markers,Name="3")
    ]
    |> Chart.Combine

[<Tests>]
let ``Polar charts`` =
    testList "PolarCharts.Polar charts" [
        testCase " data" ( fun () ->
            "var data = [{\"type\":\"scatterpolar\",\"mode\":\"markers\",\"r\":[1,2,3,4,5,6,7],\"theta\":[0,45,90,135,200,320,184],\"name\":\"1\",\"line\":{},\"marker\":{}},{\"type\":\"scatterpolar\",\"mode\":\"markers\",\"r\":[5,6,7,1,2,3,4],\"theta\":[0,45,90,135,200,320,184],\"name\":\"2\",\"line\":{},\"marker\":{}},{\"type\":\"scatterpolar\",\"mode\":\"markers\",\"r\":[3,1,5,2,8,7,5],\"theta\":[0,45,90,135,200,320,184],\"name\":\"3\",\"line\":{},\"marker\":{}}];"
            |> chartGeneratedContains polar1Chart
        );
        testCase " layout" ( fun () ->
            emptyLayout polar1Chart
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
//    |> Chart.Combine

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