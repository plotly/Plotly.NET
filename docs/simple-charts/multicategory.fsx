(**
---
title: Plotting multicategory data
category: Simple Charts
categoryindex: 3
index: 10
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
# Plotting multicategory data

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to plot multicategory data on 2D charts in F#.

Since Plotly.NET v4, multicategory data are supported on the following 2D charts:

 - [Chart.Scatter](#Scatter)
 - [Chart.Bar and Chart.Column](#Bar-and-Column)
 - [Chart.Histogram](#Histogram)
 - [Chart.Histogram2D](#Histogram2D)
 - [Chart.BoxPlot and Chart.Violin](#BoxPlot-and-Violin)
 - [Chart.Histogram2DContour](#Histogram2DContour)
 - [Chart.Heatmap and Chart.AnnotatedHeatmap](#Heatmap-and-AnnotatedHeatmap)
 - [Chart.Contour](#Contour)
 - [Chart.OHLC and Chart.Candlestick](#OHLC-and-Candlestick)

## Scatter

Note that this does not apply to all derived Charts such as `Chart.Point`, `Chart.Line`, `Chart.Bubble`, `Chart.Spline` etc. (to avoid creating dozens of overloads for scatter derived traces).

You can, however, design those yourself using Chart.Scatter. Here are some examples:
*)
open Plotly.NET
open System

let multicategoryScatterAndDerived = 
    [
        Chart.Scatter(
            Name = "Point",
            Mode = StyleParam.Mode.Markers, // creates multicategory point chart
            MultiX = [["A";"A";"B";"B"];["AA"; "AB"; "BA"; "BB"]],
            MultiY = [
                ["A";"A";"B";"B"] |> Seq.map (fun x -> x :> IConvertible) // you can use different IConvertibles if you cast here
                [1; 2; -1; -2] |> Seq.map (fun x -> x :> IConvertible)
            ]
        )
        Chart.Scatter(
            Name = "Line",
            Mode = StyleParam.Mode.Lines, // creates multicategory line chart
            MultiX = [["C";"C";"D";"D"];["CA"; "CB"; "DA"; "DB"]],
            MultiY = [
                ["A";"A";"B";"B"] |> Seq.map (fun x -> x :> IConvertible) // you can use different IConvertibles if you cast here
                [1; 2; -1; -2] |> Seq.map (fun x -> x :> IConvertible)
            ]
        )
        Chart.Scatter(
            Name = "SplineArea",
            Mode = StyleParam.Mode.Lines, // creates multicategory splinearea chart
            MultiX = [["E";"E";"F";"F"];["EA"; "EB"; "FA"; "FB"]],
            MultiY = [
                ["A";"A";"B";"B"] |> Seq.map (fun x -> x :> IConvertible) // you can use different IConvertibles if you cast here
                [1; 2; -1; -2] |> Seq.map (fun x -> x :> IConvertible)
            ],
            Line = Line.init(Shape = StyleParam.Shape.Spline),
            Fill = StyleParam.Fill.ToZero_y
        )
    ]
    |> Chart.combine
    |> Chart.withSize(Width = 1000)

(*** condition: ipynb ***)
#if IPYNB
multicategoryScatterAndDerived
#endif // IPYNB

(***hide***)
multicategoryScatterAndDerived |> GenericChart.toChartHTML
(***include-it-raw***)

(**
## Bar and Column
*)
let multiCategoryBarColumn =
    [
        Chart.Bar(
            values = [1; 2; -1; -2],
            MultiKeys = [["A";"A";"B";"B"];["AA"; "AB"; "BA"; "BB"]],
            Name = "Bar"
        )
        Chart.Column(
            values = [1; 2; -1; -2],
            MultiKeys = [["A";"A";"B";"B"];["AA"; "AB"; "BA"; "BB"]],
            Name = "Column"
        )
    ]
    |> Chart.Grid (nRows = 1, nCols = 2)
    |> Chart.withSize(Width = 1000)

(*** condition: ipynb ***)
#if IPYNB
multiCategoryBarColumn
#endif // IPYNB

(***hide***)
multiCategoryBarColumn |> GenericChart.toChartHTML
(***include-it-raw***)

(**
## Histogram
*)

let multicategoryHistogram =
    Chart.Histogram(
        MultiX = [["A";"A";"A";"B";"B"];["AA"; "AA"; "AB"; "BA"; "BB"]]
    )

(*** condition: ipynb ***)
#if IPYNB
multicategoryHistogram
#endif // IPYNB

(***hide***)
multicategoryHistogram |> GenericChart.toChartHTML
(***include-it-raw***)

(**
## Histogram2D
*)

let multicategoryHistogram2D =
    Chart.Histogram2D(
        MultiX = [["A";"A";"A";"B";"B"];["AA"; "AA"; "AB"; "BA"; "BB"]],
        MultiY = [["A";"A";"A";"B";"B"];["AA"; "AA"; "AB"; "BA"; "BB"]]
    )

(*** condition: ipynb ***)
#if IPYNB
multicategoryHistogram2D
#endif // IPYNB

(***hide***)
multicategoryHistogram2D |> GenericChart.toChartHTML
(***include-it-raw***)

(**
## BoxPlot and Violin
*)

let multicategoryBoxPlotViolin =
    [
        [
            Chart.BoxPlot(
                Name = "BoxPlot 1",
                Y = [1;1;2;3;4;3;2],
                MultiX = [["A"; "A"; "A"; "A"; "A"; "A"; "A"];["AA"; "AA"; "AA"; "AA"; "AA"; "AA"; "AA"]]
            )
            Chart.BoxPlot(
                Name = "BoxPlot 2",
                Y = [1;1;2;3;4;3;2],
                MultiX = [["A"; "A"; "A"; "A"; "A"; "A"; "A"];["AB"; "AB"; "AB"; "AB"; "AB"; "AB"; "AB"]]
            )            
            Chart.BoxPlot(
                Name = "BoxPlot 3",
                Y = [1;1;2;3;4;3;2],
                MultiX = [["B"; "B"; "B"; "B"; "B"; "B"; "B"];["BB"; "BB"; "BB"; "BB"; "BB"; "BB"; "BB"]]
            )
        ]
        |> Chart.combine
        [
            Chart.Violin(
                Name = "Violin 1",
                Y = [1;1;2;3;4;3;2],
                MultiX = [["A"; "A"; "A"; "A"; "A"; "A"; "A"];["AA"; "AA"; "AA"; "AA"; "AA"; "AA"; "AA"]]
            )
            Chart.Violin(
                Name = "Violin 2",
                Y = [1;1;2;3;4;3;2],
                MultiX = [["A"; "A"; "A"; "A"; "A"; "A"; "A"];["AB"; "AB"; "AB"; "AB"; "AB"; "AB"; "AB"]]
            )
            Chart.Violin(
                Name = "Violin 3",
                Y = [1;1;2;3;4;3;2],
                MultiX = [["B"; "B"; "B"; "B"; "B"; "B"; "B"];["BB"; "BB"; "BB"; "BB"; "BB"; "BB"; "BB"]]
            )
        ]
        |> Chart.combine
    ]
    |> Chart.Grid (nRows = 1, nCols = 2)
    |> Chart.withSize(Width = 1000)

(*** condition: ipynb ***)
#if IPYNB
multicategoryBoxPlotViolin
#endif // IPYNB

(***hide***)
multicategoryBoxPlotViolin |> GenericChart.toChartHTML
(***include-it-raw***)

(**
## Histogram2DContour
*)

let multicategoryHistogram2DContour =
    Chart.Histogram2DContour(
        MultiX = [["A";"A";"A";"B";"B"];["AA"; "AA"; "AB"; "BA"; "BB"]],
        MultiY = [["A";"A";"A";"B";"B"];["AA"; "AA"; "AB"; "BA"; "BB"]]
    )

(*** condition: ipynb ***)
#if IPYNB
multicategoryHistogram2DContour
#endif // IPYNB

(***hide***)
multicategoryHistogram2DContour |> GenericChart.toChartHTML
(***include-it-raw***)

(**
## Heatmap and AnnotatedHeatmap
*)

let multicategoryHeatmap = 
    Chart.Heatmap(
        zData = [
            [1;2;3]
            [2;3;1]
            [3;1;2]
        ],
        MultiX = [["A";"A";"B"];["AA";"AB";"BA"]],
        MultiY = [["A";"A";"B"];["AA";"AB";"BA"]]
    )

(*** condition: ipynb ***)
#if IPYNB
multicategoryHeatmap
#endif // IPYNB

(***hide***)
multicategoryHeatmap |> GenericChart.toChartHTML
(***include-it-raw***)

let multicategoryAnnotatedHeatmap = 
    Chart.AnnotatedHeatmap(
        zData = [
            [1;2;3]
            [2;3;1]
            [3;1;2]
        ],
        annotationText = [
            ["A;AA x A;AA";"A;AA x A;AB";"A;AA x B;BA"]
            ["A;AB x A;AA";"A;AB x A;AB";"A;AB x B;BA"]
            ["B;BA x A;AA";"B;BA x A;AB";"B;BA x B;BA"]
        ],
        MultiX = [["A";"A";"B"];["AA";"AB";"BA"]],
        MultiY = [["A";"A";"B"];["AA";"AB";"BA"]]
    )

(*** condition: ipynb ***)
#if IPYNB
multicategoryAnnotatedHeatmap
#endif // IPYNB

(***hide***)
multicategoryAnnotatedHeatmap |> GenericChart.toChartHTML
(***include-it-raw***)

(**
## Contour
*)

let multicategoryContour =
    Chart.Contour(
        zData = [
            [1;2;3]
            [2;3;1]
            [3;1;2]
        ],
        MultiX = [["A";"A";"B"];["AA";"AB";"BA"]],
        MultiY = [["A";"A";"B"];["AA";"AB";"BA"]]
    )

(*** condition: ipynb ***)
#if IPYNB
multicategoryContour
#endif // IPYNB

(***hide***)
multicategoryContour |> GenericChart.toChartHTML
(***include-it-raw***)

(**
## OHLC and Candlestick
*)

let multicategoryFinance =
    [
        Chart.OHLC(
            ``open`` = [1;2],
            high = [3;4],
            low = [0;1],
            close = [0.5;1.],
            MultiX = [["A";"A"];["AA";"AB"]],
            Name = "OHLC"
        )
        Chart.Candlestick(
            ``open`` = [1;2],
            high = [3;4],
            low = [0;1],
            close = [0.5;1.],
            MultiX = [["A";"A"];["AA";"AB"]],
            Name = "Candlestick"
        )
    ]
    |> Chart.Grid (nRows = 1, nCols = 2)
    |> Chart.withSize(Width = 1000)

(*** condition: ipynb ***)
#if IPYNB
multicategoryFinance
#endif // IPYNB

(***hide***)
multicategoryFinance |> GenericChart.toChartHTML
(***include-it-raw***)