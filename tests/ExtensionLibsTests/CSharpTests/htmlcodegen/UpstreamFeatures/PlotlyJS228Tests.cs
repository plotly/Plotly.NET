using System;
using System.Collections.Generic;
using Microsoft.FSharp.Core;
using Plotly.NET;
using Plotly.NET.TraceObjects;
using Xunit;
using Chart = Plotly.NET.CSharp.Chart;

namespace CSharp.Tests.HtmlCodegen.UpstreamFeatures;

public class PlotlyJS228Tests
{
    [Theory]
    [InlineData("Scatter")]
    [InlineData("Bar")]
    [InlineData("Column")]
    [InlineData("StackedBar")]
    [InlineData("StackedColumn")]
    [InlineData("BarMinimal")]
    [InlineData("ColumnMinimal")]
    [InlineData("StackedBarMinimal")]
    [InlineData("StackedColumnMinimal")]
    [InlineData("Heatmap")]
    [InlineData("HeatmapMinimal")]
    [InlineData("Histogram2D")]
    [InlineData("Histogram2DMinimal")]
    [InlineData("Scatter3D")]
    [InlineData("ParallelCoord")]
    [InlineData("ParallelCategories")]
    [InlineData("Sankey")]
    [InlineData("SankeyEncoded")]
    public void ConstructorsPreserveEncodedPayloadsAndForwardedOptions(string chartName)
    {
        var (chart, expectedData, expectedLayout) = CreateCase(chartName);

        TestUtils.ChartGeneratedSectionEquals(chart, ChartMarkupSection.Data, expectedData);
        TestUtils.ChartGeneratedSectionEquals(chart, ChartMarkupSection.Layout, expectedLayout);
    }

    private static EncodedTypedArray X() =>
        EncodedTypedArray.ofInt32Array(new[] { 0, 2 }, shape: default);

    private static EncodedTypedArray Y() =>
        EncodedTypedArray.ofFloat32Array(new[] { 1.5f, 4.5f }, shape: default);

    private static EncodedTypedArray Z() =>
        EncodedTypedArray.ofInt16Array(new short[] { 5, 7 }, shape: default);

    private static EncodedTypedArray Widths() =>
        EncodedTypedArray.ofFloat32Array(new[] { 0.25f, 0.5f }, shape: default);

    private static EncodedTypedArray Matrix() =>
        EncodedTypedArray.ofFloat32Array(
            new[] { 1.0f, 2.0f, 3.0f, 4.0f, 5.0f, 6.0f },
            shape: new FSharpOption<IEnumerable<int>>(new[] { 2, 3 })
        );

