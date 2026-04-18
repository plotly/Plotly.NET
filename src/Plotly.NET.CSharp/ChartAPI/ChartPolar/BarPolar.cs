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
        /// Creates a polar bar chart.
        ///
        /// A polar bar chart is a chart that presents categorical data on a polar coordinate system with bars with radial height proportional to the values that they represent.
        /// </summary>
        /// <param name="r">Sets the radial height of the bars</param>
        /// <param name="theta">sets the angular position of the bars</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="MarkerColor">Sets the color of the bars</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the bars</param>
        /// <param name="MarkerOutline">Sets the color of the bar outline</param>
        /// <param name="MarkerPatternShape">Sets the pattern shape for all bars</param>
        /// <param name="MultiMarkerPatternShape">Sets individual pattern shapes for the bars</param>
        /// <param name="MarkerPattern">Sets the marker pattern (use this for more finegrained control than the other pattern-associated arguments).</param>
        /// <param name="Marker">Sets the marker for the bars (use this for more finegrained control than the other marker-associated arguments).</param>
        /// <param name="Base">Sets where the bar base is drawn (in position axis units).</param>
        /// <param name="Width">Sets the bar width (in position axis units) of all bars.</param>
        /// <param name="MultiWidth">Sets the individual bar width (in position axis units) for each bar.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart BarPolar<RType, ThetaType, TextType>(
            IEnumerable<RType> r,
            IEnumerable<ThetaType> theta,
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
            Optional<RType> Base = default,
            Optional<ThetaType> Width = default,
            Optional<IEnumerable<ThetaType>> MultiWidth = default,
            Optional<bool> UseDefaults = default
        )
            where RType : IConvertible
            where ThetaType : IConvertible
            where TextType : IConvertible

            =>
                Plotly.NET.ChartPolar_Bar.Chart.BarPolar<RType, ThetaType, TextType, RType, ThetaType>(
                    r: r,
                    theta: theta,
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
                    UseDefaults: UseDefaults.ToOption()
                );
}
