(**
---
title: 2D Histograms
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
# 2D Histograms

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create a bi-dimensional histogram of two data samples in F#.

Let's first create some data for the purpose of creating example charts:
*)

open Plotly.NET

//---------------------- generate random normally distributed data ----------------------
let normal (rnd: System.Random) mu tau =
    let mutable v1 = 2.0 * rnd.NextDouble() - 1.0
    let mutable v2 = 2.0 * rnd.NextDouble() - 1.0
    let mutable r = v1 * v1 + v2 * v2

    while (r >= 1.0 || r = 0.0) do
        v1 <- 2.0 * rnd.NextDouble() - 1.0
        v2 <- 2.0 * rnd.NextDouble() - 1.0
        r <- v1 * v1 + v2 * v2

    let fac = sqrt (-2.0 * (log r) / r)
    (tau * v1 * fac + mu)

let rnd = System.Random()
let n = 2000
let a = -1.
let b = 1.2
let step i = a + ((b - a) / float (n - 1)) * float i

//---------------------- generate data distributed in x and y direction ----------------------
let x = Array.init n (fun i -> ((step i) ** 3.) + (0.3 * (normal (rnd) 0. 2.)))
let y = Array.init n (fun i -> ((step i) ** 6.) + (0.3 * (normal (rnd) 0. 2.)))

(**
A Histogram2D chart can be created using the `Chart.Histogram2D` or `Chart.Histogram2DContour` functions.
*)

let histogramContour =
    Chart.Histogram2DContour(x = x, y = y, ContourLines = Line.init (Width = 0.))

(*** condition: ipynb ***)
#if IPYNB
histogramContour
#endif // IPYNB

(***hide***)
histogramContour |> GenericChart.toChartHTML
(*** include-it-raw ***)

let histogram2D = Chart.Histogram2D(x = x, y = y)

(*** condition: ipynb ***)
#if IPYNB
histogram2D
#endif // IPYNB

(***hide***)
histogram2D |> GenericChart.toChartHTML
(*** include-it-raw ***)
