using System;
using Plotly.NET.CSharp;
using static Plotly.NET.StyleParam;
using static Plotly.NET.GenericChart;

namespace TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Chart.Combine(
                new GenericChart []
                {
                    Chart.Scatter<int,int,string>(
                        x: new int [] { 1, 2 },
                        y: new int [] { 3, 4 },
                        mode: Mode.Markers
                    ),
                    Chart.Point<int,int,string>(
                        x: new int [] { 5, 6 },
                        y: new int [] { 7, 8 }
                    ),
                    Chart.Line<int,int,string>(
                        x: new int [] { 9, 10 },
                        y: new int [] { 11, 12 }
                    )
                }
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
