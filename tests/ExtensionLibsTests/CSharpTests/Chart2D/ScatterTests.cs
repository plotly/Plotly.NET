using System.Linq;
using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.Chart2D;

public class ScatterTests
{
    private static Plotly.NET.GenericChart CreateScatterChart() =>
        Chart.Scatter<double, double, string>(
            x: Enumerable.Range(0, 4).Select(x => (double)x).ToArray(),
            y: new[] { 1.0, 4.0, 9.0, 16.0 },
            mode: Plotly.NET.StyleParam.Mode.Lines_Markers,
            Name: "scatter",
            UseDefaults: false
        );

    [Fact]
    public void ScatterChartContainsExpectedTraceTypeAndXValues()
    {
        TestUtils.ChartGeneratedContains(
            CreateScatterChart(),
            "\"type\":\"scatter\""
        );

        TestUtils.ChartGeneratedContains(
            CreateScatterChart(),
            "\"x\":[0.0,1.0,2.0,3.0]"
        );
    }

    [Fact]
    public void ScatterChartContainsExpectedTraceName()
    {
        TestUtils.ChartGeneratedContains(
            CreateScatterChart(),
            "\"name\":\"scatter\""
        );
    }
}
