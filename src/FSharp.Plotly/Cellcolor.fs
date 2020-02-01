namespace FSharp.Plotly

open System

/// CellColor type inherits from dynamic object
type CellColour () =
    inherit DynamicObj ()

    /// Initialized Line object
    static member init
        (
            ?Color
        ) =
            CellColour () 
            |> CellColour.style
                (
                    ?Color      = Color  
                )
    // Applies the styles to CellColour()
    static member style
        (
            ?Color
        ) =
            (fun (cell:CellColour) -> 
                Color      |> DynObj.setValueOpt cell "color" 
                // out -> 
                cell
            )

               