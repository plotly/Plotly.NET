using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.RootChart;

public class SingleStackTests
{
    private const string ExpectedData = """var data = [{"type":"scatter","mode":"markers","x":[1.0,2.0,3.0,4.0],"y":[2.0,1.5,5.0,1.5],"marker":{},"line":{},"xaxis":"x","yaxis":"y"},{"type":"scatter","mode":"lines","x":[1.0,2.0,3.0,4.0],"y":[2.0,1.5,5.0,1.5],"marker":{},"line":{},"xaxis":"x","yaxis":"y2"},{"type":"scatter","mode":"lines","x":[1.0,2.0,3.0,4.0],"y":[2.0,1.5,5.0,1.5],"marker":{},"line":{"shape":"spline"},"xaxis":"x","yaxis":"y3"}];""";

    private const string ExpectedLayout = """var layout = {"xaxis":{"title":{"text":"im the shared xAxis"}},"yaxis":{"title":{"text":"This title must"}},"xaxis2":{},"yaxis2":{"title":{"text":"be set on the"},"zeroline":false},"xaxis3":{},"yaxis3":{"title":{"text":"respective subplots"},"zeroline":false},"annotations":[],"grid":{"rows":3,"columns":1,"roworder":"top to bottom","pattern":"coupled","ygap":0.1,"xside":"bottom"}};""";

    private static Plotly.NET.GenericChart CreateSingleStackChart() =>
        Chart.SingleStack(
            new[]
            {
                Chart.Point<double, double, string>(
                    x: new[] { 1.0, 2.0, 3.0, 4.0 },
                    y: new[] { 2.0, 1.5, 5.0, 1.5 },
                    UseDefaults: false
                )
                    .WithYAxisStyle<int, int, int>(TitleText: "This title must"),
                Chart.Line<double, double, string>(
                    x: new[] { 1.0, 2.0, 3.0, 4.0 },
                    y: new[] { 2.0, 1.5, 5.0, 1.5 },
                    UseDefaults: false
                )
                    .WithYAxisStyle<int, int, int>(TitleText: "be set on the", ZeroLine: false),
                Chart.Spline<double, double, string>(
                    x: new[] { 1.0, 2.0, 3.0, 4.0 },
                    y: new[] { 2.0, 1.5, 5.0, 1.5 },
                    UseDefaults: false
                )
                    .WithYAxisStyle<int, int, int>(TitleText: "respective subplots", ZeroLine: false)
            },
            Pattern: Plotly.NET.StyleParam.LayoutGridPattern.Coupled,
            XSide: Plotly.NET.StyleParam.LayoutGridXSide.Bottom,
            YGap: 0.1
        )
            .WithXAxisStyle<int, int, int>(TitleText: "im the shared xAxis");

    [Fact]
    public void SingleStackDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(
            CreateSingleStackChart(),
            ChartMarkupSection.Data,
            ExpectedData
        );
    }

    [Fact]
    public void SingleStackLayoutMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(
            CreateSingleStackChart(),
            ChartMarkupSection.Layout,
            ExpectedLayout
        );
    }
}
