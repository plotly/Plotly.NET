namespace FSharp.Plotly

/// Font type inherits from dynamic object
type Font () =
    inherit DynamicObj ()

    /// Init Font()
    static member  init (applyStyle:Font->Font) = 
        Font() |> applyStyle


    // Applies the styles to Font()
    static member Style
        (    
            ?Family: StyleParam.FontFamily,
            ?Size,
            ?Color,
            ?Familysrc,
            ?Sizesrc,
            ?Colorsrc
        ) =
            (fun (font:Font) -> 
                    
                Family       |> DynObj.setValueOptBy font "family" StyleParam.FontFamily.toString                
                Size         |> DynObj.setValueOpt   font "size"
                Color        |> DynObj.setValueOpt   font "color"
                Familysrc    |> DynObj.setValueOpt   font "familysrc"
                Sizesrc      |> DynObj.setValueOpt   font "sizesrc"
                Colorsrc     |> DynObj.setValueOpt   font "colorsrc"
                        
                // out ->
                font
            )

