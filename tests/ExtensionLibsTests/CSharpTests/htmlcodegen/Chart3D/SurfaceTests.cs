using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.Chart3D;

public class SurfaceTests
{
    private const string ExpectedData = """var data = [{"type":"surface","x":[0,1],"y":[0,1],"z":[[1,2],[3,4]]}];""";

    private static Plotly.NET.GenericChart CreateSurfaceChart() =>
        Chart.Surface<int, int, int, string>(
            zData: new[]
            {
                new[] { 1, 2 },
                new[] { 3, 4 }
            },
            X: new[] { 0, 1 },
            Y: new[] { 0, 1 },
            UseDefaults: false
        );

    [Fact]
    public void SurfaceChartDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(
            CreateSurfaceChart(),
            ChartMarkupSection.Data,
            ExpectedData
        );
    }
}
