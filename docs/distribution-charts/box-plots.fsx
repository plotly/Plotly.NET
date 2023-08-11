(**
---
title: BoxPlots
category: Distribution Charts
categoryindex: 5
index: 2
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
# BoxPlots

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create boxplot charts in F#.

Let's first create some data for the purpose of creating example charts:
*)

open Plotly.NET

let y = [ 2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1. ]

let x =
    [ "bin1"
      "bin2"
      "bin1"
      "bin2"
      "bin1"
      "bin2"
      "bin1"
      "bin1"
      "bin2"
      "bin1" ]

(**
A box plot or boxplot is a convenient way of graphically depicting groups of numerical data through their quartiles. 
Box plots may also have lines extending vertically from the boxes (whiskers) indicating variability outside the upper
and lower quartiles, hence the terms box-and-whisker plot and box-and-whisker diagram. 
Outliers may be plotted as individual points.
*)

let box1 =
    Chart.BoxPlot(X = x, Y = y, Jitter = 0.1, BoxPoints = StyleParam.BoxPoints.All)

(*** condition: ipynb ***)
#if IPYNB
box1
#endif // IPYNB

(***hide***)
box1 |> GenericChart.toChartHTML
(***include-it-raw***)

(**
By swapping x and y plus using `StyleParam.Orientation.Horizontal`, we can flip the chart horizontally.
*)
let box2 =
    Chart.BoxPlot(
        X = y,
        Y = x,
        Jitter = 0.1,
        BoxPoints = StyleParam.BoxPoints.All,
        Orientation = StyleParam.Orientation.Horizontal
    )

(*** condition: ipynb ***)
#if IPYNB
box2
#endif // IPYNB

(***hide***)
box2 |> GenericChart.toChartHTML
(***include-it-raw***)

(**
You can also produce a boxplot using the `Chart.Combine` syntax.
*)

let y' =
    [ 2.
      1.5
      5.
      1.5
      2.
      2.5
      2.1
      2.5
      1.5
      1.
      2.
      1.5
      5.
      1.5
      3.
      2.5
      2.5
      1.5
      3.5
      1. ]

let box3 =
    [ Chart.BoxPlot(X = "y", Y = y, Name = "bin1", Jitter = 0.1, BoxPoints = StyleParam.BoxPoints.All)
      Chart.BoxPlot(X = "y'", Y = y', Name = "bin2", Jitter = 0.1, BoxPoints = StyleParam.BoxPoints.All) ]
    |> Chart.combine

(*** condition: ipynb ***)
#if IPYNB
box3
#endif // IPYNB

(***hide***)
box3 |> GenericChart.toChartHTML
(***include-it-raw***)
