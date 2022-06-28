using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plotly.NET;
using Plotly.NET.LayoutObjects;
using Plotly.NET.TraceObjects;
using System.Runtime.InteropServices;

namespace Plotly.NET.CSharp
{
    public static partial class Chart
    {
        /// <summary>
        /// Creates a polar scatter plot.
        ///
        /// In general, ScatterPolar plots plot two-dimensional data on a polar coordinate system comprised of angular and radial position scales.
        ///
        /// ScatterPolar charts are the basis of PointPolar, LinePolar, SplinePolar, and BubblePolar Charts, and can be customized as such. We also provide abstractions for those: Chart.PointPolar, Chart.LinePolar, Chart.SplinePolar , Chart.BubblePolar
        /// </summary>
        /// <param name="r">Sets the radial coordinates of the plotted data</param>
        /// <param name="theta">Sets the angular coordinates of the plotted data (in degrees)</param>
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
        /// <param name="UseWebGL">If true, plotly.js will use the WebGL engine to render this chart. use this when you want to render many objects at once.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart.GenericChart ScatterPolar<RType, ThetaType, TextType>(
            IEnumerable<RType> r,
            IEnumerable<ThetaType> theta,
            StyleParam.Mode mode,
            [Optional] string? Name,
            [Optional] bool? ShowLegend,
            [Optional] double? Opacity,
            [Optional] IEnumerable<double>? MultiOpacity,
            [Optional] TextType? Text,
            [Optional] IEnumerable<TextType>? MultiText,
            [Optional] StyleParam.TextPosition? TextPosition,
            [Optional] IEnumerable<StyleParam.TextPosition>? MultiTextPosition,
            [Optional] Color? MarkerColor,
            [Optional] StyleParam.Colorscale? MarkerColorScale,
            [Optional] Line? MarkerOutline,
            [Optional] StyleParam.MarkerSymbol3D? MarkerSymbol,
            [Optional] IEnumerable<StyleParam.MarkerSymbol3D>? MultiMarkerSymbol,
            [Optional] Marker? Marker,
            [Optional] Color? LineColor,
            [Optional] StyleParam.Colorscale? LineColorScale,
            [Optional] double? LineWidth,
            [Optional] StyleParam.DrawingStyle? LineDash,
            [Optional] Line? Line,
            [Optional] bool? UseWebGL,
            [Optional] bool? UseDefaults
        )
            where RType : IConvertible
            where ThetaType : IConvertible
            where TextType : IConvertible

            =>
                Plotly.NET.ChartPolar.Chart.ScatterPolar<RType, ThetaType, TextType>(
                    r: r,
                    theta: theta,
                    mode: mode,
                    Name: Helpers.ToOption(Name),
                    ShowLegend: Helpers.ToOptionV(ShowLegend),
                    Opacity: Helpers.ToOptionV(Opacity),
                    MultiOpacity: Helpers.ToOption(MultiOpacity),
                    Text: Helpers.ToOption(Text),
                    MultiText: Helpers.ToOption(MultiText),
                    TextPosition: Helpers.ToOption(TextPosition),
                    MultiTextPosition: Helpers.ToOption(MultiTextPosition),
                    MarkerColor: Helpers.ToOption(MarkerColor),
                    MarkerColorScale: Helpers.ToOption(MarkerColorScale),
                    MarkerOutline: Helpers.ToOption(MarkerOutline),
                    MarkerSymbol: Helpers.ToOption(MarkerSymbol),
                    MultiMarkerSymbol: Helpers.ToOption(MultiMarkerSymbol),
                    Marker: Helpers.ToOption(Marker),
                    LineColor: Helpers.ToOption(LineColor),
                    LineColorScale: Helpers.ToOption(LineColorScale),
                    LineWidth: Helpers.ToOptionV(LineWidth),
                    LineDash: Helpers.ToOption(LineDash),   
                    Line: Helpers.ToOption(Line),
                    UseWebGL: Helpers.ToOptionV(UseWebGL),
                    UseDefaults: Helpers.ToOptionV(UseDefaults)
                );
    }
}
