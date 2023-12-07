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

            X |> DynObj.setValueOptBy trace "xaxis" StyleParam.LinearAxisId.toString
            Y |> DynObj.setValueOptBy trace "yaxis" StyleParam.LinearAxisId.toString

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

            Name |> DynObj.setValueOpt trace "name"
            Visible |> DynObj.setValueOptBy trace "visible" StyleParam.Visible.convert
            ShowLegend |> DynObj.setValueOpt trace "showlegend"
            Legend |> DynObj.setValueOptBy trace "legend" StyleParam.SubPlotId.convert
            LegendRank |> DynObj.setValueOpt trace "legendrank"
            LegendGroup |> DynObj.setValueOpt trace "legendgroup"
            LegendGroupTitle |> DynObj.setValueOpt trace "legendgrouptitle"
            Opacity |> DynObj.setValueOpt trace "opacity"
            Mode |> DynObj.setValueOptBy trace "mode" StyleParam.Mode.convert
            Ids |> DynObj.setValueOpt trace "ids"
            (X, MultiX) |> DynObj.setSingleOrMultiOpt trace "x"
            X0 |> DynObj.setValueOpt trace "x0"
            DX |> DynObj.setValueOpt trace "dx"
            (Y, MultiY) |> DynObj.setSingleOrMultiOpt trace "y"
            Y0 |> DynObj.setValueOpt trace "y0"
            DY |> DynObj.setValueOpt trace "dy"
            (Text, MultiText) |> DynObj.setSingleOrMultiOpt trace "text"

            (TextPosition, MultiTextPosition)
            |> DynObj.setSingleOrMultiOptBy trace "textposition" StyleParam.TextPosition.convert

            (TextTemplate, MultiTextTemplate) |> DynObj.setSingleOrMultiOpt trace "texttemplate"
            (HoverText, MultiHoverText) |> DynObj.setSingleOrMultiOpt trace "hovertext"
            HoverInfo |> DynObj.setValueOptBy trace "hoverinfo" StyleParam.HoverInfo.convert
            (HoverTemplate, MultiHoverTemplate) |> DynObj.setSingleOrMultiOpt trace "hovertemplate"
            XHoverFormat |> DynObj.setValueOpt trace "xhoverformat"
            YHoverFormat |> DynObj.setValueOpt trace "yhoverformat"
            Meta |> DynObj.setValueOpt trace "meta"
            CustomData |> DynObj.setValueOpt trace "customdata"
            XAxis |> DynObj.setValueOptBy trace "xaxis" StyleParam.LinearAxisId.convert
            YAxis |> DynObj.setValueOptBy trace "yaxis" StyleParam.LinearAxisId.convert
            Orientation |> DynObj.setValueOptBy trace "orientation" StyleParam.Orientation.convert
            GroupNorm |> DynObj.setValueOptBy trace "groupnorm" StyleParam.GroupNorm.convert
            AlignmentGroup |> DynObj.setValueOpt trace "alignmentgroup"
            OffsetGroup |> DynObj.setValueOpt trace "offsetgroup"
            StackGroup |> DynObj.setValueOpt trace "stackgroup"
            XPeriod |> DynObj.setValueOpt trace "xperiod"
            XPeriodAlignment |> DynObj.setValueOptBy trace "xperiodalignment" StyleParam.PeriodAlignment.convert
            XPeriod0 |> DynObj.setValueOpt trace "xperiod0"
            YPeriod |> DynObj.setValueOpt trace "yperiod"
            YPeriodAlignment |> DynObj.setValueOptBy trace "yperiodalignment" StyleParam.PeriodAlignment.convert
            YPeriod0 |> DynObj.setValueOpt trace "yperiod0"
            Marker |> DynObj.setValueOpt trace "marker"
            Line |> DynObj.setValueOpt trace "line"
            TextFont |> DynObj.setValueOpt trace "textfont"
            XError |> DynObj.setValueOpt trace "error_x"
            YError |> DynObj.setValueOpt trace "error_y"
            SelectedPoints |> DynObj.setValueOpt trace "selectedpoints"
            Selected |> DynObj.setValueOpt trace "selected"
            Unselected |> DynObj.setValueOpt trace "unselected"
            ClipOnAxis |> DynObj.setValueOpt trace "cliponaxis"
            ConnectGaps |> DynObj.setValueOpt trace "connectgaps"
            Fill |> DynObj.setValueOptBy trace "fill" StyleParam.Fill.convert
            FillColor |> DynObj.setValueOpt trace "fillcolor"
            FillPattern |> DynObj.setValueOpt trace "fillpattern"
            HoverLabel |> DynObj.setValueOpt trace "hoverlabel"
            HoverOn |> DynObj.setValueOptBy trace "hoveron" StyleParam.HoverOn.convert
            StackGaps |> DynObj.setValueOptBy trace "stackgaps" StyleParam.StackGaps.convert
            XCalendar |> DynObj.setValueOptBy trace "xcalendar" StyleParam.Calendar.convert
            YCalendar |> DynObj.setValueOptBy trace "ycalendar" StyleParam.Calendar.convert
            UIRevision |> DynObj.setValueOpt trace "uirevision"

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

            Name |> DynObj.setValueOpt bar "name"
            Visible |> DynObj.setValueOptBy bar "visible" StyleParam.Visible.convert
            ShowLegend |> DynObj.setValueOpt bar "showlegend"
            Legend |> DynObj.setValueOptBy bar "legend" StyleParam.SubPlotId.convert
            LegendRank |> DynObj.setValueOpt bar "legendrank"
            LegendGroup |> DynObj.setValueOpt bar "legendgroup"
            LegendGroupTitle |> DynObj.setValueOpt bar "legendgrouptitle"
            Opacity |> DynObj.setValueOpt bar "opacity"
            Ids |> DynObj.setValueOpt bar "ids"
            (X, MultiX) |> DynObj.setSingleOrMultiOpt bar "x"
            X0 |> DynObj.setValueOpt bar "x0"
            DX |> DynObj.setValueOpt bar "dx"
            (Y, MultiY) |> DynObj.setSingleOrMultiOpt bar "y"
            Y0 |> DynObj.setValueOpt bar "y0"
            DY |> DynObj.setValueOpt bar "dy"
            Base |> DynObj.setValueOpt bar "base"
            (Width, MultiWidth) |> DynObj.setSingleOrMultiOpt bar "width"
            (Offset, MultiOffset) |> DynObj.setSingleOrMultiOpt bar "offset"
            (Text, MultiText) |> DynObj.setSingleOrMultiOpt bar "text"

            (TextPosition, MultiTextPosition)
            |> DynObj.setSingleOrMultiOptBy bar "textposition" StyleParam.TextPosition.convert

            (TextTemplate, MultiTextTemplate) |> DynObj.setSingleOrMultiOpt bar "texttemplate"
            (HoverText, MultiHoverText) |> DynObj.setSingleOrMultiOpt bar "hovertext"
            HoverInfo |> DynObj.setValueOptBy bar "hoverinfo" StyleParam.HoverInfo.convert
            (HoverTemplate, MultiHoverTemplate) |> DynObj.setSingleOrMultiOpt bar "hovertemplate"
            XHoverFormat |> DynObj.setValueOpt bar "xhoverformat"
            YHoverFormat |> DynObj.setValueOpt bar "yhoverformat"
            Meta |> DynObj.setValueOpt bar "meta"
            CustomData |> DynObj.setValueOpt bar "customdata"
            XAxis |> DynObj.setValueOptBy bar "xaxis" StyleParam.LinearAxisId.convert
            YAxis |> DynObj.setValueOptBy bar "yaxis" StyleParam.LinearAxisId.convert
            Orientation |> DynObj.setValueOptBy bar "orientation" StyleParam.Orientation.convert
            AlignmentGroup |> DynObj.setValueOpt bar "alignmentgroup"
            OffsetGroup |> DynObj.setValueOpt bar "offsetgroup"
            XPeriod |> DynObj.setValueOpt bar "xperiod"
            XPeriodAlignment |> DynObj.setValueOptBy bar "xperiodalignment" StyleParam.PeriodAlignment.convert
            XPeriod0 |> DynObj.setValueOpt bar "xperiod0"
            YPeriod |> DynObj.setValueOpt bar "yperiod"
            YPeriodAlignment |> DynObj.setValueOptBy bar "yperiodalignment" StyleParam.PeriodAlignment.convert
            YPeriod0 |> DynObj.setValueOpt bar "yperiod0"
            Marker |> DynObj.setValueOpt bar "marker"
            TextAngle |> DynObj.setValueOpt bar "textangle"
            TextFont |> DynObj.setValueOpt bar "textfont"
            XError |> DynObj.setValueOpt bar "error_x"
            YError |> DynObj.setValueOpt bar "error_y"
            SelectedPoints |> DynObj.setValueOpt bar "selectedpoints"
            Selected |> DynObj.setValueOpt bar "selected"
            Unselected |> DynObj.setValueOpt bar "unselected"
            ClipOnAxis |> DynObj.setValueOpt bar "cliponaxis"
            Constraintext |> DynObj.setValueOptBy bar "constraintext" StyleParam.ConstrainText.convert
            HoverLabel |> DynObj.setValueOpt bar "hoverlabel"
            InsideTextAnchor |> DynObj.setValueOptBy bar "insidetextanchor" StyleParam.InsideTextAnchor.convert
            InsideTextFont |> DynObj.setValueOpt bar "insidetextfont"
            OutsideTextFont |> DynObj.setValueOpt bar "outsidetextfont"
            XCalendar |> DynObj.setValueOptBy bar "xcalendar" StyleParam.Calendar.convert
            YCalendar |> DynObj.setValueOptBy bar "ycalendar" StyleParam.Calendar.convert
            UIRevision |> DynObj.setValueOpt bar "uirevision"

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

            Name |> DynObj.setValueOpt funnel "name"
            Visible |> DynObj.setValueOptBy funnel "visible" StyleParam.Visible.convert
            ShowLegend |> DynObj.setValueOpt funnel "showlegend"
            Legend |> DynObj.setValueOptBy funnel "legend" StyleParam.SubPlotId.convert
            LegendRank |> DynObj.setValueOpt funnel "legendrank"
            LegendGroup |> DynObj.setValueOpt funnel "legendgroup"
            LegendGroupTitle |> DynObj.setValueOpt funnel "legendgrouptitle"
            Opacity |> DynObj.setValueOpt funnel "opacity"
            Ids |> DynObj.setValueOpt funnel "ids"
            (X, MultiX) |> DynObj.setSingleOrMultiOpt funnel "x"
            X0 |> DynObj.setValueOpt funnel "x0"
            DX |> DynObj.setValueOpt funnel "dx"
            (Y, MultiY) |> DynObj.setSingleOrMultiOpt funnel "y"
            Y0 |> DynObj.setValueOpt funnel "y0"
            DY |> DynObj.setValueOpt funnel "dy"
            Width |> DynObj.setValueOpt funnel "width"
            Offset |> DynObj.setValueOpt funnel "offset"
            (Text, MultiText) |> DynObj.setSingleOrMultiOpt funnel "text"

            (TextPosition, MultiTextPosition)
            |> DynObj.setSingleOrMultiOptBy funnel "textposition" StyleParam.TextPosition.convert

            (TextTemplate, MultiTextTemplate) |> DynObj.setSingleOrMultiOpt funnel "texttemplate"
            (HoverText, MultiHoverText) |> DynObj.setSingleOrMultiOpt funnel "hovertext"
            HoverInfo |> DynObj.setValueOptBy funnel "hoverinfo" StyleParam.HoverInfo.convert
            (HoverTemplate, MultiHoverTemplate) |> DynObj.setSingleOrMultiOpt funnel "hovertemplate"
            XHoverFormat |> DynObj.setValueOpt funnel "xhoverformat"
            YHoverFormat |> DynObj.setValueOpt funnel "yhoverformat"
            Meta |> DynObj.setValueOpt funnel "meta"
            CustomData |> DynObj.setValueOpt funnel "customdata"
            XAxis |> DynObj.setValueOptBy funnel "xaxis" StyleParam.LinearAxisId.convert
            YAxis |> DynObj.setValueOptBy funnel "yaxis" StyleParam.LinearAxisId.convert
            Orientation |> DynObj.setValueOptBy funnel "orientation" StyleParam.Orientation.convert
            AlignmentGroup |> DynObj.setValueOpt funnel "alignmentgroup"
            OffsetGroup |> DynObj.setValueOpt funnel "offsetgroup"
            XPeriod |> DynObj.setValueOpt funnel "xperiod"
            XPeriodAlignment |> DynObj.setValueOptBy funnel "xperiodalignment" StyleParam.PeriodAlignment.convert
            XPeriod0 |> DynObj.setValueOpt funnel "xperiod0"
            YPeriod |> DynObj.setValueOpt funnel "yperiod"
            YPeriodAlignment |> DynObj.setValueOptBy funnel "yperiodalignment" StyleParam.PeriodAlignment.convert
            YPeriod0 |> DynObj.setValueOpt funnel "yperiod0"
            Marker |> DynObj.setValueOpt funnel "marker"
            TextAngle |> DynObj.setValueOpt funnel "textangle"
            TextFont |> DynObj.setValueOpt funnel "textfont"
            TextInfo |> DynObj.setValueOptBy funnel "textinfo" StyleParam.TextInfo.convert
            SelectedPoints |> DynObj.setValueOpt funnel "selectedpoints"
            ClipOnAxis |> DynObj.setValueOpt funnel "cliponaxis"
            Connector |> DynObj.setValueOpt funnel "connector"
            Constraintext |> DynObj.setValueOptBy funnel "constraintext" StyleParam.ConstrainText.convert
            HoverLabel |> DynObj.setValueOpt funnel "hoverlabel"
            InsideTextAnchor |> DynObj.setValueOptBy funnel "insidetextanchor" StyleParam.InsideTextAnchor.convert
            InsideTextFont |> DynObj.setValueOpt funnel "insidetextfont"
            OutsideTextFont |> DynObj.setValueOpt funnel "outsidetextfont"
            UIRevision |> DynObj.setValueOpt funnel "uirevision"

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

            Name |> DynObj.setValueOpt trace "name"
            Visible |> DynObj.setValueOptBy trace "visible" StyleParam.Visible.convert
            ShowLegend |> DynObj.setValueOpt trace "showlegend"
            Legend |> DynObj.setValueOptBy trace "legend" StyleParam.SubPlotId.convert
            LegendRank |> DynObj.setValueOpt trace "legendrank"
            LegendGroup |> DynObj.setValueOpt trace "legendgroup"
            LegendGroupTitle |> DynObj.setValueOpt trace "legendgrouptitle"
            Opacity |> DynObj.setValueOpt trace "opacity"
            Ids |> DynObj.setValueOpt trace "ids"
            (X, MultiX) |> DynObj.setSingleOrMultiOpt trace "x"
            X0 |> DynObj.setValueOpt trace "x0"
            DX |> DynObj.setValueOpt trace "dx"
            (Y, MultiY) |> DynObj.setSingleOrMultiOpt trace "y"
            Y0 |> DynObj.setValueOpt trace "y0"
            DY |> DynObj.setValueOpt trace "dy"
            Base |> DynObj.setValueOpt trace "base"
            (Width, MultiWidth) |> DynObj.setSingleOrMultiOpt trace "width"
            Measure |> DynObj.setValueOptBy trace "measure" (Seq.map StyleParam.WaterfallMeasure.convert)
            (Offset, MultiOffset) |> DynObj.setSingleOrMultiOpt trace "offset"
            (Text, MultiText) |> DynObj.setSingleOrMultiOpt trace "text"

            (TextPosition, MultiTextPosition)
            |> DynObj.setSingleOrMultiOptBy trace "textposition" StyleParam.TextPosition.convert

            (TextTemplate, MultiTextTemplate) |> DynObj.setSingleOrMultiOpt trace "texttemplate"
            (HoverText, MultiHoverText) |> DynObj.setSingleOrMultiOpt trace "hovertext"
            HoverInfo |> DynObj.setValueOptBy trace "hoverinfo" StyleParam.HoverInfo.convert
            (HoverTemplate, MultiHoverTemplate) |> DynObj.setSingleOrMultiOpt trace "hovertemTotalsplate"
            XHoverFormat |> DynObj.setValueOpt trace "xhoverformat"
            YHoverFormat |> DynObj.setValueOpt trace "yhoverformat"
            Meta |> DynObj.setValueOpt trace "meta"
            CustomData |> DynObj.setValueOpt trace "customdata"
            XAxis |> DynObj.setValueOptBy trace "xaxis" StyleParam.LinearAxisId.convert
            YAxis |> DynObj.setValueOptBy trace "yaxis" StyleParam.LinearAxisId.convert
            Orientation |> DynObj.setValueOptBy trace "orientation" StyleParam.Orientation.convert
            AlignmentGroup |> DynObj.setValueOpt trace "alignmentgroup"
            OffsetGroup |> DynObj.setValueOpt trace "offsetgroup"
            XPeriod |> DynObj.setValueOpt trace "xperiod"
            XPeriodAlignment |> DynObj.setValueOptBy trace "xperiodalignment" StyleParam.PeriodAlignment.convert
            XPeriod0 |> DynObj.setValueOpt trace "xperiod0"
            YPeriod |> DynObj.setValueOpt trace "yperiod"
            YPeriodAlignment |> DynObj.setValueOptBy trace "yperiodalignment" StyleParam.PeriodAlignment.convert
            YPeriod0 |> DynObj.setValueOpt trace "yperiod0"
            TextAngle |> DynObj.setValueOpt trace "textangle"
            TextFont |> DynObj.setValueOpt trace "textfont"
            TextInfo |> DynObj.setValueOpt trace "textinfo"
            SelectedPoints |> DynObj.setValueOpt trace "selectedpoints"
            ClipOnAxis |> DynObj.setValueOpt trace "cliponaxis"
            Connector |> DynObj.setValueOpt trace "connector"
            Constraintext |> DynObj.setValueOptBy trace "constraintext" StyleParam.ConstrainText.convert
            Increasing |> DynObj.setValueOpt trace "increasing"
            Decreasing |> DynObj.setValueOpt trace "decreasing"
            HoverLabel |> DynObj.setValueOpt trace "hoverlabel"
            InsideTextAnchor |> DynObj.setValueOptBy trace "insidetextanchor" StyleParam.InsideTextAnchor.convert
            InsideTextFont |> DynObj.setValueOpt trace "insidetextfont"
            OutsideTextFont |> DynObj.setValueOpt trace "outsidetextfont"
            Totals |> DynObj.setValueOpt trace "totals"
            UIRevision |> DynObj.setValueOpt trace "uirevision"

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

            Name |> DynObj.setValueOpt histogram "name"
            Visible |> DynObj.setValueOptBy histogram "visible" StyleParam.Visible.convert
            ShowLegend |> DynObj.setValueOpt histogram "showlegend"
            Legend |> DynObj.setValueOptBy histogram "legend" StyleParam.SubPlotId.convert
            LegendRank |> DynObj.setValueOpt histogram "legendrank"
            LegendGroup |> DynObj.setValueOpt histogram "legendgroup"
            LegendGroupTitle |> DynObj.setValueOpt histogram "legendgrouptitle"
            Opacity |> DynObj.setValueOpt histogram "opacity"
            Ids |> DynObj.setValueOpt histogram "ids"
            (X, MultiX) |> DynObj.setSingleOrMultiOpt histogram "x"
            (Y, MultiY) |> DynObj.setSingleOrMultiOpt histogram "y"
            (Text, MultiText) |> DynObj.setSingleOrMultiOpt histogram "text"
            TextPosition |> DynObj.setValueOptBy histogram "textposition" StyleParam.TextPosition.convert
            (TextTemplate, MultiTextTemplate) |> DynObj.setSingleOrMultiOpt histogram "texttemplate"
            (HoverText, MultiHoverText) |> DynObj.setSingleOrMultiOpt histogram "hovertext"
            HoverInfo |> DynObj.setValueOptBy histogram "hoverinfo" StyleParam.HoverInfo.convert
            (HoverTemplate, MultiHoverTemplate) |> DynObj.setSingleOrMultiOpt histogram "hovertemplate"
            XHoverFormat |> DynObj.setValueOpt histogram "xhoverformat"
            YHoverFormat |> DynObj.setValueOpt histogram "yhoverformat"
            Meta |> DynObj.setValueOpt histogram "meta"
            CustomData |> DynObj.setValueOpt histogram "customdata"
            XAxis |> DynObj.setValueOptBy histogram "xaxis" StyleParam.LinearAxisId.convert
            YAxis |> DynObj.setValueOptBy histogram "yaxis" StyleParam.LinearAxisId.convert
            Orientation |> DynObj.setValueOptBy histogram "orientation" StyleParam.Orientation.convert
            HistFunc |> DynObj.setValueOptBy histogram "histfunc" StyleParam.HistFunc.convert
            HistNorm |> DynObj.setValueOptBy histogram "histnorm" StyleParam.HistNorm.convert
            AlignmentGroup |> DynObj.setValueOpt histogram "alignmentgroup"
            OffsetGroup |> DynObj.setValueOpt histogram "offsetgroup"
            NBinsX |> DynObj.setValueOpt histogram "nbinsx"
            NBinsY |> DynObj.setValueOpt histogram "nbinsy"
            AutoBinX |> DynObj.setValueOpt histogram "autobinx"
            AutoBinY |> DynObj.setValueOpt histogram "autobiny"
            BinGroup |> DynObj.setValueOpt histogram "bingroup"
            XBins |> DynObj.setValueOpt histogram "xbins"
            YBins |> DynObj.setValueOpt histogram "ybins"
            Marker |> DynObj.setValueOpt histogram "marker"
            TextAngle |> DynObj.setValueOpt histogram "textangle"
            TextFont |> DynObj.setValueOpt histogram "textfont"
            Line |> DynObj.setValueOpt histogram "line"
            XError |> DynObj.setValueOpt histogram "error_x"
            YError |> DynObj.setValueOpt histogram "error_y"
            SelectedPoints |> DynObj.setValueOpt histogram "selectedpoints"
            Selected |> DynObj.setValueOpt histogram "selected"
            Unselected |> DynObj.setValueOpt histogram "unselected"
            ClipOnAxis |> DynObj.setValueOpt histogram "cliponaxis"
            Constraintext |> DynObj.setValueOptBy histogram "constraintext" StyleParam.ConstrainText.convert
            Cumulative |> DynObj.setValueOpt histogram "cumulative"
            HoverLabel |> DynObj.setValueOpt histogram "hoverlabel"
            InsideTextAnchor |> DynObj.setValueOptBy histogram "insidetextanchor" StyleParam.InsideTextAnchor.convert
            InsideTextFont |> DynObj.setValueOpt histogram "insidetextfont"
            OutsideTextFont |> DynObj.setValueOpt histogram "outsidetextfont"
            XCalendar |> DynObj.setValueOptBy histogram "xcalendar" StyleParam.Calendar.convert
            YCalendar |> DynObj.setValueOptBy histogram "ycalendar" StyleParam.Calendar.convert
            UIRevision |> DynObj.setValueOpt histogram "uirevision"

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

            Name |> DynObj.setValueOpt boxPlot "name"
            Visible |> DynObj.setValueOptBy boxPlot "visible" StyleParam.Visible.convert
            ShowLegend |> DynObj.setValueOpt boxPlot "showlegend"
            Legend |> DynObj.setValueOptBy boxPlot "legend" StyleParam.SubPlotId.convert
            LegendRank |> DynObj.setValueOpt boxPlot "legendrank"
            LegendGroup |> DynObj.setValueOpt boxPlot "legendgroup"
            LegendGroupTitle |> DynObj.setValueOpt boxPlot "legendgrouptitle"
            LegendWidth |> DynObj.setValueOpt boxPlot "legendwidth"
            Opacity |> DynObj.setValueOpt boxPlot "opacity"
            Ids |> DynObj.setValueOpt boxPlot "ids"
            (X, MultiX) |> DynObj.setSingleOrMultiOpt boxPlot "x"
            X0 |> DynObj.setValueOpt boxPlot "x0"
            DX |> DynObj.setValueOpt boxPlot "dx"
            (Y, MultiY) |> DynObj.setSingleOrMultiOpt boxPlot "y"
            Y0 |> DynObj.setValueOpt boxPlot "y0"
            DY |> DynObj.setValueOpt boxPlot "dy"
            Width |> DynObj.setValueOpt boxPlot "width"
            (Text, MultiText) |> DynObj.setSingleOrMultiOpt boxPlot "text"
            (HoverText, MultiHoverText) |> DynObj.setSingleOrMultiOpt boxPlot "hovertext"
            HoverInfo |> DynObj.setValueOptBy boxPlot "hoverinfo" StyleParam.HoverInfo.convert
            (HoverTemplate, MultiHoverTemplate) |> DynObj.setSingleOrMultiOpt boxPlot "hovertemplate"
            XHoverFormat |> DynObj.setValueOpt boxPlot "xhoverformat"
            YHoverFormat |> DynObj.setValueOpt boxPlot "yhoverformat"
            Meta |> DynObj.setValueOpt boxPlot "meta"
            CustomData |> DynObj.setValueOpt boxPlot "customdata"
            XAxis |> DynObj.setValueOptBy boxPlot "xaxis" StyleParam.LinearAxisId.convert
            YAxis |> DynObj.setValueOptBy boxPlot "yaxis" StyleParam.LinearAxisId.convert
            Orientation |> DynObj.setValueOptBy boxPlot "orientation" StyleParam.Orientation.convert
            AlignmentGroup |> DynObj.setValueOpt boxPlot "alignmentgroup"
            OffsetGroup |> DynObj.setValueOpt boxPlot "offsetgroup"
            XPeriod |> DynObj.setValueOpt boxPlot "xperiod"
            XPeriodAlignment |> DynObj.setValueOptBy boxPlot "xperiodalignment" StyleParam.PeriodAlignment.convert
            XPeriod0 |> DynObj.setValueOpt boxPlot "xperiod0"
            YPeriod |> DynObj.setValueOpt boxPlot "yperiod"
            YPeriodAlignment |> DynObj.setValueOptBy boxPlot "yperiodalignment" StyleParam.PeriodAlignment.convert
            YPeriod0 |> DynObj.setValueOpt boxPlot "yperiod0"
            Marker |> DynObj.setValueOpt boxPlot "marker"
            Line |> DynObj.setValueOpt boxPlot "line"
            BoxMean |> DynObj.setValueOptBy boxPlot "boxmean" StyleParam.BoxMean.convert
            BoxPoints |> DynObj.setValueOptBy boxPlot "boxpoints" StyleParam.BoxPoints.convert
            Notched |> DynObj.setValueOpt boxPlot "notched"
            NotchWidth |> DynObj.setValueOpt boxPlot "notchwidth"
            WhiskerWidth |> DynObj.setValueOpt boxPlot "whiskerwidth"
            ShowWhiskers |> DynObj.setValueOpt boxPlot "showwhiskers"
            Q1 |> DynObj.setValueOpt boxPlot "q1"
            Median |> DynObj.setValueOpt boxPlot "median"
            Q3 |> DynObj.setValueOpt boxPlot "q3"
            LowerFence |> DynObj.setValueOpt boxPlot "lowerfence"
            UpperFence |> DynObj.setValueOpt boxPlot "upperfence"
            NotchSpan |> DynObj.setValueOpt boxPlot "notchspan"
            Mean |> DynObj.setValueOpt boxPlot "mean"
            SD |> DynObj.setValueOpt boxPlot "sd"
            SDMultiple |> DynObj.setValueOpt boxPlot "sdmultiple"
            QuartileMethod |> DynObj.setValueOptBy boxPlot "quartilemethod" StyleParam.QuartileMethod.convert
            SelectedPoints |> DynObj.setValueOpt boxPlot "selectedpoints"
            Selected |> DynObj.setValueOpt boxPlot "selected"
            Unselected |> DynObj.setValueOpt boxPlot "unselected"
            FillColor |> DynObj.setValueOpt boxPlot "fillcolor"
            HoverLabel |> DynObj.setValueOpt boxPlot "hoverlabel"
            HoverOn |> DynObj.setValueOptBy boxPlot "hoveron" StyleParam.HoverOn.convert
            PointPos |> DynObj.setValueOpt boxPlot "pointpos"
            Jitter |> DynObj.setValueOpt boxPlot "jitter"
            SizeMode |> DynObj.setValueOptBy boxPlot "sizemode" StyleParam.BoxSizeMode.convert
            XCalendar |> DynObj.setValueOptBy boxPlot "xcalendar" StyleParam.Calendar.convert
            YCalendar |> DynObj.setValueOptBy boxPlot "ycalendar" StyleParam.Calendar.convert
            UIRevision |> DynObj.setValueOpt boxPlot "uirevision"

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

            Name |> DynObj.setValueOpt violin "name"
            Visible |> DynObj.setValueOptBy violin "visible" StyleParam.Visible.convert
            ShowLegend |> DynObj.setValueOpt violin "showlegend"
            Legend |> DynObj.setValueOptBy violin "legend" StyleParam.SubPlotId.convert
            LegendRank |> DynObj.setValueOpt violin "legendrank"
            LegendGroup |> DynObj.setValueOpt violin "legendgroup"
            LegendGroupTitle |> DynObj.setValueOpt violin "legendgrouptitle"
            Opacity |> DynObj.setValueOpt violin "opacity"
            Ids |> DynObj.setValueOpt violin "ids"
            (X, MultiX) |> DynObj.setSingleOrMultiOpt violin "x"
            X0 |> DynObj.setValueOpt violin "x0"
            DX |> DynObj.setValueOpt violin "dx"
            (Y, MultiY) |> DynObj.setSingleOrMultiOpt violin "y"
            Y0 |> DynObj.setValueOpt violin "y0"
            DY |> DynObj.setValueOpt violin "dy"
            Width |> DynObj.setValueOpt violin "width"
            (Text, MultiText) |> DynObj.setSingleOrMultiOpt violin "text"
            (HoverText, MultiHoverText) |> DynObj.setSingleOrMultiOpt violin "hovertext"
            HoverInfo |> DynObj.setValueOptBy violin "hoverinfo" StyleParam.HoverInfo.convert
            (HoverTemplate, MultiHoverTemplate) |> DynObj.setSingleOrMultiOpt violin "hovertemplate"
            XHoverFormat |> DynObj.setValueOpt violin "xhoverformat"
            YHoverFormat |> DynObj.setValueOpt violin "yhoverformat"
            Meta |> DynObj.setValueOpt violin "meta"
            CustomData |> DynObj.setValueOpt violin "customdata"
            XAxis |> DynObj.setValueOptBy violin "xaxis" StyleParam.LinearAxisId.convert
            YAxis |> DynObj.setValueOptBy violin "yaxis" StyleParam.LinearAxisId.convert
            Orientation |> DynObj.setValueOptBy violin "orientation" StyleParam.Orientation.convert
            AlignmentGroup |> DynObj.setValueOpt violin "alignmentgroup"
            OffsetGroup |> DynObj.setValueOpt violin "offsetgroup"
            Marker |> DynObj.setValueOpt violin "marker"
            Line |> DynObj.setValueOpt violin "line"
            Box |> DynObj.setValueOpt violin "box"
            SelectedPoints |> DynObj.setValueOpt violin "selectedpoints"
            Selected |> DynObj.setValueOpt violin "selected"
            Unselected |> DynObj.setValueOpt violin "unselected"
            BandWidth |> DynObj.setValueOpt violin "bandwidth"
            FillColor |> DynObj.setValueOpt violin "fillcolor"
            HoverLabel |> DynObj.setValueOpt violin "hoverlabel"
            HoverOn |> DynObj.setValueOptBy violin "hoveron" StyleParam.HoverOn.convert
            PointPos |> DynObj.setValueOpt violin "pointpos"
            Jitter |> DynObj.setValueOpt violin "jitter"
            MeanLine |> DynObj.setValueOpt violin "meanline"
            Points |> DynObj.setValueOptBy violin "points" StyleParam.JitterPoints.convert
            ScaleGroup |> DynObj.setValueOpt violin "scalegroup"
            ScaleMode |> DynObj.setValueOptBy violin "scalemode" StyleParam.ScaleMode.convert
            Side |> DynObj.setValueOptBy violin "side" StyleParam.ViolinSide.convert
            Span |> DynObj.setValueOptBy violin "span" StyleParam.Range.convert
            SpanMode |> DynObj.setValueOptBy violin "spanmode" StyleParam.SpanMode.convert
            UIRevision |> DynObj.setValueOpt violin "uirevision"

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

            Name |> DynObj.setValueOpt histogram2D "name"
            Visible |> DynObj.setValueOptBy histogram2D "visible" StyleParam.Visible.convert
            ShowLegend |> DynObj.setValueOpt histogram2D "showlegend"
            Legend |> DynObj.setValueOptBy histogram2D "legend" StyleParam.SubPlotId.convert
            LegendRank |> DynObj.setValueOpt histogram2D "legendrank"
            LegendGroup |> DynObj.setValueOpt histogram2D "legendgroup"
            LegendGroupTitle |> DynObj.setValueOpt histogram2D "legendgrouptitle"
            Opacity |> DynObj.setValueOpt histogram2D "opacity"
            Ids |> DynObj.setValueOpt histogram2D "ids"
            (X, MultiX) |> DynObj.setSingleOrMultiOpt histogram2D "x"
            XGap |> DynObj.setValueOpt histogram2D "xgap"
            (Y, MultiY) |> DynObj.setSingleOrMultiOpt histogram2D "y"
            YGap |> DynObj.setValueOpt histogram2D "ygap"
            Z |> DynObj.setValueOpt histogram2D "z"
            TextTemplate |> DynObj.setValueOpt histogram2D "texttemplate"
            HoverInfo |> DynObj.setValueOptBy histogram2D "hoverinfo" StyleParam.HoverInfo.convert
            (HoverTemplate, MultiHoverTemplate) |> DynObj.setSingleOrMultiOpt histogram2D "hovertemplate"
            XHoverFormat |> DynObj.setValueOpt histogram2D "xhoverformat"
            YHoverFormat |> DynObj.setValueOpt histogram2D "yhoverformat"
            Meta |> DynObj.setValueOpt histogram2D "meta"
            CustomData |> DynObj.setValueOpt histogram2D "customdata"
            XAxis |> DynObj.setValueOptBy histogram2D "xaxis" StyleParam.LinearAxisId.convert
            YAxis |> DynObj.setValueOptBy histogram2D "yaxis" StyleParam.LinearAxisId.convert
            ColorAxis |> DynObj.setValueOpt histogram2D "coloraxis"
            HistFunc |> DynObj.setValueOptBy histogram2D "histfunc" StyleParam.HistFunc.convert
            HistNorm |> DynObj.setValueOptBy histogram2D "histnorm" StyleParam.HistNorm.convert
            NBinsX |> DynObj.setValueOpt histogram2D "nbinsx"
            NBinsY |> DynObj.setValueOpt histogram2D "nbinsy"
            AutoBinX |> DynObj.setValueOpt histogram2D "autobinx"
            AutoBinY |> DynObj.setValueOpt histogram2D "autobiny"
            BinGroup |> DynObj.setValueOpt histogram2D "bingroup"
            XBinGroup |> DynObj.setValueOpt histogram2D "xbingroup"
            XBins |> DynObj.setValueOpt histogram2D "xbins"
            YBinGroup |> DynObj.setValueOpt histogram2D "ybingroup"
            YBins |> DynObj.setValueOpt histogram2D "ybins"
            Marker |> DynObj.setValueOpt histogram2D "marker"
            TextFont |> DynObj.setValueOpt histogram2D "textfont"
            ColorBar |> DynObj.setValueOpt histogram2D "colorbar"
            AutoColorScale |> DynObj.setValueOpt histogram2D "autocolorscale"
            ColorScale |> DynObj.setValueOptBy histogram2D "colorscale" StyleParam.Colorscale.convert
            ShowScale |> DynObj.setValueOpt histogram2D "showscale"
            ReverseScale |> DynObj.setValueOpt histogram2D "reversescale"
            ZAuto |> DynObj.setValueOpt histogram2D "zauto"
            ZHoverFormat |> DynObj.setValueOpt histogram2D "zhoverformat"
            ZMin |> DynObj.setValueOpt histogram2D "zmin"
            ZMid |> DynObj.setValueOpt histogram2D "zmid"
            ZMax |> DynObj.setValueOpt histogram2D "zmax"
            ZSmooth |> DynObj.setValueOptBy histogram2D "zsmooth" StyleParam.SmoothAlg.convert
            HoverLabel |> DynObj.setValueOpt histogram2D "hoverlabel"
            XCalendar |> DynObj.setValueOptBy histogram2D "xcalendar" StyleParam.Calendar.convert
            YCalendar |> DynObj.setValueOptBy histogram2D "ycalendar" StyleParam.Calendar.convert
            UIRevision |> DynObj.setValueOpt histogram2D "uirevision"

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

            Name |> DynObj.setValueOpt histogram2DContour "name"
            Visible |> DynObj.setValueOptBy histogram2DContour "visible" StyleParam.Visible.convert
            ShowLegend |> DynObj.setValueOpt histogram2DContour "showlegend"
            Legend |> DynObj.setValueOptBy histogram2DContour "legend" StyleParam.SubPlotId.convert
            LegendRank |> DynObj.setValueOpt histogram2DContour "legendrank"
            LegendGroup |> DynObj.setValueOpt histogram2DContour "legendgroup"
            LegendGroupTitle |> DynObj.setValueOpt histogram2DContour "legendgrouptitle"
            Opacity |> DynObj.setValueOpt histogram2DContour "opacity"
            Ids |> DynObj.setValueOpt histogram2DContour "ids"
            (X, MultiX) |> DynObj.setSingleOrMultiOpt histogram2DContour "x"
            (Y, MultiY) |> DynObj.setSingleOrMultiOpt histogram2DContour "y"
            Z |> DynObj.setValueOpt histogram2DContour "z"
            TextTemplate |> DynObj.setValueOpt histogram2DContour "texttemplate"
            HoverInfo |> DynObj.setValueOptBy histogram2DContour "hoverinfo" StyleParam.HoverInfo.convert
            (HoverTemplate, MultiHoverTemplate) |> DynObj.setSingleOrMultiOpt histogram2DContour "hovertemplate"
            XHoverFormat |> DynObj.setValueOpt histogram2DContour "xhoverformat"
            YHoverFormat |> DynObj.setValueOpt histogram2DContour "yhoverformat"
            Meta |> DynObj.setValueOpt histogram2DContour "meta"
            CustomData |> DynObj.setValueOpt histogram2DContour "customdata"
            XAxis |> DynObj.setValueOptBy histogram2DContour "xaxis" StyleParam.LinearAxisId.convert
            YAxis |> DynObj.setValueOptBy histogram2DContour "yaxis" StyleParam.LinearAxisId.convert
            ColorAxis |> DynObj.setValueOpt histogram2DContour "coloraxis"
            HistFunc |> DynObj.setValueOptBy histogram2DContour "histfunc" StyleParam.HistFunc.convert
            HistNorm |> DynObj.setValueOptBy histogram2DContour "histnorm" StyleParam.HistNorm.convert
            NBinsX |> DynObj.setValueOpt histogram2DContour "nbinsx"
            NBinsY |> DynObj.setValueOpt histogram2DContour "nbinsy"
            AutoBinX |> DynObj.setValueOpt histogram2DContour "autobinx"
            AutoBinY |> DynObj.setValueOpt histogram2DContour "autobiny"
            BinGroup |> DynObj.setValueOpt histogram2DContour "bingroup"
            XBinGroup |> DynObj.setValueOpt histogram2DContour "xbingroup"
            XBins |> DynObj.setValueOpt histogram2DContour "xbins"
            YBinGroup |> DynObj.setValueOpt histogram2DContour "ybingroup"
            YBins |> DynObj.setValueOpt histogram2DContour "ybins"
            Marker |> DynObj.setValueOpt histogram2DContour "marker"
            Line |> DynObj.setValueOpt histogram2DContour "line"
            TextFont |> DynObj.setValueOpt histogram2DContour "textfont"
            ColorBar |> DynObj.setValueOpt histogram2DContour "colorbar"
            AutoColorScale |> DynObj.setValueOpt histogram2DContour "autocolorscale"
            ColorScale |> DynObj.setValueOptBy histogram2DContour "colorscale" StyleParam.Colorscale.convert
            ShowScale |> DynObj.setValueOpt histogram2DContour "showscale"
            ReverseScale |> DynObj.setValueOpt histogram2DContour "reversescale"
            ZAuto |> DynObj.setValueOpt histogram2DContour "zauto"
            ZHoverFormat |> DynObj.setValueOpt histogram2DContour "zhoverformat"
            Zmin |> DynObj.setValueOpt histogram2DContour "zmin"
            Zmid |> DynObj.setValueOpt histogram2DContour "zmid"
            Zmax |> DynObj.setValueOpt histogram2DContour "zmax"
            AutoContour |> DynObj.setValueOpt histogram2DContour "autocontour"
            Contours |> DynObj.setValueOpt histogram2DContour "contours"
            HoverLabel |> DynObj.setValueOpt histogram2DContour "hoverlabel"
            NContours |> DynObj.setValueOpt histogram2DContour "ncontours"
            XCalendar |> DynObj.setValueOptBy histogram2DContour "xcalendar" StyleParam.Calendar.convert
            YCalendar |> DynObj.setValueOptBy histogram2DContour "ycalendar" StyleParam.Calendar.convert
            UIRevision |> DynObj.setValueOpt histogram2DContour "uirevision"

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

            Name |> DynObj.setValueOpt heatmap "name"
            Visible |> DynObj.setValueOptBy heatmap "visible" StyleParam.Visible.convert
            ShowLegend |> DynObj.setValueOpt heatmap "showlegend"
            Legend |> DynObj.setValueOptBy heatmap "legend" StyleParam.SubPlotId.convert
            LegendRank |> DynObj.setValueOpt heatmap "legendrank"
            LegendGroup |> DynObj.setValueOpt heatmap "legendgroup"
            LegendGroupTitle |> DynObj.setValueOpt heatmap "legendgrouptitle"
            Opacity |> DynObj.setValueOpt heatmap "opacity"
            Ids |> DynObj.setValueOpt heatmap "ids"
            (X, MultiX) |> DynObj.setSingleOrMultiOpt heatmap "x"
            X0 |> DynObj.setValueOpt heatmap "x0"
            DX |> DynObj.setValueOpt heatmap "dx"
            XType |> DynObj.setValueOptBy heatmap "xtype" StyleParam.CoordinateType.convert
            XGap |> DynObj.setValueOpt heatmap "xgap"
            (Y, MultiY) |> DynObj.setSingleOrMultiOpt heatmap "y"
            Y0 |> DynObj.setValueOpt heatmap "y0"
            DY |> DynObj.setValueOpt heatmap "dy"
            YType |> DynObj.setValueOptBy heatmap "ytype" StyleParam.CoordinateType.convert
            YGap |> DynObj.setValueOpt heatmap "ygap"
            Z |> DynObj.setValueOpt heatmap "z"
            (Text, MultiText) |> DynObj.setSingleOrMultiOpt heatmap "text"
            TextTemplate |> DynObj.setValueOpt heatmap "texttemplate"
            (HoverText, MultiHoverText) |> DynObj.setSingleOrMultiOpt heatmap "hovertext"
            HoverInfo |> DynObj.setValueOptBy heatmap "hoverinfo" StyleParam.HoverInfo.convert
            (HoverTemplate, MultiHoverTemplate) |> DynObj.setSingleOrMultiOpt heatmap "hovertemplate"
            XHoverFormat |> DynObj.setValueOpt heatmap "xhoverformat"
            YHoverFormat |> DynObj.setValueOpt heatmap "yhoverformat"
            Meta |> DynObj.setValueOpt heatmap "meta"
            CustomData |> DynObj.setValueOpt heatmap "customdata"
            XAxis |> DynObj.setValueOptBy heatmap "xaxis" StyleParam.LinearAxisId.convert
            YAxis |> DynObj.setValueOptBy heatmap "yaxis" StyleParam.LinearAxisId.convert
            ColorAxis |> DynObj.setValueOptBy heatmap "coloraxis" StyleParam.SubPlotId.convert
            XPeriod |> DynObj.setValueOpt heatmap "xperiod"
            XPeriodAlignment |> DynObj.setValueOptBy heatmap "xperiodalignment" StyleParam.PeriodAlignment.convert
            XPeriod0 |> DynObj.setValueOpt heatmap "xperiod0"
            YPeriod |> DynObj.setValueOpt heatmap "yperiod"
            YPeriodAlignment |> DynObj.setValueOptBy heatmap "yperiodalignment" StyleParam.PeriodAlignment.convert
            YPeriod0 |> DynObj.setValueOpt heatmap "yperiod0"
            TextFont |> DynObj.setValueOpt heatmap "textfont"
            ColorBar |> DynObj.setValueOpt heatmap "colorbar"
            AutoColorScale |> DynObj.setValueOpt heatmap "autocolorscale"
            ColorScale |> DynObj.setValueOptBy heatmap "colorscale" StyleParam.Colorscale.convert
            ShowScale |> DynObj.setValueOpt heatmap "showscale"
            ReverseScale |> DynObj.setValueOpt heatmap "reversescale"
            ZAuto |> DynObj.setValueOpt heatmap "zauto"
            ZHoverFormat |> DynObj.setValueOpt heatmap "zhoverformat"
            ZMax |> DynObj.setValueOpt heatmap "zmax"
            ZMid |> DynObj.setValueOpt heatmap "zmid"
            ZMin |> DynObj.setValueOpt heatmap "zmin"
            ZSmooth |> DynObj.setValueOptBy heatmap "zsmooth" StyleParam.SmoothAlg.convert
            ConnectGaps |> DynObj.setValueOpt heatmap "connectgaps"
            HoverLabel |> DynObj.setValueOpt heatmap "hoverlabel"
            HoverOnGaps |> DynObj.setValueOpt heatmap "hoverongaps"
            Transpose |> DynObj.setValueOpt heatmap "transpose"
            XCalendar |> DynObj.setValueOptBy heatmap "xcalendar" StyleParam.Calendar.convert
            YCalendar |> DynObj.setValueOptBy heatmap "ycalendar" StyleParam.Calendar.convert
            UIRevision |> DynObj.setValueOpt heatmap "uirevision"


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

            Name |> DynObj.setValueOpt image "name"
            Visible |> DynObj.setValueOptBy image "visible" StyleParam.Visible.convert
            ShowLegend |> DynObj.setValueOpt image "showlegend"
            Legend |> DynObj.setValueOptBy image "legend" StyleParam.SubPlotId.convert
            LegendRank |> DynObj.setValueOpt image "legendrank"
            LegendGroup |> DynObj.setValueOpt image "legendgroup"
            LegendGroupTitle |> DynObj.setValueOpt image "legendgrouptitle"
            Opacity |> DynObj.setValueOpt image "opacity"
            Ids |> DynObj.setValueOpt image "ids"
            X0 |> DynObj.setValueOpt image "x0"
            DX |> DynObj.setValueOpt image "dx"
            Y0 |> DynObj.setValueOpt image "y0"
            DY |> DynObj.setValueOpt image "dy"
            Z |> DynObj.setValueOpt image "z"
            Source |> DynObj.setValueOpt image "source"
            (Text, MultiText) |> DynObj.setSingleOrMultiOpt image "text"
            (HoverText, MultiHoverText) |> DynObj.setSingleOrMultiOpt image "hovertext"
            HoverInfo |> DynObj.setValueOptBy image "hoverinfo" StyleParam.HoverInfo.convert
            (HoverTemplate, MultiHoverTemplate) |> DynObj.setSingleOrMultiOpt image "hovertemplate"
            Meta |> DynObj.setValueOpt image "meta"
            CustomData |> DynObj.setValueOpt image "customdata"
            XAxis |> DynObj.setValueOptBy image "xaxis" StyleParam.LinearAxisId.convert
            YAxis |> DynObj.setValueOptBy image "yaxis" StyleParam.LinearAxisId.convert
            ColorModel |> DynObj.setValueOptBy image "colormodel" StyleParam.ColorModel.convert
            ZMax |> DynObj.setValueOptBy image "zmax" StyleParam.ColorComponentBound.convert
            ZMin |> DynObj.setValueOptBy image "zmin" StyleParam.ColorComponentBound.convert
            ZSmooth |> DynObj.setValueOptBy image "zsmooth" StyleParam.SmoothAlg.convert
            HoverLabel |> DynObj.setValueOpt image "hoverlabel"
            UIRevision |> DynObj.setValueOpt image "uirevision"

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

            Name |> DynObj.setValueOpt contour "name"
            Visible |> DynObj.setValueOptBy contour "visible" StyleParam.Visible.convert
            ShowLegend |> DynObj.setValueOpt contour "showlegend"
            Legend |> DynObj.setValueOptBy contour "legend" StyleParam.SubPlotId.convert
            LegendRank |> DynObj.setValueOpt contour "legendrank"
            LegendGroup |> DynObj.setValueOpt contour "legendgroup"
            LegendGroupTitle |> DynObj.setValueOpt contour "legendgrouptitle"
            Opacity |> DynObj.setValueOpt contour "opacity"
            Ids |> DynObj.setValueOpt contour "ids"
            (X, MultiX) |> DynObj.setSingleOrMultiOpt contour "x"
            X0 |> DynObj.setValueOpt contour "x0"
            DX |> DynObj.setValueOpt contour "dx"
            XType |> DynObj.setValueOptBy contour "xtype" StyleParam.CoordinateType.convert
            (Y, MultiY) |> DynObj.setSingleOrMultiOpt contour "y"
            Y0 |> DynObj.setValueOpt contour "y0"
            DY |> DynObj.setValueOpt contour "dy"
            YType |> DynObj.setValueOptBy contour "ytype" StyleParam.CoordinateType.convert
            Z |> DynObj.setValueOpt contour "z"
            TextTemplate |> DynObj.setValueOpt contour "texttemplate"
            (Text, MultiText) |> DynObj.setSingleOrMultiOpt contour "text"
            (HoverText, MultiHoverText) |> DynObj.setSingleOrMultiOpt contour "hovertext"
            HoverInfo |> DynObj.setValueOptBy contour "hoverinfo" StyleParam.HoverInfo.convert
            (HoverTemplate, MultiHoverTemplate) |> DynObj.setSingleOrMultiOpt contour "hovertemplate"
            XHoverFormat |> DynObj.setValueOpt contour "xhoverformat"
            YHoverFormat |> DynObj.setValueOpt contour "yhoverformat"
            Meta |> DynObj.setValueOpt contour "meta"
            CustomData |> DynObj.setValueOpt contour "customdata"
            XAxis |> DynObj.setValueOptBy contour "xaxis" StyleParam.LinearAxisId.convert
            YAxis |> DynObj.setValueOptBy contour "yaxis" StyleParam.LinearAxisId.convert
            ColorAxis |> DynObj.setValueOptBy contour "coloraxis" StyleParam.SubPlotId.convert
            XPeriod |> DynObj.setValueOpt contour "xperiod"
            XPeriodAlignment |> DynObj.setValueOptBy contour "xperiodalignment" StyleParam.PeriodAlignment.convert
            XPeriod0 |> DynObj.setValueOpt contour "xperiod0"
            YPeriod |> DynObj.setValueOpt contour "yperiod"
            YPeriodAlignment |> DynObj.setValueOptBy contour "yperiodalignment" StyleParam.PeriodAlignment.convert
            YPeriod0 |> DynObj.setValueOpt contour "yperiod0"
            Line |> DynObj.setValueOpt contour "line"
            TextFont |> DynObj.setValueOpt contour "textfont"
            ColorBar |> DynObj.setValueOpt contour "colorbar"
            AutoColorScale |> DynObj.setValueOpt contour "autocolorscale"
            ColorScale |> DynObj.setValueOptBy contour "colorscale" StyleParam.Colorscale.convert
            ShowScale |> DynObj.setValueOpt contour "showscale"
            ReverseScale |> DynObj.setValueOpt contour "reversescale"
            ZAuto |> DynObj.setValueOpt contour "zauto"
            ZHoverFormat |> DynObj.setValueOpt contour "zhoverformat"
            ZMax |> DynObj.setValueOpt contour "zmax"
            ZMid |> DynObj.setValueOpt contour "zmid"
            ZMin |> DynObj.setValueOpt contour "zmin"
            AutoContour |> DynObj.setValueOpt contour "autocontour"
            ConnectGaps |> DynObj.setValueOpt contour "connectgaps"
            Contours |> DynObj.setValueOpt contour "contours"
            FillColor |> DynObj.setValueOpt contour "fillcolor"
            HoverLabel |> DynObj.setValueOpt contour "hoverlabel"
            HoverOnGaps |> DynObj.setValueOpt contour "hoverongaps"
            NContours |> DynObj.setValueOpt contour "ncontours"
            Transpose |> DynObj.setValueOpt contour "transpose"
            XCalendar |> DynObj.setValueOptBy contour "xcalendar" StyleParam.Calendar.convert
            UIRevision |> DynObj.setValueOpt contour "uirevision"


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

            Name |> DynObj.setValueOpt ohlc "name"
            Visible |> DynObj.setValueOptBy ohlc "visible" StyleParam.Visible.convert
            ShowLegend |> DynObj.setValueOpt ohlc "showlegend"
            Legend |> DynObj.setValueOptBy ohlc "legend" StyleParam.SubPlotId.convert
            LegendRank |> DynObj.setValueOpt ohlc "legendrank"
            LegendGroup |> DynObj.setValueOpt ohlc "legendgroup"
            LegendGroupTitle |> DynObj.setValueOpt ohlc "legendgrouptitle"
            Opacity |> DynObj.setValueOpt ohlc "opacity"
            Ids |> DynObj.setValueOpt ohlc "ids"
            (X, MultiX) |> DynObj.setSingleOrMultiOpt ohlc "x"
            Close |> DynObj.setValueOpt ohlc "close"
            Open |> DynObj.setValueOpt ohlc "open"
            High |> DynObj.setValueOpt ohlc "high"
            Low |> DynObj.setValueOpt ohlc "low"
            (Text, MultiText) |> DynObj.setSingleOrMultiOpt ohlc "text"
            (HoverText, MultiHoverText) |> DynObj.setSingleOrMultiOpt ohlc "hovertext"
            HoverInfo |> DynObj.setValueOptBy ohlc "hoverinfo" StyleParam.HoverInfo.convert
            XHoverFormat |> DynObj.setValueOpt ohlc "xhoverformat"
            YHoverFormat |> DynObj.setValueOpt ohlc "yhoverformat"
            Meta |> DynObj.setValueOpt ohlc "meta"
            CustomData |> DynObj.setValueOpt ohlc "customdata"
            XAxis |> DynObj.setValueOptBy ohlc "xaxis" StyleParam.LinearAxisId.convert
            YAxis |> DynObj.setValueOptBy ohlc "yaxis" StyleParam.LinearAxisId.convert
            XPeriod |> DynObj.setValueOpt ohlc "xperiod"
            XPeriodAlignment |> DynObj.setValueOptBy ohlc "xperiodalignment" StyleParam.PeriodAlignment.convert
            XPeriod0 |> DynObj.setValueOpt ohlc "xperiod0"
            YPeriod |> DynObj.setValueOpt ohlc "yperiod"
            YPeriodAlignment |> DynObj.setValueOptBy ohlc "yperiodalignment" StyleParam.PeriodAlignment.convert
            YPeriod0 |> DynObj.setValueOpt ohlc "yperiod0"
            Line |> DynObj.setValueOpt ohlc "line"
            Increasing |> DynObj.setValueOpt ohlc "increasing"
            Decreasing |> DynObj.setValueOpt ohlc "decreasing"
            HoverLabel |> DynObj.setValueOpt ohlc "hoverlabel"
            TickWidth |> DynObj.setValueOpt ohlc "tickwidth"
            XCalendar |> DynObj.setValueOptBy ohlc "xcalendar" StyleParam.Calendar.convert
            UIRevision |> DynObj.setValueOpt ohlc "uirevision"

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

            Name |> DynObj.setValueOpt trace "name"
            Visible |> DynObj.setValueOptBy trace "visible" StyleParam.Visible.convert
            ShowLegend |> DynObj.setValueOpt trace "showlegend"
            Legend |> DynObj.setValueOptBy trace "legend" StyleParam.SubPlotId.convert
            LegendRank |> DynObj.setValueOpt trace "legendrank"
            LegendGroup |> DynObj.setValueOpt trace "legendgroup"
            LegendGroupTitle |> DynObj.setValueOpt trace "legendgrouptitle"
            Opacity |> DynObj.setValueOpt trace "opacity"
            Ids |> DynObj.setValueOpt trace "ids"
            (X, MultiX) |> DynObj.setSingleOrMultiOpt trace "x"
            Close |> DynObj.setValueOpt trace "close"
            Open |> DynObj.setValueOpt trace "open"
            High |> DynObj.setValueOpt trace "high"
            Low |> DynObj.setValueOpt trace "low"
            (Text, MultiText) |> DynObj.setSingleOrMultiOpt trace "text"
            (HoverText, MultiHoverText) |> DynObj.setSingleOrMultiOpt trace "hovertext"
            HoverInfo |> DynObj.setValueOptBy trace "hoverinfo" StyleParam.HoverInfo.convert
            XHoverFormat |> DynObj.setValueOpt trace "xhoverformat"
            YHoverFormat |> DynObj.setValueOpt trace "yhoverformat"
            Meta |> DynObj.setValueOpt trace "meta"
            CustomData |> DynObj.setValueOpt trace "customdata"
            XAxis |> DynObj.setValueOptBy trace "xaxis" StyleParam.LinearAxisId.convert
            YAxis |> DynObj.setValueOptBy trace "yaxis" StyleParam.LinearAxisId.convert
            XPeriod |> DynObj.setValueOpt trace "xperiod"
            XPeriodAlignment |> DynObj.setValueOptBy trace "xperiodalignment" StyleParam.PeriodAlignment.convert
            XPeriod0 |> DynObj.setValueOpt trace "xperiod0"
            YPeriod |> DynObj.setValueOpt trace "yperiod"
            YPeriodAlignment |> DynObj.setValueOptBy trace "yperiodalignment" StyleParam.PeriodAlignment.convert
            YPeriod0 |> DynObj.setValueOpt trace "yperiod0"
            Line |> DynObj.setValueOpt trace "line"
            WhiskerWidth |> DynObj.setValueOpt trace "whiskerwidth"
            Increasing |> DynObj.setValueOpt trace "increasing"
            Decreasing |> DynObj.setValueOpt trace "decreasing"
            HoverLabel |> DynObj.setValueOpt trace "hoverlabel"
            XCalendar |> DynObj.setValueOptBy trace "xcalendar" StyleParam.Calendar.convert
            UIRevision |> DynObj.setValueOpt trace "uirevision"

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

            Name |> DynObj.setValueOpt trace "name"
            Visible |> DynObj.setValueOptBy trace "visible" StyleParam.Visible.convert
            ShowLegend |> DynObj.setValueOpt trace "showlegend"
            Legend |> DynObj.setValueOptBy trace "legend" StyleParam.SubPlotId.convert
            LegendRank |> DynObj.setValueOpt trace "legendrank"
            LegendGroup |> DynObj.setValueOpt trace "legendgroup"
            LegendGroupTitle |> DynObj.setValueOpt trace "legendgrouptitle"
            Opacity |> DynObj.setValueOpt trace "opacity"
            Ids |> DynObj.setValueOpt trace "ids"
            (Text, MultiText) |> DynObj.setSingleOrMultiOpt trace "text"
            Dimensions |> DynObj.setValueOpt trace "dimensions"
            (HoverText, MultiHoverText) |> DynObj.setSingleOrMultiOpt trace "hovertext"
            HoverInfo |> DynObj.setValueOptBy trace "hoverinfo" StyleParam.HoverInfo.convert
            (HoverTemplate, MultiHoverTemplate) |> DynObj.setSingleOrMultiOpt trace "hovertemplate"
            XHoverFormat |> DynObj.setValueOpt trace "xhoverformat"
            YHoverFormat |> DynObj.setValueOpt trace "yhoverformat"
            Meta |> DynObj.setValueOpt trace "meta"
            CustomData |> DynObj.setValueOpt trace "customdata"
            Marker |> DynObj.setValueOpt trace "marker"
            Diagonal |> DynObj.setValueOpt trace "diagonal"
            XAxes |> DynObj.setValueOptBy trace "xaxis" (Seq.map StyleParam.LinearAxisId.convert)
            YAxes |> DynObj.setValueOptBy trace "yaxis" (Seq.map StyleParam.LinearAxisId.convert)
            ShowLowerHalf |> DynObj.setValueOpt trace "showlowerhalf"
            ShowUpperHalf |> DynObj.setValueOpt trace "showupperhalf"
            SelectedPoints |> DynObj.setValueOpt trace "selectedpoints"
            Selected |> DynObj.setValueOpt trace "selected"
            Unselected |> DynObj.setValueOpt trace "unselected"
            HoverLabel |> DynObj.setValueOpt trace "hoverlabel"
            UIRevision |> DynObj.setValueOpt trace "uirevision"

            trace)
