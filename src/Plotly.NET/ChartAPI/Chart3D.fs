namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects

open DynamicObj
open System
open System.IO
//open FSharp.Care.Collections

open GenericChart
open StyleParam
open System.Runtime.InteropServices
open System.Runtime.CompilerServices

[<AutoOpen>]
module Chart3D =

    [<Extension>]
    type Chart =

        /// Uses points, line or both depending on the mode to represent 3d-data points
        [<Extension>]
        static member Scatter3D
            (
                x: seq<#IConvertible>,
                y: seq<#IConvertible>,
                z: seq<#IConvertible>,
                mode: StyleParam.Mode,
                [<Optional;DefaultParameterValue(null)>] ?Name               : string,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend         : bool,
                [<Optional;DefaultParameterValue(null)>] ?Opacity            : float,
                [<Optional;DefaultParameterValue(null)>] ?Text               : #IConvertible,
                [<Optional;DefaultParameterValue(null)>] ?MultiText          : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition       : StyleParam.TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?MultiTextPosition  : seq<StyleParam.TextPosition>,
                [<Optional;DefaultParameterValue(null)>] ?MarkerColor        : Color,
                [<Optional;DefaultParameterValue(null)>] ?MarkerColorScale   : StyleParam.Colorscale,
                [<Optional;DefaultParameterValue(null)>] ?MarkerOutline      : Line,
                [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol       : StyleParam.MarkerSymbol3D,
                [<Optional;DefaultParameterValue(null)>] ?MultiMarkerSymbol  : seq<StyleParam.MarkerSymbol3D>,
                [<Optional;DefaultParameterValue(null)>] ?Marker             : Marker,
                [<Optional;DefaultParameterValue(null)>] ?LineColor          : Color,
                [<Optional;DefaultParameterValue(null)>] ?LineColorScale     : StyleParam.Colorscale,
                [<Optional;DefaultParameterValue(null)>] ?LineWidth          : float,
                [<Optional;DefaultParameterValue(null)>] ?LineDash           : StyleParam.DrawingStyle,
                [<Optional;DefaultParameterValue(null)>] ?Line               : Line,
                [<Optional;DefaultParameterValue(null)>] ?Projection         : Projection,
                [<Optional;DefaultParameterValue(true)>] ?UseDefaults        : bool
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

                Trace3D.initScatter3D(
                    Trace3DStyle.Scatter3D(
                        X = x,
                        Y = y,
                        Z = z,
                        Mode = mode,
                        ?Name               = Name             ,
                        ?ShowLegend         = ShowLegend       ,
                        ?Opacity            = Opacity          ,
                        ?Text               = Text             ,
                        ?MultiText          = MultiText        ,
                        ?TextPosition       = TextPosition     ,
                        ?MultiTextPosition  = MultiTextPosition,
                        ?Projection         = Projection       ,
                        Marker              = marker           ,
                        Line                = line
                    )
                )
               
                |> GenericChart.ofTraceObject useDefaults
      

        /// Uses points, line or both depending on the mode to represent 3d-data points
        [<Extension>]
        static member Scatter3D
            (
                xyz: seq<#IConvertible * #IConvertible * #IConvertible>, 
                mode: StyleParam.Mode,
                [<Optional;DefaultParameterValue(null)>] ?Name               : string,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend         : bool,
                [<Optional;DefaultParameterValue(null)>] ?Opacity            : float,
                [<Optional;DefaultParameterValue(null)>] ?Text               : #IConvertible,
                [<Optional;DefaultParameterValue(null)>] ?MultiText          : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition       : StyleParam.TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?MultiTextPosition  : seq<StyleParam.TextPosition>,
                [<Optional;DefaultParameterValue(null)>] ?MarkerColor        : Color,
                [<Optional;DefaultParameterValue(null)>] ?MarkerColorScale   : StyleParam.Colorscale,
                [<Optional;DefaultParameterValue(null)>] ?MarkerOutline      : Line,
                [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol       : StyleParam.MarkerSymbol3D,
                [<Optional;DefaultParameterValue(null)>] ?MultiMarkerSymbol  : seq<StyleParam.MarkerSymbol3D>,
                [<Optional;DefaultParameterValue(null)>] ?Marker             : Marker,
                [<Optional;DefaultParameterValue(null)>] ?LineColor          : Color,
                [<Optional;DefaultParameterValue(null)>] ?LineColorScale     : StyleParam.Colorscale,
                [<Optional;DefaultParameterValue(null)>] ?LineWidth          : float,
                [<Optional;DefaultParameterValue(null)>] ?LineDash           : StyleParam.DrawingStyle,
                [<Optional;DefaultParameterValue(null)>] ?Line               : Line,
                [<Optional;DefaultParameterValue(null)>] ?Projection         : Projection,
                [<Optional;DefaultParameterValue(true)>] ?UseDefaults        : bool
            ) = 

                let useDefaults = defaultArg UseDefaults true
                let x,y,z = Seq.unzip3 xyz
                Chart.Scatter3D(
                    x, y, z, mode,
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
                    ?Projection         = Projection       ,
                    ?UseDefaults        = UseDefaults      
                ) 

        ///
        [<Extension>]
        static member Point3D
            (
                x: seq<#IConvertible>,
                y: seq<#IConvertible>,
                z: seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?Name               : string,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend         : bool,
                [<Optional;DefaultParameterValue(null)>] ?Opacity            : float,
                [<Optional;DefaultParameterValue(null)>] ?Text               : #IConvertible,
                [<Optional;DefaultParameterValue(null)>] ?MultiText          : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition       : StyleParam.TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?MultiTextPosition  : seq<StyleParam.TextPosition>,
                [<Optional;DefaultParameterValue(null)>] ?MarkerColor        : Color,
                [<Optional;DefaultParameterValue(null)>] ?MarkerColorScale   : StyleParam.Colorscale,
                [<Optional;DefaultParameterValue(null)>] ?MarkerOutline      : Line,
                [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol       : StyleParam.MarkerSymbol3D,
                [<Optional;DefaultParameterValue(null)>] ?MultiMarkerSymbol  : seq<StyleParam.MarkerSymbol3D>,
                [<Optional;DefaultParameterValue(null)>] ?Marker             : Marker,
                [<Optional;DefaultParameterValue(null)>] ?Projection         : Projection,
                [<Optional;DefaultParameterValue(true)>] ?UseDefaults        : bool
            ) = 

                // if text position or font is set, then show labels (not only when hovering)
                let changeMode = StyleParam.ModeUtils.showText (TextPosition.IsSome || MultiTextPosition.IsSome)

                Chart.Scatter3D(
                    x = x, 
                    y = y, 
                    z = z,
                    mode                = changeMode StyleParam.Mode.Markers,
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
                    ?Projection         = Projection       ,
                    ?UseDefaults        = UseDefaults      
                )
        
        ///
        [<Extension>]
        static member Point3D 
            (
               xyz: seq<#IConvertible * #IConvertible * #IConvertible>, 
               [<Optional;DefaultParameterValue(null)>] ?Name               : string,
               [<Optional;DefaultParameterValue(null)>] ?ShowLegend         : bool,
               [<Optional;DefaultParameterValue(null)>] ?Opacity            : float,
               [<Optional;DefaultParameterValue(null)>] ?Text               : #IConvertible,
               [<Optional;DefaultParameterValue(null)>] ?MultiText          : seq<#IConvertible>,
               [<Optional;DefaultParameterValue(null)>] ?TextPosition       : StyleParam.TextPosition,
               [<Optional;DefaultParameterValue(null)>] ?MultiTextPosition  : seq<StyleParam.TextPosition>,
               [<Optional;DefaultParameterValue(null)>] ?MarkerColor        : Color,
               [<Optional;DefaultParameterValue(null)>] ?MarkerColorScale   : StyleParam.Colorscale,
               [<Optional;DefaultParameterValue(null)>] ?MarkerOutline      : Line,
               [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol       : StyleParam.MarkerSymbol3D,
               [<Optional;DefaultParameterValue(null)>] ?MultiMarkerSymbol  : seq<StyleParam.MarkerSymbol3D>,
               [<Optional;DefaultParameterValue(null)>] ?Marker             : Marker,
               [<Optional;DefaultParameterValue(null)>] ?Projection         : Projection,
               [<Optional;DefaultParameterValue(true)>] ?UseDefaults        : bool
            ) = 

                let x, y, z = Seq.unzip3 xyz

                Chart.Point3D(
                    x, y, z,
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
                    ?Projection         = Projection       ,
                    ?UseDefaults        = UseDefaults      
                )


        /// Uses points, line or both depending on the mode to represent 3d-data points
        [<Extension>]
        static member Line3D
            (
                x: seq<#IConvertible>,
                y: seq<#IConvertible>,
                z: seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?ShowMarkers        : bool,
                [<Optional;DefaultParameterValue(null)>] ?Name               : string,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend         : bool,
                [<Optional;DefaultParameterValue(null)>] ?Opacity            : float,
                [<Optional;DefaultParameterValue(null)>] ?Text               : #IConvertible,
                [<Optional;DefaultParameterValue(null)>] ?MultiText          : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition       : StyleParam.TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?MultiTextPosition  : seq<StyleParam.TextPosition>,
                [<Optional;DefaultParameterValue(null)>] ?MarkerColor        : Color,
                [<Optional;DefaultParameterValue(null)>] ?MarkerColorScale   : StyleParam.Colorscale,
                [<Optional;DefaultParameterValue(null)>] ?MarkerOutline      : Line,
                [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol       : StyleParam.MarkerSymbol3D,
                [<Optional;DefaultParameterValue(null)>] ?MultiMarkerSymbol  : seq<StyleParam.MarkerSymbol3D>,
                [<Optional;DefaultParameterValue(null)>] ?Marker             : Marker,
                [<Optional;DefaultParameterValue(null)>] ?LineColor          : Color,
                [<Optional;DefaultParameterValue(null)>] ?LineColorScale     : StyleParam.Colorscale,
                [<Optional;DefaultParameterValue(null)>] ?LineWidth          : float,
                [<Optional;DefaultParameterValue(null)>] ?LineDash           : StyleParam.DrawingStyle,
                [<Optional;DefaultParameterValue(null)>] ?Line               : Line,
                [<Optional;DefaultParameterValue(null)>] ?Projection         : Projection,
                [<Optional;DefaultParameterValue(true)>] ?UseDefaults        : bool
            ) = 
                let changeMode = 
                    let isShowMarker =
                        match ShowMarkers with
                        | Some isShow -> isShow
                        | Option.None        -> false
                    StyleParam.ModeUtils.showText (TextPosition.IsSome || MultiTextPosition.IsSome)                       
                    >> StyleParam.ModeUtils.showMarker (isShowMarker)

                Chart.Scatter3D(
                    x = x,
                    y = y,
                    z = z,
                    mode = changeMode StyleParam.Mode.Lines,
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
                    ?Projection         = Projection       ,
                    ?UseDefaults        = UseDefaults      
                    
                )
        
        /// Uses points, line or both depending on the mode to represent 3D-data points
        [<Extension>]
        static member Line3D
            (
                xyz: seq<#IConvertible * #IConvertible * #IConvertible>, 
                [<Optional;DefaultParameterValue(null)>] ?ShowMarkers        : bool,
                [<Optional;DefaultParameterValue(null)>] ?Name               : string,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend         : bool,
                [<Optional;DefaultParameterValue(null)>] ?Opacity            : float,
                [<Optional;DefaultParameterValue(null)>] ?Text               : #IConvertible,
                [<Optional;DefaultParameterValue(null)>] ?MultiText          : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition       : StyleParam.TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?MultiTextPosition  : seq<StyleParam.TextPosition>,
                [<Optional;DefaultParameterValue(null)>] ?MarkerColor        : Color,
                [<Optional;DefaultParameterValue(null)>] ?MarkerColorScale   : StyleParam.Colorscale,
                [<Optional;DefaultParameterValue(null)>] ?MarkerOutline      : Line,
                [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol       : StyleParam.MarkerSymbol3D,
                [<Optional;DefaultParameterValue(null)>] ?MultiMarkerSymbol  : seq<StyleParam.MarkerSymbol3D>,
                [<Optional;DefaultParameterValue(null)>] ?Marker             : Marker,
                [<Optional;DefaultParameterValue(null)>] ?LineColor          : Color,
                [<Optional;DefaultParameterValue(null)>] ?LineColorScale     : StyleParam.Colorscale,
                [<Optional;DefaultParameterValue(null)>] ?LineWidth          : float,
                [<Optional;DefaultParameterValue(null)>] ?LineDash           : StyleParam.DrawingStyle,
                [<Optional;DefaultParameterValue(null)>] ?Line               : Line,
                [<Optional;DefaultParameterValue(null)>] ?Projection         : Projection,
                [<Optional;DefaultParameterValue(true)>] ?UseDefaults        : bool
            ) = 

                let x, y, z = Seq.unzip3 xyz

                Chart.Line3D(
                    x, y, z,
                    ?ShowMarkers        = ShowMarkers      ,
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
                    ?Projection         = Projection       ,
                    ?UseDefaults        = UseDefaults      
                )

        ///
        [<Extension>]
        static member Bubble3D 
            (
                x: seq<#IConvertible>,
                y: seq<#IConvertible>,
                z: seq<#IConvertible>,
                sizes: seq<int>,
                [<Optional;DefaultParameterValue(null)>] ?Name               : string,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend         : bool,
                [<Optional;DefaultParameterValue(null)>] ?Opacity            : float,
                [<Optional;DefaultParameterValue(null)>] ?Text               : #IConvertible,
                [<Optional;DefaultParameterValue(null)>] ?MultiText          : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition       : StyleParam.TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?MultiTextPosition  : seq<StyleParam.TextPosition>,
                [<Optional;DefaultParameterValue(null)>] ?MarkerColor        : Color,
                [<Optional;DefaultParameterValue(null)>] ?MarkerColorScale   : StyleParam.Colorscale,
                [<Optional;DefaultParameterValue(null)>] ?MarkerOutline      : Line,
                [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol       : StyleParam.MarkerSymbol3D,
                [<Optional;DefaultParameterValue(null)>] ?MultiMarkerSymbol  : seq<StyleParam.MarkerSymbol3D>,
                [<Optional;DefaultParameterValue(null)>] ?Marker             : Marker,
                [<Optional;DefaultParameterValue(null)>] ?Projection         : Projection,
                [<Optional;DefaultParameterValue(true)>] ?UseDefaults        : bool
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

                Trace3D.initScatter3D(
                    Trace3DStyle.Scatter3D(
                        X = x,
                        Y = y,
                        Z = z,
                        Mode = changeMode StyleParam.Mode.Markers,
                        ?Name               = Name             ,
                        ?ShowLegend         = ShowLegend       ,
                        ?Opacity            = Opacity          ,
                        ?Text               = Text             ,
                        ?MultiText          = MultiText        ,
                        ?TextPosition       = TextPosition     ,
                        ?MultiTextPosition  = MultiTextPosition,
                        ?Projection         = Projection       ,
                        Marker              = marker           
                    )
                )
               
                |> GenericChart.ofTraceObject useDefaults


    
        ///
        [<Extension>]
        static member Bubble3D 
            (
                xyz, sizes,
                [<Optional;DefaultParameterValue(null)>] ?Name               : string,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend         : bool,
                [<Optional;DefaultParameterValue(null)>] ?Opacity            : float,
                [<Optional;DefaultParameterValue(null)>] ?Text               : #IConvertible,
                [<Optional;DefaultParameterValue(null)>] ?MultiText          : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition       : StyleParam.TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?MultiTextPosition  : seq<StyleParam.TextPosition>,
                [<Optional;DefaultParameterValue(null)>] ?MarkerColor        : Color,
                [<Optional;DefaultParameterValue(null)>] ?MarkerColorScale   : StyleParam.Colorscale,
                [<Optional;DefaultParameterValue(null)>] ?MarkerOutline      : Line,
                [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol       : StyleParam.MarkerSymbol3D,
                [<Optional;DefaultParameterValue(null)>] ?MultiMarkerSymbol  : seq<StyleParam.MarkerSymbol3D>,
                [<Optional;DefaultParameterValue(null)>] ?Marker             : Marker,
                [<Optional;DefaultParameterValue(null)>] ?Projection         : Projection,
                [<Optional;DefaultParameterValue(true)>] ?UseDefaults        : bool
            ) = 

                let x, y, z = Seq.unzip3 xyz

                Chart.Bubble3D(
                    x, y, z, sizes,
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
                    ?Projection         = Projection       ,
                    ?UseDefaults        = UseDefaults      
                    
                )


        /// Uses points, line or both depending on the mode to represent 3D-data points
        [<Extension>]
        static member Surface
            (
                zData,
                [<Optional;DefaultParameterValue(null)>] ?X,
                [<Optional;DefaultParameterValue(null)>] ?Y,
                [<Optional;DefaultParameterValue(null)>] ?Name,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend,
                [<Optional;DefaultParameterValue(null)>] ?Opacity,
                [<Optional;DefaultParameterValue(null)>] ?Contours,
                [<Optional;DefaultParameterValue(null)>] ?ColorScale,
                [<Optional;DefaultParameterValue(null)>] ?ShowScale,
                [<Optional;DefaultParameterValue(null)>] ?ColorBar,
                [<Optional;DefaultParameterValue(true)>] ?UseDefaults : bool
            ) = 

                let useDefaults = defaultArg UseDefaults true

                Trace3D.initSurface (
                    Trace3DStyle.Surface(
                        ?X=X, 
                        ?Y=Y,
                        Z=zData,
                        ?Contours=Contours,
                        ?ColorScale=ColorScale,
                        ?ShowScale=ShowScale,
                        ?ColorBar=ColorBar 
                    )
                )              
                |> TraceStyle.TraceInfo(?Name=Name,?ShowLegend=ShowLegend,?Opacity=Opacity)
                |> GenericChart.ofTraceObject useDefaults


        /// Uses points, line or both depending on the mode to represent 3D-data points
        [<Extension>]
        static member Mesh3D
            (
                x, y, z, 
                [<Optional;DefaultParameterValue(null)>] ?I,
                [<Optional;DefaultParameterValue(null)>] ?J,
                [<Optional;DefaultParameterValue(null)>] ?K,
                [<Optional;DefaultParameterValue(null)>] ?Name,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend,
                [<Optional;DefaultParameterValue(null)>] ?Opacity,
                [<Optional;DefaultParameterValue(null)>] ?Color,
                [<Optional;DefaultParameterValue(null)>] ?Contour,
                [<Optional;DefaultParameterValue(null)>] ?ColorScale,
                [<Optional;DefaultParameterValue(null)>] ?ShowScale,
                [<Optional;DefaultParameterValue(null)>] ?ColorBar,
                [<Optional;DefaultParameterValue(true)>] ?UseDefaults : bool
            ) = 

                let useDefaults = defaultArg UseDefaults true

                Trace3D.initMesh3D (
                    Trace3DStyle.Mesh3D(
                        X   = x,
                        Y   = y,
                        Z   = z,
                        ?I  = I,
                        ?J  = J,
                        ?K  = K,
                        ?Color = Color,
                        ?Contour = Contour,
                        ?ColorScale  = ColorScale,
                        ?ShowScale   = ShowScale,
                        ?ColorBar    = ColorBar
                    ) 
                )              
                |> TraceStyle.TraceInfo(?Name=Name,?ShowLegend=ShowLegend,?Opacity=Opacity)
                |> GenericChart.ofTraceObject useDefaults

        [<Extension>]
        static member Cone 
            (
                x, y, z, u, v, w,
                [<Optional;DefaultParameterValue(null)>] ?Name,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend,
                [<Optional;DefaultParameterValue(null)>] ?Opacity,
                [<Optional;DefaultParameterValue(null)>] ?ColorScale,
                [<Optional;DefaultParameterValue(null)>] ?ShowScale,
                [<Optional;DefaultParameterValue(null)>] ?ColorBar,
                [<Optional;DefaultParameterValue(true)>] ?UseDefaults : bool
            ) = 

                let useDefaults = defaultArg UseDefaults true

                Trace3D.initCone(
                    Trace3DStyle.Cone(
                        X = x,
                        Y = y,
                        Z = z,
                        U = u,
                        V = v,
                        W = w,
                        ?Name       = Name,
                        ?ShowLegend = ShowLegend,
                        ?Opacity    = Opacity,
                        ?ColorScale = ColorScale,
                        ?ShowScale  = ShowScale,
                        ?ColorBar   = ColorBar
                    )
                )
                |> TraceStyle.TraceInfo(?Name=Name,?ShowLegend=ShowLegend,?Opacity=Opacity)
                |> GenericChart.ofTraceObject useDefaults

        [<Extension>]
        static member Cone 
            (
                coneXYZ, coneUVW,
                [<Optional;DefaultParameterValue(null)>] ?Name,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend,
                [<Optional;DefaultParameterValue(null)>] ?Opacity,
                [<Optional;DefaultParameterValue(null)>] ?ColorScale,
                [<Optional;DefaultParameterValue(null)>] ?ShowScale,
                [<Optional;DefaultParameterValue(null)>] ?ColorBar,
                [<Optional;DefaultParameterValue(true)>] ?UseDefaults : bool
            ) = 

                let useDefaults = defaultArg UseDefaults true
                let x, y, z = Seq.unzip3 coneXYZ
                let u, v, w = Seq.unzip3 coneUVW

                Chart.Cone(
                    x, y, z, u, v, w,
                    ?Name       = Name          ,
                    ?ShowLegend = ShowLegend    ,
                    ?Opacity    = Opacity       ,
                    ?ColorScale = ColorScale    ,
                    ?ShowScale  = ShowScale     ,
                    ?ColorBar   = ColorBar      ,
                    ?UseDefaults= UseDefaults
                )


        [<Extension>]
        static member StreamTube 
            (
                x, y, z, u, v, w,
                [<Optional;DefaultParameterValue(null)>] ?Name,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend,
                [<Optional;DefaultParameterValue(null)>] ?Opacity,
                [<Optional;DefaultParameterValue(null)>] ?ColorScale,
                [<Optional;DefaultParameterValue(null)>] ?ShowScale,
                [<Optional;DefaultParameterValue(null)>] ?ColorBar,
                [<Optional;DefaultParameterValue(null)>] ?MaxDisplayed: int,
                [<Optional;DefaultParameterValue(null)>] ?Starts: StreamTubeStarts,
                [<Optional;DefaultParameterValue(true)>] ?UseDefaults : bool
            ) = 

                let useDefaults = defaultArg UseDefaults true

                Trace3D.initStreamTube(
                    Trace3DStyle.StreamTube(
                        X = x,
                        Y = y,
                        Z = z,
                        U = u,
                        V = v,
                        W = w,
                        ?Name           = Name,
                        ?ShowLegend     = ShowLegend,
                        ?Opacity        = Opacity,
                        ?ColorScale     = ColorScale,
                        ?ShowScale      = ShowScale,
                        ?ColorBar       = ColorBar,
                        ?MaxDisplayed   = MaxDisplayed,
                        ?Starts         = Starts
                    )
                )
                |> TraceStyle.TraceInfo(?Name=Name,?ShowLegend=ShowLegend,?Opacity=Opacity)
                |> GenericChart.ofTraceObject useDefaults


        [<Extension>]
        static member StreamTube 
            (
                streamTubeXYZ, streamTubeUVW,
                [<Optional;DefaultParameterValue(null)>] ?Name,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend,
                [<Optional;DefaultParameterValue(null)>] ?Opacity,
                [<Optional;DefaultParameterValue(null)>] ?ColorScale,
                [<Optional;DefaultParameterValue(null)>] ?ShowScale,
                [<Optional;DefaultParameterValue(null)>] ?ColorBar,
                [<Optional;DefaultParameterValue(null)>] ?MaxDisplayed: int,
                [<Optional;DefaultParameterValue(null)>] ?Starts: StreamTubeStarts,
                [<Optional;DefaultParameterValue(true)>] ?UseDefaults : bool
            ) = 

                let useDefaults = defaultArg UseDefaults true
                let x, y, z = Seq.unzip3 streamTubeXYZ
                let u, v, w = Seq.unzip3 streamTubeUVW

                Chart.StreamTube(
                    x, y, z, u, v, w,
                    ?Name           = Name          ,
                    ?ShowLegend     = ShowLegend    ,
                    ?Opacity        = Opacity       ,
                    ?ColorScale     = ColorScale    ,
                    ?ShowScale      = ShowScale     ,
                    ?ColorBar       = ColorBar      ,
                    ?MaxDisplayed   = MaxDisplayed  ,
                    ?Starts         = Starts        ,
                    ?UseDefaults    = UseDefaults
                )
        
        
        [<Extension>]
        static member Volume 
            (
                x,y,z,value,
                [<Optional;DefaultParameterValue(null)>] ?Name,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend,
                [<Optional;DefaultParameterValue(null)>] ?Opacity,
                [<Optional;DefaultParameterValue(null)>] ?ColorScale,
                [<Optional;DefaultParameterValue(null)>] ?ShowScale,
                [<Optional;DefaultParameterValue(null)>] ?ColorBar,
                [<Optional;DefaultParameterValue(null)>] ?IsoMin,
                [<Optional;DefaultParameterValue(null)>] ?IsoMax,
                [<Optional;DefaultParameterValue(null)>] ?Caps : Caps,
                [<Optional;DefaultParameterValue(null)>] ?Slices : Slices,
                [<Optional;DefaultParameterValue(null)>] ?Surface : Surface,
                [<Optional;DefaultParameterValue(true)>] ?UseDefaults : bool
            ) = 

                let useDefaults = defaultArg UseDefaults true
                Trace3D.initVolume(
                    Trace3DStyle.Volume(
                        X = x,
                        Y = y,
                        Z = z,
                        Value = value,
                        ?Name           = Name,
                        ?ShowLegend     = ShowLegend,
                        ?Opacity        = Opacity,
                        ?ColorScale     = ColorScale,
                        ?ShowScale      = ShowScale,
                        ?ColorBar       = ColorBar,
                        ?IsoMin         = IsoMin,
                        ?IsoMax         = IsoMax,
                        ?Caps           = Caps,
                        ?Slices         = Slices,
                        ?Surface        = Surface   
                    )
                )
                |> TraceStyle.TraceInfo(?Name=Name,?ShowLegend=ShowLegend,?Opacity=Opacity)
                |> GenericChart.ofTraceObject useDefaults

                
        [<Extension>]
        static member IsoSurface 
            (
                x,y,z,value,
                [<Optional;DefaultParameterValue(null)>] ?Name,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend,
                [<Optional;DefaultParameterValue(null)>] ?Opacity,
                [<Optional;DefaultParameterValue(null)>] ?ColorScale,
                [<Optional;DefaultParameterValue(null)>] ?ShowScale,
                [<Optional;DefaultParameterValue(null)>] ?ColorBar,
                [<Optional;DefaultParameterValue(null)>] ?IsoMin,
                [<Optional;DefaultParameterValue(null)>] ?IsoMax,
                [<Optional;DefaultParameterValue(null)>] ?Caps : Caps,
                [<Optional;DefaultParameterValue(null)>] ?Slices : Slices,
                [<Optional;DefaultParameterValue(null)>] ?Surface : Surface,
                [<Optional;DefaultParameterValue(true)>] ?UseDefaults : bool
            ) = 

                let useDefaults = defaultArg UseDefaults true
                Trace3D.initIsoSurface(
                    Trace3DStyle.IsoSurface(
                        X = x,
                        Y = y,
                        Z = z,
                        Value = value,
                        ?Name           = Name,
                        ?ShowLegend     = ShowLegend,
                        ?Opacity        = Opacity,
                        ?ColorScale     = ColorScale,
                        ?ShowScale      = ShowScale,
                        ?ColorBar       = ColorBar,
                        ?IsoMin         = IsoMin,
                        ?IsoMax         = IsoMax,
                        ?Caps           = Caps,
                        ?Slices         = Slices,
                        ?Surface        = Surface   
                    )
                )
                |> TraceStyle.TraceInfo(?Name=Name,?ShowLegend=ShowLegend,?Opacity=Opacity)
                |> GenericChart.ofTraceObject useDefaults
        