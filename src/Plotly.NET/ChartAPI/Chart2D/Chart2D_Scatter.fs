namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects

open DynamicObj
open System
open System.IO
open System.Runtime.CompilerServices

open System.Runtime.InteropServices

[<AutoOpen>]
module Chart2D_Scatter =
    [<Extension>]
    type Chart =
        [<Extension>]
        static member internal renderScatterTrace (useDefaults: bool) (useWebGL: bool) (style: Trace2D -> Trace2D) =
            if useWebGL then
                Trace2D.initScatterGL style |> GenericChart.ofTraceObject useDefaults
            else
                Trace2D.initScatter style |> GenericChart.ofTraceObject useDefaults

        /// <summary>
        /// Creates a Scatter plot.
        ///
        /// Scatter charts are the basis of Point, Line, and Bubble Charts, and can be customized as such. We also provide abstractions for those: Chart.Line, Chart.Point, Chart.Bubble
        /// </summary>
        /// <param name="X">Sets the x coordinates of the plotted data.</param>
        /// <param name="XEncoded">Sets the x coordinates of the plotted data as an encoded typed array.</param>
        /// <param name="MultiX">Sets the x coordinates of the plotted data. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="Y">Sets the y coordinates of the plotted data.</param>
        /// <param name="YEncoded">Sets the y coordinates of the plotted data as an encoded typed array.</param>
        /// <param name="MultiY">Sets the x coordinates of the plotted data. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="Mode">Determines the drawing mode for this scatter trace.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker</param>
        /// <param name="MarkerOutline">Sets the outline of the marker</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments)</param>
        /// <param name="LineColor">Sets the color of the line</param>
        /// <param name="LineColorScale">Sets the colorscale of the line</param>
        /// <param name="LineWidth">Sets the width of the line</param>
        /// <param name="LineDash">sets the drawing style of the line</param>
        /// <param name="Line">Sets the line (use this for more finegrained control than the other line-associated arguments)</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="StackGroup">Set several traces (on the same subplot) to the same stackgroup in order to add their y values (or their x values if `Orientation` is Horizontal). Stacking also turns `fill` on by default and sets the default `mode` to "lines" irrespective of point count. ou can only stack on a numeric (linear or log) axis. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order</param>
        /// <param name="Orientation">Sets the stacking direction. Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used.</param>
        /// <param name="GroupNorm">Sets the normalization for the sum of this `stackgroup. Only relevant when `stackgroup` is used, and only the first `groupnorm` found in the `stackgroup` will be used</param>
        /// <param name="Fill">Sets the area to fill with a solid color. Defaults to "none" unless this trace is stacked, then it gets "tonexty" ("tonextx") if `orientation` is "v" ("h") Use with `FillColor` if not "none". "tozerox" and "tozeroy" fill to x=0 and y=0 respectively. "tonextx" and "tonexty" fill between the endpoints of this trace and the endpoints of the trace before it, connecting those endpoints with straight lines (to make a stacked area graph); if there is no trace before it, they behave like "tozerox" and "tozeroy". "toself" connects the endpoints of the trace (or each segment of the trace if it has gaps) into a closed shape. "tonext" fills the space between two traces if one completely encloses the other (eg consecutive contour lines), and behaves like "toself" if there is no trace before it. "tonext" should not be used if one trace does not enclose the other. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order.</param>
        /// <param name="FillColor">Sets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
        /// <param name="FillPattern">Sets the pattern within the marker.</param>
        /// <param name="UseWebGL">If true, plotly.js will use the WebGL engine to render this chart. use this when you want to render many objects at once.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Scatter
            (
                ?X: seq<#IConvertible>,
                ?XEncoded: EncodedTypedArray,
                ?MultiX: seq<seq<#IConvertible>>,
                ?Y: seq<#IConvertible>,
                ?YEncoded: EncodedTypedArray,
                ?MultiY: seq<seq<#IConvertible>>,
                ?Mode: StyleParam.Mode,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                ?Marker: Marker,
                ?LineColor: Color,
                ?LineColorScale: StyleParam.Colorscale,
                ?LineWidth: float,
                ?LineDash: StyleParam.DrawingStyle,
                ?Line: Line,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?StackGroup: string,
                ?Orientation: StyleParam.Orientation,
                ?GroupNorm: StyleParam.GroupNorm,
                ?Fill: StyleParam.Fill,
                ?FillColor: Color,
                ?FillPattern: Pattern,
                ?UseWebGL: bool,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let marker =
                Marker
                |> Option.defaultValue (TraceObjects.Marker.init ())
                |> TraceObjects.Marker.style (
                    ?Color = MarkerColor,
                    ?Outline = MarkerOutline,
                    ?Symbol = MarkerSymbol,
                    ?MultiSymbol = MultiMarkerSymbol,
                    ?Colorscale = MarkerColorScale,
                    ?MultiOpacity = MultiOpacity
                )

            let line =
                Line
                |> Option.defaultValue (Plotly.NET.Line.init ())
                |> Plotly.NET.Line.style (
                    ?Color = LineColor,
                    ?Dash = LineDash,
                    ?Colorscale = LineColorScale,
                    ?Width = LineWidth
                )

            let style =
                Trace2DStyle.Scatter(
                    ?X = X,
                    ?XEncoded = XEncoded,
                    ?MultiX = MultiX,
                    ?Y = Y,
                    ?YEncoded = YEncoded,
                    ?MultiY = MultiY,
                    ?Mode = Mode,
                    Marker = marker,
                    Line = line,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?TextPosition = TextPosition,
                    ?MultiTextPosition = MultiTextPosition,
                    ?AlignmentGroup = AlignmentGroup,
                    ?OffsetGroup = OffsetGroup,
                    ?StackGroup = StackGroup,
                    ?Orientation = Orientation,
                    ?GroupNorm = GroupNorm,
                    ?Fill = Fill,
                    ?FillColor = FillColor,
                    ?FillPattern = FillPattern
                )

            let useWebGL = defaultArg UseWebGL false

            Chart.renderScatterTrace useDefaults useWebGL style

        /// <summary>
        /// Creates a Scatter plot from encoded x and y coordinates.
        ///
        /// Scatter charts are the basis of Point, Line, and Bubble Charts, and can be customized as such. We also provide abstractions for those: Chart.Line, Chart.Point, Chart.Bubble
        /// </summary>
        /// <param name="xEncoded">Sets the x coordinates of the plotted data as an encoded typed array.</param>
        /// <param name="yEncoded">Sets the y coordinates of the plotted data as an encoded typed array.</param>
        /// <param name="mode">Determines the drawing mode for this scatter trace.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker</param>
        /// <param name="MarkerOutline">Sets the outline of the marker</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments)</param>
        /// <param name="LineColor">Sets the color of the line</param>
        /// <param name="LineColorScale">Sets the colorscale of the line</param>
        /// <param name="LineWidth">Sets the width of the line</param>
        /// <param name="LineDash">sets the drawing style of the line</param>
        /// <param name="Line">Sets the line (use this for more finegrained control than the other line-associated arguments)</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="StackGroup">Set several traces (on the same subplot) to the same stackgroup in order to add their y values (or their x values if `Orientation` is Horizontal). Stacking also turns `fill` on by default and sets the default `mode` to "lines" irrespective of point count. ou can only stack on a numeric (linear or log) axis. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order</param>
        /// <param name="Orientation">Sets the stacking direction. Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used.</param>
        /// <param name="GroupNorm">Sets the normalization for the sum of this `stackgroup. Only relevant when `stackgroup` is used, and only the first `groupnorm` found in the `stackgroup` will be used</param>
        /// <param name="Fill">Sets the area to fill with a solid color. Defaults to "none" unless this trace is stacked, then it gets "tonexty" ("tonextx") if `orientation` is "v" ("h") Use with `FillColor` if not "none". "tozerox" and "tozeroy" fill to x=0 and y=0 respectively. "tonextx" and "tonexty" fill between the endpoints of this trace and the endpoints of the trace before it, connecting those endpoints with straight lines (to make a stacked area graph); if there is no trace before it, they behave like "tozerox" and "tozeroy". "toself" connects the endpoints of the trace (or each segment of the trace if it has gaps) into a closed shape. "tonext" fills the space between two traces if one completely encloses the other (eg consecutive contour lines), and behaves like "toself" if there is no trace before it. "tonext" should not be used if one trace does not enclose the other. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order.</param>
        /// <param name="FillColor">Sets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
        /// <param name="FillPattern">Sets the pattern within the marker.</param>
        /// <param name="UseWebGL">If true, plotly.js will use the WebGL engine to render this chart. use this when you want to render many objects at once.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Scatter
            (
                xEncoded: EncodedTypedArray,
                yEncoded: EncodedTypedArray,
                mode: StyleParam.Mode,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                ?Marker: Marker,
                ?LineColor: Color,
                ?LineColorScale: StyleParam.Colorscale,
                ?LineWidth: float,
                ?LineDash: StyleParam.DrawingStyle,
                ?Line: Line,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?StackGroup: string,
                ?Orientation: StyleParam.Orientation,
                ?GroupNorm: StyleParam.GroupNorm,
                ?Fill: StyleParam.Fill,
                ?FillColor: Color,
                ?FillPattern: Pattern,
                ?UseWebGL: bool,
                ?UseDefaults: bool
            ) =

            Chart.Scatter(
                XEncoded = xEncoded,
                YEncoded = yEncoded,
                Mode = mode,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerSymbol = MarkerSymbol,
                ?MultiMarkerSymbol = MultiMarkerSymbol,
                ?Marker = Marker,
                ?LineColor = LineColor,
                ?LineColorScale = LineColorScale,
                ?LineWidth = LineWidth,
                ?LineDash = LineDash,
                ?Line = Line,
                ?AlignmentGroup = AlignmentGroup,
                ?OffsetGroup = OffsetGroup,
                ?StackGroup = StackGroup,
                ?Orientation = Orientation,
                ?GroupNorm = GroupNorm,
                ?Fill = Fill,
                ?FillColor = FillColor,
                ?FillPattern = FillPattern,
                ?UseWebGL = UseWebGL,
                ?UseDefaults = UseDefaults
            )

        /// <summary>
        /// Creates a Scatter plot.
        ///
        /// Scatter charts are the basis of Point, Line, and Bubble Charts, and can be customized as such. We also provide abstractions for those: Chart.Line, Chart.Point, Chart.Bubble
        /// </summary>
        /// <param name="x">Sets the x coordinates of the plotted data.</param>
        /// <param name="y">Sets the y coordinates of the plotted data.</param>
        /// <param name="mode">Determines the drawing mode for this scatter trace.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker</param>
        /// <param name="MarkerOutline">Sets the outline of the marker</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments)</param>
        /// <param name="LineColor">Sets the color of the line</param>
        /// <param name="LineColorScale">Sets the colorscale of the line</param>
        /// <param name="LineWidth">Sets the width of the line</param>
        /// <param name="LineDash">sets the drawing style of the line</param>
        /// <param name="Line">Sets the line (use this for more finegrained control than the other line-associated arguments)</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="StackGroup">Set several traces (on the same subplot) to the same stackgroup in order to add their y values (or their x values if `Orientation` is Horizontal). Stacking also turns `fill` on by default and sets the default `mode` to "lines" irrespective of point count. ou can only stack on a numeric (linear or log) axis. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order</param>
        /// <param name="Orientation">Sets the stacking direction. Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used.</param>
        /// <param name="GroupNorm">Sets the normalization for the sum of this `stackgroup. Only relevant when `stackgroup` is used, and only the first `groupnorm` found in the `stackgroup` will be used</param>
        /// <param name="Fill">Sets the area to fill with a solid color. Defaults to "none" unless this trace is stacked, then it gets "tonexty" ("tonextx") if `orientation` is "v" ("h") Use with `FillColor` if not "none". "tozerox" and "tozeroy" fill to x=0 and y=0 respectively. "tonextx" and "tonexty" fill between the endpoints of this trace and the endpoints of the trace before it, connecting those endpoints with straight lines (to make a stacked area graph); if there is no trace before it, they behave like "tozerox" and "tozeroy". "toself" connects the endpoints of the trace (or each segment of the trace if it has gaps) into a closed shape. "tonext" fills the space between two traces if one completely encloses the other (eg consecutive contour lines), and behaves like "toself" if there is no trace before it. "tonext" should not be used if one trace does not enclose the other. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order.</param>
        /// <param name="FillColor">Sets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
        /// <param name="FillPattern">Sets the pattern within the marker.</param>
        /// <param name="UseWebGL">If true, plotly.js will use the WebGL engine to render this chart. use this when you want to render many objects at once.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Scatter
            (
                x: seq<#IConvertible>,
                y: seq<#IConvertible>,
                mode: StyleParam.Mode,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                ?Marker: Marker,
                ?LineColor: Color,
                ?LineColorScale: StyleParam.Colorscale,
                ?LineWidth: float,
                ?LineDash: StyleParam.DrawingStyle,
                ?Line: Line,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?StackGroup: string,
                ?Orientation: StyleParam.Orientation,
                ?GroupNorm: StyleParam.GroupNorm,
                ?Fill: StyleParam.Fill,
                ?FillColor: Color,
                ?FillPattern: Pattern,
                ?UseWebGL: bool,
                ?UseDefaults: bool
            ) =
            Chart.Scatter(
                X = x,
                Y = y,
                Mode = mode,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerSymbol = MarkerSymbol,
                ?MultiMarkerSymbol = MultiMarkerSymbol,
                ?Marker = Marker,
                ?LineColor = LineColor,
                ?LineColorScale = LineColorScale,
                ?LineWidth = LineWidth,
                ?LineDash = LineDash,
                ?Line = Line,
                ?AlignmentGroup = AlignmentGroup,
                ?OffsetGroup = OffsetGroup,
                ?StackGroup = StackGroup,
                ?Orientation = Orientation,
                ?GroupNorm = GroupNorm,
                ?Fill = Fill,
                ?FillColor = FillColor,
                ?FillPattern = FillPattern,
                ?UseWebGL = UseWebGL,
                ?UseDefaults = UseDefaults
            )

        /// <summary>
        /// Creates a Scatter chart. Scatter charts are the basis of Point, Line, and Bubble Charts in Plotly, and can be customized as such. We also provide abstractions for those: Chart.Line, Chart.Point, Chart.Bubble
        /// </summary>
        /// <param name="xy">Sets the x and y coordinates of the plotted data.</param>
        /// <param name="mode">Determines the drawing mode for this scatter trace.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker</param>
        /// <param name="MarkerOutline">Sets the outline of the marker</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments)</param>
        /// <param name="LineColor">Sets the color of the line</param>
        /// <param name="LineColorScale">Sets the colorscale of the line</param>
        /// <param name="LineWidth">Sets the width of the line</param>
        /// <param name="LineDash">sets the drawing style of the line</param>
        /// <param name="Line">Sets the line (use this for more finegrained control than the other line-associated arguments)</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="StackGroup">Set several traces (on the same subplot) to the same stackgroup in order to add their y values (or their x values if `Orientation` is Horizontal). Stacking also turns `fill` on by default and sets the default `mode` to "lines" irrespective of point count. ou can only stack on a numeric (linear or log) axis. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order</param>
        /// <param name="Orientation">Sets the stacking direction. Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used.</param>
        /// <param name="GroupNorm">Sets the normalization for the sum of this `stackgroup. Only relevant when `stackgroup` is used, and only the first `groupnorm` found in the `stackgroup` will be used</param>
        /// <param name="Fill">Sets the area to fill with a solid color. Defaults to "none" unless this trace is stacked, then it gets "tonexty" ("tonextx") if `orientation` is "v" ("h") Use with `FillColor` if not "none". "tozerox" and "tozeroy" fill to x=0 and y=0 respectively. "tonextx" and "tonexty" fill between the endpoints of this trace and the endpoints of the trace before it, connecting those endpoints with straight lines (to make a stacked area graph); if there is no trace before it, they behave like "tozerox" and "tozeroy". "toself" connects the endpoints of the trace (or each segment of the trace if it has gaps) into a closed shape. "tonext" fills the space between two traces if one completely encloses the other (eg consecutive contour lines), and behaves like "toself" if there is no trace before it. "tonext" should not be used if one trace does not enclose the other. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order.</param>
        /// <param name="FillColor">Sets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
        /// <param name="FillPattern">Sets the pattern within the marker.</param>
        /// <param name="UseWebGL">If true, plotly.js will use the WebGL engine to render this chart. use this when you want to render many objects at once.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Scatter
            (
                xy: seq<#IConvertible * #IConvertible>,
                mode: StyleParam.Mode,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                ?Marker: Marker,
                ?LineColor: Color,
                ?LineColorScale: StyleParam.Colorscale,
                ?LineWidth: float,
                ?LineDash: StyleParam.DrawingStyle,
                ?Line: Line,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?StackGroup: string,
                ?Orientation: StyleParam.Orientation,
                ?GroupNorm: StyleParam.GroupNorm,
                ?Fill: StyleParam.Fill,
                ?FillColor: Color,
                ?FillPattern: Pattern,
                ?UseWebGL: bool,
                ?UseDefaults: bool
            ) =

            let x, y = Seq.unzip xy

            Chart.Scatter(
                x = x,
                y = y,
                mode = mode,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerSymbol = MarkerSymbol,
                ?MultiMarkerSymbol = MultiMarkerSymbol,
                ?Marker = Marker,
                ?LineColor = LineColor,
                ?LineColorScale = LineColorScale,
                ?LineWidth = LineWidth,
                ?LineDash = LineDash,
                ?Line = Line,
                ?AlignmentGroup = AlignmentGroup,
                ?OffsetGroup = OffsetGroup,
                ?StackGroup = StackGroup,
                ?Orientation = Orientation,
                ?GroupNorm = GroupNorm,
                ?Fill = Fill,
                ?FillColor = FillColor,
                ?FillPattern = FillPattern,
                ?UseWebGL = UseWebGL,
                ?UseDefaults = UseDefaults
            )

        /// <summary>
        /// Creates a Point chart, which uses Points in a 2D space to visualize data.
        /// </summary>
        /// <param name="x">Sets the x coordinates of the plotted data.</param>
        /// <param name="y">Sets the y coordinates of the plotted data.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker</param>
        /// <param name="MarkerOutline">Sets the outline of the marker</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments)</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="StackGroup">Set several traces (on the same subplot) to the same stackgroup in order to add their y values (or their x values if `Orientation` is Horizontal). Stacking also turns `fill` on by default and sets the default `mode` to "lines" irrespective of point count. ou can only stack on a numeric (linear or log) axis. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order</param>
        /// <param name="Orientation">Sets the stacking direction. Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used.</param>
        /// <param name="GroupNorm">Sets the normalization for the sum of this `stackgroup. Only relevant when `stackgroup` is used, and only the first `groupnorm` found in the `stackgroup` will be used</param>
        /// <param name="UseWebGL">If true, plotly.js will use the WebGL engine to render this chart. use this when you want to render many objects at once.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Point
            (
                x: seq<#IConvertible>,
                y: seq<#IConvertible>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                ?Marker: Marker,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?StackGroup: string,
                ?Orientation: StyleParam.Orientation,
                ?GroupNorm: StyleParam.GroupNorm,
                ?UseWebGL: bool,
                ?UseDefaults: bool
            ) =

            // if text position or font is set, then show labels (not only when hovering)
            let changeMode =
                StyleParam.ModeUtils.showText (TextPosition.IsSome || MultiTextPosition.IsSome)

            Chart.Scatter(
                X = x,
                Y = y,
                Mode = changeMode StyleParam.Mode.Markers,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerSymbol = MarkerSymbol,
                ?MultiMarkerSymbol = MultiMarkerSymbol,
                ?Marker = Marker,
                ?AlignmentGroup = AlignmentGroup,
                ?OffsetGroup = OffsetGroup,
                ?StackGroup = StackGroup,
                ?Orientation = Orientation,
                ?GroupNorm = GroupNorm,
                ?UseWebGL = UseWebGL,
                ?UseDefaults = UseDefaults
            )

        /// <summary>
        /// Creates a Point chart from encoded x and y coordinates.
        /// </summary>
        /// <param name="xEncoded">Sets the x coordinates of the plotted data as an encoded typed array.</param>
        /// <param name="yEncoded">Sets the y coordinates of the plotted data as an encoded typed array.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker</param>
        /// <param name="MarkerOutline">Sets the outline of the marker</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments)</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="StackGroup">Set several traces (on the same subplot) to the same stackgroup in order to add their y values (or their x values if `Orientation` is Horizontal). Stacking also turns `fill` on by default and sets the default `mode` to "lines" irrespective of point count. ou can only stack on a numeric (linear or log) axis. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order</param>
        /// <param name="Orientation">Sets the stacking direction. Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used.</param>
        /// <param name="GroupNorm">Sets the normalization for the sum of this `stackgroup. Only relevant when `stackgroup` is used, and only the first `groupnorm` found in the `stackgroup` will be used</param>
        /// <param name="UseWebGL">If true, plotly.js will use the WebGL engine to render this chart. use this when you want to render many objects at once.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Point
            (
                xEncoded: EncodedTypedArray,
                yEncoded: EncodedTypedArray,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                ?Marker: Marker,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?StackGroup: string,
                ?Orientation: StyleParam.Orientation,
                ?GroupNorm: StyleParam.GroupNorm,
                ?UseWebGL: bool,
                ?UseDefaults: bool
            ) =

            let changeMode =
                StyleParam.ModeUtils.showText (TextPosition.IsSome || MultiTextPosition.IsSome)

            Chart.Scatter(
                XEncoded = xEncoded,
                YEncoded = yEncoded,
                Mode = changeMode StyleParam.Mode.Markers,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerSymbol = MarkerSymbol,
                ?MultiMarkerSymbol = MultiMarkerSymbol,
                ?Marker = Marker,
                ?AlignmentGroup = AlignmentGroup,
                ?OffsetGroup = OffsetGroup,
                ?StackGroup = StackGroup,
                ?Orientation = Orientation,
                ?GroupNorm = GroupNorm,
                ?UseWebGL = UseWebGL,
                ?UseDefaults = UseDefaults
            )


        /// <summary>Creates a Point chart, which uses Points in a 2D space to visualize data. </summary>
        /// <param name="xy">Sets the x and y coordinates of the plotted data.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker</param>
        /// <param name="MarkerOutline">Sets the outline of the marker</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments)</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="StackGroup">Set several traces (on the same subplot) to the same stackgroup in order to add their y values (or their x values if `Orientation` is Horizontal). Stacking also turns `fill` on by default and sets the default `mode` to "lines" irrespective of point count. ou can only stack on a numeric (linear or log) axis. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order</param>
        /// <param name="Orientation">Sets the stacking direction. Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used.</param>
        /// <param name="GroupNorm">Sets the normalization for the sum of this `stackgroup. Only relevant when `stackgroup` is used, and only the first `groupnorm` found in the `stackgroup` will be used</param>
        /// <param name="UseWebGL">If true, plotly.js will use the WebGL engine to render this chart. use this when you want to render many objects at once.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Point
            (
                xy: seq<#IConvertible * #IConvertible>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                ?Marker: Marker,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?StackGroup: string,
                ?Orientation: StyleParam.Orientation,
                ?GroupNorm: StyleParam.GroupNorm,
                ?UseWebGL: bool,
                ?UseDefaults: bool
            ) =
            let x, y = Seq.unzip xy

            Chart.Point(
                x = x,
                y = y,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerSymbol = MarkerSymbol,
                ?MultiMarkerSymbol = MultiMarkerSymbol,
                ?Marker = Marker,
                ?AlignmentGroup = AlignmentGroup,
                ?OffsetGroup = OffsetGroup,
                ?StackGroup = StackGroup,
                ?Orientation = Orientation,
                ?GroupNorm = GroupNorm,
                ?UseWebGL = UseWebGL,
                ?UseDefaults = UseDefaults
            )


        /// <summary> Creates a Line chart, which uses a Line plotted between the given datums in a 2D space to visualize typically an evolution of Y depending on X.</summary>
        /// <param name="x">Sets the x coordinates of the plotted data.</param>
        /// <param name="y">Sets the y coordinates of the plotted data.</param>
        /// <param name="ShowMarkers">Whether to show markers for the individual data points</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker</param>
        /// <param name="MarkerOutline">Sets the outline of the marker</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments)</param>
        /// <param name="LineColor">Sets the color of the line</param>
        /// <param name="LineColorScale">Sets the colorscale of the line</param>
        /// <param name="LineWidth">Sets the width of the line</param>
        /// <param name="LineDash">sets the drawing style of the line</param>
        /// <param name="Line">Sets the line (use this for more finegrained control than the other line-associated arguments)</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="StackGroup">Set several traces (on the same subplot) to the same stackgroup in order to add their y values (or their x values if `Orientation` is Horizontal). Stacking also turns `fill` on by default and sets the default `mode` to "lines" irrespective of point count. ou can only stack on a numeric (linear or log) axis. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order</param>
        /// <param name="Orientation">Sets the stacking direction. Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used.</param>
        /// <param name="GroupNorm">Sets the normalization for the sum of this `stackgroup. Only relevant when `stackgroup` is used, and only the first `groupnorm` found in the `stackgroup` will be used</param>
        /// <param name="Fill">Sets the area to fill with a solid color. Defaults to "none" unless this trace is stacked, then it gets "tonexty" ("tonextx") if `orientation` is "v" ("h") Use with `FillColor` if not "none". "tozerox" and "tozeroy" fill to x=0 and y=0 respectively. "tonextx" and "tonexty" fill between the endpoints of this trace and the endpoints of the trace before it, connecting those endpoints with straight lines (to make a stacked area graph); if there is no trace before it, they behave like "tozerox" and "tozeroy". "toself" connects the endpoints of the trace (or each segment of the trace if it has gaps) into a closed shape. "tonext" fills the space between two traces if one completely encloses the other (eg consecutive contour lines), and behaves like "toself" if there is no trace before it. "tonext" should not be used if one trace does not enclose the other. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order.</param>
        /// <param name="FillColor">Sets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
        /// <param name="FillPattern">Sets the pattern within the marker.</param>
        /// <param name="UseWebGL">If true, plotly.js will use the WebGL engine to render this chart. use this when you want to render many objects at once.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Line
            (
                x: seq<#IConvertible>,
                y: seq<#IConvertible>,
                ?ShowMarkers: bool,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                ?Marker: Marker,
                ?LineColor: Color,
                ?LineColorScale: StyleParam.Colorscale,
                ?LineWidth: float,
                ?LineDash: StyleParam.DrawingStyle,
                ?Line: Line,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?StackGroup: string,
                ?Orientation: StyleParam.Orientation,
                ?GroupNorm: StyleParam.GroupNorm,
                ?Fill: StyleParam.Fill,
                ?FillColor: Color,
                ?FillPattern: Pattern,
                ?UseWebGL: bool,
                ?UseDefaults: bool
            ) =

            // if text position or font is set than show labels (not only when hovering)
            let changeMode =
                let isShowMarker =
                    match ShowMarkers with
                    | Some isShow -> isShow
                    | Option.None -> false

                StyleParam.ModeUtils.showText (TextPosition.IsSome || MultiTextPosition.IsSome)
                >> StyleParam.ModeUtils.showMarker (isShowMarker)

            Chart.Scatter(
                X = x,
                Y = y,
                Mode = changeMode StyleParam.Mode.Lines,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerSymbol = MarkerSymbol,
                ?MultiMarkerSymbol = MultiMarkerSymbol,
                ?Marker = Marker,
                ?LineColor = LineColor,
                ?LineColorScale = LineColorScale,
                ?LineWidth = LineWidth,
                ?LineDash = LineDash,
                ?Line = Line,
                ?AlignmentGroup = AlignmentGroup,
                ?OffsetGroup = OffsetGroup,
                ?StackGroup = StackGroup,
                ?Orientation = Orientation,
                ?GroupNorm = GroupNorm,
                ?Fill = Fill,
                ?FillColor = FillColor,
                ?FillPattern = FillPattern,
                ?UseWebGL = UseWebGL,
                ?UseDefaults = UseDefaults

            )

        /// <summary>Creates a Line chart from encoded x and y coordinates.</summary>
        /// <param name="xEncoded">Sets the x coordinates of the plotted data as an encoded typed array.</param>
        /// <param name="yEncoded">Sets the y coordinates of the plotted data as an encoded typed array.</param>
        /// <param name="ShowMarkers">Whether to show markers for the individual data points</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker</param>
        /// <param name="MarkerOutline">Sets the outline of the marker</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments)</param>
        /// <param name="LineColor">Sets the color of the line</param>
        /// <param name="LineColorScale">Sets the colorscale of the line</param>
        /// <param name="LineWidth">Sets the width of the line</param>
        /// <param name="LineDash">sets the drawing style of the line</param>
        /// <param name="Line">Sets the line (use this for more finegrained control than the other line-associated arguments)</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="StackGroup">Set several traces linked to the same position axis or matching axes to the same stackgroup in order to add their y values (or their x values if `Orientation` is Horizontal). Stacking also turns `fill` on by default and sets the default `mode` to "lines" irrespective of point count. ou can only stack on a numeric (linear or log) axis. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order</param>
        /// <param name="Orientation">Sets the stacking direction. Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used.</param>
        /// <param name="GroupNorm">Sets the normalization for the sum of this `stackgroup. Only relevant when `stackgroup` is used, and only the first `groupnorm` found in the `stackgroup` will be used</param>
        /// <param name="Fill">Sets the area to fill with a solid color. Defaults to "none" unless this trace is stacked, then it gets "tonexty" ("tonextx") if `orientation` is "v" ("h") Use with `FillColor` if not "none". "tozerox" and "tozeroy" fill to x=0 and y=0 respectively. "tonextx" and "tonexty" fill between the endpoints of this trace and the endpoints of the trace before it, connecting those endpoints with straight lines (to make a stacked area graph); if there is no trace before it, they behave like "tozerox" and "tozeroy". "toself" connects the endpoints of the trace (or each segment of the trace if it has gaps) into a closed shape. "tonext" fills the space between two traces if one completely encloses the other (eg consecutive contour lines), and behaves like "toself" if there is no trace before it. "tonext" should not be used if one trace does not enclose the other. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order.</param>
        /// <param name="FillColor">Sets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
        /// <param name="FillPattern">Sets the pattern within the marker.</param>
        /// <param name="UseWebGL">If true, plotly.js will use the WebGL engine to render this chart. use this when you want to render many objects at once.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Line
            (
                xEncoded: EncodedTypedArray,
                yEncoded: EncodedTypedArray,
                ?ShowMarkers: bool,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                ?Marker: Marker,
                ?LineColor: Color,
                ?LineColorScale: StyleParam.Colorscale,
                ?LineWidth: float,
                ?LineDash: StyleParam.DrawingStyle,
                ?Line: Line,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?StackGroup: string,
                ?Orientation: StyleParam.Orientation,
                ?GroupNorm: StyleParam.GroupNorm,
                ?Fill: StyleParam.Fill,
                ?FillColor: Color,
                ?FillPattern: Pattern,
                ?UseWebGL: bool,
                ?UseDefaults: bool
            ) =

            let changeMode =
                let isShowMarker =
                    match ShowMarkers with
                    | Some isShow -> isShow
                    | Option.None -> false

                StyleParam.ModeUtils.showText (TextPosition.IsSome || MultiTextPosition.IsSome)
                >> StyleParam.ModeUtils.showMarker (isShowMarker)

            Chart.Scatter(
                XEncoded = xEncoded,
                YEncoded = yEncoded,
                Mode = changeMode StyleParam.Mode.Lines,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerSymbol = MarkerSymbol,
                ?MultiMarkerSymbol = MultiMarkerSymbol,
                ?Marker = Marker,
                ?LineColor = LineColor,
                ?LineColorScale = LineColorScale,
                ?LineWidth = LineWidth,
                ?LineDash = LineDash,
                ?Line = Line,
                ?AlignmentGroup = AlignmentGroup,
                ?OffsetGroup = OffsetGroup,
                ?StackGroup = StackGroup,
                ?Orientation = Orientation,
                ?GroupNorm = GroupNorm,
                ?Fill = Fill,
                ?FillColor = FillColor,
                ?FillPattern = FillPattern,
                ?UseWebGL = UseWebGL,
                ?UseDefaults = UseDefaults

            )



        /// <summary>Creates a Line chart, which uses a Line plotted between the given datums in a 2D space to visualize typically an evolution of Y depending on X.</summary>
        /// <param name="xy">Sets the x,y coordinates of the plotted data.</param>
        /// <param name="ShowMarkers">Whether to show markers for the individual data points</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker</param>
        /// <param name="MarkerOutline">Sets the outline of the marker</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments)</param>
        /// <param name="LineColor">Sets the color of the line</param>
        /// <param name="LineColorScale">Sets the colorscale of the line</param>
        /// <param name="LineWidth">Sets the width of the line</param>
        /// <param name="LineDash">sets the drawing style of the line</param>
        /// <param name="Line">Sets the line (use this for more finegrained control than the other line-associated arguments)</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="StackGroup">Set several traces (on the same subplot) to the same stackgroup in order to add their y values (or their x values if `Orientation` is Horizontal). Stacking also turns `fill` on by default and sets the default `mode` to "lines" irrespective of point count. ou can only stack on a numeric (linear or log) axis. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order</param>
        /// <param name="Orientation">Sets the stacking direction. Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used.</param>
        /// <param name="GroupNorm">Sets the normalization for the sum of this `stackgroup. Only relevant when `stackgroup` is used, and only the first `groupnorm` found in the `stackgroup` will be used</param>
        /// <param name="Fill">Sets the area to fill with a solid color. Defaults to "none" unless this trace is stacked, then it gets "tonexty" ("tonextx") if `orientation` is "v" ("h") Use with `FillColor` if not "none". "tozerox" and "tozeroy" fill to x=0 and y=0 respectively. "tonextx" and "tonexty" fill between the endpoints of this trace and the endpoints of the trace before it, connecting those endpoints with straight lines (to make a stacked area graph); if there is no trace before it, they behave like "tozerox" and "tozeroy". "toself" connects the endpoints of the trace (or each segment of the trace if it has gaps) into a closed shape. "tonext" fills the space between two traces if one completely encloses the other (eg consecutive contour lines), and behaves like "toself" if there is no trace before it. "tonext" should not be used if one trace does not enclose the other. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order.</param>
        /// <param name="FillColor">Sets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
        /// <param name="FillPattern">Sets the pattern within the marker.</param>
        /// <param name="UseWebGL">If true, plotly.js will use the WebGL engine to render this chart. use this when you want to render many objects at once.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Line
            (
                xy: seq<#IConvertible * #IConvertible>,
                ?ShowMarkers: bool,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                ?Marker: Marker,
                ?LineColor: Color,
                ?LineColorScale: StyleParam.Colorscale,
                ?LineWidth: float,
                ?LineDash: StyleParam.DrawingStyle,
                ?Line: Line,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?StackGroup: string,
                ?Orientation: StyleParam.Orientation,
                ?GroupNorm: StyleParam.GroupNorm,
                ?Fill: StyleParam.Fill,
                ?FillColor: Color,
                ?FillPattern: Pattern,
                ?UseWebGL: bool,
                ?UseDefaults: bool
            ) =
            let x, y = Seq.unzip xy

            Chart.Line(
                x = x,
                y = y,
                ?ShowMarkers = ShowMarkers,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerSymbol = MarkerSymbol,
                ?MultiMarkerSymbol = MultiMarkerSymbol,
                ?Marker = Marker,
                ?LineColor = LineColor,
                ?LineColorScale = LineColorScale,
                ?LineWidth = LineWidth,
                ?LineDash = LineDash,
                ?Line = Line,
                ?AlignmentGroup = AlignmentGroup,
                ?OffsetGroup = OffsetGroup,
                ?StackGroup = StackGroup,
                ?Orientation = Orientation,
                ?GroupNorm = GroupNorm,
                ?Fill = Fill,
                ?FillColor = FillColor,
                ?FillPattern = FillPattern,
                ?UseWebGL = UseWebGL,
                ?UseDefaults = UseDefaults
            )


        /// <summary>Creates a Spline chart. A spline chart is a line chart in which data points are connected by smoothed curves: this modification is aimed to improve the design of a chart.
        /// Very similar to Line Plots, spline charts are typically used to visualize an evolution of Y depending on X. </summary>
        /// <param name="x">Sets the x coordinates of the plotted data.</param>
        /// <param name="y">Sets the y coordinates of the plotted data.</param>
        /// <param name="ShowMarkers">Whether to show markers for the individual data points</param>
        /// <param name="Smoothing">Sets the amount of smoothing. "0" corresponds to no smoothing (equivalent to a "linear" shape).  Use values between 0. and 1.3</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker</param>
        /// <param name="MarkerOutline">Sets the outline of the marker</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments)</param>
        /// <param name="LineColor">Sets the color of the line</param>
        /// <param name="LineColorScale">Sets the colorscale of the line</param>
        /// <param name="LineWidth">Sets the width of the line</param>
        /// <param name="LineDash">sets the drawing style of the line</param>
        /// <param name="Line">Sets the line (use this for more finegrained control than the other line-associated arguments)</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="StackGroup">Set several traces (on the same subplot) to the same stackgroup in order to add their y values (or their x values if `Orientation` is Horizontal). Stacking also turns `fill` on by default and sets the default `mode` to "lines" irrespective of point count. ou can only stack on a numeric (linear or log) axis. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order</param>
        /// <param name="Orientation">Sets the stacking direction. Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used.</param>
        /// <param name="GroupNorm">Sets the normalization for the sum of this `stackgroup. Only relevant when `stackgroup` is used, and only the first `groupnorm` found in the `stackgroup` will be used</param>
        /// <param name="Fill">Sets the area to fill with a solid color. Defaults to "none" unless this trace is stacked, then it gets "tonexty" ("tonextx") if `orientation` is "v" ("h") Use with `FillColor` if not "none". "tozerox" and "tozeroy" fill to x=0 and y=0 respectively. "tonextx" and "tonexty" fill between the endpoints of this trace and the endpoints of the trace before it, connecting those endpoints with straight lines (to make a stacked area graph); if there is no trace before it, they behave like "tozerox" and "tozeroy". "toself" connects the endpoints of the trace (or each segment of the trace if it has gaps) into a closed shape. "tonext" fills the space between two traces if one completely encloses the other (eg consecutive contour lines), and behaves like "toself" if there is no trace before it. "tonext" should not be used if one trace does not enclose the other. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order.</param>
        /// <param name="FillColor">Sets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
        /// <param name="FillPattern">Sets the pattern within the marker.</param>
        /// <param name="UseWebGL">If true, plotly.js will use the WebGL engine to render this chart. use this when you want to render many objects at once.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Spline
            (
                x: seq<#IConvertible>,
                y: seq<#IConvertible>,
                ?ShowMarkers: bool,
                ?Smoothing: float,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                ?Marker: Marker,
                ?LineColor: Color,
                ?LineColorScale: StyleParam.Colorscale,
                ?LineWidth: float,
                ?LineDash: StyleParam.DrawingStyle,
                ?Line: Line,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?StackGroup: string,
                ?Orientation: StyleParam.Orientation,
                ?GroupNorm: StyleParam.GroupNorm,
                ?Fill: StyleParam.Fill,
                ?FillColor: Color,
                ?FillPattern: Pattern,
                ?UseWebGL: bool,
                ?UseDefaults: bool
            ) =

            // if text position set then show labels (not only when hovering)
            let changeMode =
                let isShowMarker =
                    match ShowMarkers with
                    | Some isShow -> isShow
                    | Option.None -> false

                StyleParam.ModeUtils.showText (TextPosition.IsSome || MultiTextPosition.IsSome)
                >> StyleParam.ModeUtils.showMarker (isShowMarker)

            let useDefaults =
                defaultArg UseDefaults true

            let marker =
                Marker
                |> Option.defaultValue (TraceObjects.Marker.init ())
                |> TraceObjects.Marker.style (
                    ?Color = MarkerColor,
                    ?Outline = MarkerOutline,
                    ?Symbol = MarkerSymbol,
                    ?MultiSymbol = MultiMarkerSymbol,
                    ?Colorscale = MarkerColorScale,
                    ?MultiOpacity = MultiOpacity
                )

            let line =
                Line
                |> Option.defaultValue (Plotly.NET.Line.init ())
                |> Plotly.NET.Line.style (
                    ?Color = LineColor,
                    ?Dash = LineDash,
                    ?Colorscale = LineColorScale,
                    ?Width = LineWidth,
                    Shape = StyleParam.Shape.Spline,
                    ?Smoothing = Smoothing

                )

            let style =
                Trace2DStyle.Scatter(
                    X = x,
                    Y = y,
                    Mode = changeMode StyleParam.Mode.Lines,
                    Marker = marker,
                    Line = line,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?TextPosition = TextPosition,
                    ?MultiTextPosition = MultiTextPosition,
                    ?AlignmentGroup = AlignmentGroup,
                    ?OffsetGroup = OffsetGroup,
                    ?StackGroup = StackGroup,
                    ?Orientation = Orientation,
                    ?GroupNorm = GroupNorm,
                    ?Fill = Fill,
                    ?FillColor = FillColor,
                    ?FillPattern = FillPattern
                )

            let useWebGL = defaultArg UseWebGL false

            Chart.renderScatterTrace useDefaults useWebGL style

        /// <summary>
        /// Creates a Spline chart from encoded x and y coordinates.
        /// </summary>
        /// <param name="xEncoded">Sets the x coordinates of the plotted data as an encoded typed array.</param>
        /// <param name="yEncoded">Sets the y coordinates of the plotted data as an encoded typed array.</param>
        /// <param name="ShowMarkers">Whether to show markers for the individual data points</param>
        /// <param name="Smoothing">Sets the amount of smoothing. "0" corresponds to no smoothing (equivalent to a "linear" shape).  Use values between 0. and 1.3</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker</param>
        /// <param name="MarkerOutline">Sets the outline of the marker</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments)</param>
        /// <param name="LineColor">Sets the color of the line</param>
        /// <param name="LineColorScale">Sets the colorscale of the line</param>
        /// <param name="LineWidth">Sets the width of the line</param>
        /// <param name="LineDash">sets the drawing style of the line</param>
        /// <param name="Line">Sets the line (use this for more finegrained control than the other line-associated arguments)</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="StackGroup">Set several traces (on the same subplot) to the same stackgroup in order to add their y values (or their x values if `Orientation` is Horizontal). Stacking also turns `fill` on by default and sets the default `mode` to "lines" irrespective of point count. ou can only stack on a numeric (linear or log) axis. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order</param>
        /// <param name="Orientation">Sets the stacking direction. Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used.</param>
        /// <param name="GroupNorm">Sets the normalization for the sum of this `stackgroup. Only relevant when `stackgroup` is used, and only the first `groupnorm` found in the `stackgroup` will be used</param>
        /// <param name="Fill">Sets the area to fill with a solid color. Defaults to "none" unless this trace is stacked, then it gets "tonexty" ("tonextx") if `orientation` is "v" ("h") Use with `FillColor` if not "none". "tozerox" and "tozeroy" fill to x=0 and y=0 respectively. "tonextx" and "tonexty" fill between the endpoints of this trace and the endpoints of the trace before it, connecting those endpoints with straight lines (to make a stacked area graph); if there is no trace before it, they behave like "tozerox" and "tozeroy". "toself" connects the endpoints of the trace (or each segment of the trace if it has gaps) into a closed shape. "tonext" fills the space between two traces if one completely encloses the other (eg consecutive contour lines), and behaves like "toself" if there is no trace before it. "tonext" should not be used if one trace does not enclose the other. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order.</param>
        /// <param name="FillColor">Sets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
        /// <param name="FillPattern">Sets the pattern within the marker.</param>
        /// <param name="UseWebGL">If true, plotly.js will use the WebGL engine to render this chart. use this when you want to render many objects at once.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Spline
            (
                xEncoded: EncodedTypedArray,
                yEncoded: EncodedTypedArray,
                ?ShowMarkers: bool,
                ?Smoothing: float,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                ?Marker: Marker,
                ?LineColor: Color,
                ?LineColorScale: StyleParam.Colorscale,
                ?LineWidth: float,
                ?LineDash: StyleParam.DrawingStyle,
                ?Line: Line,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?StackGroup: string,
                ?Orientation: StyleParam.Orientation,
                ?GroupNorm: StyleParam.GroupNorm,
                ?Fill: StyleParam.Fill,
                ?FillColor: Color,
                ?FillPattern: Pattern,
                ?UseWebGL: bool,
                ?UseDefaults: bool
            ) =

            let changeMode =
                let isShowMarker =
                    match ShowMarkers with
                    | Some isShow -> isShow
                    | Option.None -> false

                StyleParam.ModeUtils.showText (TextPosition.IsSome || MultiTextPosition.IsSome)
                >> StyleParam.ModeUtils.showMarker (isShowMarker)

            let useDefaults =
                defaultArg UseDefaults true

            let marker =
                Marker
                |> Option.defaultValue (TraceObjects.Marker.init ())
                |> TraceObjects.Marker.style (
                    ?Color = MarkerColor,
                    ?Outline = MarkerOutline,
                    ?Symbol = MarkerSymbol,
                    ?MultiSymbol = MultiMarkerSymbol,
                    ?Colorscale = MarkerColorScale,
                    ?MultiOpacity = MultiOpacity
                )

            let line =
                Line
                |> Option.defaultValue (Plotly.NET.Line.init ())
                |> Plotly.NET.Line.style (
                    ?Color = LineColor,
                    ?Dash = LineDash,
                    ?Colorscale = LineColorScale,
                    ?Width = LineWidth,
                    Shape = StyleParam.Shape.Spline,
                    ?Smoothing = Smoothing

                )

            let style =
                Trace2DStyle.Scatter(
                    XEncoded = xEncoded,
                    YEncoded = yEncoded,
                    Mode = changeMode StyleParam.Mode.Lines,
                    Marker = marker,
                    Line = line,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?TextPosition = TextPosition,
                    ?MultiTextPosition = MultiTextPosition,
                    ?AlignmentGroup = AlignmentGroup,
                    ?OffsetGroup = OffsetGroup,
                    ?StackGroup = StackGroup,
                    ?Orientation = Orientation,
                    ?GroupNorm = GroupNorm,
                    ?Fill = Fill,
                    ?FillColor = FillColor,
                    ?FillPattern = FillPattern
                )

            let useWebGL = defaultArg UseWebGL false

            Chart.renderScatterTrace useDefaults useWebGL style


        /// <summary>
        /// Creates a Spline chart. A spline chart is a line chart in which data points are connected by smoothed curves: this modification is aimed to improve the design of a chart.
        /// Very similar to Line Plots, spline charts are typically used to visualize an evolution of Y depending on X.
        /// </summary>
        /// <param name="xy">Sets the x,y coordinates of the plotted data.</param>
        /// <param name="ShowMarkers">Whether to show markers for the individual data points</param>
        /// <param name="Smoothing">Sets the amount of smoothing. "0" corresponds to no smoothing (equivalent to a "linear" shape).  Use values between 0. and 1.3</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker</param>
        /// <param name="MarkerOutline">Sets the outline of the marker</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments)</param>
        /// <param name="LineColor">Sets the color of the line</param>
        /// <param name="LineColorScale">Sets the colorscale of the line</param>
        /// <param name="LineWidth">Sets the width of the line</param>
        /// <param name="LineDash">sets the drawing style of the line</param>
        /// <param name="Line">Sets the line (use this for more finegrained control than the other line-associated arguments)</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="StackGroup">Set several traces (on the same subplot) to the same stackgroup in order to add their y values (or their x values if `Orientation` is Horizontal). Stacking also turns `fill` on by default and sets the default `mode` to "lines" irrespective of point count. ou can only stack on a numeric (linear or log) axis. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order</param>
        /// <param name="Orientation">Sets the stacking direction. Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used.</param>
        /// <param name="GroupNorm">Sets the normalization for the sum of this `stackgroup. Only relevant when `stackgroup` is used, and only the first `groupnorm` found in the `stackgroup` will be used</param>
        /// <param name="Fill">Sets the area to fill with a solid color. Defaults to "none" unless this trace is stacked, then it gets "tonexty" ("tonextx") if `orientation` is "v" ("h") Use with `FillColor` if not "none". "tozerox" and "tozeroy" fill to x=0 and y=0 respectively. "tonextx" and "tonexty" fill between the endpoints of this trace and the endpoints of the trace before it, connecting those endpoints with straight lines (to make a stacked area graph); if there is no trace before it, they behave like "tozerox" and "tozeroy". "toself" connects the endpoints of the trace (or each segment of the trace if it has gaps) into a closed shape. "tonext" fills the space between two traces if one completely encloses the other (eg consecutive contour lines), and behaves like "toself" if there is no trace before it. "tonext" should not be used if one trace does not enclose the other. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order.</param>
        /// <param name="FillColor">Sets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
        /// <param name="FillPattern">Sets the pattern within the marker.</param>
        /// <param name="UseWebGL">If true, plotly.js will use the WebGL engine to render this chart. use this when you want to render many objects at once.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Spline
            (
                xy: seq<#IConvertible * #IConvertible>,
                ?ShowMarkers: bool,
                ?Smoothing: float,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                ?Marker: Marker,
                ?LineColor: Color,
                ?LineColorScale: StyleParam.Colorscale,
                ?LineWidth: float,
                ?LineDash: StyleParam.DrawingStyle,
                ?Line: Line,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?StackGroup: string,
                ?Orientation: StyleParam.Orientation,
                ?GroupNorm: StyleParam.GroupNorm,
                ?Fill: StyleParam.Fill,
                ?FillColor: Color,
                ?FillPattern: Pattern,
                ?UseWebGL: bool,
                ?UseDefaults: bool
            ) =
            let x, y = Seq.unzip xy

            Chart.Spline(
                x = x,
                y = y,
                ?ShowMarkers = ShowMarkers,
                ?Smoothing = Smoothing,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerSymbol = MarkerSymbol,
                ?MultiMarkerSymbol = MultiMarkerSymbol,
                ?Marker = Marker,
                ?LineColor = LineColor,
                ?LineColorScale = LineColorScale,
                ?LineWidth = LineWidth,
                ?LineDash = LineDash,
                ?Line = Line,
                ?AlignmentGroup = AlignmentGroup,
                ?OffsetGroup = OffsetGroup,
                ?StackGroup = StackGroup,
                ?Orientation = Orientation,
                ?GroupNorm = GroupNorm,
                ?Fill = Fill,
                ?FillColor = FillColor,
                ?FillPattern = FillPattern,
                ?UseWebGL = UseWebGL,
                ?UseDefaults = UseDefaults

            )


        /// <summary>Creates a bubble chart. A bubble chart is a variation of the Point chart, where the data points get an additional scale by being rendered as bubbles of different sizes.</summary>
        /// <param name="x">Sets the x coordinates of the plotted data.</param>
        /// <param name="y">Sets the y coordinates of the plotted data.</param>
        /// <param name="sizes">Sets the bubble size of the plotted data</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker</param>
        /// <param name="MarkerOutline">Sets the outline of the marker</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments)</param>
        /// <param name="LineColor">Sets the color of the line</param>
        /// <param name="LineColorScale">Sets the colorscale of the line</param>
        /// <param name="LineWidth">Sets the width of the line</param>
        /// <param name="LineDash">sets the drawing style of the line</param>
        /// <param name="Line">Sets the line (use this for more finegrained control than the other line-associated arguments)</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="StackGroup">Set several traces (on the same subplot) to the same stackgroup in order to add their y values (or their x values if `Orientation` is Horizontal). Stacking also turns `fill` on by default and sets the default `mode` to "lines" irrespective of point count. ou can only stack on a numeric (linear or log) axis. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order</param>
        /// <param name="Orientation">Sets the stacking direction. Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used.</param>
        /// <param name="GroupNorm">Sets the normalization for the sum of this `stackgroup. Only relevant when `stackgroup` is used, and only the first `groupnorm` found in the `stackgroup` will be used</param>
        /// <param name="UseWebGL">If true, plotly.js will use the WebGL engine to render this chart. use this when you want to render many objects at once.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Bubble
            (
                x: seq<#IConvertible>,
                y: seq<#IConvertible>,
                sizes: seq<int>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                ?Marker: Marker,
                ?LineColor: Color,
                ?LineColorScale: StyleParam.Colorscale,
                ?LineWidth: float,
                ?LineDash: StyleParam.DrawingStyle,
                ?Line: Line,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?StackGroup: string,
                ?Orientation: StyleParam.Orientation,
                ?GroupNorm: StyleParam.GroupNorm,
                ?UseWebGL: bool,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            // if text position or font is set than show labels (not only when hovering)
            let changeMode =
                StyleParam.ModeUtils.showText (TextPosition.IsSome || MultiTextPosition.IsSome)

            let marker =
                Marker
                |> Option.defaultValue (TraceObjects.Marker.init ())
                |> TraceObjects.Marker.style (
                    ?Color = MarkerColor,
                    ?Outline = MarkerOutline,
                    ?Symbol = MarkerSymbol,
                    ?MultiSymbol = MultiMarkerSymbol,
                    ?Colorscale = MarkerColorScale,
                    ?MultiOpacity = MultiOpacity,
                    MultiSize = sizes
                )

            let line =
                Line
                |> Option.defaultValue (Plotly.NET.Line.init ())
                |> Plotly.NET.Line.style (
                    ?Color = LineColor,
                    ?Dash = LineDash,
                    ?Colorscale = LineColorScale,
                    ?Width = LineWidth
                )

            let style =
                Trace2DStyle.Scatter(
                    X = x,
                    Y = y,
                    Mode = changeMode StyleParam.Mode.Markers,
                    Marker = marker,
                    Line = line,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?TextPosition = TextPosition,
                    ?MultiTextPosition = MultiTextPosition,
                    ?AlignmentGroup = AlignmentGroup,
                    ?OffsetGroup = OffsetGroup,
                    ?StackGroup = StackGroup,
                    ?Orientation = Orientation,
                    ?GroupNorm = GroupNorm
                )

            let useWebGL = defaultArg UseWebGL false

            Chart.renderScatterTrace useDefaults useWebGL style

        /// <summary>Creates a bubble chart from encoded x and y coordinates.</summary>
        /// <param name="xEncoded">Sets the x coordinates of the plotted data as an encoded typed array.</param>
        /// <param name="yEncoded">Sets the y coordinates of the plotted data as an encoded typed array.</param>
        /// <param name="sizes">Sets the bubble sizes of the plotted data.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker</param>
        /// <param name="MarkerOutline">Sets the outline of the marker</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments)</param>
        /// <param name="LineColor">Sets the color of the line</param>
        /// <param name="LineColorScale">Sets the colorscale of the line</param>
        /// <param name="LineWidth">Sets the width of the line</param>
        /// <param name="LineDash">sets the drawing style of the line</param>
        /// <param name="Line">Sets the line (use this for more finegrained control than the other line-associated arguments)</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="StackGroup">Set several traces (on the same subplot) to the same stackgroup in order to add their y values (or their x values if `Orientation` is Horizontal). Stacking also turns `fill` on by default and sets the default `mode` to "lines" irrespective of point count. ou can only stack on a numeric (linear or log) axis. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order</param>
        /// <param name="Orientation">Sets the stacking direction. Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used.</param>
        /// <param name="GroupNorm">Sets the normalization for the sum of this `stackgroup. Only relevant when `stackgroup` is used, and only the first `groupnorm` found in the `stackgroup` will be used</param>
        /// <param name="UseWebGL">If true, plotly.js will use the WebGL engine to render this chart. use this when you want to render many objects at once.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Bubble
            (
                xEncoded: EncodedTypedArray,
                yEncoded: EncodedTypedArray,
                sizes: seq<int>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                ?Marker: Marker,
                ?LineColor: Color,
                ?LineColorScale: StyleParam.Colorscale,
                ?LineWidth: float,
                ?LineDash: StyleParam.DrawingStyle,
                ?Line: Line,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?StackGroup: string,
                ?Orientation: StyleParam.Orientation,
                ?GroupNorm: StyleParam.GroupNorm,
                ?UseWebGL: bool,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let changeMode =
                StyleParam.ModeUtils.showText (TextPosition.IsSome || MultiTextPosition.IsSome)

            let marker =
                Marker
                |> Option.defaultValue (TraceObjects.Marker.init ())
                |> TraceObjects.Marker.style (
                    ?Color = MarkerColor,
                    ?Outline = MarkerOutline,
                    ?Symbol = MarkerSymbol,
                    ?MultiSymbol = MultiMarkerSymbol,
                    ?Colorscale = MarkerColorScale,
                    ?MultiOpacity = MultiOpacity,
                    MultiSize = sizes
                )

            let line =
                Line
                |> Option.defaultValue (Plotly.NET.Line.init ())
                |> Plotly.NET.Line.style (
                    ?Color = LineColor,
                    ?Dash = LineDash,
                    ?Colorscale = LineColorScale,
                    ?Width = LineWidth
                )

            let style =
                Trace2DStyle.Scatter(
                    XEncoded = xEncoded,
                    YEncoded = yEncoded,
                    Mode = changeMode StyleParam.Mode.Markers,
                    Marker = marker,
                    Line = line,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?TextPosition = TextPosition,
                    ?MultiTextPosition = MultiTextPosition,
                    ?AlignmentGroup = AlignmentGroup,
                    ?OffsetGroup = OffsetGroup,
                    ?StackGroup = StackGroup,
                    ?Orientation = Orientation,
                    ?GroupNorm = GroupNorm
                )

            let useWebGL = defaultArg UseWebGL false

            Chart.renderScatterTrace useDefaults useWebGL style

        /// <summary>Creates a bubble chart. A bubble chart is a variation of the Point chart, where the data points get an additional scale by being rendered as bubbles of different sizes.</summary>
        /// <param name="xysizes">Sets the x coordinates, y coordinates, and bubble sizes of the plotted data.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker</param>
        /// <param name="MarkerOutline">Sets the outline of the marker</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments)</param>
        /// <param name="LineColor">Sets the color of the line</param>
        /// <param name="LineColorScale">Sets the colorscale of the line</param>
        /// <param name="LineWidth">Sets the width of the line</param>
        /// <param name="LineDash">sets the drawing style of the line</param>
        /// <param name="Line">Sets the line (use this for more finegrained control than the other line-associated arguments)</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="StackGroup">Set several traces (on the same subplot) to the same stackgroup in order to add their y values (or their x values if `Orientation` is Horizontal). Stacking also turns `fill` on by default and sets the default `mode` to "lines" irrespective of point count. ou can only stack on a numeric (linear or log) axis. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order</param>
        /// <param name="Orientation">Sets the stacking direction. Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used.</param>
        /// <param name="GroupNorm">Sets the normalization for the sum of this `stackgroup. Only relevant when `stackgroup` is used, and only the first `groupnorm` found in the `stackgroup` will be used</param>
        /// <param name="UseWebGL">If true, plotly.js will use the WebGL engine to render this chart. use this when you want to render many objects at once.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Bubble
            (
                xysizes: seq<#IConvertible * #IConvertible * int>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                ?Marker: Marker,
                ?LineColor: Color,
                ?LineColorScale: StyleParam.Colorscale,
                ?LineWidth: float,
                ?LineDash: StyleParam.DrawingStyle,
                ?Line: Line,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?StackGroup: string,
                ?Orientation: StyleParam.Orientation,
                ?GroupNorm: StyleParam.GroupNorm,
                ?UseWebGL: bool,
                ?UseDefaults: bool
            ) =
            let x, y, sizes = Seq.unzip3 xysizes

            Chart.Bubble(
                x = x,
                y = y,
                sizes = sizes,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerSymbol = MarkerSymbol,
                ?MultiMarkerSymbol = MultiMarkerSymbol,
                ?Marker = Marker,
                ?LineColor = LineColor,
                ?LineColorScale = LineColorScale,
                ?LineWidth = LineWidth,
                ?LineDash = LineDash,
                ?Line = Line,
                ?AlignmentGroup = AlignmentGroup,
                ?OffsetGroup = OffsetGroup,
                ?StackGroup = StackGroup,
                ?Orientation = Orientation,
                ?GroupNorm = GroupNorm,
                ?UseWebGL = UseWebGL,
                ?UseDefaults = UseDefaults

            )

        /// <summary>
        /// Displays a range of data by plotting three Y values per data point (upper, mid, lower).
        ///
        /// The mid Y value usually resembles some kind of central tendency and the upper/lower Y values some kind of spread.
        /// </summary>
        /// <param name="x">Sets the x coordinates of the plotted data.</param>
        /// <param name="y">Sets the y coordinates of the plotted data for the mid Y value.</param>
        /// <param name="upper">Sets the y coordinates of the plotted data for the upper Y value.</param>
        /// <param name="lower">Sets the y coordinates of the plotted data for the lower Y value.</param>
        /// <param name="mode">Determines the drawing mode for this scatter trace.</param>
        /// <param name="Name">Sets the trace name of the mid Y values. The trace name appear as the legend item and on hover</param>
        /// <param name="GroupName">Sets the name of the legendgroup for the three traces of this plot.</param>
        /// <param name="ShowMarkers">Determines whether or not an To show markers for each datum.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Text">Sets a text associated with each datum for the mid Y values.</param>
        /// <param name="MultiText">Sets individual text for each datum for the mid Y values.</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker for the mid Y values.</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker for the mid Y values.</param>
        /// <param name="MarkerOutline">Sets the outline of the marker for the mid Y values.</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum for the mid Y values.</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum for the mid Y values.</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments) for the mid Y values.</param>
        /// <param name="LineColor">Sets the color of the line for the mid Y values.</param>
        /// <param name="LineColorScale">Sets the colorscale of the line for the mid Y values.</param>
        /// <param name="LineWidth">Sets the width of the line for the mid Y values.</param>
        /// <param name="LineDash">sets the drawing style of the line for the mid Y values.</param>
        /// <param name="Line">Sets the line (use this for more finegrained control than the other line-associated arguments) for the mid Y values.</param>
        /// <param name="RangeColor">Sets the color of the range between upper and lower Y values.</param>
        /// <param name="RangePattern">Sets the pattern of the range between upper and lower Y values.</param>
        /// <param name="UpperText">Sets a text associated with each datum for the upper Y values.</param>
        /// <param name="MultiUpperText">Sets individual text for each datum for the upper Y values.</param>
        /// <param name="LowerText">Sets a text associated with each datum for the lower Y values.</param>
        /// <param name="MultiLowerText">Sets individual text for each datum for the lower Y values.</param>
        /// <param name="TextFont">Sets the text font for all Text items</param>
        /// <param name="LowerName">Sets the name of the lower Y value trace.</param>
        /// <param name="LowerLine">Sets the line for the lower Y values.</param>
        /// <param name="LowerMarker">Sets the marker for the lower Y values.</param>
        /// <param name="UpperName">Sets the name of the uper Y value trace.</param>
        /// <param name="UpperLine">Sets the line for the upper Y values.</param>
        /// <param name="UpperMarker">Sets the marker for the upper Y values.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Range
            (
                x: seq<#IConvertible>,
                y: seq<#IConvertible>,
                upper: seq<#IConvertible>,
                lower: seq<#IConvertible>,
                mode: StyleParam.Mode,
                ?Name: string,
                ?GroupName: string,
                ?ShowMarkers: bool,
                ?ShowLegend: bool,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                ?Marker: Marker,
                ?UpperMarker: Marker,
                ?LowerMarker: Marker,
                ?LineColor: Color,
                ?LineColorScale: StyleParam.Colorscale,
                ?LineWidth: float,
                ?LineDash: StyleParam.DrawingStyle,
                ?Line: Line,
                ?UpperLine: Line,
                ?LowerLine: Line,
                ?RangeColor: Color,
                ?RangePattern: Pattern,
                ?UpperText: #IConvertible,
                ?MultiUpperText: seq<#IConvertible>,
                ?LowerText: #IConvertible,
                ?MultiLowerText: seq<#IConvertible>,
                ?TextFont: Font,
                ?LowerName: string,
                ?UpperName: string,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let upperName = defaultArg UpperName "upper"
            let lowerName = defaultArg LowerName "lower"

            // if text position or font is set than show labels (not only when hovering)
            let changeMode =
                let isShowMarker =
                    match ShowMarkers with
                    | Some isShow -> isShow
                    | Option.None -> false

                StyleParam.ModeUtils.showText (TextPosition.IsSome || TextFont.IsSome)
                >> StyleParam.ModeUtils.showMarker (isShowMarker)

            let trace =
                Chart.Scatter(
                    X = x,
                    Y = y,
                    Mode = changeMode mode,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?TextPosition = TextPosition,
                    ?MultiTextPosition = MultiTextPosition,
                    ?MarkerColor = MarkerColor,
                    ?MarkerColorScale = MarkerColorScale,
                    ?MarkerOutline = MarkerOutline,
                    ?MarkerSymbol = MarkerSymbol,
                    ?MultiMarkerSymbol = MultiMarkerSymbol,
                    ?Marker = Marker,
                    ?LineColor = LineColor,
                    ?LineColorScale = LineColorScale,
                    ?LineWidth = LineWidth,
                    ?LineDash = LineDash,
                    ?Line = Line
                )
                |> GenericChart.mapTrace (
                    Trace2DStyle.Scatter(
                        LegendGroup = (defaultArg GroupName "Range"),
                        LegendGroupTitle = (Title.init (Text = (defaultArg GroupName "Range")))
                    )
                )

            let lower =
                Trace2D.initScatter (
                    Trace2DStyle.Scatter(
                        X = x,
                        Y = lower,
                        Mode = changeMode mode,
                        ?FillColor = RangeColor,
                        ?Name = Some lowerName,
                        ShowLegend = (defaultArg ShowLegend true),
                        ?Text = LowerText,
                        ?MultiText = MultiLowerText,
                        ?TextPosition = TextPosition,
                        ?TextFont = TextFont,
                        ?Marker = LowerMarker,
                        ?Line = LowerLine,
                        LegendGroup = (defaultArg GroupName "Range")
                    )
                )
                |> TraceStyle.Marker(
                    Color =
                        if RangeColor.IsSome then
                            RangeColor.Value
                        else
                            (Plotly.NET.Color.fromString "rgba(0,0,0,0.5)")
                )

            let upper =
                Trace2D.initScatter (
                    Trace2DStyle.Scatter(
                        X = x,
                        Y = upper,
                        Mode = changeMode mode,
                        Fill = StyleParam.Fill.ToNext_y,
                        ?FillColor = RangeColor,
                        ?FillPattern = RangePattern,
                        ?Name = Some upperName,
                        ShowLegend = (defaultArg ShowLegend true),
                        ?Text = UpperText,
                        ?MultiText = MultiUpperText,
                        ?TextPosition = TextPosition,
                        ?TextFont = TextFont,
                        ?Marker = UpperMarker,
                        ?Line = UpperLine,
                        LegendGroup = (defaultArg GroupName "Range")
                    )
                )
                |> TraceStyle.Marker(
                    Color =
                        if RangeColor.IsSome then
                            RangeColor.Value
                        else
                            (Plotly.NET.Color.fromString "rgba(0,0,0,0.5)")
                )

            GenericChart.ofTraceObjects
                useDefaults
                [
                    lower
                    upper
                    yield! (GenericChart.getTraces trace)
                ]

        /// <summary>
        /// Displays a range of data from encoded x and y coordinates by plotting three encoded Y values per data point (upper, mid, lower).
        /// </summary>
        /// <param name="xEncoded">Sets the x coordinates of the plotted data as an encoded typed array.</param>
        /// <param name="yEncoded">Sets the y coordinates of the plotted data for the mid Y values as an encoded typed array.</param>
        /// <param name="upperEncoded">Sets the y coordinates of the plotted data for the upper Y value as an encoded typed array.</param>
        /// <param name="lowerEncoded">Sets the y coordinates of the plotted data for the lower Y value as an encoded typed array.</param>
        /// <param name="mode">Determines the drawing mode for this scatter trace.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="GroupName">Sets the name of the legendgroup for the three traces of this plot.</param>
        /// <param name="ShowMarkers">Determines whether or not an To show markers for each datum.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Text">Sets a text associated with each datum for the mid Y values.</param>
        /// <param name="MultiText">Sets individual text for each datum for the mid Y values.</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker for the mid Y values.</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker for the mid Y values.</param>
        /// <param name="MarkerOutline">Sets the outline of the marker for the mid Y values.</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum for the mid Y values.</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum for the mid Y values.</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments) for the mid Y values.</param>
        /// <param name="LineColor">Sets the color of the line for the mid Y values.</param>
        /// <param name="LineColorScale">Sets the colorscale of the line for the mid Y values.</param>
        /// <param name="LineWidth">Sets the width of the line for the mid Y values.</param>
        /// <param name="LineDash">sets the drawing style of the line for the mid Y values.</param>
        /// <param name="Line">Sets the line (use this for more finegrained control than the other line-associated arguments) for the mid Y values.</param>
        /// <param name="RangeColor">Sets the color of the range between upper and lower Y values.</param>
        /// <param name="RangePattern">Sets the pattern of the range between upper and lower Y values.</param>
        /// <param name="UpperText">Sets a text associated with each datum for the upper Y values.</param>
        /// <param name="MultiUpperText">Sets individual text for each datum for the upper Y values.</param>
        /// <param name="LowerText">Sets a text associated with each datum for the lower Y values.</param>
        /// <param name="MultiLowerText">Sets individual text for each datum for the lower Y values.</param>
        /// <param name="TextFont">Sets the text font for all Text items</param>
        /// <param name="LowerName">Sets the name of the lower Y value trace.</param>
        /// <param name="LowerLine">Sets the line for the lower Y values.</param>
        /// <param name="LowerMarker">Sets the marker for the lower Y values.</param>
        /// <param name="UpperName">Sets the name of the uper Y value trace.</param>
        /// <param name="UpperLine">Sets the line for the upper Y values.</param>
        /// <param name="UpperMarker">Sets the marker for the upper Y values.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Range
            (
                xEncoded: EncodedTypedArray,
                yEncoded: EncodedTypedArray,
                upperEncoded: EncodedTypedArray,
                lowerEncoded: EncodedTypedArray,
                mode: StyleParam.Mode,
                ?Name: string,
                ?GroupName: string,
                ?ShowMarkers: bool,
                ?ShowLegend: bool,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                ?Marker: Marker,
                ?UpperMarker: Marker,
                ?LowerMarker: Marker,
                ?LineColor: Color,
                ?LineColorScale: StyleParam.Colorscale,
                ?LineWidth: float,
                ?LineDash: StyleParam.DrawingStyle,
                ?Line: Line,
                ?UpperLine: Line,
                ?LowerLine: Line,
                ?RangeColor: Color,
                ?RangePattern: Pattern,
                ?UpperText: #IConvertible,
                ?MultiUpperText: seq<#IConvertible>,
                ?LowerText: #IConvertible,
                ?MultiLowerText: seq<#IConvertible>,
                ?TextFont: Font,
                ?LowerName: string,
                ?UpperName: string,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let upperName = defaultArg UpperName "upper"
            let lowerName = defaultArg LowerName "lower"

            let changeMode =
                let isShowMarker =
                    match ShowMarkers with
                    | Some isShow -> isShow
                    | Option.None -> false

                StyleParam.ModeUtils.showText (TextPosition.IsSome || TextFont.IsSome)
                >> StyleParam.ModeUtils.showMarker (isShowMarker)

            let trace =
                Chart.Scatter(
                    XEncoded = xEncoded,
                    YEncoded = yEncoded,
                    Mode = changeMode mode,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?TextPosition = TextPosition,
                    ?MultiTextPosition = MultiTextPosition,
                    ?MarkerColor = MarkerColor,
                    ?MarkerColorScale = MarkerColorScale,
                    ?MarkerOutline = MarkerOutline,
                    ?MarkerSymbol = MarkerSymbol,
                    ?MultiMarkerSymbol = MultiMarkerSymbol,
                    ?Marker = Marker,
                    ?LineColor = LineColor,
                    ?LineColorScale = LineColorScale,
                    ?LineWidth = LineWidth,
                    ?LineDash = LineDash,
                    ?Line = Line
                )
                |> GenericChart.mapTrace (
                    Trace2DStyle.Scatter(
                        LegendGroup = (defaultArg GroupName "Range"),
                        LegendGroupTitle = (Title.init (Text = (defaultArg GroupName "Range")))
                    )
                )

            let lower =
                Trace2D.initScatter (
                    Trace2DStyle.Scatter(
                        XEncoded = xEncoded,
                        YEncoded = lowerEncoded,
                        Mode = changeMode mode,
                        ?FillColor = RangeColor,
                        ?Name = Some lowerName,
                        ShowLegend = (defaultArg ShowLegend true),
                        ?Text = LowerText,
                        ?MultiText = MultiLowerText,
                        ?TextPosition = TextPosition,
                        ?TextFont = TextFont,
                        ?Marker = LowerMarker,
                        ?Line = LowerLine,
                        LegendGroup = (defaultArg GroupName "Range")
                    )
                )
                |> TraceStyle.Marker(
                    Color =
                        if RangeColor.IsSome then
                            RangeColor.Value
                        else
                            (Plotly.NET.Color.fromString "rgba(0,0,0,0.5)")
                )

            let upper =
                Trace2D.initScatter (
                    Trace2DStyle.Scatter(
                        XEncoded = xEncoded,
                        YEncoded = upperEncoded,
                        Mode = changeMode mode,
                        Fill = StyleParam.Fill.ToNext_y,
                        ?FillColor = RangeColor,
                        ?FillPattern = RangePattern,
                        ?Name = Some upperName,
                        ShowLegend = (defaultArg ShowLegend true),
                        ?Text = UpperText,
                        ?MultiText = MultiUpperText,
                        ?TextPosition = TextPosition,
                        ?TextFont = TextFont,
                        ?Marker = UpperMarker,
                        ?Line = UpperLine,
                        LegendGroup = (defaultArg GroupName "Range")
                    )
                )
                |> TraceStyle.Marker(
                    Color =
                        if RangeColor.IsSome then
                            RangeColor.Value
                        else
                            (Plotly.NET.Color.fromString "rgba(0,0,0,0.5)")
                )

            GenericChart.ofTraceObjects
                useDefaults
                [
                    lower
                    upper
                    yield! (GenericChart.getTraces trace)
                ]

        /// <summary>
        /// Displays a range of data by plotting three Y values per data point (upper, mid, lower).
        ///
        /// The mid Y value usually resembles some kind of central tendency and the upper/lower Y values some kind of spread.
        /// </summary>
        /// <param name="xy">Sets the x and y coordinates of the plotted data (x is used for all y data, the y coordinates are those of the mod values).</param>
        /// <param name="upper">Sets the y coordinates of the plotted data for the upper Y value.</param>
        /// <param name="lower">Sets the y coordinates of the plotted data for the lower Y value.</param>
        /// <param name="mode">Determines the drawing mode for this scatter trace.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="GroupName">Sets the name of the legendgroup for the three traces of this plot.</param>
        /// <param name="ShowMarkers">Determines whether or not an To show markers for each datum.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Text">Sets a text associated with each datum for the mid Y values.</param>
        /// <param name="MultiText">Sets individual text for each datum for the mid Y values.</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker for the mid Y values.</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker for the mid Y values.</param>
        /// <param name="MarkerOutline">Sets the outline of the marker for the mid Y values.</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum for the mid Y values.</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum for the mid Y values.</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments) for the mid Y values.</param>
        /// <param name="LineColor">Sets the color of the line for the mid Y values.</param>
        /// <param name="LineColorScale">Sets the colorscale of the line for the mid Y values.</param>
        /// <param name="LineWidth">Sets the width of the line for the mid Y values.</param>
        /// <param name="LineDash">sets the drawing style of the line for the mid Y values.</param>
        /// <param name="Line">Sets the line (use this for more finegrained control than the other line-associated arguments) for the mid Y values.</param>
        /// <param name="RangeColor">Sets the color of the range between upper and lower Y values.</param>
        /// <param name="RangePattern">Sets the pattern of the range between upper and lower Y values.</param>
        /// <param name="UpperText">Sets a text associated with each datum for the upper Y values.</param>
        /// <param name="MultiUpperText">Sets individual text for each datum for the upper Y values.</param>
        /// <param name="LowerText">Sets a text associated with each datum for the lower Y values.</param>
        /// <param name="MultiLowerText">Sets individual text for each datum for the lower Y values.</param>
        /// <param name="TextFont">Sets the text font for all Text items</param>
        /// <param name="LowerName">Sets the name of the lower Y value trace.</param>
        /// <param name="LowerLine">Sets the line for the lower Y values.</param>
        /// <param name="LowerMarker">Sets the marker for the lower Y values.</param>
        /// <param name="UpperName">Sets the name of the uper Y value trace.</param>
        /// <param name="UpperLine">Sets the line for the upper Y values.</param>
        /// <param name="UpperMarker">Sets the marker for the upper Y values.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Range
            (
                xy: seq<#IConvertible * #IConvertible>,
                upper: seq<#IConvertible>,
                lower: seq<#IConvertible>,
                mode: StyleParam.Mode,
                ?Name: string,
                ?GroupName: string,
                ?ShowMarkers: bool,
                ?ShowLegend: bool,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                ?Marker: Marker,
                ?UpperMarker: Marker,
                ?LowerMarker: Marker,
                ?LineColor: Color,
                ?LineColorScale: StyleParam.Colorscale,
                ?LineWidth: float,
                ?LineDash: StyleParam.DrawingStyle,
                ?Line: Line,
                ?UpperLine: Line,
                ?LowerLine: Line,
                ?RangeColor: Color,
                ?RangePattern: Pattern,
                ?UpperText: #IConvertible,
                ?MultiUpperText: seq<#IConvertible>,
                ?LowerText: #IConvertible,
                ?MultiLowerText: seq<#IConvertible>,
                ?TextFont: Font,
                ?LowerName: string,
                ?UpperName: string,
                ?UseDefaults: bool
            ) =
            let x, y = Seq.unzip xy

            Chart.Range(
                x = x,
                y = y,
                upper = upper,
                lower = lower,
                mode = mode,
                ?Name = Name,
                ?GroupName = GroupName,
                ?ShowMarkers = ShowMarkers,
                ?ShowLegend = ShowLegend,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerSymbol = MarkerSymbol,
                ?MultiMarkerSymbol = MultiMarkerSymbol,
                ?Marker = Marker,
                ?UpperMarker = UpperMarker,
                ?LowerMarker = LowerMarker,
                ?LineColor = LineColor,
                ?LineColorScale = LineColorScale,
                ?LineWidth = LineWidth,
                ?LineDash = LineDash,
                ?Line = Line,
                ?UpperLine = UpperLine,
                ?LowerLine = LowerLine,
                ?RangeColor = RangeColor,
                ?RangePattern = RangePattern,
                ?UpperText = UpperText,
                ?MultiUpperText = MultiUpperText,
                ?LowerText = LowerText,
                ?MultiLowerText = MultiLowerText,
                ?TextFont = TextFont,
                ?LowerName = LowerName,
                ?UpperName = UpperName,
                ?UseDefaults = UseDefaults
            )
            
