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
        Chart.Polar(r,t,StyleParam.Mode.Markers,Name="1")
        Chart.Polar(r2,t,StyleParam.Mode.Markers,Name="2")
        Chart.Polar(r3,t,StyleParam.Mode.Markers,Name="3")
    ]
    |> Chart.Combine

[<Tests>]
let ``Polar charts`` =
    testList "PolarCharts.Polar charts" [
        testCase " data" ( fun () ->
            "var data = [{\"type\":\"scatter\",\"mode\":\"markers\",\"r\":[1,2,3,4,5,6,7],\"t\":[0,45,90,135,200,320,184],\"name\":\"1\",\"line\":{},\"marker\":{}},{\"type\":\"scatter\",\"mode\":\"markers\",\"r\":[5,6,7,1,2,3,4],\"t\":[0,45,90,135,200,320,184],\"name\":\"2\",\"line\":{},\"marker\":{}},{\"type\":\"scatter\",\"mode\":\"markers\",\"r\":[3,1,5,2,8,7,5],\"t\":[0,45,90,135,200,320,184],\"name\":\"3\",\"line\":{},\"marker\":{}}];"
            |> chartGeneratedContains polar1Chart
        );
        testCase " layout" ( fun () ->
            emptyLayout polar1Chart
        );
    ]