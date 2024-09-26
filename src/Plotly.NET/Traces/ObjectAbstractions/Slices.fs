namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open System
open System.Runtime.InteropServices

type SlicesFill() =
    inherit DynamicObj()

    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?Fill: float,
            [<Optional; DefaultParameterValue(null)>] ?Locations: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Show: bool
        ) =
        SlicesFill() |> SlicesFill.style (?Fill = Fill, ?Locations = Locations, ?Show = Show)

    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?Fill: float,
            [<Optional; DefaultParameterValue(null)>] ?Locations: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Show: bool
        ) =

        fun (slicesFill: SlicesFill) ->

            Fill |> DynObj.setOptionalProperty slicesFill "fill"
            Locations |> DynObj.setOptionalProperty slicesFill "locations"
            Show |> DynObj.setOptionalProperty slicesFill "show"

            slicesFill


type Slices() =
    inherit DynamicObj()

    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?X: SlicesFill,
            [<Optional; DefaultParameterValue(null)>] ?Y: SlicesFill,
            [<Optional; DefaultParameterValue(null)>] ?Z: SlicesFill
        ) =

        Slices() |> Slices.style (?X = X, ?Y = Y, ?Z = Z)

    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?X: SlicesFill,
            [<Optional; DefaultParameterValue(null)>] ?Y: SlicesFill,
            [<Optional; DefaultParameterValue(null)>] ?Z: SlicesFill
        ) =
        fun (slices: Slices) ->

            X |> DynObj.setOptionalProperty slices "x"
            Y |> DynObj.setOptionalProperty slices "y"
            Z |> DynObj.setOptionalProperty slices "z"

            slices
