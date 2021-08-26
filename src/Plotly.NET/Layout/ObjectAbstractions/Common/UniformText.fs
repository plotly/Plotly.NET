namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System

type UniformText() =
    inherit DynamicObj ()

    static member init
        (    
            ?MinSize: int,
            ?Mode:StyleParam.UniformTextMode
        ) =    
            UniformText()
            |> UniformText.style
                (
                    ?MinSize    = MinSize,
                    ?Mode       = Mode
                )

    static member style
        (    
           ?MinSize : int,
           ?Mode    : StyleParam.UniformTextMode
        ) =
            (fun (uniformText:UniformText) -> 
               
                MinSize |> DynObj.setValueOpt uniformText "minsize"
                Mode    |> DynObj.setValueOptBy uniformText "mode" StyleParam.UniformTextMode.convert

                uniformText
            )