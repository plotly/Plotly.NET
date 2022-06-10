using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plotly.NET.LayoutObjects;
using Plotly.NET.TraceObjects;

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
        public static GenericChart.GenericChart ScatterTernary<AType, BType, CType, SumType, TextType>(
            IEnumerable<AType>? A = null,
            IEnumerable<BType>? B = null,
            IEnumerable<CType>? C = null,
            SumType? Sum = null,
            StyleParam.Mode? Mode = null,
            string? Name = null,
            bool? ShowLegend = null,
            double? Opacity = null,
            IEnumerable<double>? MultiOpacity = null,
            TextType? Text = null,
            IEnumerable<TextType>? MultiText = null,
            StyleParam.TextPosition? TextPosition = null,
            IEnumerable<StyleParam.TextPosition>? MultiTextPosition = null,
            Color? MarkerColor = null,
            StyleParam.Colorscale? MarkerColorScale = null,
            Line? MarkerOutline = null,
            StyleParam.MarkerSymbol? MarkerSymbol = null,
            IEnumerable<StyleParam.MarkerSymbol>? MultiMarkerSymbol = null,
            Marker? Marker = null,
            Color? LineColor = null,
            StyleParam.Colorscale? LineColorScale = null,
            double? LineWidth = null,
            StyleParam.DrawingStyle? LineDash = null,
            Line? Line = null,
            bool? UseDefaults = null
        )
            where AType : IConvertible
            where BType : IConvertible
            where CType : IConvertible
            where SumType : class, IConvertible
            where TextType : class, IConvertible
            =>
                Plotly.NET.ChartTernary.Chart.ScatterTernary<AType, BType, CType, SumType, TextType>(
                    A: A.ToOption(),
                    B: B.ToOption(),
                    C: C.ToOption(),
                    Sum: Sum.ToOption(),
                    Mode: Mode.ToOption(),
                    Name: Name.ToOption(),
                    ShowLegend: ShowLegend.ToOptionV(),
                    Opacity: Opacity.ToOptionV(),
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
                    LineWidth: LineWidth.ToOptionV(),
                    LineDash: LineDash.ToOption(),
                    Line: Line.ToOption(),
                    UseDefaults: UseDefaults.ToOptionV()
                );
    }
}
