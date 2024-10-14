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

            transition
            |> DynObj.withOptionalProperty "duration" Duration
            |> DynObj.withOptionalPropertyBy "easing" Easing StyleParam.TransitionEasing.convert
            |> DynObj.withOptionalPropertyBy "ordering" Ordering StyleParam.TransitionOrdering.convert

        )
