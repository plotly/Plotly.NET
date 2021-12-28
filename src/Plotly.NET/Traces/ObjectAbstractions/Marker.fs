namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open DynamicObj.Operators
open System
open System.Runtime.InteropServices

/// Marker type inherits from dynamic object
type Marker() =
    inherit ImmutableDynamicObj()

    /// Initialized Marker object
    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?AutoColorScale: bool,
            [<Optional; DefaultParameterValue(null)>] ?CAuto: bool,
            [<Optional; DefaultParameterValue(null)>] ?CMax: float,
            [<Optional; DefaultParameterValue(null)>] ?CMid: float,
            [<Optional; DefaultParameterValue(null)>] ?CMin: float,
            [<Optional; DefaultParameterValue(null)>] ?Color: Color,
            [<Optional; DefaultParameterValue(null)>] ?Colors: seq<Color>,
            [<Optional; DefaultParameterValue(null)>] ?ColorAxis: StyleParam.SubPlotId,
            [<Optional; DefaultParameterValue(null)>] ?ColorBar: ColorBar,
            [<Optional; DefaultParameterValue(null)>] ?Colorscale: StyleParam.Colorscale,
            [<Optional; DefaultParameterValue(null)>] ?Gradient: Gradient,
            [<Optional; DefaultParameterValue(null)>] ?Outline: Line,
            [<Optional; DefaultParameterValue(null)>] ?Size: int,
            [<Optional; DefaultParameterValue(null)>] ?MultiSize: seq<int>,
            [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
            [<Optional; DefaultParameterValue(null)>] ?Pattern: Pattern,
            [<Optional; DefaultParameterValue(null)>] ?MultiOpacity: seq<float>,
            [<Optional; DefaultParameterValue(null)>] ?Symbol: StyleParam.MarkerSymbol,
            [<Optional; DefaultParameterValue(null)>] ?MultiSymbol: seq<StyleParam.MarkerSymbol>,
            [<Optional; DefaultParameterValue(null)>] ?OutlierColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?OutlierWidth: int,
            [<Optional; DefaultParameterValue(null)>] ?Maxdisplayed: int,
            [<Optional; DefaultParameterValue(null)>] ?ReverseScale: bool,
            [<Optional; DefaultParameterValue(null)>] ?ShowScale: bool,
            [<Optional; DefaultParameterValue(null)>] ?SizeMin: int,
            [<Optional; DefaultParameterValue(null)>] ?SizeMode: StyleParam.MarkerSizeMode,
            [<Optional; DefaultParameterValue(null)>] ?SizeRef: int
        ) =
        Marker()
        |> Marker.style (
            ?AutoColorScale = AutoColorScale,
            ?CAuto = CAuto,
            ?CMax = CMax,
            ?CMid = CMid,
            ?CMin = CMin,
            ?Color = Color,
            ?Colors = Colors,
            ?ColorAxis = ColorAxis,
            ?ColorBar = ColorBar,
            ?Colorscale = Colorscale,
            ?Gradient = Gradient,
            ?Outline = Outline,
            ?Size = Size,
            ?MultiSize = MultiSize,
            ?Opacity = Opacity,
            ?Pattern = Pattern,
            ?MultiOpacity = MultiOpacity,
            ?Symbol = Symbol,
            ?MultiSymbol = MultiSymbol,
            ?OutlierColor = OutlierColor,
            ?OutlierWidth = OutlierWidth,
            ?Maxdisplayed = Maxdisplayed,
            ?ReverseScale = ReverseScale,
            ?ShowScale = ShowScale,
            ?SizeMin = SizeMin,
            ?SizeMode = SizeMode,
            ?SizeRef = SizeRef
        )

    // Applies the styles to Marker()
    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?AutoColorScale: bool,
            [<Optional; DefaultParameterValue(null)>] ?CAuto: bool,
            [<Optional; DefaultParameterValue(null)>] ?CMax: float,
            [<Optional; DefaultParameterValue(null)>] ?CMid: float,
            [<Optional; DefaultParameterValue(null)>] ?CMin: float,
            [<Optional; DefaultParameterValue(null)>] ?Color: Color,
            [<Optional; DefaultParameterValue(null)>] ?Colors: seq<Color>,
            [<Optional; DefaultParameterValue(null)>] ?ColorAxis: StyleParam.SubPlotId,
            [<Optional; DefaultParameterValue(null)>] ?ColorBar: ColorBar,
            [<Optional; DefaultParameterValue(null)>] ?Colorscale: StyleParam.Colorscale,
            [<Optional; DefaultParameterValue(null)>] ?Gradient: Gradient,
            [<Optional; DefaultParameterValue(null)>] ?Outline: Line,
            [<Optional; DefaultParameterValue(null)>] ?Size: int,
            [<Optional; DefaultParameterValue(null)>] ?MultiSize: seq<int>,
            [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
            [<Optional; DefaultParameterValue(null)>] ?MultiOpacity: seq<float>,
            [<Optional; DefaultParameterValue(null)>] ?Pattern: Pattern,
            [<Optional; DefaultParameterValue(null)>] ?Symbol: StyleParam.MarkerSymbol,
            [<Optional; DefaultParameterValue(null)>] ?MultiSymbol: seq<StyleParam.MarkerSymbol>,
            [<Optional; DefaultParameterValue(null)>] ?Symbol3D: StyleParam.MarkerSymbol3D,
            [<Optional; DefaultParameterValue(null)>] ?MultiSymbol3D: seq<StyleParam.MarkerSymbol3D>,
            [<Optional; DefaultParameterValue(null)>] ?OutlierColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?OutlierWidth: int,
            [<Optional; DefaultParameterValue(null)>] ?Maxdisplayed: int,
            [<Optional; DefaultParameterValue(null)>] ?ReverseScale: bool,
            [<Optional; DefaultParameterValue(null)>] ?ShowScale: bool,
            [<Optional; DefaultParameterValue(null)>] ?SizeMin: int,
            [<Optional; DefaultParameterValue(null)>] ?SizeMode: StyleParam.MarkerSizeMode,
            [<Optional; DefaultParameterValue(null)>] ?SizeRef: int
        ) =
        (fun (marker: Marker) ->

            ++? ("autocolorscale", AutoColorScale )
            ++? ("cauto", CAuto )
            ++? ("cmax", CMax )
            ++? ("cmid", CMid )
            ++? ("cmin", CMin )
            ++? ("color", Color )
            ++? ("colors", Colors )
            ++?? ("coloraxis", ColorAxis , StyleParam.SubPlotId.convert)
            ++? ("colorbar", ColorBar )
            ++?? ("colorscale", Colorscale , StyleParam.Colorscale.convert)
            ++? ("gradient", Gradient )
            ++? ("line", Outline )
            (Size, MultiSize) |> DynObj.setSingleOrMultiOpt marker "size"
            (Opacity, MultiOpacity) |> DynObj.setSingleOrMultiOpt marker "opacity"
            ++? ("pattern", Pattern )
            (Symbol, MultiSymbol) |> DynObj.setSingleOrMultiOptBy marker "symbol" StyleParam.MarkerSymbol.convert
            (Symbol3D, MultiSymbol3D) |> DynObj.setSingleOrMultiOptBy marker "symbol" StyleParam.MarkerSymbol3D.convert

            marker
            ++? ("outliercolor", OutlierColor )
            ++? ("outlierwidth", OutlierWidth )
            ++? ("maxdisplayed", Maxdisplayed )
            ++? ("reversescale", ReverseScale )
            ++? ("showscale", ShowScale )
            ++? ("sizemin", SizeMin )
            ++? ("sizemode", SizeMode )
            ++? ("sizeref", SizeRef ))
