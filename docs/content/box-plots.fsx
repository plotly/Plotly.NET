(*** hide ***)
#r "../../bin/Newtonsoft.Json.dll"
#r "../../bin/FSharp.Plotly.dll"

(** 
# FSharp.Plotly: BoxPlot Charts

*Summary:* This example shows how to create boxplot charts in F#.

A boxplot chart can be created using the `Chart.BoxPlot` function.

*)

open FSharp.Plotly 
  
let y =  [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
let x = ["bin1";"bin2";"bin1";"bin2";"bin1";"bin2";"bin1";"bin1";"bin2";"bin1"]
  
(*** define-output:box1 ***)
Chart.BoxPlot(x,y,Jitter=0.3,Boxpoints=StyleOption.Boxpoints.Outliers)
(*** include-it:box1 ***)
