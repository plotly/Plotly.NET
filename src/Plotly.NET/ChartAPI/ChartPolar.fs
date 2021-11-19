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
module ChartPolar =

    [<Extension>]
    type Chart =
        [<Extension>]
        static member internal renderScatterPolarTrace (useDefaults:bool) (useWebGL:bool) (style: TracePolar -> TracePolar) =
            if useWebGL then
                TracePolar.initScatterPolarGL style
                |> GenericChart.ofTraceObject useDefaults
            else
                TracePolar.initScatterPolar style
                |> GenericChart.ofTraceObject useDefaults

        /// Uses points, line or both depending on the mode to represent data points in a polar chart
        [<Extension>]
        static member ScatterPolar
            (
                r       : seq<#IConvertible>, 
                theta   : seq<#IConvertible>,
                mode    : StyleParam.Mode,
                [<Optional;DefaultParameterValue(null)>] ?Name              : string,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend        : bool,
                [<Optional;DefaultParameterValue(null)>] ?Opacity           : float,
                [<Optional;DefaultParameterValue(null)>] ?Text              : #IConvertible,
                [<Optional;DefaultParameterValue(null)>] ?MultiText         : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition      : StyleParam.TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?MultiTextPosition : seq<StyleParam.TextPosition>,
                [<Optional;DefaultParameterValue(null)>] ?MarkerColor       : Color,
                [<Optional;DefaultParameterValue(null)>] ?MarkerColorScale  : StyleParam.Colorscale,
                [<Optional;DefaultParameterValue(null)>] ?MarkerOutline     : Line,
                [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol      : StyleParam.MarkerSymbol3D,
                [<Optional;DefaultParameterValue(null)>] ?MultiMarkerSymbol : seq<StyleParam.MarkerSymbol3D>,
                [<Optional;DefaultParameterValue(null)>] ?Marker            : Marker,
                [<Optional;DefaultParameterValue(null)>] ?LineColor         : Color,
                [<Optional;DefaultParameterValue(null)>] ?LineColorScale    : StyleParam.Colorscale,
                [<Optional;DefaultParameterValue(null)>] ?LineWidth         : float,
                [<Optional;DefaultParameterValue(null)>] ?LineDash          : StyleParam.DrawingStyle,
                [<Optional;DefaultParameterValue(null)>] ?Line              : Line,
                [<Optional;DefaultParameterValue(null)>] ?UseWebGL          : bool,
                [<Optional;DefaultParameterValue(true)>] ?UseDefaults       : bool
            ) = 

                let useDefaults = defaultArg UseDefaults true
                
                let marker =
                    Marker 
                    |> Option.defaultValue (TraceObjects.Marker.init())
                    |> TraceObjects.Marker.style(
                        ?Color          = MarkerColor,
                        ?Outline        = MarkerOutline,
                        ?Symbol3D       = MarkerSymbol,
                        ?MultiSymbol3D  = MultiMarkerSymbol,
                        ?Colorscale     = MarkerColorScale
                    )                
                
                let line =
                    Line 
                    |> Option.defaultValue (Plotly.NET.Line.init())
                    |> Plotly.NET.Line.style(
                        ?Color      = LineColor,
                        ?Dash       = LineDash,
                        ?Colorscale = LineColorScale,
                        ?Width      = LineWidth
                    )

                let style = 
                    TracePolarStyle.ScatterPolar(
                        R                   = r                ,
                        Theta               = theta            ,
                        Mode                = mode             ,
                        Marker              = marker           ,
                        Line                = line             ,
                        ?Name               = Name             ,
                        ?ShowLegend         = ShowLegend       ,
                        ?Opacity            = Opacity          ,
                        ?Text               = Text             ,
                        ?MultiText          = MultiText        ,
                        ?TextPosition       = TextPosition     ,
                        ?MultiTextPosition  = MultiTextPosition
                    ) 

                let useWebGL = defaultArg UseWebGL false

                Chart.renderScatterPolarTrace useDefaults useWebGL style

         /// Uses points, line or both depending on the mode to represent data points in a polar chart
        [<Extension>]
        static member ScatterPolar
            (
                rTheta  : seq<#IConvertible * #IConvertible>, 
                mode    : StyleParam.Mode,
                [<Optional;DefaultParameterValue(null)>] ?Name              : string,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend        : bool,
                [<Optional;DefaultParameterValue(null)>] ?Opacity           : float,
                [<Optional;DefaultParameterValue(null)>] ?Text              : #IConvertible,
                [<Optional;DefaultParameterValue(null)>] ?MultiText         : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition      : StyleParam.TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?MultiTextPosition : seq<StyleParam.TextPosition>,
                [<Optional;DefaultParameterValue(null)>] ?MarkerColor       : Color,
                [<Optional;DefaultParameterValue(null)>] ?MarkerColorScale  : StyleParam.Colorscale,
                [<Optional;DefaultParameterValue(null)>] ?MarkerOutline     : Line,
                [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol      : StyleParam.MarkerSymbol3D,
                [<Optional;DefaultParameterValue(null)>] ?MultiMarkerSymbol : seq<StyleParam.MarkerSymbol3D>,
                [<Optional;DefaultParameterValue(null)>] ?Marker            : Marker,
                [<Optional;DefaultParameterValue(null)>] ?LineColor         : Color,
                [<Optional;DefaultParameterValue(null)>] ?LineColorScale    : StyleParam.Colorscale,
                [<Optional;DefaultParameterValue(null)>] ?LineWidth         : float,
                [<Optional;DefaultParameterValue(null)>] ?LineDash          : StyleParam.DrawingStyle,
                [<Optional;DefaultParameterValue(null)>] ?Line              : Line,
                [<Optional;DefaultParameterValue(null)>] ?UseWebGL          : bool,
                [<Optional;DefaultParameterValue(true)>] ?UseDefaults       : bool
            ) = 

                let r,t = Seq.unzip rTheta

                Chart.ScatterPolar(
                    r, t, mode,
                    ?Name               = Name             ,
                    ?ShowLegend         = ShowLegend       ,
                    ?Opacity            = Opacity          ,
                    ?Text               = Text             ,
                    ?MultiText          = MultiText        ,
                    ?TextPosition       = TextPosition     ,
                    ?MultiTextPosition  = MultiTextPosition,
                    ?MarkerColor        = MarkerColor      ,
                    ?MarkerColorScale   = MarkerColorScale ,
                    ?MarkerOutline      = MarkerOutline    ,
                    ?MarkerSymbol       = MarkerSymbol     ,
                    ?MultiMarkerSymbol  = MultiMarkerSymbol,
                    ?Marker             = Marker           ,
                    ?LineColor          = LineColor        ,
                    ?LineColorScale     = LineColorScale   ,
                    ?LineWidth          = LineWidth        ,
                    ?LineDash           = LineDash         ,
                    ?Line               = Line             ,
                    ?UseWebGL           = UseWebGL         ,
                    ?UseDefaults        = UseDefaults      
                )

        /// 
        [<Extension>]
        static member PointPolar
            (
                r       : seq<#IConvertible>, 
                theta   : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?Name              : string,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend        : bool,
                [<Optional;DefaultParameterValue(null)>] ?Opacity           : float,
                [<Optional;DefaultParameterValue(null)>] ?Text              : #IConvertible,
                [<Optional;DefaultParameterValue(null)>] ?MultiText         : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition      : StyleParam.TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?MultiTextPosition : seq<StyleParam.TextPosition>,
                [<Optional;DefaultParameterValue(null)>] ?MarkerColor       : Color,
                [<Optional;DefaultParameterValue(null)>] ?MarkerColorScale  : StyleParam.Colorscale,
                [<Optional;DefaultParameterValue(null)>] ?MarkerOutline     : Line,
                [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol      : StyleParam.MarkerSymbol3D,
                [<Optional;DefaultParameterValue(null)>] ?MultiMarkerSymbol : seq<StyleParam.MarkerSymbol3D>,
                [<Optional;DefaultParameterValue(null)>] ?Marker            : Marker,
                [<Optional;DefaultParameterValue(null)>] ?UseWebGL          : bool,
                [<Optional;DefaultParameterValue(true)>] ?UseDefaults       : bool
            ) = 

                let useDefaults = defaultArg UseDefaults true

                let changeMode = StyleParam.ModeUtils.showText (TextPosition.IsSome || MultiTextPosition.IsSome)
            
                let marker =
                    Marker 
                    |> Option.defaultValue (TraceObjects.Marker.init())
                    |> TraceObjects.Marker.style(
                        ?Color          = MarkerColor,
                        ?Outline        = MarkerOutline,
                        ?Symbol3D       = MarkerSymbol,
                        ?MultiSymbol3D  = MultiMarkerSymbol,
                        ?Colorscale     = MarkerColorScale
                    )                

                let style = 
                    TracePolarStyle.ScatterPolar(
                        R                   = r                ,
                        Theta               = theta            ,
                        Mode                = changeMode StyleParam.Mode.Markers,
                        Marker              = marker           ,
                        ?Name               = Name             ,
                        ?ShowLegend         = ShowLegend       ,
                        ?Opacity            = Opacity          ,
                        ?Text               = Text             ,
                        ?MultiText          = MultiText        ,
                        ?TextPosition       = TextPosition     ,
                        ?MultiTextPosition  = MultiTextPosition
                    ) 

                let useWebGL = defaultArg UseWebGL false
            
                Chart.renderScatterPolarTrace useDefaults useWebGL style

        /// 
        [<Extension>]
        static member PointPolar
            (
                rTheta : seq<#IConvertible * #IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?Name              : string,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend        : bool,
                [<Optional;DefaultParameterValue(null)>] ?Opacity           : float,
                [<Optional;DefaultParameterValue(null)>] ?Text              : #IConvertible,
                [<Optional;DefaultParameterValue(null)>] ?MultiText         : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition      : StyleParam.TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?MultiTextPosition : seq<StyleParam.TextPosition>,
                [<Optional;DefaultParameterValue(null)>] ?MarkerColor       : Color,
                [<Optional;DefaultParameterValue(null)>] ?MarkerColorScale  : StyleParam.Colorscale,
                [<Optional;DefaultParameterValue(null)>] ?MarkerOutline     : Line,
                [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol      : StyleParam.MarkerSymbol3D,
                [<Optional;DefaultParameterValue(null)>] ?MultiMarkerSymbol : seq<StyleParam.MarkerSymbol3D>,
                [<Optional;DefaultParameterValue(null)>] ?Marker            : Marker,
                [<Optional;DefaultParameterValue(null)>] ?UseWebGL          : bool,
                [<Optional;DefaultParameterValue(true)>] ?UseDefaults       : bool
            ) = 

                let r,t = Seq.unzip rTheta

                Chart.PointPolar(
                    r, t,
                    ?Name               = Name             ,
                    ?ShowLegend         = ShowLegend       ,
                    ?Opacity            = Opacity          ,
                    ?Text               = Text             ,
                    ?MultiText          = MultiText        ,
                    ?TextPosition       = TextPosition     ,
                    ?MultiTextPosition  = MultiTextPosition,
                    ?MarkerColor        = MarkerColor      ,
                    ?MarkerColorScale   = MarkerColorScale ,
                    ?MarkerOutline      = MarkerOutline    ,
                    ?MarkerSymbol       = MarkerSymbol     ,
                    ?MultiMarkerSymbol  = MultiMarkerSymbol,
                    ?Marker             = Marker           ,
                    ?UseWebGL           = UseWebGL         ,
                    ?UseDefaults        = UseDefaults      
                    
                )
            
        ///
        [<Extension>]
        static member LinePolar 
            (
                r       : seq<#IConvertible>, 
                theta   : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?ShowMarkers       : bool,
                [<Optional;DefaultParameterValue(null)>] ?Name              : string,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend        : bool,
                [<Optional;DefaultParameterValue(null)>] ?Opacity           : float,
                [<Optional;DefaultParameterValue(null)>] ?Text              : #IConvertible,
                [<Optional;DefaultParameterValue(null)>] ?MultiText         : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition      : StyleParam.TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?MultiTextPosition : seq<StyleParam.TextPosition>,
                [<Optional;DefaultParameterValue(null)>] ?MarkerColor       : Color,
                [<Optional;DefaultParameterValue(null)>] ?MarkerColorScale  : StyleParam.Colorscale,
                [<Optional;DefaultParameterValue(null)>] ?MarkerOutline     : Line,
                [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol      : StyleParam.MarkerSymbol3D,
                [<Optional;DefaultParameterValue(null)>] ?MultiMarkerSymbol : seq<StyleParam.MarkerSymbol3D>,
                [<Optional;DefaultParameterValue(null)>] ?Marker            : Marker,
                [<Optional;DefaultParameterValue(null)>] ?LineColor         : Color,
                [<Optional;DefaultParameterValue(null)>] ?LineColorScale    : StyleParam.Colorscale,
                [<Optional;DefaultParameterValue(null)>] ?LineWidth         : float,
                [<Optional;DefaultParameterValue(null)>] ?LineDash          : StyleParam.DrawingStyle,
                [<Optional;DefaultParameterValue(null)>] ?Line              : Line,
                [<Optional;DefaultParameterValue(null)>] ?UseWebGL          : bool,
                [<Optional;DefaultParameterValue(true)>] ?UseDefaults       : bool
            ) = 

                let useDefaults = defaultArg UseDefaults true
                let changeMode = 
                    let isShowMarker =
                        match ShowMarkers with
                        | Some isShow -> isShow
                        | Option.None        -> false
                    StyleParam.ModeUtils.showText (TextPosition.IsSome || MultiTextPosition.IsSome)                       
                    >> StyleParam.ModeUtils.showMarker (isShowMarker)

                let marker =
                    Marker 
                    |> Option.defaultValue (TraceObjects.Marker.init())
                    |> TraceObjects.Marker.style(
                        ?Color          = MarkerColor,
                        ?Outline        = MarkerOutline,
                        ?Symbol3D       = MarkerSymbol,
                        ?MultiSymbol3D  = MultiMarkerSymbol,
                        ?Colorscale     = MarkerColorScale
                    )                
                
                let line =
                    Line 
                    |> Option.defaultValue (Plotly.NET.Line.init())
                    |> Plotly.NET.Line.style(
                        ?Color      = LineColor,
                        ?Dash       = LineDash,
                        ?Colorscale = LineColorScale,
                        ?Width      = LineWidth
                    )

                let style = 
                    TracePolarStyle.ScatterPolar(
                        R                   = r                ,
                        Theta               = theta            ,
                        Mode                = changeMode StyleParam.Mode.Lines,
                        Marker              = marker           ,
                        Line                = line             ,
                        ?Name               = Name             ,
                        ?ShowLegend         = ShowLegend       ,
                        ?Opacity            = Opacity          ,
                        ?Text               = Text             ,
                        ?MultiText          = MultiText        ,
                        ?TextPosition       = TextPosition     ,
                        ?MultiTextPosition  = MultiTextPosition
                    ) 

                let useWebGL = defaultArg UseWebGL false
            
                Chart.renderScatterPolarTrace useDefaults useWebGL style

        ///
        [<Extension>]
        static member LinePolar 
            (
                rTheta : seq<#IConvertible * #IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?ShowMarkers       : bool,
                [<Optional;DefaultParameterValue(null)>] ?Name              : string,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend        : bool,
                [<Optional;DefaultParameterValue(null)>] ?Opacity           : float,
                [<Optional;DefaultParameterValue(null)>] ?Text              : #IConvertible,
                [<Optional;DefaultParameterValue(null)>] ?MultiText         : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition      : StyleParam.TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?MultiTextPosition : seq<StyleParam.TextPosition>,
                [<Optional;DefaultParameterValue(null)>] ?MarkerColor       : Color,
                [<Optional;DefaultParameterValue(null)>] ?MarkerColorScale  : StyleParam.Colorscale,
                [<Optional;DefaultParameterValue(null)>] ?MarkerOutline     : Line,
                [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol      : StyleParam.MarkerSymbol3D,
                [<Optional;DefaultParameterValue(null)>] ?MultiMarkerSymbol : seq<StyleParam.MarkerSymbol3D>,
                [<Optional;DefaultParameterValue(null)>] ?Marker            : Marker,
                [<Optional;DefaultParameterValue(null)>] ?LineColor         : Color,
                [<Optional;DefaultParameterValue(null)>] ?LineColorScale    : StyleParam.Colorscale,
                [<Optional;DefaultParameterValue(null)>] ?LineWidth         : float,
                [<Optional;DefaultParameterValue(null)>] ?LineDash          : StyleParam.DrawingStyle,
                [<Optional;DefaultParameterValue(null)>] ?Line              : Line,
                [<Optional;DefaultParameterValue(null)>] ?UseWebGL          : bool,
                [<Optional;DefaultParameterValue(true)>] ?UseDefaults       : bool
            ) = 

                let r,t = Seq.unzip rTheta

                Chart.LinePolar(
                   r, t,
                   ?ShowMarkers         = ShowMarkers      ,
                   ?Name                = Name             ,
                   ?ShowLegend          = ShowLegend       ,
                   ?Opacity             = Opacity          ,
                   ?Text                = Text             ,
                   ?MultiText           = MultiText        ,
                   ?TextPosition        = TextPosition     ,
                   ?MultiTextPosition   = MultiTextPosition,
                   ?MarkerColor         = MarkerColor      ,
                   ?MarkerColorScale    = MarkerColorScale ,
                   ?MarkerOutline       = MarkerOutline    ,
                   ?MarkerSymbol        = MarkerSymbol     ,
                   ?MultiMarkerSymbol   = MultiMarkerSymbol,
                   ?Marker              = Marker           ,
                   ?LineColor           = LineColor        ,
                   ?LineColorScale      = LineColorScale   ,
                   ?LineWidth           = LineWidth        ,
                   ?LineDash            = LineDash         ,
                   ?Line                = Line             ,
                   ?UseWebGL            = UseWebGL         ,
                   ?UseDefaults         = UseDefaults      
                   
                )

        ///
        [<Extension>]
        static member SplinePolar 
            (
                r       : seq<#IConvertible>, 
                theta   : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?ShowMarkers       : bool,
                [<Optional;DefaultParameterValue(null)>] ?Smoothing         : float,
                [<Optional;DefaultParameterValue(null)>] ?Name              : string,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend        : bool,
                [<Optional;DefaultParameterValue(null)>] ?Opacity           : float,
                [<Optional;DefaultParameterValue(null)>] ?Text              : #IConvertible,
                [<Optional;DefaultParameterValue(null)>] ?MultiText         : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition      : StyleParam.TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?MultiTextPosition : seq<StyleParam.TextPosition>,
                [<Optional;DefaultParameterValue(null)>] ?MarkerColor       : Color,
                [<Optional;DefaultParameterValue(null)>] ?MarkerColorScale  : StyleParam.Colorscale,
                [<Optional;DefaultParameterValue(null)>] ?MarkerOutline     : Line,
                [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol      : StyleParam.MarkerSymbol3D,
                [<Optional;DefaultParameterValue(null)>] ?MultiMarkerSymbol : seq<StyleParam.MarkerSymbol3D>,
                [<Optional;DefaultParameterValue(null)>] ?Marker            : Marker,
                [<Optional;DefaultParameterValue(null)>] ?LineColor         : Color,
                [<Optional;DefaultParameterValue(null)>] ?LineColorScale    : StyleParam.Colorscale,
                [<Optional;DefaultParameterValue(null)>] ?LineWidth         : float,
                [<Optional;DefaultParameterValue(null)>] ?LineDash          : StyleParam.DrawingStyle,
                [<Optional;DefaultParameterValue(null)>] ?Line              : Line,
                [<Optional;DefaultParameterValue(null)>] ?UseWebGL          : bool,
                [<Optional;DefaultParameterValue(true)>] ?UseDefaults       : bool
            ) = 

                let useDefaults = defaultArg UseDefaults true
                let changeMode = 
                    let isShowMarker =
                        match ShowMarkers with
                        | Some isShow -> isShow
                        | Option.None        -> false
                    StyleParam.ModeUtils.showText (TextPosition.IsSome || MultiTextPosition.IsSome)                       
                    >> StyleParam.ModeUtils.showMarker (isShowMarker)

                let marker =
                    Marker 
                    |> Option.defaultValue (TraceObjects.Marker.init())
                    |> TraceObjects.Marker.style(
                        ?Color          = MarkerColor,
                        ?Outline        = MarkerOutline,
                        ?Symbol3D       = MarkerSymbol,
                        ?MultiSymbol3D  = MultiMarkerSymbol,
                        ?Colorscale     = MarkerColorScale
                    )                
                
                let line =
                    Line 
                    |> Option.defaultValue (Plotly.NET.Line.init())
                    |> Plotly.NET.Line.style(
                        ?Color      = LineColor,
                        ?Dash       = LineDash,
                        ?Colorscale = LineColorScale,
                        ?Width      = LineWidth,
                        ?Smoothing  = Smoothing,
                        Shape       = StyleParam.Shape.Spline
                    )

                let style = 
                    TracePolarStyle.ScatterPolar(
                        R                   = r                ,
                        Theta               = theta            ,
                        Mode                = changeMode StyleParam.Mode.Lines,
                        Marker              = marker           ,
                        Line                = line             ,
                        ?Name               = Name             ,
                        ?ShowLegend         = ShowLegend       ,
                        ?Opacity            = Opacity          ,
                        ?Text               = Text             ,
                        ?MultiText          = MultiText        ,
                        ?TextPosition       = TextPosition     ,
                        ?MultiTextPosition  = MultiTextPosition
                    ) 
            
                let useWebGL = defaultArg UseWebGL false

                Chart.renderScatterPolarTrace useDefaults useWebGL style
        ///
        [<Extension>]
        static member SplinePolar 
            (
                rTheta : seq<#IConvertible * #IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?ShowMarkers       : bool,
                [<Optional;DefaultParameterValue(null)>] ?Smoothing         : float,
                [<Optional;DefaultParameterValue(null)>] ?Name              : string,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend        : bool,
                [<Optional;DefaultParameterValue(null)>] ?Opacity           : float,
                [<Optional;DefaultParameterValue(null)>] ?Text              : #IConvertible,
                [<Optional;DefaultParameterValue(null)>] ?MultiText         : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition      : StyleParam.TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?MultiTextPosition : seq<StyleParam.TextPosition>,
                [<Optional;DefaultParameterValue(null)>] ?MarkerColor       : Color,
                [<Optional;DefaultParameterValue(null)>] ?MarkerColorScale  : StyleParam.Colorscale,
                [<Optional;DefaultParameterValue(null)>] ?MarkerOutline     : Line,
                [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol      : StyleParam.MarkerSymbol3D,
                [<Optional;DefaultParameterValue(null)>] ?MultiMarkerSymbol : seq<StyleParam.MarkerSymbol3D>,
                [<Optional;DefaultParameterValue(null)>] ?Marker            : Marker,
                [<Optional;DefaultParameterValue(null)>] ?LineColor         : Color,
                [<Optional;DefaultParameterValue(null)>] ?LineColorScale    : StyleParam.Colorscale,
                [<Optional;DefaultParameterValue(null)>] ?LineWidth         : float,
                [<Optional;DefaultParameterValue(null)>] ?LineDash          : StyleParam.DrawingStyle,
                [<Optional;DefaultParameterValue(null)>] ?Line              : Line,
                [<Optional;DefaultParameterValue(null)>] ?UseWebGL          : bool,
                [<Optional;DefaultParameterValue(true)>] ?UseDefaults       : bool
            ) = 

                let r,t = Seq.unzip rTheta

                Chart.SplinePolar(
                    r, t,
                    ?ShowMarkers        = ShowMarkers      ,
                    ?Smoothing          = Smoothing        ,
                    ?Name               = Name             ,
                    ?ShowLegend         = ShowLegend       ,
                    ?Opacity            = Opacity          ,
                    ?Text               = Text             ,
                    ?MultiText          = MultiText        ,
                    ?TextPosition       = TextPosition     ,
                    ?MultiTextPosition  = MultiTextPosition,
                    ?MarkerColor        = MarkerColor      ,
                    ?MarkerColorScale   = MarkerColorScale ,
                    ?MarkerOutline      = MarkerOutline    ,
                    ?MarkerSymbol       = MarkerSymbol     ,
                    ?MultiMarkerSymbol  = MultiMarkerSymbol,
                    ?Marker             = Marker           ,
                    ?LineColor          = LineColor        ,
                    ?LineColorScale     = LineColorScale   ,
                    ?LineWidth          = LineWidth        ,
                    ?LineDash           = LineDash         ,
                    ?Line               = Line             ,
                    ?UseWebGL           = UseWebGL         ,
                    ?UseDefaults        = UseDefaults      
                    
                )

        /// 
        [<Extension>]
        static member BubblePolar
            (
                r       : seq<#IConvertible>, 
                theta   : seq<#IConvertible>,
                sizes   : seq<int>,
                [<Optional;DefaultParameterValue(null)>] ?Name              : string,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend        : bool,
                [<Optional;DefaultParameterValue(null)>] ?Opacity           : float,
                [<Optional;DefaultParameterValue(null)>] ?Text              : #IConvertible,
                [<Optional;DefaultParameterValue(null)>] ?MultiText         : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition      : StyleParam.TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?MultiTextPosition : seq<StyleParam.TextPosition>,
                [<Optional;DefaultParameterValue(null)>] ?MarkerColor       : Color,
                [<Optional;DefaultParameterValue(null)>] ?MarkerColorScale  : StyleParam.Colorscale,
                [<Optional;DefaultParameterValue(null)>] ?MarkerOutline     : Line,
                [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol      : StyleParam.MarkerSymbol3D,
                [<Optional;DefaultParameterValue(null)>] ?MultiMarkerSymbol : seq<StyleParam.MarkerSymbol3D>,
                [<Optional;DefaultParameterValue(null)>] ?Marker            : Marker,
                [<Optional;DefaultParameterValue(null)>] ?UseWebGL          : bool,
                [<Optional;DefaultParameterValue(true)>] ?UseDefaults       : bool
            ) = 

                let useDefaults = defaultArg UseDefaults true

                let changeMode = StyleParam.ModeUtils.showText (TextPosition.IsSome || MultiTextPosition.IsSome)
            
                let marker =
                    Marker 
                    |> Option.defaultValue (TraceObjects.Marker.init())
                    |> TraceObjects.Marker.style(
                        ?Color          = MarkerColor,
                        ?Outline        = MarkerOutline,
                        ?Symbol3D       = MarkerSymbol,
                        ?MultiSymbol3D  = MultiMarkerSymbol,
                        ?Colorscale     = MarkerColorScale,
                        MultiSize       = sizes
                    )                

                let style = 
                    TracePolarStyle.ScatterPolar(
                        R                   = r                ,
                        Theta               = theta            ,
                        Mode                = StyleParam.Mode.Markers,
                        Marker              = marker           ,
                        ?Name               = Name             ,
                        ?ShowLegend         = ShowLegend       ,
                        ?Opacity            = Opacity          ,
                        ?Text               = Text             ,
                        ?MultiText          = MultiText        ,
                        ?TextPosition       = TextPosition     ,
                        ?MultiTextPosition  = MultiTextPosition
                    ) 

                let useWebGL = defaultArg UseWebGL false
            
                Chart.renderScatterPolarTrace useDefaults useWebGL style

        /// 
        [<Extension>]
        static member BubblePolar
            (
                rThetaSizes:seq<#IConvertible*#IConvertible*int>,
                [<Optional;DefaultParameterValue(null)>] ?Name              : string,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend        : bool,
                [<Optional;DefaultParameterValue(null)>] ?Opacity           : float,
                [<Optional;DefaultParameterValue(null)>] ?Text              : #IConvertible,
                [<Optional;DefaultParameterValue(null)>] ?MultiText         : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition      : StyleParam.TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?MultiTextPosition : seq<StyleParam.TextPosition>,
                [<Optional;DefaultParameterValue(null)>] ?MarkerColor       : Color,
                [<Optional;DefaultParameterValue(null)>] ?MarkerColorScale  : StyleParam.Colorscale,
                [<Optional;DefaultParameterValue(null)>] ?MarkerOutline     : Line,
                [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol      : StyleParam.MarkerSymbol3D,
                [<Optional;DefaultParameterValue(null)>] ?MultiMarkerSymbol : seq<StyleParam.MarkerSymbol3D>,
                [<Optional;DefaultParameterValue(null)>] ?Marker            : Marker,
                [<Optional;DefaultParameterValue(null)>] ?UseWebGL          : bool,
                [<Optional;DefaultParameterValue(true)>] ?UseDefaults       : bool
            ) = 

                let r,t,sizes = Seq.unzip3 rThetaSizes

                Chart.BubblePolar(
                    r, t, sizes,
                    ?Name               = Name             ,
                    ?ShowLegend         = ShowLegend       ,
                    ?Opacity            = Opacity          ,
                    ?Text               = Text             ,
                    ?MultiText          = MultiText        ,
                    ?TextPosition       = TextPosition     ,
                    ?MultiTextPosition  = MultiTextPosition,
                    ?MarkerColor        = MarkerColor      ,
                    ?MarkerColorScale   = MarkerColorScale ,
                    ?MarkerOutline      = MarkerOutline    ,
                    ?MarkerSymbol       = MarkerSymbol     ,
                    ?MultiMarkerSymbol  = MultiMarkerSymbol,
                    ?Marker             = Marker           ,
                    ?UseWebGL           = UseWebGL         ,
                    ?UseDefaults        = UseDefaults      
                    
                )

        /// 
        [<Extension>]
        static member BarPolar
            (
                r       : seq<#IConvertible>, 
                theta   : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?Name                      : string         ,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend                : bool,
                [<Optional;DefaultParameterValue(null)>] ?Opacity                   : float,
                [<Optional;DefaultParameterValue(null)>] ?MultiOpacity              : seq<float>,
                [<Optional;DefaultParameterValue(null)>] ?Text                      : #IConvertible,
                [<Optional;DefaultParameterValue(null)>] ?MultiText                 : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?MarkerColor               : Color             ,
                [<Optional;DefaultParameterValue(null)>] ?MarkerColorScale          : StyleParam.Colorscale,
                [<Optional;DefaultParameterValue(null)>] ?MarkerOutline             : Line,
                [<Optional;DefaultParameterValue(null)>] ?MarkerPatternShape        : StyleParam.PatternShape,
                [<Optional;DefaultParameterValue(null)>] ?MultiMarkerPatternShape   : seq<StyleParam.PatternShape>,
                [<Optional;DefaultParameterValue(null)>] ?MarkerPattern             : Pattern,
                [<Optional;DefaultParameterValue(null)>] ?Marker                    : Marker,
                [<Optional;DefaultParameterValue(null)>] ?Base                      : #IConvertible,
                [<Optional;DefaultParameterValue(null)>] ?Width                     : #IConvertible,
                [<Optional;DefaultParameterValue(null)>] ?MultiWidth                : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(true)>] ?UseDefaults               : bool
            ) = 

                let useDefaults = defaultArg UseDefaults true

                let pattern = 
                    MarkerPattern
                    |> Option.defaultValue (TraceObjects.Pattern.init())
                    |> TraceObjects.Pattern.style(
                        ?Shape = MarkerPatternShape,
                        ?MultiShape = MultiMarkerPatternShape
                    )
                let marker =
                    Marker 
                    |> Option.defaultValue (TraceObjects.Marker.init())
                    |> TraceObjects.Marker.style(
                        ?Color          = MarkerColor,
                        Pattern         = pattern,
                        ?MultiOpacity   = MultiOpacity,
                        ?Colorscale     = MarkerColorScale,
                        ?Outline        = MarkerOutline
                    )

                TracePolar.initBarPolar(
                    TracePolarStyle.BarPolar(
                        R = r, Theta = theta,
                        Marker      = marker,
                        ?Name       = Name      ,
                        ?ShowLegend = ShowLegend,
                        ?Opacity    = Opacity   ,
                        ?Text       = Text      ,       
                        ?MultiText  = MultiText ,       
                        ?Base       = Base      ,
                        ?Width      = Width     ,
                        ?MultiWidth = MultiWidth
                    )
                )
                |> GenericChart.ofTraceObject useDefaults

        [<Extension>]
        static member BarPolar
            (
                rTheta : seq<#IConvertible * #IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?Name                      : string         ,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend                : bool,
                [<Optional;DefaultParameterValue(null)>] ?Opacity                   : float,
                [<Optional;DefaultParameterValue(null)>] ?MultiOpacity              : seq<float>,
                [<Optional;DefaultParameterValue(null)>] ?Text                      : #IConvertible,
                [<Optional;DefaultParameterValue(null)>] ?MultiText                 : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?MarkerColor               : Color             ,
                [<Optional;DefaultParameterValue(null)>] ?MarkerColorScale          : StyleParam.Colorscale,
                [<Optional;DefaultParameterValue(null)>] ?MarkerOutline             : Line,
                [<Optional;DefaultParameterValue(null)>] ?MarkerPatternShape        : StyleParam.PatternShape,
                [<Optional;DefaultParameterValue(null)>] ?MultiMarkerPatternShape   : seq<StyleParam.PatternShape>,
                [<Optional;DefaultParameterValue(null)>] ?MarkerPattern             : Pattern,
                [<Optional;DefaultParameterValue(null)>] ?Marker                    : Marker,
                [<Optional;DefaultParameterValue(null)>] ?Base                      : #IConvertible,
                [<Optional;DefaultParameterValue(null)>] ?Width                     : #IConvertible,
                [<Optional;DefaultParameterValue(null)>] ?MultiWidth                : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(true)>] ?UseDefaults               : bool
            ) = 

                let r, theta = Seq.unzip rTheta

                Chart.BarPolar(
                    r, theta,
                    ?Name                       = Name                   ,
                    ?ShowLegend                 = ShowLegend             ,
                    ?Opacity                    = Opacity                ,
                    ?MultiOpacity               = MultiOpacity           ,
                    ?Text                       = Text                   ,
                    ?MultiText                  = MultiText              ,
                    ?MarkerColor                = MarkerColor            ,
                    ?MarkerColorScale           = MarkerColorScale       ,
                    ?MarkerOutline              = MarkerOutline          ,
                    ?MarkerPatternShape         = MarkerPatternShape     ,
                    ?MultiMarkerPatternShape    = MultiMarkerPatternShape,
                    ?MarkerPattern              = MarkerPattern          ,
                    ?Marker                     = Marker                 ,
                    ?Base                       = Base                   ,
                    ?Width                      = Width                  ,
                    ?MultiWidth                 = MultiWidth             ,
                    ?UseDefaults                = UseDefaults            
                    
                )