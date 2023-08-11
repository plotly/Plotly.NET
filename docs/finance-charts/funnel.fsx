(**
---
title: Funnel Charts
category: Finance Charts
categoryindex: 7
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
# Funnel Charts

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create funnel charts in F#.

Let's first create some data for the purpose of creating example charts:
*)

let y =
    [| "Sales person A"
       "Sales person B"
       "Sales person C"
       "Sales person D"
       "Sales person E" |]

let x = [| 1200.; 909.4; 600.6; 300.; 80. |]

(**
Funnel charts visualize stages in a process using length-encoded bars. This trace can be used to show data in either a part-to-whole 
representation wherein each item appears in a single stage, or in a "drop-off" representation wherein each item appears in each stage 
it traversed. See also the [FunnelArea]({{root}}/6_2_funnel_area.html) chart for a different approach to visualizing funnel data.
*)

open Plotly.NET
open Plotly.NET.TraceObjects

// Customize the connector lines used to connect the funnel bars
let connectorLine =
    Line.init (Color = Color.fromString "royalblue", Dash = StyleParam.DrawingStyle.Dot, Width = 3.)

let connector = FunnelConnector.init (Line = connectorLine)

// Customize the outline of the funnel bars
let line = Line.init (Width = 2., Color = Color.fromHex "3E4E88")

// create a funnel chart using custom connectors and outlines
let funnel =
    Chart.Funnel(x = x, y = y, MarkerColor = Color.fromHex "59D4E8", MarkerOutline = line, Connector = connector)
    |> Chart.withMarginSize (Left = 100)

(*** condition: ipynb ***)
#if IPYNB
funnel
#endif // IPYNB

(***hide***)
funnel |> GenericChart.toChartHTML
(***include-it-raw***)
