namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open System
open System.Runtime.InteropServices

type Spaceframe() =
    inherit DynamicObj()

    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?Fill: float,
            [<Optional; DefaultParameterValue(null)>] ?Show: bool
        ) =
        Spaceframe() |> Spaceframe.style (?Fill = Fill, ?Show = Show)

    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?Fill: float,
            [<Optional; DefaultParameterValue(null)>] ?Show: bool
        ) =

        fun (spaceframe: Spaceframe) ->

            spaceframe
            |> DynObj.withOptionalProperty "fill" Fill
            |> DynObj.withOptionalProperty "show" Show
