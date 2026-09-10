using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicObj;
using Newtonsoft.Json;
using System.Reflection;
using System.IO;
using System.Text.RegularExpressions;
using Xunit;

namespace CSharp.Tests
{
    internal enum ChartMarkupSection
    {
        Data,
        Layout,
        Config,
        PlotlyCall
    }

    internal class TestUtils
    {
        static string GetFullPlotlyJS()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            using Stream str = assembly.GetManifestResourceStream("Plotly.NET.Tests.plotly-2.18.1.min.js");
            using StreamReader r = new StreamReader(str);
            return r.ReadToEnd();
        }

        static string GetSectionPattern(ChartMarkupSection section) =>
            section switch
            {
                ChartMarkupSection.Data => @"var data = .*?;",
                ChartMarkupSection.Layout => @"var layout = .*?;",
                ChartMarkupSection.Config => @"var config = .*?;",
                ChartMarkupSection.PlotlyCall => @"Plotly\.newPlot\(.*?\);",
                _ => throw new ArgumentOutOfRangeException(nameof(section), section, null)
            };

        static string ExtractChartSection(string html, ChartMarkupSection section)
        {
            Match match = Regex.Match(html, GetSectionPattern(section), RegexOptions.Singleline);

            Assert.True(match.Success, $"Could not find {section} section in generated chart markup.");

            return match.Value.Trim();
        }

    //A method that takes a Generic chart as input, transforms it with a delegate called 'htmlizer' into a string, for which it then should be tested wether another string is contained.
    internal static void SubstringIsInChart(Plotly.NET.GenericChart chart, Func<Plotly.NET.GenericChart, string> htmlizer, string expected) 
        {
            string actual = htmlizer(chart);
            Assert.Contains(expected, actual);
        }


    internal static void ChartGeneratedContains(Plotly.NET.GenericChart chart, string expected) 
        {
            SubstringIsInChart(chart, Plotly.NET.GenericChart.toChartHTML, expected);
            SubstringIsInChart(chart, Plotly.NET.GenericChart.toEmbeddedHTML, expected);
        }

        internal static void ChartGeneratedSectionEquals(Plotly.NET.GenericChart chart, ChartMarkupSection section, string expected)
        {
            string actualChartHtml = ExtractChartSection(Plotly.NET.GenericChart.toChartHTML(chart), section);
            string actualEmbeddedHtml = ExtractChartSection(Plotly.NET.GenericChart.toEmbeddedHTML(chart), section);

            Assert.Equal(expected, actualChartHtml);
            Assert.Equal(expected, actualEmbeddedHtml);
        }

    //C# version of the following F# code:
    //let substringListIsInChart chart htmlizer substringList =
    //    for substring in substringList do
    //        substringIsInChart chart htmlizer substring
    internal static void SubstringListIsInChart(Plotly.NET.GenericChart chart, Func<Plotly.NET.GenericChart, string> htmlizer, string[] substringList)
        {
            foreach (string substring in substringList)
            {
                SubstringIsInChart(chart, htmlizer, substring);
            }
        }

    //C# verison of the following F# code:
    //let chartGeneratedContainsList chart substringList =
    //for substring in substringList do
    //    chartGeneratedContains chart substring
    internal static void ChartGeneratedContainsList(Plotly.NET.GenericChart chart, string[] substringList)
        {
            foreach (string substring in substringList)
            {
                ChartGeneratedContains(chart, substring);
            }
        }

    }
}
