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
        (fun (icicleRoot: IcicleRoot) ->

            Color |> DynObj.setOptionalProperty icicleRoot "color"

            icicleRoot)

type IcicleLeaf() =
    inherit DynamicObj()

    static member init([<Optional; DefaultParameterValue(null)>] ?Opacity: float) =
        IcicleLeaf() |> IcicleLeaf.style (?Opacity = Opacity)

    static member style([<Optional; DefaultParameterValue(null)>] ?Opacity: float) =
        (fun (icicleLeaf: IcicleLeaf) ->

            Opacity |> DynObj.setOptionalProperty icicleLeaf "opacity"

            icicleLeaf)

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
        (fun (icicleTiling: IcicleTiling) ->

            Flip |> DynObj.setOptionalPropertyBy icicleTiling "flip" StyleParam.TilingFlip.convert
            Orientation |> DynObj.setOptionalPropertyBy icicleTiling "orientation" StyleParam.Orientation.convert
            Pad |> DynObj.setOptionalProperty icicleTiling "pad"

            icicleTiling)
