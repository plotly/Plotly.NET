using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.Chart2D;

public class ContourTests
{
    private const string ExpectedData = """var data = [{"type":"contour","name":"contour","x":["Tp0","Tp30","Tp60"],"y":["p2","p1"],"z":[[1.0,1.5,0.7],[2.0,0.5,1.2]],"line":{"width":0.0},"contours":{}}];""";

    private static Plotly.NET.GenericChart CreateContourChart() =>
        Chart.Contour<double, string, string, string>(
            zData: new[]
            {
                new[] { 1.0, 1.5, 0.7 },
                new[] { 2.0, 0.5, 1.2 }
            },
            X: new[] { "Tp0", "Tp30", "Tp60" },
            Y: new[] { "p2", "p1" },
            Name: "contour",
            UseDefaults: false
        );

    [Fact]
    public void ContourChartDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(
            CreateContourChart(),
            ChartMarkupSection.Data,
            ExpectedData
        );
    }
}
