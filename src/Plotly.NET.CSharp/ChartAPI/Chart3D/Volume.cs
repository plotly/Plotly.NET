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
        public static GenericChart Volume<XType, YType, ZType, ValueType, TextType, OpacityScaleType>(
            IEnumerable<XType> x, 
            IEnumerable<YType> y, 
            IEnumerable<ZType> z, 
            IEnumerable<ValueType> value, 
            Optional<string> Name = default, 
            Optional<bool> ShowLegend = default, 
            Optional<double> Opacity = default, 
            Optional<TextType> Text = default, 
            Optional<IEnumerable<TextType>> MultiText = default,
            Optional<StyleParam.Colorscale> ColorScale = default, 
            Optional<bool> ShowScale = default, 
            Optional<ColorBar> ColorBar = default, 
            Optional<double> IsoMin = default, 
            Optional<double> IsoMax = default, 
            Optional<Caps> Caps = default, 
            Optional<Slices> Slices = default, 
            Optional<Surface> Surface = default, 
            Optional<IEnumerable<IEnumerable<OpacityScaleType>>> OpacityScale = default,
            Optional<StyleParam.CameraProjectionType> CameraProjectionType = default,
            Optional<Camera> Camera = default,
            Optional<bool> UseDefaults = default
        )
            where XType : IConvertible
            where YType : IConvertible
            where ZType : IConvertible
            where ValueType : IConvertible
            where TextType : IConvertible
            where OpacityScaleType : IConvertible
            =>
                Plotly.NET.Chart3D_Volume.Chart.Volume<XType, YType, ZType, ValueType, TextType, IEnumerable<OpacityScaleType>, OpacityScaleType>(
                    x: x,
                    y: y,
                    z: z,
                    value: value,
                    Name: Name.ToOption(),
                    ShowLegend: ShowLegend.ToOption(),
                    Opacity: Opacity.ToOption(),
                    Text: Text.ToOption(),
                    MultiText: MultiText.ToOption(),
                    ColorScale: ColorScale.ToOption(),
                    ShowScale: ShowScale.ToOption(),
                    ColorBar: ColorBar.ToOption(),
                    IsoMin: IsoMin.ToOption(),
                    IsoMax: IsoMax.ToOption(),
                    Caps: Caps.ToOption(),
                    Slices: Slices.ToOption(),
                    Surface: Surface.ToOption(),
                    OpacityScale: OpacityScale.ToOption(),
                    CameraProjectionType: CameraProjectionType.ToOption(),
                    Camera: Camera.ToOption(),
                    UseDefaults: UseDefaults.ToOption()
                );
}
