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
            "X axis title quack quack"
            |> chartGeneratedContains axisStylingChart
        );
        testCase "Y With axis has title" ( fun c ->
            "Y axis title boo foo"
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
        testCase "Layout" ( fun c ->
            "var layout = {\"yaxis\":{\"title\":\"axis 1\",\"side\":\"left\"},\"yaxis2\":{\"title\":\"axis2\",\"side\":\"right\",\"overlaying\":\"y\"}};"
            |> chartGeneratedContains multipleAxesChart
        );
        testCase "Passing args to the function" ( fun c ->
            "data, layout, config);"
            |> chartGeneratedContains multipleAxesChart
        )
    ]