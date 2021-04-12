namespace Plotly.NET



/// Contour object inherits from dynamic object
type Contour () =
    inherit DynamicObj ()

    /// Initialized a Contour object
    //[<CompiledName("init")>]
    static member init 
        (
            ?Show: bool,
            ?Start: float,
            ?End: float,
            ?Size: float,
            ?Color: string,
            ?UseColorMap: bool,
            ?Width: float,
            ?Highlight: bool,
            ?Highlightcolor: string ,
            ?Highlightwidth : float                
        ) =
            Contour ()
            |> Contour.style
                (
                    ?Show           = Show           ,
                    //?Project      = Project        ,
                    ?Color          = Color          ,
                    ?UseColorMap    = UseColorMap    ,
                    ?Width          = Width          ,
                    ?Highlight      = Highlight      ,
                    ?Highlightcolor = Highlightcolor ,
                    ?Highlightwidth = Highlightwidth 
                )


    // Applies the styles to Contours()
    //[<CompiledName("style")>]
    static member style
        (
            ?Show: bool,
            ?Start: float,
            ?End: float,
            ?Size: float,
            ?Color: string,
            ?UseColorMap: bool,
            ?Width: float,
            ?Highlight: bool,
            ?Highlightcolor: string ,
            ?Highlightwidth : float                
        ) =
            
            (fun (contour:Contour) -> 
                Show            |> DynObj.setValueOpt contour "show"
                Color           |> DynObj.setValueOpt contour "color"
                Start           |> DynObj.setValueOpt contour "start"
                End             |> DynObj.setValueOpt contour "end"
                Size            |> DynObj.setValueOpt contour "size"
                UseColorMap     |> DynObj.setValueOpt contour "usecolormap" 
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
    static member init 
        (
            ?X ,
            ?Y ,
            ?Z 
        ) =
            Contours () 
            |> Contours.style
                (
                    ?X =  X,
                    ?Y =  Y,
                    ?Z =  Z
                )

    // Applies the styles to Contours()
    //[<CompiledName("style")>]
    static member style
        (
            ?X : Contour,
            ?Y : Contour,
            ?Z : Contour
        ) =
            
            (fun (contours:Contours) -> 
                X |> DynObj.setValueOpt contours "x"
                Y |> DynObj.setValueOpt contours "y"
                Z |> DynObj.setValueOpt contours "z"
           
                contours
            )


    // Initialized x-y-z-Contours with the same properties    
    static member initXyz
        (
            ?Show           ,
            //?Project      ,
            ?Color,
            ?UseColorMap       ,
            ?Width          ,
            ?Highlight      ,
            ?Highlightcolor ,
            ?Highlightwidth 
                
        ) =
            Contours () 
            |> Contours.styleXyz
                (
                    ?Show=Show                    ,
                    //?Project                      ,
                    ?Color=Color                  ,
                    ?UseColorMap=UseColorMap            ,
                    ?Width=Width                  ,
                    ?Highlight=Highlight          ,
                    ?Highlightcolor=Highlightcolor,
                    ?Highlightwidth=Highlightwidth 
                )

    // Applies the styles to Contours()
    //[<CompiledName("styleXyz")>]
    static member styleXyz
        (
            ?Show           ,
            //?Project      ,
            ?Color,
            ?UseColorMap       ,
            ?Width          ,
            ?Highlight      ,
            ?Highlightcolor ,
            ?Highlightwidth 
                
        ) =
            
            (fun (contours: Contours) -> 
                let xyzContour =
                    Contour.init (?Show=Show,?Color=Color,?UseColorMap=UseColorMap, ?Width=Width, 
                                    ?Highlight=Highlight, ?Highlightcolor=Highlightcolor, ?Highlightwidth=Highlightwidth) 
                contours 
                |> Contours.style(X=xyzContour,Y=xyzContour,Z=xyzContour)
            )



