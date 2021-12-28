namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open DynamicObj.Operators
open System
open System.Runtime.InteropServices

type SplomDiagonal() =
    inherit ImmutableDynamicObj()

    static member init([<Optional; DefaultParameterValue(null)>] ?Visible: bool) =
        SplomDiagonal() |> SplomDiagonal.style (?Visible = Visible)

    static member style([<Optional; DefaultParameterValue(null)>] ?Visible: bool) =

        fun (splomDiagonal: SplomDiagonal) ->

            splomDiagonal

            ++? ("visible", Visible )
