(**
---
title: Chart config
category: General
categoryindex: 1
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
# Chart config

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

`Config` is an object that configures high level properties of the chart like making all chart elements editable or the tool bar on top

## Image button options

Options for chart export can be set in the config at `ToImageButtonOptions`:

  - Three file formats for chart exports are supported (SVG, PNG, JPEG) and can be set as `Format`. 

  - A predefined name for the downloaded chart can be set at `Filename`. 

  - The dimensions of the downloaded chart are set at `Width` and `Height`.

  - The `Scale` defines the size of the exported svg.

The settings do not apply for the html document containing the chart but for charts that are exported by clicking the camera icon in the menu bar.

*)

open Plotly.NET
open Plotly.NET.ConfigObjects

let svgConfig =
    Config.init (
        ToImageButtonOptions =
            ToImageButtonOptions.init (
                Format = StyleParam.ImageFormat.JPEG,
                Filename = "mySvgChart",
                Width = 900.,
                Height = 600.,
                Scale = 10.
            )
    )

let svgButtonChart = Chart.Point(xy = [ (1., 2.) ]) |> Chart.withConfig svgConfig


(*** condition: ipynb ***)
#if IPYNB
svgButtonChart
#endif // IPYNB

(***hide***)
svgButtonChart |> GenericChart.toChartHTML
(***include-it-raw***)

(** 
## Static plots

To create a static plot that has no hoverable elements, use `StaticPlot=true` on the Config:

*)

let staticConfig = Config.init (StaticPlot = true)

let staticPlot = Chart.Point(xy = [ (1., 2.) ]) |> Chart.withConfig staticConfig

(*** condition: ipynb ***)
#if IPYNB
staticPlot
#endif // IPYNB

(***hide***)
staticPlot |> GenericChart.toChartHTML
(***include-it-raw***)

(** 
## Editable charts

You can define fields that can be edited on the chart by setting `Editable = true` on the config, optionally explicitly setting the editable parts via `EditableAnnotations`

*)

let editableConfig =
    Config.init (Editable = true, Edits = Edits.init (LegendPosition = true, AxisTitleText = true, LegendText = true))

let editablePlot = Chart.Point(xy = [ (1., 2.) ]) |> Chart.withConfig editableConfig

(*** condition: ipynb ***)
#if IPYNB
editablePlot
#endif // IPYNB

(***hide***)
editablePlot |> GenericChart.toChartHTML
(***include-it-raw***)

(** 
## Responsive charts

To create a chart that is responsive to its container size, use `Responsive=true` on the Config:

(try resizing the window)
*)

let responsiveConfig = Config.init (Responsive = true)

let responsivePlot =
    Chart.Point(xy = [ (1., 2.) ]) |> Chart.withConfig responsiveConfig

(*** condition: ipynb ***)
#if IPYNB
responsivePlot
#endif // IPYNB

(***hide***)
responsivePlot |> GenericChart.toChartHTML
(***include-it-raw***)
