(*** hide ***)
#r "netstandard"
#r "../../bin/Plotly.NET/netstandard2.0/Plotly.NET.dll"

(** 
# Plotly.NET: Area Charts

*Summary:* This example shows how to create an area charts in F#.

An area chart or area graph displays graphically quantitive data. It is based on the line chart.
The area between axis and line are commonly emphasized with colors, textures and hatchings.
*)

open Plotly.NET 
  
let x  = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
let y  = [5.; 2.5; 5.; 7.5; 5.; 2.5; 7.5; 4.5; 5.5; 5.]
//let y' = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
  
let area1 = 
    Chart.Area(x,y)

(***do-not-eval***)
area1 |> Chart.Show

(*** include-value:area1 ***)

let area2 =
    Chart.SplineArea(x,y)

(***do-not-eval***)
area2 |> Chart.Show

(*** include-value:area2 ***)

let stackedArea =
    [
    Chart.StackedArea(x,y)
    Chart.StackedArea(x,y |> Seq.rev)
    ]
    |> Chart.Combine

(***do-not-eval***)
stackedArea |> Chart.Show

(*** include-value:stackedArea ***)