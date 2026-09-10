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
        public static GenericChart StreamTube<XType, YType, ZType, UType, VType, WType, TextType>(
            IEnumerable<XType> x,
            IEnumerable<YType> y,
            IEnumerable<ZType> z,
            IEnumerable<UType> u,
            IEnumerable<VType> v,
            IEnumerable<WType> w,
            Optional<string> Name = default,
            Optional<bool> ShowLegend = default,
            Optional<double> Opacity = default,
            Optional<TextType> Text = default,
            Optional<IEnumerable<TextType>> MultiText = default,
            Optional<StyleParam.Colorscale> ColorScale = default, 
            Optional<bool> ShowScale = default,
            Optional<ColorBar> ColorBar = default, 
            Optional<int> MaxDisplayed = default, 
            Optional<StreamTubeStarts> TubeStarts = default,
            Optional<StyleParam.CameraProjectionType> CameraProjectionType = default,
            Optional<Camera> Camera = default,
            Optional<bool> UseDefaults = default
        )
            where XType : IConvertible
            where YType : IConvertible
            where ZType : IConvertible
            where UType : IConvertible
            where VType : IConvertible
            where WType : IConvertible
            where TextType : IConvertible
            =>
                Plotly.NET.Chart3D_VectorField.Chart.StreamTube<XType, YType, ZType, UType, VType, WType, TextType>(
                    x: x,
                    y: y,
                    z: z,
                    u: u,
                    v: v,
                    w: w,
                    Name: Name.ToOption(),
                    ShowLegend: ShowLegend.ToOption(),
                    Opacity: Opacity.ToOption(),
                    Text: Text.ToOption(),
                    MultiText: MultiText.ToOption(),
                    ColorScale: ColorScale.ToOption(),
                    ShowScale: ShowScale.ToOption(),
                    ColorBar: ColorBar.ToOption(),
                    MaxDisplayed: MaxDisplayed.ToOption(),
                    TubeStarts: TubeStarts.ToOption(),
                    CameraProjectionType: CameraProjectionType.ToOption(),
                    Camera: Camera.ToOption(),
                    UseDefaults: UseDefaults.ToOption()
                );
}
