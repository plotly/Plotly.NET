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
        /// Creates a sunburst chart, which visualizes hierarchical data spanning outward radially from root to leaves.
        ///
        /// The hierarchy is defined by labels and parents attributes. The root starts from the center and children are added to the outer rings.
        /// </summary>
        /// <param name="labels">Sets the labels of each of the sectors.</param>
        /// <param name="parents">Sets the parent sectors for each of the sectors. Empty string items '' are understood to reference the root node in the hierarchy. If `ids` is filled, `parents` items are understood to be "ids" themselves. When `ids` is not set, plotly attempts to find matching items in `labels`, but beware they must be unique.</param>
        /// <param name="Values">Sets the values associated with each of the sectors.</param>
        /// <param name="Ids">Assigns id labels to each datum. These ids for object constancy of data points during animation.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
        /// <param name="MultiText">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
        /// <param name="SectionColors">Sets the colors associated with each section.</param>
        /// <param name="SectionColorScale">Sets the colorscale for the section values</param>
        /// <param name="ShowSectionColorScale">Whether or not to show the section colorbar</param>
        /// <param name="ReverseSectionColorScale">Whether or not to show the section colorscale</param>
        /// <param name="SectionOutlineColor">Sets the color of the section outline.</param>
        /// <param name="SectionOutlineWidth">Sets the width of the section outline.</param>
        /// <param name="SectionOutlineMultiWidth">Sets the width of each individual section outline.</param>
        /// <param name="SectionOutline">Sets the section outline (use this for more finegrained control than the other section outline-associated arguments).</param>
        /// <param name="MarkerPatternShape">Sets a pattern shape for all sections</param>
        /// <param name="MultiMarkerPatternShape">Sets an individual pattern shape for each section</param>
        /// <param name="MarkerPattern">Sets the marker pattern (use this for more finegrained control than the other pattern-associated arguments).</param>
        /// <param name="Marker">Sets the marker for the sections (use this for more finegrained control than the other marker-associated arguments).</param>
        /// <param name="TextInfo">Determines which trace information appear on the graph.</param>
        /// <param name="BranchValues">Determines how the items in `values` are summed. When set to "total", items in `values` are taken to be value of all its descendants. When set to "remainder", items in `values` corresponding to the root and the branches sectors are taken to be the extra part not part of the sum of the values at their leaves.</param>
        /// <param name="Count">Determines default for `values` when it is not provided, by inferring a 1 for each of the "leaves" and/or "branches", otherwise 0.</param>
        /// <param name="Root">Sets the styles for the root of this trace.</param>
        /// <param name="Leaf">Sets the styles for the leaves of this trace.</param>
        /// <param name="Level">Sets the level from which this trace hierarchy is rendered. Set `level` to `''` to start from the root node in the hierarchy. Must be an "id" if `ids` is filled in, otherwise plotly attempts to find a matching item in `labels`.</param>
        /// <param name="MaxDepth">Sets the number of rendered sectors from any given `level`. Set `maxdepth` to "-1" to render all the levels in the hierarchy.</param>
        /// <param name="Rotation">Rotates the whole diagram counterclockwise by some angle. By default the first slice starts at 3 o'clock.</param>
        /// <param name="Sort">Determines whether or not the sectors are reordered from largest to smallest.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart Sunburst<LabelsType, ParentsType, ValuesType, IdsType, TextType>(
            IEnumerable<LabelsType> labels,
            IEnumerable<ParentsType> parents,
            Optional<IEnumerable<ValuesType>> Values = default,
            Optional<IEnumerable<IdsType>> Ids = default,
            Optional<string> Name = default,
            Optional<bool> ShowLegend = default,
            Optional<double> Opacity = default,
            Optional<IEnumerable<double>> MultiOpacity = default,
            Optional<TextType> Text = default,
            Optional<IEnumerable<TextType>> MultiText = default,
            Optional<IEnumerable<Color>> SectionColors = default,
            Optional<StyleParam.Colorscale> SectionColorScale = default,
            Optional<bool> ShowSectionColorScale = default,
            Optional<bool> ReverseSectionColorScale = default,
            Optional<Color> SectionOutlineColor = default,
            Optional<double> SectionOutlineWidth = default,
            Optional<IEnumerable<double>> SectionOutlineMultiWidth = default,
            Optional<Line> SectionOutline = default,
            Optional<StyleParam.PatternShape> MarkerPatternShape = default,
            Optional<IEnumerable<StyleParam.PatternShape>> MultiMarkerPatternShape = default,
            Optional<Pattern> MarkerPattern = default, 
            Optional<Marker> Marker = default,
            Optional<StyleParam.TextInfo> TextInfo = default,
            Optional<StyleParam.BranchValues> BranchValues = default,
            Optional<string> Count = default,
            Optional<SunburstRoot> Root = default,
            Optional<SunburstLeaf> Leaf = default,
            Optional<string> Level = default,
            Optional<int> MaxDepth = default,
            Optional<int> Rotation = default,
            Optional<bool> Sort = default,
            Optional<bool> UseDefaults = default
        )
            where LabelsType : IConvertible
            where ParentsType : IConvertible
            where ValuesType : IConvertible
            where IdsType : IConvertible
            where TextType : IConvertible
            =>
                Plotly.NET.ChartDomain_Hierarchy.Chart.Sunburst<LabelsType, ParentsType, ValuesType, IdsType, TextType>(
                    labels: labels,
                    parents: parents,
                    Values: Values.ToOption(),
                    Ids: Ids.ToOption(),
                    Name: Name.ToOption(),
                    ShowLegend: ShowLegend.ToOption(),
                    Opacity: Opacity.ToOption(),
                    MultiOpacity: MultiOpacity.ToOption(),
                    Text: Text.ToOption(),
                    MultiText: MultiText.ToOption(),
                    SectionColors: SectionColors.ToOption(),
                    SectionColorScale: SectionColorScale.ToOption(),
                    ShowSectionColorScale: ShowSectionColorScale.ToOption(),
                    ReverseSectionColorScale: ReverseSectionColorScale.ToOption(),
                    SectionOutlineColor: SectionOutlineColor.ToOption(),
                    SectionOutlineWidth: SectionOutlineWidth.ToOption(),
                    SectionOutlineMultiWidth: SectionOutlineMultiWidth.ToOption(),
                    SectionOutline: SectionOutline.ToOption(),
                    MarkerPatternShape: MarkerPatternShape.ToOption(),
                    MultiMarkerPatternShape: MultiMarkerPatternShape.ToOption(),
                    MarkerPattern: MarkerPattern.ToOption(),
                    Marker: Marker.ToOption(),
                    TextInfo: TextInfo.ToOption(),
                    BranchValues: BranchValues.ToOption(),
                    Count: Count.ToOption(),
                    Root: Root.ToOption(),
                    Leaf: Leaf.ToOption(),
                    Level: Level.ToOption(),
                    MaxDepth: MaxDepth.ToOption(),
                    Rotation: Rotation.ToOption(),
                    Sort: Sort.ToOption(),
                    UseDefaults: UseDefaults.ToOption()
                );
}
