module PlotlyJS_2_23_TestCharts

open Plotly.NET
open Plotly.NET.TraceObjects
open Plotly.NET.LayoutObjects


module ``Colorbar X and Y ref`` = 
    
    let ``Heatmap with horizontal colorbar with x/yref = container`` = 
        Chart.Heatmap(
            [
                [1; 2; 3]
                [3; 2; 1]
            ],
            UseDefaults = false
        )
        |> Chart.withColorBar(
            ColorBar.init(
                X = 0.5,
                Y = 0.1,
                Orientation = StyleParam.Orientation.Horizontal,
                XRef = "container",
                YRef = "container",
                Title = Title.init(
                    Text = "Colorbar 1"
                )
            )
        )

module ``Legend X and Y ref`` = 

    let ``Point chart with horizontal legend with x/yref = container`` = 
        Chart.Point(
            [1,2],
            ShowLegend = true,
            UseDefaults = false
        )
        |> Chart.withLegend(
            Legend.init(
                X = 0.5,
                Y = 0.1,
                Orientation = StyleParam.Orientation.Horizontal,
                XRef = "container",
                YRef = "container",
                BorderColor = Color.fromKeyword Blue,
                BorderWidth = 2,
                Title = Title.init(
                    Text = "Legend 1"
                )
            )
        )