(**
---
title: Carpet line and scatter plots
category: Carpet Plots
categoryindex: 12
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
# Carpet charts

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Script]({{root}}img/badge-script.svg)]({{root}}{{fsdocs-source-basename}}.fsx)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create carpet charts in F#.

Let's first create some data for the purpose of creating example charts:

*)

open Plotly.NET

//carpet coordinate data
let a = [ 4.; 4.; 4.; 4.5; 4.5; 4.5; 5.; 5.; 5.; 6.; 6.; 6. ]
let b = [ 1.; 2.; 3.; 1.; 2.; 3.; 1.; 2.; 3.; 1.; 2.; 3. ]
let y = [ 2.; 3.5; 4.; 3.; 4.5; 5.; 5.5; 6.5; 7.5; 8.; 8.5; 10. ]

//carpet plot data
let aData = [ 4.; 5.; 5.; 6. ]
let bData = [ 1.; 1.; 2.; 3. ]
let sizes = [ 5; 10; 15; 20 ]

(**
A [carpet plot](https://en.wikipedia.org/wiki/Carpet_plot) is any of a few different specific types of plot. The more common plot referred to as a carpet plot is one that illustrates the interaction between two or more independent variables and one or more dependent variables in a two-dimensional plot. 

Besides the ability to incorporate more variables, another feature that distinguishes a carpet plot from an equivalent contour plot or 3D surface plot is that a carpet plot can be used to more accurately interpolate data points. 

A conventional carpet plot can capture the interaction of up to three independent variables and three dependent variables and still be easily read and interpolated.

Carpet plots have common applications within areas such as material science for showing elastic modulus in laminates, and within aeronautics.

A carpet plot with two independent variables and one dependent variable is often called a cheater plot for the use of a phantom "cheater" axis instead of the horizontal axis. 



## Carpet Traces

In plotly, carpet plots are different to all other trace types in the regard that the coordinate system of the carpet is not set on the layout, but is itself a trace.

Use `Chart.Carpet` to define these `coordinate traces`. All carpets have a mandatory identifier which will be used by other traces to define which carpet coordinate system to use.
*)

let carpet = Chart.Carpet(carpetId = "carpetIdentifier", A = a, B = b, Y = y)

(*** condition: ipynb ***)
#if IPYNB
carpet
#endif // IPYNB

(***hide***)
carpet |> GenericChart.toChartHTML
(***include-it-raw***)

(**
## Carpet point charts

Use `Chart.PointCarpet` to create a point plot on the referenced carpet coordinate system:
*)
let carpetPoint =
    [ carpet
      Chart.PointCarpet(a = aData, b = bData, carpetAnchorId = "carpetIdentifier", Name = "Point") ]
    |> Chart.combine

(*** condition: ipynb ***)
#if IPYNB
carpetPoint
#endif // IPYNB

(***hide***)
carpetPoint |> GenericChart.toChartHTML
(***include-it-raw***)

(**
## Carpet line charts

Use `Chart.LineCarpet` to create a line plot on the referenced carpet coordinate system:
*)

let carpetLine =
    [ carpet
      Chart.LineCarpet(a = aData, b = bData, carpetAnchorId = "carpetIdentifier", Name = "Line") ]
    |> Chart.combine

(*** condition: ipynb ***)
#if IPYNB
carpetLine
#endif // IPYNB

(***hide***)
carpetLine |> GenericChart.toChartHTML
(***include-it-raw***)

(**
## Carpet Spline charts

Use `Chart.LineCarpet` to create a spline plot on the referenced carpet coordinate system:
*)

let carpetSpline =
    [ carpet
      Chart.SplineCarpet(a = aData, b = bData, carpetAnchorId = "carpetIdentifier", Name = "Spline") ]
    |> Chart.combine

(*** condition: ipynb ***)
#if IPYNB
carpetSpline
#endif // IPYNB

(***hide***)
carpetSpline |> GenericChart.toChartHTML
(***include-it-raw***)

(**
## Carpet bubble charts

Use `Chart.LineCarpet` to create a bubble plot on the referenced carpet coordinate system:
*)

let carpetBubble =
    [ carpet
      Chart.BubbleCarpet(absizes = (Seq.zip3 aData bData sizes), carpetAnchorId = "carpetIdentifier", Name = "Bubble") ]
    |> Chart.combine

(*** condition: ipynb ***)
#if IPYNB
carpetBubble
#endif // IPYNB

(***hide***)
carpetBubble |> GenericChart.toChartHTML
(***include-it-raw***)
