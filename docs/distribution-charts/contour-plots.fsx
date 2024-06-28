(**
---
title: Contour plots
category: Distribution Charts
categoryindex: 5
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
# Contour plots

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create contour plot in F#.

Let's first create some data for the purpose of creating example charts:

*)

open System
open Plotly.NET

// Generate linearly spaced vector
let linspace (min, max, n) =
    if n <= 2 then
        failwithf "n needs to be larger then 2"

    let bw = float (max - min) / (float n - 1.)
    [| min..bw..max |]

// Create example data
let size = 100
let x = linspace (-2. * Math.PI, 2. * Math.PI, size)
let y = linspace (-2. * Math.PI, 2. * Math.PI, size)

let f x y = -(5. * x / (x ** 2. + y ** 2. + 1.))

let z = Array.init size (fun i -> Array.init size (fun j -> f x.[j] y.[i]))

(**
A contour plot is a graphical technique for representing a 3-dimensional surface by plotting
constant z slices, called contours, on a 2-dimensional format. That is, given a value for z,
lines are drawn for connecting the (x,y) coordinates where that z value occurs.

The contour plot is an alternative to a 3-D surface plot.

*)

let contour1 = Chart.Contour(zData = z) |> Chart.withSize (600., 600.)

(*** condition: ipynb ***)
#if IPYNB
contour1
#endif // IPYNB

(***hide***)
contour1 |> GenericChart.toChartHTML
(***include-it-raw***)

(**
## Smooth Contour Coloring

To apply heatmap gradient coloring between each contour level, set the `ContourColoring` to `heatmap`:
*)

let contour2 =
    Chart.Contour(zData = z, ContoursColoring = StyleParam.ContourColoring.Heatmap)

(*** condition: ipynb ***)
#if IPYNB
contour2
#endif // IPYNB

(***hide***)
contour2 |> GenericChart.toChartHTML
(***include-it-raw***)

(**
## Contour Line Labels

Use `ContourLabelFont` to set a contour label font, and display the labels with `ShowContourLabels`:

*)

let contour3 =
    Chart.Contour(
        zData = z,
        ContoursColoring = StyleParam.ContourColoring.Heatmap,
        ShowContoursLabels = true,
        ContoursLabelFont = Font.init (Size = 12., Color = Color.fromKeyword White)
    )

(*** condition: ipynb ***)
#if IPYNB
contour3
#endif // IPYNB

(***hide***)
contour3 |> GenericChart.toChartHTML
(***include-it-raw***)
