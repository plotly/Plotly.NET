using System;
using Plotly.NET;
using Microsoft.FSharp.Core; // use this for less verbose and more helpful intellisense
using Plotly.NET.LayoutObjects;
using DynamicObj;

namespace Plotly.NET.Tests.CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] x = new double[] { 1, 2 };
            double[] y = new double[] { 5, 10 };

            LinearAxis xAxis = new LinearAxis();
            xAxis = xAxis.AddItem("title", "xAxis");
            xAxis = xAxis.AddItem("showgrid", false);
            xAxis = xAxis.AddItem("showline", true);

            LinearAxis yAxis = new LinearAxis();
            yAxis = yAxis.AddItem("title", "yAxis");
            yAxis = yAxis.AddItem("showgrid", false);
            yAxis = yAxis.AddItem("showline", true);

            Layout layout = new Layout();
            layout = layout.AddItem("xaxis", xAxis);
            layout = layout.AddItem("yaxis", yAxis);
            layout = layout.AddItem("showlegend", true);

            Trace trace = new Trace("scatter");
            trace = trace.AddItem("x", x);
            trace = trace.AddItem("y", y);
            trace = trace.AddItem("mode", "markers");
            trace = trace.AddItem("name", "Hello from C#");

            GenericChart
                .ofTraceObject(true,trace)
                .WithLayout(layout)
                .Show();
        }
    }
}
