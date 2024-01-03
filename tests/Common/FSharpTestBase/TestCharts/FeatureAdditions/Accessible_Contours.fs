module Accessible_Contrours_TestCharts

open Plotly.NET
open Plotly.NET.TraceObjects
open Plotly.NET.LayoutObjects

// https://github.com/plotly/Plotly.NET/issues/426

module ``Contours should be accessible #426`` = 

    let ``Contour chart with more contours settings`` =
        // max z is 10
        Chart.Contour(
            zData = [
                [5;2;3]
                [10;2;1]
                [0;5;1]
            ],
            ShowContoursLabels = true,
            ShowContourLines = true,
            ContoursStart = 0,
            ContoursEnd = 15,
            UseDefaults = false
        )
        |> Chart.withColorAxisAnchor(1)


    let ``Histogram2DContour chart with more contours settings`` =
        // max z is 5
        Chart.Histogram2DContour(
            X = [1;1;2;2;2;2;2;3;4;5],
            Y = [1;1;2;2;2;2;2;3;4;5],
            ShowContoursLabels = true,
            ShowContourLines = true,
            ContoursStart = 0,
            ContoursEnd = 15,
            UseDefaults = false
        )
        |> Chart.withColorAxisAnchor(1)


    let ``PointDensity chart with accessible contours settings`` =
        // max z is 15
        Chart.PointDensity(
            x = [1;1;2;2;2;2;2;2;2;2;2;2;2;2;2;2;2;3;4;5],
            y = [1;1;2;2;2;2;2;2;2;2;2;2;2;2;2;2;2;3;4;5],
            ShowContoursLabels = true,
            ShowContourLines = true,
            ContoursStart = 0,
            ContoursEnd = 15,
            UseDefaults = false
        )
        |> Chart.withColorAxisAnchor(1)

    let ``Contours trace Grid chart with shared color axis and adapted contours ranges`` =
        [
            // max z is 10
            Chart.Contour(
                zData = [
                    [5;2;3]
                    [10;2;1]
                    [0;5;1]
                ],
                ShowContoursLabels = true,
                ShowContourLines = true,
                ContoursStart = 0,
                ContoursEnd = 15,
                UseDefaults = false
            )
            |> Chart.withColorAxisAnchor(1)

            // max z is 5
            Chart.Histogram2DContour(
                X = [1;1;2;2;2;2;2;3;4;5],
                Y = [1;1;2;2;2;2;2;3;4;5],
                ShowContoursLabels = true,
                ShowContourLines = true,
                ContoursStart = 0,
                ContoursEnd = 15,
                UseDefaults = false
            )
            |> Chart.withColorAxisAnchor(1)

            // max z is 15
            Chart.PointDensity(
                x = [1;1;2;2;2;2;2;2;2;2;2;2;2;2;2;2;2;3;4;5],
                y = [1;1;2;2;2;2;2;2;2;2;2;2;2;2;2;2;2;3;4;5],
                ShowContoursLabels = true,
                ShowContourLines = true,
                ContoursStart = 0,
                ContoursEnd = 15,
                UseDefaults = false
            )
            |> Chart.withColorAxisAnchor(1)
        ]
        |> Chart.Grid(2,2)
