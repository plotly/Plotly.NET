namespace Plotly.NET

open System


/// Line type inherits from dynamic object
type Line () =
    inherit DynamicObj ()

    /// Initialized Line object
    static member init
        (
            ?Width,
            ?Color,
            ?Shape:StyleParam.Shape,
            ?Dash,
            ?Smoothing,
            ?Colorscale:StyleParam.Colorscale,
            ?OutlierColor,
            ?OutlierWidth

        ) =
            Line () 
            |> Line.style
                (
                    ?Color      = Color     ,
                    ?Width      = Width     ,
                    ?Shape      = Shape     ,
                    ?Smoothing  = Smoothing ,
                    ?Dash       = Dash      ,
                    ?Colorscale = Colorscale,
                    ?OutlierColor = OutlierColor,
                    ?OutlierWidth = OutlierWidth
                )


    // Applies the styles to Line()
    static member style
        (
            ?Width,
            ?Color,
            ?Shape:StyleParam.Shape,
            ?Dash,
            ?Smoothing,
            ?Colorscale:StyleParam.Colorscale,
            ?OutlierColor,
            ?OutlierWidth

        ) =
            (fun (line:Line) -> 
                Color          |> DynObj.setValueOpt   line "color"
                Width          |> DynObj.setValueOpt   line "width"
                Shape          |> DynObj.setValueOptBy line "shape" StyleParam.Shape.convert
                Smoothing      |> DynObj.setValueOpt   line "smoothing"
                Dash           |> DynObj.setValueOptBy line "dash" StyleParam.DrawingStyle.convert
                Colorscale     |> DynObj.setValueOptBy line "colorscale" StyleParam.Colorscale.convert
                OutlierColor   |> DynObj.setValueOpt   line "outliercolor"
                OutlierWidth   |> DynObj.setValueOpt   line "outlierwidth"
                    
                // out -> 
                line
            )



               