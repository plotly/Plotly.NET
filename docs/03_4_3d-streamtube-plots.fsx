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
#r "nuget: DynamicObj, 1.0.1"
#r "../bin/Plotly.NET/netstandard2.0/Plotly.NET.dll"

(*** condition: ipynb ***)
#if IPYNB
#r "nuget: Plotly.NET, {{fsdocs-package-version}}"
#r "nuget: Plotly.NET.Interactive, {{fsdocs-package-version}}"
#endif // IPYNB

(** 
# 3D Mesh plots

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath={{fsdocs-source-basename}}.ipynb)&emsp;
[![Script]({{root}}img/badge-script.svg)]({{root}}{{fsdocs-source-basename}}.fsx)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create 3D-StreamTube charts in F#.

let's first create some data for the purpose of creating example charts:
*)

#r "nuget: Deedle"
#r "nuget: FSharp.Data"
open Deedle
open FSharp.Data
open System
open Plotly.NET 
open Plotly.NET.TraceObjects

let tubeData =
    Http.RequestString @"https://raw.githubusercontent.com/plotly/datasets/master/streamtube-wind.csv"
    |> Frame.ReadCsvString

let streamTube = 
    Chart.StreamTube(
        x = (tubeData.["x"] |> Series.values),
        y = (tubeData.["y"] |> Series.values),
        z = (tubeData.["z"] |> Series.values),
        u = (tubeData.["u"] |> Series.values),
        v = (tubeData.["v"] |> Series.values),
        w = (tubeData.["w"] |> Series.values),
        TubeStarts = 
            StreamTubeStarts.init(
                X = Array.init 16 (fun _ -> 80),
                Y = [20;30;40;50;20;30;40;50;20;30;40;50;20;30;40;50],
                Z = [0;0;0;0;5;5;5;5;10;10;10;10;15;15;15;15]
            )
    )

    
(*** condition: ipynb ***)
#if IPYNB
streamTube
#endif // IPYNB

(***hide***)
streamTube |> GenericChart.toChartHTML
(*** include-it-raw ***)
