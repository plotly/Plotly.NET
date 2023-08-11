(**
---
title: Treemap Charts
category: Categorical Charts
categoryindex: 10
index: 5
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
# Treemap charts

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create treemap charts in F#.

Treemap Chart is intended for the visualization of hierarchical data in the form of nested rectangles. 
Each level of such a tree structure is depicted as a colored rectangle, often called a branch, which contains other rectangles (leaves). 
The space inside each of the rectangles that compose a Treemap is highlighted based on the quantitative value in the corresponding data point.

## Treemap example

This example shows the usage of some of the styling options using `Chart.Treemap`.
For even more styling control, use the respective TraceStyle function `TraceDomainStyle.Treemap`
*)

open Plotly.NET
open Plotly.NET.TraceObjects

let treemapStyled =
    let labelsParents =
        [ ("A", ""), 20
          ("B", ""), 1
          ("C", ""), 2
          ("D", ""), 3
          ("E", ""), 4

          ("AA", "A"), 15
          ("AB", "A"), 5

          ("BA", "B"), 1

          ("AAA", "AA"), 10
          ("AAB", "AA"), 5 ]

    Chart.Treemap(
        labelsparents = (labelsParents |> Seq.map fst),
        Values = (labelsParents |> Seq.map snd),
        BranchValues = StyleParam.BranchValues.Total, // branch values are the total of their childrens values
        SectionColorScale = StyleParam.Colorscale.Viridis,
        ShowSectionColorScale = true,
        SectionOutlineColor = Color.fromKeyword Black,
        Tiling = TreemapTiling.init (Packing = StyleParam.TreemapTilingPacking.SliceDice)
    )

(*** condition: ipynb ***)
#if IPYNB
treemapStyled
#endif // IPYNB

(***hide***)
treemapStyled |> GenericChart.toChartHTML
(***include-it-raw***)
