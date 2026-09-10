using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.ChartMap;

public class DensityMapboxTests
{
    private const string ExpectedData = """var data = [{"type":"densitymapbox","name":"densitymapbox","z":[1,2],"radius":8,"lat":[2,3],"lon":[1,4],"colorscale":"Viridis"}];""";

    private static Plotly.NET.GenericChart CreateDensityMapboxChart() =>
        Chart.DensityMapbox<int, int, int, string>(
            longitudes: new[] { 1, 4 },
            latitudes: new[] { 2, 3 },
            Name: "densitymapbox",
            Z: new[] { 1, 2 },
            Radius: 8,
            ColorScale: Plotly.NET.StyleParam.Colorscale.Viridis,
            UseDefaults: false
        );

    [Fact]
    public void DensityMapboxChartDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(CreateDensityMapboxChart(), ChartMarkupSection.Data, ExpectedData);
    }
}
