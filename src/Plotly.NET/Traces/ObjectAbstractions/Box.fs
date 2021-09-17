namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open DynamicObj.Operators
open System
open System.Runtime.InteropServices

/// Box type inherits from dynamic object (parent violin)
type Box () =
    inherit ImmutableDynamicObj ()

    /// Initialized Line object
    static member init
        (            
            [<Optional;DefaultParameterValue(null)>] ?Visible: bool,
            [<Optional;DefaultParameterValue(null)>] ?Width: float,
            [<Optional;DefaultParameterValue(null)>] ?FillColor: Color,
            [<Optional;DefaultParameterValue(null)>] ?Line: Line
        ) =
            Box () 
            |> Box.style
                (
                    ?Visible   = Visible,
                    ?Width     = Width,
                    ?FillColor = FillColor,
                    ?Line      = Line           
                )


    // Applies the styles to Line()
    static member style
        (
            [<Optional;DefaultParameterValue(null)>] ?Visible: bool,
            [<Optional;DefaultParameterValue(null)>] ?Width: float,
            [<Optional;DefaultParameterValue(null)>] ?FillColor: Color,
            [<Optional;DefaultParameterValue(null)>] ?Line: Line
        ) =
            (fun (box:Box) -> 
                    
                // out -> 
                box
                ++? ("visible", Visible    )
                ++? ("width", Width      )
                ++? ("fillColor", FillColor  )
                ++? ("line", Line       )
            )



               