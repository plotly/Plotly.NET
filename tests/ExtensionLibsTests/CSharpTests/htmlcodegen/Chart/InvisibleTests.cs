using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.RootChart;

public class InvisibleTests
{
    private const string ExpectedData = """var data = [{"type":null}];""";

    private const string ExpectedLayout = """var layout = {"xaxis":{"showticklabels":false,"showline":false,"showgrid":false,"zeroline":false},"yaxis":{"showticklabels":false,"showline":false,"showgrid":false,"zeroline":false}};""";

    [Fact]
    public void InvisibleDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(
            Chart.Invisible(),
            ChartMarkupSection.Data,
            ExpectedData
        );
    }

    [Fact]
    public void InvisibleLayoutMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(
            Chart.Invisible(),
            ChartMarkupSection.Layout,
            ExpectedLayout
        );
    }
}
