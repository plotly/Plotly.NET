namespace FSharp.Plotly

/// Font type inherits from dynamic object
type Font () =
    inherit DynamicObj ()


[<CompilationRepresentationAttribute(CompilationRepresentationFlags.ModuleSuffix)>]
module Font =

    /// Init Font type
    let init (applyStyle:Font->Font) = 
        Font() |> applyStyle

    /// 
    type FontStyle =

        // Applies the styles to Font()
        static member Apply
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
                    Color        |> DynObj.setValueOpt font "color"
                    Familysrc    |> DynObj.setValueOpt font "familysrc"
                    Sizesrc      |> DynObj.setValueOpt font "sizesrc"
                    Colorsrc     |> DynObj.setValueOpt font "colorsrc"
                        
                    // out ->
                    font
                )   

        // static member Init 
        //     (    
        //         ?Family: StyleParam.FontFamily,
        //         ?Size,
        //         ?Color,
        //         ?Familysrc,
        //         ?Sizesrc,
        //         ?Colorsrc
        //     ) = 
        //         (
        //             let font = Font() 
                    
        //             Family       |> DynObj.setValueOptBy font "family" StyleParam.FontFamily.toString                
        //             Size         |> DynObj.setValueOpt font "size"
        //             Color        |> DynObj.setValueOpt font "color"
        //             Familysrc    |> DynObj.setValueOpt font "familysrc"
        //             Sizesrc      |> DynObj.setValueOpt font "sizesrc"
        //             Colorsrc     |> DynObj.setValueOpt font "colorsrc"
                        
        //             // out ->
        //             font
        //         )   


