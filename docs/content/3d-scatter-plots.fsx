(*** hide ***)
#r "../../bin/Plotly.NET/net5.0/Plotly.NET.dll"

(** 
# Scatter3d charts

*Summary:* This example shows how to create three-dimensional scatter charts in F#.

A Scatter3d chart report shows a three-dimensional spinnable view of your data
*)

open Plotly.NET 
  
let x = [19; 26; 55;]
let y = [19; 26; 55;]
let z = [19; 26; 55;]

let scatter3d = 
    Chart.Scatter3d(x,y,z,StyleParam.Mode.Markers)
    |> Chart.withX_AxisStyle("my x-axis")
    |> Chart.withY_AxisStyle("my y-axis")
    |> Chart.withZ_AxisStyle("my z-axis")
    |> Chart.withSize(800.,800.)

(***hide***)
scatter3d |> GenericChart.toChartHTML
(*** include-it-raw ***)



