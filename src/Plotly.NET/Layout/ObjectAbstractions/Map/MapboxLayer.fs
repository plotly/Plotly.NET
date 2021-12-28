namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open DynamicObj.Operators
open System
open System.Runtime.InteropServices

/// <summary></summary>
type MapboxLayer() =

    inherit ImmutableDynamicObj()

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

            CircleRadius

            ++? ("visible", Visible )
            ++?? ("sourcetype", SourceType , StyleParam.MapboxLayerSourceType.convert)
            ++? ("source", Source )
            ++? ("sourcelayer", SourceLayer )
            ++? ("sourceattribution", SourceAttribution )
            ++?? ("type", Type , StyleParam.MapboxLayerType.convert)
            ++? ("coordinates", Coordinates )
            ++? ("below", Below )
            ++? ("color", Color )
            ++? ("opacity", Opacity )
            ++? ("minzoom", MinZoom )
            ++? ("maxzoom", MaxZoom )
            |> Option.map
                (fun r ->
                    let circle = ImmutableDynamicObj()
                    circle?radius <- r

            FillOutlineColor
                    ++? ("circle", circle))

            ++? ("line", Line )
            |> Option.map
                (fun c ->
                    let fill = ImmutableDynamicObj()
                    fill?outlinecolor <- c

            mapBoxLayer
                    ++? ("fill", fill))

            ++? ("symbol", Symbol )
            ++? ("name", Name ))
