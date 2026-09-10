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
            Plotly.NET.ChartCarpet_Scatter.Chart.SplineCarpet<AType, BType, TextType>(
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
}
