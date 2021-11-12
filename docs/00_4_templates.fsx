(**
---
title: Chart Templates
category: General
categoryindex: 1
index: 5
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
# Chart Templates

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath={{fsdocs-source-basename}}.ipynb)&emsp;
[![Script]({{root}}img/badge-script.svg)]({{root}}{{fsdocs-source-basename}}.fsx)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

## Using premade templates

premade templates can be accessed via the `ChartTemplates` module. In fact, the `ChartTemplates.plotly` template is always active by default (see [global defaults](./005_defaults.html))
*)
open Plotly.NET

let lightMirrored = 
    Chart.Point([1,2])
    |> Chart.withTemplate ChartTemplates.lightMirrored

(*** condition: ipynb ***)
#if IPYNB
lightMirrored
#endif // IPYNB

(***hide***)
lightMirrored |> GenericChart.toChartHTML
(***include-it-raw***)

(**

here are then contents of the template `plotly` which is used by default for all charts:

*)

open DynamicObj

(***include-output***)
ChartTemplates.plotly
|> DynObj.print

(**

## Creating custom templates

Chart Templates consist of a `Layout` object and a collection of `Trace` objects. Both are used to set default values for all possible styling options:
*)

open Plotly.NET.TraceObjects

let layoutTemplate = 
    Layout.init(
        Title = Title.init("I will always be there now!")
    )

let traceTemplates = 
    [
        Trace2D.initScatter(
            Trace2DStyle.Scatter(
                Marker = Marker.init(Symbol = StyleParam.MarkerSymbol.ArrowLeft, Size = 20)
            )
        )
    ]

let myTemplate = Template.init(layoutTemplate, traceTemplates)

let myTemplateExampleChart =
    Chart.Point([1,2])
    |> Chart.withTemplate myTemplate

(*** condition: ipynb ***)
#if IPYNB
myTemplateExampleChart
#endif // IPYNB

(***hide***)
myTemplateExampleChart |> GenericChart.toChartHTML
(***include-it-raw***)
