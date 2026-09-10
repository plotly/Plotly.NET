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
        /// Creates a parallel categories plot.
        ///
        /// The parallel categories diagram (also known as parallel sets or alluvial diagram) is a visualization of
        /// multi-dimensional categorical data sets. Each variable in the data set is represented by a column of rectangles,
        /// where each rectangle corresponds to a discrete value taken on by that variable.
        /// The relative heights of the rectangles reflect the relative frequency of occurrence of the corresponding value.
        /// </summary>
        /// <param name="dimensions">the dimensions of the plot, containing both dimension backdrop information and the associated data</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="Counts">The number of observations represented by each state. Defaults to 1 so that each state represents one observation</param>
        /// <param name="LineColor">Sets the color of the lines that are connecting the datums on the dimensions</param>
        /// <param name="LineShape">Sets the shape of the lines that are connecting the datums on the dimensions</param>
        /// <param name="LineColorScale">Sets the colorscale of the lines that are connecting the datums on the dimensions</param>
        /// <param name="ShowLineColorScale">Whether or not to show the colorbar of the lines that are connecting the datums on the dimensions</param>
        /// <param name="ReverseLineColorScale">Whether or not to reverse the colorscale of the lines that are connecting the datums on the dimensions</param>
        /// <param name="Line">Sets the lines that are connecting the datums on the dimensions (use this for more finegrained control than the other line-associated arguments).</param>
        /// <param name="Arrangement">Sets the drag interaction mode for categories and dimensions. If `perpendicular`, the categories can only move along a line perpendicular to the paths. If `freeform`, the categories can freely move on the plane. If `fixed`, the categories and dimensions are stationary.</param>
        /// <param name="BundleColors">Sort paths so that like colors are bundled together within each category.</param>
        /// <param name="SortPaths">Sets the path sorting algorithm. If `forward`, sort paths based on dimension categories from left to right. If `backward`, sort paths based on dimensions categories from right to left.</param>
        /// <param name="LabelFont">Sets the label font of this trace.</param>
        /// <param name="TickFont">Sets the tick font of this trace.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart ParallelCategories(
            IEnumerable<Dimension> dimensions, 
            Optional<string> Name = default, 
            Optional<int> Counts = default, 
            Optional<Color> LineColor = default, 
            Optional<StyleParam.Shape> LineShape = default, 
            Optional<StyleParam.Colorscale> LineColorScale = default, 
            Optional<bool> ShowLineColorScale = default, 
            Optional<bool> ReverseLineColorScale = default, 
            Optional<Line> Line = default, 
            Optional<StyleParam.CategoryArrangement> Arrangement = default, 
            Optional<bool> BundleColors = default, 
            Optional<StyleParam.SortAlgorithm> SortPaths = default, 
            Optional<Font> LabelFont = default, 
            Optional<Font> TickFont = default, 
            Optional<bool> UseDefaults = default
        )
            =>
                Plotly.NET.ChartDomain_Relations.Chart.ParallelCategories(
                    dimensions: dimensions,
                    Name: Name.ToOption(),
                    Counts: Counts.ToOption(),
                    LineColor: LineColor.ToOption(),
                    LineShape: LineShape.ToOption(),
                    LineColorScale: LineColorScale.ToOption(),
                    ShowLineColorScale: ShowLineColorScale.ToOption(),
                    ReverseLineColorScale: ReverseLineColorScale.ToOption(),
                    Line: Line.ToOption(),
                    Arrangement: Arrangement.ToOption(),
                    BundleColors: BundleColors.ToOption(),
                    SortPaths: SortPaths.ToOption(),
                    LabelFont: LabelFont.ToOption(),
                    TickFont: TickFont.ToOption(),
                    UseDefaults: UseDefaults.ToOption()
                );
}
