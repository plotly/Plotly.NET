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
#r "nuget: Newtonsoft.JSON, 13.0.1"
#r "nuget: DynamicObj, 2.0.0"
#r "nuget: Giraffe.ViewEngine.StrongName, 2.0.0-alpha1"
#r "../../src/Plotly.NET/bin/Release/netstandard2.0/Plotly.NET.dll"

Plotly.NET.Defaults.DefaultDisplayOptions <-
    Plotly.NET.DisplayOptions.init (PlotlyJSReference = Plotly.NET.PlotlyJSReference.NoReference)

(*** condition: ipynb ***)
#if IPYNB
#r "nuget: Plotly.NET, {{fsdocs-package-version}}"
#r "nuget: Plotly.NET.Interactive, {{fsdocs-package-version}}"
#endif // IPYNB

(**
# Multicharts and subplots

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create charts with multiple subplots in F#.

Let's first create some data for the purpose of creating example charts:

*)

open Plotly.NET

let x = [ 1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10. ]
let y = [ 2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1. ]


(**

## Combining charts

`Chart.Combine` takes a sequence of charts, and attempts to combine their layouts to 
produce a composite chart with one layout containing all traces of the input:

*)

let combinedChart =
    [ Chart.Line(x = x, y = y, Name = "first")
      Chart.Line(x = y, y = x, Name = "second") ]
    |> Chart.combine

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

You can either use Chart.Grid with a 1 dimensional sequence of Charts and specify the number of rows and columns:

*)

//simple 2x2 subplot grid
let grid =
    [ Chart.Point(x = x, y = y, Name = "1,1")
      |> Chart.withXAxisStyle "x1"
      |> Chart.withYAxisStyle "y1"
      Chart.Line(x = x, y = y, Name = "1,2")
      |> Chart.withXAxisStyle "x2"
      |> Chart.withYAxisStyle "y2"
      Chart.Spline(x = x, y = y, Name = "2,1")
      |> Chart.withXAxisStyle "x3"
      |> Chart.withYAxisStyle "y3"
      Chart.Point(x = x, y = y, Name = "2,2")
      |> Chart.withXAxisStyle "x4"
      |> Chart.withYAxisStyle "y4" ]
    |> Chart.Grid(2, 2)

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
    [ [ Chart.Point(x = x, y = y, Name = "1,1")
        |> Chart.withXAxisStyle "x1"
        |> Chart.withYAxisStyle "y1"
        Chart.Line(x = x, y = y, Name = "1,2")
        |> Chart.withXAxisStyle "x2"
        |> Chart.withYAxisStyle "y2" ]
      [ Chart.Spline(x = x, y = y, Name = "2,1")
        |> Chart.withXAxisStyle "x3"
        |> Chart.withYAxisStyle "y3"
        Chart.Point(x = x, y = y, Name = "2,2")
        |> Chart.withXAxisStyle "x4"
        |> Chart.withYAxisStyle "y4"

        ] ]
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
Pleas note that when using a 2D sequence with unequal numbers of charts in the rows, the column count will be set
to the row with the highest number of charts, and the other rows will be filled by invisible charts to the right.
*)

//simple 2x2 subplot grid with an empty cell at position 1,2
let grid3 =
    [ Chart.Point(x = x, y = y, Name = "1,1")
      |> Chart.withXAxisStyle "x1"
      |> Chart.withYAxisStyle "y1"

      Chart.Invisible()

      Chart.Spline(x = x, y = y, Name = "2,1")
      |> Chart.withXAxisStyle "x3"
      |> Chart.withYAxisStyle "y3"

      Chart.Point(x = x, y = y, Name = "2,2")
      |> Chart.withXAxisStyle "x4"
      |> Chart.withYAxisStyle "y4" ]
    |> Chart.Grid(2, 2)

(*** condition: ipynb ***)
#if IPYNB
grid3
#endif // IPYNB

(***hide***)
grid3 |> GenericChart.toChartHTML
(***include-it-raw***)

(**

#### Coupled axes

Use `Pattern=StyleParam.LayoutGridPatter.Coupled` to use one shared x axis per column and one shared y axis per row. 
(Try zooming in the single subplots below)
*)

