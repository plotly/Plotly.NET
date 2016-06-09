(*** hide ***)
#r "../../bin/Newtonsoft.Json.dll"
#r "../../bin/FSharp.Plotly.dll"

(** 
# FSharp.Plotly: Histogram2d

*Summary:* This example shows how to create pie and doughnut charts in F#.

A pie or a doughnut chart can be created using the `Chart.Pie` and `Chart.Doughnut` functions.
When creating pie or doughnut charts, it is usually desirable to provide both labels and 
values.
*)

open FSharp.Plotly 
  
let rnd = System.Random()
let x' = [for i=0 to 500 do yield rnd.NextDouble() ]
let y' = [for i=0 to 500 do yield rnd.NextDouble() ]
  
(*** define-output:histo1 ***)
Chart.Histogram2d(x',y')
(*** include-it:histo1 ***)
