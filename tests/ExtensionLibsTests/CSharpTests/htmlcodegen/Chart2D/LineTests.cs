using System.Linq;
using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.Chart2D;

public class LineTests
{
    private const string ExpectedData = """var data = [{"type":"scatter","name":"line","mode":"lines","x":[0.0,1.0,2.0,3.0],"y":[1.0,4.0,9.0,16.0],"marker":{},"line":{}}];""";

    private static Plotly.NET.GenericChart CreateLineChart() =>
        Chart.Line<double, double, string>(
            x: Enumerable.Range(0, 4).Select(x => (double)x).ToArray(),
            y: new[] { 1.0, 4.0, 9.0, 16.0 },
            Name: "line",
            UseDefaults: false
        );

    [Fact]
    public void LineChartDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(
            CreateLineChart(),
            ChartMarkupSection.Data,
            ExpectedData
        );
    }
}
