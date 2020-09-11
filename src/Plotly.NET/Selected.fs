namespace Plotly.NET

open System


/// Selected type inherits from dynamic object
type Selected () =
    inherit DynamicObj ()

    /// Initialized Line object
    static member init
        (
            ?Marker
        ) =
            Selected () 
            |> Selected.style
                (
                    ?Marker      = Marker
                )


    // Applies the styles to Line()
    static member style
        (
            ?Marker
        ) =
            (fun (seletion:Selected) -> 
                Marker      |> DynObj.setValueOpt seletion "marker"                
                    
                // out -> 
                seletion
            )


// +++
// +++

/// Selected type inherits from dynamic object
type UnSelected () =
    inherit DynamicObj ()

    /// Initialized Line object
    static member init
        (
            ?Marker
        ) =
            UnSelected () 
            |> UnSelected.style
                (
                    ?Marker      = Marker
                )


    // Applies the styles to Line()
    static member style
        (
            ?Marker
        ) =
            (fun (seletion:UnSelected) -> 
                Marker      |> DynObj.setValueOpt seletion "marker"                
                    
                // out -> 
                seletion
            )

               