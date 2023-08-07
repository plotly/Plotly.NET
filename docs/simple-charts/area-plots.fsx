(**
---
title: Area charts
category: Simple Charts
categoryindex: 3
index: 3
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
# Area charts

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create area charts, area charts with splines, and stackes area charts in F#.

Let's first create some data for the purpose of creating example charts:

*)

open Plotly.NET

let x = [ 1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10. ]
let y = [ 5.; 2.5; 5.; 7.5; 5.; 2.5; 7.5; 4.5; 5.5; 5. ]

(**
An area chart or area graph displays graphically quantitive data. It is based on the line chart.
The area between axis and line are commonly emphasized with colors, textures and hatchings.

### Simple area chart
*)

let area1 = Chart.Area(x = x, y = y)

(*** condition: ipynb ***)
#if IPYNB
area1
#endif // IPYNB

(***hide***)
area1 |> GenericChart.toChartHTML
(*** include-it-raw ***)

(**
### Area chart with a spline
*)

let area2 = Chart.SplineArea(x = x, y = y)

(*** condition: ipynb ***)
#if IPYNB
area2
#endif // IPYNB

(***hide***)
area2 |> GenericChart.toChartHTML
(*** include-it-raw ***)

(**
### Stacked Area chart
*)

let stackedArea =
    [ Chart.StackedArea(x = x, y = y)
      Chart.StackedArea(x = x, y = (y |> Seq.rev)) ]
    |> Chart.combine

(*** condition: ipynb ***)
#if IPYNB
stackedArea
#endif // IPYNB

(***hide***)
stackedArea |> GenericChart.toChartHTML
(*** include-it-raw ***)
