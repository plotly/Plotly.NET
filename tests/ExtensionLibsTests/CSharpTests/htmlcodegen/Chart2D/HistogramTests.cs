using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.Chart2D;

public class HistogramTests
{
    private const string ExpectedData = """var data = [{"type":"histogram","name":"histogram","x":[1.0,1.5,2.0,2.5],"marker":{"pattern":{}}}];""";

    private static Plotly.NET.GenericChart CreateHistogramChart() =>
        Chart.Histogram<double, double, string>(
            X: new[] { 1.0, 1.5, 2.0, 2.5 },
            Name: "histogram",
            UseDefaults: false
        );

    [Fact]
    public void HistogramChartDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(
            CreateHistogramChart(),
            ChartMarkupSection.Data,
            ExpectedData
        );
    }
}
