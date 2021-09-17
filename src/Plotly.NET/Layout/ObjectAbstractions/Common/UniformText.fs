namespace Plotly.NET.LayoutObjects

open Plotly.NET
OHNONONO
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

                uniformText
               
                ++? ("minsize", MinSize )
                ++?? ("mode", Mode    , StyleParam.UniformTextMode.convert)
            )