namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open DynamicObj.Operators
open System
open System.Runtime.InteropServices

type ActiveShape() =
    inherit ImmutableDynamicObj ()

    static member init
        (    
            [<Optional;DefaultParameterValue(null)>] ?FillColor  : Color,
            [<Optional;DefaultParameterValue(null)>] ?Opacity    : float
        ) =    
            ActiveShape()
            |> ActiveShape.style
                (
                  ?FillColor = FillColor,
                  ?Opacity   = Opacity  
                )

    static member style
        (    
           [<Optional;DefaultParameterValue(null)>] ?FillColor  : Color,
           [<Optional;DefaultParameterValue(null)>] ?Opacity    : float
        ) =
            (fun (activeShape:ActiveShape) -> 

                activeShape
               
                ++? ("fillcolor", FillColor)
                ++? ("opacity", Opacity)
            )