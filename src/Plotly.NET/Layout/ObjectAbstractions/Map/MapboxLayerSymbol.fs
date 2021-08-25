namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System

/// <summary></summary>
type MapboxLayerSymbol() = 

    inherit DynamicObj ()

    /// <summary>Initialize a MapboxLayer object</summary>

    static member init
        (   
            ?Icon: string,
            ?IconSize:float,
            ?Text: string,
            ?Placement: StyleParam.MapboxLayerSymbolPlacement,
            ?TextFont: Font,
            ?TextPosition: StyleParam.TextPosition
        ) =
            MapboxLayerSymbol()
            |> MapboxLayerSymbol.style
                (
                    ?Icon           = Icon        ,
                    ?IconSize       = IconSize    ,
                    ?Text           = Text        ,
                    ?Placement      = Placement   ,
                    ?TextFont       = TextFont    ,
                    ?TextPosition   = TextPosition
                )

    /// <summary>Create a function that applies the given style parameters to a MapboxLayer object.</summary>

    static member style
        (   
            ?Icon: string,
            ?IconSize:float,
            ?Text: string,
            ?Placement: StyleParam.MapboxLayerSymbolPlacement,
            ?TextFont: Font,
            ?TextPosition: StyleParam.TextPosition

        ) =
            (fun (mapBoxLayerSymbol:MapboxLayerSymbol) -> 
                
                Icon        |> DynObj.setValueOpt mapBoxLayerSymbol "icon"
                IconSize    |> DynObj.setValueOpt mapBoxLayerSymbol "iconsize"
                Text        |> DynObj.setValueOpt mapBoxLayerSymbol "text"
                Placement   |> DynObj.setValueOptBy mapBoxLayerSymbol "placement" StyleParam.MapboxLayerSymbolPlacement.convert 
                TextFont    |> DynObj.setValueOpt mapBoxLayerSymbol "textfont"
                TextPosition|> DynObj.setValueOptBy mapBoxLayerSymbol "textposition" StyleParam.TextPosition.convert
                

                mapBoxLayerSymbol
            ) 
