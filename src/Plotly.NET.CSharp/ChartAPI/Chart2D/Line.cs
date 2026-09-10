using System;
using System.Collections.Generic;
using Plotly.NET;
using Plotly.NET.LayoutObjects;
using Plotly.NET.TraceObjects;
using static Plotly.NET.StyleParam;

namespace Plotly.NET.CSharp;

public static partial class Chart
{
    /// <summary> Creates a Line chart, which uses a Line plotted between the given datums in a 2D space to visualize typically an evolution of Y depending on X.</summary>
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
    /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
    /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
    /// <param name="StackGroup">Set several traces (on the same subplot) to the same stackgroup in order to add their y values (or their x values if `Orientation` is Horizontal). Stacking also turns `fill` on by default and sets the default `mode` to "lines" irrespective of point count. ou can only stack on a numeric (linear or log) axis. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order</param>
    /// <param name="Orientation">Sets the stacking direction. Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used.</param>
    /// <param name="GroupNorm">Sets the normalization for the sum of this `stackgroup. Only relevant when `stackgroup` is used, and only the first `groupnorm` found in the `stackgroup` will be used</param>
    /// <param name="Fill">Sets the area to fill with a solid color. Defaults to "none" unless this trace is stacked, then it gets "tonexty" ("tonextx") if `orientation` is "v" ("h") Use with `FillColor` if not "none". "tozerox" and "tozeroy" fill to x=0 and y=0 respectively. "tonextx" and "tonexty" fill between the endpoints of this trace and the endpoints of the trace before it, connecting those endpoints with straight lines (to make a stacked area graph); if there is no trace before it, they behave like "tozerox" and "tozeroy". "toself" connects the endpoints of the trace (or each segment of the trace if it has gaps) into a closed shape. "tonext" fills the space between two traces if one completely encloses the other (eg consecutive contour lines), and behaves like "toself" if there is no trace before it. "tonext" should not be used if one trace does not enclose the other. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order.</param>
    /// <param name="FillColor">Sets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
    /// <param name="FillPattern">Sets the pattern within the marker.</param>
    /// <param name="UseWebGL">If true, plotly.js will use the WebGL engine to render this chart. use this when you want to render many objects at once.</param>
    /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
    public static GenericChart Line<XType, YType, TextType>(
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
        Optional<string> AlignmentGroup = default,
        Optional<string> OffsetGroup = default,
        Optional<string> StackGroup = default,
        Optional<StyleParam.Orientation> Orientation = default,
        Optional<StyleParam.GroupNorm> GroupNorm = default,
        Optional<StyleParam.Fill> Fill = default,
        Optional<Color> FillColor = default,
        Optional<Pattern> FillPattern = default,
        Optional<bool> UseWebGL = default,
        Optional<bool> UseDefaults = default
    )
        where XType : IConvertible
        where YType : IConvertible
        where TextType : IConvertible
    =>
        Plotly.NET.Chart2D_Scatter.Chart.Line(
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
            AlignmentGroup: AlignmentGroup.ToOption(),
            OffsetGroup: OffsetGroup.ToOption(),
            StackGroup: StackGroup.ToOption(),
            Orientation: Orientation.ToOption(),
            GroupNorm: GroupNorm.ToOption(),
            Fill: Fill.ToOption(),
            FillColor: FillColor.ToOption(),
            FillPattern: FillPattern.ToOption(),
            UseWebGL: UseWebGL.ToOption(),
            UseDefaults: UseDefaults.ToOption()
        );
}
