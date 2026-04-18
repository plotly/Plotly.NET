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
    /// Creates a 2D contour plot, which shows the contour lines of a 2D numerical array z, i.e. interpolated lines of isovalues of z.
    ///
    /// A contour line (also isoline, isopleth, or isarithm) of a function of two variables is a curve along which the function has a constant value, so that the curve joins points of equal value
    ///
    /// The data from which contour lines are computed is set in `z`. Data in `z` must be a 2D array of numbers. Say that `z` has N rows and M columns, then by default, these N rows correspond to N y coordinates (set in `y` or auto-generated) and the M columns correspond to M x coordinates (set in `x` or auto-generated). By setting `transpose` to "true", the above behavior is flipped.
    /// </summary>
    /// <param name="zData">Sets the z data which is used for computing the contour lines.</param>
    /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
    /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
    /// <param name="Opacity">Sets the Opacity otf the trace.</param>
    /// <param name="X">Sets the x coordinates.</param>
    /// <param name="MultiX">Sets the x coordinates. Use two inner arrays here to plot multicategorial data</param>
    /// <param name="Y">Sets the y coordinates.</param>
    /// <param name="MultiY">Sets the y coordinates. Use two inner arrays here to plot multicategorial data</param>
    /// <param name="Text">Sets a text associated with each datum</param>
    /// <param name="MultiText">Sets individual text for each datum</param>
    /// <param name="ColorBar">Sets the styles of the colorbar for this trace.</param>
    /// <param name="ColorScale">Sets the colorscale for this trace.</param>
    /// <param name="ShowScale">Whether or not to show the colorscale/colorbar</param>
    /// <param name="ReverseScale">Reverses the color mapping if true. If true, `zmin` will correspond to the last color in the array and `zmax` will correspond to the first color.</param>
    /// <param name="Transpose">Transposes the z data.</param>
    /// <param name="ContourLinesDash">Sets the contour line dash style</param>
    /// <param name="ContourLinesColor">Sets the contour line color</param>
    /// <param name="ContourLinesSmoothing">Sets the amount of smoothing for the contour lines, where "0" corresponds to no smoothing.</param>
    /// <param name="ContourLinesWidth">Sets the width of the contour lines</param>
    /// <param name="ContourLines">Sets the contour lines (use this for more finegrained control than the other contourline-associated arguments).</param>
    /// <param name="ShowContourLines">Wether or not to show the contour line</param>
    /// <param name="ContoursColoring">Determines the coloring method showing the contour values. If "fill", coloring is done evenly between each contour level If "heatmap", a heatmap gradient coloring is applied between each contour level. If "lines", coloring is done on the contour lines. If "none", no coloring is applied on this trace.</param>
    /// <param name="ContoursOperation">Sets the constraint operation. "=" keeps regions equal to `value` "&lt;" and "&lt;=" keep regions less than `value` "&gt;" and "&gt;=" keep regions greater than `value` "[]", "()", "[)", and "(]" keep regions inside `value[0]` to `value[1]` "][", ")(", "](", ")[" keep regions outside `value[0]` to value[1]` Open vs. closed intervals make no difference to constraint display, but all versions are allowed for consistency with filter transforms.</param>
    /// <param name="ContoursType">If `levels`, the data is represented as a contour plot with multiple levels displayed. If `constraint`, the data is represented as constraints with the invalid region shaded as specified by the `operation` and `value` parameters.</param>
    /// <param name="ShowContoursLabels">Determines whether to label the contour lines with their values.</param>
    /// <param name="ContourLabelFont">Sets the font used for labeling the contour levels. The default color comes from the lines, if shown. The default family and size come from `layout.font`.</param>
    /// <param name="ContoursStart">Sets the starting contour level value. Must be less than `contours.end`</param>
    /// <param name="ContoursEnd">Sets the end contour level value. Must be more than `contours.start`</param>
    /// <param name="Contours">Sets the styles of the contours (use this for more finegrained control than the other contour-associated arguments).</param>
    /// <param name="FillColor">Sets the fill color if `contours.type` is "constraint". Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
    /// <param name="NContours">Sets the maximum number of contour levels. The actual number of contours will be chosen automatically to be less than or equal to the value of `ncontours`. Has an effect only if `autocontour` is "true" or if `contours.size` is missing.</param>
    /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
    public static GenericChart Contour<ZType, XType, YType, TextType>(
        IEnumerable<IEnumerable<ZType>> zData, 
        Optional<string> Name = default, 
        Optional<bool> ShowLegend = default, 
        Optional<double> Opacity = default, 
        Optional<IEnumerable<XType>> X = default,
        Optional<IEnumerable<IEnumerable<XType>>> MultiX = default,
        Optional<IEnumerable<YType>> Y = default,
        Optional<IEnumerable<IEnumerable<YType>>> MultiY = default,
        Optional<TextType> Text = default, 
        Optional<IEnumerable<TextType>> MultiText = default, 
        Optional<ColorBar> ColorBar = default, 
        Optional<StyleParam.Colorscale> ColorScale = default, 
        Optional<bool> ShowScale = default, 
        Optional<bool> ReverseScale = default, 
        Optional<bool> Transpose = default,
        Optional<StyleParam.DrawingStyle> ContourLinesDash = default,
        Optional<Color> ContourLinesColor = default,
        Optional<double> ContourLinesSmoothing = default,
        Optional<double> ContourLinesWidth = default,
        Optional<Line> ContourLines = default,
        Optional<bool> ShowContourLines = default,
        Optional<StyleParam.ContourColoring> ContoursColoring = default,
        Optional<StyleParam.ConstraintOperation> ContoursOperation = default,
        Optional<StyleParam.ContourType> ContoursType = default,
        Optional<bool> ShowContoursLabels = default,
        Optional<Font> ContourLabelFont = default,
        Optional<double> ContoursStart = default,
        Optional<double> ContoursEnd = default,
        Optional<Contours> Contours = default,
        Optional<Color> FillColor = default, 
        Optional<int> NContours = default, 
        Optional<bool> UseDefaults = default
    )
        where ZType : IConvertible
        where XType : IConvertible
        where YType : IConvertible
        where TextType : IConvertible
        =>
            Plotly.NET.Chart2D_Heatmap.Chart.Contour<IEnumerable<ZType>, ZType, XType, YType, TextType>(
                zData: zData,
                Name: Name.ToOption(),
                ShowLegend: ShowLegend.ToOption(),
                Opacity: Opacity.ToOption(),
                X: X.ToOption(),
                MultiX: MultiX.ToOption(),
                Y: Y.ToOption(),
                MultiY: MultiY.ToOption(),
                Text: Text.ToOption(),
                MultiText: MultiText.ToOption(),
                ColorBar: ColorBar.ToOption(),
                ColorScale: ColorScale.ToOption(),
                ShowScale: ShowScale.ToOption(),
                ReverseScale: ReverseScale.ToOption(),
                Transpose: Transpose.ToOption(),
                ContourLinesDash: ContourLinesDash.ToOption(),
                ContourLinesColor: ContourLinesColor.ToOption(),
                ContourLinesSmoothing: ContourLinesSmoothing.ToOption(),
                ContourLinesWidth: ContourLinesWidth.ToOption(),
                ContourLines: ContourLines.ToOption(),
                ShowContourLines: ShowContourLines.ToOption(),
                ContoursColoring: ContoursColoring.ToOption(),
                ContoursOperation: ContoursOperation.ToOption(),
                ContoursType: ContoursType.ToOption(),
                ShowContoursLabels: ShowContoursLabels.ToOption(),
                ContoursLabelFont: ContourLabelFont.ToOption(),
                ContoursStart: ContoursStart.ToOption(),
                ContoursEnd: ContoursEnd.ToOption(),
                Contours: Contours.ToOption(),
                FillColor: FillColor.ToOption(),
                NContours: NContours.ToOption(),
                UseDefaults: UseDefaults.ToOption()
            );
}
