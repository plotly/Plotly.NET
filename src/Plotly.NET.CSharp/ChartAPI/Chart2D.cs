using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plotly.NET;
using Plotly.NET.LayoutObjects;
using Plotly.NET.TraceObjects;

namespace Plotly.NET.CSharp.ChartAPI
{
    public static class Test
    {
        public static int Foo<T1,T2,T3>(
            IEnumerable<T1> notopt, 
            IEnumerable<T2>? opt1 = null,
            T3? opt2 = null
        ) 
            where T1 : IConvertible
            where T2 : IConvertible
            where T3 : class, IConvertible =>
            Plotly.NET.Chart2D.Chart.Foo<T1, T2, T3>(
                notopt: notopt,
                opt1: Helpers.ToOption<IEnumerable<T2>>(opt1),
                opt2: opt2
            );
    }
        public static class Chart2D
    {
        /// <summary>
        /// Creates a Scatter plot.
        ///
        /// Scatter charts are the basis of Point, Line, and Bubble Charts, and can be customized as such. We also provide abstractions for those Chart.Line, Chart.Point, Chart.Bubble
        /// </summary>
        /// <param name="x">Sets the x coordinates of the plotted data.</param>
        /// <param name="y">Sets the y coordinates of the plotted data.</param>
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
        /// <param name="StackGroup">Set several traces (on the same subplot) to the same stackgroup in order to add their y values (or their x values if `Orientation` is Horizontal). Stacking also turns `fill` on by default and sets the default `mode` to "lines" irrespective of point count. ou can only stack on a numeric (linear or log) axis. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order</param>
        /// <param name="Orientation">Sets the stacking direction. Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used.</param>
        /// <param name="GroupNorm">Sets the normalization for the sum of this `stackgroup. Only relevant when `stackgroup` is used, and only the first `groupnorm` found in the `stackgroup` will be used</param>
        /// <param name="Fill">Sets the area to fill with a solid color. Defaults to "none" unless this trace is stacked, then it gets "tonexty" ("tonextx") if `orientation` is "v" ("h") Use with `FillColor` if not "none". "tozerox" and "tozeroy" fill to x=0 and y=0 respectively. "tonextx" and "tonexty" fill between the endpoints of this trace and the endpoints of the trace before it, connecting those endpoints with straight lines (to make a stacked area graph); if there is no trace before it, they behave like "tozerox" and "tozeroy". "toself" connects the endpoints of the trace (or each segment of the trace if it has gaps) into a closed shape. "tonext" fills the space between two traces if one completely encloses the other (eg consecutive contour lines), and behaves like "toself" if there is no trace before it. "tonext" should not be used if one trace does not enclose the other. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order.</param>
        /// <param name="FillColor">ets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
        /// <param name="UseWebGL">If true, plotly.js will use the WebGL engine to render this chart. use this when you want to render many objects at once.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart.GenericChart Scatter<XType,YType,TextType>(
            IEnumerable<XType> x,
            IEnumerable<YType> y,
            StyleParam.Mode mode,
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
            string? StackGroup = null,
            StyleParam.Orientation? Orientation = null,
            StyleParam.GroupNorm? GroupNorm = null,
            StyleParam.Fill? Fill = null,
            Color? FillColor = null,
            bool? UseWebGL = null,
            bool? UseDefaults = null
        )
            where XType : IConvertible
            where YType : IConvertible
            where TextType : class, IConvertible
        =>
            Plotly.NET.Chart2D.Chart.Scatter(
                x: x, 
                y: y, 
                mode: mode,
                Name: Helpers.ToOption(Name),
                ShowLegend: Helpers.ToOption(ShowLegend),
                Opacity: Helpers.ToOption(Opacity),
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
                LineWidth: Helpers.ToOption(LineWidth),
                LineDash: Helpers.ToOption(LineDash),
                Line: Helpers.ToOption(Line),
                StackGroup: Helpers.ToOption(StackGroup),
                Orientation: Helpers.ToOption(Orientation),
                GroupNorm: Helpers.ToOption(GroupNorm),
                Fill: Helpers.ToOption(Fill),
                FillColor: Helpers.ToOption(FillColor),
                UseWebGL: Helpers.ToOption(UseWebGL),
                UseDefaults: Helpers.ToOption(UseDefaults)
            );
    };
}
