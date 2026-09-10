using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.Chart2D;

public class BarTests
{
    private const string ExpectedData = """var data = [{"type":"bar","name":"bar","x":[20,14,23],"y":["Product A","Product B","Product C"],"orientation":"h","marker":{"pattern":{}}}];""";

    private static Plotly.NET.GenericChart CreateBarChart() =>
        Chart.Bar<int, string, string>(
            values: new[] { 20, 14, 23 },
            Keys: new[] { "Product A", "Product B", "Product C" },
            Name: "bar",
            UseDefaults: false
        );

    [Fact]
    public void BarChartDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(
            CreateBarChart(),
            ChartMarkupSection.Data,
            ExpectedData
        );
    }
}
