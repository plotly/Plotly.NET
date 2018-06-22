(*** hide ***)
#r "netstandard"
#r "../../bin/FSharp.Plotly/netstandard2.0/FSharp.Plotly.dll"

(** 
# FSharp.Plotly: Bubble chart

*Summary:* This example shows how to create pie and doughnut charts in F#.

A bubble chart is a type of chart that displays three dimensions of data. Each entity with its triplet (x, y, size) 
of associated data is plotted as a disk. The first two values determine the disk's xy location and the 
third its size.
*)

open FSharp.Plotly 
  
let x = [2; 4; 6;]
let y = [4; 1; 6;]
let size = [19; 26; 55;]
  
(*** define-output:pie1 ***)
Chart.Bubble(x,y,size,Color=["rgba(255,255,100,0.5)";"rgba(255,255,10,0.5)";"rgba(255,2,10,0.5)"])
(*** include-it:pie1 ***)
