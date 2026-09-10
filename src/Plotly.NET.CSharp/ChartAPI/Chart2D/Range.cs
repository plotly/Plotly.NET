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
    /// Displays a range of data by plotting three Y values per data point (upper, mid, lower).
    ///
    /// The mid Y value usually resembles some kind of central tendency and the upper/lower Y values some kind of spread.
    /// </summary>
    /// <param name="x">Sets the x coordinates of the plotted data.</param>
    /// <param name="y">Sets the y coordinates of the plotted data for the mid Y value.</param>
    /// <param name="upper">Sets the y coordinates of the plotted data for the upper Y value.</param>
    /// <param name="lower">Sets the y coordinates of the plotted data for the lower Y value.</param>
    /// <param name="mode">Determines the drawing mode for this scatter trace.</param>
    /// <param name="Name">Sets the trace name of the mid Y values. The trace name appear as the legend item and on hover</param>
    /// <param name="GroupName">Sets the name of the legendgroup for the three traces of this plot.</param>
    /// <param name="ShowMarkers">Determines whether or not an To show markers for each datum.</param>
    /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
    /// <param name="Text">Sets a text associated with each datum for the mid Y values.</param>
    /// <param name="MultiText">Sets individual text for each datum for the mid Y values.</param>
    /// <param name="TextPosition">Sets the position of text associated with each datum</param>
    /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
    /// <param name="MarkerColor">Sets the color of the marker for the mid Y values.</param>
    /// <param name="MarkerColorScale">Sets the colorscale of the marker for the mid Y values.</param>
    /// <param name="MarkerOutline">Sets the outline of the marker for the mid Y values.</param>
    /// <param name="MarkerSymbol">Sets the marker symbol for each datum for the mid Y values.</param>
    /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum for the mid Y values.</param>
    /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments) for the mid Y values.</param>
    /// <param name="LineColor">Sets the color of the line for the mid Y values.</param>
    /// <param name="LineColorScale">Sets the colorscale of the line for the mid Y values.</param>
    /// <param name="LineWidth">Sets the width of the line for the mid Y values.</param>
    /// <param name="LineDash">sets the drawing style of the line for the mid Y values.</param>
    /// <param name="Line">Sets the line (use this for more finegrained control than the other line-associated arguments) for the mid Y values.</param>
    /// <param name="RangeColor">Sets the color of the range between upper and lower Y values.</param>
    /// <param name="RangePattern">Sets the pattern of the range between upper and lower Y values.</param>
    /// <param name="UpperText">Sets a text associated with each datum for the upper Y values.</param>
    /// <param name="MultiUpperText">Sets individual text for each datum for the upper Y values.</param>
    /// <param name="LowerText">Sets a text associated with each datum for the lower Y values.</param>
    /// <param name="MultiLowerText">Sets individual text for each datum for the lower Y values.</param>
    /// <param name="TextFont">Sets the text font for all Text items</param>
    /// <param name="LowerName">Sets the name of the lower Y value trace.</param>
    /// <param name="LowerLine">Sets the line for the lower Y values.</param>
    /// <param name="LowerMarker">Sets the marker for the lower Y values.</param>
    /// <param name="UpperName">Sets the name of the uper Y value trace.</param>
    /// <param name="UpperLine">Sets the line for the upper Y values.</param>
    /// <param name="UpperMarker">Sets the marker for the upper Y values.</param>
    /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
    public static GenericChart Range<XType, YType, TextType>(
        IEnumerable<XType> x,
        IEnumerable<YType> y,
        IEnumerable<YType> upper,
        IEnumerable<YType> lower,
        StyleParam.Mode mode,
        Optional<string> Name = default,
        Optional<string> GroupName = default,
        Optional<bool> ShowMarkers = default,
        Optional<bool> ShowLegend = default,
        Optional<TextType> Text = default,
        Optional<IEnumerable<TextType>> MultiText = default,
        Optional<StyleParam.TextPosition> TextPosition = default,
        Optional<IEnumerable<StyleParam.TextPosition>> MultiTextPosition = default,
        Optional<Color> MarkerColor = default,
        Optional<StyleParam.Colorscale> MarkerColorScale = default,
        Optional<Line> MarkerOutline = default,
        Optional<StyleParam.MarkerSymbol> MarkerSymbol = default,
        Optional<IEnumerable<StyleParam.MarkerSymbol>> MultiMarkerSymbol = default,
        Optional<Marker> Marker = default,
        Optional<Marker> UpperMarker = default,
        Optional<Marker> LowerMarker = default,
        Optional<Color> LineColor = default,
        Optional<StyleParam.Colorscale> LineColorScale = default,
        Optional<double> LineWidth = default,
        Optional<StyleParam.DrawingStyle> LineDash = default,
        Optional<Line> Line = default,
        Optional<Line> UpperLine = default,
        Optional<Line> LowerLine = default,
        Optional<Color> RangeColor = default,
        Optional<Pattern> RangePattern = default,
        Optional<TextType> UpperText = default,
        Optional<IEnumerable<TextType>> MultiUpperText = default,
        Optional<TextType> LowerText = default,
        Optional<IEnumerable<TextType>> MultiLowerText = default,
        Optional<Font> TextFont = default,
        Optional<string> LowerName = default,
        Optional<string> UpperName = default,
        Optional<bool> UseDefaults = default
    )
        where XType : IConvertible
        where YType : IConvertible
        where TextType : IConvertible
        =>
            Plotly.NET.Chart2D_Scatter.Chart.Range<XType, YType, YType, YType, TextType, TextType, TextType>(
                x: x,
                y: y,
                upper: upper,
                lower: lower,
                mode: mode,
                Name: Name.ToOption(),
                GroupName: GroupName.ToOption(),
                ShowMarkers: ShowMarkers.ToOption(),
                ShowLegend: ShowLegend.ToOption(),
                Text: Text.ToOption(),
                MultiText: MultiText.ToOption(),
                TextPosition: TextPosition.ToOption(),
                MultiTextPosition: MultiTextPosition.ToOption(),
                MarkerColor: MarkerColor.ToOption(),
                MarkerColorScale: MarkerColorScale.ToOption(),
                MarkerOutline: MarkerOutline.ToOption(),
                MarkerSymbol: MarkerSymbol.ToOption(),
                MultiMarkerSymbol: MultiMarkerSymbol.ToOption(),
                Marker: Marker.ToOption(),
                UpperMarker: UpperMarker.ToOption(),
                LowerMarker: LowerMarker.ToOption(),
                LineColor: LineColor.ToOption(),
                LineColorScale: LineColorScale.ToOption(),
                LineWidth: LineWidth.ToOption(),
                LineDash: LineDash.ToOption(),
                Line: Line.ToOption(),
                UpperLine: UpperLine.ToOption(),
                LowerLine: LowerLine.ToOption(),
                RangeColor: RangeColor.ToOption(),
                RangePattern: RangePattern.ToOption(),
                UpperText: UpperText.ToOption(),
                MultiUpperText: MultiUpperText.ToOption(),
                LowerText: LowerText.ToOption(),
                MultiLowerText: MultiLowerText.ToOption(),
                TextFont: TextFont.ToOption(),
                LowerName: LowerName.ToOption(),
                UpperName: UpperName.ToOption(),
                UseDefaults: UseDefaults.ToOption()
            );
}
