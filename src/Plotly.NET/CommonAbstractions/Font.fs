namespace Plotly.NET
open System.Runtime.InteropServices

open DynamicObj

/// Font type inherits from dynamic object
type Font () =
    inherit ImmutableDynamicObj ()

    /// Init Font()
    static member init
        (    
            [<Optional;DefaultParameterValue(null)>] ?Family: StyleParam.FontFamily,
            [<Optional;DefaultParameterValue(null)>] ?Size: float,
            [<Optional;DefaultParameterValue(null)>] ?Color: Color
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
            [<Optional;DefaultParameterValue(null)>] ?Family: StyleParam.FontFamily,
            [<Optional;DefaultParameterValue(null)>] ?Size: float,
            [<Optional;DefaultParameterValue(null)>] ?Color: Color
        ) =
            (fun (font:Font) -> 
                    
                Family       |> DynObj.setValueOptBy font "family" StyleParam.FontFamily.toString                
                Size         |> DynObj.setValueOpt   font "size"
                Color        |> DynObj.setValueOpt   font "color"
                        
                font
            )

