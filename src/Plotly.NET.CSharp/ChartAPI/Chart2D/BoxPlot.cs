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
    /// Visualizes the distribution of the input data as a box plot.
    ///
    /// A box plot is a method for graphically demonstrating the locality, spread and skewness groups of numerical data through their quartiles.
    /// The default style is based on the five number summary: minimum, first quartile, median, third quartile, and maximum.
    ///
    /// The sample data from which statistics are computed is set in `x` for vertically spanning boxes and in `y` for horizontally spanning boxes.
    /// </summary>
    /// <param name="X">Sets the x sample data or coordinates</param>
    /// <param name="MultiX">Sets the x sample data or coordinates. Use two inner arrays here to plot multicategorial data</param>
    /// <param name="Y">Sets the y sample data or coordinates</param>
    /// <param name="MultiY">Sets the y sample data or coordinates. Use two inner arrays here to plot multicategorial data</param>
    /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
    /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
    /// <param name="Text">Sets a text associated with each datum</param>
    /// <param name="MultiText">Sets individual text for each datum</param>
    /// <param name="FillColor">Sets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
    /// <param name="MarkerColor">Sets the marker color.</param>
    /// <param name="Marker">Sets the marker for the box (use this for more finegrained control than the other marker-associated arguments).</param>// <param name="Opacity">Sets the opacity of this trace.</param>
    /// <param name="WhiskerWidth">Sets the width of the whiskers relative to the box' width. For example, with 1, the whiskers are as wide as the box(es).</param>
    /// <param name="BoxPoints">If "outliers", only the sample points lying outside the whiskers are shown If "suspectedoutliers", the outlier points are shown and points either less than 4"Q1-3"Q3 or greater than 4"Q3-3"Q1 are highlighted (see `outliercolor`) If "all", all sample points are shown If "false", only the box(es) are shown with no sample points Defaults to "suspectedoutliers" when `marker.outliercolor` or `marker.line.outliercolor` is set. Defaults to "all" under the q1/median/q3 signature. Otherwise defaults to "outliers".</param>
    /// <param name="BoxMean">If "true", the mean of the box(es)' underlying distribution is drawn as a dashed line inside the box(es). If "sd" the standard deviation is also drawn. Defaults to "true" when `mean` is set. Defaults to "sd" when `sd` is set Otherwise defaults to "false".</param>
    /// <param name="Jitter">Sets the amount of jitter in the sample points drawn. If "0", the sample points align along the distribution axis. If "1", the sample points are drawn in a random jitter of width equal to the width of the box(es).</param>
    /// <param name="PointPos">Sets the position of the sample points in relation to the box(es). If "0", the sample points are places over the center of the box(es). Positive (negative) values correspond to positions to the right (left) for vertical boxes and above (below) for horizontal boxes</param>
    /// <param name="Orientation">Sets the orientation of the box(es). If "v" ("h"), the distribution is visualized along the vertical (horizontal).</param>
    /// <param name="OutlineColor">Sets the color of the box outline</param>
    /// <param name="OutlineWidth">Sets the width of the box outline</param>
    /// <param name="Outline">Sets the box outline (use this for more finegrained control than the other outline-associated arguments).</param>
    /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
    /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
    /// <param name="Notched">Determines whether or not notches are drawn. Notches displays a confidence interval around the median. We compute the confidence interval as median +/- 1.57 " IQR / sqrt(N), where IQR is the interquartile range and N is the sample size. If two boxes' notches do not overlap there is 95% confidence their medians differ. See https://sites.google.com/site/davidsstatistics/home/notched-box-plots for more info. Defaults to "false" unless `notchwidth` or `notchspan` is set.</param>
    /// <param name="NotchWidth">Sets the width of the notches relative to the box' width. For example, with 0, the notches are as wide as the box(es).</param>
    /// <param name="QuartileMethod">Sets the method used to compute the sample's Q1 and Q3 quartiles. The "linear" method uses the 25th percentile for Q1 and 75th percentile for Q3 as computed using method #10 (listed on http://www.amstat.org/publications/jse/v14n3/langford.html). The "exclusive" method uses the median to divide the ordered dataset into two halves if the sample is odd, it does not include the median in either half - Q1 is then the median of the lower half and Q3 the median of the upper half. The "inclusive" method also uses the median to divide the ordered dataset into two halves but if the sample is odd, it includes the median in both halves - Q1 is then the median of the lower half and Q3 the median of the upper half.</param>
    /// <param name="SizeMode">Sets the upper and lower bound for the boxes quartiles means box is drawn between Q1 and Q3 SD means the box is drawn between Mean +- Standard Deviation Argument sdmultiple (default 1) to scale the box size So it could be drawn 1-stddev, 3-stddev etc</param>
    /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
    public static GenericChart BoxPlot<XType, YType, TextType>(
        Optional<IEnumerable<XType>> X = default,
        Optional<IEnumerable<IEnumerable<XType>>> MultiX = default,
        Optional<IEnumerable<YType>> Y = default,
        Optional<IEnumerable<IEnumerable<YType>>> MultiY = default,
        Optional<string> Name = default, 
        Optional<bool> ShowLegend = default, 
        Optional<TextType> Text = default, 
        Optional<IEnumerable<TextType>> MultiText = default, 
        Optional<Color> FillColor = default, 
        Optional<Color> MarkerColor = default, 
        Optional<Marker> Marker = default, 
        Optional<double> Opacity = default, 
        Optional<double> WhiskerWidth = default, 
        Optional<StyleParam.BoxPoints> BoxPoints = default, 
        Optional<StyleParam.BoxMean> BoxMean = default, 
        Optional<double> Jitter = default, 
        Optional<double> PointPos = default, 
        Optional<StyleParam.Orientation> Orientation = default, 
        Optional<Color> OutlineColor = default, 
        Optional<double> OutlineWidth = default, 
        Optional<Line> Outline = default, 
        Optional<string> AlignmentGroup = default, 
        Optional<string> OffsetGroup = default, 
        Optional<bool> Notched = default, 
        Optional<double> NotchWidth = default, 
        Optional<StyleParam.QuartileMethod> QuartileMethod = default,
        Optional<StyleParam.BoxSizeMode> SizeMode = default,
        Optional<bool> UseDefaults = default
    )
        where XType : IConvertible
        where YType : IConvertible
        where TextType : IConvertible
        =>
            Plotly.NET.Chart2D_Distribution.Chart.BoxPlot<XType, YType, TextType>(
                X: X.ToOption(),
                MultiX: MultiX.ToOption(),
                Y: Y.ToOption(),
                MultiY: MultiY.ToOption(),
                Name: Name.ToOption(),
                ShowLegend: ShowLegend.ToOption(),
                Text: Text.ToOption(),
                MultiText: MultiText.ToOption(),
                FillColor: FillColor.ToOption(),
                MarkerColor: MarkerColor.ToOption(),
                Marker: Marker.ToOption(),
                Opacity: Opacity.ToOption(),
                WhiskerWidth: WhiskerWidth.ToOption(),
                BoxPoints: BoxPoints.ToOption(),
                BoxMean: BoxMean.ToOption(),
                Jitter: Jitter.ToOption(),
                PointPos: PointPos.ToOption(),
                Orientation: Orientation.ToOption(),
                OutlineColor: OutlineColor.ToOption(),
                OutlineWidth: OutlineWidth.ToOption(),
                Outline: Outline.ToOption(),
                AlignmentGroup: AlignmentGroup.ToOption(),
                OffsetGroup: OffsetGroup.ToOption(),
                Notched: Notched.ToOption(),
                NotchWidth: NotchWidth.ToOption(),
                QuartileMethod: QuartileMethod.ToOption(),
                SizeMode: SizeMode.ToOption(),
                UseDefaults: UseDefaults.ToOption()
            );
}
