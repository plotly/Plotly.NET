(**
---
title: Sankey Charts
category: Categorical Charts
categoryindex: 10
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
# Sankey charts

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create sankey charts in F#.

Sankey charts are a visualization of multiple, linked graphs layed out linearly. 
These are usually used to depict flow between nodes or stations.
To create Sankey, a set of nodes and links between them are required. 
These are created using the provided Node and Link structures.
*)
open Plotly.NET

let sankey1 =
    Chart.Sankey(
        nodeLabels = [ "A1"; "A2"; "B1"; "B2"; "C1"; "C2"; "D1" ],
        linkedNodeIds =
            [ // Edgelist, toupling sourceIndex => targetIndex of the link
              0, 2
              0, 3
              1, 3
              2, 4
              3, 4
              3, 5
              4, 6
              5, 6 ],
        NodeOutlineColor = Color.fromKeyword Black,
        NodeOutlineWidth = 1.,
        linkValues = [ 8; 4; 2; 7; 3; 2; 5; 2 ],
        LinkColor =
            Color.fromColors
                [ Color.fromHex "#828BFB"
                  Color.fromHex "#828BFB"
                  Color.fromHex "#F27762"
                  Color.fromHex "#33D6AB"
                  Color.fromHex "#BC82FB"
                  Color.fromHex "#BC82FB"
                  Color.fromHex "#FFB47B"
                  Color.fromHex "#47DCF5" ],
        LinkOutlineColor = Color.fromKeyword Black,
        LinkOutlineWidth = 1.,
        UseDefaults = false
    )

(*** condition: ipynb ***)
#if IPYNB
sankey1
#endif // IPYNB

(***hide***)
sankey1 |> GenericChart.toChartHTML
(***include-it-raw***)
