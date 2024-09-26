namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open System
open System.Runtime.InteropServices


type ProjectionDimension() =
    inherit DynamicObj()

    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
            [<Optional; DefaultParameterValue(null)>] ?Scale: float,
            [<Optional; DefaultParameterValue(null)>] ?Show: bool
        ) =
        ProjectionDimension() |> ProjectionDimension.style (?Opacity = Opacity, ?Scale = Scale, ?Show = Show)

    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
            [<Optional; DefaultParameterValue(null)>] ?Scale: float,
            [<Optional; DefaultParameterValue(null)>] ?Show: bool
        ) =

        fun (projectionDimension: ProjectionDimension) ->

            Opacity |> DynObj.setOptionalProperty projectionDimension "opacity"
            Scale |> DynObj.setOptionalProperty projectionDimension "scale"
            Show |> DynObj.setOptionalProperty projectionDimension "show"

            projectionDimension

type Projection() =
    inherit DynamicObj()

    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?X: ProjectionDimension,
            [<Optional; DefaultParameterValue(null)>] ?Y: ProjectionDimension,
            [<Optional; DefaultParameterValue(null)>] ?Z: ProjectionDimension
        ) =
        Projection() |> Projection.style (?X = X, ?Y = Y, ?Z = Z)

    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?X: ProjectionDimension,
            [<Optional; DefaultParameterValue(null)>] ?Y: ProjectionDimension,
            [<Optional; DefaultParameterValue(null)>] ?Z: ProjectionDimension
        ) =

        fun (projection: Projection) ->

            X |> DynObj.setOptionalProperty projection "x"
            Y |> DynObj.setOptionalProperty projection "y"
            Z |> DynObj.setOptionalProperty projection "z"

            projection
