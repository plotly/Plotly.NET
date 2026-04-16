namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects

open DynamicObj
open System
open System.IO
open System.Runtime.CompilerServices

open System.Runtime.InteropServices

[<AutoOpen>]
module Chart2D_Histogram =
    [<Extension>]
    type Chart =
        /// <summary>
        /// Visualizes the distribution of the input data as a histogram.
        ///
        /// A histogram is an approximate representation of the distribution of numerical data. To construct a histogram, the first step is to "bin"  the range of values - that is, divide the entire range of values into a series of intervals - and then count how many values fall into each interval.
        /// The bins are usually specified as consecutive, non-overlapping intervals of a variable.
        ///
        /// The sample data from which statistics are computed is set in `x` for vertically spanning histograms and in `y` for horizontally spanning histograms. Binning options are set `xbins` and `ybins` respectively if no aggregation data is provided.
        /// </summary>
        /// <param name="X">Sets the sample data to be binned on the x axis.</param>
        /// <param name="MultiX">Sets the sample data to be binned on the x axis. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="Y">Sets the sample data to be binned on the y axis.</param>
        /// <param name="MultiY">Sets the sample data to be binned on the y axis. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="Orientation">Sets the orientation of the bars. With "v" ("h"), the value of the each bar spans along the vertical (horizontal).</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity of the trace.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="HistFunc">Specifies the binning function used for this histogram trace. If "count", the histogram values are computed by counting the number of values lying inside each bin. If "sum", "avg", "min", "max", the histogram values are computed using the sum, the average, the minimum or the maximum of the values lying inside each bin respectively.</param>
        /// <param name="HistNorm">Specifies the type of normalization used for this histogram trace. If "", the span of each bar corresponds to the number of occurrences (i.e. the number of data points lying inside the bins). If "percent" / "probability", the span of each bar corresponds to the percentage / fraction of occurrences with respect to the total number of sample points (here, the sum of all bin HEIGHTS equals 100% / 1). If "density", the span of each bar corresponds to the number of occurrences in a bin divided by the size of the bin interval (here, the sum of all bin AREAS equals the total number of sample points). If "probability density", the area of each bar corresponds to the probability that an event will fall into the corresponding bin (here, the sum of all bin AREAS equals 1).</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="NBinsX">Specifies the maximum number of desired bins. This value will be used in an algorithm that will decide the optimal bin size such that the histogram best visualizes the distribution of the data. Ignored if `xbins.size` is provided.</param>
        /// <param name="NBinsY">Specifies the maximum number of desired bins. This value will be used in an algorithm that will decide the optimal bin size such that the histogram best visualizes the distribution of the data. Ignored if `ybins.size` is provided.</param>
        /// <param name="BinGroup">Set a group of histogram traces which will have compatible bin settings. Note that traces on the same subplot and with the same "orientation" under `barmode` "stack", "relative" and "group" are forced into the same bingroup, Using `bingroup`, traces under `barmode` "overlay" and on different axes (of the same axis type) can have compatible bin settings. Note that histogram and histogram2d" trace can share the same `bingroup`</param>
        /// <param name="XBins">Sets the binning across the x dimension</param>
        /// <param name="YBins">Sets the binning across the y dimension</param>
        /// <param name="MarkerColor">Sets the color of the bars</param>
        /// <param name="MarkerColorScale">Sets the colorscale for the bars. To have an effect, `MarkerColor` must map to color scale values.</param>
        /// <param name="MarkerOutline">Sets the color of the bar outlines</param>
        /// <param name="MarkerPatternShape">Sets a pattern shape for all bars</param>
        /// <param name="MultiMarkerPatternShape">Sets an individual pattern shape for each bar</param>
        /// <param name="MarkerPattern">Sets the marker pattern (use this for more finegrained control than the other pattern-associated arguments).</param>
        /// <param name="Marker">Sets the marker of this trace.</param>
        /// <param name="Line">Sets the outline of the histogram's bars.</param>
        /// <param name="XError">Sets the x error of this trace.</param>
        /// <param name="YError">Sets the y error of this trace.</param>
        /// <param name="Cumulative">Sets whether and how the cumulative distribution is displayed</param>
        /// <param name="HoverLabel">Sets the style of the hoverlabels of this trace.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Histogram
            (
                ?X: seq<#IConvertible>,
                ?MultiX: seq<seq<#IConvertible>>,
                ?Y: seq<#IConvertible>,
                ?MultiY: seq<seq<#IConvertible>>,
                ?Orientation: StyleParam.Orientation,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?HistFunc: StyleParam.HistFunc,
                ?HistNorm: StyleParam.HistNorm,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?NBinsX: int,
                ?NBinsY: int,
                ?BinGroup: string,
                ?XBins: Bins,
                ?YBins: Bins,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerPatternShape: StyleParam.PatternShape,
                ?MultiMarkerPatternShape: seq<StyleParam.PatternShape>,
                ?MarkerPattern: Pattern,
                ?Marker: Marker,
                ?Line: Line,
                ?XError: Error,
                ?YError: Error,
                ?Cumulative: Cumulative,
                ?HoverLabel: Hoverlabel,
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
                    ?Colorscale = MarkerColorScale,
                    ?Outline = MarkerOutline
                )

            Trace2D.initHistogram (
                Trace2DStyle.Histogram(
                    ?X = X,
                    ?MultiX = MultiX,
                    ?Y = Y,
                    ?MultiY = MultiY,
                    ?Orientation = Orientation,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?TextPosition = TextPosition,
                    ?HistFunc = HistFunc,
                    ?HistNorm = HistNorm,
                    ?AlignmentGroup = AlignmentGroup,
                    ?OffsetGroup = OffsetGroup,
                    ?NBinsX = NBinsX,
                    ?NBinsY = NBinsY,
                    ?BinGroup = BinGroup,
                    ?XBins = XBins,
                    ?YBins = YBins,
                    Marker = marker,
                    ?Line = Line,
                    ?XError = XError,
                    ?YError = YError,
                    ?Cumulative = Cumulative,
                    ?HoverLabel = HoverLabel
                )
            )
            |> GenericChart.ofTraceObject useDefaults


        /// <summary>
        /// Visualizes the distribution of the input data as a histogram, automatically determining if the data is to be used for the x or y dimension based on the `orientation` parameter.
        ///
        /// A histogram is an approximate representation of the distribution of numerical data. To construct a histogram, the first step is to "bin"  the range of values - that is, divide the entire range of values into a series of intervals - and then count how many values fall into each interval.
        /// The bins are usually specified as consecutive, non-overlapping intervals of a variable.
        ///
        /// Binning options are set `xbins` and `ybins` respectively if no aggregation data is provided.
        /// </summary>
        /// <param name="data">Sets the sample data to be binned</param>
        /// <param name="orientation">Sets the orientation of the bars. With "v" ("h"), the value of the each bar spans along the vertical (horizontal).</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity of the trace.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="HistFunc">Specifies the binning function used for this histogram trace. If "count", the histogram values are computed by counting the number of values lying inside each bin. If "sum", "avg", "min", "max", the histogram values are computed using the sum, the average, the minimum or the maximum of the values lying inside each bin respectively.</param>
        /// <param name="HistNorm">Specifies the type of normalization used for this histogram trace. If "", the span of each bar corresponds to the number of occurrences (i.e. the number of data points lying inside the bins). If "percent" / "probability", the span of each bar corresponds to the percentage / fraction of occurrences with respect to the total number of sample points (here, the sum of all bin HEIGHTS equals 100% / 1). If "density", the span of each bar corresponds to the number of occurrences in a bin divided by the size of the bin interval (here, the sum of all bin AREAS equals the total number of sample points). If "probability density", the area of each bar corresponds to the probability that an event will fall into the corresponding bin (here, the sum of all bin AREAS equals 1).</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="NBinsX">Specifies the maximum number of desired bins. This value will be used in an algorithm that will decide the optimal bin size such that the histogram best visualizes the distribution of the data. Ignored if `xbins.size` is provided.</param>
        /// <param name="NBinsY">Specifies the maximum number of desired bins. This value will be used in an algorithm that will decide the optimal bin size such that the histogram best visualizes the distribution of the data. Ignored if `ybins.size` is provided.</param>
        /// <param name="BinGroup">Set a group of histogram traces which will have compatible bin settings. Note that traces on the same subplot and with the same "orientation" under `barmode` "stack", "relative" and "group" are forced into the same bingroup, Using `bingroup`, traces under `barmode` "overlay" and on different axes (of the same axis type) can have compatible bin settings. Note that histogram and histogram2d" trace can share the same `bingroup`</param>
        /// <param name="XBins">Sets the binning across the x dimension</param>
        /// <param name="YBins">Sets the binning across the y dimension</param>
        /// <param name="MarkerColor">Sets the color of the histogram's bars.</param>
        /// <param name="Marker">Sets the marker for the histogram's bars (use this for more finegrained control than the other marker-associated arguments).</param>
        /// <param name="Line">Sets the outline of the histogram's bars.</param>
        /// <param name="XError">Sets the x error of this trace.</param>
        /// <param name="YError">Sets the y error of this trace.</param>
        /// <param name="Cumulative">Sets whether and how the cumulative distribution is displayed</param>
        /// <param name="HoverLabel">Sets the style of the hoverlabels of this trace.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Histogram
            (
                data: seq<#IConvertible>,
                orientation: StyleParam.Orientation,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?HistFunc: StyleParam.HistFunc,
                ?HistNorm: StyleParam.HistNorm,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?NBinsX: int,
                ?NBinsY: int,
                ?BinGroup: string,
                ?XBins: Bins,
                ?YBins: Bins,
                ?MarkerColor: Color,
                ?Marker: Marker,
                ?Line: Line,
                ?XError: Error,
                ?YError: Error,
                ?Cumulative: Cumulative,
                ?HoverLabel: Hoverlabel,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let histChart =
                Trace2D.initHistogram (
                    Trace2DStyle.Histogram(
                        ?Opacity = Opacity,
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
                        ?XError = XError,
                        ?YError = YError,
                        ?Cumulative = Cumulative,
                        ?HoverLabel = HoverLabel
                    )
                )
                |> TraceStyle.Marker(?Color = MarkerColor)
                |> TraceStyle.TraceInfo(?Name = Name, ?ShowLegend = ShowLegend)
                |> GenericChart.ofTraceObject useDefaults

            match orientation with
            | StyleParam.Orientation.Horizontal -> histChart |> GenericChart.mapTrace (Trace2DStyle.Histogram(Y = data))
            | StyleParam.Orientation.Vertical -> histChart |> GenericChart.mapTrace (Trace2DStyle.Histogram(X = data))

        /// <summary>
        /// Visualizes the distribution of the input data as a histogram using an encoded typed array.
        /// </summary>
        /// <param name="dataEncoded">Sets the sample data to be binned as an encoded typed array.</param>
        /// <param name="orientation">Sets the orientation of the bars. With "v" ("h"), the value of the each bar spans along the vertical (horizontal).</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity of the trace.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="HistFunc">Specifies the binning function used for this histogram trace.</param>
        /// <param name="HistNorm">Specifies the type of normalization used for this histogram trace.</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="NBinsX">Specifies the maximum number of desired bins.</param>
        /// <param name="NBinsY">Specifies the maximum number of desired bins.</param>
        /// <param name="BinGroup">Set a group of histogram traces which will have compatible bin settings.</param>
        /// <param name="XBins">Sets the binning across the x dimension</param>
        /// <param name="YBins">Sets the binning across the y dimension</param>
        /// <param name="MarkerColor">Sets the color of the histogram's bars.</param>
        /// <param name="Marker">Sets the marker for the histogram's bars.</param>
        /// <param name="Line">Sets the outline of the histogram's bars.</param>
        /// <param name="XError">Sets the x error of this trace.</param>
        /// <param name="YError">Sets the y error of this trace.</param>
        /// <param name="Cumulative">Sets whether and how the cumulative distribution is displayed</param>
        /// <param name="HoverLabel">Sets the style of the hoverlabels of this trace.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Histogram
            (
                dataEncoded: EncodedTypedArray,
                orientation: StyleParam.Orientation,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?HistFunc: StyleParam.HistFunc,
                ?HistNorm: StyleParam.HistNorm,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?NBinsX: int,
                ?NBinsY: int,
                ?BinGroup: string,
                ?XBins: Bins,
                ?YBins: Bins,
                ?MarkerColor: Color,
                ?Marker: Marker,
                ?Line: Line,
                ?XError: Error,
                ?YError: Error,
                ?Cumulative: Cumulative,
                ?HoverLabel: Hoverlabel,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let histChart =
                Trace2D.initHistogram (
                    Trace2DStyle.Histogram(
                        ?Opacity = Opacity,
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
                        ?XError = XError,
                        ?YError = YError,
                        ?Cumulative = Cumulative,
                        ?HoverLabel = HoverLabel
                    )
                )
                |> TraceStyle.Marker(?Color = MarkerColor)
                |> TraceStyle.TraceInfo(?Name = Name, ?ShowLegend = ShowLegend)
                |> GenericChart.ofTraceObject useDefaults

            match orientation with
            | StyleParam.Orientation.Horizontal -> histChart |> GenericChart.mapTrace (Trace2DStyle.Histogram(YEncoded = dataEncoded))
            | StyleParam.Orientation.Vertical -> histChart |> GenericChart.mapTrace (Trace2DStyle.Histogram(XEncoded = dataEncoded))

        /// <summary>
        /// Visualizes the distribution of the 2-dimensional input data as 2D Histogram.
        ///
        ///The sample data from which statistics are computed is set in `x` and `y` (where `x` and `y` represent marginal distributions, binning is set in `xbins` and `ybins` in this case) or `z` (where `z` represent the 2D distribution and binning set, binning is set by `x` and `y` in this case). The resulting distribution is visualized as a heatmap.
        /// </summary>
        /// <param name="X">Sets the sample data to be binned on the x axis.</param>
        /// <param name="MultiX">Sets the sample data to be binned on the x axis. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="Y">Sets the sample data to be binned on the y axis.</param>
        /// <param name="MultiY">Sets the sample data to be binned on the y axis. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="Z">Sets the aggregation data.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity of the trace.</param>
        /// <param name="XGap">Sets the horizontal gap (in pixels) between bricks.</param>
        /// <param name="YGap">Sets the vertical gap (in pixels) between bricks.</param>
        /// <param name="HistFunc">Specifies the binning function used for this histogram trace. If "count", the histogram values are computed by counting the number of values lying inside each bin. If "sum", "avg", "min", "max", the histogram values are computed using the sum, the average, the minimum or the maximum of the values lying inside each bin respectively.</param>
        /// <param name="HistNorm">Specifies the type of normalization used for this histogram trace. If "", the span of each bar corresponds to the number of occurrences (i.e. the number of data points lying inside the bins). If "percent" / "probability", the span of each bar corresponds to the percentage / fraction of occurrences with respect to the total number of sample points (here, the sum of all bin HEIGHTS equals 100% / 1). If "density", the span of each bar corresponds to the number of occurrences in a bin divided by the size of the bin interval (here, the sum of all bin AREAS equals the total number of sample points). If "probability density", the area of each bar corresponds to the probability that an event will fall into the corresponding bin (here, the sum of all bin AREAS equals 1).</param>
        /// <param name="NBinsX">Specifies the maximum number of desired bins. This value will be used in an algorithm that will decide the optimal bin size such that the histogram best visualizes the distribution of the data. Ignored if `xbins.size` is provided.</param>
        /// <param name="NBinsY">Specifies the maximum number of desired bins. This value will be used in an algorithm that will decide the optimal bin size such that the histogram best visualizes the distribution of the data. Ignored if `ybins.size` is provided.</param>
        /// <param name="XBins">Sets the binning across the x dimension</param>
        /// <param name="YBins">Sets the binning across the y dimension</param>
        /// <param name="ColorBar">Sets the styles of the colorbar for this trace.</param>
        /// <param name="ColorScale">Sets the colorscale for this trace.</param>
        /// <param name="ShowScale">Whether or not to show the colorscale/colorbar</param>
        /// <param name="ReverseScale">Reverses the color mapping if true. If true, `zmin` will correspond to the last color in the array and `zmax` will correspond to the first color.</param>
        /// <param name="ZSmooth">Picks a smoothing algorithm use to smooth `z` data.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Histogram2D
            (
                ?X: seq<#IConvertible>,
                ?MultiX: seq<seq<#IConvertible>>,
                ?Y: seq<#IConvertible>,
                ?MultiY: seq<seq<#IConvertible>>,
                ?Z: seq<#seq<#IConvertible>>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?XGap: int,
                ?YGap: int,
                ?HistFunc: StyleParam.HistFunc,
                ?HistNorm: StyleParam.HistNorm,
                ?NBinsX: int,
                ?NBinsY: int,
                ?XBins: Bins,
                ?YBins: Bins,
                ?ColorBar: ColorBar,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
                ?ReverseScale: bool,
                ?ZSmooth: StyleParam.SmoothAlg,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            Trace2D.initHistogram2D (
                Trace2DStyle.Histogram2D(
                    ?X = X,
                    ?MultiX = MultiX,
                    ?Y = Y,
                    ?MultiY = MultiY,
                    ?Z = Z,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?XGap = XGap,
                    ?YGap = YGap,
                    ?HistFunc = HistFunc,
                    ?HistNorm = HistNorm,
                    ?NBinsX = NBinsX,
                    ?NBinsY = NBinsY,
                    ?XBins = XBins,
                    ?YBins = YBins,
                    ?ColorBar = ColorBar,
                    ?ColorScale = ColorScale,
                    ?ShowScale = ShowScale,
                    ?ReverseScale = ReverseScale,
                    ?ZSmooth = ZSmooth
                )
            )
            |> GenericChart.ofTraceObject useDefaults

        /// <summary>
        /// Visualizes the distribution of the encoded 2-dimensional input data as a 2D histogram.
        ///
        /// The sample data from which statistics are computed is set in `xEncoded` and `yEncoded`, and optional encoded aggregation data can be provided through `zEncoded`.
        /// </summary>
        /// <param name="xEncoded">Sets the sample data to be binned on the x axis as an encoded typed array.</param>
        /// <param name="yEncoded">Sets the sample data to be binned on the y axis as an encoded typed array.</param>
        /// <param name="zEncoded">Sets the aggregation data as an encoded typed array.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity of the trace.</param>
        /// <param name="XGap">Sets the horizontal gap (in pixels) between bricks.</param>
        /// <param name="YGap">Sets the vertical gap (in pixels) between bricks.</param>
        /// <param name="HistFunc">Specifies the binning function used for this histogram trace.</param>
        /// <param name="HistNorm">Specifies the type of normalization used for this histogram trace.</param>
        /// <param name="NBinsX">Specifies the maximum number of desired bins.</param>
        /// <param name="NBinsY">Specifies the maximum number of desired bins.</param>
        /// <param name="XBins">Sets the binning across the x dimension</param>
        /// <param name="YBins">Sets the binning across the y dimension</param>
        /// <param name="ColorBar">Sets the styles of the colorbar for this trace.</param>
        /// <param name="ColorScale">Sets the colorscale for this trace.</param>
        /// <param name="ShowScale">Whether or not to show the colorscale/colorbar</param>
        /// <param name="ReverseScale">Reverses the color mapping if true.</param>
        /// <param name="ZSmooth">Picks a smoothing algorithm use to smooth `z` data.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Histogram2D
            (
                xEncoded: EncodedTypedArray,
                yEncoded: EncodedTypedArray,
                ?zEncoded: EncodedTypedArray,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?XGap: int,
                ?YGap: int,
                ?HistFunc: StyleParam.HistFunc,
                ?HistNorm: StyleParam.HistNorm,
                ?NBinsX: int,
                ?NBinsY: int,
                ?XBins: Bins,
                ?YBins: Bins,
                ?ColorBar: ColorBar,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
                ?ReverseScale: bool,
                ?ZSmooth: StyleParam.SmoothAlg,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            Trace2D.initHistogram2D (
                Trace2DStyle.Histogram2D(
                    XEncoded = xEncoded,
                    YEncoded = yEncoded,
                    ?ZEncoded = zEncoded,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?XGap = XGap,
                    ?YGap = YGap,
                    ?HistFunc = HistFunc,
                    ?HistNorm = HistNorm,
                    ?NBinsX = NBinsX,
                    ?NBinsY = NBinsY,
                    ?XBins = XBins,
                    ?YBins = YBins,
                    ?ColorBar = ColorBar,
                    ?ColorScale = ColorScale,
                    ?ShowScale = ShowScale,
                    ?ReverseScale = ReverseScale,
                    ?ZSmooth = ZSmooth
                )
            )
            |> GenericChart.ofTraceObject useDefaults

        /// <summary>
        /// Visualizes the distribution of the 2-dimensional input data as 2D Histogram.
        ///
        ///The sample data from which statistics are computed is set in `x` and `y` (where `x` and `y` represent marginal distributions, binning is set in `xbins` and `ybins` in this case) or `z` (where `z` represent the 2D distribution and binning set, binning is set by `x` and `y` in this case). The resulting distribution is visualized as a heatmap.
        /// </summary>
        /// <param name="x">Sets the sample data to be binned on the x axis.</param>
        /// <param name="y">Sets the sample data to be binned on the y axis.</param>
        /// <param name="Z">Sets the aggregation data.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity of the trace.</param>
        /// <param name="XGap">Sets the horizontal gap (in pixels) between bricks.</param>
        /// <param name="YGap">Sets the vertical gap (in pixels) between bricks.</param>
        /// <param name="HistFunc">Specifies the binning function used for this histogram trace. If "count", the histogram values are computed by counting the number of values lying inside each bin. If "sum", "avg", "min", "max", the histogram values are computed using the sum, the average, the minimum or the maximum of the values lying inside each bin respectively.</param>
        /// <param name="HistNorm">Specifies the type of normalization used for this histogram trace. If "", the span of each bar corresponds to the number of occurrences (i.e. the number of data points lying inside the bins). If "percent" / "probability", the span of each bar corresponds to the percentage / fraction of occurrences with respect to the total number of sample points (here, the sum of all bin HEIGHTS equals 100% / 1). If "density", the span of each bar corresponds to the number of occurrences in a bin divided by the size of the bin interval (here, the sum of all bin AREAS equals the total number of sample points). If "probability density", the area of each bar corresponds to the probability that an event will fall into the corresponding bin (here, the sum of all bin AREAS equals 1).</param>
        /// <param name="NBinsX">Specifies the maximum number of desired bins. This value will be used in an algorithm that will decide the optimal bin size such that the histogram best visualizes the distribution of the data. Ignored if `xbins.size` is provided.</param>
        /// <param name="NBinsY">Specifies the maximum number of desired bins. This value will be used in an algorithm that will decide the optimal bin size such that the histogram best visualizes the distribution of the data. Ignored if `ybins.size` is provided.</param>
        /// <param name="XBins">Sets the binning across the x dimension</param>
        /// <param name="YBins">Sets the binning across the y dimension</param>
        /// <param name="ColorBar">Sets the styles of the colorbar for this trace.</param>
        /// <param name="ColorScale">Sets the colorscale for this trace.</param>
        /// <param name="ShowScale">Whether or not to show the colorscale/colorbar</param>
        /// <param name="ReverseScale">Reverses the color mapping if true. If true, `zmin` will correspond to the last color in the array and `zmax` will correspond to the first color.</param>
        /// <param name="ZSmooth">Picks a smoothing algorithm use to smooth `z` data.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Histogram2D
            (
                x: seq<#IConvertible>,
                y: seq<#IConvertible>,
                ?Z: seq<#seq<#IConvertible>>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?XGap: int,
                ?YGap: int,
                ?HistFunc: StyleParam.HistFunc,
                ?HistNorm: StyleParam.HistNorm,
                ?NBinsX: int,
                ?NBinsY: int,
                ?XBins: Bins,
                ?YBins: Bins,
                ?ColorBar: ColorBar,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
                ?ReverseScale: bool,
                ?ZSmooth: StyleParam.SmoothAlg,
                ?UseDefaults: bool
            ) =

            Chart.Histogram2D(
                X = x,
                Y = y,
                ?Z = Z,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?XGap = XGap,
                ?YGap = YGap,
                ?HistFunc = HistFunc,
                ?HistNorm = HistNorm,
                ?NBinsX = NBinsX,
                ?NBinsY = NBinsY,
                ?XBins = XBins,
                ?YBins = YBins,
                ?ColorBar = ColorBar,
                ?ColorScale = ColorScale,
                ?ShowScale = ShowScale,
                ?ReverseScale = ReverseScale,
                ?ZSmooth = ZSmooth,
                ?UseDefaults = UseDefaults
            )


        /// <summary>
        /// Computes a 2D histogram contour plot, also known as a density contour plot, which is a 2-dimensional generalization of a histogram which resembles a contour plot but is computed by grouping a set of points specified by their x and y coordinates into bins, and applying an aggregation function such as count or sum (if z is provided) to compute the value to be used to compute contours.
        ///
        /// The sample data from which statistics are computed is set in `x` and `y` (where `x` and `y` represent marginal distributions, binning is set in `xbins` and `ybins` in this case) or `z` (where `z` represent the 2D distribution and binning set, binning is set by `x` and `y` in this case). The resulting distribution is visualized as a contour plot.
        /// </summary>
        /// <param name="X">Sets the sample data to be binned on the x axis.</param>
        /// <param name="MultiX">Sets the sample data to be binned on the x axis. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="Y">Sets the sample data to be binned on the y axis.</param>
        /// <param name="MultiY">Sets the sample data to be binned on the y axis. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity otf the trace.</param>
        /// <param name="Z">Sets the aggregation data.</param>
        /// <param name="HistFunc">Specifies the binning function used for this histogram trace. If "count", the histogram values are computed by counting the number of values lying inside each bin. If "sum", "avg", "min", "max", the histogram values are computed using the sum, the average, the minimum or the maximum of the values lying inside each bin respectively.</param>
        /// <param name="HistNorm">Specifies the type of normalization used for this histogram trace. If "", the span of each bar corresponds to the number of occurrences (i.e. the number of data points lying inside the bins). If "percent" / "probability", the span of each bar corresponds to the percentage / fraction of occurrences with respect to the total number of sample points (here, the sum of all bin HEIGHTS equals 100% / 1). If "density", the span of each bar corresponds to the number of occurrences in a bin divided by the size of the bin interval (here, the sum of all bin AREAS equals the total number of sample points). If "probability density", the area of each bar corresponds to the probability that an event will fall into the corresponding bin (here, the sum of all bin AREAS equals 1).</param>
        /// <param name="NBinsX">Specifies the maximum number of desired bins. This value will be used in an algorithm that will decide the optimal bin size such that the histogram best visualizes the distribution of the data. Ignored if `xbins.size` is provided.</param>
        /// <param name="NBinsY">Specifies the maximum number of desired bins. This value will be used in an algorithm that will decide the optimal bin size such that the histogram best visualizes the distribution of the data. Ignored if `ybins.size` is provided.</param>
        /// <param name="BinGroup">Set the `xbingroup` and `ybingroup` default prefix For example, setting a `bingroup` of "1" on two histogram2d traces will make them their x-bins and y-bins match separately.</param>
        /// <param name="XBinGroup">Set a group of histogram traces which will have compatible x-bin settings. Using `xbingroup`, histogram2d and histogram2dcontour traces (on axes of the same axis type) can have compatible x-bin settings. Note that the same `xbingroup` value can be used to set (1D) histogram `bingroup`</param>
        /// <param name="XBins">Sets the binning across the x dimension</param>
        /// <param name="YBinGroup">Set a group of histogram traces which will have compatible y-bin settings. Using `ybingroup`, histogram2d and histogram2dcontour traces (on axes of the same axis type) can have compatible y-bin settings. Note that the same `ybingroup` value can be used to set (1D) histogram `bingroup`</param>
        /// <param name="YBins">Sets the binning across the y dimension</param>
        /// <param name="Marker">Sets the marker of this trace.</param>
        /// <param name="ContourLinesDash">Sets the contour line dash style</param>
        /// <param name="ContourLinesColor">Sets the contour line color</param>
        /// <param name="ContourLinesSmoothing">Sets the amount of smoothing for the contour lines, where "0" corresponds to no smoothing.</param>
        /// <param name="ContourLinesWidth">Sets the width of the contour lines</param>
        /// <param name="ContourLines">Sets the contour lines (use this for more finegrained control than the other contourline-associated arguments).</param>
        /// <param name="ShowContourLines">Wether or not to show the contour line</param>
        /// <param name="ContoursColoring">Determines the coloring method showing the contour values. If "fill", coloring is done evenly between each contour level If "heatmap", a heatmap gradient coloring is applied between each contour level. If "lines", coloring is done on the contour lines. If "none", no coloring is applied on this trace.</param>
        /// <param name="ContoursOperation">Sets the constraint operation. "=" keeps regions equal to `value` "&lt;" and "&lt;=" keep regions less than `value` "&gt;" and "&gt;=" keep regions greater than `value` "[]", "()", "[)", and "(]" keep regions inside `value[0]` to `value[1]` "][", ")(", "](", ")[" keep regions outside `value[0]` to value[1]` Open vs. closed intervals make no difference to constraint display, but all versions are allowed for consistency with filter transforms.</param>
        /// <param name="ContoursType">If `levels`, the data is represented as a contour plot with multiple levels displayed. If `constraint`, the data is represented as constraints with the invalid region shaded as specified by the `operation` and `value` parameters.</param>
        /// <param name="ShowContoursLabels">Determines whether to label the contour lines with their values.</param>
        /// <param name="ContoursLabelFont">Sets the font used for labeling the contour levels. The default color comes from the lines, if shown. The default family and size come from `layout.font`.</param>
        /// <param name="ContoursStart">Sets the starting contour level value. Must be less than `contours.end`</param>
        /// <param name="ContoursEnd">Sets the end contour level value. Must be more than `contours.start`</param>
        /// <param name="Contours">Sets the styles of the contours (use this for more finegrained control than the other contour-associated arguments).</param>
        /// <param name="ColorBar">Sets the styles of the colorbar for this trace.</param>
        /// <param name="ColorScale">Sets the colorscale for this trace.</param>
        /// <param name="ShowScale">Whether or not to show the colorscale/colorbar</param>
        /// <param name="ReverseScale">Reverses the color mapping if true. If true, `zmin` will correspond to the last color in the array and `zmax` will correspond to the first color.</param>
        /// <param name="NContours">Sets the maximum number of contour levels. The actual number of contours will be chosen automatically to be less than or equal to the value of `ncontours`. Has an effect only if `autocontour` is "true" or if `contours.size` is missing.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Histogram2DContour
            (
                ?X: seq<#IConvertible>,
                ?MultiX: seq<seq<#IConvertible>>,
                ?Y: seq<#IConvertible>,
                ?MultiY: seq<seq<#IConvertible>>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Z: seq<#seq<#IConvertible>>,
                ?HistFunc: StyleParam.HistFunc,
                ?HistNorm: StyleParam.HistNorm,
                ?NBinsX: int,
                ?NBinsY: int,
                ?BinGroup: string,
                ?XBinGroup: string,
                ?XBins: Bins,
                ?YBinGroup: string,
                ?YBins: Bins,
                ?Marker: Marker,
                ?ContourLinesColor: Color,
                ?ContourLinesDash: StyleParam.DrawingStyle,
                ?ContourLinesSmoothing: float,
                ?ContourLinesWidth: float,
                ?ContourLines: Line,
                ?ShowContourLines: bool,
                ?ContoursColoring: StyleParam.ContourColoring,
                ?ContoursOperation: StyleParam.ConstraintOperation,
                ?ContoursType: StyleParam.ContourType,
                ?ShowContoursLabels: bool,
                ?ContoursLabelFont: Font,
                ?ContoursStart: float,
                ?ContoursEnd: float,
                ?Contours: Contours,
                ?ColorBar: ColorBar,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
                ?ReverseScale: bool,
                ?NContours: int,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let showContourLines =
                defaultArg ShowContourLines false

            let contourLineWidth =
                ContourLinesWidth |> Option.map (fun v -> if showContourLines then v else 0.) |> Option.defaultValue 0.

            let contours =
                Contours
                |> Option.defaultValue (TraceObjects.Contours.init ())
                |> TraceObjects.Contours.style (
                    ?Coloring = ContoursColoring,
                    ?Operation = ContoursOperation,
                    ?Start = ContoursStart,
                    ?End = ContoursEnd,
                    ?Type = ContoursType,
                    ?ShowLabels = ShowContoursLabels,
                    ?LabelFont = ContoursLabelFont
                )

            let contourLines =
                ContourLines
                |> Option.defaultValue (Plotly.NET.Line.init ())
                |> Plotly.NET.Line.style (
                    Width = contourLineWidth,
                    ?Color = ContourLinesColor,
                    ?Dash = ContourLinesDash,
                    ?Smoothing = ContourLinesSmoothing
                )

            Trace2D.initHistogram2DContour (
                Trace2DStyle.Histogram2DContour(
                    ?X = X,
                    ?MultiX = MultiX,
                    ?Y = Y,
                    ?MultiY = MultiY,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
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
                    Line = contourLines,
                    ?ColorBar = ColorBar,
                    ?ColorScale = ColorScale,
                    ?ShowScale = ShowScale,
                    ?ReverseScale = ReverseScale,
                    Contours = contours,
                    ?NContours = NContours
                )
            )
            |> GenericChart.ofTraceObject useDefaults

        /// <summary>
        /// Computes a 2D histogram contour plot from encoded input data.
        /// </summary>
        /// <param name="xEncoded">Sets the sample data to be binned on the x axis as an encoded typed array.</param>
        /// <param name="yEncoded">Sets the sample data to be binned on the y axis as an encoded typed array.</param>
        /// <param name="zEncoded">Sets the aggregation data as an encoded typed array.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity otf the trace.</param>
        /// <param name="HistFunc">Specifies the binning function used for this histogram trace.</param>
        /// <param name="HistNorm">Specifies the type of normalization used for this histogram trace.</param>
        /// <param name="NBinsX">Specifies the maximum number of desired bins.</param>
        /// <param name="NBinsY">Specifies the maximum number of desired bins.</param>
        /// <param name="BinGroup">Set the `xbingroup` and `ybingroup` default prefix.</param>
        /// <param name="XBinGroup">Set a group of histogram traces which will have compatible x-bin settings.</param>
        /// <param name="XBins">Sets the binning across the x dimension</param>
        /// <param name="YBinGroup">Set a group of histogram traces which will have compatible y-bin settings.</param>
        /// <param name="YBins">Sets the binning across the y dimension</param>
        /// <param name="Marker">Sets the marker of this trace.</param>
        /// <param name="ContourLinesDash">Sets the contour line dash style</param>
        /// <param name="ContourLinesColor">Sets the contour line color</param>
        /// <param name="ContourLinesSmoothing">Sets the amount of smoothing for the contour lines.</param>
        /// <param name="ContourLinesWidth">Sets the width of the contour lines</param>
        /// <param name="ContourLines">Sets the contour lines.</param>
        /// <param name="ShowContourLines">Wether or not to show the contour line</param>
        /// <param name="ContoursColoring">Determines the coloring method showing the contour values.</param>
        /// <param name="ContoursOperation">Sets the constraint operation.</param>
        /// <param name="ContoursType">Sets the contour representation type.</param>
        /// <param name="ShowContoursLabels">Determines whether to label the contour lines with their values.</param>
        /// <param name="ContoursLabelFont">Sets the font used for labeling the contour levels.</param>
        /// <param name="ContoursStart">Sets the starting contour level value.</param>
        /// <param name="ContoursEnd">Sets the end contour level value.</param>
        /// <param name="Contours">Sets the styles of the contours.</param>
        /// <param name="ColorBar">Sets the styles of the colorbar for this trace.</param>
        /// <param name="ColorScale">Sets the colorscale for this trace.</param>
        /// <param name="ShowScale">Whether or not to show the colorscale/colorbar</param>
        /// <param name="ReverseScale">Reverses the color mapping if true.</param>
        /// <param name="NContours">Sets the maximum number of contour levels.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Histogram2DContour
            (
                xEncoded: EncodedTypedArray,
                yEncoded: EncodedTypedArray,
                ?zEncoded: EncodedTypedArray,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?HistFunc: StyleParam.HistFunc,
                ?HistNorm: StyleParam.HistNorm,
                ?NBinsX: int,
                ?NBinsY: int,
                ?BinGroup: string,
                ?XBinGroup: string,
                ?XBins: Bins,
                ?YBinGroup: string,
                ?YBins: Bins,
                ?Marker: Marker,
                ?ContourLinesColor: Color,
                ?ContourLinesDash: StyleParam.DrawingStyle,
                ?ContourLinesSmoothing: float,
                ?ContourLinesWidth: float,
                ?ContourLines: Line,
                ?ShowContourLines: bool,
                ?ContoursColoring: StyleParam.ContourColoring,
                ?ContoursOperation: StyleParam.ConstraintOperation,
                ?ContoursType: StyleParam.ContourType,
                ?ShowContoursLabels: bool,
                ?ContoursLabelFont: Font,
                ?ContoursStart: float,
                ?ContoursEnd: float,
                ?Contours: Contours,
                ?ColorBar: ColorBar,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
                ?ReverseScale: bool,
                ?NContours: int,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let showContourLines =
                defaultArg ShowContourLines false

            let contourLineWidth =
                ContourLinesWidth |> Option.map (fun v -> if showContourLines then v else 0.) |> Option.defaultValue 0.

            let contours =
                Contours
                |> Option.defaultValue (TraceObjects.Contours.init ())
                |> TraceObjects.Contours.style (
                    ?Coloring = ContoursColoring,
                    ?Operation = ContoursOperation,
                    ?Start = ContoursStart,
                    ?End = ContoursEnd,
                    ?Type = ContoursType,
                    ?ShowLabels = ShowContoursLabels,
                    ?LabelFont = ContoursLabelFont
                )

            let contourLines =
                ContourLines
                |> Option.defaultValue (Plotly.NET.Line.init ())
                |> Plotly.NET.Line.style (
                    Width = contourLineWidth,
                    ?Color = ContourLinesColor,
                    ?Dash = ContourLinesDash,
                    ?Smoothing = ContourLinesSmoothing
                )

            Trace2D.initHistogram2DContour (
                Trace2DStyle.Histogram2DContour(
                    XEncoded = xEncoded,
                    YEncoded = yEncoded,
                    ?ZEncoded = zEncoded,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
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
                    Line = contourLines,
                    ?ColorBar = ColorBar,
                    ?ColorScale = ColorScale,
                    ?ShowScale = ShowScale,
                    ?ReverseScale = ReverseScale,
                    Contours = contours,
                    ?NContours = NContours
                )
            )
            |> GenericChart.ofTraceObject useDefaults

        /// <summary>
        /// Computes a 2D histogram contour plot, also known as a density contour plot, which is a 2-dimensional generalization of a histogram which resembles a contour plot but is computed by grouping a set of points specified by their x and y coordinates into bins, and applying an aggregation function such as count or sum (if z is provided) to compute the value to be used to compute contours.
        ///
        /// The sample data from which statistics are computed is set in `x` and `y` (where `x` and `y` represent marginal distributions, binning is set in `xbins` and `ybins` in this case) or `z` (where `z` represent the 2D distribution and binning set, binning is set by `x` and `y` in this case). The resulting distribution is visualized as a contour plot.
        /// </summary>
        /// <param name="x">Sets the sample data to be binned on the x axis.</param>
        /// <param name="y">Sets the sample data to be binned on the y axis.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity otf the trace.</param>
        /// <param name="Z">Sets the aggregation data.</param>
        /// <param name="HistFunc">Specifies the binning function used for this histogram trace. If "count", the histogram values are computed by counting the number of values lying inside each bin. If "sum", "avg", "min", "max", the histogram values are computed using the sum, the average, the minimum or the maximum of the values lying inside each bin respectively.</param>
        /// <param name="HistNorm">Specifies the type of normalization used for this histogram trace. If "", the span of each bar corresponds to the number of occurrences (i.e. the number of data points lying inside the bins). If "percent" / "probability", the span of each bar corresponds to the percentage / fraction of occurrences with respect to the total number of sample points (here, the sum of all bin HEIGHTS equals 100% / 1). If "density", the span of each bar corresponds to the number of occurrences in a bin divided by the size of the bin interval (here, the sum of all bin AREAS equals the total number of sample points). If "probability density", the area of each bar corresponds to the probability that an event will fall into the corresponding bin (here, the sum of all bin AREAS equals 1).</param>
        /// <param name="NBinsX">Specifies the maximum number of desired bins. This value will be used in an algorithm that will decide the optimal bin size such that the histogram best visualizes the distribution of the data. Ignored if `xbins.size` is provided.</param>
        /// <param name="NBinsY">Specifies the maximum number of desired bins. This value will be used in an algorithm that will decide the optimal bin size such that the histogram best visualizes the distribution of the data. Ignored if `ybins.size` is provided.</param>
        /// <param name="BinGroup">Set the `xbingroup` and `ybingroup` default prefix For example, setting a `bingroup` of "1" on two histogram2d traces will make them their x-bins and y-bins match separately.</param>
        /// <param name="XBinGroup">Set a group of histogram traces which will have compatible x-bin settings. Using `xbingroup`, histogram2d and histogram2dcontour traces (on axes of the same axis type) can have compatible x-bin settings. Note that the same `xbingroup` value can be used to set (1D) histogram `bingroup`</param>
        /// <param name="XBins">Sets the binning across the x dimension</param>
        /// <param name="YBinGroup">Set a group of histogram traces which will have compatible y-bin settings. Using `ybingroup`, histogram2d and histogram2dcontour traces (on axes of the same axis type) can have compatible y-bin settings. Note that the same `ybingroup` value can be used to set (1D) histogram `bingroup`</param>
        /// <param name="YBins">Sets the binning across the y dimension</param>
        /// <param name="Marker">Sets the marker of this trace.</param>
        /// <param name="ContourLinesDash">Sets the contour line dash style</param>
        /// <param name="ContourLinesColor">Sets the contour line color</param>
        /// <param name="ContourLinesSmoothing">Sets the amount of smoothing for the contour lines, where "0" corresponds to no smoothing.</param>
        /// <param name="ContourLinesWidth">Sets the width of the contour lines</param>
        /// <param name="ContourLines">Sets the contour lines (use this for more finegrained control than the other contourline-associated arguments).</param>
        /// <param name="ShowContourLines">Wether or not to show the contour line</param>
        /// <param name="ContoursColoring">Determines the coloring method showing the contour values. If "fill", coloring is done evenly between each contour level If "heatmap", a heatmap gradient coloring is applied between each contour level. If "lines", coloring is done on the contour lines. If "none", no coloring is applied on this trace.</param>
        /// <param name="ContoursOperation">Sets the constraint operation. "=" keeps regions equal to `value` "&lt;" and "&lt;=" keep regions less than `value` "&gt;" and "&gt;=" keep regions greater than `value` "[]", "()", "[)", and "(]" keep regions inside `value[0]` to `value[1]` "][", ")(", "](", ")[" keep regions outside `value[0]` to value[1]` Open vs. closed intervals make no difference to constraint display, but all versions are allowed for consistency with filter transforms.</param>
        /// <param name="ContoursType">If `levels`, the data is represented as a contour plot with multiple levels displayed. If `constraint`, the data is represented as constraints with the invalid region shaded as specified by the `operation` and `value` parameters.</param>
        /// <param name="ShowContoursLabels">Determines whether to label the contour lines with their values.</param>
        /// <param name="ContoursLabelFont">Sets the font used for labeling the contour levels. The default color comes from the lines, if shown. The default family and size come from `layout.font`.</param>
        /// <param name="ContoursStart">Sets the starting contour level value. Must be less than `contours.end`</param>
        /// <param name="ContoursEnd">Sets the end contour level value. Must be more than `contours.start`</param>
        /// <param name="Contours">Sets the styles of the contours (use this for more finegrained control than the other contour-associated arguments).</param>
        /// <param name="ColorBar">Sets the styles of the colorbar for this trace.</param>
        /// <param name="ColorScale">Sets the colorscale for this trace.</param>
        /// <param name="ShowScale">Whether or not to show the colorscale/colorbar</param>
        /// <param name="ReverseScale">Reverses the color mapping if true. If true, `zmin` will correspond to the last color in the array and `zmax` will correspond to the first color.</param>
        /// <param name="NContours">Sets the maximum number of contour levels. The actual number of contours will be chosen automatically to be less than or equal to the value of `ncontours`. Has an effect only if `autocontour` is "true" or if `contours.size` is missing.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Histogram2DContour
            (
                x: seq<#IConvertible>,
                y: seq<#IConvertible>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Z: seq<#seq<#IConvertible>>,
                ?HistFunc: StyleParam.HistFunc,
                ?HistNorm: StyleParam.HistNorm,
                ?NBinsX: int,
                ?NBinsY: int,
                ?BinGroup: string,
                ?XBinGroup: string,
                ?XBins: Bins,
                ?YBinGroup: string,
                ?YBins: Bins,
                ?Marker: Marker,
                ?ContourLinesColor: Color,
                ?ContourLinesDash: StyleParam.DrawingStyle,
                ?ContourLinesSmoothing: float,
                ?ContourLinesWidth: float,
                ?ContourLines: Line,
                ?ShowContourLines: bool,
                ?ContoursColoring: StyleParam.ContourColoring,
                ?ContoursOperation: StyleParam.ConstraintOperation,
                ?ContoursType: StyleParam.ContourType,
                ?ShowContoursLabels: bool,
                ?ContoursLabelFont: Font,
                ?ContoursStart: float,
                ?ContoursEnd: float,
                ?Contours: Contours,
                ?ColorBar: ColorBar,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
                ?ReverseScale: bool,
                ?NContours: int,
                ?UseDefaults: bool
            ) =
            Chart.Histogram2DContour(
                X = x,
                Y = y,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
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
                ?ContourLinesColor = ContourLinesColor,
                ?ContourLinesDash = ContourLinesDash,
                ?ContourLinesSmoothing = ContourLinesSmoothing,
                ?ContourLinesWidth = ContourLinesWidth,
                ?ContourLines = ContourLines,
                ?ShowContourLines= ShowContourLines,
                ?ContoursColoring = ContoursColoring,
                ?ContoursOperation = ContoursOperation,
                ?ContoursType = ContoursType,
                ?ShowContoursLabels = ShowContoursLabels,
                ?ContoursLabelFont = ContoursLabelFont,
                ?ContoursStart = ContoursStart,
                ?ContoursEnd = ContoursEnd,
                ?Contours = Contours,
                ?ColorBar = ColorBar,
                ?ColorScale = ColorScale,
                ?ShowScale = ShowScale,
                ?ReverseScale = ReverseScale,
                ?NContours = NContours,
                ?UseDefaults = UseDefaults
            )

