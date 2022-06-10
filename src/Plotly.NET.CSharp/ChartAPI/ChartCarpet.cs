using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plotly.NET.LayoutObjects;
using Plotly.NET.TraceObjects;

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
            string? Name = null,
            bool? ShowLegend = null,
            double? Opacity = null,
            IEnumerable<XType>? X = null,
            IEnumerable<IEnumerable<MultiXType>>? MultiX = null,
            IEnumerable<YType>? Y = null,
            IEnumerable<IEnumerable<MultiYType>>? MultiY = null,
            IEnumerable<AType>? A = null,
            IEnumerable<BType>? B = null,
            LinearAxis? AAxis = null,
            LinearAxis? BAxis = null,
            StyleParam.LinearAxisId? XAxis = null,
            StyleParam.LinearAxisId? YAxis = null,
            Color? Color = null,
            double? CheaterSlope = null,
            bool? UseDefaults = true
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
    }
}
