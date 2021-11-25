namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects

open DynamicObj
open System
open System.IO

open GenericChart
open StyleParam
open System.Runtime.InteropServices
open System.Runtime.CompilerServices

[<AutoOpen>]
module ChartDomain =

    [<Extension>]
    type Chart =

        /// Shows how proportions of data, shown as pie-shaped pieces, contribute to the data.
        [<Extension>]
        static member Pie
            (
                values: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?Labels: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Pull: float,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?TextPosition: StyleParam.TextPosition,
                [<Optional; DefaultParameterValue(null)>] ?MultiTextPosition: seq<StyleParam.TextPosition>,
                [<Optional; DefaultParameterValue(null)>] ?SectionColors: seq<Color>,
                [<Optional; DefaultParameterValue(null)>] ?SectionOutlineColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?SectionOutlineWidth: float,
                [<Optional; DefaultParameterValue(null)>] ?SectionOutlineMultiWidth: seq<float>,
                [<Optional; DefaultParameterValue(null)>] ?SectionOutline: Line,
                [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
                [<Optional; DefaultParameterValue(null)>] ?TextInfo: StyleParam.TextInfo,
                [<Optional; DefaultParameterValue(null)>] ?Direction: StyleParam.Direction,
                [<Optional; DefaultParameterValue(null)>] ?Hole: float,
                [<Optional; DefaultParameterValue(null)>] ?Rotation: float,
                [<Optional; DefaultParameterValue(null)>] ?Sort: bool,
                [<Optional; DefaultParameterValue(null)>] ?UseDefaults: bool
            ) =

            let useDefaults = defaultArg UseDefaults true

            let outline = 
                SectionOutline
                |> Option.defaultValue (Line.init ())
                |> Line.style (
                    ?Color = SectionOutlineColor,
                    ?Width = SectionOutlineWidth,
                    ?MultiWidth = SectionOutlineMultiWidth
                )
            let marker =
                Marker
                |> Option.defaultValue (TraceObjects.Marker.init ())
                |> TraceObjects.Marker.style (
                    ?Colors = SectionColors,
                    Outline = outline
                )


            TraceDomain.initPie (
                TraceDomainStyle.Pie(
                    Values = values,
                    ?Name               = Name,
                    ?ShowLegend         = ShowLegend,
                    ?Opacity            = Opacity,
                    ?Labels             = Labels,
                    ?Pull               = Pull,
                    ?Text               = Text,
                    ?MultiText          = MultiText,
                    ?TextPosition       = TextPosition,
                    ?MultiTextPosition  = MultiTextPosition,
                    Marker              = marker,
                    ?TextInfo           = TextInfo,
                    ?Direction          = Direction,
                    ?Hole               = Hole,
                    ?Rotation           = Rotation,
                    ?Sort               = Sort
                    
                )
            )
            |> GenericChart.ofTraceObject useDefaults

        /// Shows how proportions of data, shown as pie-shaped pieces, contribute to the data.
        [<Extension>]
        static member Pie
            (
                valuesLabels: seq<#IConvertible * #IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?Pull: float,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?TextPosition: StyleParam.TextPosition,
                [<Optional; DefaultParameterValue(null)>] ?MultiTextPosition: seq<StyleParam.TextPosition>,
                [<Optional; DefaultParameterValue(null)>] ?SectionColors: seq<Color>,
                [<Optional; DefaultParameterValue(null)>] ?SectionOutlineColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?SectionOutlineWidth: float,
                [<Optional; DefaultParameterValue(null)>] ?SectionOutlineMultiWidth: seq<float>,
                [<Optional; DefaultParameterValue(null)>] ?SectionOutline: Line,
                [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
                [<Optional; DefaultParameterValue(null)>] ?TextInfo: StyleParam.TextInfo,
                [<Optional; DefaultParameterValue(null)>] ?Direction: StyleParam.Direction,
                [<Optional; DefaultParameterValue(null)>] ?Hole: float,
                [<Optional; DefaultParameterValue(null)>] ?Rotation: float,
                [<Optional; DefaultParameterValue(null)>] ?Sort: bool,
                [<Optional; DefaultParameterValue(null)>] ?UseDefaults: bool
            ) =

            let values, labels = Seq.unzip valuesLabels

            Chart.Pie(
                values,
                Labels = labels,
                ?Name                       = Name,
                ?ShowLegend                 = ShowLegend,
                ?Opacity                    = Opacity,
                ?Pull                       = Pull,
                ?Text                       = Text,
                ?MultiText                  = MultiText,
                ?TextPosition               = TextPosition,
                ?MultiTextPosition          = MultiTextPosition,
                ?SectionColors              = SectionColors,
                ?SectionOutlineColor        = SectionOutlineColor,
                ?SectionOutlineWidth        = SectionOutlineWidth,
                ?SectionOutlineMultiWidth   = SectionOutlineMultiWidth,
                ?SectionOutline             = SectionOutline,
                ?Marker                     = Marker,
                ?TextInfo                   = TextInfo,
                ?Direction                  = Direction,
                ?Hole                       = Hole,
                ?Rotation                   = Rotation,
                ?Sort                       = Sort,
                ?UseDefaults                = UseDefaults
            )


        /// Shows how proportions of data, shown as pie-shaped pieces, contribute to the data as a whole.
        [<Extension>]
        static member Doughnut
            (
                values: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?Hole: float,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?Labels: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Pull: float,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?TextPosition: StyleParam.TextPosition,
                [<Optional; DefaultParameterValue(null)>] ?MultiTextPosition: seq<StyleParam.TextPosition>,
                [<Optional; DefaultParameterValue(null)>] ?SectionColors: seq<Color>,
                [<Optional; DefaultParameterValue(null)>] ?SectionOutlineColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?SectionOutlineWidth: float,
                [<Optional; DefaultParameterValue(null)>] ?SectionOutlineMultiWidth: seq<float>,
                [<Optional; DefaultParameterValue(null)>] ?SectionOutline: Line,
                [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
                [<Optional; DefaultParameterValue(null)>] ?TextInfo: StyleParam.TextInfo,
                [<Optional; DefaultParameterValue(null)>] ?Direction: StyleParam.Direction,
                [<Optional; DefaultParameterValue(null)>] ?Rotation: float,
                [<Optional; DefaultParameterValue(null)>] ?Sort: bool,
                [<Optional; DefaultParameterValue(null)>] ?UseDefaults: bool
            ) =

            let useDefaults = defaultArg UseDefaults true
            let hole = Option.defaultValue 0.4 Hole

            Chart.Pie(
                values,
                Hole                        = hole,
                ?Labels                     = Labels,
                ?Name                       = Name,
                ?ShowLegend                 = ShowLegend,
                ?Opacity                    = Opacity,
                ?Pull                       = Pull,
                ?Text                       = Text,
                ?MultiText                  = MultiText,
                ?TextPosition               = TextPosition,
                ?MultiTextPosition          = MultiTextPosition,
                ?SectionColors              = SectionColors,
                ?SectionOutlineColor        = SectionOutlineColor,
                ?SectionOutlineWidth        = SectionOutlineWidth,
                ?SectionOutlineMultiWidth   = SectionOutlineMultiWidth,
                ?SectionOutline             = SectionOutline,
                ?Marker                     = Marker,
                ?TextInfo                   = TextInfo,
                ?Direction                  = Direction,
                ?Rotation                   = Rotation,
                ?Sort                       = Sort,
                ?UseDefaults                = UseDefaults
            )


        /// Shows how proportions of data, shown as pie-shaped pieces, contribute to the data as a whole.
        [<Extension>]
        static member Doughnut
            (
                valuesLabels: seq<#IConvertible * #IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Hole: float,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?Pull: float,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?TextPosition: StyleParam.TextPosition,
                [<Optional; DefaultParameterValue(null)>] ?MultiTextPosition: seq<StyleParam.TextPosition>,
                [<Optional; DefaultParameterValue(null)>] ?SectionColors: seq<Color>,
                [<Optional; DefaultParameterValue(null)>] ?SectionOutlineColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?SectionOutlineWidth: float,
                [<Optional; DefaultParameterValue(null)>] ?SectionOutlineMultiWidth: seq<float>,
                [<Optional; DefaultParameterValue(null)>] ?SectionOutline: Line,
                [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
                [<Optional; DefaultParameterValue(null)>] ?TextInfo: StyleParam.TextInfo,
                [<Optional; DefaultParameterValue(null)>] ?Direction: StyleParam.Direction,
                [<Optional; DefaultParameterValue(null)>] ?Rotation: float,
                [<Optional; DefaultParameterValue(null)>] ?Sort: bool,
                [<Optional; DefaultParameterValue(null)>] ?UseDefaults: bool
            ) =
            let values, labels = Seq.unzip valuesLabels

            Chart.Doughnut(
                values,
                Labels = labels,
                ?Hole                       = Hole,
                ?Name                       = Name,
                ?ShowLegend                 = ShowLegend,
                ?Opacity                    = Opacity,
                ?Pull                       = Pull,
                ?Text                       = Text,
                ?MultiText                  = MultiText,
                ?TextPosition               = TextPosition,
                ?MultiTextPosition          = MultiTextPosition,
                ?SectionColors              = SectionColors,
                ?SectionOutlineColor        = SectionOutlineColor,
                ?SectionOutlineWidth        = SectionOutlineWidth,
                ?SectionOutlineMultiWidth   = SectionOutlineMultiWidth,
                ?SectionOutline             = SectionOutline,
                ?Marker                     = Marker,
                ?TextInfo                   = TextInfo,
                ?Direction                  = Direction,
                ?Rotation                   = Rotation,
                ?Sort                       = Sort,
                ?UseDefaults                = UseDefaults
            )



        /// Creates a FunnelArea chart.
        [<Extension>]
        static member FunnelArea
            (
                values: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?Labels: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?TextPosition: StyleParam.TextPosition,
                [<Optional; DefaultParameterValue(null)>] ?MultiTextPosition: seq<StyleParam.TextPosition>,
                [<Optional; DefaultParameterValue(null)>] ?SectionColors: seq<Color>,
                [<Optional; DefaultParameterValue(null)>] ?SectionOutlineColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?SectionOutlineWidth: float,
                [<Optional; DefaultParameterValue(null)>] ?SectionOutlineMultiWidth: seq<float>,
                [<Optional; DefaultParameterValue(null)>] ?SectionOutline: Line,
                [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
                [<Optional; DefaultParameterValue(null)>] ?TextInfo: StyleParam.TextInfo,
                [<Optional; DefaultParameterValue(null)>] ?AspectRatio: float,
                [<Optional; DefaultParameterValue(null)>] ?BaseRatio: float,
                [<Optional; DefaultParameterValue(null)>] ?UseDefaults: bool
            ) =

            
            let useDefaults = defaultArg UseDefaults true

            let outline = 
                SectionOutline
                |> Option.defaultValue (Line.init ())
                |> Line.style (
                    ?Color = SectionOutlineColor,
                    ?Width = SectionOutlineWidth,
                    ?MultiWidth = SectionOutlineMultiWidth
                )
            let marker =
                Marker
                |> Option.defaultValue (TraceObjects.Marker.init ())
                |> TraceObjects.Marker.style (
                    ?Colors = SectionColors,
                    Outline = outline
                )


            TraceDomain.initFunnelArea (
                TraceDomainStyle.FunnelArea(
                    Values              = values,
                    ?Name               = Name,
                    ?ShowLegend         = ShowLegend,
                    ?Opacity            = Opacity,
                    ?Labels             = Labels,
                    ?Text               = Text,
                    ?MultiText          = MultiText,
                    ?TextPosition       = TextPosition,
                    ?MultiTextPosition  = MultiTextPosition,
                    Marker              = marker,
                    ?TextInfo           = TextInfo,
                    ?AspectRatio        = AspectRatio,
                    ?BaseRatio          = BaseRatio
                )
            )
            |> GenericChart.ofTraceObject useDefaults

        /// Creates a FunnelArea chart.
        [<Extension>]
        static member FunnelArea
            (   
                valuesLabels: seq<#IConvertible * #IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Name                     : string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend               : bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity                  : float,
                [<Optional; DefaultParameterValue(null)>] ?Text                     : #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText                : seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?TextPosition             : StyleParam.TextPosition,
                [<Optional; DefaultParameterValue(null)>] ?MultiTextPosition        : seq<StyleParam.TextPosition>,
                [<Optional; DefaultParameterValue(null)>] ?SectionColors            : seq<Color>,
                [<Optional; DefaultParameterValue(null)>] ?SectionOutlineColor      : Color,
                [<Optional; DefaultParameterValue(null)>] ?SectionOutlineWidth      : float,
                [<Optional; DefaultParameterValue(null)>] ?SectionOutlineMultiWidth : seq<float>,
                [<Optional; DefaultParameterValue(null)>] ?SectionOutline           : Line,
                [<Optional; DefaultParameterValue(null)>] ?Marker                   : Marker,
                [<Optional; DefaultParameterValue(null)>] ?TextInfo                 : StyleParam.TextInfo,
                [<Optional; DefaultParameterValue(null)>] ?AspectRatio              : float,
                [<Optional; DefaultParameterValue(null)>] ?BaseRatio                : float,
                [<Optional; DefaultParameterValue(null)>] ?UseDefaults              : bool
            ) =
                let values, labels = Seq.unzip valuesLabels

                Chart.FunnelArea(
                    values,
                    Labels = labels,
                    ?Name                    = Name                    ,
                    ?ShowLegend              = ShowLegend              ,
                    ?Opacity                 = Opacity                 ,
                    ?Text                    = Text                    ,
                    ?MultiText               = MultiText               ,
                    ?TextPosition            = TextPosition            ,
                    ?MultiTextPosition       = MultiTextPosition       ,
                    ?SectionColors           = SectionColors           ,
                    ?SectionOutlineColor     = SectionOutlineColor     ,
                    ?SectionOutlineWidth     = SectionOutlineWidth     ,
                    ?SectionOutlineMultiWidth= SectionOutlineMultiWidth,
                    ?SectionOutline          = SectionOutline          ,
                    ?Marker                  = Marker                  ,
                    ?TextInfo                = TextInfo                ,
                    ?AspectRatio             = AspectRatio             ,
                    ?BaseRatio               = BaseRatio               ,
                    ?UseDefaults             = UseDefaults             
                )



        /// Creates a sunburst chart. Visualize hierarchical data spanning outward radially from root to leaves.
        /// Applies the styles of sundburst plot to TraceObjects
        ///
        /// Parameters:
        ///
        /// labels: Sets the labels of each of the sectors.
        ///
        /// parents: Sets the parent sectors for each of the sectors. Empty string items '' are understood to reference the root node in the hierarchy. If `ids` is filled, `parents` items are understood to be "ids" themselves. When `ids` is not set, plotly attempts to find matching items in `labels`, but beware they must be unique.
        ///
        /// Ids: Assigns id labels to each datum. These ids for object constancy of data points during animation.
        ///
        /// Values: Sets the values associated with each of the sectors. Use with `branchvalues` to determine how the values are summed.
        ///
        /// Text: Sets text elements associated with each sector. If trace `textinfo` contains a "text" flag, these elements will be seen on the chart. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.
        ///
        /// Branchvalues: Determines how the items in `values` are summed. When set to "total", items in `values` are taken to be value of all its descendants. When set to "remainder", items in `values` corresponding to the root and the branches sectors are taken to be the extra part not part of the sum of the values at their leaves.
        ///
        /// Level: Sets the level from which this trace hierarchy is rendered. Set `level` to `''` to start from the root node in the hierarchy. Must be an "id" if `ids` is filled in, otherwise plotly attempts to find a matching item in `labels`.
        ///
        /// Maxdepth: Sets the number of rendered sectors from any given `level`. Set `maxdepth` to "-1" to render all the levels in the hierarchy.
        ///
        /// ColorBar: Sets the ColorBar for the chart
        ///
        ///Colors: Sets the color of each sector of this trace. If not specified, the default trace color set is used to pick the sector colors.
        [<Extension>]
        static member Sunburst
            (
                labels,
                parents,
                [<Optional; DefaultParameterValue(null)>] ?Ids,
                [<Optional; DefaultParameterValue(null)>] ?Values,
                [<Optional; DefaultParameterValue(null)>] ?Text,
                [<Optional; DefaultParameterValue(null)>] ?Branchvalues,
                [<Optional; DefaultParameterValue(null)>] ?Level,
                [<Optional; DefaultParameterValue(null)>] ?Maxdepth,
                [<Optional; DefaultParameterValue(null)>] ?Color,
                [<Optional; DefaultParameterValue(null)>] ?ColorBar: ColorBar,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            let useDefaults = defaultArg UseDefaults true

            TraceDomain.initSunburst (
                TraceDomainStyle.Sunburst(
                    labels = labels,
                    parents = parents,
                    ?Ids = Ids,
                    ?Values = Values,
                    ?Text = Text,
                    ?Branchvalues = Branchvalues,
                    ?Level = Level,
                    ?Maxdepth = Maxdepth
                )
            )
            |> TraceStyle.Marker(?Color = Color, ?ColorBar = ColorBar)
            |> GenericChart.ofTraceObject useDefaults



        /// Creates a treemap chart. Treemap charts visualize hierarchical data using nested rectangles. Same as Sunburst the hierarchy is defined by labels and parents attributes. Click on one sector to zoom in/out, which also displays a pathbar in the upper-left corner of your treemap. To zoom out you can use the path bar as well.
        ///
        /// Parameters:
        ///
        /// labels: Sets the labels of each of the sectors.
        ///
        /// parents: Sets the parent sectors for each of the sectors. Empty string items '' are understood to reference the root node in the hierarchy. If `ids` is filled, `parents` items are understood to be "ids" themselves. When `ids` is not set, plotly attempts to find matching items in `labels`, but beware they must be unique.
        ///
        /// Ids: Assigns id labels to each datum. These ids for object constancy of data points during animation.
        ///
        /// Values: Sets the values associated with each of the sectors. Use with `branchvalues` to determine how the values are summed.
        ///
        /// Text: Sets text elements associated with each sector. If trace `textinfo` contains a "text" flag, these elements will be seen on the chart. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.
        ///
        /// Branchvalues: Determines how the items in `values` are summed. When set to "total", items in `values` are taken to be value of all its descendants. When set to "remainder", items in `values` corresponding to the root and the branches sectors are taken to be the extra part not part of the sum of the values at their leaves.
        ///
        /// Level: Sets the level from which this trace hierarchy is rendered. Set `level` to `''` to start from the root node in the hierarchy. Must be an "id" if `ids` is filled in, otherwise plotly attempts to find a matching item in `labels`.
        ///
        /// Maxdepth: Sets the number of rendered sectors from any given `level`. Set `maxdepth` to "-1" to render all the levels in the hierarchy.
        ///
        /// ColorBar: Sets the ColorBar for the chart
        ///
        ///Colors: Sets the color of each sector of this trace. If not specified, the default trace color set is used to pick the sector colors.
        [<Extension>]
        static member Treemap
            (
                labels,
                parents,
                [<Optional; DefaultParameterValue(null)>] ?Ids,
                [<Optional; DefaultParameterValue(null)>] ?Values,
                [<Optional; DefaultParameterValue(null)>] ?Text,
                [<Optional; DefaultParameterValue(null)>] ?Branchvalues,
                [<Optional; DefaultParameterValue(null)>] ?Tiling,
                [<Optional; DefaultParameterValue(null)>] ?PathBar,
                [<Optional; DefaultParameterValue(null)>] ?Level,
                [<Optional; DefaultParameterValue(null)>] ?Maxdepth,
                [<Optional; DefaultParameterValue(null)>] ?Color,
                [<Optional; DefaultParameterValue(null)>] ?ColorBar: ColorBar,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            let useDefaults = defaultArg UseDefaults true

            TraceDomain.initTreemap (
                TraceDomainStyle.Treemap(
                    labels = labels,
                    parents = parents,
                    ?Ids = Ids,
                    ?Values = Values,
                    ?Text = Text,
                    ?Branchvalues = Branchvalues,
                    ?Tiling = Tiling,
                    ?PathBar = PathBar,
                    ?Level = Level,
                    ?Maxdepth = Maxdepth
                )
            )
            |> TraceStyle.Marker(?Color = Color, ?ColorBar = ColorBar)
            |> GenericChart.ofTraceObject useDefaults


        /// Computes the parallel coordinates plot
        [<Extension>]
        static member ParallelCoord
            (
                dims: seq<'key * #seq<'values>>,
                [<Optional; DefaultParameterValue(null)>] ?Range,
                [<Optional; DefaultParameterValue(null)>] ?Constraintrange,
                [<Optional; DefaultParameterValue(null)>] ?Color,
                [<Optional; DefaultParameterValue(null)>] ?Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?Width,
                [<Optional; DefaultParameterValue(null)>] ?Dash,
                [<Optional; DefaultParameterValue(null)>] ?Domain,
                [<Optional; DefaultParameterValue(null)>] ?Labelfont,
                [<Optional; DefaultParameterValue(null)>] ?Tickfont,
                [<Optional; DefaultParameterValue(null)>] ?Rangefont,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            let useDefaults = defaultArg UseDefaults true

            let dims' =
                dims
                |> Seq.map
                    (fun (k, vals) ->
                        Dimension.initParallel (
                            Values = vals,
                            ?Range = Range,
                            ?ConstraintRange = Constraintrange,
                            Label = k
                        ))

            TraceDomain.initParallelCoord (
                TraceDomainStyle.ParallelCoord(
                    Dimensions = dims',
                    ?Domain = Domain,
                    ?Labelfont = Labelfont,
                    ?Tickfont = Tickfont,
                    ?Rangefont = Rangefont
                )
            )
            |> TraceStyle.Line(?Width = Width, ?Color = Color, ?Dash = Dash, ?Colorscale = Colorscale)
            |> GenericChart.ofTraceObject useDefaults


        /// Computes the parallel coordinates plot
        [<Extension>]
        static member ParallelCoord
            (
                dims: seq<Dimension>,
                [<Optional; DefaultParameterValue(null)>] ?Color,
                [<Optional; DefaultParameterValue(null)>] ?Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?Width,
                [<Optional; DefaultParameterValue(null)>] ?Dash,
                [<Optional; DefaultParameterValue(null)>] ?Domain,
                [<Optional; DefaultParameterValue(null)>] ?Labelfont,
                [<Optional; DefaultParameterValue(null)>] ?Tickfont,
                [<Optional; DefaultParameterValue(null)>] ?Rangefont,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            let useDefaults = defaultArg UseDefaults true

            TraceDomain.initParallelCoord (
                TraceDomainStyle.ParallelCoord(
                    Dimensions = dims,
                    ?Domain = Domain,
                    ?Labelfont = Labelfont,
                    ?Tickfont = Tickfont,
                    ?Rangefont = Rangefont
                )
            )
            |> TraceStyle.Line(?Width = Width, ?Color = Color, ?Dash = Dash, ?Colorscale = Colorscale)
            |> GenericChart.ofTraceObject useDefaults

        ///Parallel categories diagram for multidimensional categorical data.
        [<Extension>]
        static member ParallelCategories
            (
                dims: seq<'key * #seq<'values>>,
                [<Optional; DefaultParameterValue(null)>] ?Range,
                [<Optional; DefaultParameterValue(null)>] ?Constraintrange,
                [<Optional; DefaultParameterValue(null)>] ?Color,
                [<Optional; DefaultParameterValue(null)>] ?Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?Width,
                [<Optional; DefaultParameterValue(null)>] ?Dash,
                [<Optional; DefaultParameterValue(null)>] ?Domain,
                [<Optional; DefaultParameterValue(null)>] ?Labelfont,
                [<Optional; DefaultParameterValue(null)>] ?Tickfont,
                [<Optional; DefaultParameterValue(null)>] ?Rangefont,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            let useDefaults = defaultArg UseDefaults true

            let dims' =
                dims
                |> Seq.map
                    (fun (k, vals) ->
                        Dimension.initParallel (
                            Values = vals,
                            ?Range = Range,
                            ?ConstraintRange = Constraintrange,
                            Label = k
                        ))

            TraceDomain.initParallelCategories (
                TraceDomainStyle.ParallelCategories(
                    Dimensions = dims',
                    ?Domain = Domain,
                    ?Labelfont = Labelfont,
                    ?Tickfont = Tickfont,
                    ?Rangefont = Rangefont
                )
            )
            |> TraceStyle.Line(?Width = Width, ?Color = Color, ?Dash = Dash, ?Colorscale = Colorscale)
            |> GenericChart.ofTraceObject useDefaults

        ///
        [<Extension>]
        static member ParallelCategories
            (
                dims: seq<Dimension>,
                [<Optional; DefaultParameterValue(null)>] ?Color,
                [<Optional; DefaultParameterValue(null)>] ?Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?Width,
                [<Optional; DefaultParameterValue(null)>] ?Dash,
                [<Optional; DefaultParameterValue(null)>] ?Domain,
                [<Optional; DefaultParameterValue(null)>] ?Labelfont,
                [<Optional; DefaultParameterValue(null)>] ?Tickfont,
                [<Optional; DefaultParameterValue(null)>] ?Rangefont,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            let useDefaults = defaultArg UseDefaults true

            TraceDomain.initParallelCategories (
                TraceDomainStyle.ParallelCategories(
                    Dimensions = dims,
                    ?Domain = Domain,
                    ?Color = Color,
                    ?Labelfont = Labelfont,
                    ?Tickfont = Tickfont,
                    ?Rangefont = Rangefont
                )
            )
            |> TraceStyle.Line(?Width = Width, ?Dash = Dash, ?Colorscale = Colorscale)
            |> GenericChart.ofTraceObject useDefaults


        /// creates table out of header sequence and row sequences
        [<Extension>]
        static member Table
            (
                headerValues,
                cellValues,
                [<Optional; DefaultParameterValue(null)>] ?AlignHeader,
                [<Optional; DefaultParameterValue(null)>] ?AlignCells,
                [<Optional; DefaultParameterValue(null)>] ?ColumnWidth,
                [<Optional; DefaultParameterValue(null)>] ?ColumnOrder,
                [<Optional; DefaultParameterValue(null)>] ?ColorHeader,
                [<Optional; DefaultParameterValue(null)>] ?ColorCells,
                [<Optional; DefaultParameterValue(null)>] ?FontHeader,
                [<Optional; DefaultParameterValue(null)>] ?FontCells,
                [<Optional; DefaultParameterValue(null)>] ?HeightHeader,
                [<Optional; DefaultParameterValue(null)>] ?HeightCells,
                [<Optional; DefaultParameterValue(null)>] ?LineHeader,
                [<Optional; DefaultParameterValue(null)>] ?LineCells,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            let useDefaults = defaultArg UseDefaults true

            TraceDomain.initTable (

                let CellFilling =
                    match ColorCells with
                    | Some color -> Some(CellColor.init (?Color = ColorCells))
                    | Option.None -> Option.None

                let HeaderFilling =
                    match ColorHeader with
                    | Some color -> Some(CellColor.init (?Color = ColorHeader))
                    | Option.None -> Option.None

                TraceDomainStyle.Table(
                    header =
                        TableHeader.init (
                            headerValues |> Seq.map seq,
                            ?Align = AlignHeader,
                            ?Fill = HeaderFilling,
                            ?Font = FontHeader,
                            ?Height = HeightHeader,
                            ?Line = LineHeader
                        ),
                    cells =
                        TableCells.init (
                            cellValues |> Seq.transpose,
                            ?Align = AlignCells,
                            ?Fill = CellFilling,
                            ?Font = FontCells,
                            ?Height = HeightCells,
                            ?Line = LineCells
                        ),
                    ?ColumnWidth = ColumnWidth,
                    ?ColumnOrder = ColumnOrder
                )
            )
            |> GenericChart.ofTraceObject useDefaults

        /// creates table out of header sequence and row sequences
        [<Extension>]
        static member Indicator
            (
                value: IConvertible,
                mode: StyleParam.IndicatorMode,
                [<Optional; DefaultParameterValue(null)>] ?Range: StyleParam.Range,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?Title: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Domain: Domain,
                [<Optional; DefaultParameterValue(null)>] ?Align: StyleParam.IndicatorAlignment,
                [<Optional; DefaultParameterValue(null)>] ?DeltaReference: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?Delta: IndicatorDelta,
                [<Optional; DefaultParameterValue(null)>] ?Number: IndicatorNumber,
                [<Optional; DefaultParameterValue(null)>] ?GaugeShape: StyleParam.IndicatorGaugeShape,
                [<Optional; DefaultParameterValue(null)>] ?Gauge: IndicatorGauge,
                [<Optional; DefaultParameterValue(null)>] ?ShowGaugeAxis: bool,
                [<Optional; DefaultParameterValue(null)>] ?GaugeAxis: LinearAxis,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            let useDefaults = defaultArg UseDefaults true

            let axis =
                GaugeAxis
                |> Option.defaultValue (LinearAxis.init ())
                |> LinearAxis.style (?Range = Range, ?Visible = ShowGaugeAxis)

            let gauge =
                Gauge
                |> Option.defaultValue (IndicatorGauge.init ())
                |> IndicatorGauge.style (Axis = axis, ?Shape = GaugeShape)

            let delta =
                Delta
                |> Option.defaultValue (IndicatorDelta.init ())
                |> IndicatorDelta.style (?Reference = DeltaReference)

            TraceDomain.initIndicator (
                TraceDomainStyle.Indicator(
                    ?Name = Name,
                    ?Title = Title,
                    ?ShowLegend = ShowLegend,
                    Mode = mode,
                    Value = value,
                    ?Domain = Domain,
                    ?Align = Align,
                    Delta = delta,
                    ?Number = Number,
                    Gauge = gauge
                )
            )
            |> GenericChart.ofTraceObject useDefaults

        /// creates table out of header sequence and row sequences
        [<Extension>]
        static member Icicle
            (
                labels: seq<#IConvertible>,
                parents: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Values: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?MultiOpacity: seq<float>,
                [<Optional; DefaultParameterValue(null)>] ?Color: Color,
                [<Optional; DefaultParameterValue(null)>] ?ColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?ShowScale: bool,
                [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?TextPosition: StyleParam.TextPosition,
                [<Optional; DefaultParameterValue(null)>] ?MultiTextPosition: seq<StyleParam.TextPosition>,
                [<Optional; DefaultParameterValue(null)>] ?Domain: Domain,
                [<Optional; DefaultParameterValue(null)>] ?BranchValues: StyleParam.BranchValues,
                [<Optional; DefaultParameterValue(null)>] ?Count: StyleParam.IcicleCount,
                [<Optional; DefaultParameterValue(null)>] ?TilingOrientation: StyleParam.Orientation,
                [<Optional; DefaultParameterValue(null)>] ?TilingFlip: StyleParam.TilingFlip,
                [<Optional; DefaultParameterValue(null)>] ?Tiling: IcicleTiling,
                [<Optional; DefaultParameterValue(null)>] ?PathBarEdgeShape: StyleParam.PathbarEdgeShape,
                [<Optional; DefaultParameterValue(null)>] ?PathBar: Pathbar,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            let useDefaults = defaultArg UseDefaults true

            let tiling =
                Tiling
                |> Option.defaultValue (IcicleTiling.init ())
                |> IcicleTiling.style (?Orientation = TilingOrientation, ?Flip = TilingFlip)

            let pathbar =
                PathBar |> Option.defaultValue (Pathbar.init ()) |> Pathbar.style (?EdgeShape = PathBarEdgeShape)

            TraceDomain.initIcicle (
                TraceDomainStyle.Icicle(
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    Parents = parents,
                    ?Values = Values,
                    Labels = labels,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?TextPosition = TextPosition,
                    ?MultiTextPosition = MultiTextPosition,
                    ?Domain = Domain,
                    ?Marker = Marker,
                    ?BranchValues = BranchValues,
                    ?Count = Count,
                    Tiling = tiling,
                    PathBar = pathbar
                )
                >> TraceStyle.Marker(
                    ?Color = Color,
                    ?MultiOpacity = MultiOpacity,
                    ?Colorscale = ColorScale,
                    ?ShowScale = ShowScale
                )
            )
            |> GenericChart.ofTraceObject useDefaults

        /// creates table out of header sequence and row sequences
        [<Extension>]
        static member Icicle
            (
                labelsParents: seq<#IConvertible * #IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Values: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?MultiOpacity: seq<float>,
                [<Optional; DefaultParameterValue(null)>] ?Color: Color,
                [<Optional; DefaultParameterValue(null)>] ?ColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?ShowScale: bool,
                [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?TextPosition: StyleParam.TextPosition,
                [<Optional; DefaultParameterValue(null)>] ?MultiTextPosition: seq<StyleParam.TextPosition>,
                [<Optional; DefaultParameterValue(null)>] ?Domain: Domain,
                [<Optional; DefaultParameterValue(null)>] ?BranchValues: StyleParam.BranchValues,
                [<Optional; DefaultParameterValue(null)>] ?Count: StyleParam.IcicleCount,
                [<Optional; DefaultParameterValue(null)>] ?TilingOrientation: StyleParam.Orientation,
                [<Optional; DefaultParameterValue(null)>] ?TilingFlip: StyleParam.TilingFlip,
                [<Optional; DefaultParameterValue(null)>] ?Tiling: IcicleTiling,
                [<Optional; DefaultParameterValue(null)>] ?PathBarEdgeShape: StyleParam.PathbarEdgeShape,
                [<Optional; DefaultParameterValue(null)>] ?PathBar: Pathbar,
                [<Optional; DefaultParameterValue(true)>] ?UseDefaults: bool
            ) =

            let labels, parents = Seq.unzip labelsParents

            Chart.Icicle(
                labels,
                parents,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Values = Values,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Color = Color,
                ?ColorScale = ColorScale,
                ?ShowScale = ShowScale,
                ?Marker = Marker,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?Domain = Domain,
                ?BranchValues = BranchValues,
                ?Count = Count,
                ?TilingOrientation = TilingOrientation,
                ?TilingFlip = TilingFlip,
                ?Tiling = Tiling,
                ?PathBarEdgeShape = PathBarEdgeShape,
                ?PathBar = PathBar,
                ?UseDefaults = UseDefaults
            )
