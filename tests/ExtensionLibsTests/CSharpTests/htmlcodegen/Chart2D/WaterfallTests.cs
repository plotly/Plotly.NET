using Plotly.NET.CSharp;
using static Plotly.NET.StyleParam;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.Chart2D;

public class WaterfallTests
{
    private const string ExpectedData = """var data = [{"type":"waterfall","name":"waterfall","x":["Sales","Consulting","Net revenue"],"y":[60.0,80.0,0.0],"measure":["relative","relative","total"],"increasing":{"line":{}},"decreasing":{"line":{}},"totals":{"line":{}}}];""";

    private static Plotly.NET.GenericChart CreateWaterfallChart() =>
        Chart.Waterfall<string, double, string>(
            x: new[] { "Sales", "Consulting", "Net revenue" },
            y: new[] { 60.0, 80.0, 0.0 },
            Name: "waterfall",
            Measure: new[] { WaterfallMeasure.Relative, WaterfallMeasure.Relative, WaterfallMeasure.Total },
            UseDefaults: false
        );

    [Fact]
    public void WaterfallChartDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(
            CreateWaterfallChart(),
            ChartMarkupSection.Data,
            ExpectedData
        );
    }
}
