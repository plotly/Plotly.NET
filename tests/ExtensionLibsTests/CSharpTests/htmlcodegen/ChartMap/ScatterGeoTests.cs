using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.ChartMap;

public class ScatterGeoTests
{
    private const string ExpectedData = """var data = [{"type":"scattergeo","name":"scattergeo","mode":"lines+markers","lat":[2,3],"lon":[1,4],"marker":{},"line":{}}];""";

    private static Plotly.NET.GenericChart CreateScatterGeoChart() =>
        Chart.ScatterGeo<int, int, string>(
            longitudes: new[] { 1, 4 },
            latitudes: new[] { 2, 3 },
            mode: Plotly.NET.StyleParam.Mode.Lines_Markers,
            Name: "scattergeo",
            UseDefaults: false
        );

    [Fact]
    public void ScatterGeoChartDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(CreateScatterGeoChart(), ChartMarkupSection.Data, ExpectedData);
    }
}
