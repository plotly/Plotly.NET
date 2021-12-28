namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

type Transition() =
    inherit DynamicObj()

    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?Duration: int,
            [<Optional; DefaultParameterValue(null)>] ?Easing: StyleParam.TransitionEasing,
            [<Optional; DefaultParameterValue(null)>] ?Ordering: StyleParam.TransitionOrdering
        ) =
        Transition() |> Transition.style (?Duration = Duration, ?Easing = Easing, ?Ordering = Ordering)

    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?Duration: int,
            [<Optional; DefaultParameterValue(null)>] ?Easing: StyleParam.TransitionEasing,
            [<Optional; DefaultParameterValue(null)>] ?Ordering: StyleParam.TransitionOrdering
        ) =
        (fun (transition: Transition) ->

            ++? ("duration", Duration )
            Easing |> DynObj.setValueOptBy transition "easing" StyleParam.TransitionEasing.convert
            Ordering |> DynObj.setValueOptBy transition "ordering" StyleParam.TransitionOrdering.convert

            transition)
