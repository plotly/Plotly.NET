using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.ChartCarpet;

public class CarpetTests
{
    private const string ExpectedData = """var data = [{"type":"carpet","y":[2.0,3.0],"a":[0.0,1.0],"b":[1.0,2.0],"carpet":"carpet"}];""";

    private static Plotly.NET.GenericChart CreateChart() =>
        Chart.Carpet<double, double, double, double, double, double>(
            carpetId: "carpet",
            A: new[] { 0.0, 1.0 },
            B: new[] { 1.0, 2.0 },
            Y: new[] { 2.0, 3.0 },
            UseDefaults: false
        );

    [Fact]
    public void CarpetChartDataMatchesExpectedMarkup() =>
        TestUtils.ChartGeneratedSectionEquals(CreateChart(), ChartMarkupSection.Data, ExpectedData);
}

public class ScatterCarpetTests
{
    private const string ExpectedData = """var data = [{"type":"carpet","y":[2.0,3.0],"a":[0.0,1.0],"b":[1.0,2.0],"carpet":"carpet-scatter"},{"type":"scattercarpet","name":"scattercarpet","mode":"lines+markers","a":[0.0,1.0],"b":[1.0,2.0],"marker":{},"line":{},"carpet":"carpet-scatter"}];""";

    private static Plotly.NET.GenericChart CreateChart() =>
        Chart.Combine(
            new[]
            {
                Chart.Carpet<double, double, double, double, double, double>(
                    carpetId: "carpet-scatter",
                    A: new[] { 0.0, 1.0 },
                    B: new[] { 1.0, 2.0 },
                    Y: new[] { 2.0, 3.0 },
                    UseDefaults: false
                ),
                Chart.ScatterCarpet<double, double, string>(
                    a: new[] { 0.0, 1.0 },
                    b: new[] { 1.0, 2.0 },
                    mode: Plotly.NET.StyleParam.Mode.Lines_Markers,
                    carpetAnchorId: "carpet-scatter",
                    Name: "scattercarpet",
                    UseDefaults: false
                )
            }
        );

    [Fact]
    public void ScatterCarpetChartDataMatchesExpectedMarkup() =>
        TestUtils.ChartGeneratedSectionEquals(CreateChart(), ChartMarkupSection.Data, ExpectedData);
}

public class PointCarpetTests
{
    private const string ExpectedData = """var data = [{"type":"carpet","y":[2.0,3.0],"a":[0.0,1.0],"b":[1.0,2.0],"carpet":"carpet-point"},{"type":"scattercarpet","name":"pointcarpet","mode":"markers","a":[0.0,1.0],"b":[1.0,2.0],"marker":{},"line":{},"carpet":"carpet-point"}];""";

    private static Plotly.NET.GenericChart CreateChart() =>
        Chart.Combine(
            new[]
            {
                Chart.Carpet<double, double, double, double, double, double>(
                    carpetId: "carpet-point",
                    A: new[] { 0.0, 1.0 },
                    B: new[] { 1.0, 2.0 },
                    Y: new[] { 2.0, 3.0 },
                    UseDefaults: false
                ),
                Chart.PointCarpet<double, double, string>(
                    a: new[] { 0.0, 1.0 },
                    b: new[] { 1.0, 2.0 },
                    carpetAnchorId: "carpet-point",
                    Name: "pointcarpet",
                    UseDefaults: false
                )
            }
        );

    [Fact]
    public void PointCarpetChartDataMatchesExpectedMarkup() =>
        TestUtils.ChartGeneratedSectionEquals(CreateChart(), ChartMarkupSection.Data, ExpectedData);
}

public class LineCarpetTests
{
    private const string ExpectedData = """var data = [{"type":"carpet","y":[2.0,3.0],"a":[0.0,1.0],"b":[1.0,2.0],"carpet":"carpet-line"},{"type":"scattercarpet","name":"linecarpet","mode":"lines","a":[0.0,1.0],"b":[1.0,2.0],"marker":{},"line":{},"carpet":"carpet-line"}];""";

    private static Plotly.NET.GenericChart CreateChart() =>
        Chart.Combine(
            new[]
            {
                Chart.Carpet<double, double, double, double, double, double>(
                    carpetId: "carpet-line",
                    A: new[] { 0.0, 1.0 },
                    B: new[] { 1.0, 2.0 },
                    Y: new[] { 2.0, 3.0 },
                    UseDefaults: false
                ),
                Chart.LineCarpet<double, double, string>(
                    a: new[] { 0.0, 1.0 },
                    b: new[] { 1.0, 2.0 },
                    carpetAnchorId: "carpet-line",
                    Name: "linecarpet",
                    UseDefaults: false
                )
            }
        );

