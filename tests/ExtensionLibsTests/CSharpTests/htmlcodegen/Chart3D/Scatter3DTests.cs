using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.Chart3D;

public class Scatter3DTests
{
    private const string ExpectedData = """var data = [{"type":"scatter3d","name":"scatter3d","mode":"lines+markers","x":[1,2,3],"y":[4,5,6],"z":[7,8,9],"marker":{},"line":{}}];""";

    private static Plotly.NET.GenericChart CreateScatter3DChart() =>
        Chart.Scatter3D<int, int, int, string>(
            x: new[] { 1, 2, 3 },
            y: new[] { 4, 5, 6 },
            z: new[] { 7, 8, 9 },
            mode: Plotly.NET.StyleParam.Mode.Lines_Markers,
            Name: "scatter3d",
            UseDefaults: false
        );

    [Fact]
    public void Scatter3DChartDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(
            CreateScatter3DChart(),
            ChartMarkupSection.Data,
            ExpectedData
        );
    }
}
