(**
---
title: Pie and doughnut Charts
category: Simple Charts
categoryindex: 3
index: 6
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
# Pie and doughnut Charts

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Script]({{root}}img/badge-script.svg)]({{root}}{{fsdocs-source-basename}}.fsx)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create pie and doughnut charts in F#.

Let's first create some data for the purpose of creating example charts:

*)
open Plotly.NET

let values = [ 19; 26; 55 ]
let labels = [ "Residential"; "Non-Residential"; "Utility" ]

(**

A pie, doughnut, or sunburst chart can be created using the `Chart.Pie`, `Chart.Doughnut`, and `Chart.Sunburst` functions.
When creating pie charts, it is usually desirable to provide both labels and values.

*)

let pie1 = Chart.Pie(values = values, Labels = labels)

(*** condition: ipynb ***)
#if IPYNB
pie1
#endif // IPYNB

(***hide***)
pie1 |> GenericChart.toChartHTML
(***include-it-raw***)

let doughnut1 =
    Chart.Doughnut(values = values, Labels = labels, Hole = 0.3, MultiText = labels)

(*** condition: ipynb ***)
#if IPYNB
doughnut1
#endif // IPYNB

(***hide***)
doughnut1 |> GenericChart.toChartHTML
(***include-it-raw***)

(**
## More styled example

This example shows the usage of some of the styling options using `Chart.Pie`.
For even more styling control, use the respective TraceStyle function `TraceDomainStyle.Pie`
*)


let pieStyled =

    let values = [ 19; 26; 55 ]
    let labels = [ "Residential"; "Non-Residential"; "Utility" ]

    Chart.Pie(
        values = values,
        Labels = labels,
        SectionColors = [ Color.fromKeyword Aqua; Color.fromKeyword Salmon; Color.fromKeyword Tan ],
        SectionOutlineColor = Color.fromKeyword Black,
        SectionOutlineWidth = 2.,
        MultiText = [ "Some"; "More"; "Stuff" ],
        MultiTextPosition =
            [ StyleParam.TextPosition.Inside
              StyleParam.TextPosition.Outside
              StyleParam.TextPosition.Inside ],
        Rotation = 45.,
        MultiPull = [ 0.; 0.3; 0. ]
    )

(*** condition: ipynb ***)
#if IPYNB
pieStyled
#endif // IPYNB

(***hide***)
pieStyled |> GenericChart.toChartHTML
(***include-it-raw***)
