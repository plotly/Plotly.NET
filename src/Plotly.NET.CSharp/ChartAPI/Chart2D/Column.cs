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
    /// Creates a column chart, with bars plotted vertically
    ///
    /// A column chart is a chart that presents categorical data with rectangular bars with heights or lengths proportional to the values that they represent.
    /// </summary>
    /// <param name="values">Sets the values that are plotted as the size of each bar.</param>
    /// <param name="Keys">Sets the keys associated with each bar.</param>
    /// <param name="MultiKeys">Sets the keys associated with each bar. Use two inner arrays here to plot multicategorial data</param>
    /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
    /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
    /// <param name="Opacity">Sets the Opacity of the trace.</param>
    /// <param name="MultiOpacity">Sets the Opacity of each individual bar.</param>
    /// <param name="Text">Sets a text associated with each datum</param>
    /// <param name="MultiText">Sets individual text for each datum</param>
    /// <param name="MarkerColor">Sets the color of the bars</param>
    /// <param name="MarkerColorScale">Sets the colorscale for the bars. To have an effect, `MarkerColor` must map to color scale values.</param>
    /// <param name="MarkerOutline">Sets the color of the bar outlines</param>
    /// <param name="MarkerPatternShape">Sets a pattern shape for all bars</param>
    /// <param name="MultiMarkerPatternShape">Sets an individual pattern shape for each bar</param>
    /// <param name="MarkerPattern">Sets the marker pattern (use this for more finegrained control than the other pattern-associated arguments).</param>
    /// <param name="Marker">Sets the marker for the bars (use this for more finegrained control than the other marker-associated arguments).</param>
    /// <param name="Base">Sets where the bar base is drawn (in position axis units).</param>
    /// <param name="Width">Sets the bar width (in position axis units) of all bars.</param>
    /// <param name="MultiWidth">Sets the individual bar width (in position axis units) for each bar.</param>
    /// <param name="TextPosition">Sets the position of text associated with each datum</param>
    /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
    /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
    public static GenericChart Column<ValuesType, KeysType, TextType>(
        IEnumerable<ValuesType> values,
        Optional<IEnumerable<KeysType>> Keys = default,
        Optional<IEnumerable<IEnumerable<KeysType>>> MultiKeys = default,
        Optional<string> Name = default,
        Optional<bool> ShowLegend = default,
        Optional<double> Opacity = default,
        Optional<IEnumerable<double>> MultiOpacity = default,
        Optional<TextType> Text = default,
        Optional<IEnumerable<TextType>> MultiText = default,
        Optional<Color> MarkerColor = default,
        Optional<StyleParam.Colorscale> MarkerColorScale = default,
        Optional<Line> MarkerOutline = default,
        Optional<StyleParam.PatternShape> MarkerPatternShape = default,
        Optional<IEnumerable<StyleParam.PatternShape>> MultiMarkerPatternShape = default,
        Optional<Pattern> MarkerPattern = default,
        Optional<Marker> Marker = default,
        Optional<StyleParam.TextPosition> TextPosition = default,
        Optional<IEnumerable<StyleParam.TextPosition>> MultiTextPosition = default,
        Optional<IEnumerable<ValuesType>> MultiWidth = default,
        Optional<bool> UseDefaults = default,
        Optional<ValuesType> Base = default,
        Optional<ValuesType> Width = default
    )
        where ValuesType : IConvertible
        where KeysType : IConvertible
        where TextType : IConvertible
        =>
            Plotly.NET.Chart2D_Bar.Chart.Column<ValuesType, KeysType, TextType, ValuesType, ValuesType>(
                values: values,
                Keys: Keys.ToOption(),
                MultiKeys: MultiKeys.ToOption(),
                Name: Name.ToOption(),
                ShowLegend: ShowLegend.ToOption(),
                Opacity: Opacity.ToOption(),
                MultiOpacity: MultiOpacity.ToOption(),
                Text: Text.ToOption(),
                MultiText: MultiText.ToOption(),
                MarkerColor: MarkerColor.ToOption(),
                MarkerColorScale: MarkerColorScale.ToOption(),
                MarkerOutline: MarkerOutline.ToOption(),
                MarkerPatternShape: MarkerPatternShape.ToOption(),
                MultiMarkerPatternShape: MultiMarkerPatternShape.ToOption(),
                MarkerPattern: MarkerPattern.ToOption(),
                Marker: Marker.ToOption(),
                Base: Base.ToOption(),
                Width: Width.ToOption(),
                MultiWidth: MultiWidth.ToOption(),
                TextPosition: TextPosition.ToOption(),
                MultiTextPosition: MultiTextPosition.ToOption(),
                UseDefaults: UseDefaults.ToOption()
            );

    /// <summary>Creates a column chart from encoded values, with bars plotted vertically.</summary>
    /// <param name="valuesEncoded">Sets the bar lengths as an encoded typed array.</param>
    /// <param name="KeysEncoded">Sets the bar keys as an encoded typed array.</param>
    /// <param name="Base">Sets where the bar base is drawn (in position axis units).</param>
    /// <param name="Width">Sets the bar width (in position axis units) of all bars.</param>
    /// <param name="UseDefaults">If set to false, ignore the global default settings set in <c>Defaults</c></param>
    public static GenericChart Column<TextType, BaseType, WidthType>(
        EncodedTypedArray valuesEncoded,
        Optional<EncodedTypedArray> KeysEncoded = default,
        Optional<string> Name = default,
        Optional<bool> ShowLegend = default,
        Optional<double> Opacity = default,
        Optional<IEnumerable<double>> MultiOpacity = default,
        Optional<TextType> Text = default,
        Optional<IEnumerable<TextType>> MultiText = default,
        Optional<Color> MarkerColor = default,
        Optional<StyleParam.Colorscale> MarkerColorScale = default,
        Optional<Line> MarkerOutline = default,
        Optional<StyleParam.PatternShape> MarkerPatternShape = default,
        Optional<IEnumerable<StyleParam.PatternShape>> MultiMarkerPatternShape = default,
        Optional<Pattern> MarkerPattern = default,
        Optional<Marker> Marker = default,
        Optional<BaseType> Base = default,
        Optional<WidthType> Width = default,
        Optional<EncodedTypedArray> MultiWidthEncoded = default,
        Optional<StyleParam.TextPosition> TextPosition = default,
        Optional<IEnumerable<StyleParam.TextPosition>> MultiTextPosition = default,
        Optional<bool> UseDefaults = default
    )
        where TextType : IConvertible
        where BaseType : IConvertible
        where WidthType : IConvertible
        =>
            Plotly.NET.Chart2D_Bar.Chart.Column(
                valuesEncoded: valuesEncoded,
                KeysEncoded: KeysEncoded.ToOption(),
                Name: Name.ToOption(),
                ShowLegend: ShowLegend.ToOption(),
                Opacity: Opacity.ToOption(),
                MultiOpacity: MultiOpacity.ToOption(),
                Text: Text.ToOption(),
                MultiText: MultiText.ToOption(),
                MarkerColor: MarkerColor.ToOption(),
                MarkerColorScale: MarkerColorScale.ToOption(),
                MarkerOutline: MarkerOutline.ToOption(),
                MarkerPatternShape: MarkerPatternShape.ToOption(),
                MultiMarkerPatternShape: MultiMarkerPatternShape.ToOption(),
                MarkerPattern: MarkerPattern.ToOption(),
                Marker: Marker.ToOption(),
                Base: Base.ToOption(),
                Width: Width.ToOption(),
                MultiWidthEncoded: MultiWidthEncoded.ToOption(),
                TextPosition: TextPosition.ToOption(),
                MultiTextPosition: MultiTextPosition.ToOption(),
                UseDefaults: UseDefaults.ToOption()
            );
}
