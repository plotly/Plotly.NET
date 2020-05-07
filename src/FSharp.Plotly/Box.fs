namespace FSharp.Plotly

open System


/// Box type inherits from dynamic object (parent violin)
type Box () =
    inherit DynamicObj ()

    /// Initialized Line object
    static member init
        (            
            ?Visible   :bool,
            ?Width     :float,
            ?FillColor,
            ?Line      :Line
        ) =
            Box () 
            |> Box.style
                (
                    ?Visible   = Visible,
                    ?Width     = Width,
                    ?FillColor = FillColor,
                    ?Line      = Line           
                )


    // Applies the styles to Line()
    static member style
        (
            ?Visible   :bool,
            ?Width     :float,
            ?FillColor :Colors.Color,
            ?Line      :Line
        ) =
            (fun (box:Box) -> 
                Visible    |> DynObj.setValueOpt box "visible"
                Width      |> DynObj.setValueOpt box "width"
                FillColor  |> DynObj.setValueOpt box "fillColor"
                Line       |> DynObj.setValueOpt box "line"
                    
                // out -> 
                box
            )



               