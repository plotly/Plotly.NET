(**
---
title: Icicle Charts
category: Categorical Charts
categoryindex: 10
index: 4
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
# Icicle charts

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath={{fsdocs-source-basename}}.ipynb)&emsp;
[![Script]({{root}}img/badge-script.svg)]({{root}}{{fsdocs-source-basename}}.fsx)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create icicle charts in F#.

Icicle charts visualize hierarchical data using rectangular sectors that cascade from root to leaves in one of four directions: up, down, left, or right. 
Similar to Sunburst charts and Treemaps charts, the hierarchy is defined by labels and parents attributes. 
Click on one sector to zoom in/out, which also displays a pathbar on the top of your icicle. 
To zoom out, you can click the parent sector or click the pathbar as well.
*)

open Plotly.NET
open Plotly.NET.TraceObjects

let character   = ["Eve"; "Cain"; "Seth"; "Enos"; "Noam"; "Abel"; "Awan"; "Enoch"; "Azura"]
let parent      = [""; "Eve"; "Eve"; "Seth"; "Seth"; "Eve"; "Eve"; "Awan"; "Eve" ]

let icicle = 
    Chart.Icicle(
        character,
        parent,
        ShowScale = true,
        ColorScale = StyleParam.Colorscale.Viridis,
        TilingOrientation = StyleParam.Orientation.Vertical, // wether the icicles will grow in the vertical (up/down) or horizontal (left/right) direction
        TilingFlip = StyleParam.TilingFlip.Y, // flip in the Y direction (grow up instead of down)
        PathBarEdgeShape = StyleParam.PathbarEdgeShape.BackSlash
    )

(*** condition: ipynb ***)
#if IPYNB
icicle
#endif // IPYNB

(***hide***)
icicle |> GenericChart.toChartHTML
(***include-it-raw***)

