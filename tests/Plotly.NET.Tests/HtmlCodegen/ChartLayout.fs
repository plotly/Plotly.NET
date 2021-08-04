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


let subPlotChart =
    let x = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
    let y = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
    [
        Chart.Point(x, y, Name="1,1")
        |> Chart.withX_AxisStyle "x1"
        |> Chart.withY_AxisStyle "y1"    
        Chart.Line(x, y, Name="1,2")
        |> Chart.withX_AxisStyle "x2"
        |> Chart.withY_AxisStyle "y2"
        Chart.Spline(x, y, Name="2,1")
        |> Chart.withX_AxisStyle "x3"
        |> Chart.withY_AxisStyle "y3"    
        Chart.Point(x, y, Name="2,2")
        |> Chart.withX_AxisStyle "x4"
        |> Chart.withY_AxisStyle "y4"
    ]
    |> Chart.Grid(2, 2)


let singleStackChart =
    let x = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
    let y = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
    [
        Chart.Point(x,y) 
        |> Chart.withY_AxisStyle("This title must")
    
        Chart.Line(x,y) 
        |> Chart.withY_AxisStyle("be set on the",Zeroline=false)
        
        Chart.Spline(x,y) 
        |> Chart.withY_AxisStyle("respective subplots",Zeroline=false)
    ]
    |> Chart.SingleStack(Pattern = StyleParam.LayoutGridPattern.Coupled)
    //move xAxis to bottom and increase spacing between plots by using the withLayoutGridStyle function
    |> Chart.withLayoutGridStyle(XSide=StyleParam.LayoutGridXSide.Bottom,YGap= 0.1)
    |> Chart.withTitle("Hi i am the new SingleStackChart")
    |> Chart.withX_AxisStyle("im the shared xAxis")

    
[<Tests>]
let ``Multicharts and subplots`` =
    testList "Multicharts and subplots" [
        testCase "Combining" ( fun () ->
            "var data = [{\"type\":\"scatter\",\"x\":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],\"y\":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],\"mode\":\"lines\",\"line\":{},\"name\":\"first\",\"marker\":{}},{\"type\":\"scatter\",\"x\":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],\"y\":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],\"mode\":\"lines\",\"line\":{},\"name\":\"second\",\"marker\":{}}];"
            |> chartGeneratedContains combinedChart
        );
        testCase "Subplot grids data" ( fun () ->
            "var data = [{\"type\":\"scatter\",\"x\":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],\"y\":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],\"mode\":\"markers\",\"name\":\"1,1\",\"marker\":{},\"xaxis\":\"x\",\"yaxis\":\"y\"},{\"type\":\"scatter\",\"x\":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],\"y\":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],\"mode\":\"lines\",\"line\":{},\"name\":\"1,2\",\"marker\":{},\"xaxis\":\"x2\",\"yaxis\":\"y2\"},{\"type\":\"scatter\",\"x\":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],\"y\":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],\"mode\":\"lines\",\"name\":\"2,1\",\"line\":{\"shape\":\"spline\"},\"marker\":{},\"xaxis\":\"x3\",\"yaxis\":\"y3\"},{\"type\":\"scatter\",\"x\":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],\"y\":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],\"mode\":\"markers\",\"name\":\"2,2\",\"marker\":{},\"xaxis\":\"x4\",\"yaxis\":\"y4\"}];"
            |> chartGeneratedContains subPlotChart
        );
        testCase "Subplot grids layout" ( fun () ->
            "var layout = {\"xaxis\":{\"title\":\"x1\"},\"yaxis\":{\"title\":\"y1\"},\"xaxis2\":{\"title\":\"x2\"},\"yaxis2\":{\"title\":\"y2\"},\"xaxis3\":{\"title\":\"x3\"},\"yaxis3\":{\"title\":\"y3\"},\"xaxis4\":{\"title\":\"x4\"},\"yaxis4\":{\"title\":\"y4\"},\"grid\":{\"rows\":2,\"columns\":2,\"pattern\":\"independent\"}};"
            |> chartGeneratedContains subPlotChart
        );
        testCase "Single Stack data" ( fun () -> 
            "var data = [{\"type\":\"scatter\",\"x\":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],\"y\":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],\"mode\":\"markers\",\"marker\":{},\"xaxis\":\"x\",\"yaxis\":\"y\"},{\"type\":\"scatter\",\"x\":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],\"y\":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],\"mode\":\"lines\",\"line\":{},\"marker\":{},\"xaxis\":\"x\",\"yaxis\":\"y2\"},{\"type\":\"scatter\",\"x\":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],\"y\":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],\"mode\":\"lines\",\"line\":{\"shape\":\"spline\"},\"marker\":{},\"xaxis\":\"x\",\"yaxis\":\"y3\"}];"
            |> chartGeneratedContains singleStackChart
        );
        testCase "Single Stack layout" ( fun () -> 
            "var layout = {\"yaxis\":{\"title\":\"This title must\"},\"xaxis\":{\"title\":\"im the shared xAxis\"},\"xaxis2\":{},\"yaxis2\":{\"title\":\"be set on the\",\"zeroline\":false},\"xaxis3\":{},\"yaxis3\":{\"title\":\"respective subplots\",\"zeroline\":false},\"grid\":{\"rows\":3,\"columns\":1,\"pattern\":\"coupled\",\"ygap\":0.1,\"xside\":\"bottom\"},\"title\":\"Hi i am the new SingleStackChart\"};"
            |> chartGeneratedContains singleStackChart
        );
    ]


let shapesChart =
    let x  = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
    let y' = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
    let s1 = Shape.init (StyleParam.ShapeType.Rectangle,2.,4.,3.,4.,Opacity=0.3,Fillcolor="#d3d3d3")
    let s2 = Shape.init (StyleParam.ShapeType.Rectangle,5.,7.,3.,4.,Opacity=0.3,Fillcolor="#d3d3d3")
    Chart.Line(x,y',Name="line")    
    |> Chart.withShapes([s1;s2])


[<Tests>]
let ``Shapes`` =
    testList "Shapes" [
        testCase "Data" ( fun () ->
            "var data = [{\"type\":\"scatter\",\"x\":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],\"y\":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],\"mode\":\"lines\",\"line\":{},\"name\":\"line\",\"marker\":{}}];"
            |> chartGeneratedContains shapesChart
        );
        testCase "Layout" ( fun () ->
            "var layout = {\"shapes\":[{\"type\":\"rect\",\"x0\":2.0,\"x1\":4.0,\"y0\":3.0,\"y1\":4.0,\"opacity\":0.3,\"fillcolor\":\"#d3d3d3\"},{\"type\":\"rect\",\"x0\":5.0,\"x1\":7.0,\"y0\":3.0,\"y1\":4.0,\"opacity\":0.3,\"fillcolor\":\"#d3d3d3\"}]};"
            |> chartGeneratedContains shapesChart
        );
    ]