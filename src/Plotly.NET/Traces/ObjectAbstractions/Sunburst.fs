namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open DynamicObj.Operators
open System
open System.Runtime.InteropServices


type SunburstRoot() =
    inherit ImmutableDynamicObj()

    static member init([<Optional; DefaultParameterValue(null)>] ?Color: Color) =

        SunburstRoot() |> SunburstRoot.style (?Color = Color)

    static member style([<Optional; DefaultParameterValue(null)>] ?Color: Color) =
        (fun (root: SunburstRoot) ->

            root

            ++? ("color", Color ))

type SunburstLeaf() =
    inherit ImmutableDynamicObj()

    static member init([<Optional; DefaultParameterValue(null)>] ?Opacity: float) =

        SunburstLeaf() |> SunburstLeaf.style (?Opacity = Opacity)

    static member style([<Optional; DefaultParameterValue(null)>] ?Opacity: float) =
        (fun (leaf: SunburstLeaf) ->

            leaf

            ++? ("opacity", Opacity ))
