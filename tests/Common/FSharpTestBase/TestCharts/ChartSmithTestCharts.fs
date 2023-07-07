module ChartSmithTestCharts

open Plotly.NET
open Plotly.NET.TraceObjects


module ScatterSmith =

    let ``Simple smith scatter chart`` =
        Chart.ScatterSmith(
            real = [0.5; 1.; 2.; 3.],
            imag = [0.5; 1.; 2.; 3.],
            mode = StyleParam.Mode.Lines_Markers_Text,
            MultiText = ["Pretty"; "Cool"; "Plot"; "Huh?"],
            TextPosition = StyleParam.TextPosition.TopCenter,
            UseDefaults = false
        )

module PointSmith =

    let ``Simple smith point chart`` =
        Chart.PointSmith(
            real = [0.5; 1.; 2.; 3.],
            imag = [0.5; 1.; 2.; 3.],
            UseDefaults = false
        )

module LineSmith =

    let ``Simple smith line chart`` =
        Chart.LineSmith(
            real = [0.5; 1.; 2.; 3.],
            imag = [0.5; 1.; 2.; 3.],
            LineDash = StyleParam.DrawingStyle.DashDot,
            LineColor = Color.fromKeyword Purple,
            UseDefaults = false
        )

module BubbleSmith =

    let ``Simple smith bubble chart`` =
        Chart.BubbleSmith(
            real = [0.5; 1.; 2.; 3.],
            imag = [0.5; 1.; 2.; 3.],
            sizes = [10;20;30;40],
            MultiText=["one";"two";"three";"four";"five";"six";"seven"],
            TextPosition=StyleParam.TextPosition.TopCenter,
            UseDefaults = false
        )