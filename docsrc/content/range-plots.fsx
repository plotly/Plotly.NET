(*** hide ***)
#r "netstandard"
#r "../../bin/Plotly.NET/netstandard2.0/Plotly.NET.dll"


(** 
# Plotly.NET: Range plot Charts

*Summary:* This example shows how to create Range plot charts in F#.

A pie or a doughnut chart can be created using the `Chart.Pie` and `Chart.Doughnut` functions.
When creating pie or doughnut charts, it is usually desirable to provide both labels and 
values.
*)

open Plotly.NET 
open StyleParam

let rnd = System.Random()

let x  = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
let y = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]

let yUpper = y |> List.map (fun v -> v + rnd.NextDouble())
let yLower = y |> List.map (fun v -> v - rnd.NextDouble())

  
let range1 =
    Chart.Range(x,y,yUpper,yLower,Mode.Markers,Color="grey",RangeColor="lightblue")

(***do-not-eval***)
range1 |> Chart.Show

(*** include-value:range1 ***)


