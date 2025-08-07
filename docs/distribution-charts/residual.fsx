(**
---
title: Residual chart
category: Distribution Charts
categoryindex: 5
index: 10
---
*)

(*** hide ***)

(*** condition: prepare ***)
#r "nuget: Newtonsoft.JSON, 13.0.3"
#r "nuget: DynamicObj, 7.0.1"
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
# Residual chart

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create a Residual (or Lollipop) chart in F#.

Let's first create some data for the purpose of creating example charts:

*)

open Plotly.NET

let ydata =
    [9.;25.;-73.;-30.;3.;35.;-35.;9.;-3.;33.;17.;25.;-15.;38.;-2.;36.;29.;-23.;15.;19]
let mean = Seq.average ydata

let xy = Seq.indexed ydata

(**
## What is a Residual (Lollipop) Chart?

A Residual or Lollipop chart is a type of chart that showcases the deviation of values to a reference value, often the **mean**, **median**, or a custom threshold.

- Each observation is represented by a **dot** connected to the reference line by a **line segment**.
- This type of visualization is useful for identifying **patterns**, **outliers**, or **distribution skewness** in relation to a central value.
- This approach is also helpful when visualizing residuals in regression models to assess **SSR (Sum of Squared Residuals)**, or highlight deviations to measures like **R²**.
*)

let residualChart = 
    Chart.Residual(
        xy=xy,
        referenceValue = mean,
        MarkerColor = Color.fromString "purple",
        LineColor = Color.fromString "blue",
        ReferenceColor = Color.fromString "black"
    )

(*** condition: ipynb ***)
#if IPYNB
residualChart
#endif // IPYNB

(***hide***)
residualChart |> GenericChart.toChartHTML
(***include-it-raw***)

