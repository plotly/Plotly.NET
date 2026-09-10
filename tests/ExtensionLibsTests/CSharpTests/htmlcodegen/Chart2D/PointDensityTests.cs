using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.Chart2D;

public class PointDensityTests
{
    private const string ExpectedData = """var data = [{"type":"histogram2dcontour","x":[1.0,2.0,3.0,4.0],"y":[1.0,1.5,2.5,3.0],"line":{"width":0.0},"contours":{"coloring":"fill"}},{"type":"scatter","opacity":0.3,"mode":"markers","x":[1.0,2.0,3.0,4.0],"y":[1.0,1.5,2.5,3.0],"marker":{}}];""";

    private static Plotly.NET.GenericChart CreatePointDensityChart() =>
        Chart.PointDensity<double, double>(
            x: new[] { 1.0, 2.0, 3.0, 4.0 },
            y: new[] { 1.0, 1.5, 2.5, 3.0 },
            UseDefaults: false
        );

    [Fact]
    public void PointDensityChartDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(
            CreatePointDensityChart(),
            ChartMarkupSection.Data,
            ExpectedData
        );
    }
}
