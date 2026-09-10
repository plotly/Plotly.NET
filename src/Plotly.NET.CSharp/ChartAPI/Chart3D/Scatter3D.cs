using System;
using System.Collections.Generic;
using Plotly.NET;
using Plotly.NET.LayoutObjects;
using Plotly.NET.TraceObjects;
using static Plotly.NET.StyleParam;

namespace Plotly.NET.CSharp;

public static partial class Chart
{
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
        public static GenericChart Scatter3D<XType, YType, ZType, TextType>(
            IEnumerable<XType> x,
            IEnumerable<YType> y,
            IEnumerable<ZType> z,
            StyleParam.Mode mode,
            Optional<string> Name = default,
            Optional<bool> ShowLegend = default,
            Optional<double> Opacity = default,
            Optional<IEnumerable<double>> MultiOpacity = default,
            Optional<TextType> Text = default,
            Optional<IEnumerable<TextType>> MultiText = default,
            Optional<StyleParam.TextPosition> TextPosition = default,
            Optional<IEnumerable<StyleParam.TextPosition>> MultiTextPosition = default,
            Optional<Color> MarkerColor = default,
            Optional<StyleParam.Colorscale> MarkerColorScale = default,
            Optional<Line> MarkerOutline = default,
            Optional<StyleParam.MarkerSymbol3D> MarkerSymbol = default,
            Optional<IEnumerable<StyleParam.MarkerSymbol3D>> MultiMarkerSymbol = default,
            Optional<Marker> Marker = default,
            Optional<Color> LineColor = default,
            Optional<StyleParam.Colorscale> LineColorScale = default,
            Optional<double> LineWidth = default,
            Optional<StyleParam.DrawingStyle> LineDash = default,
            Optional<Line> Line = default,
            Optional<StyleParam.CameraProjectionType> CameraProjectionType = default ,
            Optional<Camera> Camera = default,
            Optional<Projection> Projection = default,
            Optional<bool> UseDefaults = default
        )
            where XType: IConvertible
            where YType: IConvertible
            where ZType : IConvertible
            where TextType : IConvertible
            
            => Plotly.NET.Chart3D_Scatter.Chart.Scatter3D<XType, YType, ZType, TextType>(
                x: x,
                y: y,
                z: z,
                mode: mode,
                Name: Name.ToOption(),
                ShowLegend: ShowLegend.ToOption(),
                Opacity: Opacity.ToOption(),
                MultiOpacity: MultiOpacity.ToOption(),
                Text: Text.ToOption(),
                MultiText: MultiText.ToOption(),
                TextPosition: TextPosition.ToOption(),
                MultiTextPosition: MultiTextPosition.ToOption(),
                MarkerColor: MarkerColor.ToOption(),
                MarkerColorScale: MarkerColorScale.ToOption(),
                MarkerOutline: MarkerOutline.ToOption(),
                MarkerSymbol: MarkerSymbol.ToOption(),
                MultiMarkerSymbol: MultiMarkerSymbol.ToOption(),
                Marker: Marker.ToOption(),
                LineColor: LineColor.ToOption(),
                LineColorScale: LineColorScale.ToOption(),
                LineWidth: LineWidth.ToOption(),
                LineDash: LineDash.ToOption(),
                Line: Line.ToOption(),
                Projection: Projection.ToOption(),
                CameraProjectionType: CameraProjectionType.ToOption(),
                Camera: Camera.ToOption(),
                UseDefaults: UseDefaults.ToOption()
            );

    /// <summary>Creates a Scatter3D plot from encoded x, y, and z typed arrays.</summary>
    /// <param name="xEncoded">Sets the x coordinates as an encoded typed array.</param>
    /// <param name="yEncoded">Sets the y coordinates as an encoded typed array.</param>
    /// <param name="zEncoded">Sets the z coordinates as an encoded typed array.</param>
    /// <param name="mode">Determines the drawing mode for this scatter trace.</param>
    /// <param name="UseDefaults">If set to false, ignore the global default settings set in <c>Defaults</c></param>
    public static GenericChart Scatter3D<TextType>(
        EncodedTypedArray xEncoded,
        EncodedTypedArray yEncoded,
        EncodedTypedArray zEncoded,
        StyleParam.Mode mode,
        Optional<string> Name = default,
        Optional<bool> ShowLegend = default,
        Optional<double> Opacity = default,
        Optional<IEnumerable<double>> MultiOpacity = default,
        Optional<TextType> Text = default,
        Optional<IEnumerable<TextType>> MultiText = default,
        Optional<StyleParam.TextPosition> TextPosition = default,
        Optional<IEnumerable<StyleParam.TextPosition>> MultiTextPosition = default,
        Optional<Color> MarkerColor = default,
        Optional<StyleParam.Colorscale> MarkerColorScale = default,
        Optional<Line> MarkerOutline = default,
        Optional<StyleParam.MarkerSymbol3D> MarkerSymbol = default,
        Optional<IEnumerable<StyleParam.MarkerSymbol3D>> MultiMarkerSymbol = default,
        Optional<Marker> Marker = default,
        Optional<Color> LineColor = default,
        Optional<StyleParam.Colorscale> LineColorScale = default,
        Optional<double> LineWidth = default,
        Optional<StyleParam.DrawingStyle> LineDash = default,
        Optional<Line> Line = default,
        Optional<StyleParam.CameraProjectionType> CameraProjectionType = default,
        Optional<Camera> Camera = default,
        Optional<Projection> Projection = default,
        Optional<bool> UseDefaults = default
    )
        where TextType : IConvertible
        =>
            Plotly.NET.Chart3D_Scatter.Chart.Scatter3D(
                xEncoded: xEncoded,
                yEncoded: yEncoded,
                zEncoded: zEncoded,
                mode: mode,
                Name: Name.ToOption(),
                ShowLegend: ShowLegend.ToOption(),
                Opacity: Opacity.ToOption(),
                MultiOpacity: MultiOpacity.ToOption(),
                Text: Text.ToOption(),
                MultiText: MultiText.ToOption(),
                TextPosition: TextPosition.ToOption(),
                MultiTextPosition: MultiTextPosition.ToOption(),
                MarkerColor: MarkerColor.ToOption(),
                MarkerColorScale: MarkerColorScale.ToOption(),
                MarkerOutline: MarkerOutline.ToOption(),
                MarkerSymbol: MarkerSymbol.ToOption(),
                MultiMarkerSymbol: MultiMarkerSymbol.ToOption(),
                Marker: Marker.ToOption(),
                LineColor: LineColor.ToOption(),
                LineColorScale: LineColorScale.ToOption(),
                LineWidth: LineWidth.ToOption(),
                LineDash: LineDash.ToOption(),
                Line: Line.ToOption(),
                CameraProjectionType: CameraProjectionType.ToOption(),
                Camera: Camera.ToOption(),
                Projection: Projection.ToOption(),
                UseDefaults: UseDefaults.ToOption()
            );
}
