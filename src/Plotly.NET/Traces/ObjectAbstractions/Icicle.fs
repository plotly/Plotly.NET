namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open System
open System.Runtime.InteropServices

type IcicleRoot() =
    inherit DynamicObj()

    static member init([<Optional; DefaultParameterValue(null)>] ?Color: Color) =
        IcicleRoot() |> IcicleRoot.style (?Color = Color)

    static member style([<Optional; DefaultParameterValue(null)>] ?Color: Color) =
        fun (icicleRoot: IcicleRoot) ->
            icicleRoot
            |> DynObj.withOptionalProperty "color" Color

type IcicleLeaf() =
    inherit DynamicObj()

    static member init([<Optional; DefaultParameterValue(null)>] ?Opacity: float) =
        IcicleLeaf() |> IcicleLeaf.style (?Opacity = Opacity)

    static member style([<Optional; DefaultParameterValue(null)>] ?Opacity: float) =
        fun (icicleLeaf: IcicleLeaf) ->
            icicleLeaf
            |> DynObj.withOptionalProperty "opacity" Opacity

type IcicleTiling() =
    inherit DynamicObj()

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
        fun (icicleTiling: IcicleTiling) ->

            icicleTiling
            |> DynObj.withOptionalPropertyBy "flip" Flip StyleParam.TilingFlip.convert
            |> DynObj.withOptionalPropertyBy "orientation" Orientation StyleParam.Orientation.convert
            |> DynObj.withOptionalProperty "pad" Pad
