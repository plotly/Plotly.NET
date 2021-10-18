namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open System
open System.Runtime.InteropServices

/// Meanline type inherits from dynamic object (parent violin)
type MeanLine () =
    inherit DynamicObj ()

    /// Initialized Line object
    static member init
        (
            [<Optional;DefaultParameterValue(null)>] ?Visible: bool,
            [<Optional;DefaultParameterValue(null)>] ?Color: Color,
            [<Optional;DefaultParameterValue(null)>] ?Width: float
        ) =
            MeanLine () 
            |> MeanLine.style
                (
                    ?Visible    = Visible,
                    ?Color      = Color  ,
                    ?Width      = Width             
                )


    // Applies the styles to Line()
    static member style
        (
            [<Optional;DefaultParameterValue(null)>] ?Visible: bool,
            [<Optional;DefaultParameterValue(null)>] ?Color: Color,
            [<Optional;DefaultParameterValue(null)>] ?Width: float
        ) =
            (fun (line:MeanLine) -> 
                Visible    |> DynObj.setValueOpt line "visible"
                Color      |> DynObj.setValueOpt line "color"
                Width      |> DynObj.setValueOpt line "width"
                    
                // out -> 
                line
            )



               
