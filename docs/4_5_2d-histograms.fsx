(*** hide ***)

(*** condition: prepare ***)
#r "nuget: Newtonsoft.JSON, 12.0.3"
#r "../bin/Plotly.NET/netstandard2.0/Plotly.NET.dll"

(*** condition: ipynb ***)
#if IPYNB
#r "nuget: Plotly.NET, {{fsdocs-package-version}}"
#r "nuget: Plotly.NET.Interactive, {{fsdocs-package-version}}"
#endif // IPYNB

(** 
# 2D Histograms

[![Binder](https://mybinder.org/badge_logo.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=4_5_2d-histograms.ipynb)

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
        Chart.Histogram2dContour (x,y,Line=Line.init(Width=0.))
        Chart.Point(x,y,Opacity=0.3)
    ]
    |> Chart.Combine

(*** condition: ipynb ***)
#if IPYNB
histogramContour
#endif // IPYNB

(***hide***)
histogramContour |> GenericChart.toChartHTML
(*** include-it-raw ***)

let histogram2d = 
    Chart.Histogram2d (x,y)

(*** condition: ipynb ***)
#if IPYNB
histogram2d
#endif // IPYNB

(***hide***)
histogram2d |> GenericChart.toChartHTML
(*** include-it-raw ***)