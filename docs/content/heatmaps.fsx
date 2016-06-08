(*** hide ***)
#r "../../bin/Newtonsoft.Json.dll"
#r "../../bin/FSharp.Plotly.dll"

(** 
# FSharp.Plotly: Heatmaps

*Summary:* This example shows how to create heatmap charts in F#.

A heatmap chart can be created using the `Chart.HeatMap` functions.
When creating heatmap charts, it is usually desirable to provide the values in matrix form, rownames and colnames.
*)

open FSharp.Plotly 
 

let matrix =
    [[1.;1.5;0.7;2.7];
    [2.;0.5;1.2;1.4];
    [0.1;2.6;2.4;3.0];]

let rownames = ["p3";"p2";"p1"]
let colnames = ["Tp0";"Tp30";"Tp60";"Tp160"]



let colorscaleValue = 
    //StyleOption.ColorScale.Electric
    StyleOption.ColorScale.Custom [(0.0,"#3D9970");(1.0,"#001f3f")]
    
(*** define-output:heat1 ***)
Chart.HeatMap(matrix,colnames,rownames,Colorscale=colorscaleValue,Showscale=true)
|> Chart.withSize(700.,500.)
|> Chart.withMarginSize(left=200.)
(*** include-it:heat1 ***)
