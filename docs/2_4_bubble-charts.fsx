(*** hide ***)

(*** condition: prepare ***)
#r "nuget: Newtonsoft.JSON, 12.0.3"
#r "../bin/Plotly.NET/netstandard2.1/Plotly.NET.dll"

(*** condition: ipynb ***)
#if IPYNB
#r "nuget: Plotly.NET, {{fsdocs-package-version}}"
#r "nuget: Plotly.NET.Interactive, {{fsdocs-package-version}}"
#endif // IPYNB

(** 
# Bubble charts

[![Binder](https://mybinder.org/badge_logo.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=2_4_bubble-charts.ipynb)

*Summary:* This example shows how to create bubble charts in F#.

let's first create some data for the purpose of creating example charts:
*)

open Plotly.NET 
  
let x = [2; 4; 6;]
let y = [4; 1; 6;]
let size = [19; 26; 55;]

(**

A bubble chart is a type of chart that displays three dimensions of data. Each entity with its triplet (x, y, size) 
of associated data is plotted as a disk. The first two values determine the disk's xy location and the 
third its size.

*)

let bubble1 = Chart.Bubble(x,y,size)

(*** condition: ipynb ***)
#if IPYNB
bubble1
#endif // IPYNB

(***hide***)
bubble1 |> GenericChart.toChartHTML
(***include-it-raw***)

