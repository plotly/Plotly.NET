(**
---
title: 3D surface plots
category: 3D Charts
categoryindex: 4
index: 2
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
# 3D surface plots

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create 3D surface plots in F#.

Let's first create some data for the purpose of creating example charts:
*)
open System
open Plotly.NET

//---------------------- Generate linearly spaced vector ----------------------
let linspace (min, max, n) =
    if n <= 2 then
        failwithf "n needs to be larger then 2"

    let bw = float (max - min) / (float n - 1.)
    Array.init n (fun i -> min + (bw * float i))

//---------------------- Create example data ----------------------
let size = 100
let x = linspace (-2. * Math.PI, 2. * Math.PI, size)
let y = linspace (-2. * Math.PI, 2. * Math.PI, size)

let f x y = -(5. * x / (x ** 2. + y ** 2. + 1.))

let z = Array.init size (fun i -> Array.init size (fun j -> f x.[j] y.[i]))

let surface = Chart.Surface(zData = z)

(*** condition: ipynb ***)
#if IPYNB
surface
#endif // IPYNB

(***hide***)
surface |> GenericChart.toChartHTML
(*** include-it-raw ***)

// Create simple example data were x y and z is given (z is a xy-Matrix)
let x' = [ 0.; 2.5 ]
let y' = [ 0.; 2.5 ]

let z' =
    [ [ 1.; 1. ] // row wise (length x)
      [ 1.; 2. ] ] // column (length y)

open Plotly.NET.TraceObjects

let surface2 =
    Chart.Surface(zData = z', X = x', Y = y', Opacity = 0.5, Contours = Contours.initXyz (Show = true))

(*** condition: ipynb ***)
#if IPYNB
surface2
#endif // IPYNB

(***hide***)
surface2 |> GenericChart.toChartHTML
(*** include-it-raw ***)
