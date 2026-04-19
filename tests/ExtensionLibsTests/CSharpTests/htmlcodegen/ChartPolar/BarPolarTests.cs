using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.ChartPolar;

public class BarPolarTests
{
    private const string ExpectedData = """var data = [{"type":"barpolar","name":"barpolar","r":[1,2,3],"theta":["N","E","S"],"marker":{"pattern":{}}}];""";

    private static Plotly.NET.GenericChart CreateBarPolarChart() =>
        Chart.BarPolar<int, string, string>(
            r: new[] { 1, 2, 3 },
            theta: new[] { "N", "E", "S" },
            Name: "barpolar",
            UseDefaults: false
        );

    [Fact]
    public void BarPolarChartDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(
            CreateBarPolarChart(),
            ChartMarkupSection.Data,
            ExpectedData
        );
    }
}
