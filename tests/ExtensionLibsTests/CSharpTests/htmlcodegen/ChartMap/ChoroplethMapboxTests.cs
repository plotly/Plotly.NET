using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.ChartMap;

public class ChoroplethMapboxTests
{
    private const string ExpectedData = """var data = [{"type":"choroplethmapbox","name":"choroplethmapbox","z":[1,2],"geojson":"https://example.com/test.geojson","locations":["A","B"]}];""";

    private static Plotly.NET.GenericChart CreateChoroplethMapboxChart() =>
        Chart.ChoroplethMapbox<int, string>(
            locations: new[] { "A", "B" },
            z: new[] { 1, 2 },
            geoJson: "https://example.com/test.geojson",
            Name: "choroplethmapbox",
            UseDefaults: false
        );

    [Fact]
    public void ChoroplethMapboxChartDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(CreateChoroplethMapboxChart(), ChartMarkupSection.Data, ExpectedData);
    }
}
