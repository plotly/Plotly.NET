(**
---
title: Ternary line and scatter plots
category: Ternary Plots
categoryindex: 11
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
# Ternary charts

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Script]({{root}}img/badge-script.svg)]({{root}}{{fsdocs-source-basename}}.fsx)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create ternary charts in F#.

Let's first create some data for the purpose of creating example charts:

*)

open Plotly.NET

// a coordinates
let a = [ 1; 2; 3; 4; 5; 6; 7 ]

// b coordinates
let b = a |> List.rev

//c
let c = [ 2; 2; 2; 2; 2; 2; 2 ]


(**
A Ternary plot is a barycentric plot on three variables which sum to a constant.

It graphically depicts the ratios of the three variables as positions in an equilateral triangle. 

It is used in physical chemistry, petrology, mineralogy, metallurgy, and other physical sciences to show the compositions of systems composed of three species. 
In population genetics, a triangle plot of genotype frequencies is called a de Finetti diagram. In game theory, it is often called a simplex plot.

Ternary plots are tools for analyzing compositional data in the three-dimensional case.

## Ternary point charts

Use `Chart.PointTernary` to create a ternary plot that displays points on a ternary coordinate system:
*)

let ternaryPoint = Chart.PointTernary(A = a, B = b, C = c)
(*** condition: ipynb ***)
#if IPYNB
ternaryPoint
#endif // IPYNB

(***hide***)
ternaryPoint |> GenericChart.toChartHTML
(***include-it-raw***)

(**
## Ternary line charts

Use `Chart.LineTernary` to create a ternary plot that displays a line connecting input the data on a ternary coordinate system.

As values on ternary plots sum to a constant, you can omit one dimension of the data by providing that sum.

You can also, for example, change the line style using `Chart.withLineStyle`:
*)

let lineTernary =
    Chart.LineTernary(A = a, B = b, Sum = 10)
    |> Chart.withLineStyle (Color = Color.fromString "purple", Dash = StyleParam.DrawingStyle.DashDot)

(*** condition: ipynb ***)
#if IPYNB
lineTernary
#endif // IPYNB

(***hide***)
lineTernary |> GenericChart.toChartHTML
(***include-it-raw***)
