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
    /// <param name="ContourLabelFont">Sets the font used for labeling the contour levels. The default color comes from the lines, if shown. The default family and size come from `layout.font`.</param>
    /// <param name="ContoursStart">Sets the starting contour level value. Must be less than `contours.end`</param>
    /// <param name="ContoursEnd">Sets the end contour level value. Must be more than `contours.start`</param>
    /// <param name="Contours">Sets the styles of the contours (use this for more finegrained control than the other contour-associated arguments).</param>
    /// <param name="ColorBar">Sets the styles of the colorbar for this trace.</param>
    /// <param name="ColorScale">Sets the colorscale for this trace.</param>
    /// <param name="ShowScale">Whether or not to show the colorscale/colorbar</param>
    /// <param name="ReverseScale">Reverses the color mapping if true. If true, `zmin` will correspond to the last color in the array and `zmax` will correspond to the first color.</param>
    /// <param name="NContours">Sets the maximum number of contour levels. The actual number of contours will be chosen automatically to be less than or equal to the value of `ncontours`. Has an effect only if `autocontour` is "true" or if `contours.size` is missing.</param>
    /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
    public static GenericChart Histogram2DContour<XType, YType, ZType>(
        Optional<IEnumerable<XType>> X,
        Optional<IEnumerable<IEnumerable<XType>>> MultiX,
        Optional<IEnumerable<YType>> Y,
        Optional<IEnumerable<IEnumerable<YType>>> MultiY,
        Optional<string> Name = default,
        Optional<bool> ShowLegend = default,
        Optional<double> Opacity = default,
        Optional<IEnumerable<IEnumerable<ZType>>> Z = default,
        Optional<StyleParam.HistFunc> HistFunc = default,
        Optional<StyleParam.HistNorm> HistNorm = default,
        Optional<int> NBinsX = default,
        Optional<int> NBinsY = default,
        Optional<string> BinGroup = default,
        Optional<string> XBinGroup = default,
        Optional<Bins> XBins = default,
        Optional<string> YBinGroup = default,
        Optional<Bins> YBins = default,
        Optional<Marker> Marker = default,
        Optional<StyleParam.DrawingStyle> ContourLinesDash = default,
        Optional<Color> ContourLinesColor = default,
        Optional<double> ContourLinesSmoothing = default,
        Optional<double> ContourLinesWidth = default,
        Optional<Line> ContourLines = default,
        Optional<bool> ShowContourLines = default,
        Optional<StyleParam.ContourColoring> ContoursColoring = default,
        Optional<StyleParam.ConstraintOperation> ContoursOperation = default,
        Optional<StyleParam.ContourType> ContoursType = default,
        Optional<bool> ShowContoursLabels = default,
        Optional<Font> ContourLabelFont = default,
        Optional<double> ContoursStart = default,
        Optional<double> ContoursEnd = default,
        Optional<Contours> Contours = default,
        Optional<ColorBar> ColorBar = default,
        Optional<StyleParam.Colorscale> ColorScale = default,
        Optional<bool> ShowScale = default,
        Optional<bool> ReverseScale = default,
        Optional<int> NContours = default,
        Optional<bool> UseDefaults = default
    )
        where XType : IConvertible
        where YType : IConvertible
        where ZType : IConvertible
        =>
            Plotly.NET.Chart2D_Histogram.Chart.Histogram2DContour<XType, YType, IEnumerable<ZType>, ZType>(
                X: X.ToOption(),
                MultiX: MultiX.ToOption(),
                Y: Y.ToOption(),
                MultiY: MultiY.ToOption(),
                Name: Name.ToOption(),
                ShowLegend: ShowLegend.ToOption(),
                Opacity: Opacity.ToOption(),
                Z: Z.ToOption(),
                HistFunc: HistFunc.ToOption(),
                HistNorm: HistNorm.ToOption(),
                NBinsX: NBinsX.ToOption(),
                NBinsY: NBinsY.ToOption(),
                BinGroup: BinGroup.ToOption(),
                XBinGroup: XBinGroup.ToOption(),
                XBins: XBins.ToOption(),
                YBinGroup: YBinGroup.ToOption(),
                YBins: YBins.ToOption(),
                Marker: Marker.ToOption(),
                ContourLinesDash: ContourLinesDash.ToOption(),
                ContourLinesColor: ContourLinesColor.ToOption(),
                ContourLinesSmoothing: ContourLinesSmoothing.ToOption(),
                ContourLinesWidth: ContourLinesWidth.ToOption(),
                ContourLines: ContourLines.ToOption(),
                ShowContourLines: ShowContourLines.ToOption(),
                ContoursColoring: ContoursColoring.ToOption(),
                ContoursOperation: ContoursOperation.ToOption(),
                ContoursType: ContoursType.ToOption(),
                ShowContoursLabels: ShowContoursLabels.ToOption(),
                ContoursLabelFont: ContourLabelFont.ToOption(),
                ContoursStart: ContoursStart.ToOption(),
                ContoursEnd: ContoursEnd.ToOption(),
                Contours: Contours.ToOption(),
                ColorBar: ColorBar.ToOption(),
                ColorScale: ColorScale.ToOption(),
                ShowScale: ShowScale.ToOption(),
                ReverseScale: ReverseScale.ToOption(),
                NContours: NContours.ToOption(),
                UseDefaults: UseDefaults.ToOption()
            );
}
