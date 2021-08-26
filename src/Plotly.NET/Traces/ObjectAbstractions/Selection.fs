namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open System
open System.Runtime.InteropServices

type MarkerSelectionStyle() =
    inherit DynamicObj ()

    static member init
        (    
            [<Optional;DefaultParameterValue(null)>] ?Opacity:   float,
            [<Optional;DefaultParameterValue(null)>] ?Color:     string,
            [<Optional;DefaultParameterValue(null)>] ?Size:      float
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
            [<Optional;DefaultParameterValue(null)>] ?Opacity:   float,
            [<Optional;DefaultParameterValue(null)>] ?Color:     string,
            [<Optional;DefaultParameterValue(null)>] ?Size:      float
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
            [<Optional;DefaultParameterValue(null)>] ?Color:     string
        ) =    
            FontSelectionStyle()
            |> FontSelectionStyle.style
                (
                    ?Color  = Color
                )


    // Applies the styles to Font()
    static member style
        (    
            [<Optional;DefaultParameterValue(null)>] ?Color:     string
        ) =
            (fun (fontSelectionStyle:FontSelectionStyle) -> 
                Color |> DynObj.setValueOpt fontSelectionStyle "color" 
            )

type Selection () =
    inherit DynamicObj ()

    static member init
        (    
            [<Optional;DefaultParameterValue(null)>] ?MarkerSelectionStyle: MarkerSelectionStyle,
            [<Optional;DefaultParameterValue(null)>] ?FontSelectionStyle: FontSelectionStyle
        ) =    
            Selection()
            |> Selection.style
                (
                    ?MarkerSelectionStyle   = MarkerSelectionStyle,
                    ?FontSelectionStyle     = FontSelectionStyle
                )

    static member style
        (    
            [<Optional;DefaultParameterValue(null)>] ?MarkerSelectionStyle: MarkerSelectionStyle,
            [<Optional;DefaultParameterValue(null)>] ?FontSelectionStyle: FontSelectionStyle
        ) =
            (fun (selection:Selection) -> 
                MarkerSelectionStyle |> DynObj.setValueOpt selection "marker"
                FontSelectionStyle   |> DynObj.setValueOpt selection "textfont"
                selection
            )
