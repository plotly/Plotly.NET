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
        /// Creates a doughnut chart.
        ///
        /// A doughnut chart is a variation of the pie chart that has a fraction cut from the center of the slices.
        /// </summary>
        /// <param name="values">Sets the values of the sectors</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="Hole">Sets the fraction of the radius to cut out of the pie. Use this to make a donut chart.</param>
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
        /// <param name="MarkerPatternShape">Sets a pattern shape for all sections</param>
        /// <param name="MultiMarkerPatternShape">Sets an individual pattern shape for each section</param>
        /// <param name="MarkerPattern">Sets the marker pattern (use this for more finegrained control than the other pattern-associated arguments).</param>
        /// <param name="Marker">Sets the marker for the sections (use this for more finegrained control than the other marker-associated arguments).</param>
        /// <param name="TextInfo">Determines which trace information appear on the graph.</param>
        /// <param name="Direction">Specifies the direction at which succeeding sectors follow one another.</param>
        /// <param name="Rotation">Instead of the first slice starting at 12 o'clock, rotate to some other angle.</param>
        /// <param name="Sort">Determines whether or not the sectors are reordered from largest to smallest.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart Doughnut<ValuesType, LabelsType, TextType>(
            IEnumerable<ValuesType> values,
            Optional<string> Name = default,
            Optional<bool> ShowLegend = default,
            Optional<double> Opacity = default,
            Optional<IEnumerable<double>> MultiOpacity = default,
            Optional<IEnumerable<LabelsType>> Labels = default,
            Optional<double> Pull = default,
            Optional<IEnumerable<double>> MultiPull = default,
            Optional<TextType> Text = default,
            Optional<IEnumerable<TextType>> MultiText = default,
            Optional<StyleParam.TextPosition> TextPosition = default,
            Optional<IEnumerable<StyleParam.TextPosition>> MultiTextPosition = default,
            Optional<IEnumerable<Color>> SectionColors = default,
            Optional<Color> SectionOutlineColor = default,
            Optional<double> SectionOutlineWidth = default,
            Optional<IEnumerable<double>> SectionOutlineMultiWidth = default,
            Optional<Line> SectionOutline = default,
            Optional<StyleParam.PatternShape> MarkerPatternShape = default,
            Optional<IEnumerable<StyleParam.PatternShape>> MultiMarkerPatternShape = default,
            Optional<Pattern> MarkerPattern = default, 
            Optional<Marker> Marker = default,
            Optional<StyleParam.TextInfo> TextInfo = default,
            Optional<StyleParam.Direction> Direction = default,
            Optional<double> Hole = default,
            Optional<double> Rotation = default,
            Optional<bool> Sort = default,
            Optional<bool> UseDefaults = default
        )
            where ValuesType : IConvertible
            where LabelsType : IConvertible
            where TextType : IConvertible
            =>
                Plotly.NET.ChartDomain_Pie.Chart.Doughnut<ValuesType, LabelsType, TextType>(
                    values: values,
                    Name: Name.ToOption(),
                    ShowLegend: ShowLegend.ToOption(),
                    Opacity: Opacity.ToOption(),
                    MultiOpacity: MultiOpacity.ToOption(),
                    Labels: Labels.ToOption(),
                    Pull: Pull.ToOption(),
                    MultiPull: MultiPull.ToOption(),
                    Text: Text.ToOption(),
                    MultiText: MultiText.ToOption(),
                    TextPosition: TextPosition.ToOption(),
                    MultiTextPosition: MultiTextPosition.ToOption(),
                    SectionColors: SectionColors.ToOption(),
                    SectionOutlineColor: SectionOutlineColor.ToOption(),
                    SectionOutlineWidth: SectionOutlineWidth.ToOption(),
                    SectionOutlineMultiWidth: SectionOutlineMultiWidth.ToOption(),
                    SectionOutline: SectionOutline.ToOption(),
                    MarkerPatternShape: MarkerPatternShape.ToOption(),
                    MultiMarkerPatternShape: MultiMarkerPatternShape.ToOption(),
                    MarkerPattern: MarkerPattern.ToOption(),
                    Marker: Marker.ToOption(),
                    TextInfo: TextInfo.ToOption(),
                    Direction: Direction.ToOption(),
                    Hole: Hole.ToOption(),
                    Rotation: Rotation.ToOption(),
                    Sort: Sort.ToOption(),
                    UseDefaults: UseDefaults.ToOption()
                );
}
