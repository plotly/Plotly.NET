(*** hide ***)

(*** condition: prepare ***)
#r @"..\packages\Newtonsoft.Json\lib\netstandard2.0\Newtonsoft.Json.dll"
#r "../bin/Plotly.NET/net5.0/Plotly.NET.dll"
(*** condition: fsx ***)
#if FSX
#r "../packages/Newtonsoft.Json/lib/netstandard2.0/Newtonsoft.Json.dll"
#r "../bin/Plotly.NET/net5.0/Plotly.NET.dll"
#endif // FSX
(*** condition: ipynb ***)
#if IPYNB
#r "nuget: Plotly.NET, 2.0.0-beta1"
#r "nuget: Plotly.NET.Interactive, 2.0.0-alpha5"
#endif // IPYNB

(** 
# Wind rose charts

[![Binder](https://mybinder.org/badge_logo.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=windrose-charts.ipynb)

*Summary:* This example shows how to create wind rose charts in F#.

let's first create some data for the purpose of creating example charts:

*)

open Plotly.NET 
  
let r    = [77.5; 72.5; 70.0; 45.0; 22.5; 42.5; 40.0; 62.5]
let r'   = [57.5; 50.0; 45.0; 35.0; 20.0; 22.5; 37.5; 55.0]
let r''  = [40.0; 30.0; 30.0; 35.0; 7.5; 7.5; 32.5; 40.0]
let r''' = [20.0; 7.5; 15.0; 22.5; 2.5; 2.5; 12.5; 22.5]

let t = ["North"; "N-E"; "East"; "S-E"; "South"; "S-W"; "West"; "N-W"]

(**
A wind rose is a graphic tool used by meteorologists to give a succinct view 
of how wind speed and direction are typically distributed at a particular location.
*)
  
let windrose1 =
    [
        Chart.WindRose (r   ,t,Name="11-14 m/s")
        Chart.WindRose (r'  ,t,Name="8-11 m/s")
        Chart.WindRose (r'' ,t,Name="5-8 m/s")
        Chart.WindRose (r''',t,Name="< 5 m/s")
    ]
    |> Chart.Combine

(*** condition: ipynb ***)
#if IPYNB
windrose1
#endif // IPYNB

(***hide***)
windrose1 |> GenericChart.toChartHTML
(***include-it-raw***)



