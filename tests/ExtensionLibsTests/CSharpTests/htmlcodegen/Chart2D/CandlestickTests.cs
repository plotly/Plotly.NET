using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.Chart2D;

public class CandlestickTests
{
    private const string ExpectedData = """var data = [{"type":"candlestick","name":"candlestick","x":["2020-01-17T13:40:00","2020-01-17T13:41:00","2020-01-17T13:42:00"],"close":[0.6888,0.68877,0.68886],"open":[0.68888,0.68883,0.68878],"high":[0.68888,0.68884,0.68889],"low":[0.68879,0.68875,0.68878],"increasing":{"line":{}},"decreasing":{"line":{}}}];""";

    private const string ExpectedLayout = """var layout = {"xaxis":{"rangeslider":{"yaxis":{}}}};""";

    private static Plotly.NET.GenericChart CreateCandlestickChart() =>
        Chart.Candlestick<double, string, string>(
            open: new[] { 0.68888, 0.68883, 0.68878 },
            high: new[] { 0.68888, 0.68884, 0.68889 },
            low: new[] { 0.68879, 0.68875, 0.68878 },
            close: new[] { 0.68880, 0.68877, 0.68886 },
            X: new[] { "2020-01-17T13:40:00", "2020-01-17T13:41:00", "2020-01-17T13:42:00" },
            MultiX: default,
            Name: "candlestick",
            UseDefaults: false
        );

    [Fact]
    public void CandlestickChartDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(
            CreateCandlestickChart(),
            ChartMarkupSection.Data,
            ExpectedData
        );
    }

    [Fact]
    public void CandlestickChartLayoutMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(
            CreateCandlestickChart(),
            ChartMarkupSection.Layout,
            ExpectedLayout
        );
    }
}
