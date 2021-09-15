(**
---
title: Pie and doughnut Charts
category: Simple Charts
categoryindex: 3
index: 6
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
# Pie and doughnut Charts

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath={{fsdocs-source-basename}}.ipynb)&emsp;
[![Script]({{root}}img/badge-script.svg)]({{root}}{{fsdocs-source-basename}}.fsx)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create pie and doughnut charts in F#.

let's first create some data for the purpose of creating example charts:

*)
open Plotly.NET 
  
let values = [19; 26; 55;]
let labels = ["Residential"; "Non-Residential"; "Utility"]

(**

A pie, doughnut, or sunburst chart can be created using the `Chart.Pie`, `Chart.Doughnut`, and `Chart.Sunburst` functions.
When creating pie charts, it is usually desirable to provide both labels and values.

*)

let pie1 =
    Chart.Pie(values,labels)

(*** condition: ipynb ***)
#if IPYNB
pie1
#endif // IPYNB

(***hide***)
pie1 |> GenericChart.toChartHTML
(***include-it-raw***)

let doughnut1 =
    Chart.Doughnut(
        values,
        labels,
        Hole=0.3,
        TextLabels=labels
    )

(*** condition: ipynb ***)
#if IPYNB
doughnut1
#endif // IPYNB

(***hide***)
doughnut1 |> GenericChart.toChartHTML
(***include-it-raw***)

let sunburst1 =
    Chart.Sunburst(
        ["A";"B";"C";"D";"E"],
        ["";"";"B";"B";""],
        Values=[5.;0.;3.;2.;3.],
        Text=["At";"Bt";"Ct";"Dt";"Et"]
    )

(*** condition: ipynb ***)
#if IPYNB
sunburst1
#endif // IPYNB

(***hide***)
sunburst1 |> GenericChart.toChartHTML
(***include-it-raw***)
