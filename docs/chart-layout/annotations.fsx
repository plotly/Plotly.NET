(**
---
title: Annotations
category: Chart Layout
categoryindex: 2
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
# Annotations

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create Shapes and add them to the Charts in F#.

Let's first create some data for the purpose of creating example charts:

*)

open Plotly.NET

let x = [ 1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10. ]
let y = [ 2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1. ]

(**
Use the `Annotation.init` function to generate a shape, and either the `Chart.withAnnotation` or the `Chart.withAnnotations` function to add
multiple annotations at once.

*)

open Plotly.NET.LayoutObjects

let a1 = Annotation.init (X = 2., Y = 4., Text = "Hi there!")

let a2 =
    Annotation.init (
        X = 5.,
        Y = 7.,
        Text = "I am another annotation!",
        BGColor = Color.fromString "white",
        BorderColor = Color.fromString "black"
    )

let annotations =
    Chart.Line(x = x, y = y, Name = "line") |> Chart.withAnnotations ([ a1; a2 ])

(*** condition: ipynb ***)
#if IPYNB
annotations
#endif // IPYNB

(***hide***)
annotations |> GenericChart.toChartHTML
(***include-it-raw***)