    // Baselines generated through tools/chart-baseline-generation/generate-chart-markup.fsx
    // using these C# constructors and GenericChart.toChartHTML.
    private static (GenericChart Chart, string Data, string Layout) CreateCase(string chartName) =>
        chartName switch
        {
            "Scatter" => (
                Chart.Scatter<string>(
                    xEncoded: X(), yEncoded: Y(), mode: StyleParam.Mode.Lines_Markers,
                    Name: "encoded scatter", ShowLegend: false,
                    MarkerColor: Color.fromString("red"), LineWidth: 2.0,
                    UseWebGL: true, UseDefaults: false),
                """var data = [{"type":"scattergl","name":"encoded scatter","showlegend":false,"mode":"lines+markers","x":{"bdata":"AAAAAAIAAAA=","dtype":"i4"},"y":{"bdata":"AADAPwAAkEA=","dtype":"f4"},"marker":{"color":"red"},"line":{"width":2.0}}];""",
                """var layout = {};"""
            ),

            "Bar" => (
                Chart.Bar<string, int, double>(
                    valuesEncoded: Y(), KeysEncoded: X(), Base: 0,
                    MultiWidthEncoded: Widths(), MarkerColor: Color.fromString("red"),
                    UseDefaults: false),
                """var data = [{"type":"bar","x":{"bdata":"AADAPwAAkEA=","dtype":"f4"},"y":{"bdata":"AAAAAAIAAAA=","dtype":"i4"},"base":0,"width":{"bdata":"AACAPgAAAD8=","dtype":"f4"},"orientation":"h","marker":{"color":"red","pattern":{}}}];""",
                """var layout = {};"""
            ),

            "Column" => (
                Chart.Column<string, int, double>(
                    valuesEncoded: Y(), KeysEncoded: X(), Base: 0,
                    MultiWidthEncoded: Widths(), MarkerColor: Color.fromString("red"),
                    UseDefaults: false),
                """var data = [{"type":"bar","x":{"bdata":"AAAAAAIAAAA=","dtype":"i4"},"y":{"bdata":"AADAPwAAkEA=","dtype":"f4"},"base":0,"width":{"bdata":"AACAPgAAAD8=","dtype":"f4"},"orientation":"v","marker":{"color":"red","pattern":{}}}];""",
                """var layout = {};"""
            ),

            "StackedBar" => (
                Chart.StackedBar<string, int, double>(
                    valuesEncoded: Y(), KeysEncoded: X(),
                    MultiWidthEncoded: Widths(), MarkerColor: Color.fromString("red"),
                    UseDefaults: false),
                """var data = [{"type":"bar","x":{"bdata":"AADAPwAAkEA=","dtype":"f4"},"y":{"bdata":"AAAAAAIAAAA=","dtype":"i4"},"width":{"bdata":"AACAPgAAAD8=","dtype":"f4"},"orientation":"h","marker":{"color":"red","pattern":{}}}];""",
                """var layout = {"barmode":"stack"};"""
            ),

            "StackedColumn" => (
                Chart.StackedColumn<string, int, double>(
                    valuesEncoded: Y(), KeysEncoded: X(),
                    MultiWidthEncoded: Widths(), MarkerColor: Color.fromString("red"),
                    UseDefaults: false),
                """var data = [{"type":"bar","x":{"bdata":"AAAAAAIAAAA=","dtype":"i4"},"y":{"bdata":"AADAPwAAkEA=","dtype":"f4"},"width":{"bdata":"AACAPgAAAD8=","dtype":"f4"},"orientation":"v","marker":{"color":"red","pattern":{}}}];""",
                """var layout = {"barmode":"stack"};"""
            ),

            "BarMinimal" => (
                Chart.Bar<string, int, double>(valuesEncoded: Y(), UseDefaults: false),
                """var data = [{"type":"bar","x":{"bdata":"AADAPwAAkEA=","dtype":"f4"},"orientation":"h","marker":{"pattern":{}}}];""",
                """var layout = {};"""
            ),

            "ColumnMinimal" => (
                Chart.Column<string, int, double>(valuesEncoded: Y(), UseDefaults: false),
                """var data = [{"type":"bar","y":{"bdata":"AADAPwAAkEA=","dtype":"f4"},"orientation":"v","marker":{"pattern":{}}}];""",
                """var layout = {};"""
            ),

            "StackedBarMinimal" => (
                Chart.StackedBar<string, int, double>(valuesEncoded: Y(), UseDefaults: false),
                """var data = [{"type":"bar","x":{"bdata":"AADAPwAAkEA=","dtype":"f4"},"orientation":"h","marker":{"pattern":{}}}];""",
                """var layout = {"barmode":"stack"};"""
            ),

            "StackedColumnMinimal" => (
                Chart.StackedColumn<string, int, double>(valuesEncoded: Y(), UseDefaults: false),
                """var data = [{"type":"bar","y":{"bdata":"AADAPwAAkEA=","dtype":"f4"},"orientation":"v","marker":{"pattern":{}}}];""",
                """var layout = {"barmode":"stack"};"""
            ),

            "Heatmap" => (
                Chart.Heatmap<string>(
                    zEncoded: Matrix(),
                    xEncoded: EncodedTypedArray.ofInt32Array(new[] { 0, 1, 2 }, shape: default),
                    yEncoded: EncodedTypedArray.ofInt32Array(new[] { 10, 20 }, shape: default),
                    XGap: 2, ShowScale: false, ReverseYAxis: true, UseDefaults: false),
                """var data = [{"type":"heatmap","x":{"bdata":"AAAAAAEAAAACAAAA","dtype":"i4"},"xgap":2,"y":{"bdata":"CgAAABQAAAA=","dtype":"i4"},"z":{"bdata":"AACAPwAAAEAAAEBAAACAQAAAoEAAAMBA","dtype":"f4","shape":"2,3"},"showscale":false}];""",
                """var layout = {"yaxis":{"autorange":"reversed"}};"""
            ),

            "HeatmapMinimal" => (
                Chart.Heatmap<string>(zEncoded: Matrix(), UseDefaults: false),
                """var data = [{"type":"heatmap","z":{"bdata":"AACAPwAAAEAAAEBAAACAQAAAoEAAAMBA","dtype":"f4","shape":"2,3"}}];""",
                """var layout = {};"""
            ),

            "Histogram2D" => (
                Chart.Histogram2D(
                    xEncoded: X(), yEncoded: Y(), zEncoded: Z(),
                    HistFunc: StyleParam.HistFunc.Sum, NBinsX: 3, ShowScale: false,
                    UseDefaults: false),
                """var data = [{"type":"histogram2d","x":{"bdata":"AAAAAAIAAAA=","dtype":"i4"},"y":{"bdata":"AADAPwAAkEA=","dtype":"f4"},"z":{"bdata":"BQAHAA==","dtype":"i2"},"histfunc":"sum","nbinsx":3,"showscale":false}];""",
                """var layout = {};"""
            ),

            "Histogram2DMinimal" => (
                Chart.Histogram2D(xEncoded: X(), yEncoded: Y(), UseDefaults: false),
                """var data = [{"type":"histogram2d","x":{"bdata":"AAAAAAIAAAA=","dtype":"i4"},"y":{"bdata":"AADAPwAAkEA=","dtype":"f4"}}];""",
                """var layout = {};"""
            ),

            "Scatter3D" => (
                Chart.Scatter3D<string>(
                    xEncoded: X(), yEncoded: Y(), zEncoded: Z(), mode: StyleParam.Mode.Markers,
                    MarkerColor: Color.fromString("blue"),
                    CameraProjectionType: StyleParam.CameraProjectionType.Orthographic,
                    UseDefaults: false),
                """var data = [{"type":"scatter3d","mode":"markers","x":{"bdata":"AAAAAAIAAAA=","dtype":"i4"},"y":{"bdata":"AADAPwAAkEA=","dtype":"f4"},"z":{"bdata":"BQAHAA==","dtype":"i2"},"marker":{"color":"blue"},"line":{}}];""",
                """var layout = {"scene":{"camera":{"projection":{"type":"orthographic"}}}};"""
            ),

            "ParallelCoord" => (
                Chart.ParallelCoord(
                    keyValuesEncoded: new[] { ("A", X()), ("B", Y()) },
                    LabelAngle: 30, LineColor: Color.fromString("blue"),
                    ShowLineColorScale: false, UseDefaults: false),
                """var data = [{"type":"parcoords","dimensions":[{"label":"A","values":{"bdata":"AAAAAAIAAAA=","dtype":"i4"},"axis":{}},{"label":"B","values":{"bdata":"AADAPwAAkEA=","dtype":"f4"},"axis":{}}],"line":{"color":"blue","showscale":false},"labelangle":30}];""",
                """var layout = {};"""
            ),

            "ParallelCategories" => (
                Chart.ParallelCategories(
                    keyValuesEncoded: new[] { ("A", X()), ("B", Z()) },
                    Counts: 2, LineColor: Color.fromString("blue"),
                    Arrangement: StyleParam.CategoryArrangement.Fixed, BundleColors: false,
                    UseDefaults: false),
                """var data = [{"type":"parcats","counts":2,"dimensions":[{"label":"A","values":{"bdata":"AAAAAAIAAAA=","dtype":"i4"},"axis":{}},{"label":"B","values":{"bdata":"BQAHAA==","dtype":"i2"},"axis":{}}],"line":{"color":"blue"},"arrangement":"fixed","bundlecolors":false}];""",
                """var layout = {};"""
            ),

            "Sankey" => (
                Chart.Sankey<int, string>(
                    nodeLabels: new[] { "A", "B", "C" },
                    linkedNodeIds: new[] { (0, 1), (1, 2) }, linkValues: new[] { 2, 3 },
                    NodeAlign: StyleParam.SankeyNodeAlign.Left, NodeThickness: 20,
                    NodeColor: Color.fromString("red"), LinkColor: Color.fromString("blue"),
                    Arrangement: StyleParam.CategoryArrangement.Fixed,
                    ValueSuffix: " units", UseDefaults: false),
                """var data = [{"type":"sankey","node":{"align":"left","color":"red","label":["A","B","C"],"line":{},"thickness":20},"link":{"color":"blue","line":{},"source":[0,1],"target":[1,2],"value":[2,3]},"arrangement":"fixed","valuesuffix":" units"}];""",
                """var layout = {};"""
            ),

            "SankeyEncoded" => (
                Chart.Sankey<string>(
                    nodes: SankeyNodes.init<string, int[], double, double>(
                        Align: StyleParam.SankeyNodeAlign.Right,
                        Color: default,
                        ColorEncoded: default,
                        CustomData: default,
                        CustomDataEncoded: default,
                        Groups: default,
                        HoverInfo: default,
                        HoverLabel: default,
                        HoverTemplate: default,
                        MultiHoverTemplate: default,
                        Label: new[] { "A", "B", "C" },
                        Line: default,
                        Pad: default,
                        Thickness: default,
                        X: default,
                        XEncoded: EncodedTypedArray.ofFloat32Array(new[] { 0.0f, 0.5f, 1.0f }, shape: default),
                        Y: default,
                        YEncoded: EncodedTypedArray.ofFloat32Array(new[] { 0.25f, 0.5f, 0.75f }, shape: default)
                    ),
                    links: SankeyLinks.init<string, double>(
                        ArrowLen: default,
                        Color: default,
                        ColorEncoded: default,
                        ColorScales: default,
                        CustomData: default,
                        CustomDataEncoded: default,
                        HoverInfo: default,
                        HoverLabel: default,
                        HoverTemplate: default,
                        MultiHoverTemplate: default,
                        Label: default,
                        Line: default,
                        Source: default,
                        SourceEncoded: EncodedTypedArray.ofInt32Array(new[] { 0, 1 }, shape: default),
                        Target: default,
                        TargetEncoded: EncodedTypedArray.ofInt32Array(new[] { 1, 2 }, shape: default),
                        Value: default,
                        ValueEncoded: Y()
                    ),
                    ValueSuffix: " units", UseDefaults: false),
                """var data = [{"type":"sankey","node":{"align":"right","label":["A","B","C"],"x":{"bdata":"AAAAAAAAAD8AAIA/","dtype":"f4"},"y":{"bdata":"AACAPgAAAD8AAEA/","dtype":"f4"}},"link":{"source":{"bdata":"AAAAAAEAAAA=","dtype":"i4"},"target":{"bdata":"AQAAAAIAAAA=","dtype":"i4"},"value":{"bdata":"AADAPwAAkEA=","dtype":"f4"}},"valuesuffix":" units"}];""",
                """var layout = {};"""
            ),
            _ => throw new ArgumentOutOfRangeException(nameof(chartName), chartName, null)
        };
}
