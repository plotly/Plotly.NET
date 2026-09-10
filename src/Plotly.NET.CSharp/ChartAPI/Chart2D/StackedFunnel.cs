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
    /// Creates a stacked Funnel chart, a variation of the funnel chart where multiple funnel bars of each stage are stacked on top of each other.
    /// To create this type of chart, combine multiple of these charts via `Chart.combine`.
    ///
    /// Funnel charts visualize stages in a process using length-encoded bars. This trace can be used to show data in either a part-to-whole representation wherein each item appears in a single stage, or in a "drop-off" representation wherein each item appears in each stage it traversed. See also the "funnelarea" trace type for a different approach to visualizing funnel data.
    /// </summary>
    /// <param name="x">Sets the x coordinates of the plotted data.</param>
    /// <param name="y">Sets the y coordinates of the plotted data.</param>
    /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
    /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
    /// <param name="Opacity">Sets the Opacity of the trace.</param>
    /// <param name="Width">Sets the bar width (in position axis units).</param>
    /// <param name="Offset">Shifts the position where the bar is drawn (in position axis units). In "group" barmode, traces that set "offset" will be excluded and drawn in "overlay" mode instead.</param>
    /// <param name="Text">Sets a text associated with each datum</param>
    /// <param name="MultiText">Sets individual text for each datum</param>
    /// <param name="TextPosition">Sets the position of text associated with each datum</param>
    /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
    /// <param name="Orientation">Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used - including if `visible` is "legendonly" but not if it is `false`. Sets the stacking direction. With "v" ("h"), the y (x) values of subsequent traces are added. Also affects the default value of `fill`.</param>
    /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
    /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
    /// <param name="MarkerColor">Sets the color of the bars.</param>
    /// <param name="MarkerOutline">Sets the color of the bar outline.</param>
    /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments)</param>
    /// <param name="TextInfo">Determines which trace information appear on the graph. In the case of having multiple funnels, percentages and totals are computed separately (per trace).</param>
    /// <param name="ConnectorLineColor">Sets the line color of the funnel connector</param>
    /// <param name="ConnectorLineStyle">Sets the line style of the funnel connector</param>
    /// <param name="ConnectorFillColor">Sets the fill color of the funnel connector</param>
    /// <param name="ConnectorLine">Sets the line of the funnel connector (use this for more finegrained control than the other connector line associated arguments).</param>
    /// <param name="Connector">Sets the funnel connector (use this for more finegrained control than the other connector-associated arguments).</param>
    /// <param name="InsideTextFont">Sets the font used for `text` lying inside the bar.</param>
    /// <param name="OutsideTextFont">Sets the font used for `text` lying outside the bar.</param>
    /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
    public static GenericChart StackedFunnel<XType, YType, TextType>(
        IEnumerable<XType> x,
        IEnumerable<YType> y,
        Optional<string> Name = default,
        Optional<bool> ShowLegend = default,
        Optional<double> Opacity = default,
        Optional<double> Width = default,
        Optional<double> Offset = default,
        Optional<TextType> Text = default,
        Optional<IEnumerable<TextType>> MultiText = default,
        Optional<StyleParam.TextPosition> TextPosition = default,
        Optional<IEnumerable<StyleParam.TextPosition>> MultiTextPosition = default,
        Optional<StyleParam.Orientation> Orientation = default,
        Optional<string> AlignmentGroup = default,
        Optional<string> OffsetGroup = default,
        Optional<Color> MarkerColor = default,
        Optional<Line> MarkerOutline = default,
        Optional<Marker> Marker = default,
        Optional<StyleParam.TextInfo> TextInfo = default,
        Optional<Color> ConnectorLineColor = default,
        Optional<StyleParam.DrawingStyle> ConnectorLineStyle = default,
        Optional<Color> ConnectorFillColor = default,
        Optional<Line> ConnectorLine = default,
        Optional<FunnelConnector> Connector = default,
        Optional<Font> InsideTextFont = default,
        Optional<Font> OutsideTextFont = default,
        Optional<bool> UseDefaults = default
    )
        where XType : IConvertible
        where YType : IConvertible
        where TextType : IConvertible
        =>
            Plotly.NET.Chart2D_Funnel.Chart.StackedFunnel<XType, YType, TextType>(
                x: x,
                y: y,
                Name: Name.ToOption(),
                ShowLegend: ShowLegend.ToOption(),
                Opacity: Opacity.ToOption(),
                Width: Width.ToOption(),
                Offset: Offset.ToOption(),
                Text: Text.ToOption(),
                MultiText: MultiText.ToOption(),
                TextPosition: TextPosition.ToOption(),
                MultiTextPosition: MultiTextPosition.ToOption(),
                Orientation: Orientation.ToOption(),
                AlignmentGroup: AlignmentGroup.ToOption(),
                OffsetGroup: OffsetGroup.ToOption(),
                MarkerColor: MarkerColor.ToOption(),
                MarkerOutline: MarkerOutline.ToOption(),
                Marker: Marker.ToOption(),
                TextInfo: TextInfo.ToOption(),
                ConnectorLineColor: ConnectorLineColor.ToOption(),
                ConnectorLineStyle: ConnectorLineStyle.ToOption(),
                ConnectorFillColor: ConnectorFillColor.ToOption(),
                ConnectorLine: ConnectorLine.ToOption(),
                Connector: Connector.ToOption(),
                InsideTextFont: InsideTextFont.ToOption(),
                OutsideTextFont: OutsideTextFont.ToOption(),
                UseDefaults: UseDefaults.ToOption()
            );
}
