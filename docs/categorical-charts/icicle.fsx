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
# Icicle charts

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Script]({{root}}img/badge-script.svg)]({{root}}{{fsdocs-source-basename}}.fsx)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create icicle charts in F#.

Icicle charts visualize hierarchical data using rectangular sectors that cascade from root to leaves in one of four directions: up, down, left, or right. 
Similar to Sunburst charts and Treemaps charts, the hierarchy is defined by labels and parents attributes. 
Click on one sector to zoom in/out, which also displays a pathbar on the top of your icicle. 
To zoom out, you can click the parent sector or click the pathbar, as well.
*)

open Plotly.NET
open Plotly.NET.TraceObjects

let character =
    [ "Eve"; "Cain"; "Seth"; "Enos"; "Noam"; "Abel"; "Awan"; "Enoch"; "Azura" ]

let parent = [ ""; "Eve"; "Eve"; "Seth"; "Seth"; "Eve"; "Eve"; "Awan"; "Eve" ]

let icicle =
    Chart.Icicle(
        labels = character,
        parents = parent,
        ShowSectionColorScale = true,
        SectionColorScale = StyleParam.Colorscale.Viridis,
        TilingOrientation = StyleParam.Orientation.Vertical,
        TilingFlip = StyleParam.TilingFlip.Y,
        PathBarEdgeShape = StyleParam.PathbarEdgeShape.BackSlash
    )

(*** condition: ipynb ***)
#if IPYNB
icicle
#endif // IPYNB

(***hide***)
icicle |> GenericChart.toChartHTML
(***include-it-raw***)

(**
## More styled example

This example shows the usage of some of the styling options using `Chart.Icicle`.
For even more styling control, use the respective TraceStyle function `TraceDomainStyle.Icicle`
*)

let icicleStyled =
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

    Chart.Icicle(
        labelsparents = (labelsParents |> Seq.map fst),
        Values = (labelsParents |> Seq.map snd),
        BranchValues = StyleParam.BranchValues.Total, // branch values are the total of their childrens values
        SectionColorScale = StyleParam.Colorscale.Viridis,
        ShowSectionColorScale = true,
        SectionOutlineColor = Color.fromKeyword Black,
        Tiling = IcicleTiling.init (Flip = StyleParam.TilingFlip.XY),
        UseDefaults = false
    )

(*** condition: ipynb ***)
#if IPYNB
icicleStyled
#endif // IPYNB

(***hide***)
icicleStyled |> GenericChart.toChartHTML
(***include-it-raw***)
