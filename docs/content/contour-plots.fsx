(*** hide ***)
#r "../../bin/Plotly.NET/net5.0/Plotly.NET.dll"

(** 
# Contour plots

*Summary:* This example shows how to create contour plot in F#.

let's first create some data for the purpose of creating example charts:

*)

open System
open Plotly.NET 

// Generate linearly spaced vector
let linspace (min,max,n) = 
    if n <= 2 then failwithf "n needs to be larger then 2"
    let bw = float (max - min) / (float n - 1.)
    [|min ..bw ..max|]

// Create example data
let size = 100
let x = linspace(-2. * Math.PI, 2. * Math.PI, size)
let y = linspace(-2. * Math.PI, 2. * Math.PI, size)

let f x y = - (5. * x / (x**2. + y**2. + 1.) )

let z = 
    Array.init size (fun i -> 
        Array.init size (fun j -> 
            f x.[j] y.[i] 
        )
    )

(**
A contour plot is a graphical technique for representing a 3-dimensional surface by plotting
constant z slices, called contours, on a 2-dimensional format. That is, given a value for z,
lines are drawn for connecting the (x,y) coordinates where that z value occurs.
The contour plot is an alternative to a 3-D surface plot.

The contour plot is an alternative to a 3-D surface plot.

*)

let contour1 =
    z
    |> Chart.Contour
    |> Chart.withSize(600.,600.)

(***hide***)
contour1 |> GenericChart.toChartHTML
(***include-it-raw***)
