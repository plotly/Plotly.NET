module PlotlyJS_2_27_TestCharts

open Plotly.NET
open Plotly.NET.TraceObjects
open Plotly.NET.LayoutObjects


module ``InsideRange for linear axes`` = 

    let ``Inside range for y axis`` = 
        Chart.Line(
            x = [1; 2; 3; 4],
            y = [1; 1; 2; 3], 
            UseDefaults = false
        )
        |> Chart.withXAxis(
            LinearAxis.init(
                Anchor = StyleParam.LinearAxisId.Y 1,
                Ticks = StyleParam.TickOptions.Inside,
                TickLabelPosition = StyleParam.TickLabelPosition.Inside
            )
        )
        |> Chart.withYAxis(
            LinearAxis.init(
                Anchor = StyleParam.LinearAxisId.X 1,
                InsideRange = StyleParam.Range.ofMinMax(1, 3)
            )
        )
    
    let ``Inside range for x axis`` = 
        Chart.Line(
            x = [1; 2; 3; 4],
            y = [1; 1; 2; 3], 
            UseDefaults = false
        )
        |> Chart.withXAxis(
            LinearAxis.init(
                Anchor = StyleParam.LinearAxisId.Y 1,
                InsideRange = StyleParam.Range.ofMinMax(1, 3)
            )
        )
        |> Chart.withYAxis(
            LinearAxis.init(
                Anchor = StyleParam.LinearAxisId.X 1,
                Ticks = StyleParam.TickOptions.Inside,
                TickLabelPosition = StyleParam.TickLabelPosition.Inside
            )
        )