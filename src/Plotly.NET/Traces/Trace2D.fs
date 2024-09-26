namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open DynamicObj
open System
open System.Runtime.InteropServices

/// The most commonly-used kind of subplot is a two-dimensional Cartesian subplot. Traces compatible with these subplots
/// support xaxis and yaxis attributes whose values must refer to corresponding objects in the layout portion of the figure.
/// For example, if xaxis="x", and yaxis="y" (which is the default) then this trace is drawn on the subplot at the intersection
/// of the axes configured under layout.xaxis and layout.yaxis, but if xaxis="x2" and yaxis="y3" then the trace is drawn at the
/// intersection of the axes configured under layout.xaxis2 and layout.yaxis3. Note that attributes such as layout.xaxis and
/// layout.xaxis2 etc do not have to be explicitly defined, in which case default values will be inferred. Multiple traces of
/// different types can be drawn on the same subplot.
///
/// X- and Y-axes support the type attribute, which enables them to represent continuous values (type="linear", type="log"),
/// temporal values (type="date") or categorical values (type="category", type="multicategory). Axes can also be overlaid on
/// top of one another to create dual-axis or multiple-axis charts. 2-d cartesian subplots lend themselves very well to creating
/// "small multiples" figures, also known as facet or trellis plots.
///
/// The following trace types are compatible with 2D-cartesian subplots via the xaxis and yaxis attributes:
///
/// - scatter-like trace types: scatter and scattergl can be used to draw scatter plots, line plots and curves, time-series plots,
/// bubble charts, dot plots and filled areas and also support error bars
///
/// - bar, funnel, waterfall: bar-like trace types which can also be used to draw timelines and Gantt charts
///
/// - histogram: an aggregating bar-like trace type
///
/// - box and violin: 1-dimensional distribution-like trace types
///
/// - histogram2D and histogram2Dcontour: 2-dimensional distribution-like density trace types
///
/// - image, heatmap and contour: matrix trace types
///
/// - ohlc and candlestick: stock-like trace types
///
/// - splom: multi-dimensional scatter plots which implicitly refer to many 2-d cartesian subplots at once.
type Trace2D(traceTypeName) =

    inherit Trace(traceTypeName)

    ///initializes a trace of type "scatter" applying the given trace styling function
    static member initScatter(applyStyle: Trace2D -> Trace2D) = Trace2D("scatter") |> applyStyle

    ///initializes a trace of type "scattergl" applying the given trace styling function
    static member initScatterGL(applyStyle: Trace2D -> Trace2D) = Trace2D("scattergl") |> applyStyle

    ///initializes a trace of type "bar" applying the given trace styling function
    static member initBar(applyStyle: Trace2D -> Trace2D) = Trace2D("bar") |> applyStyle

    ///initializes a trace of type "funnel" applying the given trace styling function
    static member initFunnel(applyStyle: Trace2D -> Trace2D) = Trace2D("funnel") |> applyStyle

    ///initializes a trace of type "waterfall" applying the given trace styling function
    static member initWaterfall(applyStyle: Trace2D -> Trace2D) = Trace2D("waterfall") |> applyStyle

    ///initializes a trace of type "histogram" applying the given trace styling function
    static member initHistogram(applyStyle: Trace2D -> Trace2D) = Trace2D("histogram") |> applyStyle

    ///initializes a trace of type "box" applying the given trace styling function
    static member initBoxPlot(applyStyle: Trace2D -> Trace2D) = Trace2D("box") |> applyStyle

    ///initializes a trace of type "violin" applying the given trace styling function
    static member initViolin(applyStyle: Trace2D -> Trace2D) = Trace2D("violin") |> applyStyle

    ///initializes a trace of type "histogram2D" applying the given trace styling function
    static member initHistogram2D(applyStyle: Trace2D -> Trace2D) = Trace2D("histogram2d") |> applyStyle

    ///initializes a trace of type "histogram2Dcontour" applying the given trace styling function
    static member initHistogram2DContour(applyStyle: Trace2D -> Trace2D) =
        Trace2D("histogram2dcontour") |> applyStyle

    ///initializes a trace of type "image" applying the given trace styling function
    static member initImage(applyStyle: Trace2D -> Trace2D) = Trace2D("image") |> applyStyle

    ///initializes a trace of type "heatmap" applying the given trace styling function
    static member initHeatmap(applyStyle: Trace2D -> Trace2D) = Trace2D("heatmap") |> applyStyle

    ///initializes a trace of type "heatmapgl" applying the given trace styling function
    static member initHeatmapGL(applyStyle: Trace2D -> Trace2D) = Trace2D("heatmapgl") |> applyStyle

    ///initializes a trace of type "contour" applying the given trace styling function
    static member initContour(applyStyle: Trace2D -> Trace2D) = Trace2D("contour") |> applyStyle

    ///initializes a trace of type "ohlc" applying the given trace styling function
    static member initOHLC(applyStyle: Trace2D -> Trace2D) = Trace2D("ohlc") |> applyStyle

    ///initializes a trace of type "candlestick" applying the given trace styling function
    static member initCandlestick(applyStyle: Trace2D -> Trace2D) = Trace2D("candlestick") |> applyStyle

    ///initializes a trace of type "SPLOM" applying the given trace styling function
    static member initSplom(applyStyle: Trace2D -> Trace2D) = Trace2D("splom") |> applyStyle


