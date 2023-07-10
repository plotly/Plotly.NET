module PlotlyJS_2_21_TestCharts

open Plotly.NET
open Plotly.NET.TraceObjects
open Plotly.NET.LayoutObjects


module ShapeLabelTextTemplate = 
    
    let ``Line shape with all template item variables accessed``=
        Chart.Point(
            [(0,10);(10,10)],
            UseDefaults = false
        )
        |> Chart.withShape(
            Shape.init(
                X0 = 0,
                X1 = 10,
                Y0 = 10,
                Y1 = 10,
                ShapeType = StyleParam.ShapeType.Line,
                Label = ShapeLabel.init(
                    TextTemplate = "Here are the values i can access:<br><b>Raw variables (from shape definition):</b><br><br>x0: %{x0}<br>x1: %{x1}<br>y0: %{y0}<br>y1: %{y1}<br><br><b>Calculated variables:</b><br><br>xcenter (calculated as (x0+x1)/2): %{xcenter}<br>ycenter (calculated as (y0+y1)/2): %{ycenter}<br>dx (calculated as x1-x0): %{dx}<br>dy (calculated as y1-y0): %{dy}<br>width (calculated as abs(x1-x0)): %{width}<br>height (calculated as abs(y1-y0)): %{height}<br>length (calculated as sqrt(dx^2+dy^2)) -- for lines only: %{length}<br>slope (calculated as (y1-y0)/(x1-x0)): %{slope}<br>"
                )
            )
        )
        |> Chart.withSize(1000,1000)