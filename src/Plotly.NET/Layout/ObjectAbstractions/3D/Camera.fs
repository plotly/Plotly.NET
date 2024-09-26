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

            X |> DynObj.setOptionalProperty cameraCenter "x"
            Y |> DynObj.setOptionalProperty cameraCenter "y"
            Z |> DynObj.setOptionalProperty cameraCenter "z"

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

            X |> DynObj.setOptionalProperty cameraEye "x"
            Y |> DynObj.setOptionalProperty cameraEye "y"
            Z |> DynObj.setOptionalProperty cameraEye "z"

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

            X |> DynObj.setOptionalProperty cameraUp "x"
            Y |> DynObj.setOptionalProperty cameraUp "y"
            Z |> DynObj.setOptionalProperty cameraUp "z"

            cameraUp

type CameraProjection() =
    inherit DynamicObj()

    static member init([<Optional; DefaultParameterValue(null)>] ?ProjectionType: StyleParam.CameraProjectionType) =
        CameraProjection() |> CameraProjection.style (?ProjectionType = ProjectionType)

    static member style([<Optional; DefaultParameterValue(null)>] ?ProjectionType: StyleParam.CameraProjectionType) =

        fun (cameraProjection: CameraProjection) ->

            ProjectionType |> DynObj.setOptionalPropertyBy cameraProjection "type" StyleParam.CameraProjectionType.convert

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

            Center |> DynObj.setOptionalProperty camera "center"
            Eye |> DynObj.setOptionalProperty camera "eye"
            Projection |> DynObj.setOptionalProperty camera "projection"
            Up |> DynObj.setOptionalProperty camera "up"

            camera
