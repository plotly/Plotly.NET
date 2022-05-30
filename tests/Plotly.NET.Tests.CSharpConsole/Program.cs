using System;
using Plotly.NET.CSharp;
using Plotly.NET.CSharp.ChartAPI;
using Plotly.NET.LayoutObjects;

namespace Plotly.NET.Tests.CSharpConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Plotly.NET.CSharp.ChartAPI.Chart2D.Scatter<int,int,string>(
                x: new int [] { 1, 2 },
                y: new int [] { 1, 2 },
                mode: StyleParam.Mode.Markers
            ).Show();

            Chart2D.Chart.Scatter<int,int,string> (
                x: new int[] { 1, 2 },
                y: new int[] { 1, 2 },
                mode: StyleParam.Mode.Markers
            ).Show();
        }
        static void Main2(string[] args)
        {
            double[] x = new double[] { 1, 2 };
            double[] y = new double[] { 5, 10 };
            GenericChart.GenericChart chart = Chart2D.Chart.Point<double, double, string>(x: x, y: y);
            chart
                .WithTraceInfo("Hello from C#", ShowLegend: true)
                .WithXAxisStyle(title: Title.init("xAxis"))
                .WithYAxisStyle(title: Title.init("yAxis"))
                .Show();
        }
    }
}
