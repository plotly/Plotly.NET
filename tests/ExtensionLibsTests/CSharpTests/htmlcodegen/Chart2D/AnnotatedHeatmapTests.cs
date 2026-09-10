using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.Chart2D;

public class AnnotatedHeatmapTests
{
    private const string ExpectedData = """var data = [{"type":"heatmap","name":"annotatedHeatmap","x":["C1","C2","C3"],"y":["R1","R2"],"z":[[1,2,3],[4,5,6]]}];""";

    private const string ExpectedLayout = """var layout = {"yaxis":{"autorange":"reversed"},"annotations":[{"x":0,"y":0,"showarrow":false,"text":"1,1"},{"x":1,"y":0,"showarrow":false,"text":"1,2"},{"x":2,"y":0,"showarrow":false,"text":"1,3"},{"x":0,"y":1,"showarrow":false,"text":"2,1"},{"x":1,"y":1,"showarrow":false,"text":"2,2"},{"x":2,"y":1,"showarrow":false,"text":"2,3"}]};""";

    private static Plotly.NET.GenericChart CreateAnnotatedHeatmapChart() =>
        Chart.AnnotatedHeatmap<int, string, string, string>(
            zData: new[]
            {
                new[] { 1, 2, 3 },
                new[] { 4, 5, 6 }
            },
            annotationText: new[]
            {
                new[] { "1,1", "1,2", "1,3" },
                new[] { "2,1", "2,2", "2,3" }
            },
            X: new[] { "C1", "C2", "C3" },
            Y: new[] { "R1", "R2" },
            Name: "annotatedHeatmap",
            ReverseYAxis: true,
            UseDefaults: false
        );

    [Fact]
    public void AnnotatedHeatmapChartDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(
            CreateAnnotatedHeatmapChart(),
            ChartMarkupSection.Data,
            ExpectedData
        );
    }

    [Fact]
    public void AnnotatedHeatmapChartLayoutMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(
            CreateAnnotatedHeatmapChart(),
            ChartMarkupSection.Layout,
            ExpectedLayout
        );
    }
}
