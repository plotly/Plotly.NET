namespace FSharp.Plotly

open System


/// Line type inherits from dynamic object
type Line () =
    inherit DynamicObj ()

    /// Initialized Line object
    static member init (apply:Line->Line) =
        Line () |> apply

    // Applies the styles to Line()
    static member style
        (
            ?Width,
            ?Color,
            ?Shape:StyleParam.Shape,
            ?Dash,
            ?Smoothing,
            ?Colorscale:StyleParam.Colorscale
        ) =
            (fun (line:Line) -> 
                Color      |> DynObj.setValueOpt   line "color"
                Width      |> DynObj.setValueOpt   line "width"
                Shape      |> DynObj.setValueOptBy line "shape" StyleParam.Shape.convert
                Smoothing  |> DynObj.setValueOpt   line "smoothing"
                Dash       |> DynObj.setValueOptBy line "dash" StyleParam.DrawingStyle.toString
                Colorscale |> DynObj.setValueOptBy line "colorscale" StyleParam.Colorscale.convert
                    
                // out -> 
                line
            )



               