using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.ChartTernary;

public class BubbleTernaryTests
{
    private const string ExpectedData = """var data = [{"type":"scatterternary","name":"bubbleternary","mode":"markers","a":[1,2],"b":[2,3],"c":[3,4],"marker":{"size":[10,20]},"line":{}}];""";

    private static Plotly.NET.GenericChart CreateBubbleTernaryChart() =>
        Chart.BubbleTernary<int, int, int, int, string>(
            sizes: new[] { 10, 20 },
            A: new[] { 1, 2 },
            B: new[] { 2, 3 },
            C: new[] { 3, 4 },
            Name: "bubbleternary",
            UseDefaults: false
        );

    [Fact]
    public void BubbleTernaryChartDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(CreateBubbleTernaryChart(), ChartMarkupSection.Data, ExpectedData);
    }
}
