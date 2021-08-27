module Tests.ChartLayout

open Expecto
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open TestUtils
open Plotly.NET.GenericChart

let axisStylingChart =
    let x = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
    let y = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
    let plot1 =
        Chart.Point(x,y)
        |> Chart.withXAxisStyle ("X axis title quack quack", MinMax = (-1.,10.))
        |> Chart.withYAxisStyle ("Y axis title boo foo", MinMax = (-1.,10.))
    plot1


[<Tests>]
let ``Axis styling`` =
    testList "ChartLayout.Axis styling tests" [
        testCase "X With axis has title" ( fun c ->
            "\"title\":{\"text\":\"X axis title quack quack\"}"
            |> chartGeneratedContains axisStylingChart
        );
        testCase "Y With axis has title" ( fun c ->
            "\"title\":{\"text\":\"Y axis title boo foo\"}"
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
    
    let twoYAxes1 = 
        [
           anchoredAt1
           anchoredAt2
        ]
        |> Chart.combine
        |> Chart.withYAxisStyle(
            "axis 1",
            Side=StyleParam.Side.Left,
            Id= StyleParam.SubPlotId.YAxis 1
        )
        |> Chart.withYAxisStyle(
            "axis2",
            Side=StyleParam.Side.Right,
            Id=StyleParam.SubPlotId.YAxis 2,
            Overlaying=StyleParam.LinearAxisId.Y 1
        )
    twoYAxes1

[<Tests>]
let ``Multiple Axes styling`` =
    testList "ChartLayout.Multiple Axes styling tests" [
        testCase "Layout" ( fun () ->
            "var layout = {\"yaxis\":{\"title\":{\"text\":\"axis 1\"},\"side\":\"left\"},\"yaxis2\":{\"title\":{\"text\":\"axis2\"},\"side\":\"right\",\"overlaying\":\"y\"}};"
            |> chartGeneratedContains multipleAxesChart
        );
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
let ``Error bars`` =
    testList "ChartLayout.Error bars tests" [
        testCase "Full data test" ( fun () ->
            """var data = [{"type":"scatter","mode":"markers","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"name":"points with errors","marker":{},"error_x":{"symmetric":true,"array":[0.2,0.3,0.2,0.1,0.2,0.4,0.2,0.08,0.2,0.1]},"error_y":{"array":[0.3,0.2,0.1,0.4,0.2,0.4,0.1,0.18,0.02,0.2],"arrayminus":[0.2,0.3,0.2,0.1,0.2,0.4,0.2,0.08,0.2,0.1]}}];"""
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
    |> Chart.combine

let subPlotChart =
    let x = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
    let y = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
    [
        Chart.Point(x, y, Name="1,1")
        |> Chart.withXAxisStyle "x1"
        |> Chart.withYAxisStyle "y1"    
        Chart.Line(x, y, Name="1,2")
        |> Chart.withXAxisStyle "x2"
        |> Chart.withYAxisStyle "y2"
        Chart.Spline(x, y, Name="2,1")
        |> Chart.withXAxisStyle "x3"
        |> Chart.withYAxisStyle "y3"    
        Chart.Point(x, y, Name="2,2")
        |> Chart.withXAxisStyle "x4"
        |> Chart.withYAxisStyle "y4"
    ]
    |> Chart.Grid(2, 2)


let singleStackChart =
    let x = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
    let y = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
    [
        Chart.Point(x,y) 
        |> Chart.withYAxisStyle("This title must")
    
        Chart.Line(x,y) 
        |> Chart.withYAxisStyle("be set on the",ZeroLine=false)
        
        Chart.Spline(x,y) 
        |> Chart.withYAxisStyle("respective subplots",ZeroLine=false)
    ]
    |> Chart.SingleStack(Pattern = StyleParam.LayoutGridPattern.Coupled)
    //move xAxis to bottom and increase spacing between plots by using the withLayoutGridStyle function
    |> Chart.withLayoutGridStyle(XSide=StyleParam.LayoutGridXSide.Bottom,YGap= 0.1)
    |> Chart.withTitle("Hi i am the new SingleStackChart")
    |> Chart.withXAxisStyle("im the shared xAxis")
    
[<Tests>]
let ``Multicharts and subplots`` =
    testList "ChartLayout.Multicharts and subplots" [
        testCase "Combining" ( fun () ->
            """var data = [{"type":"scatter","mode":"lines","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"line":{},"name":"first","marker":{}},{"type":"scatter","mode":"lines","x":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"y":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"line":{},"name":"second","marker":{}}];"""
            |> chartGeneratedContains combinedChart
        );
        testCase "Subplot grids data" ( fun () ->
            """var data = [{"type":"scatter","mode":"markers","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"name":"1,1","marker":{},"xaxis":"x","yaxis":"y"},{"type":"scatter","mode":"lines","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"line":{},"name":"1,2","marker":{},"xaxis":"x2","yaxis":"y2"},{"type":"scatter","mode":"lines","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"name":"2,1","line":{"shape":"spline"},"marker":{},"xaxis":"x3","yaxis":"y3"},{"type":"scatter","mode":"markers","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"name":"2,2","marker":{},"xaxis":"x4","yaxis":"y4"}];"""
            |> chartGeneratedContains subPlotChart
        );
        testCase "Subplot grids layout" ( fun () ->
            "var layout = {\"xaxis\":{\"title\":{\"text\":\"x1\"}},\"yaxis\":{\"title\":{\"text\":\"y1\"}},\"xaxis2\":{\"title\":{\"text\":\"x2\"}},\"yaxis2\":{\"title\":{\"text\":\"y2\"}},\"xaxis3\":{\"title\":{\"text\":\"x3\"}},\"yaxis3\":{\"title\":{\"text\":\"y3\"}},\"xaxis4\":{\"title\":{\"text\":\"x4\"}},\"yaxis4\":{\"title\":{\"text\":\"y4\"}},\"grid\":{\"rows\":2,\"columns\":2,\"pattern\":\"independent\"}};"
            |> chartGeneratedContains subPlotChart
        );
        testCase "Single Stack data" ( fun () -> 
            """var data = [{"type":"scatter","mode":"markers","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"marker":{},"xaxis":"x","yaxis":"y"},{"type":"scatter","mode":"lines","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"line":{},"marker":{},"xaxis":"x","yaxis":"y2"},{"type":"scatter","mode":"lines","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"line":{"shape":"spline"},"marker":{},"xaxis":"x","yaxis":"y3"}];"""
            |> chartGeneratedContains singleStackChart
        );
        testCase "Single Stack layout" ( fun () -> 
            "var layout = {\"yaxis\":{\"title\":{\"text\":\"This title must\"}},\"xaxis\":{\"title\":{\"text\":\"im the shared xAxis\"}},\"xaxis2\":{},\"yaxis2\":{\"title\":{\"text\":\"be set on the\"},\"zeroline\":false},\"xaxis3\":{},\"yaxis3\":{\"title\":{\"text\":\"respective subplots\"},\"zeroline\":false},\"grid\":{\"rows\":3,\"columns\":1,\"pattern\":\"coupled\",\"ygap\":0.1,\"xside\":\"bottom\"},\"title\":{\"text\":\"Hi i am the new SingleStackChart\"}};"
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
    testList "ChartLayout.Shapes" [
        testCase "Data" ( fun () ->
            """var data = [{"type":"scatter","mode":"lines","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"line":{},"name":"line","marker":{}}];"""
            |> chartGeneratedContains shapesChart
        );
        testCase "Layout" ( fun () ->
            "var layout = {\"shapes\":[{\"type\":\"rect\",\"x0\":2.0,\"x1\":4.0,\"y0\":3.0,\"y1\":4.0,\"opacity\":0.3,\"fillcolor\":\"#d3d3d3\"},{\"type\":\"rect\",\"x0\":5.0,\"x1\":7.0,\"y0\":3.0,\"y1\":4.0,\"opacity\":0.3,\"fillcolor\":\"#d3d3d3\"}]};"
            |> chartGeneratedContains shapesChart
        );
    ]

let displayOptionsChartDescriptionChart =
    let x = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
    let y = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
    let description1 = ChartDescription.create "Hello" "F#"
    Chart.Point(x,y,Name="desc1")    
    |> Chart.withDescription(description1)

let additionalHeadTagsChart =
    let x = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
    let y = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
    let bulmaHero = """<section class="hero is-primary is-bold">
    <div class="hero-body">
      <p class="title">
        Hero title
      </p>
      <p class="subtitle">
        Hero subtitle
      </p>
    </div>
    </section>
    """
    
    // chart description containing bulma classes
    let description3 =
      ChartDescription.create 
          """<h1 class="title">I am heading</h1>""" 
         bulmaHero
    Chart.Point(x,y,Name="desc3")    
    |> Chart.withDescription description3
    // Add reference to the bulma css framework
    |> Chart.withAdditionalHeadTags ["""<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bulma@0.9.2/css/bulma.min.css">"""]

let mathtexChart =
    [
        Chart.Point([(1.,2.)],@"$\beta_{1c} = 25 \pm 11 \text{ km s}^{-1}$")
        Chart.Point([(2.,4.)],@"$\beta_{1c} = 25 \pm 11 \text{ km s}^{-1}$")
    ]
    |> Chart.combine
    |> Chart.withTitle @"$\beta_{1c} = 25 \pm 11 \text{ km s}^{-1}$"
    // include mathtex tags in <head>. pass true to append these scripts, false to ONLY include MathTeX.
    |> Chart.withMathTex(true)

[<Tests>]
let ``Display options`` =
    testList "ChartLayout.Display options" [
        testCase "Chart description data" ( fun () ->
            """var data = [{"type":"scatter","mode":"markers","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"name":"desc1","marker":{}}];"""
            |> chartGeneratedContains displayOptionsChartDescriptionChart
        );
        testCase "Chart description layout" ( fun () ->
            "var layout = {};"
            |> chartGeneratedContains displayOptionsChartDescriptionChart
        );
        testCase "Chart description header" ( fun () ->
            "<h3>Hello</h3>"
            |> substringIsInChart displayOptionsChartDescriptionChart toEmbeddedHTML
        );
        testCase "Chart description paragraph" ( fun () ->
            "<p>F#</p>"
            |> substringIsInChart displayOptionsChartDescriptionChart toEmbeddedHTML
        );
        testCase "Additional head tags" ( fun () ->
            [ "<h3><h1 class=\"title\">I am heading</h1></h3>"
              "<p><section class=\"hero is-primary is-bold\">"
              "<div class=\"hero-body\">"
              "<p class=\"title\">"
              "Hero title"
              "<p class=\"subtitle\">"
              "Hero subtitle"
            ]
            |> substringListIsInChart additionalHeadTagsChart toEmbeddedHTML
        );
        testCase "MathTex data" ( fun () ->
            """var data = [{"type":"scatter","mode":"markers","x":[1.0],"y":[2.0],"name":"$\\beta_{1c} = 25 \\pm 11 \\text{ km s}^{-1}$","marker":{}},{"type":"scatter","mode":"markers","x":[2.0],"y":[4.0],"name":"$\\beta_{1c} = 25 \\pm 11 \\text{ km s}^{-1}$","marker":{}}];"""
            |> chartGeneratedContains mathtexChart
        );
        testCase "MathTex layout" ( fun () ->
            "var layout = {\"title\":{\"text\":\"$\\\\beta_{1c} = 25 \\\\pm 11 \\\\text{ km s}^{-1}$\"}};"
            |> chartGeneratedContains mathtexChart
        );
        testCase "MathTex include mathjax" ( fun () ->
            "https://cdnjs.cloudflare.com/ajax/libs/mathjax/"
            |> substringIsInChart mathtexChart toEmbeddedHTML
        )
    ]