namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects

open DynamicObj
open System
open System.IO
open System.Runtime.CompilerServices

open System.Runtime.InteropServices

[<AutoOpen>]
module Chart2D_Bar =
    [<Extension>]
    type Chart =
        [<Extension>]
        static member Bar
            (
                values: seq<#IConvertible>,
                ?Keys: seq<#IConvertible>,
                ?MultiKeys: seq<seq<#IConvertible>>,
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
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
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


            Trace2D.initBar (
                Trace2DStyle.Bar(
                    X = values,
                    ?Y = Keys,
                    ?MultiY = MultiKeys,
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

        /// <summary>
        /// Creates a bar chart with encoded values, plotted horizontally.
        ///
        /// A bar chart is a chart that presents categorical data with rectangular bars with heights or lengths proportional to the values that they represent.
        /// </summary>
        /// <param name="valuesEncoded">Sets the values that are plotted as the size of each bar as an encoded typed array.</param>
        /// <param name="KeysEncoded">Sets the keys associated with each bar as an encoded typed array.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity of the trace.</param>
        /// <param name="MultiOpacity">Sets the Opacity of each individual bar.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="MarkerColor">Sets the color of the bars</param>
        /// <param name="MarkerColorScale">Sets the colorscale for the bars. To have an effect, `MarkerColor` must map to color scale values.</param>
        /// <param name="MarkerOutline">Sets the color of the bar outlines</param>
        /// <param name="MarkerPatternShape">Sets a pattern shape for all bars</param>
        /// <param name="MultiMarkerPatternShape">Sets an individual pattern shape for each bar</param>
        /// <param name="MarkerPattern">Sets the marker pattern (use this for more finegrained control than the other pattern-associated arguments).</param>
        /// <param name="Marker">Sets the marker for the bars (use this for more finegrained control than the other marker-associated arguments).</param>
        /// <param name="Base">Sets where the bar base is drawn (in position axis units).</param>
        /// <param name="Width">Sets the bar width (in position axis units) of all bars.</param>
        /// <param name="MultiWidthEncoded">Sets the individual bar width for each bar as an encoded typed array.</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Bar
            (
                valuesEncoded: EncodedTypedArray,
                ?KeysEncoded: EncodedTypedArray,
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
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
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


            Trace2D.initBar (
                Trace2DStyle.Bar(
                    XEncoded = valuesEncoded,
                    ?YEncoded = KeysEncoded,
                    Orientation = StyleParam.Orientation.Horizontal,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?Base = Base,
                    ?Width = Width,
                    ?MultiWidthEncoded = MultiWidthEncoded,
                    ?TextPosition = TextPosition,
                    ?MultiTextPosition = MultiTextPosition,
                    Marker = marker
                )
            )
            |> GenericChart.ofTraceObject useDefaults

        /// <summary>
        /// Creates a bar chart, with bars plotted horizontally
        ///
        /// A bar chart is a chart that presents categorical data with rectangular bars with heights or lengths proportional to the values that they represent.
        /// </summary>
        /// <param name="keysValues">Sets the (key,value) pairs that are plotted as the size and key of each bar.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity of the trace.</param>
        /// <param name="MultiOpacity">Sets the Opacity of each individual bar.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="MarkerColor">Sets the color of the bars</param>
        /// <param name="MarkerColorScale">Sets the colorscale for the bars. To have an effect, `MarkerColor` must map to color scale values.</param>
        /// <param name="MarkerOutline">Sets the color of the bar outlines</param>
        /// <param name="MarkerPatternShape">Sets a pattern shape for all bars</param>
        /// <param name="MultiMarkerPatternShape">Sets an individual pattern shape for each bar</param>
        /// <param name="MarkerPattern">Sets the marker pattern (use this for more finegrained control than the other pattern-associated arguments).</param>
        /// <param name="Marker">Sets the marker for the bars (use this for more finegrained control than the other marker-associated arguments).</param>
        /// <param name="Base">Sets where the bar base is drawn (in position axis units).</param>
        /// <param name="Width">Sets the bar width (in position axis units) of all bars.</param>
        /// <param name="MultiWidth">Sets the individual bar width (in position axis units) for each bar.</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Bar
            (
                keysValues: seq<#IConvertible * #IConvertible>,
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
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?UseDefaults: bool
            ) =

            let keys, values = Seq.unzip keysValues

            Chart.Bar(
                values = values,
                Keys = keys,
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


        /// <summary>
        /// Creates a stacked bar chart, with bars plotted horizontally. Values with the same key are stacked on top of each other in the X dimension.
        /// To create this type of chart, combine multiple of these charts via `Chart.combine`.
        ///
        /// A bar chart is a chart that presents categorical data with rectangular bars with heights or lengths proportional to the values that they represent.
        /// </summary>
        /// <param name="values">Sets the values that are plotted as the size of each bar.</param>
        /// <param name="Keys">Sets the keys associated with each bar.</param>
        /// <param name="MultiKeys">Sets the keys associated with each bar. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity of the trace.</param>
        /// <param name="MultiOpacity">Sets the Opacity of each individual bar.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="MarkerColor">Sets the color of the bars</param>
        /// <param name="MarkerColorScale">Sets the colorscale for the bars. To have an effect, `MarkerColor` must map to color scale values.</param>
        /// <param name="MarkerOutline">Sets the color of the bar outlines</param>
        /// <param name="MarkerPatternShape">Sets a pattern shape for all bars</param>
        /// <param name="MultiMarkerPatternShape">Sets an individual pattern shape for each bar</param>
        /// <param name="MarkerPattern">Sets the marker pattern (use this for more finegrained control than the other pattern-associated arguments).</param>
        /// <param name="Marker">Sets the marker for the bars (use this for more finegrained control than the other marker-associated arguments).</param>
        /// <param name="Base">Sets where the bar base is drawn (in position axis units).</param>
        /// <param name="Width">Sets the bar width (in position axis units) of all bars.</param>
        /// <param name="MultiWidth">Sets the individual bar width (in position axis units) for each bar.</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member StackedBar
            (
                values: seq<#IConvertible>,
                ?Keys: seq<#IConvertible>,
                ?MultiKeys: seq<seq<#IConvertible>>,
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
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?UseDefaults: bool
            ) =

            Chart.Bar(
                values = values,
                ?Keys = Keys,
                ?MultiKeys = MultiKeys,
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

        /// <summary>
        /// Creates a stacked bar chart from encoded values, with bars plotted horizontally.
        /// </summary>
        [<Extension>]
        static member StackedBar
            (
                valuesEncoded: EncodedTypedArray,
                ?KeysEncoded: EncodedTypedArray,
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
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?UseDefaults: bool
            ) =

            Chart.Bar(
                valuesEncoded = valuesEncoded,
                ?KeysEncoded = KeysEncoded,
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
                ?MultiWidthEncoded = MultiWidthEncoded,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?UseDefaults = UseDefaults
            )
            |> GenericChart.mapLayout (Layout.style (BarMode = StyleParam.BarMode.Stack))


        /// <summary>
        /// Creates a stacked bar chart, with bars plotted horizontally. Values with the same key are stacked on top of each other in the X dimension.
        /// To create this type of chart, combine multiple of these charts via `Chart.combine`.
        ///
        /// A bar chart is a chart that presents categorical data with rectangular bars with heights or lengths proportional to the values that they represent.
        /// </summary>
        /// <param name="keysValues">Sets the (key,value) pairs that are plotted as the size and key of each bar.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity of the trace.</param>
        /// <param name="MultiOpacity">Sets the Opacity of each individual bar.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="MarkerColor">Sets the color of the bars</param>
        /// <param name="MarkerColorScale">Sets the colorscale for the bars. To have an effect, `MarkerColor` must map to color scale values.</param>
        /// <param name="MarkerOutline">Sets the color of the bar outlines</param>
        /// <param name="MarkerPatternShape">Sets a pattern shape for all bars</param>
        /// <param name="MultiMarkerPatternShape">Sets an individual pattern shape for each bar</param>
        /// <param name="MarkerPattern">Sets the marker pattern (use this for more finegrained control than the other pattern-associated arguments).</param>
        /// <param name="Marker">Sets the marker for the bars (use this for more finegrained control than the other marker-associated arguments).</param>
        /// <param name="Base">Sets where the bar base is drawn (in position axis units).</param>
        /// <param name="Width">Sets the bar width (in position axis units) of all bars.</param>
        /// <param name="MultiWidth">Sets the individual bar width (in position axis units) for each bar.</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member StackedBar
            (
                keysValues: seq<#IConvertible * #IConvertible>,
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
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?UseDefaults: bool
            ) =

            let keys, values = Seq.unzip keysValues

            Chart.StackedBar(
                values = values,
                Keys = keys,
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

        /// <summary>
        /// Creates a column chart, with bars plotted vertically
        ///
        /// A column chart is a chart that presents categorical data with rectangular bars with heights or lengths proportional to the values that they represent.
        /// </summary>
        /// <param name="values">Sets the values that are plotted as the size of each bar.</param>
        /// <param name="Keys">Sets the keys associated with each bar.</param>
        /// <param name="MultiKeys">Sets the keys associated with each bar. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity of the trace.</param>
        /// <param name="MultiOpacity">Sets the Opacity of each individual bar.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="MarkerColor">Sets the color of the bars</param>
        /// <param name="MarkerColorScale">Sets the colorscale for the bars. To have an effect, `MarkerColor` must map to color scale values.</param>
        /// <param name="MarkerOutline">Sets the color of the bar outlines</param>
        /// <param name="MarkerPatternShape">Sets a pattern shape for all bars</param>
        /// <param name="MultiMarkerPatternShape">Sets an individual pattern shape for each bar</param>
        /// <param name="MarkerPattern">Sets the marker pattern (use this for more finegrained control than the other pattern-associated arguments).</param>
        /// <param name="Marker">Sets the marker for the bars (use this for more finegrained control than the other marker-associated arguments).</param>
        /// <param name="Base">Sets where the bar base is drawn (in position axis units).</param>
        /// <param name="Width">Sets the bar width (in position axis units) of all bars.</param>
        /// <param name="MultiWidth">Sets the individual bar width (in position axis units) for each bar.</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Column
            (
                values: seq<#IConvertible>,
                ?Keys: seq<#IConvertible>,
                ?MultiKeys: seq<seq<#IConvertible>>,
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
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
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


            Trace2D.initBar (
                Trace2DStyle.Bar(
                    Y = values,
                    ?X = Keys,
                    ?MultiX = MultiKeys,
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

        /// <summary>
        /// Creates a column chart from encoded values, with bars plotted vertically.
        /// </summary>
        [<Extension>]
        static member Column
            (
                valuesEncoded: EncodedTypedArray,
                ?KeysEncoded: EncodedTypedArray,
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
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
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


            Trace2D.initBar (
                Trace2DStyle.Bar(
                    YEncoded = valuesEncoded,
                    ?XEncoded = KeysEncoded,
                    Orientation = StyleParam.Orientation.Vertical,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?Base = Base,
                    ?Width = Width,
                    ?MultiWidthEncoded = MultiWidthEncoded,
                    ?TextPosition = TextPosition,
                    ?MultiTextPosition = MultiTextPosition,
                    Marker = marker
                )
            )
            |> GenericChart.ofTraceObject useDefaults


        /// <summary>
        /// Creates a column chart, with bars plotted vertically
        ///
        /// A column chart is a chart that presents categorical data with rectangular bars with heights or lengths proportional to the values that they represent.
        /// </summary>
        /// <param name="keysValues">Sets the (key,value) pairs that are plotted as the size and key of each bar.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity of the trace.</param>
        /// <param name="MultiOpacity">Sets the Opacity of each individual bar.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="MarkerColor">Sets the color of the bars</param>
        /// <param name="MarkerColorScale">Sets the colorscale for the bars. To have an effect, `MarkerColor` must map to color scale values.</param>
        /// <param name="MarkerOutline">Sets the color of the bar outlines</param>
        /// <param name="MarkerPatternShape">Sets a pattern shape for all bars</param>
        /// <param name="MultiMarkerPatternShape">Sets an individual pattern shape for each bar</param>
        /// <param name="MarkerPattern">Sets the marker pattern (use this for more finegrained control than the other pattern-associated arguments).</param>
        /// <param name="Marker">Sets the marker for the bars (use this for more finegrained control than the other marker-associated arguments).</param>
        /// <param name="Base">Sets where the bar base is drawn (in position axis units).</param>
        /// <param name="Width">Sets the bar width (in position axis units) of all bars.</param>
        /// <param name="MultiWidth">Sets the individual bar width (in position axis units) for each bar.</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Column
            (
                keysValues: seq<#IConvertible * #IConvertible>,
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
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?UseDefaults: bool
            ) =

            let keys, values = Seq.unzip keysValues

            Chart.Column(
                values = values,
                Keys = keys,
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


        /// <summary>
        /// Creates a stacked column chart, with bars plotted vertically. Values with the same key are stacked on top of each other in the Y dimension.
        /// To create this type of chart, combine multiple of these charts via `Chart.combine`.
        ///
        /// A bar chart is a chart that presents categorical data with rectangular bars with heights or lengths proportional to the values that they represent.
        /// </summary>
        /// <param name="values">Sets the values that are plotted as the size of each bar.</param>
        /// <param name="Keys">Sets the keys associated with each bar.</param>
        /// <param name="MultiKeys">Sets the keys associated with each bar. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity of the trace.</param>
        /// <param name="MultiOpacity">Sets the Opacity of each individual bar.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="MarkerColor">Sets the color of the bars</param>
        /// <param name="MarkerColorScale">Sets the colorscale for the bars. To have an effect, `MarkerColor` must map to color scale values.</param>
        /// <param name="MarkerOutline">Sets the color of the bar outlines</param>
        /// <param name="MarkerPatternShape">Sets a pattern shape for all bars</param>
        /// <param name="MultiMarkerPatternShape">Sets an individual pattern shape for each bar</param>
        /// <param name="MarkerPattern">Sets the marker pattern (use this for more finegrained control than the other pattern-associated arguments).</param>
        /// <param name="Marker">Sets the marker for the bars (use this for more finegrained control than the other marker-associated arguments).</param>
        /// <param name="Base">Sets where the bar base is drawn (in position axis units).</param>
        /// <param name="Width">Sets the bar width (in position axis units) of all bars.</param>
        /// <param name="MultiWidth">Sets the individual bar width (in position axis units) for each bar.</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member StackedColumn
            (
                values: seq<#IConvertible>,
                ?Keys: seq<#IConvertible>,
                ?MultiKeys: seq<seq<#IConvertible>>,
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
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?UseDefaults: bool
            ) =

            Chart.Column(
                values = values,
                ?Keys = Keys,
                ?MultiKeys = MultiKeys,
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

        /// <summary>
        /// Creates a stacked column chart from encoded values, with bars plotted vertically.
        /// </summary>
        [<Extension>]
        static member StackedColumn
            (
                valuesEncoded: EncodedTypedArray,
                ?KeysEncoded: EncodedTypedArray,
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
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?UseDefaults: bool
            ) =

            Chart.Column(
                valuesEncoded = valuesEncoded,
                ?KeysEncoded = KeysEncoded,
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
                ?MultiWidthEncoded = MultiWidthEncoded,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?UseDefaults = UseDefaults
            )
            |> GenericChart.mapLayout (Layout.style (BarMode = StyleParam.BarMode.Stack))


        /// <summary>
        /// Creates a stacked column chart, with bars plotted vertically. Values with the same key are stacked on top of each other in the Y dimension.
        /// To create this type of chart, combine multiple of these charts via `Chart.combine`.
        ///
        /// A bar chart is a chart that presents categorical data with rectangular bars with heights or lengths proportional to the values that they represent.
        /// </summary>
        /// <param name="keysValues">Sets the (key,value) pairs that are plotted as the size and key of each bar.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity of the trace.</param>
        /// <param name="MultiOpacity">Sets the Opacity of each individual bar.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="MarkerColor">Sets the color of the bars</param>
        /// <param name="MarkerColorScale">Sets the colorscale for the bars. To have an effect, `MarkerColor` must map to color scale values.</param>
        /// <param name="MarkerOutline">Sets the color of the bar outlines</param>
        /// <param name="MarkerPatternShape">Sets a pattern shape for all bars</param>
        /// <param name="MultiMarkerPatternShape">Sets an individual pattern shape for each bar</param>
        /// <param name="MarkerPattern">Sets the marker pattern (use this for more finegrained control than the other pattern-associated arguments).</param>
        /// <param name="Marker">Sets the marker for the bars (use this for more finegrained control than the other marker-associated arguments).</param>
        /// <param name="Base">Sets where the bar base is drawn (in position axis units).</param>
        /// <param name="Width">Sets the bar width (in position axis units) of all bars.</param>
        /// <param name="MultiWidth">Sets the individual bar width (in position axis units) for each bar.</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member StackedColumn
            (
                keysValues: seq<#IConvertible * #IConvertible>,
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
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?UseDefaults: bool
            ) =

            let keys, values = Seq.unzip keysValues

            Chart.StackedColumn(
                values = values,
                Keys = keys,
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

