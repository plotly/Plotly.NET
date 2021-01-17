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
# Error bars

[![Binder](https://mybinder.org/badge_logo.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=errorbars.ipynb)

*Summary:* This example shows how to add error bars to plots in F#.

let's first create some data for the purpose of creating example charts:

*)

open Plotly.NET

let x  = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
let y' = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
let xError = [|0.2;0.3;0.2;0.1;0.2;0.4;0.2;0.08;0.2;0.1;|]
let yError = [|0.3;0.2;0.1;0.4;0.2;0.4;0.1;0.18;0.02;0.2;|]
(**
To add error bars to a chart, use the `Chart.with*ErrorStyle` functions for either X, Y, or Z.
*)

let pointsWithErrorBars =
    Chart.Point(x,y',Name="points with errors")    
    |> Chart.withXErrorStyle (Array=xError,Symmetric=true)
    |> Chart.withYErrorStyle (Array=yError, Arrayminus = xError) // for negative error, use positive values in the `Arrayminus` argument 

(*** condition: ipynb ***)
#if IPYNB
pointsWithErrorBars
#endif // IPYNB

(***hide***)
pointsWithErrorBars |> GenericChart.toChartHTML
(***include-it-raw***)
