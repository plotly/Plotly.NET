(**
---
title: 3D IsoSurface plots
category: 3D Charts
categoryindex: 4
index: 7
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
# 3D IsoSurface plots

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create 3D-IsoSurface charts in F#.

Let's first create some data for the purpose of creating example charts:
*)

open System
open Plotly.NET

let linspace (min, max, n) =
    if n <= 2 then
        failwithf "n needs to be larger then 2"

    let bw = float (max - min) / (float n - 1.)
    Array.init n (fun i -> min + (bw * float i))

let mgrid (min, max, n) =

    let data = linspace (min, max, n)

    let z =
        [| for i in 1..n do
               [| for i in 1..n do
                      yield data |] |]

    let x =
        [| for i in 1..n do
               [| for j in 1..n do
                      yield
                          [| for k in 1..n do
                                 yield data.[i - 1] |] |] |]

    let y =
        [| for i in 1..n do
               [| for j in 1..n do
                      yield
                          [| for k in 1..n do
                                 yield data.[j - 1] |] |] |]

    x, y, z

let xIso, yIso, zIso =
    mgrid (-5., 5., 40)
    |> fun (x, y, z) ->
        (x |> Array.concat |> Array.concat), (y |> Array.concat |> Array.concat), (z |> Array.concat |> Array.concat)

let valueIso =
    Array.map3 (fun x y z -> x * x * 0.5 + y * y + z * z * 2.) xIso yIso zIso

open Plotly.NET.TraceObjects

let isoSurface =
    Chart.IsoSurface(
        x = xIso,
        y = yIso,
        z = zIso,
        value = valueIso,
        IsoMin = 10.,
        IsoMax = 40.,
        Caps = Caps.init (X = (CapFill.init (Show = false)), Y = (CapFill.init (Show = false))),
        Surface = Surface.init (Count = 5)
    )

(*** condition: ipynb ***)
#if IPYNB
isoSurface
#endif // IPYNB

(***hide***)
isoSurface |> GenericChart.toChartHTML
(*** include-it-raw ***)
