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
        /// Creates a polar point plot.
        ///
        /// PointPolar plots plot two-dimensional data on a polar coordinate system comprised of angular and radial position scales as points.
        /// </summary>
        /// <param name="r">Sets the radial coordinates of the plotted data</param>
        /// <param name="theta">Sets the angular coordinates of the plotted data</param>
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
        /// <param name="UseWebGL">If true, plotly.js will use the WebGL engine to render this chart. use this when you want to render many objects at once.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart PointPolar<RType, ThetaType, TextType>(
            IEnumerable<RType> r,
            IEnumerable<ThetaType> theta,
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
            Optional<bool> UseWebGL = default,
            Optional<bool> UseDefaults = default
        )
            where RType : IConvertible
            where ThetaType : IConvertible
            where TextType : IConvertible

            =>
                Plotly.NET.ChartPolar_Scatter.Chart.PointPolar<RType, ThetaType, TextType>(
                    r: r,
                    theta: theta,
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
                    UseWebGL: UseWebGL.ToOption(),
                    UseDefaults: UseDefaults.ToOption()
                );
}
