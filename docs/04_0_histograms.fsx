(**
---
title: Histograms
category: Distribution Charts
categoryindex: 5
index: 1
---
*)


(*** hide ***)

(*** condition: prepare ***)
#r "nuget: Newtonsoft.JSON, 13.0.1"
#r "nuget: DynamicObj, 2.0.0"
#r "../src/Plotly.NET/bin/Release/netstandard2.0/Plotly.NET.dll"

(*** condition: ipynb ***)
#if IPYNB
#r "nuget: Plotly.NET, {{fsdocs-package-version}}"
#r "nuget: Plotly.NET.Interactive, {{fsdocs-package-version}}"
#endif // IPYNB

(** 
# Histograms

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath={{fsdocs-source-basename}}.ipynb)&emsp;
[![Script]({{root}}img/badge-script.svg)]({{root}}{{fsdocs-source-basename}}.fsx)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create a one-dimensional histogram of a data samples in F#.

let's first create some data for the purpose of creating example charts:

*)


open Plotly.NET 

let rnd = System.Random()
let x = [for i=0 to 500 do yield rnd.NextDouble() ]

(**
A histogram consisting of rectangles whose area is proportional to the frequency of a variable and whose width is equal to the class interval.
The histogram chart represents the distribution of numerical data and can be created using the `Chart.Histogram` function:.
*)

let histo1 =
    x
    |> Chart.Histogram
    |> Chart.withSize(500.,500.)

(*** condition: ipynb ***)
#if IPYNB
histo1
#endif // IPYNB

(***hide***)
histo1 |> GenericChart.toChartHTML
(***include-it-raw***)

