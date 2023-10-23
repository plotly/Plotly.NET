using Plotly.NET;
using Plotly.NET.LayoutObjects;
using Plotly.NET.TraceObjects;
using System.Runtime.InteropServices;

namespace Plotly.NET.CSharp
{
    public static partial class Chart
    {
        /// <summary>
        /// Creates a Scatter plot on a smith coordinate system.
        ///
        /// In general, ScatterSmith charts plot complex numbers on a transformed two-dimensional Cartesian complex plane. Complex numbers with positive real parts map inside the circle. Those with negative real parts map outside the circle.
        ///
        /// ScatterSmith charts are the basis of PointSmith, LineSmith, and BubbleSmith Charts, and can be customized as such. We also provide abstractions for those: Chart.LineSmith, Chart.PointSmith, Chart.BubbleSmith
        /// </summary>
        /// <param name="real">Sets the real component of the data, in units of normalized impedance such that real=1, imag=0 is the center of the chart.</param>
        /// <param name="imag">Sets the imaginary component of the data, in units of normalized impedance such that real=1, imag=0 is the center of the chart.</param>
        /// <param name="mode">Determines the drawing mode for this scatter trace.</param>
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
        /// <param name="LineColor">Sets the color of the line</param>
        /// <param name="LineColorScale">Sets the colorscale of the line</param>
        /// <param name="LineWidth">Sets the width of the line</param>
        /// <param name="LineDash">sets the drawing style of the line</param>
        /// <param name="Line">Sets the line (use this for more finegrained control than the other line-associated arguments)</param>
        /// <param name="Fill">Sets the area to fill with a solid color. Defaults to "none" unless this trace is stacked, then it gets "tonexty" ("tonextx") if `orientation` is "v" ("h") Use with `FillColor` if not "none". "tozerox" and "tozeroy" fill to x=0 and y=0 respectively. "tonextx" and "tonexty" fill between the endpoints of this trace and the endpoints of the trace before it, connecting those endpoints with straight lines (to make a stacked area graph); if there is no trace before it, they behave like "tozerox" and "tozeroy". "toself" connects the endpoints of the trace (or each segment of the trace if it has gaps) into a closed shape. "tonext" fills the space between two traces if one completely encloses the other (eg consecutive contour lines), and behaves like "toself" if there is no trace before it. "tonext" should not be used if one trace does not enclose the other. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order.</param>
        /// <param name="FillColor">ets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart ScatterSmith<RealType, ImagType, TextType>(
            IEnumerable<RealType> real,
            IEnumerable<ImagType> imag,
            StyleParam.Mode mode,
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
            Optional<Color> LineColor = default,
            Optional<StyleParam.Colorscale> LineColorScale = default,
            Optional<double> LineWidth = default,
            Optional<StyleParam.DrawingStyle> LineDash = default,
            Optional<Line> Line = default,
            Optional<StyleParam.Fill> Fill = default,
            Optional<Color> FillColor = default,
            Optional<bool> UseDefaults = default
        )
            where RealType : IConvertible
            where ImagType : IConvertible
            where TextType : IConvertible
            =>
                Plotly.NET.ChartSmith.Chart.ScatterSmith<RealType, ImagType, TextType>(
                    real: real,
                    imag: imag,
                    mode: mode,
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
                    LineColor: LineColor.ToOption(),
                    LineColorScale: LineColorScale.ToOption(),
                    LineWidth: LineWidth.ToOption(),
                    LineDash: LineDash.ToOption(),
                    Line: Line.ToOption(),
                    Fill: Fill.ToOption(),
                    FillColor: FillColor.ToOption(),
                    UseDefaults: UseDefaults.ToOption()
                );

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
                Plotly.NET.ChartSmith.Chart.PointSmith<RealType, ImagType, TextType>(
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

        /// <summary>
        /// Creates a Line plot on a smith coordinate system.
        ///
        /// In general, LineSmith charts plot complex numbers on a transformed two-dimensional Cartesian complex plane as datums connected by a line. Complex numbers with positive real parts map inside the circle. Those with negative real parts map outside the circle.
        /// </summary>
        /// <param name="real">Sets the real component of the data, in units of normalized impedance such that real=1, imag=0 is the center of the chart.</param>
        /// <param name="imag">Sets the imaginary component of the data, in units of normalized impedance such that real=1, imag=0 is the center of the chart.</param>
        /// <param name="ShowMarkers">Whether or not to show markers for each datum.</param>
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
        /// <param name="LineColor">Sets the color of the line</param>
        /// <param name="LineColorScale">Sets the colorscale of the line</param>
        /// <param name="LineWidth">Sets the width of the line</param>
        /// <param name="LineDash">sets the drawing style of the line</param>
        /// <param name="Line">Sets the line (use this for more finegrained control than the other line-associated arguments)</param>
        /// <param name="Fill">Sets the area to fill with a solid color. Defaults to "none" unless this trace is stacked, then it gets "tonexty" ("tonextx") if `orientation` is "v" ("h") Use with `FillColor` if not "none". "tozerox" and "tozeroy" fill to x=0 and y=0 respectively. "tonextx" and "tonexty" fill between the endpoints of this trace and the endpoints of the trace before it, connecting those endpoints with straight lines (to make a stacked area graph); if there is no trace before it, they behave like "tozerox" and "tozeroy". "toself" connects the endpoints of the trace (or each segment of the trace if it has gaps) into a closed shape. "tonext" fills the space between two traces if one completely encloses the other (eg consecutive contour lines), and behaves like "toself" if there is no trace before it. "tonext" should not be used if one trace does not enclose the other. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order.</param>
        /// <param name="FillColor">ets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart LineSmith<RealType, ImagType, TextType>(
            IEnumerable<RealType> real,
            IEnumerable<ImagType> imag,
            Optional<bool> ShowMarkers = default,
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
            Optional<Color> LineColor = default,
            Optional<StyleParam.Colorscale> LineColorScale = default,
            Optional<double> LineWidth = default,
            Optional<StyleParam.DrawingStyle> LineDash = default,
            Optional<Line> Line = default,
            Optional<StyleParam.Fill> Fill = default,
            Optional<Color> FillColor = default,
            Optional<bool> UseDefaults = default
        )
            where RealType : IConvertible
            where ImagType : IConvertible
            where TextType : IConvertible
            =>
                Plotly.NET.ChartSmith.Chart.LineSmith<RealType, ImagType, TextType>(
                    real: real,
                    imag: imag,
                    ShowMarkers: ShowMarkers.ToOption(),
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
                    LineColor: LineColor.ToOption(),
                    LineColorScale: LineColorScale.ToOption(),
                    LineWidth: LineWidth.ToOption(),
                    LineDash: LineDash.ToOption(),
                    Line: Line.ToOption(),
                    Fill: Fill.ToOption(),
                    FillColor: FillColor.ToOption(),
                    UseDefaults: UseDefaults.ToOption()
                );
        /// <summary>
        /// Creates a Bubble plot on a smith coordinate system. A bubble chart is a variation of the Point chart, where the data points get an additional scale by being rendered as bubbles of different sizes.
        ///
        /// In general, BubbleSmith charts plot complex numbers on a transformed two-dimensional Cartesian complex plane as points of varying sizes. Complex numbers with positive real parts map inside the circle. Those with negative real parts map outside the circle.
        /// </summary>
        /// <param name="real">Sets the real component of the data, in units of normalized impedance such that real=1, imag=0 is the center of the chart.</param>
        /// <param name="imag">Sets the imaginary component of the data, in units of normalized impedance such that real=1, imag=0 is the center of the chart.</param>
        /// <param name="sizes">Sets the size of the points</param>
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
        /// <param name="LineColor">Sets the color of the line</param>
        /// <param name="LineColorScale">Sets the colorscale of the line</param>
        /// <param name="LineWidth">Sets the width of the line</param>
        /// <param name="LineDash">sets the drawing style of the line</param>
        /// <param name="Line">Sets the line (use this for more finegrained control than the other line-associated arguments)</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart BubbleSmith<RealType, ImagType, TextType>(
            IEnumerable<RealType> real,
            IEnumerable<ImagType> imag,
            IEnumerable<int> sizes,
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
            Optional<Color> LineColor = default,
            Optional<StyleParam.Colorscale> LineColorScale = default,
            Optional<double> LineWidth = default,
            Optional<StyleParam.DrawingStyle> LineDash = default,
            Optional<Line> Line = default,
            Optional<bool> UseDefaults = default
        )
            where RealType : IConvertible
            where ImagType : IConvertible
            where TextType : IConvertible
            =>
                Plotly.NET.ChartSmith.Chart.BubbleSmith<RealType, ImagType, TextType>(
                    real: real,
                    imag: imag,
                    sizes: sizes,
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
                    LineColor: LineColor.ToOption(),
                    LineColorScale: LineColorScale.ToOption(),
                    LineWidth: LineWidth.ToOption(),
                    LineDash: LineDash.ToOption(),
                    Line: Line.ToOption(),
                    UseDefaults: UseDefaults.ToOption()
                );
    }
}
