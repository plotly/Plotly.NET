(**
---
title: Heatmaps
category: Simple Charts
categoryindex: 3
index: 8
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
# Heatmaps

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create heatmap charts in F#.

Let's first create some data for the purpose of creating example charts:

*)

open Plotly.NET

let matrix =
    [ [ 1.; 1.5; 0.7; 2.7 ]; [ 2.; 0.5; 1.2; 1.4 ]; [ 0.1; 2.6; 2.4; 3.0 ] ]

let rownames = [ "p3"; "p2"; "p1" ]
let colnames = [ "Tp0"; "Tp30"; "Tp60"; "Tp160" ]

(**

A heatmap chart can be created using the `Chart.Heatmap` functions.

When creating heatmap charts, it is usually desirable to provide the values in matrix form, rownames and colnames.

A heatmap needs at least two-dimensional data that represents the z dimension. The X and Y dimension sizes can be inferred from the z data:
*)

// Generating the Heatmap with only z Data
let heat1 = Chart.Heatmap(zData = matrix)

(*** condition: ipynb ***)
#if IPYNB
heat1
#endif // IPYNB

(***hide***)
heat1 |> GenericChart.toChartHTML
(***include-it-raw***)

(**
## Inverting the Y Axis

By default, the y axis starts at the origin of the X/Y plane. 
If it is however desired to represent a 2D matrix exactly how it is notated, invert the YAxis by setting `ReverseYAxis`.
*)

// Addning row/column names and inverting the Y axis:
let heat2 =
    Chart.Heatmap(zData = matrix, colNames = colnames, rowNames = rownames, ReverseYAxis = true)

(*** condition: ipynb ***)
#if IPYNB
heat2
#endif // IPYNB

(***hide***)
heat2 |> GenericChart.toChartHTML
(***include-it-raw***)

(**
## Styling Colorbars and using custom color scales

The colorscale can be set via the `ColorScale` argument.
All charts that contain colorbars can be styled by the `Chart.withColorBarStyle` function.
Here is an example that adds a title to the colorbar:
*)

let heat3 =
    Chart.Heatmap(zData = matrix, ColorScale = StyleParam.Colorscale.Viridis)
    |> Chart.withColorBarStyle (TitleText = "Im the ColorBar")

(*** condition: ipynb ***)
#if IPYNB
heat3
#endif // IPYNB

(***hide***)
heat3 |> GenericChart.toChartHTML
(***include-it-raw***)


(**
## Annotated Heatmaps
 
Use `Chart.AnnotatedHeatmap` to add an annotation text to each z value:
*)

let heat4 =
    Chart.AnnotatedHeatmap(
        zData = [ [ 1..5 ]; [ 6..10 ]; [ 11..15 ] ],
        annotationText = [ [ "1,1"; "1,2"; "1,3" ]; [ "2,1"; "2,2"; "2,3" ]; [ "3,1"; "3,2"; "3,3" ] ],
        X = [ "C1"; "C2"; "C3" ],
        Y = [ "R1"; "R2"; "R3" ],
        ReverseYAxis = true
    )

(*** condition: ipynb ***)
#if IPYNB
heat4
#endif // IPYNB

(***hide***)
heat4 |> GenericChart.toChartHTML
(***include-it-raw***)
