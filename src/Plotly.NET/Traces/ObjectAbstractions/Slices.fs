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

            slicesFill
            |> DynObj.withOptionalProperty "fill" Fill
            |> DynObj.withOptionalProperty "locations" Locations
            |> DynObj.withOptionalProperty "show" Show


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

            slices
            |> DynObj.withOptionalProperty "x" X
            |> DynObj.withOptionalProperty "y" Y
            |> DynObj.withOptionalProperty "z" Z
