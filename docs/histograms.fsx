(*** hide ***)
#r "../bin/Plotly.NET/net5.0/Plotly.NET.dll"

(** 
# Histograms

*Summary:* This example shows how to create a one-dimensional histogram of a data samples in F#.

let's first create some data for the purpose of creating example charts:

*)


open Plotly.NET 

let rnd = System.Random()
let x = [for i=0 to 500 do yield rnd.NextDouble() ]

(**
A histogram consisting of rectangles whose area is proportional to the frequency of a variable and whose width is equal to the class interval.
The histogram chart represents the distribution of numerical data and can be created using the `Chart.Histogram` function:.
*)

let histo1 =
    x
    |> Chart.Histogram
    |> Chart.withSize(500.,500.)

(***hide***)
histo1 |> GenericChart.toChartHTML
(***include-it-raw***)

