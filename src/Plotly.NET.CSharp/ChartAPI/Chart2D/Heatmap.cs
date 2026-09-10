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
    /// Creates a heatmap.
    ///
    /// A heatmap is a data visualization technique that shows magnitude of a phenomenon as color in two dimensions.
    /// </summary>
    /// <param name="zData">Sets the 2-dimensional z data, which will be visualized with the color scale.</param>
    /// <param name="X">Sets the x coordinates</param>
    /// <param name="MultiX">Sets the x coordinates. Use two inner arrays here to plot multicategorial data</param>
    /// <param name="Y">Sets the y coordinates</param>
    /// <param name="MultiY">Sets the y coordinates. Use two inner arrays here to plot multicategorial data</param>
    /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
    /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
    /// <param name="Opacity">Sets the Opacity otf the trace.</param>
    /// <param name="XGap">Sets the horizontal gap (in pixels) between bricks.</param>
    /// <param name="YGap">Sets the vertical gap (in pixels) between bricks.</param>
    /// <param name="Text">Sets a text associated with each datum</param>
    /// <param name="MultiText">Sets individual text for each datum</param>
    /// <param name="ColorBar">Sets the styles of the colorbar for this trace.</param>
    /// <param name="ColorScale">Sets the colorscale for this trace.</param>
    /// <param name="ShowScale">Whether or not to show the colorscale/colorbar</param>
    /// <param name="ReverseScale">Reverses the color mapping if true. If true, `zmin` will correspond to the last color in the array and `zmax` will correspond to the first color.</param>
    /// <param name="ZSmooth">Picks a smoothing algorithm use to smooth `z` data.</param>
    /// <param name="Transpose">Transposes the z data.</param>
    /// <param name="UseWebGL">Whether or not to use WebGL to render this trace</param>
    /// <param name="ReverseYAxis">Whether or not to reverse the y axis. If true, (0,0) will lie on the top left and increase downwards.</param>
    /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
    public static GenericChart Heatmap<ZType, XType, YType, TextType>(
        IEnumerable<IEnumerable<ZType>> zData, 
        Optional<IEnumerable<XType>> X = default,
        Optional<IEnumerable<IEnumerable<XType>>> MultiX = default,
        Optional<IEnumerable<YType>> Y = default,
        Optional<IEnumerable<IEnumerable<YType>>> MultiY = default,
        Optional<string> Name = default, 
        Optional<bool> ShowLegend = default, 
        Optional<double> Opacity = default, 
        Optional<int> XGap = default, 
        Optional<int> YGap = default, 
        Optional<TextType> Text = default, 
        Optional<IEnumerable<TextType>> MultiText = default, 
        Optional<ColorBar> ColorBar = default, 
        Optional<StyleParam.Colorscale> ColorScale = default, 
        Optional<bool> ShowScale = default, 
        Optional<bool> ReverseScale = default, 
        Optional<StyleParam.SmoothAlg> ZSmooth = default, 
        Optional<bool> Transpose = default, 
        Optional<bool> UseWebGL = default, 
        Optional<bool> ReverseYAxis = default, 
        Optional<bool> UseDefaults = default
    )
        where ZType : IConvertible
        where XType : IConvertible
        where YType : IConvertible
        where TextType : IConvertible
        =>
            Plotly.NET.Chart2D_Heatmap.Chart.Heatmap<IEnumerable<ZType>, ZType, XType, YType, TextType>(
                zData: zData,
                X: X.ToOption(),
                MultiX: MultiX.ToOption(),
                Y: Y.ToOption(),
                MultiY: MultiY.ToOption(),
                Name: Name.ToOption(),
                ShowLegend: ShowLegend.ToOption(),
                Opacity: Opacity.ToOption(),
                XGap: XGap.ToOption(),
                YGap: YGap.ToOption(),
                Text: Text.ToOption(),
                MultiText: MultiText.ToOption(),
                ColorBar: ColorBar.ToOption(),
                ColorScale: ColorScale.ToOption(),
                ShowScale: ShowScale.ToOption(),
                ReverseScale: ReverseScale.ToOption(),
                ZSmooth: ZSmooth.ToOption(),
                Transpose: Transpose.ToOption(),
                UseWebGL: UseWebGL.ToOption(),
                ReverseYAxis: ReverseYAxis.ToOption(),
                UseDefaults: UseDefaults.ToOption()
            );

    /// <summary>Creates a heatmap from encoded z data and optional encoded axes.</summary>
    /// <param name="zEncoded">Sets the z matrix as an encoded typed array.</param>
    /// <param name="xEncoded">Sets the x coordinates as an encoded typed array.</param>
    /// <param name="yEncoded">Sets the y coordinates as an encoded typed array.</param>
    /// <param name="UseDefaults">If set to false, ignore the global default settings set in <c>Defaults</c></param>
    public static GenericChart Heatmap<TextType>(
        EncodedTypedArray zEncoded,
        Optional<EncodedTypedArray> xEncoded = default,
        Optional<EncodedTypedArray> yEncoded = default,
        Optional<string> Name = default,
        Optional<bool> ShowLegend = default,
        Optional<double> Opacity = default,
        Optional<int> XGap = default,
        Optional<int> YGap = default,
        Optional<TextType> Text = default,
        Optional<IEnumerable<TextType>> MultiText = default,
        Optional<ColorBar> ColorBar = default,
        Optional<StyleParam.Colorscale> ColorScale = default,
        Optional<bool> ShowScale = default,
        Optional<bool> ReverseScale = default,
        Optional<StyleParam.SmoothAlg> ZSmooth = default,
        Optional<bool> Transpose = default,
        Optional<bool> UseWebGL = default,
        Optional<bool> ReverseYAxis = default,
        Optional<bool> UseDefaults = default
    )
        where TextType : IConvertible
        =>
            Plotly.NET.Chart2D_Heatmap.Chart.Heatmap(
                zEncoded: zEncoded,
                xEncoded: xEncoded.ToOption(),
                yEncoded: yEncoded.ToOption(),
                Name: Name.ToOption(),
                ShowLegend: ShowLegend.ToOption(),
                Opacity: Opacity.ToOption(),
                XGap: XGap.ToOption(),
                YGap: YGap.ToOption(),
                Text: Text.ToOption(),
                MultiText: MultiText.ToOption(),
                ColorBar: ColorBar.ToOption(),
                ColorScale: ColorScale.ToOption(),
                ShowScale: ShowScale.ToOption(),
                ReverseScale: ReverseScale.ToOption(),
                ZSmooth: ZSmooth.ToOption(),
                Transpose: Transpose.ToOption(),
                UseWebGL: UseWebGL.ToOption(),
                ReverseYAxis: ReverseYAxis.ToOption(),
                UseDefaults: UseDefaults.ToOption()
            );
}
