using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.Chart2D;

public class Histogram2DContourTests
{
    private const string ExpectedData = """var data = [{"type":"histogram2dcontour","name":"histogram2dcontour","x":[1.0,2.0,3.0,4.0],"y":[1.0,2.0,2.0,3.0],"line":{"width":0.0},"contours":{}}];""";

    private static Plotly.NET.GenericChart CreateHistogram2DContourChart() =>
        Chart.Histogram2DContour<double, double, double>(
            X: new[] { 1.0, 2.0, 3.0, 4.0 },
            MultiX: default,
            Y: new[] { 1.0, 2.0, 2.0, 3.0 },
            MultiY: default,
            Name: "histogram2dcontour",
            UseDefaults: false
        );

    [Fact]
    public void Histogram2DContourChartDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(
            CreateHistogram2DContourChart(),
            ChartMarkupSection.Data,
            ExpectedData
        );
    }
}
