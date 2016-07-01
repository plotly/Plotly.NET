(*** hide ***)
#r "../../bin/Newtonsoft.Json.dll"
#r "../../bin/FSharp.Plotly.dll"

(** 
# FSharp.Plotly: Histogram2d

*Summary:* This example shows how to create a bi-dimensional histogram of two data samples in F#.

A Histogram2d chart can be created using the `Chart.Histogram2d` functions.
*)

open FSharp.Plotly 
  
let rnd = System.Random()
let x' = [for i=0 to 500 do yield rnd.NextDouble() ]
let y' = [for i=0 to 500 do yield rnd.NextDouble() ]
  
(*** define-output:histo1 ***)
[for i=0 to 500 do yield rnd.NextDouble(),rnd.NextDouble() ]
|> Chart.Histogram2d
|> Chart.withSize(500.,500.)
(*** include-it:histo1 ***)
