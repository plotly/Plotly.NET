namespace FSharp.Plotly

/// Module containing plotly Contours 
module Contours =

    /// Contours type inherits from dynamic object
    type Contours () =
        inherit DynamicObj ()

    let initContours (applyStyle:Contours->Contours) = 
        Contours() |> applyStyle

    /// Contour type inherits from dynamic object
    type Contour () =
        inherit DynamicObj ()

    let initContour (applyStyle:Contour->Contour) = 
        Contour() |> applyStyle

    type ContoursStyle = 

        // Applies the styles to Contours()
        static member Contours
            (
                ?X : Contour,
                ?Y : Contour,
                ?Z : Contour
            ) =
            
                (fun (contours:('T :> Contours)) -> 
                    X |> DynObj.setValueOpt contours "x"
                    Y |> DynObj.setValueOpt contours "y"
                    Z |> DynObj.setValueOpt contours "z"
           
                    contours
                )


        // Applies the styles to Contours()
        static member Contour
            (
                ?Show           : bool,
                //?Project      : Project,
                ?Color,
                ?Usecolor       : bool,
                ?Width          : int,
                ?Highlight      : bool,
                ?Highlightcolor,
                ?Highlightwidth : int
                
            ) =
            
                (fun (contour:('T :> Contour)) -> 
                    Show            |> DynObj.setValueOpt contour "show"
                    //?Project      |> DynObj.setValueOpt contour "project"
                    Color           |> DynObj.setValueOpt contour "color"
                    Usecolor        |> DynObj.setValueOpt contour "usecolor" 
                    Width           |> DynObj.setValueOpt contour "width"
                    Highlight       |> DynObj.setValueOpt contour "highlight" 
                    Highlightcolor  |> DynObj.setValueOpt contour "highlightcolor"
                    Highlightwidth  |> DynObj.setValueOpt contour "highlightwidth"

                    contour
                )


        // Applies the styles to Contours()
        static member XyzContours
            (
                ?Show           : bool,
                //?Project      : Project,
                ?Color,
                ?Usecolor       : bool,
                ?Width          : int,
                ?Highlight      : bool,
                ?Highlightcolor,
                ?Highlightwidth : int
                
            ) =
            
                (fun (contours:('T :> Contours)) -> 
                    let xyzContour =
                        initContour (ContoursStyle.Contour(?Show=Show,
                            ?Color=Color,?Usecolor=Usecolor, ?Width=Width, 
                            ?Highlight=Highlight, ?Highlightcolor=Highlightcolor, ?Highlightwidth=Highlightwidth)) 
                    contours 
                    |> ContoursStyle.Contours(X=xyzContour,Y=xyzContour,Z=xyzContour)
                )

