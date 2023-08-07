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
# Chart Templates

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

## Using premade templates

Premade templates can be accessed via the `ChartTemplates` module. In fact, the `ChartTemplates.plotly` template is always active by default (see [global defaults](./00_5_defaults.html))
*)
open Plotly.NET

let lightMirrored =
    Chart.Point(xy = [ 1, 2 ]) |> Chart.withTemplate ChartTemplates.lightMirrored

(*** condition: ipynb ***)
#if IPYNB
lightMirrored
#endif // IPYNB

(***hide***)
lightMirrored |> GenericChart.toChartHTML
(***include-it-raw***)

(**

Here are the contents of the template `plotly` which is used by default for all charts: https://github.com/plotly/Plotly.NET/blob/6e28decca64441320d8cffab5bcfee664b118c36/src/Plotly.NET/Templates/ChartTemplates.fs#L163-L665

## Creating custom templates

Chart Templates consist of a `Layout` object and a collection of `Trace` objects. Both are used to set default values for all possible styling options:
*)

open Plotly.NET.TraceObjects

let layoutTemplate =
    Layout.init (Title = Title.init ("I will always be there now!"))

let traceTemplates =
    [ Trace2D.initScatter (
          Trace2DStyle.Scatter(Marker = Marker.init (Symbol = StyleParam.MarkerSymbol.ArrowLeft, Size = 20))
      ) ]

let myTemplate = Template.init (layoutTemplate, traceTemplates)

let myTemplateExampleChart =
    Chart.Point(xy = [ 1, 2 ]) |> Chart.withTemplate myTemplate

(*** condition: ipynb ***)
#if IPYNB
myTemplateExampleChart
#endif // IPYNB

(***hide***)
myTemplateExampleChart |> GenericChart.toChartHTML
(***include-it-raw***)
