(*** hide ***)
#r "../../bin/Plotly.NET/net5.0/Plotly.NET.dll"

(** 
# Pie and doughnut Charts

*Summary:* This example shows how to create pie and doughnut charts in F#.

let's first create some data for the purpose of creating example charts:

*)
open Plotly.NET 
  
let values = [19; 26; 55;]
let labels = ["Residential"; "Non-Residential"; "Utility"]

(**

A pie or a doughnut chart can be created using the `Chart.Pie` and `Chart.Doughnut` functions.
When creating pie or doughnut charts, it is usually desirable to provide both labels and 
values.

*)

let pie1 =
    Chart.Pie(values,labels)

(***hide***)
pie1 |> GenericChart.toChartHTML
(***include-it-raw***)

let doughnut1 =
    Chart.Doughnut(
        values,
        labels,
        Hole=0.3,
        Textinfo=labels
    )

(***hide***)
doughnut1 |> GenericChart.toChartHTML
(***include-it-raw***)