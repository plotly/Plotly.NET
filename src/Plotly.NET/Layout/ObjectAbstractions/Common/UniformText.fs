namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

type UniformText() =
    inherit ImmutableDynamicObj ()

    static member init
        (    
            [<Optional;DefaultParameterValue(null)>] ?MinSize: int,
            [<Optional;DefaultParameterValue(null)>] ?Mode:StyleParam.UniformTextMode
        ) =    
            UniformText()
            |> UniformText.style
                (
                    ?MinSize    = MinSize,
                    ?Mode       = Mode
                )

    static member style
        (    
           [<Optional;DefaultParameterValue(null)>] ?MinSize : int,
           [<Optional;DefaultParameterValue(null)>] ?Mode    : StyleParam.UniformTextMode
        ) =
            (fun (uniformText:UniformText) -> 
               
                MinSize |> DynObj.setValueOpt uniformText "minsize"
                Mode    |> DynObj.setValueOptBy uniformText "mode" StyleParam.UniformTextMode.convert

                uniformText
            )