using System;
using System.Collections.Generic;
using System.Linq;
using Plotly.NET;
using Plotly.NET.LayoutObjects;
using Plotly.NET.TraceObjects;
using static Plotly.NET.StyleParam;

namespace Plotly.NET.CSharp;

public static partial class Chart
{
        /// <summary>
        /// Creates a sankey diagram.
        ///
        /// A Sankey diagram is a flow diagram, in which the width of arrows is proportional to the flow quantity.
        ///
        /// Sankey diagrams visualize the contributions to a flow by defining source to represent the source node, target for the target node, value to set the flow volume, and label that shows the node name.
        /// </summary>
        /// <param name="nodes">Sets the nodes of the Sankey plot.</param>
        /// <param name="links">Sets the links between nodes of the Sankey plot.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="Ids">Assigns id labels to each datum.</param>
        /// <param name="Orientation">Sets the orientation of the Sankey diagram.</param>
        /// <param name="TextFont">Sets the text font of this trace.</param>
        /// <param name="Arrangement">If value is `snap` (the default), the node arrangement is assisted by automatic snapping of elements to preserve space between nodes specified via `nodepad`. If value is `perpendicular`, the nodes can only move along a line perpendicular to the flow. If value is `freeform`, the nodes can freely move on the plane. If value is `fixed`, the nodes are stationary.</param>
        /// <param name="ValueFormat">Sets the value formatting rule using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format.</param>
        /// <param name="ValueSuffix">Adds a unit to follow the value in the hover tooltip. Add a space if a separation is necessary from the value.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart Sankey<IdsType>(
            SankeyNodes nodes,
            SankeyLinks links,
            Optional<string> Name = default,
            Optional<IEnumerable<IdsType>> Ids = default,
            Optional<StyleParam.Orientation> Orientation = default,
            Optional<Font> TextFont = default,
            Optional<StyleParam.CategoryArrangement> Arrangement = default,
            Optional<string> ValueFormat = default,
            Optional<string> ValueSuffix = default,
            Optional<bool> UseDefaults = default
        )
            where IdsType : IConvertible
            =>
                Plotly.NET.ChartDomain_Relations.Chart.Sankey<IdsType>(
                    nodes: nodes,
                    links: links,
                    Name: Name.ToOption(),
                    Ids: Ids.ToOption(),
                    Orientation: Orientation.ToOption(),
                    TextFont: TextFont.ToOption(),
                    Arrangement: Arrangement.ToOption(),
                    ValueFormat: ValueFormat.ToOption(),
                    ValueSuffix: ValueSuffix.ToOption(),
                    UseDefaults: UseDefaults.ToOption()
                );

        /// <summary>
        /// Creates a sankey diagram.
        ///
        /// A Sankey diagram is a flow diagram, in which the width of arrows is proportional to the flow quantity.
        /// </summary>
        /// <param name="nodeLabels">Sets the labels of the nodes in the sankey diagram</param>
        /// <param name="linkedNodeIds">(source, target) tuples which indicate connected nodes. These values map to the index in `nodeLabels`</param>
        /// <param name="linkValues">The values for the links in the sankey diagram.</param>
        /// <param name="NodeColor">Sets the color of the nodes in the sankey diagram.</param>
        /// <param name="NodeOutlineColor">Sets the color of the node outlines in the sankey diagram.</param>
        /// <param name="NodeOutlineWidth">Sets the outline width of the nodes in the sankey diagram.</param>
        /// <param name="NodeThickness">Sets the thickness of the nodes in the sankey diagram.</param>
        /// <param name="NodeGroups">Sets groups of nodes. Each group is defined by an array with the indices of the nodes it contains. Multiple groups can be specified.</param>
        /// <param name="LinkColor">Sets the color of the links in the sankey diagram.</param>
        /// <param name="LinkColorScales">Sets the colorscale of the links in the sankey diagram.</param>
        /// <param name="LinkOutlineColor">Sets the outline color of the links in the sankey diagram.</param>
        /// <param name="LinkOutlineWidth">Sets the outline width of the links in the sankey diagram.</param>
        /// <param name="LinkLabels">Sets the labels of the links in the sankey diagram.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="Ids">Assigns id labels to each datum.</param>
        /// <param name="Orientation">Sets the orientation of the Sankey diagram.</param>
        /// <param name="TextFont">Sets the text font of this trace.</param>
        /// <param name="Arrangement">If value is `snap` (the default), the node arrangement is assisted by automatic snapping of elements to preserve space between nodes specified via `nodepad`. If value is `perpendicular`, the nodes can only move along a line perpendicular to the flow. If value is `freeform`, the nodes can freely move on the plane. If value is `fixed`, the nodes are stationary.</param>
        /// <param name="NodeAlign">Sets the horizontal alignment of the nodes in the Sankey diagram. If value is `justify` (the default), the nodes are spread to fill the width. If value is `left`, `right`, or `center`, the nodes are aligned accordingly.</param>
        /// <param name="ValueFormat">Sets the value formatting rule using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format.</param>
        /// <param name="ValueSuffix">Adds a unit to follow the value in the hover tooltip. Add a space if a separation is necessary from the value.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart Sankey<LinkValuesType, IdsType>(
            IEnumerable<string> nodeLabels,
            IEnumerable<(int, int)> linkedNodeIds,
            IEnumerable<LinkValuesType> linkValues,
            Optional<Color> NodeColor = default,
            Optional<Color> NodeOutlineColor = default,
            Optional<double> NodeOutlineWidth = default,
            Optional<int> NodeThickness = default,
            Optional<IEnumerable<IEnumerable<int>>> NodeGroups = default,
            Optional<Color> LinkColor = default,
            Optional<IEnumerable<StyleParam.Colorscale>> LinkColorScales = default,
            Optional<Color> LinkOutlineColor = default,
            Optional<double> LinkOutlineWidth = default,
            Optional<IEnumerable<string>> LinkLabels = default,
            Optional<string> Name = default,
            Optional<IEnumerable<IdsType>> Ids = default,
            Optional<StyleParam.Orientation> Orientation = default,
            Optional<Font> TextFont = default,
            Optional<StyleParam.CategoryArrangement> Arrangement = default,
            Optional<StyleParam.SankeyNodeAlign> NodeAlign = default,
            Optional<string> ValueFormat = default,
            Optional<string> ValueSuffix = default,
            Optional<bool> UseDefaults = default
        )
            where LinkValuesType : IConvertible
            where IdsType : IConvertible
            =>
                Plotly.NET.ChartDomain_Relations.Chart.Sankey<LinkValuesType, IEnumerable<int>, IdsType>(
                    nodeLabels,
                    linkedNodeIds.Select(link => link.ToTuple()),
                    linkValues,
                    NodeColor.ToOption(),
                    NodeOutlineColor.ToOption(),
                    NodeOutlineWidth.ToOption(),
                    NodeThickness.ToOption(),
                    NodeGroups.ToOption(),
                    LinkColor.ToOption(),
                    LinkColorScales.ToOption(),
                    LinkOutlineColor.ToOption(),
                    LinkOutlineWidth.ToOption(),
                    LinkLabels.ToOption(),
                    Name.ToOption(),
                    Ids.ToOption(),
                    Orientation.ToOption(),
                    TextFont.ToOption(),
                    Arrangement.ToOption(),
                    NodeAlign.ToOption(),
                    ValueFormat.ToOption(),
                    ValueSuffix.ToOption(),
                    UseDefaults.ToOption()
                );
}
