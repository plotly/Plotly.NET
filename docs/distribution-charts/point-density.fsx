(**
---
title: PointDensity
category: Distribution Charts
categoryindex: 5
index: 6
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
# PointDensity

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create PointDensity plots in F#.

Let's first create some data for the purpose of creating example charts:

*)

let rnd = new System.Random()
let x = [ for i in 0..100 -> rnd.NextDouble() ]
let y = [ for i in 0..100 -> rnd.NextDouble() ]

(**
`Chart.PointDensity` is a combination of a scatter plot and a histogram2dcontour.

It helps assessing the two-dimensional distribution of a scatter plot by adding density contours based on the same data.
*)

open Plotly.NET

let pointDensityChart = Chart.PointDensity(x = x, y = y)

(*** condition: ipynb ***)
#if IPYNB
pointDensityChart
#endif // IPYNB

(***hide***)
pointDensityChart |> GenericChart.toChartHTML
(***include-it-raw***)

(**
## More styled example

This example shows the usage of some of the styling options using `Chart.PointDensity`.
*)

let pointDensityChartStyled =
    Chart.PointDensity(
        x = x,
        y = y,
        PointMarkerColor = Color.fromKeyword Purple,
        PointMarkerSymbol = StyleParam.MarkerSymbol.X,
        PointMarkerSize = 4,
        ColorScale = StyleParam.Colorscale.Viridis,
        ColorBar = ColorBar.init (Title = Title.init ("Density")),
        ShowContoursLabels = true
    )

(*** condition: ipynb ***)
#if IPYNB
pointDensityChartStyled
#endif // IPYNB

(***hide***)
pointDensityChartStyled |> GenericChart.toChartHTML
(***include-it-raw***)
