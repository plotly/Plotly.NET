using System;
using System.Linq;
using Xunit;
using Plotly.NET.CSharp;

// avoid the namespace 'Plotly.NET', as we dont want to accidentally use F# type extensions instead of real C# bindings
namespace CSharp.Tests.HtmlCodegen.Chart2D
{
    public class SimpleTests
    {
        private const string ExpectedData = """var data = [{"type":"scatter","mode":"markers","x":[0.0,1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[0.0,1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"marker":{},"line":{}}];""";

        private const string ExpectedLayout = """var layout = {"xaxis":{"title":{"text":"xAxis"}},"yaxis":{"title":{"text":"yAxis"}}};""";

        static Plotly.NET.GenericChart simpleChart =
            Chart.Point<double, double, string>(
                x: Enumerable.Range(0, 11).Select(x => Convert.ToDouble(x)).ToArray(),
                y: Enumerable.Range(0, 11).Select(x => Convert.ToDouble(x)).ToArray(),
                UseDefaults: false
            )
                .WithXAxisStyle<int, int, int>(TitleText: "xAxis")
                .WithYAxisStyle<int, int, int>(TitleText: "yAxis");

        public class HtmlLayoutTests
        {
            [Fact]
            public void PlotlyJsScriptInGeneratedHTMLDocument()
            {
                TestUtils.SubstringIsInChart(
                    simpleChart,
                    Plotly.NET.GenericChart.toEmbeddedHTML, 
                    $"https://cdn.plot.ly/plotly-{Globals.PLOTLYJS_VERSION}.min"
                );
            }

            [Fact]
            public void ExpectingData()
            {
                TestUtils.ChartGeneratedSectionEquals(
                    simpleChart,
                    ChartMarkupSection.Data,
                    ExpectedData
                );
            }

            [Fact]
            public void ExpectingLayoutInfo()
            {
                TestUtils.ChartGeneratedSectionEquals(
                    simpleChart,
                    ChartMarkupSection.Layout,
                    ExpectedLayout
                );
            }

            [Fact]
            public void ExpectingHTMLTagsInEmbeddedPageOnly()
            {
                string[] tags = new string[] { "<html>", "</html>", "<head>", "</head>", "<body>", "</body>", "<script type=\"text/javascript\">", "</script>" };
                TestUtils.SubstringListIsInChart(
                    simpleChart,
                    Plotly.NET.GenericChart.toEmbeddedHTML,
                    tags
                );
            }

            [Fact]
            public void ExpectingSomeHTMLTagsInBothEmbeddedAndNotEmbedded()
            {
                string[] tags = new string[] { "<script type=\"text/javascript\">", "</script>" };
                TestUtils.ChartGeneratedContainsList(
                    simpleChart,
                    tags
                );
            }

            [Fact]
            public void PassingArgsToTheFunction()
            {
                TestUtils.ChartGeneratedContains(
                    simpleChart,
                    "data, layout, config);"
                );
            }

        }
    }
}
