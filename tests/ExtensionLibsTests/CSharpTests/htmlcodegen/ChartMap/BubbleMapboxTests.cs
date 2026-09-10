using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.ChartMap;

public class BubbleMapboxTests
{
    private const string ExpectedData = """var data = [{"type":"scattermapbox","name":"bubblemapbox","mode":"markers","lat":[2,3],"lon":[1,4],"marker":{"size":[10,20]}}];""";

    private static Plotly.NET.GenericChart CreateBubbleMapboxChart() =>
        Chart.BubbleMapbox<int, int, string>(
            longitudes: new[] { 1, 4 },
            latitudes: new[] { 2, 3 },
            sizes: new[] { 10, 20 },
            Name: "bubblemapbox",
            UseDefaults: false
        );

    [Fact]
    public void BubbleMapboxChartDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(CreateBubbleMapboxChart(), ChartMarkupSection.Data, ExpectedData);
    }
}
