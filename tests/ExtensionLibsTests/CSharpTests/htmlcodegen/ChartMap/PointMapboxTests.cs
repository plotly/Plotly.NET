using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.ChartMap;

public class PointMapboxTests
{
    private const string ExpectedData = """var data = [{"type":"scattermapbox","name":"pointmapbox","mode":"markers","lat":[2,3],"lon":[1,4],"cluster":{},"marker":{},"line":{}}];""";

    private static Plotly.NET.GenericChart CreatePointMapboxChart() =>
        Chart.PointMapbox<int, int, string>(
            longitudes: new[] { 1, 4 },
            latitudes: new[] { 2, 3 },
            Name: "pointmapbox",
            UseDefaults: false
        );

    [Fact]
    public void PointMapboxChartDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(CreatePointMapboxChart(), ChartMarkupSection.Data, ExpectedData);
    }
}
