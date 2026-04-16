namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects

open DynamicObj
open System
open System.IO

open StyleParam
open System.Runtime.InteropServices
open System.Runtime.CompilerServices

[<AutoOpen>]
module ChartDomain_Relations =

    [<Extension>]
    type Chart =
        /// <summary>
        /// Creates a parallel coordinates plot.
        ///
        /// Parallel coordinates are a common way of visualizing and analyzing high-dimensional datasets.
        ///
        /// To show a set of points in an n-dimensional space, a backdrop is drawn consisting of n parallel lines, typically vertical and equally spaced. A point in n-dimensional space is represented as a polyline with vertices on the parallel axes; the position of the vertex on the i-th axis corresponds to the i-th coordinate of the point.
        ///
        /// This visualization is closely related to time series visualization, except that it is applied to data where the axes do not correspond to points in time, and therefore do not have a natural order. Therefore, different axis arrangements may be of interest.
        /// </summary>
        /// <param name="dimensions">the dimensions of the plot, containing both dimension backdrop information and the associated data</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="LineColor">Sets the color of the lines that are connecting the datums on the dimensions</param>
        /// <param name="LineColorScale">Sets the colorscale of the lines that are connecting the datums on the dimensions</param>
        /// <param name="ShowLineColorScale">Whether or not to show the colorbar of the lines that are connecting the datums on the dimensions</param>
        /// <param name="ReverseLineColorScale">Whether or not to reverse the colorscale of the lines that are connecting the datums on the dimensions</param>
        /// <param name="Line">Sets the lines that are connecting the datums on the dimensions (use this for more finegrained control than the other line-associated arguments).</param>
        /// <param name="LabelAngle">Sets the angle of the labels with respect to the horizontal. For example, a `tickangle` of -90 draws the labels vertically. Tilted labels with "labelangle" may be positioned better inside margins when `labelposition` is set to "bottom".</param>
        /// <param name="LabelFont">Sets the label font of this trace.</param>
        /// <param name="LabelSide">Specifies the location of the `label`. "top" positions labels above, next to the title "bottom" positions labels below the graph Tilted labels with "labelangle" may be positioned better inside margins when `labelposition` is set to "bottom".</param>
        /// <param name="RangeFont">Sets the range font of this trace.</param>
        /// <param name="TickFont">Sets the tick font of this trace.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member ParallelCoord
            (
                dimensions: seq<Dimension>,
                ?Name: string,
                ?LineColor: Color,
                ?LineColorScale: StyleParam.Colorscale,
                ?ShowLineColorScale: bool,
                ?ReverseLineColorScale: bool,
                ?Line: Line,
                ?LabelAngle: int,
                ?LabelFont: Font,
                ?LabelSide: StyleParam.Side,
                ?RangeFont: Font,
                ?TickFont: Font,
                ?UseDefaults: bool
            ) =
            let useDefaults =
                defaultArg UseDefaults true

            let line =
                Line
                |> Option.defaultValue (Plotly.NET.Line.init ())
                |> Plotly.NET.Line.style (
                    ?Color = LineColor,
                    ?Colorscale = LineColorScale,
                    ?ShowScale = ShowLineColorScale,
                    ?ReverseScale = ReverseLineColorScale
                )

            TraceDomain.initParallelCoord (
                TraceDomainStyle.ParallelCoord(
                    Dimensions = dimensions,
                    Line = line,
                    ?Name = Name,
                    ?LabelAngle = LabelAngle,
                    ?LabelFont = LabelFont,
                    ?LabelSide = LabelSide,
                    ?RangeFont = RangeFont,
                    ?TickFont = TickFont
                )
            )
            |> GenericChart.ofTraceObject useDefaults

        /// <summary>
        /// Creates a parallel coordinates plot.
        ///
        /// Parallel coordinates are a common way of visualizing and analyzing high-dimensional datasets.
        ///
        /// To show a set of points in an n-dimensional space, a backdrop is drawn consisting of n parallel lines, typically vertical and equally spaced. A point in n-dimensional space is represented as a polyline with vertices on the parallel axes; the position of the vertex on the i-th axis corresponds to the i-th coordinate of the point.
        ///
        /// This visualization is closely related to time series visualization, except that it is applied to data where the axes do not correspond to points in time, and therefore do not have a natural order. Therefore, different axis arrangements may be of interest.
        /// </summary>
        /// <param name="keyValues">Sets the values for each dimension of the plot, together with the name of the respective dimension</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="LineColor">Sets the color of the lines that are connecting the datums on the dimensions</param>
        /// <param name="LineColorScale">Sets the colorscale of the lines that are connecting the datums on the dimensions</param>
        /// <param name="ShowLineColorScale">Whether or not to show the colorbar of the lines that are connecting the datums on the dimensions</param>
        /// <param name="ReverseLineColorScale">Whether or not to reverse the colorscale of the lines that are connecting the datums on the dimensions</param>
        /// <param name="Line">Sets the lines that are connecting the datums on the dimensions (use this for more finegrained control than the other line-associated arguments).</param>
        /// <param name="LabelAngle">Sets the angle of the labels with respect to the horizontal. For example, a `tickangle` of -90 draws the labels vertically. Tilted labels with "labelangle" may be positioned better inside margins when `labelposition` is set to "bottom".</param>
        /// <param name="LabelFont">Sets the label font of this trace.</param>
        /// <param name="LabelSide">Specifies the location of the `label`. "top" positions labels above, next to the title "bottom" positions labels below the graph Tilted labels with "labelangle" may be positioned better inside margins when `labelposition` is set to "bottom".</param>
        /// <param name="RangeFont">Sets the range font of this trace.</param>
        /// <param name="TickFont">Sets the tick font of this trace.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member ParallelCoord
            (
                keyValues: seq<string * #seq<#IConvertible>>,
                ?Name: string,
                ?LineColor: Color,
                ?LineColorScale: StyleParam.Colorscale,
                ?ShowLineColorScale: bool,
                ?ReverseLineColorScale: bool,
                ?Line: Line,
                ?LabelAngle: int,
                ?LabelFont: Font,
                ?LabelSide: StyleParam.Side,
                ?RangeFont: Font,
                ?TickFont: Font,
                ?UseDefaults: bool
            ) =

            let dims =
                keyValues |> Seq.map (fun (key, vals) -> Dimension.initParallel (Label = key, Values = vals))

            Chart.ParallelCoord(
                dimensions = dims,
                ?Name = Name,
                ?LineColor = LineColor,
                ?LineColorScale = LineColorScale,
                ?ShowLineColorScale = ShowLineColorScale,
                ?ReverseLineColorScale = ReverseLineColorScale,
                ?Line = Line,
                ?LabelAngle = LabelAngle,
                ?LabelFont = LabelFont,
                ?LabelSide = LabelSide,
                ?RangeFont = RangeFont,
                ?TickFont = TickFont,
                ?UseDefaults = UseDefaults
            )

        /// <summary>
        /// Creates a parallel categories plot.
        ///
        /// The parallel categories diagram (also known as parallel sets or alluvial diagram) is a visualization of
        /// multi-dimensional categorical data sets. Each variable in the data set is represented by a column of rectangles,
        /// where each rectangle corresponds to a discrete value taken on by that variable.
        /// The relative heights of the rectangles reflect the relative frequency of occurrence of the corresponding value.
        /// </summary>
        /// <param name="dimensions">the dimensions of the plot, containing both dimension backdrop information and the associated data</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="Counts">The number of observations represented by each state. Defaults to 1 so that each state represents one observation</param>
        /// <param name="LineColor">Sets the color of the lines that are connecting the datums on the dimensions</param>
        /// <param name="LineShape">Sets the shape of the lines that are connecting the datums on the dimensions</param>
        /// <param name="LineColorScale">Sets the colorscale of the lines that are connecting the datums on the dimensions</param>
        /// <param name="ShowLineColorScale">Whether or not to show the colorbar of the lines that are connecting the datums on the dimensions</param>
        /// <param name="ReverseLineColorScale">Whether or not to reverse the colorscale of the lines that are connecting the datums on the dimensions</param>
        /// <param name="Line">Sets the lines that are connecting the datums on the dimensions (use this for more finegrained control than the other line-associated arguments).</param>
        /// <param name="Arrangement">Sets the drag interaction mode for categories and dimensions. If `perpendicular`, the categories can only move along a line perpendicular to the paths. If `freeform`, the categories can freely move on the plane. If `fixed`, the categories and dimensions are stationary.</param>
        /// <param name="BundleColors">Sort paths so that like colors are bundled together within each category.</param>
        /// <param name="SortPaths">Sets the path sorting algorithm. If `forward`, sort paths based on dimension categories from left to right. If `backward`, sort paths based on dimensions categories from right to left.</param>
        /// <param name="LabelFont">Sets the label font of this trace.</param>
        /// <param name="TickFont">Sets the tick font of this trace.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member ParallelCategories
            (
                dimensions: seq<Dimension>,
                ?Name: string,
                ?Counts: int,
                ?LineColor: Color,
                ?LineShape: StyleParam.Shape,
                ?LineColorScale: StyleParam.Colorscale,
                ?ShowLineColorScale: bool,
                ?ReverseLineColorScale: bool,
                ?Line: Line,
                ?Arrangement: StyleParam.CategoryArrangement,
                ?BundleColors: bool,
                ?SortPaths: StyleParam.SortAlgorithm,
                ?LabelFont: Font,
                ?TickFont: Font,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let line =
                Line
                |> Option.defaultValue (Plotly.NET.Line.init ())
                |> Plotly.NET.Line.style (
                    ?Color = LineColor,
                    ?Shape = LineShape,
                    ?Colorscale = LineColorScale,
                    ?ShowScale = ShowLineColorScale,
                    ?ReverseScale = ReverseLineColorScale
                )

            TraceDomain.initParallelCategories (
                TraceDomainStyle.ParallelCategories(
                    Dimensions = dimensions,
                    Line = line,
                    ?Name = Name,
                    ?Counts = Counts,
                    ?Arrangement = Arrangement,
                    ?BundleColors = BundleColors,
                    ?SortPaths = SortPaths,
                    ?LabelFont = LabelFont,
                    ?TickFont = TickFont
                )
            )

            |> GenericChart.ofTraceObject useDefaults

        /// <summary>
        /// Creates a parallel categories plot.
        ///
        /// The parallel categories diagram (also known as parallel sets or alluvial diagram) is a visualization of
        /// multi-dimensional categorical data sets. Each variable in the data set is represented by a column of rectangles,
        /// where each rectangle corresponds to a discrete value taken on by that variable.
        /// The relative heights of the rectangles reflect the relative frequency of occurrence of the corresponding value.
        /// </summary>
        /// <param name="keyValues">Sets the values for each dimension of the plot, together with the name of the respective dimension</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="Counts">The number of observations represented by each state. Defaults to 1 so that each state represents one observation</param>
        /// <param name="LineColor">Sets the color of the lines that are connecting the datums on the dimensions</param>
        /// <param name="LineShape">Sets the shape of the lines that are connecting the datums on the dimensions</param>
        /// <param name="LineColorScale">Sets the colorscale of the lines that are connecting the datums on the dimensions</param>
        /// <param name="ShowLineColorScale">Whether or not to show the colorbar of the lines that are connecting the datums on the dimensions</param>
        /// <param name="ReverseLineColorScale">Whether or not to reverse the colorscale of the lines that are connecting the datums on the dimensions</param>
        /// <param name="Line">Sets the lines that are connecting the datums on the dimensions (use this for more finegrained control than the other line-associated arguments).</param>
        /// <param name="Arrangement">Sets the drag interaction mode for categories and dimensions. If `perpendicular`, the categories can only move along a line perpendicular to the paths. If `freeform`, the categories can freely move on the plane. If `fixed`, the categories and dimensions are stationary.</param>
        /// <param name="BundleColors">Sort paths so that like colors are bundled together within each category.</param>
        /// <param name="SortPaths">Sets the path sorting algorithm. If `forward`, sort paths based on dimension categories from left to right. If `backward`, sort paths based on dimensions categories from right to left.</param>
        /// <param name="LabelFont">Sets the label font of this trace.</param>
        /// <param name="TickFont">Sets the tick font of this trace.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member ParallelCategories
            (
                keyValues: seq<string * #seq<#IConvertible>>,
                ?Name: string,
                ?Counts: int,
                ?LineColor: Color,
                ?LineShape: StyleParam.Shape,
                ?LineColorScale: StyleParam.Colorscale,
                ?ShowLineColorScale: bool,
                ?ReverseLineColorScale: bool,
                ?Line: Line,
                ?Arrangement: StyleParam.CategoryArrangement,
                ?BundleColors: bool,
                ?SortPaths: StyleParam.SortAlgorithm,
                ?LabelFont: Font,
                ?TickFont: Font,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let dims =
                keyValues |> Seq.map (fun (key, vals) -> Dimension.initParallel (Label = key, Values = vals))

            let line =
                Line
                |> Option.defaultValue (Plotly.NET.Line.init ())
                |> Plotly.NET.Line.style (
                    ?Color = LineColor,
                    ?Shape = LineShape,
                    ?Colorscale = LineColorScale,
                    ?ShowScale = ShowLineColorScale,
                    ?ReverseScale = ReverseLineColorScale
                )

            TraceDomain.initParallelCategories (
                TraceDomainStyle.ParallelCategories(
                    Dimensions = dims,
                    Line = line,
                    ?Name = Name,
                    ?Counts = Counts,
                    ?Arrangement = Arrangement,
                    ?BundleColors = BundleColors,
                    ?SortPaths = SortPaths,
                    ?LabelFont = LabelFont,
                    ?TickFont = TickFont
                )
            )
            |> GenericChart.ofTraceObject useDefaults

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
        [<Extension>]
        static member Sankey
            (
                nodes: SankeyNodes,
                links: SankeyLinks,
                ?Name: string,
                ?Ids: seq<#IConvertible>,
                ?Orientation: StyleParam.Orientation,
                ?TextFont: Font,
                ?Arrangement: StyleParam.CategoryArrangement,
                ?ValueFormat: string,
                ?ValueSuffix: string,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            TraceDomain.initSankey (
                TraceDomainStyle.Sankey(
                    Node = nodes,
                    Link = links,
                    ?Name = Name,
                    ?Ids = Ids,
                    ?Orientation = Orientation,
                    ?TextFont = TextFont,
                    ?Arrangement = Arrangement,
                    ?ValueFormat = ValueFormat,
                    ?ValueSuffix = ValueSuffix

                )
            )
            |> GenericChart.ofTraceObject useDefaults

        /// <summary>
        /// Creates a sankey diagram.
        ///
        /// A Sankey diagram is a flow diagram, in which the width of arrows is proportional to the flow quantity.
        ///
        /// Sankey diagrams visualize the contributions to a flow by defining source to represent the source node, target for the target node, value to set the flow volume, and label that shows the node name.        /// </summary>
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
        /// <param name="ValueFormat">Sets the value formatting rule using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format.</param>
        /// <param name="ValueSuffix">Adds a unit to follow the value in the hover tooltip. Add a space if a separation is necessary from the value.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Sankey
            (
                nodeLabels: seq<string>,
                linkedNodeIds: seq<int * int>,
                linkValues: seq<#IConvertible>,
                ?NodeColor: Color,
                ?NodeOutlineColor: Color,
                ?NodeOutlineWidth: float,
                ?NodeThickness: int,
                ?NodeGroups: seq<#seq<int>>,
                ?LinkColor: Color,
                ?LinkColorScales: seq<StyleParam.Colorscale>,
                ?LinkOutlineColor: Color,
                ?LinkOutlineWidth: float,
                ?LinkLabels: seq<string>,
                ?Name: string,
                ?Ids: seq<#IConvertible>,
                ?Orientation: StyleParam.Orientation,
                ?TextFont: Font,
                ?Arrangement: StyleParam.CategoryArrangement,
                ?ValueFormat: string,
                ?ValueSuffix: string,
                ?UseDefaults: bool
            ) =

            let nodeOutline =
                Line.init (?Color = NodeOutlineColor, ?Width = NodeOutlineWidth)

            let nodes =
                SankeyNodes.init (
                    Label = nodeLabels,
                    Line = nodeOutline,
                    ?Color = NodeColor,
                    ?Thickness = NodeThickness,
                    ?Groups = NodeGroups
                )

            let linkOutline =
                Line.init (?Color = LinkOutlineColor, ?Width = LinkOutlineWidth)

            let sources, targets =
                Seq.unzip linkedNodeIds

            let colorScales =
                LinkColorScales
                |> Option.map (fun c -> c |> Seq.map (fun cs -> SankeyLinkColorscale.init (ColorScale = cs)))

            let links =
                SankeyLinks.init (
                    Source = sources,
                    Target = targets,
                    Line = linkOutline,
                    Value = linkValues,
                    ?ColorScales = colorScales,
                    ?Color = LinkColor,
                    ?Label = LinkLabels
                )

            Chart.Sankey(
                nodes,
                links,
                ?Name = Name,
                ?Ids = Ids,
                ?Orientation = Orientation,
                ?TextFont = TextFont,
                ?Arrangement = Arrangement,
                ?ValueFormat = ValueFormat,
                ?ValueSuffix = ValueSuffix,
                ?UseDefaults = UseDefaults
            )

