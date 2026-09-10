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
    /// Creates a waterfall chart.
    ///
    /// Waterfall charts are special bar charts that help visualizing the cumulative effect of sequentially introduced positive or negative values
    /// </summary>
    /// <param name="x">Sets the x coordinates of the plotted data.</param>
    /// <param name="y">Sets the y coordinates of the plotted data.</param>
    /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
    /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
    /// <param name="IncreasingColor">Sets the color of increasing values</param>
    /// <param name="Increasing">Sets the style options of increasing values (use this for more finegrained control than the other increasing-associated arguments).</param>
    /// <param name="DecreasingColor">Sets the color of decreasing values</param>
    /// <param name="Decreasing">Sets the style options of decreasing values (use this for more finegrained control than the other increasing-associated arguments).</param>
    /// <param name="TotalsColor">Sets the color of total values</param>
    /// <param name="Totals">Sets the style options of total values (use this for more finegrained control than the other increasing-associated arguments).</param>
    /// <param name="Base">Sets where the bar base is drawn (in position axis units).</param>
    /// <param name="Width">Sets the bar width (in position axis units).</param>
    /// <param name="MultiWidth">Sets the individual bar width of each datum (in position axis units).</param>
    /// <param name="Opacity">Sets the opacity of the trace.</param>
    /// <param name="Text">Sets a text associated with each datum</param>
    /// <param name="MultiText">Sets individual text for each datum</param>
    /// <param name="TextPosition">Sets the position of text associated with each datum</param>
    /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
    /// <param name="TextFont">Sets the font used for `text`.</param>
    /// <param name="Connector">Sets the waterfall connector of this trace</param>
    /// <param name="Measure">An array containing types of measures. By default the values are considered as 'relative'. However; it is possible to use 'total' to compute the sums. Also 'absolute' could be applied to reset the computed total or to declare an initial value where needed.</param>
    /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
    /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
    /// <param name="Orientation">Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used - including if `visible` is "legendonly" but not if it is `false`. Sets the stacking direction. With "v" ("h"), the y (x) values of subsequent traces are added. Also affects the default value of `fill`.</param>
    /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
    public static GenericChart Waterfall<XType, YType, TextType>(
        IEnumerable<XType> x,
        IEnumerable<YType> y,
        Optional<string> Name = default,
        Optional<bool> ShowLegend = default,
        Optional<Color> IncreasingColor = default,
        Optional<FinanceMarker> Increasing = default,
        Optional<Color> DecreasingColor = default,
        Optional<FinanceMarker> Decreasing = default,
        Optional<Color> TotalsColor = default,
        Optional<FinanceMarker> Totals = default,
        Optional<double> Base = default,
        Optional<double> Width = default,
        Optional<IEnumerable<double>> MultiWidth = default,
        Optional<double> Opacity = default,
        Optional<TextType> Text = default,
        Optional<IEnumerable<TextType>> MultiText = default,
        Optional<StyleParam.TextPosition> TextPosition = default,
        Optional<IEnumerable<StyleParam.TextPosition>> MultiTextPosition = default,
        Optional<Font> TextFont = default,
        Optional<WaterfallConnector> Connector = default,
        Optional<IEnumerable<StyleParam.WaterfallMeasure>> Measure = default,
        Optional<string> AlignmentGroup = default,
        Optional<string> OffsetGroup = default,
        Optional<StyleParam.Orientation> Orientation = default,
        Optional<bool> UseDefaults = default
    )
        where XType : IConvertible
        where YType : IConvertible
        where TextType : IConvertible
        =>
            Plotly.NET.Chart2D_Funnel.Chart.Waterfall<XType, YType, TextType>(
                x: x,
                y: y,
                Name: Name.ToOption(),
                ShowLegend: ShowLegend.ToOption(),
                IncreasingColor: IncreasingColor.ToOption(),
                Increasing: Increasing.ToOption(),
                DecreasingColor: DecreasingColor.ToOption(),
                Decreasing: Decreasing.ToOption(),
                TotalsColor: TotalsColor.ToOption(),
                Totals: Totals.ToOption(),
                Base: Base.ToOption(),
                Width: Width.ToOption(),
                MultiWidth: MultiWidth.ToOption(),
                Opacity: Opacity.ToOption(),
                Text: Text.ToOption(),
                MultiText: MultiText.ToOption(),
                TextPosition: TextPosition.ToOption(),
                MultiTextPosition: MultiTextPosition.ToOption(),
                TextFont: TextFont.ToOption(),
                Connector: Connector.ToOption(),
                Measure: Measure.ToOption(),
                AlignmentGroup: AlignmentGroup.ToOption(),
                OffsetGroup: OffsetGroup.ToOption(),
                Orientation: Orientation.ToOption(),
                UseDefaults: UseDefaults.ToOption()
            );
}