/// Create various functions for applying 2D chart styles to traces
type Trace2DStyle() =

    /// Sets the given axis anchor id(s) on a Trace object.
    static member SetAxisAnchor
        (
            [<Optional; DefaultParameterValue(null)>] ?X: StyleParam.LinearAxisId,
            [<Optional; DefaultParameterValue(null)>] ?Y: StyleParam.LinearAxisId
        ) =
        (fun (trace: Trace2D) ->

            X |> DynObj.setOptionalPropertyBy trace "xaxis" StyleParam.LinearAxisId.toString
            Y |> DynObj.setOptionalPropertyBy trace "yaxis" StyleParam.LinearAxisId.toString

            trace)

    /// <summary>
    /// Create a function that applies the styles of a scatter plot to a Trace object
    /// </summary>
    /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
    /// <param name="Visible">Determines whether or not this trace is visible. If "legendonly", the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).</param>
    /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
    /// <param name="Legend">Sets the reference to a legend to show this trace in. References to these legends are "legend", "legend2", "legend3", etc. Settings for these legends are set in the layout, under `layout.legend`, `layout.legend2`, etc.</param>
    /// <param name="LegendRank">Sets the legend rank for this trace. Items and groups with smaller ranks are presented on top/left side while with `"reversed" `legend.traceorder` they are on bottom/right side. The default legendrank is 1000, so that you can use ranks less than 1000 to place certain items before all unranked items, and ranks greater than 1000 to go after all unranked items.</param>
    /// <param name="LegendGroup">Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling legend items.</param>
    /// <param name="LegendGroupTitle">Sets the legend group title for this trace.</param>
    /// <param name="Opacity">Sets the opacity of the trace.</param>
    /// <param name="Mode">Determines the drawing mode for this scatter trace. If the provided `mode` includes "text" then the `text` elements appear at the coordinates. Otherwise, the `text` elements appear on hover. If there are less than 20 points and the trace is not stacked then the default is "lines+markers". Otherwise, "lines".</param>
    /// <param name="Ids">Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.</param>
    /// <param name="X">Sets the x coordinates.</param>
    /// <param name="MultiX">Sets the x coordinates.</param>
    /// <param name="X0">Alternate to `x`. Builds a linear space of x coordinates. Use with `dx` where `x0` is the starting coordinate and `dx` the step.</param>
    /// <param name="DX">Sets the x coordinate step. See `x0` for more info.</param>
    /// <param name="Y">Sets the y coordinates.</param>
    /// <param name="MultiY">Sets the y coordinates.</param>
    /// <param name="Y0">Alternate to `y`. Builds a linear space of y coordinates. Use with `dy` where `y0` is the starting coordinate and `dy` the step.</param>
    /// <param name="DY">Sets the y coordinate step. See `y0` for more info.</param>
    /// <param name="Text">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
    /// <param name="MultiText">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
    /// <param name="TextPosition">Sets the positions of the `text` elements with respects to the (x,y) coordinates.</param>
    /// <param name="MultiTextPosition">Sets the positions of the `text` elements with respects to the (x,y) coordinates.</param>
    /// <param name="TextTemplate">Template string used for rendering the information text that appear on points. Note that this will override `textinfo`. Variables are inserted using %{variable}, for example "y: %{y}". Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. Every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available.</param>
    /// <param name="MultiTextTemplate">Template string used for rendering the information text that appear on points. Note that this will override `textinfo`. Variables are inserted using %{variable}, for example "y: %{y}". Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. Every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available.</param>
    /// <param name="HoverText">Sets hover text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. To be seen, trace `hoverinfo` must contain a "text" flag.</param>
    /// <param name="MultiHoverText">Sets hover text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. To be seen, trace `hoverinfo` must contain a "text" flag.</param>
    /// <param name="HoverInfo">Determines which trace information appear on hover. If `none` or `skip` are set, no information is displayed upon hovering. But, if `none` is set, click and hover events are still fired.</param>
    /// <param name="HoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
    /// <param name="MultiHoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
    /// <param name="XHoverFormat">Sets the hover text formatting rulefor `x` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `xaxis.hoverformat`.</param>
    /// <param name="YHoverFormat">Sets the hover text formatting rulefor `y` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `xaxis.hoverformat`.</param>
    /// <param name="Meta">Assigns extra meta information associated with this trace that can be used in various text attributes. Attributes such as trace `name`, graph, axis and colorbar `title.text`, annotation `text` `rangeselector`, `updatemenues` and `sliders` `label` text all support `meta`. To access the trace `meta` values in an attribute in the same trace, simply use `%{meta[i]}` where `i` is the index or key of the `meta` item in question. To access trace `meta` in layout attributes, use `%{data[n[.meta[i]}` where `i` is the index or key of the `meta` and `n` is the trace index.</param>
    /// <param name="CustomData">Assigns extra data each datum. This may be useful when listening to hover, click and selection events. Note that, "scatter" traces also appends customdata items in the markers DOM elements</param>
    /// <param name="XAxis">Sets a reference between this trace's x coordinates and a 2D cartesian x axis. If "x" (the default value), the x coordinates refer to `layout.xaxis`. If "x2", the x coordinates refer to `layout.xaxis2`, and so on.</param>
    /// <param name="YAxis">Sets a reference between this trace's y coordinates and a 2D cartesian y axis. If "y" (the default value), the y coordinates refer to `layout.yaxis`. If "y2", the y coordinates refer to `layout.yaxis2`, and so on.</param>
    /// <param name="Orientation">Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used - including if `visible` is "legendonly" but not if it is `false`. Sets the stacking direction. With "v" ("h"), the y (x) values of subsequent traces are added. Also affects the default value of `fill`.</param>
    /// <param name="GroupNorm">Only relevant when `stackgroup` is used, and only the first `groupnorm` found in the `stackgroup` will be used - including if `visible` is "legendonly" but not if it is `false`. Sets the normalization for the sum of this `stackgroup`. With "fraction", the value of each trace at each location is divided by the sum of all trace values at that location. "percent" is the same but multiplied by 100 to show percentages. If there are multiple subplots, or multiple `stackgroup`s on one subplot, each will be normalized within its own set.</param>
    /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
    /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
    /// <param name="StackGroup">Set several scatter traces (on the same subplot) to the same stackgroup in order to add their y values (or their x values if `orientation` is "h"). If blank or omitted this trace will not be stacked. Stacking also turns `fill` on by default, using "tonexty" ("tonextx") if `orientation` is "h" ("v") and sets the default `mode` to "lines" irrespective of point count. You can only stack on a numeric (linear or log) axis. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order.</param>
    /// <param name="XPeriod">Only relevant when the axis `type` is "date". Sets the period positioning in milliseconds or "M&lt;n&gt;" on the x axis. Special values in the form of "M&lt;n&gt;" could be used to declare the number of months. In this case `n` must be a positive integer.</param>
    /// <param name="XPeriodAlignment">Only relevant when the axis `type` is "date". Sets the alignment of data points on the x axis.</param>
    /// <param name="XPeriod0">Only relevant when the axis `type` is "date". Sets the base for period positioning in milliseconds or date string on the x0 axis. When `x0period` is round number of weeks, the `x0period0` by default would be on a Sunday i.e. 2000-01-02, otherwise it would be at 2000-01-01.</param>
    /// <param name="YPeriod">Only relevant when the axis `type` is "date". Sets the period positioning in milliseconds or "M&lt;n&gt;" on the y axis. Special values in the form of "M&lt;n&gt;" could be used to declare the number of months. In this case `n` must be a positive integer.</param>
    /// <param name="YPeriodAlignment">Only relevant when the axis `type` is "date". Sets the alignment of data points on the y axis.</param>
    /// <param name="YPeriod0">Only relevant when the axis `type` is "date". Sets the base for period positioning in milliseconds or date string on the y0 axis. When `y0period` is round number of weeks, the `y0period0` by default would be on a Sunday i.e. 2000-01-02, otherwise it would be at 2000-01-01.</param>
    /// <param name="Marker">Sets the marker of this trace.</param>
    /// <param name="Line">Sets the line of this trace.</param>
    /// <param name="TextFont">Sets the text font of this trace.</param>
    /// <param name="XError">Sets the x error of this trace.</param>
    /// <param name="YError">Sets the y error of this trace.</param>
    /// <param name="SelectedPoints">Array containing integer indices of selected points. Has an effect only for traces that support selections. Note that an empty array means an empty selection where the `unselected` are turned on for all points, whereas, any other non-array values means no selection all where the `selected` and `unselected` styles have no effect.</param>
    /// <param name="Selected">Sets the style of selected points of this trace.</param>
    /// <param name="Unselected">Sets the style of unselected points of this trace.</param>
    /// <param name="ClipOnAxis">Determines whether or not markers and text nodes are clipped about the subplot axes. To show markers and text nodes above axis lines and tick labels, make sure to set `xaxis.layer` and `yaxis.layer` to "below traces".</param>
    /// <param name="ConnectGaps">Determines whether or not gaps (i.e. {nan} or missing values) in the provided data arrays are connected.</param>
    /// <param name="Fill">Sets the area to fill with a solid color. Defaults to "none" unless this trace is stacked, then it gets "tonexty" ("tonextx") if `orientation` is "v" ("h") Use with `fillcolor` if not "none". "tozerox" and "tozeroy" fill to x=0 and y=0 respectively. "tonextx" and "tonexty" fill between the endpoints of this trace and the endpoints of the trace before it, connecting those endpoints with straight lines (to make a stacked area graph); if there is no trace before it, they behave like "tozerox" and "tozeroy". "toself" connects the endpoints of the trace (or each segment of the trace if it has gaps) into a closed shape. "tonext" fills the space between two traces if one completely encloses the other (eg consecutive contour lines), and behaves like "toself" if there is no trace before it. "tonext" should not be used if one trace does not enclose the other. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order.</param>
    /// <param name="FillColor">Sets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
    /// <param name="FillPattern">Sets the pattern within the marker.</param>
    /// <param name="HoverLabel">Sets the style of the hoverlabels of this trace.</param>
    /// <param name="HoverOn">Do the hover effects highlight individual points (markers or line points) or do they highlight filled regions? If the fill is "toself" or "tonext" and there are no markers or text, then the default is "fills", otherwise it is "points".</param>
    /// <param name="StackGaps">Only relevant when `stackgroup` is used, and only the first `stackgaps` found in the `stackgroup` will be used - including if `visible` is "legendonly" but not if it is `false`. Determines how we handle locations at which other traces in this group have data but this one does not. With "infer zero" we insert a zero at these locations. With "interpolate" we linearly interpolate between existing values, and extrapolate a constant beyond the existing values.</param>
    /// <param name="XCalendar">Sets the calendar system to use with `x` date data.</param>
    /// <param name="YCalendar">Sets the calendar system to use with `y` date data.</param>
    /// <param name="UIRevision">Controls persistence of some user-driven changes to the trace: `constraintrange` in `parcoords` traces, as well as some `editable: true` modifications such as `name` and `colorbar.title`. Defaults to `layout.uirevision`. Note that other user-driven trace attribute changes are controlled by `layout` attributes: `trace.visible` is controlled by `layout.legend.uirevision`, `selectedpoints` is controlled by `layout.selectionrevision`, and `colorbar.(x|y)` (accessible with `config: {editable: true}`) is controlled by `layout.editrevision`. Trace changes are tracked by `uid`, which only falls back on trace index if no `uid` is provided. So if your app can add/remove traces before the end of the `data` array, such that the same trace has a different index, you can still preserve user-driven changes if you give each trace a `uid` that stays with it as it moves.</param>
    static member Scatter
        (
            [<Optional; DefaultParameterValue(null)>] ?Name: string,
            [<Optional; DefaultParameterValue(null)>] ?Visible: StyleParam.Visible,
            [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
            [<Optional; DefaultParameterValue(null)>] ?Legend: StyleParam.SubPlotId,
            [<Optional; DefaultParameterValue(null)>] ?LegendRank: int,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroup: string,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroupTitle: Title,
            [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
            [<Optional; DefaultParameterValue(null)>] ?Mode: StyleParam.Mode,
            [<Optional; DefaultParameterValue(null)>] ?Ids: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?X: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?MultiX: seq<seq<#IConvertible>>,
            [<Optional; DefaultParameterValue(null)>] ?X0: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?DX: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?Y: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?MultiY: seq<seq<#IConvertible>>,
            [<Optional; DefaultParameterValue(null)>] ?Y0: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?DY: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?TextPosition: StyleParam.TextPosition,
            [<Optional; DefaultParameterValue(null)>] ?MultiTextPosition: seq<StyleParam.TextPosition>,
            [<Optional; DefaultParameterValue(null)>] ?TextTemplate: string,
            [<Optional; DefaultParameterValue(null)>] ?MultiTextTemplate: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?HoverText: string,
            [<Optional; DefaultParameterValue(null)>] ?MultiHoverText: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?HoverInfo: StyleParam.HoverInfo,
            [<Optional; DefaultParameterValue(null)>] ?HoverTemplate: string,
            [<Optional; DefaultParameterValue(null)>] ?MultiHoverTemplate: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?XHoverFormat: string,
            [<Optional; DefaultParameterValue(null)>] ?YHoverFormat: string,
            [<Optional; DefaultParameterValue(null)>] ?Meta: string,
            [<Optional; DefaultParameterValue(null)>] ?CustomData: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?XAxis: StyleParam.LinearAxisId,
            [<Optional; DefaultParameterValue(null)>] ?YAxis: StyleParam.LinearAxisId,
            [<Optional; DefaultParameterValue(null)>] ?Orientation: StyleParam.Orientation,
            [<Optional; DefaultParameterValue(null)>] ?GroupNorm: StyleParam.GroupNorm,
            [<Optional; DefaultParameterValue(null)>] ?AlignmentGroup: string,
            [<Optional; DefaultParameterValue(null)>] ?OffsetGroup: string,
            [<Optional; DefaultParameterValue(null)>] ?StackGroup: string,
            [<Optional; DefaultParameterValue(null)>] ?XPeriod: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?XPeriodAlignment: StyleParam.PeriodAlignment,
            [<Optional; DefaultParameterValue(null)>] ?XPeriod0: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?YPeriod: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?YPeriodAlignment: StyleParam.PeriodAlignment,
            [<Optional; DefaultParameterValue(null)>] ?YPeriod0: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
            [<Optional; DefaultParameterValue(null)>] ?Line: Line,
            [<Optional; DefaultParameterValue(null)>] ?TextFont: Font,
            [<Optional; DefaultParameterValue(null)>] ?XError: Error,
            [<Optional; DefaultParameterValue(null)>] ?YError: Error,
            [<Optional; DefaultParameterValue(null)>] ?SelectedPoints: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Selected: TraceSelection,
            [<Optional; DefaultParameterValue(null)>] ?Unselected: TraceSelection,
            [<Optional; DefaultParameterValue(null)>] ?ClipOnAxis: bool,
            [<Optional; DefaultParameterValue(null)>] ?ConnectGaps: bool,
            [<Optional; DefaultParameterValue(null)>] ?Fill: StyleParam.Fill,
            [<Optional; DefaultParameterValue(null)>] ?FillColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?FillPattern: Pattern,
            [<Optional; DefaultParameterValue(null)>] ?HoverLabel: Hoverlabel,
            [<Optional; DefaultParameterValue(null)>] ?HoverOn: StyleParam.HoverOn,
            [<Optional; DefaultParameterValue(null)>] ?StackGaps: StyleParam.StackGaps,
            [<Optional; DefaultParameterValue(null)>] ?XCalendar: StyleParam.Calendar,
            [<Optional; DefaultParameterValue(null)>] ?YCalendar: StyleParam.Calendar,
            [<Optional; DefaultParameterValue(null)>] ?UIRevision: string
        ) =
        (fun (trace: ('T :> Trace)) ->

            Name |> DynObj.setOptionalProperty trace "name"
            Visible |> DynObj.setOptionalPropertyBy trace "visible" StyleParam.Visible.convert
            ShowLegend |> DynObj.setOptionalProperty trace "showlegend"
            Legend |> DynObj.setOptionalPropertyBy trace "legend" StyleParam.SubPlotId.convert
            LegendRank |> DynObj.setOptionalProperty trace "legendrank"
            LegendGroup |> DynObj.setOptionalProperty trace "legendgroup"
            LegendGroupTitle |> DynObj.setOptionalProperty trace "legendgrouptitle"
            Opacity |> DynObj.setOptionalProperty trace "opacity"
            Mode |> DynObj.setOptionalPropertyBy trace "mode" StyleParam.Mode.convert
            Ids |> DynObj.setOptionalProperty trace "ids"
            (X, MultiX) |> DynObj.setOptionalSingleOrMultiProperty trace "x"
            X0 |> DynObj.setOptionalProperty trace "x0"
            DX |> DynObj.setOptionalProperty trace "dx"
            (Y, MultiY) |> DynObj.setOptionalSingleOrMultiProperty trace "y"
            Y0 |> DynObj.setOptionalProperty trace "y0"
            DY |> DynObj.setOptionalProperty trace "dy"
            (Text, MultiText) |> DynObj.setOptionalSingleOrMultiProperty trace "text"

            (TextPosition, MultiTextPosition)
            |> DynObj.setSingleOrMultiOptBy trace "textposition" StyleParam.TextPosition.convert

            (TextTemplate, MultiTextTemplate) |> DynObj.setOptionalSingleOrMultiProperty trace "texttemplate"
            (HoverText, MultiHoverText) |> DynObj.setOptionalSingleOrMultiProperty trace "hovertext"
            HoverInfo |> DynObj.setOptionalPropertyBy trace "hoverinfo" StyleParam.HoverInfo.convert
            (HoverTemplate, MultiHoverTemplate) |> DynObj.setOptionalSingleOrMultiProperty trace "hovertemplate"
            XHoverFormat |> DynObj.setOptionalProperty trace "xhoverformat"
            YHoverFormat |> DynObj.setOptionalProperty trace "yhoverformat"
            Meta |> DynObj.setOptionalProperty trace "meta"
            CustomData |> DynObj.setOptionalProperty trace "customdata"
            XAxis |> DynObj.setOptionalPropertyBy trace "xaxis" StyleParam.LinearAxisId.convert
            YAxis |> DynObj.setOptionalPropertyBy trace "yaxis" StyleParam.LinearAxisId.convert
            Orientation |> DynObj.setOptionalPropertyBy trace "orientation" StyleParam.Orientation.convert
            GroupNorm |> DynObj.setOptionalPropertyBy trace "groupnorm" StyleParam.GroupNorm.convert
            AlignmentGroup |> DynObj.setOptionalProperty trace "alignmentgroup"
            OffsetGroup |> DynObj.setOptionalProperty trace "offsetgroup"
            StackGroup |> DynObj.setOptionalProperty trace "stackgroup"
            XPeriod |> DynObj.setOptionalProperty trace "xperiod"
            XPeriodAlignment |> DynObj.setOptionalPropertyBy trace "xperiodalignment" StyleParam.PeriodAlignment.convert
            XPeriod0 |> DynObj.setOptionalProperty trace "xperiod0"
            YPeriod |> DynObj.setOptionalProperty trace "yperiod"
            YPeriodAlignment |> DynObj.setOptionalPropertyBy trace "yperiodalignment" StyleParam.PeriodAlignment.convert
            YPeriod0 |> DynObj.setOptionalProperty trace "yperiod0"
            Marker |> DynObj.setOptionalProperty trace "marker"
            Line |> DynObj.setOptionalProperty trace "line"
            TextFont |> DynObj.setOptionalProperty trace "textfont"
            XError |> DynObj.setOptionalProperty trace "error_x"
            YError |> DynObj.setOptionalProperty trace "error_y"
            SelectedPoints |> DynObj.setOptionalProperty trace "selectedpoints"
            Selected |> DynObj.setOptionalProperty trace "selected"
            Unselected |> DynObj.setOptionalProperty trace "unselected"
            ClipOnAxis |> DynObj.setOptionalProperty trace "cliponaxis"
            ConnectGaps |> DynObj.setOptionalProperty trace "connectgaps"
            Fill |> DynObj.setOptionalPropertyBy trace "fill" StyleParam.Fill.convert
            FillColor |> DynObj.setOptionalProperty trace "fillcolor"
            FillPattern |> DynObj.setOptionalProperty trace "fillpattern"
            HoverLabel |> DynObj.setOptionalProperty trace "hoverlabel"
            HoverOn |> DynObj.setOptionalPropertyBy trace "hoveron" StyleParam.HoverOn.convert
            StackGaps |> DynObj.setOptionalPropertyBy trace "stackgaps" StyleParam.StackGaps.convert
            XCalendar |> DynObj.setOptionalPropertyBy trace "xcalendar" StyleParam.Calendar.convert
            YCalendar |> DynObj.setOptionalPropertyBy trace "ycalendar" StyleParam.Calendar.convert
            UIRevision |> DynObj.setOptionalProperty trace "uirevision"

            trace)

    /// <summary>
    /// Create a function that applies the styles of a bar plot to a Trace object
    /// </summary>
    /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
    /// <param name="Visible">Determines whether or not this trace is visible. If "legendonly", the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).</param>
    /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
    /// <param name="Legend">Sets the reference to a legend to show this trace in. References to these legends are "legend", "legend2", "legend3", etc. Settings for these legends are set in the layout, under `layout.legend`, `layout.legend2`, etc.</param>
    /// <param name="LegendRank">Sets the legend rank for this trace. Items and groups with smaller ranks are presented on top/left side while with `"reversed" `legend.traceorder` they are on bottom/right side. The default legendrank is 1000, so that you can use ranks less than 1000 to place certain items before all unranked items, and ranks greater than 1000 to go after all unranked items.</param>
    /// <param name="LegendGroup">Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling legend items.</param>
    /// <param name="LegendGroupTitle">Sets the legend group title for this trace.</param>
    /// <param name="Opacity">Sets the opacity of the trace.</param>
    /// <param name="Ids">Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.</param>
    /// <param name="X">Sets the x coordinates.</param>
    /// <param name="MultiX">Sets the x coordinates.</param>
    /// <param name="X0">Alternate to `x`. Builds a linear space of x coordinates. Use with `dx` where `x0` is the starting coordinate and `dx` the step.</param>
    /// <param name="DX">Sets the x coordinate step. See `x0` for more info.</param>
    /// <param name="Y">Sets the y coordinates.</param>
    /// <param name="MultiY">Sets the y coordinates.</param>
    /// <param name="Y0">Alternate to `y`. Builds a linear space of y coordinates. Use with `dy` where `y0` is the starting coordinate and `dy` the step.</param>
    /// <param name="DY">Sets the y coordinate step. See `y0` for more info.</param>
    /// <param name="Base">Sets where the bar base is drawn (in position axis units). In "stack" or "relative" barmode, traces that set "base" will be excluded and drawn in "overlay" mode instead.</param>
    /// <param name="Width">Sets the bar width (in position axis units).</param>
    /// <param name="MultiWidth">Sets the bar width (in position axis units).</param>
    /// <param name="Offset">Shifts the position where the bar is drawn (in position axis units). In "group" barmode, traces that set "offset" will be excluded and drawn in "overlay" mode instead.</param>
    /// <param name="MultiOffset">Shifts the position where the bar is drawn (in position axis units). In "group" barmode, traces that set "offset" will be excluded and drawn in "overlay" mode instead.</param>
    /// <param name="Text">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
    /// <param name="MultiText">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
    /// <param name="TextPosition">Specifies the location of the `text`. "inside" positions `text` inside, next to the bar end (rotated and scaled if needed). "outside" positions `text` outside, next to the bar end (scaled if needed), unless there is another bar stacked on this one, then the text gets pushed inside. "auto" tries to position `text` inside the bar, but if the bar is too small and no bar is stacked on this one the text is moved outside. If "none", no text appears.</param>
    /// <param name="MultiTextPosition">Specifies the location of the `text`. "inside" positions `text` inside, next to the bar end (rotated and scaled if needed). "outside" positions `text` outside, next to the bar end (scaled if needed), unless there is another bar stacked on this one, then the text gets pushed inside. "auto" tries to position `text` inside the bar, but if the bar is too small and no bar is stacked on this one the text is moved outside. If "none", no text appears.</param>
    /// <param name="TextTemplate">Template string used for rendering the information text that appear on points. Note that this will override `textinfo`. Variables are inserted using %{variable}, for example "y: %{y}". Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. Every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available.</param>
    /// <param name="MultiTextTemplate">Template string used for rendering the information text that appear on points. Note that this will override `textinfo`. Variables are inserted using %{variable}, for example "y: %{y}". Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. Every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available.</param>
    /// <param name="HoverText">Sets hover text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. To be seen, trace `hoverinfo` must contain a "text" flag.</param>
    /// <param name="MultiHoverText">Sets hover text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. To be seen, trace `hoverinfo` must contain a "text" flag.</param>
    /// <param name="HoverInfo">Determines which trace information appear on hover. If `none` or `skip` are set, no information is displayed upon hovering. But, if `none` is set, click and hover events are still fired.</param>
    /// <param name="HoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
    /// <param name="MultiHoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
    /// <param name="XHoverFormat">Sets the hover text formatting rulefor `x` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `xaxis.hoverformat`.</param>
    /// <param name="YHoverFormat">Sets the hover text formatting rulefor `y` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `xaxis.hoverformat`.</param>
    /// <param name="Meta">Assigns extra meta information associated with this trace that can be used in various text attributes. Attributes such as trace `name`, graph, axis and colorbar `title.text`, annotation `text` `rangeselector`, `updatemenues` and `sliders` `label` text all support `meta`. To access the trace `meta` values in an attribute in the same trace, simply use `%{meta[i]}` where `i` is the index or key of the `meta` item in question. To access trace `meta` in layout attributes, use `%{data[n[.meta[i]}` where `i` is the index or key of the `meta` and `n` is the trace index.</param>
    /// <param name="CustomData">Assigns extra data each datum. This may be useful when listening to hover, click and selection events. Note that, "scatter" traces also appends customdata items in the markers DOM elements</param>
    /// <param name="XAxis">Sets a reference between this trace's x coordinates and a 2D cartesian x axis. If "x" (the default value), the x coordinates refer to `layout.xaxis`. If "x2", the x coordinates refer to `layout.xaxis2`, and so on.</param>
    /// <param name="YAxis">Sets a reference between this trace's y coordinates and a 2D cartesian y axis. If "y" (the default value), the y coordinates refer to `layout.yaxis`. If "y2", the y coordinates refer to `layout.yaxis2`, and so on.</param>
    /// <param name="Orientation">Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used - including if `visible` is "legendonly" but not if it is `false`. Sets the stacking direction. With "v" ("h"), the y (x) values of subsequent traces are added. Also affects the default value of `fill`.</param>
    /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
    /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
    /// <param name="XPeriod">Only relevant when the axis `type` is "date". Sets the period positioning in milliseconds or "M&lt;n&gt;" on the x axis. Special values in the form of "M&lt;n&gt;" could be used to declare the number of months. In this case `n` must be a positive integer.</param>
    /// <param name="XPeriodAlignment">Only relevant when the axis `type` is "date". Sets the alignment of data points on the x axis.</param>
    /// <param name="XPeriod0">Only relevant when the axis `type` is "date". Sets the base for period positioning in milliseconds or date string on the x0 axis. When `x0period` is round number of weeks, the `x0period0` by default would be on a Sunday i.e. 2000-01-02, otherwise it would be at 2000-01-01.</param>
    /// <param name="YPeriod">Only relevant when the axis `type` is "date". Sets the period positioning in milliseconds or "M&lt;n&gt;" on the y axis. Special values in the form of "M&lt;n&gt;" could be used to declare the number of months. In this case `n` must be a positive integer.</param>
    /// <param name="YPeriodAlignment">Only relevant when the axis `type` is "date". Sets the alignment of data points on the y axis.</param>
    /// <param name="YPeriod0">Only relevant when the axis `type` is "date". Sets the base for period positioning in milliseconds or date string on the y0 axis. When `y0period` is round number of weeks, the `y0period0` by default would be on a Sunday i.e. 2000-01-02, otherwise it would be at 2000-01-01.</param>
    /// <param name="Marker">Sets the marker of this trace.</param>
    /// <param name="TextAngle">Sets the angle of the tick labels with respect to the bar. For example, a `tickangle` of -90 draws the tick labels vertically. With "auto" the texts may automatically be rotated to fit with the maximum size in bars.</param>
    /// <param name="TextFont">Sets the font used for `text`.</param>
    /// <param name="XError">Sets the x error of this trace.</param>
    /// <param name="YError">Sets the y error of this trace.</param>
    /// <param name="SelectedPoints">Array containing integer indices of selected points. Has an effect only for traces that support selections. Note that an empty array means an empty selection where the `unselected` are turned on for all points, whereas, any other non-array values means no selection all where the `selected` and `unselected` styles have no effect.</param>
    /// <param name="Selected">Sets the style of selected points of this trace.</param>
    /// <param name="Unselected">Sets the style of unselected points of this trace.</param>
    /// <param name="ClipOnAxis">Determines whether or not markers and text nodes are clipped about the subplot axes. To show markers and text nodes above axis lines and tick labels, make sure to set `xaxis.layer` and `yaxis.layer` to "below traces".</param>
    /// <param name="Constraintext">Constrain the size of text inside or outside a bar to be no larger than the bar itself.</param>
    /// <param name="HoverLabel">Sets the style of the hoverlabels of this trace.</param>
    /// <param name="InsideTextAnchor">Determines if texts are kept at center or start/end points in `textposition` "inside" mode.</param>
    /// <param name="InsideTextFont">Sets the font used for `text` lying inside the bar.</param>
    /// <param name="OutsideTextFont">Sets the font used for `text` lying outside the bar.</param>
    /// <param name="XCalendar">Sets the calendar system to use with `x` date data.</param>
    /// <param name="YCalendar">Sets the calendar system to use with `y` date data.</param>
    /// <param name="UIRevision">Controls persistence of some user-driven changes to the trace: `constraintrange` in `parcoords` traces, as well as some `editable: true` modifications such as `name` and `colorbar.title`. Defaults to `layout.uirevision`. Note that other user-driven trace attribute changes are controlled by `layout` attributes: `trace.visible` is controlled by `layout.legend.uirevision`, `selectedpoints` is controlled by `layout.selectionrevision`, and `colorbar.(x|y)` (accessible with `config: {editable: true}`) is controlled by `layout.editrevision`. Trace changes are tracked by `uid`, which only falls back on trace index if no `uid` is provided. So if your app can add/remove traces before the end of the `data` array, such that the same trace has a different index, you can still preserve user-driven changes if you give each trace a `uid` that stays with it as it moves.</param>
    static member Bar
        (
            [<Optional; DefaultParameterValue(null)>] ?Name: string,
            [<Optional; DefaultParameterValue(null)>] ?Visible: StyleParam.Visible,
            [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
            [<Optional; DefaultParameterValue(null)>] ?Legend: StyleParam.SubPlotId,
            [<Optional; DefaultParameterValue(null)>] ?LegendRank: int,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroup: string,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroupTitle: Title,
            [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
            [<Optional; DefaultParameterValue(null)>] ?Ids: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?X: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?MultiX: seq<seq<#IConvertible>>,
            [<Optional; DefaultParameterValue(null)>] ?X0: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?DX: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?Y: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?MultiY: seq<seq<#IConvertible>>,
            [<Optional; DefaultParameterValue(null)>] ?Y0: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?DY: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?Base: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?Width: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?MultiWidth: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Offset: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?MultiOffset: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?TextPosition: StyleParam.TextPosition,
            [<Optional; DefaultParameterValue(null)>] ?MultiTextPosition: seq<StyleParam.TextPosition>,
            [<Optional; DefaultParameterValue(null)>] ?TextTemplate: string,
            [<Optional; DefaultParameterValue(null)>] ?MultiTextTemplate: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?HoverText: string,
            [<Optional; DefaultParameterValue(null)>] ?MultiHoverText: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?HoverInfo: StyleParam.HoverInfo,
            [<Optional; DefaultParameterValue(null)>] ?HoverTemplate: string,
            [<Optional; DefaultParameterValue(null)>] ?MultiHoverTemplate: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?XHoverFormat: string,
            [<Optional; DefaultParameterValue(null)>] ?YHoverFormat: string,
            [<Optional; DefaultParameterValue(null)>] ?Meta: string,
            [<Optional; DefaultParameterValue(null)>] ?CustomData: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?XAxis: StyleParam.LinearAxisId,
            [<Optional; DefaultParameterValue(null)>] ?YAxis: StyleParam.LinearAxisId,
            [<Optional; DefaultParameterValue(null)>] ?Orientation: StyleParam.Orientation,
            [<Optional; DefaultParameterValue(null)>] ?AlignmentGroup: string,
            [<Optional; DefaultParameterValue(null)>] ?OffsetGroup: string,
            [<Optional; DefaultParameterValue(null)>] ?XPeriod: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?XPeriodAlignment: StyleParam.PeriodAlignment,
            [<Optional; DefaultParameterValue(null)>] ?XPeriod0: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?YPeriod: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?YPeriodAlignment: StyleParam.PeriodAlignment,
            [<Optional; DefaultParameterValue(null)>] ?YPeriod0: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
            [<Optional; DefaultParameterValue(null)>] ?TextAngle: float,
            [<Optional; DefaultParameterValue(null)>] ?TextFont: Font,
            [<Optional; DefaultParameterValue(null)>] ?XError: Error,
            [<Optional; DefaultParameterValue(null)>] ?YError: Error,
            [<Optional; DefaultParameterValue(null)>] ?SelectedPoints: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Selected: TraceSelection,
            [<Optional; DefaultParameterValue(null)>] ?Unselected: TraceSelection,
            [<Optional; DefaultParameterValue(null)>] ?ClipOnAxis: bool,
            [<Optional; DefaultParameterValue(null)>] ?Constraintext: StyleParam.ConstrainText,
            [<Optional; DefaultParameterValue(null)>] ?HoverLabel: Hoverlabel,
            [<Optional; DefaultParameterValue(null)>] ?InsideTextAnchor: StyleParam.InsideTextAnchor,
            [<Optional; DefaultParameterValue(null)>] ?InsideTextFont: Font,
            [<Optional; DefaultParameterValue(null)>] ?OutsideTextFont: Font,
            [<Optional; DefaultParameterValue(null)>] ?XCalendar: StyleParam.Calendar,
            [<Optional; DefaultParameterValue(null)>] ?YCalendar: StyleParam.Calendar,
            [<Optional; DefaultParameterValue(null)>] ?UIRevision: string
        ) =
        (fun (bar: ('T :> Trace)) ->

            Name |> DynObj.setOptionalProperty bar "name"
            Visible |> DynObj.setOptionalPropertyBy bar "visible" StyleParam.Visible.convert
            ShowLegend |> DynObj.setOptionalProperty bar "showlegend"
            Legend |> DynObj.setOptionalPropertyBy bar "legend" StyleParam.SubPlotId.convert
            LegendRank |> DynObj.setOptionalProperty bar "legendrank"
            LegendGroup |> DynObj.setOptionalProperty bar "legendgroup"
            LegendGroupTitle |> DynObj.setOptionalProperty bar "legendgrouptitle"
            Opacity |> DynObj.setOptionalProperty bar "opacity"
            Ids |> DynObj.setOptionalProperty bar "ids"
            (X, MultiX) |> DynObj.setOptionalSingleOrMultiProperty bar "x"
            X0 |> DynObj.setOptionalProperty bar "x0"
            DX |> DynObj.setOptionalProperty bar "dx"
            (Y, MultiY) |> DynObj.setOptionalSingleOrMultiProperty bar "y"
            Y0 |> DynObj.setOptionalProperty bar "y0"
            DY |> DynObj.setOptionalProperty bar "dy"
            Base |> DynObj.setOptionalProperty bar "base"
            (Width, MultiWidth) |> DynObj.setOptionalSingleOrMultiProperty bar "width"
            (Offset, MultiOffset) |> DynObj.setOptionalSingleOrMultiProperty bar "offset"
            (Text, MultiText) |> DynObj.setOptionalSingleOrMultiProperty bar "text"

            (TextPosition, MultiTextPosition)
            |> DynObj.setSingleOrMultiOptBy bar "textposition" StyleParam.TextPosition.convert

            (TextTemplate, MultiTextTemplate) |> DynObj.setOptionalSingleOrMultiProperty bar "texttemplate"
            (HoverText, MultiHoverText) |> DynObj.setOptionalSingleOrMultiProperty bar "hovertext"
            HoverInfo |> DynObj.setOptionalPropertyBy bar "hoverinfo" StyleParam.HoverInfo.convert
            (HoverTemplate, MultiHoverTemplate) |> DynObj.setOptionalSingleOrMultiProperty bar "hovertemplate"
            XHoverFormat |> DynObj.setOptionalProperty bar "xhoverformat"
            YHoverFormat |> DynObj.setOptionalProperty bar "yhoverformat"
            Meta |> DynObj.setOptionalProperty bar "meta"
            CustomData |> DynObj.setOptionalProperty bar "customdata"
            XAxis |> DynObj.setOptionalPropertyBy bar "xaxis" StyleParam.LinearAxisId.convert
            YAxis |> DynObj.setOptionalPropertyBy bar "yaxis" StyleParam.LinearAxisId.convert
            Orientation |> DynObj.setOptionalPropertyBy bar "orientation" StyleParam.Orientation.convert
            AlignmentGroup |> DynObj.setOptionalProperty bar "alignmentgroup"
            OffsetGroup |> DynObj.setOptionalProperty bar "offsetgroup"
            XPeriod |> DynObj.setOptionalProperty bar "xperiod"
            XPeriodAlignment |> DynObj.setOptionalPropertyBy bar "xperiodalignment" StyleParam.PeriodAlignment.convert
            XPeriod0 |> DynObj.setOptionalProperty bar "xperiod0"
            YPeriod |> DynObj.setOptionalProperty bar "yperiod"
            YPeriodAlignment |> DynObj.setOptionalPropertyBy bar "yperiodalignment" StyleParam.PeriodAlignment.convert
            YPeriod0 |> DynObj.setOptionalProperty bar "yperiod0"
            Marker |> DynObj.setOptionalProperty bar "marker"
            TextAngle |> DynObj.setOptionalProperty bar "textangle"
            TextFont |> DynObj.setOptionalProperty bar "textfont"
            XError |> DynObj.setOptionalProperty bar "error_x"
            YError |> DynObj.setOptionalProperty bar "error_y"
            SelectedPoints |> DynObj.setOptionalProperty bar "selectedpoints"
            Selected |> DynObj.setOptionalProperty bar "selected"
            Unselected |> DynObj.setOptionalProperty bar "unselected"
            ClipOnAxis |> DynObj.setOptionalProperty bar "cliponaxis"
            Constraintext |> DynObj.setOptionalPropertyBy bar "constraintext" StyleParam.ConstrainText.convert
            HoverLabel |> DynObj.setOptionalProperty bar "hoverlabel"
            InsideTextAnchor |> DynObj.setOptionalPropertyBy bar "insidetextanchor" StyleParam.InsideTextAnchor.convert
            InsideTextFont |> DynObj.setOptionalProperty bar "insidetextfont"
            OutsideTextFont |> DynObj.setOptionalProperty bar "outsidetextfont"
            XCalendar |> DynObj.setOptionalPropertyBy bar "xcalendar" StyleParam.Calendar.convert
            YCalendar |> DynObj.setOptionalPropertyBy bar "ycalendar" StyleParam.Calendar.convert
            UIRevision |> DynObj.setOptionalProperty bar "uirevision"

            bar

        )

    /// <summary>
    /// Create a function that applies the styles of a funnel plot to a Trace object
    /// </summary>
    /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
    /// <param name="Visible">Determines whether or not this trace is visible. If "legendonly", the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).</param>
    /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
    /// <param name="Legend">Sets the reference to a legend to show this trace in. References to these legends are "legend", "legend2", "legend3", etc. Settings for these legends are set in the layout, under `layout.legend`, `layout.legend2`, etc.</param>
    /// <param name="LegendRank">Sets the legend rank for this trace. Items and groups with smaller ranks are presented on top/left side while with `"reversed" `legend.traceorder` they are on bottom/right side. The default legendrank is 1000, so that you can use ranks less than 1000 to place certain items before all unranked items, and ranks greater than 1000 to go after all unranked items.</param>
    /// <param name="LegendGroup">Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling legend items.</param>
    /// <param name="LegendGroupTitle">Sets the legend group title for this trace.</param>
    /// <param name="Opacity">Sets the opacity of the trace.</param>
    /// <param name="Ids">Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.</param>
    /// <param name="X">Sets the x coordinates.</param>
    /// <param name="MultiX">Sets the x coordinates.</param>
    /// <param name="X0">Alternate to `x`. Builds a linear space of x coordinates. Use with `dx` where `x0` is the starting coordinate and `dx` the step.</param>
    /// <param name="DX">Sets the x coordinate step. See `x0` for more info.</param>
    /// <param name="Y">Sets the y coordinates.</param>
    /// <param name="MultiY">Sets the y coordinates.</param>
    /// <param name="Y0">Alternate to `y`. Builds a linear space of y coordinates. Use with `dy` where `y0` is the starting coordinate and `dy` the step.</param>
    /// <param name="DY">Sets the y coordinate step. See `y0` for more info.</param>
    /// <param name="Width">Sets the bar width (in position axis units).</param>
    /// <param name="Offset">Shifts the position where the bar is drawn (in position axis units). In "group" barmode, traces that set "offset" will be excluded and drawn in "overlay" mode instead.</param>
    /// <param name="Text">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
    /// <param name="MultiText">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
    /// <param name="TextPosition">Specifies the location of the `text`. "inside" positions `text` inside, next to the bar end (rotated and scaled if needed). "outside" positions `text` outside, next to the bar end (scaled if needed), unless there is another bar stacked on this one, then the text gets pushed inside. "auto" tries to position `text` inside the bar, but if the bar is too small and no bar is stacked on this one the text is moved outside. If "none", no text appears.</param>
    /// <param name="MultiTextPosition">Specifies the location of the `text`. "inside" positions `text` inside, next to the bar end (rotated and scaled if needed). "outside" positions `text` outside, next to the bar end (scaled if needed), unless there is another bar stacked on this one, then the text gets pushed inside. "auto" tries to position `text` inside the bar, but if the bar is too small and no bar is stacked on this one the text is moved outside. If "none", no text appears.</param>
    /// <param name="TextTemplate">Template string used for rendering the information text that appear on points. Note that this will override `textinfo`. Variables are inserted using %{variable}, for example "y: %{y}". Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. Every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available.</param>
    /// <param name="MultiTextTemplate">Template string used for rendering the information text that appear on points. Note that this will override `textinfo`. Variables are inserted using %{variable}, for example "y: %{y}". Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. Every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available.</param>
    /// <param name="HoverText">Sets hover text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. To be seen, trace `hoverinfo` must contain a "text" flag.</param>
    /// <param name="MultiHoverText">Sets hover text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. To be seen, trace `hoverinfo` must contain a "text" flag.</param>
    /// <param name="HoverInfo">Determines which trace information appear on hover. If `none` or `skip` are set, no information is displayed upon hovering. But, if `none` is set, click and hover events are still fired.</param>
    /// <param name="HoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
    /// <param name="MultiHoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
    /// <param name="XHoverFormat">Sets the hover text formatting rulefor `x` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `xaxis.hoverformat`.</param>
    /// <param name="YHoverFormat">Sets the hover text formatting rulefor `y` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `xaxis.hoverformat`.</param>
    /// <param name="Meta">Assigns extra meta information associated with this trace that can be used in various text attributes. Attributes such as trace `name`, graph, axis and colorbar `title.text`, annotation `text` `rangeselector`, `updatemenues` and `sliders` `label` text all support `meta`. To access the trace `meta` values in an attribute in the same trace, simply use `%{meta[i]}` where `i` is the index or key of the `meta` item in question. To access trace `meta` in layout attributes, use `%{data[n[.meta[i]}` where `i` is the index or key of the `meta` and `n` is the trace index.</param>
    /// <param name="CustomData">Assigns extra data each datum. This may be useful when listening to hover, click and selection events. Note that, "scatter" traces also appends customdata items in the markers DOM elements</param>
    /// <param name="XAxis">Sets a reference between this trace's x coordinates and a 2D cartesian x axis. If "x" (the default value), the x coordinates refer to `layout.xaxis`. If "x2", the x coordinates refer to `layout.xaxis2`, and so on.</param>
    /// <param name="YAxis">Sets a reference between this trace's y coordinates and a 2D cartesian y axis. If "y" (the default value), the y coordinates refer to `layout.yaxis`. If "y2", the y coordinates refer to `layout.yaxis2`, and so on.</param>
    /// <param name="Orientation">Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used - including if `visible` is "legendonly" but not if it is `false`. Sets the stacking direction. With "v" ("h"), the y (x) values of subsequent traces are added. Also affects the default value of `fill`.</param>
    /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
    /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
    /// <param name="XPeriod">Only relevant when the axis `type` is "date". Sets the period positioning in milliseconds or "M&lt;n&gt;" on the x axis. Special values in the form of "M&lt;n&gt;" could be used to declare the number of months. In this case `n` must be a positive integer.</param>
    /// <param name="XPeriodAlignment">Only relevant when the axis `type` is "date". Sets the alignment of data points on the x axis.</param>
    /// <param name="XPeriod0">Only relevant when the axis `type` is "date". Sets the base for period positioning in milliseconds or date string on the x0 axis. When `x0period` is round number of weeks, the `x0period0` by default would be on a Sunday i.e. 2000-01-02, otherwise it would be at 2000-01-01.</param>
    /// <param name="YPeriod">Only relevant when the axis `type` is "date". Sets the period positioning in milliseconds or "M&lt;n&gt;" on the y axis. Special values in the form of "M&lt;n&gt;" could be used to declare the number of months. In this case `n` must be a positive integer.</param>
    /// <param name="YPeriodAlignment">Only relevant when the axis `type` is "date". Sets the alignment of data points on the y axis.</param>
    /// <param name="YPeriod0">Only relevant when the axis `type` is "date". Sets the base for period positioning in milliseconds or date string on the y0 axis. When `y0period` is round number of weeks, the `y0period0` by default would be on a Sunday i.e. 2000-01-02, otherwise it would be at 2000-01-01.</param>
    /// <param name="Marker">Sets the marker of this trace.</param>
    /// <param name="TextAngle">Sets the angle of the tick labels with respect to the bar. For example, a `tickangle` of -90 draws the tick labels vertically. With "auto" the texts may automatically be rotated to fit with the maximum size in bars.</param>
    /// <param name="TextFont">Sets the font used for `text`.</param>
    /// <param name="TextInfo">Determines which trace information appear on the graph. In the case of having multiple funnels, percentages and totals are computed separately (per trace).</param>
    /// <param name="SelectedPoints">Array containing integer indices of selected points. Has an effect only for traces that support selections. Note that an empty array means an empty selection where the `unselected` are turned on for all points, whereas, any other non-array values means no selection all where the `selected` and `unselected` styles have no effect.</param>
    /// <param name="ClipOnAxis">Determines whether the text nodes are clipped about the subplot axes. To show the text nodes above axis lines and tick labels, make sure to set `xaxis.layer` and `yaxis.layer` to "below traces".</param>
    /// <param name="Connector">Sets the funnel connector of this trace</param>
    /// <param name="Constraintext">Constrain the size of text inside or outside a bar to be no larger than the bar itself.</param>
    /// <param name="HoverLabel">Sets the style of the hoverlabels of this trace.</param>
    /// <param name="InsideTextAnchor">Determines if texts are kept at center or start/end points in `textposition` "inside" mode.</param>
    /// <param name="InsideTextFont">Sets the font used for `text` lying inside the bar.</param>
    /// <param name="OutsideTextFont">Sets the font used for `text` lying outside the bar.</param>
    /// <param name="UIRevision">Controls persistence of some user-driven changes to the trace: `constraintrange` in `parcoords` traces, as well as some `editable: true` modifications such as `name` and `colorbar.title`. Defaults to `layout.uirevision`. Note that other user-driven trace attribute changes are controlled by `layout` attributes: `trace.visible` is controlled by `layout.legend.uirevision`, `selectedpoints` is controlled by `layout.selectionrevision`, and `colorbar.(x|y)` (accessible with `config: {editable: true}`) is controlled by `layout.editrevision`. Trace changes are tracked by `uid`, which only falls back on trace index if no `uid` is provided. So if your app can add/remove traces before the end of the `data` array, such that the same trace has a different index, you can still preserve user-driven changes if you give each trace a `uid` that stays with it as it moves.</param>
    static member Funnel
        (
            [<Optional; DefaultParameterValue(null)>] ?Name: string,
            [<Optional; DefaultParameterValue(null)>] ?Visible: StyleParam.Visible,
            [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
            [<Optional; DefaultParameterValue(null)>] ?Legend: StyleParam.SubPlotId,
            [<Optional; DefaultParameterValue(null)>] ?LegendRank: int,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroup: string,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroupTitle: Title,
            [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
            [<Optional; DefaultParameterValue(null)>] ?Ids: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?X: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?MultiX: seq<seq<#IConvertible>>,
            [<Optional; DefaultParameterValue(null)>] ?X0: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?DX: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?Y: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?MultiY: seq<seq<#IConvertible>>,
            [<Optional; DefaultParameterValue(null)>] ?Y0: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?DY: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?Width: float,
            [<Optional; DefaultParameterValue(null)>] ?Offset: float,
            [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?TextPosition: StyleParam.TextPosition,
            [<Optional; DefaultParameterValue(null)>] ?MultiTextPosition: seq<StyleParam.TextPosition>,
            [<Optional; DefaultParameterValue(null)>] ?TextTemplate: string,
            [<Optional; DefaultParameterValue(null)>] ?MultiTextTemplate: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?HoverText: string,
            [<Optional; DefaultParameterValue(null)>] ?MultiHoverText: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?HoverInfo: StyleParam.HoverInfo,
            [<Optional; DefaultParameterValue(null)>] ?HoverTemplate: string,
            [<Optional; DefaultParameterValue(null)>] ?MultiHoverTemplate: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?XHoverFormat: string,
            [<Optional; DefaultParameterValue(null)>] ?YHoverFormat: string,
            [<Optional; DefaultParameterValue(null)>] ?Meta: string,
            [<Optional; DefaultParameterValue(null)>] ?CustomData: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?XAxis: StyleParam.LinearAxisId,
            [<Optional; DefaultParameterValue(null)>] ?YAxis: StyleParam.LinearAxisId,
            [<Optional; DefaultParameterValue(null)>] ?Orientation: StyleParam.Orientation,
            [<Optional; DefaultParameterValue(null)>] ?AlignmentGroup: string,
            [<Optional; DefaultParameterValue(null)>] ?OffsetGroup: string,
            [<Optional; DefaultParameterValue(null)>] ?XPeriod: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?XPeriodAlignment: StyleParam.PeriodAlignment,
            [<Optional; DefaultParameterValue(null)>] ?XPeriod0: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?YPeriod: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?YPeriodAlignment: StyleParam.PeriodAlignment,
            [<Optional; DefaultParameterValue(null)>] ?YPeriod0: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
            [<Optional; DefaultParameterValue(null)>] ?TextAngle: float,
            [<Optional; DefaultParameterValue(null)>] ?TextFont: Font,
            [<Optional; DefaultParameterValue(null)>] ?TextInfo: StyleParam.TextInfo,
            [<Optional; DefaultParameterValue(null)>] ?SelectedPoints: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?ClipOnAxis: bool,
            [<Optional; DefaultParameterValue(null)>] ?Connector: FunnelConnector,
            [<Optional; DefaultParameterValue(null)>] ?Constraintext: StyleParam.ConstrainText,
            [<Optional; DefaultParameterValue(null)>] ?HoverLabel: Hoverlabel,
            [<Optional; DefaultParameterValue(null)>] ?InsideTextAnchor: StyleParam.InsideTextAnchor,
            [<Optional; DefaultParameterValue(null)>] ?InsideTextFont: Font,
            [<Optional; DefaultParameterValue(null)>] ?OutsideTextFont: Font,
            [<Optional; DefaultParameterValue(null)>] ?UIRevision: string
        ) =
        (fun (funnel: #Trace) ->

            Name |> DynObj.setOptionalProperty funnel "name"
            Visible |> DynObj.setOptionalPropertyBy funnel "visible" StyleParam.Visible.convert
            ShowLegend |> DynObj.setOptionalProperty funnel "showlegend"
            Legend |> DynObj.setOptionalPropertyBy funnel "legend" StyleParam.SubPlotId.convert
            LegendRank |> DynObj.setOptionalProperty funnel "legendrank"
            LegendGroup |> DynObj.setOptionalProperty funnel "legendgroup"
            LegendGroupTitle |> DynObj.setOptionalProperty funnel "legendgrouptitle"
            Opacity |> DynObj.setOptionalProperty funnel "opacity"
            Ids |> DynObj.setOptionalProperty funnel "ids"
            (X, MultiX) |> DynObj.setOptionalSingleOrMultiProperty funnel "x"
            X0 |> DynObj.setOptionalProperty funnel "x0"
            DX |> DynObj.setOptionalProperty funnel "dx"
            (Y, MultiY) |> DynObj.setOptionalSingleOrMultiProperty funnel "y"
            Y0 |> DynObj.setOptionalProperty funnel "y0"
            DY |> DynObj.setOptionalProperty funnel "dy"
            Width |> DynObj.setOptionalProperty funnel "width"
            Offset |> DynObj.setOptionalProperty funnel "offset"
            (Text, MultiText) |> DynObj.setOptionalSingleOrMultiProperty funnel "text"

            (TextPosition, MultiTextPosition)
            |> DynObj.setSingleOrMultiOptBy funnel "textposition" StyleParam.TextPosition.convert

            (TextTemplate, MultiTextTemplate) |> DynObj.setOptionalSingleOrMultiProperty funnel "texttemplate"
            (HoverText, MultiHoverText) |> DynObj.setOptionalSingleOrMultiProperty funnel "hovertext"
            HoverInfo |> DynObj.setOptionalPropertyBy funnel "hoverinfo" StyleParam.HoverInfo.convert
            (HoverTemplate, MultiHoverTemplate) |> DynObj.setOptionalSingleOrMultiProperty funnel "hovertemplate"
            XHoverFormat |> DynObj.setOptionalProperty funnel "xhoverformat"
            YHoverFormat |> DynObj.setOptionalProperty funnel "yhoverformat"
            Meta |> DynObj.setOptionalProperty funnel "meta"
            CustomData |> DynObj.setOptionalProperty funnel "customdata"
            XAxis |> DynObj.setOptionalPropertyBy funnel "xaxis" StyleParam.LinearAxisId.convert
            YAxis |> DynObj.setOptionalPropertyBy funnel "yaxis" StyleParam.LinearAxisId.convert
            Orientation |> DynObj.setOptionalPropertyBy funnel "orientation" StyleParam.Orientation.convert
            AlignmentGroup |> DynObj.setOptionalProperty funnel "alignmentgroup"
            OffsetGroup |> DynObj.setOptionalProperty funnel "offsetgroup"
            XPeriod |> DynObj.setOptionalProperty funnel "xperiod"
            XPeriodAlignment |> DynObj.setOptionalPropertyBy funnel "xperiodalignment" StyleParam.PeriodAlignment.convert
            XPeriod0 |> DynObj.setOptionalProperty funnel "xperiod0"
            YPeriod |> DynObj.setOptionalProperty funnel "yperiod"
            YPeriodAlignment |> DynObj.setOptionalPropertyBy funnel "yperiodalignment" StyleParam.PeriodAlignment.convert
            YPeriod0 |> DynObj.setOptionalProperty funnel "yperiod0"
            Marker |> DynObj.setOptionalProperty funnel "marker"
            TextAngle |> DynObj.setOptionalProperty funnel "textangle"
            TextFont |> DynObj.setOptionalProperty funnel "textfont"
            TextInfo |> DynObj.setOptionalPropertyBy funnel "textinfo" StyleParam.TextInfo.convert
            SelectedPoints |> DynObj.setOptionalProperty funnel "selectedpoints"
            ClipOnAxis |> DynObj.setOptionalProperty funnel "cliponaxis"
            Connector |> DynObj.setOptionalProperty funnel "connector"
            Constraintext |> DynObj.setOptionalPropertyBy funnel "constraintext" StyleParam.ConstrainText.convert
            HoverLabel |> DynObj.setOptionalProperty funnel "hoverlabel"
            InsideTextAnchor |> DynObj.setOptionalPropertyBy funnel "insidetextanchor" StyleParam.InsideTextAnchor.convert
            InsideTextFont |> DynObj.setOptionalProperty funnel "insidetextfont"
            OutsideTextFont |> DynObj.setOptionalProperty funnel "outsidetextfont"
            UIRevision |> DynObj.setOptionalProperty funnel "uirevision"

            funnel

        )

    /// <summary>
    /// Create a function that applies the styles of a waterfall plot to a Trace object
    /// </summary>
    /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
    /// <param name="Visible">Determines whether or not this trace is visible. If "legendonly", the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).</param>
    /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
    /// <param name="Legend">Sets the reference to a legend to show this trace in. References to these legends are "legend", "legend2", "legend3", etc. Settings for these legends are set in the layout, under `layout.legend`, `layout.legend2`, etc.</param>
    /// <param name="LegendRank">Sets the legend rank for this trace. Items and groups with smaller ranks are presented on top/left side while with `"reversed" `legend.traceorder` they are on bottom/right side. The default legendrank is 1000, so that you can use ranks less than 1000 to place certain items before all unranked items, and ranks greater than 1000 to go after all unranked items.</param>
    /// <param name="LegendGroup">Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling legend items.</param>
    /// <param name="LegendGroupTitle">Sets the legend group title for this trace.</param>
    /// <param name="Opacity">Sets the opacity of the trace.</param>
    /// <param name="Ids">Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.</param>
    /// <param name="X">Sets the x coordinates.</param>
    /// <param name="MultiX">Sets the x coordinates.</param>
    /// <param name="X0">Alternate to `x`. Builds a linear space of x coordinates. Use with `dx` where `x0` is the starting coordinate and `dx` the step.</param>
    /// <param name="DX">Sets the x coordinate step. See `x0` for more info.</param>
    /// <param name="Y">Sets the y coordinates.</param>
    /// <param name="MultiY">Sets the y coordinates.</param>
    /// <param name="Y0">Alternate to `y`. Builds a linear space of y coordinates. Use with `dy` where `y0` is the starting coordinate and `dy` the step.</param>
    /// <param name="DY">Sets the y coordinate step. See `y0` for more info.</param>
    /// <param name="Base">Sets where the bar base is drawn (in position axis units).</param>
    /// <param name="Width">Sets the bar width (in position axis units).</param>
    /// <param name="MultiWidth">Sets the bar width (in position axis units).</param>
    /// <param name="Measure">An array containing types of values. By default the values are considered as 'relative'. However; it is possible to use 'total' to compute the sums. Also 'absolute' could be applied to reset the computed total or to declare an initial value where needed.</param>
    /// <param name="Offset">Shifts the position where the bar is drawn (in position axis units). In "group" barmode, traces that set "offset" will be excluded and drawn in "overlay" mode instead.</param>
    /// <param name="MultiOffset">Shifts the position where the bar is drawn (in position axis units). In "group" barmode, traces that set "offset" will be excluded and drawn in "overlay" mode instead.</param>
    /// <param name="Text">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
    /// <param name="MultiText">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
    /// <param name="TextPosition">Specifies the location of the `text`. "inside" positions `text` inside, next to the bar end (rotated and scaled if needed). "outside" positions `text` outside, next to the bar end (scaled if needed), unless there is another bar stacked on this one, then the text gets pushed inside. "auto" tries to position `text` inside the bar, but if the bar is too small and no bar is stacked on this one the text is moved outside. If "none", no text appears.</param>
    /// <param name="MultiTextPosition">Specifies the location of the `text`. "inside" positions `text` inside, next to the bar end (rotated and scaled if needed). "outside" positions `text` outside, next to the bar end (scaled if needed), unless there is another bar stacked on this one, then the text gets pushed inside. "auto" tries to position `text` inside the bar, but if the bar is too small and no bar is stacked on this one the text is moved outside. If "none", no text appears.</param>
    /// <param name="TextTemplate">Template string used for rendering the information text that appear on points. Note that this will override `textinfo`. Variables are inserted using %{variable}, for example "y: %{y}". Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. Every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available.</param>
    /// <param name="MultiTextTemplate">Template string used for rendering the information text that appear on points. Note that this will override `textinfo`. Variables are inserted using %{variable}, for example "y: %{y}". Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. Every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available.</param>
    /// <param name="HoverText">Sets hover text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. To be seen, trace `hoverinfo` must contain a "text" flag.</param>
    /// <param name="MultiHoverText">Sets hover text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. To be seen, trace `hoverinfo` must contain a "text" flag.</param>
    /// <param name="HoverInfo">Determines which trace information appear on hover. If `none` or `skip` are set, no information is displayed upon hovering. But, if `none` is set, click and hover events are still fired.</param>
    /// <param name="HoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
    /// <param name="MultiHoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
    /// <param name="XHoverFormat">Sets the hover text formatting rulefor `x` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `xaxis.hoverformat`.</param>
    /// <param name="YHoverFormat">Sets the hover text formatting rulefor `y` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `xaxis.hoverformat`.</param>
    /// <param name="Meta">Assigns extra meta information associated with this trace that can be used in various text attributes. Attributes such as trace `name`, graph, axis and colorbar `title.text`, annotation `text` `rangeselector`, `updatemenues` and `sliders` `label` text all support `meta`. To access the trace `meta` values in an attribute in the same trace, simply use `%{meta[i]}` where `i` is the index or key of the `meta` item in question. To access trace `meta` in layout attributes, use `%{data[n[.meta[i]}` where `i` is the index or key of the `meta` and `n` is the trace index.</param>
    /// <param name="CustomData">Assigns extra data each datum. This may be useful when listening to hover, click and selection events. Note that, "scatter" traces also appends customdata items in the markers DOM elements</param>
    /// <param name="XAxis">Sets a reference between this trace's x coordinates and a 2D cartesian x axis. If "x" (the default value), the x coordinates refer to `layout.xaxis`. If "x2", the x coordinates refer to `layout.xaxis2`, and so on.</param>
    /// <param name="YAxis">Sets a reference between this trace's y coordinates and a 2D cartesian y axis. If "y" (the default value), the y coordinates refer to `layout.yaxis`. If "y2", the y coordinates refer to `layout.yaxis2`, and so on.</param>
    /// <param name="Orientation">Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used - including if `visible` is "legendonly" but not if it is `false`. Sets the stacking direction. With "v" ("h"), the y (x) values of subsequent traces are added. Also affects the default value of `fill`.</param>
    /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
    /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
    /// <param name="XPeriod">Only relevant when the axis `type` is "date". Sets the period positioning in milliseconds or "M&lt;n&gt;" on the x axis. Special values in the form of "M&lt;n&gt;" could be used to declare the number of months. In this case `n` must be a positive integer.</param>
    /// <param name="XPeriodAlignment">Only relevant when the axis `type` is "date". Sets the alignment of data points on the x axis.</param>
    /// <param name="XPeriod0">Only relevant when the axis `type` is "date". Sets the base for period positioning in milliseconds or date string on the x0 axis. When `x0period` is round number of weeks, the `x0period0` by default would be on a Sunday i.e. 2000-01-02, otherwise it would be at 2000-01-01.</param>
    /// <param name="YPeriod">Only relevant when the axis `type` is "date". Sets the period positioning in milliseconds or "M&lt;n&gt;" on the y axis. Special values in the form of "M&lt;n&gt;" could be used to declare the number of months. In this case `n` must be a positive integer.</param>
    /// <param name="YPeriodAlignment">Only relevant when the axis `type` is "date". Sets the alignment of data points on the y axis.</param>
    /// <param name="YPeriod0">Only relevant when the axis `type` is "date". Sets the base for period positioning in milliseconds or date string on the y0 axis. When `y0period` is round number of weeks, the `y0period0` by default would be on a Sunday i.e. 2000-01-02, otherwise it would be at 2000-01-01.</param>
    /// <param name="TextAngle">Sets the angle of the tick labels with respect to the bar. For example, a `tickangle` of -90 draws the tick labels vertically. With "auto" the texts may automatically be rotated to fit with the maximum size in bars.</param>
    /// <param name="TextFont">Sets the font used for `text`.</param>
    /// <param name="TextInfo">Determines which trace information appear on the graph. In the case of having multiple funnels, percentages and totals are computed separately (per trace).</param>
    /// <param name="SelectedPoints">Array containing integer indices of selected points. Has an effect only for traces that support selections. Note that an empty array means an empty selection where the `unselected` are turned on for all points, whereas, any other non-array values means no selection all where the `selected` and `unselected` styles have no effect.</param>
    /// <param name="ClipOnAxis">Determines whether the text nodes are clipped about the subplot axes. To show the text nodes above axis lines and tick labels, make sure to set `xaxis.layer` and `yaxis.layer` to "below traces".</param>
    /// <param name="Connector">Sets the waterfall connector of this trace</param>
    /// <param name="Constraintext">Constrain the size of text inside or outside a bar to be no larger than the bar itself.</param>
    /// <param name="Increasing">Sets the style parameters for markers for increasing bars</param>
    /// <param name="Decreasing">Sets the style parameters for markers for decreasing bars</param>
    /// <param name="HoverLabel">Sets the style of the hoverlabels of this trace.</param>
    /// <param name="InsideTextAnchor">Determines if texts are kept at center or start/end points in `textposition` "inside" mode.</param>
    /// <param name="InsideTextFont">Sets the font used for `text` lying inside the bar.</param>
    /// <param name="OutsideTextFont">Sets the font used for `text` lying outside the bar.</param>
    /// <param name="Totals">Sets the style parameters for markers for totals bars</param>
    /// <param name="UIRevision">Controls persistence of some user-driven changes to the trace: `constraintrange` in `parcoords` traces, as well as some `editable: true` modifications such as `name` and `colorbar.title`. Defaults to `layout.uirevision`. Note that other user-driven trace attribute changes are controlled by `layout` attributes: `trace.visible` is controlled by `layout.legend.uirevision`, `selectedpoints` is controlled by `layout.selectionrevision`, and `colorbar.(x|y)` (accessible with `config: {editable: true}`) is controlled by `layout.editrevision`. Trace changes are tracked by `uid`, which only falls back on trace index if no `uid` is provided. So if your app can add/remove traces before the end of the `data` array, such that the same trace has a different index, you can still preserve user-driven changes if you give each trace a `uid` that stays with it as it moves.</param>
    static member Waterfall
        (
            [<Optional; DefaultParameterValue(null)>] ?Name: string,
            [<Optional; DefaultParameterValue(null)>] ?Visible: StyleParam.Visible,
            [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
            [<Optional; DefaultParameterValue(null)>] ?Legend: StyleParam.SubPlotId,
            [<Optional; DefaultParameterValue(null)>] ?LegendRank: int,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroup: string,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroupTitle: Title,
            [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
            [<Optional; DefaultParameterValue(null)>] ?Ids: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?X: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?MultiX: seq<seq<#IConvertible>>,
            [<Optional; DefaultParameterValue(null)>] ?X0: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?DX: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?Y: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?MultiY: seq<seq<#IConvertible>>,
            [<Optional; DefaultParameterValue(null)>] ?Y0: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?DY: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?Base: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?Width: float,
            [<Optional; DefaultParameterValue(null)>] ?MultiWidth: seq<float>,
            [<Optional; DefaultParameterValue(null)>] ?Measure: StyleParam.WaterfallMeasure seq,
            [<Optional; DefaultParameterValue(null)>] ?Offset: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?MultiOffset: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?TextPosition: StyleParam.TextPosition,
            [<Optional; DefaultParameterValue(null)>] ?MultiTextPosition: seq<StyleParam.TextPosition>,
            [<Optional; DefaultParameterValue(null)>] ?TextTemplate: string,
            [<Optional; DefaultParameterValue(null)>] ?MultiTextTemplate: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?HoverText: string,
            [<Optional; DefaultParameterValue(null)>] ?MultiHoverText: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?HoverInfo: StyleParam.HoverInfo,
            [<Optional; DefaultParameterValue(null)>] ?HoverTemplate: string,
            [<Optional; DefaultParameterValue(null)>] ?MultiHoverTemplate: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?XHoverFormat: string,
            [<Optional; DefaultParameterValue(null)>] ?YHoverFormat: string,
            [<Optional; DefaultParameterValue(null)>] ?Meta: string,
            [<Optional; DefaultParameterValue(null)>] ?CustomData: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?XAxis: StyleParam.LinearAxisId,
            [<Optional; DefaultParameterValue(null)>] ?YAxis: StyleParam.LinearAxisId,
            [<Optional; DefaultParameterValue(null)>] ?Orientation: StyleParam.Orientation,
            [<Optional; DefaultParameterValue(null)>] ?AlignmentGroup: string,
            [<Optional; DefaultParameterValue(null)>] ?OffsetGroup: string,
            [<Optional; DefaultParameterValue(null)>] ?XPeriod: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?XPeriodAlignment: StyleParam.PeriodAlignment,
            [<Optional; DefaultParameterValue(null)>] ?XPeriod0: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?YPeriod: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?YPeriodAlignment: StyleParam.PeriodAlignment,
            [<Optional; DefaultParameterValue(null)>] ?YPeriod0: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?TextAngle: float,
            [<Optional; DefaultParameterValue(null)>] ?TextFont: Font,
            [<Optional; DefaultParameterValue(null)>] ?TextInfo: StyleParam.TextInfo,
            [<Optional; DefaultParameterValue(null)>] ?SelectedPoints: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?ClipOnAxis: bool,
            [<Optional; DefaultParameterValue(null)>] ?Connector: WaterfallConnector,
            [<Optional; DefaultParameterValue(null)>] ?Constraintext: StyleParam.ConstrainText,
            [<Optional; DefaultParameterValue(null)>] ?Increasing: FinanceMarker,
            [<Optional; DefaultParameterValue(null)>] ?Decreasing: FinanceMarker,
            [<Optional; DefaultParameterValue(null)>] ?HoverLabel: Hoverlabel,
            [<Optional; DefaultParameterValue(null)>] ?InsideTextAnchor: StyleParam.InsideTextAnchor,
            [<Optional; DefaultParameterValue(null)>] ?InsideTextFont: Font,
            [<Optional; DefaultParameterValue(null)>] ?OutsideTextFont: Font,
            [<Optional; DefaultParameterValue(null)>] ?Totals: FinanceMarker,
            [<Optional; DefaultParameterValue(null)>] ?UIRevision: string
        ) =
        (fun (trace: ('T :> Trace)) ->

            Name |> DynObj.setOptionalProperty trace "name"
            Visible |> DynObj.setOptionalPropertyBy trace "visible" StyleParam.Visible.convert
            ShowLegend |> DynObj.setOptionalProperty trace "showlegend"
            Legend |> DynObj.setOptionalPropertyBy trace "legend" StyleParam.SubPlotId.convert
            LegendRank |> DynObj.setOptionalProperty trace "legendrank"
            LegendGroup |> DynObj.setOptionalProperty trace "legendgroup"
            LegendGroupTitle |> DynObj.setOptionalProperty trace "legendgrouptitle"
            Opacity |> DynObj.setOptionalProperty trace "opacity"
            Ids |> DynObj.setOptionalProperty trace "ids"
            (X, MultiX) |> DynObj.setOptionalSingleOrMultiProperty trace "x"
            X0 |> DynObj.setOptionalProperty trace "x0"
            DX |> DynObj.setOptionalProperty trace "dx"
            (Y, MultiY) |> DynObj.setOptionalSingleOrMultiProperty trace "y"
            Y0 |> DynObj.setOptionalProperty trace "y0"
            DY |> DynObj.setOptionalProperty trace "dy"
            Base |> DynObj.setOptionalProperty trace "base"
            (Width, MultiWidth) |> DynObj.setOptionalSingleOrMultiProperty trace "width"
            Measure |> DynObj.setOptionalPropertyBy trace "measure" (Seq.map StyleParam.WaterfallMeasure.convert)
            (Offset, MultiOffset) |> DynObj.setOptionalSingleOrMultiProperty trace "offset"
            (Text, MultiText) |> DynObj.setOptionalSingleOrMultiProperty trace "text"

            (TextPosition, MultiTextPosition)
            |> DynObj.setSingleOrMultiOptBy trace "textposition" StyleParam.TextPosition.convert

            (TextTemplate, MultiTextTemplate) |> DynObj.setOptionalSingleOrMultiProperty trace "texttemplate"
            (HoverText, MultiHoverText) |> DynObj.setOptionalSingleOrMultiProperty trace "hovertext"
            HoverInfo |> DynObj.setOptionalPropertyBy trace "hoverinfo" StyleParam.HoverInfo.convert
            (HoverTemplate, MultiHoverTemplate) |> DynObj.setOptionalSingleOrMultiProperty trace "hovertemTotalsplate"
            XHoverFormat |> DynObj.setOptionalProperty trace "xhoverformat"
            YHoverFormat |> DynObj.setOptionalProperty trace "yhoverformat"
            Meta |> DynObj.setOptionalProperty trace "meta"
            CustomData |> DynObj.setOptionalProperty trace "customdata"
            XAxis |> DynObj.setOptionalPropertyBy trace "xaxis" StyleParam.LinearAxisId.convert
            YAxis |> DynObj.setOptionalPropertyBy trace "yaxis" StyleParam.LinearAxisId.convert
            Orientation |> DynObj.setOptionalPropertyBy trace "orientation" StyleParam.Orientation.convert
            AlignmentGroup |> DynObj.setOptionalProperty trace "alignmentgroup"
            OffsetGroup |> DynObj.setOptionalProperty trace "offsetgroup"
            XPeriod |> DynObj.setOptionalProperty trace "xperiod"
            XPeriodAlignment |> DynObj.setOptionalPropertyBy trace "xperiodalignment" StyleParam.PeriodAlignment.convert
            XPeriod0 |> DynObj.setOptionalProperty trace "xperiod0"
            YPeriod |> DynObj.setOptionalProperty trace "yperiod"
            YPeriodAlignment |> DynObj.setOptionalPropertyBy trace "yperiodalignment" StyleParam.PeriodAlignment.convert
            YPeriod0 |> DynObj.setOptionalProperty trace "yperiod0"
            TextAngle |> DynObj.setOptionalProperty trace "textangle"
            TextFont |> DynObj.setOptionalProperty trace "textfont"
            TextInfo |> DynObj.setOptionalProperty trace "textinfo"
            SelectedPoints |> DynObj.setOptionalProperty trace "selectedpoints"
            ClipOnAxis |> DynObj.setOptionalProperty trace "cliponaxis"
            Connector |> DynObj.setOptionalProperty trace "connector"
            Constraintext |> DynObj.setOptionalPropertyBy trace "constraintext" StyleParam.ConstrainText.convert
            Increasing |> DynObj.setOptionalProperty trace "increasing"
            Decreasing |> DynObj.setOptionalProperty trace "decreasing"
            HoverLabel |> DynObj.setOptionalProperty trace "hoverlabel"
            InsideTextAnchor |> DynObj.setOptionalPropertyBy trace "insidetextanchor" StyleParam.InsideTextAnchor.convert
            InsideTextFont |> DynObj.setOptionalProperty trace "insidetextfont"
            OutsideTextFont |> DynObj.setOptionalProperty trace "outsidetextfont"
            Totals |> DynObj.setOptionalProperty trace "totals"
            UIRevision |> DynObj.setOptionalProperty trace "uirevision"

            trace)


    /// <summary>
    /// Create a function that applies the styles of a histogram plot to a Trace object
    /// </summary>
    /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
    /// <param name="Visible">Determines whether or not this trace is visible. If "legendonly", the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).</param>
    /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
    /// <param name="Legend">Sets the reference to a legend to show this trace in. References to these legends are "legend", "legend2", "legend3", etc. Settings for these legends are set in the layout, under `layout.legend`, `layout.legend2`, etc.</param>
    /// <param name="LegendRank">Sets the legend rank for this trace. Items and groups with smaller ranks are presented on top/left side while with `"reversed" `legend.traceorder` they are on bottom/right side. The default legendrank is 1000, so that you can use ranks less than 1000 to place certain items before all unranked items, and ranks greater than 1000 to go after all unranked items.</param>
    /// <param name="LegendGroup">Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling legend items.</param>
    /// <param name="LegendGroupTitle">Sets the legend group title for this trace.</param>
    /// <param name="Opacity">Sets the opacity of the trace.</param>
    /// <param name="Ids">Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.</param>
    /// <param name="X">Sets the sample data to be binned on the x axis.</param>
    /// <param name="MultiX">Sets the sample data to be binned on the x axis.</param>
    /// <param name="Y">Sets the sample data to be binned on the y axis.</param>
    /// <param name="MultiY">Sets the sample data to be binned on the y axis.</param>
    /// <param name="Text">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
    /// <param name="MultiText">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
    /// <param name="TextPosition">Sets the positions of the `text` elements with respects to the (x,y) coordinates.</param>
    /// <param name="TextTemplate">Template string used for rendering the information text that appear on points. Note that this will override `textinfo`. Variables are inserted using %{variable}, for example "y: %{y}". Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. Every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available.</param>
    /// <param name="MultiTextTemplate">Template string used for rendering the information text that appear on points. Note that this will override `textinfo`. Variables are inserted using %{variable}, for example "y: %{y}". Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. Every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available.</param>
    /// <param name="HoverText">Sets hover text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. To be seen, trace `hoverinfo` must contain a "text" flag.</param>
    /// <param name="MultiHoverText">Sets hover text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. To be seen, trace `hoverinfo` must contain a "text" flag.</param>
    /// <param name="HoverInfo">Determines which trace information appear on hover. If `none` or `skip` are set, no information is displayed upon hovering. But, if `none` is set, click and hover events are still fired.</param>
    /// <param name="HoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
    /// <param name="MultiHoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
    /// <param name="XHoverFormat">Sets the hover text formatting rulefor `x` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `xaxis.hoverformat`.</param>
    /// <param name="YHoverFormat">Sets the hover text formatting rulefor `y` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `xaxis.hoverformat`.</param>
    /// <param name="Meta">Assigns extra meta information associated with this trace that can be used in various text attributes. Attributes such as trace `name`, graph, axis and colorbar `title.text`, annotation `text` `rangeselector`, `updatemenues` and `sliders` `label` text all support `meta`. To access the trace `meta` values in an attribute in the same trace, simply use `%{meta[i]}` where `i` is the index or key of the `meta` item in question. To access trace `meta` in layout attributes, use `%{data[n[.meta[i]}` where `i` is the index or key of the `meta` and `n` is the trace index.</param>
    /// <param name="CustomData">Assigns extra data each datum. This may be useful when listening to hover, click and selection events. Note that, "scatter" traces also appends customdata items in the markers DOM elements</param>
    /// <param name="XAxis">Sets a reference between this trace's x coordinates and a 2D cartesian x axis. If "x" (the default value), the x coordinates refer to `layout.xaxis`. If "x2", the x coordinates refer to `layout.xaxis2`, and so on.</param>
    /// <param name="YAxis">Sets a reference between this trace's y coordinates and a 2D cartesian y axis. If "y" (the default value), the y coordinates refer to `layout.yaxis`. If "y2", the y coordinates refer to `layout.yaxis2`, and so on.</param>
    /// <param name="Orientation">Sets the orientation of the bars. With "v" ("h"), the value of the each bar spans along the vertical (horizontal).</param>
    /// <param name="HistFunc">Specifies the binning function used for this histogram trace. If "count", the histogram values are computed by counting the number of values lying inside each bin. If "sum", "avg", "min", "max", the histogram values are computed using the sum, the average, the minimum or the maximum of the values lying inside each bin respectively.</param>
    /// <param name="HistNorm">Specifies the type of normalization used for this histogram trace. If "", the span of each bar corresponds to the number of occurrences (i.e. the number of data points lying inside the bins). If "percent" / "probability", the span of each bar corresponds to the percentage / fraction of occurrences with respect to the total number of sample points (here, the sum of all bin HEIGHTS equals 100% / 1). If "density", the span of each bar corresponds to the number of occurrences in a bin divided by the size of the bin interval (here, the sum of all bin AREAS equals the total number of sample points). If "probability density", the area of each bar corresponds to the probability that an event will fall into the corresponding bin (here, the sum of all bin AREAS equals 1).</param>
    /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
    /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
    /// <param name="NBinsX">Specifies the maximum number of desired bins. This value will be used in an algorithm that will decide the optimal bin size such that the histogram best visualizes the distribution of the data. Ignored if `xbins.size` is provided.</param>
    /// <param name="NBinsY">Specifies the maximum number of desired bins. This value will be used in an algorithm that will decide the optimal bin size such that the histogram best visualizes the distribution of the data. Ignored if `ybins.size` is provided.</param>
    /// <param name="AutoBinX">Obsolete: since v1.42 each bin attribute is auto-determined separately and `autobinx` is not needed. However, we accept `autobinx: true` or `false` and will update `xbins` accordingly before deleting `autobinx` from the trace.</param>
    /// <param name="AutoBinY">Obsolete: since v1.42 each bin attribute is auto-determined separately and `autobiny` is not needed. However, we accept `autobiny: true` or `false` and will update `ybins` accordingly before deleting `autobiny` from the trace.</param>
    /// <param name="BinGroup">Set a group of histogram traces which will have compatible bin settings. Note that traces on the same subplot and with the same "orientation" under `barmode` "stack", "relative" and "group" are forced into the same bingroup, Using `bingroup`, traces under `barmode` "overlay" and on different axes (of the same axis type) can have compatible bin settings. Note that histogram and histogram2d" trace can share the same `bingroup`</param>
    /// <param name="XBins">Sets the binning across the x dimension</param>
    /// <param name="YBins">Sets the binning across the y dimension</param>
    /// <param name="Marker">Sets the marker of this trace.</param>
    /// <param name="TextAngle">Sets the angle of the tick labels with respect to the bar. For example, a `tickangle` of -90 draws the tick labels vertically. With "auto" the texts may automatically be rotated to fit with the maximum size in bars.</param>
    /// <param name="TextFont">Sets the font used for `text`.</param>
    /// <param name="Line">Sets the line of this trace.</param>
    /// <param name="XError">Sets the x error of this trace.</param>
    /// <param name="YError">Sets the y error of this trace.</param>
    /// <param name="SelectedPoints">Array containing integer indices of selected points. Has an effect only for traces that support selections. Note that an empty array means an empty selection where the `unselected` are turned on for all points, whereas, any other non-array values means no selection all where the `selected` and `unselected` styles have no effect.</param>
    /// <param name="Selected">Sets the style of selected points of this trace.</param>
    /// <param name="Unselected">Sets the style of unselected points of this trace.</param>
    /// <param name="ClipOnAxis">Determines whether the text nodes are clipped about the subplot axes. To show the text nodes above axis lines and tick labels, make sure to set `xaxis.layer` and `yaxis.layer` to "below traces".</param>
    /// <param name="Constraintext">Constrain the size of text inside or outside a bar to be no larger than the bar itself.</param>
    /// <param name="Cumulative">Sets whether and how the cumulative distribution is displayed</param>
    /// <param name="HoverLabel">Sets the style of the hoverlabels of this trace.</param>
    /// <param name="InsideTextAnchor">Determines if texts are kept at center or start/end points in `textposition` "inside" mode.</param>
    /// <param name="InsideTextFont">Sets the font used for `text` lying inside the bar.</param>
    /// <param name="OutsideTextFont">Sets the font used for `text` lying outside the bar.</param>
    /// <param name="XCalendar">Sets the calendar system to use with `x` date data.</param>
    /// <param name="YCalendar">Sets the calendar system to use with `y` date data.</param>
    /// <param name="UIRevision">Controls persistence of some user-driven changes to the trace: `constraintrange` in `parcoords` traces, as well as some `editable: true` modifications such as `name` and `colorbar.title`. Defaults to `layout.uirevision`. Note that other user-driven trace attribute changes are controlled by `layout` attributes: `trace.visible` is controlled by `layout.legend.uirevision`, `selectedpoints` is controlled by `layout.selectionrevision`, and `colorbar.(x|y)` (accessible with `config: {editable: true}`) is controlled by `layout.editrevision`. Trace changes are tracked by `uid`, which only falls back on trace index if no `uid` is provided. So if your app can add/remove traces before the end of the `data` array, such that the same trace has a different index, you can still preserve user-driven changes if you give each trace a `uid` that stays with it as it moves.</param>
    static member Histogram
        (
            [<Optional; DefaultParameterValue(null)>] ?Name: string,
            [<Optional; DefaultParameterValue(null)>] ?Visible: StyleParam.Visible,
            [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
            [<Optional; DefaultParameterValue(null)>] ?Legend: StyleParam.SubPlotId,
            [<Optional; DefaultParameterValue(null)>] ?LegendRank: int,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroup: string,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroupTitle: Title,
            [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
            [<Optional; DefaultParameterValue(null)>] ?Ids: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?X: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?MultiX: seq<seq<#IConvertible>>,
            [<Optional; DefaultParameterValue(null)>] ?Y: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?MultiY: seq<seq<#IConvertible>>,
            [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?TextPosition: StyleParam.TextPosition,
            [<Optional; DefaultParameterValue(null)>] ?TextTemplate: string,
            [<Optional; DefaultParameterValue(null)>] ?MultiTextTemplate: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?HoverText: string,
            [<Optional; DefaultParameterValue(null)>] ?MultiHoverText: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?HoverInfo: StyleParam.HoverInfo,
            [<Optional; DefaultParameterValue(null)>] ?HoverTemplate: string,
            [<Optional; DefaultParameterValue(null)>] ?MultiHoverTemplate: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?XHoverFormat: string,
            [<Optional; DefaultParameterValue(null)>] ?YHoverFormat: string,
            [<Optional; DefaultParameterValue(null)>] ?Meta: string,
            [<Optional; DefaultParameterValue(null)>] ?CustomData: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?XAxis: StyleParam.LinearAxisId,
            [<Optional; DefaultParameterValue(null)>] ?YAxis: StyleParam.LinearAxisId,
            [<Optional; DefaultParameterValue(null)>] ?Orientation: StyleParam.Orientation,
            [<Optional; DefaultParameterValue(null)>] ?HistFunc: StyleParam.HistFunc,
            [<Optional; DefaultParameterValue(null)>] ?HistNorm: StyleParam.HistNorm,
            [<Optional; DefaultParameterValue(null)>] ?AlignmentGroup: string,
            [<Optional; DefaultParameterValue(null)>] ?OffsetGroup: string,
            [<Optional; DefaultParameterValue(null)>] ?NBinsX: int,
            [<Optional; DefaultParameterValue(null)>] ?NBinsY: int,
            [<Optional; DefaultParameterValue(null)>] ?AutoBinX: bool,
            [<Optional; DefaultParameterValue(null)>] ?AutoBinY: bool,
            [<Optional; DefaultParameterValue(null)>] ?BinGroup: string,
            [<Optional; DefaultParameterValue(null)>] ?XBins: Bins,
            [<Optional; DefaultParameterValue(null)>] ?YBins: Bins,
            [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
            [<Optional; DefaultParameterValue(null)>] ?TextAngle: float,
            [<Optional; DefaultParameterValue(null)>] ?TextFont: Font,
            [<Optional; DefaultParameterValue(null)>] ?Line: Line,
            [<Optional; DefaultParameterValue(null)>] ?XError: Error,
            [<Optional; DefaultParameterValue(null)>] ?YError: Error,
            [<Optional; DefaultParameterValue(null)>] ?SelectedPoints: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Selected: TraceSelection,
            [<Optional; DefaultParameterValue(null)>] ?Unselected: TraceSelection,
            [<Optional; DefaultParameterValue(null)>] ?ClipOnAxis: bool,
            [<Optional; DefaultParameterValue(null)>] ?Constraintext: StyleParam.ConstrainText,
            [<Optional; DefaultParameterValue(null)>] ?Cumulative: Cumulative,
            [<Optional; DefaultParameterValue(null)>] ?HoverLabel: Hoverlabel,
            [<Optional; DefaultParameterValue(null)>] ?InsideTextAnchor: StyleParam.InsideTextAnchor,
            [<Optional; DefaultParameterValue(null)>] ?InsideTextFont: Font,
            [<Optional; DefaultParameterValue(null)>] ?OutsideTextFont: Font,
            [<Optional; DefaultParameterValue(null)>] ?XCalendar: StyleParam.Calendar,
            [<Optional; DefaultParameterValue(null)>] ?YCalendar: StyleParam.Calendar,
            [<Optional; DefaultParameterValue(null)>] ?UIRevision: string
        ) =
        (fun (histogram: ('T :> Trace)) ->

            Name |> DynObj.setOptionalProperty histogram "name"
            Visible |> DynObj.setOptionalPropertyBy histogram "visible" StyleParam.Visible.convert
            ShowLegend |> DynObj.setOptionalProperty histogram "showlegend"
            Legend |> DynObj.setOptionalPropertyBy histogram "legend" StyleParam.SubPlotId.convert
            LegendRank |> DynObj.setOptionalProperty histogram "legendrank"
            LegendGroup |> DynObj.setOptionalProperty histogram "legendgroup"
            LegendGroupTitle |> DynObj.setOptionalProperty histogram "legendgrouptitle"
            Opacity |> DynObj.setOptionalProperty histogram "opacity"
            Ids |> DynObj.setOptionalProperty histogram "ids"
            (X, MultiX) |> DynObj.setOptionalSingleOrMultiProperty histogram "x"
            (Y, MultiY) |> DynObj.setOptionalSingleOrMultiProperty histogram "y"
            (Text, MultiText) |> DynObj.setOptionalSingleOrMultiProperty histogram "text"
            TextPosition |> DynObj.setOptionalPropertyBy histogram "textposition" StyleParam.TextPosition.convert
            (TextTemplate, MultiTextTemplate) |> DynObj.setOptionalSingleOrMultiProperty histogram "texttemplate"
            (HoverText, MultiHoverText) |> DynObj.setOptionalSingleOrMultiProperty histogram "hovertext"
            HoverInfo |> DynObj.setOptionalPropertyBy histogram "hoverinfo" StyleParam.HoverInfo.convert
            (HoverTemplate, MultiHoverTemplate) |> DynObj.setOptionalSingleOrMultiProperty histogram "hovertemplate"
            XHoverFormat |> DynObj.setOptionalProperty histogram "xhoverformat"
            YHoverFormat |> DynObj.setOptionalProperty histogram "yhoverformat"
            Meta |> DynObj.setOptionalProperty histogram "meta"
            CustomData |> DynObj.setOptionalProperty histogram "customdata"
            XAxis |> DynObj.setOptionalPropertyBy histogram "xaxis" StyleParam.LinearAxisId.convert
            YAxis |> DynObj.setOptionalPropertyBy histogram "yaxis" StyleParam.LinearAxisId.convert
            Orientation |> DynObj.setOptionalPropertyBy histogram "orientation" StyleParam.Orientation.convert
            HistFunc |> DynObj.setOptionalPropertyBy histogram "histfunc" StyleParam.HistFunc.convert
            HistNorm |> DynObj.setOptionalPropertyBy histogram "histnorm" StyleParam.HistNorm.convert
            AlignmentGroup |> DynObj.setOptionalProperty histogram "alignmentgroup"
            OffsetGroup |> DynObj.setOptionalProperty histogram "offsetgroup"
            NBinsX |> DynObj.setOptionalProperty histogram "nbinsx"
            NBinsY |> DynObj.setOptionalProperty histogram "nbinsy"
            AutoBinX |> DynObj.setOptionalProperty histogram "autobinx"
            AutoBinY |> DynObj.setOptionalProperty histogram "autobiny"
            BinGroup |> DynObj.setOptionalProperty histogram "bingroup"
            XBins |> DynObj.setOptionalProperty histogram "xbins"
            YBins |> DynObj.setOptionalProperty histogram "ybins"
            Marker |> DynObj.setOptionalProperty histogram "marker"
            TextAngle |> DynObj.setOptionalProperty histogram "textangle"
            TextFont |> DynObj.setOptionalProperty histogram "textfont"
            Line |> DynObj.setOptionalProperty histogram "line"
            XError |> DynObj.setOptionalProperty histogram "error_x"
            YError |> DynObj.setOptionalProperty histogram "error_y"
            SelectedPoints |> DynObj.setOptionalProperty histogram "selectedpoints"
            Selected |> DynObj.setOptionalProperty histogram "selected"
            Unselected |> DynObj.setOptionalProperty histogram "unselected"
            ClipOnAxis |> DynObj.setOptionalProperty histogram "cliponaxis"
            Constraintext |> DynObj.setOptionalPropertyBy histogram "constraintext" StyleParam.ConstrainText.convert
            Cumulative |> DynObj.setOptionalProperty histogram "cumulative"
            HoverLabel |> DynObj.setOptionalProperty histogram "hoverlabel"
            InsideTextAnchor |> DynObj.setOptionalPropertyBy histogram "insidetextanchor" StyleParam.InsideTextAnchor.convert
            InsideTextFont |> DynObj.setOptionalProperty histogram "insidetextfont"
            OutsideTextFont |> DynObj.setOptionalProperty histogram "outsidetextfont"
            XCalendar |> DynObj.setOptionalPropertyBy histogram "xcalendar" StyleParam.Calendar.convert
            YCalendar |> DynObj.setOptionalPropertyBy histogram "ycalendar" StyleParam.Calendar.convert
            UIRevision |> DynObj.setOptionalProperty histogram "uirevision"

            histogram)

    /// <summary>
    /// Create a function that applies the styles of a boxplot to a Trace object
    /// </summary>
    /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
    /// <param name="Visible">Determines whether or not this trace is visible. If "legendonly", the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).</param>
    /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
    /// <param name="Legend">Sets the reference to a legend to show this trace in. References to these legends are "legend", "legend2", "legend3", etc. Settings for these legends are set in the layout, under `layout.legend`, `layout.legend2`, etc.</param>
    /// <param name="LegendRank">Sets the legend rank for this trace. Items and groups with smaller ranks are presented on top/left side while with `"reversed" `legend.traceorder` they are on bottom/right side. The default legendrank is 1000, so that you can use ranks less than 1000 to place certain items before all unranked items, and ranks greater than 1000 to go after all unranked items.</param>
    /// <param name="LegendGroup">Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling legend items.</param>
    /// <param name="LegendGroupTitle">Sets the legend group title for this trace.</param>
    /// <param name="LegendWidth">Sets the width (in px or fraction) of the legend for this trace.</param>
    /// <param name="Opacity">Sets the opacity of the trace.</param>
    /// <param name="Ids">Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.</param>
    /// <param name="X">Sets the x sample data or coordinates. See overview for more info.</param>
    /// <param name="MultiX">Sets the x sample data or coordinates. See overview for more info.</param>
    /// <param name="X0">Sets the x coordinate for single-box traces or the starting coordinate for multi-box traces set using q1/median/q3. See overview for more info.</param>
    /// <param name="DX">Sets the x coordinate step for multi-box traces set using q1/median/q3.</param>
    /// <param name="Y">Sets the y sample data or coordinates. See overview for more info.</param>
    /// <param name="MultiY">Sets the y sample data or coordinates. See overview for more info.</param>
    /// <param name="Y0">Sets the y coordinate for single-box traces or the starting coordinate for multi-box traces set using q1/median/q3. See overview for more info.</param>
    /// <param name="DY">Sets the y coordinate step for multi-box traces set using q1/median/q3.</param>
    /// <param name="Width">Sets the width of the box in data coordinate If "0" (default value) the width is automatically selected based on the positions of other box traces in the same subplot.</param>
    /// <param name="Text">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
    /// <param name="MultiText">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
    /// <param name="HoverText">Sets hover text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. To be seen, trace `hoverinfo` must contain a "text" flag.</param>
    /// <param name="MultiHoverText">Sets hover text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. To be seen, trace `hoverinfo` must contain a "text" flag.</param>
    /// <param name="HoverInfo">Determines which trace information appear on hover. If `none` or `skip` are set, no information is displayed upon hovering. But, if `none` is set, click and hover events are still fired.</param>
    /// <param name="HoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
    /// <param name="MultiHoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
    /// <param name="XHoverFormat">Sets the hover text formatting rulefor `x` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `xaxis.hoverformat`.</param>
    /// <param name="YHoverFormat">Sets the hover text formatting rulefor `y` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `xaxis.hoverformat`.</param>
    /// <param name="Meta">Assigns extra meta information associated with this trace that can be used in various text attributes. Attributes such as trace `name`, graph, axis and colorbar `title.text`, annotation `text` `rangeselector`, `updatemenues` and `sliders` `label` text all support `meta`. To access the trace `meta` values in an attribute in the same trace, simply use `%{meta[i]}` where `i` is the index or key of the `meta` item in question. To access trace `meta` in layout attributes, use `%{data[n[.meta[i]}` where `i` is the index or key of the `meta` and `n` is the trace index.</param>
    /// <param name="CustomData">Assigns extra data each datum. This may be useful when listening to hover, click and selection events. Note that, "scatter" traces also appends customdata items in the markers DOM elements</param>
    /// <param name="XAxis">Sets a reference between this trace's x coordinates and a 2D cartesian x axis. If "x" (the default value), the x coordinates refer to `layout.xaxis`. If "x2", the x coordinates refer to `layout.xaxis2`, and so on.</param>
    /// <param name="YAxis">Sets a reference between this trace's y coordinates and a 2D cartesian y axis. If "y" (the default value), the y coordinates refer to `layout.yaxis`. If "y2", the y coordinates refer to `layout.yaxis2`, and so on.</param>
    /// <param name="Orientation">Sets the orientation of the box(es). If "v" ("h"), the distribution is visualized along the vertical (horizontal).</param>
    /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
    /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
    /// <param name="XPeriod">Only relevant when the axis `type` is "date". Sets the period positioning in milliseconds or "M&lt;n&gt;" on the x axis. Special values in the form of "M&lt;n&gt;" could be used to declare the number of months. In this case `n` must be a positive integer.</param>
    /// <param name="XPeriodAlignment">Only relevant when the axis `type` is "date". Sets the alignment of data points on the x axis.</param>
    /// <param name="XPeriod0">Only relevant when the axis `type` is "date". Sets the base for period positioning in milliseconds or date string on the x0 axis. When `x0period` is round number of weeks, the `x0period0` by default would be on a Sunday i.e. 2000-01-02, otherwise it would be at 2000-01-01.</param>
    /// <param name="YPeriod">Only relevant when the axis `type` is "date". Sets the period positioning in milliseconds or "M&lt;n&gt;" on the y axis. Special values in the form of "M&lt;n&gt;" could be used to declare the number of months. In this case `n` must be a positive integer.</param>
    /// <param name="YPeriodAlignment">Only relevant when the axis `type` is "date". Sets the alignment of data points on the y axis.</param>
    /// <param name="YPeriod0">Only relevant when the axis `type` is "date". Sets the base for period positioning in milliseconds or date string on the y0 axis. When `y0period` is round number of weeks, the `y0period0` by default would be on a Sunday i.e. 2000-01-02, otherwise it would be at 2000-01-01.</param>
    /// <param name="Marker">Sets the marker of this trace.</param>
    /// <param name="Line">Sets the line of this trace.</param>
    /// <param name="BoxMean">If "true", the mean of the box(es)' underlying distribution is drawn as a dashed line inside the box(es). If "sd" the standard deviation is also drawn. Defaults to "true" when `mean` is set. Defaults to "sd" when `sd` is set Otherwise defaults to "false".</param>
    /// <param name="BoxPoints">If "outliers", only the sample points lying outside the whiskers are shown If "suspectedoutliers", the outlier points are shown and points either less than 4"Q1-3"Q3 or greater than 4"Q3-3"Q1 are highlighted (see `outliercolor`) If "all", all sample points are shown If "false", only the box(es) are shown with no sample points Defaults to "suspectedoutliers" when `marker.outliercolor` or `marker.line.outliercolor` is set. Defaults to "all" under the q1/median/q3 signature. Otherwise defaults to "outliers".</param>
    /// <param name="Notched">Determines whether or not notches are drawn. Notches displays a confidence interval around the median. We compute the confidence interval as median +/- 1.57 " IQR / sqrt(N), where IQR is the interquartile range and N is the sample size. If two boxes' notches do not overlap there is 95% confidence their medians differ. See https://sites.google.com/site/davidsstatistics/home/notched-box-plots for more info. Defaults to "false" unless `notchwidth` or `notchspan` is set.</param>
    /// <param name="NotchWidth">Sets the width of the notches relative to the box' width. For example, with 0, the notches are as wide as the box(es).</param>
    /// <param name="ShowWhiskers">Determines whether or not whiskers are visible. Defaults to true for `sizemode` "quartiles", false for "sd".</param>
    /// <param name="WhiskerWidth">Sets the width of the whiskers relative to the box' width. For example, with 1, the whiskers are as wide as the box(es).</param>
    /// <param name="Q1">Sets the Quartile 1 values. There should be as many items as the number of boxes desired.</param>
    /// <param name="Median">Sets the Quartile 1 values. There should be as many items as the number of boxes desired.</param>
    /// <param name="Q3">Sets the Quartile 3 values. There should be as many items as the number of boxes desired.</param>
    /// <param name="LowerFence">Sets the lower fence values. There should be as many items as the number of boxes desired. This attribute has effect only under the q1/median/q3 signature. If `lowerfence` is not provided but a sample (in `y` or `x`) is set, we compute the lower as the last sample point below 1.5 times the IQR.</param>
    /// <param name="UpperFence">Sets the upper fence values. There should be as many items as the number of boxes desired. This attribute has effect only under the q1/median/q3 signature. If `upperfence` is not provided but a sample (in `y` or `x`) is set, we compute the lower as the last sample point above 1.5 times the IQR.</param>
    /// <param name="NotchSpan">Sets the notch span from the boxes' `median` values. There should be as many items as the number of boxes desired. This attribute has effect only under the q1/median/q3 signature. If `notchspan` is not provided but a sample (in `y` or `x`) is set, we compute it as 1.57 " IQR / sqrt(N), where N is the sample size.</param>
    /// <param name="Mean">Sets the mean values. There should be as many items as the number of boxes desired. This attribute has effect only under the q1/median/q3 signature. If `mean` is not provided but a sample (in `y` or `x`) is set, we compute the mean for each box using the sample values.</param>
    /// <param name="SD">Sets the standard deviation values. There should be as many items as the number of boxes desired. This attribute has effect only under the q1/median/q3 signature. If `sd` is not provided but a sample (in `y` or `x`) is set, we compute the standard deviation for each box using the sample values.</param>
    /// <param name="SDMultiple">Scales the box size when sizemode=sd Allowing boxes to be drawn across any stddev range For example 1-stddev, 3-stddev, 5-stddev</param>
    /// <param name="QuartileMethod">Sets the method used to compute the sample's Q1 and Q3 quartiles. The "linear" method uses the 25th percentile for Q1 and 75th percentile for Q3 as computed using method #10 (listed on http://www.amstat.org/publications/jse/v14n3/langford.html). The "exclusive" method uses the median to divide the ordered dataset into two halves if the sample is odd, it does not include the median in either half - Q1 is then the median of the lower half and Q3 the median of the upper half. The "inclusive" method also uses the median to divide the ordered dataset into two halves but if the sample is odd, it includes the median in both halves - Q1 is then the median of the lower half and Q3 the median of the upper half.</param>
    /// <param name="SelectedPoints">Array containing integer indices of selected points. Has an effect only for traces that support selections. Note that an empty array means an empty selection where the `unselected` are turned on for all points, whereas, any other non-array values means no selection all where the `selected` and `unselected` styles have no effect.</param>
    /// <param name="Selected">Sets the style of selected points of this trace.</param>
    /// <param name="Unselected">Sets the style of unselected points of this trace.</param>
    /// <param name="FillColor">Sets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
    /// <param name="HoverLabel">Sets the style of the hoverlabels of this trace.</param>
    /// <param name="HoverOn">Do the hover effects highlight individual boxes or sample points or both?</param>
    /// <param name="PointPos">Sets the position of the sample points in relation to the box(es). If "0", the sample points are places over the center of the box(es). Positive (negative) values correspond to positions to the right (left) for vertical boxes and above (below) for horizontal boxes</param>
    /// <param name="Jitter">Sets the amount of jitter in the sample points drawn. If "0", the sample points align along the distribution axis. If "1", the sample points are drawn in a random jitter of width equal to the width of the box(es).</param>
    /// <param name="SizeMode">Sets the upper and lower bound for the boxes quartiles means box is drawn between Q1 and Q3 SD means the box is drawn between Mean +- Standard Deviation Argument sdmultiple (default 1) to scale the box size So it could be drawn 1-stddev, 3-stddev etc</param>
    /// <param name="XCalendar">Sets the calendar system to use with `x` date data.</param>
    /// <param name="YCalendar">Sets the calendar system to use with `y` date data.</param>
    /// <param name="UIRevision">Controls persistence of some user-driven changes to the trace: `constraintrange` in `parcoords` traces, as well as some `editable: true` modifications such as `name` and `colorbar.title`. Defaults to `layout.uirevision`. Note that other user-driven trace attribute changes are controlled by `layout` attributes: `trace.visible` is controlled by `layout.legend.uirevision`, `selectedpoints` is controlled by `layout.selectionrevision`, and `colorbar.(x|y)` (accessible with `config: {editable: true}`) is controlled by `layout.editrevision`. Trace changes are tracked by `uid`, which only falls back on trace index if no `uid` is provided. So if your app can add/remove traces before the end of the `data` array, such that the same trace has a different index, you can still preserve user-driven changes if you give each trace a `uid` that stays with it as it moves.</param>
    static member BoxPlot
        (
            [<Optional; DefaultParameterValue(null)>] ?Name: string,
            [<Optional; DefaultParameterValue(null)>] ?Visible: StyleParam.Visible,
            [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
            [<Optional; DefaultParameterValue(null)>] ?Legend: StyleParam.SubPlotId,
            [<Optional; DefaultParameterValue(null)>] ?LegendRank: int,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroup: string,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroupTitle: Title,
            [<Optional; DefaultParameterValue(null)>] ?LegendWidth: float,
            [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
            [<Optional; DefaultParameterValue(null)>] ?Ids: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?X: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?MultiX: seq<seq<#IConvertible>>,
            [<Optional; DefaultParameterValue(null)>] ?X0: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?DX: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?Y: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?MultiY: seq<seq<#IConvertible>>,
            [<Optional; DefaultParameterValue(null)>] ?Y0: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?DY: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?Width: float,
            [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?HoverText: string,
            [<Optional; DefaultParameterValue(null)>] ?MultiHoverText: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?HoverInfo: StyleParam.HoverInfo,
            [<Optional; DefaultParameterValue(null)>] ?HoverTemplate: string,
            [<Optional; DefaultParameterValue(null)>] ?MultiHoverTemplate: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?XHoverFormat: string,
            [<Optional; DefaultParameterValue(null)>] ?YHoverFormat: string,
            [<Optional; DefaultParameterValue(null)>] ?Meta: string,
            [<Optional; DefaultParameterValue(null)>] ?CustomData: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?XAxis: StyleParam.LinearAxisId,
            [<Optional; DefaultParameterValue(null)>] ?YAxis: StyleParam.LinearAxisId,
            [<Optional; DefaultParameterValue(null)>] ?Orientation: StyleParam.Orientation,
            [<Optional; DefaultParameterValue(null)>] ?AlignmentGroup: string,
            [<Optional; DefaultParameterValue(null)>] ?OffsetGroup: string,
            [<Optional; DefaultParameterValue(null)>] ?XPeriod: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?XPeriodAlignment: StyleParam.PeriodAlignment,
            [<Optional; DefaultParameterValue(null)>] ?XPeriod0: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?YPeriod: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?YPeriodAlignment: StyleParam.PeriodAlignment,
            [<Optional; DefaultParameterValue(null)>] ?YPeriod0: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
            [<Optional; DefaultParameterValue(null)>] ?Line: Line,
            [<Optional; DefaultParameterValue(null)>] ?BoxMean: StyleParam.BoxMean,
            [<Optional; DefaultParameterValue(null)>] ?BoxPoints: StyleParam.BoxPoints,
            [<Optional; DefaultParameterValue(null)>] ?Notched: bool,
            [<Optional; DefaultParameterValue(null)>] ?NotchWidth: float,
            [<Optional; DefaultParameterValue(null)>] ?ShowWhiskers: bool,
            [<Optional; DefaultParameterValue(null)>] ?WhiskerWidth: float,
            [<Optional; DefaultParameterValue(null)>] ?Q1: seq<IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Median: seq<IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Q3: seq<IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?LowerFence: seq<IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?UpperFence: seq<IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?NotchSpan: seq<IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Mean: seq<IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?SD: seq<IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?SDMultiple: float,
            [<Optional; DefaultParameterValue(null)>] ?QuartileMethod: StyleParam.QuartileMethod,
            [<Optional; DefaultParameterValue(null)>] ?SelectedPoints: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Selected: TraceSelection,
            [<Optional; DefaultParameterValue(null)>] ?Unselected: TraceSelection,
            [<Optional; DefaultParameterValue(null)>] ?FillColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?HoverLabel: Hoverlabel,
            [<Optional; DefaultParameterValue(null)>] ?HoverOn: StyleParam.HoverOn,
            [<Optional; DefaultParameterValue(null)>] ?PointPos: float,
            [<Optional; DefaultParameterValue(null)>] ?Jitter: float,
            [<Optional; DefaultParameterValue(null)>] ?SizeMode: StyleParam.BoxSizeMode,
            [<Optional; DefaultParameterValue(null)>] ?XCalendar: StyleParam.Calendar,
            [<Optional; DefaultParameterValue(null)>] ?YCalendar: StyleParam.Calendar,
            [<Optional; DefaultParameterValue(null)>] ?UIRevision: string
        ) =
        (fun (boxPlot: ('T :> Trace)) ->

            Name |> DynObj.setOptionalProperty boxPlot "name"
            Visible |> DynObj.setOptionalPropertyBy boxPlot "visible" StyleParam.Visible.convert
            ShowLegend |> DynObj.setOptionalProperty boxPlot "showlegend"
            Legend |> DynObj.setOptionalPropertyBy boxPlot "legend" StyleParam.SubPlotId.convert
            LegendRank |> DynObj.setOptionalProperty boxPlot "legendrank"
            LegendGroup |> DynObj.setOptionalProperty boxPlot "legendgroup"
            LegendGroupTitle |> DynObj.setOptionalProperty boxPlot "legendgrouptitle"
            LegendWidth |> DynObj.setOptionalProperty boxPlot "legendwidth"
            Opacity |> DynObj.setOptionalProperty boxPlot "opacity"
            Ids |> DynObj.setOptionalProperty boxPlot "ids"
            (X, MultiX) |> DynObj.setOptionalSingleOrMultiProperty boxPlot "x"
            X0 |> DynObj.setOptionalProperty boxPlot "x0"
            DX |> DynObj.setOptionalProperty boxPlot "dx"
            (Y, MultiY) |> DynObj.setOptionalSingleOrMultiProperty boxPlot "y"
            Y0 |> DynObj.setOptionalProperty boxPlot "y0"
            DY |> DynObj.setOptionalProperty boxPlot "dy"
            Width |> DynObj.setOptionalProperty boxPlot "width"
            (Text, MultiText) |> DynObj.setOptionalSingleOrMultiProperty boxPlot "text"
            (HoverText, MultiHoverText) |> DynObj.setOptionalSingleOrMultiProperty boxPlot "hovertext"
            HoverInfo |> DynObj.setOptionalPropertyBy boxPlot "hoverinfo" StyleParam.HoverInfo.convert
            (HoverTemplate, MultiHoverTemplate) |> DynObj.setOptionalSingleOrMultiProperty boxPlot "hovertemplate"
            XHoverFormat |> DynObj.setOptionalProperty boxPlot "xhoverformat"
            YHoverFormat |> DynObj.setOptionalProperty boxPlot "yhoverformat"
            Meta |> DynObj.setOptionalProperty boxPlot "meta"
            CustomData |> DynObj.setOptionalProperty boxPlot "customdata"
            XAxis |> DynObj.setOptionalPropertyBy boxPlot "xaxis" StyleParam.LinearAxisId.convert
            YAxis |> DynObj.setOptionalPropertyBy boxPlot "yaxis" StyleParam.LinearAxisId.convert
            Orientation |> DynObj.setOptionalPropertyBy boxPlot "orientation" StyleParam.Orientation.convert
            AlignmentGroup |> DynObj.setOptionalProperty boxPlot "alignmentgroup"
            OffsetGroup |> DynObj.setOptionalProperty boxPlot "offsetgroup"
            XPeriod |> DynObj.setOptionalProperty boxPlot "xperiod"
            XPeriodAlignment |> DynObj.setOptionalPropertyBy boxPlot "xperiodalignment" StyleParam.PeriodAlignment.convert
            XPeriod0 |> DynObj.setOptionalProperty boxPlot "xperiod0"
            YPeriod |> DynObj.setOptionalProperty boxPlot "yperiod"
            YPeriodAlignment |> DynObj.setOptionalPropertyBy boxPlot "yperiodalignment" StyleParam.PeriodAlignment.convert
            YPeriod0 |> DynObj.setOptionalProperty boxPlot "yperiod0"
            Marker |> DynObj.setOptionalProperty boxPlot "marker"
            Line |> DynObj.setOptionalProperty boxPlot "line"
            BoxMean |> DynObj.setOptionalPropertyBy boxPlot "boxmean" StyleParam.BoxMean.convert
            BoxPoints |> DynObj.setOptionalPropertyBy boxPlot "boxpoints" StyleParam.BoxPoints.convert
            Notched |> DynObj.setOptionalProperty boxPlot "notched"
            NotchWidth |> DynObj.setOptionalProperty boxPlot "notchwidth"
            WhiskerWidth |> DynObj.setOptionalProperty boxPlot "whiskerwidth"
            ShowWhiskers |> DynObj.setOptionalProperty boxPlot "showwhiskers"
            Q1 |> DynObj.setOptionalProperty boxPlot "q1"
            Median |> DynObj.setOptionalProperty boxPlot "median"
            Q3 |> DynObj.setOptionalProperty boxPlot "q3"
            LowerFence |> DynObj.setOptionalProperty boxPlot "lowerfence"
            UpperFence |> DynObj.setOptionalProperty boxPlot "upperfence"
            NotchSpan |> DynObj.setOptionalProperty boxPlot "notchspan"
            Mean |> DynObj.setOptionalProperty boxPlot "mean"
            SD |> DynObj.setOptionalProperty boxPlot "sd"
            SDMultiple |> DynObj.setOptionalProperty boxPlot "sdmultiple"
            QuartileMethod |> DynObj.setOptionalPropertyBy boxPlot "quartilemethod" StyleParam.QuartileMethod.convert
            SelectedPoints |> DynObj.setOptionalProperty boxPlot "selectedpoints"
            Selected |> DynObj.setOptionalProperty boxPlot "selected"
            Unselected |> DynObj.setOptionalProperty boxPlot "unselected"
            FillColor |> DynObj.setOptionalProperty boxPlot "fillcolor"
            HoverLabel |> DynObj.setOptionalProperty boxPlot "hoverlabel"
            HoverOn |> DynObj.setOptionalPropertyBy boxPlot "hoveron" StyleParam.HoverOn.convert
            PointPos |> DynObj.setOptionalProperty boxPlot "pointpos"
            Jitter |> DynObj.setOptionalProperty boxPlot "jitter"
            SizeMode |> DynObj.setOptionalPropertyBy boxPlot "sizemode" StyleParam.BoxSizeMode.convert
            XCalendar |> DynObj.setOptionalPropertyBy boxPlot "xcalendar" StyleParam.Calendar.convert
            YCalendar |> DynObj.setOptionalPropertyBy boxPlot "ycalendar" StyleParam.Calendar.convert
            UIRevision |> DynObj.setOptionalProperty boxPlot "uirevision"

            // out ->
            boxPlot)


    /// <summary>
    /// Create a function that applies the styles of a violin plot to a Trace object
    /// </summary>
    /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
    /// <param name="Visible">Determines whether or not this trace is visible. If "legendonly", the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).</param>
    /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
    /// <param name="Legend">Sets the reference to a legend to show this trace in. References to these legends are "legend", "legend2", "legend3", etc. Settings for these legends are set in the layout, under `layout.legend`, `layout.legend2`, etc.</param>
    /// <param name="LegendRank">Sets the legend rank for this trace. Items and groups with smaller ranks are presented on top/left side while with `"reversed" `legend.traceorder` they are on bottom/right side. The default legendrank is 1000, so that you can use ranks less than 1000 to place certain items before all unranked items, and ranks greater than 1000 to go after all unranked items.</param>
    /// <param name="LegendGroup">Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling legend items.</param>
    /// <param name="LegendGroupTitle">Sets the legend group title for this trace.</param>
    /// <param name="Opacity">Sets the opacity of the trace.</param>
    /// <param name="Ids">Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.</param>
    /// <param name="X">Sets the x sample data or coordinates. See overview for more info.</param>
    /// <param name="MultiX">Sets the x sample data or coordinates. See overview for more info.</param>
    /// <param name="X0">Sets the x coordinate for single-box traces or the starting coordinate for multi-box traces set using q1/median/q3. See overview for more info.</param>
    /// <param name="DX">Sets the x coordinate step for multi-box traces set using q1/median/q3.</param>
    /// <param name="Y">Sets the y sample data or coordinates. See overview for more info.</param>
    /// <param name="MultiY">Sets the y sample data or coordinates. See overview for more info.</param>
    /// <param name="Y0">Sets the y coordinate for single-box traces or the starting coordinate for multi-box traces set using q1/median/q3. See overview for more info.</param>
    /// <param name="DY">Sets the y coordinate step for multi-box traces set using q1/median/q3.</param>
    /// <param name="Width">Sets the width of the violin in data coordinates. If "0" (default value) the width is automatically selected based on the positions of other violin traces in the same subplot.</param>
    /// <param name="Text">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
    /// <param name="MultiText">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
    /// <param name="HoverText">Sets hover text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. To be seen, trace `hoverinfo` must contain a "text" flag.</param>
    /// <param name="MultiHoverText">Sets hover text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. To be seen, trace `hoverinfo` must contain a "text" flag.</param>
    /// <param name="HoverInfo">Determines which trace information appear on hover. If `none` or `skip` are set, no information is displayed upon hovering. But, if `none` is set, click and hover events are still fired.</param>
    /// <param name="HoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
    /// <param name="MultiHoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
    /// <param name="XHoverFormat">Sets the hover text formatting rulefor `x` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `xaxis.hoverformat`.</param>
    /// <param name="YHoverFormat">Sets the hover text formatting rulefor `y` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `xaxis.hoverformat`.</param>
    /// <param name="Meta">Assigns extra meta information associated with this trace that can be used in various text attributes. Attributes such as trace `name`, graph, axis and colorbar `title.text`, annotation `text` `rangeselector`, `updatemenues` and `sliders` `label` text all support `meta`. To access the trace `meta` values in an attribute in the same trace, simply use `%{meta[i]}` where `i` is the index or key of the `meta` item in question. To access trace `meta` in layout attributes, use `%{data[n[.meta[i]}` where `i` is the index or key of the `meta` and `n` is the trace index.</param>
    /// <param name="CustomData">Assigns extra data each datum. This may be useful when listening to hover, click and selection events. Note that, "scatter" traces also appends customdata items in the markers DOM elements</param>
    /// <param name="XAxis">Sets a reference between this trace's x coordinates and a 2D cartesian x axis. If "x" (the default value), the x coordinates refer to `layout.xaxis`. If "x2", the x coordinates refer to `layout.xaxis2`, and so on.</param>
    /// <param name="YAxis">Sets a reference between this trace's y coordinates and a 2D cartesian y axis. If "y" (the default value), the y coordinates refer to `layout.yaxis`. If "y2", the y coordinates refer to `layout.yaxis2`, and so on.</param>
    /// <param name="Orientation">Sets the orientation of the violin(s). If "v" ("h"), the distribution is visualized along the vertical (horizontal).</param>
    /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
    /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
    /// <param name="Marker">Sets the Marker of this trace.</param>
    /// <param name="Line">Sets the line of this trace.</param>
    /// <param name="Box">Whether and how to draw a miniature box plot</param>
    /// <param name="SelectedPoints">Array containing integer indices of selected points. Has an effect only for traces that support selections. Note that an empty array means an empty selection where the `unselected` are turned on for all points, whereas, any other non-array values means no selection all where the `selected` and `unselected` styles have no effect.</param>
    /// <param name="Selected">Sets the style of selected points of this trace.</param>
    /// <param name="Unselected">Sets the style of unselected points of this trace.</param>
    /// <param name="BandWidth">Sets the bandwidth used to compute the kernel density estimate. By default, the bandwidth is determined by Silverman's rule of thumb.</param>
    /// <param name="FillColor">Sets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
    /// <param name="HoverLabel">Sets the style of the hoverlabels of this trace.</param>
    /// <param name="HoverOn">Do the hover effects highlight individual boxes or sample points or both?</param>
    /// <param name="PointPos">Sets the position of the sample points in relation to the box(es). If "0", the sample points are places over the center of the box(es). Positive (negative) values correspond to positions to the right (left) for vertical boxes and above (below) for horizontal boxes</param>
    /// <param name="Jitter">Sets the amount of jitter in the sample points drawn. If "0", the sample points align along the distribution axis. If "1", the sample points are drawn in a random jitter of width equal to the width of the box(es).</param>
    /// <param name="MeanLine">Whether and how to draw the meanline</param>
    /// <param name="Points">If "outliers", only the sample points lying outside the whiskers are shown If "suspectedoutliers", the outlier points are shown and points either less than 4"Q1-3"Q3 or greater than 4"Q3-3"Q1 are highlighted (see `outliercolor`) If "all", all sample points are shown If "false", only the violins are shown with no sample points. Defaults to "suspectedoutliers" when `marker.outliercolor` or `marker.line.outliercolor` is set, otherwise defaults to "outliers".</param>
    /// <param name="ScaleGroup">If there are multiple violins that should be sized according to to some metric (see `scalemode`), link them by providing a non-empty group id here shared by every trace in the same group. If a violin's `width` is undefined, `scalegroup` will default to the trace's name. In this case, violins with the same names will be linked together</param>
    /// <param name="ScaleMode">Sets the metric by which the width of each violin is determined."width" means each violin has the same (max) width"count" means the violins are scaled by the number of sample points makingup each violin.</param>
    /// <param name="Side">Determines on which side of the position value the density function making up one half of a violin is plotted. Useful when comparing two violin traces under "overlay" mode, where one trace has `side` set to "positive" and the other to "negative".</param>
    /// <param name="Span">Sets the span in data space for which the density function will be computed. Has an effect only when `spanmode` is set to "manual".</param>
    /// <param name="SpanMode">Sets the method by which the span in data space where the density function will be computed. "soft" means the span goes from the sample's minimum value minus two bandwidths to the sample's maximum value plus two bandwidths. "hard" means the span goes from the sample's minimum to its maximum value. For custom span settings, use mode "manual" and fill in the `span` attribute.</param>
    /// <param name="UIRevision">Controls persistence of some user-driven changes to the trace: `constraintrange` in `parcoords` traces, as well as some `editable: true` modifications such as `name` and `colorbar.title`. Defaults to `layout.uirevision`. Note that other user-driven trace attribute changes are controlled by `layout` attributes: `trace.visible` is controlled by `layout.legend.uirevision`, `selectedpoints` is controlled by `layout.selectionrevision`, and `colorbar.(x|y)` (accessible with `config: {editable: true}`) is controlled by `layout.editrevision`. Trace changes are tracked by `uid`, which only falls back on trace index if no `uid` is provided. So if your app can add/remove traces before the end of the `data` array, such that the same trace has a different index, you can still preserve user-driven changes if you give each trace a `uid` that stays with it as it moves.</param>
    static member Violin
        (
            [<Optional; DefaultParameterValue(null)>] ?Name: string,
            [<Optional; DefaultParameterValue(null)>] ?Visible: StyleParam.Visible,
            [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
            [<Optional; DefaultParameterValue(null)>] ?Legend: StyleParam.SubPlotId,
            [<Optional; DefaultParameterValue(null)>] ?LegendRank: int,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroup: string,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroupTitle: Title,
            [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
            [<Optional; DefaultParameterValue(null)>] ?Ids: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?X: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?MultiX: seq<seq<#IConvertible>>,
            [<Optional; DefaultParameterValue(null)>] ?X0: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?DX: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?Y: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?MultiY: seq<seq<#IConvertible>>,
            [<Optional; DefaultParameterValue(null)>] ?Y0: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?DY: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?Width: float,
            [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?HoverText: string,
            [<Optional; DefaultParameterValue(null)>] ?MultiHoverText: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?HoverInfo: StyleParam.HoverInfo,
            [<Optional; DefaultParameterValue(null)>] ?HoverTemplate: string,
            [<Optional; DefaultParameterValue(null)>] ?MultiHoverTemplate: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?XHoverFormat: string,
            [<Optional; DefaultParameterValue(null)>] ?YHoverFormat: string,
            [<Optional; DefaultParameterValue(null)>] ?Meta: string,
            [<Optional; DefaultParameterValue(null)>] ?CustomData: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?XAxis: StyleParam.LinearAxisId,
            [<Optional; DefaultParameterValue(null)>] ?YAxis: StyleParam.LinearAxisId,
            [<Optional; DefaultParameterValue(null)>] ?Orientation: StyleParam.Orientation,
            [<Optional; DefaultParameterValue(null)>] ?AlignmentGroup: string,
            [<Optional; DefaultParameterValue(null)>] ?OffsetGroup: string,
            [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
            [<Optional; DefaultParameterValue(null)>] ?Line: Line,
            [<Optional; DefaultParameterValue(null)>] ?Box: Box,
            [<Optional; DefaultParameterValue(null)>] ?SelectedPoints: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Selected: TraceSelection,
            [<Optional; DefaultParameterValue(null)>] ?Unselected: TraceSelection,
            [<Optional; DefaultParameterValue(null)>] ?BandWidth: float,
            [<Optional; DefaultParameterValue(null)>] ?FillColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?HoverLabel: Hoverlabel,
            [<Optional; DefaultParameterValue(null)>] ?HoverOn: StyleParam.HoverOn,
            [<Optional; DefaultParameterValue(null)>] ?PointPos: float,
            [<Optional; DefaultParameterValue(null)>] ?Jitter: float,
            [<Optional; DefaultParameterValue(null)>] ?MeanLine: MeanLine,
            [<Optional; DefaultParameterValue(null)>] ?Points: StyleParam.JitterPoints,
            [<Optional; DefaultParameterValue(null)>] ?ScaleGroup: string,
            [<Optional; DefaultParameterValue(null)>] ?ScaleMode: StyleParam.ScaleMode,
            [<Optional; DefaultParameterValue(null)>] ?Side: StyleParam.ViolinSide,
            [<Optional; DefaultParameterValue(null)>] ?Span: StyleParam.Range,
            [<Optional; DefaultParameterValue(null)>] ?SpanMode: StyleParam.SpanMode,
            [<Optional; DefaultParameterValue(null)>] ?UIRevision: string
        ) =
        (fun (violin: ('T :> Trace)) ->

            Name |> DynObj.setOptionalProperty violin "name"
            Visible |> DynObj.setOptionalPropertyBy violin "visible" StyleParam.Visible.convert
            ShowLegend |> DynObj.setOptionalProperty violin "showlegend"
            Legend |> DynObj.setOptionalPropertyBy violin "legend" StyleParam.SubPlotId.convert
            LegendRank |> DynObj.setOptionalProperty violin "legendrank"
            LegendGroup |> DynObj.setOptionalProperty violin "legendgroup"
            LegendGroupTitle |> DynObj.setOptionalProperty violin "legendgrouptitle"
            Opacity |> DynObj.setOptionalProperty violin "opacity"
            Ids |> DynObj.setOptionalProperty violin "ids"
            (X, MultiX) |> DynObj.setOptionalSingleOrMultiProperty violin "x"
            X0 |> DynObj.setOptionalProperty violin "x0"
            DX |> DynObj.setOptionalProperty violin "dx"
            (Y, MultiY) |> DynObj.setOptionalSingleOrMultiProperty violin "y"
            Y0 |> DynObj.setOptionalProperty violin "y0"
            DY |> DynObj.setOptionalProperty violin "dy"
            Width |> DynObj.setOptionalProperty violin "width"
            (Text, MultiText) |> DynObj.setOptionalSingleOrMultiProperty violin "text"
            (HoverText, MultiHoverText) |> DynObj.setOptionalSingleOrMultiProperty violin "hovertext"
            HoverInfo |> DynObj.setOptionalPropertyBy violin "hoverinfo" StyleParam.HoverInfo.convert
            (HoverTemplate, MultiHoverTemplate) |> DynObj.setOptionalSingleOrMultiProperty violin "hovertemplate"
            XHoverFormat |> DynObj.setOptionalProperty violin "xhoverformat"
            YHoverFormat |> DynObj.setOptionalProperty violin "yhoverformat"
            Meta |> DynObj.setOptionalProperty violin "meta"
            CustomData |> DynObj.setOptionalProperty violin "customdata"
            XAxis |> DynObj.setOptionalPropertyBy violin "xaxis" StyleParam.LinearAxisId.convert
            YAxis |> DynObj.setOptionalPropertyBy violin "yaxis" StyleParam.LinearAxisId.convert
            Orientation |> DynObj.setOptionalPropertyBy violin "orientation" StyleParam.Orientation.convert
            AlignmentGroup |> DynObj.setOptionalProperty violin "alignmentgroup"
            OffsetGroup |> DynObj.setOptionalProperty violin "offsetgroup"
            Marker |> DynObj.setOptionalProperty violin "marker"
            Line |> DynObj.setOptionalProperty violin "line"
            Box |> DynObj.setOptionalProperty violin "box"
            SelectedPoints |> DynObj.setOptionalProperty violin "selectedpoints"
            Selected |> DynObj.setOptionalProperty violin "selected"
            Unselected |> DynObj.setOptionalProperty violin "unselected"
            BandWidth |> DynObj.setOptionalProperty violin "bandwidth"
            FillColor |> DynObj.setOptionalProperty violin "fillcolor"
            HoverLabel |> DynObj.setOptionalProperty violin "hoverlabel"
            HoverOn |> DynObj.setOptionalPropertyBy violin "hoveron" StyleParam.HoverOn.convert
            PointPos |> DynObj.setOptionalProperty violin "pointpos"
            Jitter |> DynObj.setOptionalProperty violin "jitter"
            MeanLine |> DynObj.setOptionalProperty violin "meanline"
            Points |> DynObj.setOptionalPropertyBy violin "points" StyleParam.JitterPoints.convert
            ScaleGroup |> DynObj.setOptionalProperty violin "scalegroup"
            ScaleMode |> DynObj.setOptionalPropertyBy violin "scalemode" StyleParam.ScaleMode.convert
            Side |> DynObj.setOptionalPropertyBy violin "side" StyleParam.ViolinSide.convert
            Span |> DynObj.setOptionalPropertyBy violin "span" StyleParam.Range.convert
            SpanMode |> DynObj.setOptionalPropertyBy violin "spanmode" StyleParam.SpanMode.convert
            UIRevision |> DynObj.setOptionalProperty violin "uirevision"

            violin)

    /// <summary>
    /// Create a function that applies the styles of a 2d histogram plot to a Trace object
    /// </summary>
    /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
    /// <param name="Visible">Determines whether or not this trace is visible. If "legendonly", the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).</param>
    /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
    /// <param name="Legend">Sets the reference to a legend to show this trace in. References to these legends are "legend", "legend2", "legend3", etc. Settings for these legends are set in the layout, under `layout.legend`, `layout.legend2`, etc.</param>
    /// <param name="LegendRank">Sets the legend rank for this trace. Items and groups with smaller ranks are presented on top/left side while with `"reversed" `legend.traceorder` they are on bottom/right side. The default legendrank is 1000, so that you can use ranks less than 1000 to place certain items before all unranked items, and ranks greater than 1000 to go after all unranked items.</param>
    /// <param name="LegendGroup">Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling legend items.</param>
    /// <param name="LegendGroupTitle">Sets the legend group title for this trace.</param>
    /// <param name="Opacity">Sets the opacity of the trace.</param>
    /// <param name="Ids">Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.</param>
    /// <param name="X">Sets the sample data to be binned on the x axis.</param>
    /// <param name="MultiX">Sets the sample data to be binned on the x axis.</param>
    /// <param name="XGap">Sets the horizontal gap (in pixels) between bricks.</param>
    /// <param name="Y">Sets the sample data to be binned on the y axis.</param>
    /// <param name="MultiY">Sets the sample data to be binned on the y axis.</param>
    /// <param name="YGap">Sets the vertical gap (in pixels) between bricks.</param>
    /// <param name="Z">Sets the aggregation data.</param>
    /// <param name="TextTemplate">Template string used for rendering the information text that appear on points. Note that this will override `textinfo`. Variables are inserted using %{variable}, for example "y: %{y}". Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. Every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available.</param>
    /// <param name="HoverInfo">Determines which trace information appear on hover. If `none` or `skip` are set, no information is displayed upon hovering. But, if `none` is set, click and hover events are still fired.</param>
    /// <param name="HoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
    /// <param name="MultiHoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
    /// <param name="XHoverFormat">Sets the hover text formatting rulefor `x` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `xaxis.hoverformat`.</param>
    /// <param name="YHoverFormat">Sets the hover text formatting rulefor `y` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `xaxis.hoverformat`.</param>
    /// <param name="Meta">Assigns extra meta information associated with this trace that can be used in various text attributes. Attributes such as trace `name`, graph, axis and colorbar `title.text`, annotation `text` `rangeselector`, `updatemenues` and `sliders` `label` text all support `meta`. To access the trace `meta` values in an attribute in the same trace, simply use `%{meta[i]}` where `i` is the index or key of the `meta` item in question. To access trace `meta` in layout attributes, use `%{data[n[.meta[i]}` where `i` is the index or key of the `meta` and `n` is the trace index.</param>
    /// <param name="CustomData">Assigns extra data each datum. This may be useful when listening to hover, click and selection events. Note that, "scatter" traces also appends customdata items in the markers DOM elements</param>
    /// <param name="XAxis">Sets a reference between this trace's x coordinates and a 2D cartesian x axis. If "x" (the default value), the x coordinates refer to `layout.xaxis`. If "x2", the x coordinates refer to `layout.xaxis2`, and so on.</param>
    /// <param name="YAxis">Sets a reference between this trace's y coordinates and a 2D cartesian y axis. If "y" (the default value), the y coordinates refer to `layout.yaxis`. If "y2", the y coordinates refer to `layout.yaxis2`, and so on.</param>
    /// <param name="ColorAxis">Sets a reference to a shared color axis. References to these shared color axes are "coloraxis", "coloraxis2", "coloraxis3", etc. Settings for these shared color axes are set in the layout, under `layout.coloraxis`, `layout.coloraxis2`, etc. Note that multiple color scales can be linked to the same color axis.</param>
    /// <param name="HistFunc">Specifies the binning function used for this histogram trace. If "count", the histogram values are computed by counting the number of values lying inside each bin. If "sum", "avg", "min", "max", the histogram values are computed using the sum, the average, the minimum or the maximum of the values lying inside each bin respectively.</param>
    /// <param name="HistNorm">Specifies the type of normalization used for this histogram trace. If "", the span of each bar corresponds to the number of occurrences (i.e. the number of data points lying inside the bins). If "percent" / "probability", the span of each bar corresponds to the percentage / fraction of occurrences with respect to the total number of sample points (here, the sum of all bin HEIGHTS equals 100% / 1). If "density", the span of each bar corresponds to the number of occurrences in a bin divided by the size of the bin interval (here, the sum of all bin AREAS equals the total number of sample points). If "probability density", the area of each bar corresponds to the probability that an event will fall into the corresponding bin (here, the sum of all bin AREAS equals 1).</param>
    /// <param name="NBinsX">Specifies the maximum number of desired bins. This value will be used in an algorithm that will decide the optimal bin size such that the histogram best visualizes the distribution of the data. Ignored if `xbins.size` is provided.</param>
    /// <param name="NBinsY">Specifies the maximum number of desired bins. This value will be used in an algorithm that will decide the optimal bin size such that the histogram best visualizes the distribution of the data. Ignored if `ybins.size` is provided.</param>
    /// <param name="AutoBinX">Obsolete: since v1.42 each bin attribute is auto-determined separately and `autobinx` is not needed. However, we accept `autobinx: true` or `false` and will update `xbins` accordingly before deleting `autobinx` from the trace.</param>
    /// <param name="AutoBinY">Obsolete: since v1.42 each bin attribute is auto-determined separately and `autobiny` is not needed. However, we accept `autobiny: true` or `false` and will update `ybins` accordingly before deleting `autobiny` from the trace.</param>
    /// <param name="BinGroup">Set the `xbingroup` and `ybingroup` default prefix For example, setting a `bingroup` of "1" on two histogram2d traces will make them their x-bins and y-bins match separately.</param>
    /// <param name="XBinGroup">Set a group of histogram traces which will have compatible x-bin settings. Using `xbingroup`, histogram2d and histogram2dcontour traces (on axes of the same axis type) can have compatible x-bin settings. Note that the same `xbingroup` value can be used to set (1D) histogram `bingroup`</param>
    /// <param name="XBins">Sets the binning across the x dimension</param>
    /// <param name="YBinGroup">Set a group of histogram traces which will have compatible y-bin settings. Using `ybingroup`, histogram2d and histogram2dcontour traces (on axes of the same axis type) can have compatible y-bin settings. Note that the same `ybingroup` value can be used to set (1D) histogram `bingroup`</param>
    /// <param name="YBins">Sets the binning across the y dimension</param>
    /// <param name="Marker">Sets the marker of this trace.</param>
    /// <param name="TextFont">Sets the text font of this trace.</param>
    /// <param name="ColorBar">Sets the colorbar of this trace.</param>
    /// <param name="AutoColorScale">Determines whether the colorscale is a default palette (`autocolorscale: true`) or the palette determined by `colorscale`. In case `colorscale` is unspecified or `autocolorscale` is true, the default palette will be chosen according to whether numbers in the `color` array are all positive, all negative or mixed.</param>
    /// <param name="ColorScale">Sets the colorscale. The colorscale must be an array containing arrays mapping a normalized value to an rgb, rgba, hex, hsl, hsv, or named color string. At minimum, a mapping for the lowest (0) and highest (1) values are required. For example, `[[0, 'rgb(0,0,255)'], [1, 'rgb(255,0,0)']]`. To control the bounds of the colorscale in color space, use`zmin` and `zmax`. Alternatively, `colorscale` may be a palette name string of the following list: Blackbody,Bluered,Blues,Cividis,Earth,Electric,Greens,Greys,Hot,Jet,Picnic,Portland,Rainbow,RdBu,Reds,Viridis,YlGnBu,YlOrRd.</param>
    /// <param name="ShowScale">Determines whether or not a colorbar is displayed for this trace.</param>
    /// <param name="ReverseScale">Reverses the color mapping if true. If true, `zmin` will correspond to the last color in the array and `zmax` will correspond to the first color.</param>
    /// <param name="ZAuto">Determines whether or not the color domain is computed with respect to the input data (here in `z`) or the bounds set in `zmin` and `zmax` Defaults to `false` when `zmin` and `zmax` are set by the user.</param>
    /// <param name="ZHoverFormat">Sets the hover text formatting rulefor `z` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format.By default the values are formatted using generic number format.</param>
    /// <param name="ZMax">Sets the upper bound of the color domain. Value should have the same units as in `z` and if set, `zmin` must be set as well.</param>
    /// <param name="ZMid">Sets the mid-point of the color domain by scaling `zmin` and/or `zmax` to be equidistant to this point. Value should have the same units as in `z`. Has no effect when `zauto` is `false`.</param>
    /// <param name="ZMin">Sets the lower bound of the color domain. Value should have the same units as in `z` and if set, `zmax` must be set as well.</param>
    /// <param name="ZSmooth">Picks a smoothing algorithm use to smooth `z` data.</param>
    /// <param name="HoverLabel">Sets the style of the hoverlabels of this trace.</param>
    /// <param name="XCalendar">Sets the calendar system to use with `x` date data.</param>
    /// <param name="YCalendar">Sets the calendar system to use with `y` date data.</param>
    /// <param name="UIRevision">Controls persistence of some user-driven changes to the trace: `constraintrange` in `parcoords` traces, as well as some `editable: true` modifications such as `name` and `colorbar.title`. Defaults to `layout.uirevision`. Note that other user-driven trace attribute changes are controlled by `layout` attributes: `trace.visible` is controlled by `layout.legend.uirevision`, `selectedpoints` is controlled by `layout.selectionrevision`, and `colorbar.(x|y)` (accessible with `config: {editable: true}`) is controlled by `layout.editrevision`. Trace changes are tracked by `uid`, which only falls back on trace index if no `uid` is provided. So if your app can add/remove traces before the end of the `data` array, such that the same trace has a different index, you can still preserve user-driven changes if you give each trace a `uid` that stays with it as it moves.</param>
    static member Histogram2D
        (
            [<Optional; DefaultParameterValue(null)>] ?Name: string,
            [<Optional; DefaultParameterValue(null)>] ?Visible: StyleParam.Visible,
            [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
            [<Optional; DefaultParameterValue(null)>] ?Legend: StyleParam.SubPlotId,
            [<Optional; DefaultParameterValue(null)>] ?LegendRank: int,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroup: string,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroupTitle: Title,
            [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
            [<Optional; DefaultParameterValue(null)>] ?Ids: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?X: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?MultiX: seq<seq<#IConvertible>>,
            [<Optional; DefaultParameterValue(null)>] ?XGap: int,
            [<Optional; DefaultParameterValue(null)>] ?Y: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?MultiY: seq<seq<#IConvertible>>,
            [<Optional; DefaultParameterValue(null)>] ?YGap: int,
            [<Optional; DefaultParameterValue(null)>] ?Z: seq<#seq<#IConvertible>>,
            [<Optional; DefaultParameterValue(null)>] ?TextTemplate: string,
            [<Optional; DefaultParameterValue(null)>] ?HoverInfo: StyleParam.HoverInfo,
            [<Optional; DefaultParameterValue(null)>] ?HoverTemplate: string,
            [<Optional; DefaultParameterValue(null)>] ?MultiHoverTemplate: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?XHoverFormat: string,
            [<Optional; DefaultParameterValue(null)>] ?YHoverFormat: string,
            [<Optional; DefaultParameterValue(null)>] ?Meta: string,
            [<Optional; DefaultParameterValue(null)>] ?CustomData: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?XAxis: StyleParam.LinearAxisId,
            [<Optional; DefaultParameterValue(null)>] ?YAxis: StyleParam.LinearAxisId,
            [<Optional; DefaultParameterValue(null)>] ?ColorAxis: StyleParam.SubPlotId,
            [<Optional; DefaultParameterValue(null)>] ?HistFunc: StyleParam.HistFunc,
            [<Optional; DefaultParameterValue(null)>] ?HistNorm: StyleParam.HistNorm,
            [<Optional; DefaultParameterValue(null)>] ?NBinsX: int,
            [<Optional; DefaultParameterValue(null)>] ?NBinsY: int,
            [<Optional; DefaultParameterValue(null)>] ?AutoBinX: bool,
            [<Optional; DefaultParameterValue(null)>] ?AutoBinY: bool,
            [<Optional; DefaultParameterValue(null)>] ?BinGroup: string,
            [<Optional; DefaultParameterValue(null)>] ?XBinGroup: string,
            [<Optional; DefaultParameterValue(null)>] ?XBins: Bins,
            [<Optional; DefaultParameterValue(null)>] ?YBinGroup: string,
            [<Optional; DefaultParameterValue(null)>] ?YBins: Bins,
            [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
            [<Optional; DefaultParameterValue(null)>] ?TextFont: Font,
            [<Optional; DefaultParameterValue(null)>] ?ColorBar: ColorBar,
            [<Optional; DefaultParameterValue(null)>] ?AutoColorScale: bool,
            [<Optional; DefaultParameterValue(null)>] ?ColorScale: StyleParam.Colorscale,
            [<Optional; DefaultParameterValue(null)>] ?ShowScale: bool,
            [<Optional; DefaultParameterValue(null)>] ?ReverseScale: bool,
            [<Optional; DefaultParameterValue(null)>] ?ZAuto: bool,
            [<Optional; DefaultParameterValue(null)>] ?ZHoverFormat: string,
            [<Optional; DefaultParameterValue(null)>] ?ZMin: float,
            [<Optional; DefaultParameterValue(null)>] ?ZMid: float,
            [<Optional; DefaultParameterValue(null)>] ?ZMax: float,
            [<Optional; DefaultParameterValue(null)>] ?ZSmooth: StyleParam.SmoothAlg,
            [<Optional; DefaultParameterValue(null)>] ?HoverLabel: Hoverlabel,
            [<Optional; DefaultParameterValue(null)>] ?XCalendar: StyleParam.Calendar,
            [<Optional; DefaultParameterValue(null)>] ?YCalendar: StyleParam.Calendar,
            [<Optional; DefaultParameterValue(null)>] ?UIRevision: string
        ) =
        (fun (histogram2D: ('T :> Trace)) ->

            Name |> DynObj.setOptionalProperty histogram2D "name"
            Visible |> DynObj.setOptionalPropertyBy histogram2D "visible" StyleParam.Visible.convert
            ShowLegend |> DynObj.setOptionalProperty histogram2D "showlegend"
            Legend |> DynObj.setOptionalPropertyBy histogram2D "legend" StyleParam.SubPlotId.convert
            LegendRank |> DynObj.setOptionalProperty histogram2D "legendrank"
            LegendGroup |> DynObj.setOptionalProperty histogram2D "legendgroup"
            LegendGroupTitle |> DynObj.setOptionalProperty histogram2D "legendgrouptitle"
            Opacity |> DynObj.setOptionalProperty histogram2D "opacity"
            Ids |> DynObj.setOptionalProperty histogram2D "ids"
            (X, MultiX) |> DynObj.setOptionalSingleOrMultiProperty histogram2D "x"
            XGap |> DynObj.setOptionalProperty histogram2D "xgap"
            (Y, MultiY) |> DynObj.setOptionalSingleOrMultiProperty histogram2D "y"
            YGap |> DynObj.setOptionalProperty histogram2D "ygap"
            Z |> DynObj.setOptionalProperty histogram2D "z"
            TextTemplate |> DynObj.setOptionalProperty histogram2D "texttemplate"
            HoverInfo |> DynObj.setOptionalPropertyBy histogram2D "hoverinfo" StyleParam.HoverInfo.convert
            (HoverTemplate, MultiHoverTemplate) |> DynObj.setOptionalSingleOrMultiProperty histogram2D "hovertemplate"
            XHoverFormat |> DynObj.setOptionalProperty histogram2D "xhoverformat"
            YHoverFormat |> DynObj.setOptionalProperty histogram2D "yhoverformat"
            Meta |> DynObj.setOptionalProperty histogram2D "meta"
            CustomData |> DynObj.setOptionalProperty histogram2D "customdata"
            XAxis |> DynObj.setOptionalPropertyBy histogram2D "xaxis" StyleParam.LinearAxisId.convert
            YAxis |> DynObj.setOptionalPropertyBy histogram2D "yaxis" StyleParam.LinearAxisId.convert
            ColorAxis |> DynObj.setOptionalProperty histogram2D "coloraxis"
            HistFunc |> DynObj.setOptionalPropertyBy histogram2D "histfunc" StyleParam.HistFunc.convert
            HistNorm |> DynObj.setOptionalPropertyBy histogram2D "histnorm" StyleParam.HistNorm.convert
            NBinsX |> DynObj.setOptionalProperty histogram2D "nbinsx"
            NBinsY |> DynObj.setOptionalProperty histogram2D "nbinsy"
            AutoBinX |> DynObj.setOptionalProperty histogram2D "autobinx"
            AutoBinY |> DynObj.setOptionalProperty histogram2D "autobiny"
            BinGroup |> DynObj.setOptionalProperty histogram2D "bingroup"
            XBinGroup |> DynObj.setOptionalProperty histogram2D "xbingroup"
            XBins |> DynObj.setOptionalProperty histogram2D "xbins"
            YBinGroup |> DynObj.setOptionalProperty histogram2D "ybingroup"
            YBins |> DynObj.setOptionalProperty histogram2D "ybins"
            Marker |> DynObj.setOptionalProperty histogram2D "marker"
            TextFont |> DynObj.setOptionalProperty histogram2D "textfont"
            ColorBar |> DynObj.setOptionalProperty histogram2D "colorbar"
            AutoColorScale |> DynObj.setOptionalProperty histogram2D "autocolorscale"
            ColorScale |> DynObj.setOptionalPropertyBy histogram2D "colorscale" StyleParam.Colorscale.convert
            ShowScale |> DynObj.setOptionalProperty histogram2D "showscale"
            ReverseScale |> DynObj.setOptionalProperty histogram2D "reversescale"
            ZAuto |> DynObj.setOptionalProperty histogram2D "zauto"
            ZHoverFormat |> DynObj.setOptionalProperty histogram2D "zhoverformat"
            ZMin |> DynObj.setOptionalProperty histogram2D "zmin"
            ZMid |> DynObj.setOptionalProperty histogram2D "zmid"
            ZMax |> DynObj.setOptionalProperty histogram2D "zmax"
            ZSmooth |> DynObj.setOptionalPropertyBy histogram2D "zsmooth" StyleParam.SmoothAlg.convert
            HoverLabel |> DynObj.setOptionalProperty histogram2D "hoverlabel"
            XCalendar |> DynObj.setOptionalPropertyBy histogram2D "xcalendar" StyleParam.Calendar.convert
            YCalendar |> DynObj.setOptionalPropertyBy histogram2D "ycalendar" StyleParam.Calendar.convert
            UIRevision |> DynObj.setOptionalProperty histogram2D "uirevision"

            histogram2D)

    /// <summary>
    /// Create a function that applies the styles of a 2d histogram contour plot to a Trace object
    /// </summary>
    /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
    /// <param name="Visible">Determines whether or not this trace is visible. If "legendonly", the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).</param>
    /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
    /// <param name="Legend">Sets the reference to a legend to show this trace in. References to these legends are "legend", "legend2", "legend3", etc. Settings for these legends are set in the layout, under `layout.legend`, `layout.legend2`, etc.</param>
    /// <param name="LegendRank">Sets the legend rank for this trace. Items and groups with smaller ranks are presented on top/left side while with `"reversed" `legend.traceorder` they are on bottom/right side. The default legendrank is 1000, so that you can use ranks less than 1000 to place certain items before all unranked items, and ranks greater than 1000 to go after all unranked items.</param>
    /// <param name="LegendGroup">Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling legend items.</param>
    /// <param name="LegendGroupTitle">Sets the legend group title for this trace.</param>
    /// <param name="Opacity">Sets the opacity of the trace.</param>
    /// <param name="Ids">Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.</param>
    /// <param name="X">Sets the sample data to be binned on the x axis.</param>
    /// <param name="MultiX">Sets the sample data to be binned on the x axis.</param>
    /// <param name="Y">Sets the sample data to be binned on the y axis.</param>
    /// <param name="MultiY">Sets the sample data to be binned on the y axis.</param>
    /// <param name="Z">Sets the aggregation data.</param>
    /// <param name="TextTemplate">For this trace it only has an effect if `coloring` is set to "heatmap". Template string used for rendering the information text that appear on points. Note that this will override `textinfo`. Variables are inserted using %{variable}, for example "y: %{y}". Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. Every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available.</param>
    /// <param name="HoverInfo">Determines which trace information appear on hover. If `none` or `skip` are set, no information is displayed upon hovering. But, if `none` is set, click and hover events are still fired.</param>
    /// <param name="HoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
    /// <param name="MultiHoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
    /// <param name="XHoverFormat">Sets the hover text formatting rulefor `x` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `xaxis.hoverformat`.</param>
    /// <param name="YHoverFormat">Sets the hover text formatting rulefor `y` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `xaxis.hoverformat`.</param>
    /// <param name="Meta">Assigns extra meta information associated with this trace that can be used in various text attributes. Attributes such as trace `name`, graph, axis and colorbar `title.text`, annotation `text` `rangeselector`, `updatemenues` and `sliders` `label` text all support `meta`. To access the trace `meta` values in an attribute in the same trace, simply use `%{meta[i]}` where `i` is the index or key of the `meta` item in question. To access trace `meta` in layout attributes, use `%{data[n[.meta[i]}` where `i` is the index or key of the `meta` and `n` is the trace index.</param>
    /// <param name="CustomData">Assigns extra data each datum. This may be useful when listening to hover, click and selection events. Note that, "scatter" traces also appends customdata items in the markers DOM elements</param>
    /// <param name="XAxis">Sets a reference between this trace's x coordinates and a 2D cartesian x axis. If "x" (the default value), the x coordinates refer to `layout.xaxis`. If "x2", the x coordinates refer to `layout.xaxis2`, and so on.</param>
    /// <param name="YAxis">Sets a reference between this trace's y coordinates and a 2D cartesian y axis. If "y" (the default value), the y coordinates refer to `layout.yaxis`. If "y2", the y coordinates refer to `layout.yaxis2`, and so on.</param>
    /// <param name="ColorAxis">Sets a reference to a shared color axis. References to these shared color axes are "coloraxis", "coloraxis2", "coloraxis3", etc. Settings for these shared color axes are set in the layout, under `layout.coloraxis`, `layout.coloraxis2`, etc. Note that multiple color scales can be linked to the same color axis.</param>
    /// <param name="HistFunc">Specifies the binning function used for this histogram trace. If "count", the histogram values are computed by counting the number of values lying inside each bin. If "sum", "avg", "min", "max", the histogram values are computed using the sum, the average, the minimum or the maximum of the values lying inside each bin respectively.</param>
    /// <param name="HistNorm">Specifies the type of normalization used for this histogram trace. If "", the span of each bar corresponds to the number of occurrences (i.e. the number of data points lying inside the bins). If "percent" / "probability", the span of each bar corresponds to the percentage / fraction of occurrences with respect to the total number of sample points (here, the sum of all bin HEIGHTS equals 100% / 1). If "density", the span of each bar corresponds to the number of occurrences in a bin divided by the size of the bin interval (here, the sum of all bin AREAS equals the total number of sample points). If "probability density", the area of each bar corresponds to the probability that an event will fall into the corresponding bin (here, the sum of all bin AREAS equals 1).</param>
    /// <param name="NBinsX">Specifies the maximum number of desired bins. This value will be used in an algorithm that will decide the optimal bin size such that the histogram best visualizes the distribution of the data. Ignored if `xbins.size` is provided.</param>
    /// <param name="NBinsY">Specifies the maximum number of desired bins. This value will be used in an algorithm that will decide the optimal bin size such that the histogram best visualizes the distribution of the data. Ignored if `ybins.size` is provided.</param>
    /// <param name="AutoBinX">Obsolete: since v1.42 each bin attribute is auto-determined separately and `autobinx` is not needed. However, we accept `autobinx: true` or `false` and will update `xbins` accordingly before deleting `autobinx` from the trace.</param>
    /// <param name="AutoBinY">Obsolete: since v1.42 each bin attribute is auto-determined separately and `autobiny` is not needed. However, we accept `autobiny: true` or `false` and will update `ybins` accordingly before deleting `autobiny` from the trace.</param>
    /// <param name="BinGroup">Set the `xbingroup` and `ybingroup` default prefix For example, setting a `bingroup` of "1" on two histogram2d traces will make them their x-bins and y-bins match separately.</param>
    /// <param name="XBinGroup">Set a group of histogram traces which will have compatible x-bin settings. Using `xbingroup`, histogram2d and histogram2dcontour traces (on axes of the same axis type) can have compatible x-bin settings. Note that the same `xbingroup` value can be used to set (1D) histogram `bingroup`</param>
    /// <param name="XBins">Sets the binning across the x dimension</param>
    /// <param name="YBinGroup">Set a group of histogram traces which will have compatible y-bin settings. Using `ybingroup`, histogram2d and histogram2dcontour traces (on axes of the same axis type) can have compatible y-bin settings. Note that the same `ybingroup` value can be used to set (1D) histogram `bingroup`</param>
    /// <param name="YBins">Sets the binning across the y dimension</param>
    /// <param name="Marker">Sets the marker of this trace.</param>
    /// <param name="Line">Sets the line of this trace.</param>
    /// <param name="TextFont">For this trace it only has an effect if `coloring` is set to "heatmap". Sets the text font of this trace.</param>
    /// <param name="ColorBar">Sets the colorbar of this trace.</param>
    /// <param name="AutoColorScale">Determines whether the colorscale is a default palette (`autocolorscale: true`) or the palette determined by `colorscale`. In case `colorscale` is unspecified or `autocolorscale` is true, the default palette will be chosen according to whether numbers in the `color` array are all positive, all negative or mixed.</param>
    /// <param name="ColorScale">Sets the colorscale. The colorscale must be an array containing arrays mapping a normalized value to an rgb, rgba, hex, hsl, hsv, or named color string. At minimum, a mapping for the lowest (0) and highest (1) values are required. For example, `[[0, 'rgb(0,0,255)'], [1, 'rgb(255,0,0)']]`. To control the bounds of the colorscale in color space, use`zmin` and `zmax`. Alternatively, `colorscale` may be a palette name string of the following list: Blackbody,Bluered,Blues,Cividis,Earth,Electric,Greens,Greys,Hot,Jet,Picnic,Portland,Rainbow,RdBu,Reds,Viridis,YlGnBu,YlOrRd.</param>
    /// <param name="ShowScale">Determines whether or not a colorbar is displayed for this trace.</param>
    /// <param name="ReverseScale">Reverses the color mapping if true. If true, `zmin` will correspond to the last color in the array and `zmax` will correspond to the first color.</param>
    /// <param name="ZAuto">Determines whether or not the color domain is computed with respect to the input data (here in `z`) or the bounds set in `zmin` and `zmax` Defaults to `false` when `zmin` and `zmax` are set by the user.</param>
    /// <param name="ZHoverFormat">Sets the hover text formatting rulefor `z` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format.By default the values are formatted using generic number format.</param>
    /// <param name="Zmax">Sets the upper bound of the color domain. Value should have the same units as in `z` and if set, `zmin` must be set as well.</param>
    /// <param name="Zmid">Sets the mid-point of the color domain by scaling `zmin` and/or `zmax` to be equidistant to this point. Value should have the same units as in `z`. Has no effect when `zauto` is `false`.</param>
    /// <param name="Zmin">Sets the lower bound of the color domain. Value should have the same units as in `z` and if set, `zmax` must be set as well.</param>
    /// <param name="AutoContour">Determines whether or not the contour level attributes are picked by an algorithm. If "true", the number of contour levels can be set in `ncontours`. If "false", set the contour level attributes in `contours`.</param>
    /// <param name="Contours">Sets the contours of this trace.</param>
    /// <param name="HoverLabel">Sets the style of the hoverlabels of this trace.</param>
    /// <param name="NContours">Sets the maximum number of contour levels. The actual number of contours will be chosen automatically to be less than or equal to the value of `ncontours`. Has an effect only if `autocontour` is "true" or if `contours.size` is missing.</param>
    /// <param name="XCalendar">Sets the calendar system to use with `x` date data.</param>
    /// <param name="YCalendar">Sets the calendar system to use with `y` date data.</param>
    /// <param name="UIRevision">Controls persistence of some user-driven changes to the trace: `constraintrange` in `parcoords` traces, as well as some `editable: true` modifications such as `name` and `colorbar.title`. Defaults to `layout.uirevision`. Note that other user-driven trace attribute changes are controlled by `layout` attributes: `trace.visible` is controlled by `layout.legend.uirevision`, `selectedpoints` is controlled by `layout.selectionrevision`, and `colorbar.(x|y)` (accessible with `config: {editable: true}`) is controlled by `layout.editrevision`. Trace changes are tracked by `uid`, which only falls back on trace index if no `uid` is provided. So if your app can add/remove traces before the end of the `data` array, such that the same trace has a different index, you can still preserve user-driven changes if you give each trace a `uid` that stays with it as it moves.</param>
    static member Histogram2DContour
        (
            [<Optional; DefaultParameterValue(null)>] ?Name: string,
            [<Optional; DefaultParameterValue(null)>] ?Visible: StyleParam.Visible,
            [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
            [<Optional; DefaultParameterValue(null)>] ?Legend: StyleParam.SubPlotId,
            [<Optional; DefaultParameterValue(null)>] ?LegendRank: int,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroup: string,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroupTitle: Title,
            [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
            [<Optional; DefaultParameterValue(null)>] ?Ids: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?X: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?MultiX: seq<seq<#IConvertible>>,
            [<Optional; DefaultParameterValue(null)>] ?Y: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?MultiY: seq<seq<#IConvertible>>,
            [<Optional; DefaultParameterValue(null)>] ?Z: seq<#seq<#IConvertible>>,
            [<Optional; DefaultParameterValue(null)>] ?TextTemplate: string,
            [<Optional; DefaultParameterValue(null)>] ?HoverInfo: StyleParam.HoverInfo,
            [<Optional; DefaultParameterValue(null)>] ?HoverTemplate: string,
            [<Optional; DefaultParameterValue(null)>] ?MultiHoverTemplate: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?XHoverFormat: string,
            [<Optional; DefaultParameterValue(null)>] ?YHoverFormat: string,
            [<Optional; DefaultParameterValue(null)>] ?Meta: string,
            [<Optional; DefaultParameterValue(null)>] ?CustomData: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?XAxis: StyleParam.LinearAxisId,
            [<Optional; DefaultParameterValue(null)>] ?YAxis: StyleParam.LinearAxisId,
            [<Optional; DefaultParameterValue(null)>] ?ColorAxis: StyleParam.SubPlotId,
            [<Optional; DefaultParameterValue(null)>] ?HistFunc: StyleParam.HistFunc,
            [<Optional; DefaultParameterValue(null)>] ?HistNorm: StyleParam.HistNorm,
            [<Optional; DefaultParameterValue(null)>] ?NBinsX: int,
            [<Optional; DefaultParameterValue(null)>] ?NBinsY: int,
            [<Optional; DefaultParameterValue(null)>] ?AutoBinX: bool,
            [<Optional; DefaultParameterValue(null)>] ?AutoBinY: bool,
            [<Optional; DefaultParameterValue(null)>] ?BinGroup: string,
            [<Optional; DefaultParameterValue(null)>] ?XBinGroup: string,
            [<Optional; DefaultParameterValue(null)>] ?XBins: Bins,
            [<Optional; DefaultParameterValue(null)>] ?YBinGroup: string,
            [<Optional; DefaultParameterValue(null)>] ?YBins: Bins,
            [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
            [<Optional; DefaultParameterValue(null)>] ?Line: Line,
            [<Optional; DefaultParameterValue(null)>] ?TextFont: Font,
            [<Optional; DefaultParameterValue(null)>] ?ColorBar: ColorBar,
            [<Optional; DefaultParameterValue(null)>] ?AutoColorScale: bool,
            [<Optional; DefaultParameterValue(null)>] ?ColorScale: StyleParam.Colorscale,
            [<Optional; DefaultParameterValue(null)>] ?ShowScale: bool,
            [<Optional; DefaultParameterValue(null)>] ?ReverseScale: bool,
            [<Optional; DefaultParameterValue(null)>] ?ZAuto: bool,
            [<Optional; DefaultParameterValue(null)>] ?ZHoverFormat: string,
            [<Optional; DefaultParameterValue(null)>] ?Zmin: float,
            [<Optional; DefaultParameterValue(null)>] ?Zmid: float,
            [<Optional; DefaultParameterValue(null)>] ?Zmax: float,
            [<Optional; DefaultParameterValue(null)>] ?AutoContour: bool,
            [<Optional; DefaultParameterValue(null)>] ?Contours: Contours,
            [<Optional; DefaultParameterValue(null)>] ?HoverLabel: Hoverlabel,
            [<Optional; DefaultParameterValue(null)>] ?NContours: int,
            [<Optional; DefaultParameterValue(null)>] ?XCalendar: StyleParam.Calendar,
            [<Optional; DefaultParameterValue(null)>] ?YCalendar: StyleParam.Calendar,
            [<Optional; DefaultParameterValue(null)>] ?UIRevision: string
        ) =
        (fun (histogram2DContour: ('T :> Trace)) ->

            Name |> DynObj.setOptionalProperty histogram2DContour "name"
            Visible |> DynObj.setOptionalPropertyBy histogram2DContour "visible" StyleParam.Visible.convert
            ShowLegend |> DynObj.setOptionalProperty histogram2DContour "showlegend"
            Legend |> DynObj.setOptionalPropertyBy histogram2DContour "legend" StyleParam.SubPlotId.convert
            LegendRank |> DynObj.setOptionalProperty histogram2DContour "legendrank"
            LegendGroup |> DynObj.setOptionalProperty histogram2DContour "legendgroup"
            LegendGroupTitle |> DynObj.setOptionalProperty histogram2DContour "legendgrouptitle"
            Opacity |> DynObj.setOptionalProperty histogram2DContour "opacity"
            Ids |> DynObj.setOptionalProperty histogram2DContour "ids"
            (X, MultiX) |> DynObj.setOptionalSingleOrMultiProperty histogram2DContour "x"
            (Y, MultiY) |> DynObj.setOptionalSingleOrMultiProperty histogram2DContour "y"
            Z |> DynObj.setOptionalProperty histogram2DContour "z"
            TextTemplate |> DynObj.setOptionalProperty histogram2DContour "texttemplate"
            HoverInfo |> DynObj.setOptionalPropertyBy histogram2DContour "hoverinfo" StyleParam.HoverInfo.convert
            (HoverTemplate, MultiHoverTemplate) |> DynObj.setOptionalSingleOrMultiProperty histogram2DContour "hovertemplate"
            XHoverFormat |> DynObj.setOptionalProperty histogram2DContour "xhoverformat"
            YHoverFormat |> DynObj.setOptionalProperty histogram2DContour "yhoverformat"
            Meta |> DynObj.setOptionalProperty histogram2DContour "meta"
            CustomData |> DynObj.setOptionalProperty histogram2DContour "customdata"
            XAxis |> DynObj.setOptionalPropertyBy histogram2DContour "xaxis" StyleParam.LinearAxisId.convert
            YAxis |> DynObj.setOptionalPropertyBy histogram2DContour "yaxis" StyleParam.LinearAxisId.convert
            ColorAxis |> DynObj.setOptionalProperty histogram2DContour "coloraxis"
            HistFunc |> DynObj.setOptionalPropertyBy histogram2DContour "histfunc" StyleParam.HistFunc.convert
            HistNorm |> DynObj.setOptionalPropertyBy histogram2DContour "histnorm" StyleParam.HistNorm.convert
            NBinsX |> DynObj.setOptionalProperty histogram2DContour "nbinsx"
            NBinsY |> DynObj.setOptionalProperty histogram2DContour "nbinsy"
            AutoBinX |> DynObj.setOptionalProperty histogram2DContour "autobinx"
            AutoBinY |> DynObj.setOptionalProperty histogram2DContour "autobiny"
            BinGroup |> DynObj.setOptionalProperty histogram2DContour "bingroup"
            XBinGroup |> DynObj.setOptionalProperty histogram2DContour "xbingroup"
            XBins |> DynObj.setOptionalProperty histogram2DContour "xbins"
            YBinGroup |> DynObj.setOptionalProperty histogram2DContour "ybingroup"
            YBins |> DynObj.setOptionalProperty histogram2DContour "ybins"
            Marker |> DynObj.setOptionalProperty histogram2DContour "marker"
            Line |> DynObj.setOptionalProperty histogram2DContour "line"
            TextFont |> DynObj.setOptionalProperty histogram2DContour "textfont"
            ColorBar |> DynObj.setOptionalProperty histogram2DContour "colorbar"
            AutoColorScale |> DynObj.setOptionalProperty histogram2DContour "autocolorscale"
            ColorScale |> DynObj.setOptionalPropertyBy histogram2DContour "colorscale" StyleParam.Colorscale.convert
            ShowScale |> DynObj.setOptionalProperty histogram2DContour "showscale"
            ReverseScale |> DynObj.setOptionalProperty histogram2DContour "reversescale"
            ZAuto |> DynObj.setOptionalProperty histogram2DContour "zauto"
            ZHoverFormat |> DynObj.setOptionalProperty histogram2DContour "zhoverformat"
            Zmin |> DynObj.setOptionalProperty histogram2DContour "zmin"
            Zmid |> DynObj.setOptionalProperty histogram2DContour "zmid"
            Zmax |> DynObj.setOptionalProperty histogram2DContour "zmax"
            AutoContour |> DynObj.setOptionalProperty histogram2DContour "autocontour"
            Contours |> DynObj.setOptionalProperty histogram2DContour "contours"
            HoverLabel |> DynObj.setOptionalProperty histogram2DContour "hoverlabel"
            NContours |> DynObj.setOptionalProperty histogram2DContour "ncontours"
            XCalendar |> DynObj.setOptionalPropertyBy histogram2DContour "xcalendar" StyleParam.Calendar.convert
            YCalendar |> DynObj.setOptionalPropertyBy histogram2DContour "ycalendar" StyleParam.Calendar.convert
            UIRevision |> DynObj.setOptionalProperty histogram2DContour "uirevision"

            histogram2DContour)


    /// <summary>
    /// Create a function that applies the styles of a heatmap to a Trace object
    /// </summary>
    /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
    /// <param name="Visible">Determines whether or not this trace is visible. If "legendonly", the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).</param>
    /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
    /// <param name="Legend">Sets the reference to a legend to show this trace in. References to these legends are "legend", "legend2", "legend3", etc. Settings for these legends are set in the layout, under `layout.legend`, `layout.legend2`, etc.</param>
    /// <param name="LegendRank">Sets the legend rank for this trace. Items and groups with smaller ranks are presented on top/left side while with `"reversed" `legend.traceorder` they are on bottom/right side. The default legendrank is 1000, so that you can use ranks less than 1000 to place certain items before all unranked items, and ranks greater than 1000 to go after all unranked items.</param>
    /// <param name="LegendGroup">Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling legend items.</param>
    /// <param name="LegendGroupTitle">Sets the legend group title for this trace.</param>
    /// <param name="Opacity">Sets the opacity of the trace.</param>
    /// <param name="Ids">Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.</param>
    /// <param name="X">Sets the x coordinates.</param>
    /// <param name="MultiX">Sets the x coordinates.</param>
    /// <param name="X0">Alternate to `x`. Builds a linear space of x coordinates. Use with `dx` where `x0` is the starting coordinate and `dx` the step.</param>
    /// <param name="DX">Sets the x coordinate step. See `x0` for more info.</param>
    /// <param name="XType">If "array", the heatmap's x coordinates are given by "x" (the default behavior when `x` is provided). If "scaled", the heatmap's x coordinates are given by "x0" and "dx" (the default behavior when `x` is not provided).</param>
    /// <param name="XGap">Sets the horizontal gap (in pixels) between bricks.</param>
    /// <param name="Y">Sets the y coordinates.</param>
    /// <param name="MultiY">Sets the y coordinates.</param>
    /// <param name="Y0">Alternate to `y`. Builds a linear space of y coordinates. Use with `dy` where `y0` is the starting coordinate and `dy` the step.</param>
    /// <param name="DY">Sets the y coordinate step. See `y0` for more info.</param>
    /// <param name="YType">If "array", the heatmap's y coordinates are given by "y" (the default behavior when `y` is provided) If "scaled", the heatmap's y coordinates are given by "y0" and "dy" (the default behavior when `y` is not provided)</param>
    /// <param name="YGap">Sets the vertical gap (in pixels) between bricks.</param>
    /// <param name="Z">Sets the z data.</param>
    /// <param name="Text">Sets the text elements associated with each z value.</param>
    /// <param name="MultiText">Sets the text elements associated with each z value.</param>
    /// <param name="TextTemplate">Template string used for rendering the information text that appear on points. Note that this will override `textinfo`. Variables are inserted using %{variable}, for example "y: %{y}". Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. Every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available.</param>
    /// <param name="HoverText">Sets hover text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. To be seen, trace `hoverinfo` must contain a "text" flag.</param>
    /// <param name="MultiHoverText">Sets hover text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. To be seen, trace `hoverinfo` must contain a "text" flag.</param>
    /// <param name="HoverInfo">Determines which trace information appear on hover. If `none` or `skip` are set, no information is displayed upon hovering. But, if `none` is set, click and hover events are still fired.</param>
    /// <param name="HoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
    /// <param name="MultiHoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
    /// <param name="XHoverFormat">Sets the hover text formatting rulefor `x` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `xaxis.hoverformat`.</param>
    /// <param name="YHoverFormat">Sets the hover text formatting rulefor `y` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `xaxis.hoverformat`.</param>
    /// <param name="Meta">Assigns extra meta information associated with this trace that can be used in various text attributes. Attributes such as trace `name`, graph, axis and colorbar `title.text`, annotation `text` `rangeselector`, `updatemenues` and `sliders` `label` text all support `meta`. To access the trace `meta` values in an attribute in the same trace, simply use `%{meta[i]}` where `i` is the index or key of the `meta` item in question. To access trace `meta` in layout attributes, use `%{data[n[.meta[i]}` where `i` is the index or key of the `meta` and `n` is the trace index.</param>
    /// <param name="CustomData">Assigns extra data each datum. This may be useful when listening to hover, click and selection events. Note that, "scatter" traces also appends customdata items in the markers DOM elements</param>
    /// <param name="XAxis">Sets a reference between this trace's x coordinates and a 2D cartesian x axis. If "x" (the default value), the x coordinates refer to `layout.xaxis`. If "x2", the x coordinates refer to `layout.xaxis2`, and so on.</param>
    /// <param name="YAxis">Sets a reference between this trace's y coordinates and a 2D cartesian y axis. If "y" (the default value), the y coordinates refer to `layout.yaxis`. If "y2", the y coordinates refer to `layout.yaxis2`, and so on.</param>
    /// <param name="ColorAxis">Sets a reference to a shared color axis. References to these shared color axes are "coloraxis", "coloraxis2", "coloraxis3", etc. Settings for these shared color axes are set in the layout, under `layout.coloraxis`, `layout.coloraxis2`, etc. Note that multiple color scales can be linked to the same color axis.</param>
    /// <param name="XPeriod">Only relevant when the axis `type` is "date". Sets the period positioning in milliseconds or "M&lt;n&gt;" on the x axis. Special values in the form of "M&lt;n&gt;" could be used to declare the number of months. In this case `n` must be a positive integer.</param>
    /// <param name="XPeriodAlignment">Only relevant when the axis `type` is "date". Sets the alignment of data points on the x axis.</param>
    /// <param name="XPeriod0">Only relevant when the axis `type` is "date". Sets the base for period positioning in milliseconds or date string on the x0 axis. When `x0period` is round number of weeks, the `x0period0` by default would be on a Sunday i.e. 2000-01-02, otherwise it would be at 2000-01-01.</param>
    /// <param name="YPeriod">Only relevant when the axis `type` is "date". Sets the period positioning in milliseconds or "M&lt;n&gt;" on the y axis. Special values in the form of "M&lt;n&gt;" could be used to declare the number of months. In this case `n` must be a positive integer.</param>
    /// <param name="YPeriodAlignment">Only relevant when the axis `type` is "date". Sets the alignment of data points on the y axis.</param>
    /// <param name="YPeriod0">Only relevant when the axis `type` is "date". Sets the base for period positioning in milliseconds or date string on the y0 axis. When `y0period` is round number of weeks, the `y0period0` by default would be on a Sunday i.e. 2000-01-02, otherwise it would be at 2000-01-01.</param>
    /// <param name="TextFont">Sets the text font of this trace.</param>
    /// <param name="ColorBar">Sets the colorbar of this trace.</param>
    /// <param name="AutoColorScale">Determines whether the colorscale is a default palette (`autocolorscale: true`) or the palette determined by `colorscale`. In case `colorscale` is unspecified or `autocolorscale` is true, the default palette will be chosen according to whether numbers in the `color` array are all positive, all negative or mixed.</param>
    /// <param name="ColorScale">Sets the colorscale. The colorscale must be an array containing arrays mapping a normalized value to an rgb, rgba, hex, hsl, hsv, or named color string. At minimum, a mapping for the lowest (0) and highest (1) values are required. For example, `[[0, 'rgb(0,0,255)'], [1, 'rgb(255,0,0)']]`. To control the bounds of the colorscale in color space, use`zmin` and `zmax`. Alternatively, `colorscale` may be a palette name string of the following list: Blackbody,Bluered,Blues,Cividis,Earth,Electric,Greens,Greys,Hot,Jet,Picnic,Portland,Rainbow,RdBu,Reds,Viridis,YlGnBu,YlOrRd.</param>
    /// <param name="ShowScale">Determines whether or not a colorbar is displayed for this trace.</param>
    /// <param name="ReverseScale">Reverses the color mapping if true. If true, `zmin` will correspond to the last color in the array and `zmax` will correspond to the first color.</param>
    /// <param name="ZAuto">Determines whether or not the color domain is computed with respect to the input data (here in `z`) or the bounds set in `zmin` and `zmax` Defaults to `false` when `zmin` and `zmax` are set by the user.</param>
    /// <param name="ZHoverFormat">Sets the hover text formatting rulefor `z` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format.By default the values are formatted using generic number format.</param>
    /// <param name="ZMax">Sets the upper bound of the color domain. Value should have the same units as in `z` and if set, `zmin` must be set as well.</param>
    /// <param name="ZMid">Sets the mid-point of the color domain by scaling `zmin` and/or `zmax` to be equidistant to this point. Value should have the same units as in `z`. Has no effect when `zauto` is `false`.</param>
    /// <param name="ZMin">Sets the lower bound of the color domain. Value should have the same units as in `z` and if set, `zmax` must be set as well.</param>
    /// <param name="ZSmooth">Picks a smoothing algorithm use to smooth `z` data.</param>
    /// <param name="ConnectGaps">Determines whether or not gaps (i.e. {nan} or missing values) in the `z` data are filled in. It is defaulted to true if `z` is a one dimensional array and `zsmooth` is not false; otherwise it is defaulted to false.</param>
    /// <param name="HoverLabel">Sets the style of the hoverlabels of this trace.</param>
    /// <param name="HoverOnGaps">Determines whether or not gaps (i.e. {nan} or missing values) in the `z` data have hover labels associated with them.</param>
    /// <param name="Transpose">Transposes the z data.</param>
    /// <param name="XCalendar">Sets the calendar system to use with `x` date data.</param>
    /// <param name="YCalendar">Sets the calendar system to use with `y` date data.</param>
    /// <param name="UIRevision">Controls persistence of some user-driven changes to the trace: `constraintrange` in `parcoords` traces, as well as some `editable: true` modifications such as `name` and `colorbar.title`. Defaults to `layout.uirevision`. Note that other user-driven trace attribute changes are controlled by `layout` attributes: `trace.visible` is controlled by `layout.legend.uirevision`, `selectedpoints` is controlled by `layout.selectionrevision`, and `colorbar.(x|y)` (accessible with `config: {editable: true}`) is controlled by `layout.editrevision`. Trace changes are tracked by `uid`, which only falls back on trace index if no `uid` is provided. So if your app can add/remove traces before the end of the `data` array, such that the same trace has a different index, you can still preserve user-driven changes if you give each trace a `uid` that stays with it as it moves.</param>
    static member Heatmap
        (
            [<Optional; DefaultParameterValue(null)>] ?Name: string,
            [<Optional; DefaultParameterValue(null)>] ?Visible: StyleParam.Visible,
            [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
            [<Optional; DefaultParameterValue(null)>] ?Legend: StyleParam.SubPlotId,
            [<Optional; DefaultParameterValue(null)>] ?LegendRank: int,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroup: string,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroupTitle: Title,
            [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
            [<Optional; DefaultParameterValue(null)>] ?Ids: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?X: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?MultiX: seq<seq<#IConvertible>>,
            [<Optional; DefaultParameterValue(null)>] ?X0: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?DX: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?XType: StyleParam.CoordinateType,
            [<Optional; DefaultParameterValue(null)>] ?XGap: int,
            [<Optional; DefaultParameterValue(null)>] ?Y: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?MultiY: seq<seq<#IConvertible>>,
            [<Optional; DefaultParameterValue(null)>] ?Y0: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?DY: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?YType: StyleParam.CoordinateType,
            [<Optional; DefaultParameterValue(null)>] ?YGap: int,
            [<Optional; DefaultParameterValue(null)>] ?Z: seq<#seq<#IConvertible>>,
            [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?TextTemplate: string,
            [<Optional; DefaultParameterValue(null)>] ?HoverText: string,
            [<Optional; DefaultParameterValue(null)>] ?MultiHoverText: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?HoverInfo: StyleParam.HoverInfo,
            [<Optional; DefaultParameterValue(null)>] ?HoverTemplate: string,
            [<Optional; DefaultParameterValue(null)>] ?MultiHoverTemplate: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?XHoverFormat: string,
            [<Optional; DefaultParameterValue(null)>] ?YHoverFormat: string,
            [<Optional; DefaultParameterValue(null)>] ?Meta: string,
            [<Optional; DefaultParameterValue(null)>] ?CustomData: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?XAxis: StyleParam.LinearAxisId,
            [<Optional; DefaultParameterValue(null)>] ?YAxis: StyleParam.LinearAxisId,
            [<Optional; DefaultParameterValue(null)>] ?ColorAxis: StyleParam.SubPlotId,
            [<Optional; DefaultParameterValue(null)>] ?XPeriod: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?XPeriodAlignment: StyleParam.PeriodAlignment,
            [<Optional; DefaultParameterValue(null)>] ?XPeriod0: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?YPeriod: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?YPeriodAlignment: StyleParam.PeriodAlignment,
            [<Optional; DefaultParameterValue(null)>] ?YPeriod0: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?TextFont: Font,
            [<Optional; DefaultParameterValue(null)>] ?ColorBar: ColorBar,
            [<Optional; DefaultParameterValue(null)>] ?AutoColorScale: bool,
            [<Optional; DefaultParameterValue(null)>] ?ColorScale: StyleParam.Colorscale,
            [<Optional; DefaultParameterValue(null)>] ?ShowScale: bool,
            [<Optional; DefaultParameterValue(null)>] ?ReverseScale: bool,
            [<Optional; DefaultParameterValue(null)>] ?ZAuto: bool,
            [<Optional; DefaultParameterValue(null)>] ?ZHoverFormat: string,
            [<Optional; DefaultParameterValue(null)>] ?ZMax: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?ZMid: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?ZMin: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?ZSmooth: StyleParam.SmoothAlg,
            [<Optional; DefaultParameterValue(null)>] ?ConnectGaps: bool,
            [<Optional; DefaultParameterValue(null)>] ?HoverLabel: Hoverlabel,
            [<Optional; DefaultParameterValue(null)>] ?HoverOnGaps: bool,
            [<Optional; DefaultParameterValue(null)>] ?Transpose: bool,
            [<Optional; DefaultParameterValue(null)>] ?XCalendar: StyleParam.Calendar,
            [<Optional; DefaultParameterValue(null)>] ?YCalendar: StyleParam.Calendar,
            [<Optional; DefaultParameterValue(null)>] ?UIRevision: string
        ) =
        (fun (heatmap: ('T :> Trace)) ->

            Name |> DynObj.setOptionalProperty heatmap "name"
            Visible |> DynObj.setOptionalPropertyBy heatmap "visible" StyleParam.Visible.convert
            ShowLegend |> DynObj.setOptionalProperty heatmap "showlegend"
            Legend |> DynObj.setOptionalPropertyBy heatmap "legend" StyleParam.SubPlotId.convert
            LegendRank |> DynObj.setOptionalProperty heatmap "legendrank"
            LegendGroup |> DynObj.setOptionalProperty heatmap "legendgroup"
            LegendGroupTitle |> DynObj.setOptionalProperty heatmap "legendgrouptitle"
            Opacity |> DynObj.setOptionalProperty heatmap "opacity"
            Ids |> DynObj.setOptionalProperty heatmap "ids"
            (X, MultiX) |> DynObj.setOptionalSingleOrMultiProperty heatmap "x"
            X0 |> DynObj.setOptionalProperty heatmap "x0"
            DX |> DynObj.setOptionalProperty heatmap "dx"
            XType |> DynObj.setOptionalPropertyBy heatmap "xtype" StyleParam.CoordinateType.convert
            XGap |> DynObj.setOptionalProperty heatmap "xgap"
            (Y, MultiY) |> DynObj.setOptionalSingleOrMultiProperty heatmap "y"
            Y0 |> DynObj.setOptionalProperty heatmap "y0"
            DY |> DynObj.setOptionalProperty heatmap "dy"
            YType |> DynObj.setOptionalPropertyBy heatmap "ytype" StyleParam.CoordinateType.convert
            YGap |> DynObj.setOptionalProperty heatmap "ygap"
            Z |> DynObj.setOptionalProperty heatmap "z"
            (Text, MultiText) |> DynObj.setOptionalSingleOrMultiProperty heatmap "text"
            TextTemplate |> DynObj.setOptionalProperty heatmap "texttemplate"
            (HoverText, MultiHoverText) |> DynObj.setOptionalSingleOrMultiProperty heatmap "hovertext"
            HoverInfo |> DynObj.setOptionalPropertyBy heatmap "hoverinfo" StyleParam.HoverInfo.convert
            (HoverTemplate, MultiHoverTemplate) |> DynObj.setOptionalSingleOrMultiProperty heatmap "hovertemplate"
            XHoverFormat |> DynObj.setOptionalProperty heatmap "xhoverformat"
            YHoverFormat |> DynObj.setOptionalProperty heatmap "yhoverformat"
            Meta |> DynObj.setOptionalProperty heatmap "meta"
            CustomData |> DynObj.setOptionalProperty heatmap "customdata"
            XAxis |> DynObj.setOptionalPropertyBy heatmap "xaxis" StyleParam.LinearAxisId.convert
            YAxis |> DynObj.setOptionalPropertyBy heatmap "yaxis" StyleParam.LinearAxisId.convert
            ColorAxis |> DynObj.setOptionalPropertyBy heatmap "coloraxis" StyleParam.SubPlotId.convert
            XPeriod |> DynObj.setOptionalProperty heatmap "xperiod"
            XPeriodAlignment |> DynObj.setOptionalPropertyBy heatmap "xperiodalignment" StyleParam.PeriodAlignment.convert
            XPeriod0 |> DynObj.setOptionalProperty heatmap "xperiod0"
            YPeriod |> DynObj.setOptionalProperty heatmap "yperiod"
            YPeriodAlignment |> DynObj.setOptionalPropertyBy heatmap "yperiodalignment" StyleParam.PeriodAlignment.convert
            YPeriod0 |> DynObj.setOptionalProperty heatmap "yperiod0"
            TextFont |> DynObj.setOptionalProperty heatmap "textfont"
            ColorBar |> DynObj.setOptionalProperty heatmap "colorbar"
            AutoColorScale |> DynObj.setOptionalProperty heatmap "autocolorscale"
            ColorScale |> DynObj.setOptionalPropertyBy heatmap "colorscale" StyleParam.Colorscale.convert
            ShowScale |> DynObj.setOptionalProperty heatmap "showscale"
            ReverseScale |> DynObj.setOptionalProperty heatmap "reversescale"
            ZAuto |> DynObj.setOptionalProperty heatmap "zauto"
            ZHoverFormat |> DynObj.setOptionalProperty heatmap "zhoverformat"
            ZMax |> DynObj.setOptionalProperty heatmap "zmax"
            ZMid |> DynObj.setOptionalProperty heatmap "zmid"
            ZMin |> DynObj.setOptionalProperty heatmap "zmin"
            ZSmooth |> DynObj.setOptionalPropertyBy heatmap "zsmooth" StyleParam.SmoothAlg.convert
            ConnectGaps |> DynObj.setOptionalProperty heatmap "connectgaps"
            HoverLabel |> DynObj.setOptionalProperty heatmap "hoverlabel"
            HoverOnGaps |> DynObj.setOptionalProperty heatmap "hoverongaps"
            Transpose |> DynObj.setOptionalProperty heatmap "transpose"
            XCalendar |> DynObj.setOptionalPropertyBy heatmap "xcalendar" StyleParam.Calendar.convert
            YCalendar |> DynObj.setOptionalPropertyBy heatmap "ycalendar" StyleParam.Calendar.convert
            UIRevision |> DynObj.setOptionalProperty heatmap "uirevision"


            // out ->
            heatmap)

    /// <summary>
    /// Create a function that applies the styles of a Image plot to a Trace object
    /// </summary>
    /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
    /// <param name="Visible">Determines whether or not this trace is visible. If "legendonly", the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).</param>
    /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
    /// <param name="Legend">Sets the reference to a legend to show this trace in. References to these legends are "legend", "legend2", "legend3", etc. Settings for these legends are set in the layout, under `layout.legend`, `layout.legend2`, etc.</param>
    /// <param name="LegendRank">Sets the legend rank for this trace. Items and groups with smaller ranks are presented on top/left side while with `"reversed" `legend.traceorder` they are on bottom/right side. The default legendrank is 1000, so that you can use ranks less than 1000 to place certain items before all unranked items, and ranks greater than 1000 to go after all unranked items.</param>
    /// <param name="LegendGroup">Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling legend items.</param>
    /// <param name="LegendGroupTitle">Sets the legend group title for this trace.</param>
    /// <param name="Opacity">Sets the opacity of the trace.</param>
    /// <param name="Ids">Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.</param>
    /// <param name="X0">Set the image's x position.</param>
    /// <param name="DX">Set the pixel's horizontal size.</param>
    /// <param name="Y0">Set the image's y position.</param>
    /// <param name="DY">Set the pixel's vertical size</param>
    /// <param name="Z">A 2-dimensional array in which each element is an array of 3 or 4 numbers representing a color.</param>
    /// <param name="Source">Specifies the data URI of the image to be visualized. The URI consists of "data:image/[&lt;media subtype&gt;][;base64],&lt;data&gt;"</param>
    /// <param name="Text">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
    /// <param name="MultiText">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
    /// <param name="HoverText">Sets hover text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. To be seen, trace `hoverinfo` must contain a "text" flag.</param>
    /// <param name="MultiHoverText">Sets hover text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. To be seen, trace `hoverinfo` must contain a "text" flag.</param>
    /// <param name="HoverInfo">Determines which trace information appear on hover. If `none` or `skip` are set, no information is displayed upon hovering. But, if `none` is set, click and hover events are still fired.</param>
    /// <param name="HoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
    /// <param name="MultiHoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
    /// <param name="Meta">Assigns extra meta information associated with this trace that can be used in various text attributes. Attributes such as trace `name`, graph, axis and colorbar `title.text`, annotation `text` `rangeselector`, `updatemenues` and `sliders` `label` text all support `meta`. To access the trace `meta` values in an attribute in the same trace, simply use `%{meta[i]}` where `i` is the index or key of the `meta` item in question. To access trace `meta` in layout attributes, use `%{data[n[.meta[i]}` where `i` is the index or key of the `meta` and `n` is the trace index.</param>
    /// <param name="CustomData">Assigns extra data each datum. This may be useful when listening to hover, click and selection events. Note that, "scatter" traces also appends customdata items in the markers DOM elements</param>
    /// <param name="XAxis">Sets a reference between this trace's x coordinates and a 2D cartesian x axis. If "x" (the default value), the x coordinates refer to `layout.xaxis`. If "x2", the x coordinates refer to `layout.xaxis2`, and so on.</param>
    /// <param name="YAxis">Sets a reference between this trace's y coordinates and a 2D cartesian y axis. If "y" (the default value), the y coordinates refer to `layout.yaxis`. If "y2", the y coordinates refer to `layout.yaxis2`, and so on.</param>
    /// <param name="ColorModel">Color model used to map the numerical color components described in `z` into colors. If `source` is specified, this attribute will be set to `rgba256` otherwise it defaults to `rgb`.</param>
    /// <param name="ZMax">Sets the upper bound of the color domain. Value should have the same units as in `z` and if set, `zmin` must be set as well.</param>
    /// <param name="ZMin">Sets the lower bound of the color domain. Value should have the same units as in `z` and if set, `zmax` must be set as well.</param>
    /// <param name="ZSmooth">Picks a smoothing algorithm use to smooth `z` data.</param>
    /// <param name="HoverLabel">Sets the style of the hoverlabels of this trace.</param>
    /// <param name="UIRevision">Controls persistence of some user-driven changes to the trace: `constraintrange` in `parcoords` traces, as well as some `editable: true` modifications such as `name` and `colorbar.title`. Defaults to `layout.uirevision`. Note that other user-driven trace attribute changes are controlled by `layout` attributes: `trace.visible` is controlled by `layout.legend.uirevision`, `selectedpoints` is controlled by `layout.selectionrevision`, and `colorbar.(x|y)` (accessible with `config: {editable: true}`) is controlled by `layout.editrevision`. Trace changes are tracked by `uid`, which only falls back on trace index if no `uid` is provided. So if your app can add/remove traces before the end of the `data` array, such that the same trace has a different index, you can still preserve user-driven changes if you give each trace a `uid` that stays with it as it moves.</param>
    static member Image
        (
            [<Optional; DefaultParameterValue(null)>] ?Name: string,
            [<Optional; DefaultParameterValue(null)>] ?Visible: StyleParam.Visible,
            [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
            [<Optional; DefaultParameterValue(null)>] ?Legend: StyleParam.SubPlotId,
            [<Optional; DefaultParameterValue(null)>] ?LegendRank: int,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroup: string,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroupTitle: Title,
            [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
            [<Optional; DefaultParameterValue(null)>] ?Ids: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?X0: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?DX: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?Y0: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?DY: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?Z: #seq<#seq<#seq<int>>>,
            [<Optional; DefaultParameterValue(null)>] ?Source: string,
            [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?HoverText: string,
            [<Optional; DefaultParameterValue(null)>] ?MultiHoverText: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?HoverInfo: StyleParam.HoverInfo,
            [<Optional; DefaultParameterValue(null)>] ?HoverTemplate: string,
            [<Optional; DefaultParameterValue(null)>] ?MultiHoverTemplate: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?Meta: string,
            [<Optional; DefaultParameterValue(null)>] ?CustomData: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?XAxis: StyleParam.LinearAxisId,
            [<Optional; DefaultParameterValue(null)>] ?YAxis: StyleParam.LinearAxisId,
            [<Optional; DefaultParameterValue(null)>] ?ColorModel: StyleParam.ColorModel,
            [<Optional; DefaultParameterValue(null)>] ?ZMax: StyleParam.ColorComponentBound,
            [<Optional; DefaultParameterValue(null)>] ?ZMin: StyleParam.ColorComponentBound,
            [<Optional; DefaultParameterValue(null)>] ?ZSmooth: StyleParam.SmoothAlg,
            [<Optional; DefaultParameterValue(null)>] ?HoverLabel: Hoverlabel,
            [<Optional; DefaultParameterValue(null)>] ?UIRevision: string
        ) =
        (fun (image: ('T :> Trace)) ->

            Name |> DynObj.setOptionalProperty image "name"
            Visible |> DynObj.setOptionalPropertyBy image "visible" StyleParam.Visible.convert
            ShowLegend |> DynObj.setOptionalProperty image "showlegend"
            Legend |> DynObj.setOptionalPropertyBy image "legend" StyleParam.SubPlotId.convert
            LegendRank |> DynObj.setOptionalProperty image "legendrank"
            LegendGroup |> DynObj.setOptionalProperty image "legendgroup"
            LegendGroupTitle |> DynObj.setOptionalProperty image "legendgrouptitle"
            Opacity |> DynObj.setOptionalProperty image "opacity"
            Ids |> DynObj.setOptionalProperty image "ids"
            X0 |> DynObj.setOptionalProperty image "x0"
            DX |> DynObj.setOptionalProperty image "dx"
            Y0 |> DynObj.setOptionalProperty image "y0"
            DY |> DynObj.setOptionalProperty image "dy"
            Z |> DynObj.setOptionalProperty image "z"
            Source |> DynObj.setOptionalProperty image "source"
            (Text, MultiText) |> DynObj.setOptionalSingleOrMultiProperty image "text"
            (HoverText, MultiHoverText) |> DynObj.setOptionalSingleOrMultiProperty image "hovertext"
            HoverInfo |> DynObj.setOptionalPropertyBy image "hoverinfo" StyleParam.HoverInfo.convert
            (HoverTemplate, MultiHoverTemplate) |> DynObj.setOptionalSingleOrMultiProperty image "hovertemplate"
            Meta |> DynObj.setOptionalProperty image "meta"
            CustomData |> DynObj.setOptionalProperty image "customdata"
            XAxis |> DynObj.setOptionalPropertyBy image "xaxis" StyleParam.LinearAxisId.convert
            YAxis |> DynObj.setOptionalPropertyBy image "yaxis" StyleParam.LinearAxisId.convert
            ColorModel |> DynObj.setOptionalPropertyBy image "colormodel" StyleParam.ColorModel.convert
            ZMax |> DynObj.setOptionalPropertyBy image "zmax" StyleParam.ColorComponentBound.convert
            ZMin |> DynObj.setOptionalPropertyBy image "zmin" StyleParam.ColorComponentBound.convert
            ZSmooth |> DynObj.setOptionalPropertyBy image "zsmooth" StyleParam.SmoothAlg.convert
            HoverLabel |> DynObj.setOptionalProperty image "hoverlabel"
            UIRevision |> DynObj.setOptionalProperty image "uirevision"

            // out ->
            image)

    /// <summary>
    /// Create a function that applies the styles of a contour plot to a Trace object
    /// </summary>
    /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
    /// <param name="Visible">Determines whether or not this trace is visible. If "legendonly", the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).</param>
    /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
    /// <param name="Legend">Sets the reference to a legend to show this trace in. References to these legends are "legend", "legend2", "legend3", etc. Settings for these legends are set in the layout, under `layout.legend`, `layout.legend2`, etc.</param>
    /// <param name="LegendRank">Sets the legend rank for this trace. Items and groups with smaller ranks are presented on top/left side while with `"reversed" `legend.traceorder` they are on bottom/right side. The default legendrank is 1000, so that you can use ranks less than 1000 to place certain items before all unranked items, and ranks greater than 1000 to go after all unranked items.</param>
    /// <param name="LegendGroup">Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling legend items.</param>
    /// <param name="LegendGroupTitle">Sets the legend group title for this trace.</param>
    /// <param name="Opacity">Sets the opacity of the trace.</param>
    /// <param name="Ids">Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.</param>
    /// <param name="X">Sets the x coordinates.</param>
    /// <param name="MultiX">Sets the x coordinates.</param>
    /// <param name="X0">Alternate to `x`. Builds a linear space of x coordinates. Use with `dx` where `x0` is the starting coordinate and `dx` the step.</param>
    /// <param name="DX">Sets the x coordinate step. See `x0` for more info.</param>
    /// <param name="XType">If "array", the heatmap's x coordinates are given by "x" (the default behavior when `x` is provided). If "scaled", the heatmap's x coordinates are given by "x0" and "dx" (the default behavior when `x` is not provided).</param>
    /// <param name="Y">Sets the y coordinates.</param>
    /// <param name="MultiY">Sets the y coordinates.</param>
    /// <param name="Y0">Alternate to `y`. Builds a linear space of y coordinates. Use with `dy` where `y0` is the starting coordinate and `dy` the step.</param>
    /// <param name="DY">Sets the y coordinate step. See `y0` for more info.</param>
    /// <param name="YType">If "array", the heatmap's y coordinates are given by "y" (the default behavior when `y` is provided) If "scaled", the heatmap's y coordinates are given by "y0" and "dy" (the default behavior when `y` is not provided)</param>
    /// <param name="Z">Sets the z data.</param>
    /// <param name="Text">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
    /// <param name="MultiText">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
    /// <param name="TextTemplate">For this trace it only has an effect if `coloring` is set to "heatmap". Template string used for rendering the information text that appear on points. Note that this will override `textinfo`. Variables are inserted using %{variable}, for example "y: %{y}". Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. Every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available.</param>
    /// <param name="HoverText">Sets hover text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. To be seen, trace `hoverinfo` must contain a "text" flag.</param>
    /// <param name="MultiHoverText">Sets hover text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. To be seen, trace `hoverinfo` must contain a "text" flag.</param>
    /// <param name="HoverInfo">Determines which trace information appear on hover. If `none` or `skip` are set, no information is displayed upon hovering. But, if `none` is set, click and hover events are still fired.</param>
    /// <param name="HoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
    /// <param name="MultiHoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
    /// <param name="XHoverFormat">Sets the hover text formatting rulefor `x` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `xaxis.hoverformat`.</param>
    /// <param name="YHoverFormat">Sets the hover text formatting rulefor `y` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `xaxis.hoverformat`.</param>
    /// <param name="Meta">Assigns extra meta information associated with this trace that can be used in various text attributes. Attributes such as trace `name`, graph, axis and colorbar `title.text`, annotation `text` `rangeselector`, `updatemenues` and `sliders` `label` text all support `meta`. To access the trace `meta` values in an attribute in the same trace, simply use `%{meta[i]}` where `i` is the index or key of the `meta` item in question. To access trace `meta` in layout attributes, use `%{data[n[.meta[i]}` where `i` is the index or key of the `meta` and `n` is the trace index.</param>
    /// <param name="CustomData">Assigns extra data each datum. This may be useful when listening to hover, click and selection events. Note that, "scatter" traces also appends customdata items in the markers DOM elements</param>
    /// <param name="XAxis">Sets a reference between this trace's x coordinates and a 2D cartesian x axis. If "x" (the default value), the x coordinates refer to `layout.xaxis`. If "x2", the x coordinates refer to `layout.xaxis2`, and so on.</param>
    /// <param name="YAxis">Sets a reference between this trace's y coordinates and a 2D cartesian y axis. If "y" (the default value), the y coordinates refer to `layout.yaxis`. If "y2", the y coordinates refer to `layout.yaxis2`, and so on.</param>
    /// <param name="ColorAxis">Sets a reference to a shared color axis. References to these shared color axes are "coloraxis", "coloraxis2", "coloraxis3", etc. Settings for these shared color axes are set in the layout, under `layout.coloraxis`, `layout.coloraxis2`, etc. Note that multiple color scales can be linked to the same color axis.</param>
    /// <param name="XPeriod">Only relevant when the axis `type` is "date". Sets the period positioning in milliseconds or "M&lt;n&gt;" on the x axis. Special values in the form of "M&lt;n&gt;" could be used to declare the number of months. In this case `n` must be a positive integer.</param>
    /// <param name="XPeriodAlignment">Only relevant when the axis `type` is "date". Sets the alignment of data points on the x axis.</param>
    /// <param name="XPeriod0">Only relevant when the axis `type` is "date". Sets the base for period positioning in milliseconds or date string on the x0 axis. When `x0period` is round number of weeks, the `x0period0` by default would be on a Sunday i.e. 2000-01-02, otherwise it would be at 2000-01-01.</param>
    /// <param name="YPeriod">Only relevant when the axis `type` is "date". Sets the period positioning in milliseconds or "M&lt;n&gt;" on the y axis. Special values in the form of "M&lt;n&gt;" could be used to declare the number of months. In this case `n` must be a positive integer.</param>
    /// <param name="YPeriodAlignment">Only relevant when the axis `type` is "date". Sets the alignment of data points on the y axis.</param>
    /// <param name="YPeriod0">Only relevant when the axis `type` is "date". Sets the base for period positioning in milliseconds or date string on the y0 axis. When `y0period` is round number of weeks, the `y0period0` by default would be on a Sunday i.e. 2000-01-02, otherwise it would be at 2000-01-01.</param>
    /// <param name="Line">Sets the line of this trace.</param>
    /// <param name="TextFont">For this trace it only has an effect if `coloring` is set to "heatmap". Sets the text font of this trace.</param>
    /// <param name="ColorBar">Sets the colorbar of this trace.</param>
    /// <param name="AutoColorScale">Determines whether the colorscale is a default palette (`autocolorscale: true`) or the palette determined by `colorscale`. In case `colorscale` is unspecified or `autocolorscale` is true, the default palette will be chosen according to whether numbers in the `color` array are all positive, all negative or mixed.</param>
    /// <param name="ColorScale">Sets the colorscale. The colorscale must be an array containing arrays mapping a normalized value to an rgb, rgba, hex, hsl, hsv, or named color string. At minimum, a mapping for the lowest (0) and highest (1) values are required. For example, `[[0, 'rgb(0,0,255)'], [1, 'rgb(255,0,0)']]`. To control the bounds of the colorscale in color space, use`zmin` and `zmax`. Alternatively, `colorscale` may be a palette name string of the following list: Blackbody,Bluered,Blues,Cividis,Earth,Electric,Greens,Greys,Hot,Jet,Picnic,Portland,Rainbow,RdBu,Reds,Viridis,YlGnBu,YlOrRd.</param>
    /// <param name="ShowScale">Determines whether or not a colorbar is displayed for this trace.</param>
    /// <param name="ReverseScale">Reverses the color mapping if true. If true, `zmin` will correspond to the last color in the array and `zmax` will correspond to the first color.</param>
    /// <param name="ZAuto">Determines whether or not the color domain is computed with respect to the input data (here in `z`) or the bounds set in `zmin` and `zmax` Defaults to `false` when `zmin` and `zmax` are set by the user.</param>
    /// <param name="ZHoverFormat">Sets the hover text formatting rulefor `z` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format.By default the values are formatted using generic number format.</param>
    /// <param name="ZMax">Sets the upper bound of the color domain. Value should have the same units as in `z` and if set, `zmin` must be set as well.</param>
    /// <param name="ZMid">Sets the mid-point of the color domain by scaling `zmin` and/or `zmax` to be equidistant to this point. Value should have the same units as in `z`. Has no effect when `zauto` is `false`.</param>
    /// <param name="ZMin">Sets the lower bound of the color domain. Value should have the same units as in `z` and if set, `zmax` must be set as well.</param>
    /// <param name="AutoContour">Determines whether or not the contour level attributes are picked by an algorithm. If "true", the number of contour levels can be set in `ncontours`. If "false", set the contour level attributes in `contours`.</param>
    /// <param name="ConnectGaps">Determines whether or not gaps (i.e. {nan} or missing values) in the `z` data are filled in. It is defaulted to true if `z` is a one dimensional array otherwise it is defaulted to false.</param>
    /// <param name="Contours">Sets the contours of this trace.</param>
    /// <param name="FillColor">Sets the fill color if `contours.type` is "constraint". Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
    /// <param name="HoverLabel">Sets the style of the hoverlabels of this trace.</param>
    /// <param name="HoverOnGaps">Determines whether or not gaps (i.e. {nan} or missing values) in the `z` data have hover labels associated with them.</param>
    /// <param name="NContours">Sets the maximum number of contour levels. The actual number of contours will be chosen automatically to be less than or equal to the value of `ncontours`. Has an effect only if `autocontour` is "true" or if `contours.size` is missing.</param>
    /// <param name="Transpose">Transposes the z data.</param>
    /// <param name="XCalendar">Sets the calendar system to use with `x` date data.</param>
    /// <param name="YCalendar">Sets the calendar system to use with `y` date data.</param>
    /// <param name="UIRevision">Controls persistence of some user-driven changes to the trace: `constraintrange` in `parcoords` traces, as well as some `editable: true` modifications such as `name` and `colorbar.title`. Defaults to `layout.uirevision`. Note that other user-driven trace attribute changes are controlled by `layout` attributes: `trace.visible` is controlled by `layout.legend.uirevision`, `selectedpoints` is controlled by `layout.selectionrevision`, and `colorbar.(x|y)` (accessible with `config: {editable: true}`) is controlled by `layout.editrevision`. Trace changes are tracked by `uid`, which only falls back on trace index if no `uid` is provided. So if your app can add/remove traces before the end of the `data` array, such that the same trace has a different index, you can still preserve user-driven changes if you give each trace a `uid` that stays with it as it moves.</param>
    static member Contour
        (
            [<Optional; DefaultParameterValue(null)>] ?Name: string,
            [<Optional; DefaultParameterValue(null)>] ?Visible: StyleParam.Visible,
            [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
            [<Optional; DefaultParameterValue(null)>] ?Legend: StyleParam.SubPlotId,
            [<Optional; DefaultParameterValue(null)>] ?LegendRank: int,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroup: string,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroupTitle: Title,
            [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
            [<Optional; DefaultParameterValue(null)>] ?Ids: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?X: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?MultiX: seq<seq<#IConvertible>>,
            [<Optional; DefaultParameterValue(null)>] ?X0: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?DX: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?XType: StyleParam.CoordinateType,
            [<Optional; DefaultParameterValue(null)>] ?Y: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?MultiY: seq<seq<#IConvertible>>,
            [<Optional; DefaultParameterValue(null)>] ?Y0: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?DY: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?YType: StyleParam.CoordinateType,
            [<Optional; DefaultParameterValue(null)>] ?Z: seq<#seq<#IConvertible>>,
            [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?TextTemplate: string,
            [<Optional; DefaultParameterValue(null)>] ?HoverText: string,
            [<Optional; DefaultParameterValue(null)>] ?MultiHoverText: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?HoverInfo: StyleParam.HoverInfo,
            [<Optional; DefaultParameterValue(null)>] ?HoverTemplate: string,
            [<Optional; DefaultParameterValue(null)>] ?MultiHoverTemplate: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?XHoverFormat: string,
            [<Optional; DefaultParameterValue(null)>] ?YHoverFormat: string,
            [<Optional; DefaultParameterValue(null)>] ?Meta: string,
            [<Optional; DefaultParameterValue(null)>] ?CustomData: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?XAxis: StyleParam.LinearAxisId,
            [<Optional; DefaultParameterValue(null)>] ?YAxis: StyleParam.LinearAxisId,
            [<Optional; DefaultParameterValue(null)>] ?ColorAxis: StyleParam.SubPlotId,
            [<Optional; DefaultParameterValue(null)>] ?XPeriod: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?XPeriodAlignment: StyleParam.PeriodAlignment,
            [<Optional; DefaultParameterValue(null)>] ?XPeriod0: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?YPeriod: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?YPeriodAlignment: StyleParam.PeriodAlignment,
            [<Optional; DefaultParameterValue(null)>] ?YPeriod0: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?Line: Line,
            [<Optional; DefaultParameterValue(null)>] ?TextFont: Font,
            [<Optional; DefaultParameterValue(null)>] ?ColorBar: ColorBar,
            [<Optional; DefaultParameterValue(null)>] ?AutoColorScale: bool,
            [<Optional; DefaultParameterValue(null)>] ?ColorScale: StyleParam.Colorscale,
            [<Optional; DefaultParameterValue(null)>] ?ShowScale: bool,
            [<Optional; DefaultParameterValue(null)>] ?ReverseScale: bool,
            [<Optional; DefaultParameterValue(null)>] ?ZAuto: bool,
            [<Optional; DefaultParameterValue(null)>] ?ZHoverFormat: string,
            [<Optional; DefaultParameterValue(null)>] ?ZMax: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?ZMid: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?ZMin: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?AutoContour: bool,
            [<Optional; DefaultParameterValue(null)>] ?ConnectGaps: bool,
            [<Optional; DefaultParameterValue(null)>] ?Contours: Contours,
            [<Optional; DefaultParameterValue(null)>] ?FillColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?HoverLabel: Hoverlabel,
            [<Optional; DefaultParameterValue(null)>] ?HoverOnGaps: bool,
            [<Optional; DefaultParameterValue(null)>] ?NContours: int,
            [<Optional; DefaultParameterValue(null)>] ?Transpose: bool,
            [<Optional; DefaultParameterValue(null)>] ?XCalendar: StyleParam.Calendar,
            [<Optional; DefaultParameterValue(null)>] ?YCalendar: StyleParam.Calendar,
            [<Optional; DefaultParameterValue(null)>] ?UIRevision: string
        ) =
        (fun (contour: ('T :> Trace)) ->

            Name |> DynObj.setOptionalProperty contour "name"
            Visible |> DynObj.setOptionalPropertyBy contour "visible" StyleParam.Visible.convert
            ShowLegend |> DynObj.setOptionalProperty contour "showlegend"
            Legend |> DynObj.setOptionalPropertyBy contour "legend" StyleParam.SubPlotId.convert
            LegendRank |> DynObj.setOptionalProperty contour "legendrank"
            LegendGroup |> DynObj.setOptionalProperty contour "legendgroup"
            LegendGroupTitle |> DynObj.setOptionalProperty contour "legendgrouptitle"
            Opacity |> DynObj.setOptionalProperty contour "opacity"
            Ids |> DynObj.setOptionalProperty contour "ids"
            (X, MultiX) |> DynObj.setOptionalSingleOrMultiProperty contour "x"
            X0 |> DynObj.setOptionalProperty contour "x0"
            DX |> DynObj.setOptionalProperty contour "dx"
            XType |> DynObj.setOptionalPropertyBy contour "xtype" StyleParam.CoordinateType.convert
            (Y, MultiY) |> DynObj.setOptionalSingleOrMultiProperty contour "y"
            Y0 |> DynObj.setOptionalProperty contour "y0"
            DY |> DynObj.setOptionalProperty contour "dy"
            YType |> DynObj.setOptionalPropertyBy contour "ytype" StyleParam.CoordinateType.convert
            Z |> DynObj.setOptionalProperty contour "z"
            TextTemplate |> DynObj.setOptionalProperty contour "texttemplate"
            (Text, MultiText) |> DynObj.setOptionalSingleOrMultiProperty contour "text"
            (HoverText, MultiHoverText) |> DynObj.setOptionalSingleOrMultiProperty contour "hovertext"
            HoverInfo |> DynObj.setOptionalPropertyBy contour "hoverinfo" StyleParam.HoverInfo.convert
            (HoverTemplate, MultiHoverTemplate) |> DynObj.setOptionalSingleOrMultiProperty contour "hovertemplate"
            XHoverFormat |> DynObj.setOptionalProperty contour "xhoverformat"
            YHoverFormat |> DynObj.setOptionalProperty contour "yhoverformat"
            Meta |> DynObj.setOptionalProperty contour "meta"
            CustomData |> DynObj.setOptionalProperty contour "customdata"
            XAxis |> DynObj.setOptionalPropertyBy contour "xaxis" StyleParam.LinearAxisId.convert
            YAxis |> DynObj.setOptionalPropertyBy contour "yaxis" StyleParam.LinearAxisId.convert
            ColorAxis |> DynObj.setOptionalPropertyBy contour "coloraxis" StyleParam.SubPlotId.convert
            XPeriod |> DynObj.setOptionalProperty contour "xperiod"
            XPeriodAlignment |> DynObj.setOptionalPropertyBy contour "xperiodalignment" StyleParam.PeriodAlignment.convert
            XPeriod0 |> DynObj.setOptionalProperty contour "xperiod0"
            YPeriod |> DynObj.setOptionalProperty contour "yperiod"
            YPeriodAlignment |> DynObj.setOptionalPropertyBy contour "yperiodalignment" StyleParam.PeriodAlignment.convert
            YPeriod0 |> DynObj.setOptionalProperty contour "yperiod0"
            Line |> DynObj.setOptionalProperty contour "line"
            TextFont |> DynObj.setOptionalProperty contour "textfont"
            ColorBar |> DynObj.setOptionalProperty contour "colorbar"
            AutoColorScale |> DynObj.setOptionalProperty contour "autocolorscale"
            ColorScale |> DynObj.setOptionalPropertyBy contour "colorscale" StyleParam.Colorscale.convert
            ShowScale |> DynObj.setOptionalProperty contour "showscale"
            ReverseScale |> DynObj.setOptionalProperty contour "reversescale"
            ZAuto |> DynObj.setOptionalProperty contour "zauto"
            ZHoverFormat |> DynObj.setOptionalProperty contour "zhoverformat"
            ZMax |> DynObj.setOptionalProperty contour "zmax"
            ZMid |> DynObj.setOptionalProperty contour "zmid"
            ZMin |> DynObj.setOptionalProperty contour "zmin"
            AutoContour |> DynObj.setOptionalProperty contour "autocontour"
            ConnectGaps |> DynObj.setOptionalProperty contour "connectgaps"
            Contours |> DynObj.setOptionalProperty contour "contours"
            FillColor |> DynObj.setOptionalProperty contour "fillcolor"
            HoverLabel |> DynObj.setOptionalProperty contour "hoverlabel"
            HoverOnGaps |> DynObj.setOptionalProperty contour "hoverongaps"
            NContours |> DynObj.setOptionalProperty contour "ncontours"
            Transpose |> DynObj.setOptionalProperty contour "transpose"
            XCalendar |> DynObj.setOptionalPropertyBy contour "xcalendar" StyleParam.Calendar.convert
            UIRevision |> DynObj.setOptionalProperty contour "uirevision"


            // out ->
            contour)


    /// <summary>
    /// Create a function that applies the styles of a OHLC plot to a Trace object
    /// </summary>
    /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
    /// <param name="Visible">Determines whether or not this trace is visible. If "legendonly", the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).</param>
    /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
    /// <param name="Legend">Sets the reference to a legend to show this trace in. References to these legends are "legend", "legend2", "legend3", etc. Settings for these legends are set in the layout, under `layout.legend`, `layout.legend2`, etc.</param>
    /// <param name="LegendRank">Sets the legend rank for this trace. Items and groups with smaller ranks are presented on top/left side while with `"reversed" `legend.traceorder` they are on bottom/right side. The default legendrank is 1000, so that you can use ranks less than 1000 to place certain items before all unranked items, and ranks greater than 1000 to go after all unranked items.</param>
    /// <param name="LegendGroup">Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling legend items.</param>
    /// <param name="LegendGroupTitle">Sets the legend group title for this trace.</param>
    /// <param name="Opacity">Sets the opacity of the trace.</param>
    /// <param name="Ids">Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.</param>
    /// <param name="X">Sets the x coordinates.</param>
    /// <param name="MultiX">Sets the x coordinates.</param>
    /// <param name="Close">Sets the close values.</param>
    /// <param name="Open">Sets the open values.</param>
    /// <param name="High">Sets the high values.</param>
    /// <param name="Low">Sets the low values.</param>
    /// <param name="Text">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
    /// <param name="MultiText">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
    /// <param name="HoverText">Sets hover text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. To be seen, trace `hoverinfo` must contain a "text" flag.</param>
    /// <param name="MultiHoverText">Sets hover text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. To be seen, trace `hoverinfo` must contain a "text" flag.</param>
    /// <param name="HoverInfo">Determines which trace information appear on hover. If `none` or `skip` are set, no information is displayed upon hovering. But, if `none` is set, click and hover events are still fired.</param>
    /// <param name="XHoverFormat">Sets the hover text formatting rulefor `x` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `xaxis.hoverformat`.</param>
    /// <param name="YHoverFormat">Sets the hover text formatting rulefor `y` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `xaxis.hoverformat`.</param>
    /// <param name="Meta">Assigns extra meta information associated with this trace that can be used in various text attributes. Attributes such as trace `name`, graph, axis and colorbar `title.text`, annotation `text` `rangeselector`, `updatemenues` and `sliders` `label` text all support `meta`. To access the trace `meta` values in an attribute in the same trace, simply use `%{meta[i]}` where `i` is the index or key of the `meta` item in question. To access trace `meta` in layout attributes, use `%{data[n[.meta[i]}` where `i` is the index or key of the `meta` and `n` is the trace index.</param>
    /// <param name="CustomData">Assigns extra data each datum. This may be useful when listening to hover, click and selection events. Note that, "scatter" traces also appends customdata items in the markers DOM elements</param>
    /// <param name="XAxis">Sets a reference between this trace's x coordinates and a 2D cartesian x axis. If "x" (the default value), the x coordinates refer to `layout.xaxis`. If "x2", the x coordinates refer to `layout.xaxis2`, and so on.</param>
    /// <param name="YAxis">Sets a reference between this trace's y coordinates and a 2D cartesian y axis. If "y" (the default value), the y coordinates refer to `layout.yaxis`. If "y2", the y coordinates refer to `layout.yaxis2`, and so on.</param>
    /// <param name="XPeriod">Only relevant when the axis `type` is "date". Sets the period positioning in milliseconds or "M&lt;n&gt;" on the x axis. Special values in the form of "M&lt;n&gt;" could be used to declare the number of months. In this case `n` must be a positive integer.</param>
    /// <param name="XPeriodAlignment">Only relevant when the axis `type` is "date". Sets the alignment of data points on the x axis.</param>
    /// <param name="XPeriod0">Only relevant when the axis `type` is "date". Sets the base for period positioning in milliseconds or date string on the x0 axis. When `x0period` is round number of weeks, the `x0period0` by default would be on a Sunday i.e. 2000-01-02, otherwise it would be at 2000-01-01.</param>
    /// <param name="YPeriod">Only relevant when the axis `type` is "date". Sets the period positioning in milliseconds or "M&lt;n&gt;" on the y axis. Special values in the form of "M&lt;n&gt;" could be used to declare the number of months. In this case `n` must be a positive integer.</param>
    /// <param name="YPeriodAlignment">Only relevant when the axis `type` is "date". Sets the alignment of data points on the y axis.</param>
    /// <param name="YPeriod0">Only relevant when the axis `type` is "date". Sets the base for period positioning in milliseconds or date string on the y0 axis. When `y0period` is round number of weeks, the `y0period0` by default would be on a Sunday i.e. 2000-01-02, otherwise it would be at 2000-01-01.</param>
    /// <param name="Line">Sets the line of this trace.</param>
    /// <param name="SelectedPoints">Array containing integer indices of selected points. Has an effect only for traces that support selections. Note that an empty array means an empty selection where the `unselected` are turned on for all points, whereas, any other non-array values means no selection all where the `selected` and `unselected` styles have no effect.</param>
    /// <param name="Increasing">Sets the styles for increasing candles</param>
    /// <param name="Decreasing">Sets the styles for decreasing candles</param>
    /// <param name="HoverLabel">Sets the style of the hoverlabels of this trace.</param>
    /// <param name="TickWidth">Sets the width of the open/close tick marks relative to the "x" minimal interval.</param>
    /// <param name="XCalendar">Sets the calendar system to use with `x` date data.</param>
    /// <param name="UIRevision">Controls persistence of some user-driven changes to the trace: `constraintrange` in `parcoords` traces, as well as some `editable: true` modifications such as `name` and `colorbar.title`. Defaults to `layout.uirevision`. Note that other user-driven trace attribute changes are controlled by `layout` attributes: `trace.visible` is controlled by `layout.legend.uirevision`, `selectedpoints` is controlled by `layout.selectionrevision`, and `colorbar.(x|y)` (accessible with `config: {editable: true}`) is controlled by `layout.editrevision`. Trace changes are tracked by `uid`, which only falls back on trace index if no `uid` is provided. So if your app can add/remove traces before the end of the `data` array, such that the same trace has a different index, you can still preserve user-driven changes if you give each trace a `uid` that stays with it as it moves.</param>
    static member OHLC
        (
            [<Optional; DefaultParameterValue(null)>] ?Name: string,
            [<Optional; DefaultParameterValue(null)>] ?Visible: StyleParam.Visible,
            [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
            [<Optional; DefaultParameterValue(null)>] ?Legend: StyleParam.SubPlotId,
            [<Optional; DefaultParameterValue(null)>] ?LegendRank: int,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroup: string,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroupTitle: Title,
            [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
            [<Optional; DefaultParameterValue(null)>] ?Ids: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?X: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?MultiX: seq<seq<#IConvertible>>,
            [<Optional; DefaultParameterValue(null)>] ?Close: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Open: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?High: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Low: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?HoverText: string,
            [<Optional; DefaultParameterValue(null)>] ?MultiHoverText: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?HoverInfo: StyleParam.HoverInfo,
            [<Optional; DefaultParameterValue(null)>] ?XHoverFormat: string,
            [<Optional; DefaultParameterValue(null)>] ?YHoverFormat: string,
            [<Optional; DefaultParameterValue(null)>] ?Meta: string,
            [<Optional; DefaultParameterValue(null)>] ?CustomData: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?XAxis: StyleParam.LinearAxisId,
            [<Optional; DefaultParameterValue(null)>] ?YAxis: StyleParam.LinearAxisId,
            [<Optional; DefaultParameterValue(null)>] ?XPeriod: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?XPeriodAlignment: StyleParam.PeriodAlignment,
            [<Optional; DefaultParameterValue(null)>] ?XPeriod0: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?YPeriod: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?YPeriodAlignment: StyleParam.PeriodAlignment,
            [<Optional; DefaultParameterValue(null)>] ?YPeriod0: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?Line: Line,
            [<Optional; DefaultParameterValue(null)>] ?SelectedPoints: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Increasing: FinanceMarker,
            [<Optional; DefaultParameterValue(null)>] ?Decreasing: FinanceMarker,
            [<Optional; DefaultParameterValue(null)>] ?HoverLabel: Hoverlabel,
            [<Optional; DefaultParameterValue(null)>] ?TickWidth: float,
            [<Optional; DefaultParameterValue(null)>] ?XCalendar: StyleParam.Calendar,
            [<Optional; DefaultParameterValue(null)>] ?UIRevision: string
        ) =
        (fun (ohlc: ('T :> Trace)) ->

            Name |> DynObj.setOptionalProperty ohlc "name"
            Visible |> DynObj.setOptionalPropertyBy ohlc "visible" StyleParam.Visible.convert
            ShowLegend |> DynObj.setOptionalProperty ohlc "showlegend"
            Legend |> DynObj.setOptionalPropertyBy ohlc "legend" StyleParam.SubPlotId.convert
            LegendRank |> DynObj.setOptionalProperty ohlc "legendrank"
            LegendGroup |> DynObj.setOptionalProperty ohlc "legendgroup"
            LegendGroupTitle |> DynObj.setOptionalProperty ohlc "legendgrouptitle"
            Opacity |> DynObj.setOptionalProperty ohlc "opacity"
            Ids |> DynObj.setOptionalProperty ohlc "ids"
            (X, MultiX) |> DynObj.setOptionalSingleOrMultiProperty ohlc "x"
            Close |> DynObj.setOptionalProperty ohlc "close"
            Open |> DynObj.setOptionalProperty ohlc "open"
            High |> DynObj.setOptionalProperty ohlc "high"
            Low |> DynObj.setOptionalProperty ohlc "low"
            (Text, MultiText) |> DynObj.setOptionalSingleOrMultiProperty ohlc "text"
            (HoverText, MultiHoverText) |> DynObj.setOptionalSingleOrMultiProperty ohlc "hovertext"
            HoverInfo |> DynObj.setOptionalPropertyBy ohlc "hoverinfo" StyleParam.HoverInfo.convert
            XHoverFormat |> DynObj.setOptionalProperty ohlc "xhoverformat"
            YHoverFormat |> DynObj.setOptionalProperty ohlc "yhoverformat"
            Meta |> DynObj.setOptionalProperty ohlc "meta"
            CustomData |> DynObj.setOptionalProperty ohlc "customdata"
            XAxis |> DynObj.setOptionalPropertyBy ohlc "xaxis" StyleParam.LinearAxisId.convert
            YAxis |> DynObj.setOptionalPropertyBy ohlc "yaxis" StyleParam.LinearAxisId.convert
            XPeriod |> DynObj.setOptionalProperty ohlc "xperiod"
            XPeriodAlignment |> DynObj.setOptionalPropertyBy ohlc "xperiodalignment" StyleParam.PeriodAlignment.convert
            XPeriod0 |> DynObj.setOptionalProperty ohlc "xperiod0"
            YPeriod |> DynObj.setOptionalProperty ohlc "yperiod"
            YPeriodAlignment |> DynObj.setOptionalPropertyBy ohlc "yperiodalignment" StyleParam.PeriodAlignment.convert
            YPeriod0 |> DynObj.setOptionalProperty ohlc "yperiod0"
            Line |> DynObj.setOptionalProperty ohlc "line"
            Increasing |> DynObj.setOptionalProperty ohlc "increasing"
            Decreasing |> DynObj.setOptionalProperty ohlc "decreasing"
            HoverLabel |> DynObj.setOptionalProperty ohlc "hoverlabel"
            TickWidth |> DynObj.setOptionalProperty ohlc "tickwidth"
            XCalendar |> DynObj.setOptionalPropertyBy ohlc "xcalendar" StyleParam.Calendar.convert
            UIRevision |> DynObj.setOptionalProperty ohlc "uirevision"

            ohlc)


    /// <summary>
    /// Create a function that applies the styles of a candlestick plot to a Trace object
    /// </summary>
    /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
    /// <param name="Visible">Determines whether or not this trace is visible. If "legendonly", the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).</param>
    /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
    /// <param name="Legend">Sets the reference to a legend to show this trace in. References to these legends are "legend", "legend2", "legend3", etc. Settings for these legends are set in the layout, under `layout.legend`, `layout.legend2`, etc.</param>
    /// <param name="LegendRank">Sets the legend rank for this trace. Items and groups with smaller ranks are presented on top/left side while with `"reversed" `legend.traceorder` they are on bottom/right side. The default legendrank is 1000, so that you can use ranks less than 1000 to place certain items before all unranked items, and ranks greater than 1000 to go after all unranked items.</param>
    /// <param name="LegendGroup">Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling legend items.</param>
    /// <param name="LegendGroupTitle">Sets the legend group title for this trace.</param>
    /// <param name="Opacity">Sets the opacity of the trace.</param>
    /// <param name="Ids">Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.</param>
    /// <param name="X">Sets the x coordinates.</param>
    /// <param name="MultiX">Sets the x coordinates.</param>
    /// <param name="Close">Sets the close values.</param>
    /// <param name="Open">Sets the open values.</param>
    /// <param name="High">Sets the high values.</param>
    /// <param name="Low">Sets the low values.</param>
    /// <param name="Text">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
    /// <param name="MultiText">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
    /// <param name="HoverText">Sets hover text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. To be seen, trace `hoverinfo` must contain a "text" flag.</param>
    /// <param name="MultiHoverText">Sets hover text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. To be seen, trace `hoverinfo` must contain a "text" flag.</param>
    /// <param name="HoverInfo">Determines which trace information appear on hover. If `none` or `skip` are set, no information is displayed upon hovering. But, if `none` is set, click and hover events are still fired.</param>
    /// <param name="XHoverFormat">Sets the hover text formatting rulefor `x` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `xaxis.hoverformat`.</param>
    /// <param name="YHoverFormat">Sets the hover text formatting rulefor `y` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `xaxis.hoverformat`.</param>
    /// <param name="Meta">Assigns extra meta information associated with this trace that can be used in various text attributes. Attributes such as trace `name`, graph, axis and colorbar `title.text`, annotation `text` `rangeselector`, `updatemenues` and `sliders` `label` text all support `meta`. To access the trace `meta` values in an attribute in the same trace, simply use `%{meta[i]}` where `i` is the index or key of the `meta` item in question. To access trace `meta` in layout attributes, use `%{data[n[.meta[i]}` where `i` is the index or key of the `meta` and `n` is the trace index.</param>
    /// <param name="CustomData">Assigns extra data each datum. This may be useful when listening to hover, click and selection events. Note that, "scatter" traces also appends customdata items in the markers DOM elements</param>
    /// <param name="XAxis">Sets a reference between this trace's x coordinates and a 2D cartesian x axis. If "x" (the default value), the x coordinates refer to `layout.xaxis`. If "x2", the x coordinates refer to `layout.xaxis2`, and so on.</param>
    /// <param name="YAxis">Sets a reference between this trace's y coordinates and a 2D cartesian y axis. If "y" (the default value), the y coordinates refer to `layout.yaxis`. If "y2", the y coordinates refer to `layout.yaxis2`, and so on.</param>
    /// <param name="XPeriod">Only relevant when the axis `type` is "date". Sets the period positioning in milliseconds or "M&lt;n&gt;" on the x axis. Special values in the form of "M&lt;n&gt;" could be used to declare the number of months. In this case `n` must be a positive integer.</param>
    /// <param name="XPeriodAlignment">Only relevant when the axis `type` is "date". Sets the alignment of data points on the x axis.</param>
    /// <param name="XPeriod0">Only relevant when the axis `type` is "date". Sets the base for period positioning in milliseconds or date string on the x0 axis. When `x0period` is round number of weeks, the `x0period0` by default would be on a Sunday i.e. 2000-01-02, otherwise it would be at 2000-01-01.</param>
    /// <param name="YPeriod">Only relevant when the axis `type` is "date". Sets the period positioning in milliseconds or "M&lt;n&gt;" on the y axis. Special values in the form of "M&lt;n&gt;" could be used to declare the number of months. In this case `n` must be a positive integer.</param>
    /// <param name="YPeriodAlignment">Only relevant when the axis `type` is "date". Sets the alignment of data points on the y axis.</param>
    /// <param name="YPeriod0">Only relevant when the axis `type` is "date". Sets the base for period positioning in milliseconds or date string on the y0 axis. When `y0period` is round number of weeks, the `y0period0` by default would be on a Sunday i.e. 2000-01-02, otherwise it would be at 2000-01-01.</param>
    /// <param name="Line">Sets the line of this trace.</param>
    /// <param name="WhiskerWidth">Sets the width of the whiskers relative to the box' width. For example, with 1, the whiskers are as wide as the box(es).</param>
    /// <param name="SelectedPoints">Array containing integer indices of selected points. Has an effect only for traces that support selections. Note that an empty array means an empty selection where the `unselected` are turned on for all points, whereas, any other non-array values means no selection all where the `selected` and `unselected` styles have no effect.</param>
    /// <param name="Increasing">Sets the styles for increasing candles</param>
    /// <param name="Decreasing">Sets the styles for decreasing candles</param>
    /// <param name="HoverLabel">Sets the style of the hoverlabels of this trace.</param>
    /// <param name="XCalendar">Sets the calendar system to use with `x` date data.</param>
    /// <param name="UIRevision">Controls persistence of some user-driven changes to the trace: `constraintrange` in `parcoords` traces, as well as some `editable: true` modifications such as `name` and `colorbar.title`. Defaults to `layout.uirevision`. Note that other user-driven trace attribute changes are controlled by `layout` attributes: `trace.visible` is controlled by `layout.legend.uirevision`, `selectedpoints` is controlled by `layout.selectionrevision`, and `colorbar.(x|y)` (accessible with `config: {editable: true}`) is controlled by `layout.editrevision`. Trace changes are tracked by `uid`, which only falls back on trace index if no `uid` is provided. So if your app can add/remove traces before the end of the `data` array, such that the same trace has a different index, you can still preserve user-driven changes if you give each trace a `uid` that stays with it as it moves.</param>
    static member Candlestick
        (
            [<Optional; DefaultParameterValue(null)>] ?Name: string,
            [<Optional; DefaultParameterValue(null)>] ?Visible: StyleParam.Visible,
            [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
            [<Optional; DefaultParameterValue(null)>] ?Legend: StyleParam.SubPlotId,
            [<Optional; DefaultParameterValue(null)>] ?LegendRank: int,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroup: string,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroupTitle: Title,
            [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
            [<Optional; DefaultParameterValue(null)>] ?Ids: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?X: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?MultiX: seq<seq<#IConvertible>>,
            [<Optional; DefaultParameterValue(null)>] ?Close: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Open: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?High: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Low: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?HoverText: string,
            [<Optional; DefaultParameterValue(null)>] ?MultiHoverText: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?HoverInfo: StyleParam.HoverInfo,
            [<Optional; DefaultParameterValue(null)>] ?XHoverFormat: string,
            [<Optional; DefaultParameterValue(null)>] ?YHoverFormat: string,
            [<Optional; DefaultParameterValue(null)>] ?Meta: string,
            [<Optional; DefaultParameterValue(null)>] ?CustomData: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?XAxis: StyleParam.LinearAxisId,
            [<Optional; DefaultParameterValue(null)>] ?YAxis: StyleParam.LinearAxisId,
            [<Optional; DefaultParameterValue(null)>] ?XPeriod: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?XPeriodAlignment: StyleParam.PeriodAlignment,
            [<Optional; DefaultParameterValue(null)>] ?XPeriod0: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?YPeriod: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?YPeriodAlignment: StyleParam.PeriodAlignment,
            [<Optional; DefaultParameterValue(null)>] ?YPeriod0: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?Line: Line,
            [<Optional; DefaultParameterValue(null)>] ?WhiskerWidth: float,
            [<Optional; DefaultParameterValue(null)>] ?SelectedPoints: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Increasing: FinanceMarker,
            [<Optional; DefaultParameterValue(null)>] ?Decreasing: FinanceMarker,
            [<Optional; DefaultParameterValue(null)>] ?HoverLabel: Hoverlabel,
            [<Optional; DefaultParameterValue(null)>] ?XCalendar: StyleParam.Calendar,
            [<Optional; DefaultParameterValue(null)>] ?UIRevision: string
        ) =
        (fun (trace: ('T :> Trace)) ->

            Name |> DynObj.setOptionalProperty trace "name"
            Visible |> DynObj.setOptionalPropertyBy trace "visible" StyleParam.Visible.convert
            ShowLegend |> DynObj.setOptionalProperty trace "showlegend"
            Legend |> DynObj.setOptionalPropertyBy trace "legend" StyleParam.SubPlotId.convert
            LegendRank |> DynObj.setOptionalProperty trace "legendrank"
            LegendGroup |> DynObj.setOptionalProperty trace "legendgroup"
            LegendGroupTitle |> DynObj.setOptionalProperty trace "legendgrouptitle"
            Opacity |> DynObj.setOptionalProperty trace "opacity"
            Ids |> DynObj.setOptionalProperty trace "ids"
            (X, MultiX) |> DynObj.setOptionalSingleOrMultiProperty trace "x"
            Close |> DynObj.setOptionalProperty trace "close"
            Open |> DynObj.setOptionalProperty trace "open"
            High |> DynObj.setOptionalProperty trace "high"
            Low |> DynObj.setOptionalProperty trace "low"
            (Text, MultiText) |> DynObj.setOptionalSingleOrMultiProperty trace "text"
            (HoverText, MultiHoverText) |> DynObj.setOptionalSingleOrMultiProperty trace "hovertext"
            HoverInfo |> DynObj.setOptionalPropertyBy trace "hoverinfo" StyleParam.HoverInfo.convert
            XHoverFormat |> DynObj.setOptionalProperty trace "xhoverformat"
            YHoverFormat |> DynObj.setOptionalProperty trace "yhoverformat"
            Meta |> DynObj.setOptionalProperty trace "meta"
            CustomData |> DynObj.setOptionalProperty trace "customdata"
            XAxis |> DynObj.setOptionalPropertyBy trace "xaxis" StyleParam.LinearAxisId.convert
            YAxis |> DynObj.setOptionalPropertyBy trace "yaxis" StyleParam.LinearAxisId.convert
            XPeriod |> DynObj.setOptionalProperty trace "xperiod"
            XPeriodAlignment |> DynObj.setOptionalPropertyBy trace "xperiodalignment" StyleParam.PeriodAlignment.convert
            XPeriod0 |> DynObj.setOptionalProperty trace "xperiod0"
            YPeriod |> DynObj.setOptionalProperty trace "yperiod"
            YPeriodAlignment |> DynObj.setOptionalPropertyBy trace "yperiodalignment" StyleParam.PeriodAlignment.convert
            YPeriod0 |> DynObj.setOptionalProperty trace "yperiod0"
            Line |> DynObj.setOptionalProperty trace "line"
            WhiskerWidth |> DynObj.setOptionalProperty trace "whiskerwidth"
            Increasing |> DynObj.setOptionalProperty trace "increasing"
            Decreasing |> DynObj.setOptionalProperty trace "decreasing"
            HoverLabel |> DynObj.setOptionalProperty trace "hoverlabel"
            XCalendar |> DynObj.setOptionalPropertyBy trace "xcalendar" StyleParam.Calendar.convert
            UIRevision |> DynObj.setOptionalProperty trace "uirevision"

            trace)

    /// <summary>
    /// Create a function that applies the styles of a scatter plot matrix (SPLOM) to a Trace object
    /// </summary>
    /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
    /// <param name="Visible">Determines whether or not this trace is visible. If "legendonly", the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).</param>
    /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
    /// <param name="Legend">Sets the reference to a legend to show this trace in. References to these legends are "legend", "legend2", "legend3", etc. Settings for these legends are set in the layout, under `layout.legend`, `layout.legend2`, etc.</param>
    /// <param name="LegendRank">Sets the legend rank for this trace. Items and groups with smaller ranks are presented on top/left side while with `"reversed" `legend.traceorder` they are on bottom/right side. The default legendrank is 1000, so that you can use ranks less than 1000 to place certain items before all unranked items, and ranks greater than 1000 to go after all unranked items.</param>
    /// <param name="LegendGroup">Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling legend items.</param>
    /// <param name="LegendGroupTitle">Sets the legend group title for this trace.</param>
    /// <param name="Opacity">Sets the opacity of the trace.</param>
    /// <param name="Ids">Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.</param>
    /// <param name="Text">Sets text elements associated with each (x,y) pair to appear on hover. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates.</param>
    /// <param name="MultiText">Sets text elements associated with each (x,y) pair to appear on hover. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates.</param>
    /// <param name="Dimensions">Sets the dimensions of this trace.</param>
    /// <param name="HoverText">Sets hover text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. To be seen, trace `hoverinfo` must contain a "text" flag.</param>
    /// <param name="MultiHoverText">Sets hover text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. To be seen, trace `hoverinfo` must contain a "text" flag.</param>
    /// <param name="HoverInfo">Determines which trace information appear on hover. If `none` or `skip` are set, no information is displayed upon hovering. But, if `none` is set, click and hover events are still fired.</param>
    /// <param name="HoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
    /// <param name="MultiHoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
    /// <param name="XHoverFormat">Sets the hover text formatting rulefor `x` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `xaxis.hoverformat`.</param>
    /// <param name="YHoverFormat">Sets the hover text formatting rulefor `y` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `xaxis.hoverformat`.</param>
    /// <param name="Meta">Assigns extra meta information associated with this trace that can be used in various text attributes. Attributes such as trace `name`, graph, axis and colorbar `title.text`, annotation `text` `rangeselector`, `updatemenues` and `sliders` `label` text all support `meta`. To access the trace `meta` values in an attribute in the same trace, simply use `%{meta[i]}` where `i` is the index or key of the `meta` item in question. To access trace `meta` in layout attributes, use `%{data[n[.meta[i]}` where `i` is the index or key of the `meta` and `n` is the trace index.</param>
    /// <param name="CustomData">Assigns extra data each datum. This may be useful when listening to hover, click and selection events. Note that, "scatter" traces also appends customdata items in the markers DOM elements</param>
    /// <param name="Marker">Sets the marker of this trace.</param>
    /// <param name="Diagonal">Sets the styles applied to the scatter plot matrix diagonal</param>
    /// <param name="XAxes">Sets the list of x axes corresponding to dimensions of this splom trace. By default, a splom will match the first N xaxes where N is the number of input dimensions. Note that, in case where `diagonal.visible` is false and `showupperhalf` or `showlowerhalf` is false, this splom trace will generate one less x-axis and one less y-axis.</param>
    /// <param name="YAxes">Sets the list of y axes corresponding to dimensions of this splom trace. By default, a splom will match the first N yaxes where N is the number of input dimensions. Note that, in case where `diagonal.visible` is false and `showupperhalf` or `showlowerhalf` is false, this splom trace will generate one less x-axis and one less y-axis.</param>
    /// <param name="ShowLowerHalf">Determines whether or not subplots on the lower half from the diagonal are displayed.</param>
    /// <param name="ShowUpperHalf">Determines whether or not subplots on the upper half from the diagonal are displayed.</param>
    /// <param name="SelectedPoints">Array containing integer indices of selected points. Has an effect only for traces that support selections. Note that an empty array means an empty selection where the `unselected` are turned on for all points, whereas, any other non-array values means no selection all where the `selected` and `unselected` styles have no effect.</param>
    /// <param name="Selected">Sets the style of selected points of this trace.</param>
    /// <param name="Unselected">Sets the style of unselected points of this trace.</param>
    /// <param name="HoverLabel">Sets the style of the hoverlabels of this trace.</param>
    /// <param name="UIRevision">Controls persistence of some user-driven changes to the trace: `constraintrange` in `parcoords` traces, as well as some `editable: true` modifications such as `name` and `colorbar.title`. Defaults to `layout.uirevision`. Note that other user-driven trace attribute changes are controlled by `layout` attributes: `trace.visible` is controlled by `layout.legend.uirevision`, `selectedpoints` is controlled by `layout.selectionrevision`, and `colorbar.(x|y)` (accessible with `config: {editable: true}`) is controlled by `layout.editrevision`. Trace changes are tracked by `uid`, which only falls back on trace index if no `uid` is provided. So if your app can add/remove traces before the end of the `data` array, such that the same trace has a different index, you can still preserve user-driven changes if you give each trace a `uid` that stays with it as it moves.</param>
    static member Splom
        (
            [<Optional; DefaultParameterValue(null)>] ?Name: string,
            [<Optional; DefaultParameterValue(null)>] ?Visible: StyleParam.Visible,
            [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
            [<Optional; DefaultParameterValue(null)>] ?Legend: StyleParam.SubPlotId,
            [<Optional; DefaultParameterValue(null)>] ?LegendRank: int,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroup: string,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroupTitle: Title,
            [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
            [<Optional; DefaultParameterValue(null)>] ?Ids: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Dimensions: seq<Dimension>,
            [<Optional; DefaultParameterValue(null)>] ?HoverText: string,
            [<Optional; DefaultParameterValue(null)>] ?MultiHoverText: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?HoverInfo: StyleParam.HoverInfo,
            [<Optional; DefaultParameterValue(null)>] ?HoverTemplate: string,
            [<Optional; DefaultParameterValue(null)>] ?MultiHoverTemplate: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?XHoverFormat: string,
            [<Optional; DefaultParameterValue(null)>] ?YHoverFormat: string,
            [<Optional; DefaultParameterValue(null)>] ?Meta: string,
            [<Optional; DefaultParameterValue(null)>] ?CustomData: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
            [<Optional; DefaultParameterValue(null)>] ?Diagonal: SplomDiagonal,
            [<Optional; DefaultParameterValue(null)>] ?XAxes: seq<StyleParam.LinearAxisId>,
            [<Optional; DefaultParameterValue(null)>] ?YAxes: seq<StyleParam.LinearAxisId>,
            [<Optional; DefaultParameterValue(null)>] ?ShowLowerHalf: bool,
            [<Optional; DefaultParameterValue(null)>] ?ShowUpperHalf: bool,
            [<Optional; DefaultParameterValue(null)>] ?SelectedPoints: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Selected: TraceSelection,
            [<Optional; DefaultParameterValue(null)>] ?Unselected: TraceSelection,
            [<Optional; DefaultParameterValue(null)>] ?HoverLabel: Hoverlabel,
            [<Optional; DefaultParameterValue(null)>] ?UIRevision: string
        ) =
        (fun (trace: ('T :> Trace)) ->

            Name |> DynObj.setOptionalProperty trace "name"
            Visible |> DynObj.setOptionalPropertyBy trace "visible" StyleParam.Visible.convert
            ShowLegend |> DynObj.setOptionalProperty trace "showlegend"
            Legend |> DynObj.setOptionalPropertyBy trace "legend" StyleParam.SubPlotId.convert
            LegendRank |> DynObj.setOptionalProperty trace "legendrank"
            LegendGroup |> DynObj.setOptionalProperty trace "legendgroup"
            LegendGroupTitle |> DynObj.setOptionalProperty trace "legendgrouptitle"
            Opacity |> DynObj.setOptionalProperty trace "opacity"
            Ids |> DynObj.setOptionalProperty trace "ids"
            (Text, MultiText) |> DynObj.setOptionalSingleOrMultiProperty trace "text"
            Dimensions |> DynObj.setOptionalProperty trace "dimensions"
            (HoverText, MultiHoverText) |> DynObj.setOptionalSingleOrMultiProperty trace "hovertext"
            HoverInfo |> DynObj.setOptionalPropertyBy trace "hoverinfo" StyleParam.HoverInfo.convert
            (HoverTemplate, MultiHoverTemplate) |> DynObj.setOptionalSingleOrMultiProperty trace "hovertemplate"
            XHoverFormat |> DynObj.setOptionalProperty trace "xhoverformat"
            YHoverFormat |> DynObj.setOptionalProperty trace "yhoverformat"
            Meta |> DynObj.setOptionalProperty trace "meta"
            CustomData |> DynObj.setOptionalProperty trace "customdata"
            Marker |> DynObj.setOptionalProperty trace "marker"
            Diagonal |> DynObj.setOptionalProperty trace "diagonal"
            XAxes |> DynObj.setOptionalPropertyBy trace "xaxis" (Seq.map StyleParam.LinearAxisId.convert)
            YAxes |> DynObj.setOptionalPropertyBy trace "yaxis" (Seq.map StyleParam.LinearAxisId.convert)
            ShowLowerHalf |> DynObj.setOptionalProperty trace "showlowerhalf"
            ShowUpperHalf |> DynObj.setOptionalProperty trace "showupperhalf"
            SelectedPoints |> DynObj.setOptionalProperty trace "selectedpoints"
            Selected |> DynObj.setOptionalProperty trace "selected"
            Unselected |> DynObj.setOptionalProperty trace "unselected"
            HoverLabel |> DynObj.setOptionalProperty trace "hoverlabel"
            UIRevision |> DynObj.setOptionalProperty trace "uirevision"

            trace)
