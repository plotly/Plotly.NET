(*** hide ***)
#r "../bin/Plotly.NET/net5.0/Plotly.NET.dll"

(** 
# Bar and column charts

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

(***hide***)
column |> GenericChart.toChartHTML
(***include-it-raw***)

(**
### Bar Charts
*)

let bar =
    Chart.Bar(keys,values)

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

(***hide***)
stackedColumn |> GenericChart.toChartHTML
(***include-it-raw***)
