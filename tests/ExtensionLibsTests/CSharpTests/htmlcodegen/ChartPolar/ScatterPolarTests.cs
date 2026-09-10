using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.ChartPolar;

public class ScatterPolarTests
{
    private const string ExpectedData = """var data = [{"type":"scatterpolar","name":"scatterpolar","mode":"lines+markers","r":[1,2,3],"theta":[0,45,90],"marker":{},"line":{}}];""";

    private static Plotly.NET.GenericChart CreateScatterPolarChart() =>
        Chart.ScatterPolar<int, int, string>(
            r: new[] { 1, 2, 3 },
            theta: new[] { 0, 45, 90 },
            mode: Plotly.NET.StyleParam.Mode.Lines_Markers,
            Name: "scatterpolar",
            UseDefaults: false
        );

    [Fact]
    public void ScatterPolarChartDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(
            CreateScatterPolarChart(),
            ChartMarkupSection.Data,
            ExpectedData
        );
    }
}
