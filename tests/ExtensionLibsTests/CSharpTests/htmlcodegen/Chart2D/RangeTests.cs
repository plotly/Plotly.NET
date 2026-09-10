using System.Linq;
using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.Chart2D;

public class RangeTests
{
    private const string ExpectedData = """var data = [{"type":"scatter","name":"lower","showlegend":true,"legendgroup":"Range","mode":"lines+markers","x":[0.0,1.0,2.0,3.0],"y":[0.0,3.0,8.0,15.0],"marker":{"color":"rgba(0,0,0,0.5)"}},{"type":"scatter","name":"upper","showlegend":true,"legendgroup":"Range","mode":"lines+markers","x":[0.0,1.0,2.0,3.0],"y":[2.0,5.0,10.0,17.0],"fill":"tonexty","marker":{"color":"rgba(0,0,0,0.5)"}},{"type":"scatter","name":"range","mode":"lines+markers","x":[0.0,1.0,2.0,3.0],"y":[1.0,4.0,9.0,16.0],"marker":{},"line":{},"legendgroup":"Range","legendgrouptitle":{"text":"Range"}}];""";

    private static Plotly.NET.GenericChart CreateRangeChart() =>
        Chart.Range<double, double, string>(
            x: Enumerable.Range(0, 4).Select(x => (double)x).ToArray(),
            y: new[] { 1.0, 4.0, 9.0, 16.0 },
            upper: new[] { 2.0, 5.0, 10.0, 17.0 },
            lower: new[] { 0.0, 3.0, 8.0, 15.0 },
            mode: Plotly.NET.StyleParam.Mode.Lines_Markers,
            Name: "range",
            UseDefaults: false
        );

    [Fact]
    public void RangeChartDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(
            CreateRangeChart(),
            ChartMarkupSection.Data,
            ExpectedData
        );
    }
}
