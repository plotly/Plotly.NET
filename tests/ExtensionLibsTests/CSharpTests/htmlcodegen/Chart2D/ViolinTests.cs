using Plotly.NET.CSharp;
using static Plotly.NET.StyleParam;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.Chart2D;

public class ViolinTests
{
    private const string ExpectedData = """var data = [{"type":"violin","name":"violin","x":["bin1","bin1","bin2","bin2"],"y":[2.0,1.5,5.0,3.0],"marker":{},"line":{},"box":{},"points":"all"}];""";

    private static Plotly.NET.GenericChart CreateViolinChart() =>
        Chart.Violin<string, double, string>(
            X: new[] { "bin1", "bin1", "bin2", "bin2" },
            Y: new[] { 2.0, 1.5, 5.0, 3.0 },
            Name: "violin",
            Points: BoxPoints.All,
            UseDefaults: false
        );

    [Fact]
    public void ViolinChartDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(
            CreateViolinChart(),
            ChartMarkupSection.Data,
            ExpectedData
        );
    }
}
