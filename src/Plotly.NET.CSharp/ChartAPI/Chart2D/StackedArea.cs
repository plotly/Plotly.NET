using System;
using System.Collections.Generic;
using Plotly.NET;
using Plotly.NET.LayoutObjects;
using Plotly.NET.TraceObjects;
using static Plotly.NET.StyleParam;

namespace Plotly.NET.CSharp;

public static partial class Chart
{
    /// <summary> Creates a stacked Area chart, which uses a Line plotted between the given datums in a 2D space, additionally colouring the area between the line and the Y Axis. Multiple Charts of this type are stacked on top of each others y dimensions</summary>
    /// <param name="x">Sets the x coordinates of the plotted data.</param>
    /// <param name="y">Sets the y coordinates of the plotted data.</param>
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
    /// <param name="Orientation">Sets the stacking direction. Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used.</param>
    /// <param name="GroupNorm">Sets the normalization for the sum of this `stackgroup. Only relevant when `stackgroup` is used, and only the first `groupnorm` found in the `stackgroup` will be used</param>
    /// <param name="FillColor">ets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
    /// <param name="FillPatternShape">Sets a pattern shape for the area fill</param>
    /// <param name="FillPattern">Sets the pattern within the area. (use this for more finegrained control than the other fillpattern-associated arguments).</param>
    /// <param name="UseWebGL">If true, plotly.js will use the WebGL engine to render this chart. use this when you want to render many objects at once.</param>
    /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
    public static GenericChart StackedArea<XType, YType, TextType>(
        IEnumerable<XType> x,
        IEnumerable<YType> y,
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
        Optional<StyleParam.Orientation> Orientation = default,
        Optional<StyleParam.GroupNorm> GroupNorm = default,
        Optional<Color> FillColor = default,
        Optional<StyleParam.PatternShape> FillPatternShape = default,
        Optional<Pattern> FillPattern = default,
        Optional<bool> UseWebGL = default,
        Optional<bool> UseDefaults = default
    )
        where XType : IConvertible
        where YType : IConvertible
        where TextType : IConvertible
    =>
        Plotly.NET.Chart2D_Area.Chart.StackedArea<XType, YType, TextType>(
            x: x,
            y: y,
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
            Orientation: Orientation.ToOption(),
            GroupNorm: GroupNorm.ToOption(),
            FillColor: FillColor.ToOption(),
            FillPatternShape: FillPatternShape.ToOption(),
            FillPattern: FillPattern.ToOption(),
            UseWebGL: UseWebGL.ToOption(),
            UseDefaults: UseDefaults.ToOption()
        );
}
