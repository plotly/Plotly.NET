using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.ChartMap;

public class PointGeoTests
{
    private const string ExpectedData = """var data = [{"type":"scattergeo","name":"pointgeo","mode":"markers","lat":[2,3],"lon":[1,4],"marker":{},"line":{}}];""";

    private static Plotly.NET.GenericChart CreatePointGeoChart() =>
        Chart.PointGeo<int, int, string>(
            longitudes: new[] { 1, 4 },
            latitudes: new[] { 2, 3 },
            Name: "pointgeo",
            UseDefaults: false
        );

    [Fact]
    public void PointGeoChartDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(CreatePointGeoChart(), ChartMarkupSection.Data, ExpectedData);
    }
}
