using Plotly.NET;
using Plotly.NET.LayoutObjects;
using Plotly.NET.TraceObjects;
using System.Runtime.InteropServices;


namespace Plotly.NET.CSharp
{
    public static partial class Chart
    {
        /// <summary>
        /// Creates a pie chart.
        ///
        /// A pie chart (or a circle chart) is a circular statistical graphic, which is divided into slices to illustrate numerical proportion.
        /// In a pie chart, the arc length of each slice (and consequently its central angle and area), is proportional to the quantity it represents.
        /// </summary>
        /// <param name="values">Sets the values of the sectors</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Labels">Sets the sector labels. If `labels` entries are duplicated, the associated `values` are summed.</param>
        /// <param name="Pull">Sets the fraction of larger radius to pull the sectors out from the center. This can be a constant to pull all slices apart from each other equally or an array to highlight one or more slices.</param>
        /// <param name="MultiPull">Sets the fraction of larger radius to pull the sectors out from the center. This can be a constant to pull all slices apart from each other equally or an array to highlight one or more slices.</param>
        /// <param name="Text">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
        /// <param name="MultiText">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
        /// <param name="TextPosition">Sets the positions of the `text` elements with respects to the (x,y) coordinates.</param>
        /// <param name="MultiTextPosition">Sets the positions of the `text` elements with respects to the (x,y) coordinates.</param>
        /// <param name="SectionColors">Sets the colors associated with each section.</param>
        /// <param name="SectionOutlineColor">Sets the color of the section outline.</param>
        /// <param name="SectionOutlineWidth">Sets the width of the section outline.</param>
        /// <param name="SectionOutlineMultiWidth">Sets the width of each individual section outline.</param>
        /// <param name="SectionOutline">Sets the section outline (use this for more finegrained control than the other section outline-associated arguments).</param>
        /// <param name="Marker">Sets the marker of this trace.</param>
        /// <param name="TextInfo">Determines which trace information appear on the graph.</param>
        /// <param name="Direction">Specifies the direction at which succeeding sectors follow one another.</param>
        /// <param name="Hole">Sets the fraction of the radius to cut out of the pie. Use this to make a donut chart.</param>
        /// <param name="Rotation">Instead of the first slice starting at 12 o'clock, rotate to some other angle.</param>
        /// <param name="Sort">Determines whether or not the sectors are reordered from largest to smallest.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart.GenericChart Pie<ValuesType, LabelsType, TextType>(
            IEnumerable<ValuesType> values,
            [Optional] string? Name,
            [Optional] bool? ShowLegend,
            [Optional] double? Opacity,
            [Optional] IEnumerable<double>? MultiOpacity,
            [Optional] IEnumerable<LabelsType>? Labels,
            [Optional] double? Pull,
            [Optional] IEnumerable<double>? MultiPull,
            [Optional] TextType? Text,
            [Optional] IEnumerable<TextType>? MultiText,
            [Optional] StyleParam.TextPosition? TextPosition,
            [Optional] IEnumerable<StyleParam.TextPosition>? MultiTextPosition,
            [Optional] IEnumerable<Color>? SectionColors,
            [Optional] Color? SectionOutlineColor,
            [Optional] double? SectionOutlineWidth,
            [Optional] IEnumerable<double>? SectionOutlineMultiWidth,
            [Optional] Line? SectionOutline,
            [Optional] Marker? Marker,
            [Optional] StyleParam.TextInfo? TextInfo,
            [Optional] StyleParam.Direction? Direction,
            [Optional] double? Hole,
            [Optional] double? Rotation,
            [Optional] bool? Sort,
            [Optional] bool? UseDefaults
        )
            where ValuesType : IConvertible
            where LabelsType : IConvertible
            where TextType : IConvertible
            =>
                Plotly.NET.ChartDomain.Chart.Pie<ValuesType, LabelsType, TextType>(
                    values: values,
                    Name: Name.ToOption(),
                    ShowLegend: ShowLegend.ToOptionV(),
                    Opacity: Opacity.ToOptionV(),
                    MultiOpacity: MultiOpacity.ToOption(),
                    Labels: Labels.ToOption(),
                    Pull: Pull.ToOptionV(),
                    MultiPull: MultiPull.ToOption(),
                    Text: Text.ToOption(),
                    MultiText: MultiText.ToOption(),
                    TextPosition: TextPosition.ToOption(),
                    MultiTextPosition: MultiTextPosition.ToOption(),
                    SectionColors: SectionColors.ToOption(),
                    SectionOutlineColor: SectionOutlineColor.ToOption(),
                    SectionOutlineWidth: SectionOutlineWidth.ToOptionV(),
                    SectionOutlineMultiWidth: SectionOutlineMultiWidth.ToOption(),
                    SectionOutline: SectionOutline.ToOption(),
                    Marker: Marker.ToOption(),
                    TextInfo: TextInfo.ToOption(),
                    Direction: Direction.ToOption(),
                    Hole: Hole.ToOptionV(),
                    Rotation: Rotation.ToOptionV(),
                    Sort: Sort.ToOptionV(),
                    UseDefaults: UseDefaults.ToOptionV()
                );

    }
}
