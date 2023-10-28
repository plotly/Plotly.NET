(**
---
title: Pareto chart
category: Distribution Charts
categoryindex: 5
index: 9
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
# Pareto chart

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create a Pareto chart in F#.

Let's first create some data for the purpose of creating example charts:

*)

open Plotly.NET

let data =
    [
        "C#"         , 420.
        "F#"         , 10008
        "Smalltalk"  , 777
        "Pascal"     , 543
        "Perl"       , 666
        "VB.NET"     , 640
        "C"          , 111
        "ChucK"      , 1230
        "ARexx"      , 4440
    ]

(**

A Pareto chart is a type of chart that contains both bars and a line graph, where individual values are represented in descending order by bars, and the cumulative total is represented by the line.
The chart is named for the Pareto principle, which, in turn, derives its name from Vilfredo Pareto, a noted Italian economist. <sup>[Source](https://en.wikipedia.org/wiki/Pareto_chart)</sup>
*)

let pareto = Chart.Pareto(keysValues = data, Name="Language", Label="Respondents")

(*** condition: ipynb ***)
#if IPYNB
pareto
#endif // IPYNB

(***hide***)
pareto |> GenericChart.toChartHTML
(***include-it-raw***)

