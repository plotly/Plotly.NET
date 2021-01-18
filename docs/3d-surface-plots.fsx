(*** hide ***)

(*** condition: prepare ***)
#r @"..\packages\Newtonsoft.Json\lib\netstandard2.0\Newtonsoft.Json.dll"
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
# 3D surface plots

[![Binder](https://mybinder.org/badge_logo.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=3d-surface-plots.ipynb)

*Summary:* This example shows how to create 3D surface plots in F#.

let's first create some data for the purpose of creating example charts:
*)
open System
open Plotly.NET 

//---------------------- Generate linearly spaced vector ----------------------
let linspace (min,max,n) = 
    if n <= 2 then failwithf "n needs to be larger then 2"
    let bw = float (max - min) / (float n - 1.)
    Array.init n (fun i -> min + (bw * float i))

//---------------------- Create example data ----------------------
let size = 100
let x = linspace(-2. * Math.PI, 2. * Math.PI, size)
let y = linspace(-2. * Math.PI, 2. * Math.PI, size)

let f x y = - (5. * x / (x**2. + y**2. + 1.) )

let z = 
    Array.init size (fun i -> 
        Array.init size (fun j -> f x.[j] y.[i] )
                    )

let rnd = System.Random()
let a = Array.init 50 (fun _ -> rnd.NextDouble())
let b = Array.init 50 (fun _ -> rnd.NextDouble())
let c = Array.init 50 (fun _ -> rnd.NextDouble())

let surface = 
    z
    |> Chart.Surface

(*** condition: ipynb ***)
#if IPYNB
surface
#endif // IPYNB

(***hide***)
surface |> GenericChart.toChartHTML
(*** include-it-raw ***)

// Create simple example data were x y and z is given (z is a xy-Matrix)
let x' = [0.;2.5]
let y' = [0.;2.5]
let z' = [
    [1.;1.;]; // row wise (length x)
    [1.;2.;];
    ] // column (length y)

let surface2 = 
    Chart.Surface(z',x',y',Opacity=0.5,Contours=Contours.initXyz(Show=true))

(*** condition: ipynb ***)
#if IPYNB
surface2
#endif // IPYNB

(***hide***)
surface2 |> GenericChart.toChartHTML
(*** include-it-raw ***)


