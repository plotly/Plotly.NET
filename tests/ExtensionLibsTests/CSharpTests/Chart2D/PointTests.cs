using System.Linq;
using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.Chart2D;

public class PointTests
{
    private static Plotly.NET.GenericChart CreatePointChart() =>
        Chart.Point<double, double, string>(
            x: Enumerable.Range(0, 4).Select(x => (double)x).ToArray(),
            y: new[] { 1.0, 4.0, 9.0, 16.0 },
            Name: "points",
            UseDefaults: false
        );

    [Fact]
    public void PointChartContainsExpectedTraceTypeAndMode()
    {
        TestUtils.ChartGeneratedContains(
            CreatePointChart(),
            "\"type\":\"scatter\""
        );

        TestUtils.ChartGeneratedContains(
            CreatePointChart(),
            "\"mode\":\"markers\""
        );
    }

    [Fact]
    public void PointChartContainsExpectedTraceName()
    {
        TestUtils.ChartGeneratedContains(
            CreatePointChart(),
            "\"name\":\"points\""
        );
    }
}
