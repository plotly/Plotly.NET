(*** hide ***)
#r "../../packages/Newtonsoft.Json/lib/netstandard2.0/Newtonsoft.Json.dll"
#r "../../bin/Plotly.NET/net5.0/Plotly.NET.dll"


(** 
# Histogram2D

*Summary:* This example shows how to create a bi-dimensional histogram of two data samples in F#.

let's first create some data for the purpose of creating example charts:
*)

open Plotly.NET 

//---------------------- generate random normally distributed data ---------------------- 
let normal (rnd:System.Random) mu tau =
    let mutable v1 = 2.0 * rnd.NextDouble() - 1.0
    let mutable v2 = 2.0 * rnd.NextDouble() - 1.0
    let mutable r = v1 * v1 + v2 * v2
    while (r >= 1.0 || r = 0.0) do
        v1 <- 2.0 * rnd.NextDouble() - 1.0
        v2 <- 2.0 * rnd.NextDouble() - 1.0
        r <- v1 * v1 + v2 * v2
    let fac = sqrt(-2.0*(log r)/r)
    (tau * v1 * fac + mu)

let rnd = System.Random()
let n = 2000
let a = -1.
let b = 1.2
let step i = a +  ((b - a) / float (n - 1)) * float i

//---------------------- generate data distributed in x and y direction ---------------------- 
let x = Array.init n (fun i -> ((step i)**3.) + (0.3 * (normal (rnd) 0. 2.) ))
let y = Array.init n (fun i -> ((step i)**6.) + (0.3 * (normal (rnd) 0. 2.) ))

(**
A Histogram2d chart can be created using the `Chart.Histogram2d` or `Chart.Histogram2dContour` functions.
*)

let histogramContour =
    [
        Chart.Histogram2dContour (x,y,Line=Line.init(Width=0))
        Chart.Point(x,y,Opacity=0.3)
    ]
    |> Chart.Combine

(***hide***)
histogramContour |> GenericChart.toChartHTML
(*** include-it-raw ***)

let histogram2d = 
    Chart.Histogram2d (x,y)

(***hide***)
histogram2d |> GenericChart.toChartHTML
(*** include-it-raw ***)