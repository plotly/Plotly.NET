using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.Chart3D;

public class IsoSurfaceTests
{
    private const string ExpectedData = """var data = [{"type":"isosurface","x":[0,1,0,1],"y":[0,0,1,1],"z":[0,0,1,1],"value":[1,2,3,4],"colorscale":"Viridis"}];""";

    private static Plotly.NET.GenericChart CreateIsoSurfaceChart() =>
        Chart.IsoSurface<int, int, int, int, string>(
            x: new[] { 0, 1, 0, 1 },
            y: new[] { 0, 0, 1, 1 },
            z: new[] { 0, 0, 1, 1 },
            value: new[] { 1, 2, 3, 4 },
            ColorScale: Plotly.NET.StyleParam.Colorscale.Viridis,
            UseDefaults: false
        );

    [Fact]
    public void IsoSurfaceChartDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(
            CreateIsoSurfaceChart(),
            ChartMarkupSection.Data,
            ExpectedData
        );
    }
}
