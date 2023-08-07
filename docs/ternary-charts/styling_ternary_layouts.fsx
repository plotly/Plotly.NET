(**
---
title: Styling ternary layouts
category: Ternary Plots
categoryindex: 11
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
# Styling ternary layouts

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to style polar layouts in F#.

Let's first create some data for the purpose of creating example charts:
*)
open Plotly.NET

// a coordinates
let a = [ 1; 2; 3; 4; 5; 6; 7 ]

// b coordinates
let b = a |> List.rev

//c
let c = [ 2; 2; 2; 2; 2; 2; 2 ]

(**
Consider this combined ternary chart:
*)

let combinedTernary =
    [ Chart.PointTernary(A = a, B = b, C = c)
      Chart.LineTernary(A = a, C = c, Sum = 10) ]

    |> Chart.combine

(*** condition: ipynb ***)
#if IPYNB
combinedTernary
#endif // IPYNB

(***hide***)
combinedTernary |> GenericChart.toChartHTML
(***include-it-raw***)

(**
## Styling the polar layout

Use the `Chart.withTernary` function and initialize a Ternary layout with the desired looks:
*)
open Plotly.NET.LayoutObjects

let styledTernary =
    combinedTernary
    |> Chart.withTernary (
        Ternary.init (
            AAxis = LinearAxis.init (Title = Title.init ("A"), Color = Color.fromKeyword ColorKeyword.DarkOrchid),
            BAxis = LinearAxis.init (Title = Title.init ("B"), Color = Color.fromKeyword ColorKeyword.DarkRed)
        )
    )

(*** condition: ipynb ***)
#if IPYNB
styledTernary
#endif // IPYNB

(***hide***)
styledTernary |> GenericChart.toChartHTML
(***include-it-raw***)

(**
## Styling A, B, and C Axes

You could pass these axes to `Chart.withTernary` as above, but for the case where you want to specifically set one axis, there are the `Chart.withAAxis`, `Chart.withBAxis`, `Chart.withCAxis` functions:
*)

let styledTernary2 =
    styledTernary
    |> Chart.withCAxis (LinearAxis.init (Title = Title.init ("C"), Color = Color.fromKeyword ColorKeyword.DarkCyan))



(*** condition: ipynb ***)
#if IPYNB
styledTernary2
#endif // IPYNB

(***hide***)
styledTernary2 |> GenericChart.toChartHTML
(***include-it-raw***)
