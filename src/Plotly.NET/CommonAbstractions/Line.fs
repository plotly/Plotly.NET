namespace Plotly.NET

open System.Runtime.InteropServices
open DynamicObj
open System

/// Line type inherits from dynamic object
type Line() =
    inherit DynamicObj()

    /// Initialized Line object
    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?Color: Color,
            [<Optional; DefaultParameterValue(null)>] ?Width: float,
            [<Optional; DefaultParameterValue(null)>] ?MultiWidth: seq<float>,
            [<Optional; DefaultParameterValue(null)>] ?Shape: StyleParam.Shape,
            [<Optional; DefaultParameterValue(null)>] ?Dash: StyleParam.DrawingStyle,
            [<Optional; DefaultParameterValue(null)>] ?Smoothing: float,
            [<Optional; DefaultParameterValue(null)>] ?OutlierColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?OutlierWidth: float,
            [<Optional; DefaultParameterValue(null)>] ?AutoColorScale: bool,
            [<Optional; DefaultParameterValue(null)>] ?CAuto: bool,
            [<Optional; DefaultParameterValue(null)>] ?CMax: float,
            [<Optional; DefaultParameterValue(null)>] ?CMid: float,
            [<Optional; DefaultParameterValue(null)>] ?CMin: float,
            [<Optional; DefaultParameterValue(null)>] ?ColorAxis: StyleParam.SubPlotId,
            [<Optional; DefaultParameterValue(null)>] ?Colorscale: StyleParam.Colorscale,
            [<Optional; DefaultParameterValue(null)>] ?ReverseScale: bool,
            [<Optional; DefaultParameterValue(null)>] ?ShowScale: bool,
            [<Optional; DefaultParameterValue(null)>] ?ColorBar: #DynamicObj
        ) =
        Line()
        |> Line.style (
            ?Color = Color,
            ?Width = Width,
            ?MultiWidth = MultiWidth,
            ?Shape = Shape,
            ?Dash = Dash,
            ?Smoothing = Smoothing,
            ?OutlierColor = OutlierColor,
            ?OutlierWidth = OutlierWidth,
            ?AutoColorScale = AutoColorScale,
            ?CAuto = CAuto,
            ?CMax = CMax,
            ?CMid = CMid,
            ?CMin = CMin,
            ?ColorAxis = ColorAxis,
            ?Colorscale = Colorscale,
            ?ReverseScale = ReverseScale,
            ?ShowScale = ShowScale,
            ?ColorBar = ColorBar

        )


    // Applies the styles to Line()
    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?Color: Color,
            [<Optional; DefaultParameterValue(null)>] ?Width: float,
            [<Optional; DefaultParameterValue(null)>] ?MultiWidth: seq<float>,
            [<Optional; DefaultParameterValue(null)>] ?Shape: StyleParam.Shape,
            [<Optional; DefaultParameterValue(null)>] ?Dash: StyleParam.DrawingStyle,
            [<Optional; DefaultParameterValue(null)>] ?Smoothing: float,
            [<Optional; DefaultParameterValue(null)>] ?OutlierColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?OutlierWidth: float,
            [<Optional; DefaultParameterValue(null)>] ?AutoColorScale: bool,
            [<Optional; DefaultParameterValue(null)>] ?CAuto: bool,
            [<Optional; DefaultParameterValue(null)>] ?CMax: float,
            [<Optional; DefaultParameterValue(null)>] ?CMid: float,
            [<Optional; DefaultParameterValue(null)>] ?CMin: float,
            [<Optional; DefaultParameterValue(null)>] ?ColorAxis: StyleParam.SubPlotId,
            [<Optional; DefaultParameterValue(null)>] ?Colorscale: StyleParam.Colorscale,
            [<Optional; DefaultParameterValue(null)>] ?ReverseScale: bool,
            [<Optional; DefaultParameterValue(null)>] ?ShowScale: bool,
            [<Optional; DefaultParameterValue(null)>] ?ColorBar: #DynamicObj
        ) =
        (fun (line: Line) ->
            ++? ("color", Color )
            (Width, MultiWidth) |> DynObj.setSingleOrMultiOpt line "width"

            // out ->
            line
            ++?? ("shape", Shape , StyleParam.Shape.convert)
            ++? ("smoothing", Smoothing )
            ++?? ("dash", Dash , StyleParam.DrawingStyle.convert)
            ++? ("outliercolor", OutlierColor )
            ++? ("outlierwidth", OutlierWidth )
            ++? ("autocolorscale", AutoColorScale )
            ++? ("cauto", CAuto )
            ++? ("cmax", CMax )
            ++? ("cmid", CMid )
            ++? ("cmin", CMin )
            ++? ("color", Color )
            ++?? ("coloraxis", ColorAxis , StyleParam.SubPlotId.convert)
            ++?? ("colorscale", Colorscale , StyleParam.Colorscale.convert)
            ++? ("reversescale", ReverseScale )
            ++? ("showscale", ShowScale )
            ++? ("colorbar", ColorBar ))
