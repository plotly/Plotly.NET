namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System

type ActiveShape() =
    inherit DynamicObj ()

    static member init
        (    
            ?FillColor  : string,
            ?Opacity    : float
        ) =    
            ActiveShape()
            |> ActiveShape.style
                (
                  ?FillColor = FillColor,
                  ?Opacity   = Opacity  
                )

    static member style
        (    
           ?FillColor  : string,
           ?Opacity    : float
        ) =
            (fun (activeShape:ActiveShape) -> 
               
                FillColor   |> DynObj.setValueOpt activeShape "fillcolor"
                Opacity     |> DynObj.setValueOpt activeShape "opacity"

                activeShape
            )