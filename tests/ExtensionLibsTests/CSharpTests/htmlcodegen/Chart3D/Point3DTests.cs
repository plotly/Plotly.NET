using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.Chart3D;

public class Point3DTests
{
    private const string ExpectedData = """var data = [{"type":"scatter3d","name":"point3d","mode":"markers","x":[1,2,3],"y":[4,5,6],"z":[7,8,9],"marker":{},"line":{}}];""";

    private static Plotly.NET.GenericChart CreatePoint3DChart() =>
        Chart.Point3D<int, int, int, string>(
            x: new[] { 1, 2, 3 },
            y: new[] { 4, 5, 6 },
            z: new[] { 7, 8, 9 },
            Name: "point3d",
            UseDefaults: false
        );

    [Fact]
    public void Point3DChartDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(
            CreatePoint3DChart(),
            ChartMarkupSection.Data,
            ExpectedData
        );
    }
}
