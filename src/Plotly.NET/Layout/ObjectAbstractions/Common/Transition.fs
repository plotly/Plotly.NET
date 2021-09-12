namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open DynamicObj.Operators
open System
open System.Runtime.InteropServices

type Transition() =
    inherit ImmutableDynamicObj ()

    static member init
        (    
            [<Optional;DefaultParameterValue(null)>] ?Duration   : int,
            [<Optional;DefaultParameterValue(null)>] ?Easing     : StyleParam.TransitionEasing,
            [<Optional;DefaultParameterValue(null)>] ?Ordering   : StyleParam.TransitionOrdering
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
            [<Optional;DefaultParameterValue(null)>] ?Duration: int,
            [<Optional;DefaultParameterValue(null)>] ?Easing: StyleParam.TransitionEasing,
            [<Optional;DefaultParameterValue(null)>] ?Ordering: StyleParam.TransitionOrdering
        ) =
            (fun (transition:Transition) -> 
               
                transition
               
                ++? ("duration", Duration)
                ++?? ("easing", Easing, StyleParam.TransitionEasing.convert)
                ++?? ("ordering", Ordering, StyleParam.TransitionOrdering.convert)
            )