using System;
using System.Collections.Generic;
using Plotly.NET;
using Plotly.NET.LayoutObjects;
using Plotly.NET.TraceObjects;
using static Plotly.NET.StyleParam;

namespace Plotly.NET.CSharp;

public static partial class Chart
{
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
    public static GenericChart Histogram<XType, YType, TextType>(
        Optional<IEnumerable<XType>> X = default,
        Optional<IEnumerable<IEnumerable<XType>>> MultiX = default,
        Optional<IEnumerable<YType>> Y = default,
        Optional<IEnumerable<IEnumerable<YType>>> MultiY = default,
        Optional<StyleParam.Orientation> Orientation = default,
        Optional<string> Name = default,
        Optional<bool> ShowLegend = default,
        Optional<double> Opacity = default,
        Optional<TextType> Text = default,
        Optional<IEnumerable<TextType>> MultiText = default,
        Optional<StyleParam.TextPosition> TextPosition = default,
        Optional<StyleParam.HistFunc> HistFunc = default,
        Optional<StyleParam.HistNorm> HistNorm = default,
        Optional<string> AlignmentGroup = default,
        Optional<string> OffsetGroup = default,
        Optional<int> NBinsX = default,
        Optional<int> NBinsY = default,
        Optional<string> BinGroup = default,
        Optional<Bins> XBins = default,
        Optional<Bins> YBins = default,
        Optional<Color> MarkerColor = default,
        Optional<StyleParam.Colorscale> MarkerColorScale = default,
        Optional<Line> MarkerOutline = default,
        Optional<StyleParam.PatternShape> MarkerPatternShape = default,
        Optional<IEnumerable<PatternShape>> MultiMarkerPatternShape = default,
        Optional<Pattern> MarkerPattern = default,
        Optional<Marker> Marker = default,
        Optional<Line> Line = default,
        Optional<Error> XError = default,
        Optional<Error> YError = default,
        Optional<Cumulative> Cumulative = default,
        Optional<Hoverlabel> HoverLabel = default,
        Optional<bool> UseDefaults = default
    )
        where XType : IConvertible
        where YType : IConvertible
        where TextType : IConvertible
        =>
            Plotly.NET.Chart2D_Histogram.Chart.Histogram<XType, YType, TextType>(
                X: X.ToOption(),
                MultiX: MultiX.ToOption(),
                Y: Y.ToOption(),
                MultiY: MultiY.ToOption(),
                Orientation: Orientation.ToOption(),
                Name: Name.ToOption(),
                ShowLegend: ShowLegend.ToOption(),
                Opacity: Opacity.ToOption(),
                Text: Text.ToOption(),
                MultiText: MultiText.ToOption(),
                TextPosition: TextPosition.ToOption(),
                HistFunc: HistFunc.ToOption(),
                HistNorm: HistNorm.ToOption(),
                AlignmentGroup: AlignmentGroup.ToOption(),
                OffsetGroup: OffsetGroup.ToOption(),
                NBinsX: NBinsX.ToOption(),
                NBinsY: NBinsY.ToOption(),
                BinGroup: BinGroup.ToOption(),
                XBins: XBins.ToOption(),
                YBins: YBins.ToOption(),
                MarkerColor: MarkerColor.ToOption(),
                MarkerColorScale: MarkerColorScale.ToOption(),
                MarkerOutline: MarkerOutline.ToOption(),
                MarkerPatternShape: MarkerPatternShape.ToOption(),
                MultiMarkerPatternShape: MultiMarkerPatternShape.ToOption(),
                MarkerPattern: MarkerPattern.ToOption(),
                Marker: Marker.ToOption(),
                Line: Line.ToOption(),
                XError: XError.ToOption(),
                YError: YError.ToOption(),
                Cumulative: Cumulative.ToOption(),
                HoverLabel: HoverLabel.ToOption(),
                UseDefaults: UseDefaults.ToOption()
            );
}
