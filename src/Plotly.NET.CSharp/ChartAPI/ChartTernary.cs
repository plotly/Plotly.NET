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
        public static GenericChart.GenericChart Scatterternary<AType, BType, CType, SumType, TextType>(
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
