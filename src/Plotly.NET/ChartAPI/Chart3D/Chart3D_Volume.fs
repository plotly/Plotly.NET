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
module Chart3D_Volume =

    [<Extension>]
    type Chart =
        /// <summary>
        /// Creates a volume plot to visualize the volume of a 3D shape.
        ///
        /// Draws volume trace between iso-min and iso-max values with coordinates given by four 1-dimensional arrays containing the `value`, `x`, `y` and `z` of every vertex of a uniform or non-uniform 3-D grid.
        /// Horizontal or vertical slices, caps as well as spaceframe between iso-min and iso-max values could also be drawn using this trace.
        ///
        /// This plot is very similar to the `IsoSurface` plot. However, whereas isosurface plots show all surfaces with the same opacity, tweaking the opacityscale parameter of Volume plots results in a depth effect and better volume rendering.
        /// </summary>
        /// <param name="x">Sets the X coordinates of the vertices on X axis.</param>
        /// <param name="y">Sets the Y coordinates of the vertices on Y axis.</param>
        /// <param name="z">Sets the Z coordinates of the vertices on Z axis.</param>
        /// <param name="value">Sets the 4th dimension (value) of the vertices.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="ColorScale">Sets the colorscale</param>
        /// <param name="ShowScale">Whether or not to show the colorbar/colorscale</param>
        /// <param name="ColorBar">Sets the colorbar</param>
        /// <param name="IsoMin">Sets the minimum boundary for iso-surface plot.</param>
        /// <param name="IsoMax">Sets the maximum boundary for iso-surface plot.</param>
        /// <param name="Caps">Sets the caps (color-coded surfaces on the sides of the visualization domain)</param>
        /// <param name="Slices">Adds Slices through the volume</param>
        /// <param name="Surface">Sets the surface.</param>
        /// <param name="OpacityScale">Sets the opacityscale. The opacityscale must be an array containing arrays mapping a normalized value to an opacity value. At minimum, a mapping for the lowest (0) and highest (1) values are required. For example, `[[0, 1], [0.5, 0.2], [1, 1]]` means that higher/lower values would have higher opacity values and those in the middle would be more transparent Alternatively, `opacityscale` may be a palette name string of the following list: 'min', 'max', 'extremes' and 'uniform'. The default is 'uniform'.</param>
        /// <param name="CameraProjectionType">Sets the camera projection type of this trace.</param>
        /// <param name="Camera">Sets the camera of this trace.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Volume
            (
                x,
                y,
                z,
                value,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
                ?ColorBar: ColorBar,
                ?IsoMin: float,
                ?IsoMax: float,
                ?Caps: Caps,
                ?Slices: Slices,
                ?Surface: Surface,
                ?OpacityScale: seq<#seq<#IConvertible>>,
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

            Trace3D.initVolume (
                Trace3DStyle.Volume(
                    X = x,
                    Y = y,
                    Z = z,
                    Value = value,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?ColorScale = ColorScale,
                    ?ShowScale = ShowScale,
                    ?ColorBar = ColorBar,
                    ?IsoMin = IsoMin,
                    ?IsoMax = IsoMax,
                    ?Caps = Caps,
                    ?Slices = Slices,
                    ?Surface = Surface,
                    ?OpacityScale = OpacityScale
                )
            )

            |> GenericChart.ofTraceObject useDefaults
            |> GenericChart.addLayout (
                Layout.init () |> Layout.setScene (StyleParam.SubPlotId.Scene 1, Scene.init (Camera = camera))
            )

        /// <summary>
        /// Creates a volume plot from encoded coordinate and value arrays.
        /// </summary>
        [<Extension>]
        static member Volume
            (
                xEncoded: EncodedTypedArray,
                yEncoded: EncodedTypedArray,
                zEncoded: EncodedTypedArray,
                valueEncoded: EncodedTypedArray,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
                ?ColorBar: ColorBar,
                ?IsoMin: float,
                ?IsoMax: float,
                ?Caps: Caps,
                ?Slices: Slices,
                ?Surface: Surface,
                ?OpacityScaleEncoded: EncodedTypedArray,
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

            Trace3D.initVolume (
                Trace3DStyle.Volume(
                    XEncoded = xEncoded,
                    YEncoded = yEncoded,
                    ZEncoded = zEncoded,
                    ValueEncoded = valueEncoded,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?ColorScale = ColorScale,
                    ?ShowScale = ShowScale,
                    ?ColorBar = ColorBar,
                    ?IsoMin = IsoMin,
                    ?IsoMax = IsoMax,
                    ?Caps = Caps,
                    ?Slices = Slices,
                    ?Surface = Surface,
                    ?OpacityScaleEncoded = OpacityScaleEncoded
                )
            )
            |> GenericChart.ofTraceObject useDefaults
            |> GenericChart.addLayout (
                Layout.init () |> Layout.setScene (StyleParam.SubPlotId.Scene 1, Scene.init (Camera = camera))
            )

        /// <summary>
        /// Creates a isosurface plot to visualize the volume of a 3D shape.
        ///
        /// An isosurface is a surface that represents points of a constant value (e.g. pressure, temperature, velocity, density) within a volume of space.
        ///
        /// Draws isosurfaces between iso-min and iso-max values with coordinates given by four 1-dimensional arrays containing the `value`, `x`, `y` and `z` of every vertex of a uniform or non-uniform 3-D grid.
        /// Horizontal or vertical slices, caps as well as spaceframe between iso-min and iso-max values could also be drawn using this trace.
        ///
        /// This plot is very similar to the `Volume` plot. However it shows all surfaces with the same opacity.
        /// </summary>
        /// <param name="x">Sets the X coordinates of the vertices on X axis.</param>
        /// <param name="y">Sets the Y coordinates of the vertices on Y axis.</param>
        /// <param name="z">Sets the Z coordinates of the vertices on Z axis.</param>
        /// <param name="value">Sets the 4th dimension (value) of the vertices.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="ColorScale">Sets the colorscale</param>
        /// <param name="ShowScale">Whether or not to show the colorbar/colorscale</param>
        /// <param name="ColorBar">Sets the colorbar</param>
        /// <param name="IsoMin">Sets the minimum boundary for iso-surface plot.</param>
        /// <param name="IsoMax">Sets the maximum boundary for iso-surface plot.</param>
        /// <param name="Caps">Sets the caps (color-coded surfaces on the sides of the visualization domain)</param>
        /// <param name="Slices">Adds Slices through the volume</param>
        /// <param name="Surface">Sets the surface.</param>
        /// <param name="CameraProjectionType">Sets the camera projection type of this trace.</param>
        /// <param name="Camera">Sets the camera of this trace.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member IsoSurface
            (
                x,
                y,
                z,
                value,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
                ?ColorBar: ColorBar,
                ?IsoMin: float,
                ?IsoMax: float,
                ?Caps: Caps,
                ?Slices: Slices,
                ?Surface: Surface,
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

            Trace3D.initIsoSurface (
                Trace3DStyle.IsoSurface(
                    X = x,
                    Y = y,
                    Z = z,
                    Value = value,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?ColorScale = ColorScale,
                    ?ShowScale = ShowScale,
                    ?ColorBar = ColorBar,
                    ?IsoMin = IsoMin,
                    ?IsoMax = IsoMax,
                    ?Caps = Caps,
                    ?Slices = Slices,
                    ?Surface = Surface

                )
            )
            |> GenericChart.ofTraceObject useDefaults
            |> GenericChart.addLayout (
                Layout.init () |> Layout.setScene (StyleParam.SubPlotId.Scene 1, Scene.init (Camera = camera))
            )

        /// <summary>
        /// Creates an isosurface plot from encoded coordinate and value arrays.
        /// </summary>
        [<Extension>]
        static member IsoSurface
            (
                xEncoded: EncodedTypedArray,
                yEncoded: EncodedTypedArray,
                zEncoded: EncodedTypedArray,
                valueEncoded: EncodedTypedArray,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
                ?ColorBar: ColorBar,
                ?IsoMin: float,
                ?IsoMax: float,
                ?Caps: Caps,
                ?Slices: Slices,
                ?Surface: Surface,
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

            Trace3D.initIsoSurface (
                Trace3DStyle.IsoSurface(
                    XEncoded = xEncoded,
                    YEncoded = yEncoded,
                    ZEncoded = zEncoded,
                    ValueEncoded = valueEncoded,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?ColorScale = ColorScale,
                    ?ShowScale = ShowScale,
                    ?ColorBar = ColorBar,
                    ?IsoMin = IsoMin,
                    ?IsoMax = IsoMax,
                    ?Caps = Caps,
                    ?Slices = Slices,
                    ?Surface = Surface

                )
            )
            |> GenericChart.ofTraceObject useDefaults
            |> GenericChart.addLayout (
                Layout.init () |> Layout.setScene (StyleParam.SubPlotId.Scene 1, Scene.init (Camera = camera))
            )
