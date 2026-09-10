using System.Linq;
using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.Chart2D;

public class SplineAreaTests
{
    private const string ExpectedData = """var data = [{"type":"scatter","name":"splineArea","mode":"lines","x":[0.0,1.0,2.0,3.0],"y":[1.0,4.0,9.0,16.0],"marker":{},"line":{"shape":"spline"},"fill":"tozeroy","fillpattern":{}}];""";

    private static Plotly.NET.GenericChart CreateSplineAreaChart() =>
        Chart.SplineArea<double, double, string>(
            x: Enumerable.Range(0, 4).Select(x => (double)x).ToArray(),
            y: new[] { 1.0, 4.0, 9.0, 16.0 },
            Name: "splineArea",
            UseDefaults: false
        );

    [Fact]
    public void SplineAreaChartDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(
            CreateSplineAreaChart(),
            ChartMarkupSection.Data,
            ExpectedData
        );
    }
}
