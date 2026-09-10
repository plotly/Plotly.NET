using Plotly.NET.CSharp;
using Plotly.NET.TraceObjects;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.Chart2D;

public class SplomTests
{
    private const string ExpectedData = """var data = [{"type":"splom","name":"splom","dimensions":[{"label":"A","values":[1.0,4.0,3.4,0.7],"axis":{}},{"label":"B","values":[3.0,1.5,1.7,2.3],"axis":{}},{"label":"C","values":[2.0,4.0,3.1,5.0],"axis":{}}],"marker":{},"diagonal":{}}];""";

    private static Plotly.NET.GenericChart CreateSplomChart() =>
        Chart.Splom<string>(
            dimensions: new Dimension[]
            {
                Dimension.initSplom<string, double>(
                    AxisMatches: default,
                    AxisType: default,
                    Label: "A",
                    Name: default,
                    TemplateItemName: default,
                    Values: new[] { 1.0, 4.0, 3.4, 0.7 },
                    ValuesEncoded: default,
                    Visible: default
                ),
                Dimension.initSplom<string, double>(
                    AxisMatches: default,
                    AxisType: default,
                    Label: "B",
                    Name: default,
                    TemplateItemName: default,
                    Values: new[] { 3.0, 1.5, 1.7, 2.3 },
                    ValuesEncoded: default,
                    Visible: default
                ),
                Dimension.initSplom<string, double>(
                    AxisMatches: default,
                    AxisType: default,
                    Label: "C",
                    Name: default,
                    TemplateItemName: default,
                    Values: new[] { 2.0, 4.0, 3.1, 5.0 },
                    ValuesEncoded: default,
                    Visible: default
                )
            },
            Name: "splom",
            UseDefaults: false
        );

    [Fact]
    public void SplomChartDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(
            CreateSplomChart(),
            ChartMarkupSection.Data,
            ExpectedData
        );
    }
}
