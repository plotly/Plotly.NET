(**
---
title: 3D Cone plots
category: 3D Charts
categoryindex: 4
index: 4
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
# 3D Cone plots

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create 3D-Cone charts in F#.

*)

open System
open Plotly.NET


let cone =
    Chart.Cone(x = [ 1; 1; 1 ], y = [ 1; 2; 3 ], z = [ 1; 1; 1 ], u = [ 1; 2; 3 ], v = [ 1; 1; 2 ], w = [ 4; 4; 1 ])

(*** condition: ipynb ***)
#if IPYNB
cone
#endif // IPYNB

(***hide***)
cone |> GenericChart.toChartHTML
(*** include-it-raw ***)
