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
module ChartCarpet =

    [<Extension>]
    type Chart =

        /// Shows how proportions of data, shown as pie-shaped pieces, contribute to the data.
        [<Extension>]
        static member Carpet
            (
                carpetId: string,
                [<Optional;DefaultParameterValue(null)>] ?Name              : string,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend        : bool,
                [<Optional;DefaultParameterValue(null)>] ?Opacity           : float,  
                [<Optional;DefaultParameterValue(null)>] ?X                 : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?MultiX            : seq<#seq<#IConvertible>>,
                [<Optional;DefaultParameterValue(null)>] ?Y                 : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?MultiY            : seq<#seq<#IConvertible>>,
                [<Optional;DefaultParameterValue(null)>] ?A                 : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?B                 : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?AAxis             : LinearAxis,
                [<Optional;DefaultParameterValue(null)>] ?BAxis             : LinearAxis,
                [<Optional;DefaultParameterValue(null)>] ?XAxis             : StyleParam.LinearAxisId,
                [<Optional;DefaultParameterValue(null)>] ?YAxis             : StyleParam.LinearAxisId,
                [<Optional;DefaultParameterValue(null)>] ?Color             : Color,
                [<Optional;DefaultParameterValue(null)>] ?CheaterSlope      : float,
                [<Optional;DefaultParameterValue(true)>] ?UseDefaults : bool
            ) = 

                let useDefaults = defaultArg UseDefaults true
                TraceCarpet.initCarpet(
                    TraceCarpetStyle.Carpet(
                        Carpet          = StyleParam.SubPlotId.Carpet carpetId,
                        ?Name           = Name        ,
                        ?ShowLegend     = ShowLegend  ,
                        ?Opacity        = Opacity     ,
                        ?X              = X           ,
                        ?MultiX         = MultiX      ,
                        ?Y              = Y           ,
                        ?MultiY         = MultiY      ,
                        ?A              = A           ,
                        ?B              = B           ,
                        ?AAxis          = AAxis       ,
                        ?BAxis          = BAxis       ,
                        ?XAxis          = XAxis       ,
                        ?YAxis          = YAxis       ,
                        ?Color          = Color       ,
                        ?CheaterSlope   = CheaterSlope
                    )
                )
                |> GenericChart.ofTraceObject useDefaults

        [<Extension>]
        static member ScatterCarpet
            (
                a               : seq<#IConvertible>,
                b               : seq<#IConvertible>,
                mode            : StyleParam.Mode,
                carpetAnchorId  : string,
                [<Optional;DefaultParameterValue(null)>] ?Name              : string,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend        : bool,
                [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol      : StyleParam.MarkerSymbol,
                [<Optional;DefaultParameterValue(null)>] ?MultiMarkerSymbol : seq<StyleParam.MarkerSymbol>,
                [<Optional;DefaultParameterValue(null)>] ?Color             : Color,
                [<Optional;DefaultParameterValue(null)>] ?Opacity           : float,
                [<Optional;DefaultParameterValue(null)>] ?MultiOpacity      : seq<float>,
                [<Optional;DefaultParameterValue(null)>] ?Text              : #IConvertible,
                [<Optional;DefaultParameterValue(null)>] ?MultiText         : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition      : StyleParam.TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?MultiTextPosition : seq<StyleParam.TextPosition>,
                [<Optional;DefaultParameterValue(null)>] ?TextFont          : Font,
                [<Optional;DefaultParameterValue(null)>] ?Size              : int,
                [<Optional;DefaultParameterValue(null)>] ?MultiSize         : seq<int>,
                [<Optional;DefaultParameterValue(null)>] ?Marker            : Marker,
                [<Optional;DefaultParameterValue(null)>] ?Dash              : StyleParam.DrawingStyle,
                [<Optional;DefaultParameterValue(null)>] ?Width             : float ,
                [<Optional;DefaultParameterValue(null)>] ?Line              : Line,
                [<Optional;DefaultParameterValue(true)>] ?UseDefaults : bool
            ) = 

                let useDefaults = defaultArg UseDefaults true
                TraceCarpet.initScatterCarpet(
                    TraceCarpetStyle.ScatterCarpet(
                        A                   = a,
                        B                   = b,
                        Mode                = mode,
                        Carpet             = (carpetAnchorId |> StyleParam.SubPlotId.Carpet),
                        ?Name               = Name             ,
                        ?ShowLegend         = ShowLegend       ,
                        ?Opacity            = Opacity          ,
                        ?Text               = Text             ,
                        ?MultiText          = MultiText        ,
                        ?TextPosition       = TextPosition     ,
                        ?MultiTextPosition  = MultiTextPosition,
                        ?TextFont           = TextFont         ,
                        ?Marker             = Marker           ,
                        ?Line               = Line             
                    )
                    >> TraceStyle.Marker(
                        ?Symbol         = MarkerSymbol     ,
                        ?MultiSymbol    = MultiMarkerSymbol,
                        ?Color          = Color            ,
                        ?Opacity        = Opacity          ,
                        ?MultiOpacity   = MultiOpacity     ,
                        ?Size           = Size,
                        ?MultiSize      = MultiSize
                    )
                    >> TraceStyle.Line(
                        ?Dash   = Dash,
                        ?Width  = Width,
                        ?Color  = Color
                    )

                )
                |> GenericChart.ofTraceObject useDefaults

        [<Extension>]
        static member ScatterCarpet
            (
                ab       : seq<#IConvertible*#IConvertible>,
                mode    : StyleParam.Mode,
                carpetAnchorId  : string,
                [<Optional;DefaultParameterValue(null)>] ?Name              : string,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend        : bool,
                [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol      : StyleParam.MarkerSymbol,
                [<Optional;DefaultParameterValue(null)>] ?MultiMarkerSymbol : seq<StyleParam.MarkerSymbol>,
                [<Optional;DefaultParameterValue(null)>] ?Color             : Color,
                [<Optional;DefaultParameterValue(null)>] ?Opacity           : float,
                [<Optional;DefaultParameterValue(null)>] ?MultiOpacity      : seq<float>,
                [<Optional;DefaultParameterValue(null)>] ?Text              : #IConvertible,
                [<Optional;DefaultParameterValue(null)>] ?MultiText         : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition      : StyleParam.TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?MultiTextPosition : seq<StyleParam.TextPosition>,
                [<Optional;DefaultParameterValue(null)>] ?TextFont          : Font,
                [<Optional;DefaultParameterValue(null)>] ?Size              : int,
                [<Optional;DefaultParameterValue(null)>] ?MultiSize         : seq<int>,
                [<Optional;DefaultParameterValue(null)>] ?Marker            : Marker,
                [<Optional;DefaultParameterValue(null)>] ?Dash              : StyleParam.DrawingStyle,
                [<Optional;DefaultParameterValue(null)>] ?Width             : float ,
                [<Optional;DefaultParameterValue(null)>] ?Line              : Line,
                [<Optional;DefaultParameterValue(true)>] ?UseDefaults : bool
            ) = 

                let a,b = Seq.unzip ab

                Chart.ScatterCarpet(
                    a, b, mode, carpetAnchorId,
                    ?Name               = Name             ,
                    ?ShowLegend         = ShowLegend       ,
                    ?MarkerSymbol       = MarkerSymbol     ,
                    ?MultiMarkerSymbol  = MultiMarkerSymbol,
                    ?Color              = Color            ,
                    ?Opacity            = Opacity          ,
                    ?MultiOpacity       = MultiOpacity     ,
                    ?Text               = Text             ,
                    ?MultiText          = MultiText        ,
                    ?TextPosition       = TextPosition     ,
                    ?MultiTextPosition  = MultiTextPosition,
                    ?TextFont           = TextFont         ,
                    ?Size               = Size             ,
                    ?MultiSize          = MultiSize        ,
                    ?Marker             = Marker           ,
                    ?Dash               = Dash             ,
                    ?Width              = Width            ,
                    ?Line               = Line             ,
                    ?UseDefaults        = UseDefaults
                )


        [<Extension>]
        static member PointCarpet
            (
                a               : seq<#IConvertible>,
                b               : seq<#IConvertible>,
                carpetAnchorId  : string,
                [<Optional;DefaultParameterValue(null)>] ?Name              : string,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend        : bool,
                [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol      : StyleParam.MarkerSymbol,
                [<Optional;DefaultParameterValue(null)>] ?MultiMarkerSymbol : seq<StyleParam.MarkerSymbol>,
                [<Optional;DefaultParameterValue(null)>] ?Color             : Color,
                [<Optional;DefaultParameterValue(null)>] ?Opacity           : float,
                [<Optional;DefaultParameterValue(null)>] ?MultiOpacity      : seq<float>,
                [<Optional;DefaultParameterValue(null)>] ?Text              : #IConvertible,
                [<Optional;DefaultParameterValue(null)>] ?MultiText         : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition      : StyleParam.TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?MultiTextPosition : seq<StyleParam.TextPosition>,
                [<Optional;DefaultParameterValue(null)>] ?TextFont          : Font,
                [<Optional;DefaultParameterValue(null)>] ?Size              : int,
                [<Optional;DefaultParameterValue(null)>] ?MultiSize         : seq<int>,
                [<Optional;DefaultParameterValue(null)>] ?Marker            : Marker,
                [<Optional;DefaultParameterValue(true)>] ?UseDefaults : bool
            ) = 

                let useDefaults = defaultArg UseDefaults true

                let changeMode = StyleParam.ModeUtils.showText (TextPosition.IsSome || TextFont.IsSome)

                TraceCarpet.initScatterCarpet(
                    TraceCarpetStyle.ScatterCarpet(
                        A                   = a,
                        B                   = b,
                        Mode                = changeMode StyleParam.Mode.Markers,
                        Carpet              = (carpetAnchorId |> StyleParam.SubPlotId.Carpet),
                        ?Name               = Name             ,
                        ?ShowLegend         = ShowLegend       ,
                        ?Opacity            = Opacity          ,
                        ?Text               = Text             ,
                        ?MultiText          = MultiText        ,
                        ?TextPosition       = TextPosition     ,
                        ?MultiTextPosition  = MultiTextPosition,
                        ?TextFont           = TextFont         ,
                        ?Marker             = Marker           
                    )
                    >> TraceStyle.Marker(
                        ?Symbol         = MarkerSymbol     ,
                        ?MultiSymbol    = MultiMarkerSymbol,
                        ?Color          = Color            ,
                        ?Opacity        = Opacity          ,
                        ?MultiOpacity   = MultiOpacity     ,
                        ?Size           = Size             ,
                        ?MultiSize      = MultiSize
                    )
                )
                |> GenericChart.ofTraceObject useDefaults

        [<Extension>]
        static member PointCarpet
            (
                ab : seq<#IConvertible*#IConvertible>,
                carpetAnchorId          : string,
                [<Optional;DefaultParameterValue(null)>] ?Name              : string,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend        : bool,
                [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol      : StyleParam.MarkerSymbol,
                [<Optional;DefaultParameterValue(null)>] ?MultiMarkerSymbol : seq<StyleParam.MarkerSymbol>,
                [<Optional;DefaultParameterValue(null)>] ?Color             : Color,
                [<Optional;DefaultParameterValue(null)>] ?Opacity           : float,
                [<Optional;DefaultParameterValue(null)>] ?MultiOpacity      : seq<float>,
                [<Optional;DefaultParameterValue(null)>] ?Text              : #IConvertible,
                [<Optional;DefaultParameterValue(null)>] ?MultiText         : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition      : StyleParam.TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?MultiTextPosition : seq<StyleParam.TextPosition>,
                [<Optional;DefaultParameterValue(null)>] ?TextFont          : Font,
                [<Optional;DefaultParameterValue(null)>] ?Size              : int,
                [<Optional;DefaultParameterValue(null)>] ?MultiSize         : seq<int>,
                [<Optional;DefaultParameterValue(null)>] ?Marker            : Marker,
                [<Optional;DefaultParameterValue(true)>] ?UseDefaults : bool
            ) = 

                let a,b = Seq.unzip ab

                Chart.PointCarpet(
                    a, b, carpetAnchorId,
                    ?Name              = Name              ,
                    ?ShowLegend        = ShowLegend        ,
                    ?MarkerSymbol      = MarkerSymbol      ,
                    ?MultiMarkerSymbol = MultiMarkerSymbol ,
                    ?Color             = Color             ,
                    ?Opacity           = Opacity           ,
                    ?MultiOpacity      = MultiOpacity      ,
                    ?Text              = Text              ,
                    ?MultiText         = MultiText         ,
                    ?TextPosition      = TextPosition      ,
                    ?MultiTextPosition = MultiTextPosition ,
                    ?TextFont          = TextFont          ,
                    ?Size              = Size              ,
                    ?MultiSize         = MultiSize         ,
                    ?Marker            = Marker            ,
                    ?UseDefaults       = UseDefaults
                )

        [<Extension>]
        static member LineCarpet
            (
                a               : seq<#IConvertible>,
                b               : seq<#IConvertible>,
                carpetAnchorId  : string,
                [<Optional;DefaultParameterValue(null)>] ?Name              : string,
                [<Optional;DefaultParameterValue(null)>] ?ShowMarkers       : bool,
                [<Optional;DefaultParameterValue(null)>] ?Dash              : StyleParam.DrawingStyle,
                [<Optional;DefaultParameterValue(null)>] ?Width             : float ,
                [<Optional;DefaultParameterValue(null)>] ?Line              : Line,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend        : bool,
                [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol      : StyleParam.MarkerSymbol,
                [<Optional;DefaultParameterValue(null)>] ?MultiMarkerSymbol : seq<StyleParam.MarkerSymbol>,
                [<Optional;DefaultParameterValue(null)>] ?Color             : Color,
                [<Optional;DefaultParameterValue(null)>] ?Opacity           : float,
                [<Optional;DefaultParameterValue(null)>] ?MultiOpacity      : seq<float>,
                [<Optional;DefaultParameterValue(null)>] ?Text              : #IConvertible,
                [<Optional;DefaultParameterValue(null)>] ?MultiText         : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition      : StyleParam.TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?MultiTextPosition : seq<StyleParam.TextPosition>,
                [<Optional;DefaultParameterValue(null)>] ?TextFont          : Font,
                [<Optional;DefaultParameterValue(null)>] ?Size              : int,
                [<Optional;DefaultParameterValue(null)>] ?MultiSize         : seq<int>,
                [<Optional;DefaultParameterValue(null)>] ?Marker            : Marker,
                [<Optional;DefaultParameterValue(true)>] ?UseDefaults : bool
            ) = 

                let useDefaults = defaultArg UseDefaults true

                let changeMode = 
                    let isShowMarker =
                        match ShowMarkers with
                        | Some isShow -> isShow
                        | Option.None        -> false
                    StyleParam.ModeUtils.showText (TextPosition.IsSome || TextFont.IsSome)                       
                    >> StyleParam.ModeUtils.showMarker (isShowMarker)

                TraceCarpet.initScatterCarpet(
                    TraceCarpetStyle.ScatterCarpet(
                        A                   = a,
                        B                   = b,
                        Mode                = changeMode StyleParam.Mode.Lines,
                        Carpet              = (carpetAnchorId |> StyleParam.SubPlotId.Carpet),
                        ?Name               = Name             ,
                        ?ShowLegend         = ShowLegend       ,
                        ?Opacity            = Opacity          ,
                        ?Text               = Text             ,
                        ?MultiText          = MultiText        ,
                        ?TextPosition       = TextPosition     ,
                        ?MultiTextPosition  = MultiTextPosition,
                        ?TextFont           = TextFont         ,
                        ?Marker             = Marker           ,
                        ?Line               = Line
                    )
                    >> TraceStyle.Marker(
                        ?Symbol         = MarkerSymbol     ,
                        ?MultiSymbol    = MultiMarkerSymbol,
                        ?Color          = Color            ,
                        ?Opacity        = Opacity          ,
                        ?MultiOpacity   = MultiOpacity     ,
                        ?Size           = Size             ,
                        ?MultiSize      = MultiSize
                    )
                    >> TraceStyle.Line(
                        ?Dash   = Dash,
                        ?Width  = Width,
                        ?Color  = Color
                    )
                )
                |> GenericChart.ofTraceObject useDefaults

        [<Extension>]
        static member LineCarpet
            (
                ab : seq<#IConvertible*#IConvertible>,
                carpetAnchorId          : string,
                [<Optional;DefaultParameterValue(null)>] ?Name              : string,
                [<Optional;DefaultParameterValue(null)>] ?ShowMarkers       : bool,
                [<Optional;DefaultParameterValue(null)>] ?Dash              : StyleParam.DrawingStyle,
                [<Optional;DefaultParameterValue(null)>] ?Width             : float ,
                [<Optional;DefaultParameterValue(null)>] ?Line              : Line,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend        : bool,
                [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol      : StyleParam.MarkerSymbol,
                [<Optional;DefaultParameterValue(null)>] ?MultiMarkerSymbol : seq<StyleParam.MarkerSymbol>,
                [<Optional;DefaultParameterValue(null)>] ?Color             : Color,
                [<Optional;DefaultParameterValue(null)>] ?Opacity           : float,
                [<Optional;DefaultParameterValue(null)>] ?MultiOpacity      : seq<float>,
                [<Optional;DefaultParameterValue(null)>] ?Text              : #IConvertible,
                [<Optional;DefaultParameterValue(null)>] ?MultiText         : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition      : StyleParam.TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?MultiTextPosition : seq<StyleParam.TextPosition>,
                [<Optional;DefaultParameterValue(null)>] ?TextFont          : Font,
                [<Optional;DefaultParameterValue(null)>] ?Size              : int,
                [<Optional;DefaultParameterValue(null)>] ?MultiSize         : seq<int>,
                [<Optional;DefaultParameterValue(null)>] ?Marker            : Marker,
                [<Optional;DefaultParameterValue(true)>] ?UseDefaults : bool
            ) = 

                let a,b = Seq.unzip ab

                Chart.LineCarpet(
                    a, b, carpetAnchorId,
                    ?Name              = Name              ,
                    ?ShowMarkers       = ShowMarkers       ,
                    ?Dash              = Dash              ,
                    ?Width             = Width             ,
                    ?Line              = Line              ,
                    ?ShowLegend        = ShowLegend        ,
                    ?MarkerSymbol      = MarkerSymbol      ,
                    ?MultiMarkerSymbol = MultiMarkerSymbol ,
                    ?Color             = Color             ,
                    ?Opacity           = Opacity           ,
                    ?MultiOpacity      = MultiOpacity      ,
                    ?Text              = Text              ,
                    ?MultiText         = MultiText         ,
                    ?TextPosition      = TextPosition      ,
                    ?MultiTextPosition = MultiTextPosition ,
                    ?TextFont          = TextFont          ,
                    ?Size              = Size              ,
                    ?MultiSize         = MultiSize         ,
                    ?Marker            = Marker            ,
                    ?UseDefaults       = UseDefaults
                )

        [<Extension>]
        static member SplineCarpet
            (
                a               : seq<#IConvertible>,
                b               : seq<#IConvertible>,
                carpetAnchorId  : string,
                [<Optional;DefaultParameterValue(null)>] ?Name              : string,
                [<Optional;DefaultParameterValue(null)>] ?ShowMarkers       : bool,
                [<Optional;DefaultParameterValue(null)>] ?Dash              : StyleParam.DrawingStyle,
                [<Optional;DefaultParameterValue(null)>] ?Width             : float ,
                [<Optional;DefaultParameterValue(null)>] ?Smoothing         : float,
                [<Optional;DefaultParameterValue(null)>] ?Line              : Line,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend        : bool,
                [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol      : StyleParam.MarkerSymbol,
                [<Optional;DefaultParameterValue(null)>] ?MultiMarkerSymbol : seq<StyleParam.MarkerSymbol>,
                [<Optional;DefaultParameterValue(null)>] ?Color             : Color,
                [<Optional;DefaultParameterValue(null)>] ?Opacity           : float,
                [<Optional;DefaultParameterValue(null)>] ?MultiOpacity      : seq<float>,
                [<Optional;DefaultParameterValue(null)>] ?Text              : #IConvertible,
                [<Optional;DefaultParameterValue(null)>] ?MultiText         : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition      : StyleParam.TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?MultiTextPosition : seq<StyleParam.TextPosition>,
                [<Optional;DefaultParameterValue(null)>] ?TextFont          : Font,
                [<Optional;DefaultParameterValue(null)>] ?Size              : int,
                [<Optional;DefaultParameterValue(null)>] ?MultiSize         : seq<int>,
                [<Optional;DefaultParameterValue(null)>] ?Marker            : Marker,
                [<Optional;DefaultParameterValue(true)>] ?UseDefaults : bool
            ) = 

                let useDefaults = defaultArg UseDefaults true

                let changeMode = 
                    let isShowMarker =
                        match ShowMarkers with
                        | Some isShow -> isShow
                        | Option.None        -> false
                    StyleParam.ModeUtils.showText (TextPosition.IsSome || TextFont.IsSome)                       
                    >> StyleParam.ModeUtils.showMarker (isShowMarker)

                TraceCarpet.initScatterCarpet(
                    TraceCarpetStyle.ScatterCarpet(
                        A                   = a,
                        B                   = b,
                        Mode                = changeMode StyleParam.Mode.Lines,
                        Carpet              = (carpetAnchorId |> StyleParam.SubPlotId.Carpet),
                        ?Name               = Name             ,
                        ?ShowLegend         = ShowLegend       ,
                        ?Opacity            = Opacity          ,
                        ?Text               = Text             ,
                        ?MultiText          = MultiText        ,
                        ?TextPosition       = TextPosition     ,
                        ?MultiTextPosition  = MultiTextPosition,
                        ?TextFont           = TextFont         ,
                        ?Marker             = Marker           ,
                        ?Line               = Line
                    )
                    >> TraceStyle.Marker(
                        ?Symbol         = MarkerSymbol     ,
                        ?MultiSymbol    = MultiMarkerSymbol,
                        ?Color          = Color            ,
                        ?Opacity        = Opacity          ,
                        ?MultiOpacity   = MultiOpacity     ,
                        ?Size           = Size             ,
                        ?MultiSize      = MultiSize
                    )
                    >> TraceStyle.Line(
                        ?Color      = Color,
                        ?Dash       = Dash,
                        ?Width      = Width, 
                        Shape       = StyleParam.Shape.Spline, 
                        ?Smoothing  = Smoothing
                    )
                )
                |> GenericChart.ofTraceObject useDefaults

        [<Extension>]
        static member SplineCarpet
            (
                ab : seq<#IConvertible*#IConvertible>,
                carpetAnchorId          : string,
                [<Optional;DefaultParameterValue(null)>] ?Name              : string,
                [<Optional;DefaultParameterValue(null)>] ?ShowMarkers       : bool,
                [<Optional;DefaultParameterValue(null)>] ?Dash              : StyleParam.DrawingStyle,
                [<Optional;DefaultParameterValue(null)>] ?Width             : float ,
                [<Optional;DefaultParameterValue(null)>] ?Smoothing         : float,
                [<Optional;DefaultParameterValue(null)>] ?Line              : Line,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend        : bool,
                [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol      : StyleParam.MarkerSymbol,
                [<Optional;DefaultParameterValue(null)>] ?MultiMarkerSymbol : seq<StyleParam.MarkerSymbol>,
                [<Optional;DefaultParameterValue(null)>] ?Color             : Color,
                [<Optional;DefaultParameterValue(null)>] ?Opacity           : float,
                [<Optional;DefaultParameterValue(null)>] ?MultiOpacity      : seq<float>,
                [<Optional;DefaultParameterValue(null)>] ?Text              : #IConvertible,
                [<Optional;DefaultParameterValue(null)>] ?MultiText         : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition      : StyleParam.TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?MultiTextPosition : seq<StyleParam.TextPosition>,
                [<Optional;DefaultParameterValue(null)>] ?TextFont          : Font,
                [<Optional;DefaultParameterValue(null)>] ?Size              : int,
                [<Optional;DefaultParameterValue(null)>] ?MultiSize         : seq<int>,
                [<Optional;DefaultParameterValue(null)>] ?Marker            : Marker,
                [<Optional;DefaultParameterValue(true)>] ?UseDefaults : bool
            ) = 

                let a,b = Seq.unzip ab

                Chart.SplineCarpet(
                    a, b, carpetAnchorId,
                    ?Name              = Name              ,
                    ?ShowMarkers       = ShowMarkers       ,
                    ?Dash              = Dash              ,
                    ?Width             = Width             ,
                    ?Smoothing         = Smoothing         ,
                    ?Line              = Line              ,
                    ?ShowLegend        = ShowLegend        ,
                    ?MarkerSymbol      = MarkerSymbol      ,
                    ?MultiMarkerSymbol = MultiMarkerSymbol ,
                    ?Color             = Color             ,
                    ?Opacity           = Opacity           ,
                    ?MultiOpacity      = MultiOpacity      ,
                    ?Text              = Text              ,
                    ?MultiText         = MultiText         ,
                    ?TextPosition      = TextPosition      ,
                    ?MultiTextPosition = MultiTextPosition ,
                    ?TextFont          = TextFont          ,
                    ?Size              = Size              ,
                    ?MultiSize         = MultiSize         ,
                    ?Marker            = Marker            ,
                    ?UseDefaults       = UseDefaults
                )

        static member BubbleCarpet 
            (
                a               : seq<#IConvertible>,
                b               : seq<#IConvertible>,
                sizes           : seq<int>,
                carpetAnchorId  : string,
                [<Optional;DefaultParameterValue(null)>] ?Name              : string,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend        : bool,
                [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol      : StyleParam.MarkerSymbol,
                [<Optional;DefaultParameterValue(null)>] ?MultiMarkerSymbol : seq<StyleParam.MarkerSymbol>,
                [<Optional;DefaultParameterValue(null)>] ?Color             : Color,
                [<Optional;DefaultParameterValue(null)>] ?Opacity           : float,
                [<Optional;DefaultParameterValue(null)>] ?MultiOpacity      : seq<float>,
                [<Optional;DefaultParameterValue(null)>] ?Text              : #IConvertible,
                [<Optional;DefaultParameterValue(null)>] ?MultiText         : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition      : StyleParam.TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?MultiTextPosition : seq<StyleParam.TextPosition>,
                [<Optional;DefaultParameterValue(null)>] ?TextFont          : Font,
                [<Optional;DefaultParameterValue(null)>] ?Marker            : Marker,
                [<Optional;DefaultParameterValue(true)>] ?UseDefaults : bool
            ) = 

                Chart.PointCarpet(
                    a,b,carpetAnchorId,
                    MultiSize = sizes,
                    ?Name               = Name             ,
                    ?ShowLegend         = ShowLegend       ,
                    ?MarkerSymbol       = MarkerSymbol     ,
                    ?MultiMarkerSymbol  = MultiMarkerSymbol,
                    ?Color              = Color            ,
                    ?Opacity            = Opacity          ,
                    ?MultiOpacity       = MultiOpacity     ,
                    ?Text               = Text             ,
                    ?MultiText          = MultiText        ,
                    ?TextPosition       = TextPosition     ,
                    ?MultiTextPosition  = MultiTextPosition,
                    ?TextFont           = TextFont         ,
                    ?Marker             = Marker           ,
                    ?UseDefaults        = UseDefaults
                )

        static member BubbleCarpet 
            (
                absizes         : seq<#IConvertible*#IConvertible*int>,
                carpetAnchorId  : string,
                [<Optional;DefaultParameterValue(null)>] ?Name              : string,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend        : bool,
                [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol      : StyleParam.MarkerSymbol,
                [<Optional;DefaultParameterValue(null)>] ?MultiMarkerSymbol : seq<StyleParam.MarkerSymbol>,
                [<Optional;DefaultParameterValue(null)>] ?Color             : Color,
                [<Optional;DefaultParameterValue(null)>] ?Opacity           : float,
                [<Optional;DefaultParameterValue(null)>] ?MultiOpacity      : seq<float>,
                [<Optional;DefaultParameterValue(null)>] ?Text              : #IConvertible,
                [<Optional;DefaultParameterValue(null)>] ?MultiText         : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition      : StyleParam.TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?MultiTextPosition : seq<StyleParam.TextPosition>,
                [<Optional;DefaultParameterValue(null)>] ?TextFont          : Font,
                [<Optional;DefaultParameterValue(null)>] ?Marker            : Marker,
                [<Optional;DefaultParameterValue(true)>] ?UseDefaults : bool
            ) = 
                
                let a,b,sizes = Seq.unzip3 absizes
                
                Chart.PointCarpet(
                    a,b,carpetAnchorId,
                    MultiSize = sizes,
                    ?Name               = Name             ,
                    ?ShowLegend         = ShowLegend       ,
                    ?MarkerSymbol       = MarkerSymbol     ,
                    ?MultiMarkerSymbol  = MultiMarkerSymbol,
                    ?Color              = Color            ,
                    ?Opacity            = Opacity          ,
                    ?MultiOpacity       = MultiOpacity     ,
                    ?Text               = Text             ,
                    ?MultiText          = MultiText        ,
                    ?TextPosition       = TextPosition     ,
                    ?MultiTextPosition  = MultiTextPosition,
                    ?TextFont           = TextFont         ,
                    ?Marker             = Marker           ,
                    ?UseDefaults        = UseDefaults
                )

        static member ContourCarpet 
            (
                carpetAnchorId  : string,
                z               : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?Name      : string,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional;DefaultParameterValue(null)>] ?Opacity   : float,
                [<Optional;DefaultParameterValue(null)>] ?A         : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?B         : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?Text      : #IConvertible,
                [<Optional;DefaultParameterValue(null)>] ?MultiText : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?Dash      : StyleParam.DrawingStyle,
                [<Optional;DefaultParameterValue(null)>] ?Width     : float ,
                [<Optional;DefaultParameterValue(null)>] ?LineColor : Color ,
                [<Optional;DefaultParameterValue(null)>] ?Line      : Line,
                [<Optional;DefaultParameterValue(null)>] ?ColorScale: StyleParam.Colorscale,
                [<Optional;DefaultParameterValue(null)>] ?ShowScale : bool,
                [<Optional;DefaultParameterValue(null)>] ?Contours  : Contours,
                [<Optional;DefaultParameterValue(true)>] ?UseDefaults : bool
            ) = 

                let useDefaults = defaultArg UseDefaults true

                TraceCarpet.initContourCarpet(
                    TraceCarpetStyle.ContourCarpet (
                        Carpet = StyleParam.SubPlotId.Carpet carpetAnchorId,
                        ?Name       = Name              ,
                        ?ShowLegend = ShowLegend        ,
                        ?Opacity    = Opacity           ,
                        Z           = z                 ,
                        ?A          = A                 ,
                        ?B          = B                 ,
                        ?Text       = Text              ,
                        ?MultiText  = MultiText         ,
                        ?Line       = Line              ,
                        ?ColorScale = ColorScale        ,
                        ?ShowScale  = ShowScale         ,
                        ?Contours   = Contours          
                    )
                    >> TraceStyle.Line(
                        ?Dash       = Dash              ,
                        ?Width      = Width             ,
                        ?Color      = LineColor         
                    )
                )
                |> GenericChart.ofTraceObject useDefaults
                
                
        static member ContourCarpet 
            (
                carpetAnchorId  : string,
                abz             : seq<#IConvertible * #IConvertible * #IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?Name      : string,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend: bool,
                [<Optional;DefaultParameterValue(null)>] ?Opacity   : float,
                [<Optional;DefaultParameterValue(null)>] ?Text      : #IConvertible,
                [<Optional;DefaultParameterValue(null)>] ?MultiText : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?Dash      : StyleParam.DrawingStyle,
                [<Optional;DefaultParameterValue(null)>] ?Width     : float ,
                [<Optional;DefaultParameterValue(null)>] ?LineColor : Color ,
                [<Optional;DefaultParameterValue(null)>] ?Line      : Line,
                [<Optional;DefaultParameterValue(null)>] ?ColorScale: StyleParam.Colorscale,
                [<Optional;DefaultParameterValue(null)>] ?ShowScale : bool,
                [<Optional;DefaultParameterValue(null)>] ?Contours  : Contours,
                [<Optional;DefaultParameterValue(true)>] ?UseDefaults : bool
            ) = 

                let useDefaults = defaultArg UseDefaults true
                
                let a,b,z = Seq.unzip3 abz

                TraceCarpet.initContourCarpet(
                    TraceCarpetStyle.ContourCarpet (
                        Carpet = StyleParam.SubPlotId.Carpet carpetAnchorId,
                        ?Name       = Name              ,
                        ?ShowLegend = ShowLegend        ,
                        ?Opacity    = Opacity           ,
                        Z           = z                 ,
                        A           = a                 ,
                        B           = b                 ,
                        ?Text       = Text              ,
                        ?MultiText  = MultiText         ,
                        ?Line       = Line              ,
                        ?ColorScale = ColorScale        ,
                        ?ShowScale  = ShowScale         ,
                        ?Contours   = Contours          
                    )
                    >> TraceStyle.Line(
                        ?Dash       = Dash              ,
                        ?Width      = Width             ,
                        ?Color      = LineColor         
                    )
                )
                |> GenericChart.ofTraceObject useDefaults
                
                