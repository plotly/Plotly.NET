module Tests.Charts3D

open Expecto
open Plotly.NET
open TestUtils
open Plotly.NET.GenericChart

let scatterChart =
    let x = [19; 26; 55;]
    let y = [19; 26; 55;]
    let z = [19; 26; 55;]

    Chart.Scatter3d(x,y,z,StyleParam.Mode.Markers)
    |> Chart.withX_AxisStyle("my x-axis")
    |> Chart.withY_AxisStyle("my y-axis")
    |> Chart.withZ_AxisStyle("my z-axis")
    |> Chart.withSize(800.,800.)

[<Tests>]
let ``3D Scatter charts`` =
    testList "3D Scatter charts" [
        testCase "3D Scatter charts data" ( fun () ->
            "var data = [{\"type\":\"scatter3d\",\"x\":[19,26,55],\"y\":[19,26,55],\"z\":[19,26,55],\"mode\":\"markers\",\"line\":{},\"marker\":{}}];"
            |> chartGeneratedContains scatterChart
        );
        testCase "3D Scatter charts layout" ( fun () ->
            "var layout = {\"scene\":{\"xaxis\":{\"title\":\"my x-axis\"},\"yaxis\":{\"title\":\"my y-axis\"},\"zaxis\":{\"title\":\"my z-axis\"}},\"width\":800.0,\"height\":800.0};"
            |> chartGeneratedContains scatterChart
        );
    ]