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
module ChartMap =

    [<Extension>]
    type Chart =

        /// Computes the choropleth map plot
        [<Extension>]
        static member ChoroplethMap
            (
                locations,z,
                [<Optional;DefaultParameterValue(null)>] ?Text,
                [<Optional;DefaultParameterValue(null)>] ?Locationmode,
                [<Optional;DefaultParameterValue(null)>] ?Autocolorscale,
                [<Optional;DefaultParameterValue(null)>] ?Colorscale,
                [<Optional;DefaultParameterValue(null)>] ?ColorBar,
                [<Optional;DefaultParameterValue(null)>] ?Marker,
                [<Optional;DefaultParameterValue(null)>] ?GeoJson,
                [<Optional;DefaultParameterValue(null)>] ?FeatureIdKey: string,
                [<Optional;DefaultParameterValue(null)>] ?Zmin,
                [<Optional;DefaultParameterValue(null)>] ?Zmax,
                [<Optional;DefaultParameterValue(true)>] ?UseDefaults : bool
            ) = 

                let useDefaults = defaultArg UseDefaults true

                TraceGeo.initChoroplethMap (
                    TraceGeoStyle.ChoroplethMap(
                        Locations=locations,
                        Z=z,
                        ?Text=Text,
                        ?Locationmode=Locationmode,
                        ?Autocolorscale=Autocolorscale,
                        ?Colorscale=Colorscale,
                        ?ColorBar=ColorBar,
                        ?Marker=Marker,
                        ?Zmin=Zmin,
                        ?Zmax=Zmax,
                        ?GeoJson=GeoJson,
                        ?FeatureIdKey=FeatureIdKey
                    )              
                )
                |> GenericChart.ofTraceObject useDefaults


        /// Creates a ScatterGeo chart, where data is visualized on a geographic map.
        /// ScatterGeo charts are the basis of GeoPoint, GeoLine, and GeoBubble Charts, and can be customized as such. We also provide abstractions for those: Chart.GeoPoint, Chart.GeoLine, Chart.GeoBubble
        [<Extension>]
        static member ScatterGeo
            (
                longitudes: seq<#IConvertible>, 
                latitudes: seq<#IConvertible>, 
                mode: StyleParam.Mode,
                [<Optional;DefaultParameterValue(null)>] ?Name              : string,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend        : bool,
                [<Optional;DefaultParameterValue(null)>] ?Opacity           : float,
                [<Optional;DefaultParameterValue(null)>] ?MultiOpacity      : seq<float>,
                [<Optional;DefaultParameterValue(null)>] ?Text              : #IConvertible,
                [<Optional;DefaultParameterValue(null)>] ?MultiText         : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition      : StyleParam.TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?MultiTextPosition : seq<StyleParam.TextPosition>,
                [<Optional;DefaultParameterValue(null)>] ?MarkerColor       : Color,
                [<Optional;DefaultParameterValue(null)>] ?MarkerColorScale  : StyleParam.Colorscale,
                [<Optional;DefaultParameterValue(null)>] ?MarkerOutline     : Line,
                [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol      : StyleParam.MarkerSymbol,
                [<Optional;DefaultParameterValue(null)>] ?MultiMarkerSymbol : seq<StyleParam.MarkerSymbol>,
                [<Optional;DefaultParameterValue(null)>] ?Marker            : Marker,
                [<Optional;DefaultParameterValue(null)>] ?LineColor         : Color,
                [<Optional;DefaultParameterValue(null)>] ?LineColorScale    : StyleParam.Colorscale,
                [<Optional;DefaultParameterValue(null)>] ?LineWidth         : float,
                [<Optional;DefaultParameterValue(null)>] ?LineDash          : StyleParam.DrawingStyle,
                [<Optional;DefaultParameterValue(null)>] ?Line              : Line,
                [<Optional;DefaultParameterValue(null)>] ?LocationMode      : StyleParam.LocationFormat,
                [<Optional;DefaultParameterValue(null)>] ?GeoJson           : obj                  ,
                [<Optional;DefaultParameterValue(null)>] ?FeatureIdKey      : string          ,
                [<Optional;DefaultParameterValue(true)>] ?UseDefaults       : bool
            ) = 
 
                let useDefaults = defaultArg UseDefaults true

                let marker =
                    Marker 
                    |> Option.defaultValue (TraceObjects.Marker.init())
                    |> TraceObjects.Marker.style(
                        ?Color          = MarkerColor,
                        ?Outline        = MarkerOutline,
                        ?Symbol         = MarkerSymbol,
                        ?MultiSymbol    = MultiMarkerSymbol,
                        ?Colorscale     = MarkerColorScale,
                        ?MultiOpacity   = MultiOpacity
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


                TraceGeo.initScatterGeo(
                    TraceGeoStyle.ScatterGeo(
                        Lon                 = longitudes,
                        Lat                 = latitudes,
                        Mode                = mode,
                        Marker              = marker,
                        Line                = line,
                        ?Name               = Name             ,
                        ?ShowLegend         = ShowLegend       ,
                        ?Opacity            = Opacity          ,
                        ?Text               = Text             ,
                        ?MultiText          = MultiText        ,
                        ?TextPosition       = TextPosition     ,
                        ?MultiTextPosition  = MultiTextPosition,
                        ?LocationMode       = LocationMode ,
                        ?GeoJson            = GeoJson      ,
                        ?FeatureIdKey       = FeatureIdKey 
                        
                    )               
                )

                |> GenericChart.ofTraceObject useDefaults


        /// Creates a ScatterGeo chart, where data is visualized on a geographic map.
        /// ScatterGeo charts are the basis of GeoPoint, GeoLine, and GeoBubble Charts, and can be customized as such. We also provide abstractions for those: Chart.GeoPoint, Chart.GeoLine, Chart.GeoBubble
        
        [<Extension>]
        static member ScatterGeo
            (
                lonlat: seq<#IConvertible * #IConvertible>, 
                mode: StyleParam.Mode,
                [<Optional;DefaultParameterValue(null)>] ?Name              : string,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend        : bool,
                [<Optional;DefaultParameterValue(null)>] ?Opacity           : float,
                [<Optional;DefaultParameterValue(null)>] ?MultiOpacity      : seq<float>,
                [<Optional;DefaultParameterValue(null)>] ?Text              : #IConvertible,
                [<Optional;DefaultParameterValue(null)>] ?MultiText         : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition      : StyleParam.TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?MultiTextPosition : seq<StyleParam.TextPosition>,
                [<Optional;DefaultParameterValue(null)>] ?MarkerColor       : Color,
                [<Optional;DefaultParameterValue(null)>] ?MarkerColorScale  : StyleParam.Colorscale,
                [<Optional;DefaultParameterValue(null)>] ?MarkerOutline     : Line,
                [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol      : StyleParam.MarkerSymbol,
                [<Optional;DefaultParameterValue(null)>] ?MultiMarkerSymbol : seq<StyleParam.MarkerSymbol>,
                [<Optional;DefaultParameterValue(null)>] ?Marker            : Marker,
                [<Optional;DefaultParameterValue(null)>] ?LineColor         : Color,
                [<Optional;DefaultParameterValue(null)>] ?LineColorScale    : StyleParam.Colorscale,
                [<Optional;DefaultParameterValue(null)>] ?LineWidth         : float,
                [<Optional;DefaultParameterValue(null)>] ?LineDash          : StyleParam.DrawingStyle,
                [<Optional;DefaultParameterValue(null)>] ?Line              : Line,
                [<Optional;DefaultParameterValue(null)>] ?LocationMode      : StyleParam.LocationFormat,
                [<Optional;DefaultParameterValue(null)>] ?GeoJson           : obj                  ,
                [<Optional;DefaultParameterValue(null)>] ?FeatureIdKey      : string          ,
                [<Optional;DefaultParameterValue(true)>] ?UseDefaults       : bool
            ) = 

                let longitudes, latitudes = Seq.unzip lonlat

                Chart.ScatterGeo(
                    longitudes, latitudes, mode,
                    ?Name               = Name              ,
                    ?ShowLegend         = ShowLegend        ,
                    ?Opacity            = Opacity           ,
                    ?MultiOpacity       = MultiOpacity      ,
                    ?Text               = Text              ,
                    ?MultiText          = MultiText         ,
                    ?TextPosition       = TextPosition      ,
                    ?MultiTextPosition  = MultiTextPosition ,
                    ?MarkerColor        = MarkerColor       ,
                    ?MarkerColorScale   = MarkerColorScale  ,
                    ?MarkerOutline      = MarkerOutline     ,
                    ?MarkerSymbol       = MarkerSymbol      ,
                    ?MultiMarkerSymbol  = MultiMarkerSymbol ,
                    ?Marker             = Marker            ,
                    ?LineColor          = LineColor         ,
                    ?LineColorScale     = LineColorScale    ,
                    ?LineWidth          = LineWidth         ,
                    ?LineDash           = LineDash          ,
                    ?Line               = Line              ,
                    ?LocationMode       = LocationMode      ,
                    ?GeoJson            = GeoJson           ,
                    ?FeatureIdKey       = FeatureIdKey      ,
                    ?UseDefaults        = UseDefaults       
                )

        /// Creates a ScatterGeo chart, where data is visualized on a geographic map.
        /// ScatterGeo charts are the basis of GeoPoint, GeoLine, and GeoBubble Charts, and can be customized as such. We also provide abstractions for those: Chart.GeoPoint, Chart.GeoLine, Chart.GeoBubble
        [<Extension>]
        static member ScatterGeo
            (
                locations: seq<string>, 
                mode: StyleParam.Mode,
                [<Optional;DefaultParameterValue(null)>] ?Name              : string,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend        : bool,
                [<Optional;DefaultParameterValue(null)>] ?Opacity           : float,
                [<Optional;DefaultParameterValue(null)>] ?MultiOpacity      : seq<float>,
                [<Optional;DefaultParameterValue(null)>] ?Text              : #IConvertible,
                [<Optional;DefaultParameterValue(null)>] ?MultiText         : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition      : StyleParam.TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?MultiTextPosition : seq<StyleParam.TextPosition>,
                [<Optional;DefaultParameterValue(null)>] ?MarkerColor       : Color,
                [<Optional;DefaultParameterValue(null)>] ?MarkerColorScale  : StyleParam.Colorscale,
                [<Optional;DefaultParameterValue(null)>] ?MarkerOutline     : Line,
                [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol      : StyleParam.MarkerSymbol,
                [<Optional;DefaultParameterValue(null)>] ?MultiMarkerSymbol : seq<StyleParam.MarkerSymbol>,
                [<Optional;DefaultParameterValue(null)>] ?Marker            : Marker,
                [<Optional;DefaultParameterValue(null)>] ?LineColor         : Color,
                [<Optional;DefaultParameterValue(null)>] ?LineColorScale    : StyleParam.Colorscale,
                [<Optional;DefaultParameterValue(null)>] ?LineWidth         : float,
                [<Optional;DefaultParameterValue(null)>] ?LineDash          : StyleParam.DrawingStyle,
                [<Optional;DefaultParameterValue(null)>] ?Line              : Line,
                [<Optional;DefaultParameterValue(null)>] ?LocationMode      : StyleParam.LocationFormat,
                [<Optional;DefaultParameterValue(null)>] ?GeoJson           : obj                  ,
                [<Optional;DefaultParameterValue(null)>] ?FeatureIdKey      : string          ,
                [<Optional;DefaultParameterValue(true)>] ?UseDefaults       : bool
            ) = 

                let useDefaults = defaultArg UseDefaults true
                
                let marker =
                    Marker 
                    |> Option.defaultValue (TraceObjects.Marker.init())
                    |> TraceObjects.Marker.style(
                        ?Color          = MarkerColor,
                        ?Outline        = MarkerOutline,
                        ?Symbol         = MarkerSymbol,
                        ?MultiSymbol    = MultiMarkerSymbol,
                        ?Colorscale     = MarkerColorScale,
                        ?MultiOpacity   = MultiOpacity
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
                
                
                TraceGeo.initScatterGeo(
                    TraceGeoStyle.ScatterGeo(
                        Locations           = locations,
                        Mode                = mode,
                        Marker              = marker,
                        Line                = line,
                        ?Name               = Name             ,
                        ?ShowLegend         = ShowLegend       ,
                        ?Opacity            = Opacity          ,
                        ?Text               = Text             ,
                        ?MultiText          = MultiText        ,
                        ?TextPosition       = TextPosition     ,
                        ?MultiTextPosition  = MultiTextPosition,
                        ?LocationMode       = LocationMode ,
                        ?GeoJson            = GeoJson      ,
                        ?FeatureIdKey       = FeatureIdKey 
                                        
                    )               
                )
                
                |> GenericChart.ofTraceObject useDefaults

        /// Creates a PointGeo chart, where data is visualized as points on a geographic map.
        [<Extension>]
        static member PointGeo
            (
                longitudes  : seq<#IConvertible>, 
                latitudes   : seq<#IConvertible>, 
                [<Optional;DefaultParameterValue(null)>] ?Name              : string,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend        : bool,
                [<Optional;DefaultParameterValue(null)>] ?Opacity           : float,
                [<Optional;DefaultParameterValue(null)>] ?MultiOpacity      : seq<float>,
                [<Optional;DefaultParameterValue(null)>] ?Text              : #IConvertible,
                [<Optional;DefaultParameterValue(null)>] ?MultiText         : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition      : StyleParam.TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?MultiTextPosition : seq<StyleParam.TextPosition>,
                [<Optional;DefaultParameterValue(null)>] ?MarkerColor       : Color,
                [<Optional;DefaultParameterValue(null)>] ?MarkerColorScale  : StyleParam.Colorscale,
                [<Optional;DefaultParameterValue(null)>] ?MarkerOutline     : Line,
                [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol      : StyleParam.MarkerSymbol,
                [<Optional;DefaultParameterValue(null)>] ?MultiMarkerSymbol : seq<StyleParam.MarkerSymbol>,
                [<Optional;DefaultParameterValue(null)>] ?Marker            : Marker,
                [<Optional;DefaultParameterValue(null)>] ?LocationMode      : StyleParam.LocationFormat,
                [<Optional;DefaultParameterValue(null)>] ?GeoJson           : obj                  ,
                [<Optional;DefaultParameterValue(null)>] ?FeatureIdKey      : string          ,
                [<Optional;DefaultParameterValue(true)>] ?UseDefaults       : bool
            ) = 

                let changeMode = StyleParam.ModeUtils.showText (TextPosition.IsSome || MultiTextPosition.IsSome)

                Chart.ScatterGeo(
                    longitudes, latitudes,
                    mode = changeMode StyleParam.Mode.Markers,
                    ?Name               = Name             ,
                    ?ShowLegend         = ShowLegend       ,
                    ?Opacity            = Opacity          ,
                    ?MultiOpacity       = MultiOpacity     ,
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
                    ?LocationMode       = LocationMode     ,
                    ?GeoJson            = GeoJson          ,
                    ?FeatureIdKey       = FeatureIdKey     ,
                    ?UseDefaults        = UseDefaults      

                )

        /// Creates a PointGeo chart, where data is visualized as points on a geographic map.
        [<Extension>]
        static member PointGeo
            (
                lonlat: seq<#IConvertible * #IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?Name              : string,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend        : bool,
                [<Optional;DefaultParameterValue(null)>] ?Opacity           : float,
                [<Optional;DefaultParameterValue(null)>] ?MultiOpacity      : seq<float>,
                [<Optional;DefaultParameterValue(null)>] ?Text              : #IConvertible,
                [<Optional;DefaultParameterValue(null)>] ?MultiText         : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition      : StyleParam.TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?MultiTextPosition : seq<StyleParam.TextPosition>,
                [<Optional;DefaultParameterValue(null)>] ?MarkerColor       : Color,
                [<Optional;DefaultParameterValue(null)>] ?MarkerColorScale  : StyleParam.Colorscale,
                [<Optional;DefaultParameterValue(null)>] ?MarkerOutline     : Line,
                [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol      : StyleParam.MarkerSymbol,
                [<Optional;DefaultParameterValue(null)>] ?MultiMarkerSymbol : seq<StyleParam.MarkerSymbol>,
                [<Optional;DefaultParameterValue(null)>] ?Marker            : Marker,
                [<Optional;DefaultParameterValue(null)>] ?LocationMode      : StyleParam.LocationFormat,
                [<Optional;DefaultParameterValue(null)>] ?GeoJson           : obj                  ,
                [<Optional;DefaultParameterValue(null)>] ?FeatureIdKey      : string          ,
                [<Optional;DefaultParameterValue(true)>] ?UseDefaults       : bool
            ) = 

                let longitudes, latitudes = Seq.unzip lonlat

                Chart.PointGeo(
                    longitudes, latitudes,
                    ?Name               = Name             ,
                    ?ShowLegend         = ShowLegend       ,
                    ?Opacity            = Opacity          ,
                    ?MultiOpacity       = MultiOpacity     ,
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
                    ?LocationMode       = LocationMode     ,
                    ?GeoJson            = GeoJson          ,
                    ?FeatureIdKey       = FeatureIdKey     ,
                    ?UseDefaults        = UseDefaults      
                )

        /// Creates a PointGeo chart, where data is visualized as points on a geographic map.
        [<Extension>]
        static member PointGeo
            (
                locations: seq<string>, 
                [<Optional;DefaultParameterValue(null)>] ?Name              : string,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend        : bool,
                [<Optional;DefaultParameterValue(null)>] ?Opacity           : float,
                [<Optional;DefaultParameterValue(null)>] ?MultiOpacity      : seq<float>,
                [<Optional;DefaultParameterValue(null)>] ?Text              : #IConvertible,
                [<Optional;DefaultParameterValue(null)>] ?MultiText         : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition      : StyleParam.TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?MultiTextPosition : seq<StyleParam.TextPosition>,
                [<Optional;DefaultParameterValue(null)>] ?MarkerColor       : Color,
                [<Optional;DefaultParameterValue(null)>] ?MarkerColorScale  : StyleParam.Colorscale,
                [<Optional;DefaultParameterValue(null)>] ?MarkerOutline     : Line,
                [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol      : StyleParam.MarkerSymbol,
                [<Optional;DefaultParameterValue(null)>] ?MultiMarkerSymbol : seq<StyleParam.MarkerSymbol>,
                [<Optional;DefaultParameterValue(null)>] ?Marker            : Marker,
                [<Optional;DefaultParameterValue(null)>] ?LocationMode      : StyleParam.LocationFormat,
                [<Optional;DefaultParameterValue(null)>] ?GeoJson           : obj                  ,
                [<Optional;DefaultParameterValue(null)>] ?FeatureIdKey      : string          ,
                [<Optional;DefaultParameterValue(true)>] ?UseDefaults       : bool
            ) = 
                let changeMode = StyleParam.ModeUtils.showText (TextPosition.IsSome || MultiTextPosition.IsSome)

                Chart.ScatterGeo(
                    locations,
                    mode = changeMode StyleParam.Mode.Markers,
                    ?Name               = Name             ,
                    ?ShowLegend         = ShowLegend       ,
                    ?Opacity            = Opacity          ,
                    ?MultiOpacity       = MultiOpacity     ,
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
                    ?LocationMode       = LocationMode     ,
                    ?GeoJson            = GeoJson          ,
                    ?FeatureIdKey       = FeatureIdKey     ,
                    ?UseDefaults        = UseDefaults      
                )

        /// Creates a LineGeo chart, where data is visualized as coordinates connected via lines on a geographic map.
        [<Extension>]
        static member LineGeo
            (
                longitudes: seq<#IConvertible>, 
                latitudes: seq<#IConvertible>, 
                [<Optional;DefaultParameterValue(null)>] ?ShowMarkers       : bool,
                [<Optional;DefaultParameterValue(null)>] ?Name              : string,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend        : bool,
                [<Optional;DefaultParameterValue(null)>] ?Opacity           : float,
                [<Optional;DefaultParameterValue(null)>] ?MultiOpacity      : seq<float>,
                [<Optional;DefaultParameterValue(null)>] ?Text              : #IConvertible,
                [<Optional;DefaultParameterValue(null)>] ?MultiText         : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition      : StyleParam.TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?MultiTextPosition : seq<StyleParam.TextPosition>,
                [<Optional;DefaultParameterValue(null)>] ?MarkerColor       : Color,
                [<Optional;DefaultParameterValue(null)>] ?MarkerColorScale  : StyleParam.Colorscale,
                [<Optional;DefaultParameterValue(null)>] ?MarkerOutline     : Line,
                [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol      : StyleParam.MarkerSymbol,
                [<Optional;DefaultParameterValue(null)>] ?MultiMarkerSymbol : seq<StyleParam.MarkerSymbol>,
                [<Optional;DefaultParameterValue(null)>] ?Marker            : Marker,
                [<Optional;DefaultParameterValue(null)>] ?LineColor         : Color,
                [<Optional;DefaultParameterValue(null)>] ?LineColorScale    : StyleParam.Colorscale,
                [<Optional;DefaultParameterValue(null)>] ?LineWidth         : float,
                [<Optional;DefaultParameterValue(null)>] ?LineDash          : StyleParam.DrawingStyle,
                [<Optional;DefaultParameterValue(null)>] ?Line              : Line,
                [<Optional;DefaultParameterValue(null)>] ?LocationMode      : StyleParam.LocationFormat,
                [<Optional;DefaultParameterValue(null)>] ?GeoJson           : obj                  ,
                [<Optional;DefaultParameterValue(null)>] ?FeatureIdKey      : string          ,
                [<Optional;DefaultParameterValue(true)>] ?UseDefaults       : bool
            ) = 

                let changeMode = 
                    let isShowMarker =
                        match ShowMarkers with
                        | Some isShow -> isShow
                        | Option.None        -> false
                    StyleParam.ModeUtils.showText (TextPosition.IsSome || MultiTextPosition.IsSome)                       
                    >> StyleParam.ModeUtils.showMarker (isShowMarker)

                Chart.ScatterGeo(
                    longitudes, latitudes,
                    mode = changeMode StyleParam.Mode.Lines,
                    ?Name               = Name             ,
                    ?ShowLegend         = ShowLegend       ,
                    ?Opacity            = Opacity          ,
                    ?MultiOpacity       = MultiOpacity     ,
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
                    ?LocationMode       = LocationMode     ,
                    ?GeoJson            = GeoJson          ,
                    ?FeatureIdKey       = FeatureIdKey     ,
                    ?UseDefaults        = UseDefaults      
                )

        /// Creates a LineGeo chart, where data is visualized as coordinates connected via lines on a geographic map.
        [<Extension>]
        static member LineGeo
            (
                lonlat: seq<#IConvertible * #IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?ShowMarkers       : bool,
                [<Optional;DefaultParameterValue(null)>] ?Name              : string,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend        : bool,
                [<Optional;DefaultParameterValue(null)>] ?Opacity           : float,
                [<Optional;DefaultParameterValue(null)>] ?MultiOpacity      : seq<float>,
                [<Optional;DefaultParameterValue(null)>] ?Text              : #IConvertible,
                [<Optional;DefaultParameterValue(null)>] ?MultiText         : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition      : StyleParam.TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?MultiTextPosition : seq<StyleParam.TextPosition>,
                [<Optional;DefaultParameterValue(null)>] ?MarkerColor       : Color,
                [<Optional;DefaultParameterValue(null)>] ?MarkerColorScale  : StyleParam.Colorscale,
                [<Optional;DefaultParameterValue(null)>] ?MarkerOutline     : Line,
                [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol      : StyleParam.MarkerSymbol,
                [<Optional;DefaultParameterValue(null)>] ?MultiMarkerSymbol : seq<StyleParam.MarkerSymbol>,
                [<Optional;DefaultParameterValue(null)>] ?Marker            : Marker,
                [<Optional;DefaultParameterValue(null)>] ?LineColor         : Color,
                [<Optional;DefaultParameterValue(null)>] ?LineColorScale    : StyleParam.Colorscale,
                [<Optional;DefaultParameterValue(null)>] ?LineWidth         : float,
                [<Optional;DefaultParameterValue(null)>] ?LineDash          : StyleParam.DrawingStyle,
                [<Optional;DefaultParameterValue(null)>] ?Line              : Line,
                [<Optional;DefaultParameterValue(null)>] ?LocationMode      : StyleParam.LocationFormat,
                [<Optional;DefaultParameterValue(null)>] ?GeoJson           : obj                  ,
                [<Optional;DefaultParameterValue(null)>] ?FeatureIdKey      : string          ,
                [<Optional;DefaultParameterValue(true)>] ?UseDefaults       : bool
            ) = 

                let longitudes, latitudes = Seq.unzip lonlat
                
                Chart.LineGeo(
                    longitudes, latitudes,
                    ?ShowMarkers        = ShowMarkers       ,
                    ?Name               = Name              ,
                    ?ShowLegend         = ShowLegend        ,
                    ?Opacity            = Opacity           ,
                    ?MultiOpacity       = MultiOpacity      ,
                    ?Text               = Text              ,
                    ?MultiText          = MultiText         ,
                    ?TextPosition       = TextPosition      ,
                    ?MultiTextPosition  = MultiTextPosition ,
                    ?MarkerColor        = MarkerColor       ,
                    ?MarkerColorScale   = MarkerColorScale  ,
                    ?MarkerOutline      = MarkerOutline     ,
                    ?MarkerSymbol       = MarkerSymbol      ,
                    ?MultiMarkerSymbol  = MultiMarkerSymbol ,
                    ?Marker             = Marker            ,
                    ?LineColor          = LineColor         ,
                    ?LineColorScale     = LineColorScale    ,
                    ?LineWidth          = LineWidth         ,
                    ?LineDash           = LineDash          ,
                    ?Line               = Line              ,
                    ?LocationMode       = LocationMode      ,
                    ?GeoJson            = GeoJson           ,
                    ?FeatureIdKey       = FeatureIdKey      ,
                    ?UseDefaults        = UseDefaults       
                    
                )

        /// Creates a LineGeo chart, where data is visualized as coordinates connected via lines on a geographic map.
        [<Extension>]
        static member LineGeo
            (
                locations: seq<string>,
                [<Optional;DefaultParameterValue(null)>] ?ShowMarkers       : bool,
                [<Optional;DefaultParameterValue(null)>] ?Name              : string,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend        : bool,
                [<Optional;DefaultParameterValue(null)>] ?Opacity           : float,
                [<Optional;DefaultParameterValue(null)>] ?MultiOpacity      : seq<float>,
                [<Optional;DefaultParameterValue(null)>] ?Text              : #IConvertible,
                [<Optional;DefaultParameterValue(null)>] ?MultiText         : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition      : StyleParam.TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?MultiTextPosition : seq<StyleParam.TextPosition>,
                [<Optional;DefaultParameterValue(null)>] ?MarkerColor       : Color,
                [<Optional;DefaultParameterValue(null)>] ?MarkerColorScale  : StyleParam.Colorscale,
                [<Optional;DefaultParameterValue(null)>] ?MarkerOutline     : Line,
                [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol      : StyleParam.MarkerSymbol,
                [<Optional;DefaultParameterValue(null)>] ?MultiMarkerSymbol : seq<StyleParam.MarkerSymbol>,
                [<Optional;DefaultParameterValue(null)>] ?Marker            : Marker,
                [<Optional;DefaultParameterValue(null)>] ?LineColor         : Color,
                [<Optional;DefaultParameterValue(null)>] ?LineColorScale    : StyleParam.Colorscale,
                [<Optional;DefaultParameterValue(null)>] ?LineWidth         : float,
                [<Optional;DefaultParameterValue(null)>] ?LineDash          : StyleParam.DrawingStyle,
                [<Optional;DefaultParameterValue(null)>] ?Line              : Line,
                [<Optional;DefaultParameterValue(null)>] ?LocationMode      : StyleParam.LocationFormat,
                [<Optional;DefaultParameterValue(null)>] ?GeoJson           : obj                  ,
                [<Optional;DefaultParameterValue(null)>] ?FeatureIdKey      : string          ,
                [<Optional;DefaultParameterValue(true)>] ?UseDefaults       : bool
            ) = 

                let changeMode = 
                    let isShowMarker =
                        match ShowMarkers with
                        | Some isShow -> isShow
                        | Option.None        -> false
                    StyleParam.ModeUtils.showText (TextPosition.IsSome || MultiTextPosition.IsSome)                       
                    >> StyleParam.ModeUtils.showMarker (isShowMarker)

                Chart.ScatterGeo(
                    locations,
                    mode = changeMode StyleParam.Mode.Lines,
                    ?Name               = Name             ,
                    ?ShowLegend         = ShowLegend       ,
                    ?Opacity            = Opacity          ,
                    ?MultiOpacity       = MultiOpacity     ,
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
                    ?LocationMode       = LocationMode     ,
                    ?GeoJson            = GeoJson          ,
                    ?FeatureIdKey       = FeatureIdKey     ,
                    ?UseDefaults        = UseDefaults      
                )

        /// <summary>
        /// Creates a ScatterMapbox chart, where data is visualized by (longitude,latitude) pairs on a geographic map using mapbox.
        ///
        /// Customize the mapbox layers, style, etc. by using Chart.withMapbox.
        ///
        /// You might need a Mapbox token, which you can also configure with Chart.withMapbox.
        ///
        /// ScatterGeo charts are the basis of PointMapbox and LineMapbox Charts, and can be customized as such. We also provide abstractions for those: Chart.PointMapbox and Chart.LineMapbox
        /// </summary>
        /// <param name="longitudes">Sets the longitude coordinates (in degrees East).</param>
        /// <param name="latitudes">Sets the latitude coordinates (in degrees North).</param>
        /// <param name="mode">Determines the drawing mode for this scatter trace. If the provided `mode` includes "text" then the `text` elements appear at the coordinates. Otherwise, the `text` elements appear on hover.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Color">Sets the marker color. It accepts either a specific color or an array of numbers that are mapped to the colorscale relative to the max and min values of the array or relative to `marker.cmin` and `marker.cmax` if set.</param>
        /// <param name="Opacity">Sets the opacity of the trace.</param>
        /// <param name="Labels">Sets text elements associated with each (lon,lat) pair If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (lon,lat) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
        /// <param name="TextPosition">Sets the positions of the `text` elements with respects to the (x,y) coordinates.</param>
        /// <param name="TextFont">Sets the icon text font (color=mapbox.layer.paint.text-color, size=mapbox.layer.layout.text-size). Has an effect only when `type` is set to "symbol".</param>
        /// <param name="Width">Sets the line width (in px).</param>
        /// <param name="Below">Determines if this scattermapbox trace's layers are to be inserted before the layer with the specified ID. By default, scattermapbox layers are inserted above all the base layers. To place the scattermapbox layers above every other layer, set `below` to "''".</param>
        /// <param name="Connectgaps">Determines whether or not gaps (i.e. {nan} or missing values) in the provided data arrays are connected.</param>
        /// <param name="Fill">Sets the area to fill with a solid color. Use with `fillcolor` if not "none". "toself" connects the endpoints of the trace (or each segment of the trace if it has gaps) into a closed shape.</param>
        /// <param name="Fillcolor">Sets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
        [<Extension>]
        static member ScatterMapbox
            (
                longitudes, latitudes, 
                mode,
                [<Optional;DefaultParameterValue(null)>] ?Name                          ,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend                    ,
                [<Optional;DefaultParameterValue(null)>] ?Color                         ,
                [<Optional;DefaultParameterValue(null)>] ?Opacity                       ,
                [<Optional;DefaultParameterValue(null)>] ?Labels                        ,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition                  ,
                [<Optional;DefaultParameterValue(null)>] ?TextFont                      ,
                [<Optional;DefaultParameterValue(null)>] ?Width : float                 ,
                [<Optional;DefaultParameterValue(null)>] ?Below : string                ,
                [<Optional;DefaultParameterValue(null)>] ?Connectgaps : bool            ,
                [<Optional;DefaultParameterValue(null)>] ?Fill        : StyleParam.Fill ,
                [<Optional;DefaultParameterValue(null)>] ?Fillcolor,
                [<Optional;DefaultParameterValue(true)>] ?UseDefaults : bool
            ) = 

                let useDefaults = defaultArg UseDefaults true

                TraceMapbox.initScatterMapbox(
                    TraceMapboxStyle.ScatterMapbox(
                        Mode            = mode          ,
                        Longitudes      = longitudes    ,
                        Latitudes       = latitudes     ,
                        ?Below          = Below         ,
                        ?Connectgaps    = Connectgaps  ,
                        ?Fill           = Fill         ,
                        ?Fillcolor      = Fillcolor    
                    )               
                )
                |> TraceStyle.TraceInfo(?Name=Name,?ShowLegend=ShowLegend,?Opacity=Opacity)
                |> TraceStyle.Line(?Color=Color,?Width=Width)
                |> TraceStyle.Marker(?Color=Color)
                |> TraceStyle.TextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
                |> GenericChart.ofTraceObject useDefaults

        /// <summary>
        /// Creates a ScatterMapbox chart, where data is visualized by (longitude,latitude) pairs on a geographic map using mapbox.
        ///
        /// Customize the mapbox layers, style, etc. by using Chart.withMapbox.
        ///
        /// You might need a Mapbox token, which you can also configure with Chart.withMapbox.
        ///
        /// ScatterGeo charts are the basis of PointMapbox and LineMapbox Charts, and can be customized as such. We also provide abstractions for those: Chart.PointMapbox and Chart.LineMapbox
        /// </summary>
        /// <param name="lonlat">Sets the (longitude,latitude) coordinates (in degrees North, degrees South).</param>
        /// <param name="mode">Determines the drawing mode for this scatter trace. If the provided `mode` includes "text" then the `text` elements appear at the coordinates. Otherwise, the `text` elements appear on hover.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Color">Sets the marker color. It accepts either a specific color or an array of numbers that are mapped to the colorscale relative to the max and min values of the array or relative to `marker.cmin` and `marker.cmax` if set.</param>
        /// <param name="Opacity">Sets the opacity of the trace.</param>
        /// <param name="Labels">Sets text elements associated with each (lon,lat) pair If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (lon,lat) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
        /// <param name="TextPosition">Sets the positions of the `text` elements with respects to the (x,y) coordinates.</param>
        /// <param name="TextFont">Sets the icon text font (color=mapbox.layer.paint.text-color, size=mapbox.layer.layout.text-size). Has an effect only when `type` is set to "symbol".</param>
        /// <param name="Width">Sets the line width (in px).</param>
        /// <param name="Below">Determines if this scattermapbox trace's layers are to be inserted before the layer with the specified ID. By default, scattermapbox layers are inserted above all the base layers. To place the scattermapbox layers above every other layer, set `below` to "''".</param>
        /// <param name="Connectgaps">Determines whether or not gaps (i.e. {nan} or missing values) in the provided data arrays are connected.</param>
        /// <param name="Fill">Sets the area to fill with a solid color. Use with `fillcolor` if not "none". "toself" connects the endpoints of the trace (or each segment of the trace if it has gaps) into a closed shape.</param>
        /// <param name="Fillcolor">Sets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
        [<Extension>]
        static member ScatterMapbox
            (
                lonlat, mode,
                [<Optional;DefaultParameterValue(null)>] ?Name                          ,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend                    ,
                [<Optional;DefaultParameterValue(null)>] ?Color                         ,
                [<Optional;DefaultParameterValue(null)>] ?Opacity                       ,
                [<Optional;DefaultParameterValue(null)>] ?Labels                        ,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition                  ,
                [<Optional;DefaultParameterValue(null)>] ?TextFont                      ,
                [<Optional;DefaultParameterValue(null)>] ?Width : float                 ,
                [<Optional;DefaultParameterValue(null)>] ?Below : string                ,
                [<Optional;DefaultParameterValue(null)>] ?Connectgaps : bool            ,
                [<Optional;DefaultParameterValue(null)>] ?Fill        : StyleParam.Fill ,
                [<Optional;DefaultParameterValue(null)>] ?Fillcolor ,
                [<Optional;DefaultParameterValue(true)>] ?UseDefaults : bool
            ) = 

                let longitudes, latitudes = Seq.unzip lonlat

                Chart.ScatterMapbox(
                    longitudes, 
                    latitudes, 
                    mode,
                    ?Name           = Name       ,
                    ?ShowLegend     = ShowLegend ,
                    ?Color          = Color      ,
                    ?Opacity        = Opacity    ,
                    ?Labels         = Labels     ,
                    ?TextPosition   = TextPosition,
                    ?TextFont       = TextFont   ,
                    ?Width          = Width      ,
                    ?Below          = Below      ,
                    ?Connectgaps    = Connectgaps,
                    ?Fill           = Fill       ,
                    ?Fillcolor      = Fillcolor  ,
                    ?UseDefaults    = UseDefaults
                )                  
                           
        /// <summary>
        /// Creates a PointMapbox chart, where data is visualized by (longitude,latitude) pairs as Points on a geographic map using mapbox.
        ///
        /// Customize the mapbox layers, style, etc. by using Chart.withMapbox.
        ///
        /// You might need a Mapbox token, which you can also configure with Chart.withMapbox.
        /// </summary>
        /// <param name="longitudes">Sets the longitude coordinates (in degrees East).</param>
        /// <param name="latitudes">Sets the latitude coordinates (in degrees North).</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Color">Sets the marker color. It accepts either a specific color or an array of numbers that are mapped to the colorscale relative to the max and min values of the array or relative to `marker.cmin` and `marker.cmax` if set.</param>
        /// <param name="Opacity">Sets the opacity of the trace.</param>
        /// <param name="Labels">Sets text elements associated with each (lon,lat) pair If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (lon,lat) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
        /// <param name="TextPosition">Sets the positions of the `text` elements with respects to the (x,y) coordinates.</param>
        /// <param name="TextFont">Sets the icon text font (color=mapbox.layer.paint.text-color, size=mapbox.layer.layout.text-size). Has an effect only when `type` is set to "symbol".</param>
        /// <param name="Width">Sets the line width (in px).</param>
        /// <param name="Below">Determines if this scattermapbox trace's layers are to be inserted before the layer with the specified ID. By default, scattermapbox layers are inserted above all the base layers. To place the scattermapbox layers above every other layer, set `below` to "''".</param>
        /// <param name="Connectgaps">Determines whether or not gaps (i.e. {nan} or missing values) in the provided data arrays are connected.</param>
        /// <param name="Fill">Sets the area to fill with a solid color. Use with `fillcolor` if not "none". "toself" connects the endpoints of the trace (or each segment of the trace if it has gaps) into a closed shape.</param>
        /// <param name="Fillcolor">Sets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
        [<Extension>]
        static member PointMapbox
            (
                longitudes,latitudes,
                [<Optional;DefaultParameterValue(null)>] ?Name                          ,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend                    ,
                [<Optional;DefaultParameterValue(null)>] ?Color                         ,
                [<Optional;DefaultParameterValue(null)>] ?Opacity                       ,
                [<Optional;DefaultParameterValue(null)>] ?Labels                        ,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition                  ,
                [<Optional;DefaultParameterValue(null)>] ?TextFont                      ,
                [<Optional;DefaultParameterValue(null)>] ?Width : float                 ,
                [<Optional;DefaultParameterValue(null)>] ?Below : string                ,
                [<Optional;DefaultParameterValue(null)>] ?Connectgaps : bool            ,
                [<Optional;DefaultParameterValue(null)>] ?Fill        : StyleParam.Fill ,
                [<Optional;DefaultParameterValue(null)>] ?Fillcolor   ,
                [<Optional;DefaultParameterValue(true)>] ?UseDefaults : bool
            ) = 

                let changeMode = StyleParam.ModeUtils.showText (TextPosition.IsSome || TextFont.IsSome)

                Chart.ScatterMapbox(
                    longitudes, 
                    latitudes, 
                    changeMode StyleParam.Mode.Markers ,
                    ?Name        =  Name       ,
                    ?ShowLegend  =  ShowLegend ,
                    ?Color       =  Color      ,
                    ?Opacity     =  Opacity    ,
                    ?Labels      =  Labels     ,
                    ?TextPosition=  TextPosition,
                    ?TextFont    =  TextFont   ,
                    ?Width       =  Width      ,
                    ?Below       =  Below      ,
                    ?Connectgaps =  Connectgaps,
                    ?Fill        =  Fill       ,
                    ?Fillcolor   =  Fillcolor  ,
                    ?UseDefaults = UseDefaults
                )                  
                                                      
        /// <summary>
        /// Creates a PointMapbox chart, where data is visualized by (longitude,latitude) pairs as Points on a geographic map using mapbox.
        ///
        /// Customize the mapbox layers, style, etc. by using Chart.withMapbox.
        ///
        /// You might need a Mapbox token, which you can also configure with Chart.withMapbox.
        /// </summary>
        /// <param name="lonlat">Sets the (longitude,latitude) coordinates (in degrees North, degrees South).</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Color">Sets the marker color. It accepts either a specific color or an array of numbers that are mapped to the colorscale relative to the max and min values of the array or relative to `marker.cmin` and `marker.cmax` if set.</param>
        /// <param name="Opacity">Sets the opacity of the trace.</param>
        /// <param name="Labels">Sets text elements associated with each (lon,lat) pair If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (lon,lat) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
        /// <param name="TextPosition">Sets the positions of the `text` elements with respects to the (x,y) coordinates.</param>
        /// <param name="TextFont">Sets the icon text font (color=mapbox.layer.paint.text-color, size=mapbox.layer.layout.text-size). Has an effect only when `type` is set to "symbol".</param>
        /// <param name="Width">Sets the line width (in px).</param>
        /// <param name="Below">Determines if this scattermapbox trace's layers are to be inserted before the layer with the specified ID. By default, scattermapbox layers are inserted above all the base layers. To place the scattermapbox layers above every other layer, set `below` to "''".</param>
        /// <param name="Connectgaps">Determines whether or not gaps (i.e. {nan} or missing values) in the provided data arrays are connected.</param>
        /// <param name="Fill">Sets the area to fill with a solid color. Use with `fillcolor` if not "none". "toself" connects the endpoints of the trace (or each segment of the trace if it has gaps) into a closed shape.</param>
        /// <param name="Fillcolor">Sets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
        [<Extension>]
        static member PointMapbox
            (
                lonlat,
                [<Optional;DefaultParameterValue(null)>] ?Name                          ,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend                    ,
                [<Optional;DefaultParameterValue(null)>] ?Color                         ,
                [<Optional;DefaultParameterValue(null)>] ?Opacity                       ,
                [<Optional;DefaultParameterValue(null)>] ?Labels                        ,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition                  ,
                [<Optional;DefaultParameterValue(null)>] ?TextFont                      ,
                [<Optional;DefaultParameterValue(null)>] ?Width : float                 ,
                [<Optional;DefaultParameterValue(null)>] ?Below : string                ,
                [<Optional;DefaultParameterValue(null)>] ?Connectgaps : bool            ,
                [<Optional;DefaultParameterValue(null)>] ?Fill        : StyleParam.Fill ,
                [<Optional;DefaultParameterValue(null)>] ?Fillcolor,
                [<Optional;DefaultParameterValue(true)>] ?UseDefaults : bool
            ) = 

                let changeMode = StyleParam.ModeUtils.showText (TextPosition.IsSome || TextFont.IsSome)
                let longitudes, latitudes = Seq.unzip lonlat

                Chart.ScatterMapbox(
                    longitudes, 
                    latitudes, 
                    mode = changeMode StyleParam.Mode.Markers ,
                    ?Name        =  Name       ,
                    ?ShowLegend  =  ShowLegend ,
                    ?Color       =  Color      ,
                    ?Opacity     =  Opacity    ,
                    ?Labels      =  Labels     ,
                    ?TextPosition=  TextPosition,
                    ?TextFont    =  TextFont   ,
                    ?Width       =  Width      ,
                    ?Below       =  Below      ,
                    ?Connectgaps =  Connectgaps,
                    ?Fill        =  Fill       ,
                    ?Fillcolor   =  Fillcolor  ,
                    ?UseDefaults = UseDefaults
                )                                             
        /// <summary>
        /// Creates a LineMapbox chart, where data is visualized by (longitude,latitude) pairs connected by a line on a geographic map using mapbox.
        ///
        /// Customize the mapbox layers, style, etc. by using Chart.withMapbox.
        ///
        /// You might need a Mapbox token, which you can also configure with Chart.withMapbox.
        /// </summary>
        /// <param name="longitudes">Sets the longitude coordinates (in degrees East).</param>
        /// <param name="latitudes">Sets the latitude coordinates (in degrees North).</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="ShowMarkers">Determines whether or not To show markers for the individual datums.</param>
        /// <param name="Color">Sets the marker color. It accepts either a specific color or an array of numbers that are mapped to the colorscale relative to the max and min values of the array or relative to `marker.cmin` and `marker.cmax` if set.</param>
        /// <param name="Opacity">Sets the opacity of the trace.</param>
        /// <param name="Labels">Sets text elements associated with each (lon,lat) pair If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (lon,lat) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
        /// <param name="TextPosition">Sets the positions of the `text` elements with respects to the (x,y) coordinates.</param>
        /// <param name="TextFont">Sets the icon text font (color=mapbox.layer.paint.text-color, size=mapbox.layer.layout.text-size). Has an effect only when `type` is set to "symbol".</param>
        /// <param name="Width">Sets the line width (in px).</param>
        /// <param name="Below">Determines if this scattermapbox trace's layers are to be inserted before the layer with the specified ID. By default, scattermapbox layers are inserted above all the base layers. To place the scattermapbox layers above every other layer, set `below` to "''".</param>
        /// <param name="Connectgaps">Determines whether or not gaps (i.e. {nan} or missing values) in the provided data arrays are connected.</param>
        /// <param name="Fill">Sets the area to fill with a solid color. Use with `fillcolor` if not "none". "toself" connects the endpoints of the trace (or each segment of the trace if it has gaps) into a closed shape.</param>
        /// <param name="Fillcolor">Sets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
        [<Extension>]
        static member LineMapbox
            (
                longitudes,latitudes,
                [<Optional;DefaultParameterValue(null)>] ?Name                          ,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend                    ,
                [<Optional;DefaultParameterValue(null)>] ?ShowMarkers                   ,
                [<Optional;DefaultParameterValue(null)>] ?Color                         ,
                [<Optional;DefaultParameterValue(null)>] ?Opacity                       ,
                [<Optional;DefaultParameterValue(null)>] ?Labels                        ,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition                  ,
                [<Optional;DefaultParameterValue(null)>] ?TextFont                      ,
                [<Optional;DefaultParameterValue(null)>] ?Width : float                 ,
                [<Optional;DefaultParameterValue(null)>] ?Below : string                ,
                [<Optional;DefaultParameterValue(null)>] ?Connectgaps : bool            ,
                [<Optional;DefaultParameterValue(null)>] ?Fill        : StyleParam.Fill ,
                [<Optional;DefaultParameterValue(null)>] ?Fillcolor   ,
                [<Optional;DefaultParameterValue(true)>] ?UseDefaults : bool
            ) = 

                let changeMode = 
                    let isShowMarker =
                        match ShowMarkers with
                        | Some isShow -> isShow
                        | Option.None        -> false
                    StyleParam.ModeUtils.showText (TextPosition.IsSome || TextFont.IsSome)                       
                    >> StyleParam.ModeUtils.showMarker (isShowMarker)

                Chart.ScatterMapbox(
                    longitudes, 
                    latitudes, 
                    changeMode StyleParam.Mode.Lines ,
                    ?Name        =  Name       ,
                    ?ShowLegend  =  ShowLegend ,
                    ?Color       =  Color      ,
                    ?Opacity     =  Opacity    ,
                    ?Labels      =  Labels     ,
                    ?TextPosition=  TextPosition,
                    ?TextFont    =  TextFont   ,
                    ?Width       =  Width      ,
                    ?Below       =  Below      ,
                    ?Connectgaps =  Connectgaps,
                    ?Fill        =  Fill       ,
                    ?Fillcolor   =  Fillcolor  ,
                    ?UseDefaults = UseDefaults
                )                  
                                                      
        /// <summary>
        /// Creates a LineMapbox chart, where data is visualized by (longitude,latitude) pairs connected by a line on a geographic map using mapbox.
        ///
        /// Customize the mapbox layers, style, etc. by using Chart.withMapbox.
        ///
        /// You might need a Mapbox token, which you can also configure with Chart.withMapbox.
        /// </summary>
        /// <param name="lonlat">Sets the (longitude,latitude) coordinates (in degrees North, degrees South).</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="ShowMarkers">Determines whether or not To show markers for the individual datums.</param>
        /// <param name="Color">Sets the marker color. It accepts either a specific color or an array of numbers that are mapped to the colorscale relative to the max and min values of the array or relative to `marker.cmin` and `marker.cmax` if set.</param>
        /// <param name="Opacity">Sets the opacity of the trace.</param>
        /// <param name="Labels">Sets text elements associated with each (lon,lat) pair If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (lon,lat) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
        /// <param name="TextPosition">Sets the positions of the `text` elements with respects to the (x,y) coordinates.</param>
        /// <param name="TextFont">Sets the icon text font (color=mapbox.layer.paint.text-color, size=mapbox.layer.layout.text-size). Has an effect only when `type` is set to "symbol".</param>
        /// <param name="Width">Sets the line width (in px).</param>
        /// <param name="Below">Determines if this scattermapbox trace's layers are to be inserted before the layer with the specified ID. By default, scattermapbox layers are inserted above all the base layers. To place the scattermapbox layers above every other layer, set `below` to "''".</param>
        /// <param name="Connectgaps">Determines whether or not gaps (i.e. {nan} or missing values) in the provided data arrays are connected.</param>
        /// <param name="Fill">Sets the area to fill with a solid color. Use with `fillcolor` if not "none". "toself" connects the endpoints of the trace (or each segment of the trace if it has gaps) into a closed shape.</param>
        /// <param name="Fillcolor">Sets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
        [<Extension>]
        static member LineMapbox
            (
                lonlat,
                [<Optional;DefaultParameterValue(null)>] ?Name                          ,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend                    ,
                [<Optional;DefaultParameterValue(null)>] ?ShowMarkers                   ,
                [<Optional;DefaultParameterValue(null)>] ?Color                         ,
                [<Optional;DefaultParameterValue(null)>] ?Opacity                       ,
                [<Optional;DefaultParameterValue(null)>] ?Labels                        ,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition                  ,
                [<Optional;DefaultParameterValue(null)>] ?TextFont                      ,
                [<Optional;DefaultParameterValue(null)>] ?Width : float                 ,
                [<Optional;DefaultParameterValue(null)>] ?Below : string                ,
                [<Optional;DefaultParameterValue(null)>] ?Connectgaps : bool            ,
                [<Optional;DefaultParameterValue(null)>] ?Fill        : StyleParam.Fill ,
                [<Optional;DefaultParameterValue(null)>] ?Fillcolor,
                [<Optional;DefaultParameterValue(true)>] ?UseDefaults : bool
            ) = 

                let changeMode = 
                    let isShowMarker =
                        match ShowMarkers with
                        | Some isShow -> isShow
                        | Option.None        -> false
                    StyleParam.ModeUtils.showText (TextPosition.IsSome || TextFont.IsSome)                       
                    >> StyleParam.ModeUtils.showMarker (isShowMarker)
                let longitudes, latitudes = Seq.unzip lonlat

                Chart.ScatterMapbox(
                    longitudes, 
                    latitudes, 
                    mode = changeMode StyleParam.Mode.Lines ,
                    ?Name        =  Name       ,
                    ?ShowLegend  =  ShowLegend ,
                    ?Color       =  Color      ,
                    ?Opacity     =  Opacity    ,
                    ?Labels      =  Labels     ,
                    ?TextPosition=  TextPosition,
                    ?TextFont    =  TextFont   ,
                    ?Width       =  Width      ,
                    ?Below       =  Below      ,
                    ?Connectgaps =  Connectgaps,
                    ?Fill        =  Fill       ,
                    ?Fillcolor   =  Fillcolor  ,
                    ?UseDefaults = UseDefaults
                )                  

        /// <summary>
        /// Creates a ChoroplethMapbox Chart. 
        ///
        /// Choropleth Maps display divided geographical areas or regions that are coloured, shaded or patterned in relation to 
        /// a data variable. This provides a way to visualise values over a geographical area, which can show variation or 
        /// patterns across the displayed location.
        ///
        /// GeoJSON features to be filled are set in `geojson` The data that describes the choropleth value-to-color mapping is set in `locations` and `z`.
        /// </summary>
        /// <param name="locations">Sets which features found in "geojson" to plot using their feature `id` field.</param>
        /// <param name="z">Sets the color values.</param>
        /// <param name="geoJson">Sets the GeoJSON data associated with this trace. It can be set as a valid GeoJSON object or as a URL string. Note that we only accept GeoJSONs of type "FeatureCollection" or "Feature" with geometries of type "Polygon" or "MultiPolygon".</param>
        /// <param name="FeatureIdKey">Sets the key in GeoJSON features which is used as id to match the items included in the `locations` array. Support nested property, for example "properties.name".</param>
        /// <param name="Text">Sets the text elements associated with each location.</param>
        /// <param name="Below">Determines if the choropleth polygons will be inserted before the layer with the specified ID. By default, choroplethmapbox traces are placed above the water layers. If set to '', the layer will be inserted above every existing layer.</param>
        /// <param name="Colorscale">Sets the colorscale.</param>
        /// <param name="ColorBar">Sets the ColorBar object asociated with this trace</param>
        /// <param name="ZAuto">Determines whether or not the color domain is computed with respect to the input data (here in `z`) or the bounds set in `zmin` and `zmax` Defaults to `false` when `zmin` and `zmax` are set by the user.</param>
        /// <param name="ZMin">Sets the lower bound of the color domain. Value should have the same units as in `z` and if set, `zmax` must be set as well.</param>
        /// <param name="ZMid">Sets the mid-point of the color domain by scaling `zmin` and/or `zmax` to be equidistant to this point. Value should have the same units as in `z`. Has no effect when `zauto` is `false`.</param>
        /// <param name="ZMax">Sets the upper bound of the color domain. Value should have the same units as in `z` and if set, `zmin` must be set as well.</param>
        [<Extension>]
        static member ChoroplethMapbox
            (
                locations,z,geoJson,
                [<Optional;DefaultParameterValue(null)>] ?FeatureIdKey,
                [<Optional;DefaultParameterValue(null)>] ?Text,
                [<Optional;DefaultParameterValue(null)>] ?Below,
                [<Optional;DefaultParameterValue(null)>] ?Colorscale,
                [<Optional;DefaultParameterValue(null)>] ?ColorBar,
                [<Optional;DefaultParameterValue(null)>] ?ZAuto,
                [<Optional;DefaultParameterValue(null)>] ?ZMin,
                [<Optional;DefaultParameterValue(null)>] ?ZMid,
                [<Optional;DefaultParameterValue(null)>] ?ZMax,
                [<Optional;DefaultParameterValue(true)>] ?UseDefaults : bool
            ) = 

                let useDefaults = defaultArg UseDefaults true
            
                TraceMapbox.initChoroplethMapbox (
                    TraceMapboxStyle.ChoroplethMapbox (
                        Z               = z,
                        Locations       = locations,
                        GeoJson         = geoJson,
                        ?FeatureIdKey   = FeatureIdKey,
                        ?Text           = Text,
                        ?Below          = Below,
                        ?Colorscale     = Colorscale,
                        ?ColorBar       = ColorBar,
                        ?ZAuto          = ZAuto,
                        ?ZMin           = ZMin,
                        ?ZMid           = ZMid,
                        ?ZMax           = ZMax
                    )
                )
                |> GenericChart.ofTraceObject useDefaults
            
        /// <summary>
        /// Creates a DensityMapbox Chart that draws a bivariate kernel density estimation with a Gaussian kernel from `lon` and `lat` coordinates and optional `z` values using a colorscale.
        /// </summary>
        /// <param name="lon">Sets the longitude coordinates (in degrees East).</param>
        /// <param name="lat">Sets the latitude coordinates (in degrees North).</param>
        /// <param name="Z">Sets the points' weight. For example, a value of 10 would be equivalent to having 10 points of weight 1 in the same spot</param>
        /// <param name="Radius">Sets the radius of influence of one `lon` / `lat` point in pixels. Increasing the value makes the densitymapbox trace smoother, but less detailed.</param>
        /// <param name="Opacity">Sets the opacity of the trace.</param>
        /// <param name="Text">Sets text elements associated with each (lon,lat) pair If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (lon,lat) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
        /// <param name="Below">Determines if the densitymapbox trace will be inserted before the layer with the specified ID. By default, densitymapbox traces are placed below the first layer of type symbol If set to '', the layer will be inserted above every existing layer.</param>
        /// <param name="Colorscale">Sets the colorscale.</param>
        /// <param name="ColorBar">Sets the ColorBar object asociated with this trace</param>
        /// <param name="Showscale">Determines whether or not a colorbar is displayed for this trace.</param>
        /// <param name="ZAuto">Determines whether or not the color domain is computed with respect to the input data (here in `z`) or the bounds set in `zmin` and `zmax` Defaults to `false` when `zmin` and `zmax` are set by the user.</param>
        /// <param name="ZMin">Sets the lower bound of the color domain. Value should have the same units as in `z` and if set, `zmax` must be set as well.</param>
        /// <param name="ZMid">Sets the mid-point of the color domain by scaling `zmin` and/or `zmax` to be equidistant to this point. Value should have the same units as in `z`. Has no effect when `zauto` is `false`.</param>
        /// <param name="ZMax">Sets the upper bound of the color domain. Value should have the same units as in `z` and if set, `zmin` must be set as well.</param>
        [<Extension>]
        static member DensityMapbox 
            (
                lon,lat,
                [<Optional;DefaultParameterValue(null)>] ?Z,
                [<Optional;DefaultParameterValue(null)>] ?Radius,
                [<Optional;DefaultParameterValue(null)>] ?Opacity,
                [<Optional;DefaultParameterValue(null)>] ?Text,
                [<Optional;DefaultParameterValue(null)>] ?Below,
                [<Optional;DefaultParameterValue(null)>] ?Colorscale,
                [<Optional;DefaultParameterValue(null)>] ?ColorBar,
                [<Optional;DefaultParameterValue(null)>] ?Showscale ,
                [<Optional;DefaultParameterValue(null)>] ?ZAuto,
                [<Optional;DefaultParameterValue(null)>] ?ZMin,
                [<Optional;DefaultParameterValue(null)>] ?ZMid,
                [<Optional;DefaultParameterValue(null)>] ?ZMax,
                [<Optional;DefaultParameterValue(true)>] ?UseDefaults : bool
            ) = 

                let useDefaults = defaultArg UseDefaults true

                TraceMapbox.initDensityMapbox(
                    TraceMapboxStyle.DensityMapbox(
                        Longitudes  = lon,
                        Latitudes   = lat,
                        ?Z          = Z,
                        ?Radius     = Radius,
                        ?Opacity    = Opacity,
                        ?Text       = Text,
                        ?Below      = Below,
                        ?Colorscale = Colorscale,
                        ?ColorBar   = ColorBar,
                        ?Showscale  = Showscale,
                        ?ZAuto      = ZAuto,
                        ?ZMin       = ZMin,
                        ?ZMid       = ZMid,
                        ?ZMax       = ZMax
                    )
                )
                |> GenericChart.ofTraceObject useDefaults
    
        /// <summary>
        /// Creates a DensityMapbox Chart that draws a bivariate kernel density estimation with a Gaussian kernel from `lon` and `lat` coordinates and optional `z` values using a colorscale.
        /// </summary>
        /// <param name="lonlat">Sets the (longitude,latitude) coordinates (in degrees North, degrees South).</param>
        /// <param name="Z">Sets the points' weight. For example, a value of 10 would be equivalent to having 10 points of weight 1 in the same spot</param>
        /// <param name="Radius">Sets the radius of influence of one `lon` / `lat` point in pixels. Increasing the value makes the densitymapbox trace smoother, but less detailed.</param>
        /// <param name="Opacity">Sets the opacity of the trace.</param>
        /// <param name="Text">Sets text elements associated with each (lon,lat) pair If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (lon,lat) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
        /// <param name="Below">Determines if the densitymapbox trace will be inserted before the layer with the specified ID. By default, densitymapbox traces are placed below the first layer of type symbol If set to '', the layer will be inserted above every existing layer.</param>
        /// <param name="Colorscale">Sets the colorscale.</param>
        /// <param name="ColorBar">Sets the ColorBar object asociated with this trace</param>
        /// <param name="Showscale">Determines whether or not a colorbar is displayed for this trace.</param>
        /// <param name="ZAuto">Determines whether or not the color domain is computed with respect to the input data (here in `z`) or the bounds set in `zmin` and `zmax` Defaults to `false` when `zmin` and `zmax` are set by the user.</param>
        /// <param name="ZMin">Sets the lower bound of the color domain. Value should have the same units as in `z` and if set, `zmax` must be set as well.</param>
        /// <param name="ZMid">Sets the mid-point of the color domain by scaling `zmin` and/or `zmax` to be equidistant to this point. Value should have the same units as in `z`. Has no effect when `zauto` is `false`.</param>
        /// <param name="ZMax">Sets the upper bound of the color domain. Value should have the same units as in `z` and if set, `zmin` must be set as well.</param>
        [<Extension>]
        static member DensityMapbox 
            (
                lonlat,
                [<Optional;DefaultParameterValue(null)>] ?Z,
                [<Optional;DefaultParameterValue(null)>] ?Radius,
                [<Optional;DefaultParameterValue(null)>] ?Opacity,
                [<Optional;DefaultParameterValue(null)>] ?Text,
                [<Optional;DefaultParameterValue(null)>] ?Below,
                [<Optional;DefaultParameterValue(null)>] ?Colorscale,
                [<Optional;DefaultParameterValue(null)>] ?ColorBar,
                [<Optional;DefaultParameterValue(null)>] ?Showscale ,
                [<Optional;DefaultParameterValue(null)>] ?ZAuto,
                [<Optional;DefaultParameterValue(null)>] ?ZMin,
                [<Optional;DefaultParameterValue(null)>] ?ZMid,
                [<Optional;DefaultParameterValue(null)>] ?ZMax,
                [<Optional;DefaultParameterValue(true)>] ?UseDefaults : bool
            ) = 

                let longitudes, latitudes = Seq.unzip lonlat
            
                Chart.DensityMapbox(
                    longitudes,
                    latitudes,
                    ?Z          = Z,
                    ?Radius     = Radius,
                    ?Opacity    = Opacity,
                    ?Text       = Text,
                    ?Below      = Below,
                    ?Colorscale = Colorscale,
                    ?ColorBar   = ColorBar, 
                    ?Showscale  = Showscale,
                    ?ZAuto      = ZAuto,
                    ?ZMin       = ZMin,
                    ?ZMid       = ZMid,
                    ?ZMax       = ZMax,
                    ?UseDefaults= UseDefaults
                )