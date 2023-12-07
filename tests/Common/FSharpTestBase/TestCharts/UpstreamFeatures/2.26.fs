module PlotlyJS_2_26_TestCharts

open Plotly.NET
open Plotly.NET.TraceObjects
open Plotly.NET.LayoutObjects


module ``AutoRangeOptions`` = 

    let ``Point chart with autorange options on x and y axes`` =
        Chart.Point(
            x = [0 .. 10],
            y = [0 .. 10],
            UseDefaults = false, 
            ShowLegend = true
        )
        |> Chart.withXAxis(
            LinearAxis.init(
                AutoRangeOptions = AutoRangeOptions.init(
                    MinAllowed = 4,
                    ClipMax = 8
                )
            )
        )
        |> Chart.withYAxis(
            LinearAxis.init(
                AutoRangeOptions = AutoRangeOptions.init(
                    MinAllowed = 4,
                    ClipMax = 8
                )
            )
        )

    let ``Point chart with minallowed and maxallowed on x and y axes`` =
        Chart.Point(
            x = [0 .. 10],
            y = [0 .. 10],
            UseDefaults = false, 
            ShowLegend = true
        )
        |> Chart.withXAxis(
            LinearAxis.init(
                MinAllowed = 4,
                MaxAllowed = 8
            )
        )
        |> Chart.withYAxis(
            LinearAxis.init(
                MinAllowed = 4,
                MaxAllowed = 8
            )
        )

    let ``Point3D chart with autorange options on x, y, and z axes`` =

        Chart.Point3D(
            x = [0 .. 10],
            y = [0 .. 10],
            z = [0 .. 10],
            UseDefaults = false, 
            ShowLegend = true,
            CameraProjectionType = StyleParam.CameraProjectionType.Orthographic
        )
        |> Chart.withXAxis(
            LinearAxis.init(
                AutoRangeOptions = AutoRangeOptions.init(
                    MinAllowed = 4,
                    ClipMax = 8
                )
            ),
            Id = StyleParam.SubPlotId.Scene 1
        )
        |> Chart.withYAxis(
            LinearAxis.init(
                AutoRangeOptions = AutoRangeOptions.init(
                    MinAllowed = 4,
                    ClipMax = 8
                )
            ),
            Id = StyleParam.SubPlotId.Scene 1
        )
        |> Chart.withZAxis(
            LinearAxis.init(
                AutoRangeOptions = AutoRangeOptions.init(
                    MinAllowed = 4,
                    ClipMax = 8
                )
            )
        )

    let ``Point3D chart with minallowed and maxallowed on x, y, and z axes`` =

        Chart.Point3D(
            x = [0 .. 10],
            y = [0 .. 10],
            z = [0 .. 10],
            UseDefaults = false, 
            ShowLegend = true,
            CameraProjectionType = StyleParam.CameraProjectionType.Orthographic
        )
        |> Chart.withXAxis(
            LinearAxis.init(
                MinAllowed = 4,
                MaxAllowed = 8
            ),
            Id = StyleParam.SubPlotId.Scene 1
        )
        |> Chart.withYAxis(
            LinearAxis.init(
                MinAllowed = 4,
                MaxAllowed = 8
            ),
            Id = StyleParam.SubPlotId.Scene 1
        )
        |> Chart.withZAxis(
            LinearAxis.init(
                MinAllowed = 4,
                MaxAllowed = 8
            )
        )

    let ``PointPolar chart with autorange options on radial axis`` =

        Chart.PointPolar(
            r = [0 .. 10],
            theta = [0 .. 10 .. 100],
            UseDefaults = false, 
            ShowLegend = true
        )
        |> Chart.withRadialAxis(
            RadialAxis.init(
                AutoRangeOptions = AutoRangeOptions.init(
                    MinAllowed = 4,
                    MaxAllowed = 8
                )
            )
        )

    let ``PointPolar chart with minallowed and maxallowed on radial axis`` =
    
        Chart.PointPolar(
            r = [0 .. 10],
            theta = [0 .. 10 .. 100],
            UseDefaults = false, 
            ShowLegend = true
        )
        |> Chart.withRadialAxis(
            RadialAxis.init(
                MinAllowed = 4,
                MaxAllowed = 8
            )
        )

module ``N-sigma (std deviations) box plots`` =
    
    let ``2-sigma BoxPlot`` =
        Chart.BoxPlot(
            data = [-20; 1; 2; 3; 1; 2; 3; 3; 3; 3; 3; 1; 5; 20],
            orientation = StyleParam.Orientation.Vertical,
            SizeMode = StyleParam.BoxSizeMode.SD,
            UseDefaults = false
        )
        |> GenericChart.mapTrace (
            Trace2DStyle.BoxPlot(
                SDMultiple = 2.
            )
        )