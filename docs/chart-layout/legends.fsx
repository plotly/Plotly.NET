(**
---
title: Legends
category: Chart Layout
categoryindex: 2
index: 9
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
# Legends

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create Legends and add them to the Charts in F#.

Let's first create some data for the purpose of creating example charts:

*)

open Plotly.NET

let x = [ 1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10. ]
let y = [ 2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1. ]

// note that legends are not shown on charts with only one trace, 
// which is why we need to set the trace to visible manually on this chart
let simple_chart = Chart.Point(x, y, ShowLegend = true, Name = "test_chart")

(**
## Creating a legend

Legends are `LayoutObjects` that can be added to a chart's `Layout`. The `LayoutLegend.init` function is used to create a legend object, which can then be added to a chart using the `Chart.withLegend` function:
*)
open Plotly.NET.LayoutObjects

let my_legend =
    Legend.init (
        Title = Title.init("my first legend!"),
        BorderColor = Color.fromString "black",
        BorderWidth = 1
    )

let first_legend_chart =
    simple_chart
    |> Chart.withLegend my_legend

(*** condition: ipynb ***)
#if IPYNB
first_legend_chart
#endif // IPYNB

(***hide***)
first_legend_chart |> GenericChart.toChartHTML
(***include-it-raw***)

(**
## Styling existing legends

The `Chart.withLegendStyle` function can be used to update the style of an existing legend. 
The following code will move the existing legend to the center bottom of the chart:
*)

let styled_legend_chart =
    first_legend_chart
    |> Chart.withLegendStyle(
        Orientation = StyleParam.Orientation.Horizontal,
        X = 0.5,
        XAnchor = StyleParam.XAnchorPosition.Center
    )

(*** condition: ipynb ***)
#if IPYNB
styled_legend_chart
#endif // IPYNB

(***hide***)
styled_legend_chart |> GenericChart.toChartHTML
(***include-it-raw***)

(**
## Grouping legend items

You can group multiple traces as a single legend item by setting the `LegendGroup` property of the individual traces to the same value:
*)

let grouped_legend_chart =
    [
        Chart.Point(x, y)
        |> GenericChart.mapTrace (
            Trace2DStyle.Scatter(
                LegendGroup = "Group A",
                LegendGroupTitle = (Title.init (Text = "Group A"))
            )
        )
        Chart.Point(y, x)
        |> GenericChart.mapTrace (
            Trace2DStyle.Scatter(
                LegendGroup = "Group A"
            )
        )
        Chart.Point(y, y)
        |> GenericChart.mapTrace (
            Trace2DStyle.Scatter(
                LegendGroup = "Group B",
                LegendGroupTitle = (Title.init (Text = "Group B"))
            )
        )
    ]
    |> Chart.combine

(*** condition: ipynb ***)
#if IPYNB
grouped_legend_chart
#endif // IPYNB

(***hide***)
grouped_legend_chart |> GenericChart.toChartHTML
(***include-it-raw***)

(**
## Multiple legends

Starting with Plotly.NET 5.0.0, the multiple legends feature from plotl.js v2.22+ is supported.

However, plotly.js has a [regression bug starting from 2.24.3](https://github.com/plotly/plotly.js/issues/7023), which causes multiple legends to not display correctly

This means that the referenced plotly.js version has to be changed to <2.24.3 to use this feature. Note that features introduced in plotly.js/.NET after this version will not work on a chart using that reference.
Future versions of plotly.js will hopefully fix this issue.

Similarily to how multiple axes are handled, multiple legends are added by providing an additional `Id` argument when using the `Chart.withLegend` function:

To select which legend a trace should belong to, use `Chart.withLegendAnchor` with the corresponding `id` argument.
*)


let multi_legend_chart =
    [
        Chart.Point(x, y)
        |> Chart.withLegendAnchor 1
        Chart.Point(y, x)
        |> Chart.withLegendAnchor 2
    ]
    |> Chart.combine
    |> Chart.withLegend(
        Legend.init(
            BorderColor = Color.fromKeyword Blue,
            BorderWidth = 2,
            Title = Title.init(
                Text = "Legend 1"
            )
        )
    )
    |> Chart.withLegend(
        Legend.init(
            X = 0.75,
            Y = 0.75,
            BorderColor = Color.fromKeyword Red,
            BorderWidth = 2,
            Title = Title.init(
                Text = "Legend 2"
            )
        ),
        Id = 2
    )
    // set lower plotly.js version to avoid regression bug
    |> Chart.withDisplayOptionsStyle(
        PlotlyJSReference = Plotly.NET.PlotlyJSReference.CDN "https://cdn.plot.ly/plotly-2.23.0.min.js"
    )

(*** condition: ipynb ***)
#if IPYNB
multi_legend_chart
#endif // IPYNB

(***hide***)
multi_legend_chart |> GenericChart.toEmbeddedHTML
(***include-it-raw***)