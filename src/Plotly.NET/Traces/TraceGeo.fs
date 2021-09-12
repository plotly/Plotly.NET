namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open DynamicObj
open System
open System.Runtime.InteropServices


//Figures can include two different types of map subplots: geo subplots for outline maps and mapbox subplots for tile maps. 
///The following trace types support attributes named geo or mapbox, whose values must refer to corresponding objects in the layout 
///i.e. geo="geo2" etc. Note that attributes such as layout.geo2 and layout.mapbox etc do not have to be explicitly defined, in which 
///case default values will be inferred. Multiple traces of a compatible type can be placed on the same subplot.
///
/// The following trace types are compatible with geo subplots via the geo attribute:
/// 
/// - scattergeo, which can be used to draw individual markers, line and curves and filled areas on outline maps
/// 
/// - choropleth: colored polygons on outline maps
/// 
/// The following trace types are compatible with mapbox subplots via the mapbox attribute:
/// 
/// - scattermapbox, which can be used to draw individual markers, lines and curves and filled areas on tile maps
/// 
/// - choroplethmapbox: colored polygons on tile maps
/// 
/// - densitymapbox: density heatmaps on tile maps

type TraceGeo(traceTypeName) =

    inherit Trace (traceTypeName)

    ///initializes a trace of type "scattergeo" applying the given trace styling function
    static member initScatterGeo (applyStyle: TraceGeo -> TraceGeo) = 
        TraceGeo("scattergeo") |> applyStyle

    ///initializes a trace of type "choropleth" applying the given trace styling function
    static member initChoroplethMap (applyStyle: TraceGeo -> TraceGeo) = 
        TraceGeo("choropleth") |> applyStyle

type TraceGeoStyle() = 

    static member SetGeo
        (
            [<Optional;DefaultParameterValue(null)>] ?GeoId:StyleParam.SubPlotId
        ) =  
            (fun (trace:TraceGeo) ->

                ++?? ("geo", GeoId, StyleParam.SubPlotId.toString)

                trace
            )

    // Applies the styles of choropleth map plot to TraceObjects 
    static member ChoroplethMap
        (                
            [<Optional;DefaultParameterValue(null)>] ?Locations      : seq<string>,
            [<Optional;DefaultParameterValue(null)>] ?Z              : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?Text           : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?Locationmode   : StyleParam.LocationFormat,
            [<Optional;DefaultParameterValue(null)>] ?Autocolorscale : bool,
            [<Optional;DefaultParameterValue(null)>] ?Colorscale     : StyleParam.Colorscale,
            [<Optional;DefaultParameterValue(null)>] ?ColorBar       : ColorBar,
            [<Optional;DefaultParameterValue(null)>] ?Marker         : Marker,
            [<Optional;DefaultParameterValue(null)>] ?GeoJson,
            [<Optional;DefaultParameterValue(null)>] ?FeatureIdKey   : string,
            [<Optional;DefaultParameterValue(null)>] ?Zmin           : float,
            [<Optional;DefaultParameterValue(null)>] ?Zmid           : float,
            [<Optional;DefaultParameterValue(null)>] ?Zmax           : float
        ) =
            (fun (choropleth: #Trace) -> 
                
                ++? ("locations", Locations)         
                ++? ("z", Z)                     
                ++? ("text", Text)     
                ++?? ("locationmode", Locationmode, StyleParam.LocationFormat.convert)            
                ++? ("autocolorscale", Autocolorscale)    
                    
                ++?? ("colorscale", Colorscale, StyleParam.Colorscale.convert)
                ++? ("colorbar", ColorBar)
                ++? ("marker", Marker)  
                ++? ("geojson", GeoJson) 
                ++? ("featureidkey", FeatureIdKey)
                ++? ("zmin", Zmin)
                ++? ("zmid", Zmid)
                ++? ("zmax", Zmax)  
                    
                choropleth 
            ) 


    static member ScatterGeo 
        (
            mode       : StyleParam.Mode,
            [<Optional;DefaultParameterValue(null)>] ?Longitudes : #IConvertible seq,
            [<Optional;DefaultParameterValue(null)>] ?Latitudes  : #IConvertible seq,
            [<Optional;DefaultParameterValue(null)>] ?Locations  : seq<string>,
            [<Optional;DefaultParameterValue(null)>] ?GeoJson    ,
            [<Optional;DefaultParameterValue(null)>] ?FeatureIdKey:string,
            [<Optional;DefaultParameterValue(null)>] ?Connectgaps : bool,
            [<Optional;DefaultParameterValue(null)>] ?Fill        : StyleParam.Fill,
            [<Optional;DefaultParameterValue(null)>] ?Fillcolor   : Color
        ) =
            (fun (trace: #Trace) -> 
            
                mode        |> StyleParam.Mode.convert |> DynObj.setValue trace "mode"
                ++? ("lon", Longitudes)
                ++? ("lat", Latitudes)
                ++? ("locations", Locations)
                ++? ("geojson", GeoJson)
                ++? ("featureidkey", FeatureIdKey)
                ++? ("connectgaps", Connectgaps)
                ++?? ("fill", Fill, StyleParam.Fill.convert)
                ++? ("fillcolor", Fillcolor)

                trace

            )