let grid4 =
    [ Chart.Point(x = x, y = y, Name = "1,1")
      |> Chart.withXAxisStyle "x1"
      |> Chart.withYAxisStyle "y1"
      Chart.Line(x = x, y = y, Name = "1,2")
      |> Chart.withXAxisStyle "x2"
      |> Chart.withYAxisStyle "y2"
      Chart.Spline(x = x, y = y, Name = "2,1")
      |> Chart.withXAxisStyle "x3"
      |> Chart.withYAxisStyle "y3"
      Chart.Point(x = x, y = y, Name = "2,2")
      |> Chart.withXAxisStyle "x4"
      |> Chart.withYAxisStyle "y4" ]
    |> Chart.Grid(nRows = 2, nCols = 2, Pattern = StyleParam.LayoutGridPattern.Coupled)

(*** condition: ipynb ***)
#if IPYNB
grid4
#endif // IPYNB

(***hide***)
grid4 |> GenericChart.toChartHTML
(***include-it-raw***)

(**

#### Individual subplot titles

You can set individual subplot titles by using the `SubPlotTitles` argument of the `Chart.Grid` function:
*)

let grid5 =
    [ Chart.Point(x = x, y = y, Name = "1,1")
      |> Chart.withXAxisStyle "x1"
      |> Chart.withYAxisStyle "y1"
      Chart.Line(x = x, y = y, Name = "1,2")
      |> Chart.withXAxisStyle "x2"
      |> Chart.withYAxisStyle "y2"
      Chart.Spline(x = x, y = y, Name = "2,1")
      |> Chart.withXAxisStyle "x3"
      |> Chart.withYAxisStyle "y3"
      Chart.Point(x = x, y = y, Name = "2,2")
      |> Chart.withXAxisStyle "x4"
      |> Chart.withYAxisStyle "y4" ]
    |> Chart.Grid(2, 2, SubPlotTitles = [ "First"; "Second"; "Third"; "Fourth" ])

(*** condition: ipynb ***)
#if IPYNB
grid5
#endif // IPYNB

(***hide***)
grid5 |> GenericChart.toChartHTML
(***include-it-raw***)

(** 
### Chart.SingleStack

The `Chart.SingleStack` function is a special version of Chart.Grid that creates only one column from a 1D input chart sequence.
It uses a shared x axis by default.

As with all grid charts, you can also use the Chart.withLayoutGridStyle to style subplot grids:

*)

let singleStack =
    [ Chart.Point(x = x, y = y) |> Chart.withYAxisStyle ("This title must")

      Chart.Line(x = x, y = y) |> Chart.withYAxisStyle ("be set on the")

      Chart.Spline(x = x, y = y) |> Chart.withYAxisStyle ("respective subplots") ]
    |> Chart.SingleStack(Pattern = StyleParam.LayoutGridPattern.Coupled)
    //increase spacing between plots by using the withLayoutGridStyle function
    |> Chart.withLayoutGridStyle (YGap = 0.1)
    |> Chart.withTitle (title = "Hi i am the new SingleStackChart")
    |> Chart.withXAxisStyle (TitleText = "im the shared xAxis")

(*** condition: ipynb ***)
#if IPYNB
singleStack
#endif // IPYNB

(***hide***)
singleStack |> GenericChart.toChartHTML
(***include-it-raw***)

(**
### Using subplots of different trace types in a grid

Chart.Grid does some internal magic to make sure that all trace types get their grid cell according to plotly.js's inner logic. 

The only thing you have to consider is that when you are using nested combined charts, they have to have the same trace type.

Otherwise, you can freely combine all charts with Chart.Grid:

*)
open Plotly.NET.LayoutObjects

