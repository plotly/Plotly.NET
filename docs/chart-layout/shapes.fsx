(**
---
title: Shapes
category: Chart Layout
categoryindex: 2
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
# Shapes

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create Shapes and add them to the Charts in F#.

Let's first create some data for the purpose of creating example charts:

*)

open Plotly.NET

let x = [ 1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10. ]
let y' = [ 2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1. ]

(**
Use the `Shape.init` function to generate a shape, and either the `Chart.withShape` or the `Chart.withShapes` function to add
multiple shapes at once.

**Attention**: Adding a shape after you added a previous one currently removes the old one. This is a bug and will be fixed
*)

open Plotly.NET.LayoutObjects

let s1 =
    Shape.init (
        ShapeType = StyleParam.ShapeType.Rectangle,
        X0 = 2.,
        X1 = 4.,
        Y0 = 3.,
        Y1 = 4.,
        Opacity = 0.3,
        FillColor = Color.fromHex "#d3d3d3"
    )

let s2 =
    Shape.init (
        ShapeType = StyleParam.ShapeType.Rectangle,
        X0 = 5.,
        X1 = 7.,
        Y0 = 3.,
        Y1 = 4.,
        Opacity = 0.3,
        FillColor = Color.fromHex "#d3d3d3"
    )

let shapes = Chart.Line(x, y', Name = "line") |> Chart.withShapes ([ s1; s2 ])
//|> Chart.withShape(Options.Shape(StyleOption.ShapeType.Rectangle,2.,4.,3.,4.,Opacity=0.3,Fillcolor="#d3d3d3"))

(*** condition: ipynb ***)
#if IPYNB
shapes
#endif // IPYNB

(***hide***)
shapes |> GenericChart.toChartHTML
(***include-it-raw***)
