(**
---
title: Annotations
category: Chart Layout
categoryindex: 2
index: 5
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
# Annotations

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create Shapes and add them to the Charts in F#.

Let's first create some data for the purpose of creating example charts:

*)

open Plotly.NET

let x = [ 1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10. ]
let y = [ 2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1. ]

(**
Use the `Annotation.init` function to generate a shape, and either the `Chart.withAnnotation` or the `Chart.withAnnotations` function to add
multiple annotations at once.

*)

open Plotly.NET.LayoutObjects

let a1 = Annotation.init (X = 2., Y = 4., Text = "Hi there!")

let a2 =
    Annotation.init (
        X = 5.,
        Y = 7.,
        Text = "I am another annotation!",
        BGColor = Color.fromString "white",
        BorderColor = Color.fromString "black"
    )

let annotations =
    Chart.Line(x = x, y = y, Name = "line") |> Chart.withAnnotations ([ a1; a2 ])

(*** condition: ipynb ***)
#if IPYNB
annotations
#endif // IPYNB

(***hide***)
annotations |> GenericChart.toChartHTML
(***include-it-raw***)


(**
## Annotations with logged axes

When using log axes, the values for `X` or `Y` given in `Annotation.init` must be transformed as well even if the axis shows the expected value range.
*)

let y_highrange = [ 2.; 15_000.; 1_600.; 1.5; 3.; 25_000; 25_000.; 15_000; 350; 1. ]

// The default log axis is base 10
let a_log = Annotation.init (X = 5., Y = log10 2_500., Text = "I'm at position<br>x=5, y=2500")

let annotations_log =
    Chart.Line(x = x, y = y_highrange, Name = "log_line") 
    |> Chart.withYAxis(LinearAxis.init(AxisType = StyleParam.AxisType.Log))
    |> Chart.withAnnotation a_log

(*** condition: ipynb ***)
#if IPYNB
annotations_log
#endif // IPYNB

(***hide***)
annotations_log |> GenericChart.toChartHTML
(***include-it-raw***)



(**
## Multicharts

Annotations can also be placed using coordinates proportional to the chart canvas, by setting the `XRef` and `YRef` to `"paper"`. 
In multi-chart layouts, the reference can be set to the respective x, and y axis-component (e.g. `XRef = x3, YRef = y3` for the third chart within the chart grid).
*)

// setting no reference, the annotation will be placed at the given x and y values in the first chart
let a_multichart1 = Annotation.init (X = 8,   Y = 5.0,                                 Text = "no ref defined")

// setting the reference to specific x and y components, the annotation will be placed at the given x and y values in the chart defined by the ref-coordinates
let a_multichart2 = Annotation.init (X = 7,   Y = 3.5, XRef = "x1",    YRef = "y1",    Text = "ref: x1 and y1")
let a_multichart3 = Annotation.init (X = 7,   Y = 3.5, XRef = "x2",    YRef = "y2",    Text = "ref: x2 and y2")
let a_multichart4 = Annotation.init (X = 7,   Y = 3.5, XRef = "x3",    YRef = "y3",    Text = "ref: x3 and y3")
let a_multichart5 = Annotation.init (X = 7,   Y = 3.5, XRef = "x4",    YRef = "y4",    Text = "ref: x4 and y4")

// setting the x and y reference to "paper", the annotation will be placed proportional to the chart canvas
let a_multichart6 = Annotation.init (X = 1.1, Y = 1.1, XRef = "paper", YRef = "paper", Text = "ref: paper@1.1")
let a_multichart7 = Annotation.init (X = 0.5, Y = 0.4, XRef = "paper", YRef = "paper", Text = "ref: paper@0.5")


let annotations_multi =
    [
        Chart.Line(x = x, y = y, Name = "chart 1") 
        Chart.Line(x = x, y = y, Name = "chart 2") 
        Chart.Line(x = x, y = y, Name = "chart 3") 
        Chart.Line(x = x, y = y, Name = "chart 4") 
    ]
    |> Chart.Grid(2, 2)
    |> Chart.withAnnotations ([a_multichart1; a_multichart2; a_multichart3; a_multichart4; a_multichart5; a_multichart6; a_multichart7])

(*** condition: ipynb ***)
#if IPYNB
annotations_multi
#endif // IPYNB

(***hide***)
annotations_multi |> GenericChart.toChartHTML
(***include-it-raw***)

(**
In multi-chart layouts *with coupled axis*, the reference can be set to the respective coupled x, and y axis-component (e.g. `XRef = x1, YRef = y2` for the leftmost chart in the second row).
*)

// setting the reference to specific x and y components with coupled axes, the annotation will be placed at the given x and y values in the chart defined by the ref-coordinates
let a_multichart_coupled_1 = Annotation.init (X = 7,   Y = 3.5, XRef = "x1",    YRef = "y1",    Text = "ref: x1 and y1")
let a_multichart_coupled_2 = Annotation.init (X = 7,   Y = 3.5, XRef = "x2",    YRef = "y1",    Text = "ref: x2 and y1")
let a_multichart_coupled_3 = Annotation.init (X = 7,   Y = 3.5, XRef = "x2",    YRef = "y2",    Text = "ref: x2 and y2")
let a_multichart_coupled_4 = Annotation.init (X = 7,   Y = 3.5, XRef = "x1",    YRef = "y2",    Text = "ref: x1 and y2")


let annotations_paper_coupled =
    [
        Chart.Line(x = x, y = y, Name = "chart 1") 
        Chart.Line(x = x, y = y, Name = "chart 2") 
        Chart.Line(x = x, y = y, Name = "chart 3") 
        Chart.Line(x = x, y = y, Name = "chart 4") 
    ]
    |> Chart.Grid(2, 2, Pattern = StyleParam.LayoutGridPattern.Coupled)
    |> Chart.withAnnotations ([a_multichart_coupled_1; a_multichart_coupled_2; a_multichart_coupled_3; a_multichart_coupled_4])

(*** condition: ipynb ***)
#if IPYNB
annotations_paper_coupled
#endif // IPYNB

(***hide***)
annotations_paper_coupled |> GenericChart.toChartHTML
(***include-it-raw***)
