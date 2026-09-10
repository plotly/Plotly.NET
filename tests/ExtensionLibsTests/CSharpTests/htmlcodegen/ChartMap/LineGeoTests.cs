using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.ChartMap;

public class LineGeoTests
{
    private const string ExpectedData = """var data = [{"type":"scattergeo","name":"linegeo","mode":"lines+markers","lat":[2,3],"lon":[1,4],"marker":{},"line":{}}];""";

    private static Plotly.NET.GenericChart CreateLineGeoChart() =>
        Chart.LineGeo<int, int, string>(
            longitudes: new[] { 1, 4 },
            latitudes: new[] { 2, 3 },
            ShowMarkers: true,
            Name: "linegeo",
            UseDefaults: false
        );

    [Fact]
    public void LineGeoChartDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(CreateLineGeoChart(), ChartMarkupSection.Data, ExpectedData);
    }
}
