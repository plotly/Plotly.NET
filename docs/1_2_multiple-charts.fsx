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

`Chart.Grid` takes a 2D input sequence of charts and creates a subplot grid 
with the dimensions (outerlength,(max (innerLengths))

*)

//simple 3x3 subplot grid
let grid = 
    Chart.Grid(
        [
            [Chart.Line(x,y); Chart.Line(x,y); Chart.Line(x,y)]
            [Chart.Point(x,y); Chart.Point(x,y); Chart.Point(x,y)]
            [Chart.Spline(x,y); Chart.Spline(x,y); Chart.Spline(x,y)]
        ]
    )

(*** condition: ipynb ***)
#if IPYNB
grid
#endif // IPYNB

(***hide***)
grid |> GenericChart.toChartHTML
(***include-it-raw***)


(**
use `sharedAxis=true` to use one shared x axis per column and one shared y axis per row. 
(Try zooming in the single subplots below)
*)

let grid2 =
    Chart.Grid(
        [
            [Chart.Line(x,y); Chart.Line(x,y); Chart.Line(x,y)]
            [Chart.Point(x,y); Chart.Point(x,y); Chart.Point(x,y)]
            [Chart.Spline(x,y); Chart.Spline(x,y); Chart.Spline(x,y)]
        ],
        sharedAxes=true
    )
    |> Chart.withLayoutGridStyle(
        XSide = StyleParam.LayoutGridXSide.Bottom
    )

(*** condition: ipynb ***)
#if IPYNB
grid2
#endif // IPYNB

(***hide***)
grid2 |> GenericChart.toChartHTML
(***include-it-raw***)


(** 
### Chart.SingleStack

The `Chart.SingleStack` function is a special version of Chart.Grid that creates only one column from a 1D input chart sequence.
It uses a shared x axis per default. You can also use the Chart.withLayoutGridStyle to further style subplot grids:

*)

let singleStack =
    [
        Chart.Point(x,y) 
        |> Chart.withY_AxisStyle("This title must")

        Chart.Line(x,y) 
        |> Chart.withY_AxisStyle("be set on the",Zeroline=false)
        
        Chart.Spline(x,y) 
        |> Chart.withY_AxisStyle("respective subplots",Zeroline=false)
    ]
    |> Chart.SingleStack
    //move xAxis to bottom and increase spacing between plots by using the withLayoutGridStyle function
    |> Chart.withLayoutGridStyle(XSide=StyleParam.LayoutGridXSide.Bottom,YGap= 0.1)
    |> Chart.withTitle("Hi i am the new SingleStackChart")
    |> Chart.withX_AxisStyle("im the shared xAxis")

(*** condition: ipynb ***)
#if IPYNB
singleStack
#endif // IPYNB

(***hide***)
singleStack |> GenericChart.toChartHTML
(***include-it-raw***)
