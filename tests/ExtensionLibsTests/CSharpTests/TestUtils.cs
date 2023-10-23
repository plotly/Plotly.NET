using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicObj;
using Newtonsoft.Json;
using System.Reflection;
using System.IO;
using Xunit;

namespace CSharp.Tests
{
    internal class TestUtils
    {
        static string GetFullPlotlyJS()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            using Stream str = assembly.GetManifestResourceStream("Plotly.NET.Tests.plotly-2.18.1.min.js");
            using StreamReader r = new StreamReader(str);
            return r.ReadToEnd();
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
