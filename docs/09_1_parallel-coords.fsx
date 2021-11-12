(**
---
title: Parallel coordinates
category: Categorical Charts
categoryindex: 10
index: 2
---
*)

(*** hide ***)

(*** condition: prepare ***)
#r "nuget: Newtonsoft.JSON, 12.0.3"
#r "nuget: DynamicObj"
#r "../bin/Plotly.NET/netstandard2.0/Plotly.NET.dll"

(*** condition: ipynb ***)
#if IPYNB
#r "nuget: Plotly.NET, {{fsdocs-package-version}}"
#r "nuget: Plotly.NET.Interactive, {{fsdocs-package-version}}"
#endif // IPYNB


(** 
# Parallel coordinates

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath={{fsdocs-source-basename}}.ipynb)&emsp;
[![Script]({{root}}img/badge-script.svg)]({{root}}{{fsdocs-source-basename}}.fsx)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create parallel coordinates plot in F#.

let's first create some data for the purpose of creating example charts:

*)

open Plotly.NET 

let data = 
    [
        "A",[1.;4.;3.4;0.7;]
        "B",[3.;1.5;1.7;2.3;]
        "C",[2.;4.;3.1;5.]
        "D",[4.;2.;2.;4.;]
    ]

(**

Parallel coordinates are a common way of visualizing high-dimensional geometry and analyzing multivariate data.
To show a set of points in an n-dimensional space, a backdrop is drawn consisting of n parallel lines, typically 
vertical and equally spaced. A point in n-dimensional space is represented as a polyline with vertices on the parallel axes; 
the position of the vertex on the i-th axis corresponds to the i-th coordinate of the point.
*)

let parcoords1 =
    Chart.ParallelCoord(data,Color=Color.fromString "blue")

(*** condition: ipynb ***)
#if IPYNB
parcoords1
#endif // IPYNB

(***hide***)
parcoords1 |> GenericChart.toChartHTML
(***include-it-raw***)

open Plotly.NET.TraceObjects

// Dynamic object version
let parcoords = 
    let v = [|
        Dimensions.init([|1.;4.;|],  
            StyleParam.Range.MinMax (1.,5.),StyleParam.Range.MinMax (1.,2.),Label="A");
        Dimensions.init([|3.;1.5;|], 
            StyleParam.Range.MinMax (1.,5.),Label="B",Tickvals=[|1.5;3.;4.;5.;|]);
        Dimensions.init([|2.;4.;|],  
            StyleParam.Range.MinMax (1.,5.),Label="C",Tickvals=[|1.;2.;4.;5.;|],
                TickText=[|"txt 1";"txt 2";"txt 4";"txt 5";|]);
        Dimensions.init([|4.;2.;|],  
            StyleParam.Range.MinMax (1.,5.),Label="D");
    |]

    let dyn = Trace("parcoords")

    dyn?dimensions <- v
    dyn?line <- Line.init(Color=Color.fromString "blue")

    dyn
    |> GenericChart.ofTraceObject true

(*** condition: ipynb ***)
#if IPYNB
parcoords
#endif // IPYNB

(***hide***)
parcoords |> GenericChart.toChartHTML
(***include-it-raw***)

