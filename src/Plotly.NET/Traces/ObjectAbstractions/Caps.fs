namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open System
open System.Runtime.InteropServices

type CapFill () =
    inherit ImmutableDynamicObj () 

    static member init 
        (
            [<Optional;DefaultParameterValue(null)>] ?Fill: float,
            [<Optional;DefaultParameterValue(null)>] ?Show: bool
        ) =
            CapFill()
            |> CapFill.style
                (
                    ?Fill = Fill,
                    ?Show = Show
                )

    static member style
        (
            [<Optional;DefaultParameterValue(null)>] ?Fill: float,
            [<Optional;DefaultParameterValue(null)>] ?Show: bool
        ) =

            fun (capFill: CapFill) ->
                
                ++? ("fill", Fill)
                ++? ("show", Show)

                capFill


type Caps() =
    inherit ImmutableDynamicObj ()

    static member init
        (
            [<Optional;DefaultParameterValue(null)>] ?X: CapFill,
            [<Optional;DefaultParameterValue(null)>] ?Y: CapFill,
            [<Optional;DefaultParameterValue(null)>] ?Z: CapFill
        ) =

            Caps()
            |> Caps.style
                (
                    ?X  = X,
                    ?Y  = Y,
                    ?Z  = Z
                )
            
    static member style 
        (
            [<Optional;DefaultParameterValue(null)>] ?X: CapFill,
            [<Optional;DefaultParameterValue(null)>] ?Y: CapFill,
            [<Optional;DefaultParameterValue(null)>] ?Z: CapFill
        ) =
            fun (caps: Caps) ->

                ++? ("x", X)
                ++? ("y", Y)
                ++? ("z", Z)

                caps