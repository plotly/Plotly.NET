(**
---
title: Layout images
category: Chart Layout
categoryindex: 2
index: 6
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
# Layout images

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create Images and add them to the Charts in F#.

Let's first create some data for the purpose of creating example charts:

*)

open Plotly.NET

let x = [ 1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10. ]
let y = [ 2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1. ]

(**
Use the `LayoutImage.init` function to generate an image, and either the `Chart.withLayoutImage` or the `Chart.withLayoutImages` function to add
multiple annotations at once.

*)

open Plotly.NET.LayoutObjects

let image =
    LayoutImage.init (
        Source = "https://fsharp.org/img/logo/fsharp.svg",
        XRef = "x",
        YRef = "y",
        X = 4,
        Y = 4,
        SizeX = 5,
        SizeY = 3,
        Sizing = StyleParam.LayoutImageSizing.Stretch,
        Opacity = 0.5,
        Layer = StyleParam.Layer.Below
    )

let imageChart =
    Chart.Line(x = x, y = y, Name = "line") |> Chart.withLayoutImage (image)

(*** condition: ipynb ***)
#if IPYNB
imageChart
#endif // IPYNB

(***hide***)
imageChart |> GenericChart.toChartHTML
(***include-it-raw***)
