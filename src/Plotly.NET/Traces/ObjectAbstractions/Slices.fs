namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open System
open System.Runtime.InteropServices

type SlicesFill () =
    inherit ImmutableDynamicObj () 

    static member init 
        (
            [<Optional;DefaultParameterValue(null)>] ?Fill: float,
            [<Optional;DefaultParameterValue(null)>] ?Locations: seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?Show: bool
        ) =
            SlicesFill()
            |> SlicesFill.style
                (
                    ?Fill       = Fill,
                    ?Locations  = Locations,
                    ?Show       = Show
                )

    static member style
        (
            [<Optional;DefaultParameterValue(null)>] ?Fill: float,
            [<Optional;DefaultParameterValue(null)>] ?Locations: seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?Show: bool
        ) =

            fun (slicesFill: SlicesFill) ->
                
                ++? ("fill", Fill)
                ++? ("locations", Locations)
                ++? ("show", Show)

                slicesFill


type Slices() =
    inherit ImmutableDynamicObj ()

    static member init
        (
            [<Optional;DefaultParameterValue(null)>] ?X: SlicesFill,
            [<Optional;DefaultParameterValue(null)>] ?Y: SlicesFill,
            [<Optional;DefaultParameterValue(null)>] ?Z: SlicesFill
        ) =

            Slices()
            |> Slices.style
                (
                    ?X  = X,
                    ?Y  = Y,
                    ?Z  = Z
                )
            
    static member style 
        (
            [<Optional;DefaultParameterValue(null)>] ?X: SlicesFill,
            [<Optional;DefaultParameterValue(null)>] ?Y: SlicesFill,
            [<Optional;DefaultParameterValue(null)>] ?Z: SlicesFill
        ) =
            fun (slices: Slices) ->

                ++? ("x", X)
                ++? ("y", Y)
                ++? ("z", Z)

                slices