namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects

open DynamicObj
open System
open System.IO
open System.Runtime.CompilerServices

open System.Runtime.InteropServices

[<AutoOpen>]
module Chart2D_Finance =
    [<Extension>]
    type Chart =
        /// <summary>
        /// Creates an OHLC chart.
        ///
        /// The ohlc (short for Open-High-Low-Close) is a style of financial chart describing open, high, low and close for a given `x` coordinate (most likely time). The tip of the lines represent the `low` and `high` values and the horizontal segments represent the `open` and `close` values. Sample points where the close value is higher (lower) then the open value are called increasing (decreasing). By default, increasing items are drawn in green whereas decreasing are drawn in red.
        /// </summary>
        /// <param name="open">Sets the open values.</param>
        /// <param name="high">Sets the high values.</param>
        /// <param name="low">Sets the low values.</param>
        /// <param name="close">Sets the close values.</param>
        /// <param name="X">Sets the x coordinates. If absent, linear coordinate will be generated.</param>
        /// <param name="MultiX">Sets the x coordinates. If absent, linear coordinate will be generated. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity otf the trace.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="Line">Sets the line of this trace.</param>
        /// <param name="IncreasingColor">Sets the color of increasing values</param>
        /// <param name="Increasing">Sets the style options of increasing values (use this for more finegrained control than the other increasing-associated arguments).</param>
        /// <param name="DecreasingColor">Sets the color of decreasing values</param>
        /// <param name="Decreasing">Sets the style options of decreasing values (use this for more finegrained control than the other increasing-associated arguments).</param>
        /// <param name="TickWidth">Sets the width of the open/close tick marks relative to the "x" minimal interval.</param>
        /// <param name="ShowXAxisRangeSlider">Whether or not to show a rangeslider for the xaxis</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member OHLC
            (
                ``open``: #IConvertible seq,
                high: #IConvertible seq,
                low: #IConvertible seq,
                close: #IConvertible seq,
                ?X: seq<#IConvertible>,
                ?MultiX: seq<seq<#IConvertible>>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?Line: Line,
                ?IncreasingColor: Color,
                ?Increasing: FinanceMarker,
                ?DecreasingColor: Color,
                ?Decreasing: FinanceMarker,
                ?TickWidth: float,
                ?ShowXAxisRangeSlider: bool,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

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
                    ?X = X,
                    ?MultiX = MultiX,
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
            |> GenericChart.addLayout (
                Layout.init ()
                |> Layout.setLinearAxis (
                    id = StyleParam.SubPlotId.XAxis 1,
                    axis = LinearAxis.init (RangeSlider = RangeSlider.init (?Visible = ShowXAxisRangeSlider))
                )
            )

        /// <summary>
        /// Creates an OHLC chart.
        ///
        /// The ohlc (short for Open-High-Low-Close) is a style of financial chart describing open, high, low and close for a given `x` coordinate (most likely time). The tip of the lines represent the `low` and `high` values and the horizontal segments represent the `open` and `close` values. Sample points where the close value is higher (lower) then the open value are called increasing (decreasing). By default, increasing items are drawn in green whereas decreasing are drawn in red.
        /// </summary>
        /// <param name="open">Sets the open values.</param>
        /// <param name="high">Sets the high values.</param>
        /// <param name="low">Sets the low values.</param>
        /// <param name="close">Sets the close values.</param>
        /// <param name="x">Sets the x coordinates. If absent, linear coordinate will be generated.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity otf the trace.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="Line">Sets the line of this trace.</param>
        /// <param name="IncreasingColor">Sets the color of increasing values</param>
        /// <param name="Increasing">Sets the style options of increasing values (use this for more finegrained control than the other increasing-associated arguments).</param>
        /// <param name="DecreasingColor">Sets the color of decreasing values</param>
        /// <param name="Decreasing">Sets the style options of decreasing values (use this for more finegrained control than the other increasing-associated arguments).</param>
        /// <param name="TickWidth">Sets the width of the open/close tick marks relative to the "x" minimal interval.</param>
        /// <param name="ShowXAxisRangeSlider">Whether or not to show a rangeslider for the xaxis</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member OHLC
            (
                ``open``: #IConvertible seq,
                high: #IConvertible seq,
                low: #IConvertible seq,
                close: #IConvertible seq,
                x: #IConvertible seq,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?Line: Line,
                ?IncreasingColor: Color,
                ?Increasing: FinanceMarker,
                ?DecreasingColor: Color,
                ?Decreasing: FinanceMarker,
                ?TickWidth: float,
                ?ShowXAxisRangeSlider: bool,
                ?UseDefaults: bool
            ) =

            Chart.OHLC(
                ``open`` = ``open``,
                high = high,
                low = low,
                close = close,
                X = x,
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
                ?ShowXAxisRangeSlider = ShowXAxisRangeSlider,
                ?UseDefaults = UseDefaults
            )

        /// <summary>
        /// Creates an OHLC chart from encoded financial arrays.
        /// </summary>
        /// <param name="openEncoded">Sets the open values as an encoded typed array.</param>
        /// <param name="highEncoded">Sets the high values as an encoded typed array.</param>
        /// <param name="lowEncoded">Sets the low values as an encoded typed array.</param>
        /// <param name="closeEncoded">Sets the close values as an encoded typed array.</param>
        /// <param name="xEncoded">Sets the x coordinates as an encoded typed array. If absent, linear coordinates will be generated.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity of the trace.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="Line">Sets the line of this trace.</param>
        /// <param name="IncreasingColor">Sets the color of increasing values</param>
        /// <param name="Increasing">Sets the style options of increasing values.</param>
        /// <param name="DecreasingColor">Sets the color of decreasing values</param>
        /// <param name="Decreasing">Sets the style options of decreasing values.</param>
        /// <param name="TickWidth">Sets the width of the open/close tick marks.</param>
        /// <param name="ShowXAxisRangeSlider">Whether or not to show a rangeslider for the xaxis</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member OHLC
            (
                openEncoded: EncodedTypedArray,
                highEncoded: EncodedTypedArray,
                lowEncoded: EncodedTypedArray,
                closeEncoded: EncodedTypedArray,
                ?xEncoded: EncodedTypedArray,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?Line: Line,
                ?IncreasingColor: Color,
                ?Increasing: FinanceMarker,
                ?DecreasingColor: Color,
                ?Decreasing: FinanceMarker,
                ?TickWidth: float,
                ?ShowXAxisRangeSlider: bool,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

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
                    OpenEncoded = openEncoded,
                    HighEncoded = highEncoded,
                    LowEncoded = lowEncoded,
                    CloseEncoded = closeEncoded,
                    ?XEncoded = xEncoded,
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
            |> GenericChart.addLayout (
                Layout.init ()
                |> Layout.setLinearAxis (
                    id = StyleParam.SubPlotId.XAxis 1,
                    axis = LinearAxis.init (RangeSlider = RangeSlider.init (?Visible = ShowXAxisRangeSlider))
                )
            )

        /// <summary>
        /// Creates an OHLC chart.
        ///
        /// The ohlc (short for Open-High-Low-Close) is a style of financial chart describing open, high, low and close for a given `x` coordinate (most likely time). The tip of the lines represent the `low` and `high` values and the horizontal segments represent the `open` and `close` values. Sample points where the close value is higher (lower) then the open value are called increasing (decreasing). By default, increasing items are drawn in green whereas decreasing are drawn in red.
        /// </summary>
        /// <param name="stockTimeSeries">a series of (time,StockData), where StockData contains opwn, high, low and close values.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity otf the trace.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="Line">Sets the line of this trace.</param>
        /// <param name="IncreasingColor">Sets the color of increasing values</param>
        /// <param name="Increasing">Sets the style options of increasing values (use this for more finegrained control than the other increasing-associated arguments).</param>
        /// <param name="DecreasingColor">Sets the color of decreasing values</param>
        /// <param name="Decreasing">Sets the style options of decreasing values (use this for more finegrained control than the other increasing-associated arguments).</param>
        /// <param name="TickWidth">Sets the width of the open/close tick marks relative to the "x" minimal interval.</param>
        /// <param name="ShowXAxisRangeSlider">Whether or not to show a rangeslider for the xaxis</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member OHLC
            (
                stockTimeSeries: seq<System.DateTime * StockData>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?Line: Line,
                ?IncreasingColor: Color,
                ?Increasing: FinanceMarker,
                ?DecreasingColor: Color,
                ?Decreasing: FinanceMarker,
                ?TickWidth: float,
                ?ShowXAxisRangeSlider: bool,
                ?UseDefaults: bool
            ) =

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
                ?ShowXAxisRangeSlider = ShowXAxisRangeSlider,
                ?UseDefaults = UseDefaults
            )



        /// <summary>
        /// Creates a candlestick chart.
        ///
        /// The candlestick is a style of financial chart describing open, high, low and close for a given `x` coordinate (most likely time). The boxes represent the spread between the `open` and `close` values and the lines represent the spread between the `low` and `high` values Sample points where the close value is higher (lower) then the open value are called increasing (decreasing). By default, increasing candles are drawn in green whereas decreasing are drawn in red.
        /// </summary>
        /// <param name="open">Sets the open values.</param>
        /// <param name="high">Sets the high values.</param>
        /// <param name="low">Sets the low values.</param>
        /// <param name="close">Sets the close values.</param>
        /// <param name="X">Sets the x coordinates. If absent, linear coordinate will be generated.</param>
        /// <param name="MultiX">Sets the x coordinates. If absent, linear coordinate will be generated. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity otf the trace.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="Line">Sets the line of this trace.</param>
        /// <param name="IncreasingColor">Sets the color of increasing values</param>
        /// <param name="Increasing">Sets the style options of increasing values (use this for more finegrained control than the other increasing-associated arguments).</param>
        /// <param name="DecreasingColor">Sets the color of decreasing values</param>
        /// <param name="Decreasing">Sets the style options of decreasing values (use this for more finegrained control than the other increasing-associated arguments).</param>
        /// <param name="WhiskerWidth">Sets the width of the whiskers relative to the box' width. For example, with 1, the whiskers are as wide as the box(es).</param>
        /// <param name="ShowXAxisRangeSlider">Whether or not to show a rangeslider for the xaxis</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        static member Candlestick
            (
                ``open``: #IConvertible seq,
                high: #IConvertible seq,
                low: #IConvertible seq,
                close: #IConvertible seq,
                ?X: seq<#IConvertible>,
                ?MultiX: seq<seq<#IConvertible>>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?Line: Line,
                ?IncreasingColor: Color,
                ?Increasing: FinanceMarker,
                ?DecreasingColor: Color,
                ?Decreasing: FinanceMarker,
                ?WhiskerWidth: float,
                ?ShowXAxisRangeSlider: bool,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

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
                    ?X = X,
                    ?MultiX = MultiX,
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
            |> GenericChart.addLayout (
                Layout.init ()
                |> Layout.setLinearAxis (
                    id = StyleParam.SubPlotId.XAxis 1,
                    axis = LinearAxis.init (RangeSlider = RangeSlider.init (?Visible = ShowXAxisRangeSlider))
                )
            )

        /// <summary>
        /// Creates a candlestick chart.
        ///
        /// The candlestick is a style of financial chart describing open, high, low and close for a given `x` coordinate (most likely time). The boxes represent the spread between the `open` and `close` values and the lines represent the spread between the `low` and `high` values Sample points where the close value is higher (lower) then the open value are called increasing (decreasing). By default, increasing candles are drawn in green whereas decreasing are drawn in red.
        /// </summary>
        /// <param name="open">Sets the open values.</param>
        /// <param name="high">Sets the high values.</param>
        /// <param name="low">Sets the low values.</param>
        /// <param name="close">Sets the close values.</param>
        /// <param name="x">Sets the x coordinates. If absent, linear coordinate will be generated.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity otf the trace.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="Line">Sets the line of this trace.</param>
        /// <param name="IncreasingColor">Sets the color of increasing values</param>
        /// <param name="Increasing">Sets the style options of increasing values (use this for more finegrained control than the other increasing-associated arguments).</param>
        /// <param name="DecreasingColor">Sets the color of decreasing values</param>
        /// <param name="Decreasing">Sets the style options of decreasing values (use this for more finegrained control than the other increasing-associated arguments).</param>
        /// <param name="WhiskerWidth">Sets the width of the whiskers relative to the box' width. For example, with 1, the whiskers are as wide as the box(es).</param>
        /// <param name="ShowXAxisRangeSlider">Whether or not to show a rangeslider for the xaxis</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Candlestick
            (
                ``open``: #IConvertible seq,
                high: #IConvertible seq,
                low: #IConvertible seq,
                close: #IConvertible seq,
                x: #IConvertible seq,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?Line: Line,
                ?IncreasingColor: Color,
                ?Increasing: FinanceMarker,
                ?DecreasingColor: Color,
                ?Decreasing: FinanceMarker,
                ?WhiskerWidth: float,
                ?ShowXAxisRangeSlider: bool,
                ?UseDefaults: bool
            ) =

            Chart.Candlestick(
                ``open`` = ``open``,
                high = high,
                low = low,
                close = close,
                X = x,
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
                ?ShowXAxisRangeSlider = ShowXAxisRangeSlider,
                ?UseDefaults = UseDefaults
            )

        /// <summary>
        /// Creates a candlestick chart from encoded financial arrays.
        /// </summary>
        /// <param name="openEncoded">Sets the open values as an encoded typed array.</param>
        /// <param name="highEncoded">Sets the high values as an encoded typed array.</param>
        /// <param name="lowEncoded">Sets the low values as an encoded typed array.</param>
        /// <param name="closeEncoded">Sets the close values as an encoded typed array.</param>
        /// <param name="xEncoded">Sets the x coordinates as an encoded typed array. If absent, linear coordinates will be generated.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity of the trace.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="Line">Sets the line of this trace.</param>
        /// <param name="IncreasingColor">Sets the color of increasing values</param>
        /// <param name="Increasing">Sets the style options of increasing values.</param>
        /// <param name="DecreasingColor">Sets the color of decreasing values</param>
        /// <param name="Decreasing">Sets the style options of decreasing values.</param>
        /// <param name="WhiskerWidth">Sets the width of the whiskers relative to the box' width.</param>
        /// <param name="ShowXAxisRangeSlider">Whether or not to show a rangeslider for the xaxis</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Candlestick
            (
                openEncoded: EncodedTypedArray,
                highEncoded: EncodedTypedArray,
                lowEncoded: EncodedTypedArray,
                closeEncoded: EncodedTypedArray,
                ?xEncoded: EncodedTypedArray,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?Line: Line,
                ?IncreasingColor: Color,
                ?Increasing: FinanceMarker,
                ?DecreasingColor: Color,
                ?Decreasing: FinanceMarker,
                ?WhiskerWidth: float,
                ?ShowXAxisRangeSlider: bool,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

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
                    OpenEncoded = openEncoded,
                    HighEncoded = highEncoded,
                    LowEncoded = lowEncoded,
                    CloseEncoded = closeEncoded,
                    ?XEncoded = xEncoded,
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
            |> GenericChart.addLayout (
                Layout.init ()
                |> Layout.setLinearAxis (
                    id = StyleParam.SubPlotId.XAxis 1,
                    axis = LinearAxis.init (RangeSlider = RangeSlider.init (?Visible = ShowXAxisRangeSlider))
                )
            )

        /// <summary>
        /// Creates a candlestick chart.
        ///
        /// The candlestick is a style of financial chart describing open, high, low and close for a given `x` coordinate (most likely time). The boxes represent the spread between the `open` and `close` values and the lines represent the spread between the `low` and `high` values Sample points where the close value is higher (lower) then the open value are called increasing (decreasing). By default, increasing candles are drawn in green whereas decreasing are drawn in red.
        /// </summary>
        /// <param name="stockTimeSeries">a series of (time,StockData), where StockData contains opwn, high, low and close values.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity otf the trace.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="Line">Sets the line of this trace.</param>
        /// <param name="IncreasingColor">Sets the color of increasing values</param>
        /// <param name="Increasing">Sets the style options of increasing values (use this for more finegrained control than the other increasing-associated arguments).</param>
        /// <param name="DecreasingColor">Sets the color of decreasing values</param>
        /// <param name="Decreasing">Sets the style options of decreasing values (use this for more finegrained control than the other increasing-associated arguments).</param>
        /// <param name="WhiskerWidth">Sets the width of the whiskers relative to the box' width. For example, with 1, the whiskers are as wide as the box(es).</param>
        /// <param name="ShowXAxisRangeSlider">Whether or not to show a rangeslider for the xaxis</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Candlestick
            (
                stockTimeSeries: seq<System.DateTime * StockData>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?Line: Line,
                ?IncreasingColor: Color,
                ?Increasing: FinanceMarker,
                ?DecreasingColor: Color,
                ?Decreasing: FinanceMarker,
                ?WhiskerWidth: float,
                ?ShowXAxisRangeSlider: bool,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

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
                ?ShowXAxisRangeSlider = ShowXAxisRangeSlider,
                ?UseDefaults = UseDefaults
            )

