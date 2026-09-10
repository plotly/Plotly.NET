using System.Linq;
using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.Chart2D;

public class ScatterTests
{
    private const string ExpectedData = """var data = [{"type":"scatter","name":"scatter","mode":"lines+markers","x":[0.0,1.0,2.0,3.0],"y":[1.0,4.0,9.0,16.0],"marker":{},"line":{}}];""";

    private static Plotly.NET.GenericChart CreateScatterChart() =>
        Chart.Scatter<double, double, string>(
            x: Enumerable.Range(0, 4).Select(x => (double)x).ToArray(),
            y: new[] { 1.0, 4.0, 9.0, 16.0 },
            mode: Plotly.NET.StyleParam.Mode.Lines_Markers,
            Name: "scatter",
            UseDefaults: false
        );

    [Fact]
    public void ScatterChartDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(
            CreateScatterChart(),
            ChartMarkupSection.Data,
            ExpectedData
        );
    }
}
