(**
---
title: 3D Mesh plots
category: 3D Charts
categoryindex: 4
index: 3
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
# 3D Mesh plots

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create 3D-Mesh charts in F#.

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
//[|min ..bw ..max|]

//---------------------- Create example data ----------------------
let size = 100
let x = linspace (-2. * Math.PI, 2. * Math.PI, size)
let y = linspace (-2. * Math.PI, 2. * Math.PI, size)

let f x y = -(5. * x / (x ** 2. + y ** 2. + 1.))

let z = Array.init size (fun i -> Array.init size (fun j -> f x.[j] y.[i]))

let rnd = System.Random()
let a = Array.init 50 (fun _ -> rnd.NextDouble())
let b = Array.init 50 (fun _ -> rnd.NextDouble())
let c = Array.init 50 (fun _ -> rnd.NextDouble())

open Plotly.NET.TraceObjects

let mesh3d = Chart.Mesh3D(x = a, y = b, z = c, FlatShading = true)

(*** condition: ipynb ***)
#if IPYNB
mesh3d
#endif // IPYNB

(***hide***)
mesh3d |> GenericChart.toChartHTML
(*** include-it-raw ***)
