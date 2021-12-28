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
module ChartTernary =

    [<Extension>]
    type Chart =

        static member ScatterTernary
            (
                [<Optional; DefaultParameterValue(null)>] ?A: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?B: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?C: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Sum: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?Mode: StyleParam.Mode,
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

            TraceTernary.initScatterTernary (
                TraceTernaryStyle.ScatterTernary(
                    Marker = marker,
                    Line = line,
                    ?A = A,
                    ?B = B,
                    ?C = C,
                    ?Mode = Mode,
                    ?Sum = Sum,
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

        static member ScatterTernary
            (
                abc,
                [<Optional; DefaultParameterValue(null)>] ?Mode: StyleParam.Mode,
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

            let a, b, c = Seq.unzip3 abc

            Chart.ScatterTernary(
                A = a,
                B = b,
                C = c,
                ?Mode = Mode,
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

        static member PointTernary
            (
                [<Optional; DefaultParameterValue(null)>] ?A: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?B: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?C: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Sum: #IConvertible,
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

            let changeMode =
                StyleParam.ModeUtils.showText (TextPosition.IsSome || MultiTextPosition.IsSome)

            Chart.ScatterTernary(
                ?A = A,
                ?B = B,
                ?C = C,
                Mode = changeMode StyleParam.Mode.Markers,
                ?Sum = Sum,
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

        static member PointTernary
            (
                abc: seq<#IConvertible * #IConvertible * #IConvertible>,
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

            let a, b, c = Seq.unzip3 abc

            Chart.PointTernary(
                A = a,
                B = b,
                C = c,
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

        static member LineTernary
            (
                [<Optional; DefaultParameterValue(null)>] ?A: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?B: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?C: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Sum: #IConvertible,
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

            Chart.ScatterTernary(
                ?A = A,
                ?B = B,
                ?C = C,
                ?Sum = Sum,
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
                ?UseDefaults = UseDefaults
            )


        static member LineTernary
            (
                abc,
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

            let a, b, c = Seq.unzip3 abc

            Chart.LineTernary(
                A = a,
                B = b,
                C = c,
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
