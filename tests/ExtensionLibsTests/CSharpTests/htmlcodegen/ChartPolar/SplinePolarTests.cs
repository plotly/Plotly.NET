using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.ChartPolar;

public class SplinePolarTests
{
    private const string ExpectedData = """var data = [{"type":"scatterpolar","name":"splinepolar","mode":"lines+markers","r":[1,2,3],"theta":[0,45,90],"marker":{},"line":{"shape":"spline"}}];""";

    private static Plotly.NET.GenericChart CreateSplinePolarChart() =>
        Chart.SplinePolar<int, int, string>(
            r: new[] { 1, 2, 3 },
            theta: new[] { 0, 45, 90 },
            ShowMarkers: true,
            Name: "splinepolar",
            UseDefaults: false
        );

    [Fact]
    public void SplinePolarChartDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(
            CreateSplinePolarChart(),
            ChartMarkupSection.Data,
            ExpectedData
        );
    }
}
