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
        /// Creates a Point plot on a smith coordinate system.
        ///
        /// In general, ScatterPoint charts plot complex numbers on a transformed two-dimensional Cartesian complex plane as points. Complex numbers with positive real parts map inside the circle. Those with negative real parts map outside the circle.
        /// </summary>
        /// <param name="real">Sets the real component of the data, in units of normalized impedance such that real=1, imag=0 is the center of the chart.</param>
        /// <param name="imag">Sets the imaginary component of the data, in units of normalized impedance such that real=1, imag=0 is the center of the chart.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker</param>
        /// <param name="MarkerOutline">Sets the outline of the marker</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments)</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart PointSmith<RealType, ImagType, TextType>(
            IEnumerable<RealType> real,
            IEnumerable<ImagType> imag,
            Optional<string> Name = default,
            Optional<bool> ShowLegend = default,
            Optional<double> Opacity = default,
            Optional<IEnumerable<double>> MultiOpacity = default,
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
            Optional<bool> UseDefaults = default
        )
            where RealType : IConvertible
            where ImagType : IConvertible
            where TextType : IConvertible
            =>
                Plotly.NET.ChartSmith_Scatter.Chart.PointSmith<RealType, ImagType, TextType>(
                    real: real,
                    imag: imag,
                    Name: Name.ToOption(),
                    ShowLegend: ShowLegend.ToOption(),
                    Opacity: Opacity.ToOption(),
                    MultiOpacity: MultiOpacity.ToOption(),
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
                    UseDefaults: UseDefaults.ToOption()
                );
}
