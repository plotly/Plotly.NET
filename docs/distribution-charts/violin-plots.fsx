(**
---
title: Violin plots
category: Distribution Charts
categoryindex: 5
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
# Violin plots

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create violin plot charts in F#.

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
A violin plot is a method of plotting numeric data. It is similar to box plot with a rotated kernel density plot 
on each side. The violin plot is similar to box plots, except that they also show the probability density of the 
data at different values.
*)

let violin1 = Chart.Violin(X = x, Y = y, Points = StyleParam.JitterPoints.All)

(*** condition: ipynb ***)
#if IPYNB
violin1
#endif // IPYNB

(***hide***)
violin1 |> GenericChart.toChartHTML
(***include-it-raw***)

(**
By swapping x and y plus using `StyleParam.Orientation.Horizontal`, we can flip the chart horizontally.
*)
open Plotly.NET.TraceObjects

let violin2 =
    Chart.Violin(
        X = y,
        Y = x,
        Jitter = 0.1,
        Points = StyleParam.JitterPoints.All,
        Orientation = StyleParam.Orientation.Horizontal,
        MeanLine = MeanLine.init (Visible = true)
    )

(*** condition: ipynb ***)
#if IPYNB
violin2
#endif // IPYNB

(***hide***)
violin2 |> GenericChart.toChartHTML
(***include-it-raw***)

(**
You can also produce a violin plot using the `Chart.Combine` syntax.
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

let violin3 =
    [ Chart.Violin(X = "y", Y = y, Name = "bin1", Jitter = 0.1, Points = StyleParam.JitterPoints.All)
      Chart.Violin(X = "y'", Y = y', Name = "bin2", Jitter = 0.1, Points = StyleParam.JitterPoints.All) ]
    |> Chart.combine

(*** condition: ipynb ***)
#if IPYNB
violin3
#endif // IPYNB

(***hide***)
violin3 |> GenericChart.toChartHTML
(***include-it-raw***)
