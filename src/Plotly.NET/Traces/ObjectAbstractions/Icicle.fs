namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open DynamicObj.Operators
open System
open System.Runtime.InteropServices

type IcicleRoot() =
    inherit ImmutableDynamicObj()

    static member init([<Optional; DefaultParameterValue(null)>] ?Color: Color) =
        IcicleRoot() |> IcicleRoot.style (?Color = Color)

    static member style([<Optional; DefaultParameterValue(null)>] ?Color: Color) =
        (fun (icicleRoot: IcicleRoot) ->

            icicleRoot

            ++? ("color", Color ))

type IcicleLeaf() =
    inherit ImmutableDynamicObj()

    static member init([<Optional; DefaultParameterValue(null)>] ?Opacity: float) =
        IcicleLeaf() |> IcicleLeaf.style (?Opacity = Opacity)

    static member style([<Optional; DefaultParameterValue(null)>] ?Opacity: float) =
        (fun (icicleLeaf: IcicleLeaf) ->

            icicleLeaf

            ++? ("opacity", Opacity ))

type IcicleTiling() =
    inherit ImmutableDynamicObj()

    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?Flip: StyleParam.TilingFlip,
            [<Optional; DefaultParameterValue(null)>] ?Orientation: StyleParam.Orientation,
            [<Optional; DefaultParameterValue(null)>] ?Pad: int
        ) =
        IcicleTiling() |> IcicleTiling.style (?Flip = Flip, ?Orientation = Orientation, ?Pad = Pad)

    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?Flip: StyleParam.TilingFlip,
            [<Optional; DefaultParameterValue(null)>] ?Orientation: StyleParam.Orientation,
            [<Optional; DefaultParameterValue(null)>] ?Pad: int
        ) =
        (fun (icicleTiling: IcicleTiling) ->

            icicleTiling

            ++?? ("flip", Flip , StyleParam.TilingFlip.convert)
            ++?? ("orientation", Orientation , StyleParam.Orientation.convert)
            ++? ("pad", Pad ))
