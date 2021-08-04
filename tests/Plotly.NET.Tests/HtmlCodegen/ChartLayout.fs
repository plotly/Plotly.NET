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


let errorBarsChart =
    let x  = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
    let y' = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
    let xError = [|0.2;0.3;0.2;0.1;0.2;0.4;0.2;0.08;0.2;0.1;|]
    let yError = [|0.3;0.2;0.1;0.4;0.2;0.4;0.1;0.18;0.02;0.2;|]
    Chart.Point(x,y',Name="points with errors")    
    |> Chart.withXErrorStyle (Array=xError,Symmetric=true)
    |> Chart.withYErrorStyle (Array=yError, Arrayminus = xError)


[<Tests>]
let ``Error bars tests`` =
    testList "Error bars tests" [
        testCase "Full data test" ( fun () ->
            "var data = [{\"type\":\"scatter\",\"x\":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],\"y\":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],\"mode\":\"markers\",\"name\":\"points with errors\",\"marker\":{},\"error_x\":{\"symmetric\":true,\"array\":[0.2,0.3,0.2,0.1,0.2,0.4,0.2,0.08,0.2,0.1]},\"error_y\":{\"array\":[0.3,0.2,0.1,0.4,0.2,0.4,0.1,0.18,0.02,0.2],\"arrayminus\":[0.2,0.3,0.2,0.1,0.2,0.4,0.2,0.08,0.2,0.1]}}];"
            |> chartGeneratedContains errorBarsChart
        );
        testCase "Expecting name" ( fun () ->
            "\"name\":\"points with errors\""
            |> chartGeneratedContains errorBarsChart
        );
        testCase "Expecting error X data" ( fun () ->
            "\"error_x\":{\"symmetric\":true,\"array\":[0.2,0.3,0.2,0.1,0.2,0.4,0.2,0.08,0.2,0.1]}"
            |> chartGeneratedContains errorBarsChart
        );
        testCase "Expecting error Y data" ( fun () ->
            "\"error_y\":{\"array\":[0.3,0.2,0.1,0.4,0.2,0.4,0.1,0.18,0.02,0.2],\"arrayminus\":[0.2,0.3,0.2,0.1,0.2,0.4,0.2,0.08,0.2,0.1]}"
            |> chartGeneratedContains errorBarsChart
        );
    ]


let combinedChart =
    let x = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
    let y = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
    [
        Chart.Line(x, y, Name="first")
        Chart.Line(y, x, Name="second")
    ]
    |> Chart.Combine

    
[<Tests>]
let ``Multicharts and subplots`` =
    testList "Multicharts and subplots" [
        testCase "Combining" ( fun () ->
            "var data = [{\"type\":\"scatter\",\"x\":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],\"y\":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],\"mode\":\"lines\",\"line\":{},\"name\":\"first\",\"marker\":{}},{\"type\":\"scatter\",\"x\":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],\"y\":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],\"mode\":\"lines\",\"line\":{},\"name\":\"second\",\"marker\":{}}];"
            |> chartGeneratedContains multipleAxesChart
        );
        testCase "Subplot grids data" ( fun () ->
            [ "var data = [{\"type\":\"scatter\",\"x\":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0]"
              ",\"y\":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],\"mode\":\"lines\",\"line\":{},\"marker\":{}"
              ",\"xaxis\":\"x\",\"yaxis\":\"y\"},{\"type\":\"scatter\",\"x\":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0]"
              ",\"y\":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],\"mode\":\"lines\",\"line\":{},\"marker\":{},\"xaxis\":\"x2\","
              "\"yaxis\":\"y2\"},{\"type\":\"scatter\",\"x\":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0]"
              ",\"y\":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],\"mode\":\"lines\",\"line\":{},\"marker\":{},"
              "\"xaxis\":\"x3\",\"yaxis\":\"y3\"},{\"type\":\"scatter\",\"x\":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0]"
              ",\"y\":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],\"mode\":\"markers\",\"marker\":{},\"xaxis\":\"x4\",\"yaxis\":\"y4\"},"
              "{\"type\":\"scatter\",\"x\":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],\"y\":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"
              "\"mode\":\"markers\",\"marker\":{},\"xaxis\":\"x5\",\"yaxis\":\"y5\"},{\"type\":\"scatter\",\"x\":"
              "[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],\"y\":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0]"
              ",\"mode\":\"markers\",\"marker\":{},\"xaxis\":\"x6\",\"yaxis\":\"y6\"},{\"type\":\"scatter\",\"x\":"
              "[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],\"y\":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],\"mode\":\"lines\",\"line\":"
              "{\"shape\":\"spline\"},\"marker\":{},\"xaxis\":\"x7\",\"yaxis\":\"y7\"},{\"type\":\"scatter\",\"x\":"
              "[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],\"y\":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"
              "\"mode\":\"lines\",\"line\":{\"shape\":\"spline\"},\"marker\":{},\"xaxis\":\"x8\",\"yaxis\":\"y8\"},"
              "{\"type\":\"scatter\",\"x\":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],\"y\":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"
              "\"mode\":\"lines\",\"line\":{\"shape\":\"spline\"},\"marker\":{},\"xaxis\":\"x9\",\"yaxis\":\"y9\"}];"
            ] |> chartGeneratedContainsList multipleAxesChart
        );
        testCase "Subplot grids layout" ( fun () ->
            "var layout = {\"xaxis\":{\"anchor\":\"x\",\"domain\":[0.0,0.3083333333333333]},\"yaxis\":{\"anchor\":\"y\",\"domain\":[0.0,0.3083333333333333]},\"xaxis2\":{\"anchor\":\"x2\",\"domain\":[0.35833333333333334,0.6416666666666666]},\"yaxis2\":{\"anchor\":\"y2\",\"domain\":[0.0,0.3083333333333333]},\"xaxis3\":{\"anchor\":\"x3\",\"domain\":[0.6916666666666667,0.975]},\"yaxis3\":{\"anchor\":\"y3\",\"domain\":[0.0,0.3083333333333333]},\"xaxis4\":{\"anchor\":\"x4\",\"domain\":[0.0,0.3083333333333333]},\"yaxis4\":{\"anchor\":\"y4\",\"domain\":[0.35833333333333334,0.6416666666666666]},\"xaxis5\":{\"anchor\":\"x5\",\"domain\":[0.35833333333333334,0.6416666666666666]},\"yaxis5\":{\"anchor\":\"y5\",\"domain\":[0.35833333333333334,0.6416666666666666]},\"xaxis6\":{\"anchor\":\"x6\",\"domain\":[0.6916666666666667,0.975]},\"yaxis6\":{\"anchor\":\"y6\",\"domain\":[0.35833333333333334,0.6416666666666666]},\"xaxis7\":{\"anchor\":\"x7\",\"domain\":[0.0,0.3083333333333333]},\"yaxis7\":{\"anchor\":\"y7\",\"domain\":[0.6916666666666667,0.975]},\"xaxis8\":{\"anchor\":\"x8\",\"domain\":[0.35833333333333334,0.6416666666666666]},\"yaxis8\":{\"anchor\":\"y8\",\"domain\":[0.6916666666666667,0.975]},\"xaxis9\":{\"anchor\":\"x9\",\"domain\":[0.6916666666666667,0.975]},\"yaxis9\":{\"anchor\":\"y9\",\"domain\":[0.6916666666666667,0.975]},\"grid\":{\"rows\":3,\"columns\":3,\"roworder\":\"top to bottom\",\"pattern\":\"independent\",\"xgap\":0.05,\"ygap\":0.05}};"
            |> chartGeneratedContains multipleAxesChart
        );
        testCase "Single Stack data" ( fun () -> 
            "var data = [{\"type\":\"scatter\",\"x\":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],\"y\":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],\"mode\":\"markers\",\"marker\":{},\"xaxis\":\"x\",\"yaxis\":\"y\"},{\"type\":\"scatter\",\"x\":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],\"y\":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],\"mode\":\"lines\",\"line\":{},\"marker\":{},\"xaxis\":\"x\",\"yaxis\":\"y2\"},{\"type\":\"scatter\",\"x\":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],\"y\":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],\"mode\":\"lines\",\"line\":{\"shape\":\"spline\"},\"marker\":{},\"xaxis\":\"x\",\"yaxis\":\"y3\"}];"
            |> chartGeneratedContains multipleAxesChart
        );
        testCase "Single Stack layout" ( fun () -> 
            "var layout = {\"xaxis\":{\"anchor\":\"x\",\"domain\":[0.0,0.975],\"title\":\"im the shared xAxis\"},\"yaxis\":{\"title\":\"This title must\",\"anchor\":\"y\",\"domain\":[0.0,0.3083333333333333]},\"yaxis2\":{\"title\":\"be set on the\",\"zeroline\":false,\"anchor\":\"y2\",\"domain\":[0.35833333333333334,0.6416666666666666]},\"yaxis3\":{\"title\":\"respective subplots\",\"zeroline\":false,\"anchor\":\"y3\",\"domain\":[0.6916666666666667,0.975]},\"grid\":{\"rows\":3,\"columns\":1,\"roworder\":\"bottom to top\",\"pattern\":\"coupled\",\"xgap\":0.05,\"ygap\":0.1,\"xside\":\"bottom\"},\"title\":\"Hi i am the new SingleStackChart\"};"
            |> chartGeneratedContains multipleAxesChart
        );
    ]