(*** hide ***)

(*** condition: prepare ***)
#r "../bin/Plotly.NET/net5.0/Plotly.NET.dll"
(*** condition: fsx ***)
#if FSX
#r "../packages/Newtonsoft.Json/lib/netstandard2.0/Newtonsoft.Json.dll"
#r "../bin/Plotly.NET/net5.0/Plotly.NET.dll"
#endif // FSX
(*** condition: ipynb ***)
#if IPYNB
#r "nuget: Plotly.NET, 2.0.0-beta1"
#r "nuget: Plotly.NET.Interactive, 2.0.0-alpha5"
#endif // IPYNB

(** 
# Area charts

[![Binder](https://mybinder.org/badge_logo.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=area-plots.ipynb)

*Summary:* This example shows how to create area charts, area charts with splines, and stackes area charts in F#.

let's first create some data for the purpose of creating example charts:

*)

open Plotly.NET 
  
let x  = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
let y  = [5.; 2.5; 5.; 7.5; 5.; 2.5; 7.5; 4.5; 5.5; 5.]

(**
An area chart or area graph displays graphically quantitive data. It is based on the line chart.
The area between axis and line are commonly emphasized with colors, textures and hatchings.

### Simple area chart
*)

let area1 = Chart.Area(x,y)

(*** condition: ipynb ***)
#if IPYNB
area1
#endif // IPYNB

(***hide***)
area1 |> GenericChart.toChartHTML
(*** include-it-raw ***)

(**
### Area chart with a spline
*)

let area2 =
    Chart.SplineArea(x,y)

(*** condition: ipynb ***)
#if IPYNB
area2
#endif // IPYNB

(***hide***)
area2 |> GenericChart.toChartHTML
(*** include-it-raw ***)

(**
### Stacked Area chart
*)

let stackedArea =
    [
        Chart.StackedArea(x,y)
        Chart.StackedArea(x,y |> Seq.rev)
    ]
    |> Chart.Combine

(*** condition: ipynb ***)
#if IPYNB
stackedArea
#endif // IPYNB

(***hide***)
stackedArea |> GenericChart.toChartHTML
(*** include-it-raw ***)
