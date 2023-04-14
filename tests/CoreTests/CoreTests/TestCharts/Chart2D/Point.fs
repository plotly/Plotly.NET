namespace Plotly.NET.Tests.TestCharts.Chart2D

open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open Plotly.NET.GenericChart
open Plotly.NET.StyleParam

/// Test charts created with Chart2D.Chart.Point
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