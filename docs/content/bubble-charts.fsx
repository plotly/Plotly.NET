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
  
let x = [2; 4; 6;]
let y = [4; 1; 6;]
let size = [19; 26; 55;]
  
(*** define-output:pie1 ***)
Chart.Bubble(x,y,size,Color=["rgba(255,255,100,0.5)";"rgba(255,255,10,0.5)";"rgba(255,2,10,0.5)"])
(*** include-it:pie1 ***)
