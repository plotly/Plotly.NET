using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.Chart3D;

public class Mesh3DTests
{
    private const string ExpectedData = """var data = [{"type":"mesh3d","x":[0,1,0,0],"y":[0,0,1,0],"z":[0,0,0,1],"i":[0],"j":[1],"k":[2]}];""";

    private static Plotly.NET.GenericChart CreateMesh3DChart() =>
        Chart.Mesh3D<int, int, int, int, int, int, string>(
            x: new[] { 0, 1, 0, 0 },
            y: new[] { 0, 0, 1, 0 },
            z: new[] { 0, 0, 0, 1 },
            I: new[] { 0 },
            J: new[] { 1 },
            K: new[] { 2 },
            UseDefaults: false
        );

    [Fact]
    public void Mesh3DChartDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(
            CreateMesh3DChart(),
            ChartMarkupSection.Data,
            ExpectedData
        );
    }
}
