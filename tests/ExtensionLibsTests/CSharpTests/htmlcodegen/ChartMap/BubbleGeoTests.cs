using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.ChartMap;

public class BubbleGeoTests
{
    private const string ExpectedData = """var data = [{"type":"scattergeo","name":"bubblegeo","mode":"markers","lat":[2,3],"lon":[1,4],"marker":{"size":[10,20]}}];""";

    private static Plotly.NET.GenericChart CreateBubbleGeoChart() =>
        Chart.BubbleGeo<int, int, string>(
            longitudes: new[] { 1, 4 },
            latitudes: new[] { 2, 3 },
            sizes: new[] { 10, 20 },
            Name: "bubblegeo",
            UseDefaults: false
        );

    [Fact]
    public void BubbleGeoChartDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(CreateBubbleGeoChart(), ChartMarkupSection.Data, ExpectedData);
    }
}
