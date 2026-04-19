using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.ChartMap;

public class ScatterMapboxTests
{
    private const string ExpectedData = """var data = [{"type":"scattermapbox","name":"scattermapbox","mode":"lines+markers","lat":[2,3],"lon":[1,4],"cluster":{},"marker":{},"line":{}}];""";

    private static Plotly.NET.GenericChart CreateScatterMapboxChart() =>
        Chart.ScatterMapbox<int, int, string>(
            longitudes: new[] { 1, 4 },
            latitudes: new[] { 2, 3 },
            mode: Plotly.NET.StyleParam.Mode.Lines_Markers,
            Name: "scattermapbox",
            UseDefaults: false
        );

    [Fact]
    public void ScatterMapboxChartDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(CreateScatterMapboxChart(), ChartMarkupSection.Data, ExpectedData);
    }
}
