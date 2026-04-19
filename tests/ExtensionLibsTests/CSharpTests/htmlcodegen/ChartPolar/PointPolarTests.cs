using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.ChartPolar;

public class PointPolarTests
{
    private const string ExpectedData = """var data = [{"type":"scatterpolar","name":"pointpolar","mode":"markers","r":[1,2,3],"theta":[0,45,90],"marker":{}}];""";

    private static Plotly.NET.GenericChart CreatePointPolarChart() =>
        Chart.PointPolar<int, int, string>(
            r: new[] { 1, 2, 3 },
            theta: new[] { 0, 45, 90 },
            Name: "pointpolar",
            UseDefaults: false
        );

    [Fact]
    public void PointPolarChartDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(
            CreatePointPolarChart(),
            ChartMarkupSection.Data,
            ExpectedData
        );
    }
}