let multipleTraceTypesGrid =
    [ Chart.Point(xy = [ 1, 2; 2, 3 ], Name = "2D Cartesian")
      Chart.Point3D(xyz = [ 1, 3, 2 ], Name = "3D Cartesian")
      Chart.PointPolar(rTheta = [ 10, 20 ], Name = "Polar")
      Chart.PointGeo(lonlat = [ 1, 2 ], Name = "Geo")
      Chart.PointMapbox(lonlat = [ 1, 2 ], Name = "MapBox")
      |> Chart.withMapbox (Mapbox.init (Style = StyleParam.MapboxStyle.OpenStreetMap))
      Chart.PointTernary(abc = [ 1, 2, 3; 2, 3, 4 ], Name = "Ternary")
      [ Chart.Carpet(
            carpetId = "contour",
            A = [ 0.; 1.; 2.; 3.; 0.; 1.; 2.; 3.; 0.; 1.; 2.; 3. ],
            B = [ 4.; 4.; 4.; 4.; 5.; 5.; 5.; 5.; 6.; 6.; 6.; 6. ],
            X = [ 2.; 3.; 4.; 5.; 2.2; 3.1; 4.1; 5.1; 1.5; 2.5; 3.5; 4.5 ],
            Y = [ 1.; 1.4; 1.6; 1.75; 2.; 2.5; 2.7; 2.75; 3.; 3.5; 3.7; 3.75 ],
            AAxis =
                LinearAxis.initCarpet (
                    TickPrefix = "a = ",
                    Smoothing = 0.,
                    MinorGridCount = 9,
                    AxisType = StyleParam.AxisType.Linear
                ),
            BAxis =
                LinearAxis.initCarpet (
                    TickPrefix = "b = ",
                    Smoothing = 0.,
                    MinorGridCount = 9,
                    AxisType = StyleParam.AxisType.Linear
                ),
            Opacity = 0.75
        )
        Chart.ContourCarpet(
            z = [ 1.; 1.96; 2.56; 3.0625; 4.; 5.0625; 1.; 7.5625; 9.; 12.25; 15.21; 14.0625 ],
            carpetAnchorId = "contour",
            A = [ 0; 1; 2; 3; 0; 1; 2; 3; 0; 1; 2; 3 ],
            B = [ 4; 4; 4; 4; 5; 5; 5; 5; 6; 6; 6; 6 ],
            ContourLineColor = Color.fromKeyword White,
            ShowContourLabels = true,
            ShowScale = false
        ) ]
      |> Chart.combine
      Chart.Pie(values = [ 10; 40; 50 ], Name = "Domain")
      Chart.BubbleSmith(
          real = [ 0.5; 1.; 2.; 3. ],
          imag = [ 0.5; 1.; 2.; 3. ],
          sizes = [ 10; 20; 30; 40 ],
          MultiText = [ "one"; "two"; "three"; "four"; "five"; "six"; "seven" ],
          TextPosition = StyleParam.TextPosition.TopCenter,
          Name = "Smith"
      )
      [
        // you can use nested combined charts, but they have to have the same trace type (Cartesian2D in this case)
        let y =
            [ 2.
              1.5
              5.
              1.5
              2.
              2.5
              2.1
              2.5
              1.5
              1.
              2.
              1.5
              5.
              1.5
              3.
              2.5
              2.5
              1.5
              3.5
              1. ]

        Chart.BoxPlot(X = "y", Y = y, Name = "Combined 1", Jitter = 0.1, BoxPoints = StyleParam.BoxPoints.All)
        Chart.BoxPlot(X = "y'", Y = y, Name = "Combined 2", Jitter = 0.1, BoxPoints = StyleParam.BoxPoints.All) ]
      |> Chart.combine ]
    |> Chart.Grid(
      nRows = 4, 
      nCols = 3,
      SubPlotTitles = [ 
        "2D Cartesian"
        "3D Cartesian"
        "Polar"
        "Geo"
        "MapBox"
        "Ternary"
        "Carpet"
        "Pie"
        "BubbleSmith"
        "Combined 1"
      ]
    )
    |> Chart.withSize (Width = 1000, Height = 1500)

(*** condition: ipynb ***)
#if IPYNB
multipleTraceTypesGrid
#endif // IPYNB

(***hide***)
multipleTraceTypesGrid |> GenericChart.toChartHTML
(***include-it-raw***)

(**
If you are not sure if trace types are compatible, look at the `TraceIDs`:
*)

Chart.Point(xy = [ 1, 2 ]) |> GenericChart.getTraceID
(***include-it***)

[ Chart.Point(xy = [ 1, 2 ]); Chart.PointTernary(abc = [ 1, 2, 3 ]) ]
|> Chart.combine
|> GenericChart.getTraceID
(***include-it***)

[ Chart.Point(xy = [ 1, 2 ]); Chart.PointTernary(abc = [ 1, 2, 3 ]) ]
|> Chart.combine
|> GenericChart.getTraceIDs
(***include-it***)
