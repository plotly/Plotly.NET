namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects

open DynamicObj
open System
open System.IO
open System.Runtime.CompilerServices

open System.Runtime.InteropServices

[<AutoOpen>]
module Chart2D_Funnel =
    [<Extension>]
    type Chart =
        [<Extension>]
        static member Funnel
            (
                x: seq<#IConvertible>,
                y: seq<#IConvertible>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Width: float,
                ?Offset: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?Orientation: StyleParam.Orientation,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?MarkerColor: Color,
                ?MarkerOutline: Line,
                ?Marker: Marker,
                ?TextInfo: StyleParam.TextInfo,
                ?ConnectorLineColor: Color,
                ?ConnectorLineStyle: StyleParam.DrawingStyle,
                ?ConnectorFillColor: Color,
                ?ConnectorLine: Line,
                ?Connector: FunnelConnector,
                ?InsideTextFont: Font,
                ?OutsideTextFont: Font,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let marker =
                Marker
                |> Option.defaultValue (TraceObjects.Marker.init ())
                |> TraceObjects.Marker.style (?Color = MarkerColor, ?Outline = MarkerOutline)

            let connectorLine =
                ConnectorLine
                |> Option.map (Plotly.NET.Line.style (?Color = ConnectorLineColor, ?Dash = ConnectorLineStyle))

            let connector =
                Connector
                |> Option.defaultValue (TraceObjects.FunnelConnector.init ())
                |> TraceObjects.FunnelConnector.style (?FillColor = ConnectorFillColor, ?Line = connectorLine)

            Trace2D.initFunnel (
                Trace2DStyle.Funnel(
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    X = x,
                    Y = y,
                    ?Width = Width,
                    ?Offset = Offset,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?TextPosition = TextPosition,
                    ?MultiTextPosition = MultiTextPosition,
                    ?Orientation = Orientation,
                    ?AlignmentGroup = AlignmentGroup,
                    ?OffsetGroup = OffsetGroup,
                    Marker = marker,
                    ?TextInfo = TextInfo,
                    Connector = connector,
                    ?InsideTextFont = InsideTextFont,
                    ?OutsideTextFont = OutsideTextFont

                )
            )
            |> GenericChart.ofTraceObject useDefaults

        /// <summary>
        /// Creates a Funnel chart from encoded x and y coordinates.
        ///
        /// Funnel charts visualize stages in a process using length-encoded bars. This trace can be used to show data in either a part-to-whole representation wherein each item appears in a single stage, or in a "drop-off" representation wherein each item appears in each stage it traversed. See also the "funnelarea" trace type for a different approach to visualizing funnel data.
        /// </summary>
        /// <param name="xEncoded">Sets the x coordinates of the plotted data as an encoded typed array.</param>
        /// <param name="yEncoded">Sets the y coordinates of the plotted data as an encoded typed array.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity of the trace.</param>
        /// <param name="Width">Sets the bar width (in position axis units).</param>
        /// <param name="Offset">Shifts the position where the bar is drawn (in position axis units). In "group" barmode, traces that set "offset" will be excluded and drawn in "overlay" mode instead.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="Orientation">Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used - including if `visible` is "legendonly" but not if it is `false`. Sets the stacking direction. With "v" ("h"), the y (x) values of subsequent traces are added. Also affects the default value of `fill`.</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="MarkerColor">Sets the color of the bars.</param>
        /// <param name="MarkerOutline">Sets the color of the bar outline.</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments)</param>
        /// <param name="TextInfo">Determines which trace information appear on the graph. In the case of having multiple funnels, percentages and totals are computed separately (per trace).</param>
        /// <param name="ConnectorLineColor">Sets the line color of the funnel connector</param>
        /// <param name="ConnectorLineStyle">Sets the line style of the funnel connector</param>
        /// <param name="ConnectorFillColor">Sets the fill color of the funnel connector</param>
        /// <param name="ConnectorLine">Sets the line of the funnel connector (use this for more finegrained control than the other connector line associated arguments).</param>
        /// <param name="Connector">Sets the funnel connector (use this for more finegrained control than the other connector-associated arguments).</param>
        /// <param name="InsideTextFont">Sets the font used for `text` lying inside the bar.</param>
        /// <param name="OutsideTextFont">Sets the font used for `text` lying outside the bar.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Funnel
            (
                xEncoded: EncodedTypedArray,
                yEncoded: EncodedTypedArray,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Width: float,
                ?Offset: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?Orientation: StyleParam.Orientation,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?MarkerColor: Color,
                ?MarkerOutline: Line,
                ?Marker: Marker,
                ?TextInfo: StyleParam.TextInfo,
                ?ConnectorLineColor: Color,
                ?ConnectorLineStyle: StyleParam.DrawingStyle,
                ?ConnectorFillColor: Color,
                ?ConnectorLine: Line,
                ?Connector: FunnelConnector,
                ?InsideTextFont: Font,
                ?OutsideTextFont: Font,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let marker =
                Marker
                |> Option.defaultValue (TraceObjects.Marker.init ())
                |> TraceObjects.Marker.style (?Color = MarkerColor, ?Outline = MarkerOutline)

            let connectorLine =
                ConnectorLine
                |> Option.map (Plotly.NET.Line.style (?Color = ConnectorLineColor, ?Dash = ConnectorLineStyle))

            let connector =
                Connector
                |> Option.defaultValue (TraceObjects.FunnelConnector.init ())
                |> TraceObjects.FunnelConnector.style (?FillColor = ConnectorFillColor, ?Line = connectorLine)

            Trace2D.initFunnel (
                Trace2DStyle.Funnel(
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    XEncoded = xEncoded,
                    YEncoded = yEncoded,
                    ?Width = Width,
                    ?Offset = Offset,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?TextPosition = TextPosition,
                    ?MultiTextPosition = MultiTextPosition,
                    ?Orientation = Orientation,
                    ?AlignmentGroup = AlignmentGroup,
                    ?OffsetGroup = OffsetGroup,
                    Marker = marker,
                    ?TextInfo = TextInfo,
                    Connector = connector,
                    ?InsideTextFont = InsideTextFont,
                    ?OutsideTextFont = OutsideTextFont

                )
            )
            |> GenericChart.ofTraceObject useDefaults

        /// <summary>
        /// Creates a stacked Funnel chart, a variation of the funnel chart where multiple funnel bars of each stage are stacked on top of each other.
        /// To create this type of chart, combine multiple of these charts via `Chart.combine`.
        ///
        /// Funnel charts visualize stages in a process using length-encoded bars. This trace can be used to show data in either a part-to-whole representation wherein each item appears in a single stage, or in a "drop-off" representation wherein each item appears in each stage it traversed. See also the "funnelarea" trace type for a different approach to visualizing funnel data.
        /// </summary>
        /// <param name="x">Sets the x coordinates of the plotted data.</param>
        /// <param name="y">Sets the y coordinates of the plotted data.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity of the trace.</param>
        /// <param name="Width">Sets the bar width (in position axis units).</param>
        /// <param name="Offset">Shifts the position where the bar is drawn (in position axis units). In "group" barmode, traces that set "offset" will be excluded and drawn in "overlay" mode instead.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="Orientation">Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used - including if `visible` is "legendonly" but not if it is `false`. Sets the stacking direction. With "v" ("h"), the y (x) values of subsequent traces are added. Also affects the default value of `fill`.</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="MarkerColor">Sets the color of the bars.</param>
        /// <param name="MarkerOutline">Sets the color of the bar outline.</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments)</param>
        /// <param name="TextInfo">Determines which trace information appear on the graph. In the case of having multiple funnels, percentages and totals are computed separately (per trace).</param>
        /// <param name="ConnectorLineColor">Sets the line color of the funnel connector</param>
        /// <param name="ConnectorLineStyle">Sets the line style of the funnel connector</param>
        /// <param name="ConnectorFillColor">Sets the fill color of the funnel connector</param>
        /// <param name="ConnectorLine">Sets the line of the funnel connector (use this for more finegrained control than the other connector line associated arguments).</param>
        /// <param name="Connector">Sets the funnel connector (use this for more finegrained control than the other connector-associated arguments).</param>
        /// <param name="InsideTextFont">Sets the font used for `text` lying inside the bar.</param>
        /// <param name="OutsideTextFont">Sets the font used for `text` lying outside the bar.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        static member StackedFunnel
            (
                x: seq<#IConvertible>,
                y: seq<#IConvertible>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Width: float,
                ?Offset: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?Orientation: StyleParam.Orientation,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?MarkerColor: Color,
                ?MarkerOutline: Line,
                ?Marker: Marker,
                ?TextInfo: StyleParam.TextInfo,
                ?ConnectorLineColor: Color,
                ?ConnectorLineStyle: StyleParam.DrawingStyle,
                ?ConnectorFillColor: Color,
                ?ConnectorLine: Line,
                ?Connector: FunnelConnector,
                ?InsideTextFont: Font,
                ?OutsideTextFont: Font,
                ?UseDefaults: bool
            ) =
            Chart.Funnel(
                x = x,
                y = y,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?Width = Width,
                ?Offset = Offset,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?Orientation = Orientation,
                ?AlignmentGroup = AlignmentGroup,
                ?OffsetGroup = OffsetGroup,
                ?MarkerColor = MarkerColor,
                ?MarkerOutline = MarkerOutline,
                ?Marker = Marker,
                ?TextInfo = TextInfo,
                ?ConnectorLineColor = ConnectorLineColor,
                ?ConnectorLineStyle = ConnectorLineStyle,
                ?ConnectorFillColor = ConnectorFillColor,
                ?ConnectorLine = ConnectorLine,
                ?Connector = Connector,
                ?InsideTextFont = InsideTextFont,
                ?OutsideTextFont = OutsideTextFont,
                ?UseDefaults = UseDefaults

            )
            |> GenericChart.mapLayout (Layout.style (FunnelMode = StyleParam.FunnelMode.Stack))

        /// <summary>Creates a stacked funnel chart from encoded x and y coordinates.</summary>
        [<Extension>]
        static member StackedFunnel
            (
                xEncoded: EncodedTypedArray,
                yEncoded: EncodedTypedArray,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Width: float,
                ?Offset: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?Orientation: StyleParam.Orientation,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?MarkerColor: Color,
                ?MarkerOutline: Line,
                ?Marker: Marker,
                ?TextInfo: StyleParam.TextInfo,
                ?ConnectorLineColor: Color,
                ?ConnectorLineStyle: StyleParam.DrawingStyle,
                ?ConnectorFillColor: Color,
                ?ConnectorLine: Line,
                ?Connector: FunnelConnector,
                ?InsideTextFont: Font,
                ?OutsideTextFont: Font,
                ?UseDefaults: bool
            ) =
            Chart.Funnel(
                xEncoded = xEncoded,
                yEncoded = yEncoded,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?Width = Width,
                ?Offset = Offset,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?Orientation = Orientation,
                ?AlignmentGroup = AlignmentGroup,
                ?OffsetGroup = OffsetGroup,
                ?MarkerColor = MarkerColor,
                ?MarkerOutline = MarkerOutline,
                ?Marker = Marker,
                ?TextInfo = TextInfo,
                ?ConnectorLineColor = ConnectorLineColor,
                ?ConnectorLineStyle = ConnectorLineStyle,
                ?ConnectorFillColor = ConnectorFillColor,
                ?ConnectorLine = ConnectorLine,
                ?Connector = Connector,
                ?InsideTextFont = InsideTextFont,
                ?OutsideTextFont = OutsideTextFont,
                ?UseDefaults = UseDefaults
            )
            |> GenericChart.mapLayout (Layout.style (FunnelMode = StyleParam.FunnelMode.Stack))

        /// <summary>
        /// Creates a waterfall chart.
        ///
        /// Waterfall charts are special bar charts that help visualizing the cumulative effect of sequentially introduced positive or negative values
        /// </summary>
        /// <param name="x">Sets the x coordinates of the plotted data.</param>
        /// <param name="y">Sets the y coordinates of the plotted data.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="IncreasingColor">Sets the color of increasing values</param>
        /// <param name="Increasing">Sets the style options of increasing values (use this for more finegrained control than the other increasing-associated arguments).</param>
        /// <param name="DecreasingColor">Sets the color of decreasing values</param>
        /// <param name="Decreasing">Sets the style options of decreasing values (use this for more finegrained control than the other increasing-associated arguments).</param>
        /// <param name="TotalsColor">Sets the color of total values</param>
        /// <param name="Totals">Sets the style options of total values (use this for more finegrained control than the other increasing-associated arguments).</param>
        /// <param name="Base">Sets where the bar base is drawn (in position axis units).</param>
        /// <param name="Width">Sets the bar width (in position axis units).</param>
        /// <param name="MultiWidth">Sets the individual bar width of each datum (in position axis units).</param>
        /// <param name="Opacity">Sets the opacity of the trace.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="TextFont">Sets the font used for `text`.</param>
        /// <param name="Connector">Sets the waterfall connector of this trace</param>
        /// <param name="Measure">An array containing types of measures. By default the values are considered as 'relative'. However; it is possible to use 'total' to compute the sums. Also 'absolute' could be applied to reset the computed total or to declare an initial value where needed.</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="Orientation">Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used - including if `visible` is "legendonly" but not if it is `false`. Sets the stacking direction. With "v" ("h"), the y (x) values of subsequent traces are added. Also affects the default value of `fill`.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Waterfall
            (
                x: seq<#IConvertible>,
                y: seq<#IConvertible>,
                ?Name: string,
                ?ShowLegend: bool,
                ?IncreasingColor: Color,
                ?Increasing: FinanceMarker,
                ?DecreasingColor: Color,
                ?Decreasing: FinanceMarker,
                ?TotalsColor: Color,
                ?Totals: FinanceMarker,
                ?Base: float,
                ?Width: float,
                ?MultiWidth: seq<float>,
                ?Opacity: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?TextFont: Font,
                ?Connector: WaterfallConnector,
                ?Measure: StyleParam.WaterfallMeasure seq,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?Orientation: StyleParam.Orientation,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let increasing =
                Increasing
                |> Option.defaultValue (FinanceMarker.init ())
                |> FinanceMarker.style (?FillColor = IncreasingColor)

            let decreasing =
                Decreasing
                |> Option.defaultValue (FinanceMarker.init ())
                |> FinanceMarker.style (?FillColor = DecreasingColor)

            let totals =
                Totals
                |> Option.defaultValue (FinanceMarker.init ())
                |> FinanceMarker.style (?FillColor = TotalsColor)

            Trace2D.initWaterfall (
                Trace2DStyle.Waterfall(
                    X = x,
                    Y = y,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    Increasing = increasing,
                    Decreasing = decreasing,
                    Totals = totals,
                    ?Base = Base,
                    ?Width = Width,
                    ?MultiWidth = MultiWidth,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?TextPosition = TextPosition,
                    ?MultiTextPosition = MultiTextPosition,
                    ?TextFont = TextFont,
                    ?Connector = Connector,
                    ?Measure = Measure,
                    ?AlignmentGroup = AlignmentGroup,
                    ?OffsetGroup = OffsetGroup,
                    ?Orientation = Orientation
                )
            )
            |> GenericChart.ofTraceObject useDefaults

        /// <summary>
        /// Creates a waterfall chart from encoded x and y coordinates.
        ///
        /// Waterfall charts are special bar charts that help visualizing the cumulative effect of sequentially introduced positive or negative values
        /// </summary>
        /// <param name="xEncoded">Sets the x coordinates of the plotted data as an encoded typed array.</param>
        /// <param name="yEncoded">Sets the y coordinates of the plotted data as an encoded typed array.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="IncreasingColor">Sets the color of increasing values</param>
        /// <param name="Increasing">Sets the style options of increasing values (use this for more finegrained control than the other increasing-associated arguments).</param>
        /// <param name="DecreasingColor">Sets the color of decreasing values</param>
        /// <param name="Decreasing">Sets the style options of decreasing values (use this for more finegrained control than the other increasing-associated arguments).</param>
        /// <param name="TotalsColor">Sets the color of total values</param>
        /// <param name="Totals">Sets the style options of total values (use this for more finegrained control than the other increasing-associated arguments).</param>
        /// <param name="Base">Sets where the bar base is drawn (in position axis units).</param>
        /// <param name="Width">Sets the bar width (in position axis units).</param>
        /// <param name="MultiWidthEncoded">Sets the individual bar width for each bar as an encoded typed array.</param>
        /// <param name="Opacity">Sets the opacity of the trace.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="TextFont">Sets the font used for `text`.</param>
        /// <param name="Connector">Sets the waterfall connector of this trace</param>
        /// <param name="Measure">An array containing types of measures. By default the values are considered as 'relative'. However; it is possible to use 'total' to compute the sums. Also 'absolute' could be applied to reset the computed total or to declare an initial value where needed.</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="Orientation">Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used - including if `visible` is "legendonly" but not if it is `false`. Sets the stacking direction. With "v" ("h"), the y (x) values of subsequent traces are added. Also affects the default value of `fill`.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Waterfall
            (
                xEncoded: EncodedTypedArray,
                yEncoded: EncodedTypedArray,
                ?Name: string,
                ?ShowLegend: bool,
                ?IncreasingColor: Color,
                ?Increasing: FinanceMarker,
                ?DecreasingColor: Color,
                ?Decreasing: FinanceMarker,
                ?TotalsColor: Color,
                ?Totals: FinanceMarker,
                ?Base: float,
                ?Width: float,
                ?MultiWidthEncoded: EncodedTypedArray,
                ?Opacity: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?TextFont: Font,
                ?Connector: WaterfallConnector,
                ?Measure: StyleParam.WaterfallMeasure seq,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?Orientation: StyleParam.Orientation,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let increasing =
                Increasing
                |> Option.defaultValue (FinanceMarker.init ())
                |> FinanceMarker.style (?FillColor = IncreasingColor)

            let decreasing =
                Decreasing
                |> Option.defaultValue (FinanceMarker.init ())
                |> FinanceMarker.style (?FillColor = DecreasingColor)

            let totals =
                Totals
                |> Option.defaultValue (FinanceMarker.init ())
                |> FinanceMarker.style (?FillColor = TotalsColor)

            Trace2D.initWaterfall (
                Trace2DStyle.Waterfall(
                    XEncoded = xEncoded,
                    YEncoded = yEncoded,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    Increasing = increasing,
                    Decreasing = decreasing,
                    Totals = totals,
                    ?Base = Base,
                    ?Width = Width,
                    ?MultiWidthEncoded = MultiWidthEncoded,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?TextPosition = TextPosition,
                    ?MultiTextPosition = MultiTextPosition,
                    ?TextFont = TextFont,
                    ?Connector = Connector,
                    ?Measure = Measure,
                    ?AlignmentGroup = AlignmentGroup,
                    ?OffsetGroup = OffsetGroup,
                    ?Orientation = Orientation
                )
            )
            |> GenericChart.ofTraceObject useDefaults


        /// <summary>
        /// Creates a waterfall chart.
        ///
        /// Waterfall charts are special bar charts that help visualizing the cumulative effect of sequentially introduced positive or negative values
        /// </summary>
        /// <param name="xy">Sets the x and y coordinates of the plotted data.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="IncreasingColor">Sets the color of increasing values</param>
        /// <param name="Increasing">Sets the style options of increasing values (use this for more finegrained control than the other increasing-associated arguments).</param>
        /// <param name="DecreasingColor">Sets the color of decreasing values</param>
        /// <param name="Decreasing">Sets the style options of decreasing values (use this for more finegrained control than the other increasing-associated arguments).</param>
        /// <param name="TotalsColor">Sets the color of total values</param>
        /// <param name="Totals">Sets the style options of total values (use this for more finegrained control than the other increasing-associated arguments).</param>
        /// <param name="Base">Sets where the bar base is drawn (in position axis units).</param>
        /// <param name="Width">Sets the bar width (in position axis units).</param>
        /// <param name="MultiWidth">Sets the individual bar width of each datum (in position axis units).</param>
        /// <param name="Opacity">Sets the opacity of the trace.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="TextFont">Sets the font used for `text`.</param>
        /// <param name="Connector">Sets the waterfall connector of this trace</param>
        /// <param name="Measure">An array containing types of measures. By default the values are considered as 'relative'. However; it is possible to use 'total' to compute the sums. Also 'absolute' could be applied to reset the computed total or to declare an initial value where needed.</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="Orientation">Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used - including if `visible` is "legendonly" but not if it is `false`. Sets the stacking direction. With "v" ("h"), the y (x) values of subsequent traces are added. Also affects the default value of `fill`.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Waterfall
            (
                xy: seq<#IConvertible * #IConvertible>,
                ?Name: string,
                ?ShowLegend: bool,
                ?IncreasingColor: Color,
                ?Increasing: FinanceMarker,
                ?DecreasingColor: Color,
                ?Decreasing: FinanceMarker,
                ?TotalsColor: Color,
                ?Totals: FinanceMarker,
                ?Base: float,
                ?Width: float,
                ?MultiWidth: seq<float>,
                ?Opacity: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?TextFont: Font,
                ?Connector: WaterfallConnector,
                ?Measure: StyleParam.WaterfallMeasure seq,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?Orientation: StyleParam.Orientation,
                ?UseDefaults: bool
            ) =

            let x, y = Seq.unzip xy

            Chart.Waterfall(
                x = x,
                y = y,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?IncreasingColor = IncreasingColor,
                ?Increasing = Increasing,
                ?DecreasingColor = DecreasingColor,
                ?Decreasing = Decreasing,
                ?TotalsColor = TotalsColor,
                ?Totals = Totals,
                ?Base = Base,
                ?Width = Width,
                ?MultiWidth = MultiWidth,
                ?Opacity = Opacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?TextFont = TextFont,
                ?Connector = Connector,
                ?Measure = Measure,
                ?AlignmentGroup = AlignmentGroup,
                ?OffsetGroup = OffsetGroup,
                ?Orientation = Orientation,
                ?UseDefaults = UseDefaults
            )

        /// <summary>
        /// Creates a waterfall chart.
        ///
        /// Waterfall charts are special bar charts that help visualizing the cumulative effect of sequentially introduced positive or negative values
        /// </summary>
        /// <param name="xymeasures">Sets the x and y coordinates of the plotted data, together with a measure for each (x,y) pair that defines the type of computation done for each pair.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="IncreasingColor">Sets the color of increasing values</param>
        /// <param name="Increasing">Sets the style options of increasing values (use this for more finegrained control than the other increasing-associated arguments).</param>
        /// <param name="DecreasingColor">Sets the color of decreasing values</param>
        /// <param name="Decreasing">Sets the style options of decreasing values (use this for more finegrained control than the other increasing-associated arguments).</param>
        /// <param name="TotalsColor">Sets the color of total values</param>
        /// <param name="Totals">Sets the style options of total values (use this for more finegrained control than the other increasing-associated arguments).</param>
        /// <param name="Base">Sets where the bar base is drawn (in position axis units).</param>
        /// <param name="Width">Sets the bar width (in position axis units).</param>
        /// <param name="MultiWidth">Sets the individual bar width of each datum (in position axis units).</param>
        /// <param name="Opacity">Sets the opacity of the trace.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="TextFont">Sets the font used for `text`.</param>
        /// <param name="Connector">Sets the waterfall connector of this trace</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="Orientation">Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used - including if `visible` is "legendonly" but not if it is `false`. Sets the stacking direction. With "v" ("h"), the y (x) values of subsequent traces are added. Also affects the default value of `fill`.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Waterfall
            (
                xymeasures: seq<#IConvertible * #IConvertible * StyleParam.WaterfallMeasure>,
                ?Name: string,
                ?ShowLegend: bool,
                ?IncreasingColor: Color,
                ?Increasing: FinanceMarker,
                ?DecreasingColor: Color,
                ?Decreasing: FinanceMarker,
                ?TotalsColor: Color,
                ?Totals: FinanceMarker,
                ?Base: float,
                ?Width: float,
                ?MultiWidth: seq<float>,
                ?Opacity: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?TextFont: Font,
                ?Connector: WaterfallConnector,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?Orientation: StyleParam.Orientation,
                ?UseDefaults: bool
            ) =

            let x, y, measure = Seq.unzip3 xymeasures

            Chart.Waterfall(
                x = x,
                y = y,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?IncreasingColor = IncreasingColor,
                ?Increasing = Increasing,
                ?DecreasingColor = DecreasingColor,
                ?Decreasing = Decreasing,
                ?TotalsColor = TotalsColor,
                ?Totals = Totals,
                ?Base = Base,
                ?Width = Width,
                ?MultiWidth = MultiWidth,
                ?Opacity = Opacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?TextFont = TextFont,
                ?Connector = Connector,
                Measure = measure,
                ?AlignmentGroup = AlignmentGroup,
                ?OffsetGroup = OffsetGroup,
                ?Orientation = Orientation,
                ?UseDefaults = UseDefaults
            )

