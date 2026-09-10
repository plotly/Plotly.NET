using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.Chart2D;

public class ImageTests
{
    private const string ExpectedData = """var data = [{"type":"image","name":"image","z":[[[0,0,255],[255,255,0]],[[255,0,0],[255,0,255]]]}];""";

    private static Plotly.NET.GenericChart CreateImageChart() =>
        Chart.Image<string>(
            Z: new[]
            {
                new[]
                {
                    new[] { 0, 0, 255 },
                    new[] { 255, 255, 0 }
                },
                new[]
                {
                    new[] { 255, 0, 0 },
                    new[] { 255, 0, 255 }
                }
            },
            Name: "image",
            UseDefaults: false
        );

    [Fact]
    public void ImageChartDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(
            CreateImageChart(),
            ChartMarkupSection.Data,
            ExpectedData
        );
    }
}
