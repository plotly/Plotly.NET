using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.RootChart;

public class CombineTests
{
    private const string ExpectedData = """var data = [{"type":"scatter","name":"first","mode":"lines","x":[1.0,2.0,3.0,4.0],"y":[2.0,1.5,5.0,1.5],"marker":{},"line":{}},{"type":"scatter","name":"second","mode":"lines","x":[2.0,1.5,5.0,1.5],"y":[1.0,2.0,3.0,4.0],"marker":{},"line":{}}];""";

    private static Plotly.NET.GenericChart CreateCombinedChart() =>
        Chart.Combine(
            new[]
            {
                Chart.Line<double, double, string>(
                    x: new[] { 1.0, 2.0, 3.0, 4.0 },
                    y: new[] { 2.0, 1.5, 5.0, 1.5 },
                    Name: "first",
                    UseDefaults: false
                ),
                Chart.Line<double, double, string>(
                    x: new[] { 2.0, 1.5, 5.0, 1.5 },
                    y: new[] { 1.0, 2.0, 3.0, 4.0 },
                    Name: "second",
                    UseDefaults: false
                )
            }
        );

    [Fact]
    public void CombineDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(
            CreateCombinedChart(),
            ChartMarkupSection.Data,
            ExpectedData
        );
    }
}
