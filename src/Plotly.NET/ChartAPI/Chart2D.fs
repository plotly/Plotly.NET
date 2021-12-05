namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects

open DynamicObj
open System
open System.IO
open System.Runtime.CompilerServices

open GenericChart
open System.Runtime.InteropServices

[<AutoOpen>]
module Chart2D =
    [<Extension>]
    type Chart =
        [<Extension>]
        static member internal renderScatterTrace (useDefaults: bool) (useWebGL: bool) (style: Trace2D -> Trace2D) =
            if useWebGL then
                Trace2D.initScatterGL style |> GenericChart.ofTraceObject useDefaults
            else
                Trace2D.initScatter style |> GenericChart.ofTraceObject useDefaults

        [<Extension>]
        static member internal renderHeatmapTrace (useDefaults: bool) (useWebGL: bool) (style: Trace2D -> Trace2D) =
            if useWebGL then
                Trace2D.initHeatmapGL style |> GenericChart.ofTraceObject useDefaults
            else
                Trace2D.initHeatmap style |> GenericChart.ofTraceObject useDefaults



        /// <summary>
        /// Creates a Scatter chart. Scatter charts are the basis of Point, Line, and Bubble Charts in Plotly, and can be customized as such. We also provide abstractions for those: Chart.Line, Chart.Point, Chart.Bubble
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
        /// <param name="StackGroup">Set several traces (on the same subplot) to the same stackgroup in order to add their y values (or their x values if `Orientation` is Horizontal). Stacking also turns `fill` on by default and sets the default `mode` to "lines" irrespective of point count. ou can only stack on a numeric (linear or log) axis. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order</param>
        /// <param name="Orientation">Sets the stacking direction. Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used.</param>
        /// <param name="GroupNorm">Sets the normalization for the sum of this `stackgroup. Only relevant when `stackgroup` is used, and only the first `groupnorm` found in the `stackgroup` will be used</param>
        /// <param name="UseWebGL">If true, plotly.js will use the WebGL engine to render this chart. use this when you want to render many objects at once.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Scatter
            (
                x: seq<#IConvertible>,
                y: seq<#IConvertible>,
                mode: StyleParam.Mode,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?MultiOpacity: seq<float>,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?TextPosition: StyleParam.TextPosition,
                [<Optional; DefaultParameterValue(null)>] ?MultiTextPosition: seq<StyleParam.TextPosition>,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?MarkerOutline: Line,
                [<Optional; DefaultParameterValue(null)>] ?MarkerSymbol: StyleParam.MarkerSymbol,
                [<Optional; DefaultParameterValue(null)>] ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
                [<Optional; DefaultParameterValue(null)>] ?LineColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?LineColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?LineWidth: float,
                [<Optional; DefaultParameterValue(null)>] ?LineDash: StyleParam.DrawingStyle,
                [<Optional; DefaultParameterValue(null)>] ?Line: Line,
                [<Optional; DefaultParameterValue(null)>] ?StackGroup: string,
                [<Optional; DefaultParameterValue(null)>] ?Orientation: StyleParam.Orientation,
                [<Optional; DefaultParameterValue(null)>] ?GroupNorm: StyleParam.GroupNorm,
                [<Optional; DefaultParameterValue(false)>] ?UseWebGL: bool,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            let useDefaults = defaultArg UseDefaults true

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
                    X = x,
                    Y = y,
                    Mode = mode,
                    Marker = marker,
                    Line = line,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?TextPosition = TextPosition,
                    ?MultiTextPosition = MultiTextPosition,
                    ?StackGroup = StackGroup,
                    ?Orientation = Orientation,
                    ?GroupNorm = GroupNorm
                )

            let useWebGL = defaultArg UseWebGL false

            Chart.renderScatterTrace useDefaults useWebGL style


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
        /// <param name="StackGroup">Set several traces (on the same subplot) to the same stackgroup in order to add their y values (or their x values if `Orientation` is Horizontal). Stacking also turns `fill` on by default and sets the default `mode` to "lines" irrespective of point count. ou can only stack on a numeric (linear or log) axis. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order</param>
        /// <param name="Orientation">Sets the stacking direction. Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used.</param>
        /// <param name="GroupNorm">Sets the normalization for the sum of this `stackgroup. Only relevant when `stackgroup` is used, and only the first `groupnorm` found in the `stackgroup` will be used</param>
        /// <param name="UseWebGL">If true, plotly.js will use the WebGL engine to render this chart. use this when you want to render many objects at once.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Scatter
            (
                xy: seq<#IConvertible * #IConvertible>,
                mode: StyleParam.Mode,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?MultiOpacity: seq<float>,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?TextPosition: StyleParam.TextPosition,
                [<Optional; DefaultParameterValue(null)>] ?MultiTextPosition: seq<StyleParam.TextPosition>,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?MarkerOutline: Line,
                [<Optional; DefaultParameterValue(null)>] ?MarkerSymbol: StyleParam.MarkerSymbol,
                [<Optional; DefaultParameterValue(null)>] ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
                [<Optional; DefaultParameterValue(null)>] ?LineColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?LineColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?LineWidth: float,
                [<Optional; DefaultParameterValue(null)>] ?LineDash: StyleParam.DrawingStyle,
                [<Optional; DefaultParameterValue(null)>] ?Line: Line,
                [<Optional; DefaultParameterValue(null)>] ?StackGroup: string,
                [<Optional; DefaultParameterValue(null)>] ?Orientation: StyleParam.Orientation,
                [<Optional; DefaultParameterValue(null)>] ?GroupNorm: StyleParam.GroupNorm,
                [<Optional; DefaultParameterValue(false)>] ?UseWebGL: bool,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            let x, y = Seq.unzip xy

            Chart.Scatter(
                x,
                y,
                mode,
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
                ?StackGroup = StackGroup,
                ?Orientation = Orientation,
                ?GroupNorm = GroupNorm,
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
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?MultiOpacity: seq<float>,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?TextPosition: StyleParam.TextPosition,
                [<Optional; DefaultParameterValue(null)>] ?MultiTextPosition: seq<StyleParam.TextPosition>,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?MarkerOutline: Line,
                [<Optional; DefaultParameterValue(null)>] ?MarkerSymbol: StyleParam.MarkerSymbol,
                [<Optional; DefaultParameterValue(null)>] ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
                [<Optional; DefaultParameterValue(null)>] ?StackGroup: string,
                [<Optional; DefaultParameterValue(null)>] ?Orientation: StyleParam.Orientation,
                [<Optional; DefaultParameterValue(null)>] ?GroupNorm: StyleParam.GroupNorm,
                [<Optional; DefaultParameterValue(false)>] ?UseWebGL: bool,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            let useDefaults = defaultArg UseDefaults true
            // if text position or font is set, then show labels (not only when hovering)
            let changeMode =
                StyleParam.ModeUtils.showText (TextPosition.IsSome || MultiTextPosition.IsSome)

            let useWebGL = defaultArg UseWebGL false

            Chart.Scatter(
                x,
                y,
                mode = changeMode StyleParam.Mode.Markers,
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
        /// <param name="StackGroup">Set several traces (on the same subplot) to the same stackgroup in order to add their y values (or their x values if `Orientation` is Horizontal). Stacking also turns `fill` on by default and sets the default `mode` to "lines" irrespective of point count. ou can only stack on a numeric (linear or log) axis. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order</param>
        /// <param name="Orientation">Sets the stacking direction. Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used.</param>
        /// <param name="GroupNorm">Sets the normalization for the sum of this `stackgroup. Only relevant when `stackgroup` is used, and only the first `groupnorm` found in the `stackgroup` will be used</param>
        /// <param name="UseWebGL">If true, plotly.js will use the WebGL engine to render this chart. use this when you want to render many objects at once.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Point
            (
                xy: seq<#IConvertible * #IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?MultiOpacity: seq<float>,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?TextPosition: StyleParam.TextPosition,
                [<Optional; DefaultParameterValue(null)>] ?MultiTextPosition: seq<StyleParam.TextPosition>,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?MarkerOutline: Line,
                [<Optional; DefaultParameterValue(null)>] ?MarkerSymbol: StyleParam.MarkerSymbol,
                [<Optional; DefaultParameterValue(null)>] ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
                [<Optional; DefaultParameterValue(null)>] ?StackGroup: string,
                [<Optional; DefaultParameterValue(null)>] ?Orientation: StyleParam.Orientation,
                [<Optional; DefaultParameterValue(null)>] ?GroupNorm: StyleParam.GroupNorm,
                [<Optional; DefaultParameterValue(false)>] ?UseWebGL: bool,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =
            let x, y = Seq.unzip xy

            Chart.Point(
                x,
                y,
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
                ?StackGroup = StackGroup,
                ?Orientation = Orientation,
                ?GroupNorm = GroupNorm,
                ?UseWebGL = UseWebGL,
                ?UseDefaults = UseDefaults
            )


        /// <summary> Creates a Line chart, which uses a Line plotted between the given datums in a 2D space to visualize typically an evolution of Y depending on X.</summary>
        /// <param name="x">Sets the x coordinates of the plotted data.</param>
        /// <param name="y">Sets the y coordinates of the plotted data.</param>
        /// <param name="ShowMarkers">Wether to show markers for the individual data points</param>
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
        /// <param name="StackGroup">Set several traces (on the same subplot) to the same stackgroup in order to add their y values (or their x values if `Orientation` is Horizontal). Stacking also turns `fill` on by default and sets the default `mode` to "lines" irrespective of point count. ou can only stack on a numeric (linear or log) axis. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order</param>
        /// <param name="Orientation">Sets the stacking direction. Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used.</param>
        /// <param name="GroupNorm">Sets the normalization for the sum of this `stackgroup. Only relevant when `stackgroup` is used, and only the first `groupnorm` found in the `stackgroup` will be used</param>
        /// <param name="UseWebGL">If true, plotly.js will use the WebGL engine to render this chart. use this when you want to render many objects at once.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Line
            (
                x: seq<#IConvertible>,
                y: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?ShowMarkers: bool,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?MultiOpacity: seq<float>,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?TextPosition: StyleParam.TextPosition,
                [<Optional; DefaultParameterValue(null)>] ?MultiTextPosition: seq<StyleParam.TextPosition>,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?MarkerOutline: Line,
                [<Optional; DefaultParameterValue(null)>] ?MarkerSymbol: StyleParam.MarkerSymbol,
                [<Optional; DefaultParameterValue(null)>] ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
                [<Optional; DefaultParameterValue(null)>] ?LineColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?LineColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?LineWidth: float,
                [<Optional; DefaultParameterValue(null)>] ?LineDash: StyleParam.DrawingStyle,
                [<Optional; DefaultParameterValue(null)>] ?Line: Line,
                [<Optional; DefaultParameterValue(null)>] ?StackGroup: string,
                [<Optional; DefaultParameterValue(null)>] ?Orientation: StyleParam.Orientation,
                [<Optional; DefaultParameterValue(null)>] ?GroupNorm: StyleParam.GroupNorm,
                [<Optional; DefaultParameterValue(false)>] ?UseWebGL: bool,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            let useDefaults = defaultArg UseDefaults true

            // if text position or font is set than show labels (not only when hovering)
            let changeMode =
                let isShowMarker =
                    match ShowMarkers with
                    | Some isShow -> isShow
                    | Option.None -> false

                StyleParam.ModeUtils.showText (TextPosition.IsSome || MultiTextPosition.IsSome)
                >> StyleParam.ModeUtils.showMarker (isShowMarker)

            Chart.Scatter(
                x,
                y,
                mode = changeMode StyleParam.Mode.Lines,
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
                ?StackGroup = StackGroup,
                ?Orientation = Orientation,
                ?GroupNorm = GroupNorm,
                ?UseWebGL = UseWebGL,
                ?UseDefaults = UseDefaults

            )



        /// <summary>Creates a Line chart, which uses a Line plotted between the given datums in a 2D space to visualize typically an evolution of Y depending on X.</summary>
        /// <param name="xy">Sets the x,y coordinates of the plotted data.</param>
        /// <param name="ShowMarkers">Wether to show markers for the individual data points</param>
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
        /// <param name="StackGroup">Set several traces (on the same subplot) to the same stackgroup in order to add their y values (or their x values if `Orientation` is Horizontal). Stacking also turns `fill` on by default and sets the default `mode` to "lines" irrespective of point count. ou can only stack on a numeric (linear or log) axis. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order</param>
        /// <param name="Orientation">Sets the stacking direction. Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used.</param>
        /// <param name="GroupNorm">Sets the normalization for the sum of this `stackgroup. Only relevant when `stackgroup` is used, and only the first `groupnorm` found in the `stackgroup` will be used</param>
        /// <param name="UseWebGL">If true, plotly.js will use the WebGL engine to render this chart. use this when you want to render many objects at once.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Line
            (
                xy: seq<#IConvertible * #IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?ShowMarkers: bool,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?MultiOpacity: seq<float>,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?TextPosition: StyleParam.TextPosition,
                [<Optional; DefaultParameterValue(null)>] ?MultiTextPosition: seq<StyleParam.TextPosition>,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?MarkerOutline: Line,
                [<Optional; DefaultParameterValue(null)>] ?MarkerSymbol: StyleParam.MarkerSymbol,
                [<Optional; DefaultParameterValue(null)>] ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
                [<Optional; DefaultParameterValue(null)>] ?LineColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?LineColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?LineWidth: float,
                [<Optional; DefaultParameterValue(null)>] ?LineDash: StyleParam.DrawingStyle,
                [<Optional; DefaultParameterValue(null)>] ?Line: Line,
                [<Optional; DefaultParameterValue(null)>] ?StackGroup: string,
                [<Optional; DefaultParameterValue(null)>] ?Orientation: StyleParam.Orientation,
                [<Optional; DefaultParameterValue(null)>] ?GroupNorm: StyleParam.GroupNorm,
                [<Optional; DefaultParameterValue(false)>] ?UseWebGL: bool,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =
            let x, y = Seq.unzip xy

            Chart.Line(
                x,
                y,
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
                ?StackGroup = StackGroup,
                ?Orientation = Orientation,
                ?GroupNorm = GroupNorm,
                ?UseWebGL = UseWebGL,
                ?UseDefaults = UseDefaults
            )


        /// <summary>Creates a Spline chart. A spline chart is a line chart in which data points are connected by smoothed curves: this modification is aimed to improve the design of a chart.
        /// Very similar to Line Plots, spline charts are typically used to visualize an evolution of Y depending on X. </summary>
        /// <param name="x">Sets the x coordinates of the plotted data.</param>
        /// <param name="y">Sets the y coordinates of the plotted data.</param>
        /// <param name="ShowMarkers">Wether to show markers for the individual data points</param>
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
        /// <param name="StackGroup">Set several traces (on the same subplot) to the same stackgroup in order to add their y values (or their x values if `Orientation` is Horizontal). Stacking also turns `fill` on by default and sets the default `mode` to "lines" irrespective of point count. ou can only stack on a numeric (linear or log) axis. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order</param>
        /// <param name="Orientation">Sets the stacking direction. Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used.</param>
        /// <param name="GroupNorm">Sets the normalization for the sum of this `stackgroup. Only relevant when `stackgroup` is used, and only the first `groupnorm` found in the `stackgroup` will be used</param>
        /// <param name="UseWebGL">If true, plotly.js will use the WebGL engine to render this chart. use this when you want to render many objects at once.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Spline
            (
                x: seq<#IConvertible>,
                y: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?ShowMarkers: bool,
                [<Optional; DefaultParameterValue(null)>] ?Smoothing: float,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?MultiOpacity: seq<float>,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?TextPosition: StyleParam.TextPosition,
                [<Optional; DefaultParameterValue(null)>] ?MultiTextPosition: seq<StyleParam.TextPosition>,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?MarkerOutline: Line,
                [<Optional; DefaultParameterValue(null)>] ?MarkerSymbol: StyleParam.MarkerSymbol,
                [<Optional; DefaultParameterValue(null)>] ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
                [<Optional; DefaultParameterValue(null)>] ?LineColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?LineColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?LineWidth: float,
                [<Optional; DefaultParameterValue(null)>] ?LineDash: StyleParam.DrawingStyle,
                [<Optional; DefaultParameterValue(null)>] ?Line: Line,
                [<Optional; DefaultParameterValue(null)>] ?StackGroup: string,
                [<Optional; DefaultParameterValue(null)>] ?Orientation: StyleParam.Orientation,
                [<Optional; DefaultParameterValue(null)>] ?GroupNorm: StyleParam.GroupNorm,
                [<Optional; DefaultParameterValue(false)>] ?UseWebGL: bool,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            // if text position set then show labels (not only when hovering)
            let changeMode =
                let isShowMarker =
                    match ShowMarkers with
                    | Some isShow -> isShow
                    | Option.None -> false

                StyleParam.ModeUtils.showText (TextPosition.IsSome || MultiTextPosition.IsSome)
                >> StyleParam.ModeUtils.showMarker (isShowMarker)

            let useDefaults = defaultArg UseDefaults true

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
                    ?StackGroup = StackGroup,
                    ?Orientation = Orientation,
                    ?GroupNorm = GroupNorm
                )

            let useWebGL = defaultArg UseWebGL false

            Chart.renderScatterTrace useDefaults useWebGL style


        /// <summary>
        /// Creates a Spline chart. A spline chart is a line chart in which data points are connected by smoothed curves: this modification is aimed to improve the design of a chart.
        /// Very similar to Line Plots, spline charts are typically used to visualize an evolution of Y depending on X.
        /// </summary>
        /// <param name="xy">Sets the x,y coordinates of the plotted data.</param>
        /// <param name="ShowMarkers">Wether to show markers for the individual data points</param>
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
        /// <param name="StackGroup">Set several traces (on the same subplot) to the same stackgroup in order to add their y values (or their x values if `Orientation` is Horizontal). Stacking also turns `fill` on by default and sets the default `mode` to "lines" irrespective of point count. ou can only stack on a numeric (linear or log) axis. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order</param>
        /// <param name="Orientation">Sets the stacking direction. Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used.</param>
        /// <param name="GroupNorm">Sets the normalization for the sum of this `stackgroup. Only relevant when `stackgroup` is used, and only the first `groupnorm` found in the `stackgroup` will be used</param>
        /// <param name="UseWebGL">If true, plotly.js will use the WebGL engine to render this chart. use this when you want to render many objects at once.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Spline
            (
                xy: seq<#IConvertible * #IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?ShowMarkers: bool,
                [<Optional; DefaultParameterValue(null)>] ?Smoothing: float,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?MultiOpacity: seq<float>,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?TextPosition: StyleParam.TextPosition,
                [<Optional; DefaultParameterValue(null)>] ?MultiTextPosition: seq<StyleParam.TextPosition>,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?MarkerOutline: Line,
                [<Optional; DefaultParameterValue(null)>] ?MarkerSymbol: StyleParam.MarkerSymbol,
                [<Optional; DefaultParameterValue(null)>] ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
                [<Optional; DefaultParameterValue(null)>] ?LineColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?LineColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?LineWidth: float,
                [<Optional; DefaultParameterValue(null)>] ?LineDash: StyleParam.DrawingStyle,
                [<Optional; DefaultParameterValue(null)>] ?Line: Line,
                [<Optional; DefaultParameterValue(null)>] ?StackGroup: string,
                [<Optional; DefaultParameterValue(null)>] ?Orientation: StyleParam.Orientation,
                [<Optional; DefaultParameterValue(null)>] ?GroupNorm: StyleParam.GroupNorm,
                [<Optional; DefaultParameterValue(false)>] ?UseWebGL: bool,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =
            let x, y = Seq.unzip xy

            Chart.Spline(
                x,
                y,
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
                ?StackGroup = StackGroup,
                ?Orientation = Orientation,
                ?GroupNorm = GroupNorm,
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
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?MultiOpacity: seq<float>,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?TextPosition: StyleParam.TextPosition,
                [<Optional; DefaultParameterValue(null)>] ?MultiTextPosition: seq<StyleParam.TextPosition>,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?MarkerOutline: Line,
                [<Optional; DefaultParameterValue(null)>] ?MarkerSymbol: StyleParam.MarkerSymbol,
                [<Optional; DefaultParameterValue(null)>] ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
                [<Optional; DefaultParameterValue(null)>] ?LineColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?LineColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?LineWidth: float,
                [<Optional; DefaultParameterValue(null)>] ?LineDash: StyleParam.DrawingStyle,
                [<Optional; DefaultParameterValue(null)>] ?Line: Line,
                [<Optional; DefaultParameterValue(null)>] ?StackGroup: string,
                [<Optional; DefaultParameterValue(null)>] ?Orientation: StyleParam.Orientation,
                [<Optional; DefaultParameterValue(null)>] ?GroupNorm: StyleParam.GroupNorm,
                [<Optional; DefaultParameterValue(false)>] ?UseWebGL: bool,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            let useDefaults = defaultArg UseDefaults true

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
        /// <param name="StackGroup">Set several traces (on the same subplot) to the same stackgroup in order to add their y values (or their x values if `Orientation` is Horizontal). Stacking also turns `fill` on by default and sets the default `mode` to "lines" irrespective of point count. ou can only stack on a numeric (linear or log) axis. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order</param>
        /// <param name="Orientation">Sets the stacking direction. Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used.</param>
        /// <param name="GroupNorm">Sets the normalization for the sum of this `stackgroup. Only relevant when `stackgroup` is used, and only the first `groupnorm` found in the `stackgroup` will be used</param>
        /// <param name="UseWebGL">If true, plotly.js will use the WebGL engine to render this chart. use this when you want to render many objects at once.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Bubble
            (
                xysizes: seq<#IConvertible * #IConvertible * int>,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?MultiOpacity: seq<float>,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?TextPosition: StyleParam.TextPosition,
                [<Optional; DefaultParameterValue(null)>] ?MultiTextPosition: seq<StyleParam.TextPosition>,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?MarkerOutline: Line,
                [<Optional; DefaultParameterValue(null)>] ?MarkerSymbol: StyleParam.MarkerSymbol,
                [<Optional; DefaultParameterValue(null)>] ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
                [<Optional; DefaultParameterValue(null)>] ?LineColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?LineColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?LineWidth: float,
                [<Optional; DefaultParameterValue(null)>] ?LineDash: StyleParam.DrawingStyle,
                [<Optional; DefaultParameterValue(null)>] ?Line: Line,
                [<Optional; DefaultParameterValue(null)>] ?StackGroup: string,
                [<Optional; DefaultParameterValue(null)>] ?Orientation: StyleParam.Orientation,
                [<Optional; DefaultParameterValue(null)>] ?GroupNorm: StyleParam.GroupNorm,
                [<Optional; DefaultParameterValue(false)>] ?UseWebGL: bool,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =
            let x, y, sizes = Seq.unzip3 xysizes

            Chart.Bubble(
                x,
                y,
                sizes,
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
                ?StackGroup = StackGroup,
                ?Orientation = Orientation,
                ?GroupNorm = GroupNorm,
                ?UseWebGL = UseWebGL,
                ?UseDefaults = UseDefaults

            )

        /// Displays a range of data by plotting two Y values per data point, with each Y value being drawn as a line
        [<Extension>]
        static member Range
            (
                x,
                y,
                upper,
                lower,
                mode,
                [<Optional; DefaultParameterValue(null)>] ?Name,
                [<Optional; DefaultParameterValue(null)>] ?ShowMarkers,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend,
                [<Optional; DefaultParameterValue(null)>] ?Color,
                [<Optional; DefaultParameterValue(null)>] ?RangeColor,
                [<Optional; DefaultParameterValue(null)>] ?Labels,
                [<Optional; DefaultParameterValue(null)>] ?UpperLabels,
                [<Optional; DefaultParameterValue(null)>] ?LowerLabels,
                [<Optional; DefaultParameterValue(null)>] ?TextPosition,
                [<Optional; DefaultParameterValue(null)>] ?TextFont,
                [<Optional; DefaultParameterValue("lower")>] ?LowerName: string,
                [<Optional; DefaultParameterValue("upper")>] ?UpperName: string,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            let useDefaults = defaultArg UseDefaults true

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
                Trace2D.initScatter (Trace2DStyle.Scatter(X = x, Y = y, Mode = mode, ?FillColor = Color))
                |> TraceStyle.TraceInfo(?Name = Name, ?ShowLegend = ShowLegend)
                |> TraceStyle.Line(?Color = Color)
                |> TraceStyle.Marker(?Color = Color)
                |> TraceStyle.TextLabel(?Text = Labels, ?Textposition = TextPosition, ?Textfont = TextFont)

            let lower =
                Trace2D.initScatter (
                    Trace2DStyle.Scatter(X = x, Y = lower, Mode = StyleParam.Mode.Lines, ?FillColor = RangeColor)
                )
                |> TraceStyle.TraceInfo(?Name = Some lowerName, ShowLegend = false)
                |> TraceStyle.Line(Width = 0.)
                |> TraceStyle.Marker(
                    Color =
                        if RangeColor.IsSome then
                            RangeColor.Value
                        else
                            (Plotly.NET.Color.fromString "rgba(0,0,0,0.5)")
                )
                |> TraceStyle.TextLabel(?Text = LowerLabels, ?Textposition = TextPosition, ?Textfont = TextFont)

            let upper =
                Trace2D.initScatter (
                    Trace2DStyle.Scatter(
                        X = x,
                        Y = upper,
                        Mode = StyleParam.Mode.Lines,
                        ?FillColor = RangeColor,
                        Fill = StyleParam.Fill.ToNext_y
                    )
                )
                |> TraceStyle.TraceInfo(?Name = Some upperName, ShowLegend = false)
                |> TraceStyle.Line(Width = 0.)
                |> TraceStyle.Marker(
                    Color =
                        if RangeColor.IsSome then
                            RangeColor.Value
                        else
                            (Plotly.NET.Color.fromString "rgba(0,0,0,0.5)")
                )
                |> TraceStyle.TextLabel(?Text = UpperLabels, ?Textposition = TextPosition, ?Textfont = TextFont)

            GenericChart.ofTraceObjects useDefaults [ lower; upper; trace ]

        /// Displays a range of data by plotting two Y values per data point, with each Y value being drawn as a line
        [<Extension>]
        static member Range
            (
                xy,
                upper,
                lower,
                mode,
                [<Optional; DefaultParameterValue(null)>] ?Name,
                [<Optional; DefaultParameterValue(null)>] ?ShowMarkers,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend,
                [<Optional; DefaultParameterValue(null)>] ?Color,
                [<Optional; DefaultParameterValue(null)>] ?RangeColor,
                [<Optional; DefaultParameterValue(null)>] ?Labels,
                [<Optional; DefaultParameterValue(null)>] ?UpperLabels,
                [<Optional; DefaultParameterValue(null)>] ?LowerLabels,
                [<Optional; DefaultParameterValue(null)>] ?TextPosition,
                [<Optional; DefaultParameterValue(null)>] ?TextFont,
                [<Optional; DefaultParameterValue(null)>] ?LowerName,
                [<Optional; DefaultParameterValue(null)>] ?UpperName,
                [<Optional; DefaultParameterValue(null)>] ?UseDefaults: bool
            ) =
            let x, y = Seq.unzip xy

            Chart.Range(
                x,
                y,
                upper,
                lower,
                mode,
                ?Name = Name,
                ?ShowMarkers = ShowMarkers,
                ?ShowLegend = ShowLegend,
                ?Color = Color,
                ?RangeColor = RangeColor,
                ?Labels = Labels,
                ?UpperLabels = UpperLabels,
                ?LowerLabels = LowerLabels,
                ?TextPosition = TextPosition,
                ?TextFont = TextFont,
                ?LowerName = LowerName,
                ?UpperName = UpperName,
                ?UseDefaults = UseDefaults
            )


        /// Emphasizes the degree of change over time and shows the relationship of the parts to a whole.
        [<Extension>]
        static member Area
            (
                x,
                y,
                [<Optional; DefaultParameterValue(null)>] ?Name,
                [<Optional; DefaultParameterValue(null)>] ?ShowMarkers,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend,
                [<Optional; DefaultParameterValue(null)>] ?MarkerSymbol,
                [<Optional; DefaultParameterValue(null)>] ?Color,
                [<Optional; DefaultParameterValue(null)>] ?Opacity,
                [<Optional; DefaultParameterValue(null)>] ?Labels,
                [<Optional; DefaultParameterValue(null)>] ?TextPosition,
                [<Optional; DefaultParameterValue(null)>] ?TextFont,
                [<Optional; DefaultParameterValue(null)>] ?Dash,
                [<Optional; DefaultParameterValue(null)>] ?Width,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            let useDefaults = defaultArg UseDefaults true
            // if text position or font is set than show labels (not only when hovering)
            let changeMode =
                let isShowMarker =
                    match ShowMarkers with
                    | Some isShow -> isShow
                    | Option.None -> false

                StyleParam.ModeUtils.showText (TextPosition.IsSome || TextFont.IsSome)
                >> StyleParam.ModeUtils.showMarker (isShowMarker)

            Trace2D.initScatter (
                Trace2DStyle.Scatter(
                    X = x,
                    Y = y,
                    Mode = changeMode StyleParam.Mode.Lines,
                    Fill = StyleParam.Fill.ToZero_y
                )
            )
            |> TraceStyle.TraceInfo(?Name = Name, ?ShowLegend = ShowLegend, ?Opacity = Opacity)
            |> TraceStyle.Line(?Color = Color, ?Dash = Dash, ?Width = Width)
            |> TraceStyle.Marker(?Color = Color, ?Symbol = MarkerSymbol)
            |> TraceStyle.TextLabel(?Text = Labels, ?Textposition = TextPosition, ?Textfont = TextFont)
            |> GenericChart.ofTraceObject useDefaults


        /// Emphasizes the degree of change over time and shows the relationship of the parts to a whole.
        [<Extension>]
        static member Area
            (
                xy,
                [<Optional; DefaultParameterValue(null)>] ?Name,
                [<Optional; DefaultParameterValue(null)>] ?ShowMarkers,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend,
                [<Optional; DefaultParameterValue(null)>] ?MarkerSymbol,
                [<Optional; DefaultParameterValue(null)>] ?Color,
                [<Optional; DefaultParameterValue(null)>] ?Opacity,
                [<Optional; DefaultParameterValue(null)>] ?Labels,
                [<Optional; DefaultParameterValue(null)>] ?TextPosition,
                [<Optional; DefaultParameterValue(null)>] ?TextFont,
                [<Optional; DefaultParameterValue(null)>] ?Dash,
                [<Optional; DefaultParameterValue(null)>] ?Width,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            let x, y = Seq.unzip xy

            Chart.Area(
                x,
                y,
                ?Name = Name,
                ?ShowMarkers = ShowMarkers,
                ?ShowLegend = ShowLegend,
                ?MarkerSymbol = MarkerSymbol,
                ?Color = Color,
                ?Opacity = Opacity,
                ?Labels = Labels,
                ?TextPosition = TextPosition,
                ?TextFont = TextFont,
                ?Dash = Dash,
                ?Width = Width,
                ?UseDefaults = UseDefaults
            )


        /// Emphasizes the degree of change over time and shows the relationship of the parts to a whole.
        [<Extension>]
        static member SplineArea
            (
                x,
                y,
                [<Optional; DefaultParameterValue(null)>] ?Name,
                [<Optional; DefaultParameterValue(null)>] ?ShowMarkers,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend,
                [<Optional; DefaultParameterValue(null)>] ?MarkerSymbol,
                [<Optional; DefaultParameterValue(null)>] ?Color,
                [<Optional; DefaultParameterValue(null)>] ?Opacity,
                [<Optional; DefaultParameterValue(null)>] ?Labels,
                [<Optional; DefaultParameterValue(null)>] ?TextPosition,
                [<Optional; DefaultParameterValue(null)>] ?TextFont,
                [<Optional; DefaultParameterValue(null)>] ?Dash,
                [<Optional; DefaultParameterValue(null)>] ?Width,
                [<Optional; DefaultParameterValue(null)>] ?Smoothing,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            let useDefaults = defaultArg UseDefaults true
            // if text position or font is set than show labels (not only when hovering)
            let changeMode =
                let isShowMarker =
                    match ShowMarkers with
                    | Some isShow -> isShow
                    | Option.None -> false

                StyleParam.ModeUtils.showText (TextPosition.IsSome || TextFont.IsSome)
                >> StyleParam.ModeUtils.showMarker (isShowMarker)

            Trace2D.initScatter (
                Trace2DStyle.Scatter(
                    X = x,
                    Y = y,
                    Mode = changeMode StyleParam.Mode.Lines,
                    Fill = StyleParam.Fill.ToZero_y
                )
            )
            |> TraceStyle.TraceInfo(?Name = Name, ?ShowLegend = ShowLegend, ?Opacity = Opacity)
            |> TraceStyle.Line(
                ?Color = Color,
                ?Dash = Dash,
                ?Width = Width,
                Shape = StyleParam.Shape.Spline,
                ?Smoothing = Smoothing
            )
            |> TraceStyle.Marker(?Color = Color, ?Symbol = MarkerSymbol)
            |> TraceStyle.TextLabel(?Text = Labels, ?Textposition = TextPosition, ?Textfont = TextFont)
            |> GenericChart.ofTraceObject useDefaults

        /// Emphasizes the degree of change over time and shows the relationship of the parts to a whole.
        [<Extension>]
        static member SplineArea
            (
                xy,
                [<Optional; DefaultParameterValue(null)>] ?Name,
                [<Optional; DefaultParameterValue(null)>] ?ShowMarkers,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend,
                [<Optional; DefaultParameterValue(null)>] ?MarkerSymbol,
                [<Optional; DefaultParameterValue(null)>] ?Color,
                [<Optional; DefaultParameterValue(null)>] ?Opacity,
                [<Optional; DefaultParameterValue(null)>] ?Labels,
                [<Optional; DefaultParameterValue(null)>] ?TextPosition,
                [<Optional; DefaultParameterValue(null)>] ?TextFont,
                [<Optional; DefaultParameterValue(null)>] ?Dash,
                [<Optional; DefaultParameterValue(null)>] ?Width,
                [<Optional; DefaultParameterValue(null)>] ?Smoothing,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            let x, y = Seq.unzip xy

            Chart.SplineArea(
                x,
                y,
                ?Name = Name,
                ?ShowMarkers = ShowMarkers,
                ?ShowLegend = ShowLegend,
                ?MarkerSymbol = MarkerSymbol,
                ?Color = Color,
                ?Opacity = Opacity,
                ?Labels = Labels,
                ?TextPosition = TextPosition,
                ?TextFont = TextFont,
                ?Dash = Dash,
                ?Width = Width,
                ?Smoothing = Smoothing,
                ?UseDefaults = UseDefaults
            )

        /// Emphasizes the degree of change over time and shows the relationship of the parts to a whole.
        [<Extension>]
        static member StackedArea
            (
                x,
                y,
                [<Optional; DefaultParameterValue(null)>] ?Name,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend,
                [<Optional; DefaultParameterValue(null)>] ?MarkerSymbol,
                [<Optional; DefaultParameterValue(null)>] ?Color,
                [<Optional; DefaultParameterValue(null)>] ?Opacity,
                [<Optional; DefaultParameterValue(null)>] ?Labels,
                [<Optional; DefaultParameterValue(null)>] ?TextPosition,
                [<Optional; DefaultParameterValue(null)>] ?TextFont,
                [<Optional; DefaultParameterValue(null)>] ?Dash,
                [<Optional; DefaultParameterValue(null)>] ?Width,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            let useDefaults = defaultArg UseDefaults true

            Trace2D.initScatter (Trace2DStyle.Scatter(X = x, Y = y, Mode = StyleParam.Mode.Lines))
            |> TraceStyle.TraceInfo(?Name = Name, ?ShowLegend = ShowLegend, ?Opacity = Opacity)
            |> TraceStyle.Line(?Color = Color, ?Dash = Dash, ?Width = Width)
            |> TraceStyle.Marker(?Color = Color, ?Symbol = MarkerSymbol)
            |> TraceStyle.TextLabel(?Text = Labels, ?Textposition = TextPosition, ?Textfont = TextFont)
            |> TraceStyle.SetStackGroup "static"
            |> GenericChart.ofTraceObject useDefaults

        /// Emphasizes the degree of change over time and shows the relationship of the parts to a whole.
        [<Extension>]
        static member StackedArea
            (
                xy,
                [<Optional; DefaultParameterValue(null)>] ?Name,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend,
                [<Optional; DefaultParameterValue(null)>] ?MarkerSymbol,
                [<Optional; DefaultParameterValue(null)>] ?Color,
                [<Optional; DefaultParameterValue(null)>] ?Opacity,
                [<Optional; DefaultParameterValue(null)>] ?Labels,
                [<Optional; DefaultParameterValue(null)>] ?TextPosition,
                [<Optional; DefaultParameterValue(null)>] ?TextFont,
                [<Optional; DefaultParameterValue(null)>] ?Dash,
                [<Optional; DefaultParameterValue(null)>] ?Width,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            let x, y = Seq.unzip xy

            Chart.StackedArea(
                x,
                y,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?MarkerSymbol = MarkerSymbol,
                ?Color = Color,
                ?Opacity = Opacity,
                ?Labels = Labels,
                ?TextPosition = TextPosition,
                ?TextFont = TextFont,
                ?Dash = Dash,
                ?Width = Width,
                ?UseDefaults = UseDefaults
            )


        /// Creates a Funnel chart.
        /// Funnel charts visualize stages in a process using length-encoded bars. This trace can be used to show data in either a part-to-whole representation wherein each item appears in a single stage, or in a "drop-off" representation wherein each item appears in each stage it traversed. See also the "funnelarea" trace type for a different approach to visualizing funnel data.
        ///
        /// Parameters:
        ///
        /// x              : Sets the x coordinates.
        ///
        /// y              : Sets the y coordinates.
        ///
        /// Name           : Sets the trace name. The trace name appear as the legend item and on hover
        ///
        /// ShowLegend     : Determines whether or not an item corresponding to this trace is shown in the legend.
        ///
        /// Opacity        : Sets the Opacity of the trace
        ///
        /// Labels         : Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.
        ///
        /// TextPosition   : Sets the positions of the `text` elements with respects to the (x,y) coordinates.
        ///
        /// TextFont       : Sets the text font of this trace
        ///
        /// Color          : Sets Marker Color
        ///
        /// Line           : Line type
        ///
        /// x0             : Alternate to `x`. Builds a linear space of x coordinates. Use with `dx` where `x0` is the starting coordinate and `dx` the step.
        ///
        /// dX             : Sets the x coordinate step. See `x0` for more info.
        ///
        /// y0             : Alternate to `y`. Builds a linear space of y coordinates. Use with `dy` where `y0` is the starting coordinate and `dy` the step.
        ///
        /// dY             : Sets the y coordinate step. See `y0` for more info.
        ///
        /// Width          : Sets the bar width (in position axis units).
        ///
        /// Offset         : Shifts the position where the bar is drawn (in position axis units). In "group" barmode, traces that set "offset" will be excluded and drawn in "overlay" mode instead.
        ///
        /// Orientation    : Sets the orientation of the funnels. With "v" ("h"), the value of the each bar spans along the vertical (horizontal). By default funnels are tend to be oriented horizontally; unless only "y" array is presented or orientation is set to "v". Also regarding graphs including only 'horizontal' funnels, "autorange" on the "y-axis" are set to "reversed".
        ///
        /// Alignmentgroup : Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.
        ///
        /// Offsetgroup    : Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.
        ///
        /// Cliponaxis     : Determines whether the text nodes are clipped about the subplot axes. To show the text nodes above axis lines and tick labels, make sure to set `xaxis.layer` and `yaxis.layer` to "below traces".
        ///
        /// Connector      : Connector type
        ///
        /// Insidetextfont : Sets the font used for `text` lying inside the bar.
        ///
        /// Outsidetextfont: Sets the font used for `text` lying outside the bar.
        [<Extension>]
        static member Funnel
            (
                x: seq<#IConvertible>,
                y: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?Width: float,
                [<Optional; DefaultParameterValue(null)>] ?Offset: float,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?TextPosition: StyleParam.TextPosition,
                [<Optional; DefaultParameterValue(null)>] ?MultiTextPosition: seq<StyleParam.TextPosition>,
                [<Optional; DefaultParameterValue(null)>] ?Orientation: StyleParam.Orientation,
                [<Optional; DefaultParameterValue(null)>] ?AlignmentGroup: string,
                [<Optional; DefaultParameterValue(null)>] ?OffsetGroup: string,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?MarkerOutline: Line,
                [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
                [<Optional; DefaultParameterValue(null)>] ?TextInfo: StyleParam.TextInfo,
                [<Optional; DefaultParameterValue(null)>] ?ConnectorLineColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?ConnectorLineStyle: StyleParam.DrawingStyle,
                [<Optional; DefaultParameterValue(null)>] ?ConnectorFillColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?ConnectorLine: Line,
                [<Optional; DefaultParameterValue(null)>] ?Connector: FunnelConnector,
                [<Optional; DefaultParameterValue(null)>] ?InsideTextFont: Font,
                [<Optional; DefaultParameterValue(null)>] ?OutsideTextFont: Font,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            let useDefaults = defaultArg UseDefaults true

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
                |> TraceObjects.FunnelConnector.style (?Fillcolor = ConnectorFillColor, ?Line = connectorLine)

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

        static member StackedFunnel
            (
                x: seq<#IConvertible>,
                y: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?Width: float,
                [<Optional; DefaultParameterValue(null)>] ?Offset: float,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?TextPosition: StyleParam.TextPosition,
                [<Optional; DefaultParameterValue(null)>] ?MultiTextPosition: seq<StyleParam.TextPosition>,
                [<Optional; DefaultParameterValue(null)>] ?Orientation: StyleParam.Orientation,
                [<Optional; DefaultParameterValue(null)>] ?AlignmentGroup: string,
                [<Optional; DefaultParameterValue(null)>] ?OffsetGroup: string,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?MarkerOutline: Line,
                [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
                [<Optional; DefaultParameterValue(null)>] ?TextInfo: StyleParam.TextInfo,
                [<Optional; DefaultParameterValue(null)>] ?ConnectorLineColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?ConnectorLineStyle: StyleParam.DrawingStyle,
                [<Optional; DefaultParameterValue(null)>] ?ConnectorFillColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?ConnectorLine: Line,
                [<Optional; DefaultParameterValue(null)>] ?Connector: FunnelConnector,
                [<Optional; DefaultParameterValue(null)>] ?InsideTextFont: Font,
                [<Optional; DefaultParameterValue(null)>] ?OutsideTextFont: Font,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =
            Chart.Funnel(
                x,
                y,
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

        /// Creates a waterfall chart. Waterfall charts are special bar charts that help visualizing the cumulative effect of sequentially introduced positive or negative values
        [<Extension>]
        static member Waterfall
            (
                x: seq<#IConvertible>,
                y: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?IncreasingColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?Increasing: FinanceMarker,
                [<Optional; DefaultParameterValue(null)>] ?DecreasingColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?Decreasing: FinanceMarker,
                [<Optional; DefaultParameterValue(null)>] ?TotalsColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?Totals: FinanceMarker,
                [<Optional; DefaultParameterValue(null)>] ?Base: float,
                [<Optional; DefaultParameterValue(null)>] ?Width: float,
                [<Optional; DefaultParameterValue(null)>] ?MultiWidth: seq<float>,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?TextPosition: StyleParam.TextPosition,
                [<Optional; DefaultParameterValue(null)>] ?MultiTextPosition: seq<StyleParam.TextPosition>,
                [<Optional; DefaultParameterValue(null)>] ?TextFont: Font,
                [<Optional; DefaultParameterValue(null)>] ?Connector: WaterfallConnector,
                [<Optional; DefaultParameterValue(null)>] ?Measure: StyleParam.WaterfallMeasure seq,
                [<Optional; DefaultParameterValue(null)>] ?AlignmentGroup: string,
                [<Optional; DefaultParameterValue(null)>] ?OffsetGroup: string,
                [<Optional; DefaultParameterValue(true)>] ?Orientation: StyleParam.Orientation,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            let useDefaults = defaultArg UseDefaults true

            let increasing =
                Increasing
                |> Option.defaultValue (FinanceMarker.init ())
                |> FinanceMarker.style (?MarkerColor = IncreasingColor)

            let decreasing =
                Decreasing
                |> Option.defaultValue (FinanceMarker.init ())
                |> FinanceMarker.style (?MarkerColor = DecreasingColor)

            let totals =
                Totals
                |> Option.defaultValue (FinanceMarker.init ())
                |> FinanceMarker.style (?MarkerColor = TotalsColor)

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


        /// Creates a waterfall chart. Waterfall charts are special bar charts that help visualizing the cumulative effect of sequentially introduced positive or negative values
        [<Extension>]
        static member Waterfall
            (
                xy: seq<#IConvertible * #IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?IncreasingColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?Increasing: FinanceMarker,
                [<Optional; DefaultParameterValue(null)>] ?DecreasingColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?Decreasing: FinanceMarker,
                [<Optional; DefaultParameterValue(null)>] ?TotalsColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?Totals: FinanceMarker,
                [<Optional; DefaultParameterValue(null)>] ?Base: float,
                [<Optional; DefaultParameterValue(null)>] ?Width: float,
                [<Optional; DefaultParameterValue(null)>] ?MultiWidth: seq<float>,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?TextPosition: StyleParam.TextPosition,
                [<Optional; DefaultParameterValue(null)>] ?MultiTextPosition: seq<StyleParam.TextPosition>,
                [<Optional; DefaultParameterValue(null)>] ?TextFont: Font,
                [<Optional; DefaultParameterValue(null)>] ?Connector: WaterfallConnector,
                [<Optional; DefaultParameterValue(null)>] ?Measure: StyleParam.WaterfallMeasure seq,
                [<Optional; DefaultParameterValue(null)>] ?AlignmentGroup: string,
                [<Optional; DefaultParameterValue(null)>] ?OffsetGroup: string,
                [<Optional; DefaultParameterValue(true)>] ?Orientation: StyleParam.Orientation,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            let x, y = Seq.unzip xy

            Chart.Waterfall(
                x,
                y,
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

        /// Creates a waterfall chart. Waterfall charts are special bar charts that help visualizing the cumulative effect of sequentially introduced positive or negative values
        [<Extension>]
        static member Waterfall
            (
                xymeasures: seq<#IConvertible * #IConvertible * StyleParam.WaterfallMeasure>,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?IncreasingColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?Increasing: FinanceMarker,
                [<Optional; DefaultParameterValue(null)>] ?DecreasingColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?Decreasing: FinanceMarker,
                [<Optional; DefaultParameterValue(null)>] ?TotalsColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?Totals: FinanceMarker,
                [<Optional; DefaultParameterValue(null)>] ?Base: float,
                [<Optional; DefaultParameterValue(null)>] ?Width: float,
                [<Optional; DefaultParameterValue(null)>] ?MultiWidth: seq<float>,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?TextPosition: StyleParam.TextPosition,
                [<Optional; DefaultParameterValue(null)>] ?MultiTextPosition: seq<StyleParam.TextPosition>,
                [<Optional; DefaultParameterValue(null)>] ?TextFont: Font,
                [<Optional; DefaultParameterValue(null)>] ?Connector: WaterfallConnector,
                [<Optional; DefaultParameterValue(null)>] ?AlignmentGroup: string,
                [<Optional; DefaultParameterValue(null)>] ?OffsetGroup: string,
                [<Optional; DefaultParameterValue(true)>] ?Orientation: StyleParam.Orientation,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            let x, y, measure = Seq.unzip3 xymeasures

            Chart.Waterfall(
                x,
                y,
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

        /// Illustrates comparisons among individual items
        [<Extension>]
        static member Bar
            (
                values: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Keys: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?MultiOpacity: seq<float>,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?MarkerOutline: Line,
                [<Optional; DefaultParameterValue(null)>] ?MarkerPatternShape: StyleParam.PatternShape,
                [<Optional; DefaultParameterValue(null)>] ?MultiMarkerPatternShape: seq<StyleParam.PatternShape>,
                [<Optional; DefaultParameterValue(null)>] ?MarkerPattern: Pattern,
                [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
                [<Optional; DefaultParameterValue(null)>] ?Base: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?Width: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiWidth: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?TextPosition: StyleParam.TextPosition,
                [<Optional; DefaultParameterValue(null)>] ?MultiTextPosition: seq<StyleParam.TextPosition>,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            let useDefaults = defaultArg UseDefaults true

            let pattern =
                MarkerPattern
                |> Option.defaultValue (TraceObjects.Pattern.init ())
                |> TraceObjects.Pattern.style (?Shape = MarkerPatternShape, ?MultiShape = MultiMarkerPatternShape)

            let marker =
                Marker
                |> Option.defaultValue (TraceObjects.Marker.init ())
                |> TraceObjects.Marker.style (
                    ?Color = MarkerColor,
                    Pattern = pattern,
                    ?MultiOpacity = MultiOpacity,
                    ?Colorscale = MarkerColorScale,
                    ?Outline = MarkerOutline
                )


            Trace2D.initBar (
                Trace2DStyle.Bar(
                    X = values,
                    ?Y = Keys,
                    Orientation = StyleParam.Orientation.Horizontal,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?Base = Base,
                    ?Width = Width,
                    ?MultiWidth = MultiWidth,
                    ?TextPosition = TextPosition,
                    ?MultiTextPosition = MultiTextPosition,
                    Marker = marker
                )
            )
            |> GenericChart.ofTraceObject useDefaults

        /// Illustrates comparisons among individual items
        [<Extension>]
        static member Bar
            (
                keysValues: seq<#IConvertible * #IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?MultiOpacity: seq<float>,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?MarkerOutline: Line,
                [<Optional; DefaultParameterValue(null)>] ?MarkerPatternShape: StyleParam.PatternShape,
                [<Optional; DefaultParameterValue(null)>] ?MultiMarkerPatternShape: seq<StyleParam.PatternShape>,
                [<Optional; DefaultParameterValue(null)>] ?MarkerPattern: Pattern,
                [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
                [<Optional; DefaultParameterValue(null)>] ?Base: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?Width: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiWidth: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?TextPosition: StyleParam.TextPosition,
                [<Optional; DefaultParameterValue(null)>] ?MultiTextPosition: seq<StyleParam.TextPosition>,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            let keys, values = Seq.unzip keysValues

            Chart.Bar(
                values,
                keys,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerPatternShape = MarkerPatternShape,
                ?MultiMarkerPatternShape = MultiMarkerPatternShape,
                ?MarkerPattern = MarkerPattern,
                ?Marker = Marker,
                ?Base = Base,
                ?Width = Width,
                ?MultiWidth = MultiWidth,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?UseDefaults = UseDefaults
            )


        /// Displays series of tcolumn chart type as stacked bars.
        [<Extension>]
        static member StackedBar
            (
                values: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Keys: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?MultiOpacity: seq<float>,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?MarkerOutline: Line,
                [<Optional; DefaultParameterValue(null)>] ?MarkerPatternShape: StyleParam.PatternShape,
                [<Optional; DefaultParameterValue(null)>] ?MultiMarkerPatternShape: seq<StyleParam.PatternShape>,
                [<Optional; DefaultParameterValue(null)>] ?MarkerPattern: Pattern,
                [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
                [<Optional; DefaultParameterValue(null)>] ?Base: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?Width: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiWidth: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?TextPosition: StyleParam.TextPosition,
                [<Optional; DefaultParameterValue(null)>] ?MultiTextPosition: seq<StyleParam.TextPosition>,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            Chart.Bar(
                values,
                ?Keys = Keys,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerPatternShape = MarkerPatternShape,
                ?MultiMarkerPatternShape = MultiMarkerPatternShape,
                ?MarkerPattern = MarkerPattern,
                ?Marker = Marker,
                ?Base = Base,
                ?Width = Width,
                ?MultiWidth = MultiWidth,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?UseDefaults = UseDefaults
            )
            |> GenericChart.mapLayout (Layout.style (BarMode = StyleParam.BarMode.Stack))


        /// Displays series of tcolumn chart type as stacked bars.
        [<Extension>]
        static member StackedBar
            (
                keysValues: seq<#IConvertible * #IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Keys: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?MultiOpacity: seq<float>,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?MarkerOutline: Line,
                [<Optional; DefaultParameterValue(null)>] ?MarkerPatternShape: StyleParam.PatternShape,
                [<Optional; DefaultParameterValue(null)>] ?MultiMarkerPatternShape: seq<StyleParam.PatternShape>,
                [<Optional; DefaultParameterValue(null)>] ?MarkerPattern: Pattern,
                [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
                [<Optional; DefaultParameterValue(null)>] ?Base: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?Width: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiWidth: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?TextPosition: StyleParam.TextPosition,
                [<Optional; DefaultParameterValue(null)>] ?MultiTextPosition: seq<StyleParam.TextPosition>,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            let keys, values = Seq.unzip keysValues

            Chart.StackedBar(
                values,
                keys,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerPatternShape = MarkerPatternShape,
                ?MultiMarkerPatternShape = MultiMarkerPatternShape,
                ?MarkerPattern = MarkerPattern,
                ?Marker = Marker,
                ?Base = Base,
                ?Width = Width,
                ?MultiWidth = MultiWidth,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?UseDefaults = UseDefaults
            )

        /// Illustrates comparisons among individual items
        [<Extension>]
        static member Column
            (
                values: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Keys: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?MultiOpacity: seq<float>,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?MarkerOutline: Line,
                [<Optional; DefaultParameterValue(null)>] ?MarkerPatternShape: StyleParam.PatternShape,
                [<Optional; DefaultParameterValue(null)>] ?MultiMarkerPatternShape: seq<StyleParam.PatternShape>,
                [<Optional; DefaultParameterValue(null)>] ?MarkerPattern: Pattern,
                [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
                [<Optional; DefaultParameterValue(null)>] ?Base: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?Width: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiWidth: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?TextPosition: StyleParam.TextPosition,
                [<Optional; DefaultParameterValue(null)>] ?MultiTextPosition: seq<StyleParam.TextPosition>,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            let useDefaults = defaultArg UseDefaults true

            let pattern =
                MarkerPattern
                |> Option.defaultValue (TraceObjects.Pattern.init ())
                |> TraceObjects.Pattern.style (?Shape = MarkerPatternShape, ?MultiShape = MultiMarkerPatternShape)

            let marker =
                Marker
                |> Option.defaultValue (TraceObjects.Marker.init ())
                |> TraceObjects.Marker.style (
                    ?Color = MarkerColor,
                    Pattern = pattern,
                    ?MultiOpacity = MultiOpacity,
                    ?Colorscale = MarkerColorScale,
                    ?Outline = MarkerOutline
                )


            Trace2D.initBar (
                Trace2DStyle.Bar(
                    Y = values,
                    ?X = Keys,
                    Orientation = StyleParam.Orientation.Vertical,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?Base = Base,
                    ?Width = Width,
                    ?MultiWidth = MultiWidth,
                    ?TextPosition = TextPosition,
                    ?MultiTextPosition = MultiTextPosition,
                    Marker = marker
                )
            )
            |> GenericChart.ofTraceObject useDefaults


        /// Illustrates comparisons among individual items
        [<Extension>]
        static member Column
            (
                keysValues: seq<#IConvertible * #IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?MultiOpacity: seq<float>,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?MarkerOutline: Line,
                [<Optional; DefaultParameterValue(null)>] ?MarkerPatternShape: StyleParam.PatternShape,
                [<Optional; DefaultParameterValue(null)>] ?MultiMarkerPatternShape: seq<StyleParam.PatternShape>,
                [<Optional; DefaultParameterValue(null)>] ?MarkerPattern: Pattern,
                [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
                [<Optional; DefaultParameterValue(null)>] ?Base: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?Width: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiWidth: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?TextPosition: StyleParam.TextPosition,
                [<Optional; DefaultParameterValue(null)>] ?MultiTextPosition: seq<StyleParam.TextPosition>,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            let keys, values = Seq.unzip keysValues

            Chart.Column(
                values,
                keys,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerPatternShape = MarkerPatternShape,
                ?MultiMarkerPatternShape = MultiMarkerPatternShape,
                ?MarkerPattern = MarkerPattern,
                ?Marker = Marker,
                ?Base = Base,
                ?Width = Width,
                ?MultiWidth = MultiWidth,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?UseDefaults = UseDefaults
            )


        /// Displays series of tcolumn chart type as stacked bars.
        [<Extension>]
        static member StackedColumn
            (
                values: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Keys: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?MultiOpacity: seq<float>,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?MarkerOutline: Line,
                [<Optional; DefaultParameterValue(null)>] ?MarkerPatternShape: StyleParam.PatternShape,
                [<Optional; DefaultParameterValue(null)>] ?MultiMarkerPatternShape: seq<StyleParam.PatternShape>,
                [<Optional; DefaultParameterValue(null)>] ?MarkerPattern: Pattern,
                [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
                [<Optional; DefaultParameterValue(null)>] ?Base: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?Width: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiWidth: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?TextPosition: StyleParam.TextPosition,
                [<Optional; DefaultParameterValue(null)>] ?MultiTextPosition: seq<StyleParam.TextPosition>,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            Chart.Column(
                values,
                ?Keys = Keys,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerPatternShape = MarkerPatternShape,
                ?MultiMarkerPatternShape = MultiMarkerPatternShape,
                ?MarkerPattern = MarkerPattern,
                ?Marker = Marker,
                ?Base = Base,
                ?Width = Width,
                ?MultiWidth = MultiWidth,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?UseDefaults = UseDefaults
            )
            |> GenericChart.mapLayout (Layout.style (BarMode = StyleParam.BarMode.Stack))


        /// Displays series of tcolumn chart type as stacked bars.
        [<Extension>]
        static member StackedColumn
            (
                keysValues: seq<#IConvertible * #IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?MultiOpacity: seq<float>,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?MarkerOutline: Line,
                [<Optional; DefaultParameterValue(null)>] ?MarkerPatternShape: StyleParam.PatternShape,
                [<Optional; DefaultParameterValue(null)>] ?MultiMarkerPatternShape: seq<StyleParam.PatternShape>,
                [<Optional; DefaultParameterValue(null)>] ?MarkerPattern: Pattern,
                [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
                [<Optional; DefaultParameterValue(null)>] ?Base: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?Width: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiWidth: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?TextPosition: StyleParam.TextPosition,
                [<Optional; DefaultParameterValue(null)>] ?MultiTextPosition: seq<StyleParam.TextPosition>,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            let keys, values = Seq.unzip keysValues

            Chart.StackedColumn(
                values,
                keys,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerPatternShape = MarkerPatternShape,
                ?MultiMarkerPatternShape = MultiMarkerPatternShape,
                ?MarkerPattern = MarkerPattern,
                ?Marker = Marker,
                ?Base = Base,
                ?Width = Width,
                ?MultiWidth = MultiWidth,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?UseDefaults = UseDefaults
            )


        /// Visualizes the distribution of the input data as a histogram.
        [<Extension>]
        static member Histogram
            (
                [<Optional; DefaultParameterValue(null)>] ?X: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Y: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Orientation: StyleParam.Orientation,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?HistFunc: StyleParam.HistFunc,
                [<Optional; DefaultParameterValue(null)>] ?HistNorm: StyleParam.HistNorm,
                [<Optional; DefaultParameterValue(null)>] ?AlignmentGroup: string,
                [<Optional; DefaultParameterValue(null)>] ?OffsetGroup: string,
                [<Optional; DefaultParameterValue(null)>] ?NBinsX: int,
                [<Optional; DefaultParameterValue(null)>] ?NBinsY: int,
                [<Optional; DefaultParameterValue(null)>] ?BinGroup: string,
                [<Optional; DefaultParameterValue(null)>] ?XBins: Bins,
                [<Optional; DefaultParameterValue(null)>] ?YBins: Bins,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
                [<Optional; DefaultParameterValue(null)>] ?Line: Line,
                [<Optional; DefaultParameterValue(null)>] ?ErrorX: Error,
                [<Optional; DefaultParameterValue(null)>] ?ErrorY: Error,
                [<Optional; DefaultParameterValue(null)>] ?Cumulative: Cumulative,
                [<Optional; DefaultParameterValue(null)>] ?HoverLabel: Hoverlabel,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            let useDefaults = defaultArg UseDefaults true

            Trace2D.initHistogram (
                Trace2DStyle.Histogram(
                    ?X = X,
                    ?Y = Y,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?Orientation = Orientation,
                    ?HistFunc = HistFunc,
                    ?HistNorm = HistNorm,
                    ?AlignmentGroup = AlignmentGroup,
                    ?OffsetGroup = OffsetGroup,
                    ?NBinsX = NBinsX,
                    ?NBinsY = NBinsY,
                    ?BinGroup = BinGroup,
                    ?XBins = XBins,
                    ?YBins = YBins,
                    ?Marker = Marker,
                    ?Line = Line,
                    ?ErrorX = ErrorX,
                    ?ErrorY = ErrorY,
                    ?Cumulative = Cumulative,
                    ?HoverLabel = HoverLabel
                )
            )
            |> TraceStyle.Marker(?Color = MarkerColor)
            |> TraceStyle.TraceInfo(?Name = Name, ?ShowLegend = ShowLegend, ?Opacity = Opacity)
            |> GenericChart.ofTraceObject useDefaults

        /// Visualizes the distribution of the input data as a histogram, automatically determining if the data is to be used for the x or y dimension based on the `orientation` parameter.
        [<Extension>]
        static member Histogram
            (
                data: seq<#IConvertible>,
                orientation: StyleParam.Orientation,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?HistFunc: StyleParam.HistFunc,
                [<Optional; DefaultParameterValue(null)>] ?HistNorm: StyleParam.HistNorm,
                [<Optional; DefaultParameterValue(null)>] ?AlignmentGroup: string,
                [<Optional; DefaultParameterValue(null)>] ?OffsetGroup: string,
                [<Optional; DefaultParameterValue(null)>] ?NBinsX: int,
                [<Optional; DefaultParameterValue(null)>] ?NBinsY: int,
                [<Optional; DefaultParameterValue(null)>] ?BinGroup: string,
                [<Optional; DefaultParameterValue(null)>] ?XBins: Bins,
                [<Optional; DefaultParameterValue(null)>] ?YBins: Bins,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
                [<Optional; DefaultParameterValue(null)>] ?Line: Line,
                [<Optional; DefaultParameterValue(null)>] ?ErrorX: Error,
                [<Optional; DefaultParameterValue(null)>] ?ErrorY: Error,
                [<Optional; DefaultParameterValue(null)>] ?Cumulative: Cumulative,
                [<Optional; DefaultParameterValue(null)>] ?HoverLabel: Hoverlabel,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            let useDefaults = defaultArg UseDefaults true

            let histChart =
                Trace2D.initHistogram (
                    Trace2DStyle.Histogram(
                        ?Text = Text,
                        ?MultiText = MultiText,
                        Orientation = orientation,
                        ?HistFunc = HistFunc,
                        ?HistNorm = HistNorm,
                        ?AlignmentGroup = AlignmentGroup,
                        ?OffsetGroup = OffsetGroup,
                        ?NBinsX = NBinsX,
                        ?NBinsY = NBinsY,
                        ?BinGroup = BinGroup,
                        ?XBins = XBins,
                        ?YBins = YBins,
                        ?Marker = Marker,
                        ?Line = Line,
                        ?ErrorX = ErrorX,
                        ?ErrorY = ErrorY,
                        ?Cumulative = Cumulative,
                        ?HoverLabel = HoverLabel
                    )
                )
                |> TraceStyle.Marker(?Color = MarkerColor)
                |> TraceStyle.TraceInfo(?Name = Name, ?ShowLegend = ShowLegend, ?Opacity = Opacity)
                |> GenericChart.ofTraceObject useDefaults

            match orientation with
            | StyleParam.Orientation.Horizontal -> histChart |> GenericChart.mapTrace (Trace2DStyle.Histogram(Y = data))
            | StyleParam.Orientation.Vertical -> histChart |> GenericChart.mapTrace (Trace2DStyle.Histogram(X = data))

        /// Computes the bi-dimensional histogram of two data samples.
        [<Extension>]
        static member Histogram2D
            (
                x: seq<#IConvertible>,
                y: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Z: seq<#seq<#IConvertible>>,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?XGap: int,
                [<Optional; DefaultParameterValue(null)>] ?YGap: int,
                [<Optional; DefaultParameterValue(null)>] ?HistFunc: StyleParam.HistFunc,
                [<Optional; DefaultParameterValue(null)>] ?HistNorm: StyleParam.HistNorm,
                [<Optional; DefaultParameterValue(null)>] ?NBinsX: int,
                [<Optional; DefaultParameterValue(null)>] ?NBinsY: int,
                [<Optional; DefaultParameterValue(null)>] ?AutoBinX: bool,
                [<Optional; DefaultParameterValue(null)>] ?AutoBinY: bool,
                [<Optional; DefaultParameterValue(null)>] ?XBins: Bins,
                [<Optional; DefaultParameterValue(null)>] ?YBins: Bins,
                [<Optional; DefaultParameterValue(null)>] ?ColorBar: ColorBar,
                [<Optional; DefaultParameterValue(null)>] ?ColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?ShowScale: bool,
                [<Optional; DefaultParameterValue(null)>] ?ReverseScale: bool,
                [<Optional; DefaultParameterValue(null)>] ?ZSmooth: StyleParam.SmoothAlg,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            let useDefaults = defaultArg UseDefaults true

            Trace2D.initHistogram2D (
                Trace2DStyle.Histogram2D(
                    X = x,
                    ?XGap = XGap,
                    Y = y,
                    ?YGap = YGap,
                    ?Z = Z,
                    ?HistFunc = HistFunc,
                    ?HistNorm = HistNorm,
                    ?NBinsX = NBinsX,
                    ?NBinsY = NBinsY,
                    ?AutoBinX = AutoBinX,
                    ?AutoBinY = AutoBinY,
                    ?XBins = XBins,
                    ?YBins = YBins,
                    ?ColorBar = ColorBar,
                    ?ColorScale = ColorScale,
                    ?ShowScale = ShowScale,
                    ?ReverseScale = ReverseScale,
                    ?ZSmooth = ZSmooth
                )
            )
            |> TraceStyle.TraceInfo(?Name = Name, ?ShowLegend = ShowLegend, ?Opacity = Opacity)
            |> GenericChart.ofTraceObject useDefaults

        /// Displays the distribution of data based on the five number summary: minimum, first quartile, median, third quartile, and maximum.
        [<Extension>]
        static member BoxPlot
            (
                [<Optional; DefaultParameterValue(null)>] ?x: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?y: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Fillcolor: Color,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?OutlierColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?OutlierWidth: int,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?WhiskerWidth: float,
                [<Optional; DefaultParameterValue(null)>] ?BoxPoints: StyleParam.BoxPoints,
                [<Optional; DefaultParameterValue(null)>] ?BoxMean: StyleParam.BoxMean,
                [<Optional; DefaultParameterValue(null)>] ?Jitter: float,
                [<Optional; DefaultParameterValue(null)>] ?PointPos: float,
                [<Optional; DefaultParameterValue(null)>] ?Orientation: StyleParam.Orientation,
                [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
                [<Optional; DefaultParameterValue(null)>] ?Line: Line,
                [<Optional; DefaultParameterValue(null)>] ?AlignmentGroup: string,
                [<Optional; DefaultParameterValue(null)>] ?Offsetgroup: string,
                [<Optional; DefaultParameterValue(null)>] ?Notched: bool,
                [<Optional; DefaultParameterValue(null)>] ?NotchWidth: float,
                [<Optional; DefaultParameterValue(null)>] ?QuartileMethod: StyleParam.QuartileMethod,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            let useDefaults = defaultArg UseDefaults true

            Trace2D.initBoxPlot (
                Trace2DStyle.BoxPlot(
                    ?X = x,
                    ?Y = y,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?Whiskerwidth = WhiskerWidth,
                    ?BoxPoints = BoxPoints,
                    ?BoxMean = BoxMean,
                    ?Jitter = Jitter,
                    ?PointPos = PointPos,
                    ?Orientation = Orientation,
                    ?FillColor = Fillcolor,
                    ?Marker = Marker,
                    ?Line = Line,
                    ?AlignmentGroup = AlignmentGroup,
                    ?OffsetGroup = Offsetgroup,
                    ?Notched = Notched,
                    ?NotchWidth = NotchWidth,
                    ?QuartileMethod = QuartileMethod
                )
            )
            |> TraceStyle.TraceInfo(?Name = Name, ?ShowLegend = ShowLegend, ?Opacity = Opacity)
            |> TraceStyle.Marker(?Color = MarkerColor, ?OutlierColor = OutlierColor, ?OutlierWidth = OutlierWidth)
            |> GenericChart.ofTraceObject useDefaults


        /// Displays the distribution of data based on the five number summary: minimum, first quartile, median, third quartile, and maximum.
        [<Extension>]
        static member BoxPlot
            (
                xy: seq<#IConvertible * #IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Fillcolor: Color,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?OutlierColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?OutlierWidth: int,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?WhiskerWidth: float,
                [<Optional; DefaultParameterValue(null)>] ?BoxPoints: StyleParam.BoxPoints,
                [<Optional; DefaultParameterValue(null)>] ?BoxMean: StyleParam.BoxMean,
                [<Optional; DefaultParameterValue(null)>] ?Jitter: float,
                [<Optional; DefaultParameterValue(null)>] ?PointPos: float,
                [<Optional; DefaultParameterValue(null)>] ?Orientation: StyleParam.Orientation,
                [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
                [<Optional; DefaultParameterValue(null)>] ?Line: Line,
                [<Optional; DefaultParameterValue(null)>] ?AlignmentGroup: string,
                [<Optional; DefaultParameterValue(null)>] ?Offsetgroup: string,
                [<Optional; DefaultParameterValue(null)>] ?Notched: bool,
                [<Optional; DefaultParameterValue(null)>] ?NotchWidth: float,
                [<Optional; DefaultParameterValue(null)>] ?QuartileMethod: StyleParam.QuartileMethod,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            let x, y = Seq.unzip xy

            Chart.BoxPlot(
                x,
                y,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Text = Text,
                ?MultiText = MultiText,
                ?Fillcolor = Fillcolor,
                ?MarkerColor = MarkerColor,
                ?OutlierColor = OutlierColor,
                ?OutlierWidth = OutlierWidth,
                ?Opacity = Opacity,
                ?WhiskerWidth = WhiskerWidth,
                ?BoxPoints = BoxPoints,
                ?BoxMean = BoxMean,
                ?Jitter = Jitter,
                ?PointPos = PointPos,
                ?Orientation = Orientation,
                ?Marker = Marker,
                ?Line = Line,
                ?AlignmentGroup = AlignmentGroup,
                ?Offsetgroup = Offsetgroup,
                ?Notched = Notched,
                ?NotchWidth = NotchWidth,
                ?QuartileMethod = QuartileMethod,
                ?UseDefaults = UseDefaults
            )



        /// Displays the distribution of data based on the five number summary: minimum, first quartile, median, third quartile, and maximum.
        [<Extension>]
        static member Violin
            (
                [<Optional; DefaultParameterValue(null)>] ?X: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Y: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?FillColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?Points: StyleParam.JitterPoints,
                [<Optional; DefaultParameterValue(null)>] ?Jitter: float,
                [<Optional; DefaultParameterValue(null)>] ?PointPos: float,
                [<Optional; DefaultParameterValue(null)>] ?Orientation: StyleParam.Orientation,
                [<Optional; DefaultParameterValue(null)>] ?Width: float,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?OutlierColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?OutlierWidth: int,
                [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
                [<Optional; DefaultParameterValue(null)>] ?Line: Line,
                [<Optional; DefaultParameterValue(null)>] ?AlignmentGroup: string,
                [<Optional; DefaultParameterValue(null)>] ?OffsetGroup: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowBox: bool,
                [<Optional; DefaultParameterValue(null)>] ?BoxWidth: float,
                [<Optional; DefaultParameterValue(null)>] ?BoxFillColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?Box: Box,
                [<Optional; DefaultParameterValue(null)>] ?BandWidth: float,
                [<Optional; DefaultParameterValue(null)>] ?MeanLine: MeanLine,
                [<Optional; DefaultParameterValue(null)>] ?ScaleGroup: string,
                [<Optional; DefaultParameterValue(null)>] ?ScaleMode: StyleParam.ScaleMode,
                [<Optional; DefaultParameterValue(null)>] ?Side: StyleParam.ViolinSide,
                [<Optional; DefaultParameterValue(null)>] ?Span: StyleParam.Range,
                [<Optional; DefaultParameterValue(null)>] ?SpanMode: StyleParam.SpanMode,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            let useDefaults = defaultArg UseDefaults true

            let box =
                Box
                |> Option.defaultValue (TraceObjects.Box.init ())
                |> TraceObjects.Box.style (?Visible = ShowBox, ?Width = BoxWidth, ?FillColor = BoxFillColor)

            Trace2D.initViolin (
                Trace2DStyle.Violin(
                    ?X = X,
                    ?Y = Y,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?FillColor = FillColor,
                    ?Opacity = Opacity,
                    ?Points = Points,
                    ?Jitter = Jitter,
                    ?PointPos = PointPos,
                    ?Orientation = Orientation,
                    ?Width = Width,
                    ?Marker = Marker,
                    ?Line = Line,
                    ?AlignmentGroup = AlignmentGroup,
                    ?OffsetGroup = OffsetGroup,
                    Box = box,
                    ?BandWidth = BandWidth,
                    ?MeanLine = MeanLine,
                    ?ScaleGroup = ScaleGroup,
                    ?ScaleMode = ScaleMode,
                    ?Side = Side,
                    ?Span = Span,
                    ?SpanMode = SpanMode
                )
            )
            |> TraceStyle.TraceInfo(?Name = Name, ?ShowLegend = ShowLegend, ?Opacity = Opacity)
            |> TraceStyle.Marker(?Color = MarkerColor, ?OutlierColor = OutlierColor, ?OutlierWidth = OutlierWidth)
            |> GenericChart.ofTraceObject useDefaults


        /// Displays the distribution of data based on the five number summary: minimum, first quartile, median, third quartile, and maximum.
        [<Extension>]
        static member Violin
            (
                xy: seq<#IConvertible * #IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?FillColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?Points: StyleParam.JitterPoints,
                [<Optional; DefaultParameterValue(null)>] ?Jitter: float,
                [<Optional; DefaultParameterValue(null)>] ?PointPos: float,
                [<Optional; DefaultParameterValue(null)>] ?Orientation: StyleParam.Orientation,
                [<Optional; DefaultParameterValue(null)>] ?Width: float,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?OutlierColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?OutlierWidth: int,
                [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
                [<Optional; DefaultParameterValue(null)>] ?Line: Line,
                [<Optional; DefaultParameterValue(null)>] ?AlignmentGroup: string,
                [<Optional; DefaultParameterValue(null)>] ?OffsetGroup: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowBox: bool,
                [<Optional; DefaultParameterValue(null)>] ?BoxWidth: float,
                [<Optional; DefaultParameterValue(null)>] ?BoxFillColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?Box: Box,
                [<Optional; DefaultParameterValue(null)>] ?BandWidth: float,
                [<Optional; DefaultParameterValue(null)>] ?MeanLine: MeanLine,
                [<Optional; DefaultParameterValue(null)>] ?ScaleGroup: string,
                [<Optional; DefaultParameterValue(null)>] ?ScaleMode: StyleParam.ScaleMode,
                [<Optional; DefaultParameterValue(null)>] ?Side: StyleParam.ViolinSide,
                [<Optional; DefaultParameterValue(null)>] ?Span: StyleParam.Range,
                [<Optional; DefaultParameterValue(null)>] ?SpanMode: StyleParam.SpanMode,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            let x, y = Seq.unzip xy

            Chart.Violin(
                x,
                y,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?FillColor = FillColor,
                ?Opacity = Opacity,
                ?Points = Points,
                ?Jitter = Jitter,
                ?PointPos = PointPos,
                ?Orientation = Orientation,
                ?Width = Width,
                ?MarkerColor = MarkerColor,
                ?OutlierColor = OutlierColor,
                ?OutlierWidth = OutlierWidth,
                ?Marker = Marker,
                ?Line = Line,
                ?AlignmentGroup = AlignmentGroup,
                ?OffsetGroup = OffsetGroup,
                ?ShowBox = ShowBox,
                ?BoxWidth = BoxWidth,
                ?BoxFillColor = BoxFillColor,
                ?Box = Box,
                ?BandWidth = BandWidth,
                ?MeanLine = MeanLine,
                ?ScaleGroup = ScaleGroup,
                ?ScaleMode = ScaleMode,
                ?Side = Side,
                ?Span = Span,
                ?SpanMode = SpanMode,
                ?UseDefaults = UseDefaults
            )


        /// Computes the bi-dimensional histogram of two data samples and auto-determines the bin size.
        [<Extension>]
        static member Histogram2DContour
            (
                x: seq<#IConvertible>,
                y: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?Z: seq<#seq<#IConvertible>>,
                [<Optional; DefaultParameterValue(null)>] ?HistFunc: StyleParam.HistFunc,
                [<Optional; DefaultParameterValue(null)>] ?HistNorm: StyleParam.HistNorm,
                [<Optional; DefaultParameterValue(null)>] ?NBinsX: int,
                [<Optional; DefaultParameterValue(null)>] ?NBinsY: int,
                [<Optional; DefaultParameterValue(null)>] ?BinGroup: string,
                [<Optional; DefaultParameterValue(null)>] ?XBinGroup: string,
                [<Optional; DefaultParameterValue(null)>] ?XBins: Bins,
                [<Optional; DefaultParameterValue(null)>] ?YBinGroup: string,
                [<Optional; DefaultParameterValue(null)>] ?YBins: Bins,
                [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
                [<Optional; DefaultParameterValue(null)>] ?LineDash: StyleParam.DrawingStyle,
                [<Optional; DefaultParameterValue(null)>] ?LineColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?Line: Line,
                [<Optional; DefaultParameterValue(null)>] ?ColorBar: ColorBar,
                [<Optional; DefaultParameterValue(null)>] ?ColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?ShowScale: bool,
                [<Optional; DefaultParameterValue(null)>] ?ReverseScale: bool,
                [<Optional; DefaultParameterValue(null)>] ?Contours: Contours,
                [<Optional; DefaultParameterValue(null)>] ?NContours: int,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =
            let useDefaults = defaultArg UseDefaults true

            Trace2D.initHistogram2DContour (
                Trace2DStyle.Histogram2DContour(
                    X = x,
                    Y = y,
                    ?Z = Z,
                    ?HistFunc = HistFunc,
                    ?HistNorm = HistNorm,
                    ?NBinsX = NBinsX,
                    ?NBinsY = NBinsY,
                    ?BinGroup = BinGroup,
                    ?XBinGroup = XBinGroup,
                    ?XBins = XBins,
                    ?YBinGroup = YBinGroup,
                    ?YBins = YBins,
                    ?Marker = Marker,
                    ?Line = Line,
                    ?ColorBar = ColorBar,
                    ?ColorScale = ColorScale,
                    ?ShowScale = ShowScale,
                    ?ReverseScale = ReverseScale,
                    ?Contours = Contours,
                    ?NContours = NContours
                )
            )
            |> TraceStyle.TraceInfo(?Name = Name, ?ShowLegend = ShowLegend, ?Opacity = Opacity)
            |> TraceStyle.Line(?Color = LineColor, ?Dash = LineDash)
            |> GenericChart.ofTraceObject useDefaults

        /// Shows a graphical representation of a 3-dimensional surface by plotting constant z slices, called contours, on a 2-dimensional format.
        /// That is, given a value for z, lines are drawn for connecting the (x,y) coordinates where that z value occurs.
        [<Extension>]
        static member Heatmap
            (
                zData: seq<#seq<#IConvertible>>,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?X: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?XGap: int,
                [<Optional; DefaultParameterValue(null)>] ?Y: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?YGap: int,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?ColorBar: ColorBar,
                [<Optional; DefaultParameterValue(null)>] ?ColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?ShowScale: bool,
                [<Optional; DefaultParameterValue(null)>] ?ReverseScale: bool,
                [<Optional; DefaultParameterValue(null)>] ?ZSmooth: StyleParam.SmoothAlg,
                [<Optional; DefaultParameterValue(null)>] ?Transpose: bool,
                [<Optional; DefaultParameterValue(false)>] ?UseWebGL: bool,
                [<Optional; DefaultParameterValue(false)>] ?ReverseYAxis: bool,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            let useDefaults = defaultArg UseDefaults true
            let reverseYAxis = defaultArg ReverseYAxis false

            let style =
                Trace2DStyle.Heatmap(
                    Z = zData,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?X = X,
                    ?XGap = XGap,
                    ?Y = Y,
                    ?YGap = YGap,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?ColorBar = ColorBar,
                    ?ColorScale = ColorScale,
                    ?ShowScale = ShowScale,
                    ?ReverseScale = ReverseScale,
                    ?ZSmooth = ZSmooth,
                    ?Transpose = Transpose
                )

            let useWebGL = defaultArg UseWebGL false

            Chart.renderHeatmapTrace useDefaults useWebGL style
            |> fun c ->
                if reverseYAxis then
                    c |> Chart.withYAxis (LinearAxis.init (AutoRange = StyleParam.AutoRange.Reversed))
                else
                    c

        /// Shows a graphical representation of a 3-dimensional surface by plotting constant z slices, called contours, on a 2-dimensional format.
        /// That is, given a value for z, lines are drawn for connecting the (x,y) coordinates where that z value occurs.
        [<Extension>]
        static member Heatmap
            (
                zData: seq<#seq<#IConvertible>>,
                colNames: seq<string>,
                rowNames: seq<string>,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?XGap: int,
                [<Optional; DefaultParameterValue(null)>] ?YGap: int,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?ColorBar: ColorBar,
                [<Optional; DefaultParameterValue(null)>] ?ColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?ShowScale: bool,
                [<Optional; DefaultParameterValue(null)>] ?ReverseScale: bool,
                [<Optional; DefaultParameterValue(null)>] ?ZSmooth: StyleParam.SmoothAlg,
                [<Optional; DefaultParameterValue(null)>] ?Transpose: bool,
                [<Optional; DefaultParameterValue(false)>] ?UseWebGL: bool,
                [<Optional; DefaultParameterValue(false)>] ?ReverseYAxis: bool,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            let useDefaults = defaultArg UseDefaults true
            let reverseYAxis = defaultArg ReverseYAxis false

            let style =
                Trace2DStyle.Heatmap(
                    Z = zData,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    X = (colNames |> Seq.map (fun x -> x :> IConvertible)),
                    ?XGap = XGap,
                    Y = (rowNames |> Seq.map (fun x -> x :> IConvertible)),
                    ?YGap = YGap,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?ColorBar = ColorBar,
                    ?ColorScale = ColorScale,
                    ?ShowScale = ShowScale,
                    ?ReverseScale = ReverseScale,
                    ?ZSmooth = ZSmooth,
                    ?Transpose = Transpose
                )

            let useWebGL = defaultArg UseWebGL false

            Chart.renderHeatmapTrace useDefaults useWebGL style
            |> fun c ->
                if reverseYAxis then
                    c |> Chart.withYAxis (LinearAxis.init (AutoRange = StyleParam.AutoRange.Reversed))
                else
                    c

        /// Shows a graphical representation of a 3-dimensional surface by plotting constant z slices, called contours, on a 2-dimensional format.
        /// That is, given a value for z, lines are drawn for connecting the (x,y) coordinates where that z value occurs.
        [<Extension>]
        static member AnnotatedHeatmap
            (
                zData: seq<#seq<#IConvertible>>,
                annotationText: seq<#seq<string>>,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?X: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?XGap: int,
                [<Optional; DefaultParameterValue(null)>] ?Y: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?YGap: int,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?ColorBar: ColorBar,
                [<Optional; DefaultParameterValue(null)>] ?ColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?ShowScale: bool,
                [<Optional; DefaultParameterValue(null)>] ?ReverseScale: bool,
                [<Optional; DefaultParameterValue(null)>] ?ZSmooth: StyleParam.SmoothAlg,
                [<Optional; DefaultParameterValue(null)>] ?Transpose: bool,
                [<Optional; DefaultParameterValue(false)>] ?UseWebGL: bool,
                [<Optional; DefaultParameterValue(false)>] ?ReverseYAxis: bool,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            let useDefaults = defaultArg UseDefaults true
            let reverseYAxis = defaultArg ReverseYAxis false

            let dims = Seq.length zData
            let dims2 = Seq.length annotationText

            if dims <> dims2 then
                failwith "incompatible dims"

            let style =
                Trace2DStyle.Heatmap(
                    Z = zData,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?X = X,
                    ?XGap = XGap,
                    ?Y = Y,
                    ?YGap = YGap,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?ColorBar = ColorBar,
                    ?ColorScale = ColorScale,
                    ?ShowScale = ShowScale,
                    ?ReverseScale = ReverseScale,
                    ?ZSmooth = ZSmooth,
                    ?Transpose = Transpose
                )

            let useWebGL = defaultArg UseWebGL false

            Chart.renderHeatmapTrace useDefaults useWebGL style
            |> fun c ->
                if reverseYAxis then
                    c |> Chart.withYAxis (LinearAxis.init (AutoRange = StyleParam.AutoRange.Reversed))
                else
                    c
            |> Chart.withAnnotations (
                annotationText
                |> Seq.mapi
                    (fun y inner ->
                        inner
                        |> Seq.mapi (fun x text -> Annotation.init (x, y, Text = (string text), ShowArrow = false)))
                |> Seq.concat
            )


        [<Extension>]
        static member Image
            (
                [<Optional; DefaultParameterValue(null)>] ?Z: seq<#seq<#seq<int>>>,
                [<Optional; DefaultParameterValue(null)>] ?Source: string,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?Ids: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?ColorModel: StyleParam.ColorModel,
                [<Optional; DefaultParameterValue(null)>] ?ZMax: StyleParam.ColorComponentBound,
                [<Optional; DefaultParameterValue(null)>] ?ZMin: StyleParam.ColorComponentBound,
                [<Optional; DefaultParameterValue(null)>] ?ZSmooth: StyleParam.SmoothAlg,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            let useDefaults = defaultArg UseDefaults true

            Trace2D.initImage (
                Trace2DStyle.Image(
                    ?Z = Z,
                    ?Source = Source,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Ids = Ids,
                    ?ColorModel = ColorModel,
                    ?ZMax = ZMax,
                    ?ZMin = ZMin,
                    ?ZSmooth = ZSmooth
                )
            )
            |> GenericChart.ofTraceObject useDefaults

        [<Extension>]
        static member Image
            (
                z: seq<#seq<ARGB>>,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?Ids: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?ZMax: StyleParam.ColorComponentBound,
                [<Optional; DefaultParameterValue(null)>] ?ZMin: StyleParam.ColorComponentBound,
                [<Optional; DefaultParameterValue(null)>] ?ZSmooth: StyleParam.SmoothAlg,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            let useDefaults = defaultArg UseDefaults true

            let z' =
                z
                |> Seq.map (
                    Seq.map
                        (fun argb ->
                            seq {
                                int argb.R
                                int argb.G
                                int argb.B
                                int argb.A
                            })
                )


            Trace2D.initImage (
                Trace2DStyle.Image(
                    Z = z',
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Ids = Ids,
                    ColorModel = StyleParam.ColorModel.RGBA,
                    ?ZMax = ZMax,
                    ?ZMin = ZMin,
                    ?ZSmooth = ZSmooth
                )
            )
            |> GenericChart.ofTraceObject useDefaults

        /// Shows a graphical representation of a 3-dimensional surface by plotting constant z slices, called contours, on a 2-dimensional format
        [<Extension>]
        static member Contour
            (
                zData: seq<#seq<#IConvertible>>,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?X: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Y: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?ColorBar: ColorBar,
                [<Optional; DefaultParameterValue(null)>] ?ColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?ShowScale: bool,
                [<Optional; DefaultParameterValue(null)>] ?ReverseScale: bool,
                [<Optional; DefaultParameterValue(null)>] ?Transpose: bool,
                [<Optional; DefaultParameterValue(null)>] ?LineColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?LineDash: StyleParam.DrawingStyle,
                [<Optional; DefaultParameterValue(null)>] ?Line: Line,
                [<Optional; DefaultParameterValue(null)>] ?ContoursColoring: StyleParam.ContourColoring,
                [<Optional; DefaultParameterValue(null)>] ?ContoursOperation: StyleParam.ConstraintOperation,
                [<Optional; DefaultParameterValue(null)>] ?ContoursType: StyleParam.ContourType,
                [<Optional; DefaultParameterValue(null)>] ?ShowContourLabels: bool,
                [<Optional; DefaultParameterValue(null)>] ?ContourLabelFont: Font,
                [<Optional; DefaultParameterValue(null)>] ?Contours: Contours,
                [<Optional; DefaultParameterValue(null)>] ?FillColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?NContours: int,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            let useDefaults = defaultArg UseDefaults true

            let contours =
                Contours
                |> Option.defaultValue (TraceObjects.Contours.init ())
                |> TraceObjects.Contours.style (
                    ?Coloring = ContoursColoring,
                    ?Operation = ContoursOperation,
                    ?Type = ContoursType,
                    ?ShowLabels = ShowContourLabels,
                    ?LabelFont = ContourLabelFont
                )

            let line =
                Line
                |> Option.defaultValue (Plotly.NET.Line.init ())
                |> Plotly.NET.Line.style (?Color = LineColor, ?Dash = LineDash)

            Trace2D.initContour (
                Trace2DStyle.Contour(
                    Z = zData,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?X = X,
                    ?Y = Y,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?ColorBar = ColorBar,
                    ?ColorScale = ColorScale,
                    ?ShowScale = ShowScale,
                    ?ReverseScale = ReverseScale,
                    ?Transpose = Transpose,
                    ?FillColor = FillColor,
                    ?NContours = NContours,
                    Contours = contours,
                    Line = line
                )
            )
            |> GenericChart.ofTraceObject useDefaults

        /// Creates an OHLC (open-high-low-close) chart. OHLC charts are typically used to illustrate movements in the price of a financial instrument over time.
        [<Extension>]
        static member OHLC
            (
                ``open``: #IConvertible seq,
                high: #IConvertible seq,
                low: #IConvertible seq,
                close: #IConvertible seq,
                x: #IConvertible seq,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Line: Line,
                [<Optional; DefaultParameterValue(null)>] ?IncreasingColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?Increasing: FinanceMarker,
                [<Optional; DefaultParameterValue(null)>] ?DecreasingColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?Decreasing: FinanceMarker,
                [<Optional; DefaultParameterValue(null)>] ?TickWidth: float,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            let useDefaults = defaultArg UseDefaults true

            let increasing =
                Increasing
                |> Option.defaultValue (FinanceMarker.init ())
                |> FinanceMarker.style (?LineColor = IncreasingColor)

            let decreasing =
                Decreasing
                |> Option.defaultValue (FinanceMarker.init ())
                |> FinanceMarker.style (?LineColor = DecreasingColor)

            Trace2D.initOHLC (
                Trace2DStyle.OHLC(
                    Open = ``open``,
                    High = high,
                    Low = low,
                    Close = close,
                    X = x,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?Line = Line,
                    Increasing = increasing,
                    Decreasing = decreasing,
                    ?TickWidth = TickWidth
                )
            )
            |> GenericChart.ofTraceObject useDefaults

        /// Creates an OHLC (open-high-low-close) chart. OHLC charts are typically used to illustrate movements in the price of a financial instrument over time.
        [<Extension>]
        static member OHLC
            (
                stockTimeSeries: seq<System.DateTime * StockData>,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Line: Line,
                [<Optional; DefaultParameterValue(null)>] ?IncreasingColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?Increasing: FinanceMarker,
                [<Optional; DefaultParameterValue(null)>] ?DecreasingColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?Decreasing: FinanceMarker,
                [<Optional; DefaultParameterValue(null)>] ?TickWidth: float,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            let useDefaults = defaultArg UseDefaults true

            Chart.OHLC(
                ``open`` = (stockTimeSeries |> Seq.map (snd >> (fun x -> x.Open))),
                high = (stockTimeSeries |> Seq.map (snd >> (fun x -> x.High))),
                low = (stockTimeSeries |> Seq.map (snd >> (fun x -> x.Low))),
                close = (stockTimeSeries |> Seq.map (snd >> (fun x -> x.Close))),
                x = (stockTimeSeries |> Seq.map fst),
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?Line = Line,
                ?IncreasingColor = IncreasingColor,
                ?Increasing = Increasing,
                ?DecreasingColor = DecreasingColor,
                ?Decreasing = Decreasing,
                ?TickWidth = TickWidth,
                ?UseDefaults = UseDefaults
            )



        /// Creates a candlestick chart. A candlestick cart is a style of financial chart used to describe price movements of a
        /// security, derivative, or currency. Each "candlestick" typically shows one day, thus a one-month chart may show the 20
        /// trading days as 20 candlesticks. Candlestick charts can also be built using intervals shorter or longer than one day.
        static member Candlestick
            (
                ``open``: #IConvertible seq,
                high: #IConvertible seq,
                low: #IConvertible seq,
                close: #IConvertible seq,
                x: #IConvertible seq,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Line: Line,
                [<Optional; DefaultParameterValue(null)>] ?IncreasingColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?Increasing: FinanceMarker,
                [<Optional; DefaultParameterValue(null)>] ?DecreasingColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?Decreasing: FinanceMarker,
                [<Optional; DefaultParameterValue(null)>] ?WhiskerWidth: float,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            let useDefaults = defaultArg UseDefaults true

            let increasing =
                Increasing
                |> Option.defaultValue (FinanceMarker.init ())
                |> FinanceMarker.style (?LineColor = IncreasingColor)

            let decreasing =
                Decreasing
                |> Option.defaultValue (FinanceMarker.init ())
                |> FinanceMarker.style (?LineColor = DecreasingColor)

            Trace2D.initCandlestick (
                Trace2DStyle.Candlestick(
                    Open = ``open``,
                    High = high,
                    Low = low,
                    Close = close,
                    X = x,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?Line = Line,
                    Increasing = increasing,
                    Decreasing = decreasing,
                    ?WhiskerWidth = WhiskerWidth
                )
            )
            |> GenericChart.ofTraceObject useDefaults

        /// Creates an OHLC (open-high-low-close) chart. OHLC charts are typically used to illustrate movements in the price of a financial instrument over time.
        [<Extension>]
        static member Candlestick
            (
                stockTimeSeries: seq<System.DateTime * StockData>,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Line: Line,
                [<Optional; DefaultParameterValue(null)>] ?IncreasingColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?Increasing: FinanceMarker,
                [<Optional; DefaultParameterValue(null)>] ?DecreasingColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?Decreasing: FinanceMarker,
                [<Optional; DefaultParameterValue(null)>] ?WhiskerWidth: float,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            let useDefaults = defaultArg UseDefaults true

            Chart.Candlestick(
                ``open`` = (stockTimeSeries |> Seq.map (snd >> (fun x -> x.Open))),
                high = (stockTimeSeries |> Seq.map (snd >> (fun x -> x.High))),
                low = (stockTimeSeries |> Seq.map (snd >> (fun x -> x.Low))),
                close = (stockTimeSeries |> Seq.map (snd >> (fun x -> x.Close))),
                x = (stockTimeSeries |> Seq.map fst),
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?Line = Line,
                ?IncreasingColor = IncreasingColor,
                ?Increasing = Increasing,
                ?DecreasingColor = DecreasingColor,
                ?Decreasing = Decreasing,
                ?WhiskerWidth = WhiskerWidth,
                ?UseDefaults = UseDefaults
            )

        /// Computes a scatter plot matrix (SPLOM)
        [<Extension>]
        static member Splom
            (
                dimensions: seq<Dimension>,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?MarkerOutline: Line,
                [<Optional; DefaultParameterValue(null)>] ?MarkerSymbol: StyleParam.MarkerSymbol,
                [<Optional; DefaultParameterValue(null)>] ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
                [<Optional; DefaultParameterValue(null)>] ?ShowDiagonal: bool,
                [<Optional; DefaultParameterValue(null)>] ?Diagonal: SplomDiagonal,
                [<Optional; DefaultParameterValue(null)>] ?ShowLowerHalf: bool,
                [<Optional; DefaultParameterValue(null)>] ?ShowUpperHalf: bool,
                [<Optional; DefaultParameterValue(null)>] ?UseDefaults: bool
            ) =

            let useDefaults = defaultArg UseDefaults true

            let marker =
                Marker
                |> Option.defaultValue (TraceObjects.Marker.init ())
                |> TraceObjects.Marker.style (
                    ?Color = MarkerColor,
                    ?Outline = MarkerOutline,
                    ?Symbol = MarkerSymbol,
                    ?MultiSymbol = MultiMarkerSymbol,
                    ?Colorscale = MarkerColorScale
                )

            let diagonal =
                Diagonal
                |> Option.defaultValue (TraceObjects.SplomDiagonal.init ())
                |> TraceObjects.SplomDiagonal.style (?Visible = ShowDiagonal)

            Trace2D.initSplom (
                Trace2DStyle.Splom(
                    Dimensions = dimensions,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    Marker = marker,
                    Diagonal = diagonal,
                    ?ShowLowerHalf = ShowLowerHalf,
                    ?ShowUpperHalf = ShowUpperHalf
                )
            )
            |> GenericChart.ofTraceObject useDefaults

        /// Computes the Splom plot
        [<Extension>]
        static member Splom
            (
                keyValues: seq<string * #seq<#IConvertible>>,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?MarkerColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?MarkerOutline: Line,
                [<Optional; DefaultParameterValue(null)>] ?MarkerSymbol: StyleParam.MarkerSymbol,
                [<Optional; DefaultParameterValue(null)>] ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
                [<Optional; DefaultParameterValue(null)>] ?ShowDiagonal: bool,
                [<Optional; DefaultParameterValue(null)>] ?Diagonal: SplomDiagonal,
                [<Optional; DefaultParameterValue(null)>] ?ShowLowerHalf: bool,
                [<Optional; DefaultParameterValue(null)>] ?ShowUpperHalf: bool,
                [<Optional; DefaultParameterValue(null)>] ?UseDefaults: bool
            ) =

            let dims =
                keyValues |> Seq.map (fun (key, vals) -> Dimension.initSplom (Label = key, Values = vals))

            Chart.Splom(
                dims,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerSymbol = MarkerSymbol,
                ?MultiMarkerSymbol = MultiMarkerSymbol,
                ?Marker = Marker,
                ?ShowDiagonal = ShowDiagonal,
                ?Diagonal = Diagonal,
                ?ShowLowerHalf = ShowLowerHalf,
                ?ShowUpperHalf = ShowUpperHalf,
                ?UseDefaults = UseDefaults
            )
