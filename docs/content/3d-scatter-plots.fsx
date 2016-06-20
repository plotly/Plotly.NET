(*** hide ***)
#r "../../bin/Newtonsoft.Json.dll"
#r "../../bin/FSharp.Plotly.dll"

(** 
# FSharp.Plotly: Scatter3d Charts

*Summary:* This example shows how to create three-dimensional scatter charts in F#.

A Scatter3d chart report shows a three-dimensional spinnable view of your data
*)

open FSharp.Plotly 
  
let x = [19; 26; 55;]
let y = [19; 26; 55;]
let z = [19; 26; 55;]

  
(*** define-output:scatter3d_1 ***)
Chart.Scatter3d(x,y,z,StyleOption.Mode.Markers)
|> Chart.withX_AxisStyle("my x-axis")
|> Chart.withSize(800.,800.)

(*** include-it:scatter3d_1 ***)
|> Chart.Show






