(**
---
title: FunnelArea Charts
category: Finance Charts
categoryindex: 7
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
# FunnelArea Charts

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create funnel area charts in F#.

Let's first create some data for the purpose of creating example charts:
*)

let values = [| 5; 4; 3; 2; 1 |]
let text = [| "The 1st"; "The 2nd"; "The 3rd"; "The 4th"; "The 5th" |]

(**
FunnelArea charts visualize stages in a process using area-encoded trapezoids. 
This trace can be used to show data in a part-to-whole representation similar to a "pie" trace, 
wherein each item appears in a single stage. See also the the [Funnel]({{root}}/6_1_funnel.html) chart for a different approach 
to visualizing funnel data.
*)

open Plotly.NET

let line = Line.init (Color = Color.fromString "purple", Width = 3.)

let funnelArea =
    Chart.FunnelArea(values = values, MultiText = text, SectionOutline = line)

(*** condition: ipynb ***)
#if IPYNB
funnelArea
#endif // IPYNB

(***hide***)
funnelArea |> GenericChart.toChartHTML
(***include-it-raw***)


(**
## More styled example

This example shows the usage of some of the styling options using `Chart.FunnelArea`.
For even more styling control, use the respective TraceStyle function `TraceDomainStyle.FunnelArea`
*)

let funnelAreaStyled =
    let values = [| 5; 4; 3 |]
    let labels = [| "The 1st"; "The 2nd"; "The 3rd" |]

    Chart.FunnelArea(
        values = values,
        Labels = labels,
        MultiText = labels,
        SectionColors = [ Color.fromKeyword Aqua; Color.fromKeyword Salmon; Color.fromKeyword Tan ],
        SectionOutlineColor = Color.fromKeyword Black,
        SectionOutlineWidth = 2.,
        AspectRatio = 0.75,
        BaseRatio = 0.1
    )

(*** condition: ipynb ***)
#if IPYNB
funnelAreaStyled
#endif // IPYNB

(***hide***)
funnelAreaStyled |> GenericChart.toChartHTML
(***include-it-raw***)
