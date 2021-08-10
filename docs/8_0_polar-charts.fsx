(**
---
title: Polar charts
category: Polar Charts
categoryindex: 8
index: 1
---
*)

(*** hide ***)

(*** condition: prepare ***)
#r "nuget: Newtonsoft.JSON, 12.0.3"
#r "../bin/Plotly.NET/netstandard2.0/Plotly.NET.dll"

(*** condition: ipynb ***)
#if IPYNB
#r "nuget: Plotly.NET, {{fsdocs-package-version}}"
#r "nuget: Plotly.NET.Interactive, {{fsdocs-package-version}}"
#endif // IPYNB

(** 
# Polar charts

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath={{fsdocs-source-basename}}.ipynb)&emsp;
[![Script]({{root}}img/badge-script.svg)]({{root}}{{fsdocs-source-basename}}.fsx)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create polar charts in F#.

let's first create some data for the purpose of creating example charts:

*)

open Plotly.NET 
  
let r  = [ 1; 2; 3; 4; 5; 6; 7;]
let r2 = [ 5; 6; 7; 1; 2; 3; 4;]
let r3 = [ 3; 1; 5; 2; 8; 7; 5;]

let t  = [0; 45; 90; 135; 200; 320; 184;]

(**
A polar chart is a graphical method of displaying multivariate data in the form of a two-dimensional chart 
of three or more quantitative variables represented on axes starting from the same point.
The relative position and angle of the axes is typically uninformative.
*)

let polar1 =
        [
            Chart.Polar(r,t,StyleParam.Mode.Markers,Name="1")
            Chart.Polar(r2,t,StyleParam.Mode.Markers,Name="2")
            Chart.Polar(r3,t,StyleParam.Mode.Markers,Name="3")
        ]
        |> Chart.combine

(*** condition: ipynb ***)
#if IPYNB
polar1
#endif // IPYNB

(***hide***)
polar1 |> GenericChart.toChartHTML
(***include-it-raw***)
