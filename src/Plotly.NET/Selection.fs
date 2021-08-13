namespace Plotly.NET

open DynamicObj

type MarkerSelectionStyle() =
    inherit DynamicObj ()

    static member init
        (    
            ?Opacity:   float,
            ?Color:     string,
            ?Size:      float
        ) =    
            MarkerSelectionStyle()
            |> MarkerSelectionStyle.style
                (
                    ?Opacity = Opacity,
                    ?Color   = Color,
                    ?Size    = Size
                )

    static member style
        (    
            ?Opacity:   float,
            ?Color:     string,
            ?Size:      float
        ) =
            (fun (markerSelectionStyle:MarkerSelectionStyle) -> 

                Opacity    |> DynObj.setValueOpt markerSelectionStyle "opacity"
                Color      |> DynObj.setValueOpt markerSelectionStyle "color"
                Size       |> DynObj.setValueOpt markerSelectionStyle "size"

                markerSelectionStyle
            )

type FontSelectionStyle() =
    inherit DynamicObj ()

    /// Init Font()
    static member init
        (    
            ?Color:     string
        ) =    
            FontSelectionStyle()
            |> FontSelectionStyle.style
                (
                    ?Color  = Color
                )


    // Applies the styles to Font()
    static member style
        (    
            ?Color:     string
        ) =
            (fun (fontSelectionStyle:FontSelectionStyle) -> 
                Color |> DynObj.setValueOpt fontSelectionStyle "color" 
            )

type Selection () =
    inherit DynamicObj ()

    static member init
        (    
            ?MarkerSelectionStyle: MarkerSelectionStyle,
            ?FontSelectionStyle: FontSelectionStyle
        ) =    
            Selection()
            |> Selection.style
                (
                    ?MarkerSelectionStyle   = MarkerSelectionStyle,
                    ?FontSelectionStyle     = FontSelectionStyle
                )

    static member style
        (    
            ?MarkerSelectionStyle: MarkerSelectionStyle,
            ?FontSelectionStyle: FontSelectionStyle
        ) =
            (fun (selection:Selection) -> 
                MarkerSelectionStyle |> DynObj.setValueOpt selection "marker"
                FontSelectionStyle   |> DynObj.setValueOpt selection "textfont"
                selection
            )
