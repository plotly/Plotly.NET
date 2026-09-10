using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.Chart2D;

public class StackedFunnelTests
{
    private const string ExpectedData = """var data = [{"type":"funnel","name":"old","x":[1200.0,909.4,600.6],"y":["Visitors","Leads","Qualified"],"marker":{},"connector":{}},{"type":"funnel","name":"new","x":[800.0,600.0,400.0],"y":["Visitors","Leads","Qualified"],"marker":{},"connector":{}}];""";

    private const string ExpectedLayout = """var layout = {"funnelmode":"stack"};""";

    private static Plotly.NET.GenericChart CreateStackedFunnelChart() =>
        Chart.Combine(
            new[]
            {
                Chart.StackedFunnel<double, string, string>(
                    x: new[] { 1200.0, 909.4, 600.6 },
                    y: new[] { "Visitors", "Leads", "Qualified" },
                    Name: "old",
                    UseDefaults: false
                ),
                Chart.StackedFunnel<double, string, string>(
                    x: new[] { 800.0, 600.0, 400.0 },
                    y: new[] { "Visitors", "Leads", "Qualified" },
                    Name: "new",
                    UseDefaults: false
                )
            }
        );

    [Fact]
    public void StackedFunnelChartDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(
            CreateStackedFunnelChart(),
            ChartMarkupSection.Data,
            ExpectedData
        );
    }

    [Fact]
    public void StackedFunnelChartLayoutMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(
            CreateStackedFunnelChart(),
            ChartMarkupSection.Layout,
            ExpectedLayout
        );
    }
}
