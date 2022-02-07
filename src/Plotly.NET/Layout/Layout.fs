namespace Plotly.NET

open DynamicObj
open Plotly.NET.LayoutObjects
open System
open System.Runtime.InteropServices

/// A Layout object in the context of plotly charts contains all styling options that are not directly related to the visualization of the data itself, such as axes, legends, watermarks, etc.
type Layout() =
    inherit DynamicObj()

    /// <summary>
    /// Returns a new Layout object with the given styling.
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
    static member init
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
        Layout()
        |> Layout.style (
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

    /// <summary>
    /// Returns a function that applies the given styles to a Layout object.
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
    static member style
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
        (fun (layout: Layout) ->

            Title |> DynObj.setValueOpt layout "title"
            ShowLegend |> DynObj.setValueOpt layout "showlegend"
            Legend |> DynObj.setValueOpt layout "legend"
            Margin |> DynObj.setValueOpt layout "margin"
            AutoSize |> DynObj.setValueOpt layout "autosize"
            Width |> DynObj.setValueOpt layout "width"
            Height |> DynObj.setValueOpt layout "height"
            Font |> DynObj.setValueOpt layout "font"
            UniformText |> DynObj.setValueOpt layout "uniformtext"
            Separators |> DynObj.setValueOpt layout "separators"
            PaperBGColor |> DynObj.setValueOpt layout "paper_bgcolor"
            PlotBGColor |> DynObj.setValueOpt layout "plot_bgcolor"
            AutoTypeNumbers |> DynObj.setValueOptBy layout "autotypenumbers" StyleParam.AutoTypeNumbers.convert
            Colorscale |> DynObj.setValueOpt layout "colorscale"
            Colorway |> DynObj.setValueOpt layout "colorway"
            ModeBar |> DynObj.setValueOpt layout "modebar"
            HoverMode |> DynObj.setValueOptBy layout "hovermode" StyleParam.HoverMode.convert
            ClickMode |> DynObj.setValueOptBy layout "clickmode" StyleParam.ClickMode.convert
            DragMode |> DynObj.setValueOptBy layout "dragmode" StyleParam.DragMode.convert
            SelectDirection |> DynObj.setValueOptBy layout "selectdirection" StyleParam.SelectDirection.convert
            HoverDistance |> DynObj.setValueOpt layout "hoverdistance"
            SpikeDistance |> DynObj.setValueOpt layout "spikedistance"
            Hoverlabel |> DynObj.setValueOpt layout "hoverlabel"
            Transition |> DynObj.setValueOpt layout "transition"
            DataRevision |> DynObj.setValueOpt layout "datarevision"
            UIRevision |> DynObj.setValueOpt layout "uirevision"
            EditRevision |> DynObj.setValueOpt layout "editrevision"
            SelectRevision |> DynObj.setValueOpt layout "selectrevision"
            Template |> DynObj.setValueOpt layout "template"
            Meta |> DynObj.setValueOpt layout "meta"
            Computed |> DynObj.setValueOpt layout "computed"
            Grid |> DynObj.setValueOpt layout "grid"
            Calendar |> DynObj.setValueOptBy layout "calendar" StyleParam.Calendar.convert
            NewShape |> DynObj.setValueOpt layout "newshape"
            ActiveShape |> DynObj.setValueOpt layout "activeshape"
            HideSources |> DynObj.setValueOpt layout "hidesources"
            BarGap |> DynObj.setValueOpt layout "bargap"
            BarGroupGap |> DynObj.setValueOpt layout "bargroupgap"
            BarMode |> DynObj.setValueOptBy layout "barmode" StyleParam.BarMode.convert
            BarNorm |> DynObj.setValueOptBy layout "barnorm" StyleParam.BarNorm.convert
            ExtendPieColors |> DynObj.setValueOpt layout "extendpiecolors"
            HiddenLabels |> DynObj.setValueOpt layout "hiddenlabels"
            PieColorWay |> DynObj.setValueOpt layout "piecolorway"
            BoxGap |> DynObj.setValueOpt layout "boxgap"
            BoxGroupGap |> DynObj.setValueOpt layout "boxgroupgap"
            BoxMode |> DynObj.setValueOptBy layout "boxmode" StyleParam.BoxMode.convert
            ViolinGap |> DynObj.setValueOpt layout "violingap"
            ViolinGroupGap |> DynObj.setValueOpt layout "violingroupgap"
            ViolinMode |> DynObj.setValueOptBy layout "violinmode" StyleParam.ViolinMode.convert
            WaterfallGap |> DynObj.setValueOpt layout "waterfallgap"
            WaterfallGroupGap |> DynObj.setValueOpt layout "waterfallgroupgap"
            WaterfallMode |> DynObj.setValueOptBy layout "waterfallmode" StyleParam.WaterfallMode.convert
            FunnelGap |> DynObj.setValueOpt layout "funnelgap"
            FunnelGroupGap |> DynObj.setValueOpt layout "funnelgroupgap"
            FunnelMode |> DynObj.setValueOptBy layout "funnelmode" StyleParam.FunnelMode.convert
            ExtendFunnelAreaColors |> DynObj.setValueOpt layout "extendfunnelareacolors "
            FunnelAreaColorWay |> DynObj.setValueOpt layout "funnelareacolorway"
            ExtendSunBurstColors |> DynObj.setValueOpt layout "extendsunburstcolors"
            SunBurstColorWay |> DynObj.setValueOpt layout "sunburstcolorway"
            ExtendTreeMapColors |> DynObj.setValueOpt layout "extendtreemapcolors"
            TreeMapColorWay |> DynObj.setValueOpt layout "treemapcolorway"
            ExtendIcicleColors |> DynObj.setValueOpt layout "extendiciclecolors"
            IcicleColorWay |> DynObj.setValueOpt layout "iciclecolorway"
            Annotations |> DynObj.setValueOpt layout "annotations"
            Shapes |> DynObj.setValueOpt layout "shapes"
            Images |> DynObj.setValueOpt layout "images"
            Sliders |> DynObj.setValueOpt layout "sliders"
            UpdateMenus |> DynObj.setValueOpt layout "updatemenus"

            layout)


    /// <summary>
    /// Returns Some(dynamic member value) of the trace object's underlying DynamicObj when a dynamic member eith the given name exists, and None otherwise.
    /// </summary>
    /// <param name="propName">The name of the dynamic member to get the value of</param>
    /// <param name="layout">The layout to get the dynamic member value from</param>
    static member tryGetTypedMember<'T> (propName: string) (layout: Layout) = layout.TryGetTypedValue<'T>(propName)

    /// <summary>
    /// Returns Some(LinearAxis) if there is an axis object set on the layout with the given id, and None otherwise.
    /// </summary>
    /// <param name="id">The target axis id</param>
    static member tryGetLinearAxisById(id: StyleParam.SubPlotId) =
        (fun (layout: Layout) -> layout.TryGetTypedValue<LinearAxis>(StyleParam.SubPlotId.toString id))

    /// <summary>
    /// Combines the given axis object with the one already present on the layout.
    /// </summary>
    /// <param name="id">The target axis id</param>
    /// <param name="axis">The updated axis object.</param>
    static member updateLinearAxisById(id: StyleParam.SubPlotId, axis: LinearAxis) =
        (fun (layout: Layout) ->

            match id with
            | StyleParam.SubPlotId.XAxis _
            | StyleParam.SubPlotId.YAxis _ ->

                let axis' =
                    match Layout.tryGetLinearAxisById id layout with
                    | Some a -> (DynObj.combine a axis) :?> LinearAxis
                    | None -> axis

                axis' |> DynObj.setValue layout (StyleParam.SubPlotId.toString id)

                layout
            | _ ->
                failwith
                    $"{StyleParam.SubPlotId.toString id} is an invalid subplot id for setting a linear axis on layout")

    /// <summary>
    /// Returns the linear axis object of the layout with the given id.
    ///
    /// If there is no linear axis set, returns an empty LinearAxis object.
    /// </summary>
    /// <param name="id">The target axis id</param>
    static member getLinearAxisById(id: StyleParam.SubPlotId) =
        (fun (layout: Layout) -> layout |> Layout.tryGetLinearAxisById id |> Option.defaultValue (LinearAxis.init ()))

    /// <summary>
    /// Sets a linear axis object on the layout as a dynamic property with the given axis id.
    /// </summary>
    /// <param name="id">The axis id of the new axis</param>
    /// <param name="axis">The axis to add to the layout.</param>
    static member setLinearAxis(id: StyleParam.SubPlotId, axis: LinearAxis) =
        (fun (layout: Layout) ->

            match id with
            | StyleParam.SubPlotId.XAxis _
            | StyleParam.SubPlotId.YAxis _ ->
                axis |> DynObj.setValue layout (StyleParam.SubPlotId.toString id)
                layout

            | _ ->
                failwith
                    $"{StyleParam.SubPlotId.toString id} is an invalid subplot id for setting a linear axis on layout")

    /// <summary>
    /// Returns Some(Scene) if there is a scene object set on the layout with the given id, and None otherwise.
    /// </summary>
    /// <param name="id">The target scene id</param>
    static member tryGetSceneById(id: StyleParam.SubPlotId) =
        (fun (layout: Layout) -> layout.TryGetTypedValue<Scene>(StyleParam.SubPlotId.toString id))

    /// <summary>
    /// Combines the given scene object with the one already present on the layout.
    /// </summary>
    /// <param name="id">The target scene id</param>
    /// <param name="scene">The updated scene object.</param>
    static member updateSceneById(id: StyleParam.SubPlotId, scene: Scene) =
        (fun (layout: Layout) ->
            let scene' =
                match Layout.tryGetSceneById id layout with
                | Some a -> (DynObj.combine a scene) :?> Scene
                | None -> scene

            scene' |> DynObj.setValue layout (StyleParam.SubPlotId.toString id)
            layout)

    /// <summary>
    /// Returns the Scene object of the layout with the given id.
    ///
    /// If there is no scene set, returns an empty Scene object.
    /// </summary>
    /// <param name="id">The target scene id</param>
    static member getSceneById(id: StyleParam.SubPlotId) =
        (fun (layout: Layout) -> layout |> Layout.tryGetSceneById id |> Option.defaultValue (Scene.init ()))

    /// <summary>
    /// Sets a scene object on the layout as a dynamic property with the given scene id.
    /// </summary>
    /// <param name="id">The scene id of the new scene</param>
    /// <param name="scene">The scene to add to the layout.</param>
    static member setScene(id: StyleParam.SubPlotId, scene: Scene) =
        (fun (layout: Layout) ->
            scene |> DynObj.setValue layout (StyleParam.SubPlotId.toString id)
            layout)

    /// <summary>
    /// Returns Some(Geo) if there is a geo object set on the layout with the given id, and None otherwise.
    /// </summary>
    /// <param name="id">The target geo id</param>
    static member tryGetGeoById(id: StyleParam.SubPlotId) =
        (fun (layout: Layout) -> layout.TryGetTypedValue<Geo>(StyleParam.SubPlotId.toString id))

    /// <summary>
    /// Combines the given geo object with the one already present on the layout.
    /// </summary>
    /// <param name="id">The target geo id</param>
    /// <param name="geo">The updated geo object.</param>
    static member updateGeoById(id: StyleParam.SubPlotId, geo: Geo) =
        (fun (layout: Layout) ->
            let geo' =
                match Layout.tryGetGeoById id layout with
                | Some a -> (DynObj.combine a geo) :?> Geo
                | None -> geo

            geo' |> DynObj.setValue layout (StyleParam.SubPlotId.toString id)
            layout)

    /// <summary>
    /// Returns the Geo object of the layout with the given id.
    ///
    /// If there is no geo set, returns an empty Geo object.
    /// </summary>
    /// <param name="id">The target geo id</param>
    static member getGeoById(id: StyleParam.SubPlotId) =
        (fun (layout: Layout) -> layout |> Layout.tryGetGeoById id |> Option.defaultValue (Geo.init ()))

    /// <summary>
    /// Sets a geo object on the layout as a dynamic property with the given geo id.
    /// </summary>
    /// <param name="id">The scene id of the new geo</param>
    /// <param name="geo">The geo to add to the layout.</param>
    static member setGeo(id: StyleParam.SubPlotId, geo: Geo) =
        (fun (layout: Layout) ->

            geo |> DynObj.setValue layout (StyleParam.SubPlotId.toString id)

            layout)

    /// <summary>
    /// Returns Some(Mapbox) if there is amapbox object set on the layout with the given id, and None otherwise.
    /// </summary>
    /// <param name="id">The target mapbox id</param>
    static member tryGetMapboxById(id: StyleParam.SubPlotId) =
        (fun (layout: Layout) -> layout.TryGetTypedValue<Mapbox>(StyleParam.SubPlotId.toString id))

    /// <summary>
    /// Combines the given mapbox object with the one already present on the layout.
    /// </summary>
    /// <param name="id">The target mapbox id</param>
    /// <param name="mapbox">The updated mapbox object.</param>
    static member updateMapboxById(id: StyleParam.SubPlotId, mapbox: Mapbox) =
        (fun (layout: Layout) ->
            let mapbox' =
                match Layout.tryGetMapboxById id layout with
                | Some a -> (DynObj.combine a mapbox) :?> Mapbox
                | None -> mapbox

            mapbox' |> DynObj.setValue layout (StyleParam.SubPlotId.toString id)
            layout)

    /// <summary>
    /// Returns the Mapbox object of the layout with the given id.
    ///
    /// If there is no mapbox set, returns an empty Mapbox object.
    /// </summary>
    /// <param name="id">The target mapbox id</param>
    static member getMapboxById(id: StyleParam.SubPlotId) =
        (fun (layout: Layout) -> layout |> Layout.tryGetMapboxById id |> Option.defaultValue (Mapbox.init ()))

    /// <summary>
    /// Sets a mapbox object on the layout as a dynamic property with the given mapbox id.
    /// </summary>
    /// <param name="id">The mapbox id of the new mapbox</param>
    /// <param name="mapbox">The mapbox to add to the layout.</param>
    static member setMapbox(id: StyleParam.SubPlotId, mapbox: Mapbox) =
        (fun (layout: Layout) ->

            mapbox |> DynObj.setValue layout (StyleParam.SubPlotId.toString id)

            layout)

    /// <summary>
    /// Returns Some(Polar) if there is a polar object set on the layout with the given id, and None otherwise.
    /// </summary>
    /// <param name="id">he target polar id</param>
    static member tryGetPolarById(id: StyleParam.SubPlotId) =
        (fun (layout: Layout) -> layout.TryGetTypedValue<Polar>(StyleParam.SubPlotId.toString id))

    /// <summary>
    /// Combines the given polar object with the one already present on the layout.
    /// </summary>
    /// <param name="id">The target polar id</param>
    /// <param name="polar">The updated polar object.</param>
    static member updatePolarById(id: StyleParam.SubPlotId, polar: Polar) =
        (fun (layout: Layout) ->

            let polar' =
                match layout |> Layout.tryGetPolarById (id) with
                | Some a -> (DynObj.combine a polar) :?> Polar
                | None -> polar

            polar' |> DynObj.setValue layout (StyleParam.SubPlotId.toString id)

            layout)

    /// <summary>
    /// Returns the Polar object of the layout with the given id.
    ///
    /// If there is no polar set, returns an empty Polar object.
    /// </summary>
    /// <param name="id">The target polar id</param>
    static member getPolarById(id: StyleParam.SubPlotId) =
        (fun (layout: Layout) -> layout |> Layout.tryGetPolarById id |> Option.defaultValue (Polar.init ()))

    /// <summary>
    /// Sets a polar object on the layout as a dynamic property with the given polar id.
    /// </summary>
    /// <param name="id">The scene id of the new geo</param>
    /// <param name="polar">The polar to add to the layout.</param>
    static member setPolar(id: StyleParam.SubPlotId, polar: Polar) =
        (fun (layout: Layout) ->

            polar |> DynObj.setValue layout (StyleParam.SubPlotId.toString id)

            layout)

    /// <summary>
    /// Returns Some(ColorAxis) if there is a ColorAxis object set on the layout with the given id, and None otherwise.
    /// </summary>
    /// <param name="id">The target ColorAxis id</param>
    static member tryGetColorAxisById(id: StyleParam.SubPlotId) =
        (fun (layout: Layout) -> layout.TryGetTypedValue<ColorAxis>(StyleParam.SubPlotId.toString id))

    /// <summary>
    /// Combines the given colorAxis object with the one already present on the layout.
    /// </summary>
    /// <param name="id">The target ColorAxis id</param>
    /// <param name="colorAxis">The updated ColorAxis object.</param>
    static member updateColorAxisById(id: StyleParam.SubPlotId, colorAxis: ColorAxis) =
        (fun (layout: Layout) ->

            let colorAxis' =
                match layout |> Layout.tryGetColorAxisById (id) with
                | Some a -> (DynObj.combine a colorAxis) :?> ColorAxis
                | None -> colorAxis

            colorAxis' |> DynObj.setValue layout (StyleParam.SubPlotId.toString id)

            layout)

    /// <summary>
    /// Returns the ColorAxis object of the layout with the given id.
    ///
    /// If there is no color axis set, returns an empty ColorAxis object.
    /// </summary>
    /// <param name="id">The target color axis id</param>
    static member getColorAxisById(id: StyleParam.SubPlotId) =
        (fun (layout: Layout) -> layout |> Layout.tryGetColorAxisById id |> Option.defaultValue (ColorAxis.init ()))

    /// <summary>
    /// Sets a ColorAxis object on the layout as a dynamic property with the given ColorAxis id.
    /// </summary>
    /// <param name="id">The ColorAxis id of the new ColorAxis</param>
    /// <param name="colorAxis">The ColorAxis to add to the layout.</param>
    static member setColorAxis(id: StyleParam.SubPlotId, colorAxis: ColorAxis) =
        (fun (layout: Layout) ->

            colorAxis |> DynObj.setValue layout (StyleParam.SubPlotId.toString id)

            layout)

    /// <summary>
    /// Returns Some(Ternary) if there is a ColorAxis object set on the layout with the given id, and None otherwise.
    /// </summary>
    /// <param name="id">The target Ternary id</param>
    static member tryGetTernaryById(id: StyleParam.SubPlotId) =
        (fun (layout: Layout) -> layout.TryGetTypedValue<Ternary>(StyleParam.SubPlotId.toString id))

    /// <summary>
    /// Combines the given ternary object with the one already present on the layout.
    /// </summary>
    /// <param name="id">The target Ternary id</param>
    /// <param name="ternary">The updated Ternary object.</param>
    static member updateTernaryById(id: StyleParam.SubPlotId, ternary: Ternary) =
        (fun (layout: Layout) ->

            let ternary' =
                match layout |> Layout.tryGetTernaryById (id) with
                | Some a -> (DynObj.combine a ternary) :?> Ternary
                | None -> ternary

            ternary' |> DynObj.setValue layout (StyleParam.SubPlotId.toString id)

            layout)

    /// <summary>
    /// Returns the Ternary object of the layout with the given id.
    ///
    /// If there is no ternary set, returns an empty Ternary object.
    /// </summary>
    /// <param name="id">The target ternary id</param>
    static member getTernaryById(id: StyleParam.SubPlotId) =
        (fun (layout: Layout) -> layout |> Layout.tryGetTernaryById id |> Option.defaultValue (Ternary.init ()))

    /// <summary>
    /// Sets a Ternary object on the layout as a dynamic property with the given Ternary id.
    /// </summary>
    /// <param name="id">The Ternary id of the new ColorAxis</param>
    /// <param name="ternary">The Ternary to add to the layout.</param>
    static member setTernary(id: StyleParam.SubPlotId, ternary: Ternary) =
        (fun (layout: Layout) ->

            ternary |> DynObj.setValue layout (StyleParam.SubPlotId.toString id)

            layout)

    /// <summary>
    /// Returns the LayoutGrid object of the given layout.
    ///
    /// If there is no grid set, returns an empty LayoutGrid object.
    /// </summary>
    /// <param name="layout">The layout to get the grid from</param>
    static member getLayoutGrid(layout: Layout) =
        layout |> Layout.tryGetTypedMember<LayoutGrid> "grid" |> Option.defaultValue (LayoutGrid.init ())

    /// <summary>
    /// Returns a function that sets the LayoutGrid object of the given trace.
    /// </summary>
    /// <param name="layoutGrid">The new LayoutGrid object</param>
    static member setLayoutGrid(layoutGrid: LayoutGrid) =
        (fun (layout: Layout) ->
            layout.SetValue("grid", layoutGrid)
            layout)

    /// <summary>
    /// Combines the given layoutGrid object with the one already present on the layout.
    /// </summary>
    /// <param name="layoutGrid">The updated LayoutGrid object</param>
    static member updateLayoutGrid(layoutGrid: LayoutGrid) =
        (fun (layout: Layout) ->
            let combined =
                (DynObj.combine (layout |> Layout.getLayoutGrid) layoutGrid) :?> LayoutGrid

            layout |> Layout.setLayoutGrid combined)

    /// <summary>
    /// Returns the legend object of the given layout.
    ///
    /// If there is no legend set, returns an empty Legend object.
    /// </summary>
    /// <param name="layout">The layout to get the legend from</param>
    static member getLegend(layout: Layout) =
        layout |> Layout.tryGetTypedMember<Legend> "legend" |> Option.defaultValue (Legend.init ())

    /// <summary>
    /// Returns a function that sets the Legend object of the given trace.
    /// </summary>
    /// <param name="legend">The new Legend object</param>
    static member setLegend(legend: Legend) =
        (fun (layout: Layout) ->
            layout.SetValue("legend", legend)
            layout)

    /// <summary>
    /// Combines the given Legend object with the one already present on the layout.
    /// </summary>
    /// <param name="legend">The updated Legend object</param>
    static member updateLegend(legend: Legend) =
        (fun (layout: Layout) ->
            let combined =
                (DynObj.combine (layout |> Layout.getLegend) legend) :?> Legend

            layout |> Layout.setLegend combined)
