using Plotly.NET.CSharp;
using Plotly.NET.LayoutObjects;
using Plotly.NET.TraceObjects;
using Xunit;

namespace CSharp.Tests.HtmlCodegen.ChartDomain;

public class PieTests
{
    private const string ExpectedData = """var data = [{"type":"pie","values":[19,26,55],"labels":["A","B","C"],"marker":{"line":{},"pattern":{}}}];""";

    private static Plotly.NET.GenericChart CreateChart() =>
        Chart.Pie<int, string, string>(
            values: new[] { 19, 26, 55 },
            Labels: new[] { "A", "B", "C" },
            UseDefaults: false
        );

    [Fact]
    public void PieChartDataMatchesExpectedMarkup() =>
        TestUtils.ChartGeneratedSectionEquals(CreateChart(), ChartMarkupSection.Data, ExpectedData);
}

public class DoughnutTests
{
    private const string ExpectedData = """var data = [{"type":"pie","values":[19,26,55],"labels":["A","B","C"],"text":["A","B","C"],"marker":{"line":{},"pattern":{}},"hole":0.3}];""";

    private static Plotly.NET.GenericChart CreateChart() =>
        Chart.Doughnut<int, string, string>(
            values: new[] { 19, 26, 55 },
            Labels: new[] { "A", "B", "C" },
            MultiText: new[] { "A", "B", "C" },
            Hole: 0.3,
            UseDefaults: false
        );

    [Fact]
    public void DoughnutChartDataMatchesExpectedMarkup() =>
        TestUtils.ChartGeneratedSectionEquals(CreateChart(), ChartMarkupSection.Data, ExpectedData);
}

public class FunnelAreaTests
{
    private const string ExpectedData = """var data = [{"type":"funnelarea","values":[5,4,3],"text":["The 1st","The 2nd","The 3rd"],"marker":{"line":{"color":"purple","width":3.0},"pattern":{}}}];""";

    private static Plotly.NET.GenericChart CreateChart() =>
        Chart.FunnelArea<int, string, string>(
            values: new[] { 5, 4, 3 },
            MultiText: new[] { "The 1st", "The 2nd", "The 3rd" },
            SectionOutlineColor: Plotly.NET.Color.fromString("purple"),
            SectionOutlineWidth: 3.0,
            UseDefaults: false
        );

    [Fact]
    public void FunnelAreaChartDataMatchesExpectedMarkup() =>
        TestUtils.ChartGeneratedSectionEquals(CreateChart(), ChartMarkupSection.Data, ExpectedData);
}

public class SunburstTests
{
    private const string ExpectedData = """var data = [{"type":"sunburst","parents":["","","B"],"values":[19,26,55],"labels":["A","B","C"],"text":["At","Bt","Ct"],"marker":{"line":{},"pattern":{}}}];""";

    private static Plotly.NET.GenericChart CreateChart() =>
        Chart.Sunburst<string, string, int, string, string>(
            labels: new[] { "A", "B", "C" },
            parents: new[] { "", "", "B" },
            Values: new[] { 19, 26, 55 },
            MultiText: new[] { "At", "Bt", "Ct" },
            UseDefaults: false
        );

    [Fact]
    public void SunburstChartDataMatchesExpectedMarkup() =>
        TestUtils.ChartGeneratedSectionEquals(CreateChart(), ChartMarkupSection.Data, ExpectedData);
}

public class TreemapTests
{
    private const string ExpectedData = """var data = [{"type":"treemap","parents":["","","A"],"values":[20,5,15],"labels":["A","B","C"],"marker":{"line":{},"pattern":{}}}];""";

    private static Plotly.NET.GenericChart CreateChart() =>
        Chart.Treemap<string, string, int, string, string>(
            labels: new[] { "A", "B", "C" },
            parents: new[] { "", "", "A" },
            Values: new[] { 20, 5, 15 },
            UseDefaults: false
        );

    [Fact]
    public void TreemapChartDataMatchesExpectedMarkup() =>
        TestUtils.ChartGeneratedSectionEquals(CreateChart(), ChartMarkupSection.Data, ExpectedData);
}

