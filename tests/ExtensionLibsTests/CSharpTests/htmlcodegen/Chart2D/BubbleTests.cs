using System.Linq;
using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.Chart2D;

public class BubbleTests
{
    private const string ExpectedData = """var data = [{"type":"scatter","name":"bubble","mode":"markers","x":[0.0,1.0,2.0,3.0],"y":[1.0,4.0,9.0,16.0],"marker":{"size":[5,10,15,20]},"line":{}}];""";

    private static Plotly.NET.GenericChart CreateBubbleChart() =>
        Chart.Bubble<double, double, string>(
            x: Enumerable.Range(0, 4).Select(x => (double)x).ToArray(),
            y: new[] { 1.0, 4.0, 9.0, 16.0 },
            sizes: new[] { 5, 10, 15, 20 },
            Name: "bubble",
            UseDefaults: false
        );

    [Fact]
    public void BubbleChartDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(
            CreateBubbleChart(),
            ChartMarkupSection.Data,
            ExpectedData
        );
    }
}
