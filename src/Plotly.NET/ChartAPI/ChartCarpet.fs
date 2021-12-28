namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects

open DynamicObj
open DynamicObj.Operators
open System
open System.IO

open GenericChart
open StyleParam
open System.Runtime.InteropServices
open System.Runtime.CompilerServices

[<AutoOpen>]
module ChartCarpet =

    [<Extension>]
    type Chart =

        /// Shows how proportions of data, shown as pie-shaped pieces, contribute to the data.
        [<Extension>]
        static member Carpet
            (
                carpetId: string,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?X: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?MultiX: seq<#seq<#IConvertible>>,
                [<Optional; DefaultParameterValue(null)>] ?Y: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?MultiY: seq<#seq<#IConvertible>>,
                [<Optional; DefaultParameterValue(null)>] ?A: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?B: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?AAxis: LinearAxis,
                [<Optional; DefaultParameterValue(null)>] ?BAxis: LinearAxis,
                [<Optional; DefaultParameterValue(null)>] ?XAxis: StyleParam.LinearAxisId,
                [<Optional; DefaultParameterValue(null)>] ?YAxis: StyleParam.LinearAxisId,
                [<Optional; DefaultParameterValue(null)>] ?Color: Color,
                [<Optional; DefaultParameterValue(null)>] ?CheaterSlope: float,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            let useDefaults = defaultArg UseDefaults true

            TraceCarpet.initCarpet (
                TraceCarpetStyle.Carpet(
                    Carpet = StyleParam.SubPlotId.Carpet carpetId,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?X = X,
                    ?MultiX = MultiX,
                    ?Y = Y,
                    ?MultiY = MultiY,
                    ?A = A,
                    ?B = B,
                    ?AAxis = AAxis,
                    ?BAxis = BAxis,
                    ?XAxis = XAxis,
                    ?YAxis = YAxis,
                    ?Color = Color,
                    ?CheaterSlope = CheaterSlope
                )
            )
            |> GenericChart.ofTraceObject useDefaults

        [<Extension>]
        static member ScatterCarpet
            (
                a: seq<#IConvertible>,
                b: seq<#IConvertible>,
                mode: StyleParam.Mode,
                carpetAnchorId: string,
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

        [<Extension>]
        static member ScatterCarpet
            (
                ab: seq<#IConvertible * #IConvertible>,
                mode: StyleParam.Mode,
                carpetAnchorId: string,
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
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
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


        [<Extension>]
        static member PointCarpet
            (
                a: seq<#IConvertible>,
                b: seq<#IConvertible>,
                carpetAnchorId: string,
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
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            let useDefaults = defaultArg UseDefaults true

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

        [<Extension>]
        static member PointCarpet
            (
                ab: seq<#IConvertible * #IConvertible>,
                carpetAnchorId: string,
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
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
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

        [<Extension>]
        static member LineCarpet
            (
                a: seq<#IConvertible>,
                b: seq<#IConvertible>,
                carpetAnchorId: string,
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
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
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


        [<Extension>]
        static member LineCarpet
            (
                ab: seq<#IConvertible * #IConvertible>,
                carpetAnchorId: string,
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
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
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

        [<Extension>]
        static member SplineCarpet
            (
                a: seq<#IConvertible>,
                b: seq<#IConvertible>,
                carpetAnchorId: string,
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
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            let useDefaults = defaultArg UseDefaults true

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



        [<Extension>]
        static member SplineCarpet
            (
                ab: seq<#IConvertible * #IConvertible>,
                carpetAnchorId: string,
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
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
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

        static member BubbleCarpet
            (
                a: seq<#IConvertible>,
                b: seq<#IConvertible>,
                sizes: seq<int>,
                carpetAnchorId: string,
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
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            let useDefaults = defaultArg UseDefaults true

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

        static member BubbleCarpet
            (
                absizes: seq<#IConvertible * #IConvertible * int>,
                carpetAnchorId: string,
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
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
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

        static member ContourCarpet
            (
                carpetAnchorId: string,
                z: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?A: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?B: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Dash: StyleParam.DrawingStyle,
                [<Optional; DefaultParameterValue(null)>] ?Width: float,
                [<Optional; DefaultParameterValue(null)>] ?LineColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?Line: Line,
                [<Optional; DefaultParameterValue(null)>] ?ColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?ShowScale: bool,
                [<Optional; DefaultParameterValue(null)>] ?Contours: Contours,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            let useDefaults = defaultArg UseDefaults true

            TraceCarpet.initContourCarpet (
                TraceCarpetStyle.ContourCarpet(
                    Carpet = StyleParam.SubPlotId.Carpet carpetAnchorId,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    Z = z,
                    ?A = A,
                    ?B = B,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?Line = Line,
                    ?ColorScale = ColorScale,
                    ?ShowScale = ShowScale,
                    ?Contours = Contours
                )
                >> TraceStyle.Line(?Dash = Dash, ?Width = Width, ?Color = LineColor)
            )
            |> GenericChart.ofTraceObject useDefaults


        static member ContourCarpet
            (
                carpetAnchorId: string,
                abz: seq<#IConvertible * #IConvertible * #IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
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

            let a, b, z = Seq.unzip3 abz

            TraceCarpet.initContourCarpet (
                TraceCarpetStyle.ContourCarpet(
                    A = a,
                    B = b,
                    Z = z,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?ColorBar = ColorBar,
                    ?ColorScale = ColorScale,
                    ?ShowScale = ShowScale,
                    ?ReverseScale = ReverseScale,
                    ?Transpose = Transpose,
                    Contours = contours,
                    Line = line
                )
            )
