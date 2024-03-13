module Fix_HoverInfo_TestCharts

open Plotly.NET
open Plotly.NET.TraceObjects
open Plotly.NET.LayoutObjects
open DynamicObj

// https://github.com/plotly/Plotly.NET/issues/446

module ``Fix missing HoverInfo bindings #446`` = 
    
    let ``Point3D charts with all possible hoverinfo combinations`` =
        [
            StyleParam.HoverInfo.X
            StyleParam.HoverInfo.XY
            StyleParam.HoverInfo.XYZ
            StyleParam.HoverInfo.XYZText
            StyleParam.HoverInfo.XYZTextName
            StyleParam.HoverInfo.Y
            StyleParam.HoverInfo.YZ
            StyleParam.HoverInfo.YZText
            StyleParam.HoverInfo.YZTextName
            StyleParam.HoverInfo.Z
            StyleParam.HoverInfo.ZText
            StyleParam.HoverInfo.ZTextName
            StyleParam.HoverInfo.Text
            StyleParam.HoverInfo.TextName
            StyleParam.HoverInfo.Name
            StyleParam.HoverInfo.All
            StyleParam.HoverInfo.None
            StyleParam.HoverInfo.Skip
        ]
        |> List.mapi (fun i hi ->
            Chart.Point3D(
                xyz = [i + 1, i + 2, i + 3],
                Name = $"NAME: trace with {hi.ToString()}",
                Text = $"TEXT: trace with {hi.ToString()}",
                UseDefaults = false
            )
            |> GenericChart.mapTrace (Trace3DStyle.Scatter3D(HoverInfo = hi))
        )
        |> Chart.combine
        |> Chart.withSize(1000,1000)