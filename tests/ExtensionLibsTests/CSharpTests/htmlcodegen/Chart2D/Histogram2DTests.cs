using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.Chart2D;

public class Histogram2DTests
{
    private const string ExpectedData = """var data = [{"type":"histogram2d","name":"histogram2d","x":[1.0,2.0,3.0,4.0],"y":[1.0,2.0,2.0,3.0]}];""";

    private static Plotly.NET.GenericChart CreateHistogram2DChart() =>
        Chart.Histogram2D<double, double, double>(
            x: new[] { 1.0, 2.0, 3.0, 4.0 },
            y: new[] { 1.0, 2.0, 2.0, 3.0 },
            Name: "histogram2d",
            UseDefaults: false
        );

    [Fact]
    public void Histogram2DChartDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(
            CreateHistogram2DChart(),
            ChartMarkupSection.Data,
            ExpectedData
        );
    }
}
