namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

type AspectRatio() =

    inherit DynamicObj()

    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?X: float,
            [<Optional; DefaultParameterValue(null)>] ?Y: float,
            [<Optional; DefaultParameterValue(null)>] ?Z: float
        ) =
        AspectRatio() |> AspectRatio.style (?X = X, ?Y = Y, ?Z = Z)

    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?X: float,
            [<Optional; DefaultParameterValue(null)>] ?Y: float,
            [<Optional; DefaultParameterValue(null)>] ?Z: float
        ) =

        fun (aspectRatio: AspectRatio) ->

            aspectRatio

            ++? ("x", X )
            ++? ("y", Y )
            ++? ("z", Z )