public class ParallelCoordTests
{
    private const string ExpectedData = """var data = [{"type":"parcoords","dimensions":[{"label":"A","values":[1.0,4.0,3.4,0.7],"axis":{}},{"label":"B","values":[3.0,1.5,1.7,2.3],"axis":{}}],"line":{"color":"blue"}}];""";

    private static Plotly.NET.GenericChart CreateChart() =>
        Chart.ParallelCoord(
            dimensions: new Dimension[]
            {
                Dimension.initParallel<string, string, double, double>(
                    ConstraintRange: default,
                    Label: "A",
                    MultiSelect: default,
                    Name: default,
                    Range: default,
                    TemplateItemName: default,
                    TickFormat: default,
                    TickText: default,
                    Tickvals: default,
                    Values: new[] { 1.0, 4.0, 3.4, 0.7 },
                    ValuesEncoded: default,
                    Visible: default
                ),
                Dimension.initParallel<string, string, double, double>(
                    ConstraintRange: default,
                    Label: "B",
                    MultiSelect: default,
                    Name: default,
                    Range: default,
                    TemplateItemName: default,
                    TickFormat: default,
                    TickText: default,
                    Tickvals: default,
                    Values: new[] { 3.0, 1.5, 1.7, 2.3 },
                    ValuesEncoded: default,
                    Visible: default
                )
            },
            LineColor: Plotly.NET.Color.fromString("blue"),
            UseDefaults: false
        );

    [Fact]
    public void ParallelCoordChartDataMatchesExpectedMarkup() =>
        TestUtils.ChartGeneratedSectionEquals(CreateChart(), ChartMarkupSection.Data, ExpectedData);
}

public class ParallelCategoriesTests
{
    private const string ExpectedData = """var data = [{"type":"parcats","dimensions":[{"label":"A","values":["Cat1","Cat1","Cat2"],"axis":{}},{"label":"B","values":["Yes","No","Yes"],"axis":{}}],"line":{"color":"blue"}}];""";

    private static Plotly.NET.GenericChart CreateChart() =>
        Chart.ParallelCategories(
            dimensions: new Dimension[]
            {
                Dimension.initParallel<string, string, string, string>(
                    ConstraintRange: default,
                    Label: "A",
                    MultiSelect: default,
                    Name: default,
                    Range: default,
                    TemplateItemName: default,
                    TickFormat: default,
                    TickText: default,
                    Tickvals: default,
                    Values: new[] { "Cat1", "Cat1", "Cat2" },
                    ValuesEncoded: default,
                    Visible: default
                ),
                Dimension.initParallel<string, string, string, string>(
                    ConstraintRange: default,
                    Label: "B",
                    MultiSelect: default,
                    Name: default,
                    Range: default,
                    TemplateItemName: default,
                    TickFormat: default,
                    TickText: default,
                    Tickvals: default,
                    Values: new[] { "Yes", "No", "Yes" },
                    ValuesEncoded: default,
                    Visible: default
                )
            },
            LineColor: Plotly.NET.Color.fromString("blue"),
            UseDefaults: false
        );

    [Fact]
    public void ParallelCategoriesChartDataMatchesExpectedMarkup() =>
        TestUtils.ChartGeneratedSectionEquals(CreateChart(), ChartMarkupSection.Data, ExpectedData);
}

public class SankeyTests
{
    private const string ExpectedData = """var data = [{"type":"sankey","node":{"label":["A","B","C","D"]},"link":{"source":[0,1,1],"target":[2,2,3],"value":[1,2,5]}}];""";

