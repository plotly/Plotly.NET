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
        /// Creates a Scatter plot on a ternary coordinate system
        ///
        /// In general, ScatterTernary creates a barycentric plot on three variables which sum to a constant, graphically depicting the ratios of the three variables as positions in an equilateral triangle.
        ///
        /// ScatterTernary charts are the basis of PointTernary, LineTernary, and BubbleTernary Charts, and can be customized as such. We also provide abstractions for those: Chart.LineTernary, Chart.PointTernary, Chart.BubbleTernary
        /// </summary>
        /// <param name="A">Sets the quantity of component `a` in each data point. If `a`, `b`, and `c` are all provided, they need not be normalized, only the relative values matter. If only two arrays are provided they must be normalized to match `ternary&lt;i&gt;.sum`.</param>
        /// <param name="B">Sets the quantity of component `b` in each data point. If `a`, `b`, and `c` are all provided, they need not be normalized, only the relative values matter. If only two arrays are provided they must be normalized to match `ternary&lt;i&gt;.sum`.</param>
        /// <param name="C">Sets the quantity of component `c` in each data point. If `a`, `b`, and `c` are all provided, they need not be normalized, only the relative values matter. If only two arrays are provided they must be normalized to match `ternary&lt;i&gt;.sum`.</param>
        /// <param name="Sum">The number each triplet should sum to, if only two of `a`, `b`, and `c` are provided. This overrides `ternary&lt;i&gt;.sum` to normalize this specific trace, but does not affect the values displayed on the axes. 0 (or missing) means to use `ternary&lt;i&gt;.sum`</param>
        /// <param name="Mode">Determines the drawing mode for this scatter trace.</param>
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
        public static GenericChart ScatterTernary<AType, BType, CType, SumType, TextType>(
            Optional<IEnumerable<AType>> A = default,
            Optional<IEnumerable<BType>> B = default,
            Optional<IEnumerable<CType>> C = default,
            Optional<SumType> Sum = default,
            Optional<StyleParam.Mode> Mode = default,
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
            where CType : IConvertible
            where SumType : IConvertible
            where TextType : IConvertible
            =>
                Plotly.NET.ChartTernary.Chart.ScatterTernary<AType, BType, CType, SumType, TextType>(
                    A: A.ToOption(),
                    B: B.ToOption(),
                    C: C.ToOption(),
                    Sum: Sum.ToOption(),
                    Mode: Mode.ToOption(),
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
        /// Creates a point plot on a ternary coordinate system
        ///
        /// In general, PointTernary creates a barycentric point plot on three variables which sum to a constant, graphically depicting the ratios of the three variables as positions in an equilateral triangle.
        /// </summary>
        /// <param name="A">Sets the quantity of component `a` in each data point. If `a`, `b`, and `c` are all provided, they need not be normalized, only the relative values matter. If only two arrays are provided they must be normalized to match `ternary&lt;i&gt;.sum`.</param>
        /// <param name="B">Sets the quantity of component `b` in each data point. If `a`, `b`, and `c` are all provided, they need not be normalized, only the relative values matter. If only two arrays are provided they must be normalized to match `ternary&lt;i&gt;.sum`.</param>
        /// <param name="C">Sets the quantity of component `c` in each data point. If `a`, `b`, and `c` are all provided, they need not be normalized, only the relative values matter. If only two arrays are provided they must be normalized to match `ternary&lt;i&gt;.sum`.</param>
        /// <param name="Sum">The number each triplet should sum to, if only two of `a`, `b`, and `c` are provided. This overrides `ternary&lt;i&gt;.sum` to normalize this specific trace, but does not affect the values displayed on the axes. 0 (or missing) means to use `ternary&lt;i&gt;.sum`</param>
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
        public static GenericChart PointTernary<AType, BType, CType, SumType, TextType>(
            Optional<IEnumerable<AType>> A = default,
            Optional<IEnumerable<BType>> B = default,
            Optional<IEnumerable<CType>> C = default,
            Optional<SumType> Sum = default,
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
            where CType : IConvertible
            where SumType : IConvertible
            where TextType : IConvertible
            =>
                Plotly.NET.ChartTernary.Chart.PointTernary<AType, BType, CType, SumType, TextType>(
                    A: A.ToOption(),
                    B: B.ToOption(),
                    C: C.ToOption(),
                    Sum: Sum.ToOption(),
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
        /// Creates a line plot on a ternary coordinate system
        ///
        /// In general, LineTernary creates a barycentric line plot on three variables which sum to a constant, graphically depicting the ratios of the three variables as positions in an equilateral triangle.
        /// </summary>
        /// <param name="A">Sets the quantity of component `a` in each data point. If `a`, `b`, and `c` are all provided, they need not be normalized, only the relative values matter. If only two arrays are provided they must be normalized to match `ternary&lt;i&gt;.sum`.</param>
        /// <param name="B">Sets the quantity of component `b` in each data point. If `a`, `b`, and `c` are all provided, they need not be normalized, only the relative values matter. If only two arrays are provided they must be normalized to match `ternary&lt;i&gt;.sum`.</param>
        /// <param name="C">Sets the quantity of component `c` in each data point. If `a`, `b`, and `c` are all provided, they need not be normalized, only the relative values matter. If only two arrays are provided they must be normalized to match `ternary&lt;i&gt;.sum`.</param>
        /// <param name="Sum">The number each triplet should sum to, if only two of `a`, `b`, and `c` are provided. This overrides `ternary&lt;i&gt;.sum` to normalize this specific trace, but does not affect the values displayed on the axes. 0 (or missing) means to use `ternary&lt;i&gt;.sum`</param>
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
        public static GenericChart LineTernary<AType, BType, CType, SumType, TextType>(
            Optional<IEnumerable<AType>> A = default,
            Optional<IEnumerable<BType>> B = default,
            Optional<IEnumerable<CType>> C = default,
            Optional<SumType> Sum = default,
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
            where CType : IConvertible
            where SumType : IConvertible
            where TextType : IConvertible
            =>
                Plotly.NET.ChartTernary.Chart.LineTernary<AType, BType, CType, SumType, TextType>(
                    A: A.ToOption(),
                    B: B.ToOption(),
                    C: C.ToOption(),
                    Sum: Sum.ToOption(),
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
        /// Creates a bubble plot on a ternary coordinate system
        ///
        /// A bubble chart is a variation of the Point chart, where the data points get an additional scale by being rendered as bubbles of different sizes.
        ///
        /// In general, BubbleTernary creates a barycentric point plot on three variables which sum to a constant, graphically depicting the ratios of the three variables as positions in an equilateral triangle.
        /// A 4th data dimension is used to determine the size of the points.
        /// </summary>
        /// <param name="sizes">Sets the bubble size of the plotted data</param>
        /// <param name="A">Sets the quantity of component `a` in each data point. If `a`, `b`, and `c` are all provided, they need not be normalized, only the relative values matter. If only two arrays are provided they must be normalized to match `ternary&lt;i&gt;.sum`.</param>
        /// <param name="B">Sets the quantity of component `b` in each data point. If `a`, `b`, and `c` are all provided, they need not be normalized, only the relative values matter. If only two arrays are provided they must be normalized to match `ternary&lt;i&gt;.sum`.</param>
        /// <param name="C">Sets the quantity of component `c` in each data point. If `a`, `b`, and `c` are all provided, they need not be normalized, only the relative values matter. If only two arrays are provided they must be normalized to match `ternary&lt;i&gt;.sum`.</param>
        /// <param name="Sum">The number each triplet should sum to, if only two of `a`, `b`, and `c` are provided. This overrides `ternary&lt;i&gt;.sum` to normalize this specific trace, but does not affect the values displayed on the axes. 0 (or missing) means to use `ternary&lt;i&gt;.sum`</param>
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
        public static GenericChart BubbleTernary<AType, BType, CType, SumType, TextType>(
            IEnumerable<int> sizes,
            Optional<IEnumerable<AType>> A = default,
            Optional<IEnumerable<BType>> B = default,
            Optional<IEnumerable<CType>> C = default,
            Optional<SumType> Sum = default,
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
            where CType : IConvertible
            where SumType : IConvertible
            where TextType : IConvertible
            =>
                Plotly.NET.ChartTernary.Chart.BubbleTernary<AType, BType, CType, SumType, TextType>(
                    sizes: sizes,
                    A: A.ToOption(),
                    B: B.ToOption(),
                    C: C.ToOption(),
                    Sum: Sum.ToOption(),
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
