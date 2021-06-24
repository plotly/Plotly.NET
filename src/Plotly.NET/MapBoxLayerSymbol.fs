namespace Plotly.NET

open System

/// <summary></summary>
type MapBoxLayerSymbol() = 

    inherit DynamicObj ()

    /// <summary>Initialize a MapBoxLayer object</summary>

    static member init
        (   
            ?Icon: string,
            ?IconSize:float,
            ?Text: string,
            ?Placement: StyleParam.MapBoxLayerSymbolPlacement,
            ?TextFont: Font,
            ?TextPosition: StyleParam.TextPosition
        ) =
            MapBoxLayerSymbol()
            |> MapBoxLayerSymbol.style
                (
                    ?Icon           = Icon        ,
                    ?IconSize       = IconSize    ,
                    ?Text           = Text        ,
                    ?Placement      = Placement   ,
                    ?TextFont       = TextFont    ,
                    ?TextPosition   = TextPosition
                )

    /// <summary>Create a function that applies the given style parameters to a MapBoxLayer object.</summary>

    static member style
        (   
            ?Icon: string,
            ?IconSize:float,
            ?Text: string,
            ?Placement: StyleParam.MapBoxLayerSymbolPlacement,
            ?TextFont: Font,
            ?TextPosition: StyleParam.TextPosition

        ) =
            (fun (mapBoxLayerSymbol:MapBoxLayerSymbol) -> 
                
                Icon        |> DynObj.setValueOpt mapBoxLayerSymbol "icon"
                IconSize    |> DynObj.setValueOpt mapBoxLayerSymbol "iconsize"
                Text        |> DynObj.setValueOpt mapBoxLayerSymbol "text"
                Placement   |> DynObj.setValueOptBy mapBoxLayerSymbol "placement" StyleParam.MapBoxLayerSymbolPlacement.convert 
                TextFont    |> DynObj.setValueOpt mapBoxLayerSymbol "textfont"
                TextPosition|> DynObj.setValueOptBy mapBoxLayerSymbol "textposition" StyleParam.TextPosition.convert
                

                mapBoxLayerSymbol
            ) 