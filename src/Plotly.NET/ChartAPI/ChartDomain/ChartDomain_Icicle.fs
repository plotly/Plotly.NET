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
module ChartDomain_Icicle =

    [<Extension>]
    type Chart =
        /// <summary>
        /// Creates an icicle chart.
        ///
        /// Icicle charts visualize hierarchal data from leaves (and/or outer branches) towards root with rectangles.
        /// The icicle sectors are determined by the entries in "labels" or "ids" and in "parents".
        /// </summary>
        /// <param name="labels">Sets the labels of each of the sectors.</param>
        /// <param name="parents">Sets the parent sectors for each of the sectors. Empty string items '' are understood to reference the root node in the hierarchy. If `ids` is filled, `parents` items are understood to be "ids" themselves. When `ids` is not set, plotly attempts to find matching items in `labels`, but beware they must be unique.</param>
        /// <param name="Values">Sets the values associated with each of the sectors.</param>
        /// <param name="Ids">Assigns id labels to each datum. These ids for object constancy of data points during animation.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
        /// <param name="MultiText">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
        /// <param name="TextPosition">Sets the positions of the `text` elements with respects to the (x,y) coordinates.</param>
        /// <param name="MultiTextPosition">Sets the positions of the `text` elements with respects to the (x,y) coordinates.</param>
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
        /// <param name="BranchValues">Determines how the items in `values` are summed. When set to "total", items in `values` are taken to be value of all its descendants. When set to "remainder", items in `values` corresponding to the root and the branches sectors are taken to be the extra part not part of the sum of the values at their leaves.</param>
        /// <param name="Count">Determines default for `values` when it is not provided, by inferring a 1 for each of the "leaves" and/or "branches", otherwise 0.</param>
        /// <param name="TilingOrientation">Sets the orientation of the tiling.</param>
        /// <param name="TilingFlip">Sets the flip of the tiling: Determines if the positions obtained from solver are flipped on each axis.</param>
        /// <param name="Tiling">Sets the styles for the icicle tiling</param>
        /// <param name="PathBarEdgeShape">Sets the edge shape of the pathbar.</param>
        /// <param name="PathBar">Sets the pathbar</param>
        /// <param name="TextInfo">Determines which trace information appear on the graph.</param>
        /// <param name="Root">Sets the styles for the root of this trace.</param>
        /// <param name="Level">Sets the level from which this trace hierarchy is rendered. Set `level` to `''` to start from the root node in the hierarchy. Must be an "id" if `ids` is filled in, otherwise plotly attempts to find a matching item in `labels`.</param>
        /// <param name="MaxDepth">Sets the number of rendered sectors from any given `level`. Set `maxdepth` to "-1" to render all the levels in the hierarchy.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Icicle
            (
                labels: seq<#IConvertible>,
                parents: seq<#IConvertible>,
                ?Values: seq<#IConvertible>,
                ?Ids: seq<#IConvertible>,
                ?Name: string,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?SectionColors: seq<Color>,
                ?SectionColorScale: StyleParam.Colorscale,
                ?ShowSectionColorScale: bool,
                ?ReverseSectionColorScale: bool,
                ?SectionOutlineColor: Color,
                ?SectionOutlineWidth: float,
                ?SectionOutlineMultiWidth: seq<float>,
                ?SectionOutline: Line,
                ?MarkerPatternShape: StyleParam.PatternShape,
                ?MultiMarkerPatternShape: seq<StyleParam.PatternShape>,
                ?MarkerPattern: Pattern,
                ?Marker: Marker,
                ?BranchValues: StyleParam.BranchValues,
                ?Count: StyleParam.IcicleCount,
                ?TilingOrientation: StyleParam.Orientation,
                ?TilingFlip: StyleParam.TilingFlip,
                ?Tiling: IcicleTiling,
                ?PathBarEdgeShape: StyleParam.PathbarEdgeShape,
                ?PathBar: Pathbar,
                ?TextInfo: StyleParam.TextInfo,
                ?Root: IcicleRoot,
                ?Level: string,
                ?MaxDepth: int,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let outline =
                SectionOutline
                |> Option.defaultValue (Line.init ())
                |> Line.style (
                    ?Color = SectionOutlineColor,
                    ?Width = SectionOutlineWidth,
                    ?MultiWidth = SectionOutlineMultiWidth
                )

            let pattern =
                MarkerPattern
                |> Option.defaultValue (TraceObjects.Pattern.init ())
                |> TraceObjects.Pattern.style (?Shape = MarkerPatternShape, ?MultiShape = MultiMarkerPatternShape)

            let marker =
                Marker
                |> Option.defaultValue (TraceObjects.Marker.init ())
                |> TraceObjects.Marker.style (
                    ?MultiOpacity = MultiOpacity,
                    ?Colors = SectionColors,
                    ?Colorscale = SectionColorScale,
                    ?ShowScale = ShowSectionColorScale,
                    ?ReverseScale = ReverseSectionColorScale,
                    Outline = outline,
                    Pattern = pattern
                )

            let tiling =
                Tiling
                |> Option.defaultValue (IcicleTiling.init ())
                |> IcicleTiling.style (?Orientation = TilingOrientation, ?Flip = TilingFlip)

            let pathbar =
                PathBar |> Option.defaultValue (Pathbar.init ()) |> Pathbar.style (?EdgeShape = PathBarEdgeShape)

            TraceDomain.initIcicle (
                TraceDomainStyle.Icicle(
                    Labels = labels,
                    Parents = parents,
                    Marker = marker,
                    PathBar = pathbar,
                    Tiling = tiling,
                    ?Values = Values,
                    ?Ids = Ids,
                    ?Name = Name,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?TextPosition = TextPosition,
                    ?MultiTextPosition = MultiTextPosition,
                    ?BranchValues = BranchValues,
                    ?Count = Count,
                    ?TextInfo = TextInfo,
                    ?Root = Root,
                    ?Level = Level,
                    ?MaxDepth = MaxDepth
                )
            )
            |> GenericChart.ofTraceObject useDefaults

        /// <summary>
        /// Creates an icicle chart from encoded hierarchy arrays.
        ///
        /// Icicle charts visualize hierarchal data from leaves (and/or outer branches) towards root with rectangles.
        /// The icicle sectors are determined by the entries in "labels" or "ids" and in "parents".
        /// </summary>
        /// <param name="labelsEncoded">Sets the labels of each of the sectors as an encoded typed array.</param>
        /// <param name="parentsEncoded">Sets the parent sectors for each of the sectors as an encoded typed array.</param>
        /// <param name="valuesEncoded">Sets the values associated with each of the sectors as an encoded typed array.</param>
        /// <param name="idsEncoded">Assigns id labels to each datum as an encoded typed array. These ids for object constancy of data points during animation.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
        /// <param name="MultiText">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
        /// <param name="TextPosition">Sets the positions of the `text` elements with respects to the (x,y) coordinates.</param>
        /// <param name="MultiTextPosition">Sets the positions of the `text` elements with respects to the (x,y) coordinates.</param>
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
        /// <param name="BranchValues">Determines how the items in `values` are summed. When set to "total", items in `values` are taken to be value of all its descendants. When set to "remainder", items in `values` corresponding to the root and the branches sectors are taken to be the extra part not part of the sum of the values at their leaves.</param>
        /// <param name="Count">Determines default for `values` when it is not provided, by inferring a 1 for each of the "leaves" and/or "branches", otherwise 0.</param>
        /// <param name="TilingOrientation">Sets the orientation of the tiling.</param>
        /// <param name="TilingFlip">Sets the flip of the tiling: Determines if the positions obtained from solver are flipped on each axis.</param>
        /// <param name="Tiling">Sets the styles for the icicle tiling</param>
        /// <param name="PathBarEdgeShape">Sets the edge shape of the pathbar.</param>
        /// <param name="PathBar">Sets the pathbar</param>
        /// <param name="TextInfo">Determines which trace information appear on the graph.</param>
        /// <param name="Root">Sets the styles for the root of this trace.</param>
        /// <param name="Level">Sets the level from which this trace hierarchy is rendered. Set `level` to `''` to start from the root node in the hierarchy. Must be an "id" if `ids` is filled in, otherwise plotly attempts to find a matching item in `labels`.</param>
        /// <param name="MaxDepth">Sets the number of rendered sectors from any given `level`. Set `maxdepth` to "-1" to render all the levels in the hierarchy.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Icicle
            (
                labelsEncoded: EncodedTypedArray,
                parentsEncoded: EncodedTypedArray,
                ?valuesEncoded: EncodedTypedArray,
                ?idsEncoded: EncodedTypedArray,
                ?Name: string,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?SectionColors: seq<Color>,
                ?SectionColorScale: StyleParam.Colorscale,
                ?ShowSectionColorScale: bool,
                ?ReverseSectionColorScale: bool,
                ?SectionOutlineColor: Color,
                ?SectionOutlineWidth: float,
                ?SectionOutlineMultiWidth: seq<float>,
                ?SectionOutline: Line,
                ?MarkerPatternShape: StyleParam.PatternShape,
                ?MultiMarkerPatternShape: seq<StyleParam.PatternShape>,
                ?MarkerPattern: Pattern,
                ?Marker: Marker,
                ?BranchValues: StyleParam.BranchValues,
                ?Count: StyleParam.IcicleCount,
                ?TilingOrientation: StyleParam.Orientation,
                ?TilingFlip: StyleParam.TilingFlip,
                ?Tiling: IcicleTiling,
                ?PathBarEdgeShape: StyleParam.PathbarEdgeShape,
                ?PathBar: Pathbar,
                ?TextInfo: StyleParam.TextInfo,
                ?Root: IcicleRoot,
                ?Level: string,
                ?MaxDepth: int,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let outline =
                SectionOutline
                |> Option.defaultValue (Line.init ())
                |> Line.style (
                    ?Color = SectionOutlineColor,
                    ?Width = SectionOutlineWidth,
                    ?MultiWidth = SectionOutlineMultiWidth
                )

            let pattern =
                MarkerPattern
                |> Option.defaultValue (TraceObjects.Pattern.init ())
                |> TraceObjects.Pattern.style (?Shape = MarkerPatternShape, ?MultiShape = MultiMarkerPatternShape)

            let marker =
                Marker
                |> Option.defaultValue (TraceObjects.Marker.init ())
                |> TraceObjects.Marker.style (
                    ?MultiOpacity = MultiOpacity,
                    ?Colors = SectionColors,
                    ?Colorscale = SectionColorScale,
                    ?ShowScale = ShowSectionColorScale,
                    ?ReverseScale = ReverseSectionColorScale,
                    Outline = outline,
                    Pattern = pattern
                )

            let tiling =
                Tiling
                |> Option.defaultValue (IcicleTiling.init ())
                |> IcicleTiling.style (?Orientation = TilingOrientation, ?Flip = TilingFlip)

            let pathbar =
                PathBar |> Option.defaultValue (Pathbar.init ()) |> Pathbar.style (?EdgeShape = PathBarEdgeShape)

            TraceDomain.initIcicle (
                TraceDomainStyle.Icicle(
                    LabelsEncoded = labelsEncoded,
                    ParentsEncoded = parentsEncoded,
                    Marker = marker,
                    PathBar = pathbar,
                    Tiling = tiling,
                    ?ValuesEncoded = valuesEncoded,
                    ?IdsEncoded = idsEncoded,
                    ?Name = Name,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?TextPosition = TextPosition,
                    ?MultiTextPosition = MultiTextPosition,
                    ?BranchValues = BranchValues,
                    ?Count = Count,
                    ?TextInfo = TextInfo,
                    ?Root = Root,
                    ?Level = Level,
                    ?MaxDepth = MaxDepth
                )
            )
            |> GenericChart.ofTraceObject useDefaults


        /// <summary>
        /// Creates an icicle chart.
        ///
        /// Icicle charts visualize hierarchal data from leaves (and/or outer branches) towards root with rectangles.
        /// The icicle sectors are determined by the entries in "labels" or "ids" and in "parents".
        /// </summary>
        /// <param name="labelsparents">Sets the labels of each of the sectors and their respective parent sector.</param>
        /// <param name="Values">Sets the values associated with each of the sectors.</param>
        /// <param name="Ids">Assigns id labels to each datum. These ids for object constancy of data points during animation.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
        /// <param name="MultiText">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
        /// <param name="TextPosition">Sets the positions of the `text` elements with respects to the (x,y) coordinates.</param>
        /// <param name="MultiTextPosition">Sets the positions of the `text` elements with respects to the (x,y) coordinates.</param>
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
        /// <param name="BranchValues">Determines how the items in `values` are summed. When set to "total", items in `values` are taken to be value of all its descendants. When set to "remainder", items in `values` corresponding to the root and the branches sectors are taken to be the extra part not part of the sum of the values at their leaves.</param>
        /// <param name="Count">Determines default for `values` when it is not provided, by inferring a 1 for each of the "leaves" and/or "branches", otherwise 0.</param>
        /// <param name="TilingOrientation">Sets the orientation of the tiling.</param>
        /// <param name="TilingFlip">Sets the flip of the tiling: Determines if the positions obtained from solver are flipped on each axis.</param>
        /// <param name="Tiling">Sets the styles for the icicle tiling</param>
        /// <param name="PathBarEdgeShape">Sets the edge shape of the pathbar.</param>
        /// <param name="PathBar">Sets the pathbar</param>
        /// <param name="TextInfo">Determines which trace information appear on the graph.</param>
        /// <param name="Root">Sets the styles for the root of this trace.</param>
        /// <param name="Level">Sets the level from which this trace hierarchy is rendered. Set `level` to `''` to start from the root node in the hierarchy. Must be an "id" if `ids` is filled in, otherwise plotly attempts to find a matching item in `labels`.</param>
        /// <param name="MaxDepth">Sets the number of rendered sectors from any given `level`. Set `maxdepth` to "-1" to render all the levels in the hierarchy.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Icicle
            (
                labelsparents: seq<#IConvertible * #IConvertible>,
                ?Values: seq<#IConvertible>,
                ?Ids: seq<#IConvertible>,
                ?Name: string,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?SectionColors: seq<Color>,
                ?SectionColorScale: StyleParam.Colorscale,
                ?ShowSectionColorScale: bool,
                ?ReverseSectionColorScale: bool,
                ?SectionOutlineColor: Color,
                ?SectionOutlineWidth: float,
                ?SectionOutlineMultiWidth: seq<float>,
                ?SectionOutline: Line,
                ?MarkerPatternShape: StyleParam.PatternShape,
                ?MultiMarkerPatternShape: seq<StyleParam.PatternShape>,
                ?MarkerPattern: Pattern,
                ?Marker: Marker,
                ?BranchValues: StyleParam.BranchValues,
                ?Count: StyleParam.IcicleCount,
                ?TilingOrientation: StyleParam.Orientation,
                ?TilingFlip: StyleParam.TilingFlip,
                ?Tiling: IcicleTiling,
                ?PathBarEdgeShape: StyleParam.PathbarEdgeShape,
                ?PathBar: Pathbar,
                ?TextInfo: StyleParam.TextInfo,
                ?Root: IcicleRoot,
                ?Level: string,
                ?MaxDepth: int,
                ?UseDefaults: bool
            ) =

            let labels, parents =
                Seq.unzip labelsparents

            Chart.Icicle(
                labels,
                parents,
                ?Values = Values,
                ?Ids = Ids,
                ?Name = Name,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?SectionColors = SectionColors,
                ?SectionColorScale = SectionColorScale,
                ?ShowSectionColorScale = ShowSectionColorScale,
                ?ReverseSectionColorScale = ReverseSectionColorScale,
                ?SectionOutlineColor = SectionOutlineColor,
                ?SectionOutlineWidth = SectionOutlineWidth,
                ?SectionOutlineMultiWidth = SectionOutlineMultiWidth,
                ?SectionOutline = SectionOutline,
                ?MarkerPatternShape = MarkerPatternShape, 
                ?MultiMarkerPatternShape = MultiMarkerPatternShape,
                ?MarkerPattern = MarkerPattern,
                ?Marker = Marker,
                ?BranchValues = BranchValues,
                ?Count = Count,
                ?TilingOrientation = TilingOrientation,
                ?TilingFlip = TilingFlip,
                ?Tiling = Tiling,
                ?PathBarEdgeShape = PathBarEdgeShape,
                ?PathBar = PathBar,
                ?TextInfo = TextInfo,
                ?Root = Root,
                ?Level = Level,
                ?MaxDepth = MaxDepth,
                ?UseDefaults = UseDefaults

            )
