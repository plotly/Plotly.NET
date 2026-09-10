using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.ChartTernary;

public class PointTernaryTests
{
    private const string ExpectedData = """var data = [{"type":"scatterternary","name":"pointternary","mode":"markers","a":[1],"b":[2],"c":[3],"marker":{},"line":{}}];""";

    private static Plotly.NET.GenericChart CreatePointTernaryChart() =>
        Chart.PointTernary<int, int, int, int, string>(
            A: new[] { 1 },
            B: new[] { 2 },
            C: new[] { 3 },
            Name: "pointternary",
            UseDefaults: false
        );

    [Fact]
    public void PointTernaryChartDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(CreatePointTernaryChart(), ChartMarkupSection.Data, ExpectedData);
    }
}
