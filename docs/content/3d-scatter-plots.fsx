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

open FSharp.Plotly 
  
let x = [19; 26; 55;]
let y = [19; 26; 55;]
let z = [19; 26; 55;]

  
(*** define-output:scatter3d_1 ***)
Chart3d.Scatter(x,y,z,StyleOption.Mode.Markers)
(*** include-it:scatter3d_1 ***)
|> Chart3d.withSize(900.,900.)
|> Chart3d.Show





