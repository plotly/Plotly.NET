(**
---
title: Parallel coordinates
category: Categorical Charts
categoryindex: 10
index: 2
---
*)
 
(*** hide ***)

(*** condition: prepare ***)
#r "nuget: Newtonsoft.JSON, 13.0.1"
#r "nuget: DynamicObj, 2.0.0"
#r "nuget: Giraffe.ViewEngine.StrongName, 2.0.0-alpha1"
#r "../data/Deedle.dll"
#r "../../src/Plotly.NET/bin/Release/netstandard2.0/Plotly.NET.dll"

Plotly.NET.Defaults.DefaultDisplayOptions <-
    Plotly.NET.DisplayOptions.init (PlotlyJSReference = Plotly.NET.PlotlyJSReference.NoReference)

(*** condition: ipynb ***)
#if IPYNB
#r "nuget: Plotly.NET, {{fsdocs-package-version}}"
#r "nuget: Plotly.NET.Interactive, {{fsdocs-package-version}}"
#endif // IPYNB


(** 
# Parallel coordinates

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create parallel coordinates plot in F#.

Let's first create some data for the purpose of creating example charts:

*)

open Plotly.NET

let data =
    [ "A", [ 1.; 4.; 3.4; 0.7 ]
      "B", [ 3.; 1.5; 1.7; 2.3 ]
      "C", [ 2.; 4.; 3.1; 5. ]
      "D", [ 4.; 2.; 2.; 4. ] ]

(**

Parallel coordinates are a common way of visualizing high-dimensional geometry and analyzing multivariate data.
To show a set of points in an n-dimensional space, a backdrop is drawn consisting of n parallel lines, typically 
vertical and equally spaced. A point in n-dimensional space is represented as a polyline with vertices on the parallel axes; 
the position of the vertex on the i-th axis corresponds to the i-th coordinate of the point.
*)

let parcoords1 =
    Chart.ParallelCoord(keyValues = data, LineColor = Color.fromString "blue")

(*** condition: ipynb ***)
#if IPYNB
parcoords1
#endif // IPYNB

(***hide***)
parcoords1 |> GenericChart.toChartHTML
(***include-it-raw***)

(**
## More styled example

This example shows the usage of some of the styling options using `Chart.ParallelCoord`.
For even more styling control, use the respective TraceStyle function `TraceDomainStyle.ParallelCoord`
*)

open Plotly.NET.TraceObjects
open Deedle

let parcoordsStyled =

    let data =
        __SOURCE_DIRECTORY__ + "/../data/iris_cat.csv"
        |> Frame.ReadCsv

    let dims =
        [ Dimension.initParallel (
              Label = "sepal_length",
              Values = (data |> Frame.getCol "sepal_length" |> Series.values),
              Range = StyleParam.Range.MinMax(0., 8.)
          )
          Dimension.initParallel (
              Label = "sepal_width",
              Values = (data |> Frame.getCol "sepal_width" |> Series.values),
              Range = StyleParam.Range.MinMax(0., 8.)
          )
          Dimension.initParallel (
              Label = "petal_length",
              Values = (data |> Frame.getCol "petal_length" |> Series.values),
              Range = StyleParam.Range.MinMax(0., 8.)
          )
          Dimension.initParallel (
              Label = "petal_width",
              Values = (data |> Frame.getCol "petal_width" |> Series.values),
              Range = StyleParam.Range.MinMax(0., 8.)
          ) ]

    let colors =
        data |> Frame.getCol "species_id" |> Series.values |> Color.fromColorScaleValues

    Chart.ParallelCoord(dimensions = dims, LineColorScale = StyleParam.Colorscale.Viridis, LineColor = colors)


(*** condition: ipynb ***)
#if IPYNB
parcoordsStyled
#endif // IPYNB

(***hide***)
parcoordsStyled |> GenericChart.toChartHTML
(***include-it-raw***)
