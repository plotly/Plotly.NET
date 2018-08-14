(*** hide ***)
#r "netstandard"
#r "../../bin/FSharp.Plotly/netstandard2.0/FSharp.Plotly.dll"

(** 
# FSharp.Plotly: Pie and Doughnut Charts

*Summary:* This example shows how to create pie and doughnut charts in F#.

A pie or a doughnut chart can be created using the `Chart.Pie` and `Chart.Doughnut` functions.
When creating pie or doughnut charts, it is usually desirable to provide both labels and 
values.
*)

open FSharp.Plotly 
  
let values = [19; 26; 55;]
let labels = ["Residential"; "Non-Residential"; "Utility"]
  
(*** define-output:pie1 ***)
Chart.Pie(values,labels)
(*** include-it:pie1 ***)

(*** define-output:doughnut1 ***)
Chart.Doughnut(values,labels,Hole=0.3,Textinfo=labels)
(*** include-it:doughnut1 ***)
|> Chart.Show


