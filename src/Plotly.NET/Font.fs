namespace Plotly.NET

open DynamicObj

/// Font type inherits from dynamic object
type Font () =
    inherit DynamicObj ()

    /// Init Font()
    static member init
        (    
            ?Family    ,
            ?Size      ,
            ?Color     
        ) =    
            Font()
            |> Font.style
                (
                    ?Family    = Family    ,
                    ?Size      = Size      ,
                    ?Color     = Color     
                )


    // Applies the styles to Font()
    static member style
        (    
            ?Family: StyleParam.FontFamily,
            ?Size: float,
            ?Color: string
        ) =
            (fun (font:Font) -> 
                    
                Family       |> DynObj.setValueOptBy font "family" StyleParam.FontFamily.toString                
                Size         |> DynObj.setValueOpt   font "size"
                Color        |> DynObj.setValueOpt   font "color"
                        
                font
            )

