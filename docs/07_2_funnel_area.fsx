(**
---
title: FunnelArea Charts
category: Finance Charts
categoryindex: 7
index: 3
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
# FunnelArea Charts

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath={{fsdocs-source-basename}}.ipynb)&emsp;
[![Script]({{root}}img/badge-script.svg)]({{root}}{{fsdocs-source-basename}}.fsx)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create funnel area charts in F#.

let's first create some data for the purpose of creating example charts:
*)

let values = [|5; 4; 3; 2; 1|]
let text = [|"The 1st"; "The 2nd"; "The 3rd"; "The 4th"; "The 5th"|]

(**
FunnelArea charts visualize stages in a process using area-encoded trapezoids. 
This trace can be used to show data in a part-to-whole representation similar to a "pie" trace, 
wherein each item appears in a single stage. See also the the [Funnel]({{root}}/6_1_funnel.html) chart for a different approach 
to visualizing funnel data.
*)

open Plotly.NET 

let line = Line.init (Color=Color.fromString "purple", Width=3.)

let funnelArea = 
    Chart.FunnelArea(Values=values, Text=text, Line=line)

(*** condition: ipynb ***)
#if IPYNB
funnelArea
#endif // IPYNB

(***hide***)
funnelArea |> GenericChart.toChartHTML
(***include-it-raw***)

