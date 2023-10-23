using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plotly.NET.LayoutObjects;
using Plotly.NET.TraceObjects;
using System.Runtime.InteropServices;

namespace Plotly.NET.CSharp
{
    public static partial class Chart
    {
        /// <summary>
        /// Creates a carpet in a 2D coordinate system to be used as additional coordinate system in a carpet plot.
        ///
        /// A  carpet plot illustrates the interaction between two or more independent variables and one or more dependent variables in a two-dimensional plot.
        /// Besides the ability to incorporate more variables, another feature that distinguishes a carpet plot from an equivalent contour plot or 3D surface plot is that a carpet plot can be used to more accurately interpolate data points.
        /// A conventional carpet plot can capture the interaction of up to three independent variables and three dependent variables and still be easily read and interpolated.
        ///
        /// Three-variable carpet plot (cheater plot):
        ///
        /// A carpet plot with two independent variables and one dependent variable is often called a cheater plot for the use of a phantom "cheater" axis instead of the horizontal axis. As a result of this missing axis, the values can be shifted horizontally such that the intersections line up vertically. This allows easy interpolation by having fixed horizontal intervals correspond to fixed intervals in both independent variables.
        ///
        /// Four-variable carpet plot (true carpet plot)
        ///
        /// Instead of using the horizontal axis to adjust the plot perspective and align carpet intersections vertically, the horizontal axis can be used to show the effects on an additional dependent variable.[5] In this case the perspective is fixed, and any overlapping cannot be adjusted. Because a true carpet plot represents two independent variables and two dependent variables simultaneously, there is no corresponding way to show the information on a conventional contour plot or 3D surface plot.
        ///
        /// (from https://en.wikipedia.org/wiki/Carpet_plot @ 1/11/2021)
        /// </summary>
        /// <param name="carpetId">An identifier for this carpet, so that `scattercarpet` and `contourcarpet` traces can specify a carpet plot on which they lie.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="X">A one dimensional array of x coordinates matching the dimensions of `a` and `b`.</param>
        /// <param name="MultiX">A two dimensional array of x coordinates at each carpet point. If omitted, the plot is a cheater plot and the xaxis is hidden by default.</param>
        /// <param name="Y">A one dimensional array of y coordinates matching the dimensions of `a` and `b`.</param>
        /// <param name="MultiY">A two dimensional array of y coordinates at each carpet point.</param>
        /// <param name="A">An array containing values of the first parameter value</param>
        /// <param name="B">An array containing values of the second parameter value</param>
        /// <param name="AAxis">Sets this carpet's a axis.</param>
        /// <param name="BAxis">Sets this carpet's b axis.</param>
        /// <param name="XAxis">Sets a reference between this trace's x coordinates and a 2D cartesian x axis. If "x" (the default value), the x coordinates refer to `layout.xaxis`. If "x2", the x coordinates refer to `layout.xaxis2`, and so on.</param>
        /// <param name="YAxis">Sets a reference between this trace's y coordinates and a 2D cartesian y axis. If "y" (the default value), the y coordinates refer to `layout.yaxis`. If "y2", the y coordinates refer to `layout.yaxis2`, and so on.</param>
        /// <param name="Color">Sets default for all colors associated with this axis all at once: line, font, tick, and grid colors. Grid color is lightened by blending this with the plot background Individual pieces can override this.</param>
        /// <param name="CheaterSlope">The shift applied to each successive row of data in creating a cheater plot. Only used if `x` is been omitted.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart Carpet<XType, MultiXType, YType, MultiYType, AType, BType>(
            string carpetId,
            Optional<string> Name = default,
            Optional<bool> ShowLegend = default,
            Optional<double> Opacity = default,
            Optional<IEnumerable<XType>> X = default,
            Optional<IEnumerable<IEnumerable<MultiXType>>> MultiX = default,
            Optional<IEnumerable<YType>> Y = default,
            Optional<IEnumerable<IEnumerable<MultiYType>>> MultiY = default,
            Optional<IEnumerable<AType>> A = default,
            Optional<IEnumerable<BType>> B = default,
            Optional<LinearAxis> AAxis = default,
            Optional<LinearAxis> BAxis = default,
            Optional<StyleParam.LinearAxisId> XAxis = default,
            Optional<StyleParam.LinearAxisId> YAxis = default,
            Optional<Color> Color = default,
            Optional<double> CheaterSlope = default,
            Optional<bool> UseDefaults = default
        )
            where XType : IConvertible 
            where MultiXType : IConvertible 
            where YType : IConvertible 
            where MultiYType : IConvertible 
            where AType : IConvertible 
            where BType : IConvertible
            =>
                Plotly.NET.ChartCarpet.Chart.Carpet<XType, IEnumerable<MultiXType>, MultiXType, YType, IEnumerable<MultiYType>, MultiYType, AType, BType>(
                    carpetId: carpetId,
                    Name: Name.ToOption(),
                    ShowLegend: ShowLegend.ToOption(),
                    Opacity: Opacity.ToOption(),
                    X: X.ToOption(),
                    MultiX: MultiX.ToOption(), 
                    Y: Y.ToOption(),
                    MultiY: MultiY.ToOption(),
                    A: A.ToOption(),
                    B: B.ToOption(),
                    AAxis: AAxis.ToOption(),
                    BAxis: BAxis.ToOption(),
                    XAxis: XAxis.ToOption(),
                    YAxis: YAxis.ToOption(),
                    Color: Color.ToOption(),
                    CheaterSlope: CheaterSlope.ToOption(),
                    UseDefaults: UseDefaults.ToOption()
                );

