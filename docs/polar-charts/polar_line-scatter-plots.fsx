(**
---
title: Polar line and scatter plots
category: Polar Charts
categoryindex: 8
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
# Polar charts

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Script]({{root}}img/badge-script.svg)]({{root}}{{fsdocs-source-basename}}.fsx)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create polar charts in F#.

Let's first create some data for the purpose of creating example charts:

*)

open Plotly.NET

// radial coordinates
let radial = [ 1; 2; 3; 4; 5; 6; 7 ]

// angular coordinates
let theta = [ 0; 45; 90; 135; 200; 320; 184 ]

(**
A polar chart is a graphical method of displaying multivariate data in the form of a two-dimensional chart 
of three or more quantitative variables represented on axes starting from the same point.

The relative position and angle of the axes is typically uninformative.

In Polar Charts, a series is represented by a closed curve that connects points in the polar coordinate system. 
Each data point is determined by the distance from the pole (the radial coordinate) and the angle from the fixed direction (the angular coordinate).

## Polar point charts

Use `Chart.PointPolar` to create a polar plot that displays points on a polar coordinate system:
*)

let pointPolar = Chart.PointPolar(r = radial, theta = theta)
(*** condition: ipynb ***)
#if IPYNB
pointPolar
#endif // IPYNB

(***hide***)
pointPolar |> GenericChart.toChartHTML
(***include-it-raw***)

(**
## Polar line charts

Use `Chart.LinePolar` to create a polar plot that displays a line connecting input the data on a polar coordinate system.

You can, for example, change the line style using `Chart.withLineStyle`
*)

let linePolar =
    Chart.LinePolar(r = radial, theta = theta)
    |> Chart.withLineStyle (Color = Color.fromString "purple", Dash = StyleParam.DrawingStyle.DashDot)

(*** condition: ipynb ***)
#if IPYNB
linePolar
#endif // IPYNB

(***hide***)
linePolar |> GenericChart.toChartHTML
(***include-it-raw***)

(**
## Polar Spline charts

Use `Chart.SpinePolar` to create a polar plot that displays a smoothed line connecting input the data on a polar coordinate system.

As for all other plots above, you can, for example, add labels to each datum:
*)

let splinePolar =
    Chart.SplinePolar(
        r = radial,
        theta = theta,
        MultiText = [ "one"; "two"; "three"; "four"; "five"; "six"; "seven" ],
        TextPosition = StyleParam.TextPosition.TopCenter,
        ShowMarkers = true
    )

(*** condition: ipynb ***)
#if IPYNB
splinePolar
#endif // IPYNB

(***hide***)
splinePolar |> GenericChart.toChartHTML
(***include-it-raw***)
