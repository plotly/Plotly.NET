(**
---
title: Contour carpet plots
category: Carpet Plots
categoryindex: 12
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
# Contour carpet charts

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create contour plots on carpets in F#.

*)

open Plotly.NET
open Plotly.NET.LayoutObjects

let contourCarpet =
    [ Chart.Carpet(
          carpetId = "contour",
          A = [ 0.; 1.; 2.; 3.; 0.; 1.; 2.; 3.; 0.; 1.; 2.; 3. ],
          B = [ 4.; 4.; 4.; 4.; 5.; 5.; 5.; 5.; 6.; 6.; 6.; 6. ],
          X = [ 2.; 3.; 4.; 5.; 2.2; 3.1; 4.1; 5.1; 1.5; 2.5; 3.5; 4.5 ],
          Y = [ 1.; 1.4; 1.6; 1.75; 2.; 2.5; 2.7; 2.75; 3.; 3.5; 3.7; 3.75 ],
          AAxis =
              LinearAxis.initCarpet (
                  TickPrefix = "a = ",
                  Smoothing = 0.,
                  MinorGridCount = 9,
                  AxisType = StyleParam.AxisType.Linear
              ),
          BAxis =
              LinearAxis.initCarpet (
                  TickPrefix = "b = ",
                  Smoothing = 0.,
                  MinorGridCount = 9,
                  AxisType = StyleParam.AxisType.Linear
              ),
          Opacity = 0.75
      )
      Chart.ContourCarpet(
          z = [ 1.; 1.96; 2.56; 3.0625; 4.; 5.0625; 1.; 7.5625; 9.; 12.25; 15.21; 14.0625 ],
          carpetAnchorId = "contour",
          A = [ 0; 1; 2; 3; 0; 1; 2; 3; 0; 1; 2; 3 ],
          B = [ 4; 4; 4; 4; 5; 5; 5; 5; 6; 6; 6; 6 ],
          ContourLineColor = Color.fromKeyword White,
          ShowContourLabels = true
      ) ]
    |> Chart.combine

(*** condition: ipynb ***)
#if IPYNB
contourCarpet
#endif // IPYNB

(***hide***)
contourCarpet |> GenericChart.toChartHTML
(***include-it-raw***)
