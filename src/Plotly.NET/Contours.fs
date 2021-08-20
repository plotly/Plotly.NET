namespace Plotly.NET

open DynamicObj

type ContourProject () =
    inherit DynamicObj () 

    static member init 
        (
            ?X: bool,
            ?Y: bool,
            ?Z: bool
        ) =
            ContourProject()
            |> ContourProject.style
                (
                    ?X   = X,
                    ?Y   = Y,
                    ?Z   = Z
                )

    static member style
        (
           ?X: bool,
           ?Y: bool,
           ?Z: bool
        ) =

            fun (contourProject: ContourProject) ->
                
                X   |> DynObj.setValueOpt contourProject "x"
                Y   |> DynObj.setValueOpt contourProject "y"
                Z   |> DynObj.setValueOpt contourProject "z"

                contourProject

/// Contour object inherits from dynamic object
type Contour () =
    inherit DynamicObj ()

    /// Initialized a Contour object
    //[<CompiledName("init")>]
    static member init 
        (
            ?Color          : string,
            ?End            : float,
            ?Highlight      : bool,
            ?HighlightColor : string ,
            ?HighlightWidth : float,
            ?Project        : ContourProject,
            ?Show           : bool,
            ?Size           : float,
            ?Start          : float,
            ?UseColorMap    : bool,
            ?Width          : float
        ) =
            Contour ()
            |> Contour.style
                (
                    ?Color          = Color         ,
                    ?End            = End           ,
                    ?Highlight      = Highlight     ,
                    ?HighlightColor = HighlightColor,
                    ?HighlightWidth = HighlightWidth,
                    ?Project        = Project       ,
                    ?Show           = Show          ,
                    ?Size           = Size          ,
                    ?Start          = Start         ,
                    ?UseColorMap    = UseColorMap   ,
                    ?Width          = Width         
                )


    // Applies the styles to Contours()
    //[<CompiledName("style")>]
    static member style
        (
            ?Color          : string,
            ?End            : float,
            ?Highlight      : bool,
            ?HighlightColor : string ,
            ?HighlightWidth : float,
            ?Project        : ContourProject,
            ?Show           : bool,
            ?Size           : float,
            ?Start          : float,
            ?UseColorMap    : bool,
            ?Width          : float
        ) =
            
            (fun (contour:Contour) -> 
                Color            |> DynObj.setValueOpt contour "color"
                End              |> DynObj.setValueOpt contour "end"
                Highlight        |> DynObj.setValueOpt contour "highlight"
                HighlightColor   |> DynObj.setValueOpt contour "highlightcolor"
                HighlightWidth   |> DynObj.setValueOpt contour "highlightwidth"
                Project          |> DynObj.setValueOpt contour "project"
                Show             |> DynObj.setValueOpt contour "show"
                Size             |> DynObj.setValueOpt contour "size"
                Start            |> DynObj.setValueOpt contour "start"
                UseColorMap      |> DynObj.setValueOpt contour "usecolormap"
                Width            |> DynObj.setValueOpt contour "width"
               

                contour
            )

/// Contours type inherits from dynamic object
type Contours () =
    inherit DynamicObj ()

    /// Initialized Contours object
    //[<CompiledName("init")>]
    static member init 
        (
            ?X : Contour,
            ?Y : Contour,
            ?Z : Contour
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
            ?Color          : string,
            ?End            : float,
            ?Highlight      : bool,
            ?HighlightColor : string ,
            ?HighlightWidth : float,
            ?Project        : ContourProject,
            ?Show           : bool,
            ?Size           : float,
            ?Start          : float,
            ?UseColorMap    : bool,
            ?Width          : float
                
        ) =
            Contours () 
            |> Contours.styleXyz
                (
                    ?Color          = Color         ,
                    ?End            = End           ,
                    ?Highlight      = Highlight     ,
                    ?HighlightColor = HighlightColor,
                    ?HighlightWidth = HighlightWidth,
                    ?Project        = Project       ,
                    ?Show           = Show          ,
                    ?Size           = Size          ,
                    ?Start          = Start         ,
                    ?UseColorMap    = UseColorMap   ,
                    ?Width          = Width         
                )

    // Applies the styles to Contours()
    //[<CompiledName("styleXyz")>]
    static member styleXyz
        (
            ?Color          : string,
            ?End            : float,
            ?Highlight      : bool,
            ?HighlightColor : string ,
            ?HighlightWidth : float,
            ?Project        : ContourProject,
            ?Show           : bool,
            ?Size           : float,
            ?Start          : float,
            ?UseColorMap    : bool,
            ?Width          : float
                
        ) =
            
            (fun (contours: Contours) -> 
                let xyzContour =
                    Contour.init (
                        ?Show=Show,
                        ?Color=Color,
                        ?UseColorMap=UseColorMap, 
                        ?Width=Width, 
                        ?Highlight=Highlight, 
                        ?HighlightColor=HighlightColor, 
                        ?HighlightWidth=HighlightWidth, 
                        ?Project = Project
                    ) 
                contours 
                |> Contours.style(X=xyzContour,Y=xyzContour,Z=xyzContour)
            )



