using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.Chart2D;

public class ColumnTests
{
    private const string ExpectedData = """var data = [{"type":"bar","name":"column","x":["Product A","Product B","Product C"],"y":[20,14,23],"orientation":"v","marker":{"pattern":{}}}];""";

    private static Plotly.NET.GenericChart CreateColumnChart() =>
        Chart.Column<int, string, string>(
            values: new[] { 20, 14, 23 },
            Keys: new[] { "Product A", "Product B", "Product C" },
            Name: "column",
            UseDefaults: false
        );

    [Fact]
    public void ColumnChartDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(
            CreateColumnChart(),
            ChartMarkupSection.Data,
            ExpectedData
        );
    }
}
