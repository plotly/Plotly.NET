using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.Chart3D;

public class StreamTubeTests
{
    private const string ExpectedData = """var data = [{"type":"streamtube","x":[0,0,0],"y":[0,1,2],"z":[0,0,0],"u":[0,0,0],"v":[1,1,1],"w":[0,0,0],"colorscale":"Viridis"}];""";

    private static Plotly.NET.GenericChart CreateStreamTubeChart() =>
        Chart.StreamTube<int, int, int, int, int, int, string>(
            x: new[] { 0, 0, 0 },
            y: new[] { 0, 1, 2 },
            z: new[] { 0, 0, 0 },
            u: new[] { 0, 0, 0 },
            v: new[] { 1, 1, 1 },
            w: new[] { 0, 0, 0 },
            ColorScale: Plotly.NET.StyleParam.Colorscale.Viridis,
            UseDefaults: false
        );

    [Fact]
    public void StreamTubeChartDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(
            CreateStreamTubeChart(),
            ChartMarkupSection.Data,
            ExpectedData
        );
    }
}
