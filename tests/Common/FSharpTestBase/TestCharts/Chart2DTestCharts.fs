module Chart2DTestCharts

open Plotly.NET

module Point =
    
    let ``Point chart with full plotly.js reference`` =
        let xData = [0. .. 10.]
        let yData = [0. .. 10.]
        Chart.Point(xData, yData, UseDefaults = false)
        |> Chart.withDisplayOptions(
            DisplayOptions.init(
                PlotlyJSReference = Full
            )
        )
        
    let ``Point chart with plotly.js cdn reference`` =
        let xData = [0. .. 10.]
        let yData = [0. .. 10.]
        Chart.Point(xData, yData, UseDefaults = false)
        |> Chart.withDisplayOptions(
            DisplayOptions.init(
                PlotlyJSReference = CDN $"https://cdn.plot.ly/plotly-2.0.0.min"
            )
        )

    let ``Point chart referencing plotly.js using require.js`` =
        let xData = [0. .. 10.]
        let yData = [0. .. 10.]
        Chart.Point(xData, yData, UseDefaults = false)
        |> Chart.withDisplayOptions(
            DisplayOptions.init(
                PlotlyJSReference = Require $"https://cdn.plot.ly/plotly-{Globals.PLOTLYJS_VERSION}.min"
            )
        )

    let ``Point chart with axis labels and title`` =
        let xData = [0. .. 10.]
        let yData = [0. .. 10.]
        Chart.Point(x = xData, y = yData, UseDefaults = false)
        |> Chart.withTitle "Hello world!"
        |> Chart.withXAxisStyle (TitleText = "xAxis", ShowGrid=false)
        |> Chart.withYAxisStyle (TitleText = "yAxis", ShowGrid=false)

    let ``Point chart with text labels`` =
        let x  = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
        let y = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
        let labels  = ["a";"b";"c";"d";"e";"f";"g";"h";"i";"j";]
        Chart.Point(
            x = x,y = y,
            Name="points",
            MultiText=labels,
            TextPosition=StyleParam.TextPosition.TopRight, 
            UseDefaults = false
        )

module Line = 

    let ``Simple line chart`` = Chart.Line([ for x in 1.0 .. 100.0 -> (x, x ** 2.0) ], UseDefaults = false)

    let ``Line chart with line styling`` =
        let x  = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
        let y = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
        Chart.Line(
            x = x,
            y = y,
            Name="line",
            ShowMarkers=true,
            MarkerSymbol=StyleParam.MarkerSymbol.Square,
            UseDefaults = false
        )    
        |> Chart.withLineStyle(Width=2.,Dash=StyleParam.DrawingStyle.Dot)

module Spline =

    let ``Simple spline chart`` = 
        let x  = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
        let y = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
        Chart.Spline(x = x, y = y, Name="spline", UseDefaults = false)   

        
module Bubble = ()

module Range = ()

module Area = 
    
    let ``Simple area chart`` =
        let x  = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
        let y  = [5.; 2.5; 5.; 7.5; 5.; 2.5; 7.5; 4.5; 5.5; 5.]
        Chart.Area(x = x, y = y, UseDefaults = false)

module SplineArea = 
    
    let ``Simple spline area chart`` =
        let x  = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
        let y  = [5.; 2.5; 5.; 7.5; 5.; 2.5; 7.5; 4.5; 5.5; 5.]
        Chart.SplineArea(x = x, y = y, UseDefaults = false)

module StackedArea = 
    
    let ``Two stacked areas chart`` =
        let x  = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
        let y  = [5.; 2.5; 5.; 7.5; 5.; 2.5; 7.5; 4.5; 5.5; 5.]
        [
            Chart.StackedArea(x = x, y = y, UseDefaults = false)
            Chart.StackedArea(x = x, y = (y |> Seq.rev), UseDefaults = false)
        ]
        |> Chart.combine


module Funnel = ()

module StackedFunnel = ()

module Waterfall = ()

module Bar = 

    let ``Simple bar chart`` =
        let values = [20; 14; 23;]
        let keys   = ["Product A"; "Product B"; "Product C";]
        Chart.Bar(values = values, Keys = keys, UseDefaults = false)

    let ``Two stacked bars chart`` =
        let values = [20; 14; 23;]
        let keys   = ["Product A"; "Product B"; "Product C";]
        [
            Chart.StackedBar(values = values, Keys = keys, Name="old", UseDefaults = false);
            Chart.StackedBar(values = [8; 21; 13;], Keys = keys, Name="new", UseDefaults = false)
        ]
        |> Chart.combine

module StackedBar = ()

module Column = 

    let ``Simple column chart`` =
        let values = [20; 14; 23;]
        let keys   = ["Product A"; "Product B"; "Product C";]
        Chart.Column(values = values, Keys = keys, UseDefaults = false)

    let ``Two stacked columns chart`` =
        let values = [20; 14; 23;]
        let keys   = ["Product A"; "Product B"; "Product C";]
        [
            Chart.StackedColumn(values = values, Keys = keys,Name="old", UseDefaults = false);
            Chart.StackedColumn(values = [8; 21; 13;], Keys = keys,Name="new", UseDefaults = false)
        ]
        |> Chart.combine

module StackedColumn = ()

module Histogram = ()

module Histogram2D = ()

module BoxPlot = ()

module Violin = ()

module Histogram2DContour = ()

module Heatmap = ()

module AnnotatedHeatmap = ()

module Image = ()

module Contour = ()

module OHLC = ()

module Candlestick = ()

module Splom = ()

module PointDensity = ()