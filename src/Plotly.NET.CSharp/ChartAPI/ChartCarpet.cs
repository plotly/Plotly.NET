using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plotly.NET.LayoutObjects;
using Plotly.NET.TraceObjects;
using System.Runtime.InteropServices;

namespace Plotly.NET.CSharp
{
    public static partial class Chart
    {
        /// <summary>
        /// Creates a carpet in a 2D coordinate system to be used as additional coordinate system in a carpet plot.
        ///
        /// A  carpet plot illustrates the interaction between two or more independent variables and one or more dependent variables in a two-dimensional plot.
        /// Besides the ability to incorporate more variables, another feature that distinguishes a carpet plot from an equivalent contour plot or 3D surface plot is that a carpet plot can be used to more accurately interpolate data points.
        /// A conventional carpet plot can capture the interaction of up to three independent variables and three dependent variables and still be easily read and interpolated.
        ///
        /// Three-variable carpet plot (cheater plot):
        ///
        /// A carpet plot with two independent variables and one dependent variable is often called a cheater plot for the use of a phantom "cheater" axis instead of the horizontal axis. As a result of this missing axis, the values can be shifted horizontally such that the intersections line up vertically. This allows easy interpolation by having fixed horizontal intervals correspond to fixed intervals in both independent variables.
        ///
        /// Four-variable carpet plot (true carpet plot)
        ///
        /// Instead of using the horizontal axis to adjust the plot perspective and align carpet intersections vertically, the horizontal axis can be used to show the effects on an additional dependent variable.[5] In this case the perspective is fixed, and any overlapping cannot be adjusted. Because a true carpet plot represents two independent variables and two dependent variables simultaneously, there is no corresponding way to show the information on a conventional contour plot or 3D surface plot.
        ///
        /// (from https://en.wikipedia.org/wiki/Carpet_plot @ 1/11/2021)
        /// </summary>
        /// <param name="carpetId">An identifier for this carpet, so that `scattercarpet` and `contourcarpet` traces can specify a carpet plot on which they lie.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="X">A one dimensional array of x coordinates matching the dimensions of `a` and `b`.</param>
        /// <param name="MultiX">A two dimensional array of x coordinates at each carpet point. If omitted, the plot is a cheater plot and the xaxis is hidden by default.</param>
        /// <param name="Y">A one dimensional array of y coordinates matching the dimensions of `a` and `b`.</param>
        /// <param name="MultiY">A two dimensional array of y coordinates at each carpet point.</param>
        /// <param name="A">An array containing values of the first parameter value</param>
        /// <param name="B">An array containing values of the second parameter value</param>
        /// <param name="AAxis">Sets this carpet's a axis.</param>
        /// <param name="BAxis">Sets this carpet's b axis.</param>
        /// <param name="XAxis">Sets a reference between this trace's x coordinates and a 2D cartesian x axis. If "x" (the default value), the x coordinates refer to `layout.xaxis`. If "x2", the x coordinates refer to `layout.xaxis2`, and so on.</param>
        /// <param name="YAxis">Sets a reference between this trace's y coordinates and a 2D cartesian y axis. If "y" (the default value), the y coordinates refer to `layout.yaxis`. If "y2", the y coordinates refer to `layout.yaxis2`, and so on.</param>
        /// <param name="Color">Sets default for all colors associated with this axis all at once: line, font, tick, and grid colors. Grid color is lightened by blending this with the plot background Individual pieces can override this.</param>
        /// <param name="CheaterSlope">The shift applied to each successive row of data in creating a cheater plot. Only used if `x` is been omitted.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart.GenericChart Carpet<XType, MultiXType, YType, MultiYType, AType, BType>(
            string carpetId,
            [Optional] string? Name,
            [Optional] bool? ShowLegend,
            [Optional] double? Opacity,
            [Optional] IEnumerable<XType>? X,
            [Optional] IEnumerable<IEnumerable<MultiXType>>? MultiX,
            [Optional] IEnumerable<YType>? Y,
            [Optional] IEnumerable<IEnumerable<MultiYType>>? MultiY,
            [Optional] IEnumerable<AType>? A,
            [Optional] IEnumerable<BType>? B,
            [Optional] LinearAxis? AAxis,
            [Optional] LinearAxis? BAxis,
            [Optional] StyleParam.LinearAxisId? XAxis,
            [Optional] StyleParam.LinearAxisId? YAxis,
            [Optional] Color? Color,
            [Optional] double? CheaterSlope,
            [Optional] bool? UseDefaults
        )
            where XType : IConvertible 
            where MultiXType : IConvertible 
            where YType : IConvertible 
            where MultiYType : IConvertible 
            where AType : IConvertible 
            where BType : IConvertible
            =>
                Plotly.NET.ChartCarpet.Chart.Carpet<XType, IEnumerable<MultiXType>, MultiXType, YType, IEnumerable<MultiYType>, MultiYType, AType, BType>(
                    carpetId: carpetId,
                    Name: Name.ToOption(),
                    ShowLegend: ShowLegend.ToOptionV(),
                    Opacity: Opacity.ToOptionV(),
                    X: X.ToOption(),
                    MultiX: MultiX.ToOption(), 
                    Y: Y.ToOption(),
                    MultiY: MultiY.ToOption(),
                    A: A.ToOption(),
                    B: B.ToOption(),
                    AAxis: AAxis.ToOption(),
                    BAxis: BAxis.ToOption(),
                    XAxis: XAxis.ToOption(),
                    YAxis: YAxis.ToOption(),
                    Color: Color.ToOption(),
                    CheaterSlope: CheaterSlope.ToOptionV(),
                    UseDefaults: UseDefaults.ToOptionV()
                );

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
        public static GenericChart.GenericChart ContourCarpet<ZType, AType, BType, TextType>(
            IEnumerable<ZType> z,
            string carpetAnchorId,
            [Optional] string? Name,
            [Optional] bool? ShowLegend,
            [Optional] double? Opacity,
            [Optional] IEnumerable<AType>? A,
            [Optional] IEnumerable<BType>? B,
            [Optional] TextType? Text,
            [Optional] IEnumerable<TextType>? MultiText,
            [Optional] ColorBar? ColorBar,
            [Optional] StyleParam.Colorscale? ColorScale,
            [Optional] bool? ShowScale,
            [Optional] bool? ReverseScale,
            [Optional] bool? Transpose,
            [Optional] Color? ContourLineColor,
            [Optional] StyleParam.DrawingStyle? ContourLineDash,
            [Optional] double? ContourLineSmoothing,
            [Optional] Line? ContourLine,
            [Optional] StyleParam.ContourColoring? ContoursColoring,
            [Optional] StyleParam.ConstraintOperation? ContoursOperation,
            [Optional] StyleParam.ContourType? ContoursType,
            [Optional] bool? ShowContourLabels,
            [Optional] Font? ContourLabelFont,
            [Optional] Contours? Contours,
            [Optional] bool? UseDefaults
        )
            where ZType : IConvertible
            where AType : IConvertible
            where BType : IConvertible
            where TextType : IConvertible
            =>
                Plotly.NET.ChartCarpet.Chart.ContourCarpet<ZType, AType, BType, TextType>(
                    z: z,
                    carpetAnchorId: carpetAnchorId,
                    Name: Name.ToOption(),
                    ShowLegend: ShowLegend.ToOptionV(),
                    Opacity: Opacity.ToOptionV(),
                    A: A.ToOption(),
                    B: B.ToOption(),
                    Text: Text.ToOption(),
                    MultiText: MultiText.ToOption(),
                    ColorBar: ColorBar.ToOption(),
                    ColorScale: ColorScale.ToOption(),
                    ShowScale: ShowScale.ToOptionV(),
                    ReverseScale: ReverseScale.ToOptionV(),
                    Transpose: Transpose.ToOptionV(),
                    ContourLineColor: ContourLineColor.ToOption(),
                    ContourLineDash: ContourLineDash.ToOption(),
                    ContourLineSmoothing: ContourLineSmoothing.ToOptionV(),
                    ContourLine: ContourLine.ToOption(),
                    ContoursColoring: ContoursColoring.ToOption(),
                    ContoursOperation: ContoursOperation.ToOption(),
                    ContoursType: ContoursType.ToOption(),
                    ShowContourLabels: ShowContourLabels.ToOptionV(),
                    ContourLabelFont: ContourLabelFont.ToOption(),
                    Contours: Contours.ToOption(),
                    UseDefaults: UseDefaults.ToOptionV()
                );
    }
}
