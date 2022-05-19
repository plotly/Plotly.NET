using System;
using Plotly.NET;
using Microsoft.FSharp.Core; // use this for less verbose and more helpful intellisense
using Plotly.NET.LayoutObjects;

namespace Plotly.NET.Tests.CSharpConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] x = new double[] { 1, 2 };
            double[] y = new double[] { 5, 10 };

            LinearAxis xAxis = new LinearAxis();
            xAxis.SetValue("title", "xAxis");
            xAxis.SetValue("showgrid", false);
            xAxis.SetValue("showline", true);

            LinearAxis yAxis = new LinearAxis();
            yAxis.SetValue("title", "yAxis");
            yAxis.SetValue("showgrid", false);
            yAxis.SetValue("showline", true);

            Layout layout = new Layout();
            layout.SetValue("xaxis", xAxis);
            layout.SetValue("yaxis", yAxis);
            layout.SetValue("showlegend", true);

            Trace trace = new Trace("scatter");
            trace.SetValue("x", x);
            trace.SetValue("y", y);
            trace.SetValue("mode", "markers");
            trace.SetValue("name", "Hello from C#");

            GenericChart
                .ofTraceObject(true, trace)
                .WithLayout(layout)
                .Show();
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
