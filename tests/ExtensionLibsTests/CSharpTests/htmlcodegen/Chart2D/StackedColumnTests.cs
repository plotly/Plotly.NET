using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.Chart2D;

public class StackedColumnTests
{
    private const string ExpectedData = """var data = [{"type":"bar","name":"old","x":["Product A","Product B","Product C"],"y":[20,14,23],"orientation":"v","marker":{"pattern":{}}},{"type":"bar","name":"new","x":["Product A","Product B","Product C"],"y":[8,21,13],"orientation":"v","marker":{"pattern":{}}}];""";

    private const string ExpectedLayout = """var layout = {"barmode":"stack"};""";

    private static Plotly.NET.GenericChart CreateStackedColumnChart() =>
        Chart.Combine(
            new[]
            {
                Chart.StackedColumn<int, string, string>(
                    values: new[] { 20, 14, 23 },
                    Keys: new[] { "Product A", "Product B", "Product C" },
                    Name: "old",
                    UseDefaults: false
                ),
                Chart.StackedColumn<int, string, string>(
                    values: new[] { 8, 21, 13 },
                    Keys: new[] { "Product A", "Product B", "Product C" },
                    Name: "new",
                    UseDefaults: false
                )
            }
        );

    [Fact]
    public void StackedColumnChartDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(
            CreateStackedColumnChart(),
            ChartMarkupSection.Data,
            ExpectedData
        );
    }

    [Fact]
    public void StackedColumnChartLayoutMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(
            CreateStackedColumnChart(),
            ChartMarkupSection.Layout,
            ExpectedLayout
        );
    }
}
