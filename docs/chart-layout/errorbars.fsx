(**
---
title: Error bars
category: Chart Layout
categoryindex: 2
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
# Error bars

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to add error bars to plots in F#.

Let's first create some data for the purpose of creating example charts:

*)

open Plotly.NET

let x = [ 1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10. ]
let y' = [ 2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1. ]
let xError = [| 0.2; 0.3; 0.2; 0.1; 0.2; 0.4; 0.2; 0.08; 0.2; 0.1 |]
let yError = [| 0.3; 0.2; 0.1; 0.4; 0.2; 0.4; 0.1; 0.18; 0.02; 0.2 |]
(**
To add error bars to a chart, use the `Chart.with*ErrorStyle` functions for either X, Y, or Z.
*)

let pointsWithErrorBars =
    Chart.Point(x = x, y = y', Name = "points with errors")
    |> Chart.withXErrorStyle (Array = xError, Symmetric = true)
    |> Chart.withYErrorStyle (Array = yError, Arrayminus = xError) // for negative error, use positive values in the `Arrayminus` argument

(*** condition: ipynb ***)
#if IPYNB
pointsWithErrorBars
#endif // IPYNB

(***hide***)
pointsWithErrorBars |> GenericChart.toChartHTML
(***include-it-raw***)
