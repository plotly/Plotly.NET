(*** hide ***)

(*** condition: prepare ***)
#r "../bin/Plotly.NET/net5.0/Plotly.NET.dll"
(*** condition: fsx ***)
#if FSX
#r "../packages/Newtonsoft.Json/lib/netstandard2.0/Newtonsoft.Json.dll"
#r "../bin/Plotly.NET/net5.0/Plotly.NET.dll"
#endif // FSX
(*** condition: ipynb ***)
#if IPYNB
#r "nuget: Plotly.NET, 2.0.0-beta1"
#r "nuget: Plotly.NET.Interactive, 2.0.0-alpha5"
#endif // IPYNB

(** 
# Line and scatter plots

[![Binder](https://mybinder.org/badge_logo.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=line-scatter-plots.ipynb)

*Summary:* This example shows how to create line and point charts in F#.

let's first create some data for the purpose of creating example charts:

*)

open Plotly.NET 
  
let x  = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
let y = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]

(**

A line or a point chart can be created using the `Chart.Line` and `Chart.Point` functions. 

## Chart.Line with LineStyle

The following example generates a line Plot containing X and Y values and applies a line style to it.
*)

let line1 =
    Chart.Line(
        x,y,
        Name="line",
        ShowMarkers=true,
        MarkerSymbol=StyleParam.Symbol.Square)    
    |> Chart.withLineStyle(Width=2,Dash=StyleParam.DrawingStyle.Dot)

(*** condition: ipynb ***)
#if IPYNB
line1
#endif // IPYNB

(***hide***)
line1 |> GenericChart.toChartHTML
(***include-it-raw***)

(** 

## Pipelining into Chart.Line
The following example calls the `Chart.Line` method with a list of X and Y values as tuples. The snippet generates
values of a simple function, f(x)=x^2. The values of the function are generated for X ranging from 1 to 100. The chart generated is 
shown below.
*)

let line2 =
    // Drawing graph of a 'square' function 
    [ for x in 1.0 .. 100.0 -> (x, x ** 2.0) ]
    |> Chart.Line

(*** condition: ipynb ***)
#if IPYNB
line2
#endif // IPYNB

(***hide***)
line2 |> GenericChart.toChartHTML
(***include-it-raw***)

(**
## Spline charts

Spline charts interpolate the curves between single points of 
the chart to generate a smoother version of the line chart.
*)

let spline1 = Chart.Spline(x,y,Name="spline")    

(*** condition: ipynb ***)
#if IPYNB
spline1
#endif // IPYNB

(***hide***)
spline1 |> GenericChart.toChartHTML
(***include-it-raw***)

let spline2 = 
    Chart.Spline(
        x,y,
        Name="spline",
        Smoothing = 0.4
    )      
    
(*** condition: ipynb ***)
#if IPYNB
spline2
#endif // IPYNB

(***hide***)
spline2 |> GenericChart.toChartHTML
(***include-it-raw***)

(** 
## Point chart with text label

The following example calls the `Chart.Point` function to generate a scatter Plot containing X and Y values.
Addtionally, text labels are added . 

If `TextPosition` is set the labels are drawn otherwise only shown when hovering over the points.
*)


let labels  = ["a";"b";"c";"d";"e";"f";"g";"h";"i";"j";]

let pointsWithLabels =
    Chart.Point(
        x,y,
        Name="points",
        Labels=labels,
        TextPosition=StyleParam.TextPosition.TopRight
    )    

(*** condition: ipynb ***)
#if IPYNB
pointsWithLabels
#endif // IPYNB

(***hide***)
pointsWithLabels |> GenericChart.toChartHTML
(***include-it-raw***)