        /// <summary>
        /// Creates a scatter plot that lies on a specified carpet.
        ///
        /// In general, ScatterCarpet creates a plot that uses the given carpet identifier as coordinate system.
        ///
        /// Whether the resulting plot is a cheater or true carpet plot depends on the referenced carpet.
        ///
        /// ScatterCarpet charts are the basis of PointCarpet, LineCarpet, and BubbleCarpet Charts, and can be customized as such. We also provide abstractions for those: Chart.LineCarpet, Chart.PointCarpet, Chart.BubbleCarpet
        /// </summary>
        /// <param name="a">Sets the a-axis coordinates on the carpet.</param>
        /// <param name="b">Sets the b-axis coordinates on the carpet.</param>
        /// <param name="mode">Determines the drawing mode for this scatter trace. If the provided `mode` includes "text" then the `text` elements appear at the coordinates. Otherwise, the `text` elements appear on hover. If there are less than 20 points and the trace is not stacked then the default is "lines+markers". Otherwise, "lines".</param>
        /// <param name="carpetAnchorId">The identifier of the carpet that this trace will lie on.</param>
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
        public static GenericChart ScatterCarpet<AType, BType, TextType>(
            IEnumerable<AType> a,
            IEnumerable<BType> b,
            StyleParam.Mode mode,
            string carpetAnchorId,
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
            where AType : IConvertible
            where BType : IConvertible
            where TextType : IConvertible
        =>
            Plotly.NET.ChartCarpet.Chart.ScatterCarpet<AType, BType, TextType>(
                a: a,
                b: b,
                mode: mode,
                carpetAnchorId: carpetAnchorId,
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

        /// <summary>
        /// Creates a point plot that lies on a specified carpet.
        ///
        /// In general, PointCarpet creates a point plot that uses the given carpet identifier as coordinate system.
        ///
        /// Whether the resulting plot is a cheater or true carpet plot depends on the referenced carpet.
        /// </summary>
        /// <param name="a">Sets the a-axis coordinates on the carpet.</param>
        /// <param name="b">Sets the b-axis coordinates on the carpet.</param>
        /// <param name="carpetAnchorId">The identifier of the carpet that this trace will lie on.</param>
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
        public static GenericChart PointCarpet<AType, BType, TextType>(
            IEnumerable<AType> a,
            IEnumerable<BType> b,
            string carpetAnchorId,
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
            where AType : IConvertible
            where BType : IConvertible
            where TextType : IConvertible
        =>
            Plotly.NET.ChartCarpet.Chart.PointCarpet<AType, BType, TextType>(
                a: a,
                b: b,
                carpetAnchorId: carpetAnchorId,
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
        /// Creates a line plot that lies on a specified carpet.
        ///
        /// In general, LineCarpet creates a line plot that uses the given carpet identifier as coordinate system.
        ///
        /// Whether the resulting plot is a cheater or true carpet plot depends on the referenced carpet.
        /// </summary>
        /// <param name="a">Sets the a-axis coordinates on the carpet.</param>
        /// <param name="b">Sets the b-axis coordinates on the carpet.</param>
        /// <param name="carpetAnchorId">The identifier of the carpet that this trace will lie on.</param>
        /// <param name="ShowMarkers">Whether to show markers for the individual data points</param>
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
        public static GenericChart LineCarpet<AType, BType, TextType>(
            IEnumerable<AType> a,
            IEnumerable<BType> b,
            string carpetAnchorId,
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
            Optional<bool> UseDefaults = default
        )
            where AType : IConvertible
            where BType : IConvertible
            where TextType : IConvertible
        =>
            Plotly.NET.ChartCarpet.Chart.LineCarpet<AType, BType, TextType>(
                a: a,
                b: b,
                carpetAnchorId: carpetAnchorId,
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
                UseDefaults: UseDefaults.ToOption()
            );

        /// <summary>
        /// Creates a spline plot that lies on a specified carpet.
        ///
        /// In general, SplineCarpet creates a spline plot that uses the given carpet identifier as coordinate system.
        /// A spline chart is a line chart in which data points are connected by smoothed curves.
        ///
        /// Whether the resulting plot is a cheater or true carpet plot depends on the referenced carpet.
        /// </summary>
        /// <param name="a">Sets the a-axis coordinates on the carpet.</param>
        /// <param name="b">Sets the b-axis coordinates on the carpet.</param>
        /// <param name="carpetAnchorId">The identifier of the carpet that this trace will lie on.</param>
        /// <param name="ShowMarkers">Whether to show markers for the individual data points</param>
        /// <param name="Smoothing">Sets the amount of smoothing. "0" corresponds to no smoothing (equivalent to a "linear" shape).  Use values between 0. and 1.3</param>
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
        public static GenericChart SplineCarpet<AType, BType, TextType>(
            IEnumerable<AType> a,
            IEnumerable<BType> b,
            string carpetAnchorId,
            Optional<bool> ShowMarkers = default,
            Optional<double> Smoothing = default,
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
            where AType : IConvertible
            where BType : IConvertible
            where TextType : IConvertible
        =>
            Plotly.NET.ChartCarpet.Chart.SplineCarpet<AType, BType, TextType>(
                a: a,
                b: b,
                carpetAnchorId: carpetAnchorId,
                ShowMarkers: ShowMarkers.ToOption(),
                Smoothing: Smoothing.ToOption(),
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

        /// <summary>
        /// Creates a bubble chart that lies on a specified carpet.
        ///
        /// In general, BubbleCarpet creates a bubble chart that uses the given carpet identifier as coordinate system.
        ///
        /// A bubble chart is a variation of the Point chart, where the data points get an additional scale by being rendered as bubbles of different sizes.
        ///
        /// Whether the resulting plot is a cheater or true carpet plot depends on the referenced carpet.
        /// </summary>
        /// <param name="a">Sets the a-axis coordinates on the carpet.</param>
        /// <param name="b">Sets the b-axis coordinates on the carpet.</param>
        /// <param name="sizes">Sets the bubble size of the plotted data</param>
        /// <param name="carpetAnchorId">The identifier of the carpet that this trace will lie on.</param>
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
        public static GenericChart BubbleCarpet<AType, BType, TextType>(
            IEnumerable<AType> a,
            IEnumerable<BType> b,
            IEnumerable<int> sizes,
            string carpetAnchorId,
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
            where AType : IConvertible
            where BType : IConvertible
            where TextType : IConvertible
        =>
            Plotly.NET.ChartCarpet.Chart.BubbleCarpet<AType, BType, TextType>(
                a: a,
                b: b,
                sizes: sizes,
                carpetAnchorId: carpetAnchorId,
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

        /// <summary>
        /// Creates a contour chart that lies on a specified carpet.
        ///
        /// Plots contours on either the first carpet axis or the carpet axis with a matching `carpet` attribute. Data `z` is interpreted as matching that of the corresponding carpet axis.
        /// </summary>
        /// <param name="carpetAnchorId">The identifier of the carpet that this trace will lie on.</param>
        /// <param name="z">Sets the z data.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="A">Sets the a coordinates.</param>
        /// <param name="B">Sets the b coordinates.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="ColorBar">Sets the colorbar of this trace.</param>
        /// <param name="ColorScale">Sets the colorscale of this trace.</param>
        /// <param name="ShowScale">Determines whether or not a colorbar is displayed for this trace.</param>
        /// <param name="ReverseScale">Reverses the color mapping if true. If true, `zmin` will correspond to the last color in the array and `zmax` will correspond to the first color.</param>
        /// <param name="Transpose">Transposes the z data.</param>
        /// <param name="ContourLineDash">Sets the contour line dash style</param>
        /// <param name="ContourLineColor">Sets the contour line color</param>
        /// <param name="ContourLineSmoothing">Sets the amount of smoothing for the contour lines, where "0" corresponds to no smoothing.</param>
        /// <param name="ContourLine">Sets the contour lines (use this for more finegrained control than the other contourline-associated arguments).</param>
        /// <param name="ContoursColoring">Determines the coloring method showing the contour values. If "fill", coloring is done evenly between each contour level If "heatmap", a heatmap gradient coloring is applied between each contour level. If "lines", coloring is done on the contour lines. If "none", no coloring is applied on this trace.</param>
        /// <param name="ContoursOperation">Sets the constraint operation. "=" keeps regions equal to `value` "&lt;" and "&lt;=" keep regions less than `value` "&gt;" and "&gt;=" keep regions greater than `value` "[]", "()", "[)", and "(]" keep regions inside `value[0]` to `value[1]` "][", ")(", "](", ")[" keep regions outside `value[0]` to value[1]` Open vs. closed intervals make no difference to constraint display, but all versions are allowed for consistency with filter transforms.</param>
        /// <param name="ContoursType">If `levels`, the data is represented as a contour plot with multiple levels displayed. If `constraint`, the data is represented as constraints with the invalid region shaded as specified by the `operation` and `value` parameters.</param>
        /// <param name="ShowContourLabels">Determines whether to label the contour lines with their values.</param>
        /// <param name="ContourLabelFont">Sets the font used for labeling the contour levels. The default color comes from the lines, if shown. The default family and size come from `layout.font`.</param>
        /// <param name="Contours">Sets the styles of the contours (use this for more finegrained control than the other contour-associated arguments).</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart ContourCarpet<ZType, AType, BType, TextType>(
            IEnumerable<ZType> z,
            string carpetAnchorId,
            Optional<string> Name = default,
            Optional<bool> ShowLegend = default,
            Optional<double> Opacity = default,
            Optional<IEnumerable<AType>> A = default,
            Optional<IEnumerable<BType>> B = default,
            Optional<TextType> Text = default,
            Optional<IEnumerable<TextType>> MultiText = default,
            Optional<ColorBar> ColorBar = default,
            Optional<StyleParam.Colorscale> ColorScale = default,
            Optional<bool> ShowScale = default,
            Optional<bool> ReverseScale = default,
            Optional<bool> Transpose = default,
            Optional<Color> ContourLineColor = default,
            Optional<StyleParam.DrawingStyle> ContourLineDash = default,
            Optional<double> ContourLineSmoothing = default,
            Optional<Line> ContourLine = default,
            Optional<StyleParam.ContourColoring> ContoursColoring = default,
            Optional<StyleParam.ConstraintOperation> ContoursOperation = default,
            Optional<StyleParam.ContourType> ContoursType = default,
            Optional<bool> ShowContourLabels = default,
            Optional<Font> ContourLabelFont = default,
            Optional<Contours> Contours = default,
            Optional<bool> UseDefaults = default
        )
            where ZType : IConvertible
            where AType : IConvertible
            where BType : IConvertible
            where TextType : IConvertible
            =>
                Plotly.NET.ChartCarpet.Chart.ContourCarpet<ZType, AType, BType, TextType>(
                    z: z,
                    carpetAnchorId: carpetAnchorId,
                    Name: Name.ToOption(),
                    ShowLegend: ShowLegend.ToOption(),
                    Opacity: Opacity.ToOption(),
                    A: A.ToOption(),
                    B: B.ToOption(),
                    Text: Text.ToOption(),
                    MultiText: MultiText.ToOption(),
                    ColorBar: ColorBar.ToOption(),
                    ColorScale: ColorScale.ToOption(),
                    ShowScale: ShowScale.ToOption(),
                    ReverseScale: ReverseScale.ToOption(),
                    Transpose: Transpose.ToOption(),
                    ContourLineColor: ContourLineColor.ToOption(),
                    ContourLineDash: ContourLineDash.ToOption(),
                    ContourLineSmoothing: ContourLineSmoothing.ToOption(),
                    ContourLine: ContourLine.ToOption(),
                    ContoursColoring: ContoursColoring.ToOption(),
                    ContoursOperation: ContoursOperation.ToOption(),
                    ContoursType: ContoursType.ToOption(),
                    ShowContourLabels: ShowContourLabels.ToOption(),
                    ContourLabelFont: ContourLabelFont.ToOption(),
                    Contours: Contours.ToOption(),
                    UseDefaults: UseDefaults.ToOption()
                );
    }
}
