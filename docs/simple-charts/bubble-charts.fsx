(**
---
title: Bubble charts
category: Simple Charts
categoryindex: 3
index: 5
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
# Bubble charts

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create bubble charts in F#.

Let's first create some data for the purpose of creating example charts:
*)

open Plotly.NET

let x = [ 2; 4; 6 ]
let y = [ 4; 1; 6 ]
let size = [ 19; 26; 55 ]

(**

A bubble chart is a type of chart that displays three dimensions of data. Each entity with its triplet (x, y, size) 
of associated data is plotted as a disk. The first two values determine the disk's xy location and the 
third its size.

*)

let bubble1 = Chart.Bubble(x = x, y = y, sizes = size)

(*** condition: ipynb ***)
#if IPYNB
bubble1
#endif // IPYNB

(***hide***)
bubble1 |> GenericChart.toChartHTML
(***include-it-raw***)