    private static Plotly.NET.GenericChart CreateChart() =>
        Chart.Sankey<string>(
            nodes: SankeyNodes.init<string, int[], string, string>(
                Color: default,
                CustomData: default,
                Groups: default,
                HoverInfo: default,
                HoverLabel: default,
                HoverTemplate: default,
                MultiHoverTemplate: default,
                Label: new[] { "A", "B", "C", "D" },
                Line: default,
                Pad: default,
                Thickness: default,
                X: default,
                Y: default
            ),
            links: SankeyLinks.init<string, int>(
                ArrowLen: default,
                Color: default,
                ColorScales: default,
                CustomData: default,
                HoverInfo: default,
                HoverLabel: default,
                HoverTemplate: default,
                MultiHoverTemplate: default,
                Label: default,
                Line: default,
                Source: new[] { 0, 1, 1 },
                Target: new[] { 2, 2, 3 },
                Value: new[] { 1, 2, 5 }
            ),
            UseDefaults: false
        );

    [Fact]
    public void SankeyChartDataMatchesExpectedMarkup() =>
        TestUtils.ChartGeneratedSectionEquals(CreateChart(), ChartMarkupSection.Data, ExpectedData);
}

public class TableTests
{
    private const string ExpectedData = """var data = [{"type":"table","cells":{"values":[["0","1"],["A","B"]]},"header":{"values":["H1","H2"]}}];""";

    private static Plotly.NET.GenericChart CreateChart() =>
        Chart.Table(
            header: TableCells.init<string, char>(
                Align: default,
                MultiAlign: default,
                Fill: default,
                Font: default,
                Format: default,
                Height: default,
                Line: default,
                Prefix: default,
                MultiPrefix: default,
                Suffix: default,
                MultiSuffix: default,
                Values: new[] { "H1", "H2" }
            ),
            cells: TableCells.init<string[], string>(
                Align: default,
                MultiAlign: default,
                Fill: default,
                Font: default,
                Format: default,
                Height: default,
                Line: default,
                Prefix: default,
                MultiPrefix: default,
                Suffix: default,
                MultiSuffix: default,
                Values: new[]
                {
                    new[] { "0", "1" },
                    new[] { "A", "B" }
                }
            ),
            UseDefaults: false
        );

    [Fact]
    public void TableChartDataMatchesExpectedMarkup() =>
        TestUtils.ChartGeneratedSectionEquals(CreateChart(), ChartMarkupSection.Data, ExpectedData);
}

public class IndicatorTests
{
    private const string ExpectedData = """var data = [{"type":"indicator","mode":"number+delta+gauge","value":120,"domain":{"row":0,"column":1},"delta":{"reference":90},"gauge":{"axis":{"visible":false,"range":[-200.0,200.0]},"shape":"bullet"}}];""";

    private static Plotly.NET.GenericChart CreateChart() =>
        Chart.Indicator<int>(
            value: 120,
            mode: Plotly.NET.StyleParam.IndicatorMode.NumberDeltaGauge,
            DeltaReference: 90,
            Range: new Plotly.NET.StyleParam.Range.MinMax(-200.0, 200.0),
            GaugeShape: Plotly.NET.StyleParam.IndicatorGaugeShape.Bullet,
            ShowGaugeAxis: false,
            Domain: Domain.init(X: default, Y: default, Row: 0, Column: 1),
            UseDefaults: false
        );

    [Fact]
    public void IndicatorChartDataMatchesExpectedMarkup() =>
        TestUtils.ChartGeneratedSectionEquals(CreateChart(), ChartMarkupSection.Data, ExpectedData);
}

public class IcicleTests
{
    private const string ExpectedData = """var data = [{"type":"icicle","parents":["","A","A"],"values":[20,15,5],"labels":["A","AA","AB"],"marker":{"line":{},"pattern":{}},"tiling":{},"pathbar":{}}];""";

    private static Plotly.NET.GenericChart CreateChart() =>
        Chart.Icicle<string, string, int, string, string>(
            labels: new[] { "A", "AA", "AB" },
            parents: new[] { "", "A", "A" },
            Values: new[] { 20, 15, 5 },
            UseDefaults: false
        );

    [Fact]
    public void IcicleChartDataMatchesExpectedMarkup() =>
        TestUtils.ChartGeneratedSectionEquals(CreateChart(), ChartMarkupSection.Data, ExpectedData);
}
