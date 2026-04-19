using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.Chart2D;

public class StackedBarTests
{
    private const string ExpectedData = """var data = [{"type":"bar","name":"old","x":[20,14,23],"y":["Product A","Product B","Product C"],"orientation":"h","marker":{"pattern":{}}},{"type":"bar","name":"new","x":[8,21,13],"y":["Product A","Product B","Product C"],"orientation":"h","marker":{"pattern":{}}}];""";

    private const string ExpectedLayout = """var layout = {"barmode":"stack"};""";

    private static Plotly.NET.GenericChart CreateStackedBarChart() =>
        Chart.Combine(
            new[]
            {
                Chart.StackedBar<int, string, string>(
                    values: new[] { 20, 14, 23 },
                    Keys: new[] { "Product A", "Product B", "Product C" },
                    Name: "old",
                    UseDefaults: false
                ),
                Chart.StackedBar<int, string, string>(
                    values: new[] { 8, 21, 13 },
                    Keys: new[] { "Product A", "Product B", "Product C" },
                    Name: "new",
                    UseDefaults: false
                )
            }
        );

    [Fact]
    public void StackedBarChartDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(
            CreateStackedBarChart(),
            ChartMarkupSection.Data,
            ExpectedData
        );
    }

    [Fact]
    public void StackedBarChartLayoutMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(
            CreateStackedBarChart(),
            ChartMarkupSection.Layout,
            ExpectedLayout
        );
    }
}
