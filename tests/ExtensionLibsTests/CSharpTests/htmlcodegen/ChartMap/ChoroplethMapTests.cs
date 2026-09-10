using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.ChartMap;

public class ChoroplethMapTests
{
    private const string ExpectedData = """var data = [{"type":"choropleth","name":"choroplethmap","z":[1,2],"locations":["A","B"]}];""";

    private static Plotly.NET.GenericChart CreateChoroplethMapChart() =>
        Chart.ChoroplethMap<int, string>(
            locations: new[] { "A", "B" },
            z: new[] { 1, 2 },
            Name: "choroplethmap",
            UseDefaults: false
        );

    [Fact]
    public void ChoroplethMapChartDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(CreateChoroplethMapChart(), ChartMarkupSection.Data, ExpectedData);
    }
}
