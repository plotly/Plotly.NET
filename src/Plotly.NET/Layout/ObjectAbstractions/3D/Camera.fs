namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices



type CameraCenter() =
    inherit DynamicObj()

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

            X |> DynObj.setValueOpt cameraCenter "x"
            Y |> DynObj.setValueOpt cameraCenter "y"
            Z |> DynObj.setValueOpt cameraCenter "z"

            cameraCenter

type CameraEye() =
    inherit DynamicObj()

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

            X |> DynObj.setValueOpt cameraEye "x"
            Y |> DynObj.setValueOpt cameraEye "y"
            Z |> DynObj.setValueOpt cameraEye "z"

            cameraEye

type CameraUp() =
    inherit DynamicObj()

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

            X |> DynObj.setValueOpt cameraUp "x"
            Y |> DynObj.setValueOpt cameraUp "y"
            Z |> DynObj.setValueOpt cameraUp "z"

            cameraUp

type CameraProjection() =
    inherit DynamicObj()

    static member init([<Optional; DefaultParameterValue(null)>] ?ProjectionType: StyleParam.CameraProjectionType) =
        CameraProjection() |> CameraProjection.style (?ProjectionType = ProjectionType)

    static member style([<Optional; DefaultParameterValue(null)>] ?ProjectionType: StyleParam.CameraProjectionType) =

        fun (cameraProjection: CameraProjection) ->

            ProjectionType |> DynObj.setValueOptBy cameraProjection "type" StyleParam.CameraProjectionType.convert

            cameraProjection

type Camera() =
    inherit DynamicObj()

    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?Center: CameraCenter,
            [<Optional; DefaultParameterValue(null)>] ?Eye: CameraEye,
            [<Optional; DefaultParameterValue(null)>] ?Projection: CameraProjection,
            [<Optional; DefaultParameterValue(null)>] ?Up: CameraUp
        ) =
        Camera() |> Camera.style (?Center = Center, ?Eye = Eye, ?Projection = Projection, ?Up = Up)

    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?Center: CameraCenter,
            [<Optional; DefaultParameterValue(null)>] ?Eye: CameraEye,
            [<Optional; DefaultParameterValue(null)>] ?Projection: CameraProjection,
            [<Optional; DefaultParameterValue(null)>] ?Up: CameraUp
        ) =

        fun (camera: Camera) ->

            Center |> DynObj.setValueOpt camera "center"
            Eye |> DynObj.setValueOpt camera "eye"
            Projection |> DynObj.setValueOpt camera "projection"
            Up |> DynObj.setValueOpt camera "up"

            camera
