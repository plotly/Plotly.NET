namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open DynamicObj.Operators
open System
open System.Runtime.InteropServices



type CameraCenter() =
    inherit ImmutableDynamicObj()

    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?X: float,
            [<Optional; DefaultParameterValue(null)>] ?Y: float,
            [<Optional; DefaultParameterValue(null)>] ?Z: float
        ) =
        CameraCenter() |> CameraCenter.style (?X = X, ?Y = Y, ?Z = Z)

    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?X: float,
            [<Optional; DefaultParameterValue(null)>] ?Y: float,
            [<Optional; DefaultParameterValue(null)>] ?Z: float
        ) =

        fun (cameraCenter: CameraCenter) ->

            cameraCenter

            ++? ("x", X )
            ++? ("y", Y )
            ++? ("z", Z )

type CameraEye() =
    inherit ImmutableDynamicObj()

    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?X: float,
            [<Optional; DefaultParameterValue(null)>] ?Y: float,
            [<Optional; DefaultParameterValue(null)>] ?Z: float
        ) =
        CameraEye() |> CameraEye.style (?X = X, ?Y = Y, ?Z = Z)

    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?X: float,
            [<Optional; DefaultParameterValue(null)>] ?Y: float,
            [<Optional; DefaultParameterValue(null)>] ?Z: float
        ) =

        fun (cameraEye: CameraEye) ->

            cameraEye

            ++? ("x", X )
            ++? ("y", Y )
            ++? ("z", Z )

type CameraUp() =
    inherit ImmutableDynamicObj()

    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?X: float,
            [<Optional; DefaultParameterValue(null)>] ?Y: float,
            [<Optional; DefaultParameterValue(null)>] ?Z: float
        ) =
        CameraUp() |> CameraUp.style (?X = X, ?Y = Y, ?Z = Z)

    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?X: float,
            [<Optional; DefaultParameterValue(null)>] ?Y: float,
            [<Optional; DefaultParameterValue(null)>] ?Z: float
        ) =

        fun (cameraUp: CameraUp) ->

            cameraUp

            ++? ("x", X )
            ++? ("y", Y )
            ++? ("z", Z )

type Camera() =
    inherit ImmutableDynamicObj()

    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?Center: CameraCenter,
            [<Optional; DefaultParameterValue(null)>] ?Eye: CameraEye,
            [<Optional; DefaultParameterValue(null)>] ?Projection: StyleParam.CameraProjection,
            [<Optional; DefaultParameterValue(null)>] ?Up: CameraUp
        ) =
        Camera() |> Camera.style (?Center = Center, ?Eye = Eye, ?Projection = Projection, ?Up = Up)

    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?Center: CameraCenter,
            [<Optional; DefaultParameterValue(null)>] ?Eye: CameraEye,
            [<Optional; DefaultParameterValue(null)>] ?Projection: StyleParam.CameraProjection,
            [<Optional; DefaultParameterValue(null)>] ?Up: CameraUp
        ) =

        fun (camera: Camera) ->

            camera

            ++? ("center", Center )
            ++? ("eye", Eye )
            ++?? ("projection", Projection , StyleParam.CameraProjection.convert)
            ++? ("up", Up )
