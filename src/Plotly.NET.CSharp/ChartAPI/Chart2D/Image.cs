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
    /// Display an image, i.e. data on a 2D regular raster. By default, when an image is displayed in a subplot, its y axis will be reversed (ie. `autorange: 'reversed'`), constrained to the domain (ie. `constrain: 'domain'`) and it will have the same scale as its x axis (ie. `scaleanchor: 'x,`) in order for pixels to be rendered as squares.
    /// </summary>
    /// <param name="Z">A 2-dimensional array in which each element is an array of 3 or 4 numbers representing a color.</param>
    /// <param name="Source">Specifies the data URI of the image to be visualized. The URI consists of "data:image/[&lt;media subtype&gt;][;base64],&lt;data&gt;"</param>
    /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
    /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
    /// <param name="Opacity">Sets the Opacity otf the trace.</param>
    /// <param name="Ids">Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.</param>
    /// <param name="ColorModel">Color model used to map the numerical color components described in `z` into colors. If `source` is specified, this attribute will be set to `rgba256` otherwise it defaults to `rgb`.</param>
    /// <param name="ZMax">Sets the upper bound of the color domain. Value should have the same units as in `z` and if set, `zmin` must be set as well.</param>
    /// <param name="ZMin">Sets the lower bound of the color domain. Value should have the same units as in `z` and if set, `zmax` must be set as well.</param>
    /// <param name="ZSmooth">Picks a smoothing algorithm use to smooth `z` data.</param>
    /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
    public static GenericChart Image<IdType>(
        Optional<IEnumerable<IEnumerable<IEnumerable<int>>>> Z = default, 
        Optional<string> Source = default, 
        Optional<string> Name = default, 
        Optional<bool> ShowLegend = default, 
        Optional<double> Opacity = default, 
        Optional<IEnumerable<IdType>> Ids = default, 
        Optional<StyleParam.ColorModel> ColorModel = default, 
        Optional<StyleParam.ColorComponentBound> ZMax = default, 
        Optional<StyleParam.ColorComponentBound> ZMin = default, 
        Optional<StyleParam.SmoothAlg> ZSmooth = default, 
        Optional<bool> UseDefaults = default
    )
        where IdType : IConvertible
        =>
            Plotly.NET.Chart2D_Heatmap.Chart.Image<IEnumerable<IEnumerable<int>>, IEnumerable<int>, IdType>(
                Z: Z.ToOption(),
                Source: Source.ToOption(),
                Name: Name.ToOption(),
                ShowLegend: ShowLegend.ToOption(),
                Opacity: Opacity.ToOption(),
                Ids: Ids.ToOption(),
                ColorModel: ColorModel.ToOption(),
                ZMax: ZMax.ToOption(),
                ZMin: ZMin.ToOption(),
                ZSmooth: ZSmooth.ToOption(),
                UseDefaults: UseDefaults.ToOption()
            );
}
