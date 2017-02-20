namespace FSharp.Plotly



/// Contour object inherits from dynamic object
type Contour () =
    inherit DynamicObj ()

    /// Initialized a Contour object
    //[<CompiledName("init")>]
    static member init (apply:Contour->Contour) =
        Contour () |> apply

    // Applies the styles to Contours()
    //[<CompiledName("style")>]
    static member style
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

/// Contours type inherits from dynamic object
type Contours () =
    inherit DynamicObj ()

    /// Initialized Contours object
    //[<CompiledName("init")>]
    static member init (apply:Contours->Contours) =
        Contours () |> apply

    // Applies the styles to Contours()
    //[<CompiledName("style")>]
    static member style
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
    //[<CompiledName("styleXyz")>]
    static member styleXyz
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
                    Contour.init (Contour.style (?Show=Show,?Color=Color,?Usecolor=Usecolor, ?Width=Width, 
                                    ?Highlight=Highlight, ?Highlightcolor=Highlightcolor, ?Highlightwidth=Highlightwidth)) 
                contours 
                |> Contours.style(X=xyzContour,Y=xyzContour,Z=xyzContour)
            )



