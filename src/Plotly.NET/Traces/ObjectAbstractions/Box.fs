namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open System
open System.Runtime.InteropServices

/// Box type inherits from dynamic object (parent violin)
type Box () =
    inherit DynamicObj ()

    /// Initialized Line object
    static member init
        (            
            [<Optional;DefaultParameterValue(null)>] ?Visible: bool,
            [<Optional;DefaultParameterValue(null)>] ?Width: float,
            [<Optional;DefaultParameterValue(null)>] ?FillColor: Color,
            [<Optional;DefaultParameterValue(null)>] ?LineColor: Color,
            [<Optional;DefaultParameterValue(null)>] ?LineWidth: float
        ) =
            Box () 
            |> Box.style
                (
                    ?Visible    = Visible,
                    ?Width      = Width,
                    ?FillColor  = FillColor,
                    ?LineColor  = LineColor,
                    ?LineWidth  = LineWidth
                )


    // Applies the styles to Line()
    static member style
        (
            [<Optional;DefaultParameterValue(null)>] ?Visible: bool,
            [<Optional;DefaultParameterValue(null)>] ?Width: float,
            [<Optional;DefaultParameterValue(null)>] ?FillColor: Color,
            [<Optional;DefaultParameterValue(null)>] ?LineColor: Color,
            [<Optional;DefaultParameterValue(null)>] ?LineWidth: float
        ) =
            (fun (box:Box) -> 

                let line = 
                    if LineColor.IsSome || LineWidth.IsSome then
                        Some (Line.init(?Color = LineColor, ?Width = LineWidth))
                    else None

                Visible    |> DynObj.setValueOpt box "visible"
                Width      |> DynObj.setValueOpt box "width"
                FillColor  |> DynObj.setValueOpt box "fillColor"
                line       |> DynObj.setValueOpt box "line"
                    
                // out -> 
                box
            )



               