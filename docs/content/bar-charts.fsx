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
  
let yValues = [20; 14; 23;]
let xValues = ["Product A"; "Product B"; "Product C";]
let labels  = ["27% market share"; "24% market share"; "19% market share";]
  
(*** define-output:pie1 ***)
Chart.Bar(xValues,yValues,Labels=labels,Opacity=0.3,Marker=Options.Marker(Color="rgba(222,45,38,0.8)"))
|> Chart.withSize(500.,500.)
(*** include-it:pie1 ***)
|> Chart.Show

