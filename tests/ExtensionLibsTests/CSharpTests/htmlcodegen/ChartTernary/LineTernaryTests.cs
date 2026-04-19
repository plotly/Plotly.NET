using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.ChartTernary;

public class LineTernaryTests
{
    private const string ExpectedData = """var data = [{"type":"scatterternary","name":"lineternary","mode":"lines+markers","a":[10,20],"b":[20,10],"marker":{},"line":{},"sum":100}];""";

    private static Plotly.NET.GenericChart CreateLineTernaryChart() =>
        Chart.LineTernary<int, int, int, int, string>(
            A: new[] { 10, 20 },
            B: new[] { 20, 10 },
            Sum: 100,
            ShowMarkers: true,
            Name: "lineternary",
            UseDefaults: false
        );

    [Fact]
    public void LineTernaryChartDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(CreateLineTernaryChart(), ChartMarkupSection.Data, ExpectedData);
    }
}
