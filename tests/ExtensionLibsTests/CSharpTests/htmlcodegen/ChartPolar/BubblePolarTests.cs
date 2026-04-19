using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.ChartPolar;

public class BubblePolarTests
{
    private const string ExpectedData = """var data = [{"type":"scatterpolar","name":"bubblepolar","mode":"markers","r":[1,2,3],"theta":[0,45,90],"text":["A","B","C"],"textposition":"top left","marker":{"size":[10,20,30]}}];""";

    private static Plotly.NET.GenericChart CreateBubblePolarChart() =>
        Chart.BubblePolar<int, int, string>(
            r: new[] { 1, 2, 3 },
            theta: new[] { 0, 45, 90 },
            sizes: new[] { 10, 20, 30 },
            Name: "bubblepolar",
            MultiText: new[] { "A", "B", "C" },
            TextPosition: Plotly.NET.StyleParam.TextPosition.TopLeft,
            UseDefaults: false
        );

    [Fact]
    public void BubblePolarChartDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(
            CreateBubblePolarChart(),
            ChartMarkupSection.Data,
            ExpectedData
        );
    }
}
