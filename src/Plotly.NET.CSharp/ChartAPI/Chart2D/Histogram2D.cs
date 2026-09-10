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
    public static GenericChart Histogram2D<XType, YType, ZType>(
        IEnumerable<XType> x,
        IEnumerable<YType> y,
        Optional<IEnumerable<IEnumerable<ZType>>> Z = default,
        Optional<string> Name = default,
        Optional<bool> ShowLegend = default,
        Optional<double> Opacity = default,
        Optional<int> XGap = default,
        Optional<int> YGap = default,
        Optional<StyleParam.HistFunc> HistFunc = default,
        Optional<StyleParam.HistNorm> HistNorm = default,
        Optional<int> NBinsX = default,
        Optional<int> NBinsY = default,
        Optional<Bins> XBins = default,
        Optional<Bins> YBins = default,
        Optional<ColorBar> ColorBar = default,
        Optional<StyleParam.Colorscale> ColorScale = default,
        Optional<bool> ShowScale = default,
        Optional<bool> ReverseScale = default,
        Optional<StyleParam.SmoothAlg> ZSmooth = default,
        Optional<bool> UseDefaults = default
    )
        where XType : IConvertible
        where YType : IConvertible
        where ZType : IConvertible
        =>
            Plotly.NET.Chart2D_Histogram.Chart.Histogram2D<XType, YType, IEnumerable<ZType>, ZType>(
                x: x,
                y: y,
                Z: Z.ToOption(),
                Name: Name.ToOption(),
                ShowLegend: ShowLegend.ToOption(),
                Opacity: Opacity.ToOption(),
                XGap: XGap.ToOption(),
                YGap: YGap.ToOption(),
                HistFunc: HistFunc.ToOption(),
                HistNorm: HistNorm.ToOption(),
                NBinsX: NBinsX.ToOption(),
                NBinsY: NBinsY.ToOption(),
                XBins: XBins.ToOption(),
                YBins: YBins.ToOption(),
                ColorBar: ColorBar.ToOption(),
                ColorScale: ColorScale.ToOption(),
                ShowScale: ShowScale.ToOption(),
                ReverseScale: ReverseScale.ToOption(),
                ZSmooth: ZSmooth.ToOption(),
                UseDefaults: UseDefaults.ToOption()
            );
}
