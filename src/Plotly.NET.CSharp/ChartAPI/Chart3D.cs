using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plotly.NET;
using Plotly.NET.LayoutObjects;
using Plotly.NET.TraceObjects;
using System.Runtime.InteropServices;


namespace Plotly.NET.CSharp
{
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
        /// <param name="Projection">Sets the projection of this trace.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart.GenericChart Scatter3D<XType, YType, ZType, TextType>(
            IEnumerable<XType> x,
            IEnumerable<YType> y,
            IEnumerable<ZType> z,
            StyleParam.Mode mode,
            [Optional] string? Name,
            [Optional] bool? ShowLegend,
            [Optional] double? Opacity,
            [Optional] IEnumerable<double>? MultiOpacity,
            [Optional] TextType? Text,
            [Optional] IEnumerable<TextType>? MultiText,
            [Optional] StyleParam.TextPosition? TextPosition,
            [Optional] IEnumerable<StyleParam.TextPosition>? MultiTextPosition,
            [Optional] Color? MarkerColor,
            [Optional] StyleParam.Colorscale? MarkerColorScale,
            [Optional] Line? MarkerOutline,
            [Optional] StyleParam.MarkerSymbol3D? MarkerSymbol,
            [Optional] IEnumerable<StyleParam.MarkerSymbol3D>? MultiMarkerSymbol,
            [Optional] Marker? Marker,
            [Optional] Color? LineColor,
            [Optional] StyleParam.Colorscale? LineColorScale,
            [Optional] double? LineWidth,
            [Optional] StyleParam.DrawingStyle? LineDash,
            [Optional] Line? Line,
            [Optional] Projection? Projection,
            [Optional] bool? UseDefaults
        )
            where XType: IConvertible
            where YType: IConvertible
            where ZType : IConvertible
            where TextType : IConvertible
            
            => Plotly.NET.Chart3D.Chart.Scatter3D<XType, YType, ZType, TextType>(
                x: x,
                y: y,
                z: z,
                mode: mode,
                Name: Name.ToOption(),
                ShowLegend: ShowLegend.ToOptionV(),
                Opacity: Opacity.ToOptionV(),
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
                LineWidth: LineWidth.ToOptionV(),
                LineDash: LineDash.ToOption(),
                Line: Line.ToOption(),
                Projection: Projection.ToOption(),
                UseDefaults: UseDefaults.ToOptionV()
            );
    }
}
