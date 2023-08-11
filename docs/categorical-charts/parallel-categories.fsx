(**
---
title: Parallel categories
category: Categorical Charts
categoryindex: 10
index: 1
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
# Parallel categories

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create parallel categories plot in F#.

The parallel categories diagram (also known as parallel sets or alluvial diagram) is a visualization of multi-dimensional categorical data sets. Each variable in the data set is represented by a column of rectangles, where each rectangle corresponds to a discrete value taken on by that variable. The relative heights of the rectangles reflect the relative frequency of occurrence of the corresponding value.

Combinations of category rectangles across dimensions are connected by ribbons, where the height of the ribbon corresponds to the relative frequency of occurrence of the combination of categories in the data set.
*)
open Plotly.NET
open Plotly.NET.TraceObjects

let dims =
    [ Dimension.initParallel (Values = [ "Cat1"; "Cat1"; "Cat1"; "Cat1"; "Cat2"; "Cat2"; "Cat3" ], Label = "A")
      Dimension.initParallel (Values = [ 0; 1; 0; 1; 0; 0; 0 ], Label = "B", TickText = [ "YES"; "NO" ]) ]

let parcats =
    Chart.ParallelCategories(
        dimensions = dims,
        LineColor = Color.fromColorScaleValues [ 0.; 1.; 0.; 1.; 0.; 0.; 0. ],
        LineColorScale = StyleParam.Colorscale.Blackbody
    )

(*** condition: ipynb ***)
#if IPYNB
parcats
#endif // IPYNB

(***hide***)
parcats |> GenericChart.toChartHTML
(***include-it-raw***)

(**
## More styled example

This example shows the usage of some of the styling options using `Chart.ParallelCategories`.
For even more styling control, use the respective TraceStyle function `TraceDomainStyle.ParallelCategories`
*)

let parcatsStyled =
    let dims =
        [ Dimension.initParallel (Values = [ "A"; "A"; "A"; "B"; "B"; "B"; "C"; "D" ], Label = "Lvl1")
          Dimension.initParallel (Values = [ "AA"; "AA"; "AB"; "AB"; "AB"; "AB"; "AB"; "AB" ], Label = "Lvl2")
          Dimension.initParallel (Values = [ "AAA"; "AAB"; "AAC"; "AAC"; "AAB"; "AAB"; "AAA"; "AAA" ], Label = "Lvl3") ]

    Chart.ParallelCategories(
        dimensions = dims,
        LineColor = Color.fromColorScaleValues [ 0; 1; 2; 2; 1; 1; 0; 0 ], // These values map to the last category axis, meaning [AAA => 0; AAB = 1; AAC => 2]
        LineColorScale = StyleParam.Colorscale.Viridis,
        BundleColors = false
    )

(*** condition: ipynb ***)
#if IPYNB
parcatsStyled
#endif // IPYNB

(***hide***)
parcatsStyled |> GenericChart.toChartHTML
(***include-it-raw***)
