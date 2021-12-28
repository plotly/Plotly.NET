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

            ++? ("color", Color )

            root)

type TreemapLeaf() =
    inherit DynamicObj()

    static member init([<Optional; DefaultParameterValue(null)>] ?Opacity: float) =

        TreemapLeaf() |> TreemapLeaf.style (?Opacity = Opacity)

    static member style([<Optional; DefaultParameterValue(null)>] ?Opacity: float) =
        (fun (leaf: TreemapLeaf) ->

            ++? ("opacity", Opacity )

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
            ++?? ("packing", Packing , StyleParam.TreemapTilingPacking.convert)
            ++? ("squarifyRatio", SquarifyRatio )
            ++?? ("flip", Flip , StyleParam.TilingFlip.convert)
            ++? ("pad", Pad )

            tiling)
