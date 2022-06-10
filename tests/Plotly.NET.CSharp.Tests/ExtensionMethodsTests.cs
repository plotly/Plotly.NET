using System;
using Xunit;
using Plotly.NET.CSharp;


namespace Plotly.NET.CSharp.Tests
{
    public class ExtensionMethodsTests
    {
        internal GenericChart.GenericChart chart = Chart2D.Chart.Point<double, double, string>(x: new double[] { 1, 2 }, y: new double[] { 5, 10 });

        [Fact]
        public void CanUseCSharpExtensionMethod()
        {
            Trace actual =
                chart
                .WithTraceInfo(Name: "Trace Name")
                .GetTraces()
                [0];

            Assert.Equal("Trace Name", DynamicObj.DynamicObj.GetValue(actual,"name"));
        }
    }
}
