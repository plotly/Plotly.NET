(**
---
title: 3D line charts
category: 3D Charts
categoryindex: 4
index: 2
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
# 3D line charts

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath={{fsdocs-source-basename}}.ipynb)&emsp;
[![Script]({{root}}img/badge-script.svg)]({{root}}{{fsdocs-source-basename}}.fsx)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create three-dimensional scatter charts in F#.

let's first create some data for the purpose of creating example charts:
*)

open Plotly.NET 
open System
 
let c = [0. .. 0.5 .. 15.]

let x,y,z =  
    c
    |> List.map (fun i ->
        let i' = float i 
        let r = 10. * Math.Cos (i' / 10.)
        (r*Math.Cos i',r*Math.Sin i',i')
    )
    |> List.unzip3

(**
A Scatter3 chart shows a three-dimensional spinnable view of your data.
When using `Lines_Markers` as the mode of the chart, you additionally render a line between the points:
*)

let scatter3dLine = 
    Chart.Scatter3d(x,y,z,StyleParam.Mode.Lines_Markers)
    |> Chart.withXAxisStyle("x-axis")
    |> Chart.withYAxisStyle("y-axis")
    |> Chart.withZAxisStyle("z-axis")
    |> Chart.withSize(800.,800.)

(*** condition: ipynb ***)
#if IPYNB
scatter3dLine
#endif // IPYNB

(***hide***)
scatter3dLine |> GenericChart.toChartHTML
(*** include-it-raw ***)