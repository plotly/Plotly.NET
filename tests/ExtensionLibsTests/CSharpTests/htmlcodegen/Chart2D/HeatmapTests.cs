using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.Chart2D;

public class HeatmapTests
{
    private const string ExpectedData = """var data = [{"type":"heatmap","name":"heatmap","x":["Tp0","Tp30","Tp60"],"y":["p2","p1"],"z":[[1.0,1.5,0.7],[2.0,0.5,1.2]]}];""";

    private static Plotly.NET.GenericChart CreateHeatmapChart() =>
        Chart.Heatmap<double, string, string, string>(
            zData: new[]
            {
                new[] { 1.0, 1.5, 0.7 },
                new[] { 2.0, 0.5, 1.2 }
            },
            X: new[] { "Tp0", "Tp30", "Tp60" },
            Y: new[] { "p2", "p1" },
            Name: "heatmap",
            UseDefaults: false
        );

    [Fact]
    public void HeatmapChartDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(
            CreateHeatmapChart(),
            ChartMarkupSection.Data,
            ExpectedData
        );
    }
}
