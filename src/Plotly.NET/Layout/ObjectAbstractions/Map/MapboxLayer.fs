namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

/// <summary></summary>
type MapboxLayer() =

    inherit DynamicObj()

    /// <summary>Initialize a MapboxLayer object</summary>

    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?Visible: bool,
            [<Optional; DefaultParameterValue(null)>] ?SourceType: StyleParam.MapboxLayerSourceType,
            [<Optional; DefaultParameterValue(null)>] ?Source: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?SourceLayer: string,
            [<Optional; DefaultParameterValue(null)>] ?SourceAttribution: string,
            [<Optional; DefaultParameterValue(null)>] ?Type: StyleParam.MapboxLayerType,
            [<Optional; DefaultParameterValue(null)>] ?Coordinates: seq<#IConvertible * #IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Below: string,
            [<Optional; DefaultParameterValue(null)>] ?Color: Color,
            [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
            [<Optional; DefaultParameterValue(null)>] ?MinZoom: float,
            [<Optional; DefaultParameterValue(null)>] ?MaxZoom: float,
            [<Optional; DefaultParameterValue(null)>] ?CircleRadius: float,
            [<Optional; DefaultParameterValue(null)>] ?Line: Line,
            [<Optional; DefaultParameterValue(null)>] ?FillOutlineColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?Symbol: MapboxLayerSymbol,
            [<Optional; DefaultParameterValue(null)>] ?Name: string
        ) =
        MapboxLayer()
        |> MapboxLayer.style (
            ?Visible = Visible,
            ?SourceType = SourceType,
            ?Source = Source,
            ?SourceLayer = SourceLayer,
            ?SourceAttribution = SourceAttribution,
            ?Type = Type,
            ?Coordinates = Coordinates,
            ?Below = Below,
            ?Color = Color,
            ?Opacity = Opacity,
            ?MinZoom = MinZoom,
            ?MaxZoom = MaxZoom,
            ?CircleRadius = CircleRadius,
            ?Line = Line,
            ?FillOutlineColor = FillOutlineColor,
            ?Symbol = Symbol,
            ?Name = Name
        )

    /// <summary>Create a function that applies the given style parameters to a MapboxLayer object.</summary>

    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?Visible: bool,
            [<Optional; DefaultParameterValue(null)>] ?SourceType: StyleParam.MapboxLayerSourceType,
            [<Optional; DefaultParameterValue(null)>] ?Source: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?SourceLayer: string,
            [<Optional; DefaultParameterValue(null)>] ?SourceAttribution: string,
            [<Optional; DefaultParameterValue(null)>] ?Type: StyleParam.MapboxLayerType,
            [<Optional; DefaultParameterValue(null)>] ?Coordinates: seq<#IConvertible * #IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Below: string,
            [<Optional; DefaultParameterValue(null)>] ?Color: Color,
            [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
            [<Optional; DefaultParameterValue(null)>] ?MinZoom: float,
            [<Optional; DefaultParameterValue(null)>] ?MaxZoom: float,
            [<Optional; DefaultParameterValue(null)>] ?CircleRadius: float,
            [<Optional; DefaultParameterValue(null)>] ?Line: Line,
            [<Optional; DefaultParameterValue(null)>] ?FillOutlineColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?Symbol: MapboxLayerSymbol,
            [<Optional; DefaultParameterValue(null)>] ?Name: string
        ) =
        fun (mapBoxLayer: MapboxLayer) ->

            let circle =
                CircleRadius
                |> Option.map (fun r ->
                    DynamicObj() |> DynObj.withProperty "radius" r
                )

            let fill =
                FillOutlineColor
                |> Option.map (fun c ->
                    DynamicObj() |> DynObj.withProperty "outlinecolor" c
                )

            mapBoxLayer
            |> DynObj.withOptionalProperty   "visible"           Visible           
            |> DynObj.withOptionalPropertyBy "sourcetype"        SourceType        StyleParam.MapboxLayerSourceType.convert
            |> DynObj.withOptionalProperty   "source"            Source            
            |> DynObj.withOptionalProperty   "sourcelayer"       SourceLayer       
            |> DynObj.withOptionalProperty   "sourceattribution" SourceAttribution 
            |> DynObj.withOptionalPropertyBy "type"              Type              StyleParam.MapboxLayerType.convert
            |> DynObj.withOptionalProperty   "coordinates"       Coordinates       
            |> DynObj.withOptionalProperty   "below"             Below             
            |> DynObj.withOptionalProperty   "color"             Color             
            |> DynObj.withOptionalProperty   "opacity"           Opacity           
            |> DynObj.withOptionalProperty   "minzoom"           MinZoom           
            |> DynObj.withOptionalProperty   "maxzoom"           MaxZoom           
            |> DynObj.withOptionalProperty   "circle"            circle            
            |> DynObj.withOptionalProperty   "line"              Line              
            |> DynObj.withOptionalProperty   "fill"              fill              
            |> DynObj.withOptionalProperty   "symbol"            Symbol            
            |> DynObj.withOptionalProperty   "name"              Name              
