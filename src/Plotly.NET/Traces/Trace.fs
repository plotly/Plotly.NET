namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open DynamicObj
open System
open System.Runtime.InteropServices

/// Trace type inherits from dynamic object
type Trace(traceTypeName: string) =
    inherit DynamicObj()
    //interface ITrace with
    // Implictit ITrace
    member val ``type`` = traceTypeName with get, set

    static member tryGetTypedMember<'T> (propName: string) (trace: Trace) = trace.TryGetTypedValue<'T>(propName)

//-------------------------------------------------------------------------------------------------------------------------------------------------
/// Functions provide the styling of the Chart objects
/// These functions are used internally to style traces of Chart objects. Users are usually pointed
/// to the API layer provided by the `Chart` module/object
type TraceStyle() =

    /// <summary>
    /// Sets trace information on the given trace.
    /// </summary>
    /// <param name="Name">Sets the name of the chart's trace(s). When the chart is a multichart (it contains multiple traces), the name is suffixed by '_%i' where %i is the index of the trace.</param>
    /// <param name="Visible">Wether or not the chart's traces are visible</param>
    /// <param name="ShowLegend">Determines whether or not item(s) corresponding to this chart's trace(s) is/are shown in the legend.</param>
    /// <param name="LegendRank">Sets the legend rank for the chart's trace(s). Items and groups with smaller ranks are presented on top/left side while with `"reversed" `legend.traceorder` they are on bottom/right side. The default legendrank is 1000, so that you can use ranks less than 1000 to place certain items before all unranked items, and ranks greater than 1000 to go after all unranked items.</param>
    /// <param name="LegendGroup">Sets the legend group for the chart's trace(s). Traces part of the same legend group hide/show at the same time when toggling legend items.</param>
    /// <param name="LegendGroupTitle">Sets the title for the chart's trace legend group </param>
    static member TraceInfo
        (
            [<Optional; DefaultParameterValue(null)>] ?Name: string,
            [<Optional; DefaultParameterValue(null)>] ?Visible: StyleParam.Visible,
            [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
            [<Optional; DefaultParameterValue(null)>] ?LegendRank: int,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroup: string,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroupTitle: Title
        ) =
        (fun (trace: ('T :> Trace)) ->

            Name |> DynObj.setValueOpt trace "name"
            Visible |> DynObj.setValueOptBy trace "visible" StyleParam.Visible.toObject
            ShowLegend |> DynObj.setValueOpt trace "showlegend"
            LegendRank |> DynObj.setValueOpt trace "legendrank"
            LegendGroup |> DynObj.setValueOpt trace "legendgroup"
            LegendGroupTitle |> DynObj.setValueOpt trace "legendgrouptitle"

            trace)

    /// Sets selection of data points on a Trace object.
    static member SetSelection
        (
            [<Optional; DefaultParameterValue(null)>] ?Selectedpoints,
            [<Optional; DefaultParameterValue(null)>] ?Selected,
            [<Optional; DefaultParameterValue(null)>] ?UnSelected
        ) =
        (fun (trace: ('T :> Trace)) ->

            Selectedpoints |> DynObj.setValueOpt trace "Selectedpoints"
            Selected |> DynObj.setValueOpt trace "Selected"
            UnSelected |> DynObj.setValueOpt trace "UnSelected"

            trace)


    /// Sets the given text label styles on a Trace object.
    static member TextLabel
        (
            [<Optional; DefaultParameterValue(null)>] ?Text: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Textposition: StyleParam.TextPosition,
            [<Optional; DefaultParameterValue(null)>] ?Textfont: Font,
            [<Optional; DefaultParameterValue(null)>] ?Textsrc: string,
            [<Optional; DefaultParameterValue(null)>] ?Textpositionsrc: string
        ) =
        (fun (trace: ('T :> Trace)) ->
            Text |> DynObj.setValueOpt trace "text"
            Textposition |> DynObj.setValueOptBy trace "textposition" StyleParam.TextPosition.toString
            Textsrc |> DynObj.setValueOpt trace "textsrc"
            Textpositionsrc |> DynObj.setValueOpt trace "textpositionsrc"
            Textfont |> DynObj.setValueOpt trace "textfont"

            // out ->
            trace)


    /// Sets the given line on a Trace object.
    static member SetLine(line: Line) =
        (fun (trace: ('T :> Trace)) ->

            trace.SetValue("line", line)
            trace)


    /// Sets the given Line styles on the line property of a Trace object
    static member Line
        (
            [<Optional; DefaultParameterValue(null)>] ?Width: float,
            [<Optional; DefaultParameterValue(null)>] ?Color: Color,
            [<Optional; DefaultParameterValue(null)>] ?Shape: StyleParam.Shape,
            [<Optional; DefaultParameterValue(null)>] ?Dash: StyleParam.DrawingStyle,
            [<Optional; DefaultParameterValue(null)>] ?Smoothing: float,
            [<Optional; DefaultParameterValue(null)>] ?Colorscale: StyleParam.Colorscale
        ) =
        (fun (trace: ('T :> Trace)) ->
            let line =
                match (trace.TryGetValue "line") with
                | Some line -> line :?> Line
                | None -> Line.init ()
                |> Line.style (
                    ?Width = Width,
                    ?Color = Color,
                    ?Shape = Shape,
                    ?Dash = Dash,
                    ?Smoothing = Smoothing,
                    ?Colorscale = Colorscale
                )

            trace.SetValue("line", line)
            trace)


    /// Sets the given marker on a Trace object.
    static member SetMarker(marker: Marker) =
        (fun (trace: ('T :> Trace)) ->

            trace.SetValue("marker", marker)
            trace)

    /// <summary>
    /// Applies the given styles to the trace's marker object.
    /// </summary>
    /// <param name="AutoColorScale">Determines whether the colorscale is a default palette (`autocolorscale: true`) or the palette determined by `marker.colorscale`. Has an effect only if in `marker.color`is set to a numerical array. In case `colorscale` is unspecified or `autocolorscale` is true, the default palette will be chosen according to whether numbers in the `color` array are all positive, all negative or mixed.</param>
    /// <param name="CAuto">Determines whether or not the color domain is computed with respect to the input data (here in `marker.color`) or the bounds set in `marker.cmin` and `marker.cmax` Has an effect only if in `marker.color`is set to a numerical array. Defaults to `false` when `marker.cmin` and `marker.cmax` are set by the user.</param>
    /// <param name="CMax">Sets the upper bound of the color domain. Has an effect only if in `marker.color`is set to a numerical array. Value should have the same units as in `marker.color` and if set, `marker.cmin` must be set as well.</param>
    /// <param name="CMid">Sets the mid-point of the color domain by scaling `marker.cmin` and/or `marker.cmax` to be equidistant to this point. Has an effect only if in `marker.color`is set to a numerical array. Value should have the same units as in `marker.color`. Has no effect when `marker.cauto` is `false`.</param>
    /// <param name="CMin">Sets the lower bound of the color domain. Has an effect only if in `marker.color`is set to a numerical array. Value should have the same units as in `marker.color` and if set, `marker.cmax` must be set as well.</param>
    /// <param name="Color">Sets the marker color. It accepts either a specific color or an array of numbers that are mapped to the colorscale relative to the max and min values of the array or relative to `marker.cmin` and `marker.cmax` if set.</param>
    /// <param name="Colors">Sets the color of each sector. If not specified, the default trace color set is used to pick the sector colors.</param>
    /// <param name="ColorAxis">Sets a reference to a shared color axis. References to these shared color axes are "coloraxis", "coloraxis2", "coloraxis3", etc. Settings for these shared color axes are set in the layout, under `layout.coloraxis`, `layout.coloraxis2`, etc. Note that multiple color scales can be linked to the same color axis.</param>
    /// <param name="ColorBar">Sets the marker's color bar.</param>
    /// <param name="Colorscale"></param>
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
    /// <param name="Symbol">Sets the marker symbol.</param>
    /// <param name="MultiSymbol">Sets the individual marker symbols.</param>
    /// <param name="Symbol3D">Sets the marker symbol for 3d traces.</param>
    /// <param name="MultiSymbol3D">Sets the individual marker symbols for 3d traces.</param>
    /// <param name="OutlierColor">Sets the color of the outlier sample points.</param>
    /// <param name="OutlierWidth">Sets the width of the outlier sample points.</param>
    static member Marker
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
            [<Optional; DefaultParameterValue(null)>] ?Symbol: StyleParam.MarkerSymbol,
            [<Optional; DefaultParameterValue(null)>] ?MultiSymbol: seq<StyleParam.MarkerSymbol>,
            [<Optional; DefaultParameterValue(null)>] ?Symbol3D: StyleParam.MarkerSymbol3D,
            [<Optional; DefaultParameterValue(null)>] ?MultiSymbol3D: seq<StyleParam.MarkerSymbol3D>,
            [<Optional; DefaultParameterValue(null)>] ?OutlierColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?OutlierWidth: int
        ) =
        (fun (trace: ('T :> Trace)) ->
            let marker =
                trace
                |> Trace.tryGetTypedMember<Marker> "marker"
                |> Option.defaultValue (Marker.init ())
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
                    ?Symbol3D = Symbol3D,
                    ?MultiSymbol3D = MultiSymbol3D,
                    ?OutlierColor = OutlierColor,
                    ?OutlierWidth = OutlierWidth,
                    ?MaxDisplayed = MaxDisplayed,
                    ?ReverseScale = ReverseScale,
                    ?ShowScale = ShowScale,
                    ?SizeMin = SizeMin,
                    ?SizeMode = SizeMode,
                    ?SizeRef = SizeRef
                )

            trace.SetValue("marker", marker)
            trace

            )

    /// Sets the given color axis anchor on a Trace object. (determines which colorscale it uses)
    static member setColorAxisAnchor(?ColorAxisId: int) =
        let id =
            ColorAxisId |> Option.map StyleParam.SubPlotId.ColorAxis

        (fun (trace: ('T :> Trace)) ->
            id |> DynObj.setValueOptBy trace "coloraxis" StyleParam.SubPlotId.convert
            trace)

    /// Sets the given domain on a Trace object.
    static member SetDomain(domain: Domain) =
        (fun (trace: ('T :> Trace)) ->

            trace.SetValue("domain", domain)
            trace)

    /// Sets the given Domain styles on the domain property of a Trace object
    static member Domain
        (
            [<Optional; DefaultParameterValue(null)>] ?X: StyleParam.Range,
            [<Optional; DefaultParameterValue(null)>] ?Y: StyleParam.Range,
            [<Optional; DefaultParameterValue(null)>] ?Row: int,
            [<Optional; DefaultParameterValue(null)>] ?Column: int
        ) =
        (fun (trace: ('T :> Trace)) ->
            let domain =
                match (trace.TryGetValue "domain") with
                | Some m -> m :?> Domain
                | None -> Domain()

                |> Domain.style (?X = X, ?Y = Y, ?Row = Row, ?Column = Column)

            trace.SetValue("domain", domain)
            trace)

    // Sets the X-Error an a Trace object.
    static member SetErrorX(error: Error) =
        (fun (trace: ('T :> Trace)) ->

            trace.SetValue("error_x", error)
            trace)

    // Sets Y-Error() to TraceObjects
    static member SetErrorY(error: Error) =
        (fun (trace: ('T :> Trace)) ->

            trace.SetValue("error_y", error)
            trace)

    // Sets Z-Error() to TraceObjects
    static member SetErrorZ(error: Error) =
        (fun (trace: ('T :> Trace)) ->

            trace.SetValue("error_z", error)
            trace)

    // Sets Stackgroup() to TraceObjects
    static member SetStackGroup(stackgroup: string) =
        (fun (trace: ('T :> Trace)) ->

            trace.SetValue("stackgroup", stackgroup)
            trace)
