(**
---
title: Multicharts and subplots
category: Chart Layout
categoryindex: 2
index: 3
---
*)

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
# Multicharts and subplots

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath={{fsdocs-source-basename}}.ipynb)&emsp;
[![Script]({{root}}img/badge-script.svg)]({{root}}{{fsdocs-source-basename}}.fsx)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create charts with multiple subplots in F#.

let's first create some data for the purpose of creating example charts:

*)

open Plotly.NET 
  
let x = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
let y = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]


(**

## Combining charts

`Chart.Combine` takes a sequence of charts, and attempts to combine their layouts to 
produce a composite chart with one layout containing all traces of the input:

*)

let combinedChart = 
    [
        Chart.Line(x,y,Name="first")
        Chart.Line(y,x,Name="second")
    ]
    |> Chart.Combine

#if IPYNB
combinedChart
#endif // end cell with chart value in a notebook context
(***hide***)
combinedChart |> GenericChart.toChartHTML
(***include-it-raw***)

(**

## Chart subplot grids

### Chart.Grid

`Chart.Grid` creates a subplot grid. There are two overloads:

You can either use Chart.Grid with a 1 dimensional sequence of Charts and specify the amount of rows and columns:

*)

//simple 2x2 subplot grid
let grid = 
    [
        Chart.Point(x,y,Name="1,1")
        |> Chart.withX_AxisStyle "x1"
        |> Chart.withY_AxisStyle "y1"    
        Chart.Line(x,y,Name="1,2")
        |> Chart.withX_AxisStyle "x2"
        |> Chart.withY_AxisStyle "y2"
        Chart.Spline(x,y,Name="2,1")
        |> Chart.withX_AxisStyle "x3"
        |> Chart.withY_AxisStyle "y3"    
        Chart.Point(x,y,Name="2,2")
        |> Chart.withX_AxisStyle "x4"
        |> Chart.withY_AxisStyle "y4"
    ]
    |> Chart.Grid(2,2)

(*** condition: ipynb ***)
#if IPYNB
grid
#endif // IPYNB

(***hide***)
grid |> GenericChart.toChartHTML
(***include-it-raw***)

(**
or provide a 2-dimensional Chart sequence as input, the dimensions of the input will then be used to set the dimensions of the grid:
*)

//simple 2x2 subplot grid using a 2x2 2D chart sequence as input
let grid2 = 
    [
        [
            Chart.Point(x,y,Name="1,1")
            |> Chart.withX_AxisStyle "x1"
            |> Chart.withY_AxisStyle "y1"    
            Chart.Line(x,y,Name="1,2")
            |> Chart.withX_AxisStyle "x2"
            |> Chart.withY_AxisStyle "y2"
        ]
        [
            Chart.Spline(x,y,Name="2,1")
            |> Chart.withX_AxisStyle "x3"
            |> Chart.withY_AxisStyle "y3"    
            Chart.Point(x,y,Name="2,2")
            |> Chart.withX_AxisStyle "x4"
            |> Chart.withY_AxisStyle "y4"
        
        ]
    ]
    |> Chart.Grid()

(*** condition: ipynb ***)
#if IPYNB
grid2
#endif // IPYNB

(***hide***)
grid2 |> GenericChart.toChartHTML
(***include-it-raw***)

(**
To leave cells of the grid empty, you have to fill it with dummy charts via `Chart.Invisible()`.
Pleas enote that when using a 2D sequence with unequal amounts of charts in the rows, the column amount will be set
to the row with the highest amount of charts, and the other rows will be filled by invisible charts to the right.
*)

//simple 2x2 subplot grid with an empty cell at position 1,2
let grid3 = 
    [
        Chart.Point(x,y,Name="1,1")
        |> Chart.withX_AxisStyle "x1"
        |> Chart.withY_AxisStyle "y1"    

        Chart.Invisible()

        Chart.Spline(x,y,Name="2,1")
        |> Chart.withX_AxisStyle "x3"
        |> Chart.withY_AxisStyle "y3"    

        Chart.Point(x,y,Name="2,2")
        |> Chart.withX_AxisStyle "x4"
        |> Chart.withY_AxisStyle "y4"
    ]
    |> Chart.Grid(2,2)

(*** condition: ipynb ***)
#if IPYNB
grid3
#endif // IPYNB

(***hide***)
grid3 |> GenericChart.toChartHTML
(***include-it-raw***)

(**
use `Pattern=StyleParam.LayoutGridPatter.Coupled` to use one shared x axis per column and one shared y axis per row. 
(Try zooming in the single subplots below)
*)

let grid4 =
    [
        Chart.Point(x,y,Name="1,1")
        |> Chart.withX_AxisStyle "x1"
        |> Chart.withY_AxisStyle "y1"    
        Chart.Line(x,y,Name="1,2")
        |> Chart.withX_AxisStyle "x2"
        |> Chart.withY_AxisStyle "y2"
        Chart.Spline(x,y,Name="2,1")
        |> Chart.withX_AxisStyle "x3"
        |> Chart.withY_AxisStyle "y3"    
        Chart.Point(x,y,Name="2,2")
        |> Chart.withX_AxisStyle "x4"
        |> Chart.withY_AxisStyle "y4"
    ]
    |> Chart.Grid(2,2,Pattern=StyleParam.LayoutGridPattern.Coupled)

(*** condition: ipynb ***)
#if IPYNB
grid4
#endif // IPYNB

(***hide***)
grid4 |> GenericChart.toChartHTML
(***include-it-raw***)

(** 
### Chart.SingleStack

The `Chart.SingleStack` function is a special version of Chart.Grid that creates only one column from a 1D input chart sequence.
It uses a shared x axis per default.

As with all grid charts, you can also use the Chart.withLayoutGridStyle to style subplot grids:

*)

let singleStack =
    [
        Chart.Point(x,y) 
        |> Chart.withY_AxisStyle("This title must")

        Chart.Line(x,y) 
        |> Chart.withY_AxisStyle("be set on the")
        
        Chart.Spline(x,y) 
        |> Chart.withY_AxisStyle("respective subplots")
    ]
    |> Chart.SingleStack(Pattern= StyleParam.LayoutGridPattern.Coupled)
    //increase spacing between plots by using the withLayoutGridStyle function
    |> Chart.withLayoutGridStyle(YGap= 0.1)
    |> Chart.withTitle("Hi i am the new SingleStackChart")
    |> Chart.withX_AxisStyle("im the shared xAxis")

(*** condition: ipynb ***)
#if IPYNB
singleStack
#endif // IPYNB

(***hide***)
singleStack |> GenericChart.toChartHTML
(***include-it-raw***)
