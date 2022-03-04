namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects

open DynamicObj
open System
open System.IO

open GenericChart
open System.Runtime.InteropServices

/// Provides a set of static methods for creating and styling charts.
type Chart =

    //==============================================================================================================
    //================================================ Core methods ================================================
    //==============================================================================================================

    /// <summary>
    /// Saves the given Chart as html file at the given path (.html file extension is added if not present). 
    /// Optionally opens the generated file in the browser.
    /// </summary>
    /// <param name="path">The path to save the chart html at.</param>
    /// <param name="OpenInBrowser">Wether or not to open the generated file in the browser (default: false)</param>
    [<CompiledName("SaveHtml")>]
    static member saveHtml(path: string, [<Optional; DefaultParameterValue(null)>] ?OpenInBrowser: bool) =
        fun (ch: GenericChart) ->
            let show = defaultArg OpenInBrowser false

            let html = GenericChart.toEmbeddedHTML ch

            let file =
                if path.EndsWith(".html") then
                    path
                else
                    $"{path}.html"

            File.WriteAllText(file, html)
            if show then file |> openOsSpecificFile

    /// <summary>
    /// Saves the given chart as a temporary html file and opens it in the browser.
    /// </summary>
    /// <param name="ch">The chart to show in the browser</param>
    [<CompiledName("Show")>]
    static member show(ch: GenericChart) =
        let guid = Guid.NewGuid().ToString()
        let tempPath = Path.GetTempPath()
        let file = sprintf "%s.html" guid
        let path = Path.Combine(tempPath, file)
        ch |> Chart.saveHtml (path, true)

    /// <summary>
    /// Saves the given chart as a temporary html file containing a static image of the chart and opens it in the browser.
    ///
    /// IMPORTANT: this is not the same as static image generation. The file still needs to be opened in the browser to generate the image, as it is done via a js script in the html.
    /// 
    /// For real programmatic static image export use Plotly.NET.ImageExport (https://www.nuget.org/packages/Plotly.NET.ImageExport/)
    ///
    /// This yields basically the same results as using `StaticPlot = true` for the chart's config.
    /// </summary>
    /// <param name="format">The image format for the static chart</param>
    /// <param name="ch">The chart to show in the browser</param>
    [<Obsolete("This function will be dropped in the 2.0 release. It is recommended to either create static plots or use Plotly.NET.ImageExport instead.")>]
    [<CompiledName("ShowAsImage")>]
    static member showAsImage (format: StyleParam.ImageFormat) (ch: GenericChart) =
        let guid = Guid.NewGuid().ToString()
        let tempPath = Path.GetTempPath()
        let file = sprintf "%s.html" guid
        let path = Path.Combine(tempPath, file)

        let html =
            ch
            |> Chart.withAdditionalHeadTags [ """<script src="https://unpkg.com/@plotly/d3@3.8.0/d3.js"></script>""" ]
            |> GenericChart.toEmbeddedImage format

        File.WriteAllText(path, html)
        path |> openOsSpecificFile

    // #######################
    /// Create a combined chart with the given charts merged
    [<CompiledName("Combine")>]
    static member combine(gCharts: seq<GenericChart>) = GenericChart.combine gCharts

    //==============================================================================================================
    //============================================= Unspecific charts ==============================================
    //==============================================================================================================

    /// <summary>Creates a chart that is completely invisible when rendered. The Chart object however is NOT empty! Combining this chart with other charts will have unforseen consequences (it has for example invisible axes that can override other axes if used in Chart.Combine)</summary>
    static member Invisible() =
        let hiddenAxis () =
            LinearAxis.init (ShowGrid = false, ShowLine = false, ShowTickLabels = false, ZeroLine = false)

        let trace = Trace2D.initScatter (id)
        trace.Remove("type") |> ignore

        GenericChart.ofTraceObject false trace
        |> GenericChart.mapLayout
            (fun l ->
                l
                |> Layout.setLinearAxis (StyleParam.SubPlotId.XAxis 1, hiddenAxis ())
                |> Layout.setLinearAxis (StyleParam.SubPlotId.YAxis 1, hiddenAxis ()))

    //==============================================================================================================
    //======================================== General Trace object styling ========================================
    //==============================================================================================================

    /// <summary>
    /// Sets trace information on the given chart.
    /// </summary>
    /// <param name="Name">Sets the name of the chart's trace(s). When the chart is a multichart (it contains multiple traces), the name is suffixed by '_%i' where %i is the index of the trace.</param>
    /// <param name="Visible">Wether or not the chart's traces are visible</param>
    /// <param name="ShowLegend">Determines whether or not item(s) corresponding to this chart's trace(s) is/are shown in the legend.</param>
    /// <param name="LegendRank">Sets the legend rank for the chart's trace(s). Items and groups with smaller ranks are presented on top/left side while with `"reversed" `legend.traceorder` they are on bottom/right side. The default legendrank is 1000, so that you can use ranks less than 1000 to place certain items before all unranked items, and ranks greater than 1000 to go after all unranked items.</param>
    /// <param name="LegendGroup">Sets the legend group for the chart's trace(s). Traces part of the same legend group hide/show at the same time when toggling legend items.</param>
    /// <param name="LegendGroupTitle">Sets the title for the chart's trace legend group </param>
    [<CompiledName("WithTraceInfo")>]
    static member withTraceInfo
        (
            [<Optional; DefaultParameterValue(null)>] ?Name: string,
            [<Optional; DefaultParameterValue(null)>] ?Visible: StyleParam.Visible,
            [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
            [<Optional; DefaultParameterValue(null)>] ?LegendRank: int,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroup: string,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroupTitle: Title
        ) =
        fun (ch: GenericChart) ->
            ch
            |> mapiTrace
                (fun i trace ->
                    let naming i name =
                        name |> Option.map (fun v -> if i = 0 then v else sprintf "%s_%i" v i)

                    trace
                    |> TraceStyle.TraceInfo(
                        ?Name = (naming i Name),
                        ?Visible = Visible,
                        ?ShowLegend = ShowLegend,
                        ?LegendRank = LegendRank,
                        ?LegendGroup = LegendGroup,
                        ?LegendGroupTitle = LegendGroupTitle

                    ))

    /// <summary>
    /// Sets the axis anchor ids for the chart's cartesian and/or carpet trace(s).
    ///
    /// If the traces are not of these types, nothing will be set and a warning message will be displayed.
    /// </summary>
    /// <param name="X">The new x axis anchor id for the chart's cartesian and/or carpet trace(s)</param>
    /// <param name="Y">The new x axis anchor id for the chart's cartesian and/or carpet trace(s)</param>
    [<CompiledName("WithAxisAnchor")>]
    static member withAxisAnchor
        (
            [<Optional; DefaultParameterValue(null)>] ?X,
            [<Optional; DefaultParameterValue(null)>] ?Y
        ) =
        let idx =
            X |> Option.map StyleParam.LinearAxisId.X

        let idy =
            Y |> Option.map StyleParam.LinearAxisId.Y

        fun (ch: GenericChart) ->
            ch
            |> mapTrace
                (fun trace ->
                    match trace with
                    | :? Trace2D as trace -> trace |> Trace2DStyle.SetAxisAnchor(?X = idx, ?Y = idy) :> Trace
                    | :? TraceCarpet as trace when trace.``type`` = "carpet" ->
                        trace |> TraceCarpetStyle.SetAxisAnchor(?X = idx, ?Y = idy) :> Trace
                    | _ ->
                        printfn "the input was not a 2D cartesian or carpet trace. no axis anchors set."
                        trace)

    /// <summary>
    /// Sets the color axis id for the chart's trace(s).
    /// </summary>
    /// <param name="id">The new color axis id for the chart's trace(s)</param>
    [<CompiledName("WithColorAxisAnchor")>]
    static member withColorAxisAnchor(id: int) =
        fun (ch: GenericChart) -> ch |> mapTrace (Trace.setColorAxisAnchor id)

    /// <summary>
    /// Sets the marker for the chart's trace(s).
    /// </summary>
    /// <param name="marker">The new marker for the chart's trace(s)</param>
    /// <param name="Combine">Wether or not to combine the objects if there is already a marker (default is false)</param>
    [<CompiledName("SetMarker")>]
    static member setMarker(marker: Marker, ?Combine: bool) =
        let combine = defaultArg Combine false

        (fun (ch: GenericChart) ->
            if combine then
                ch |> GenericChart.mapTrace (Trace.updateMarker marker)
            else
                ch |> GenericChart.mapTrace (Trace.setMarker marker))

    /// <summary>
    /// Sets the marker for the chart's trace(s).
    ///
    /// If there is already a marker set, the objects are combined.
    /// </summary>
    /// <param name="marker">The new marker for the chart's trace(s)</param>
    [<CompiledName("WithMarker")>]
    static member withMarker(marker: Marker) =
        (fun (ch: GenericChart) -> ch |> Chart.setMarker (marker, true))

    /// <summary>
    /// Applies the given styles to the marker object(s) of the chart's trace(s). Overwrites attributes with the same name that are already set.
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
    [<CompiledName("WithMarkerStyle")>]
    static member withMarkerStyle
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
        fun (ch: GenericChart) ->
            ch
            |> mapTrace (
                TraceStyle.Marker(
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
            )

    /// <summary>
    /// Sets the line for the chart's trace(s).
    /// </summary>
    /// <param name="line">The new Line for the chart's trace(s)</param>
    /// <param name="Combine">Wether or not to combine the objects if there is already a Line (default is false)</param>
    [<CompiledName("SetLine")>]
    static member setLine(line: Line, ?Combine: bool) =
        let combine = defaultArg Combine false

        (fun (ch: GenericChart) ->
            if combine then
                ch |> GenericChart.mapTrace (Trace.updateLine line)
            else
                ch |> GenericChart.mapTrace (Trace.setLine line))

    /// <summary>
    /// Sets the line for the chart's trace(s).
    ///
    /// If there is already a Line set, the objects are combined.
    /// </summary>
    /// <param name="line">The new line for the chart's trace(s)</param>
    [<CompiledName("WithLine")>]
    static member withLine(line: Line) =
        (fun (ch: GenericChart) -> ch |> Chart.setLine (line, true))

    /// <summary>
    /// Applies the given styles to the line object(s) of the chart's trace(s). Overwrites attributes with the same name that are already set.
    /// </summary>
    /// <param name="AutoColorScale">Determines whether the colorscale is a default palette (`autocolorscale: true`) or the palette determined by `line.colorscale`. Has an effect only if in `line.color`is set to a numerical array. In case `colorscale` is unspecified or `autocolorscale` is true, the default palette will be chosen according to whether numbers in the `color` array are all positive, all negative or mixed.</param>
    /// <param name="CAuto">Determines whether or not the color domain is computed with respect to the input data (here in `line.color`) or the bounds set in `line.cmin` and `line.cmax` Has an effect only if in `line.color`is set to a numerical array. Defaults to `false` when `line.cmin` and `line.cmax` are set by the user.</param>
    /// <param name="CMax">Sets the upper bound of the color domain. Has an effect only if in `line.color`is set to a numerical array. Value should have the same units as in `line.color` and if set, `line.cmin` must be set as well.</param>
    /// <param name="CMid">Sets the mid-point of the color domain by scaling `line.cmin` and/or `line.cmax` to be equidistant to this point. Has an effect only if in `line.color`is set to a numerical array. Value should have the same units as in `line.color`. Has no effect when `line.cauto` is `false`.</param>
    /// <param name="CMin">Sets the lower bound of the color domain. Has an effect only if in `line.color`is set to a numerical array. Value should have the same units as in `line.color` and if set, `line.cmax` must be set as well.</param>
    /// <param name="Color">Sets the line color.</param>
    /// <param name="ColorAxis">Sets a reference to a shared color axis. References to these shared color axes are "coloraxis", "coloraxis2", "coloraxis3", etc. Settings for these shared color axes are set in the layout, under `layout.coloraxis`, `layout.coloraxis2`, etc. Note that multiple color scales can be linked to the same color axis.</param>
    /// <param name="Colorscale">Sets the line colorscale</param>
    /// <param name="ReverseScale">Reverses the color mapping if true.</param>
    /// <param name="ShowScale">Wether or not to show the color bar</param>
    /// <param name="ColorBar">Sets the colorbar.</param>
    /// <param name="Dash">Sets the dash style of lines. Set to a dash type string ("solid", "dot", "dash", "longdash", "dashdot", or "longdashdot") or a dash length list in px (eg "5px,10px,2px,2px").</param>
    /// <param name="Shape">Determines the line shape. With "spline" the lines are drawn using spline interpolation. The other available values correspond to step-wise line shapes.</param>
    /// <param name="Simplify">Simplifies lines by removing nearly-collinear points. When transitioning lines, it may be desirable to disable this so that the number of points along the resulting SVG path is unaffected.</param>
    /// <param name="Smoothing">Has an effect only if `shape` is set to "spline" Sets the amount of smoothing. "0" corresponds to no smoothing (equivalent to a "linear" shape).</param>
    /// <param name="Width">Sets the line width (in px).</param>
    /// <param name="MultiWidth">Sets the individual line width (in px).</param>
    /// <param name="OutlierColor">Sets the color of the outline of outliers</param>
    /// <param name="OutlierWidth">Sets the width of the outline of outliers</param>
    [<CompiledName("WithLineStyle")>]
    static member withLineStyle
        (
            [<Optional; DefaultParameterValue(null)>] ?AutoColorScale: bool,
            [<Optional; DefaultParameterValue(null)>] ?CAuto: bool,
            [<Optional; DefaultParameterValue(null)>] ?CMax: float,
            [<Optional; DefaultParameterValue(null)>] ?CMid: float,
            [<Optional; DefaultParameterValue(null)>] ?CMin: float,
            [<Optional; DefaultParameterValue(null)>] ?Color: Color,
            [<Optional; DefaultParameterValue(null)>] ?ColorAxis: StyleParam.SubPlotId,
            [<Optional; DefaultParameterValue(null)>] ?Colorscale: StyleParam.Colorscale,
            [<Optional; DefaultParameterValue(null)>] ?ReverseScale: bool,
            [<Optional; DefaultParameterValue(null)>] ?ShowScale: bool,
            [<Optional; DefaultParameterValue(null)>] ?ColorBar: ColorBar,
            [<Optional; DefaultParameterValue(null)>] ?Dash: StyleParam.DrawingStyle,
            [<Optional; DefaultParameterValue(null)>] ?Shape: StyleParam.Shape,
            [<Optional; DefaultParameterValue(null)>] ?Simplify: bool,
            [<Optional; DefaultParameterValue(null)>] ?Smoothing: float,
            [<Optional; DefaultParameterValue(null)>] ?Width: float,
            [<Optional; DefaultParameterValue(null)>] ?MultiWidth: seq<float>,
            [<Optional; DefaultParameterValue(null)>] ?OutlierColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?OutlierWidth: float
        ) =
        fun (ch: GenericChart) ->
            ch
            |> mapTrace (
                TraceStyle.Line(
                    ?AutoColorScale = AutoColorScale,
                    ?CAuto = CAuto,
                    ?CMax = CMax,
                    ?CMid = CMid,
                    ?CMin = CMin,
                    ?Color = Color,
                    ?ColorAxis = ColorAxis,
                    ?Colorscale = Colorscale,
                    ?ReverseScale = ReverseScale,
                    ?ShowScale = ShowScale,
                    ?ColorBar = ColorBar,
                    ?Dash = Dash,
                    ?Shape = Shape,
                    ?Simplify = Simplify,
                    ?Smoothing = Smoothing,
                    ?Width = Width,
                    ?MultiWidth = MultiWidth,
                    ?OutlierColor = OutlierColor,
                    ?OutlierWidth = OutlierWidth
                )
            )

    /// <summary>
    /// Sets the error for the x dimension for the chart's trace(s).
    /// </summary>
    /// <param name="xError">The new Error in the x dimension for the chart's trace(s)</param>
    /// <param name="Combine">Wether or not to combine the objects if there is already an Error object set (default is false)</param>
    [<CompiledName("SetXError")>]
    static member setXError(xError: Error, ?Combine: bool) =
        let combine = defaultArg Combine false

        (fun (ch: GenericChart) ->
            if combine then
                ch |> GenericChart.mapTrace (Trace.updateXError xError)
            else
                ch |> GenericChart.mapTrace (Trace.setXError xError))

    /// <summary>
    /// Sets the error in the x dimension for the chart's trace(s).
    ///
    /// If there is already an error set, the objects are combined.
    /// </summary>
    /// <param name="xError">The new error for the chart's trace(s)</param>
    [<CompiledName("WithXError")>]
    static member withXError(xError: Error) =
        (fun (ch: GenericChart) -> ch |> Chart.setXError (xError, true))

    /// <summary>
    /// Applies the given styles to the error object(s) in the x dimension of the chart's trace(s). Overwrites attributes with the same name that are already set.
    /// </summary>
    /// <param name ="Visible">Determines whether or not this set of error bars is visible.</param>
    /// <param name ="Type">Determines the rule used to generate the error bars. If "constant`, the bar lengths are of a constant value. Set this constant in `value`. If "percent", the bar lengths correspond to a percentage of underlying data. Set this percentage in `value`. If "sqrt", the bar lengths correspond to the square of the underlying data. If "data", the bar lengths are set with data set `array`.</param>
    /// <param name ="Symmetric">Determines whether or not the error bars have the same length in both direction (top/bottom for vertical bars, left/right for horizontal bars.</param>
    /// <param name ="Array">Sets the data corresponding the length of each error bar. Values are plotted relative to the underlying data.</param>
    /// <param name ="Arrayminus">Sets the data corresponding the length of each error bar in the bottom (left) direction for vertical (horizontal) bars Values are plotted relative to the underlying data.</param>
    /// <param name ="Value">Sets the value of either the percentage (if `type` is set to "percent") or the constant (if `type` is set to "constant") corresponding to the lengths of the error bars.</param>
    /// <param name ="Valueminus">Sets the value of either the percentage (if `type` is set to "percent") or the constant (if `type` is set to "constant") corresponding to the lengths of the error bars in the bottom (left) direction for vertical (horizontal) bars</param>
    /// <param name ="Traceref"></param>
    /// <param name ="Tracerefminus"></param>
    /// <param name ="Copy_ystyle"></param>
    /// <param name ="Color">Sets the stoke color of the error bars.</param>
    /// <param name ="Thickness">Sets the thickness (in px) of the error bars.</param>
    /// <param name ="Width">Sets the width (in px) of the cross-bar at both ends of the error bars.</param>
    [<CompiledName("WithXErrorStyle")>]
    static member withXErrorStyle
        (
            [<Optional; DefaultParameterValue(null)>] ?Visible: bool,
            [<Optional; DefaultParameterValue(null)>] ?Type: StyleParam.ErrorType,
            [<Optional; DefaultParameterValue(null)>] ?Symmetric: bool,
            [<Optional; DefaultParameterValue(null)>] ?Array: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Arrayminus: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Value: float,
            [<Optional; DefaultParameterValue(null)>] ?Valueminus: float,
            [<Optional; DefaultParameterValue(null)>] ?Traceref: int,
            [<Optional; DefaultParameterValue(null)>] ?Tracerefminus: int,
            [<Optional; DefaultParameterValue(null)>] ?Copy_ystyle: bool,
            [<Optional; DefaultParameterValue(null)>] ?Color: Color,
            [<Optional; DefaultParameterValue(null)>] ?Thickness: float,
            [<Optional; DefaultParameterValue(null)>] ?Width: float
        ) =
        fun (ch: GenericChart) ->
            ch
            |> mapTrace (
                TraceStyle.XError(
                    ?Visible = Visible,
                    ?Type = Type,
                    ?Symmetric = Symmetric,
                    ?Array = Array,
                    ?Arrayminus = Arrayminus,
                    ?Value = Value,
                    ?Valueminus = Valueminus,
                    ?Traceref = Traceref,
                    ?Tracerefminus = Tracerefminus,
                    ?Copy_ystyle = Copy_ystyle,
                    ?Color = Color,
                    ?Thickness = Thickness,
                    ?Width = Width
                )
            )

    /// <summary>
    /// Sets the error for the y dimension for the chart's trace(s).
    /// </summary>
    /// <param name="yError">The new Error in the x dimension for the chart's trace(s)</param>
    /// <param name="Combine">Wether or not to combine the objects if there is already an Error object set (default is false)</param>
    [<CompiledName("SetYError")>]
    static member setYError(yError: Error, ?Combine: bool) =
        let combine = defaultArg Combine false

        (fun (ch: GenericChart) ->
            if combine then
                ch |> GenericChart.mapTrace (Trace.updateYError yError)
            else
                ch |> GenericChart.mapTrace (Trace.setYError yError))

    /// <summary>
    /// Sets the error in the y dimension for the chart's trace(s).
    ///
    /// If there is already an error set, the objects are combined.
    /// </summary>
    /// <param name="yError">The new error for the chart's trace(s)</param>
    [<CompiledName("WithYError")>]
    static member withYError(yError: Error) =
        (fun (ch: GenericChart) -> ch |> Chart.setYError (yError, true))

    /// <summary>
    /// Applies the given styles to the error object(s) in the y dimension of the chart's trace(s). Overwrites attributes with the same name that are already set.
    /// </summary>
    /// <param name ="Visible">Determines whether or not this set of error bars is visible.</param>
    /// <param name ="Type">Determines the rule used to generate the error bars. If "constant`, the bar lengths are of a constant value. Set this constant in `value`. If "percent", the bar lengths correspond to a percentage of underlying data. Set this percentage in `value`. If "sqrt", the bar lengths correspond to the square of the underlying data. If "data", the bar lengths are set with data set `array`.</param>
    /// <param name ="Symmetric">Determines whether or not the error bars have the same length in both direction (top/bottom for vertical bars, left/right for horizontal bars.</param>
    /// <param name ="Array">Sets the data corresponding the length of each error bar. Values are plotted relative to the underlying data.</param>
    /// <param name ="Arrayminus">Sets the data corresponding the length of each error bar in the bottom (left) direction for vertical (horizontal) bars Values are plotted relative to the underlying data.</param>
    /// <param name ="Value">Sets the value of either the percentage (if `type` is set to "percent") or the constant (if `type` is set to "constant") corresponding to the lengths of the error bars.</param>
    /// <param name ="Valueminus">Sets the value of either the percentage (if `type` is set to "percent") or the constant (if `type` is set to "constant") corresponding to the lengths of the error bars in the bottom (left) direction for vertical (horizontal) bars</param>
    /// <param name ="Traceref"></param>
    /// <param name ="Tracerefminus"></param>
    /// <param name ="Copy_ystyle"></param>
    /// <param name ="Color">Sets the stoke color of the error bars.</param>
    /// <param name ="Thickness">Sets the thickness (in px) of the error bars.</param>
    /// <param name ="Width">Sets the width (in px) of the cross-bar at both ends of the error bars.</param>
    [<CompiledName("WithYErrorStyle")>]
    static member withYErrorStyle
        (
            [<Optional; DefaultParameterValue(null)>] ?Visible: bool,
            [<Optional; DefaultParameterValue(null)>] ?Type: StyleParam.ErrorType,
            [<Optional; DefaultParameterValue(null)>] ?Symmetric: bool,
            [<Optional; DefaultParameterValue(null)>] ?Array: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Arrayminus: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Value: float,
            [<Optional; DefaultParameterValue(null)>] ?Valueminus: float,
            [<Optional; DefaultParameterValue(null)>] ?Traceref: int,
            [<Optional; DefaultParameterValue(null)>] ?Tracerefminus: int,
            [<Optional; DefaultParameterValue(null)>] ?Copy_ystyle: bool,
            [<Optional; DefaultParameterValue(null)>] ?Color: Color,
            [<Optional; DefaultParameterValue(null)>] ?Thickness: float,
            [<Optional; DefaultParameterValue(null)>] ?Width: float
        ) =
        fun (ch: GenericChart) ->
            ch
            |> mapTrace (
                TraceStyle.YError(
                    ?Visible = Visible,
                    ?Type = Type,
                    ?Symmetric = Symmetric,
                    ?Array = Array,
                    ?Arrayminus = Arrayminus,
                    ?Value = Value,
                    ?Valueminus = Valueminus,
                    ?Traceref = Traceref,
                    ?Tracerefminus = Tracerefminus,
                    ?Copy_ystyle = Copy_ystyle,
                    ?Color = Color,
                    ?Thickness = Thickness,
                    ?Width = Width
                )
            )

    /// <summary>
    /// Sets the error for the z dimension for the chart's trace(s).
    /// </summary>
    /// <param name="zError">The new Error in the x dimension for the chart's trace(s)</param>
    /// <param name="Combine">Wether or not to combine the objects if there is already an Error object set (default is false)</param>
    [<CompiledName("SetZError")>]
    static member setZError(zError: Error, ?Combine: bool) =
        let combine = defaultArg Combine false

        (fun (ch: GenericChart) ->
            if combine then
                ch |> GenericChart.mapTrace (Trace.updateZError zError)
            else
                ch |> GenericChart.mapTrace (Trace.setZError zError))

    /// <summary>
    /// Sets the error in the z dimension for the chart's trace(s).
    ///
    /// If there is already an error set, the objects are combined.
    /// </summary>
    /// <param name="zError">The new error for the chart's trace(s)</param>
    [<CompiledName("WithZError")>]
    static member withZError(zError: Error) =
        (fun (ch: GenericChart) -> ch |> Chart.setZError (zError, true))

    /// <summary>
    /// Applies the given styles to the error object(s) in the z dimension of the chart's trace(s). Overwrites attributes with the same name that are already set.
    /// </summary>
    /// <param name ="Visible">Determines whether or not this set of error bars is visible.</param>
    /// <param name ="Type">Determines the rule used to generate the error bars. If "constant`, the bar lengths are of a constant value. Set this constant in `value`. If "percent", the bar lengths correspond to a percentage of underlying data. Set this percentage in `value`. If "sqrt", the bar lengths correspond to the square of the underlying data. If "data", the bar lengths are set with data set `array`.</param>
    /// <param name ="Symmetric">Determines whether or not the error bars have the same length in both direction (top/bottom for vertical bars, left/right for horizontal bars.</param>
    /// <param name ="Array">Sets the data corresponding the length of each error bar. Values are plotted relative to the underlying data.</param>
    /// <param name ="Arrayminus">Sets the data corresponding the length of each error bar in the bottom (left) direction for vertical (horizontal) bars Values are plotted relative to the underlying data.</param>
    /// <param name ="Value">Sets the value of either the percentage (if `type` is set to "percent") or the constant (if `type` is set to "constant") corresponding to the lengths of the error bars.</param>
    /// <param name ="Valueminus">Sets the value of either the percentage (if `type` is set to "percent") or the constant (if `type` is set to "constant") corresponding to the lengths of the error bars in the bottom (left) direction for vertical (horizontal) bars</param>
    /// <param name ="Traceref"></param>
    /// <param name ="Tracerefminus"></param>
    /// <param name ="Copy_ystyle"></param>
    /// <param name ="Color">Sets the stoke color of the error bars.</param>
    /// <param name ="Thickness">Sets the thickness (in px) of the error bars.</param>
    /// <param name ="Width">Sets the width (in px) of the cross-bar at both ends of the error bars.</param>
    [<CompiledName("WithZErrorStyle")>]
    static member withZErrorStyle
        (
            [<Optional; DefaultParameterValue(null)>] ?Visible: bool,
            [<Optional; DefaultParameterValue(null)>] ?Type: StyleParam.ErrorType,
            [<Optional; DefaultParameterValue(null)>] ?Symmetric: bool,
            [<Optional; DefaultParameterValue(null)>] ?Array: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Arrayminus: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Value: float,
            [<Optional; DefaultParameterValue(null)>] ?Valueminus: float,
            [<Optional; DefaultParameterValue(null)>] ?Traceref: int,
            [<Optional; DefaultParameterValue(null)>] ?Tracerefminus: int,
            [<Optional; DefaultParameterValue(null)>] ?Copy_ystyle: bool,
            [<Optional; DefaultParameterValue(null)>] ?Color: Color,
            [<Optional; DefaultParameterValue(null)>] ?Thickness: float,
            [<Optional; DefaultParameterValue(null)>] ?Width: float
        ) =
        fun (ch: GenericChart) ->
            ch
            |> mapTrace (
                TraceStyle.ZError(
                    ?Visible = Visible,
                    ?Type = Type,
                    ?Symmetric = Symmetric,
                    ?Array = Array,
                    ?Arrayminus = Arrayminus,
                    ?Value = Value,
                    ?Valueminus = Valueminus,
                    ?Traceref = Traceref,
                    ?Tracerefminus = Tracerefminus,
                    ?Copy_ystyle = Copy_ystyle,
                    ?Color = Color,
                    ?Thickness = Thickness,
                    ?Width = Width
                )
            )

    /// <summary>
    /// Sets the ColorBar for the chart's trace(s).
    /// </summary>
    /// <param name="colorBar">The new ColorBar for the chart's trace(s)</param>
    /// <param name="Combine">Wether or not to combine the objects if there is already a ColorBar object set (default is false)</param>
    [<CompiledName("SetColorBar")>]
    static member setColorBar(colorBar: ColorBar, ?Combine: bool) =
        let combine = defaultArg Combine false

        (fun (ch: GenericChart) ->
            if combine then
                ch |> GenericChart.mapTrace (Trace.updateColorBar colorBar)
            else
                ch |> GenericChart.mapTrace (Trace.setColorBar colorBar))

    /// <summary>
    /// Sets the ColorBar for the chart's trace(s).
    ///
    /// If there is already a ColorBar set, the objects are combined.
    /// </summary>
    /// <param name="colorbar">The new ColorBar for the chart's trace(s)</param>
    [<CompiledName("WithColorBar")>]
    static member withColorBar(colorbar: ColorBar) =
        (fun (ch: GenericChart) -> ch |> Chart.setColorBar (colorbar, true))

    /// <summary>
    /// Applies the given styles to the ColorBar object(s) of the chart's trace(s). Overwrites attributes with the same name that are already set.
    /// </summary>
    /// <param name="TitleText">Sets the text of the colorbar title.</param>
    /// <param name="TitleFont">Sets the font of the colorbar title.</param>
    /// <param name="TitleStandoff">Sets the standoff distance (in px) between the colorbar labels and the title text.</param>
    /// <param name="Title">Sets the Title (use this for more finegrained control than the other title-associated arguments)</param>
    /// <param name="Len">Sets the length of the color bar This measure excludes the padding of both ends. That is, the color bar length is this length minus the padding on both ends.</param>
    /// <param name="LenMode">Determines whether this color bar's length (i.e. the measure in the color variation direction) is set in units of plot "fraction" or in "pixels. Use `len` to set the value.</param>
    /// <param name="BGColor">Sets the color of padded area.</param>
    /// <param name="BorderColor">Sets the axis line color.</param>
    /// <param name="OutlineColor">Sets the axis line color.</param>
    /// <param name="X">Sets the x position of the color bar (in plot fraction).</param>
    /// <param name="XAnchor">Sets this color bar's horizontal position anchor. This anchor binds the `x` position to the "left", "center" or "right" of the color bar.</param>
    /// <param name="XPad">Sets the amount of padding (in px) along the x direction.</param>
    /// <param name="Y">Sets the y position of the color bar (in plot fraction).</param>
    /// <param name="YAnchor">Sets this color bar's vertical position anchor This anchor binds the `y` position to the "top", "middle" or "bottom" of the color bar.</param>
    /// <param name="YPad">Sets the amount of padding (in px) along the y direction.</param>
    [<CompiledName("WithColorbarStyle")>]
    static member withColorBarStyle
        (
            [<Optional; DefaultParameterValue(null)>] ?TitleText: string,
            [<Optional; DefaultParameterValue(null)>] ?TitleFont: Font,
            [<Optional; DefaultParameterValue(null)>] ?TitleStandoff: int,
            [<Optional; DefaultParameterValue(null)>] ?Title: Title,
            [<Optional; DefaultParameterValue(null)>] ?Len: float,
            [<Optional; DefaultParameterValue(null)>] ?LenMode: StyleParam.UnitMode,
            [<Optional; DefaultParameterValue(null)>] ?BGColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?BorderColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?OutlineColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?X: float,
            [<Optional; DefaultParameterValue(null)>] ?XAnchor: StyleParam.HorizontalAlign,
            [<Optional; DefaultParameterValue(null)>] ?XPad: float,
            [<Optional; DefaultParameterValue(null)>] ?Y: float,
            [<Optional; DefaultParameterValue(null)>] ?YAnchor: StyleParam.VerticalAlign,
            [<Optional; DefaultParameterValue(null)>] ?YPad: float
        ) =

        let title =
            Title
            |> Option.defaultValue (Plotly.NET.Title())
            |> Plotly.NET.Title.style (?Text = TitleText, ?Font = TitleFont, ?Standoff = TitleStandoff)

        let colorbar =
            ColorBar.init (
                Title = title,
                ?Len = Len,
                ?LenMode = LenMode,
                ?BGColor = BGColor,
                ?BorderColor = BorderColor,
                ?OutlineColor = OutlineColor,
                ?X = X,
                ?XAnchor = XAnchor,
                ?XPad = XPad,
                ?Y = Y,
                ?YAnchor = YAnchor,
                ?YPad = YPad

            )

        Chart.withColorBar (colorbar)

    //==============================================================================================================
    //======================================= General Layout object styling ========================================
    //==============================================================================================================


    /// <summary>
    /// Sets the given layout on the input chart.
    ///
    /// If there is already an layout set at the given id, the axis objects are combined.
    /// </summary>
    [<CompiledName("WithLayout")>]
    static member withLayout(layout: Layout) =
        (fun (ch: GenericChart) -> GenericChart.addLayout layout ch)

    /// <summary>
    /// Applies the given styles to the chart's Layout object. Overwrites attributes with the same name that are already set.
    /// </summary>
    /// <param name="Title">Sets the title of the layout.</param>
    /// <param name="ShowLegend">Determines whether or not a legend is drawn. Default is `true` if there is a trace to show and any of these: a) Two or more traces would by default be shown in the legend. b) One pie trace is shown in the legend. c) One trace is explicitly given with `showlegend: true`.</param>
    /// <param name="Legend">Sets the legend styles of the layout.</param>
    /// <param name="Margin">Sets the margins around the layout.</param>
    /// <param name="AutoSize">Determines whether or not a layout width or height that has been left undefined by the user is initialized on each relayout. Note that, regardless of this attribute, an undefined layout width or height is always initialized on the first call to plot.</param>
    /// <param name="Width">Sets the plot's width (in px).</param>
    /// <param name="Height">Sets the plot's height (in px).</param>
    /// <param name="Font">Sets the global font. Note that fonts used in traces and other layout components inherit from the global font.</param>
    /// <param name="UniformText">Determines how the font size for various text elements are uniformed between each trace type.</param>
    /// <param name="Separators">Sets the decimal and thousand separators. For example, ". " puts a '.' before decimals and a space between thousands. In English locales, dflt is ".," but other locales may alter this default.</param>
    /// <param name="PaperBGColor">Sets the background color of the paper where the graph is drawn.</param>
    /// <param name="PlotBGColor">Sets the background color of the plotting area in-between x and y axes.</param>
    /// <param name="AutoTypeNumbers">Using "strict" a numeric string in trace data is not converted to a number. Using "convert types" a numeric string in trace data may be treated as a number during automatic axis `type` detection. This is the default value; however it could be overridden for individual axes.</param>
    /// <param name="Colorscale">Sets the default colorscales that are used by plots using autocolorscale.</param>
    /// <param name="Colorway">Sets the default trace colors.</param>
    /// <param name="ModeBar">Sets the modebar of the layout.</param>
    /// <param name="HoverMode">Determines the mode of hover interactions. If "closest", a single hoverlabel will appear for the "closest" point within the `hoverdistance`. If "x" (or "y"), multiple hoverlabels will appear for multiple points at the "closest" x- (or y-) coordinate within the `hoverdistance`, with the caveat that no more than one hoverlabel will appear per trace. If "x unified" (or "y unified"), a single hoverlabel will appear multiple points at the closest x- (or y-) coordinate within the `hoverdistance` with the caveat that no more than one hoverlabel will appear per trace. In this mode, spikelines are enabled by default perpendicular to the specified axis. If false, hover interactions are disabled.</param>
    /// <param name="ClickMode">Determines the mode of single click interactions. "event" is the default value and emits the `plotly_click` event. In addition this mode emits the `plotly_selected` event in drag modes "lasso" and "select", but with no event data attached (kept for compatibility reasons). The "select" flag enables selecting single data points via click. This mode also supports persistent selections, meaning that pressing Shift while clicking, adds to / subtracts from an existing selection. "select" with `hovermode`: "x" can be confusing, consider explicitly setting `hovermode`: "closest" when using this feature. Selection events are sent accordingly as long as "event" flag is set as well. When the "event" flag is missing, `plotly_click` and `plotly_selected` events are not fired.</param>
    /// <param name="DragMode">Determines the mode of drag interactions. "select" and "lasso" apply only to scatter traces with markers or text. "orbit" and "turntable" apply only to 3D scenes.</param>
    /// <param name="SelectDirection">When `dragmode` is set to "select", this limits the selection of the drag to horizontal, vertical or diagonal. "h" only allows horizontal selection, "v" only vertical, "d" only diagonal and "any" sets no limit.</param>
    /// <param name="HoverDistance">Sets the default distance (in pixels) to look for data to add hover labels (-1 means no cutoff, 0 means no looking for data). This is only a real distance for hovering on point-like objects, like scatter points. For area-like objects (bars, scatter fills, etc) hovering is on inside the area and off outside, but these objects will not supersede hover on point-like objects in case of conflict.</param>
    /// <param name="SpikeDistance">Sets the default distance (in pixels) to look for data to draw spikelines to (-1 means no cutoff, 0 means no looking for data). As with hoverdistance, distance does not apply to area-like objects. In addition, some objects can be hovered on but will not generate spikelines, such as scatter fills.</param>
    /// <param name="Hoverlabel">Sets the style ov hover labels.</param>
    /// <param name="Transition">Sets transition options used during Plotly.react updates.</param>
    /// <param name="DataRevision">If provided, a changed value tells `Plotly.react` that one or more data arrays has changed. This way you can modify arrays in-place rather than making a complete new copy for an incremental change. If NOT provided, `Plotly.react` assumes that data arrays are being treated as immutable, thus any data array with a different identity from its predecessor contains new data.</param>
    /// <param name="UIRevision">Used to allow user interactions with the plot to persist after `Plotly.react` calls that are unaware of these interactions. If `uirevision` is omitted, or if it is given and it changed from the previous `Plotly.react` call, the exact new figure is used. If `uirevision` is truthy and did NOT change, any attribute that has been affected by user interactions and did not receive a different value in the new figure will keep the interaction value. `layout.uirevision` attribute serves as the default for `uirevision` attributes in various sub-containers. For finer control you can set these sub-attributes directly. For example, if your app separately controls the data on the x and y axes you might set `xaxis.uirevision="time"` and `yaxis.uirevision="cost"`. Then if only the y data is changed, you can update `yaxis.uirevision="quantity"` and the y axis range will reset but the x axis range will retain any user-driven zoom.</param>
    /// <param name="EditRevision">Controls persistence of user-driven changes in `editable: true` configuration, other than trace names and axis titles. Defaults to `layout.uirevision`.</param>
    /// <param name="SelectRevision">Controls persistence of user-driven changes in `editable: true` configuration, other than trace names and axis titles. Defaults to `layout.uirevision`.</param>
    /// <param name="Template">Default attributes to be applied to the plot. Templates can be created from existing plots using `Plotly.makeTemplate`, or created manually. They should be objects with format: `{layout: layoutTemplate, data: {[type]: [traceTemplate, ...]}, ...}` `layoutTemplate` and `traceTemplate` are objects matching the attribute structure of `layout` and a data trace. Trace templates are applied cyclically to traces of each type. Container arrays (eg `annotations`) have special handling: An object ending in `defaults` (eg `annotationdefaults`) is applied to each array item. But if an item has a `templateitemname` key we look in the template array for an item with matching `name` and apply that instead. If no matching `name` is found we mark the item invisible. Any named template item not referenced is appended to the end of the array, so you can use this for a watermark annotation or a logo image, for example. To omit one of these items on the plot, make an item with matching `templateitemname` and `visible: false`.</param>
    /// <param name="Meta">Assigns extra meta information that can be used in various `text` attributes. Attributes such as the graph, axis and colorbar `title.text`, annotation `text` `trace.name` in legend items, `rangeselector`, `updatemenus` and `sliders` `label` text all support `meta`. One can access `meta` fields using template strings: `%{meta[i]}` where `i` is the index of the `meta` item in question. `meta` can also be an object for example `{key: value}` which can be accessed %{meta[key]}.</param>
    /// <param name="Computed">Placeholder for exporting automargin-impacting values namely `margin.t`, `margin.b`, `margin.l` and `margin.r` in "full-json" mode.</param>
    /// <param name="Grid">Sets the layout grid for arranging multiple plots</param>
    /// <param name="Calendar">Sets the default calendar system to use for interpreting and displaying dates throughout the plot.</param>
    /// <param name="NewShape">Controls the behavior of newly drawn shapes</param>
    /// <param name="ActiveShape">Sets the styling of the active shape</param>
    /// <param name="HideSources">Determines whether or not a text link citing the data source is placed at the bottom-right cored of the figure. Has only an effect only on graphs that have been generated via forked graphs from the Chart Studio Cloud (at https://chart-studio.plotly.com or on-premise).</param>
    /// <param name="BarGap">Sets the gap (in plot fraction) between bars of adjacent location coordinates.</param>
    /// <param name="BarGroupGap">Sets the gap (in plot fraction) between bars of adjacent location coordinates.</param>
    /// <param name="BarMode">Determines how bars at the same location coordinate are displayed on the graph. With "stack", the bars are stacked on top of one another With "relative", the bars are stacked on top of one another, with negative values below the axis, positive values above With "group", the bars are plotted next to one another centered around the shared location. With "overlay", the bars are plotted over one another, you might need to an "opacity" to see multiple bars.</param>
    /// <param name="BarNorm">Sets the normalization for bar traces on the graph. With "fraction", the value of each bar is divided by the sum of all values at that location coordinate. "percent" is the same but multiplied by 100 to show percentages.</param>
    /// <param name="ExtendPieColors">If `true`, the pie slice colors (whether given by `piecolorway` or inherited from `colorway`) will be extended to three times its original length by first repeating every color 20% lighter then each color 20% darker. This is intended to reduce the likelihood of reusing the same color when you have many slices, but you can set `false` to disable. Colors provided in the trace, using `marker.colors`, are never extended.</param>
    /// <param name="HiddenLabels">If `true`, the pie slice colors (whether given by `piecolorway` or inherited from `colorway`) will be extended to three times its original length by first repeating every color 20% lighter then each color 20% darker. This is intended to reduce the likelihood of reusing the same color when you have many slices, but you can set `false` to disable. Colors provided in the trace, using `marker.colors`, are never extended.</param>
    /// <param name="PieColorWay">Sets the default pie slice colors. Defaults to the main `colorway` used for trace colors. If you specify a new list here it can still be extended with lighter and darker colors, see `extendpiecolors`.</param>
    /// <param name="BoxGap">Sets the gap (in plot fraction) between boxes of adjacent location coordinates. Has no effect on traces that have "width" set.</param>
    /// <param name="BoxGroupGap">Sets the gap (in plot fraction) between boxes of the same location coordinate. Has no effect on traces that have "width" set.</param>
    /// <param name="BoxMode">Sets the gap (in plot fraction) between boxes of the same location coordinate. Has no effect on traces that have "width" set.</param>
    /// <param name="ViolinGap">Sets the gap (in plot fraction) between boxes of the same location coordinate. Has no effect on traces that have "width" set.</param>
    /// <param name="ViolinGroupGap">Sets the gap (in plot fraction) between violins of the same location coordinate. Has no effect on traces that have "width" set.</param>
    /// <param name="ViolinMode">Determines how violins at the same location coordinate are displayed on the graph. If "group", the violins are plotted next to one another centered around the shared location. If "overlay", the violins are plotted over one another, you might need to set "opacity" to see them multiple violins. Has no effect on traces that have "width" set.</param>
    /// <param name="WaterfallGap">Sets the gap (in plot fraction) between bars of adjacent location coordinates.</param>
    /// <param name="WaterfallGroupGap">Sets the gap (in plot fraction) between bars of the same location coordinate.</param>
    /// <param name="WaterfallMode">Determines how bars at the same location coordinate are displayed on the graph. With "group", the bars are plotted next to one another centered around the shared location. With "overlay", the bars are plotted over one another, you might need to an "opacity" to see multiple bars.</param>
    /// <param name="FunnelGap">Sets the gap (in plot fraction) between bars of adjacent location coordinates.</param>
    /// <param name="FunnelGroupGap">Sets the gap (in plot fraction) between bars of adjacent location coordinates.</param>
    /// <param name="FunnelMode">Determines how bars at the same location coordinate are displayed on the graph. With "stack", the bars are stacked on top of one another With "group", the bars are plotted next to one another centered around the shared location. With "overlay", the bars are plotted over one another, you might need to an "opacity" to see multiple bars.</param>
    /// <param name="ExtendFunnelAreaColors">If `true`, the funnelarea slice colors (whether given by `funnelareacolorway` or inherited from `colorway`) will be extended to three times its original length by first repeating every color 20% lighter then each color 20% darker. This is intended to reduce the likelihood of reusing the same color when you have many slices, but you can set `false` to disable. Colors provided in the trace, using `marker.colors`, are never extended.</param>
    /// <param name="FunnelAreaColorWay">Sets the default funnelarea slice colors. Defaults to the main `colorway` used for trace colors. If you specify a new list here it can still be extended with lighter and darker colors, see `extendfunnelareacolors`.</param>
    /// <param name="ExtendSunBurstColors">If `true`, the sunburst slice colors (whether given by `sunburstcolorway` or inherited from `colorway`) will be extended to three times its original length by first repeating every color 20% lighter then each color 20% darker. This is intended to reduce the likelihood of reusing the same color when you have many slices, but you can set `false` to disable. Colors provided in the trace, using `marker.colors`, are never extended.</param>
    /// <param name="SunBurstColorWay">If `true`, the sunburst slice colors (whether given by `sunburstcolorway` or inherited from `colorway`) will be extended to three times its original length by first repeating every color 20% lighter then each color 20% darker. This is intended to reduce the likelihood of reusing the same color when you have many slices, but you can set `false` to disable. Colors provided in the trace, using `marker.colors`, are never extended.</param>
    /// <param name="ExtendTreeMapColors">If `true`, the treemap slice colors (whether given by `treemapcolorway` or inherited from `colorway`) will be extended to three times its original length by first repeating every color 20% lighter then each color 20% darker. This is intended to reduce the likelihood of reusing the same color when you have many slices, but you can set `false` to disable. Colors provided in the trace, using `marker.colors`, are never extended.</param>
    /// <param name="TreeMapColorWay">Sets the default treemap slice colors. Defaults to the main `colorway` used for trace colors. If you specify a new list here it can still be extended with lighter and darker colors, see `extendtreemapcolors`.</param>
    /// <param name="ExtendIcicleColors">If `true`, the icicle slice colors (whether given by `iciclecolorway` or inherited from `colorway`) will be extended to three times its original length by first repeating every color 20% lighter then each color 20% darker. This is intended to reduce the likelihood of reusing the same color when you have many slices, but you can set `false` to disable. Colors provided in the trace, using `marker.colors`, are never extended.</param>
    /// <param name="IcicleColorWay">Sets the default icicle slice colors. Defaults to the main `colorway` used for trace colors. If you specify a new list here it can still be extended with lighter and darker colors, see `extendiciclecolors`.</param>
    /// <param name="Annotations">A collection containing all Annotations of this layout. An annotation is a text element that can be placed anywhere in the plot. It can be positioned with respect to relative coordinates in the plot or with respect to the actual data coordinates of the graph. Annotations can be shown with or without an arrow.</param>
    /// <param name="Shapes">A collection containing all Shapes of this layout.</param>
    /// <param name="Images">A collection containing all Images of this layout. </param>
    /// <param name="Sliders">A collection containing all Sliders of this layout. </param>
    /// <param name="UpdateMenus">A collection containing all UpdateMenus of this layout. </param>
    [<CompiledName("WithLayoutStyle")>]
    static member withLayoutStyle
        (
            [<Optional; DefaultParameterValue(null)>] ?Title: Title,
            [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
            [<Optional; DefaultParameterValue(null)>] ?Legend: Legend,
            [<Optional; DefaultParameterValue(null)>] ?Margin: Margin,
            [<Optional; DefaultParameterValue(null)>] ?AutoSize: bool,
            [<Optional; DefaultParameterValue(null)>] ?Width: int,
            [<Optional; DefaultParameterValue(null)>] ?Height: int,
            [<Optional; DefaultParameterValue(null)>] ?Font: Font,
            [<Optional; DefaultParameterValue(null)>] ?UniformText: UniformText,
            [<Optional; DefaultParameterValue(null)>] ?Separators: string,
            [<Optional; DefaultParameterValue(null)>] ?PaperBGColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?PlotBGColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?AutoTypeNumbers: StyleParam.AutoTypeNumbers,
            [<Optional; DefaultParameterValue(null)>] ?Colorscale: DefaultColorScales,
            [<Optional; DefaultParameterValue(null)>] ?Colorway: Color,
            [<Optional; DefaultParameterValue(null)>] ?ModeBar: ModeBar,
            [<Optional; DefaultParameterValue(null)>] ?HoverMode: StyleParam.HoverMode,
            [<Optional; DefaultParameterValue(null)>] ?ClickMode: StyleParam.ClickMode,
            [<Optional; DefaultParameterValue(null)>] ?DragMode: StyleParam.DragMode,
            [<Optional; DefaultParameterValue(null)>] ?SelectDirection: StyleParam.SelectDirection,
            [<Optional; DefaultParameterValue(null)>] ?HoverDistance: int,
            [<Optional; DefaultParameterValue(null)>] ?SpikeDistance: int,
            [<Optional; DefaultParameterValue(null)>] ?Hoverlabel: Hoverlabel,
            [<Optional; DefaultParameterValue(null)>] ?Transition: Transition,
            [<Optional; DefaultParameterValue(null)>] ?DataRevision: string,
            [<Optional; DefaultParameterValue(null)>] ?UIRevision: string,
            [<Optional; DefaultParameterValue(null)>] ?EditRevision: string,
            [<Optional; DefaultParameterValue(null)>] ?SelectRevision: string,
            [<Optional; DefaultParameterValue(null)>] ?Template: DynamicObj,
            [<Optional; DefaultParameterValue(null)>] ?Meta: string,
            [<Optional; DefaultParameterValue(null)>] ?Computed: string,
            [<Optional; DefaultParameterValue(null)>] ?Grid: LayoutGrid,
            [<Optional; DefaultParameterValue(null)>] ?Calendar: StyleParam.Calendar,
            [<Optional; DefaultParameterValue(null)>] ?NewShape: Shape,
            [<Optional; DefaultParameterValue(null)>] ?ActiveShape: ActiveShape,
            [<Optional; DefaultParameterValue(null)>] ?HideSources: bool,
            [<Optional; DefaultParameterValue(null)>] ?BarGap: float,
            [<Optional; DefaultParameterValue(null)>] ?BarGroupGap: float,
            [<Optional; DefaultParameterValue(null)>] ?BarMode: StyleParam.BarMode,
            [<Optional; DefaultParameterValue(null)>] ?BarNorm: StyleParam.BarNorm,
            [<Optional; DefaultParameterValue(null)>] ?ExtendPieColors: bool,
            [<Optional; DefaultParameterValue(null)>] ?HiddenLabels: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?PieColorWay: Color,
            [<Optional; DefaultParameterValue(null)>] ?BoxGap: float,
            [<Optional; DefaultParameterValue(null)>] ?BoxGroupGap: float,
            [<Optional; DefaultParameterValue(null)>] ?BoxMode: StyleParam.BoxMode,
            [<Optional; DefaultParameterValue(null)>] ?ViolinGap: float,
            [<Optional; DefaultParameterValue(null)>] ?ViolinGroupGap: float,
            [<Optional; DefaultParameterValue(null)>] ?ViolinMode: StyleParam.ViolinMode,
            [<Optional; DefaultParameterValue(null)>] ?WaterfallGap: float,
            [<Optional; DefaultParameterValue(null)>] ?WaterfallGroupGap: float,
            [<Optional; DefaultParameterValue(null)>] ?WaterfallMode: StyleParam.WaterfallMode,
            [<Optional; DefaultParameterValue(null)>] ?FunnelGap: float,
            [<Optional; DefaultParameterValue(null)>] ?FunnelGroupGap: float,
            [<Optional; DefaultParameterValue(null)>] ?FunnelMode: StyleParam.FunnelMode,
            [<Optional; DefaultParameterValue(null)>] ?ExtendFunnelAreaColors: bool,
            [<Optional; DefaultParameterValue(null)>] ?FunnelAreaColorWay: Color,
            [<Optional; DefaultParameterValue(null)>] ?ExtendSunBurstColors: bool,
            [<Optional; DefaultParameterValue(null)>] ?SunBurstColorWay: Color,
            [<Optional; DefaultParameterValue(null)>] ?ExtendTreeMapColors: bool,
            [<Optional; DefaultParameterValue(null)>] ?TreeMapColorWay: Color,
            [<Optional; DefaultParameterValue(null)>] ?ExtendIcicleColors: bool,
            [<Optional; DefaultParameterValue(null)>] ?IcicleColorWay: Color,
            [<Optional; DefaultParameterValue(null)>] ?Annotations: seq<Annotation>,
            [<Optional; DefaultParameterValue(null)>] ?Shapes: seq<Shape>,
            [<Optional; DefaultParameterValue(null)>] ?Images: seq<LayoutImage>,
            [<Optional; DefaultParameterValue(null)>] ?Sliders: seq<Slider>,
            [<Optional; DefaultParameterValue(null)>] ?UpdateMenus: seq<UpdateMenu>
        ) =
        (fun (ch: GenericChart) ->

            let layout' =
                Layout.init (
                    ?Title = Title,
                    ?ShowLegend = ShowLegend,
                    ?Legend = Legend,
                    ?Margin = Margin,
                    ?AutoSize = AutoSize,
                    ?Width = Width,
                    ?Height = Height,
                    ?Font = Font,
                    ?UniformText = UniformText,
                    ?Separators = Separators,
                    ?PaperBGColor = PaperBGColor,
                    ?PlotBGColor = PlotBGColor,
                    ?AutoTypeNumbers = AutoTypeNumbers,
                    ?Colorscale = Colorscale,
                    ?Colorway = Colorway,
                    ?ModeBar = ModeBar,
                    ?HoverMode = HoverMode,
                    ?ClickMode = ClickMode,
                    ?DragMode = DragMode,
                    ?SelectDirection = SelectDirection,
                    ?HoverDistance = HoverDistance,
                    ?SpikeDistance = SpikeDistance,
                    ?Hoverlabel = Hoverlabel,
                    ?Transition = Transition,
                    ?DataRevision = DataRevision,
                    ?UIRevision = UIRevision,
                    ?EditRevision = EditRevision,
                    ?SelectRevision = SelectRevision,
                    ?Template = Template,
                    ?Meta = Meta,
                    ?Computed = Computed,
                    ?Grid = Grid,
                    ?Calendar = Calendar,
                    ?NewShape = NewShape,
                    ?ActiveShape = ActiveShape,
                    ?HideSources = HideSources,
                    ?BarGap = BarGap,
                    ?BarGroupGap = BarGroupGap,
                    ?BarMode = BarMode,
                    ?BarNorm = BarNorm,
                    ?ExtendPieColors = ExtendPieColors,
                    ?HiddenLabels = HiddenLabels,
                    ?PieColorWay = PieColorWay,
                    ?BoxGap = BoxGap,
                    ?BoxGroupGap = BoxGroupGap,
                    ?BoxMode = BoxMode,
                    ?ViolinGap = ViolinGap,
                    ?ViolinGroupGap = ViolinGroupGap,
                    ?ViolinMode = ViolinMode,
                    ?WaterfallGap = WaterfallGap,
                    ?WaterfallGroupGap = WaterfallGroupGap,
                    ?WaterfallMode = WaterfallMode,
                    ?FunnelGap = FunnelGap,
                    ?FunnelGroupGap = FunnelGroupGap,
                    ?FunnelMode = FunnelMode,
                    ?ExtendFunnelAreaColors = ExtendFunnelAreaColors,
                    ?FunnelAreaColorWay = FunnelAreaColorWay,
                    ?ExtendSunBurstColors = ExtendSunBurstColors,
                    ?SunBurstColorWay = SunBurstColorWay,
                    ?ExtendTreeMapColors = ExtendTreeMapColors,
                    ?TreeMapColorWay = TreeMapColorWay,
                    ?ExtendIcicleColors = ExtendIcicleColors,
                    ?IcicleColorWay = IcicleColorWay,
                    ?Annotations = Annotations,
                    ?Shapes = Shapes,
                    ?Images = Images,
                    ?Sliders = Sliders,
                    ?UpdateMenus = UpdateMenus
                )

            GenericChart.addLayout layout' ch)

    /// <summary>
    /// Sets the given axis with the given id on the input chart's layout.
    /// </summary>
    /// <param name="axis">The x axis to set on the chart's layout</param>
    /// <param name="id">The target axis id with which the axis should be set.</param>
    /// <param name="SceneAxis">If set on a scene, define wether it is the x, y or z axis. default is x.</param>
    /// <param name="Combine">Wether or not to combine the objects if there is already an axis set (default is false)</param>
    [<CompiledName("SetAxis")>]
    static member setAxis
        (
            axis: LinearAxis,
            id: StyleParam.SubPlotId,
            [<Optional; DefaultParameterValue(null)>] ?SceneAxis: StyleParam.SubPlotId,
            [<Optional; DefaultParameterValue(null)>] ?Combine: bool
        ) =

        fun (ch: GenericChart) ->

            let combine = defaultArg Combine false

            match id with
            // x and y axes for 2d cartesion plots are set on the layout directly
            | StyleParam.SubPlotId.XAxis _
            | StyleParam.SubPlotId.YAxis _ ->
                ch
                |> GenericChart.mapLayout
                    (fun layout ->

                        if combine then
                            layout |> Layout.updateLinearAxisById (id, axis = axis)
                        else
                            layout |> Layout.setLinearAxis (id, axis = axis))

            // x, y, and z axes for 3d cartesion plots are set on the scene object on the layout.
            | StyleParam.SubPlotId.Scene _ ->

                // we need to know which axis to set on the scene
                let sceneAxisId =
                    defaultArg SceneAxis (StyleParam.SubPlotId.XAxis 1)

                ch
                |> GenericChart.mapLayout
                    (fun layout ->
                        let scene =
                            layout |> Layout.getSceneById sceneAxisId

                        if combine then
                            let currentAxis =
                                match sceneAxisId with
                                | StyleParam.SubPlotId.XAxis _ -> scene |> Scene.getXAxis
                                | StyleParam.SubPlotId.YAxis _ -> scene |> Scene.getYAxis
                                | StyleParam.SubPlotId.ZAxis _ -> scene |> Scene.getZAxis
                                | _ -> failwith "invalid scene axis id"

                            let updatedAxis =
                                (DynObj.combine currentAxis axis) :?> LinearAxis

                            let updatedScene =
                                scene
                                |> fun s ->
                                    match sceneAxisId with
                                    | StyleParam.SubPlotId.XAxis _ -> s |> Scene.setXAxis axis
                                    | StyleParam.SubPlotId.YAxis _ -> s |> Scene.setYAxis axis
                                    | StyleParam.SubPlotId.ZAxis _ -> s |> Scene.setZAxis axis
                                    | _ -> failwith "invalid scene axis id"

                            layout |> Layout.updateSceneById (id, updatedScene)

                        else
                            let updatedScene =
                                layout
                                |> Layout.getSceneById id
                                |> fun s ->
                                    match sceneAxisId with
                                    | StyleParam.SubPlotId.XAxis _ -> s |> Scene.setXAxis axis
                                    | StyleParam.SubPlotId.YAxis _ -> s |> Scene.setYAxis axis
                                    | StyleParam.SubPlotId.ZAxis _ -> s |> Scene.setZAxis axis
                                    | _ -> failwith "invalid scene axis id"

                            layout |> Layout.updateSceneById (id, updatedScene))

            | _ -> failwith $"{StyleParam.SubPlotId.toString id} is an invalid subplot id for setting a xaxis"

    /// <summary>
    /// Sets the given x axis on the input chart's layout, optionally passing a target axis id.
    ///
    /// If there is already an axis set at the given id, the axis objects are combined.
    /// </summary>
    /// <param name="xAxis">The x axis to set on the chart's layout</param>
    /// <param name="Id">The target axis id with which the axis should be set. Default is 1.</param>
    [<CompiledName("WithXAxis")>]
    static member withXAxis(xAxis: LinearAxis, [<Optional; DefaultParameterValue(null)>] ?Id: StyleParam.SubPlotId) =
        let id =
            defaultArg Id (StyleParam.SubPlotId.XAxis 1)

        fun (ch: GenericChart) ->
            ch |> Chart.setAxis (xAxis, id, SceneAxis = StyleParam.SubPlotId.XAxis 1, Combine = true)

    /// <summary>
    /// Sets the given x axis styles on the input chart's layout.
    ///
    /// If there is already an axis set at the given id, the styles are applied to it. If there is no axis present, a new LinearAxis object with the given styles will be set.
    /// </summary>
    /// <param name="TitleText">Sets the text of the axis title.</param>
    /// <param name="TitleFont">Sets the font of the axis title.</param>
    /// <param name="TitleStandoff">Sets the standoff distance (in px) between the axis labels and the title text.</param>
    /// <param name="Title">Sets the Title (use this for more finegrained control than the other title-associated arguments)</param>
    /// <param name="Color">Sets default for all colors associated with this axis all at once: line, font, tick, and grid colors.</param>
    /// <param name="AxisType">Sets the axis type. By default, plotly attempts to determined the axis type by looking into the data of the traces that referenced the axis in question.</param>
    /// <param name="MinMax">Tuple of (Min*Max value). Sets the range of this axis (the axis will go from Min to Max). If the axis `type` is "log", then you must take the log of your desired range (e.g. to set the range from 1 to 100, set the range from 0 to 2).</param>
    /// <param name="Mirror">Determines if and how the axis lines or/and ticks are mirrored to the opposite side of the plotting area.</param>
    /// <param name="ShowSpikes">Determines whether or not spikes (aka droplines) are drawn for this axis.</param>
    /// <param name="SpikeColor">Sets the spike color. If not set, will use the series color</param>
    /// <param name="SpikeThickness">Sets the width (in px) of the zero line.</param>
    /// <param name="ShowLine">Determines whether or not a line bounding this axis is drawn.</param>
    /// <param name="LineColor">Sets the axis line color.</param>
    /// <param name="ShowGrid">Determines whether or not grid lines are drawn. If "true", the grid lines are drawn at every tick mark.</param>
    /// <param name="GridColor">Sets the color of the grid lines.</param>
    /// <param name="ZeroLine">Determines whether or not a line is drawn at along the 0 value of this axis. If "true", the zero line is drawn on top of the grid lines.</param>
    /// <param name="ZeroLineColor">Sets the line color of the zero line.</param>
    /// <param name="Anchor">If set to an opposite-letter axis id (e.g. `x2`, `y`), this axis is bound to the corresponding opposite-letter axis. If set to "free", this axis' position is determined by `position`.</param>
    /// <param name="Side">Determines whether a x (y) axis is positioned at the "bottom" ("left") or "top" ("right") of the plotting area.</param>
    /// <param name="Overlaying">If set a same-letter axis id, this axis is overlaid on top of the corresponding same-letter axis, with traces and axes visible for both axes. If "false", this axis does not overlay any same-letter axes. In this case, for axes with overlapping domains only the highest-numbered axis will be visible.</param>
    /// <param name="Domain">Tuple of (X*Y fractions). Sets the domain of this axis (in plot fraction).</param>
    /// <param name="Position">Sets the position of this axis in the plotting space (in normalized coordinates). Only has an effect if `anchor` is set to "free".</param>
    /// <param name="CategoryOrder">Specifies the ordering logic for the case of categorical variables. By default, plotly uses "trace", which specifies the order that is present in the data supplied. Set `categoryorder` to "category ascending" or "category descending" if order should be determined by the alphanumerical order of the category names. Set `categoryorder` to "array" to derive the ordering from the attribute `categoryarray`. If a category is not found in the `categoryarray` array, the sorting behavior for that attribute will be identical to the "trace" mode. The unspecified categories will follow the categories in `categoryarray`. Set `categoryorder` to "total ascending" or "total descending" if order should be determined by the numerical order of the values. Similarly, the order can be determined by the min, max, sum, mean or median of all the values.</param>
    /// <param name="CategoryArray">Sets the order in which categories on this axis appear. Only has an effect if `categoryorder` is set to "array". Used with `categoryorder`.</param>
    /// <param name="RangeSlider">Sets a range slider for this axis</param>
    /// <param name="RangeSelector">Sets a range selector for this axis. This object contains toggable presets for the rangeslider.</param>
    /// <param name="BackgroundColor">Sets the background color of this axis' wall. (Only has an effect on 3D scenes)</param>
    /// <param name="ShowBackground">Sets whether or not this axis' wall has a background color. (Only has an effect on 3D scenes)</param>
    /// <param name="Id">The target axis id on which the styles should be applied. Default is 1.</param>
    [<CompiledName("WithXAxisStyle")>]
    static member withXAxisStyle
        (
            [<Optional; DefaultParameterValue(null)>] ?TitleText: string,
            [<Optional; DefaultParameterValue(null)>] ?TitleFont: Font,
            [<Optional; DefaultParameterValue(null)>] ?TitleStandoff: int,
            [<Optional; DefaultParameterValue(null)>] ?Title: Title,
            [<Optional; DefaultParameterValue(null)>] ?Color: Color,
            [<Optional; DefaultParameterValue(null)>] ?AxisType: StyleParam.AxisType,
            [<Optional; DefaultParameterValue(null)>] ?MinMax: #IConvertible * #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?Mirror: StyleParam.Mirror,
            [<Optional; DefaultParameterValue(null)>] ?ShowSpikes: bool,
            [<Optional; DefaultParameterValue(null)>] ?SpikeColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?SpikeThickness: int,
            [<Optional; DefaultParameterValue(null)>] ?ShowLine: bool,
            [<Optional; DefaultParameterValue(null)>] ?LineColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?ShowGrid: bool,
            [<Optional; DefaultParameterValue(null)>] ?GridColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?ZeroLine: bool,
            [<Optional; DefaultParameterValue(null)>] ?ZeroLineColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?Anchor: StyleParam.LinearAxisId,
            [<Optional; DefaultParameterValue(null)>] ?Side: StyleParam.Side,
            [<Optional; DefaultParameterValue(null)>] ?Overlaying: StyleParam.LinearAxisId,
            [<Optional; DefaultParameterValue(null)>] ?Domain: float * float,
            [<Optional; DefaultParameterValue(null)>] ?Position: float,
            [<Optional; DefaultParameterValue(null)>] ?CategoryOrder: StyleParam.CategoryOrder,
            [<Optional; DefaultParameterValue(null)>] ?CategoryArray: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?RangeSlider: RangeSlider,
            [<Optional; DefaultParameterValue(null)>] ?RangeSelector: RangeSelector,
            [<Optional; DefaultParameterValue(null)>] ?BackgroundColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?ShowBackground: bool,
            [<Optional; DefaultParameterValue(null)>] ?Id: StyleParam.SubPlotId
        ) =
        let range =
            MinMax |> Option.map StyleParam.Range.ofMinMax

        let domain =
            Domain |> Option.map StyleParam.Range.ofMinMax

        let title =
            Title
            |> Option.defaultValue (Plotly.NET.Title())
            |> Plotly.NET.Title.style (?Text = TitleText, ?Font = TitleFont, ?Standoff = TitleStandoff)

        let xaxis =
            LinearAxis.init (
                Title = title,
                ?Range = range,
                ?Domain = domain,
                ?Color = Color,
                ?AxisType = AxisType,
                ?Mirror = Mirror,
                ?ShowSpikes = ShowSpikes,
                ?SpikeColor = SpikeColor,
                ?SpikeThickness = SpikeThickness,
                ?ShowLine = ShowLine,
                ?LineColor = LineColor,
                ?ShowGrid = ShowGrid,
                ?GridColor = GridColor,
                ?ZeroLine = ZeroLine,
                ?ZeroLineColor = ZeroLineColor,
                ?Anchor = Anchor,
                ?Side = Side,
                ?Overlaying = Overlaying,
                ?Position = Position,
                ?CategoryOrder = CategoryOrder,
                ?CategoryArray = CategoryArray,
                ?RangeSlider = RangeSlider,
                ?RangeSelector = RangeSelector,
                ?BackgroundColor = BackgroundColor,
                ?ShowBackground = ShowBackground

            )

        Chart.withXAxis (xaxis, ?Id = Id)

    [<Obsolete("Use withXAxisRangeSlider instead")>]
    [<CompiledName("WithX_AxisRangeSlider")>]
    static member withX_AxisRangeSlider(rangeSlider: RangeSlider, [<Optional; DefaultParameterValue(null)>] ?Id) =
        Chart.withXAxisRangeSlider (rangeSlider, ?Id = Id)

    /// Sets the range slider for the xAxis
    [<CompiledName("WithXAxisRangeSlider")>]
    static member withXAxisRangeSlider(rangeSlider: RangeSlider, [<Optional; DefaultParameterValue(null)>] ?Id) =
        let xaxis =
            LinearAxis.init (RangeSlider = rangeSlider)

        Chart.withXAxis (xaxis, ?Id = Id)

    /// <summary>
    /// Sets the given y axis on the input chart's layout, optionally passing a target axis id.
    ///
    /// If there is already an axis set at the given id, the axis objects are combined.
    /// </summary>
    /// <param name="yAxis">The y axis to set on the chart's layout</param>
    /// <param name="Id">The target axis id with which the axis should be set. Default is 1.</param>
    [<CompiledName("WithYAxis")>]
    static member withYAxis(yAxis: LinearAxis, [<Optional; DefaultParameterValue(null)>] ?Id: StyleParam.SubPlotId) =
        let id =
            defaultArg Id (StyleParam.SubPlotId.YAxis 1)

        fun (ch: GenericChart) ->
            ch |> Chart.setAxis (yAxis, id, SceneAxis = StyleParam.SubPlotId.YAxis 1, Combine = true)

    /// <summary>
    /// Sets the given y axis styles on the input chart's layout.
    ///
    /// If there is already an axis set at the given id, the styles are applied to it. If there is no axis present, a new LinearAxis object with the given styles will be set.
    /// </summary>
    /// <param name="TitleText">Sets the text of the axis title.</param>
    /// <param name="TitleFont">Sets the font of the axis title.</param>
    /// <param name="TitleStandoff">Sets the standoff distance (in px) between the axis labels and the title text.</param>
    /// <param name="Title">Sets the Title (use this for more finegrained control than the other title-associated arguments)</param>
    /// <param name="Color">Sets default for all colors associated with this axis all at once: line, font, tick, and grid colors.</param>
    /// <param name="AxisType">Sets the axis type. By default, plotly attempts to determined the axis type by looking into the data of the traces that referenced the axis in question.</param>
    /// <param name="MinMax">Tuple of (Min*Max value). Sets the range of this axis (the axis will go from Min to Max). If the axis `type` is "log", then you must take the log of your desired range (e.g. to set the range from 1 to 100, set the range from 0 to 2).</param>
    /// <param name="Mirror">Determines if and how the axis lines or/and ticks are mirrored to the opposite side of the plotting area.</param>
    /// <param name="ShowSpikes">Determines whether or not spikes (aka droplines) are drawn for this axis.</param>
    /// <param name="SpikeColor">Sets the spike color. If not set, will use the series color</param>
    /// <param name="SpikeThickness">Sets the width (in px) of the zero line.</param>
    /// <param name="ShowLine">Determines whether or not a line bounding this axis is drawn.</param>
    /// <param name="LineColor">Sets the axis line color.</param>
    /// <param name="ShowGrid">Determines whether or not grid lines are drawn. If "true", the grid lines are drawn at every tick mark.</param>
    /// <param name="GridColor">Sets the color of the grid lines.</param>
    /// <param name="ZeroLine">Determines whether or not a line is drawn at along the 0 value of this axis. If "true", the zero line is drawn on top of the grid lines.</param>
    /// <param name="ZeroLineColor">Sets the line color of the zero line.</param>
    /// <param name="Anchor">If set to an opposite-letter axis id (e.g. `x2`, `y`), this axis is bound to the corresponding opposite-letter axis. If set to "free", this axis' position is determined by `position`.</param>
    /// <param name="Side">Determines whether a x (y) axis is positioned at the "bottom" ("left") or "top" ("right") of the plotting area.</param>
    /// <param name="Overlaying">If set a same-letter axis id, this axis is overlaid on top of the corresponding same-letter axis, with traces and axes visible for both axes. If "false", this axis does not overlay any same-letter axes. In this case, for axes with overlapping domains only the highest-numbered axis will be visible.</param>
    /// <param name="Domain">Tuple of (X*Y fractions). Sets the domain of this axis (in plot fraction).</param>
    /// <param name="Position">Sets the position of this axis in the plotting space (in normalized coordinates). Only has an effect if `anchor` is set to "free".</param>
    /// <param name="CategoryOrder">Specifies the ordering logic for the case of categorical variables. By default, plotly uses "trace", which specifies the order that is present in the data supplied. Set `categoryorder` to "category ascending" or "category descending" if order should be determined by the alphanumerical order of the category names. Set `categoryorder` to "array" to derive the ordering from the attribute `categoryarray`. If a category is not found in the `categoryarray` array, the sorting behavior for that attribute will be identical to the "trace" mode. The unspecified categories will follow the categories in `categoryarray`. Set `categoryorder` to "total ascending" or "total descending" if order should be determined by the numerical order of the values. Similarly, the order can be determined by the min, max, sum, mean or median of all the values.</param>
    /// <param name="CategoryArray">Sets the order in which categories on this axis appear. Only has an effect if `categoryorder` is set to "array". Used with `categoryorder`.</param>
    /// <param name="RangeSlider">Sets a range slider for this axis</param>
    /// <param name="RangeSelector">Sets a range selector for this axis. This object contains toggable presets for the rangeslider.</param>
    /// <param name="BackgroundColor">Sets the background color of this axis' wall. (Only has an effect on 3D scenes)</param>
    /// <param name="ShowBackground">Sets whether or not this axis' wall has a background color. (Only has an effect on 3D scenes)</param>
    /// <param name="Id">The target axis id on which the styles should be applied. Default is 1.</param>
    [<CompiledName("WithYAxisStyle")>]
    static member withYAxisStyle
        (
            [<Optional; DefaultParameterValue(null)>] ?TitleText: string,
            [<Optional; DefaultParameterValue(null)>] ?TitleFont: Font,
            [<Optional; DefaultParameterValue(null)>] ?TitleStandoff: int,
            [<Optional; DefaultParameterValue(null)>] ?Title: Title,
            [<Optional; DefaultParameterValue(null)>] ?Color: Color,
            [<Optional; DefaultParameterValue(null)>] ?AxisType: StyleParam.AxisType,
            [<Optional; DefaultParameterValue(null)>] ?MinMax: #IConvertible * #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?Mirror: StyleParam.Mirror,
            [<Optional; DefaultParameterValue(null)>] ?ShowSpikes: bool,
            [<Optional; DefaultParameterValue(null)>] ?SpikeColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?SpikeThickness: int,
            [<Optional; DefaultParameterValue(null)>] ?ShowLine: bool,
            [<Optional; DefaultParameterValue(null)>] ?LineColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?ShowGrid: bool,
            [<Optional; DefaultParameterValue(null)>] ?GridColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?ZeroLine: bool,
            [<Optional; DefaultParameterValue(null)>] ?ZeroLineColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?Anchor: StyleParam.LinearAxisId,
            [<Optional; DefaultParameterValue(null)>] ?Side: StyleParam.Side,
            [<Optional; DefaultParameterValue(null)>] ?Overlaying: StyleParam.LinearAxisId,
            [<Optional; DefaultParameterValue(null)>] ?Domain: float * float,
            [<Optional; DefaultParameterValue(null)>] ?Position: float,
            [<Optional; DefaultParameterValue(null)>] ?CategoryOrder: StyleParam.CategoryOrder,
            [<Optional; DefaultParameterValue(null)>] ?CategoryArray: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?RangeSlider: RangeSlider,
            [<Optional; DefaultParameterValue(null)>] ?RangeSelector: RangeSelector,
            [<Optional; DefaultParameterValue(null)>] ?BackgroundColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?ShowBackground: bool,
            [<Optional; DefaultParameterValue(null)>] ?Id: StyleParam.SubPlotId
        ) =
        let range =
            MinMax |> Option.map StyleParam.Range.ofMinMax

        let domain =
            Domain |> Option.map StyleParam.Range.ofMinMax

        let title =
            Title
            |> Option.defaultValue (Plotly.NET.Title())
            |> Plotly.NET.Title.style (?Text = TitleText, ?Font = TitleFont, ?Standoff = TitleStandoff)

        let yaxis =
            LinearAxis.init (
                Title = title,
                ?Range = range,
                ?Domain = domain,
                ?Color = Color,
                ?AxisType = AxisType,
                ?Mirror = Mirror,
                ?ShowSpikes = ShowSpikes,
                ?SpikeColor = SpikeColor,
                ?SpikeThickness = SpikeThickness,
                ?ShowLine = ShowLine,
                ?LineColor = LineColor,
                ?ShowGrid = ShowGrid,
                ?GridColor = GridColor,
                ?ZeroLine = ZeroLine,
                ?ZeroLineColor = ZeroLineColor,
                ?Anchor = Anchor,
                ?Side = Side,
                ?Overlaying = Overlaying,
                ?Position = Position,
                ?CategoryOrder = CategoryOrder,
                ?CategoryArray = CategoryArray,
                ?RangeSlider = RangeSlider,
                ?RangeSelector = RangeSelector,
                ?BackgroundColor = BackgroundColor,
                ?ShowBackground = ShowBackground
            )

        Chart.withYAxis (yaxis, ?Id = Id)


    /// <summary>
    /// Sets the given z axis on the input chart's scene, optionally passing a scene axis id.
    ///
    /// If there is already an axis set at the given id, the axis objects are combined.
    /// </summary>
    /// <param name="zAxis">The z axis to set on the chart's layout</param>
    /// <param name="Id">The target scene id on which the axis should be set. Default is 1.</param>
    [<CompiledName("WithZAxis")>]
    static member withZAxis(zAxis: LinearAxis, [<Optional; DefaultParameterValue(null)>] ?Id: int) =
        let id =
            Id |> Option.defaultValue 1 |> StyleParam.SubPlotId.Scene

        fun (ch: GenericChart) ->
            ch |> Chart.setAxis (zAxis, id, SceneAxis = StyleParam.SubPlotId.ZAxis, Combine = true)

    /// <summary>
    /// Sets the given z axis styles on the input chart's scene.
    ///
    /// If there is already an axis set at the given id, the styles are applied to it. If there is no axis present, a new LinearAxis object with the given styles will be set.
    /// </summary>
    /// <param name="TitleText">Sets the text of the axis title.</param>
    /// <param name="TitleFont">Sets the font of the axis title.</param>
    /// <param name="TitleStandoff">Sets the standoff distance (in px) between the axis labels and the title text.</param>
    /// <param name="Title">Sets the Title (use this for more finegrained control than the other title-associated arguments)</param>
    /// <param name="Color">Sets default for all colors associated with this axis all at once: line, font, tick, and grid colors.</param>
    /// <param name="AxisType">Sets the axis type. By default, plotly attempts to determined the axis type by looking into the data of the traces that referenced the axis in question.</param>
    /// <param name="MinMax">Tuple of (Min*Max value). Sets the range of this axis (the axis will go from Min to Max). If the axis `type` is "log", then you must take the log of your desired range (e.g. to set the range from 1 to 100, set the range from 0 to 2).</param>
    /// <param name="Mirror">Determines if and how the axis lines or/and ticks are mirrored to the opposite side of the plotting area.</param>
    /// <param name="ShowSpikes">Determines whether or not spikes (aka droplines) are drawn for this axis.</param>
    /// <param name="SpikeColor">Sets the spike color. If not set, will use the series color</param>
    /// <param name="SpikeThickness">Sets the width (in px) of the zero line.</param>
    /// <param name="ShowLine">Determines whether or not a line bounding this axis is drawn.</param>
    /// <param name="LineColor">Sets the axis line color.</param>
    /// <param name="ShowGrid">Determines whether or not grid lines are drawn. If "true", the grid lines are drawn at every tick mark.</param>
    /// <param name="GridColor">Sets the color of the grid lines.</param>
    /// <param name="ZeroLine">Determines whether or not a line is drawn at along the 0 value of this axis. If "true", the zero line is drawn on top of the grid lines.</param>
    /// <param name="ZeroLineColor">Sets the line color of the zero line.</param>
    /// <param name="Anchor">If set to an opposite-letter axis id (e.g. `x2`, `y`), this axis is bound to the corresponding opposite-letter axis. If set to "free", this axis' position is determined by `position`.</param>
    /// <param name="Side">Determines whether a x (y) axis is positioned at the "bottom" ("left") or "top" ("right") of the plotting area.</param>
    /// <param name="Overlaying">If set a same-letter axis id, this axis is overlaid on top of the corresponding same-letter axis, with traces and axes visible for both axes. If "false", this axis does not overlay any same-letter axes. In this case, for axes with overlapping domains only the highest-numbered axis will be visible.</param>
    /// <param name="Domain">Tuple of (X*Y fractions). Sets the domain of this axis (in plot fraction).</param>
    /// <param name="Position">Sets the position of this axis in the plotting space (in normalized coordinates). Only has an effect if `anchor` is set to "free".</param>
    /// <param name="CategoryOrder">Specifies the ordering logic for the case of categorical variables. By default, plotly uses "trace", which specifies the order that is present in the data supplied. Set `categoryorder` to "category ascending" or "category descending" if order should be determined by the alphanumerical order of the category names. Set `categoryorder` to "array" to derive the ordering from the attribute `categoryarray`. If a category is not found in the `categoryarray` array, the sorting behavior for that attribute will be identical to the "trace" mode. The unspecified categories will follow the categories in `categoryarray`. Set `categoryorder` to "total ascending" or "total descending" if order should be determined by the numerical order of the values. Similarly, the order can be determined by the min, max, sum, mean or median of all the values.</param>
    /// <param name="CategoryArray">Sets the order in which categories on this axis appear. Only has an effect if `categoryorder` is set to "array". Used with `categoryorder`.</param>
    /// <param name="RangeSlider">Sets a range slider for this axis</param>
    /// <param name="RangeSelector">Sets a range selector for this axis. This object contains toggable presets for the rangeslider.</param>
    /// <param name="BackgroundColor">Sets the background color of this axis' wall. (Only has an effect on 3D scenes)</param>
    /// <param name="ShowBackground">Sets whether or not this axis' wall has a background color. (Only has an effect on 3D scenes)</param>
    /// <param name="Id">The target scene id on which the axis styles should be applied. Default is 1.</param>
    [<CompiledName("WithZAxisStyle")>]
    static member withZAxisStyle
        (
            [<Optional; DefaultParameterValue(null)>] ?TitleText: string,
            [<Optional; DefaultParameterValue(null)>] ?TitleFont: Font,
            [<Optional; DefaultParameterValue(null)>] ?TitleStandoff: int,
            [<Optional; DefaultParameterValue(null)>] ?Title: Title,
            [<Optional; DefaultParameterValue(null)>] ?Color: Color,
            [<Optional; DefaultParameterValue(null)>] ?AxisType: StyleParam.AxisType,
            [<Optional; DefaultParameterValue(null)>] ?MinMax: #IConvertible * #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?Mirror: StyleParam.Mirror,
            [<Optional; DefaultParameterValue(null)>] ?ShowSpikes: bool,
            [<Optional; DefaultParameterValue(null)>] ?SpikeColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?SpikeThickness: int,
            [<Optional; DefaultParameterValue(null)>] ?ShowLine: bool,
            [<Optional; DefaultParameterValue(null)>] ?LineColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?ShowGrid: bool,
            [<Optional; DefaultParameterValue(null)>] ?GridColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?ZeroLine: bool,
            [<Optional; DefaultParameterValue(null)>] ?ZeroLineColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?Anchor: StyleParam.LinearAxisId,
            [<Optional; DefaultParameterValue(null)>] ?Side: StyleParam.Side,
            [<Optional; DefaultParameterValue(null)>] ?Overlaying: StyleParam.LinearAxisId,
            [<Optional; DefaultParameterValue(null)>] ?Domain: float * float,
            [<Optional; DefaultParameterValue(null)>] ?Position: float,
            [<Optional; DefaultParameterValue(null)>] ?CategoryOrder: StyleParam.CategoryOrder,
            [<Optional; DefaultParameterValue(null)>] ?CategoryArray: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?RangeSlider: RangeSlider,
            [<Optional; DefaultParameterValue(null)>] ?RangeSelector: RangeSelector,
            [<Optional; DefaultParameterValue(null)>] ?BackgroundColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?ShowBackground: bool,
            [<Optional; DefaultParameterValue(null)>] ?Id: int
        ) =
        let range =
            MinMax |> Option.map StyleParam.Range.ofMinMax

        let domain =
            Domain |> Option.map StyleParam.Range.ofMinMax

        let title =
            Title
            |> Option.defaultValue (Plotly.NET.Title())
            |> Plotly.NET.Title.style (?Text = TitleText, ?Font = TitleFont, ?Standoff = TitleStandoff)

        let yaxis =
            LinearAxis.init (
                Title = title,
                ?Range = range,
                ?Domain = domain,
                ?Color = Color,
                ?AxisType = AxisType,
                ?Mirror = Mirror,
                ?ShowSpikes = ShowSpikes,
                ?SpikeColor = SpikeColor,
                ?SpikeThickness = SpikeThickness,
                ?ShowLine = ShowLine,
                ?LineColor = LineColor,
                ?ShowGrid = ShowGrid,
                ?GridColor = GridColor,
                ?ZeroLine = ZeroLine,
                ?ZeroLineColor = ZeroLineColor,
                ?Anchor = Anchor,
                ?Side = Side,
                ?Overlaying = Overlaying,
                ?Position = Position,
                ?CategoryOrder = CategoryOrder,
                ?CategoryArray = CategoryArray,
                ?RangeSlider = RangeSlider,
                ?RangeSelector = RangeSelector,
                ?BackgroundColor = BackgroundColor,
                ?ShowBackground = ShowBackground

            )

        Chart.withZAxis (yaxis, ?Id = Id)

    /// <summary>
    /// Sets the given Scene object with the given id on the input chart's layout.
    /// </summary>
    /// <param name="scene">The Scene object to set on the chart's layout</param>
    /// <param name="id">The target scene id with which the Scene object should be set.</param>
    /// <param name="Combine">Wether or not to combine the objects if there is already an Scene set (default is false)</param>
    [<CompiledName("SetScene")>]
    static member setScene
        (
            scene: Scene,
            id: StyleParam.SubPlotId,
            [<Optional; DefaultParameterValue(null)>] ?Combine: bool
        ) =

        let combine = defaultArg Combine false

        (fun (ch: GenericChart) ->
            if combine then
                ch |> GenericChart.mapLayout (Layout.updateSceneById (id, scene))
            else
                ch |> GenericChart.mapLayout (Layout.setScene (id, scene)))

    /// <summary>
    /// Sets the Scene for the chart's layout
    ///
    /// If there is already a Scene set, the objects are combined.
    /// </summary>
    /// <param name="scene">The Scene to set on the chart's layout</param>
    /// <param name="Id">The target scene id on which the scene should be set. Default is 1.</param>
    [<CompiledName("WithScene")>]
    static member withScene(scene: Scene, [<Optional; DefaultParameterValue(null)>] ?Id: int) =
        let id =
            Id |> Option.defaultValue 1 |> StyleParam.SubPlotId.Scene

        (fun (ch: GenericChart) -> ch |> Chart.setScene (scene, id, true))

    /// <summary>
    /// Sets the given Scene styles on the target Scene object on the input chart's layout.
    ///
    /// If there is already a Scene set, the styles are applied to it. If there is no Scene present, a new Scene object with the given styles will be set.
    /// </summary>
    /// <param name="Annotations">An annotation is a text element that can be placed anywhere in the plot. It can be positioned with respect to relative coordinates in the plot or with respect to the actual data coordinates of the graph. Annotations can be shown with or without an arrow.</param>
    /// <param name="AspectMode">If "cube", this scene's axes are drawn as a cube, regardless of the axes' ranges. If "data", this scene's axes are drawn in proportion with the axes' ranges. If "manual", this scene's axes are drawn in proportion with the input of "aspectratio" (the default behavior if "aspectratio" is provided). If "auto", this scene's axes are drawn using the results of "data" except when one axis is more than four times the size of the two others, where in that case the results of "cube" are used.</param>
    /// <param name="AspectRatio">Sets this scene's axis aspectratio.</param>
    /// <param name="BGColor">Sets this scene's background color.</param>
    /// <param name="Camera">Sets this scene's camera</param>
    /// <param name="Domain">Sets this scene's domain</param>
    /// <param name="DragMode">Determines the mode of drag interactions for this scene.</param>
    /// <param name="HoverMode">Determines the mode of hover interactions for this scene.</param>
    /// <param name="UIRevision">Controls persistence of user-driven changes in camera attributes. Defaults to `layout.uirevision`.</param>
    /// <param name="XAxis">Sets this scene's xaxis</param>
    /// <param name="YAxis">Sets this scene's yaxis</param>
    /// <param name="ZAxis">Sets this scene's zaxis</param>
    /// <param name="Id">The target scene id</param>
    [<CompiledName("WithSceneStyle")>]
    static member withSceneStyle
        (
            [<Optional; DefaultParameterValue(null)>] ?Annotations: seq<Annotation>,
            [<Optional; DefaultParameterValue(null)>] ?AspectMode: StyleParam.AspectMode,
            [<Optional; DefaultParameterValue(null)>] ?AspectRatio: AspectRatio,
            [<Optional; DefaultParameterValue(null)>] ?BGColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?Camera: Camera,
            [<Optional; DefaultParameterValue(null)>] ?Domain: Domain,
            [<Optional; DefaultParameterValue(null)>] ?DragMode: StyleParam.DragMode,
            [<Optional; DefaultParameterValue(null)>] ?HoverMode: StyleParam.HoverMode,
            [<Optional; DefaultParameterValue(null)>] ?UIRevision: string,
            [<Optional; DefaultParameterValue(null)>] ?XAxis: LinearAxis,
            [<Optional; DefaultParameterValue(null)>] ?YAxis: LinearAxis,
            [<Optional; DefaultParameterValue(null)>] ?ZAxis: LinearAxis,
            [<Optional; DefaultParameterValue(null)>] ?Id: int
        ) =
        (fun (ch: GenericChart) ->
            let scene =
                Scene.init (
                    ?Annotations = Annotations,
                    ?AspectMode = AspectMode,
                    ?AspectRatio = AspectRatio,
                    ?BGColor = BGColor,
                    ?Camera = Camera,
                    ?Domain = Domain,
                    ?DragMode = DragMode,
                    ?HoverMode = HoverMode,
                    ?UIRevision = UIRevision,
                    ?XAxis = XAxis,
                    ?YAxis = YAxis,
                    ?ZAxis = ZAxis
                )

            ch |> Chart.withScene (scene, ?Id = Id))

    /// <summary>
    /// Sets the given Polar object with the given id on the input chart's layout.
    /// </summary>
    /// <param name="polar">The Polar object to set on the chart's layout</param>
    /// <param name="id">The target polar id with which the Polar object should be set.</param>
    /// <param name="Combine">Wether or not to combine the objects if there is already an Polar set (default is false)</param>
    [<CompiledName("SetPolar")>]
    static member setPolar
        (
            polar: Polar,
            id: StyleParam.SubPlotId,
            [<Optional; DefaultParameterValue(null)>] ?Combine: bool
        ) =

        let combine = defaultArg Combine false

        (fun (ch: GenericChart) ->
            if combine then
                ch |> GenericChart.mapLayout (Layout.updatePolarById (id, polar))
            else
                ch |> GenericChart.mapLayout (Layout.setPolar (id, polar)))

    /// <summary>
    /// Sets the Polar for the chart's layout
    ///
    /// If there is already a Polar set, the objects are combined.
    /// </summary>
    /// <param name="polar">The new Polar for the chart's layout</param>
    /// <param name="Id">The target polar id on which the polar object should be set. Default is 1.</param>
    [<CompiledName("WithPolar")>]
    static member withPolar(polar: Polar, [<Optional; DefaultParameterValue(null)>] ?Id: int) =
        let id =
            Id |> Option.defaultValue 1 |> StyleParam.SubPlotId.Polar

        (fun (ch: GenericChart) -> ch |> Chart.setPolar (polar, id, true))

    /// <summary>
    /// Sets the given Polar styles on the target Polar object on the input chart's layout.
    ///
    /// If there is already a Polar set, the styles are applied to it. If there is no Polar present, a new Polar object with the given styles will be set.
    /// </summary>
    /// <param name="Domain">Sets the domain of this polar subplot</param>
    /// <param name="Sector">Sets angular span of this polar subplot with two angles (in degrees). Sector are assumed to be spanned in the counterclockwise direction with "0" corresponding to rightmost limit of the polar subplot.</param>
    /// <param name="Hole">Sets the fraction of the radius to cut out of the polar subplot.</param>
    /// <param name="BGColor">Set the background color of the subplot</param>
    /// <param name="RadialAxis">Sets the radial axis of the polar subplot.</param>
    /// <param name="AngularAxis">Sets the angular axis of the polar subplot.</param>
    /// <param name="GridShape">Determines if the radial axis grid lines and angular axis line are drawn as "circular" sectors or as "linear" (polygon) sectors. Has an effect only when the angular axis has `type` "category". Note that `radialaxis.angle` is snapped to the angle of the closest vertex when `gridshape` is "circular" (so that radial axis scale is the same as the data scale).</param>
    /// <param name="UIRevision">Controls persistence of user-driven changes in axis attributes, if not overridden in the individual axes. Defaults to `layout.uirevision`.</param>
    /// <param name="Id">The target polar id</param>
    [<CompiledName("WithPolarStyle")>]
    static member withPolarStyle
        (
            [<Optional; DefaultParameterValue(null)>] ?Domain: Domain,
            [<Optional; DefaultParameterValue(null)>] ?Sector: float * float,
            [<Optional; DefaultParameterValue(null)>] ?Hole: float,
            [<Optional; DefaultParameterValue(null)>] ?BGColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?RadialAxis: RadialAxis,
            [<Optional; DefaultParameterValue(null)>] ?AngularAxis: AngularAxis,
            [<Optional; DefaultParameterValue(null)>] ?GridShape: StyleParam.PolarGridShape,
            [<Optional; DefaultParameterValue(null)>] ?UIRevision: string,
            [<Optional; DefaultParameterValue(null)>] ?Id: int
        ) =
        (fun (ch: GenericChart) ->
            let polar =
                Polar.init (
                    ?Domain = Domain,
                    ?Sector = Sector,
                    ?Hole = Hole,
                    ?BGColor = BGColor,
                    ?RadialAxis = RadialAxis,
                    ?AngularAxis = AngularAxis,
                    ?GridShape = GridShape,
                    ?UIRevision = UIRevision
                )

            ch |> Chart.withPolar (polar, ?Id = Id))

    /// <summary>
    /// Sets the angular axis on the polar object with the given id on the input chart's layout.
    /// </summary>
    /// <param name="angularAxis">The AngularAxis to set on the target polar object on the chart's layout</param>
    /// <param name="id">The target polar id with which the AngularAxis should be set.(default is 1)</param>
    /// <param name="Combine">Wether or not to combine the objects if there is already an axis set (default is false)</param>
    [<CompiledName("SetAngularAxis")>]
    static member setAngularAxis
        (
            angularAxis: AngularAxis,
            id: StyleParam.SubPlotId,
            [<Optional; DefaultParameterValue(null)>] ?Combine: bool
        ) =

        fun (ch: GenericChart) ->

            let combine = defaultArg Combine false

            match id with
            | StyleParam.SubPlotId.Polar _ ->

                ch
                |> GenericChart.mapLayout
                    (fun layout ->
                        let polar = layout |> Layout.getPolarById id

                        if combine then
                            let currentAxis = polar |> Polar.getAngularAxis

                            let updatedAxis =
                                (DynObj.combine currentAxis angularAxis) :?> AngularAxis

                            let updatedPolar =
                                polar |> Polar.setAngularAxis updatedAxis

                            layout |> Layout.updatePolarById (id, updatedPolar)

                        else
                            let updatedPolar =
                                layout |> Layout.getPolarById id |> Polar.setAngularAxis angularAxis

                            layout |> Layout.updatePolarById (id, updatedPolar))

            | _ -> failwith $"{StyleParam.SubPlotId.toString id} is an invalid subplot id for setting an angular axis"

    /// <summary>
    /// Sets the AngularAxis on the polar object with the given id on the input chart's layout.
    ///
    /// If there is already a AngularAxis set on the polar object, the AngularAxis objects are combined.
    /// </summary>
    /// <param name="angularAxis">The new AngularAxis for the chart layout's polar object</param>
    /// <param name="Id">The target polar id on which the AngularAxis should be set. Default is 1.</param>
    [<CompiledName("WithAngularAxis")>]
    static member withAngularAxis(angularAxis: AngularAxis, [<Optional; DefaultParameterValue(null)>] ?Id: int) =
        let id =
            Id |> Option.defaultValue 1 |> StyleParam.SubPlotId.Polar

        (fun (ch: GenericChart) -> ch |> Chart.setAngularAxis (angularAxis, id, true))

    /// <summary>
    /// Sets the RadialAxis on the polar object with the given id on the input chart's layout.
    /// </summary>
    /// <param name="radialAxis">The RadialAxis to set on the target polar object on the chart's layout</param>
    /// <param name="id">The target polar id with which the RadialAxis should be set.(default is 1)</param>
    /// <param name="Combine">Wether or not to combine the objects if there is already an axis set (default is false)</param>
    [<CompiledName("SetRadialAxis")>]
    static member setRadialAxis
        (
            radialAxis: RadialAxis,
            id: StyleParam.SubPlotId,
            [<Optional; DefaultParameterValue(null)>] ?Combine: bool
        ) =

        fun (ch: GenericChart) ->

            let combine = defaultArg Combine false

            match id with
            | StyleParam.SubPlotId.Polar _ ->

                ch
                |> GenericChart.mapLayout
                    (fun layout ->
                        let polar = layout |> Layout.getPolarById id

                        if combine then
                            let currentAxis = polar |> Polar.getRadialAxis

                            let updatedAxis =
                                (DynObj.combine currentAxis radialAxis) :?> RadialAxis

                            let updatedPolar = polar |> Polar.setRadialAxis updatedAxis

                            layout |> Layout.updatePolarById (id, updatedPolar)

                        else
                            let updatedPolar =
                                layout |> Layout.getPolarById id |> Polar.setRadialAxis radialAxis

                            layout |> Layout.updatePolarById (id, updatedPolar))

            | _ -> failwith $"{StyleParam.SubPlotId.toString id} is an invalid subplot id for setting an radial axis"

    /// <summary>
    /// Sets the RadialAxis on the polar object with the given id on the input chart's layout.
    ///
    /// If there is already a RadialAxis set on the polar object, the RadialAxis objects are combined.
    /// </summary>
    /// <param name="radialAxis">The new RadialAxis for the chart layout's polar object</param>
    /// <param name="Id">The target polar id on which the RadialAxis should be set. Default is 1.</param>
    [<CompiledName("WithRadialAxis")>]
    static member withRadialAxis(radialAxis: RadialAxis, [<Optional; DefaultParameterValue(null)>] ?Id: int) =
        let id =
            Id |> Option.defaultValue 1 |> StyleParam.SubPlotId.Polar

        (fun (ch: GenericChart) -> ch |> Chart.setRadialAxis (radialAxis, id, true))

    /// <summary>
    /// Sets the given Geo object with the given id on the input chart's layout.
    /// </summary>
    /// <param name="geo">The Geo object to set on the chart's layout</param>
    /// <param name="id">The target Geo id with which the Geo object should be set.</param>
    /// <param name="Combine">Wether or not to combine the objects if there is already an Geo set (default is false)</param>
    [<CompiledName("SetGeo")>]
    static member setGeo(geo: Geo, id: StyleParam.SubPlotId, [<Optional; DefaultParameterValue(null)>] ?Combine: bool) =

        let combine = defaultArg Combine false

        (fun (ch: GenericChart) ->
            if combine then
                ch |> GenericChart.mapLayout (Layout.updateGeoById (id, geo))
            else
                ch |> GenericChart.mapLayout (Layout.setGeo (id, geo)))

    /// <summary>
    /// Sets the Geo for the chart's layout
    ///
    /// If there is already a Geo set, the objects are combined.
    /// </summary>
    /// <param name="geo">The new Geo for the chart's layout</param>
    /// <param name="Id">The target geo id on which the Geo should be set. Default is 1.</param>
    [<CompiledName("WithGeo")>]
    static member withGeo(geo: Geo, [<Optional; DefaultParameterValue(null)>] ?Id: int) =
        let id =
            Id |> Option.defaultValue 1 |> StyleParam.SubPlotId.Geo

        (fun (ch: GenericChart) -> ch |> Chart.setGeo (geo, id, true))

    /// <summary>
    /// Sets the given Geo styles on the target geo on the input chart's layout.
    ///
    /// If there is already a Geo set, the styles are applied to it. If there is no Geo present, a new Geo object with the given styles will be set.
    /// </summary>
    /// <param name="FitBounds">Determines if and how this subplot's view settings are auto-computed to fit trace data</param>
    /// <param name="Resolution">Sets the resolution of the base layers</param>
    /// <param name="Scope">Set the scope of the map.</param>
    /// <param name="Projection">Determines the type of projection used to display the map</param>
    /// <param name="Center">Sets the (lon,lat) coordinates of the map's center. By default, the map's longitude center lies at the middle of the longitude range for scoped projection and above `projection.rotation.lon` otherwise. For all projection types, the map's latitude center lies at the middle of the latitude range by default.</param>
    /// <param name="Visible">Wether or not the base layers are visible</param>
    /// <param name="Domain">The domain of this geo subplot</param>
    /// <param name="ShowCoastLines">Sets whether or not the coastlines are drawn.</param>
    /// <param name="CoastLineColor">Sets the coastline color.</param>
    /// <param name="CoastLineWidth">Sets the coastline stroke width (in px).</param>
    /// <param name="ShowLand">Sets whether or not land masses are filled in color.</param>
    /// <param name="LandColor">Sets the land mass color.</param>
    /// <param name="ShowOcean">Sets whether or not oceans are filled in color.</param>
    /// <param name="OceanColor">Sets the ocean color</param>
    /// <param name="ShowLakes">Sets whether or not lakes are drawn.</param>
    /// <param name="LakeColor">Sets the color of the lakes.</param>
    /// <param name="ShowRivers">Sets whether or not rivers are drawn.</param>
    /// <param name="RiverColor">Sets color of the rivers.</param>
    /// <param name="RiverWidth">Sets the stroke width (in px) of the rivers.</param>
    /// <param name="ShowCountries">Sets whether or not country boundaries are drawn.</param>
    /// <param name="CountryColor">Sets line color of the country boundaries.</param>
    /// <param name="CountryWidth">Sets line width (in px) of the country boundaries.</param>
    /// <param name="ShowSubunits">Sets whether or not boundaries of subunits within countries (e.g. states, provinces) are drawn.</param>
    /// <param name="SubunitColor">Sets the color of the subunits boundaries.</param>
    /// <param name="SubunitWidth">Sets the stroke width (in px) of the subunits boundaries.</param>
    /// <param name="ShowFrame">Sets whether or not a frame is drawn around the map.</param>
    /// <param name="FrameColor">Sets the color the frame.</param>
    /// <param name="FrameWidth">Sets the stroke width (in px) of the frame.</param>
    /// <param name="BgColor">Set the background color of the map</param>
    /// <param name="LatAxis">Sets the latitudinal axis for this geo trace</param>
    /// <param name="LonAxis">Sets the longitudinal axis for this geo trace</param>
    /// <param name="Id">the target geo id</param>
    [<CompiledName("WithGeoStyle")>]
    static member withGeoStyle
        (
            [<Optional; DefaultParameterValue(null)>] ?FitBounds: StyleParam.GeoFitBounds,
            [<Optional; DefaultParameterValue(null)>] ?Resolution: StyleParam.GeoResolution,
            [<Optional; DefaultParameterValue(null)>] ?Scope: StyleParam.GeoScope,
            [<Optional; DefaultParameterValue(null)>] ?Projection: GeoProjection,
            [<Optional; DefaultParameterValue(null)>] ?Center: (float * float),
            [<Optional; DefaultParameterValue(null)>] ?Visible: bool,
            [<Optional; DefaultParameterValue(null)>] ?Domain: Domain,
            [<Optional; DefaultParameterValue(null)>] ?ShowCoastLines: bool,
            [<Optional; DefaultParameterValue(null)>] ?CoastLineColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?CoastLineWidth: float,
            [<Optional; DefaultParameterValue(null)>] ?ShowLand: bool,
            [<Optional; DefaultParameterValue(null)>] ?LandColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?ShowOcean: bool,
            [<Optional; DefaultParameterValue(null)>] ?OceanColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?ShowLakes: bool,
            [<Optional; DefaultParameterValue(null)>] ?LakeColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?ShowRivers: bool,
            [<Optional; DefaultParameterValue(null)>] ?RiverColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?RiverWidth: float,
            [<Optional; DefaultParameterValue(null)>] ?ShowCountries: bool,
            [<Optional; DefaultParameterValue(null)>] ?CountryColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?CountryWidth: float,
            [<Optional; DefaultParameterValue(null)>] ?ShowSubunits: bool,
            [<Optional; DefaultParameterValue(null)>] ?SubunitColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?SubunitWidth: float,
            [<Optional; DefaultParameterValue(null)>] ?ShowFrame: bool,
            [<Optional; DefaultParameterValue(null)>] ?FrameColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?FrameWidth: float,
            [<Optional; DefaultParameterValue(null)>] ?BgColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?LatAxis: LinearAxis,
            [<Optional; DefaultParameterValue(null)>] ?LonAxis: LinearAxis,
            [<Optional; DefaultParameterValue(null)>] ?Id: int
        ) =
        (fun (ch: GenericChart) ->
            let geo =
                Geo.init (
                    ?FitBounds = FitBounds,
                    ?Resolution = Resolution,
                    ?Scope = Scope,
                    ?Projection = Projection,
                    ?Center = Center,
                    ?Visible = Visible,
                    ?Domain = Domain,
                    ?ShowCoastLines = ShowCoastLines,
                    ?CoastLineColor = CoastLineColor,
                    ?CoastLineWidth = CoastLineWidth,
                    ?ShowLand = ShowLand,
                    ?LandColor = LandColor,
                    ?ShowOcean = ShowOcean,
                    ?OceanColor = OceanColor,
                    ?ShowLakes = ShowLakes,
                    ?LakeColor = LakeColor,
                    ?ShowRivers = ShowRivers,
                    ?RiverColor = RiverColor,
                    ?RiverWidth = RiverWidth,
                    ?ShowCountries = ShowCountries,
                    ?CountryColor = CountryColor,
                    ?CountryWidth = CountryWidth,
                    ?ShowSubunits = ShowSubunits,
                    ?SubunitColor = SubunitColor,
                    ?SubunitWidth = SubunitWidth,
                    ?ShowFrame = ShowFrame,
                    ?FrameColor = FrameColor,
                    ?FrameWidth = FrameWidth,
                    ?BgColor = BgColor,
                    ?LatAxis = LatAxis,
                    ?LonAxis = LonAxis
                )

            ch |> Chart.withGeo (geo, ?Id = Id))

    /// <summary>
    /// Sets the given Geo Projection styles on the target geo on the input chart's layout.
    ///
    /// If there is already a Geo set, the styles are applied to it. If there is no Geo present, a new Geo object with the given styles will be set.
    /// </summary>
    /// <param name="projectionType">Sets the type of projection</param>
    /// <param name="Rotation">Sets the rotation applied to the map</param>
    /// <param name="Parallels">For conic projection types only. Sets the parallels (tangent, secant) where the cone intersects the sphere.</param>
    /// <param name="Scale">Zooms in or out on the map view. A scale of "1" corresponds to the largest zoom level that fits the map's lon and lat ranges.</param>
    /// <param name="Id">the target geo id</param>
    [<CompiledName("WithGeoProjection")>]
    static member withGeoProjection
        (
            projectionType: StyleParam.GeoProjectionType,
            [<Optional; DefaultParameterValue(null)>] ?Rotation,
            [<Optional; DefaultParameterValue(null)>] ?Parallels,
            [<Optional; DefaultParameterValue(null)>] ?Scale,
            [<Optional; DefaultParameterValue(null)>] ?Id: int
        ) =
        (fun (ch: GenericChart) ->

            let projection =
                GeoProjection.init (
                    projectionType = projectionType,
                    ?Rotation = Rotation,
                    ?Parallels = Parallels,
                    ?Scale = Scale
                )

            let map = Geo.init (Projection = projection)

            ch |> Chart.withGeo (map, ?Id = Id))

    /// <summary>
    /// Sets the given Mapbox object with the given id on the input chart's layout.
    /// </summary>
    /// <param name="mapbox">The Mapbox object to set on the chart's layout</param>
    /// <param name="id">The target Mapbox id with which the Mapbox object should be set.</param>
    /// <param name="Combine">Wether or not to combine the objects if there is already an Mapbox set (default is false)</param>
    [<CompiledName("SetMapbox")>]
    static member setMapbox
        (
            mapbox: Mapbox,
            id: StyleParam.SubPlotId,
            [<Optional; DefaultParameterValue(null)>] ?Combine: bool
        ) =

        let combine = defaultArg Combine false

        (fun (ch: GenericChart) ->
            if combine then
                ch |> GenericChart.mapLayout (Layout.updateMapboxById (id, mapbox))
            else
                ch |> GenericChart.mapLayout (Layout.setMapbox (id, mapbox)))

    /// <summary>
    /// Sets the Mapbox for the chart's layout
    ///
    /// If there is already a Mapbox set, the objects are combined.
    /// </summary>
    /// <param name="mapbox">The Mapbox to set on the chart's layout</param>
    /// <param name="Id">The target mapbox id on which the Mapbox should be set. Default is 1.</param>
    [<CompiledName("WithMapbox")>]
    static member withMapbox(mapbox: Mapbox, [<Optional; DefaultParameterValue(null)>] ?Id: int) =
        let id =
            Id |> Option.defaultValue 1 |> StyleParam.SubPlotId.Mapbox

        (fun (ch: GenericChart) -> ch |> Chart.setMapbox (mapbox, id, true))

    /// <summary>
    /// Sets the given Mapbox styles on the target Mapbox object on the input chart's layout.
    ///
    /// If there is already a Mapbox set, the styles are applied to it. If there is no Mapbox present, a new Mapbox object with the given styles will be set.
    /// </summary>
    /// <param name="Domain">Sets the domain of the Mapbox subplot</param>
    /// <param name="AccessToken">Sets the mapbox access token to be used for this mapbox map. Alternatively, the mapbox access token can be set in the configuration options under `mapboxAccessToken`. Note that accessToken are only required when `style` (e.g with values : basic, streets, outdoors, light, dark, satellite, satellite-streets ) and/or a layout layer references the Mapbox server.</param>
    /// <param name="Style">Defines the map layers that are rendered by default below the trace layers defined in `data`, which are themselves by default rendered below the layers defined in `layout.mapbox.layers`. These layers can be defined either explicitly as a Mapbox Style object which can contain multiple layer definitions that load data from any public or private Tile Map Service (TMS or XYZ) or Web Map Service (WMS) or implicitly by using one of the built-in style objects which use WMSes which do not require any access tokens, or by using a default Mapbox style or custom Mapbox style URL, both of which require a Mapbox access token Note that Mapbox access token can be set in the `accesstoken` attribute or in the `mapboxAccessToken` config option. Mapbox Style objects are of the form described in the Mapbox GL JS documentation available at https://docs.mapbox.com/mapbox-gl-js/style-spec The built-in plotly.js styles objects are: carto-darkmatter, carto-positron, open-street-map, stamen-terrain, stamen-toner, stamen-watercolor, white-bg The built-in Mapbox styles are: basic, streets, outdoors, light, dark, satellite, satellite-streets Mapbox style URLs are of the form: mapbox://mapbox.mapbox/name/version</param>
    /// <param name="Center">Sets the (lon,lat) coordinates of the center of the map view</param>
    /// <param name="Zoom">Sets the zoom level of the map (mapbox.zoom).</param>
    /// <param name="Bearing">Sets the bearing angle of the map in degrees counter-clockwise from North (mapbox.bearing).</param>
    /// <param name="Pitch">Sets the pitch angle of the map (in degrees, where "0" means perpendicular to the surface of the map) (mapbox.pitch).</param>
    /// <param name="Layers">Sets the layers of this Mapbox</param>
    /// <param name="Id">The target mapbox id</param>
    static member withMapboxStyle
        (
            [<Optional; DefaultParameterValue(null)>] ?Domain: Domain,
            [<Optional; DefaultParameterValue(null)>] ?AccessToken: string,
            [<Optional; DefaultParameterValue(null)>] ?Style: StyleParam.MapboxStyle,
            [<Optional; DefaultParameterValue(null)>] ?Center: (float * float),
            [<Optional; DefaultParameterValue(null)>] ?Zoom: float,
            [<Optional; DefaultParameterValue(null)>] ?Bearing: float,
            [<Optional; DefaultParameterValue(null)>] ?Pitch: float,
            [<Optional; DefaultParameterValue(null)>] ?Layers: seq<MapboxLayer>,
            [<Optional; DefaultParameterValue(null)>] ?Id: int
        ) =
        (fun (ch: GenericChart) ->
            let mapbox =
                Mapbox.init (
                    ?Domain = Domain,
                    ?AccessToken = AccessToken,
                    ?Style = Style,
                    ?Center = Center,
                    ?Zoom = Zoom,
                    ?Bearing = Bearing,
                    ?Pitch = Pitch,
                    ?Layers = Layers
                )

            ch |> Chart.withMapbox (mapbox, ?Id = Id))

    /// <summary>
    /// Sets the given Ternary object with the given id on the input chart's layout.
    /// </summary>
    /// <param name="ternary">The Ternary object to set on the chart's layout</param>
    /// <param name="id">The target Ternary id with which the Ternary object should be set.</param>
    /// <param name="Combine">Wether or not to combine the objects if there is already an Ternary set (default is false)</param>
    [<CompiledName("SetTernary")>]
    static member setTernary
        (
            ternary: Ternary,
            id: StyleParam.SubPlotId,
            [<Optional; DefaultParameterValue(null)>] ?Combine: bool
        ) =

        let combine = defaultArg Combine false

        (fun (ch: GenericChart) ->
            if combine then
                ch |> GenericChart.mapLayout (Layout.updateTernaryById (id, ternary))
            else
                ch |> GenericChart.mapLayout (Layout.setTernary (id, ternary)))

    /// <summary>
    /// Sets the Ternary for the chart's layout
    ///
    /// If there is already a Ternary set, the objects are combined.
    /// </summary>
    /// <param name="ternary">The Ternary to set on the chart's layout</param>
    /// <param name="Id">The target ternary id on which the Ternary should be set. Default is 1.</param>
    [<CompiledName("WithTernary")>]
    static member withTernary(ternary: Ternary, [<Optional; DefaultParameterValue(null)>] ?Id: int) =
        let id =
            Id |> Option.defaultValue 1 |> StyleParam.SubPlotId.Ternary

        (fun (ch: GenericChart) -> ch |> Chart.setTernary (ternary, id, true))

    /// <summary>
    /// Sets the given Ternary styles on the target Ternary object on the input chart's layout.
    ///
    /// If there is already a Ternary set, the styles are applied to it. If there is no Ternary present, a new Ternary object with the given styles will be set.
    /// </summary>
    /// <param name="AAxis">Sets the ternary A Axis</param>
    /// <param name="BAxis">Sets the ternary B Axis</param>
    /// <param name="CAxis">Sets the ternary C Axis</param>
    /// <param name="Domain">Sets the ternary domain</param>
    /// <param name="Sum">The number each triplet should sum to, and the maximum range of each axis</param>
    /// <param name="BGColor">Sets the background color of the ternary layout.</param>
    /// <param name="Id">The target Ternary id</param>
    static member withTernaryStyle
        (
            [<Optional; DefaultParameterValue(null)>] ?AAxis: LinearAxis,
            [<Optional; DefaultParameterValue(null)>] ?BAxis: LinearAxis,
            [<Optional; DefaultParameterValue(null)>] ?CAxis: LinearAxis,
            [<Optional; DefaultParameterValue(null)>] ?Domain: Domain,
            [<Optional; DefaultParameterValue(null)>] ?Sum: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?BGColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?Id: int
        ) =
        (fun (ch: GenericChart) ->
            let ternary =
                Ternary.init (
                    ?AAxis = AAxis,
                    ?BAxis = BAxis,
                    ?CAxis = CAxis,
                    ?Domain = Domain,
                    ?Sum = Sum,
                    ?BGColor = BGColor
                )

            ch |> Chart.withTernary (ternary, ?Id = Id))

    /// <summary>
    /// Sets the a axis on the ternary object with the given id on the input chart's layout.
    /// </summary>
    /// <param name="aAxis">The a Axis to set on the target ternary object on the chart's layout</param>
    /// <param name="id">The target ternary id with which the a Axis should be set.(default is 1)</param>
    /// <param name="Combine">Wether or not to combine the objects if there is already an axis set (default is false)</param>
    [<CompiledName("SetAAxis")>]
    static member setAAxis
        (
            aAxis: LinearAxis,
            id: StyleParam.SubPlotId,
            [<Optional; DefaultParameterValue(null)>] ?Combine: bool
        ) =

        fun (ch: GenericChart) ->

            let combine = defaultArg Combine false

            match id with
            | StyleParam.SubPlotId.Ternary _ ->

                ch
                |> GenericChart.mapLayout
                    (fun layout ->
                        let polar = layout |> Layout.getTernaryById id

                        if combine then
                            let currentAxis = polar |> Ternary.getAAxis

                            let updatedAxis =
                                (DynObj.combine currentAxis aAxis) :?> LinearAxis

                            let updatedTernary = polar |> Ternary.setAAxis updatedAxis

                            layout |> Layout.updateTernaryById (id, updatedTernary)

                        else
                            let updatedTernary =
                                layout |> Layout.getTernaryById id |> Ternary.setAAxis aAxis

                            layout |> Layout.updateTernaryById (id, updatedTernary))

            | _ -> failwith $"{StyleParam.SubPlotId.toString id} is an invalid subplot id for setting an a axis"

    /// <summary>
    /// Sets the a axis on the ternary object with the given id on the input chart's layout.
    ///
    /// If there is already a a axis set on the ternary object, the a axis objects are combined.
    /// </summary>
    /// <param name="aAxis">The new a axis for the chart layout's ternary object</param>
    /// <param name="Id">The target ternary id on which the a axis should be set. Default is 1.</param>
    [<CompiledName("WithAAxis")>]
    static member withAAxis(aAxis: LinearAxis, [<Optional; DefaultParameterValue(null)>] ?Id: int) =
        let id =
            Id |> Option.defaultValue 1 |> StyleParam.SubPlotId.Ternary

        (fun (ch: GenericChart) -> ch |> Chart.setAAxis (aAxis, id, true))

    /// <summary>
    /// Sets the b axis on the ternary object with the given id on the input chart's layout.
    /// </summary>
    /// <param name="bAxis">The b Axis to set on the target ternary object on the chart's layout</param>
    /// <param name="id">The target ternary id with which the b Axis should be set.(default is 1)</param>
    /// <param name="Combine">Wether or not to combine the objects if there is already an axis set (default is false)</param>
    [<CompiledName("SetBAxis")>]
    static member setBAxis
        (
            bAxis: LinearAxis,
            id: StyleParam.SubPlotId,
            [<Optional; DefaultParameterValue(null)>] ?Combine: bool
        ) =

        fun (ch: GenericChart) ->

            let combine = defaultArg Combine false

            match id with
            | StyleParam.SubPlotId.Ternary _ ->

                ch
                |> GenericChart.mapLayout
                    (fun layout ->
                        let polar = layout |> Layout.getTernaryById id

                        if combine then
                            let currentAxis = polar |> Ternary.getBAxis

                            let updatedAxis =
                                (DynObj.combine currentAxis bAxis) :?> LinearAxis

                            let updatedTernary = polar |> Ternary.setBAxis updatedAxis

                            layout |> Layout.updateTernaryById (id, updatedTernary)

                        else
                            let updatedTernary =
                                layout |> Layout.getTernaryById id |> Ternary.setBAxis bAxis

                            layout |> Layout.updateTernaryById (id, updatedTernary))

            | _ -> failwith $"{StyleParam.SubPlotId.toString id} is an invalid subplot id for setting a b axis"

    /// <summary>
    /// Sets the b axis on the ternary object with the given id on the input chart's layout.
    ///
    /// If there is already a b axis set on the ternary object, the b axis objects are combined.
    /// </summary>
    /// <param name="bAxis">The new b axis for the chart layout's ternary object</param>
    /// <param name="Id">The target ternary id on which the b axis should be set. Default is 1.</param>
    [<CompiledName("WithBAxis")>]
    static member withBAxis(bAxis: LinearAxis, [<Optional; DefaultParameterValue(null)>] ?Id: int) =
        let id =
            Id |> Option.defaultValue 1 |> StyleParam.SubPlotId.Ternary

        (fun (ch: GenericChart) -> ch |> Chart.setBAxis (bAxis, id, true))

    /// <summary>
    /// Sets the c axis on the ternary object with the given id on the input chart's layout.
    /// </summary>
    /// <param name="cAxis">The c Axis to set on the target ternary object on the chart's layout</param>
    /// <param name="id">The target ternary id with which the c Axis should be set.(default is 1)</param>
    /// <param name="Combine">Wether or not to combine the objects if there is already an axis set (default is false)</param>
    [<CompiledName("SetCAxis")>]
    static member setCAxis
        (
            cAxis: LinearAxis,
            id: StyleParam.SubPlotId,
            [<Optional; DefaultParameterValue(null)>] ?Combine: bool
        ) =

        fun (ch: GenericChart) ->

            let combine = defaultArg Combine false

            match id with
            | StyleParam.SubPlotId.Ternary _ ->

                ch
                |> GenericChart.mapLayout
                    (fun layout ->
                        let polar = layout |> Layout.getTernaryById id

                        if combine then
                            let currentAxis = polar |> Ternary.getCAxis

                            let updatedAxis =
                                (DynObj.combine currentAxis cAxis) :?> LinearAxis

                            let updatedTernary = polar |> Ternary.setCAxis updatedAxis

                            layout |> Layout.updateTernaryById (id, updatedTernary)

                        else
                            let updatedTernary =
                                layout |> Layout.getTernaryById id |> Ternary.setBAxis cAxis

                            layout |> Layout.updateTernaryById (id, updatedTernary))

            | _ -> failwith $"{StyleParam.SubPlotId.toString id} is an invalid subplot id for setting a c axis"

    /// <summary>
    /// Sets the c axis on the ternary object with the given id on the input chart's layout.
    ///
    /// If there is already a c axis set on the ternary object, the c axis objects are combined.
    /// </summary>
    /// <param name="cAxis">The new c axis for the chart layout's ternary object</param>
    /// <param name="Id">The target ternary id on which the c axis should be set. Default is 1.</param>
    [<CompiledName("WithCAxis")>]
    static member withCAxis(cAxis: LinearAxis, [<Optional; DefaultParameterValue(null)>] ?Id: int) =
        let id =
            Id |> Option.defaultValue 1 |> StyleParam.SubPlotId.Ternary

        (fun (ch: GenericChart) -> ch |> Chart.setCAxis (cAxis, id, true))

    /// <summary>
    /// Sets the LayoutGrid for the chart's layout.
    /// </summary>
    /// <param name="layoutGrid">The new LayoutGrid for the chart's layout</param>
    /// <param name="Combine">Wether or not to combine the objects if there is already a ColorBar object set (default is false)</param>
    [<CompiledName("SetLayoutGrid")>]
    static member setLayoutGrid(layoutGrid: LayoutGrid, ?Combine: bool) =
        let combine = defaultArg Combine false

        (fun (ch: GenericChart) ->
            if combine then
                ch |> GenericChart.mapLayout (Layout.updateLayoutGrid layoutGrid)
            else
                ch |> GenericChart.mapLayout (Layout.setLayoutGrid layoutGrid))

    /// <summary>
    /// Sets the LayoutGrid for the chart's layout
    ///
    /// If there is already a LayoutGrid set, the objects are combined.
    /// </summary>
    /// <param name="layoutGrid">The new LayoutGrid for the chart's layout</param>
    [<CompiledName("WithLayoutGrid")>]
    static member withLayoutGrid(layoutGrid: LayoutGrid) =
        (fun (ch: GenericChart) -> ch |> Chart.setLayoutGrid (layoutGrid, true))

    /// <summary>
    /// Sets the given LayoutGrid styles on the input chart's LayoutGrid.
    ///
    /// If there is already a LayoutGrid set , the styles are applied to it. If there is no LayoutGrid present, a new LayoutGrid object with the given styles will be set.
    /// </summary>
    /// <param name ="Rows">The number of rows in the grid. If you provide a 2D `subplots` array or a `yaxes` array, its length is used as the default. But it's also possible to have a different length, if you want to leave a row at the end for non-cartesian subplots.</param>
    /// <param name ="Columns">The number of columns in the grid. If you provide a 2D `subplots` array, the length of its longest row is used as the default. If you give an `xaxes` array, its length is used as the default. But it's also possible to have a different length, if you want to leave a row at the end for non-cartesian subplots.</param>
    /// <param name ="SubPlots">Used for freeform grids, where some axes may be shared across subplots but others are not. Each entry should be a cartesian subplot id, like "xy" or "x3y2", or "" to leave that cell empty. You may reuse x axes within the same column, and y axes within the same row. Non-cartesian subplots and traces that support `domain` can place themselves in this grid separately using the `gridcell` attribute.</param>
    /// <param name ="XAxes">Used with `yaxes` when the x and y axes are shared across columns and rows. Each entry should be an y axis id like "y", "y2", etc., or "" to not put a y axis in that row. Entries other than "" must be unique. Ignored if `subplots` is present. If missing but `xaxes` is present, will generate consecutive IDs.</param>
    /// <param name ="YAxes">Used with `yaxes` when the x and y axes are shared across columns and rows. Each entry should be an x axis id like "x", "x2", etc., or "" to not put an x axis in that column. Entries other than "" must be unique. Ignored if `subplots` is present. If missing but `yaxes` is present, will generate consecutive IDs.</param>
    /// <param name ="RowOrder">Is the first row the top or the bottom? Note that columns are always enumerated from left to right.</param>
    /// <param name ="Pattern">If no `subplots`, `xaxes`, or `yaxes` are given but we do have `rows` and `columns`, we can generate defaults using consecutive axis IDs, in two ways: "coupled" gives one x axis per column and one y axis per row. "independent" uses a new xy pair for each cell, left-to-right across each row then iterating rows according to `roworder`.</param>
    /// <param name ="XGap">Horizontal space between grid cells, expressed as a fraction of the total width available to one cell. Defaults to 0.1 for coupled-axes grids and 0.2 for independent grids.</param>
    /// <param name ="YGap">Vertical space between grid cells, expressed as a fraction of the total height available to one cell. Defaults to 0.1 for coupled-axes grids and 0.3 for independent grids.</param>
    /// <param name ="Domain">Sets the domains of this grid subplot (in plot fraction). The first and last cells end exactly at the domain edges, with no grout around the edges.</param>
    /// <param name ="XSide">Sets where the x axis labels and titles go. "bottom" means the very bottom of the grid. "bottom plot" is the lowest plot that each x axis is used in. "top" and "top plot" are similar.</param>
    /// <param name ="YSide">Sets where the y axis labels and titles go. "left" means the very left edge of the grid. "left plot" is the leftmost plot that each y axis is used in. "right" and "right plot" are similar.</param>
    [<CompiledName("WithLayoutGridStyle")>]
    static member withLayoutGridStyle
        (
            [<Optional; DefaultParameterValue(null)>] ?SubPlots: (StyleParam.LinearAxisId * StyleParam.LinearAxisId) [] [],
            [<Optional; DefaultParameterValue(null)>] ?XAxes: StyleParam.LinearAxisId [],
            [<Optional; DefaultParameterValue(null)>] ?YAxes: StyleParam.LinearAxisId [],
            [<Optional; DefaultParameterValue(null)>] ?Rows: int,
            [<Optional; DefaultParameterValue(null)>] ?Columns: int,
            [<Optional; DefaultParameterValue(null)>] ?RowOrder: StyleParam.LayoutGridRowOrder,
            [<Optional; DefaultParameterValue(null)>] ?Pattern: StyleParam.LayoutGridPattern,
            [<Optional; DefaultParameterValue(null)>] ?XGap: float,
            [<Optional; DefaultParameterValue(null)>] ?YGap: float,
            [<Optional; DefaultParameterValue(null)>] ?Domain: Domain,
            [<Optional; DefaultParameterValue(null)>] ?XSide: StyleParam.LayoutGridXSide,
            [<Optional; DefaultParameterValue(null)>] ?YSide: StyleParam.LayoutGridYSide
        ) =
        (fun (ch: GenericChart) ->
            let grid =
                LayoutGrid.init (
                    ?SubPlots = SubPlots,
                    ?XAxes = XAxes,
                    ?YAxes = YAxes,
                    ?Rows = Rows,
                    ?Columns = Columns,
                    ?RowOrder = RowOrder,
                    ?Pattern = Pattern,
                    ?XGap = XGap,
                    ?YGap = YGap,
                    ?Domain = Domain,
                    ?XSide = XSide,
                    ?YSide = YSide

                )

            ch |> Chart.withLayoutGrid grid)

    /// <summary>
    /// Sets the Legend for the chart's layout.
    /// </summary>
    /// <param name="legend">The new Legend for the chart's layout</param>
    /// <param name="Combine">Wether or not to combine the objects if there is already a Legend object set (default is false)</param>
    [<CompiledName("SetLegend")>]
    static member setLegend(legend: Legend, ?Combine: bool) =
        let combine = defaultArg Combine false

        (fun (ch: GenericChart) ->
            if combine then
                ch |> GenericChart.mapLayout (Layout.updateLegend legend)
            else
                ch |> GenericChart.mapLayout (Layout.setLegend legend))

    /// <summary>
    /// Sets the Legend for the chart's layout
    ///
    /// If there is already a Legend set, the objects are combined.
    /// </summary>
    /// <param name="legend">The new Legend for the chart's layout</param>
    [<CompiledName("WithLegend")>]
    static member withLegend(legend: Legend) =
        (fun (ch: GenericChart) -> ch |> Chart.setLegend (legend, true))

    /// <summary>
    /// Sets the given Legend styles on the input chart's Legend.
    ///
    /// If there is already a Legend set , the styles are applied to it. If there is no Legend present, a new Legend object with the given styles will be set.
    /// </summary>
    /// <param name="BGColor">Sets the legend background color. Defaults to `layout.paper_bgcolor`.</param>
    /// <param name="BorderColor">Sets the color of the border enclosing the legend.</param>
    /// <param name="Borderwidth">Sets the width (in px) of the border enclosing the legend.</param>
    /// <param name="Font">Sets the font used to text the legend items.</param>
    /// <param name="GroupClick">Determines the behavior on legend group item click. "toggleitem" toggles the visibility of the individual item clicked on the graph. "togglegroup" toggles the visibility of all items in the same legendgroup as the item clicked on the graph.</param>
    /// <param name="GroupTitleFont">Sets the font for group titles in legend. Defaults to `legend.font` with its size increased about 10%.</param>
    /// <param name="ItemClick">Determines the behavior on legend item click. "toggle" toggles the visibility of the item clicked on the graph. "toggleothers" makes the clicked item the sole visible item on the graph. "false" disables legend item click interactions.</param>
    /// <param name="ItemDoubleClick">Determines the behavior on legend item double-click. "toggle" toggles the visibility of the item clicked on the graph. "toggleothers" makes the clicked item the sole visible item on the graph. "false" disables legend item double-click interactions.</param>
    /// <param name="ItemSizing">Determines if the legend items symbols scale with their corresponding "trace" attributes or remain "constant" independent of the symbol size on the graph.</param>
    /// <param name="ItemWidth">Sets the width (in px) of the legend item symbols (the part other than the title.text).</param>
    /// <param name="Orientation">Sets the orientation of the legend.</param>
    /// <param name="Title">Sets the title of the legend.</param>
    /// <param name="TraceGroupGap">Sets the amount of vertical space (in px) between legend groups.</param>
    /// <param name="TraceOrder">Determines the order at which the legend items are displayed. If "normal", the items are displayed top-to-bottom in the same order as the input data. If "reversed", the items are displayed in the opposite order as "normal". If "grouped", the items are displayed in groups (when a trace `legendgroup` is provided). if "grouped+reversed", the items are displayed in the opposite order as "grouped".</param>
    /// <param name="UIRevision">Controls persistence of legend-driven changes in trace and pie label visibility. Defaults to `layout.uirevision`.</param>
    /// <param name="VerticalAlign">Sets the vertical alignment of the symbols with respect to their associated text.</param>
    /// <param name="X">Sets the x position (in normalized coordinates) of the legend. Defaults to "1.02" for vertical legends and defaults to "0" for horizontal legends.</param>
    /// <param name="XAnchor">Sets the legend's horizontal position anchor. This anchor binds the `x` position to the "left", "center" or "right" of the legend. Value "auto" anchors legends to the right for `x` values greater than or equal to 2/3, anchors legends to the left for `x` values less than or equal to 1/3 and anchors legends with respect to their center otherwise.</param>
    /// <param name="Y">Sets the y position (in normalized coordinates) of the legend. Defaults to "1" for vertical legends, defaults to "-0.1" for horizontal legends on graphs w/o range sliders and defaults to "1.1" for horizontal legends on graph with one or multiple range sliders.</param>
    /// <param name="YAnchor">Sets the legend's vertical position anchor This anchor binds the `y` position to the "top", "middle" or "bottom" of the legend. Value "auto" anchors legends at their bottom for `y` values less than or equal to 1/3, anchors legends to at their top for `y` values greater than or equal to 2/3 and anchors legends with respect to their middle otherwise.</param>
    [<CompiledName("WithLegendStyle")>]
    static member withLegendStyle
        (
            [<Optional; DefaultParameterValue(null)>] ?BGColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?BorderColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?Borderwidth: float,
            [<Optional; DefaultParameterValue(null)>] ?Font: Font,
            [<Optional; DefaultParameterValue(null)>] ?GroupClick: StyleParam.TraceGroupClickOptions,
            [<Optional; DefaultParameterValue(null)>] ?GroupTitleFont: Font,
            [<Optional; DefaultParameterValue(null)>] ?ItemClick: StyleParam.TraceItemClickOptions,
            [<Optional; DefaultParameterValue(null)>] ?ItemDoubleClick: StyleParam.TraceItemClickOptions,
            [<Optional; DefaultParameterValue(null)>] ?ItemSizing: StyleParam.TraceItemSizing,
            [<Optional; DefaultParameterValue(null)>] ?ItemWidth: int,
            [<Optional; DefaultParameterValue(null)>] ?Orientation: StyleParam.Orientation,
            [<Optional; DefaultParameterValue(null)>] ?Title: Title,
            [<Optional; DefaultParameterValue(null)>] ?TraceGroupGap: float,
            [<Optional; DefaultParameterValue(null)>] ?TraceOrder: StyleParam.TraceOrder,
            [<Optional; DefaultParameterValue(null)>] ?UIRevision: string,
            [<Optional; DefaultParameterValue(null)>] ?VerticalAlign: StyleParam.VerticalAlign,
            [<Optional; DefaultParameterValue(null)>] ?X: float,
            [<Optional; DefaultParameterValue(null)>] ?XAnchor: StyleParam.XAnchorPosition,
            [<Optional; DefaultParameterValue(null)>] ?Y: float,
            [<Optional; DefaultParameterValue(null)>] ?YAnchor: StyleParam.YAnchorPosition
        ) =
        (fun (ch: GenericChart) ->
            let legend =
                Legend.init (
                    ?BGColor = BGColor,
                    ?BorderColor = BorderColor,
                    ?Borderwidth = Borderwidth,
                    ?Font = Font,
                    ?GroupClick = GroupClick,
                    ?GroupTitleFont = GroupTitleFont,
                    ?ItemClick = ItemClick,
                    ?ItemDoubleClick = ItemDoubleClick,
                    ?ItemSizing = ItemSizing,
                    ?ItemWidth = ItemWidth,
                    ?Orientation = Orientation,
                    ?Title = Title,
                    ?TraceGroupGap = TraceGroupGap,
                    ?TraceOrder = TraceOrder,
                    ?UIRevision = UIRevision,
                    ?VerticalAlign = VerticalAlign,
                    ?X = X,
                    ?XAnchor = XAnchor,
                    ?Y = Y,
                    ?YAnchor = YAnchor

                )

            ch |> Chart.withLegend legend)

    [<CompiledName("WithConfig")>]
    static member withConfig(config: Config) =
        (fun (ch: GenericChart) -> GenericChart.setConfig config ch)

    /// <summary>
    ///
    /// </summary>
    /// <param name="annotations">The annotations to add to the input charts layout</param>
    /// <param name="Append">If true, the input annotations will be appended to existing annotations, otherwise existing annotations will be removed (default: true)</param>
    [<CompiledName("WithAnnotations")>]
    static member withAnnotations
        (
            annotations: seq<Annotation>,
            [<Optional; DefaultParameterValue(true)>] ?Append: bool
        ) =
        let append = defaultArg Append true

        fun (ch: GenericChart) ->

            let annotations' =

                if append then

                    let layout = GenericChart.getLayout ch

                    layout.TryGetTypedValue<seq<Annotation>>("annotations")
                    |> Option.defaultValue Seq.empty
                    |> Seq.append annotations

                else
                    annotations

            ch |> GenericChart.mapLayout (Layout.style (Annotations = annotations'))

    [<CompiledName("WithAnnotation")>]
    static member withAnnotation(annotation: Annotation, [<Optional; DefaultParameterValue(true)>] ?Append: bool) =
        Chart.withAnnotations ([ annotation ], ?Append = Append)

    // Set the title of a Chart
    [<CompiledName("WithTitle")>]
    static member withTitle(title, [<Optional; DefaultParameterValue(null)>] ?TitleFont) =
        (fun (ch: GenericChart) ->
            let layout =
                Layout() |> Layout.style (Title = Title.init (Text = title, ?Font = TitleFont))

            GenericChart.addLayout layout ch)

    // Set the title of a Chart
    [<CompiledName("WithTitle")>]
    static member withTitle(title) =
        (fun (ch: GenericChart) ->
            let layout = Layout() |> Layout.style (Title = title)
            GenericChart.addLayout layout ch)

    // Set showLegend of a Chart
    [<CompiledName("WithLegend")>]
    static member withLegend(showlegend) =
        (fun (ch: GenericChart) ->
            let layout =
                Layout() |> Layout.style (ShowLegend = showlegend)

            GenericChart.addLayout layout ch)


    // Set the size of a Chart
    [<CompiledName("WithSize")>]
    static member withSize
        (
            [<Optional; DefaultParameterValue(null)>] ?Width: int,
            [<Optional; DefaultParameterValue(null)>] ?Height: int
        ) =

        fun (ch: GenericChart) ->
            let layout =
                GenericChart.getLayout ch |> Layout.style (?Width = Width, ?Height = Height)

            GenericChart.setLayout layout ch



    // Set the size of a Chart
    [<CompiledName("WithSize")>]
    static member withSize(width: float, height: float) =
        Chart.withSize (Width = int width, Height = int height)

    // Set the margin of a Chart
    [<CompiledName("WithMargin")>]
    static member withMargin(margin: Margin) =
        (fun (ch: GenericChart) ->
            let layout =
                GenericChart.getLayout ch |> Layout.style (Margin = margin)

            GenericChart.setLayout layout ch)

    // Set the margin of a Chart
    [<CompiledName("WithMarginSize")>]
    static member withMarginSize
        (
            [<Optional; DefaultParameterValue(null)>] ?Left,
            [<Optional; DefaultParameterValue(null)>] ?Right,
            [<Optional; DefaultParameterValue(null)>] ?Top,
            [<Optional; DefaultParameterValue(null)>] ?Bottom,
            [<Optional; DefaultParameterValue(null)>] ?Pad,
            [<Optional; DefaultParameterValue(null)>] ?Autoexpand
        ) =
        let margin =
            Margin.init (
                ?Left = Left,
                ?Right = Right,
                ?Top = Top,
                ?Bottom = Bottom,
                ?Pad = Pad,
                ?Autoexpand = Autoexpand
            )

        Chart.withMargin (margin)

    [<CompiledName("WithTemplate")>]
    static member withTemplate(template: Template) =
        (fun (ch: GenericChart) -> ch |> GenericChart.mapLayout (Layout.style (Template = (template :> DynamicObj))))

    // TODO: Include withLegend & withLegendStyle

    //Specifies the shape type to be drawn. If "line", a line is drawn from (`x0`,`y0`) to (`x1`,`y1`) If "circle", a circle is drawn from
//((`x0`+`x1`)/2, (`y0`+`y1`)/2)) with radius (|(`x0`+`x1`)/2 - `x0`|, |(`y0`+`y1`)/2 -`y0`)|) If "rect", a rectangle is drawn linking
//(`x0`,`y0`), (`x1`,`y0`), (`x1`,`y1`), (`x0`,`y1`), (`x0`,`y0`)

    /// <summary>
    ///
    /// </summary>
    /// <param name="shapes">The shapes to add to the input charts layout</param>
    /// <param name="Append">If true, the input annotations will be appended to existing annotations, otherwise existing annotations will be removed (default: true)</param>
    [<CompiledName("WithShapes")>]
    static member withShapes(shapes: seq<Shape>, [<Optional; DefaultParameterValue(true)>] ?Append: bool) =
        let append = defaultArg Append true

        fun (ch: GenericChart) ->

            let shapes' =

                if append then

                    let layout = GenericChart.getLayout ch

                    layout.TryGetTypedValue<seq<Shape>>("shapes") |> Option.defaultValue Seq.empty |> Seq.append shapes

                else
                    shapes

            ch |> GenericChart.mapLayout (Layout.style (Shapes = shapes'))

    [<CompiledName("WithShape")>]
    static member withShape(shape: Shape, [<Optional; DefaultParameterValue(true)>] ?Append: bool) =
        Chart.withShapes ([ shape ], ?Append = Append)


    //==============================================================================================================
    //================================= More complicated composite methods =========================================
    //==============================================================================================================


    /// <summary>
    /// Creates a subplot grid with the given dimensions (nRows x nCols) for the input charts.
    /// </summary>
    /// <param name ="nRows">The number of rows in the grid. If you provide a 2D `subplots` array or a `yaxes` array, its length is used as the default. But it's also possible to have a different length, if you want to leave a row at the end for non-cartesian subplots.</param>
    /// <param name ="nCols">The number of columns in the grid. If you provide a 2D `subplots` array, the length of its longest row is used as the default. If you give an `xaxes` array, its length is used as the default. But it's also possible to have a different length, if you want to leave a row at the end for non-cartesian subplots.</param>
    /// <param name ="SubPlots">Used for freeform grids, where some axes may be shared across subplots but others are not. Each entry should be a cartesian subplot id, like "xy" or "x3y2", or "" to leave that cell empty. You may reuse x axes within the same column, and y axes within the same row. Non-cartesian subplots and traces that support `domain` can place themselves in this grid separately using the `gridcell` attribute.</param>
    /// <param name ="XAxes">Used with `yaxes` when the x and y axes are shared across columns and rows. Each entry should be an y axis id like "y", "y2", etc., or "" to not put a y axis in that row. Entries other than "" must be unique. Ignored if `subplots` is present. If missing but `xaxes` is present, will generate consecutive IDs.</param>
    /// <param name ="YAxes">Used with `yaxes` when the x and y axes are shared across columns and rows. Each entry should be an x axis id like "x", "x2", etc., or "" to not put an x axis in that column. Entries other than "" must be unique. Ignored if `subplots` is present. If missing but `yaxes` is present, will generate consecutive IDs.</param>
    /// <param name ="RowOrder">Is the first row the top or the bottom? Note that columns are always enumerated from left to right.</param>
    /// <param name ="Pattern">If no `subplots`, `xaxes`, or `yaxes` are given but we do have `rows` and `columns`, we can generate defaults using consecutive axis IDs, in two ways: "coupled" gives one x axis per column and one y axis per row. "independent" uses a new xy pair for each cell, left-to-right across each row then iterating rows according to `roworder`.</param>
    /// <param name ="XGap">Horizontal space between grid cells, expressed as a fraction of the total width available to one cell. Defaults to 0.1 for coupled-axes grids and 0.2 for independent grids.</param>
    /// <param name ="YGap">Vertical space between grid cells, expressed as a fraction of the total height available to one cell. Defaults to 0.1 for coupled-axes grids and 0.3 for independent grids.</param>
    /// <param name ="Domain">Sets the domains of this grid subplot (in plot fraction). The first and last cells end exactly at the domain edges, with no grout around the edges.</param>
    /// <param name ="XSide">Sets where the x axis labels and titles go. "bottom" means the very bottom of the grid. "bottom plot" is the lowest plot that each x axis is used in. "top" and "top plot" are similar.</param>
    /// <param name ="YSide">Sets where the y axis labels and titles go. "left" means the very left edge of the grid. "left plot" is the leftmost plot that each y axis is used in. "right" and "right plot" are similar.</param>
    [<CompiledName("Grid")>]
    static member Grid
        (
            nRows: int,
            nCols: int,
            [<Optional; DefaultParameterValue(null)>] ?SubPlots: (StyleParam.LinearAxisId * StyleParam.LinearAxisId) [] [],
            [<Optional; DefaultParameterValue(null)>] ?XAxes: StyleParam.LinearAxisId [],
            [<Optional; DefaultParameterValue(null)>] ?YAxes: StyleParam.LinearAxisId [],
            [<Optional; DefaultParameterValue(null)>] ?RowOrder: StyleParam.LayoutGridRowOrder,
            [<Optional; DefaultParameterValue(null)>] ?Pattern: StyleParam.LayoutGridPattern,
            [<Optional; DefaultParameterValue(null)>] ?XGap: float,
            [<Optional; DefaultParameterValue(null)>] ?YGap: float,
            [<Optional; DefaultParameterValue(null)>] ?Domain: Domain,
            [<Optional; DefaultParameterValue(null)>] ?XSide: StyleParam.LayoutGridXSide,
            [<Optional; DefaultParameterValue(null)>] ?YSide: StyleParam.LayoutGridYSide
        ) =
        fun (gCharts: #seq<GenericChart.GenericChart>) ->

            let pattern =
                defaultArg Pattern StyleParam.LayoutGridPattern.Independent

            let hasSharedAxes =
                pattern = StyleParam.LayoutGridPattern.Coupled

            // rows x cols coordinate grid
            let gridCoordinates =
                Array.init nRows (fun rowIndex -> Array.init nCols (fun colIndex -> rowIndex + 1, colIndex + 1))
                |> Array.concat

            gCharts
            |> Seq.zip gridCoordinates
            |> Seq.mapi
                (fun i ((rowIndex, colIndex), gChart) ->

                    let layout = gChart |> GenericChart.getLayout

                    match TraceID.ofTraces (gChart |> GenericChart.getTraces) with
                    | TraceID.Multi ->
                        failwith
                            $"the trace for ({rowIndex},{colIndex}) contains multiple different subplot types. this is not supported."
                    | TraceID.Cartesian2D
                    | TraceID.Carpet ->

                        let xAxis =
                            layout.TryGetTypedValue<LinearAxis> "xaxis" |> Option.defaultValue (LinearAxis.init ())

                        let yAxis =
                            layout.TryGetTypedValue<LinearAxis> "yaxis" |> Option.defaultValue (LinearAxis.init ())

                        let xAnchor, yAnchor =
                            if hasSharedAxes then
                                colIndex, rowIndex //set axis anchors according to grid coordinates
                            else
                                i + 1, i + 1

                        gChart
                        |> Chart.withAxisAnchor (xAnchor, yAnchor) // set adapted axis anchors
                        |> Chart.withXAxis (xAxis, (StyleParam.SubPlotId.XAxis(i + 1))) // set previous axis with adapted id (one individual axis for each subplot, wether or not they will be used later)
                        |> Chart.withYAxis (yAxis, (StyleParam.SubPlotId.YAxis(i + 1))) // set previous axis with adapted id (one individual axis for each subplot, wether or not they will be used later)
                        |> GenericChart.mapLayout
                            (fun l ->
                                if i > 0 then
                                    // remove default axes from consecutive charts, otherwise they will override the first one
                                    l.Remove("xaxis") |> ignore
                                    l.Remove("yaxis") |> ignore

                                l)
                    | TraceID.Cartesian3D ->

                        let scene =
                            layout.TryGetTypedValue<Scene> "scene"
                            |> Option.defaultValue (Scene.init ())
                            |> Scene.style (
                                Domain = LayoutObjects.Domain.init (Row = rowIndex - 1, Column = colIndex - 1)
                            )

                        let sceneAnchor = StyleParam.SubPlotId.Scene(i + 1)

                        gChart
                        |> GenericChart.mapTrace (fun t -> t :?> Trace3D |> Trace3DStyle.SetScene sceneAnchor :> Trace)
                        |> Chart.withScene (scene, (i + 1))
                    | TraceID.Polar ->

                        let polar =
                            layout.TryGetTypedValue<Polar> "polar"
                            |> Option.defaultValue (Polar.init ())
                            |> Polar.style (
                                Domain = LayoutObjects.Domain.init (Row = rowIndex - 1, Column = colIndex - 1)
                            )

                        let polarAnchor = StyleParam.SubPlotId.Polar(i + 1)

                        gChart
                        |> GenericChart.mapTrace
                            (fun t -> t :?> TracePolar |> TracePolarStyle.SetPolar polarAnchor :> Trace)
                        |> Chart.withPolar (polar, (i + 1))
                    | TraceID.Geo ->
                        let geo =
                            layout.TryGetTypedValue<Geo> "geo"
                            |> Option.defaultValue (Geo.init ())
                            |> Geo.style (
                                Domain = LayoutObjects.Domain.init (Row = rowIndex - 1, Column = colIndex - 1)
                            )

                        let geoAnchor = StyleParam.SubPlotId.Geo(i + 1)

                        gChart
                        |> GenericChart.mapTrace (fun t -> t :?> TraceGeo |> TraceGeoStyle.SetGeo geoAnchor :> Trace)
                        |> Chart.withGeo (geo, (i + 1))
                    | TraceID.Mapbox ->
                        let mapbox =
                            layout.TryGetTypedValue<Mapbox> "mapbox"
                            |> Option.defaultValue (Mapbox.init ())
                            |> Mapbox.style (
                                Domain = LayoutObjects.Domain.init (Row = rowIndex - 1, Column = colIndex - 1)
                            )

                        let mapboxAnchor = StyleParam.SubPlotId.Mapbox(i + 1)

                        gChart
                        |> GenericChart.mapTrace
                            (fun t -> t :?> TraceMapbox |> TraceMapboxStyle.SetMapbox mapboxAnchor :> Trace)
                        |> Chart.withMapbox (mapbox, (i + 1))
                    | TraceID.Domain ->
                        let newDomain =
                            LayoutObjects.Domain.init (Row = rowIndex - 1, Column = colIndex - 1)

                        gChart
                        |> GenericChart.mapTrace
                            (fun t -> t :?> TraceDomain |> TraceDomainStyle.SetDomain newDomain :> Trace)

                    | TraceID.Ternary ->

                        let ternary =
                            layout.TryGetTypedValue<Ternary> "ternary"
                            |> Option.defaultValue (Ternary.init ())
                            |> Ternary.style (
                                Domain = LayoutObjects.Domain.init (Row = rowIndex - 1, Column = colIndex - 1)
                            )

                        let ternaryAnchor = StyleParam.SubPlotId.Ternary(i + 1)

                        gChart
                        |> GenericChart.mapTrace
                            (fun t -> t :?> TraceTernary |> TraceTernaryStyle.SetTernary ternaryAnchor :> Trace)
                        |> Chart.withTernary (ternary, (i + 1)))
            |> Chart.combine
            |> Chart.withLayoutGrid (
                LayoutGrid.init (
                    Rows = nRows,
                    Columns = nCols,
                    Pattern = pattern,
                    ?SubPlots = SubPlots,
                    ?XAxes = XAxes,
                    ?YAxes = YAxes,
                    ?RowOrder = RowOrder,
                    ?XGap = XGap,
                    ?YGap = YGap,
                    ?Domain = Domain,
                    ?XSide = XSide,
                    ?YSide = YSide
                )
            )

    /// <summary>
    /// Creates a subplot grid with the the dimensions of the input 2D sequence containing the charts to render in the respective cells.
    ///
    /// ATTENTION: when the individual rows do not have the same amount of charts, they will be filled with dummy charts TO THE RIGHT.
    ///
    /// prevent this behaviour by using Chart.Invisible at the cells that should be empty.
    /// </summary>
    /// <param name ="SubPlots">Used for freeform grids, where some axes may be shared across subplots but others are not. Each entry should be a cartesian subplot id, like "xy" or "x3y2", or "" to leave that cell empty. You may reuse x axes within the same column, and y axes within the same row. Non-cartesian subplots and traces that support `domain` can place themselves in this grid separately using the `gridcell` attribute.</param>
    /// <param name ="XAxes">Used with `yaxes` when the x and y axes are shared across columns and rows. Each entry should be an y axis id like "y", "y2", etc., or "" to not put a y axis in that row. Entries other than "" must be unique. Ignored if `subplots` is present. If missing but `xaxes` is present, will generate consecutive IDs.</param>
    /// <param name ="YAxes">Used with `yaxes` when the x and y axes are shared across columns and rows. Each entry should be an x axis id like "x", "x2", etc., or "" to not put an x axis in that column. Entries other than "" must be unique. Ignored if `subplots` is present. If missing but `yaxes` is present, will generate consecutive IDs.</param>
    /// <param name ="RowOrder">Is the first row the top or the bottom? Note that columns are always enumerated from left to right.</param>
    /// <param name ="Pattern">If no `subplots`, `xaxes`, or `yaxes` are given but we do have `rows` and `columns`, we can generate defaults using consecutive axis IDs, in two ways: "coupled" gives one x axis per column and one y axis per row. "independent" uses a new xy pair for each cell, left-to-right across each row then iterating rows according to `roworder`.</param>
    /// <param name ="XGap">Horizontal space between grid cells, expressed as a fraction of the total width available to one cell. Defaults to 0.1 for coupled-axes grids and 0.2 for independent grids.</param>
    /// <param name ="YGap">Vertical space between grid cells, expressed as a fraction of the total height available to one cell. Defaults to 0.1 for coupled-axes grids and 0.3 for independent grids.</param>
    /// <param name ="Domain">Sets the domains of this grid subplot (in plot fraction). The first and last cells end exactly at the domain edges, with no grout around the edges.</param>
    /// <param name ="XSide">Sets where the x axis labels and titles go. "bottom" means the very bottom of the grid. "bottom plot" is the lowest plot that each x axis is used in. "top" and "top plot" are similar.</param>
    /// <param name ="YSide">Sets where the y axis labels and titles go. "left" means the very left edge of the grid. "left plot" is the leftmost plot that each y axis is used in. "right" and "right plot" are similar.</param>
    [<CompiledName("Grid")>]
    static member Grid
        (
            [<Optional; DefaultParameterValue(null)>] ?SubPlots: (StyleParam.LinearAxisId * StyleParam.LinearAxisId) [] [],
            [<Optional; DefaultParameterValue(null)>] ?XAxes: StyleParam.LinearAxisId [],
            [<Optional; DefaultParameterValue(null)>] ?YAxes: StyleParam.LinearAxisId [],
            [<Optional; DefaultParameterValue(null)>] ?RowOrder: StyleParam.LayoutGridRowOrder,
            [<Optional; DefaultParameterValue(null)>] ?Pattern: StyleParam.LayoutGridPattern,
            [<Optional; DefaultParameterValue(null)>] ?XGap: float,
            [<Optional; DefaultParameterValue(null)>] ?YGap: float,
            [<Optional; DefaultParameterValue(null)>] ?Domain: Domain,
            [<Optional; DefaultParameterValue(null)>] ?XSide: StyleParam.LayoutGridXSide,
            [<Optional; DefaultParameterValue(null)>] ?YSide: StyleParam.LayoutGridYSide
        ) =
        fun (gCharts: #seq<#seq<GenericChart>>) ->

            let nRows = Seq.length gCharts

            let nCols =
                Seq.maxBy Seq.length gCharts |> Seq.length

            if Seq.exists (fun s -> (s |> Seq.length) <> nCols) gCharts then
                printfn "WARNING: not all rows contain the same amount of charts."
                printfn "The rows will be filled TO THE RIGHT with invisible dummy charts."

                printfn
                    "To have more positional control, use Chart.Empty() in your Grid where you want to have empty cells."

                let copy =
                    gCharts |> Seq.map Seq.cast<GenericChart.GenericChart> // this is ugly but i did not find another way for the inner seq to be be a flexible type (so you can use list, array, and seq).

                let newGrid =
                    copy
                    |> Seq.map
                        (fun (row) ->
                            let nCharts = Seq.length row

                            if nCharts <> nCols then
                                seq {
                                    yield! row

                                    for i in nCharts .. nCols - 1 do
                                        yield Chart.Invisible()
                                }
                            else
                                row)
                    |> Seq.concat

                newGrid
                |> Chart.Grid(
                    nRows,
                    nCols,
                    ?SubPlots = SubPlots,
                    ?XAxes = XAxes,
                    ?YAxes = YAxes,
                    ?RowOrder = RowOrder,
                    ?Pattern = Pattern,
                    ?XGap = XGap,
                    ?YGap = YGap,
                    ?Domain = Domain,
                    ?XSide = XSide,
                    ?YSide = YSide
                )
            else
                gCharts
                |> Seq.concat
                |> Chart.Grid(
                    nRows,
                    nCols,
                    ?SubPlots = SubPlots,
                    ?XAxes = XAxes,
                    ?YAxes = YAxes,
                    ?RowOrder = RowOrder,
                    ?Pattern = Pattern,
                    ?XGap = XGap,
                    ?YGap = YGap,
                    ?Domain = Domain,
                    ?XSide = XSide,
                    ?YSide = YSide
                )

    /// Creates a chart stack (a subplot grid with one column) from the input charts.
    /// </summary>
    /// <param name ="SubPlots">Used for freeform grids, where some axes may be shared across subplots but others are not. Each entry should be a cartesian subplot id, like "xy" or "x3y2", or "" to leave that cell empty. You may reuse x axes within the same column, and y axes within the same row. Non-cartesian subplots and traces that support `domain` can place themselves in this grid separately using the `gridcell` attribute.</param>
    /// <param name ="XAxes">Used with `yaxes` when the x and y axes are shared across columns and rows. Each entry should be an y axis id like "y", "y2", etc., or "" to not put a y axis in that row. Entries other than "" must be unique. Ignored if `subplots` is present. If missing but `xaxes` is present, will generate consecutive IDs.</param>
    /// <param name ="YAxes">Used with `yaxes` when the x and y axes are shared across columns and rows. Each entry should be an x axis id like "x", "x2", etc., or "" to not put an x axis in that column. Entries other than "" must be unique. Ignored if `subplots` is present. If missing but `yaxes` is present, will generate consecutive IDs.</param>
    /// <param name ="RowOrder">Is the first row the top or the bottom? Note that columns are always enumerated from left to right.</param>
    /// <param name ="Pattern">If no `subplots`, `xaxes`, or `yaxes` are given but we do have `rows` and `columns`, we can generate defaults using consecutive axis IDs, in two ways: "coupled" gives one x axis per column and one y axis per row. "independent" uses a new xy pair for each cell, left-to-right across each row then iterating rows according to `roworder`.</param>
    /// <param name ="XGap">Horizontal space between grid cells, expressed as a fraction of the total width available to one cell. Defaults to 0.1 for coupled-axes grids and 0.2 for independent grids.</param>
    /// <param name ="YGap">Vertical space between grid cells, expressed as a fraction of the total height available to one cell. Defaults to 0.1 for coupled-axes grids and 0.3 for independent grids.</param>
    /// <param name ="Domain">Sets the domains of this grid subplot (in plot fraction). The first and last cells end exactly at the domain edges, with no grout around the edges.</param>
    /// <param name ="XSide">Sets where the x axis labels and titles go. "bottom" means the very bottom of the grid. "bottom plot" is the lowest plot that each x axis is used in. "top" and "top plot" are similar.</param>
    /// <param name ="YSide">Sets where the y axis labels and titles go. "left" means the very left edge of the grid. "left plot" is the leftmost plot that each y axis is used in. "right" and "right plot" are similar.</param>
    [<CompiledName("SingleStack")>]
    static member SingleStack
        (
            [<Optional; DefaultParameterValue(null)>] ?SubPlots: (StyleParam.LinearAxisId * StyleParam.LinearAxisId) [] [],
            [<Optional; DefaultParameterValue(null)>] ?XAxes: StyleParam.LinearAxisId [],
            [<Optional; DefaultParameterValue(null)>] ?YAxes: StyleParam.LinearAxisId [],
            [<Optional; DefaultParameterValue(null)>] ?RowOrder: StyleParam.LayoutGridRowOrder,
            [<Optional; DefaultParameterValue(null)>] ?Pattern: StyleParam.LayoutGridPattern,
            [<Optional; DefaultParameterValue(null)>] ?XGap: float,
            [<Optional; DefaultParameterValue(null)>] ?YGap: float,
            [<Optional; DefaultParameterValue(null)>] ?Domain: Domain,
            [<Optional; DefaultParameterValue(null)>] ?XSide: StyleParam.LayoutGridXSide,
            [<Optional; DefaultParameterValue(null)>] ?YSide: StyleParam.LayoutGridYSide
        ) =

        fun (gCharts: #seq<GenericChart.GenericChart>) ->

            gCharts
            |> Chart.Grid(
                nRows = Seq.length gCharts,
                nCols = 1,
                ?SubPlots = SubPlots,
                ?XAxes = XAxes,
                ?YAxes = YAxes,
                ?RowOrder = RowOrder,
                ?Pattern = Pattern,
                ?XGap = XGap,
                ?YGap = YGap,
                ?Domain = Domain,
                ?XSide = XSide,
                ?YSide = YSide
            )

    // ############################################################
// ####################### Apply to DisplayOptions

    /// Show chart in browser
    [<CompiledName("WithDescription")>]
    static member withDescription (description: ChartDescription) (ch: GenericChart) =
        ch |> mapDisplayOptions (DisplayOptions.style (Description = description))


    /// Adds the given additional html tags on the chart's DisplayOptions. They will be included in the document's <head>
    [<CompiledName("WithAdditionalHeadTags")>]
    static member withAdditionalHeadTags (additionalHeadTags: seq<string>) (ch: GenericChart) =
        ch
        |> mapDisplayOptions
            (fun d ->
                let tags =
                    d.TryGetTypedValue<seq<string>>("AdditionalHeadTags")

                let newTags =
                    tags
                    |> Option.map
                        (fun tags ->
                            seq {
                                yield! tags
                                yield! additionalHeadTags
                            })
                    |> Option.defaultValue additionalHeadTags

                d |> DisplayOptions.style (AdditionalHeadTags = newTags))

    /// Sets the given additional head tags on the chart's DisplayOptions. They will be included in the document's <head>
    [<CompiledName("WithHeadTags")>]
    static member withHeadTags (headTags: seq<string>) (ch: GenericChart) =
        ch |> mapDisplayOptions (DisplayOptions.style (AdditionalHeadTags = headTags))


    /// Adds the necessary script tags to render tex strings to the chart's DisplayOptions
    [<CompiledName("WithMathTex")>]
    static member withMathTex([<Optional; DefaultParameterValue(true)>] ?AppendTags: bool) =
        let tags =
            [
                """<script type="text/x-mathjax-config;executed=true">MathJax.Hub.Config({tex2jax: {inlineMath: [['$','$'], ['\\(','\\)']], processEscapes: true}});</script>"""
                """<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/mathjax/2.7.5/MathJax.js?config=TeX-AMS-MML_HTMLorMML%2CSafe.js&ver=4.1"></script>"""
            ]

        (fun (ch: GenericChart) ->

            if (AppendTags |> Option.defaultValue true) then
                ch |> Chart.withAdditionalHeadTags tags
            else
                ch |> Chart.withHeadTags tags)

    /// Sets the color axis with the given id on the chart layout
    [<CompiledName("WithColorAxis")>]
    static member withColorAxis(colorAxis: ColorAxis, [<Optional; DefaultParameterValue(null)>] ?Id) =
        (fun (ch: GenericChart) ->
            let layout =
                let id =
                    defaultArg Id (StyleParam.SubPlotId.ColorAxis 1)

                GenericChart.getLayout ch |> Layout.updateColorAxisById (id, colorAxis)

            GenericChart.setLayout layout ch)

    /// <summary>
    ///
    /// </summary>
    /// <param name="images">The images to add to the input charts layout</param>
    /// <param name="Append">If true, the input images will be appended to existing annotations, otherwise existing annotations will be removed (default: true)</param>
    [<CompiledName("WithLayoutImages")>]
    static member withLayoutImages(images: seq<LayoutImage>, [<Optional; DefaultParameterValue(true)>] ?Append: bool) =
        let append = defaultArg Append true

        fun (ch: GenericChart) ->

            let images' =

                if append then

                    let layout = GenericChart.getLayout ch

                    layout.TryGetTypedValue<seq<LayoutImage>>("images")
                    |> Option.defaultValue Seq.empty
                    |> Seq.append images

                else
                    images

            ch |> GenericChart.mapLayout (Layout.style (Images = images'))

    [<CompiledName("WithLayoutImage")>]
    static member withLayoutImage(image: LayoutImage, [<Optional; DefaultParameterValue(true)>] ?Append: bool) =

        Chart.withLayoutImages ([ image ], ?Append = Append)

    /// <summary>
    ///
    /// </summary>
    /// <param name="updateMenus">The updatmenus to add to the input charts layout</param>
    /// <param name="Append">If true, the input images will be appended to existing annotations, otherwise existing annotations will be removed (default: true)</param>
    [<CompiledName("WithUpdateMenus")>]
    static member withUpdateMenus
        (
            updateMenus: seq<UpdateMenu>,
            [<Optional; DefaultParameterValue(true)>] ?Append: bool
        ) =
        let append = defaultArg Append true

        fun (ch: GenericChart) ->

            let updateMenus' =

                if append then

                    let layout = GenericChart.getLayout ch

                    layout.TryGetTypedValue<seq<UpdateMenu>>("updatemenus")
                    |> Option.defaultValue Seq.empty
                    |> Seq.append updateMenus

                else
                    updateMenus

            ch |> GenericChart.mapLayout (Layout.style (UpdateMenus = updateMenus'))

    [<CompiledName("WithUpdateMenu")>]
    static member withUpdateMenu(updateMenu: UpdateMenu, [<Optional; DefaultParameterValue(true)>] ?Append: bool) =

        Chart.withUpdateMenus ([ updateMenu ], ?Append = Append)

    [<CompiledName("WithSliders")>]
    static member withSliders(sliders: seq<Slider>) =
        fun (ch: GenericChart) -> ch |> GenericChart.mapLayout (Layout.style (Sliders = sliders))

    [<CompiledName("WithSlider")>]
    static member withSlider(slider: Slider) = Chart.withSliders ([ slider ])