    [Fact]
    public void LineCarpetChartDataMatchesExpectedMarkup() =>
        TestUtils.ChartGeneratedSectionEquals(CreateChart(), ChartMarkupSection.Data, ExpectedData);
}

public class SplineCarpetTests
{
    private const string ExpectedData = """var data = [{"type":"carpet","y":[2.0,3.0],"a":[0.0,1.0],"b":[1.0,2.0],"carpet":"carpet-spline"},{"type":"scattercarpet","name":"splinecarpet","mode":"lines","a":[0.0,1.0],"b":[1.0,2.0],"marker":{},"line":{"shape":"spline"},"carpet":"carpet-spline"}];""";

    private static Plotly.NET.GenericChart CreateChart() =>
        Chart.Combine(
            new[]
            {
                Chart.Carpet<double, double, double, double, double, double>(
                    carpetId: "carpet-spline",
                    A: new[] { 0.0, 1.0 },
                    B: new[] { 1.0, 2.0 },
                    Y: new[] { 2.0, 3.0 },
                    UseDefaults: false
                ),
                Chart.SplineCarpet<double, double, string>(
                    a: new[] { 0.0, 1.0 },
                    b: new[] { 1.0, 2.0 },
                    carpetAnchorId: "carpet-spline",
                    Name: "splinecarpet",
                    UseDefaults: false
                )
            }
        );

    [Fact]
    public void SplineCarpetChartDataMatchesExpectedMarkup() =>
        TestUtils.ChartGeneratedSectionEquals(CreateChart(), ChartMarkupSection.Data, ExpectedData);
}

public class BubbleCarpetTests
{
    private const string ExpectedData = """var data = [{"type":"carpet","y":[2.0,3.0],"a":[0.0,1.0],"b":[1.0,2.0],"carpet":"carpet-bubble"},{"type":"scattercarpet","name":"bubblecarpet","mode":"markers","a":[0.0,1.0],"b":[1.0,2.0],"marker":{"size":[5,10]},"line":{},"carpet":"carpet-bubble"}];""";

    private static Plotly.NET.GenericChart CreateChart() =>
        Chart.Combine(
            new[]
            {
                Chart.Carpet<double, double, double, double, double, double>(
                    carpetId: "carpet-bubble",
                    A: new[] { 0.0, 1.0 },
                    B: new[] { 1.0, 2.0 },
                    Y: new[] { 2.0, 3.0 },
                    UseDefaults: false
                ),
                Chart.BubbleCarpet<double, double, string>(
                    a: new[] { 0.0, 1.0 },
                    b: new[] { 1.0, 2.0 },
                    sizes: new[] { 5, 10 },
                    carpetAnchorId: "carpet-bubble",
                    Name: "bubblecarpet",
                    UseDefaults: false
                )
            }
        );

    [Fact]
    public void BubbleCarpetChartDataMatchesExpectedMarkup() =>
        TestUtils.ChartGeneratedSectionEquals(CreateChart(), ChartMarkupSection.Data, ExpectedData);
}

public class ContourCarpetTests
{
    private const string ExpectedData = """var data = [{"type":"carpet","y":[2.0,3.0],"a":[0.0,1.0],"b":[1.0,2.0],"carpet":"carpet-contour"},{"type":"contourcarpet","name":"contourcarpet","z":[1.0,2.0],"a":[0,1],"b":[1,2],"line":{},"carpet":"carpet-contour","contours":{}}];""";

    private static Plotly.NET.GenericChart CreateChart() =>
        Chart.Combine(
            new[]
            {
                Chart.Carpet<double, double, double, double, double, double>(
                    carpetId: "carpet-contour",
                    A: new[] { 0.0, 1.0 },
                    B: new[] { 1.0, 2.0 },
                    Y: new[] { 2.0, 3.0 },
                    UseDefaults: false
                ),
                Chart.ContourCarpet<double, int, int, string>(
                    z: new[] { 1.0, 2.0 },
                    carpetAnchorId: "carpet-contour",
                    A: new[] { 0, 1 },
                    B: new[] { 1, 2 },
                    Name: "contourcarpet",
                    UseDefaults: false
                )
            }
        );

    [Fact]
    public void ContourCarpetChartDataMatchesExpectedMarkup() =>
        TestUtils.ChartGeneratedSectionEquals(CreateChart(), ChartMarkupSection.Data, ExpectedData);
}
