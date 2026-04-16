namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects

open DynamicObj
open System
open System.IO
//open FSharp.Care.Collections

open StyleParam
open System.Runtime.InteropServices
open System.Runtime.CompilerServices

[<AutoOpen>]
module Chart3D_VectorField =

    [<Extension>]
    type Chart =
        /// <summary>
        /// Creates a cone plot, typically used to visualize vector fields.
        ///
        /// Specify a vector field using 6 1D arrays:
        ///
        /// 3 position arrays `x`, `y` and `z` and
        ///
        /// 3 vector component arrays `u`, `v`, `w`.
        ///
        /// The cones are drawn exactly at the positions given by `x`, `y` and `z`.
        /// </summary>
        /// <param name="x">Sets the x coordinates of the vector field and of the displayed cones.</param>
        /// <param name="y">Sets the y coordinates of the vector field and of the displayed cones.</param>
        /// <param name="z">Sets the z coordinates of the vector field and of the displayed cones.</param>
        /// <param name="u">Sets the x components of the vector field.</param>
        /// <param name="v">Sets the y components of the vector field.</param>
        /// <param name="w">Sets the z components of the vector field.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="ColorScale">Sets the colorscale</param>
        /// <param name="ShowScale">Whether or not to show the colorbar/colorscale</param>
        /// <param name="ColorBar">Sets the colorbar</param>
        /// <param name="SizeMode">Determines whether `sizeref` is set as a "scaled" (i.e unitless) scalar (normalized by the max u/v/w norm in the vector field) or as "absolute" value (in the same units as the vector field).</param>
        /// <param name="ConeAnchor">Sets the cones' anchor with respect to their x/y/z positions. Note that "cm" denote the cone's center of mass which corresponds to 1/4 from the tail to tip.</param>
        /// <param name="CameraProjectionType">Sets the camera projection type of this trace.</param>
        /// <param name="Camera">Sets the camera of this trace.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Cone
            (
                x: seq<#IConvertible>,
                y: seq<#IConvertible>,
                z: seq<#IConvertible>,
                u: seq<#IConvertible>,
                v: seq<#IConvertible>,
                w: seq<#IConvertible>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
                ?ColorBar: ColorBar,
                ?SizeMode: StyleParam.ConeSizeMode,
                ?ConeAnchor: StyleParam.ConeAnchor,
                ?CameraProjectionType: StyleParam.CameraProjectionType,
                ?Camera: Camera,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let cameraProjection =
                defaultArg CameraProjectionType StyleParam.CameraProjectionType.Perspective

            let camera =
                Camera
                |> Option.defaultValue (LayoutObjects.Camera.init ())
                |> LayoutObjects.Camera.style (Projection = CameraProjection.init (ProjectionType = cameraProjection))

            Trace3D.initCone (
                Trace3DStyle.Cone(
                    X = x,
                    Y = y,
                    Z = z,
                    U = u,
                    V = v,
                    W = w,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?ColorScale = ColorScale,
                    ?ShowScale = ShowScale,
                    ?ColorBar = ColorBar,
                    ?SizeMode = SizeMode,
                    ?Anchor = ConeAnchor
                )
            )
            |> GenericChart.ofTraceObject useDefaults
            |> GenericChart.addLayout (
                Layout.init () |> Layout.setScene (StyleParam.SubPlotId.Scene 1, Scene.init (Camera = camera))
            )

        /// <summary>
        /// Creates a cone plot from encoded vector-field coordinates and components.
        /// </summary>
        [<Extension>]
        static member Cone
            (
                xEncoded: EncodedTypedArray,
                yEncoded: EncodedTypedArray,
                zEncoded: EncodedTypedArray,
                uEncoded: EncodedTypedArray,
                vEncoded: EncodedTypedArray,
                wEncoded: EncodedTypedArray,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
                ?ColorBar: ColorBar,
                ?SizeMode: StyleParam.ConeSizeMode,
                ?ConeAnchor: StyleParam.ConeAnchor,
                ?CameraProjectionType: StyleParam.CameraProjectionType,
                ?Camera: Camera,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let cameraProjection =
                defaultArg CameraProjectionType StyleParam.CameraProjectionType.Perspective

            let camera =
                Camera
                |> Option.defaultValue (LayoutObjects.Camera.init ())
                |> LayoutObjects.Camera.style (Projection = CameraProjection.init (ProjectionType = cameraProjection))

            Trace3D.initCone (
                Trace3DStyle.Cone(
                    XEncoded = xEncoded,
                    YEncoded = yEncoded,
                    ZEncoded = zEncoded,
                    UEncoded = uEncoded,
                    VEncoded = vEncoded,
                    WEncoded = wEncoded,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?ColorScale = ColorScale,
                    ?ShowScale = ShowScale,
                    ?ColorBar = ColorBar,
                    ?SizeMode = SizeMode,
                    ?Anchor = ConeAnchor
                )
            )
            |> GenericChart.ofTraceObject useDefaults
            |> GenericChart.addLayout (
                Layout.init () |> Layout.setScene (StyleParam.SubPlotId.Scene 1, Scene.init (Camera = camera))
            )

        /// <summary>
        /// Creates a cone plot, typically used to visualize vector fields.
        ///
        /// Specify a vector field using 6 1D arrays:
        ///
        /// 3 position arrays `x`, `y` and `z` and
        ///
        /// 3 vector component arrays `u`, `v`, `w`.
        ///
        /// The cones are drawn exactly at the positions given by `x`, `y` and `z`.
        /// </summary>
        /// <param name="coneXYZ">Sets the x, y, and z coordinates of the vector field and of the displayed cones.</param>
        /// <param name="coneUVW">Sets the x, y, and z components of the vector field.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="ColorScale">Sets the colorscale</param>
        /// <param name="ShowScale">Whether or not to show the colorbar/colorscale</param>
        /// <param name="ColorBar">Sets the colorbar</param>
        /// <param name="SizeMode">Determines whether `sizeref` is set as a "scaled" (i.e unitless) scalar (normalized by the max u/v/w norm in the vector field) or as "absolute" value (in the same units as the vector field).</param>
        /// <param name="ConeAnchor">Sets the cones' anchor with respect to their x/y/z positions. Note that "cm" denote the cone's center of mass which corresponds to 1/4 from the tail to tip.</param>
        /// <param name="CameraProjectionType">Sets the camera projection type of this trace.</param>
        /// <param name="Camera">Sets the camera of this trace.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Cone
            (
                coneXYZ: seq<#IConvertible * #IConvertible * #IConvertible>,
                coneUVW: seq<#IConvertible * #IConvertible * #IConvertible>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
                ?ColorBar: ColorBar,
                ?SizeMode: StyleParam.ConeSizeMode,
                ?ConeAnchor: StyleParam.ConeAnchor,
                ?CameraProjectionType: StyleParam.CameraProjectionType,
                ?Camera: Camera,
                ?UseDefaults: bool
            ) =

            let x, y, z = Seq.unzip3 coneXYZ
            let u, v, w = Seq.unzip3 coneUVW

            Chart.Cone(
                x,
                y,
                z,
                u,
                v,
                w,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?ColorScale = ColorScale,
                ?ShowScale = ShowScale,
                ?ColorBar = ColorBar,
                ?SizeMode = SizeMode,
                ?ConeAnchor = ConeAnchor,
                ?CameraProjectionType = CameraProjectionType,
                ?Camera = Camera,
                ?UseDefaults = UseDefaults
            )

        /// <summary>
        /// Creates a cone plot, typically used to visualize vector fields.
        ///
        /// Specify a vector field using 6 1D arrays:
        ///
        /// 3 position arrays `x`, `y` and `z` and
        ///
        /// 3 vector component arrays `u`, `v`, `w`.
        ///
        /// The cones are drawn exactly at the positions given by `x`, `y` and `z`.
        /// </summary>
        /// <param name="xyzuvw">Sets the x, y, and z coordinates of the vector field and of the displayed cones together with the x, y, and z components of the vector field.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="ColorScale">Sets the colorscale</param>
        /// <param name="ShowScale">Whether or not to show the colorbar/colorscale</param>
        /// <param name="ColorBar">Sets the colorbar</param>
        /// <param name="SizeMode">Determines whether `sizeref` is set as a "scaled" (i.e unitless) scalar (normalized by the max u/v/w norm in the vector field) or as "absolute" value (in the same units as the vector field).</param>
        /// <param name="ConeAnchor">Sets the cones' anchor with respect to their x/y/z positions. Note that "cm" denote the cone's center of mass which corresponds to 1/4 from the tail to tip.</param>
        /// <param name="CameraProjectionType">Sets the camera projection type of this trace.</param>
        /// <param name="Camera">Sets the camera of this trace.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Cone
            (
                xyzuvw:
                    seq<#IConvertible * #IConvertible * #IConvertible * #IConvertible * #IConvertible * #IConvertible>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
                ?ColorBar: ColorBar,
                ?SizeMode: StyleParam.ConeSizeMode,
                ?ConeAnchor: StyleParam.ConeAnchor,
                ?CameraProjectionType: StyleParam.CameraProjectionType,
                ?Camera: Camera,
                ?UseDefaults: bool
            ) =

            let x, y, z, u, v, w =
                xyzuvw |> Seq.map (fun (x, _, _, _, _, _) -> x),
                xyzuvw |> Seq.map (fun (_, y, _, _, _, _) -> y),
                xyzuvw |> Seq.map (fun (_, _, z, _, _, _) -> z),
                xyzuvw |> Seq.map (fun (_, _, _, u, _, _) -> u),
                xyzuvw |> Seq.map (fun (_, _, _, _, v, _) -> v),
                xyzuvw |> Seq.map (fun (_, _, _, _, _, w) -> w)

            Chart.Cone(
                x,
                y,
                z,
                u,
                v,
                w,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?ColorScale = ColorScale,
                ?ShowScale = ShowScale,
                ?ColorBar = ColorBar,
                ?SizeMode = SizeMode,
                ?ConeAnchor = ConeAnchor,
                ?CameraProjectionType = CameraProjectionType,
                ?Camera = Camera,
                ?UseDefaults = UseDefaults
            )

        /// <summary>
        /// Creates a streamtube plot, typically used to visualize flow in a vector field.
        ///
        /// Specify a vector field using 6 1D arrays of equal length:
        ///
        /// 3 position arrays `x`, `y` and `z` and
        ///
        /// 3 vector component arrays `u`, `v`, and `w`.
        ///
        /// By default, the tubes' starting positions will be cut from the vector field's x-z plane at its minimum y value.
        /// To specify your own starting position, use `TubeStarts`.
        /// The color is encoded by the norm of (u, v, w), and the local radius by the divergence of (u, v, w).
        /// </summary>
        /// <param name="x">Sets the x coordinates of the vector field and of the displayed cones.</param>
        /// <param name="y">Sets the y coordinates of the vector field and of the displayed cones.</param>
        /// <param name="z">Sets the z coordinates of the vector field and of the displayed cones.</param>
        /// <param name="u">Sets the x components of the vector field.</param>
        /// <param name="v">Sets the y components of the vector field.</param>
        /// <param name="w">Sets the z components of the vector field.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="ColorScale">Sets the colorscale</param>
        /// <param name="ShowScale">Whether or not to show the colorbar/colorscale</param>
        /// <param name="ColorBar">Sets the colorbar</param>
        /// <param name="MaxDisplayed">The maximum number of displayed segments in a streamtube.</param>
        /// <param name="TubeStarts">Use this object to specify custom tube start positions</param>
        /// <param name="CameraProjectionType">Sets the camera projection type of this trace.</param>
        /// <param name="Camera">Sets the camera of this trace.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member StreamTube
            (
                x,
                y,
                z,
                u,
                v,
                w,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
                ?ColorBar: ColorBar,
                ?MaxDisplayed: int,
                ?TubeStarts: StreamTubeStarts,
                ?CameraProjectionType: StyleParam.CameraProjectionType,
                ?Camera: Camera,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let cameraProjection =
                defaultArg CameraProjectionType StyleParam.CameraProjectionType.Perspective

            let camera =
                Camera
                |> Option.defaultValue (LayoutObjects.Camera.init ())
                |> LayoutObjects.Camera.style (Projection = CameraProjection.init (ProjectionType = cameraProjection))

            Trace3D.initStreamTube (
                Trace3DStyle.StreamTube(
                    X = x,
                    Y = y,
                    Z = z,
                    U = u,
                    V = v,
                    W = w,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?ColorScale = ColorScale,
                    ?ShowScale = ShowScale,
                    ?ColorBar = ColorBar,
                    ?MaxDisplayed = MaxDisplayed,
                    ?Starts = TubeStarts
                )
            )
            |> GenericChart.ofTraceObject useDefaults
            |> GenericChart.addLayout (
                Layout.init () |> Layout.setScene (StyleParam.SubPlotId.Scene 1, Scene.init (Camera = camera))
            )

        /// <summary>
        /// Creates a streamtube plot from encoded vector-field coordinates and components.
        /// </summary>
        [<Extension>]
        static member StreamTube
            (
                xEncoded: EncodedTypedArray,
                yEncoded: EncodedTypedArray,
                zEncoded: EncodedTypedArray,
                uEncoded: EncodedTypedArray,
                vEncoded: EncodedTypedArray,
                wEncoded: EncodedTypedArray,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
                ?ColorBar: ColorBar,
                ?MaxDisplayed: int,
                ?TubeStarts: StreamTubeStarts,
                ?CameraProjectionType: StyleParam.CameraProjectionType,
                ?Camera: Camera,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let cameraProjection =
                defaultArg CameraProjectionType StyleParam.CameraProjectionType.Perspective

            let camera =
                Camera
                |> Option.defaultValue (LayoutObjects.Camera.init ())
                |> LayoutObjects.Camera.style (Projection = CameraProjection.init (ProjectionType = cameraProjection))

            Trace3D.initStreamTube (
                Trace3DStyle.StreamTube(
                    XEncoded = xEncoded,
                    YEncoded = yEncoded,
                    ZEncoded = zEncoded,
                    UEncoded = uEncoded,
                    VEncoded = vEncoded,
                    WEncoded = wEncoded,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?ColorScale = ColorScale,
                    ?ShowScale = ShowScale,
                    ?ColorBar = ColorBar,
                    ?MaxDisplayed = MaxDisplayed,
                    ?Starts = TubeStarts
                )
            )
            |> GenericChart.ofTraceObject useDefaults
            |> GenericChart.addLayout (
                Layout.init () |> Layout.setScene (StyleParam.SubPlotId.Scene 1, Scene.init (Camera = camera))
            )

        /// <summary>
        /// Creates a streamtube plot, typically used to visualize flow in a vector field.
        ///
        /// Specify a vector field using 6 1D arrays of equal length:
        ///
        /// 3 position arrays `x`, `y` and `z` and
        ///
        /// 3 vector component arrays `u`, `v`, and `w`.
        ///
        /// By default, the tubes' starting positions will be cut from the vector field's x-z plane at its minimum y value.
        /// To specify your own starting position, use `TubeStarts`.
        /// The color is encoded by the norm of (u, v, w), and the local radius by the divergence of (u, v, w).
        /// </summary>
        /// <param name="streamTubeXYZ">Sets the x, y, and z coordinates of the vector field and of the displayed cones.</param>
        /// <param name="streamTubeUVW">Sets the x, y, and z components of the vector field.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="ColorScale">Sets the colorscale</param>
        /// <param name="ShowScale">Whether or not to show the colorbar/colorscale</param>
        /// <param name="ColorBar">Sets the colorbar</param>
        /// <param name="MaxDisplayed">The maximum number of displayed segments in a streamtube.</param>
        /// <param name="TubeStarts">Use this object to specify custom tube start positions</param>
        /// <param name="CameraProjectionType">Sets the camera projection type of this trace.</param>
        /// <param name="Camera">Sets the camera of this trace.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member StreamTube
            (
                streamTubeXYZ: seq<#IConvertible * #IConvertible * #IConvertible>,
                streamTubeUVW: seq<#IConvertible * #IConvertible * #IConvertible>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
                ?ColorBar: ColorBar,
                ?MaxDisplayed: int,
                ?TubeStarts: StreamTubeStarts,
                ?CameraProjectionType: StyleParam.CameraProjectionType,
                ?Camera: Camera,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let x, y, z = Seq.unzip3 streamTubeXYZ
            let u, v, w = Seq.unzip3 streamTubeUVW

            Chart.StreamTube(
                x,
                y,
                z,
                u,
                v,
                w,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?ColorScale = ColorScale,
                ?ShowScale = ShowScale,
                ?ColorBar = ColorBar,
                ?MaxDisplayed = MaxDisplayed,
                ?TubeStarts = TubeStarts,
                ?CameraProjectionType = CameraProjectionType,
                ?Camera = Camera,
                ?UseDefaults = UseDefaults

            )

        /// <summary>
        /// Creates a streamtube plot, typically used to visualize flow in a vector field.
        ///
        /// Specify a vector field using 6 1D arrays of equal length:
        ///
        /// 3 position arrays `x`, `y` and `z` and
        ///
        /// 3 vector component arrays `u`, `v`, and `w`.
        ///
        /// By default, the tubes' starting positions will be cut from the vector field's x-z plane at its minimum y value.
        /// To specify your own starting position, use `TubeStarts`.
        /// The color is encoded by the norm of (u, v, w), and the local radius by the divergence of (u, v, w).
        /// </summary>
        /// <param name="xyzuvw">Sets the x, y, and z coordinates of the vector field and of the displayed cones together with the x, y, and z components of the vector field.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="ColorScale">Sets the colorscale</param>
        /// <param name="ShowScale">Whether or not to show the colorbar/colorscale</param>
        /// <param name="ColorBar">Sets the colorbar</param>
        /// <param name="MaxDisplayed">The maximum number of displayed segments in a streamtube.</param>
        /// <param name="TubeStarts">Use this object to specify custom tube start positions</param>
        /// <param name="CameraProjectionType">Sets the camera projection type of this trace.</param>
        /// <param name="Camera">Sets the camera of this trace.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member StreamTube
            (
                xyzuvw:
                    seq<#IConvertible * #IConvertible * #IConvertible * #IConvertible * #IConvertible * #IConvertible>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
                ?ColorBar: ColorBar,
                ?MaxDisplayed: int,
                ?TubeStarts: StreamTubeStarts,
                ?CameraProjectionType: StyleParam.CameraProjectionType,
                ?Camera: Camera,
                ?UseDefaults: bool
            ) =

            let x, y, z, u, v, w =
                xyzuvw |> Seq.map (fun (x, _, _, _, _, _) -> x),
                xyzuvw |> Seq.map (fun (_, y, _, _, _, _) -> y),
                xyzuvw |> Seq.map (fun (_, _, z, _, _, _) -> z),
                xyzuvw |> Seq.map (fun (_, _, _, u, _, _) -> u),
                xyzuvw |> Seq.map (fun (_, _, _, _, v, _) -> v),
                xyzuvw |> Seq.map (fun (_, _, _, _, _, w) -> w)

            Chart.StreamTube(
                x,
                y,
                z,
                u,
                v,
                w,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?ColorScale = ColorScale,
                ?ShowScale = ShowScale,
                ?ColorBar = ColorBar,
                ?MaxDisplayed = MaxDisplayed,
                ?TubeStarts = TubeStarts,
                ?CameraProjectionType = CameraProjectionType,
                ?Camera = Camera,
                ?UseDefaults = UseDefaults

            )

