using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.ChartTernary;

public class ScatterTernaryTests
{
    private const string ExpectedData = """var data = [{"type":"scatterternary","name":"scatterternary","mode":"lines+markers","a":[1,2],"b":[2,3],"c":[3,4],"marker":{},"line":{}}];""";

    private static Plotly.NET.GenericChart CreateScatterTernaryChart() =>
        Chart.ScatterTernary<int, int, int, int, string>(
            A: new[] { 1, 2 },
            B: new[] { 2, 3 },
            C: new[] { 3, 4 },
            Mode: Plotly.NET.StyleParam.Mode.Lines_Markers,
            Name: "scatterternary",
            UseDefaults: false
        );

    [Fact]
    public void ScatterTernaryChartDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(CreateScatterTernaryChart(), ChartMarkupSection.Data, ExpectedData);
    }
}
