namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open System
open System.Runtime.InteropServices


type TreemapRoot() =
    inherit DynamicObj()

    static member init([<Optional; DefaultParameterValue(null)>] ?Color: Color) =

        TreemapRoot() |> TreemapRoot.style (?Color = Color)

    static member style([<Optional; DefaultParameterValue(null)>] ?Color: Color) =
        (fun (root: TreemapRoot) ->

            Color |> DynObj.setValueOpt root "color"

            root)

type TreemapLeaf() =
    inherit DynamicObj()

    static member init([<Optional; DefaultParameterValue(null)>] ?Opacity: float) =

        TreemapLeaf() |> TreemapLeaf.style (?Opacity = Opacity)

    static member style([<Optional; DefaultParameterValue(null)>] ?Opacity: float) =
        (fun (leaf: TreemapLeaf) ->

            Opacity |> DynObj.setValueOpt leaf "opacity"

            leaf)


type TreemapTiling() =
    inherit DynamicObj()

    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?Packing: StyleParam.TreemapTilingPacking,
            [<Optional; DefaultParameterValue(null)>] ?SquarifyRatio: float,
            [<Optional; DefaultParameterValue(null)>] ?Flip: StyleParam.TilingFlip,
            [<Optional; DefaultParameterValue(null)>] ?Pad: float
        ) =

        TreemapTiling()
        |> TreemapTiling.style (?Packing = Packing, ?SquarifyRatio = SquarifyRatio, ?Flip = Flip, ?Pad = Pad)

    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?Packing: StyleParam.TreemapTilingPacking,
            [<Optional; DefaultParameterValue(null)>] ?SquarifyRatio: float,
            [<Optional; DefaultParameterValue(null)>] ?Flip: StyleParam.TilingFlip,
            [<Optional; DefaultParameterValue(null)>] ?Pad: float
        ) =
        (fun (tiling: TreemapTiling) ->
            Packing |> DynObj.setValueOptBy tiling "packing" StyleParam.TreemapTilingPacking.convert
            SquarifyRatio |> DynObj.setValueOpt tiling "squarifyRatio"
            Flip |> DynObj.setValueOptBy tiling "flip" StyleParam.TilingFlip.convert
            Pad |> DynObj.setValueOpt tiling "pad"

            tiling)
