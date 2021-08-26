namespace Plotly.NET

open System.Runtime.InteropServices
open DynamicObj
open System

/// Line type inherits from dynamic object
type Line () =
    inherit DynamicObj ()

    /// Initialized Line object
    static member init
        (
            [<Optional;DefaultParameterValue(null)>] ?Width:float,
            [<Optional;DefaultParameterValue(null)>] ?Color:string,
            [<Optional;DefaultParameterValue(null)>] ?Shape:StyleParam.Shape,
            [<Optional;DefaultParameterValue(null)>] ?Dash:StyleParam.DrawingStyle,
            [<Optional;DefaultParameterValue(null)>] ?Smoothing:float,
            [<Optional;DefaultParameterValue(null)>] ?Colorscale:StyleParam.Colorscale,
            [<Optional;DefaultParameterValue(null)>] ?OutlierColor:string,
            [<Optional;DefaultParameterValue(null)>] ?OutlierWidth:float

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
            [<Optional;DefaultParameterValue(null)>] ?Width:float,
            [<Optional;DefaultParameterValue(null)>] ?Color:string,
            [<Optional;DefaultParameterValue(null)>] ?Shape:StyleParam.Shape,
            [<Optional;DefaultParameterValue(null)>] ?Dash:StyleParam.DrawingStyle,
            [<Optional;DefaultParameterValue(null)>] ?Smoothing:float,
            [<Optional;DefaultParameterValue(null)>] ?Colorscale:StyleParam.Colorscale,
            [<Optional;DefaultParameterValue(null)>] ?OutlierColor:string,
            [<Optional;DefaultParameterValue(null)>] ?OutlierWidth:float

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



               