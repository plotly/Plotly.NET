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

                MapboxId |> DynObj.setValueOptBy trace "subplot" StyleParam.SubPlotId.toString

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
            [<Optional;DefaultParameterValue(null)>] ?Mode        : StyleParam.Mode,
            [<Optional;DefaultParameterValue(null)>] ?Longitudes : #IConvertible seq,
            [<Optional;DefaultParameterValue(null)>] ?Latitudes  : #IConvertible seq,
            [<Optional;DefaultParameterValue(null)>] ?Below      : string,
            [<Optional;DefaultParameterValue(null)>] ?Connectgaps: bool,
            [<Optional;DefaultParameterValue(null)>] ?Fill       : StyleParam.Fill,
            [<Optional;DefaultParameterValue(null)>] ?Fillcolor  : string,
            [<Optional;DefaultParameterValue(null)>] ?Marker     : Marker
        ) =
            (fun (trace:#Trace) -> 
            
                Mode        |> DynObj.setValueOptBy trace "mode" StyleParam.Mode.convert
                Longitudes  |> DynObj.setValueOpt   trace "lon"
                Latitudes   |> DynObj.setValueOpt   trace "lat"
                Below       |> DynObj.setValueOpt   trace "below"
                Connectgaps |> DynObj.setValueOpt   trace "connectgaps"
                Fill        |> DynObj.setValueOptBy trace "fill" StyleParam.Fill.convert
                Fillcolor   |> DynObj.setValueOpt   trace "fillcolor"
                Marker      |> DynObj.setValueOpt   trace "marker"

                trace
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