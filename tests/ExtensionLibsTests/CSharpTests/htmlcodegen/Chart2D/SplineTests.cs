using System.Linq;
using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.Chart2D;

public class SplineTests
{
    private const string ExpectedData = """var data = [{"type":"scatter","name":"spline","mode":"lines","x":[0.0,1.0,2.0,3.0],"y":[1.0,4.0,9.0,16.0],"marker":{},"line":{"shape":"spline"}}];""";

    private static Plotly.NET.GenericChart CreateSplineChart() =>
        Chart.Spline<double, double, string>(
            x: Enumerable.Range(0, 4).Select(x => (double)x).ToArray(),
            y: new[] { 1.0, 4.0, 9.0, 16.0 },
            Name: "spline",
            UseDefaults: false
        );

    [Fact]
    public void SplineChartDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(
            CreateSplineChart(),
            ChartMarkupSection.Data,
            ExpectedData
        );
    }
}
