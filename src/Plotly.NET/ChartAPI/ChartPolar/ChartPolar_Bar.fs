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
module ChartPolar_Bar =

    [<Extension>]
    type Chart =
        /// <summary>
        /// Creates a polar bar chart.
        ///
        /// A polar bar chart is a chart that presents categorical data on a polar coordinate system with bars with radial height proportional to the values that they represent.
        /// </summary>
        /// <param name="r">Sets the radial height of the bars</param>
        /// <param name="theta">sets the angular position of the bars</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="MarkerColor">Sets the color of the bars</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the bars</param>
        /// <param name="MarkerOutline">Sets the color of the bar outline</param>
        /// <param name="MarkerPatternShape">Sets the pattern shape for all bars</param>
        /// <param name="MultiMarkerPatternShape">Sets individual pattern shapes for the bars</param>
        /// <param name="MarkerPattern">Sets the marker pattern (use this for more finegrained control than the other pattern-associated arguments).</param>
        /// <param name="Marker">Sets the marker for the bars (use this for more finegrained control than the other marker-associated arguments).</param>
        /// <param name="Base">Sets where the bar base is drawn (in position axis units).</param>
        /// <param name="Width">Sets the bar width (in position axis units) of all bars.</param>
        /// <param name="MultiWidth">Sets the individual bar width (in position axis units) for each bar.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member BarPolar
            (
                r: seq<#IConvertible>,
                theta: seq<#IConvertible>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerPatternShape: StyleParam.PatternShape,
                ?MultiMarkerPatternShape: seq<StyleParam.PatternShape>,
                ?MarkerPattern: Pattern,
                ?Marker: Marker,
                ?Base: #IConvertible,
                ?Width: #IConvertible,
                ?MultiWidth: seq<#IConvertible>,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

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

            TracePolar.initBarPolar (
                TracePolarStyle.BarPolar(
                    R = r,
                    Theta = theta,
                    Marker = marker,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?Base = Base,
                    ?Width = Width,
                    ?MultiWidth = MultiWidth
                )
            )
            |> GenericChart.ofTraceObject useDefaults

        /// <summary>
        /// Creates a polar bar chart.
        ///
        /// A polar bar chart is a chart that presents categorical data on a polar coordinate system with bars with radial height proportional to the values that they represent.
        /// </summary>
        /// <param name="rTheta">Sets the radial height and angular position of the bars</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="MarkerColor">Sets the color of the bars</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the bars</param>
        /// <param name="MarkerOutline">Sets the color of the bar outline</param>
        /// <param name="MarkerPatternShape">Sets the pattern shape for all bars</param>
        /// <param name="MultiMarkerPatternShape">Sets individual pattern shapes for the bars</param>
        /// <param name="MarkerPattern">Sets the marker pattern (use this for more finegrained control than the other pattern-associated arguments).</param>
        /// <param name="Marker">Sets the marker for the bars (use this for more finegrained control than the other marker-associated arguments).</param>
        /// <param name="Base">Sets where the bar base is drawn (in position axis units).</param>
        /// <param name="Width">Sets the bar width (in position axis units) of all bars.</param>
        /// <param name="MultiWidth">Sets the individual bar width (in position axis units) for each bar.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member BarPolar
            (
                rTheta: seq<#IConvertible * #IConvertible>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerPatternShape: StyleParam.PatternShape,
                ?MultiMarkerPatternShape: seq<StyleParam.PatternShape>,
                ?MarkerPattern: Pattern,
                ?Marker: Marker,
                ?Base: #IConvertible,
                ?Width: #IConvertible,
                ?MultiWidth: seq<#IConvertible>,
                ?UseDefaults: bool
            ) =

            let r, theta = Seq.unzip rTheta

            Chart.BarPolar(
                r,
                theta,
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
                ?UseDefaults = UseDefaults

            )

        /// <summary>
        /// Creates a polar bar chart from encoded radial and angular coordinates.
        ///
        /// A polar bar chart is a chart that presents categorical data on a polar coordinate system with bars with radial height proportional to the values that they represent.
        /// </summary>
        /// <param name="rEncoded">Sets the radial height of the bars as an encoded typed array.</param>
        /// <param name="thetaEncoded">Sets the angular position of the bars as an encoded typed array.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="MarkerColor">Sets the color of the bars</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the bars</param>
        /// <param name="MarkerOutline">Sets the color of the bar outline</param>
        /// <param name="MarkerPatternShape">Sets the pattern shape for all bars</param>
        /// <param name="MultiMarkerPatternShape">Sets individual pattern shapes for the bars</param>
        /// <param name="MarkerPattern">Sets the marker pattern (use this for more finegrained control than the other pattern-associated arguments).</param>
        /// <param name="Marker">Sets the marker for the bars (use this for more finegrained control than the other marker-associated arguments).</param>
        /// <param name="Base">Sets where the bar base is drawn (in position axis units).</param>
        /// <param name="Width">Sets the bar width (in position axis units) of all bars.</param>
        /// <param name="MultiWidthEncoded">Sets the individual bar width (in position axis units) for each bar as an encoded typed array.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member BarPolar
            (
                rEncoded: EncodedTypedArray,
                thetaEncoded: EncodedTypedArray,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerPatternShape: StyleParam.PatternShape,
                ?MultiMarkerPatternShape: seq<StyleParam.PatternShape>,
                ?MarkerPattern: Pattern,
                ?Marker: Marker,
                ?Base: #IConvertible,
                ?Width: #IConvertible,
                ?MultiWidthEncoded: EncodedTypedArray,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

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

            TracePolar.initBarPolar (
                TracePolarStyle.BarPolar(
                    REncoded = rEncoded,
                    ThetaEncoded = thetaEncoded,
                    Marker = marker,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?Base = Base,
                    ?Width = Width,
                    ?MultiWidthEncoded = MultiWidthEncoded
                )
            )
            |> GenericChart.ofTraceObject useDefaults
