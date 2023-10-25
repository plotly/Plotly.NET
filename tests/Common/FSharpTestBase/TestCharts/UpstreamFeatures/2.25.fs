module PlotlyJS_2_25_TestCharts

open Plotly.NET
open Plotly.NET.TraceObjects
open Plotly.NET.LayoutObjects


module ``EqualEarth Geo Projection`` = 

    let ``PointGeo chart with EqualEarth projection type`` =
        Chart.PointGeo([1,2], UseDefaults = false)
        |> Chart.withGeoProjection(
            projectionType = StyleParam.GeoProjectionType.EqualEarth
        )

module ``Legends for shapes and newshape`` = 

    let ``Point chart with 2 shapes anchored to 2 legends`` =
        Chart.Point([1,2], UseDefaults = false)
        |> Chart.withShapes [
            Shape.init(
                X0 = 0.5,
                Y0 = 0.5,
                X1 = 1.,
                Y1 = 1.,
                Yref = "y",
                Xref = "x",
                ShowLegend = true
            )
            |> Shape.setLegendAnchor(1)
            Shape.init(
                X0 = 1.,
                Y0 = 1.,
                X1 = 2.,
                Y1 = 2.,
                Yref = "y",
                Xref = "x",
                ShowLegend = true
            )
            |> Shape.setLegendAnchor(2)
        ]
        |> Chart.withLegend (
            Legend.init (
                X = 0.25,
                Y = 0.25
            ),
            Id = 1
        )
        |> Chart.withLegend (
            Legend.init (
                X = 0.75,
                Y = 0.75
            ),
            Id = 2
        )

    let ``Point chart with dragmode = drawrect with new shapes added to legend 2`` =
        Chart.Point([1,2], UseDefaults = false, ShowLegend = true)
        |> Chart.withLayout(
            Layout.init(
                DragMode = StyleParam.DragMode.DrawRect,
                NewShape = (
                    NewShape.init(
                        DrawDirection = StyleParam.DrawDirection.Diagonal,
                        Visible = StyleParam.Visible.True,
                        ShowLegend = true
                    )
                    |> NewShape.setLegendAnchor(2)
                )
            )
        )
        |> Chart.withLegend (
            Legend.init (
                X = 0.25,
                Y = 0.25
            ),
            Id = 1
        )
        |> Chart.withLegend (
            Legend.init (
                X = 0.75,
                Y = 0.75
            ),
            Id = 2
        )