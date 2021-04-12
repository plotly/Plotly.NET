namespace Plotly.NET

open System


/// Meanline type inherits from dynamic object (parent violin)
type Meanline () =
    inherit DynamicObj ()

    /// Initialized Line object
    static member init
        (
            ?Visible: bool,
            ?Color: string,
            ?Width: float
        ) =
            Meanline () 
            |> Meanline.style
                (
                    ?Visible    = Visible,
                    ?Color      = Color  ,
                    ?Width      = Width             
                )


    // Applies the styles to Line()
    static member style
        (
            ?Visible: bool,
            ?Color: string,
            ?Width: float
        ) =
            (fun (line:Meanline) -> 
                Visible    |> DynObj.setValueOpt line "visible"
                Color      |> DynObj.setValueOpt line "color"
                Width      |> DynObj.setValueOpt line "width"
                    
                // out -> 
                line
            )



               