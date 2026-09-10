using System;
using System.Collections.Generic;
using System.Linq;
using Plotly.NET;
using Plotly.NET.LayoutObjects;
using Plotly.NET.TraceObjects;
using static Plotly.NET.StyleParam;

namespace Plotly.NET.CSharp;

public static partial class Chart
{
    /// <summary> Creates a Pareto chart. </summary>
    /// <param name="keysValues">Sets the (key,value) pairs that are plotted as the size and key of each bar.</param>
    /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
    /// <param name="Label">Sets the y axis label.</param>
    /// <param name="ShowGrid">Determines whether or not grid lines are drawn. If "true", the grid lines are drawn for the pareto distribution figure; defaults to true.</param>
    public static GenericChart Pareto<TLabel>(
        IEnumerable<(TLabel, double)> keysValues
        , Optional<string> Name
        , Optional<string> Label
        , Optional<bool> ShowGrid
        )
        where TLabel : IConvertible
        =>
            Chart2D_Statistical.Chart.Pareto(
                keysValues.Select(t => t.ToTuple())
                , Name: Name.ToOption()
                , Label: Label.ToOption()
                , ShowGrid: ShowGrid.ToOption()
            );

    /// <summary> Creates a Pareto chart. </summary>
    /// <param name="labels">Sets the labels that are matching the <see paramref="values"/>.</param>
    /// <param name="values">Sets the values that are plotted as the size of each bar.</param>
    /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
    /// <param name="Label">Sets the y axis label.</param>
    /// <param name="ShowGrid">Determines whether or not grid lines are drawn. If "true", the grid lines are drawn for the pareto distribution figure; defaults to true.</param>
    public static GenericChart Pareto<TLabel>(
        IEnumerable<TLabel> labels
        , IEnumerable<double> values
        , Optional<string> Name
        , Optional<string> Label
        , Optional<bool> ShowGrid
        )
        where TLabel : IConvertible
        =>
            Chart2D_Statistical.Chart.Pareto(
                labels
                , values
                , Name: Name.ToOption()
                , Label: Label.ToOption()
                , ShowGrid: ShowGrid.ToOption()
            );
}
