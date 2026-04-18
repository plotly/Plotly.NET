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
        /// Creates a parallel coordinates plot.
        ///
        /// Parallel coordinates are a common way of visualizing and analyzing high-dimensional datasets.
        ///
        /// To show a set of points in an n-dimensional space, a backdrop is drawn consisting of n parallel lines, typically vertical and equally spaced. A point in n-dimensional space is represented as a polyline with vertices on the parallel axes; the position of the vertex on the i-th axis corresponds to the i-th coordinate of the point.
        ///
        /// This visualization is closely related to time series visualization, except that it is applied to data where the axes do not correspond to points in time, and therefore do not have a natural order. Therefore, different axis arrangements may be of interest.
        /// </summary>
        /// <param name="dimensions">the dimensions of the plot, containing both dimension backdrop information and the associated data</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="LineColor">Sets the color of the lines that are connecting the datums on the dimensions</param>
        /// <param name="LineColorScale">Sets the colorscale of the lines that are connecting the datums on the dimensions</param>
        /// <param name="ShowLineColorScale">Whether or not to show the colorbar of the lines that are connecting the datums on the dimensions</param>
        /// <param name="ReverseLineColorScale">Whether or not to reverse the colorscale of the lines that are connecting the datums on the dimensions</param>
        /// <param name="Line">Sets the lines that are connecting the datums on the dimensions (use this for more finegrained control than the other line-associated arguments).</param>
        /// <param name="LabelAngle">Sets the angle of the labels with respect to the horizontal. For example, a `tickangle` of -90 draws the labels vertically. Tilted labels with "labelangle" may be positioned better inside margins when `labelposition` is set to "bottom".</param>
        /// <param name="LabelFont">Sets the label font of this trace.</param>
        /// <param name="LabelSide">Specifies the location of the `label`. "top" positions labels above, next to the title "bottom" positions labels below the graph Tilted labels with "labelangle" may be positioned better inside margins when `labelposition` is set to "bottom".</param>
        /// <param name="RangeFont">Sets the range font of this trace.</param>
        /// <param name="TickFont">Sets the tick font of this trace.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart ParallelCoord(
            IEnumerable<Dimension> dimensions,
            Optional<string> Name = default,
            Optional<Color> LineColor = default,
            Optional<StyleParam.Colorscale> LineColorScale = default,
            Optional<bool> ShowLineColorScale = default,
            Optional<bool> ReverseLineColorScale = default,
            Optional<Line> Line = default,
            Optional<int> LabelAngle = default,
            Optional<Font> LabelFont = default,
            Optional<StyleParam.Side> LabelSide = default,
            Optional<Font> RangeFont = default,
            Optional<Font> TickFont = default,
            Optional<bool> UseDefaults = default
        )
            =>
                Plotly.NET.ChartDomain_Relations.Chart.ParallelCoord(
                    dimensions: dimensions,
                    Name: Name.ToOption(),
                    LineColor: LineColor.ToOption(),
                    LineColorScale: LineColorScale.ToOption(),
                    ShowLineColorScale: ShowLineColorScale.ToOption(),
                    ReverseLineColorScale: ReverseLineColorScale.ToOption(),
                    Line: Line.ToOption(),
                    LabelAngle: LabelAngle.ToOption(),
                    LabelFont: LabelFont.ToOption(),
                    LabelSide: LabelSide.ToOption(),
                    RangeFont: RangeFont.ToOption(),
                    TickFont: TickFont.ToOption(),
                    UseDefaults: UseDefaults.ToOption()
                );
}
