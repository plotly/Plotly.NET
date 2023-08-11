(**
---
title: Line and scatter plots
category: Simple Charts
categoryindex: 3
index: 1
---
*)

(*** hide ***)

(*** condition: prepare ***)
#r "nuget: Newtonsoft.JSON, 13.0.1"
#r "nuget: DynamicObj, 2.0.0"
#r "nuget: Giraffe.ViewEngine.StrongName, 2.0.0-alpha1"
#r "../../src/Plotly.NET/bin/Release/netstandard2.0/Plotly.NET.dll"

Plotly.NET.Defaults.DefaultDisplayOptions <-
    Plotly.NET.DisplayOptions.init (PlotlyJSReference = Plotly.NET.PlotlyJSReference.NoReference)

(*** condition: ipynb ***)
#if IPYNB
#r "nuget: Plotly.NET, {{fsdocs-package-version}}"
#r "nuget: Plotly.NET.Interactive, {{fsdocs-package-version}}"
#endif // IPYNB

(** 
# Line and scatter plots

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create line and point charts in F#.

Let's first create some data for the purpose of creating example charts:

*)

open Plotly.NET

let x = [ 1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10. ]
let y = [ 2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1. ]

(**

A line or a point chart can be created using the `Chart.Line` and `Chart.Point` functions. 

## Chart.Line with LineStyle

The following example generates a line plot containing X and Y values and applies a line style to it.
*)

let line1 =
    Chart.Line(x = x, y = y, Name = "line", ShowMarkers = true, MarkerSymbol = StyleParam.MarkerSymbol.Square)
    |> Chart.withLineStyle (Width = 2., Dash = StyleParam.DrawingStyle.Dot)

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
    Chart.Line(xy = [ for x in 1.0 .. 100.0 -> (x, x ** 2.0) ])


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

let spline1 = Chart.Spline(x = x, y = y, Name = "spline")

(*** condition: ipynb ***)
#if IPYNB
spline1
#endif // IPYNB

(***hide***)
spline1 |> GenericChart.toChartHTML
(***include-it-raw***)

let spline2 = Chart.Spline(x = x, y = y, Name = "spline", Smoothing = 0.4)

(*** condition: ipynb ***)
#if IPYNB
spline2
#endif // IPYNB

(***hide***)
spline2 |> GenericChart.toChartHTML
(***include-it-raw***)

(** 
## Point chart with text label

The following example calls the `Chart.Point` function to generate a scatter plot containing X and Y values.
Additionally, text labels are added.

If `TextPosition` is set, the labels are drawn, otherwise only shown when hovering over the points.
*)


let labels = [ "a"; "b"; "c"; "d"; "e"; "f"; "g"; "h"; "i"; "j" ]

let pointsWithLabels =
    Chart.Point(x = x, y = y, Name = "points", MultiText = labels, TextPosition = StyleParam.TextPosition.TopRight)

(*** condition: ipynb ***)
#if IPYNB
pointsWithLabels
#endif // IPYNB

(***hide***)
pointsWithLabels |> GenericChart.toChartHTML
(***include-it-raw***)
