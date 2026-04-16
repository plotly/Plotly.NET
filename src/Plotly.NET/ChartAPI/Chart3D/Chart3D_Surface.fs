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
module Chart3D_Surface =

    [<Extension>]
    type Chart =
        /// <summary>
        /// Creates a surface plot.
        ///
        /// Surface plots plot a z value as a function of x and y, creating a three-dimensional surface.
        ///
        /// The data the describes the coordinates of the surface is set in `z`. Data in `z` should be a 2D array.
        /// Coordinates in `x` and `y` can either be 1D arrays or 2D arrays (e.g. to graph parametric surfaces). If not provided in `x` and `y`, the x and y coordinates are assumed to be linear starting at 0 with a unit step.
        /// The color scale corresponds to the `z` values by default. For custom color scales, use `surfacecolor` which should be a 2D array, where its bounds can be controlled using `cmin` and `cmax`.
        /// </summary>
        /// <param name="zData">Two-dimensional data array representing the surface's z values</param>
        /// <param name="X">Sets the x coordinates.</param>
        /// <param name="Y">Sets the y coordinates.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="Contours">Sets the contours on the surface</param>
        /// <param name="ColorScale">Sets the colorscale of the surface</param>
        /// <param name="ShowScale">Whether or not to show the colorbar/colorscale</param>
        /// <param name="CameraProjectionType">Sets the camera projection type of this trace.</param>
        /// <param name="Camera">Sets the camera of this trace.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Surface
            (
                zData,
                ?X: seq<#IConvertible>,
                ?Y: seq<#IConvertible>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?Contours: Contours,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
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

            Trace3D.initSurface (
                Trace3DStyle.Surface(
                    Z = zData,
                    ?X = X,
                    ?Y = Y,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?Contours = Contours,
                    ?ColorScale = ColorScale,
                    ?ShowScale = ShowScale
                )
            )

            |> GenericChart.ofTraceObject useDefaults
            |> GenericChart.addLayout (
                Layout.init () |> Layout.setScene (StyleParam.SubPlotId.Scene 1, Scene.init (Camera = camera))
            )

        /// <summary>
        /// Creates a surface plot from an encoded z matrix and optional encoded x and y coordinates.
        /// </summary>
        [<Extension>]
        static member Surface
            (
                zEncoded: EncodedTypedArray,
                ?xEncoded: EncodedTypedArray,
                ?yEncoded: EncodedTypedArray,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?Contours: Contours,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
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

            Trace3D.initSurface (
                Trace3DStyle.Surface(
                    ZEncoded = zEncoded,
                    ?XEncoded = xEncoded,
                    ?YEncoded = yEncoded,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?Contours = Contours,
                    ?ColorScale = ColorScale,
                    ?ShowScale = ShowScale
                )
            )
            |> GenericChart.ofTraceObject useDefaults
            |> GenericChart.addLayout (
                Layout.init () |> Layout.setScene (StyleParam.SubPlotId.Scene 1, Scene.init (Camera = camera))
            )

        /// <summary>
        /// Visualizes a 3D mesh.
        ///
        /// Draws sets of triangles with coordinates given by three 1-dimensional arrays in `x`, `y`, `z` and
        ///
        /// (1) a sets of `i`, `j`, `k` indices or
        ///
        /// (2) Delaunay triangulation or
        ///
        /// (3) the Alpha-shape algorithm or
        ///
        /// (4) the Convex-hull algorithm
        /// </summary>
        /// <param name="x">Sets the X coordinates of the vertices. The nth element of vectors `x`, `y` and `z` jointly represent the X, Y and Z coordinates of the nth vertex.</param>
        /// <param name="y">Sets the Y coordinates of the vertices. The nth element of vectors `x`, `y` and `z` jointly represent the X, Y and Z coordinates of the nth vertex.</param>
        /// <param name="z">Sets the Z coordinates of the vertices. The nth element of vectors `x`, `y` and `z` jointly represent the X, Y and Z coordinates of the nth vertex.</param>
        /// <param name="I">A vector of vertex indices, i.e. integer values between 0 and the length of the vertex vectors, representing the "first" vertex of a triangle. For example, `{i[m], j[m], k[m]}` together represent face m (triangle m) in the mesh, where `i[m] = n` points to the triplet `{x[n], y[n], z[n]}` in the vertex arrays. Therefore, each element in `i` represents a point in space, which is the first vertex of a triangle.</param>
        /// <param name="J">A vector of vertex indices, i.e. integer values between 0 and the length of the vertex vectors, representing the "second" vertex of a triangle. For example, `{i[m], j[m], k[m]}` together represent face m (triangle m) in the mesh, where `j[m] = n` points to the triplet `{x[n], y[n], z[n]}` in the vertex arrays. Therefore, each element in `j` represents a point in space, which is the second vertex of a triangle.</param>
        /// <param name="K">A vector of vertex indices, i.e. integer values between 0 and the length of the vertex vectors, representing the "third" vertex of a triangle. For example, `{i[m], j[m], k[m]}` together represent face m (triangle m) in the mesh, where `k[m] = n` points to the triplet `{x[n], y[n], z[n]}` in the vertex arrays. Therefore, each element in `k` represents a point in space, which is the third vertex of a triangle.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="Color">Sets the color of the whole mesh</param>
        /// <param name="Contour">Sets the style and visibility of contours</param>
        /// <param name="ColorScale">Sets the colorscale</param>
        /// <param name="ShowScale">Whether or not to show the colorbar/colorscale</param>
        /// <param name="ColorBar">Sets the colorbar</param>
        /// <param name="FlatShading">Determines whether or not normal smoothing is applied to the meshes, creating meshes with an angular, low-poly look via flat reflections.</param>
        /// <param name="TriangulationAlgorithm">Determines how the mesh surface triangles are derived from the set of vertices (points) represented by the `x`, `y` and `z` arrays, if the `i`, `j`, `k` arrays are not supplied.</param>
        /// <param name="CameraProjectionType">Sets the camera projection type of this trace.</param>
        /// <param name="Camera">Sets the camera of this trace.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Mesh3D
            (
                x: seq<#IConvertible>,
                y: seq<#IConvertible>,
                z: seq<#IConvertible>,
                ?I: seq<#IConvertible>,
                ?J: seq<#IConvertible>,
                ?K: seq<#IConvertible>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?Color: Color,
                ?Contour: Contour,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
                ?ColorBar: ColorBar,
                ?FlatShading: bool,
                ?TriangulationAlgorithm: StyleParam.TriangulationAlgorithm,
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

            Trace3D.initMesh3D (
                Trace3DStyle.Mesh3D(
                    X = x,
                    Y = y,
                    Z = z,
                    ?I = I,
                    ?J = J,
                    ?K = K,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?Color = Color,
                    ?Contour = Contour,
                    ?ColorScale = ColorScale,
                    ?ShowScale = ShowScale,
                    ?ColorBar = ColorBar,
                    ?FlatShading = FlatShading,
                    ?AlphaHull = TriangulationAlgorithm
                )
            )
            |> GenericChart.ofTraceObject useDefaults
            |> GenericChart.addLayout (
                Layout.init () |> Layout.setScene (StyleParam.SubPlotId.Scene 1, Scene.init (Camera = camera))
            )

        /// <summary>
        /// Visualizes a 3D mesh from encoded coordinate and optional encoded topology/intensity arrays.
        /// </summary>
        [<Extension>]
        static member Mesh3D
            (
                xEncoded: EncodedTypedArray,
                yEncoded: EncodedTypedArray,
                zEncoded: EncodedTypedArray,
                ?iEncoded: EncodedTypedArray,
                ?jEncoded: EncodedTypedArray,
                ?kEncoded: EncodedTypedArray,
                ?intensityEncoded: EncodedTypedArray,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?Color: Color,
                ?Contour: Contour,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
                ?ColorBar: ColorBar,
                ?FlatShading: bool,
                ?TriangulationAlgorithm: StyleParam.TriangulationAlgorithm,
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

            Trace3D.initMesh3D (
                Trace3DStyle.Mesh3D(
                    XEncoded = xEncoded,
                    YEncoded = yEncoded,
                    ZEncoded = zEncoded,
                    ?IEncoded = iEncoded,
                    ?JEncoded = jEncoded,
                    ?KEncoded = kEncoded,
                    ?IntensityEncoded = intensityEncoded,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?Color = Color,
                    ?Contour = Contour,
                    ?ColorScale = ColorScale,
                    ?ShowScale = ShowScale,
                    ?ColorBar = ColorBar,
                    ?FlatShading = FlatShading,
                    ?AlphaHull = TriangulationAlgorithm
                )
            )
            |> GenericChart.ofTraceObject useDefaults
            |> GenericChart.addLayout (
                Layout.init () |> Layout.setScene (StyleParam.SubPlotId.Scene 1, Scene.init (Camera = camera))
            )

        /// <summary>
        /// Visualizes a 3D mesh.
        ///
        /// Draws sets of triangles with coordinates given by three 1-dimensional arrays in `x`, `y`, `z` and
        ///
        /// (1) a sets of `i`, `j`, `k` indices or
        ///
        /// (2) Delaunay triangulation or
        ///
        /// (3) the Alpha-shape algorithm or
        ///
        /// (4) the Convex-hull algorithm
        /// </summary>
        /// <param name="xyz">Sets the X, Y, and Z coordinates of the vertices. The nth element of vectors `x`, `y` and `z` jointly represent the X, Y and Z coordinates of the nth vertex.</param>
        /// <param name="I">A vector of vertex indices, i.e. integer values between 0 and the length of the vertex vectors, representing the "first" vertex of a triangle. For example, `{i[m], j[m], k[m]}` together represent face m (triangle m) in the mesh, where `i[m] = n` points to the triplet `{x[n], y[n], z[n]}` in the vertex arrays. Therefore, each element in `i` represents a point in space, which is the first vertex of a triangle.</param>
        /// <param name="J">A vector of vertex indices, i.e. integer values between 0 and the length of the vertex vectors, representing the "second" vertex of a triangle. For example, `{i[m], j[m], k[m]}` together represent face m (triangle m) in the mesh, where `j[m] = n` points to the triplet `{x[n], y[n], z[n]}` in the vertex arrays. Therefore, each element in `j` represents a point in space, which is the second vertex of a triangle.</param>
        /// <param name="K">A vector of vertex indices, i.e. integer values between 0 and the length of the vertex vectors, representing the "third" vertex of a triangle. For example, `{i[m], j[m], k[m]}` together represent face m (triangle m) in the mesh, where `k[m] = n` points to the triplet `{x[n], y[n], z[n]}` in the vertex arrays. Therefore, each element in `k` represents a point in space, which is the third vertex of a triangle.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="Color">Sets the color of the whole mesh</param>
        /// <param name="Contour">Sets the style and visibility of contours</param>
        /// <param name="ColorScale">Sets the colorscale</param>
        /// <param name="ShowScale">Whether or not to show the colorbar/colorscale</param>
        /// <param name="ColorBar">Sets the colorbar</param>
        /// <param name="FlatShading">Determines whether or not normal smoothing is applied to the meshes, creating meshes with an angular, low-poly look via flat reflections.</param>
        /// <param name="TriangulationAlgorithm">Determines how the mesh surface triangles are derived from the set of vertices (points) represented by the `x`, `y` and `z` arrays, if the `i`, `j`, `k` arrays are not supplied.</param>
        /// <param name="CameraProjectionType">Sets the camera projection type of this trace.</param>
        /// <param name="Camera">Sets the camera of this trace.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Mesh3D
            (
                xyz: seq<#IConvertible * #IConvertible * #IConvertible>,
                ?I: seq<#IConvertible>,
                ?J: seq<#IConvertible>,
                ?K: seq<#IConvertible>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?Color: Color,
                ?Contour: Contour,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
                ?ColorBar: ColorBar,
                ?FlatShading: bool,
                ?TriangulationAlgorithm: StyleParam.TriangulationAlgorithm,
                ?CameraProjectionType: StyleParam.CameraProjectionType,
                ?Camera: Camera,
                ?UseDefaults: bool
            ) =

            let x, y, z = Seq.unzip3 xyz

            Chart.Mesh3D(
                x,
                y,
                z,
                ?I = I,
                ?J = J,
                ?K = K,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?Color = Color,
                ?Contour = Contour,
                ?ColorScale = ColorScale,
                ?ShowScale = ShowScale,
                ?ColorBar = ColorBar,
                ?FlatShading = FlatShading,
                ?TriangulationAlgorithm = TriangulationAlgorithm,
                ?CameraProjectionType = CameraProjectionType,
                ?Camera = Camera,
                ?UseDefaults = UseDefaults
            )

