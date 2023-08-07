(**
---
title: Range plots
category: Simple Charts
categoryindex: 3
index: 4
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
# Range plots

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create Range plot charts in F#.

Let's first create some data for the purpose of creating example charts:

*)

open Plotly.NET

let rnd = System.Random()

let x = [ 1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10. ]
let y = [ 2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1. ]

let yUpper = y |> List.map (fun v -> v + rnd.NextDouble())
let yLower = y |> List.map (fun v -> v - rnd.NextDouble())

(**
A range plot is commonly used to indicate some property of data that lies in a certain range around a central value,
for example the range of all predictions from different models, scattering around a central tendency.
*)

let range1 =
    Chart.Range(
        x = x,
        y = y,
        upper = yUpper,
        lower = yLower,
        mode = StyleParam.Mode.Lines_Markers,
        MarkerColor = Color.fromString "grey",
        RangeColor = Color.fromString "lightblue"
    )

(*** condition: ipynb ***)
#if IPYNB
range1
#endif // IPYNB

(***hide***)
range1 |> GenericChart.toChartHTML
(***include-it-raw***)

(**
## More styled example

This example shows the usage of some of the styling options using `Chart.Range`.
*)
open Plotly.NET.TraceObjects

let rangeStyled =
    Chart.Range(
        x = [ 1; 2; 3; 4; 5 ],
        y = [ 2; 2; 3; 4; 6 ],
        upper = [ 4; 6; 7; 5; 7 ],
        lower = [ 0; 0; 0; 1; 5 ],
        mode = StyleParam.Mode.Lines_Markers,
        TextPosition = StyleParam.TextPosition.TopCenter,
        RangeColor = Color.fromString "rgba(0, 204, 150, 0.2)",
        LowerLine = Line.init (Width = 2., Color = Color.fromString "rgba(0, 204, 150, 0.4)"),
        LowerMarker = Marker.init (Color = Color.fromString "rgba(0, 204, 150, 0.6)"),
        UpperLine = Line.init (Width = 2., Color = Color.fromString "rgba(0, 204, 150, 0.4)"),
        UpperMarker = Marker.init (Color = Color.fromString "rgba(0, 204, 150, 0.6)"),
        MultiText = [ "Mid1"; "Mid2"; "Mid3"; "Mid4"; "Mid5" ],
        MultiLowerText = [ "Lower1"; "Lower2"; "Lower3"; "Lower4"; "Lower5" ],
        MultiUpperText = [ "Upper1"; "Upper2"; "Upper3"; "Upper4"; "Upper5" ],
        ShowLegend = true
    )

(*** condition: ipynb ***)
#if IPYNB
rangeStyled
#endif // IPYNB

(***hide***)
rangeStyled |> GenericChart.toChartHTML
(***include-it-raw***)
