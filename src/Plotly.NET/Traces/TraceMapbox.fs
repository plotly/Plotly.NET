namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open DynamicObj
open DynamicObj.Operators
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

type TraceMapbox(traceTypeName) =

    inherit Trace (traceTypeName)

    ///initializes a trace of type "scattermapbox" applying the given trace styling function
    static member initScatterMapbox (applyStyle: TraceMapbox -> TraceMapbox) = 
        TraceMapbox("scattermapbox") |> applyStyle

    ///initializes a trace of type "choroplethmapbox" applying the given trace styling function
    static member initChoroplethMapbox (applyStyle: TraceMapbox -> TraceMapbox) = 
        TraceMapbox("choroplethmapbox") |> applyStyle

    ///initializes a trace of type "densitymapbox" applying the given trace styling function
    static member initDensityMapbox (applyStyle: TraceMapbox -> TraceMapbox) = 
        TraceMapbox("densitymapbox") |> applyStyle

type TraceMapboxStyle() = 

    static member SetMapbox
        (
            [<Optional;DefaultParameterValue(null)>] ?MapboxId:StyleParam.SubPlotId
        ) =  
            (fun (trace:TraceMapbox) ->

                trace

                ++?? ("subplot", MapboxId, StyleParam.SubPlotId.toString)
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
                    
                choropleth
                
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
            
                mode        |> StyleParam.Mode.convert |> ++ ("mode", ++? ("lon", Longitudes))

                trace
                ++? ("lat", Latitudes)
                ++? ("locations", Locations)
                ++? ("geojson", GeoJson)
                ++? ("featureidkey", FeatureIdKey)
                ++? ("connectgaps", Connectgaps)
                ++?? ("fill", Fill, StyleParam.Fill.convert)
                ++? ("fillcolor", Fillcolor)

            )

    static member ScatterMapbox 
        (
            mode        : StyleParam.Mode,
            [<Optional;DefaultParameterValue(null)>] ?Longitudes : #IConvertible seq,
            [<Optional;DefaultParameterValue(null)>] ?Latitudes  : #IConvertible seq,
            [<Optional;DefaultParameterValue(null)>] ?Below      : string,
            [<Optional;DefaultParameterValue(null)>] ?Connectgaps: bool,
            [<Optional;DefaultParameterValue(null)>] ?Fill       : StyleParam.Fill,
            [<Optional;DefaultParameterValue(null)>] ?Fillcolor  : string
        ) =
            (fun (trace:#Trace) -> 
            
                mode        |> StyleParam.Mode.convert |> ++ ("mode", ++? ("lon", Longitudes))

                trace
                ++? ("lat", Latitudes)
                ++? ("below", Below)
                ++? ("connectgaps", Connectgaps)
                ++?? ("fill", Fill, StyleParam.Fill.convert)
                ++? ("fillcolor", Fillcolor)
            )

    static member ChoroplethMapbox
        (
            [<Optional;DefaultParameterValue(null)>] ?Z              : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?GeoJson,
            [<Optional;DefaultParameterValue(null)>] ?FeatureIdKey   : string,
            [<Optional;DefaultParameterValue(null)>] ?Locations      : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?Text           : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?Below          : string,
            [<Optional;DefaultParameterValue(null)>] ?Colorscale     : StyleParam.Colorscale,
            [<Optional;DefaultParameterValue(null)>] ?ColorBar       : ColorBar,
            [<Optional;DefaultParameterValue(null)>] ?Showscale      : bool,
            [<Optional;DefaultParameterValue(null)>] ?ZAuto          : bool,
            [<Optional;DefaultParameterValue(null)>] ?ZMin           : float,
            [<Optional;DefaultParameterValue(null)>] ?ZMid           : float,
            [<Optional;DefaultParameterValue(null)>] ?ZMax           : float
        ) =
            (fun (trace: #Trace) -> 

                trace
                
                ++? ("z", Z)
                ++? ("geojson", GeoJson)
                ++? ("featureidkey", FeatureIdKey)
                ++? ("locations", Locations)
                ++? ("text", Text)
                ++? ("below", Below)
                ++?? ("colorscale", Colorscale, StyleParam.Colorscale.convert)
                ++? ("colorbar", ColorBar)
                ++? ("showscale", Showscale)
                ++? ("zauto", ZAuto)
                ++? ("zmin", ZMin)
                ++? ("zmid", ZMid)
                ++? ("zmax", ZMax)
            )

    static member DensityMapbox
        (
            [<Optional;DefaultParameterValue(null)>] ?Z              : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?Radius         : float,
            [<Optional;DefaultParameterValue(null)>] ?Longitudes     : #IConvertible seq,
            [<Optional;DefaultParameterValue(null)>] ?Latitudes      : #IConvertible seq,
            [<Optional;DefaultParameterValue(null)>] ?Opacity        : float,
            [<Optional;DefaultParameterValue(null)>] ?Text           : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?Below          : string,
            [<Optional;DefaultParameterValue(null)>] ?Colorscale     : StyleParam.Colorscale,
            [<Optional;DefaultParameterValue(null)>] ?ColorBar       : ColorBar,
            [<Optional;DefaultParameterValue(null)>] ?Showscale      : bool,
            [<Optional;DefaultParameterValue(null)>] ?ZAuto          : bool,
            [<Optional;DefaultParameterValue(null)>] ?ZMin           : float,
            [<Optional;DefaultParameterValue(null)>] ?ZMid           : float,
            [<Optional;DefaultParameterValue(null)>] ?ZMax           : float

        ) =
            (fun (trace: #Trace) -> 

                trace
                
                ++? ("z", Z)
                ++? ("radius", Radius)
                ++? ("lon", Longitudes)
                ++? ("lat", Latitudes)
                ++? ("opacity", Opacity)
                ++? ("text", Text)
                ++? ("below", Below)
                ++?? ("colorscale", Colorscale, StyleParam.Colorscale.convert)
                ++? ("colorbar", ColorBar)
                ++? ("showscale", Showscale)
                ++? ("zauto", ZAuto)
                ++? ("zmin", ZMin)
                ++? ("zmid", ZMid)
                ++? ("zmax", ZMax)
            )