(**
---
title: 3D streamtube plots
category: 3D Charts
categoryindex: 4
index: 5
---
*)

(*** hide ***)

(*** condition: prepare ***)
#r "nuget: Newtonsoft.JSON, 13.0.1"
#r "nuget: DynamicObj, 2.0.0"
#r "nuget: Giraffe.ViewEngine.StrongName, 2.0.0-alpha1"
#r "../data/Deedle.dll"
#r "../../src/Plotly.NET/bin/Release/netstandard2.0/Plotly.NET.dll"

Plotly.NET.Defaults.DefaultDisplayOptions <-
    Plotly.NET.DisplayOptions.init (PlotlyJSReference = Plotly.NET.PlotlyJSReference.NoReference)

(*** condition: ipynb ***)
#if IPYNB
#r "nuget: Plotly.NET, {{fsdocs-package-version}}"
#r "nuget: Plotly.NET.Interactive, {{fsdocs-package-version}}"
#endif // IPYNB

(** 
# 3D Streamtube plots

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create 3D-StreamTube charts in F#.

Let's first create some data for the purpose of creating example charts:
*)

open Deedle
open System
open Plotly.NET
open Plotly.NET.TraceObjects

let tubeData =
    __SOURCE_DIRECTORY__ + "/../data/streamtube-wind.csv"
    |> Frame.ReadCsv

let streamTube =
    Chart.StreamTube(
        x = (tubeData.["x"] |> Series.values),
        y = (tubeData.["y"] |> Series.values),
        z = (tubeData.["z"] |> Series.values),
        u = (tubeData.["u"] |> Series.values),
        v = (tubeData.["v"] |> Series.values),
        w = (tubeData.["w"] |> Series.values),
        TubeStarts =
            StreamTubeStarts.init (
                X = Array.init 16 (fun _ -> 80),
                Y = [ 20; 30; 40; 50; 20; 30; 40; 50; 20; 30; 40; 50; 20; 30; 40; 50 ],
                Z = [ 0; 0; 0; 0; 5; 5; 5; 5; 10; 10; 10; 10; 15; 15; 15; 15 ]
            )
    )


(*** condition: ipynb ***)
#if IPYNB
streamTube
#endif // IPYNB

(***hide***)
streamTube |> GenericChart.toChartHTML
(*** include-it-raw ***)
