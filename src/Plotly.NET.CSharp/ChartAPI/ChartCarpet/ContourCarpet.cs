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
        /// Creates a contour chart that lies on a specified carpet.
        ///
        /// Plots contours on either the first carpet axis or the carpet axis with a matching `carpet` attribute. Data `z` is interpreted as matching that of the corresponding carpet axis.
        /// </summary>
        /// <param name="carpetAnchorId">The identifier of the carpet that this trace will lie on.</param>
        /// <param name="z">Sets the z data.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="A">Sets the a coordinates.</param>
        /// <param name="B">Sets the b coordinates.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="ColorBar">Sets the colorbar of this trace.</param>
        /// <param name="ColorScale">Sets the colorscale of this trace.</param>
        /// <param name="ShowScale">Determines whether or not a colorbar is displayed for this trace.</param>
        /// <param name="ReverseScale">Reverses the color mapping if true. If true, `zmin` will correspond to the last color in the array and `zmax` will correspond to the first color.</param>
        /// <param name="Transpose">Transposes the z data.</param>
        /// <param name="ContourLineDash">Sets the contour line dash style</param>
        /// <param name="ContourLineColor">Sets the contour line color</param>
        /// <param name="ContourLineSmoothing">Sets the amount of smoothing for the contour lines, where "0" corresponds to no smoothing.</param>
        /// <param name="ContourLine">Sets the contour lines (use this for more finegrained control than the other contourline-associated arguments).</param>
        /// <param name="ContoursColoring">Determines the coloring method showing the contour values. If "fill", coloring is done evenly between each contour level If "heatmap", a heatmap gradient coloring is applied between each contour level. If "lines", coloring is done on the contour lines. If "none", no coloring is applied on this trace.</param>
        /// <param name="ContoursOperation">Sets the constraint operation. "=" keeps regions equal to `value` "&lt;" and "&lt;=" keep regions less than `value` "&gt;" and "&gt;=" keep regions greater than `value` "[]", "()", "[)", and "(]" keep regions inside `value[0]` to `value[1]` "][", ")(", "](", ")[" keep regions outside `value[0]` to value[1]` Open vs. closed intervals make no difference to constraint display, but all versions are allowed for consistency with filter transforms.</param>
        /// <param name="ContoursType">If `levels`, the data is represented as a contour plot with multiple levels displayed. If `constraint`, the data is represented as constraints with the invalid region shaded as specified by the `operation` and `value` parameters.</param>
        /// <param name="ShowContourLabels">Determines whether to label the contour lines with their values.</param>
        /// <param name="ContourLabelFont">Sets the font used for labeling the contour levels. The default color comes from the lines, if shown. The default family and size come from `layout.font`.</param>
        /// <param name="Contours">Sets the styles of the contours (use this for more finegrained control than the other contour-associated arguments).</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart ContourCarpet<ZType, AType, BType, TextType>(
            IEnumerable<ZType> z,
            string carpetAnchorId,
            Optional<string> Name = default,
            Optional<bool> ShowLegend = default,
            Optional<double> Opacity = default,
            Optional<IEnumerable<AType>> A = default,
            Optional<IEnumerable<BType>> B = default,
            Optional<TextType> Text = default,
            Optional<IEnumerable<TextType>> MultiText = default,
            Optional<ColorBar> ColorBar = default,
            Optional<StyleParam.Colorscale> ColorScale = default,
            Optional<bool> ShowScale = default,
            Optional<bool> ReverseScale = default,
            Optional<bool> Transpose = default,
            Optional<Color> ContourLineColor = default,
            Optional<StyleParam.DrawingStyle> ContourLineDash = default,
            Optional<double> ContourLineSmoothing = default,
            Optional<Line> ContourLine = default,
            Optional<StyleParam.ContourColoring> ContoursColoring = default,
            Optional<StyleParam.ConstraintOperation> ContoursOperation = default,
            Optional<StyleParam.ContourType> ContoursType = default,
            Optional<bool> ShowContourLabels = default,
            Optional<Font> ContourLabelFont = default,
            Optional<Contours> Contours = default,
            Optional<bool> UseDefaults = default
        )
            where ZType : IConvertible
            where AType : IConvertible
            where BType : IConvertible
            where TextType : IConvertible
            =>
                Plotly.NET.ChartCarpet_Contour.Chart.ContourCarpet<ZType, AType, BType, TextType>(
                    z: z,
                    carpetAnchorId: carpetAnchorId,
                    Name: Name.ToOption(),
                    ShowLegend: ShowLegend.ToOption(),
                    Opacity: Opacity.ToOption(),
                    A: A.ToOption(),
                    B: B.ToOption(),
                    Text: Text.ToOption(),
                    MultiText: MultiText.ToOption(),
                    ColorBar: ColorBar.ToOption(),
                    ColorScale: ColorScale.ToOption(),
                    ShowScale: ShowScale.ToOption(),
                    ReverseScale: ReverseScale.ToOption(),
                    Transpose: Transpose.ToOption(),
                    ContourLineColor: ContourLineColor.ToOption(),
                    ContourLineDash: ContourLineDash.ToOption(),
                    ContourLineSmoothing: ContourLineSmoothing.ToOption(),
                    ContourLine: ContourLine.ToOption(),
                    ContoursColoring: ContoursColoring.ToOption(),
                    ContoursOperation: ContoursOperation.ToOption(),
                    ContoursType: ContoursType.ToOption(),
                    ShowContourLabels: ShowContourLabels.ToOption(),
                    ContourLabelFont: ContourLabelFont.ToOption(),
                    Contours: Contours.ToOption(),
                    UseDefaults: UseDefaults.ToOption()
                );
}
