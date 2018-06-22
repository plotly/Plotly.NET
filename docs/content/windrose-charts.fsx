(*** hide ***)
#r "netstandard"
#r "../../bin/FSharp.Plotly/netstandard2.0/FSharp.Plotly.dll"

(** 
# FSharp.Plotly: Wind Rose chart

*Summary:* This example shows how to create wind rose charts in F#.

A wind rose is a graphic tool used by meteorologists to give a succinct view 
of how wind speed and direction are typically distributed at a particular location.
*)

open FSharp.Plotly 
  
let r    = [77.5; 72.5; 70.0; 45.0; 22.5; 42.5; 40.0; 62.5]
let r'   = [57.5; 50.0; 45.0; 35.0; 20.0; 22.5; 37.5; 55.0]
let r''  = [40.0; 30.0; 30.0; 35.0; 7.5; 7.5; 32.5; 40.0]
let r''' = [20.0; 7.5; 15.0; 22.5; 2.5; 2.5; 12.5; 22.5]

let t = ["North"; "N-E"; "East"; "S-E"; "South"; "S-W"; "West"; "N-W"]
  
(*** define-output:windrose1 ***)
[
    Chart.WindRose (r   ,t,Name="11-14 m/s")
    Chart.WindRose (r'  ,t,Name="8-11 m/s")
    Chart.WindRose (r'' ,t,Name="5-8 m/s")
    Chart.WindRose (r''',t,Name="< 5 m/s")
]
|> Chart.Combine
(*** include-it:windrose1 ***)



