using System;
using Plotly.NET;
using Plotly.NET.TraceObjects;
using Xunit;
using Chart = Plotly.NET.CSharp.Chart;

namespace CSharp.Tests.HtmlCodegen.ChartDomain;

public class ParallelStylingTests
{
    [Theory]
    [InlineData("ParallelCoord")]
    [InlineData("ParallelCoordEncoded")]
    [InlineData("ParallelCategories")]
    [InlineData("ParallelCategoriesEncoded")]
    public void ConstructorsPreserveTickFontAndSupportedLineShape(string chartName)
    {
        var (chart, expectedData) = CreateCase(chartName);

        TestUtils.ChartGeneratedSectionEquals(chart, ChartMarkupSection.Data, expectedData);
    }

    private static Dimension Dimension(string label, int[] values) =>
        Plotly.NET.TraceObjects.Dimension.initParallel<string, string, int, int>(
            ConstraintRange: default,
            Label: label,
            MultiSelect: default,
            Name: default,
            Range: default,
            TemplateItemName: default,
            TickFormat: default,
            TickText: default,
            Tickvals: default,
            Values: values,
            ValuesEncoded: default,
            Visible: default
        );

    // Baselines generated with tools/chart-baseline-generation/generate-chart-markup.fsx.
    private static (GenericChart Chart, string Data) CreateCase(string chartName)
    {
        var font = Font.init(
            Family: StyleParam.FontFamily.Arial,
            Size: 14.0,
            Color: Color.fromString("purple")
        );
        var dimensions = new[] { Dimension("A", new[] { 1, 2 }), Dimension("B", new[] { 3, 4 }) };
        var encoded = new[]
        {
            ("A", EncodedTypedArray.ofInt32Array(new[] { 1, 2 }, shape: default)),
            ("B", EncodedTypedArray.ofInt32Array(new[] { 3, 4 }, shape: default))
        };

        return chartName switch
        {
            "ParallelCoord" => (
                Chart.ParallelCoord(dimensions: dimensions, TickFont: font, UseDefaults: false),
                """var data = [{"type":"parcoords","dimensions":[{"label":"A","values":[1,2],"axis":{}},{"label":"B","values":[3,4],"axis":{}}],"line":{},"tickfont":{"family":"Arial","size":14.0,"color":"purple"}}];"""
            ),
            "ParallelCoordEncoded" => (
                Chart.ParallelCoord(keyValuesEncoded: encoded, TickFont: font, UseDefaults: false),
                """var data = [{"type":"parcoords","dimensions":[{"label":"A","values":{"bdata":"AQAAAAIAAAA=","dtype":"i4"},"axis":{}},{"label":"B","values":{"bdata":"AwAAAAQAAAA=","dtype":"i4"},"axis":{}}],"line":{},"tickfont":{"family":"Arial","size":14.0,"color":"purple"}}];"""
            ),
            "ParallelCategories" => (
                Chart.ParallelCategories(
                    dimensions: dimensions, LineShape: StyleParam.Shape.HSpline,
                    TickFont: font, UseDefaults: false),
                """var data = [{"type":"parcats","dimensions":[{"label":"A","values":[1,2],"axis":{}},{"label":"B","values":[3,4],"axis":{}}],"line":{"shape":"hspline"},"tickfont":{"family":"Arial","size":14.0,"color":"purple"}}];"""
            ),
            "ParallelCategoriesEncoded" => (
                Chart.ParallelCategories(
                    keyValuesEncoded: encoded, LineShape: StyleParam.Shape.HSpline,
                    TickFont: font, UseDefaults: false),
                """var data = [{"type":"parcats","dimensions":[{"label":"A","values":{"bdata":"AQAAAAIAAAA=","dtype":"i4"},"axis":{}},{"label":"B","values":{"bdata":"AwAAAAQAAAA=","dtype":"i4"},"axis":{}}],"line":{"shape":"hspline"},"tickfont":{"family":"Arial","size":14.0,"color":"purple"}}];"""
            ),
            _ => throw new ArgumentOutOfRangeException(nameof(chartName), chartName, null)
        };
    }
}
