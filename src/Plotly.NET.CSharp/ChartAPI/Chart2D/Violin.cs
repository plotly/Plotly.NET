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
    /// Visualizes the distribution of the input data as a violin plot.
    ///
    /// A violin plot is a method of plotting numeric data. It is similar to a box plot, except that they also show the probability density of the data at different values, usually smoothed by a kernel density estimator.
    ///
    /// In vertical (horizontal) violin plots, statistics are computed using `y` (`x`) values. By supplying an `x` (`y`) array, one violin per distinct x (y) value is drawn If no `x` (`y`) array is provided, a single violin is drawn. That violin position is then positioned with with `name` or with `x0` (`y0`) if provided.
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
    /// <param name="Opacity">Sets the Opacity otf the trace.</param>
    /// <param name="Points">If "outliers", only the sample points lying outside the whiskers are shown If "suspectedoutliers", the outlier points are shown and points either less than 4"Q1-3"Q3 or greater than 4"Q3-3"Q1 are highlighted (see `outliercolor`) If "all", all sample points are shown If "false", only the violins are shown with no sample points. Defaults to "suspectedoutliers" when `marker.outliercolor` or `marker.line.outliercolor` is set, otherwise defaults to "outliers".</param>
    /// <param name="Jitter">Sets the amount of jitter in the sample points drawn. If "0", the sample points align along the distribution axis. If "1", the sample points are drawn in a random jitter of width equal to the width of the box(es).</param>
    /// <param name="PointPos">Sets the position of the sample points in relation to the box(es). If "0", the sample points are places over the center of the box(es). Positive (negative) values correspond to positions to the right (left) for vertical boxes and above (below) for horizontal boxes</param>
    /// <param name="Orientation">Sets the orientation of the violin(s). If "v" ("h"), the distribution is visualized along the vertical (horizontal).</param>
    /// <param name="Width">Sets the width of the violin in data coordinates. If "0" (default value) the width is automatically selected based on the positions of other violin traces in the same subplot.</param>
    /// <param name="MarkerColor">Sets the marker color.</param>
    /// <param name="Marker">Sets the marker for the violin (use this for more finegrained control than the other marker-associated arguments).</param>
    /// <param name="OutlineColor">Sets the color of the box outline</param>
    /// <param name="OutlineWidth">Sets the width of the box outline</param>
    /// <param name="Outline">Sets the box outline (use this for more finegrained control than the other outline-associated arguments).</param>
    /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
    /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
    /// <param name="ShowBox">Whether and how to draw a miniature box plot</param>
    /// <param name="BoxWidth">Sets the width of the miniature box plot</param>
    /// <param name="BoxFillColor">Sets the fill color of the miniature box plot</param>
    /// <param name="Box">Sets the styles of the miniature box plot (use this for more finegrained control than the other box-associated arguments)</param>
    /// <param name="BandWidth">Sets the bandwidth used to compute the kernel density estimate. By default, the bandwidth is determined by Silverman's rule of thumb.</param>
    /// <param name="MeanLine">Whether and how to draw the meanline</param>
    /// <param name="ScaleGroup">If there are multiple violins that should be sized according to to some metric (see `scalemode`), link them by providing a non-empty group id here shared by every trace in the same group. If a violin's `width` is undefined, `scalegroup` will default to the trace's name. In this case, violins with the same names will be linked together</param>
    /// <param name="ScaleMode">Sets the metric by which the width of each violin is determined."width" means each violin has the same (max) width"count" means the violins are scaled by the number of sample points makingup each violin.</param>
    /// <param name="Side">Determines on which side of the position value the density function making up one half of a violin is plotted. Useful when comparing two violin traces under "overlay" mode, where one trace has `side` set to "positive" and the other to "negative".</param>
    /// <param name="Span">Sets the span in data space for which the density function will be computed. Has an effect only when `spanmode` is set to "manual".</param>
    /// <param name="SpanMode">Sets the method by which the span in data space where the density function will be computed. "soft" means the span goes from the sample's minimum value minus two bandwidths to the sample's maximum value plus two bandwidths. "hard" means the span goes from the sample's minimum to its maximum value. For custom span settings, use mode "manual" and fill in the `span` attribute.</param>
    /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
    public static GenericChart Violin<XType, YType, TextType>(
        Optional<IEnumerable<XType>> X = default,
        Optional<IEnumerable<IEnumerable<XType>>> MultiX = default,
        Optional<IEnumerable<YType>> Y = default,
        Optional<IEnumerable<IEnumerable<YType>>> MultiY = default,
        Optional<string> Name = default,
        Optional<bool> ShowLegend = default,
        Optional<TextType> Text = default,
        Optional<IEnumerable<TextType>> MultiText = default,
        Optional<Color> FillColor = default,
        Optional<double> Opacity = default,
        Optional<StyleParam.BoxPoints> Points = default,
        Optional<double> Jitter = default,
        Optional<double> PointPos = default,
        Optional<StyleParam.Orientation> Orientation = default,
        Optional<double> Width = default,
        Optional<Color> MarkerColor = default,
        Optional<Marker> Marker = default,
        Optional<Color> OutlineColor = default,
        Optional<double> OutlineWidth = default,
        Optional<Line> Outline = default,
        Optional<string> AlignmentGroup = default,
        Optional<string> OffsetGroup = default,
        Optional<bool> ShowBox = default,
        Optional<double> BoxWidth = default,
        Optional<Color> BoxFillColor = default,
        Optional<Box> Box = default,
        Optional<double> BandWidth = default,
        Optional<MeanLine> MeanLine = default,
        Optional<string> ScaleGroup = default,
        Optional<StyleParam.ScaleMode> ScaleMode = default,
        Optional<StyleParam.ViolinSide> Side = default,
        Optional<StyleParam.Range> Span = default,
        Optional<StyleParam.SpanMode> SpanMode = default,
        Optional<bool> UseDefaults = default
    )
        where XType : IConvertible
        where YType : IConvertible
        where TextType : IConvertible
        =>
            Plotly.NET.Chart2D_Distribution.Chart.Violin<XType, YType, TextType>(
                X: X.ToOption(),
                MultiX: MultiX.ToOption(),
                Y: Y.ToOption(),
                MultiY: MultiY.ToOption(),
                Name: Name.ToOption(),
                ShowLegend: ShowLegend.ToOption(),
                Text: Text.ToOption(),
                MultiText: MultiText.ToOption(),
                FillColor: FillColor.ToOption(),
                Opacity: Opacity.ToOption(),
                Points: Points.ToOption(),
                Jitter: Jitter.ToOption(),
                PointPos: PointPos.ToOption(),
                Orientation: Orientation.ToOption(),
                Width: Width.ToOption(),
                MarkerColor: MarkerColor.ToOption(),
                Marker: Marker.ToOption(),
                OutlineColor: OutlineColor.ToOption(),
                OutlineWidth: OutlineWidth.ToOption(),
                Outline: Outline.ToOption(),
                AlignmentGroup: AlignmentGroup.ToOption(),
                OffsetGroup: OffsetGroup.ToOption(),
                ShowBox: ShowBox.ToOption(),
                BoxWidth: BoxWidth.ToOption(),
                BoxFillColor: BoxFillColor.ToOption(),
                Box: Box.ToOption(),
                BandWidth: BandWidth.ToOption(),
                MeanLine: MeanLine.ToOption(),
                ScaleGroup: ScaleGroup.ToOption(),
                ScaleMode: ScaleMode.ToOption(),
                Side: Side.ToOption(),
                Span: Span.ToOption(),
                SpanMode: SpanMode.ToOption(),
                UseDefaults: UseDefaults.ToOption()
            );
}
