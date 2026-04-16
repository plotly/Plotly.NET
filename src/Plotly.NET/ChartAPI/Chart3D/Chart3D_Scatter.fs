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
module Chart3D_Scatter =

    [<Extension>]
    type Chart =
        /// <summary>
        /// Creates a Scatter3D plot.
        ///
        /// In general, Scatter3D Plots plot three-dimensional data on 3 cartesian position scales in the X, Y, and Z dimension.
        ///
        /// Scatter3D charts are the basis of Point3D, Line3D, and Bubble3D Charts, and can be customized as such. We also provide abstractions for those: Chart.Line3D, Chart.Point3D, Chart.Bubble3D
        /// </summary>
        /// <param name="x">Sets the x coordinates of the plotted data.</param>
        /// <param name="y">Sets the y coordinates of the plotted data.</param>
        /// <param name="z">Sets the z coordinates of the plotted data.</param>
        /// <param name="mode">Determines the drawing mode for this scatter trace.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker</param>
        /// <param name="MarkerOutline">Sets the outline of the marker</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments)</param>
        /// <param name="LineColor">Sets the color of the line</param>
        /// <param name="LineColorScale">Sets the colorscale of the line</param>
        /// <param name="LineWidth">Sets the width of the line</param>
        /// <param name="LineDash">sets the drawing style of the line</param>
        /// <param name="Line">Sets the line (use this for more finegrained control than the other line-associated arguments)</param>
        /// <param name="CameraProjectionType">Sets the camera projection type of this trace.</param>
        /// <param name="Camera">Sets the camera of this trace.</param>
        /// <param name="Projection">Sets the projection of this trace.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Scatter3D
            (
                x: seq<#IConvertible>,
                y: seq<#IConvertible>,
                z: seq<#IConvertible>,
                mode: StyleParam.Mode,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol3D,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol3D>,
                ?Marker: Marker,
                ?LineColor: Color,
                ?LineColorScale: StyleParam.Colorscale,
                ?LineWidth: float,
                ?LineDash: StyleParam.DrawingStyle,
                ?Line: Line,
                ?CameraProjectionType: StyleParam.CameraProjectionType,
                ?Camera: Camera,
                ?Projection: Projection,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let marker =
                Marker
                |> Option.defaultValue (TraceObjects.Marker.init ())
                |> TraceObjects.Marker.style (
                    ?Color = MarkerColor,
                    ?Outline = MarkerOutline,
                    ?Symbol3D = MarkerSymbol,
                    ?MultiSymbol3D = MultiMarkerSymbol,
                    ?Colorscale = MarkerColorScale,
                    ?MultiOpacity = MultiOpacity
                )

            let line =
                Line
                |> Option.defaultValue (Plotly.NET.Line.init ())
                |> Plotly.NET.Line.style (
                    ?Color = LineColor,
                    ?Dash = LineDash,
                    ?Colorscale = LineColorScale,
                    ?Width = LineWidth
                )

            let cameraProjection =
                defaultArg CameraProjectionType StyleParam.CameraProjectionType.Perspective

            let camera =
                Camera
                |> Option.defaultValue (LayoutObjects.Camera.init ())
                |> LayoutObjects.Camera.style (Projection = CameraProjection.init (ProjectionType = cameraProjection))

            Trace3D.initScatter3D (
                Trace3DStyle.Scatter3D(
                    X = x,
                    Y = y,
                    Z = z,
                    Mode = mode,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?TextPosition = TextPosition,
                    ?MultiTextPosition = MultiTextPosition,
                    ?Projection = Projection,
                    Marker = marker,
                    Line = line
                )
            )

            |> GenericChart.ofTraceObject useDefaults
            |> GenericChart.addLayout (
                Layout.init () |> Layout.setScene (StyleParam.SubPlotId.Scene 1, Scene.init (Camera = camera))
            )

        /// <summary>
        /// Creates a Scatter3D plot from encoded x, y, and z coordinates.
        /// </summary>
        /// <param name="xEncoded">Sets the x coordinates of the plotted data as an encoded typed array.</param>
        /// <param name="yEncoded">Sets the y coordinates of the plotted data as an encoded typed array.</param>
        /// <param name="zEncoded">Sets the z coordinates of the plotted data as an encoded typed array.</param>
        /// <param name="mode">Determines the drawing mode for this scatter trace.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker</param>
        /// <param name="MarkerOutline">Sets the outline of the marker</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments)</param>
        /// <param name="LineColor">Sets the color of the line</param>
        /// <param name="LineColorScale">Sets the colorscale of the line</param>
        /// <param name="LineWidth">Sets the width of the line</param>
        /// <param name="LineDash">sets the drawing style of the line</param>
        /// <param name="Line">Sets the line (use this for more finegrained control than the other line-associated arguments)</param>
        /// <param name="CameraProjectionType">Sets the camera projection type of this trace.</param>
        /// <param name="Camera">Sets the camera of this trace.</param>
        /// <param name="Projection">Sets the projection of this trace.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Scatter3D
            (
                xEncoded: EncodedTypedArray,
                yEncoded: EncodedTypedArray,
                zEncoded: EncodedTypedArray,
                mode: StyleParam.Mode,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol3D,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol3D>,
                ?Marker: Marker,
                ?LineColor: Color,
                ?LineColorScale: StyleParam.Colorscale,
                ?LineWidth: float,
                ?LineDash: StyleParam.DrawingStyle,
                ?Line: Line,
                ?CameraProjectionType: StyleParam.CameraProjectionType,
                ?Camera: Camera,
                ?Projection: Projection,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let marker =
                Marker
                |> Option.defaultValue (TraceObjects.Marker.init ())
                |> TraceObjects.Marker.style (
                    ?Color = MarkerColor,
                    ?Outline = MarkerOutline,
                    ?Symbol3D = MarkerSymbol,
                    ?MultiSymbol3D = MultiMarkerSymbol,
                    ?Colorscale = MarkerColorScale,
                    ?MultiOpacity = MultiOpacity
                )

            let line =
                Line
                |> Option.defaultValue (Plotly.NET.Line.init ())
                |> Plotly.NET.Line.style (
                    ?Color = LineColor,
                    ?Dash = LineDash,
                    ?Colorscale = LineColorScale,
                    ?Width = LineWidth
                )

            let cameraProjection =
                defaultArg CameraProjectionType StyleParam.CameraProjectionType.Perspective

            let camera =
                Camera
                |> Option.defaultValue (LayoutObjects.Camera.init ())
                |> LayoutObjects.Camera.style (Projection = CameraProjection.init (ProjectionType = cameraProjection))

            Trace3D.initScatter3D (
                Trace3DStyle.Scatter3D(
                    XEncoded = xEncoded,
                    YEncoded = yEncoded,
                    ZEncoded = zEncoded,
                    Mode = mode,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?TextPosition = TextPosition,
                    ?MultiTextPosition = MultiTextPosition,
                    ?Projection = Projection,
                    Marker = marker,
                    Line = line
                )
            )
            |> GenericChart.ofTraceObject useDefaults
            |> GenericChart.addLayout (
                Layout.init () |> Layout.setScene (StyleParam.SubPlotId.Scene 1, Scene.init (Camera = camera))
            )


        /// <summary>
        /// Creates a Scatter3D plot.
        ///
        /// In general, Scatter3D Plots plot three-dimensional data on 3 cartesian position scales in the X, Y, and Z dimension.
        ///
        /// Scatter3D charts are the basis of Point3D, Line3D, and Bubble3D Charts, and can be customized as such. We also provide abstractions for those: Chart.Line3D, Chart.Point3D, Chart.Bubble3D
        /// </summary>
        /// <param name="xyz">Sets the x, y, and z coordinates of the plotted data.</param>
        /// <param name="mode">Determines the drawing mode for this scatter trace.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker</param>
        /// <param name="MarkerOutline">Sets the outline of the marker</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments)</param>
        /// <param name="LineColor">Sets the color of the line</param>
        /// <param name="LineColorScale">Sets the colorscale of the line</param>
        /// <param name="LineWidth">Sets the width of the line</param>
        /// <param name="LineDash">sets the drawing style of the line</param>
        /// <param name="Line">Sets the line (use this for more finegrained control than the other line-associated arguments)</param>
        /// <param name="CameraProjectionType">Sets the camera projection type of this trace.</param>
        /// <param name="Camera">Sets the camera of this trace.</param>
        /// <param name="Projection">Sets the projection of this trace.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Scatter3D
            (
                xyz: seq<#IConvertible * #IConvertible * #IConvertible>,
                mode: StyleParam.Mode,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol3D,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol3D>,
                ?Marker: Marker,
                ?LineColor: Color,
                ?LineColorScale: StyleParam.Colorscale,
                ?LineWidth: float,
                ?LineDash: StyleParam.DrawingStyle,
                ?Line: Line,
                ?CameraProjectionType: StyleParam.CameraProjectionType,
                ?Camera: Camera,
                ?Projection: Projection,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let x, y, z = Seq.unzip3 xyz

            Chart.Scatter3D(
                x,
                y,
                z,
                mode,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerSymbol = MarkerSymbol,
                ?MultiMarkerSymbol = MultiMarkerSymbol,
                ?Marker = Marker,
                ?LineColor = LineColor,
                ?LineColorScale = LineColorScale,
                ?LineWidth = LineWidth,
                ?LineDash = LineDash,
                ?Line = Line,
                ?CameraProjectionType = CameraProjectionType,
                ?Camera = Camera,
                ?Projection = Projection,
                ?UseDefaults = UseDefaults
            )

        /// <summary>
        /// Creates a Point3D plot.
        ///
        /// Point3D Plots plot three-dimensional data on 3 cartesian position scales in the X, Y, and Z dimension as points.
        /// </summary>
        /// <param name="x">Sets the x coordinates of the plotted data.</param>
        /// <param name="y">Sets the y coordinates of the plotted data.</param>
        /// <param name="z">Sets the z coordinates of the plotted data.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker</param>
        /// <param name="MarkerOutline">Sets the outline of the marker</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments)</param>
        /// <param name="CameraProjectionType">Sets the camera projection type of this trace.</param>
        /// <param name="Camera">Sets the camera of this trace.</param>
        /// <param name="Projection">Sets the projection of this trace.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Point3D
            (
                x: seq<#IConvertible>,
                y: seq<#IConvertible>,
                z: seq<#IConvertible>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol3D,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol3D>,
                ?Marker: Marker,
                ?CameraProjectionType: StyleParam.CameraProjectionType,
                ?Camera: Camera,
                ?Projection: Projection,
                ?UseDefaults: bool
            ) =

            // if text position or font is set, then show labels (not only when hovering)
            let changeMode =
                StyleParam.ModeUtils.showText (TextPosition.IsSome || MultiTextPosition.IsSome)

            Chart.Scatter3D(
                x = x,
                y = y,
                z = z,
                mode = changeMode StyleParam.Mode.Markers,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerSymbol = MarkerSymbol,
                ?MultiMarkerSymbol = MultiMarkerSymbol,
                ?Marker = Marker,
                ?Projection = Projection,
                ?CameraProjectionType = CameraProjectionType,
                ?Camera = Camera,
                ?UseDefaults = UseDefaults
            )

        /// <summary>
        /// Creates a Point3D plot.
        ///
        /// Point3D Plots plot three-dimensional data on 3 cartesian position scales in the X, Y, and Z dimension as points.
        /// </summary>
        /// <param name="xyz">Sets the x, y, and z coordinates of the plotted data.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker</param>
        /// <param name="MarkerOutline">Sets the outline of the marker</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments)</param>
        /// <param name="CameraProjectionType">Sets the camera projection type of this trace.</param>
        /// <param name="Camera">Sets the camera of this trace.</param>
        /// <param name="Projection">Sets the projection of this trace.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Point3D
            (
                xyz: seq<#IConvertible * #IConvertible * #IConvertible>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol3D,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol3D>,
                ?Marker: Marker,
                ?CameraProjectionType: StyleParam.CameraProjectionType,
                ?Camera: Camera,
                ?Projection: Projection,
                ?UseDefaults: bool
            ) =

            let x, y, z = Seq.unzip3 xyz

            Chart.Point3D(
                x,
                y,
                z,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerSymbol = MarkerSymbol,
                ?MultiMarkerSymbol = MultiMarkerSymbol,
                ?Marker = Marker,
                ?CameraProjectionType = CameraProjectionType,
                ?Camera = Camera,
                ?Projection = Projection,
                ?UseDefaults = UseDefaults
            )

        /// <summary>Creates a Point3D plot from encoded x, y, and z coordinates.</summary>
        [<Extension>]
        static member Point3D
            (
                xEncoded: EncodedTypedArray,
                yEncoded: EncodedTypedArray,
                zEncoded: EncodedTypedArray,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol3D,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol3D>,
                ?Marker: Marker,
                ?CameraProjectionType: StyleParam.CameraProjectionType,
                ?Camera: Camera,
                ?Projection: Projection,
                ?UseDefaults: bool
            ) =

            let changeMode =
                StyleParam.ModeUtils.showText (TextPosition.IsSome || MultiTextPosition.IsSome)

            Chart.Scatter3D(
                xEncoded = xEncoded,
                yEncoded = yEncoded,
                zEncoded = zEncoded,
                mode = changeMode StyleParam.Mode.Markers,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerSymbol = MarkerSymbol,
                ?MultiMarkerSymbol = MultiMarkerSymbol,
                ?Marker = Marker,
                ?Projection = Projection,
                ?CameraProjectionType = CameraProjectionType,
                ?Camera = Camera,
                ?UseDefaults = UseDefaults
            )


        /// <summary>
        /// Creates a Line3D plot.
        ///
        /// Line3D Plots plot three-dimensional data on 3 cartesian position scales in the X, Y, and Z dimension as a line connecting the individual datums.
        /// </summary>
        /// <param name="x">Sets the x coordinates of the plotted data.</param>
        /// <param name="y">Sets the y coordinates of the plotted data.</param>
        /// <param name="z">Sets the z coordinates of the plotted data.</param>
        /// <param name="ShowMarkers">Whether to show markers for the datums additionally to the line</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker</param>
        /// <param name="MarkerOutline">Sets the outline of the marker</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments)</param>
        /// <param name="LineColor">Sets the color of the line</param>
        /// <param name="LineColorScale">Sets the colorscale of the line</param>
        /// <param name="LineWidth">Sets the width of the line</param>
        /// <param name="LineDash">sets the drawing style of the line</param>
        /// <param name="Line">Sets the line (use this for more finegrained control than the other line-associated arguments)</param>
        /// <param name="CameraProjectionType">Sets the camera projection type of this trace.</param>
        /// <param name="Camera">Sets the camera of this trace.</param>
        /// <param name="Projection">Sets the projection of this trace.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Line3D
            (
                x: seq<#IConvertible>,
                y: seq<#IConvertible>,
                z: seq<#IConvertible>,
                ?ShowMarkers: bool,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol3D,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol3D>,
                ?Marker: Marker,
                ?LineColor: Color,
                ?LineColorScale: StyleParam.Colorscale,
                ?LineWidth: float,
                ?LineDash: StyleParam.DrawingStyle,
                ?Line: Line,
                ?CameraProjectionType: StyleParam.CameraProjectionType,
                ?Camera: Camera,
                ?Projection: Projection,
                ?UseDefaults: bool
            ) =
            let changeMode =
                let isShowMarker =
                    match ShowMarkers with
                    | Some isShow -> isShow
                    | Option.None -> false

                StyleParam.ModeUtils.showText (TextPosition.IsSome || MultiTextPosition.IsSome)
                >> StyleParam.ModeUtils.showMarker (isShowMarker)

            Chart.Scatter3D(
                x = x,
                y = y,
                z = z,
                mode = changeMode StyleParam.Mode.Lines,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerSymbol = MarkerSymbol,
                ?MultiMarkerSymbol = MultiMarkerSymbol,
                ?Marker = Marker,
                ?LineColor = LineColor,
                ?LineColorScale = LineColorScale,
                ?LineWidth = LineWidth,
                ?LineDash = LineDash,
                ?Line = Line,
                ?CameraProjectionType = CameraProjectionType,
                ?Camera = Camera,
                ?Projection = Projection,
                ?UseDefaults = UseDefaults

            )

        /// <summary>
        /// Creates a Line3D plot.
        ///
        /// Line3D Plots plot three-dimensional data on 3 cartesian position scales in the X, Y, and Z dimension as a line connecting the individual datums.
        /// </summary>
        /// <param name="xyz">Sets the x, y, and z coordinates of the plotted data.</param>
        /// <param name="ShowMarkers">Whether to show markers for the datums additionally to the line</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker</param>
        /// <param name="MarkerOutline">Sets the outline of the marker</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments)</param>
        /// <param name="LineColor">Sets the color of the line</param>
        /// <param name="LineColorScale">Sets the colorscale of the line</param>
        /// <param name="LineWidth">Sets the width of the line</param>
        /// <param name="LineDash">sets the drawing style of the line</param>
        /// <param name="Line">Sets the line (use this for more finegrained control than the other line-associated arguments)</param>
        /// <param name="CameraProjectionType">Sets the camera projection type of this trace.</param>
        /// <param name="Camera">Sets the camera of this trace.</param>
        /// <param name="Projection">Sets the projection of this trace.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Line3D
            (
                xyz: seq<#IConvertible * #IConvertible * #IConvertible>,
                ?ShowMarkers: bool,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol3D,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol3D>,
                ?Marker: Marker,
                ?LineColor: Color,
                ?LineColorScale: StyleParam.Colorscale,
                ?LineWidth: float,
                ?LineDash: StyleParam.DrawingStyle,
                ?Line: Line,
                ?CameraProjectionType: StyleParam.CameraProjectionType,
                ?Camera: Camera,
                ?Projection: Projection,
                ?UseDefaults: bool
            ) =

            let x, y, z = Seq.unzip3 xyz

            Chart.Line3D(
                x,
                y,
                z,
                ?ShowMarkers = ShowMarkers,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerSymbol = MarkerSymbol,
                ?MultiMarkerSymbol = MultiMarkerSymbol,
                ?Marker = Marker,
                ?LineColor = LineColor,
                ?LineColorScale = LineColorScale,
                ?LineWidth = LineWidth,
                ?LineDash = LineDash,
                ?Line = Line,
                ?CameraProjectionType = CameraProjectionType,
                ?Camera = Camera,
                ?Projection = Projection,
                ?UseDefaults = UseDefaults
            )

        /// <summary>Creates a Line3D plot from encoded x, y, and z coordinates.</summary>
        [<Extension>]
        static member Line3D
            (
                xEncoded: EncodedTypedArray,
                yEncoded: EncodedTypedArray,
                zEncoded: EncodedTypedArray,
                ?ShowMarkers: bool,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol3D,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol3D>,
                ?Marker: Marker,
                ?LineColor: Color,
                ?LineColorScale: StyleParam.Colorscale,
                ?LineWidth: float,
                ?LineDash: StyleParam.DrawingStyle,
                ?Line: Line,
                ?CameraProjectionType: StyleParam.CameraProjectionType,
                ?Camera: Camera,
                ?Projection: Projection,
                ?UseDefaults: bool
            ) =

            let changeMode =
                let isShowMarker =
                    match ShowMarkers with
                    | Some isShow -> isShow
                    | Option.None -> false

                StyleParam.ModeUtils.showText (TextPosition.IsSome || MultiTextPosition.IsSome)
                >> StyleParam.ModeUtils.showMarker (isShowMarker)

            Chart.Scatter3D(
                xEncoded = xEncoded,
                yEncoded = yEncoded,
                zEncoded = zEncoded,
                mode = changeMode StyleParam.Mode.Lines,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerSymbol = MarkerSymbol,
                ?MultiMarkerSymbol = MultiMarkerSymbol,
                ?Marker = Marker,
                ?LineColor = LineColor,
                ?LineColorScale = LineColorScale,
                ?LineWidth = LineWidth,
                ?LineDash = LineDash,
                ?Line = Line,
                ?CameraProjectionType = CameraProjectionType,
                ?Camera = Camera,
                ?Projection = Projection,
                ?UseDefaults = UseDefaults
            )


        /// <summary>
        /// Creates a Bubble3D plot.
        ///
        /// Bubble3D Plots plot three-dimensional data on 3 cartesian position scales in the X, Y, and Z dimension as points, additionally using the points size as a 4th dimension.
        /// </summary>
        /// <param name="x">Sets the x coordinates of the plotted data.</param>
        /// <param name="y">Sets the y coordinates of the plotted data.</param>
        /// <param name="z">Sets the z coordinates of the plotted data.</param>
        /// <param name="sizes">Sets the size of the points</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker</param>
        /// <param name="MarkerOutline">Sets the outline of the marker</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments)</param>
        /// <param name="CameraProjectionType">Sets the camera projection type of this trace.</param>
        /// <param name="Camera">Sets the camera of this trace.</param>
        /// <param name="Projection">Sets the projection of this trace.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Bubble3D
            (
                x: seq<#IConvertible>,
                y: seq<#IConvertible>,
                z: seq<#IConvertible>,
                sizes: seq<int>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol3D,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol3D>,
                ?Marker: Marker,
                ?CameraProjectionType: StyleParam.CameraProjectionType,
                ?Camera: Camera,
                ?Projection: Projection,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let changeMode =
                StyleParam.ModeUtils.showText (TextPosition.IsSome || MultiTextPosition.IsSome)

            let marker =
                Marker
                |> Option.defaultValue (TraceObjects.Marker.init ())
                |> TraceObjects.Marker.style (
                    ?Color = MarkerColor,
                    ?Outline = MarkerOutline,
                    ?Symbol3D = MarkerSymbol,
                    ?MultiSymbol3D = MultiMarkerSymbol,
                    ?Colorscale = MarkerColorScale,
                    ?MultiOpacity = MultiOpacity,
                    MultiSize = sizes
                )

            let cameraProjection =
                defaultArg CameraProjectionType StyleParam.CameraProjectionType.Perspective

            let camera =
                Camera
                |> Option.defaultValue (LayoutObjects.Camera.init ())
                |> LayoutObjects.Camera.style (Projection = CameraProjection.init (ProjectionType = cameraProjection))

            Trace3D.initScatter3D (
                Trace3DStyle.Scatter3D(
                    X = x,
                    Y = y,
                    Z = z,
                    Mode = changeMode StyleParam.Mode.Markers,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?TextPosition = TextPosition,
                    ?MultiTextPosition = MultiTextPosition,
                    ?Projection = Projection,
                    Marker = marker
                )
            )

            |> GenericChart.ofTraceObject useDefaults
            |> GenericChart.addLayout (
                Layout.init () |> Layout.setScene (StyleParam.SubPlotId.Scene 1, Scene.init (Camera = camera))
            )

        /// <summary>Creates a Bubble3D plot from encoded x, y, and z coordinates.</summary>
        [<Extension>]
        static member Bubble3D
            (
                xEncoded: EncodedTypedArray,
                yEncoded: EncodedTypedArray,
                zEncoded: EncodedTypedArray,
                sizes: seq<int>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol3D,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol3D>,
                ?Marker: Marker,
                ?CameraProjectionType: StyleParam.CameraProjectionType,
                ?Camera: Camera,
                ?Projection: Projection,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let changeMode =
                StyleParam.ModeUtils.showText (TextPosition.IsSome || MultiTextPosition.IsSome)

            let marker =
                Marker
                |> Option.defaultValue (TraceObjects.Marker.init ())
                |> TraceObjects.Marker.style (
                    ?Color = MarkerColor,
                    ?Outline = MarkerOutline,
                    ?Symbol3D = MarkerSymbol,
                    ?MultiSymbol3D = MultiMarkerSymbol,
                    ?Colorscale = MarkerColorScale,
                    ?MultiOpacity = MultiOpacity,
                    MultiSize = sizes
                )

            let cameraProjection =
                defaultArg CameraProjectionType StyleParam.CameraProjectionType.Perspective

            let camera =
                Camera
                |> Option.defaultValue (LayoutObjects.Camera.init ())
                |> LayoutObjects.Camera.style (Projection = CameraProjection.init (ProjectionType = cameraProjection))

            Trace3D.initScatter3D (
                Trace3DStyle.Scatter3D(
                    XEncoded = xEncoded,
                    YEncoded = yEncoded,
                    ZEncoded = zEncoded,
                    Mode = changeMode StyleParam.Mode.Markers,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?TextPosition = TextPosition,
                    ?MultiTextPosition = MultiTextPosition,
                    ?Projection = Projection,
                    Marker = marker
                )
            )
            |> GenericChart.ofTraceObject useDefaults
            |> GenericChart.addLayout (
                Layout.init () |> Layout.setScene (StyleParam.SubPlotId.Scene 1, Scene.init (Camera = camera))
            )


        /// <summary>
        /// Creates a Bubble3D plot.
        ///
        /// Bubble3D Plots plot three-dimensional data on 3 cartesian position scales in the X, Y, and Z dimension as points, additionally using the points size as a 4th dimension.
        /// </summary>
        /// <param name="xyz">Sets the x, y, and z coordinates of the plotted data.</param>
        /// <param name="sizes">Sets the size of the points</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker</param>
        /// <param name="MarkerOutline">Sets the outline of the marker</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments)</param>
        /// <param name="CameraProjectionType">Sets the camera projection type of this trace.</param>
        /// <param name="Camera">Sets the camera of this trace.</param>
        /// <param name="Projection">Sets the projection of this trace.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Bubble3D
            (
                xyz,
                sizes,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol3D,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol3D>,
                ?Marker: Marker,
                ?CameraProjectionType: StyleParam.CameraProjectionType,
                ?Camera: Camera,
                ?Projection: Projection,
                ?UseDefaults: bool
            ) =

            let x, y, z = Seq.unzip3 xyz

            Chart.Bubble3D(
                x,
                y,
                z,
                sizes,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerSymbol = MarkerSymbol,
                ?MultiMarkerSymbol = MultiMarkerSymbol,
                ?Marker = Marker,
                ?CameraProjectionType = CameraProjectionType,
                ?Camera = Camera,
                ?Projection = Projection,
                ?UseDefaults = UseDefaults

            )

        /// <summary>
        /// Creates a Bubble3D plot.
        ///
        /// Bubble3D Plots plot three-dimensional data on 3 cartesian position scales in the X, Y, and Z dimension as points, additionally using the points size as a 4th dimension.
        /// </summary>
        /// <param name="xyzsizes">Sets the x, y, and z coordinates together with the point size.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker</param>
        /// <param name="MarkerOutline">Sets the outline of the marker</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments)</param>
        /// <param name="CameraProjectionType">Sets the camera projection type of this trace.</param>
        /// <param name="Camera">Sets the camera of this trace.</param>
        /// <param name="Projection">Sets the projection of this trace.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Bubble3D
            (
                xyzsizes,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol3D,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol3D>,
                ?Marker: Marker,
                ?CameraProjectionType: StyleParam.CameraProjectionType,
                ?Camera: Camera,
                ?Projection: Projection,
                ?UseDefaults: bool
            ) =

            let x, y, z, sizes =
                xyzsizes |> Seq.map (fun (x, _, _, _) -> x),
                xyzsizes |> Seq.map (fun (_, y, _, _) -> y),
                xyzsizes |> Seq.map (fun (_, _, z, _) -> z),
                xyzsizes |> Seq.map (fun (_, _, _, size) -> size)

            Chart.Bubble3D(
                x,
                y,
                z,
                sizes,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerSymbol = MarkerSymbol,
                ?MultiMarkerSymbol = MultiMarkerSymbol,
                ?Marker = Marker,
                ?CameraProjectionType = CameraProjectionType,
                ?Camera = Camera,
                ?Projection = Projection,
                ?UseDefaults = UseDefaults

            )

