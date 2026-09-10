using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.Chart3D;

public class Bubble3DTests
{
    private const string ExpectedData = """var data = [{"type":"scatter3d","name":"bubble3d","mode":"markers+text","x":[1,2,3],"y":[4,5,6],"z":[7,8,9],"text":["A","B","C"],"textposition":"top left","marker":{"size":[10,20,30]}}];""";

    private static Plotly.NET.GenericChart CreateBubble3DChart() =>
        Chart.Bubble3D<int, int, int, string>(
            x: new[] { 1, 2, 3 },
            y: new[] { 4, 5, 6 },
            z: new[] { 7, 8, 9 },
            sizes: new[] { 10, 20, 30 },
            Name: "bubble3d",
            MultiText: new[] { "A", "B", "C" },
            TextPosition: Plotly.NET.StyleParam.TextPosition.TopLeft,
            UseDefaults: false
        );

    [Fact]
    public void Bubble3DChartDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(
            CreateBubble3DChart(),
            ChartMarkupSection.Data,
            ExpectedData
        );
    }
}
