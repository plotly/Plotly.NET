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
        [<Extension>]
        static member Sunburst
            (
                labels: seq<#IConvertible>,
                parents: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Values: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Name: string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
                [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?SectionColors: seq<Color>,
                [<Optional; DefaultParameterValue(null)>] ?SectionColorScale: StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?ShowSectionColorScale: bool,
                [<Optional; DefaultParameterValue(null)>] ?ReverseSectionColorScale: bool,
                [<Optional; DefaultParameterValue(null)>] ?SectionOutlineColor: Color,
                [<Optional; DefaultParameterValue(null)>] ?SectionOutlineWidth: float,
                [<Optional; DefaultParameterValue(null)>] ?SectionOutlineMultiWidth: seq<float>,
                [<Optional; DefaultParameterValue(null)>] ?SectionOutline: Line,
                [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
                [<Optional; DefaultParameterValue(null)>] ?TextInfo: StyleParam.TextInfo,
                [<Optional; DefaultParameterValue(null)>] ?BranchValues: StyleParam.BranchValues,
                [<Optional; DefaultParameterValue(null)>] ?Count        : string,
                [<Optional; DefaultParameterValue(null)>] ?Root         : SunburstRoot,
                [<Optional; DefaultParameterValue(null)>] ?Leaf         : SunburstLeaf,
                [<Optional; DefaultParameterValue(null)>] ?Level        : string,
                [<Optional; DefaultParameterValue(null)>] ?MaxDepth : int,
                [<Optional; DefaultParameterValue(null)>] ?Rotation: int,
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
                    ?Colorscale = SectionColorScale,
                    ?ShowScale = ShowSectionColorScale,
                    ?ReverseScale = ReverseSectionColorScale,
                    Outline = outline
                )

            TraceDomain.initSunburst (
                TraceDomainStyle.Sunburst(
                    Labels = labels,
                    Parents = parents,
                    Marker = marker,
                    ?Values = Values,
                    ?Name               = Name,
                    ?ShowLegend         = ShowLegend,
                    ?Opacity            = Opacity,
                    ?Text               = Text,
                    ?MultiText          = MultiText,
                    ?TextInfo           = TextInfo,
                    ?Rotation           = Rotation,
                    ?Sort               = Sort,
                    ?BranchValues       = BranchValues,
                    ?Count              = Count       ,
                    ?Root               = Root        ,
                    ?Leaf               = Leaf        ,
                    ?Level              = Level       ,
                    ?MaxDepth           = MaxDepth

                )
            )
            |> GenericChart.ofTraceObject useDefaults


        
        /// Creates a sunburst chart. Visualize hierarchical data spanning outward radially from root to leaves.
        [<Extension>]
        static member Sunburst
            (
                labelsparents: seq<#IConvertible * #IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Values                   : seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Name                     : string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend               : bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity                  : float,
                [<Optional; DefaultParameterValue(null)>] ?Text                     : #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText                : seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?SectionColors            : seq<Color>,
                [<Optional; DefaultParameterValue(null)>] ?SectionColorScale        : StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?ShowSectionColorScale    : bool,
                [<Optional; DefaultParameterValue(null)>] ?ReverseSectionColorScale : bool,
                [<Optional; DefaultParameterValue(null)>] ?SectionOutlineColor      : Color,
                [<Optional; DefaultParameterValue(null)>] ?SectionOutlineWidth      : float,
                [<Optional; DefaultParameterValue(null)>] ?SectionOutlineMultiWidth : seq<float>,
                [<Optional; DefaultParameterValue(null)>] ?SectionOutline           : Line,
                [<Optional; DefaultParameterValue(null)>] ?Marker                   : Marker,
                [<Optional; DefaultParameterValue(null)>] ?TextInfo                 : StyleParam.TextInfo,
                [<Optional; DefaultParameterValue(null)>] ?BranchValues             : StyleParam.BranchValues,
                [<Optional; DefaultParameterValue(null)>] ?Count                    : string,
                [<Optional; DefaultParameterValue(null)>] ?Root                     : SunburstRoot,
                [<Optional; DefaultParameterValue(null)>] ?Leaf                     : SunburstLeaf,
                [<Optional; DefaultParameterValue(null)>] ?Level                    : string,
                [<Optional; DefaultParameterValue(null)>] ?MaxDepth                 : int,
                [<Optional; DefaultParameterValue(null)>] ?Rotation                 : int,
                [<Optional; DefaultParameterValue(null)>] ?Sort                     : bool,
                [<Optional; DefaultParameterValue(null)>] ?UseDefaults              : bool
            ) =

            let labels, parents = Seq.unzip labelsparents

            Chart.Sunburst(
                labels,
                parents,
                ?Values                   = Values                   ,
                ?Name                     = Name                     ,
                ?ShowLegend               = ShowLegend               ,
                ?Opacity                  = Opacity                  ,
                ?Text                     = Text                     ,
                ?MultiText                = MultiText                ,
                ?SectionColors            = SectionColors            ,
                ?SectionColorScale        = SectionColorScale        ,
                ?ShowSectionColorScale    = ShowSectionColorScale    ,
                ?ReverseSectionColorScale = ReverseSectionColorScale ,
                ?SectionOutlineColor      = SectionOutlineColor      ,
                ?SectionOutlineWidth      = SectionOutlineWidth      ,
                ?SectionOutlineMultiWidth = SectionOutlineMultiWidth ,
                ?SectionOutline           = SectionOutline           ,
                ?Marker                   = Marker                   ,
                ?TextInfo                 = TextInfo                 ,
                ?BranchValues             = BranchValues             ,
                ?Count                    = Count                    ,
                ?Root                     = Root                     ,
                ?Leaf                     = Leaf                     ,
                ?Level                    = Level                    ,
                ?MaxDepth                 = MaxDepth                 ,
                ?Rotation                 = Rotation                 ,
                ?Sort                     = Sort                     ,
                ?UseDefaults              = UseDefaults              
            )


        /// Creates a treemap chart. Treemap charts visualize hierarchical data using nested rectangles. Same as Sunburst the hierarchy is defined by labels and parents attributes. Click on one sector to zoom in/out, which also displays a pathbar in the upper-left corner of your treemap. To zoom out you can use the path bar as well.
        [<Extension>]
        static member Treemap
            (
                labels : seq<#IConvertible>,
                parents : seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Values                   : seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Name                     : string,
                [<Optional; DefaultParameterValue(null)>] ?Visible                  : StyleParam.Visible,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend               : bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity                  : float,
                [<Optional; DefaultParameterValue(null)>] ?Text                     : #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText                : seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?TextPosition             : StyleParam.TextPosition,
                [<Optional; DefaultParameterValue(null)>] ?MultiTextPosition        : seq<StyleParam.TextPosition>,
                [<Optional; DefaultParameterValue(null)>] ?SectionColors            : seq<Color>,
                [<Optional; DefaultParameterValue(null)>] ?SectionColorScale        : StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?ShowSectionColorScale    : bool,
                [<Optional; DefaultParameterValue(null)>] ?ReverseSectionColorScale : bool,
                [<Optional; DefaultParameterValue(null)>] ?SectionOutlineColor      : Color,
                [<Optional; DefaultParameterValue(null)>] ?SectionOutlineWidth      : float,
                [<Optional; DefaultParameterValue(null)>] ?SectionOutlineMultiWidth : seq<float>,
                [<Optional; DefaultParameterValue(null)>] ?SectionOutline           : Line,
                [<Optional; DefaultParameterValue(null)>] ?Marker                   : Marker,
                [<Optional; DefaultParameterValue(null)>] ?TextInfo                 : StyleParam.TextInfo,
                [<Optional; DefaultParameterValue(null)>] ?BranchValues             : StyleParam.BranchValues,
                [<Optional; DefaultParameterValue(null)>] ?Count                    : string,
                [<Optional; DefaultParameterValue(null)>] ?Tiling                   : TreemapTiling,
                [<Optional; DefaultParameterValue(null)>] ?PathBar                  : Pathbar,
                [<Optional; DefaultParameterValue(null)>] ?Root                     : TreemapRoot,
                [<Optional; DefaultParameterValue(null)>] ?Level                    : string,
                [<Optional; DefaultParameterValue(null)>] ?MaxDepth                 : int,
                [<Optional; DefaultParameterValue(null)>] ?Rotation                 : int,
                [<Optional; DefaultParameterValue(null)>] ?UseDefaults              : bool
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
                    ?Colorscale = SectionColorScale,
                    ?ShowScale = ShowSectionColorScale,
                    ?ReverseScale = ReverseSectionColorScale,
                    Outline = outline
                )

            TraceDomain.initTreemap (
                TraceDomainStyle.Treemap(
                    Labels = labels,
                    Parents = parents,
                    Marker = marker,
                    ?Values = Values,
                    ?Name               = Name             ,
                    ?Visible            = Visible          ,
                    ?ShowLegend         = ShowLegend       ,
                    ?Opacity            = Opacity          ,
                    ?Text               = Text             ,
                    ?MultiText          = MultiText        ,
                    ?TextPosition       = TextPosition     ,
                    ?MultiTextPosition  = MultiTextPosition,
                    ?TextInfo           = TextInfo    ,
                    ?BranchValues       = BranchValues,
                    ?Count              = Count       ,
                    ?Tiling             = Tiling      ,
                    ?PathBar            = PathBar     ,
                    ?Root               = Root        ,
                    ?Level              = Level       ,
                    ?MaxDepth           = MaxDepth    ,
                    ?Rotation           = Rotation    
                )
            )
            |> GenericChart.ofTraceObject useDefaults        
            
        /// Creates a treemap chart. Treemap charts visualize hierarchical data using nested rectangles. Same as Sunburst the hierarchy is defined by labels and parents attributes. Click on one sector to zoom in/out, which also displays a pathbar in the upper-left corner of your treemap. To zoom out you can use the path bar as well.
        [<Extension>]
        static member Treemap
            (
                labelsparents: seq<#IConvertible * #IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Values                   : seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?Name                     : string,
                [<Optional; DefaultParameterValue(null)>] ?Visible                  : StyleParam.Visible,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend               : bool,
                [<Optional; DefaultParameterValue(null)>] ?Opacity                  : float,
                [<Optional; DefaultParameterValue(null)>] ?Text                     : #IConvertible,
                [<Optional; DefaultParameterValue(null)>] ?MultiText                : seq<#IConvertible>,
                [<Optional; DefaultParameterValue(null)>] ?TextPosition             : StyleParam.TextPosition,
                [<Optional; DefaultParameterValue(null)>] ?MultiTextPosition        : seq<StyleParam.TextPosition>,
                [<Optional; DefaultParameterValue(null)>] ?SectionColors            : seq<Color>,
                [<Optional; DefaultParameterValue(null)>] ?SectionColorScale        : StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?ShowSectionColorScale    : bool,
                [<Optional; DefaultParameterValue(null)>] ?ReverseSectionColorScale : bool,
                [<Optional; DefaultParameterValue(null)>] ?SectionOutlineColor      : Color,
                [<Optional; DefaultParameterValue(null)>] ?SectionOutlineWidth      : float,
                [<Optional; DefaultParameterValue(null)>] ?SectionOutlineMultiWidth : seq<float>,
                [<Optional; DefaultParameterValue(null)>] ?SectionOutline           : Line,
                [<Optional; DefaultParameterValue(null)>] ?Marker                   : Marker,
                [<Optional; DefaultParameterValue(null)>] ?TextInfo                 : StyleParam.TextInfo,
                [<Optional; DefaultParameterValue(null)>] ?BranchValues             : StyleParam.BranchValues,
                [<Optional; DefaultParameterValue(null)>] ?Count                    : string,
                [<Optional; DefaultParameterValue(null)>] ?Tiling                   : TreemapTiling,
                [<Optional; DefaultParameterValue(null)>] ?PathBar                  : Pathbar,
                [<Optional; DefaultParameterValue(null)>] ?Root                     : TreemapRoot,
                [<Optional; DefaultParameterValue(null)>] ?Level                    : string,
                [<Optional; DefaultParameterValue(null)>] ?MaxDepth                 : int,
                [<Optional; DefaultParameterValue(null)>] ?Rotation                 : int,
                [<Optional; DefaultParameterValue(null)>] ?UseDefaults              : bool
            ) =

            let labels, parents = Seq.unzip labelsparents

            Chart.Treemap(
                labels, 
                parents,
                ?Values                     = Values                   ,
                ?Name                       = Name                     ,
                ?Visible                    = Visible                  ,
                ?ShowLegend                 = ShowLegend               ,
                ?Opacity                    = Opacity                  ,
                ?Text                       = Text                     ,
                ?MultiText                  = MultiText                ,
                ?TextPosition               = TextPosition             ,
                ?MultiTextPosition          = MultiTextPosition        ,
                ?SectionColors              = SectionColors            ,
                ?SectionColorScale          = SectionColorScale        ,
                ?ShowSectionColorScale      = ShowSectionColorScale    ,
                ?ReverseSectionColorScale   = ReverseSectionColorScale ,
                ?SectionOutlineColor        = SectionOutlineColor      ,
                ?SectionOutlineWidth        = SectionOutlineWidth      ,
                ?SectionOutlineMultiWidth   = SectionOutlineMultiWidth ,
                ?SectionOutline             = SectionOutline           ,
                ?Marker                     = Marker                   ,
                ?TextInfo                   = TextInfo                 ,
                ?BranchValues               = BranchValues             ,
                ?Count                      = Count                    ,
                ?Tiling                     = Tiling                   ,
                ?PathBar                    = PathBar                  ,
                ?Root                       = Root                     ,
                ?Level                      = Level                    ,
                ?MaxDepth                   = MaxDepth                 ,
                ?Rotation                   = Rotation                 ,
                ?UseDefaults                = UseDefaults              
            )


        /// Computes the parallel coordinates plot
        [<Extension>]
        static member ParallelCoord
            (
                dimensions: seq<Dimension>,
                [<Optional; DefaultParameterValue(null)>] ?Name                     : string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend               : bool,
                [<Optional; DefaultParameterValue(null)>] ?LineColor                : Color,
                [<Optional; DefaultParameterValue(null)>] ?LineColorScale           : StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?ShowLineColorScale       : bool,
                [<Optional; DefaultParameterValue(null)>] ?ReverseLineColorScale    : bool,
                [<Optional; DefaultParameterValue(null)>] ?Line                     : Line,
                [<Optional; DefaultParameterValue(null)>] ?LabelAngle               : int,
                [<Optional; DefaultParameterValue(null)>] ?LabelFont                : Font,
                [<Optional; DefaultParameterValue(null)>] ?LabelSide                : StyleParam.Side,
                [<Optional; DefaultParameterValue(null)>] ?RangeFont                : Font,
                [<Optional; DefaultParameterValue(null)>] ?TickFont                 : Font,
                [<Optional; DefaultParameterValue(null)>] ?UseDefaults              : bool
            ) =
            let useDefaults = defaultArg UseDefaults true

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
                    Dimensions  = dimensions,
                    Line        = line,
                    ?Name       = Name      ,
                    ?ShowLegend = ShowLegend,
                    ?LabelAngle = LabelAngle,
                    ?LabelFont  = LabelFont ,
                    ?LabelSide  = LabelSide ,
                    ?RangeFont  = RangeFont ,
                    ?TickFont   = TickFont  
                )
            )
            |> GenericChart.ofTraceObject useDefaults

        /// Computes the parallel coordinates plot
        [<Extension>]
        static member ParallelCoord
            (
                keyValues: seq<string*seq<#IConvertible>>,
                [<Optional; DefaultParameterValue(null)>] ?Name                     : string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend               : bool,
                [<Optional; DefaultParameterValue(null)>] ?LineColor                : Color,
                [<Optional; DefaultParameterValue(null)>] ?LineColorScale           : StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?ShowLineColorScale       : bool,
                [<Optional; DefaultParameterValue(null)>] ?ReverseLineColorScale    : bool,
                [<Optional; DefaultParameterValue(null)>] ?Line                     : Line,
                [<Optional; DefaultParameterValue(null)>] ?LabelAngle               : int,
                [<Optional; DefaultParameterValue(null)>] ?LabelFont                : Font,
                [<Optional; DefaultParameterValue(null)>] ?LabelSide                : StyleParam.Side,
                [<Optional; DefaultParameterValue(null)>] ?RangeFont                : Font,
                [<Optional; DefaultParameterValue(null)>] ?TickFont                 : Font,
                [<Optional; DefaultParameterValue(null)>] ?UseDefaults              : bool
            ) =

            let dims =
                keyValues |> Seq.map (fun (key, vals) -> Dimension.initParallel (Label = key, Values = vals))

            Chart.ParallelCoord(
                dimensions = dims,
                ?Name                   = Name                 ,
                ?ShowLegend             = ShowLegend           ,
                ?LineColor              = LineColor            ,
                ?LineColorScale         = LineColorScale       ,
                ?ShowLineColorScale     = ShowLineColorScale   ,
                ?ReverseLineColorScale  = ReverseLineColorScale,
                ?Line                   = Line                 ,
                ?LabelAngle             = LabelAngle           ,
                ?LabelFont              = LabelFont            ,
                ?LabelSide              = LabelSide            ,
                ?RangeFont              = RangeFont            ,
                ?TickFont               = TickFont             ,
                ?UseDefaults            = UseDefaults          
            )

        /// Computes the parallel categories plot
        [<Extension>]
        static member ParallelCategories
            (
                dimensions: seq<Dimension>,
                [<Optional; DefaultParameterValue(null)>] ?Name                     : string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend               : bool,
                [<Optional; DefaultParameterValue(null)>] ?Counts                   : int,
                [<Optional; DefaultParameterValue(null)>] ?LineColor                : Color,
                [<Optional; DefaultParameterValue(null)>] ?LineShape                : StyleParam.Shape,
                [<Optional; DefaultParameterValue(null)>] ?LineColorScale           : StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?ShowLineColorScale       : bool,
                [<Optional; DefaultParameterValue(null)>] ?ReverseLineColorScale    : bool,
                [<Optional; DefaultParameterValue(null)>] ?Line                     : Line,
                [<Optional; DefaultParameterValue(null)>] ?Arrangement              : StyleParam.CategoryArrangement,
                [<Optional; DefaultParameterValue(null)>] ?BundleColors             : bool,
                [<Optional; DefaultParameterValue(null)>] ?SortPaths                : StyleParam.SortAlgorithm,
                [<Optional; DefaultParameterValue(null)>] ?LabelFont                : Font,
                [<Optional; DefaultParameterValue(null)>] ?TickFont                 : Font,
                [<Optional; DefaultParameterValue(null)>] ?UseDefaults              : bool
            ) =

            let useDefaults = defaultArg UseDefaults true
            
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
                    ?Name          = Name         ,
                    ?ShowLegend    = ShowLegend   ,
                    ?Counts        = Counts       ,
                    ?Arrangement   = Arrangement  ,
                    ?BundleColors  = BundleColors ,
                    ?SortPaths     = SortPaths    ,
                    ?LabelFont     = LabelFont    ,
                    ?TickFont      = TickFont    
                )
            )
            |> GenericChart.ofTraceObject useDefaults
            
        /// Computes the parallel categories plot
        [<Extension>]
        static member ParallelCategories
            (
                keyValues: seq<string*seq<#IConvertible>>,
                [<Optional; DefaultParameterValue(null)>] ?Name                     : string,
                [<Optional; DefaultParameterValue(null)>] ?ShowLegend               : bool,
                [<Optional; DefaultParameterValue(null)>] ?Counts                   : int,
                [<Optional; DefaultParameterValue(null)>] ?LineColor                : Color,
                [<Optional; DefaultParameterValue(null)>] ?LineShape                : StyleParam.Shape,
                [<Optional; DefaultParameterValue(null)>] ?LineColorScale           : StyleParam.Colorscale,
                [<Optional; DefaultParameterValue(null)>] ?ShowLineColorScale       : bool,
                [<Optional; DefaultParameterValue(null)>] ?ReverseLineColorScale    : bool,
                [<Optional; DefaultParameterValue(null)>] ?Line                     : Line,
                [<Optional; DefaultParameterValue(null)>] ?Arrangement              : StyleParam.CategoryArrangement,
                [<Optional; DefaultParameterValue(null)>] ?BundleColors             : bool,
                [<Optional; DefaultParameterValue(null)>] ?SortPaths                : StyleParam.SortAlgorithm,
                [<Optional; DefaultParameterValue(null)>] ?LabelFont                : Font,
                [<Optional; DefaultParameterValue(null)>] ?TickFont                 : Font,
                [<Optional; DefaultParameterValue(null)>] ?UseDefaults              : bool
            ) =

            let useDefaults = defaultArg UseDefaults true
            
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
                    ?Name          = Name         ,
                    ?ShowLegend    = ShowLegend   ,
                    ?Counts        = Counts       ,
                    ?Arrangement   = Arrangement  ,
                    ?BundleColors  = BundleColors ,
                    ?SortPaths     = SortPaths    ,
                    ?LabelFont     = LabelFont    ,
                    ?TickFont      = TickFont    
                )
            )
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
