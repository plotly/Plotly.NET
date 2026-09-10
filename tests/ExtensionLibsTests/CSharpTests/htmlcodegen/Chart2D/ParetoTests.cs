using Plotly.NET.CSharp;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.Chart2D;

public class ParetoTests
{
    private const string ExpectedKeysValuesData = """var data = [{"type":"bar","name":"pareto-kv","x":["b","a","c"],"y":[7.0,3.0,2.0],"orientation":"v","marker":{"pattern":{}}},{"type":"scatter","name":"Cumulative %","showlegend":true,"mode":"lines+markers","x":["b","a","c"],"y":[58.333333333333336,83.33333333333334,100.0],"marker":{"angle":45.0,"size":8,"symbol":"3"},"line":{},"yaxis":"y2"}];""";

    private const string ExpectedLabelsValuesData = """var data = [{"type":"bar","name":"pareto-lv","x":["b","a","c"],"y":[7.0,3.0,2.0],"orientation":"v","marker":{"pattern":{}}},{"type":"scatter","name":"Cumulative %","showlegend":true,"mode":"lines+markers","x":["b","a","c"],"y":[58.333333333333336,83.33333333333334,100.0],"marker":{"angle":45.0,"size":8,"symbol":"3"},"line":{},"yaxis":"y2"}];""";

    private static Plotly.NET.GenericChart CreateParetoChartFromKeysValues() =>
        Chart.Pareto<string>(
            keysValues: new[] { ("a", 3.0), ("b", 7.0), ("c", 2.0) },
            Name: "pareto-kv",
            Label: default,
            ShowGrid: default
        );

    private static Plotly.NET.GenericChart CreateParetoChartFromLabelsValues() =>
        Chart.Pareto<string>(
            labels: new[] { "a", "b", "c" },
            values: new[] { 3.0, 7.0, 2.0 },
            Name: "pareto-lv",
            Label: default,
            ShowGrid: default
        );

    [Fact]
    public void ParetoKeysValuesChartDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(
            CreateParetoChartFromKeysValues(),
            ChartMarkupSection.Data,
            ExpectedKeysValuesData
        );
    }

    [Fact]
    public void ParetoLabelsValuesChartDataMatchesExpectedMarkup()
    {
        TestUtils.ChartGeneratedSectionEquals(
            CreateParetoChartFromLabelsValues(),
            ChartMarkupSection.Data,
            ExpectedLabelsValuesData
        );
    }
}
