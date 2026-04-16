namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects

open DynamicObj
open System
open System.IO

open StyleParam
open System.Runtime.InteropServices
open System.Runtime.CompilerServices

[<AutoOpen>]
module ChartCarpet_Scatter =

    [<Extension>]
    type Chart =
        /// <summary>
        /// Creates a scatter plot that lies on a specified carpet.
        ///
        /// In general, ScatterCarpet creates a plot that uses the given carpet identifier as coordinate system.
        ///
        /// Whether the resulting plot is a cheater or true carpet plot depends on the referenced carpet.
        ///
        /// ScatterCarpet charts are the basis of PointCarpet, LineCarpet, and BubbleCarpet Charts, and can be customized as such. We also provide abstractions for those: Chart.LineCarpet, Chart.PointCarpet, Chart.BubbleCarpet
        /// </summary>
        /// <param name="a">Sets the a-axis coordinates on the carpet.</param>
        /// <param name="b">Sets the b-axis coordinates on the carpet.</param>
        /// <param name="mode">Determines the drawing mode for this scatter trace. If the provided `mode` includes "text" then the `text` elements appear at the coordinates. Otherwise, the `text` elements appear on hover. If there are less than 20 points and the trace is not stacked then the default is "lines+markers". Otherwise, "lines".</param>
        /// <param name="carpetAnchorId">The identifier of the carpet that this trace will lie on.</param>
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
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member ScatterCarpet
            (
                a: seq<#IConvertible>,
                b: seq<#IConvertible>,
                mode: StyleParam.Mode,
                carpetAnchorId: string,
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

            TraceCarpet.initScatterCarpet (
                TraceCarpetStyle.ScatterCarpet(
                    A = a,
                    B = b,
                    Mode = mode,
                    Carpet = (carpetAnchorId |> StyleParam.SubPlotId.Carpet),
                    Marker = marker,
                    Line = line,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?TextPosition = TextPosition,
                    ?MultiTextPosition = MultiTextPosition
                )
            )
            |> GenericChart.ofTraceObject useDefaults

        /// <summary>
        /// Creates a scatter plot that lies on a specified carpet from encoded a and b coordinates.
        /// </summary>
        /// <param name="aEncoded">Sets the a-axis coordinates on the carpet as an encoded typed array.</param>
        /// <param name="bEncoded">Sets the b-axis coordinates on the carpet as an encoded typed array.</param>
        /// <param name="mode">Determines the drawing mode for this scatter trace. If the provided `mode` includes "text" then the `text` elements appear at the coordinates. Otherwise, the `text` elements appear on hover. If there are less than 20 points and the trace is not stacked then the default is "lines+markers". Otherwise, "lines".</param>
        /// <param name="carpetAnchorId">The identifier of the carpet that this trace will lie on.</param>
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
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member ScatterCarpet
            (
                aEncoded: EncodedTypedArray,
                bEncoded: EncodedTypedArray,
                mode: StyleParam.Mode,
                carpetAnchorId: string,
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

            TraceCarpet.initScatterCarpet (
                TraceCarpetStyle.ScatterCarpet(
                    AEncoded = aEncoded,
                    BEncoded = bEncoded,
                    Mode = mode,
                    Carpet = (carpetAnchorId |> StyleParam.SubPlotId.Carpet),
                    Marker = marker,
                    Line = line,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?TextPosition = TextPosition,
                    ?MultiTextPosition = MultiTextPosition
                )
            )
            |> GenericChart.ofTraceObject useDefaults

        /// <summary>
        /// Creates a scatter plot that lies on a specified carpet.
        ///
        /// In general, ScatterCarpet creates a plot that uses the given carpet identifier as coordinate system.
        ///
        /// Whether the resulting plot is a cheater or true carpet plot depends on the referenced carpet.
        ///
        /// ScatterCarpet charts are the basis of PointCarpet, LineCarpet, and BubbleCarpet Charts, and can be customized as such. We also provide abstractions for those: Chart.LineCarpet, Chart.PointCarpet, Chart.BubbleCarpet
        /// </summary>
        /// <param name="ab">Sets the a and b-axis coordinates on the carpet.</param>
        /// <param name="mode">Determines the drawing mode for this scatter trace. If the provided `mode` includes "text" then the `text` elements appear at the coordinates. Otherwise, the `text` elements appear on hover. If there are less than 20 points and the trace is not stacked then the default is "lines+markers". Otherwise, "lines".</param>
        /// <param name="carpetAnchorId">The identifier of the carpet that this trace will lie on.</param>
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
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member ScatterCarpet
            (
                ab: seq<#IConvertible * #IConvertible>,
                mode: StyleParam.Mode,
                carpetAnchorId: string,
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
                ?UseDefaults: bool
            ) =

            let a, b = Seq.unzip ab

            Chart.ScatterCarpet(
                a,
                b,
                mode,
                carpetAnchorId,
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
                ?UseDefaults = UseDefaults

            )

        /// <summary>
        /// Creates a point plot that lies on a specified carpet.
        ///
        /// In general, PointCarpet creates a point plot that uses the given carpet identifier as coordinate system.
        ///
        /// Whether the resulting plot is a cheater or true carpet plot depends on the referenced carpet.
        /// </summary>
        /// <param name="a">Sets the a-axis coordinates on the carpet.</param>
        /// <param name="b">Sets the b-axis coordinates on the carpet.</param>
        /// <param name="carpetAnchorId">The identifier of the carpet that this trace will lie on.</param>
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
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member PointCarpet
            (
                a: seq<#IConvertible>,
                b: seq<#IConvertible>,
                carpetAnchorId: string,
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
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let changeMode =
                StyleParam.ModeUtils.showText (TextPosition.IsSome || MultiTextPosition.IsSome)

            Chart.ScatterCarpet(
                a,
                b,
                changeMode StyleParam.Mode.Markers,
                carpetAnchorId,
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
                ?UseDefaults = UseDefaults

            )

        /// <summary>Creates a point plot on a specified carpet from encoded a and b coordinates.</summary>
        [<Extension>]
        static member PointCarpet
            (
                aEncoded: EncodedTypedArray,
                bEncoded: EncodedTypedArray,
                carpetAnchorId: string,
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
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let changeMode =
                StyleParam.ModeUtils.showText (TextPosition.IsSome || MultiTextPosition.IsSome)

            Chart.ScatterCarpet(
                aEncoded,
                bEncoded,
                changeMode StyleParam.Mode.Markers,
                carpetAnchorId,
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
                ?UseDefaults = UseDefaults

            )

        /// <summary>
        /// Creates a point plot that lies on a specified carpet.
        ///
        /// In general, PointCarpet creates a point plot that uses the given carpet identifier as coordinate system.
        ///
        /// Whether the resulting plot is a cheater or true carpet plot depends on the referenced carpet.
        /// </summary>
        /// <param name="ab">Sets the a and b-axis coordinates on the carpet.</param>
        /// <param name="carpetAnchorId">The identifier of the carpet that this trace will lie on.</param>
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
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member PointCarpet
            (
                ab: seq<#IConvertible * #IConvertible>,
                carpetAnchorId: string,
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
                ?UseDefaults: bool
            ) =

            let a, b = Seq.unzip ab

            Chart.PointCarpet(
                a,
                b,
                carpetAnchorId,
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
                ?UseDefaults = UseDefaults
            )

        /// <summary>
        /// Creates a line plot that lies on a specified carpet.
        ///
        /// In general, LineCarpet creates a line plot that uses the given carpet identifier as coordinate system.
        ///
        /// Whether the resulting plot is a cheater or true carpet plot depends on the referenced carpet.
        /// </summary>
        /// <param name="a">Sets the a-axis coordinates on the carpet.</param>
        /// <param name="b">Sets the b-axis coordinates on the carpet.</param>
        /// <param name="carpetAnchorId">The identifier of the carpet that this trace will lie on.</param>
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
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member LineCarpet
            (
                a: seq<#IConvertible>,
                b: seq<#IConvertible>,
                carpetAnchorId: string,
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
                ?UseDefaults: bool
            ) =

            let changeMode =
                let isShowMarker =
                    match ShowMarkers with
                    | Some isShow -> isShow
                    | Option.None -> false

                StyleParam.ModeUtils.showText (TextPosition.IsSome || MultiTextPosition.IsSome)
                >> StyleParam.ModeUtils.showMarker (isShowMarker)

            Chart.ScatterCarpet(
                a,
                b,
                changeMode StyleParam.Mode.Lines,
                carpetAnchorId,
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
                ?UseDefaults = UseDefaults
            )

        /// <summary>Creates a line plot on a specified carpet from encoded a and b coordinates.</summary>
        [<Extension>]
        static member LineCarpet
            (
                aEncoded: EncodedTypedArray,
                bEncoded: EncodedTypedArray,
                carpetAnchorId: string,
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
                ?UseDefaults: bool
            ) =

            let changeMode =
                let isShowMarker =
                    match ShowMarkers with
                    | Some isShow -> isShow
                    | Option.None -> false

                StyleParam.ModeUtils.showText (TextPosition.IsSome || MultiTextPosition.IsSome)
                >> StyleParam.ModeUtils.showMarker (isShowMarker)

            Chart.ScatterCarpet(
                aEncoded,
                bEncoded,
                changeMode StyleParam.Mode.Lines,
                carpetAnchorId,
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
                ?UseDefaults = UseDefaults
            )

        /// <summary>
        /// Creates a line plot that lies on a specified carpet.
        ///
        /// In general, LineCarpet creates a line plot that uses the given carpet identifier as coordinate system.
        ///
        /// Whether the resulting plot is a cheater or true carpet plot depends on the referenced carpet.
        /// </summary>
        /// <param name="ab">Sets the a and b-axis coordinates on the carpet.</param>
        /// <param name="carpetAnchorId">The identifier of the carpet that this trace will lie on.</param>
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
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member LineCarpet
            (
                ab: seq<#IConvertible * #IConvertible>,
                carpetAnchorId: string,
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
                ?UseDefaults: bool
            ) =

            let a, b = Seq.unzip ab

            Chart.LineCarpet(
                a,
                b,
                carpetAnchorId,
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
                ?UseDefaults = UseDefaults
            )

        /// <summary>
        /// Creates a spline plot that lies on a specified carpet.
        ///
        /// In general, SplineCarpet creates a spline plot that uses the given carpet identifier as coordinate system.
        /// A spline chart is a line chart in which data points are connected by smoothed curves.
        ///
        /// Whether the resulting plot is a cheater or true carpet plot depends on the referenced carpet.
        /// </summary>
        /// <param name="a">Sets the a-axis coordinates on the carpet.</param>
        /// <param name="b">Sets the b-axis coordinates on the carpet.</param>
        /// <param name="carpetAnchorId">The identifier of the carpet that this trace will lie on.</param>
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
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member SplineCarpet
            (
                a: seq<#IConvertible>,
                b: seq<#IConvertible>,
                carpetAnchorId: string,
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
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let changeMode =
                let isShowMarker =
                    match ShowMarkers with
                    | Some isShow -> isShow
                    | Option.None -> false

                StyleParam.ModeUtils.showText (TextPosition.IsSome || MultiTextPosition.IsSome)
                >> StyleParam.ModeUtils.showMarker (isShowMarker)

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
                    ?Smoothing = Smoothing,
                    Shape = StyleParam.Shape.Spline
                )

            TraceCarpet.initScatterCarpet (
                TraceCarpetStyle.ScatterCarpet(
                    A = a,
                    B = b,
                    Mode = changeMode StyleParam.Mode.Lines,
                    Carpet = (carpetAnchorId |> StyleParam.SubPlotId.Carpet),
                    Marker = marker,
                    Line = line,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?TextPosition = TextPosition,
                    ?MultiTextPosition = MultiTextPosition
                )
            )
            |> GenericChart.ofTraceObject useDefaults

        /// <summary>Creates a spline plot on a specified carpet from encoded a and b coordinates.</summary>
        [<Extension>]
        static member SplineCarpet
            (
                aEncoded: EncodedTypedArray,
                bEncoded: EncodedTypedArray,
                carpetAnchorId: string,
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
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let changeMode =
                let isShowMarker =
                    match ShowMarkers with
                    | Some isShow -> isShow
                    | Option.None -> false

                StyleParam.ModeUtils.showText (TextPosition.IsSome || MultiTextPosition.IsSome)
                >> StyleParam.ModeUtils.showMarker (isShowMarker)

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
                    ?Smoothing = Smoothing,
                    Shape = StyleParam.Shape.Spline
                )

            TraceCarpet.initScatterCarpet (
                TraceCarpetStyle.ScatterCarpet(
                    AEncoded = aEncoded,
                    BEncoded = bEncoded,
                    Mode = changeMode StyleParam.Mode.Lines,
                    Carpet = (carpetAnchorId |> StyleParam.SubPlotId.Carpet),
                    Marker = marker,
                    Line = line,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?TextPosition = TextPosition,
                    ?MultiTextPosition = MultiTextPosition
                )
            )
            |> GenericChart.ofTraceObject useDefaults


        /// <summary>
        /// Creates a spline plot that lies on a specified carpet.
        ///
        /// In general, SplineCarpet creates a spline plot that uses the given carpet identifier as coordinate system.
        /// A spline chart is a line chart in which data points are connected by smoothed curves.
        ///
        /// Whether the resulting plot is a cheater or true carpet plot depends on the referenced carpet.
        /// </summary>
        /// <param name="ab">Sets the a and b-axis coordinates on the carpet.</param>
        /// <param name="carpetAnchorId">The identifier of the carpet that this trace will lie on.</param>
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
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member SplineCarpet
            (
                ab: seq<#IConvertible * #IConvertible>,
                carpetAnchorId: string,
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
                ?UseDefaults: bool
            ) =

            let a, b = Seq.unzip ab

            Chart.SplineCarpet(
                a,
                b,
                carpetAnchorId,
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
                ?UseDefaults = UseDefaults

            )

        /// <summary>
        /// Creates a bubble chart that lies on a specified carpet.
        ///
        /// In general, BubbleCarpet creates a bubble chart that uses the given carpet identifier as coordinate system.
        ///
        /// A bubble chart is a variation of the Point chart, where the data points get an additional scale by being rendered as bubbles of different sizes.
        ///
        /// Whether the resulting plot is a cheater or true carpet plot depends on the referenced carpet.
        /// </summary>
        /// <param name="a">Sets the a-axis coordinates on the carpet.</param>
        /// <param name="b">Sets the b-axis coordinates on the carpet.</param>
        /// <param name="sizes">Sets the bubble size of the plotted data</param>
        /// <param name="carpetAnchorId">The identifier of the carpet that this trace will lie on.</param>
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
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        static member BubbleCarpet
            (
                a: seq<#IConvertible>,
                b: seq<#IConvertible>,
                sizes: seq<int>,
                carpetAnchorId: string,
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

            TraceCarpet.initScatterCarpet (
                TraceCarpetStyle.ScatterCarpet(
                    A = a,
                    B = b,
                    Mode = changeMode StyleParam.Mode.Markers,
                    Carpet = (carpetAnchorId |> StyleParam.SubPlotId.Carpet),
                    Marker = marker,
                    Line = line,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?TextPosition = TextPosition,
                    ?MultiTextPosition = MultiTextPosition
                )
            )
            |> GenericChart.ofTraceObject useDefaults

        /// <summary>Creates a bubble chart on a specified carpet from encoded a and b coordinates.</summary>
        static member BubbleCarpet
            (
                aEncoded: EncodedTypedArray,
                bEncoded: EncodedTypedArray,
                sizes: seq<int>,
                carpetAnchorId: string,
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

            TraceCarpet.initScatterCarpet (
                TraceCarpetStyle.ScatterCarpet(
                    AEncoded = aEncoded,
                    BEncoded = bEncoded,
                    Mode = changeMode StyleParam.Mode.Markers,
                    Carpet = (carpetAnchorId |> StyleParam.SubPlotId.Carpet),
                    Marker = marker,
                    Line = line,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?TextPosition = TextPosition,
                    ?MultiTextPosition = MultiTextPosition
                )
            )
            |> GenericChart.ofTraceObject useDefaults

        /// <summary>
        /// Creates a bubble chart that lies on a specified carpet.
        ///
        /// In general, BubbleCarpet creates a bubble chart that uses the given carpet identifier as coordinate system.
        ///
        /// A bubble chart is a variation of the Point chart, where the data points get an additional scale by being rendered as bubbles of different sizes.
        ///
        /// Whether the resulting plot is a cheater or true carpet plot depends on the referenced carpet.
        /// </summary>
        /// <param name="absizes">Sets the a and b-axis coordinates on the carpet and the associated bubble size.</param>
        /// <param name="carpetAnchorId">The identifier of the carpet that this trace will lie on.</param>
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
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        static member BubbleCarpet
            (
                absizes: seq<#IConvertible * #IConvertible * int>,
                carpetAnchorId: string,
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
                ?UseDefaults: bool
            ) =

            let a, b, sizes = Seq.unzip3 absizes

            Chart.BubbleCarpet(
                a,
                b,
                sizes,
                carpetAnchorId,
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
                ?UseDefaults = UseDefaults

            )

