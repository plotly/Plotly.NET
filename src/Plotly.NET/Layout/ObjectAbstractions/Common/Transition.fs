namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System

type Transition() =
    inherit DynamicObj ()

    static member init
        (    
            ?Duration   : int,
            ?Easing     : StyleParam.TransitionEasing,
            ?Ordering   : StyleParam.TransitionOrdering
        ) =    
            Transition()
            |> Transition.style
                (
                    ?Duration   = Duration,
                    ?Easing     = Easing  ,
                    ?Ordering   = Ordering
                )

    static member style
        (    
            ?Duration: int,
            ?Easing: StyleParam.TransitionEasing,
            ?Ordering: StyleParam.TransitionOrdering
        ) =
            (fun (transition:Transition) -> 
               
                Duration    |> DynObj.setValueOpt transition "duration"
                Easing      |> DynObj.setValueOptBy transition "easing" StyleParam.TransitionEasing.convert
                Ordering    |> DynObj.setValueOptBy transition "ordering" StyleParam.TransitionOrdering.convert
               
                transition
            )