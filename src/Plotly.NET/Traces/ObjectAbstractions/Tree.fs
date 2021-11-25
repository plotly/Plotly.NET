namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open System
open System.Runtime.InteropServices

type Root() =
    inherit DynamicObj()

    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?Color: Color
        ) =

        Root() |> Root.style (?Color = Color)

    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?Color: Color
        ) =
        (fun (root: Root) ->

            Color |> DynObj.setValueOpt root "color"

            root)
            
type Leaf() =
    inherit DynamicObj()

    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?Opacity: float
        ) =

        Leaf() |> Leaf.style (?Opacity = Opacity)

    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?Opacity: float
        ) =
        (fun (leaf: Leaf) ->

            Opacity |> DynObj.setValueOpt leaf "opacity"

            leaf)
