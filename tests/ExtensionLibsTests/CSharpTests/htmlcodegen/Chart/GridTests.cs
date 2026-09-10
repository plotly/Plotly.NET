using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.RootChart;

public class GridTests
{
    private const string ExpectedData = """var data = [{"type":"scatter","name":"1,1","mode":"markers","x":[1.0,2.0,3.0,4.0],"y":[2.0,1.5,5.0,1.5],"marker":{},"line":{},"xaxis":"x","yaxis":"y"},{"type":"scatter","name":"1,2","mode":"lines","x":[1.0,2.0,3.0,4.0],"y":[2.0,1.5,5.0,1.5],"marker":{},"line":{},"xaxis":"x2","yaxis":"y2"},{"type":"scatter","name":"2,1","mode":"lines","x":[1.0,2.0,3.0,4.0],"y":[2.0,1.5,5.0,1.5],"marker":{},"line":{"shape":"spline"},"xaxis":"x3","yaxis":"y3"},{"type":"scatter","name":"2,2","mode":"markers","x":[1.0,2.0,3.0,4.0],"y":[2.0,1.5,5.0,1.5],"marker":{},"line":{},"xaxis":"x4","yaxis":"y4"}];""";

    private const string ExpectedLayout = """var layout = {"yaxis":{"title":{"text":"y1"}},"xaxis":{"title":{"text":"x1"}},"yaxis2":{"title":{"text":"y2"}},"xaxis2":{"title":{"text":"x2"}},"yaxis3":{"title":{"text":"y3"}},"xaxis3":{"title":{"text":"x3"}},"yaxis4":{"title":{"text":"y4"}},"xaxis4":{"title":{"text":"x4"}},"annotations":[],"grid":{"rows":2,"columns":2,"roworder":"top to bottom","pattern":"independent"}};""";

    private static Plotly.NET.GenericChart CreateGridChart() =>
        Chart.Grid(
            new[]
            {
                Chart.Point<double, double, string>(
                    x: new[] { 1.0, 2.0, 3.0, 4.0 },
                    y: new[] { 2.0, 1.5, 5.0, 1.5 },
                    Name: "1,1",
                    UseDefaults: false
                )
                    .WithXAxisStyle<int, int, int>(TitleText: "x1")
                    .WithYAxisStyle<int, int, int>(TitleText: "y1"),
                Chart.Line<double, double, string>(
                    x: new[] { 1.0, 2.0, 3.0, 4.0 },
                    y: new[] { 2.0, 1.5, 5.0, 1.5 },
                    Name: "1,2",
                    UseDefaults: false
                )
                    .WithXAxisStyle<int, int, int>(TitleText: "x2")
                    .WithYAxisStyle<int, int, int>(TitleText: "y2"),
                Chart.Spline<double, double, string>(
                    x: new[] { 1.0, 2.0, 3.0, 4.0 },
                    y: new[] { 2.0, 1.5, 5.0, 1.5 },
                    Name: "2,1",
                    UseDefaults: false
                )
                    .WithXAxisStyle<int, int, int>(TitleText: "x3")
                    .WithYAxisStyle<int, int, int>(TitleText: "y3"),
                Chart.Point<double, double, string>(
                    x: new[] { 1.0, 2.0, 3.0, 4.0 },
                    y: new[] { 2.0, 1.5, 5.0, 1.5 },
                    Name: "2,2",
                    UseDefaults: false
                )
                    .WithXAxisStyle<int, int, int>(TitleText: "x4")
                    .WithYAxisStyle<int, int, int>(TitleText: "y4")
            },
            nRows: 2,
            nCols: 2
        );

    [Fact]
    public void GridDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(
            CreateGridChart(),
            ChartMarkupSection.Data,
            ExpectedData
        );
    }

    [Fact]
    public void GridLayoutMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(
            CreateGridChart(),
            ChartMarkupSection.Layout,
            ExpectedLayout
        );
    }
}
