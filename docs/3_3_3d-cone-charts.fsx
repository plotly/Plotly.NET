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
#r "nuget: Newtonsoft.JSON, 12.0.3"
#r "nuget: DynamicObj"
#r "../bin/Plotly.NET/netstandard2.0/Plotly.NET.dll"

(*** condition: ipynb ***)
#if IPYNB
#r "nuget: Plotly.NET, {{fsdocs-package-version}}"
#r "nuget: Plotly.NET.Interactive, {{fsdocs-package-version}}"
#endif // IPYNB

(** 
# 3D Cone plots

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath={{fsdocs-source-basename}}.ipynb)&emsp;
[![Script]({{root}}img/badge-script.svg)]({{root}}{{fsdocs-source-basename}}.fsx)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create 3D-Cone charts in F#.

*)

open System
open Plotly.NET 


let cone =
    Chart.Cone(
        x = [1; 1; 1],
        y = [1; 2; 3],
        z = [1; 1; 1],
        u = [1; 2; 3],
        v = [1; 1; 2],
        w = [4; 4; 1]
    )

(*** condition: ipynb ***)
#if IPYNB
cone
#endif // IPYNB

(***hide***)
cone |> GenericChart.toChartHTML
(*** include-it-raw ***)
