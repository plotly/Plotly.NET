using Plotly.NET;

namespace Plotly.NET.CSharp;

public static partial class Chart
{
    /// <summary>
    /// Creates a chart that is completely invisible when rendered. The Chart object however is NOT empty! Combining this chart with other charts will have unforseen consequences (it has for example invisible axes that can override other axes if used in Chart.Combine)
    /// </summary>
    /// <returns></returns>
    public static GenericChart Invisible() => Plotly.NET.Chart.Invisible();
}
