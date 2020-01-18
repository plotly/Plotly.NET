(*** hide ***)
#r "netstandard"
#r @"../../lib/Formatting/FSharp.Plotly.dll"

(** 
# FSharp.Plotly: Sankey Charts

*Summary:* This example shows how to create sankey charts in F#.

Sankey charts are a visualization of multiple, linked graphs layed out linearly. 
These are usually used to depict flow between nodes or stations.
To create Sankey, a set of nodes and links between them are required. 
These are created using the provided Node and Link structures.
*)

open FSharp.Plotly 
open FSharp.Plotly.StyleParam
let n1 = Node.Create("a",color="Black")
let n2 = Node.Create("b",color="Red")
let n3 = Node.Create("c",color="Purple")
let n4 = Node.Create("d",color="Green")
let n5 = Node.Create("e",color="Orange")
let link1 = Link.Create(n1,n2,value=1.0)
let link2 = Link.Create(n2,n3,value=2.0)
let link3 = Link.Create(n1,n5,value=1.3)
let link4 = Link.Create(n4,n5,value=1.5)
let link5 = Link.Create(n3,n5,value=0.5)

let ch1 = 
    Chart.Sankey([n1;n2;n3;n4;n5],[link1;link2;link3;link4;link5])
    |> Chart.withTitle "Sankey Sample"


(***do-not-eval***)
ch1 |> Chart.Show

(*** include-value:ch1 ***)

