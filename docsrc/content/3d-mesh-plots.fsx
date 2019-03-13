(*** hide ***)
#r "netstandard"
#r @"../../lib/Formatting/FSharp.Plotly.dll"


(** 
# FSharp.Plotly: Mesh3d

*Summary:* This example shows how to create 3D-Mesh charts in F#.

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

let rnd = System.Random()
let a = Array.init 50 (fun _ -> rnd.NextDouble())
let b = Array.init 50 (fun _ -> rnd.NextDouble())
let c = Array.init 50 (fun _ -> rnd.NextDouble())

let cont = DynamicObj()
//cont?color <- ""
cont?show <- true
cont?width <- 3


let mesh3d =
    Trace3d.initMesh3d 
        (fun mesh3d ->
            mesh3d?x <- a
            mesh3d?y <- b
            mesh3d?z <- c
            mesh3d?flatshading <- true
            mesh3d?contour <- Contours.initXyz(Show=true)
            mesh3d
            )
    |> GenericChart.ofTraceObject 

(***do-not-eval***)
mesh3d |> Chart.Show

(*** include-value:mesh3d ***)
