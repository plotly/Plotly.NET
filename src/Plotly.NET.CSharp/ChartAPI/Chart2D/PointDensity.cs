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
    /// Creates a point density plot - a combination of a Scatter plot and Histogram2DContour.
    ///
    /// Additionally to plotting the (x,y) data as points on a 2D plane, a density contour plot is computed by grouping a set of points specified by their x and y coordinates into bins, and applying a count aggregation function to compute the value to be used to compute contours.
    /// The sample data from which statistics are computed is set in `x` and `y` (where `x` and `y` represent marginal distributions, binning is set in `xbins` and `ybins` in this case). The resulting distribution is visualized as a contour plot.
    ///
    /// </summary>
    /// <param name="x">Sets the x coordinates of the plotted data as well as the sample data to be binned on the x axis.</param>
    /// <param name="y">Sets the y coordinates of the plotted data as well as the sample data to be binned on the y axis.</param>
    /// <param name="PointOpacity">Sets the opacity of the point trace.</param>
    /// <param name="PointMarkerColor">Sets the marker color of the point trace.</param>
    /// <param name="PointMarkerSymbol">Sets the marker symbol of the point trace.</param>
    /// <param name="PointMarkerSize">Sets the marker size of the point trace.</param>
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
    /// <param name="NContours">Sets the maximum number of contour levels. The actual number of contours will be chosen automatically to be less than or equal to the value of `ncontours`. Has an effect only if `autocontour` is "true" or if `contours.size` is missing.</param>
    /// <param name="HistNorm">Specifies the type of normalization used for this histogram trace. If "", the span of each bar corresponds to the number of occurrences (i.e. the number of data points lying inside the bins). If "percent" / "probability", the span of each bar corresponds to the percentage / fraction of occurrences with respect to the total number of sample points (here, the sum of all bin HEIGHTS equals 100% / 1). If "density", the span of each bar corresponds to the number of occurrences in a bin divided by the size of the bin interval (here, the sum of all bin AREAS equals the total number of sample points). If "probability density", the area of each bar corresponds to the probability that an event will fall into the corresponding bin (here, the sum of all bin AREAS equals 1).</param>
    /// <param name="ContourOpacity">Sets the opacity of the histogram2dcontour trace.</param>
    /// <param name="ColorBar">Sets the color bar.</param>
    /// <param name="ColorScale">Sets the colorscale of the histogram2dcontour trace.</param>
    /// <param name="ShowScale">whether or not to show the colorbar</param>
    /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
    public static GenericChart PointDensity<XType, YType>(
        IEnumerable<XType> x,
        IEnumerable<YType> y, 
        Optional<double> PointOpacity = default, 
        Optional<Color> PointMarkerColor = default, 
        Optional<StyleParam.MarkerSymbol> PointMarkerSymbol = default, 
        Optional<int> PointMarkerSize = default,
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
        Optional<int> NContours = default,
        Optional<StyleParam.HistNorm> HistNorm = default,
        Optional<double> ContourOpacity = default,
        Optional<ColorBar> ColorBar = default, 
        Optional<StyleParam.Colorscale> ColorScale = default, 
        Optional<bool> ShowScale = default, 
        Optional<bool> UseDefaults = default
    )
        where XType : IConvertible
        where YType : IConvertible
        =>
            Plotly.NET.Chart2D_Splom.Chart.PointDensity<XType, YType>(
                x: x,
                y: y,
                PointOpacity: PointOpacity.ToOption(),
                PointMarkerColor: PointMarkerColor.ToOption(),
                PointMarkerSymbol: PointMarkerSymbol.ToOption(),
                PointMarkerSize: PointMarkerSize.ToOption(),
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
                NContours: NContours.ToOption(),
                HistNorm: HistNorm.ToOption(),
                ContourOpacity: ContourOpacity.ToOption(),
                ColorBar: ColorBar.ToOption(),
                ColorScale: ColorScale.ToOption(),
                ShowScale: ShowScale.ToOption(),
                UseDefaults: UseDefaults.ToOption()
            );
}
