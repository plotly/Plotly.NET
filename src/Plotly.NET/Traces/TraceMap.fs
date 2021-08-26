namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open DynamicObj
open System


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

type TraceMap(traceTypeName) =

    inherit Trace (traceTypeName)

    ///initializes a trace of type "scattergeo" applying the given trace styling function
    static member initScatterGeo (applyStyle: TraceMap -> TraceMap) = 
        TraceMap("scattergeo") |> applyStyle

    ///initializes a trace of type "choropleth" applying the given trace styling function
    static member initChoroplethMap (applyStyle: TraceMap -> TraceMap) = 
        TraceMap("choropleth") |> applyStyle

    ///initializes a trace of type "scattermapbox" applying the given trace styling function
    static member initScatterMapbox (applyStyle: TraceMap -> TraceMap) = 
        TraceMap("scattermapbox") |> applyStyle

    ///initializes a trace of type "choroplethmapbox" applying the given trace styling function
    static member initChoroplethMapbox (applyStyle: TraceMap -> TraceMap) = 
        TraceMap("choroplethmapbox") |> applyStyle

    ///initializes a trace of type "densitymapbox" applying the given trace styling function
    static member initDensityMapbox (applyStyle: TraceMap -> TraceMap) = 
        TraceMap("densitymapbox") |> applyStyle

