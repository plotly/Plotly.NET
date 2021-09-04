namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

/// Scene 
type Scene() = 
    inherit DynamicObj ()

    /// <summary>
    /// Initialize a categorical Scene object that can be used as a laxout anchor for a 3D coordinate system.
    /// </summary>
    /// <param name="Annotations">An annotation is a text element that can be placed anywhere in the plot. It can be positioned with respect to relative coordinates in the plot or with respect to the actual data coordinates of the graph. Annotations can be shown with or without an arrow.</param>
    /// <param name="AspectMode">If "cube", this scene's axes are drawn as a cube, regardless of the axes' ranges. If "data", this scene's axes are drawn in proportion with the axes' ranges. If "manual", this scene's axes are drawn in proportion with the input of "aspectratio" (the default behavior if "aspectratio" is provided). If "auto", this scene's axes are drawn using the results of "data" except when one axis is more than four times the size of the two others, where in that case the results of "cube" are used.</param>
    /// <param name="AspectRatio">Sets this scene's axis aspectratio.</param>
    /// <param name="BGColor">Sets this scene's background color.</param>
    /// <param name="Camera">Sets this scene's camera</param>
    /// <param name="Domain">Sets this scene's domain</param>
    /// <param name="DragMode">Determines the mode of drag interactions for this scene.</param>
    /// <param name="HoverMode">Determines the mode of hover interactions for this scene.</param>
    /// <param name="UIRevision">Controls persistence of user-driven changes in camera attributes. Defaults to `layout.uirevision`.</param>
    /// <param name="XAxis">Sets this scene's xaxis</param>
    /// <param name="YAxis">Sets this scene's yaxis</param>
    /// <param name="ZAxis">Sets this scene's zaxis</param>
    static member init
        (   
            [<Optional;DefaultParameterValue(null)>] ?Annotations    : seq<Annotation>,
            [<Optional;DefaultParameterValue(null)>] ?AspectMode     : StyleParam.AspectMode,
            [<Optional;DefaultParameterValue(null)>] ?AspectRatio    : AspectRatio,
            [<Optional;DefaultParameterValue(null)>] ?BGColor        : Color,
            [<Optional;DefaultParameterValue(null)>] ?Camera         : Camera,
            [<Optional;DefaultParameterValue(null)>] ?Domain         : Domain,           
            [<Optional;DefaultParameterValue(null)>] ?DragMode       : StyleParam.DragMode,
            [<Optional;DefaultParameterValue(null)>] ?HoverMode      : StyleParam.HoverMode,
            [<Optional;DefaultParameterValue(null)>] ?UIRevision     : string,
            [<Optional;DefaultParameterValue(null)>] ?XAxis          : LinearAxis,
            [<Optional;DefaultParameterValue(null)>] ?YAxis          : LinearAxis,
            [<Optional;DefaultParameterValue(null)>] ?ZAxis          : LinearAxis
        ) =
            Scene ()
            |> Scene.style
                (
                    ?Annotations    = Annotations ,
                    ?AspectMode     = AspectMode  ,
                    ?AspectRatio    = AspectRatio ,
                    ?BGColor        = BGColor     ,
                    ?Camera         = Camera      ,
                    ?Domain         = Domain      ,
                    ?DragMode       = DragMode    ,
                    ?HoverMode      = HoverMode   ,
                    ?UIRevision     = UIRevision  ,
                    ?XAxis          = XAxis       ,
                    ?YAxis          = YAxis       ,
                    ?ZAxis          = ZAxis       
                )

    /// <summary>
    /// Creates a function that applies the given style parameters to a Scene object
    /// </summary>
    /// <param name="Annotations">An annotation is a text element that can be placed anywhere in the plot. It can be positioned with respect to relative coordinates in the plot or with respect to the actual data coordinates of the graph. Annotations can be shown with or without an arrow.</param>
    /// <param name="AspectMode">If "cube", this scene's axes are drawn as a cube, regardless of the axes' ranges. If "data", this scene's axes are drawn in proportion with the axes' ranges. If "manual", this scene's axes are drawn in proportion with the input of "aspectratio" (the default behavior if "aspectratio" is provided). If "auto", this scene's axes are drawn using the results of "data" except when one axis is more than four times the size of the two others, where in that case the results of "cube" are used.</param>
    /// <param name="AspectRatio">Sets this scene's axis aspectratio.</param>
    /// <param name="BGColor">Sets this scene's background color.</param>
    /// <param name="Camera">Sets this scene's camera</param>
    /// <param name="Domain">Sets this scene's domain</param>
    /// <param name="DragMode">Determines the mode of drag interactions for this scene.</param>
    /// <param name="HoverMode">Determines the mode of hover interactions for this scene.</param>
    /// <param name="UIRevision">Controls persistence of user-driven changes in camera attributes. Defaults to `layout.uirevision`.</param>
    /// <param name="XAxis">Sets this scene's xaxis</param>
    /// <param name="YAxis">Sets this scene's yaxis</param>
    /// <param name="ZAxis">Sets this scene's zaxis</param>
    static member style
        (   
            [<Optional;DefaultParameterValue(null)>] ?Annotations    : seq<Annotation>,
            [<Optional;DefaultParameterValue(null)>] ?AspectMode     : StyleParam.AspectMode,
            [<Optional;DefaultParameterValue(null)>] ?AspectRatio    : AspectRatio,
            [<Optional;DefaultParameterValue(null)>] ?BGColor        : Color,
            [<Optional;DefaultParameterValue(null)>] ?Camera         : Camera,
            [<Optional;DefaultParameterValue(null)>] ?Domain         : Domain,           
            [<Optional;DefaultParameterValue(null)>] ?DragMode       : StyleParam.DragMode,
            [<Optional;DefaultParameterValue(null)>] ?HoverMode      : StyleParam.HoverMode,
            [<Optional;DefaultParameterValue(null)>] ?UIRevision     : string,
            [<Optional;DefaultParameterValue(null)>] ?XAxis          : LinearAxis,
            [<Optional;DefaultParameterValue(null)>] ?YAxis          : LinearAxis,
            [<Optional;DefaultParameterValue(null)>] ?ZAxis          : LinearAxis
        ) =
            (fun (scene:Scene) -> 

                Annotations |> DynObj.setValueOpt  scene "annotations"
                AspectMode  |> DynObj.setValueOptBy  scene "aspectmode" StyleParam.AspectMode.convert
                AspectRatio |> DynObj.setValueOpt  scene "aspectratio"
                BGColor     |> DynObj.setValueOpt  scene "bgcolor"
                Camera      |> DynObj.setValueOpt  scene "camera"
                Domain      |> DynObj.setValueOpt  scene "domain"
                DragMode    |> DynObj.setValueOptBy  scene "dragmode" StyleParam.DragMode.convert
                HoverMode   |> DynObj.setValueOptBy  scene "hovermode" StyleParam.HoverMode.convert
                UIRevision  |> DynObj.setValueOpt  scene "uirevision"
                XAxis       |> DynObj.setValueOpt  scene "xaxis"
                YAxis       |> DynObj.setValueOpt  scene "yaxis"
                ZAxis       |> DynObj.setValueOpt  scene "zaxis"

                scene
            ) 

