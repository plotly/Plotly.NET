using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.Chart3D;

public class ConeTests
{
    private const string ExpectedData = """var data = [{"type":"cone","x":[1,1,1],"y":[1,2,3],"z":[1,1,1],"u":[1,2,3],"v":[1,1,2],"w":[4,4,1],"colorscale":"Viridis"}];""";

    private static Plotly.NET.GenericChart CreateConeChart() =>
        Chart.Cone<int, int, int, int, int, int, string>(
            x: new[] { 1, 1, 1 },
            y: new[] { 1, 2, 3 },
            z: new[] { 1, 1, 1 },
            u: new[] { 1, 2, 3 },
            v: new[] { 1, 1, 2 },
            w: new[] { 4, 4, 1 },
            ColorScale: Plotly.NET.StyleParam.Colorscale.Viridis,
            UseDefaults: false
        );

    [Fact]
    public void ConeChartDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(
            CreateConeChart(),
            ChartMarkupSection.Data,
            ExpectedData
        );
    }
}
