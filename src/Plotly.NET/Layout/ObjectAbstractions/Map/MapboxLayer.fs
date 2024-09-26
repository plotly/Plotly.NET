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
        (fun (mapBoxLayer: MapboxLayer) ->

            Visible |> DynObj.setOptionalProperty mapBoxLayer "visible"
            SourceType |> DynObj.setOptionalPropertyBy mapBoxLayer "sourcetype" StyleParam.MapboxLayerSourceType.convert
            Source |> DynObj.setOptionalProperty mapBoxLayer "source"
            SourceLayer |> DynObj.setOptionalProperty mapBoxLayer "sourcelayer"
            SourceAttribution |> DynObj.setOptionalProperty mapBoxLayer "sourceattribution"
            Type |> DynObj.setOptionalPropertyBy mapBoxLayer "type" StyleParam.MapboxLayerType.convert
            Coordinates |> DynObj.setOptionalProperty mapBoxLayer "coordinates"
            Below |> DynObj.setOptionalProperty mapBoxLayer "below"
            Color |> DynObj.setOptionalProperty mapBoxLayer "color"
            Opacity |> DynObj.setOptionalProperty mapBoxLayer "opacity"
            MinZoom |> DynObj.setOptionalProperty mapBoxLayer "minzoom"
            MaxZoom |> DynObj.setOptionalProperty mapBoxLayer "maxzoom"

            CircleRadius
            |> Option.map (fun r ->
                let circle = DynamicObj()
                circle?radius <- r
                circle)
            |> DynObj.setOptionalProperty mapBoxLayer "circle"

            Line |> DynObj.setOptionalProperty mapBoxLayer "line"

            FillOutlineColor
            |> Option.map (fun c ->
                let fill = DynamicObj()
                fill?outlinecolor <- c
                fill)
            |> DynObj.setOptionalProperty mapBoxLayer "fill"

            Symbol |> DynObj.setOptionalProperty mapBoxLayer "symbol"
            Name |> DynObj.setOptionalProperty mapBoxLayer "name"

            mapBoxLayer)
