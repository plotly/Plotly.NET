#r "netstandard"
#r "../../bin/Plotly.NET/netstandard2.0/Plotly.NET.dll"

(** 
# Plotly.NET: Histogram

*Summary:* This example shows how to create a one-dimensional histogram of a data samples in F#.

A histogram consisting of rectangles whose area is proportional to the frequency of a variable and whose width is equal to the class interval.
The histogram chart represents the distribution of numerical data and can be created using the `Chart.Histogram`.
*)

open Plotly.NET 

let rnd = System.Random()
let x = [for i=0 to 500 do yield rnd.NextDouble() ]
  
let histo1 =
    x
    |> Chart.Histogram
    |> Chart.withSize(500.,500.)

(***do-not-eval***)
histo1 |> Chart.Show

(*** include-value:histo1 ***)


