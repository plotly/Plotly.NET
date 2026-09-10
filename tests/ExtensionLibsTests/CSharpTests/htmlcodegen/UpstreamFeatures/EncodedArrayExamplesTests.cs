using System.Collections.Generic;
using Microsoft.FSharp.Core;
using Plotly.NET;
using Plotly.NET.TraceObjects;
using Xunit;
using Chart = Plotly.NET.CSharp.Chart;

namespace CSharp.Tests.HtmlCodegen.UpstreamFeatures;

public class EncodedArrayExamplesTests
{
    [Fact]
    public void DocumentedScatterExamplePreservesOneDimensionalArrays()
    {
        // Keep this construction in sync with docs/general/encoded-arrays.fsx.
        var x = EncodedTypedArray.ofInt32Array(new[] { 0, 1, 2 }, shape: default);
        var y = EncodedTypedArray.ofFloat32Array(new[] { 1.5f, 4.5f, 2.5f }, shape: default);
        var scatter = Chart.Scatter<string>(
            xEncoded: x, yEncoded: y, mode: StyleParam.Mode.Markers,
            Name: "encoded scatter", UseDefaults: false);

        TestUtils.ChartGeneratedSectionEquals(scatter, ChartMarkupSection.Data,
            """var data = [{"type":"scatter","name":"encoded scatter","mode":"markers","x":{"bdata":"AAAAAAEAAAACAAAA","dtype":"i4"},"y":{"bdata":"AADAPwAAkEAAACBA","dtype":"f4"},"marker":{},"line":{}}];""");
    }

    [Fact]
    public void DocumentedHeatmapExamplePreservesRowsColumnsAndAxes()
    {
        // Keep this construction in sync with docs/general/encoded-arrays.fsx.
        var z = EncodedTypedArray.ofFloat32Array(
            new[] { 1.0f, 2.0f, 3.0f, 4.0f, 5.0f, 6.0f },
            shape: new FSharpOption<IEnumerable<int>>(new[] { 2, 3 }));
        var heatmap = Chart.Heatmap<string>(
            zEncoded: z,
            xEncoded: EncodedTypedArray.ofInt32Array(new[] { 10, 20, 30 }, shape: default),
            yEncoded: EncodedTypedArray.ofInt32Array(new[] { 100, 200 }, shape: default),
            ReverseYAxis: true, ShowScale: false, UseDefaults: false);

        TestUtils.ChartGeneratedSectionEquals(heatmap, ChartMarkupSection.Data,
            """var data = [{"type":"heatmap","x":{"bdata":"CgAAABQAAAAeAAAA","dtype":"i4"},"y":{"bdata":"ZAAAAMgAAAA=","dtype":"i4"},"z":{"bdata":"AACAPwAAAEAAAEBAAACAQAAAoEAAAMBA","dtype":"f4","shape":"2,3"},"showscale":false}];""");
        TestUtils.ChartGeneratedSectionEquals(heatmap, ChartMarkupSection.Layout,
            """var layout = {"yaxis":{"autorange":"reversed"}};""");
    }

    [Fact]
    public void ExistingSplomWrapperAcceptsEncodedDimensionsAndPreservesOptions()
    {
        var chart = Chart.Splom<string>(
            dimensions: new[]
            {
                Dimension.initSplom<string, int>(
                    AxisMatches: true,
                    AxisType: default,
                    Label: "A",
                    Name: default,
                    TemplateItemName: default,
                    Values: new[] { 99, 99, 99 },
                    ValuesEncoded: EncodedTypedArray.ofInt32Array(new[] { 0, 1, 2 }, shape: default),
                    Visible: default),
                Dimension.initSplom<string, float>(
                    AxisMatches: default,
                    AxisType: default,
                    Label: "B",
                    Name: default,
                    TemplateItemName: default,
                    Values: default,
                    ValuesEncoded: EncodedTypedArray.ofFloat32Array(new[] { 1.5f, 4.5f, 2.5f }, shape: default),
                    Visible: default)
            },
            Name: "encoded splom", ShowUpperHalf: false, ShowDiagonal: true,
            MarkerColor: Color.fromString("blue"), UseDefaults: false);

        TestUtils.ChartGeneratedSectionEquals(chart, ChartMarkupSection.Data,
            """var data = [{"type":"splom","name":"encoded splom","dimensions":[{"label":"A","values":{"bdata":"AAAAAAEAAAACAAAA","dtype":"i4"},"axis":{"matches":true}},{"label":"B","values":{"bdata":"AADAPwAAkEAAACBA","dtype":"f4"},"axis":{}}],"marker":{"color":"blue"},"diagonal":{"visible":true},"showupperhalf":false}];""");
    }
}
