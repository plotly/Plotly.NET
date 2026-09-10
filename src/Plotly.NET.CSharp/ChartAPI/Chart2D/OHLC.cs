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
    public static GenericChart OHLC<OHLCType, XType, TextType>(
        IEnumerable<OHLCType> open,
        IEnumerable<OHLCType> high,
        IEnumerable<OHLCType> low,
        IEnumerable<OHLCType> close,
        Optional<IEnumerable<XType>> X,
        Optional<IEnumerable<IEnumerable<XType>>> MultiX,
        Optional<string> Name = default,
        Optional<bool> ShowLegend = default,
        Optional<double> Opacity = default,
        Optional<TextType> Text = default,
        Optional<IEnumerable<TextType>> MultiText = default,
        Optional<Line> Line = default,
        Optional<Color> IncreasingColor = default,
        Optional<FinanceMarker> Increasing = default,
        Optional<Color> DecreasingColor = default,
        Optional<FinanceMarker> Decreasing = default,
        Optional<double> TickWidth = default,
        Optional<bool> ShowXAxisRangeSlider = default,
        Optional<bool> UseDefaults = default
    )
        where OHLCType : IConvertible
        where XType : IConvertible
        where TextType : IConvertible
        =>
            Plotly.NET.Chart2D_Finance.Chart.OHLC<OHLCType, OHLCType, OHLCType, OHLCType, XType, TextType>(
                open: open,
                high: high,
                low: low,
                close: close,
                X: X.ToOption(),
                MultiX: MultiX.ToOption(),
                Name: Name.ToOption(),
                ShowLegend: ShowLegend.ToOption(),
                Opacity: Opacity.ToOption(),
                Text: Text.ToOption(),
                MultiText: MultiText.ToOption(),
                Line: Line.ToOption(),
                IncreasingColor: IncreasingColor.ToOption(),
                Increasing: Increasing.ToOption(),
                DecreasingColor: DecreasingColor.ToOption(),
                Decreasing: Decreasing.ToOption(),
                TickWidth: TickWidth.ToOption(),
                ShowXAxisRangeSlider: ShowXAxisRangeSlider.ToOption(),
                UseDefaults: UseDefaults.ToOption()
            );
}
