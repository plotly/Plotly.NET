using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.ChartMap;

public class LineMapboxTests
{
    private const string ExpectedData = """var data = [{"type":"scattermapbox","name":"linemapbox","mode":"lines+markers","lat":[2,3],"lon":[1,4],"cluster":{},"marker":{},"line":{}}];""";

    private static Plotly.NET.GenericChart CreateLineMapboxChart() =>
        Chart.LineMapbox<int, int, string>(
            longitudes: new[] { 1, 4 },
            latitudes: new[] { 2, 3 },
            ShowMarkers: true,
            Name: "linemapbox",
            UseDefaults: false
        );

    [Fact]
    public void LineMapboxChartDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(CreateLineMapboxChart(), ChartMarkupSection.Data, ExpectedData);
    }
}
