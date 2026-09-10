using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.ChartPolar;

public class LinePolarTests
{
    private const string ExpectedData = """var data = [{"type":"scatterpolar","name":"linepolar","mode":"lines+markers","r":[1,2,3],"theta":[0,45,90],"marker":{},"line":{}}];""";

    private static Plotly.NET.GenericChart CreateLinePolarChart() =>
        Chart.LinePolar<int, int, string>(
            r: new[] { 1, 2, 3 },
            theta: new[] { 0, 45, 90 },
            ShowMarkers: true,
            Name: "linepolar",
            UseDefaults: false
        );

    [Fact]
    public void LinePolarChartDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(
            CreateLinePolarChart(),
            ChartMarkupSection.Data,
            ExpectedData
        );
    }
}
