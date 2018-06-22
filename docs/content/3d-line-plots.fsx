(*** hide ***)
#r "netstandard"
#r "../../bin/FSharp.Plotly/netstandard2.0/FSharp.Plotly.dll"

(** 
# FSharp.Plotly: Scatter3d Charts with lines 

*Summary:* This example shows how to create three-dimensional scatter charts in F#.

A Scatter3d chart report shows a three-dimensional spinnable view of your data as line with markers
*)

open FSharp.Plotly 
open System
 
let c = [0. .. 0.5 .. 15.]

let x,y,z =  
    c
    |> List.map (fun i ->
                    let i' = float i 
                    let r = 10. * Math.Cos (i' / 10.)
                    (r*Math.Cos i',r*Math.Sin i',i')
                    )
    |> List.unzip3

  
(*** define-output:scatter3d_line_1 ***)
Chart.Scatter3d(x,y,z,StyleParam.Mode.Lines_Markers)
|> Chart.withX_AxisStyle("x-axis")
|> Chart.withY_AxisStyle("y-axis")
|> Chart.withZ_AxisStyle("z-axis")
|> Chart.withSize(800.,800.)
(*** include-it:scatter3d_line_1 ***)


