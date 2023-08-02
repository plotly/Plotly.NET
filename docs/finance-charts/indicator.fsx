(**
---
title: Indicator Charts
category: Finance Charts
categoryindex: 7
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
# Indicator Charts

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create indicator charts in F#.

Indicator Charts visualize the evolution of a value compared to a reference value, optionally inside a range.

There are different types of indicator charts, depending on the `IndicatorMode` used in chart generation:

- `Delta`/`Number` (and combinations) simply shows if the value is increasing or decreasing compared to the reference
- Any combination of the above with `Gauge` adds a customizable gauge that indicates where the value lies inside a given range.
*)

open Plotly.NET
open Plotly.NET.TraceObjects
open Plotly.NET.LayoutObjects

let allIndicatorTypes =
    [ Chart.Indicator(
          value = 120.,
          mode = StyleParam.IndicatorMode.NumberDeltaGauge,
          Title = "Bullet gauge",
          DeltaReference = 90.,
          Range = StyleParam.Range.MinMax(-200., 200.),
          GaugeShape = StyleParam.IndicatorGaugeShape.Bullet,
          ShowGaugeAxis = false,
          Domain = Domain.init (Row = 0, Column = 0)
      )
      Chart.Indicator(
          value = 200.,
          mode = StyleParam.IndicatorMode.NumberDeltaGauge,
          Title = "Angular gauge",
          Delta = IndicatorDelta.init (Reference = 160),
          Range = StyleParam.Range.MinMax(0., 250.),
          Domain = Domain.init (Row = 0, Column = 1)
      )
      Chart.Indicator(
          value = 300.,
          mode = StyleParam.IndicatorMode.NumberDelta,
          Title = "number and delta",
          DeltaReference = 90.,
          Domain = Domain.init (Row = 1, Column = 0)
      )
      Chart.Indicator(
          value = 40.,
          mode = StyleParam.IndicatorMode.Delta,
          Title = "delta",
          DeltaReference = 90.,
          Domain = Domain.init (Row = 1, Column = 1)
      ) ]
    |> Chart.combine
    |> Chart.withLayoutGridStyle (Rows = 2, Columns = 2)
    |> Chart.withMarginSize (Left = 200)


(*** condition: ipynb ***)
#if IPYNB
allIndicatorTypes
#endif // IPYNB

(***hide***)
allIndicatorTypes |> GenericChart.toChartHTML
(***include-it-raw***)
