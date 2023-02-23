namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open System
open System.Runtime.InteropServices

/// The marker object determines the style of the markers representing datums in various types of plots.
type Marker() =
    inherit DynamicObj()

    /// <summary>
    /// Returns a new Marker object with the given styling.
    /// </summary>
    /// <param name="Angle">Sets the marker angle in respect to `angleref`.</param>
    /// <param name="AngleRef">Sets the reference for marker angle. With "previous", angle 0 points along the line from the previous point to this one. With "up", angle 0 points toward the top of the screen.</param>
    /// <param name="AutoColorScale">Determines whether the colorscale is a default palette (`autocolorscale: true`) or the palette determined by `marker.colorscale`. Has an effect only if in `marker.color`is set to a numerical array. In case `colorscale` is unspecified or `autocolorscale` is true, the default palette will be chosen according to whether numbers in the `color` array are all positive, all negative or mixed.</param>
    /// <param name="CAuto">Determines whether or not the color domain is computed with respect to the input data (here in `marker.color`) or the bounds set in `marker.cmin` and `marker.cmax` Has an effect only if in `marker.color`is set to a numerical array. Defaults to `false` when `marker.cmin` and `marker.cmax` are set by the user.</param>
    /// <param name="CMax">Sets the upper bound of the color domain. Has an effect only if in `marker.color`is set to a numerical array. Value should have the same units as in `marker.color` and if set, `marker.cmin` must be set as well.</param>
    /// <param name="CMid">Sets the mid-point of the color domain by scaling `marker.cmin` and/or `marker.cmax` to be equidistant to this point. Has an effect only if in `marker.color`is set to a numerical array. Value should have the same units as in `marker.color`. Has no effect when `marker.cauto` is `false`.</param>
    /// <param name="CMin">Sets the lower bound of the color domain. Has an effect only if in `marker.color`is set to a numerical array. Value should have the same units as in `marker.color` and if set, `marker.cmax` must be set as well.</param>
    /// <param name="Color">Sets the marker color. It accepts either a specific color or an array of numbers that are mapped to the colorscale relative to the max and min values of the array or relative to `marker.cmin` and `marker.cmax` if set.</param>
    /// <param name="Colors">Sets the color of each sector. If not specified, the default trace color set is used to pick the sector colors.</param>
    /// <param name="ColorAxis">Sets a reference to a shared color axis. References to these shared color axes are "coloraxis", "coloraxis2", "coloraxis3", etc. Settings for these shared color axes are set in the layout, under `layout.coloraxis`, `layout.coloraxis2`, etc. Note that multiple color scales can be linked to the same color axis.</param>
    /// <param name="ColorBar">Sets the marker's color bar.</param>
    /// <param name="Colorscale">Sets the colorscale. Has an effect only if colors is set to a numerical array. The colorscale must be an array containing arrays mapping a normalized value to an rgb, rgba, hex, hsl, hsv, or named color string. At minimum, a mapping for the lowest (0) and highest (1) values are required. For example, `[[0, 'rgb(0,0,255)'], [1, 'rgb(255,0,0)']]`. To control the bounds of the colorscale in color space, use `marker.cmin` and `marker.cmax`. Alternatively, `colorscale` may be a palette name string of the following list: Blackbody,Bluered,Blues,Cividis,Earth,Electric,Greens,Greys,Hot,Jet,Picnic,Portland,Rainbow,RdBu,Reds,Viridis,YlGnBu,YlOrRd.</param>
    /// <param name="CornerRadius">Sets the maximum rounding of corners (in px).</param>
    /// <param name="Gradient">Sets the marker's gradient</param>
    /// <param name="Outline">Sets the marker's outline.</param>
    /// <param name="Opacity">Sets the marker opacity.</param>
    /// <param name="MaxDisplayed">Sets a maximum number of points to be drawn on the graph. "0" corresponds to no limit.</param>
    /// <param name="MultiOpacity">Sets the individual marker opacity.</param>
    /// <param name="Pattern">Sets the pattern within the marker.</param>
    /// <param name="ReverseScale">Reverses the color mapping if true. Has an effect only if in `marker.color`is set to a numerical array. If true, `marker.cmin` will correspond to the last color in the array and `marker.cmax` will correspond to the first color.</param>
    /// <param name="ShowScale">Determines whether or not a colorbar is displayed for this trace. Has an effect only if in `marker.color`is set to a numerical array.</param>
    /// <param name="Size">Sets the marker's size.</param>
    /// <param name="MultiSize">Sets the individual marker's size.</param>
    /// <param name="SizeMin">Has an effect only if `marker.size` is set to a numerical array. Sets the minimum size (in px) of the rendered marker points.</param>
    /// <param name="SizeMode">Has an effect only if `marker.size` is set to a numerical array. Sets the rule for which the data in `size` is converted to pixels.</param>
    /// <param name="SizeRef">Has an effect only if `marker.size` is set to a numerical array. Sets the scale factor used to determine the rendered size of marker points. Use with `sizemin` and `sizemode`.</param>
    /// <param name="StandOff">Moves the marker away from the data point in the direction of `angle` (in px). This can be useful for example if you have another marker at this location and you want to point an arrowhead marker at it.</param>
    /// <param name="MultiStandOff">Moves the marker away from the data point in the direction of `angle` (in px). This can be useful for example if you have another marker at this location and you want to point an arrowhead marker at it.</param>
    /// <param name="Symbol">Sets the marker symbol.</param>
    /// <param name="MultiSymbol">Sets the individual marker symbols.</param>
    /// <param name="Symbol3D">Sets the marker symbol for 3d traces.</param>
    /// <param name="MultiSymbol3D">Sets the individual marker symbols for 3d traces.</param>
    /// <param name="OutlierColor">Sets the color of the outlier sample points.</param>
    /// <param name="OutlierWidth">Sets the width of the outlier sample points.</param>
    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?Angle: float,
            [<Optional; DefaultParameterValue(null)>] ?AngleRef: StyleParam.AngleRef,
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
            [<Optional; DefaultParameterValue(null)>] ?CornerRadius: int,
            [<Optional; DefaultParameterValue(null)>] ?Gradient: Gradient,
            [<Optional; DefaultParameterValue(null)>] ?Outline: Line,
            [<Optional; DefaultParameterValue(null)>] ?MaxDisplayed: int,
            [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
            [<Optional; DefaultParameterValue(null)>] ?MultiOpacity: seq<float>,
            [<Optional; DefaultParameterValue(null)>] ?Pattern: Pattern,
            [<Optional; DefaultParameterValue(null)>] ?ReverseScale: bool,
            [<Optional; DefaultParameterValue(null)>] ?ShowScale: bool,
            [<Optional; DefaultParameterValue(null)>] ?Size: int,
            [<Optional; DefaultParameterValue(null)>] ?MultiSize: seq<int>,
            [<Optional; DefaultParameterValue(null)>] ?SizeMin: int,
            [<Optional; DefaultParameterValue(null)>] ?SizeMode: StyleParam.MarkerSizeMode,
            [<Optional; DefaultParameterValue(null)>] ?SizeRef: int,
            [<Optional; DefaultParameterValue(null)>] ?StandOff: float,
            [<Optional; DefaultParameterValue(null)>] ?MultiStandOff: seq<float>,
            [<Optional; DefaultParameterValue(null)>] ?Symbol: StyleParam.MarkerSymbol,
            [<Optional; DefaultParameterValue(null)>] ?MultiSymbol: seq<StyleParam.MarkerSymbol>,
            [<Optional; DefaultParameterValue(null)>] ?Symbol3D: StyleParam.MarkerSymbol3D,
            [<Optional; DefaultParameterValue(null)>] ?MultiSymbol3D: seq<StyleParam.MarkerSymbol3D>,
            [<Optional; DefaultParameterValue(null)>] ?OutlierColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?OutlierWidth: int
        ) =
        Marker()
        |> Marker.style (
            ?Angle = Angle,
            ?AngleRef = AngleRef,
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
            ?CornerRadius = CornerRadius,
            ?Gradient = Gradient,
            ?Outline = Outline,
            ?Size = Size,
            ?MultiSize = MultiSize,
            ?Opacity = Opacity,
            ?Pattern = Pattern,
            ?MultiOpacity = MultiOpacity,
            ?Symbol = Symbol,
            ?MultiSymbol = MultiSymbol,
            ?Symbol3D = Symbol3D,
            ?MultiSymbol3D = MultiSymbol3D,
            ?OutlierColor = OutlierColor,
            ?OutlierWidth = OutlierWidth,
            ?MaxDisplayed = MaxDisplayed,
            ?ReverseScale = ReverseScale,
            ?ShowScale = ShowScale,
            ?SizeMin = SizeMin,
            ?SizeMode = SizeMode,
            ?SizeRef = SizeRef,
            ?StandOff = StandOff,
            ?MultiStandOff = MultiStandOff
        )

    /// <summary>
    /// Returns a function that applies the given styles to a Marker object.
    /// </summary>
    /// <param name="Angle">Sets the marker angle in respect to `angleref`.</param>
    /// <param name="AngleRef">Sets the reference for marker angle. With "previous", angle 0 points along the line from the previous point to this one. With "up", angle 0 points toward the top of the screen.</param>
    /// <param name="AutoColorScale">Determines whether the colorscale is a default palette (`autocolorscale: true`) or the palette determined by `marker.colorscale`. Has an effect only if in `marker.color`is set to a numerical array. In case `colorscale` is unspecified or `autocolorscale` is true, the default palette will be chosen according to whether numbers in the `color` array are all positive, all negative or mixed.</param>
    /// <param name="CAuto">Determines whether or not the color domain is computed with respect to the input data (here in `marker.color`) or the bounds set in `marker.cmin` and `marker.cmax` Has an effect only if in `marker.color`is set to a numerical array. Defaults to `false` when `marker.cmin` and `marker.cmax` are set by the user.</param>
    /// <param name="CMax">Sets the upper bound of the color domain. Has an effect only if in `marker.color`is set to a numerical array. Value should have the same units as in `marker.color` and if set, `marker.cmin` must be set as well.</param>
    /// <param name="CMid">Sets the mid-point of the color domain by scaling `marker.cmin` and/or `marker.cmax` to be equidistant to this point. Has an effect only if in `marker.color`is set to a numerical array. Value should have the same units as in `marker.color`. Has no effect when `marker.cauto` is `false`.</param>
    /// <param name="CMin">Sets the lower bound of the color domain. Has an effect only if in `marker.color`is set to a numerical array. Value should have the same units as in `marker.color` and if set, `marker.cmax` must be set as well.</param>
    /// <param name="Color">Sets the marker color. It accepts either a specific color or an array of numbers that are mapped to the colorscale relative to the max and min values of the array or relative to `marker.cmin` and `marker.cmax` if set.</param>
    /// <param name="Colors">Sets the color of each sector. If not specified, the default trace color set is used to pick the sector colors.</param>
    /// <param name="ColorAxis">Sets a reference to a shared color axis. References to these shared color axes are "coloraxis", "coloraxis2", "coloraxis3", etc. Settings for these shared color axes are set in the layout, under `layout.coloraxis`, `layout.coloraxis2`, etc. Note that multiple color scales can be linked to the same color axis.</param>
    /// <param name="ColorBar">Sets the marker's color bar.</param>
    /// <param name="Colorscale">Sets the colorscale. Has an effect only if colors is set to a numerical array. The colorscale must be an array containing arrays mapping a normalized value to an rgb, rgba, hex, hsl, hsv, or named color string. At minimum, a mapping for the lowest (0) and highest (1) values are required. For example, `[[0, 'rgb(0,0,255)'], [1, 'rgb(255,0,0)']]`. To control the bounds of the colorscale in color space, use `marker.cmin` and `marker.cmax`. Alternatively, `colorscale` may be a palette name string of the following list: Blackbody,Bluered,Blues,Cividis,Earth,Electric,Greens,Greys,Hot,Jet,Picnic,Portland,Rainbow,RdBu,Reds,Viridis,YlGnBu,YlOrRd.</param>
    /// <param name="CornerRadius">Sets the maximum rounding of corners (in px).</param>
    /// <param name="Gradient">Sets the marker's gradient</param>
    /// <param name="Outline">Sets the marker's outline.</param>
    /// <param name="Opacity">Sets the marker opacity.</param>
    /// <param name="MaxDisplayed">Sets a maximum number of points to be drawn on the graph. "0" corresponds to no limit.</param>
    /// <param name="MultiOpacity">Sets the individual marker opacity.</param>
    /// <param name="Pattern">Sets the pattern within the marker.</param>
    /// <param name="ReverseScale">Reverses the color mapping if true. Has an effect only if in `marker.color`is set to a numerical array. If true, `marker.cmin` will correspond to the last color in the array and `marker.cmax` will correspond to the first color.</param>
    /// <param name="ShowScale">Determines whether or not a colorbar is displayed for this trace. Has an effect only if in `marker.color`is set to a numerical array.</param>
    /// <param name="Size">Sets the marker's size.</param>
    /// <param name="MultiSize">Sets the individual marker's size.</param>
    /// <param name="SizeMin">Has an effect only if `marker.size` is set to a numerical array. Sets the minimum size (in px) of the rendered marker points.</param>
    /// <param name="SizeMode">Has an effect only if `marker.size` is set to a numerical array. Sets the rule for which the data in `size` is converted to pixels.</param>
    /// <param name="SizeRef">Has an effect only if `marker.size` is set to a numerical array. Sets the scale factor used to determine the rendered size of marker points. Use with `sizemin` and `sizemode`.</param>
    /// <param name="StandOff">Moves the marker away from the data point in the direction of `angle` (in px). This can be useful for example if you have another marker at this location and you want to point an arrowhead marker at it.</param>
    /// <param name="MultiStandOff">Moves the marker away from the data point in the direction of `angle` (in px). This can be useful for example if you have another marker at this location and you want to point an arrowhead marker at it.</param>
    /// <param name="Symbol">Sets the marker symbol.</param>
    /// <param name="MultiSymbol">Sets the individual marker symbols.</param>
    /// <param name="Symbol3D">Sets the marker symbol for 3d traces.</param>
    /// <param name="MultiSymbol3D">Sets the individual marker symbols for 3d traces.</param>
    /// <param name="OutlierColor">Sets the color of the outlier sample points.</param>
    /// <param name="OutlierWidth">Sets the width of the outlier sample points.</param>
    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?Angle: float,
            [<Optional; DefaultParameterValue(null)>] ?AngleRef: StyleParam.AngleRef,
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
            [<Optional; DefaultParameterValue(null)>] ?CornerRadius: int,
            [<Optional; DefaultParameterValue(null)>] ?Gradient: Gradient,
            [<Optional; DefaultParameterValue(null)>] ?Outline: Line,
            [<Optional; DefaultParameterValue(null)>] ?MaxDisplayed: int,
            [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
            [<Optional; DefaultParameterValue(null)>] ?MultiOpacity: seq<float>,
            [<Optional; DefaultParameterValue(null)>] ?Pattern: Pattern,
            [<Optional; DefaultParameterValue(null)>] ?ReverseScale: bool,
            [<Optional; DefaultParameterValue(null)>] ?ShowScale: bool,
            [<Optional; DefaultParameterValue(null)>] ?Size: int,
            [<Optional; DefaultParameterValue(null)>] ?MultiSize: seq<int>,
            [<Optional; DefaultParameterValue(null)>] ?SizeMin: int,
            [<Optional; DefaultParameterValue(null)>] ?SizeMode: StyleParam.MarkerSizeMode,
            [<Optional; DefaultParameterValue(null)>] ?SizeRef: int,
            [<Optional; DefaultParameterValue(null)>] ?StandOff: float,
            [<Optional; DefaultParameterValue(null)>] ?MultiStandOff: seq<float>,
            [<Optional; DefaultParameterValue(null)>] ?Symbol: StyleParam.MarkerSymbol,
            [<Optional; DefaultParameterValue(null)>] ?MultiSymbol: seq<StyleParam.MarkerSymbol>,
            [<Optional; DefaultParameterValue(null)>] ?Symbol3D: StyleParam.MarkerSymbol3D,
            [<Optional; DefaultParameterValue(null)>] ?MultiSymbol3D: seq<StyleParam.MarkerSymbol3D>,
            [<Optional; DefaultParameterValue(null)>] ?OutlierColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?OutlierWidth: int
        ) =
        (fun (marker: Marker) ->

            Angle |> DynObj.setValueOpt marker "angle"
            AngleRef |> DynObj.setValueOptBy marker "angleref" StyleParam.AngleRef.convert
            AutoColorScale |> DynObj.setValueOpt marker "autocolorscale"
            CAuto |> DynObj.setValueOpt marker "cauto"
            CMax |> DynObj.setValueOpt marker "cmax"
            CMid |> DynObj.setValueOpt marker "cmid"
            CMin |> DynObj.setValueOpt marker "cmin"
            Color |> DynObj.setValueOpt marker "color"
            Colors |> DynObj.setValueOpt marker "colors"
            ColorAxis |> DynObj.setValueOptBy marker "coloraxis" StyleParam.SubPlotId.convert
            ColorBar |> DynObj.setValueOpt marker "colorbar"
            Colorscale |> DynObj.setValueOptBy marker "colorscale" StyleParam.Colorscale.convert
            CornerRadius |> DynObj.setValueOpt marker "cornerradius"
            Gradient |> DynObj.setValueOpt marker "gradient"
            Outline |> DynObj.setValueOpt marker "line"
            (Size, MultiSize) |> DynObj.setSingleOrMultiOpt marker "size"
            (Opacity, MultiOpacity) |> DynObj.setSingleOrMultiOpt marker "opacity"
            Pattern |> DynObj.setValueOpt marker "pattern"
            (Symbol, MultiSymbol) |> DynObj.setSingleOrMultiOptBy marker "symbol" StyleParam.MarkerSymbol.convert
            (Symbol3D, MultiSymbol3D) |> DynObj.setSingleOrMultiOptBy marker "symbol" StyleParam.MarkerSymbol3D.convert
            OutlierColor |> DynObj.setValueOpt marker "outliercolor"
            OutlierWidth |> DynObj.setValueOpt marker "outlierwidth"
            MaxDisplayed |> DynObj.setValueOpt marker "maxdisplayed"
            ReverseScale |> DynObj.setValueOpt marker "reversescale"
            ShowScale |> DynObj.setValueOpt marker "showscale"
            SizeMin |> DynObj.setValueOpt marker "sizemin"
            SizeMode |> DynObj.setValueOpt marker "sizemode"
            SizeRef |> DynObj.setValueOpt marker "sizeref"
            (StandOff, MultiStandOff) |> DynObj.setSingleOrMultiOpt marker "standoff"

            marker)
