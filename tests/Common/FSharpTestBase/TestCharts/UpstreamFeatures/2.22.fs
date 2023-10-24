module PlotlyJS_2_22_TestCharts

open Plotly.NET
open Plotly.NET.TraceObjects
open Plotly.NET.LayoutObjects


module MultiLegends = 
    
    let ``Two Line traces with one styled legend each``=
        [
            Chart.Point([1,2], UseDefaults = false)
            |> Chart.withLegendAnchor 1
            Chart.Point([100,200], UseDefaults = false)
            |> Chart.withLegendAnchor 2
        ]
        |> Chart.combine
        |> Chart.withLegend(
            Legend.init(
                X = 0.25,
                Y = 0.25,
                BorderColor = Color.fromKeyword Blue,
                BorderWidth = 2,
                Title = Title.init(
                    Text = "Legend 1"
                )
            ),
            Id = 1
        )
        |> Chart.withLegend(
            Legend.init(
                X = 0.75,
                Y = 0.75,
                BorderColor = Color.fromKeyword Red,
                BorderWidth = 2,
                Title = Title.init(
                    Text = "Legend 2"
                )
            ),
            Id = 2
        )