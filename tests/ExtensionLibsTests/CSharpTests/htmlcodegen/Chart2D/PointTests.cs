using System.Linq;
using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.Chart2D;

public class PointTests
{
    private const string ExpectedData = """var data = [{"type":"scatter","name":"points","mode":"markers","x":[0.0,1.0,2.0,3.0],"y":[1.0,4.0,9.0,16.0],"marker":{},"line":{}}];""";

    private static Plotly.NET.GenericChart CreatePointChart() =>
        Chart.Point<double, double, string>(
            x: Enumerable.Range(0, 4).Select(x => (double)x).ToArray(),
            y: new[] { 1.0, 4.0, 9.0, 16.0 },
            Name: "points",
            UseDefaults: false
        );

    [Fact]
    public void PointChartDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(
            CreatePointChart(),
            ChartMarkupSection.Data,
            ExpectedData
        );
    }
}
