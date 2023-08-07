(**
---
title: Scatterplot matrix
category: Distribution Charts
categoryindex: 5
index: 5
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
# Scatterplot matrix 

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to plot a scatterplot matrix (splom) in F#.

Let's first create some data for the purpose of creating example charts:

*)
open Deedle
open Plotly.NET

let data =
    __SOURCE_DIRECTORY__ + "/../data/iris.csv"
    |> Frame.ReadCsv

let sepalLengthData = data.["sepal length"] |> Series.values
let sepalWidthData = data.["sepal width"] |> Series.values
let petalLengthData = data.["petal length"] |> Series.values
let petalWidthData = data.["petal width"] |> Series.values

let colors =
    data
    |> Frame.getCol "class"
    |> Series.values
    |> Seq.cast<string>
    |> Seq.map (fun x ->
        match x with
        | "Iris-setosa" -> 0.
        | "Iris-versicolor" -> 0.5
        | _ -> 1.)
    |> Color.fromColorScaleValues


(**
Using a scatterplot matrix of several different variables can help to determine whether there are any
relationships among the variables in the dataset.

## Splom of the iris dataset
*)

let splom1 =
    Chart.Splom(
        keyValues =
            [ "sepal length", sepalLengthData
              "sepal width", sepalWidthData
              "petal length", petalLengthData
              "petal width", petalWidthData ],
        MarkerColor = colors
    )
    |> Chart.withLayout (Layout.init (HoverMode = StyleParam.HoverMode.Closest, DragMode = StyleParam.DragMode.Select))
    |> Chart.withSize (1000, 1000)


(*** condition: ipynb ***)
#if IPYNB
splom1
#endif // IPYNB

(***hide***)
splom1 |> GenericChart.toChartHTML
(***include-it-raw***)

(**
## Showing different parts of the plot matrix

Use `ShowDiagonal`, `ShowUpperHalf` or `ShowLowerHalf` to customize the cells shown in the scatter plot matrix. 

Here are some examples:
*)

let noDiagonal =
    Chart.Splom(
        keyValues =
            [ "sepal length", sepalLengthData
              "sepal width", sepalWidthData
              "petal length", petalLengthData
              "petal width", petalWidthData ],
        MarkerColor = colors,
        ShowDiagonal = false
    )
    |> Chart.withLayout (Layout.init (HoverMode = StyleParam.HoverMode.Closest, DragMode = StyleParam.DragMode.Select))
    |> Chart.withSize (1000, 1000)

(*** condition: ipynb ***)
#if IPYNB
noDiagonal
#endif // IPYNB

(***hide***)
noDiagonal |> GenericChart.toChartHTML
(***include-it-raw***)


let noLowerHalf =
    Chart.Splom(
        keyValues =
            [ "sepal length", sepalLengthData
              "sepal width", sepalWidthData
              "petal length", petalLengthData
              "petal width", petalWidthData ],
        MarkerColor = colors,
        ShowLowerHalf = false
    )
    |> Chart.withLayout (Layout.init (HoverMode = StyleParam.HoverMode.Closest, DragMode = StyleParam.DragMode.Select))
    |> Chart.withSize (1000, 1000)

(*** condition: ipynb ***)
#if IPYNB
noLowerHalf
#endif // IPYNB

(***hide***)
noLowerHalf |> GenericChart.toChartHTML
(***include-it-raw***)
