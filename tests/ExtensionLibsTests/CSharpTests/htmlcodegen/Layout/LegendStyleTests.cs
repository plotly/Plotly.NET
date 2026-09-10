using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.Layout;

public class LegendStyleTests
{
    private const string ExpectedLegendLayout = """var layout = {"legend":{"entrywidth":0.0,"entrywidthmode":"pixels","orientation":"h","x":0.5,"xanchor":"center"}};""";

    private static Plotly.NET.GenericChart CreateChart() =>
        Chart.Point<double, double, string>(
            x: new double[] { 1, 2 },
            y: new double[] { 5, 10 },
            UseDefaults: false
        );

    [Fact]
    public void WithLegendStyleMatchesExpectedLayoutMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(
            CreateChart().WithLegendStyle(
                X: 0.5,
                Orientation: Plotly.NET.StyleParam.Orientation.Horizontal,
                XAnchor: Plotly.NET.StyleParam.XAnchorPosition.Center,
                EntryWidth: 0,
                EntryWidthMode: Plotly.NET.StyleParam.EntryWidthMode.Pixels
            ),
            ChartMarkupSection.Layout,
            ExpectedLegendLayout
        );
    }
}
