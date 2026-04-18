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
    /// Creates a scatter plot matrix (SPLOM) from multiple input dimensions.
    ///
    /// Each splom `dimensions` items correspond to a generated axis. Values for each of those dimensions are set in `dimensions[i].values`. Splom traces support all `scattergl` marker style attributes. Specify `layout.grid` attributes and/or layout x-axis and y-axis attributes for more control over the axis positioning and style.
    /// </summary>
    /// <param name="dimensions">Sets the dimensions of the scatter plot matrix, where each item corresponds to a generated axis.</param>
    /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
    /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
    /// <param name="Opacity">Sets the Opacity otf the trace.</param>
    /// <param name="Text">Sets a text associated with each datum</param>
    /// <param name="MultiText">Sets individual text for each datum</param>
    /// <param name="MarkerColor">Sets the color of the marker.</param>
    /// <param name="MarkerColorScale">Sets the colorscale of the marker. Use `Color.fromColorScaleValues` to map marker colors to a colorscale.</param>
    /// <param name="MarkerOutline">Sets the outline of the marker</param>
    /// <param name="MarkerSymbol">Sets the symbol of all marker</param>
    /// <param name="MultiMarkerSymbol">Sets the symbol of each individual marker</param>
    /// <param name="Marker">Sets the markers (use this for more finegrained control than the other marker-associated arguments).</param>
    /// <param name="ShowDiagonal">Whether or not to show the matrix diagional</param>
    /// <param name="Diagonal">Sets the styles applied to the scatter plot matrix diagonal</param>
    /// <param name="ShowLowerHalf">Determines whether or not subplots on the lower half from the diagonal are displayed.</param>
    /// <param name="ShowUpperHalf">Determines whether or not subplots on the upper half from the diagonal are displayed.</param>
    /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
    public static GenericChart Splom<TextType>(
        IEnumerable<Dimension> dimensions, 
        Optional<string> Name = default, 
        Optional<bool> ShowLegend = default, 
        Optional<double> Opacity = default, 
        Optional<TextType> Text = default, 
        Optional<IEnumerable<TextType>> MultiText = default, 
        Optional<Color> MarkerColor = default, 
        Optional<StyleParam.Colorscale> MarkerColorScale = default, 
        Optional<Line> MarkerOutline = default, 
        Optional<StyleParam.MarkerSymbol> MarkerSymbol = default, 
        Optional<IEnumerable<StyleParam.MarkerSymbol>> MultiMarkerSymbol = default, 
        Optional<Marker> Marker = default, 
        Optional<bool> ShowDiagonal = default, 
        Optional<SplomDiagonal> Diagonal = default, 
        Optional<bool> ShowLowerHalf = default, 
        Optional<bool> ShowUpperHalf = default, 
        Optional<bool> UseDefaults = default
    )
        where TextType : IConvertible
        =>
            Plotly.NET.Chart2D_Splom.Chart.Splom<TextType>(
                dimensions: dimensions,
                Name: Name.ToOption(),
                ShowLegend: ShowLegend.ToOption(),
                Opacity: Opacity.ToOption(),
                Text: Text.ToOption(),
                MultiText: MultiText.ToOption(),
                MarkerColor: MarkerColor.ToOption(),
                MarkerColorScale: MarkerColorScale.ToOption(),
                MarkerOutline: MarkerOutline.ToOption(),
                MarkerSymbol: MarkerSymbol.ToOption(),
                MultiMarkerSymbol: MultiMarkerSymbol.ToOption(),
                Marker: Marker.ToOption(),
                ShowDiagonal: ShowDiagonal.ToOption(),
                Diagonal: Diagonal.ToOption(),
                ShowLowerHalf: ShowLowerHalf.ToOption(),
                ShowUpperHalf: ShowUpperHalf.ToOption(),
                UseDefaults: UseDefaults.ToOption()
            );
}