type TraceMapStyle() = 

    // Applies the styles of choropleth map plot to TraceObjects 
    static member ChoroplethMap
        (                
            ?Locations      : seq<string>,
            ?Z              : seq<#IConvertible>,
            ?Text           : seq<#IConvertible>,
            ?Locationmode   : StyleParam.LocationFormat,
            ?Autocolorscale : bool,
            ?Colorscale     : StyleParam.Colorscale,
            ?ColorBar       : ColorBar,
            ?Marker         : Marker,
            ?GeoJson,
            ?FeatureIdKey   : string,
            ?Zmin           : float,
            ?Zmid           : float,
            ?Zmax           : float
        ) =
            (fun (choropleth: #Trace) -> 
                
                Locations          |> DynObj.setValueOpt   choropleth "locations"         
                Z                  |> DynObj.setValueOpt   choropleth "z"                     
                Text               |> DynObj.setValueOpt   choropleth "text"     
                Locationmode       |> DynObj.setValueOptBy choropleth "locationmode" StyleParam.LocationFormat.convert            
                Autocolorscale     |> DynObj.setValueOpt   choropleth "autocolorscale"    
                    
                Colorscale         |> DynObj.setValueOptBy choropleth "colorscale" StyleParam.Colorscale.convert
                ColorBar           |> DynObj.setValueOpt   choropleth "colorbar"
                Marker             |> DynObj.setValueOpt   choropleth "marker"  
                GeoJson            |> DynObj.setValueOpt   choropleth "geojson" 
                FeatureIdKey       |> DynObj.setValueOpt   choropleth "featureidkey"
                Zmin               |> DynObj.setValueOpt   choropleth "zmin"
                Zmid               |> DynObj.setValueOpt   choropleth "zmid"
                Zmax               |> DynObj.setValueOpt   choropleth "zmax"  
                    
                choropleth 
            ) 


    static member ScatterGeo 
        (
            mode       : StyleParam.Mode,
            ?Longitudes : #IConvertible seq,
            ?Latitudes  : #IConvertible seq,
            ?Locations  : seq<string>,
            ?GeoJson    ,
            ?FeatureIdKey:string,
            ?Connectgaps : bool,
            ?Fill        : StyleParam.Fill,
            ?Fillcolor   
        ) =
            (fun (trace: #Trace) -> 
            
                mode        |> StyleParam.Mode.convert |> DynObj.setValue trace "mode"
                Longitudes  |> DynObj.setValueOpt   trace "lon"
                Latitudes   |> DynObj.setValueOpt   trace "lat"
                Locations   |> DynObj.setValueOpt   trace "locations"
                GeoJson     |> DynObj.setValueOpt   trace "geojson"
                FeatureIdKey|> DynObj.setValueOpt   trace "featureidkey"
                Connectgaps |> DynObj.setValueOpt   trace "connectgaps"
                Fill        |> DynObj.setValueOptBy trace "fill" StyleParam.Fill.convert
                Fillcolor   |> DynObj.setValueOpt   trace "fillcolor"

                trace

            )

    static member ScatterMapbox 
        (
            mode        : StyleParam.Mode,
            ?Longitudes : #IConvertible seq,
            ?Latitudes  : #IConvertible seq,
            ?Below      : string,
            ?Connectgaps: bool,
            ?Fill       : StyleParam.Fill,
            ?Fillcolor  : string
        ) =
            (fun (trace:#Trace) -> 
            
                mode        |> StyleParam.Mode.convert |> DynObj.setValue trace "mode"
                Longitudes  |> DynObj.setValueOpt   trace "lon"
                Latitudes   |> DynObj.setValueOpt   trace "lat"
                Below       |> DynObj.setValueOpt   trace "below"
                Connectgaps |> DynObj.setValueOpt   trace "connectgaps"
                Fill        |> DynObj.setValueOptBy trace "fill" StyleParam.Fill.convert
                Fillcolor   |> DynObj.setValueOpt   trace "fillcolor"

                trace
            )

    static member ChoroplethMapbox
        (
            ?Z              : seq<#IConvertible>,
            ?GeoJson,
            ?FeatureIdKey   : string,
            ?Locations      : seq<#IConvertible>,
            ?Text           : seq<#IConvertible>,
            ?Below          : string,
            ?Colorscale     : StyleParam.Colorscale,
            ?ColorBar       : ColorBar,
            ?Showscale      : bool,
            ?ZAuto          : bool,
            ?ZMin           : float,
            ?ZMid           : float,
            ?ZMax           : float
        ) =
            (fun (trace: #Trace) -> 
                
                Z           |> DynObj.setValueOpt   trace "z"
                GeoJson     |> DynObj.setValueOpt   trace "geojson"
                FeatureIdKey|> DynObj.setValueOpt   trace "featureidkey"
                Locations   |> DynObj.setValueOpt   trace "locations"
                Text        |> DynObj.setValueOpt   trace "text"
                Below       |> DynObj.setValueOpt   trace "below"
                Colorscale  |> DynObj.setValueOptBy trace "colorscale" StyleParam.Colorscale.convert
                ColorBar    |> DynObj.setValueOpt   trace "colorbar"
                Showscale   |> DynObj.setValueOpt   trace "showscale"
                ZAuto       |> DynObj.setValueOpt   trace "zauto"
                ZMin        |> DynObj.setValueOpt   trace "zmin"
                ZMid        |> DynObj.setValueOpt   trace "zmid"
                ZMax        |> DynObj.setValueOpt   trace "zmax"

                trace
            )

    static member DensityMapbox
        (
            ?Z              : seq<#IConvertible>,
            ?Radius         : float,
            ?Longitudes     : #IConvertible seq,
            ?Latitudes      : #IConvertible seq,
            ?Opacity        : float,
            ?Text           : seq<#IConvertible>,
            ?Below          : string,
            ?Colorscale     : StyleParam.Colorscale,
            ?ColorBar       : ColorBar,
            ?Showscale      : bool,
            ?ZAuto          : bool,
            ?ZMin           : float,
            ?ZMid           : float,
            ?ZMax           : float

        ) =
            (fun (trace: #Trace) -> 
                
                Z           |> DynObj.setValueOpt   trace "z"
                Radius      |> DynObj.setValueOpt   trace "radius"
                Longitudes  |> DynObj.setValueOpt   trace "lon"
                Latitudes   |> DynObj.setValueOpt   trace "lat"
                Opacity     |> DynObj.setValueOpt   trace "opacity"
                Text        |> DynObj.setValueOpt   trace "text"
                Below       |> DynObj.setValueOpt   trace "below"
                Colorscale  |> DynObj.setValueOptBy trace "colorscale" StyleParam.Colorscale.convert
                ColorBar    |> DynObj.setValueOpt   trace "colorbar"
                Showscale   |> DynObj.setValueOpt   trace "showscale"
                ZAuto       |> DynObj.setValueOpt   trace "zauto"
                ZMin        |> DynObj.setValueOpt   trace "zmin"
                ZMid        |> DynObj.setValueOpt   trace "zmid"
                ZMax        |> DynObj.setValueOpt   trace "zmax"

                trace
            )