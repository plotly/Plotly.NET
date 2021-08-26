namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

/// <summary></summary>
type MapboxLayer() = 

    inherit DynamicObj ()

    /// <summary>Initialize a MapboxLayer object</summary>

    static member init
        (   
            [<Optional;DefaultParameterValue(null)>] ?Visible: bool,
            [<Optional;DefaultParameterValue(null)>] ?SourceType: StyleParam.MapboxLayerSourceType,
            [<Optional;DefaultParameterValue(null)>] ?Source: #IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?SourceLayer: string,
            [<Optional;DefaultParameterValue(null)>] ?SourceAttribution: string,
            [<Optional;DefaultParameterValue(null)>] ?Type: StyleParam.MapboxLayerType,
            [<Optional;DefaultParameterValue(null)>] ?Coordinates:seq<#IConvertible*#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?Below: string,
            [<Optional;DefaultParameterValue(null)>] ?Color: string,
            [<Optional;DefaultParameterValue(null)>] ?Opacity: float,
            [<Optional;DefaultParameterValue(null)>] ?MinZoom:float,
            [<Optional;DefaultParameterValue(null)>] ?MaxZoom:float,
            [<Optional;DefaultParameterValue(null)>] ?CircleRadius: float,
            [<Optional;DefaultParameterValue(null)>] ?Line:Line,
            [<Optional;DefaultParameterValue(null)>] ?FillOutlineColor:string,
            [<Optional;DefaultParameterValue(null)>] ?Symbol:MapboxLayerSymbol,
            [<Optional;DefaultParameterValue(null)>] ?Name: string
        ) =
            MapboxLayer()
            |> MapboxLayer.style
                (
                    ?Visible            = Visible          ,
                    ?SourceType         = SourceType       ,
                    ?Source             = Source           ,
                    ?SourceLayer        = SourceLayer      ,
                    ?SourceAttribution  = SourceAttribution,
                    ?Type               = Type             ,
                    ?Coordinates        = Coordinates      ,
                    ?Below              = Below            ,
                    ?Color              = Color            ,
                    ?Opacity            = Opacity          ,
                    ?MinZoom            = MinZoom          ,
                    ?MaxZoom            = MaxZoom          ,
                    ?CircleRadius       = CircleRadius     ,
                    ?Line               = Line             ,
                    ?FillOutlineColor   = FillOutlineColor ,
                    ?Symbol             = Symbol           ,
                    ?Name               = Name             
                )

    /// <summary>Create a function that applies the given style parameters to a MapboxLayer object.</summary>

    static member style
        (   
            [<Optional;DefaultParameterValue(null)>] ?Visible: bool,
            [<Optional;DefaultParameterValue(null)>] ?SourceType: StyleParam.MapboxLayerSourceType,
            [<Optional;DefaultParameterValue(null)>] ?Source: #IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?SourceLayer: string,
            [<Optional;DefaultParameterValue(null)>] ?SourceAttribution: string,
            [<Optional;DefaultParameterValue(null)>] ?Type: StyleParam.MapboxLayerType,
            [<Optional;DefaultParameterValue(null)>] ?Coordinates:seq<#IConvertible*#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?Below: string,
            [<Optional;DefaultParameterValue(null)>] ?Color: string,
            [<Optional;DefaultParameterValue(null)>] ?Opacity: float,
            [<Optional;DefaultParameterValue(null)>] ?MinZoom:float,
            [<Optional;DefaultParameterValue(null)>] ?MaxZoom:float,
            [<Optional;DefaultParameterValue(null)>] ?CircleRadius: float,
            [<Optional;DefaultParameterValue(null)>] ?Line:Line,
            [<Optional;DefaultParameterValue(null)>] ?FillOutlineColor:string,
            [<Optional;DefaultParameterValue(null)>] ?Symbol:MapboxLayerSymbol,
            [<Optional;DefaultParameterValue(null)>] ?Name: string

        ) =
            (fun (mapBoxLayer:MapboxLayer) -> 

                Visible          |> DynObj.setValueOpt mapBoxLayer "visible"
                SourceType       |> DynObj.setValueOptBy mapBoxLayer "sourcetype" StyleParam.MapboxLayerSourceType.convert
                Source           |> DynObj.setValueOpt mapBoxLayer "source"
                SourceLayer      |> DynObj.setValueOpt mapBoxLayer "sourcelayer"
                SourceAttribution|> DynObj.setValueOpt mapBoxLayer "sourceattribution"
                Type             |> DynObj.setValueOptBy mapBoxLayer "type" StyleParam.MapboxLayerType.convert
                Coordinates      |> DynObj.setValueOpt mapBoxLayer "coordinates"
                Below            |> DynObj.setValueOpt mapBoxLayer "below"
                Color            |> DynObj.setValueOpt mapBoxLayer "color"
                Opacity          |> DynObj.setValueOpt mapBoxLayer "opacity"
                MinZoom          |> DynObj.setValueOpt mapBoxLayer "minzoom"
                MaxZoom          |> DynObj.setValueOpt mapBoxLayer "maxzoom"

                CircleRadius     
                |> Option.map(fun r ->
                    let circle = DynamicObj()
                    circle?radius <- r
                    circle
                )
                |> DynObj.setValueOpt mapBoxLayer "circle"

                Line             |> DynObj.setValueOpt mapBoxLayer "line"

                FillOutlineColor
                |> Option.map(fun c ->
                    let fill = DynamicObj()
                    fill?outlinecolor <- c
                    fill
                )
                |> DynObj.setValueOpt mapBoxLayer "fill"

                Symbol           |> DynObj.setValueOpt mapBoxLayer "symbol"
                Name             |> DynObj.setValueOpt mapBoxLayer "name"
                                                       
                mapBoxLayer
            ) 
