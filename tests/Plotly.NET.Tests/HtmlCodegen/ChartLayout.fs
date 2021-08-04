module Tests.ChartLayout

open Expecto
open Plotly.NET
open TestUtils

let axisStylingChart =
    let x = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
    let y = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
    let plot1 =
        Chart.Point(x,y)
        |> Chart.withX_AxisStyle ("X axis title quack quack", MinMax = (-1.,10.))
        |> Chart.withY_AxisStyle ("Y axis title boo foo", MinMax = (-1.,10.))
    plot1


[<Tests>]
let ``Axis styling tests`` =
    testList "Axis styling tests" [
        testCase "X With axis has title" ( fun c ->
            "\"title\":\"X axis title quack quack\""
            |> chartGeneratedContains axisStylingChart
        );
        testCase "Y With axis has title" ( fun c ->
            "\"title\":\"Y axis title boo foo\""
            |> chartGeneratedContains axisStylingChart
        );
        testCase "Should have range" ( fun c ->
            "\"range\":[-1.0,10.0]"
            |> chartGeneratedContains axisStylingChart
        )
    ]


let multipleAxesChart =
    let x = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
    let y = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
    let y' = y |> List.map (fun y -> y * 2.) |> List.rev

    let anchoredAt1 =
        Chart.Line (x,y,Name="anchor 1")
            |> Chart.withAxisAnchor(Y=1)
    
    let anchoredAt2 =
         Chart.Line (x,y',Name="anchor 2")
            |> Chart.withAxisAnchor(Y=2)
    
    let twoXAxes1 = 
        [
           anchoredAt1
           anchoredAt2
        ]
        |> Chart.Combine
        |> Chart.withY_AxisStyle(
            "axis 1",
            Side=StyleParam.Side.Left,
            Id=1
        )
        |> Chart.withY_AxisStyle(
            "axis2",
            Side=StyleParam.Side.Right,
            Id=2,
            Overlaying=StyleParam.AxisAnchorId.Y 1
        )
    twoXAxes1

[<Tests>]
let ``Multiple Axes styling tests`` =
    testList "Multiple Axes styling tests" [
        testCase "Layout" ( fun () ->
            "var layout = {\"yaxis\":{\"title\":\"axis 1\",\"side\":\"left\"},\"yaxis2\":{\"title\":\"axis2\",\"side\":\"right\",\"overlaying\":\"y\"}};"
            |> chartGeneratedContains multipleAxesChart
        );
        testCase "Passing args to the function" ( fun () ->
            "data, layout, config);"
            |> chartGeneratedContains multipleAxesChart
        )
    ]

[<Tests>]
let ``Error bars tests`` =
    testList "Error bars tests" [
        testCase "Full data test" ( fun () ->
            "var data = [{\"type\":\"scatter\",\"x\":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],\"y\":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],\"mode\":\"markers\",\"name\":\"points with errors\",\"marker\":{},\"error_x\":{\"symmetric\":true,\"array\":[0.2,0.3,0.2,0.1,0.2,0.4,0.2,0.08,0.2,0.1]},\"error_y\":{\"array\":[0.3,0.2,0.1,0.4,0.2,0.4,0.1,0.18,0.02,0.2],\"arrayminus\":[0.2,0.3,0.2,0.1,0.2,0.4,0.2,0.08,0.2,0.1]}}];"
            |> chartGeneratedContains multipleAxesChart
        );
        testCase "Expecting name" ( fun () ->
            "\"name\":\"points with errors\""
            |> chartGeneratedContains multipleAxesChart
        );
        testCase "Expecting error X data" ( fun () ->
            "\"error_x\":{\"symmetric\":true,\"array\":[0.2,0.3,0.2,0.1,0.2,0.4,0.2,0.08,0.2,0.1]}"
            |> chartGeneratedContains multipleAxesChart
        );
        testCase "Expecting error Y data" ( fun () ->
            "\"error_y\":{\"array\":[0.3,0.2,0.1,0.4,0.2,0.4,0.1,0.18,0.02,0.2],\"arrayminus\":[0.2,0.3,0.2,0.1,0.2,0.4,0.2,0.08,0.2,0.1]}"
            |> chartGeneratedContains multipleAxesChart
        );
    ]