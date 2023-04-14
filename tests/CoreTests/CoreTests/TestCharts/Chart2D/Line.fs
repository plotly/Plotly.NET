namespace  Plotly.NET.Tests.TestCharts.Chart2D

open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open Plotly.NET.GenericChart
open Plotly.NET.StyleParam

/// Test charts created with Chart2D.Chart.Line
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