using Plotly.NET.CSharp;
using static Plotly.NET.StyleParam;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.Chart2D;

public class BoxPlotTests
{
    private const string ExpectedData = """var data = [{"type":"box","name":"boxplot","x":["bin1","bin1","bin2","bin2"],"y":[2.0,1.5,5.0,3.0],"marker":{},"line":{},"boxpoints":"all","jitter":0.1}];""";

    private static Plotly.NET.GenericChart CreateBoxPlotChart() =>
        Chart.BoxPlot<string, double, string>(
            X: new[] { "bin1", "bin1", "bin2", "bin2" },
            Y: new[] { 2.0, 1.5, 5.0, 3.0 },
            Name: "boxplot",
            Jitter: 0.1,
            BoxPoints: BoxPoints.All,
            UseDefaults: false
        );

    [Fact]
    public void BoxPlotChartDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(
            CreateBoxPlotChart(),
            ChartMarkupSection.Data,
            ExpectedData
        );
    }
}
