(*** hide ***)
#r "../../bin/Newtonsoft.Json.dll"
#r "../../bin/FSharp.Plotly.dll"

(** 
# FSharp.Plotly: Pie and Doughnut Charts

*Summary:* This example shows how to create pie and doughnut charts in F#.

A pie or a doughnut chart can be created using the `Chart.Pie` and `Chart.Doughnut` functions.
When creating pie or doughnut charts, it is usually desirable to provide both labels and 
values.
*)

open System
open FSharp.Plotly 


// Generate linearly spaced vector
let linspace (min,max,n) = 
    if n <= 2 then failwithf "n needs to be larger then 2"
    let bw = float (max - min) / (float n - 1.)
    Array.init n (fun i -> min + (bw * float i))
    //[|min ..bw ..max|]
  

// Create example data
let size = 100
let x = linspace(-2. * Math.PI, 2. * Math.PI, size)
let y = linspace(-2. * Math.PI, 2. * Math.PI, size)

let f x y = - (5. * x / (x**2. + y**2. + 1.) )

let z = 
    Array.init size (fun i -> 
        Array.init size (fun j -> f x.[j] y.[i] )
                    )


  
(*** define-output:contour1 ***)
z
|> Chart.Surface
|> Chart.withSize(600.,600.)
(*** include-it:contour1 ***)

// Create simple example data were x y and z is given (z is a xy-Matrix)
let x' = [0.;2.5]
let y' = [0.;2.5]
let z' = [
    [1.;1.;]; // row wise (length x)
    [1.;1.;];
    ] // column (length y)

Chart.Surface(z',x',y')



