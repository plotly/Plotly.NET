using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.ChartSmith;

public class ScatterSmithTests
{
    private const string ExpectedData = """var data = [{"type":"scattersmith","mode":"lines+markers+text","imag":[0.5,1.0,2.0,3.0],"real":[0.5,1.0,2.0,3.0],"text":["Pretty","Cool","Plot","Huh?"],"textposition":"top center","marker":{},"line":{}}];""";

    private static Plotly.NET.GenericChart CreateChart() =>
        Chart.ScatterSmith<double, double, string>(
            real: new[] { 0.5, 1.0, 2.0, 3.0 },
            imag: new[] { 0.5, 1.0, 2.0, 3.0 },
            mode: Plotly.NET.StyleParam.Mode.Lines_Markers_Text,
            MultiText: new[] { "Pretty", "Cool", "Plot", "Huh?" },
            TextPosition: Plotly.NET.StyleParam.TextPosition.TopCenter,
            UseDefaults: false
        );

    [Fact]
    public void ScatterSmithChartDataMatchesExpectedMarkup() =>
        TestUtils.ChartGeneratedSectionEquals(CreateChart(), ChartMarkupSection.Data, ExpectedData);
}

public class PointSmithTests
{
    private const string ExpectedData = """var data = [{"type":"scattersmith","mode":"markers","imag":[0.5,1.0,2.0,3.0],"real":[0.5,1.0,2.0,3.0],"marker":{},"line":{}}];""";

    private static Plotly.NET.GenericChart CreateChart() =>
        Chart.PointSmith<double, double, string>(
            real: new[] { 0.5, 1.0, 2.0, 3.0 },
            imag: new[] { 0.5, 1.0, 2.0, 3.0 },
            UseDefaults: false
        );

    [Fact]
    public void PointSmithChartDataMatchesExpectedMarkup() =>
        TestUtils.ChartGeneratedSectionEquals(CreateChart(), ChartMarkupSection.Data, ExpectedData);
}

public class LineSmithTests
{
    private const string ExpectedData = """var data = [{"type":"scattersmith","mode":"lines","imag":[0.5,1.0,2.0,3.0],"real":[0.5,1.0,2.0,3.0],"marker":{},"line":{"color":"rgba(128, 0, 128, 1.0)","dash":"dashdot"}}];""";

    private static Plotly.NET.GenericChart CreateChart() =>
        Chart.LineSmith<double, double, string>(
            real: new[] { 0.5, 1.0, 2.0, 3.0 },
            imag: new[] { 0.5, 1.0, 2.0, 3.0 },
            LineDash: Plotly.NET.StyleParam.DrawingStyle.DashDot,
            LineColor: Plotly.NET.Color.fromKeyword(Plotly.NET.ColorKeyword.Purple),
            UseDefaults: false
        );

    [Fact]
    public void LineSmithChartDataMatchesExpectedMarkup() =>
        TestUtils.ChartGeneratedSectionEquals(CreateChart(), ChartMarkupSection.Data, ExpectedData);
}

public class BubbleSmithTests
{
    private const string ExpectedData = """var data = [{"type":"scattersmith","mode":"markers+text","imag":[0.5,1.0,2.0,3.0],"real":[0.5,1.0,2.0,3.0],"text":["one","two","three","four","five","six","seven"],"textposition":"top center","marker":{"size":[10,20,30,40]},"line":{}}];""";

    private static Plotly.NET.GenericChart CreateChart() =>
        Chart.BubbleSmith<double, double, string>(
            real: new[] { 0.5, 1.0, 2.0, 3.0 },
            imag: new[] { 0.5, 1.0, 2.0, 3.0 },
            sizes: new[] { 10, 20, 30, 40 },
            MultiText: new[] { "one", "two", "three", "four", "five", "six", "seven" },
            TextPosition: Plotly.NET.StyleParam.TextPosition.TopCenter,
            UseDefaults: false
        );

    [Fact]
    public void BubbleSmithChartDataMatchesExpectedMarkup() =>
        TestUtils.ChartGeneratedSectionEquals(CreateChart(), ChartMarkupSection.Data, ExpectedData);
}
