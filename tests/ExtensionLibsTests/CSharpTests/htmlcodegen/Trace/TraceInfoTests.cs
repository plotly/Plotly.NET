using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.Trace;

public class TraceInfoTests
{
    private const string ExpectedData = """var data = [{"type":"scatter","mode":"markers","x":[1.0,2.0],"y":[5.0,10.0],"marker":{},"line":{},"name":"Trace Name"}];""";

    private static Plotly.NET.GenericChart CreateChart() =>
        Chart.Point<double, double, string>(
            x: new double[] { 1, 2 },
            y: new double[] { 5, 10 },
            UseDefaults: false
        );

    [Fact]
    public void WithTraceInfoSetsTraceNameInGeneratedDataSection()
    {
        TestUtils.ChartGeneratedSectionEquals(
            CreateChart().WithTraceInfo(Name: "Trace Name"),
            ChartMarkupSection.Data,
            ExpectedData
        );
    }
}
