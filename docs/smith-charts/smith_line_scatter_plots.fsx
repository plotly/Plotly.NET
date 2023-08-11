(**
---
title: Smith line and scatter plots
category: Smith Plots
categoryindex: 13
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
# Smith charts

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create smith charts in F#.

Let's first create some data for the purpose of creating example charts:

*)

open Plotly.NET

// real coordinates
let real = [ 0.5; 1.; 2.; 3. ]

// imaginary coordinates
let imaginary = [ 0.5; 1.; 2.; 3. ]

(**
The Smith chart, invented by Phillip H. Smith (1905-1987) and independently by Mizuhashi Tosaku, is a graphical calculator or nomogram designed for electrical and electronics engineers specializing in radio frequency (RF) engineering to assist in solving problems with transmission lines and matching circuits 

The Smith chart is a mathematical transformation of the two-dimensional Cartesian complex plane. Complex numbers with positive real parts map inside the circle. Those with negative real parts map outside the circle. If we are dealing only with impedances with non-negative resistive components, our interest is focused on the area inside the circle.

([Wikipedia](https://en.wikipedia.org/wiki/Smith_chart)).

Still, you can plot any kind of imaginary numbers on this plane.

## point smith charts

Use `Chart.PointSmith` to create a chart that displays points on a smith subplot:
*)

let pointSmith = Chart.PointSmith(real, imaginary)
(*** condition: ipynb ***)
#if IPYNB
pointSmith
#endif // IPYNB

(***hide***)
pointSmith |> GenericChart.toChartHTML
(***include-it-raw***)

(**
## line smith charts

Use `Chart.LineSmith` to create a plot that displays a line connecting the data on a smith subplot.

This example also changes the styles of the line.
*)

let lineSmith =
    Chart.LineSmith(
        real = real,
        imag = imaginary,
        LineDash = StyleParam.DrawingStyle.DashDot,
        LineColor = Color.fromKeyword Purple
    )


(*** condition: ipynb ***)
#if IPYNB
lineSmith
#endif // IPYNB

(***hide***)
lineSmith |> GenericChart.toChartHTML
(***include-it-raw***)

(**
## bubble smith charts

Use `Chart.BubbleSmith` to create a plot that displays datums on a smith subplot, with an additional 3rd dimension set as the marker size.

As for all other plots above, you can, for example, add labels to each datum:
*)

let bubbleSmith =
    Chart.BubbleSmith(
        real = real,
        imag = imaginary,
        sizes = [ 10; 20; 30; 40 ],
        MultiText = [ "one"; "two"; "three"; "four"; "five"; "six"; "seven" ],
        TextPosition = StyleParam.TextPosition.TopCenter
    )

(*** condition: ipynb ***)
#if IPYNB
bubbleSmith
#endif // IPYNB

(***hide***)
bubbleSmith |> GenericChart.toChartHTML
(***include-it-raw***)
