(**
---
title: Bar and column charts
category: Simple Charts
categoryindex: 3
index: 2
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
# Bar and column charts

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create bar and a column charts in F#.

Let's first create some data for the purpose of creating example charts:
*)

open Plotly.NET

let values = [ 20; 14; 23 ]
let keys = [ "Product A"; "Product B"; "Product C" ]

(**
A bar chart or bar graph is a chart that presents grouped data with rectangular bars with 
lengths proportional to the values that they represent. The bars can be plotted vertically
or horizontally. A vertical bar chart is called a column bar chart.

### Column Charts
*)

let column = Chart.Column(values = values, Keys = keys)

(*** condition: ipynb ***)
#if IPYNB
column
#endif // IPYNB

(***hide***)
column |> GenericChart.toChartHTML
(***include-it-raw***)

(**
### Bar Charts
*)

let bar = Chart.Bar(values = values, Keys = keys)

(*** condition: ipynb ***)
#if IPYNB
bar
#endif // IPYNB

(***hide***)
bar |> GenericChart.toChartHTML
(***include-it-raw***)

(** 

## Stacked bar chart or column charts

The following example shows how to create a stacked bar chart by combining bar charts created by combining multiple `Chart.StackedBar` charts: 

Basically, those charts are just normal bar/column charts with the Layout property `BarMode` set to `Stack`. You can do this yourself by changing the Chart layout.

### Stacked bar Charts
*)

let stackedBar =
    [ Chart.StackedBar(values = values, Keys = keys, Name = "old")
      Chart.StackedBar(values = [ 8; 21; 13 ], Keys = keys, Name = "new") ]
    |> Chart.combine

(*** condition: ipynb ***)
#if IPYNB
stackedBar
#endif // IPYNB

(***hide***)
stackedBar |> GenericChart.toChartHTML
(***include-it-raw***)

(*
### Stacked bar Charts
*)

let stackedColumn =
    [ Chart.StackedColumn(values = values, Keys = keys, Name = "old")
      Chart.StackedColumn(values = [ 8; 21; 13 ], Keys = keys, Name = "new") ]
    |> Chart.combine

(*** condition: ipynb ***)
#if IPYNB
stackedColumn
#endif // IPYNB

(***hide***)
stackedColumn |> GenericChart.toChartHTML
(***include-it-raw***)
