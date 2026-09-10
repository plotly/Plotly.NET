using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.Chart3D;

public class Line3DTests
{
    private const string ExpectedData = """var data = [{"type":"scatter3d","name":"line3d","mode":"lines+markers","x":[1,2,3],"y":[4,5,6],"z":[7,8,9],"marker":{},"line":{}}];""";

    private static Plotly.NET.GenericChart CreateLine3DChart() =>
        Chart.Line3D<int, int, int, string>(
            x: new[] { 1, 2, 3 },
            y: new[] { 4, 5, 6 },
            z: new[] { 7, 8, 9 },
            ShowMarkers: true,
            Name: "line3d",
            UseDefaults: false
        );

    [Fact]
    public void Line3DChartDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(
            CreateLine3DChart(),
            ChartMarkupSection.Data,
            ExpectedData
        );
    }
}
