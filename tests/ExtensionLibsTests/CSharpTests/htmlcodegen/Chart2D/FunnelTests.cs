using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.Chart2D;

public class FunnelTests
{
    private const string ExpectedData = """var data = [{"type":"funnel","name":"funnel","x":[1200.0,909.4,600.6],"y":["Visitors","Leads","Qualified"],"marker":{},"connector":{}}];""";

    private static Plotly.NET.GenericChart CreateFunnelChart() =>
        Chart.Funnel<double, string, string>(
            x: new[] { 1200.0, 909.4, 600.6 },
            y: new[] { "Visitors", "Leads", "Qualified" },
            Name: "funnel",
            UseDefaults: false
        );

    [Fact]
    public void FunnelChartDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(
            CreateFunnelChart(),
            ChartMarkupSection.Data,
            ExpectedData
        );
    }
}
