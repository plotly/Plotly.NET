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
        public static GenericChart Surface<ZType, XType, YType, TextType>(
            IEnumerable<IEnumerable<ZType>> zData, 
            Optional<IEnumerable<XType>> X = default, 
            Optional<IEnumerable<YType>> Y = default, 
            Optional<string> Name = default, 
            Optional<bool> ShowLegend = default, 
            Optional<double> Opacity = default, 
            Optional<TextType> Text = default, 
            Optional<IEnumerable<TextType>> MultiText = default, 
            Optional<Contours> Contours = default, 
            Optional<StyleParam.Colorscale> ColorScale = default,
            Optional<StyleParam.CameraProjectionType> CameraProjectionType = default,
            Optional<Camera> Camera = default,
            Optional<bool> ShowScale = default, 

            Optional<bool> UseDefaults = default
        )
            where ZType : IConvertible
            where XType : IConvertible
            where YType : IConvertible
            where TextType : IConvertible
            =>
                Plotly.NET.Chart3D_Surface.Chart.Surface<IEnumerable<ZType>, ZType, XType, YType, TextType>(
                    zData: zData,
                    X: X.ToOption(),
                    Y: Y.ToOption(),
                    Name: Name.ToOption(),
                    ShowLegend: ShowLegend.ToOption(),
                    Opacity: Opacity.ToOption(),
                    Text: Text.ToOption(),
                    MultiText: MultiText.ToOption(),
                    Contours: Contours.ToOption(),
                    ColorScale: ColorScale.ToOption(),
                    ShowScale: ShowScale.ToOption(),
                    CameraProjectionType: CameraProjectionType.ToOption(),
                    Camera: Camera.ToOption(),
                    UseDefaults: UseDefaults.ToOption()
                );
}
