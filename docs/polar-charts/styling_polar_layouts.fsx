(**
---
title: Styling polar layouts
category: Polar Charts
categoryindex: 9 
index: 3
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
# Styling polar layouts

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to style polar layouts in F#.

Let's first create some data for the purpose of creating example charts:
*)
open Plotly.NET

let r = [ 1; 2; 3; 4; 5; 6; 7 ] |> List.map ((*) 10000)
let r2 = [ 5; 6; 7; 1; 2; 3; 4 ] |> List.map ((*) 10000)
let r3 = [ 3; 1; 5; 2; 8; 7; 5 ] |> List.map ((*) 10000)

let t = [ 0; 45; 90; 135; 200; 320; 184 ]

(**
Consider this combined polar chart:
*)

let combinedPolar =
    [ Chart.PointPolar(r = r, theta = t, Name = "PointPolar")
      Chart.LinePolar(r = r2, theta = t, Name = "LinePolar", ShowMarkers = true)
      Chart.SplinePolar(r = r3, theta = t, Name = "SplinePolar", ShowMarkers = true) ]

    |> Chart.combine

(*** condition: ipynb ***)
#if IPYNB
combinedPolar
#endif // IPYNB

(***hide***)
combinedPolar |> GenericChart.toChartHTML
(***include-it-raw***)

(**
## Styling the polar layout

Use the `Chart.withPolar` function and initialize a Polar layout with the desired looks:
*)
open Plotly.NET.LayoutObjects

let styledPolar =
    combinedPolar |> Chart.withPolar (Polar.init (Sector = (0., 270.), Hole = 0.1))


(*** condition: ipynb ***)
#if IPYNB
styledPolar
#endif // IPYNB

(***hide***)
styledPolar |> GenericChart.toChartHTML
(***include-it-raw***)

(**
## Styling radial and angular axes

You could pass these axes to `Chart.withPolar`, but for the case where you want to specifically set the angular or radial axis, there are the `Chart.withAngularAxis` and `Chart.withRadialAxis` functions:
*)

let styledPolar2 =
    styledPolar
    |> Chart.withAngularAxis (AngularAxis.init (Color = Color.fromString "darkblue"))
    |> Chart.withRadialAxis (
        RadialAxis.init (
            Title = Title.init ("Hi, i am the radial axis"),
            Color = Color.fromString "darkblue",
            SeparateThousands = true
        )
    )


(*** condition: ipynb ***)
#if IPYNB
styledPolar2
#endif // IPYNB

(***hide***)
styledPolar2 |> GenericChart.toChartHTML
(***include-it-raw***)
