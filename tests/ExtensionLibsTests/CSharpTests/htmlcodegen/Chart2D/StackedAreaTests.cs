using System.Linq;
using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.Chart2D;

public class StackedAreaTests
{
    private const string ExpectedData = """var data = [{"type":"scatter","name":"stackedArea","mode":"lines","x":[0.0,1.0,2.0,3.0],"y":[1.0,4.0,9.0,16.0],"stackgroup":"stackedarea","marker":{},"line":{},"fill":"tonexty","fillpattern":{}}];""";

    private static Plotly.NET.GenericChart CreateStackedAreaChart() =>
        Chart.StackedArea<double, double, string>(
            x: Enumerable.Range(0, 4).Select(x => (double)x).ToArray(),
            y: new[] { 1.0, 4.0, 9.0, 16.0 },
            Name: "stackedArea",
            UseDefaults: false
        );

    [Fact]
    public void StackedAreaChartDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(
            CreateStackedAreaChart(),
            ChartMarkupSection.Data,
            ExpectedData
        );
    }
}
