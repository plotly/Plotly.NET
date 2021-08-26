namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

type ActiveShape() =
    inherit DynamicObj ()

    static member init
        (    
            [<Optional;DefaultParameterValue(null)>] ?FillColor  : string,
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
           [<Optional;DefaultParameterValue(null)>] ?FillColor  : string,
           [<Optional;DefaultParameterValue(null)>] ?Opacity    : float
        ) =
            (fun (activeShape:ActiveShape) -> 
               
                FillColor   |> DynObj.setValueOpt activeShape "fillcolor"
                Opacity     |> DynObj.setValueOpt activeShape "opacity"

                activeShape
            )