(*** hide ***)

(*** condition: prepare ***)
#r "nuget: Newtonsoft.JSON, 12.0.3"
#r "../bin/Plotly.NET/netstandard2.0/Plotly.NET.dll"

(*** condition: ipynb ***)
#if IPYNB
#r "nuget: Plotly.NET, {{fsdocs-package-version}}"
#r "nuget: Plotly.NET.Interactive, {{fsdocs-package-version}}"
#endif // IPYNB

(** 
# Bar and column charts

[![Binder](https://mybinder.org/badge_logo.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=2_1_bar-and-column-charts.ipynb)

*Summary:* This example shows how to create bar and a column charts in F#.

let's first create some data for the purpose of creating example charts:
*)

open Plotly.NET 
  
let values = [20; 14; 23;]
let keys   = ["Product A"; "Product B"; "Product C";]

(**
A bar chart or bar graph is a chart that presents grouped data with rectangular bars with 
lengths proportional to the values that they represent. The bars can be plotted vertically
or horizontally. A vertical bar chart is called a column bar chart.

### Column Charts
*)

let column = Chart.Column(keys,values)

(*** condition: ipynb ***)
#if IPYNB
column
#endif // IPYNB

(***hide***)
column |> GenericChart.toChartHTML
(***include-it-raw***)

(**
### Bar Charts
*)

let bar =
    Chart.Bar(keys,values)

(*** condition: ipynb ***)
#if IPYNB
bar
#endif // IPYNB

(***hide***)
bar |> GenericChart.toChartHTML
(***include-it-raw***)

(** 

## Stacked bar chart or column charts
The following example shows how to create a stacked bar chart by combining bar charts created by combining multiple `Chart.StackedBar` charts: 

### Stacked bar Charts
*)

let stackedBar =
    [
        Chart.StackedBar(keys,values,Name="old");
        Chart.StackedBar(keys,[8; 21; 13;],Name="new")
    ]
    |> Chart.Combine

(*** condition: ipynb ***)
#if IPYNB
stackedBar
#endif // IPYNB

(***hide***)
stackedBar |> GenericChart.toChartHTML
(***include-it-raw***)

(*
### Stacked bar Charts
*)

let stackedColumn =
    [
        Chart.StackedColumn(keys,values,Name="old");
        Chart.StackedColumn(keys,[8; 21; 13;],Name="new")
    ]
    |> Chart.Combine

(*** condition: ipynb ***)
#if IPYNB
stackedColumn
#endif // IPYNB

(***hide***)
stackedColumn |> GenericChart.toChartHTML
(***include-it-raw***)
