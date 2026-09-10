using System.Collections.Generic;
using Plotly.NET;

namespace Plotly.NET.CSharp;

public static partial class Chart
{
    /// <summary>
    /// Create a combined chart with the given charts merged
    /// </summary>
    /// <param name="gCharts">the charts to combine</param>
    /// <returns></returns>
    public static GenericChart Combine(IEnumerable<GenericChart> gCharts) => Plotly.NET.Chart.combine(gCharts);
}
