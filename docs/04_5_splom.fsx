(**
---
title: Scatterplot matrix
category: Distribution Charts
categoryindex: 5
index: 5
---
*)

(*** hide ***)

(*** condition: prepare ***)
#r "nuget: Newtonsoft.JSON, 12.0.3"
#r "nuget: DynamicObj"
#r "../bin/Plotly.NET/netstandard2.0/Plotly.NET.dll"

(*** condition: ipynb ***)
#if IPYNB
#r "nuget: Plotly.NET, {{fsdocs-package-version}}"
#r "nuget: Plotly.NET.Interactive, {{fsdocs-package-version}}"
#endif // IPYNB

(** 
# Scatterplot matrix 

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath={{fsdocs-source-basename}}.ipynb)&emsp;
[![Script]({{root}}img/badge-script.svg)]({{root}}{{fsdocs-source-basename}}.fsx)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to plot a scatterplot matrix (splom) in F#.

let's first create some data for the purpose of creating example charts:

*)

open Plotly.NET 

let data = 
    [
        "A",[|1.;4.;3.4;0.7;|]
        "B",[|3.;1.5;1.7;2.3;|]
        "C",[|2.;4.;3.1;5.|]
        "D",[|4.;2.;2.;4.;|]
    ]

(**
Using a scatterplot matrix of several different variables can help to determine whether there are any
relationships among the variables in the dataset.

**Attention**: this function is not very well tested and does not use the `Chart.Grid` functionality. 
Until that is fixed, consider creating splom plot programatically using `Chart.Grid` for more control.
*)

let splom1 =
    Chart.Splom(data,Color=Color.fromString "blue")

(*** condition: ipynb ***)
#if IPYNB
splom1
#endif // IPYNB

(***hide***)
splom1 |> GenericChart.toChartHTML
(***include-it-raw***)





