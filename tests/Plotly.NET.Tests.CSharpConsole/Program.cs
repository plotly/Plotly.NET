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
            Chart.Grid(
                nRows: 5,
                nCols: 3,
                gCharts:
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
                        ),
                        Chart.Scatter3D<int,int,int,string>(
                            x: new int[] { 12, 13 },
                            y: new int [] { 13, 14 },
                            z: new int [] { 14, 15 },
                            mode: Mode.Markers
                        ),
                        Chart.Invisible(),
                        Chart.Invisible(),
                        Chart.ScatterPolar<int,int,string>(
                            theta: new int [] { 1, 2 },
                            r: new int [] { 3, 4 },
                            mode: Mode.Markers
                        ),
                        Chart.Invisible(),
                        Chart.Invisible(),
                        Chart.ScatterGeo<int,int,string>(
                            longitudes: new int [] { 1, 2 },
                            latitudes: new int [] { 3, 4 },
                            mode: Mode.Markers
                        ),
                        Chart.Invisible(),
                        Chart.Invisible(),
                        Chart.Scatterternary<int,int,int,IConvertible,string>(
                            A: new int [] { 1, 2 },
                            B: new int [] { 3, 4 },
                            C: new int [] { 5, 6 }
                        ),
                        Chart.Invisible(),
                        Chart.Invisible(),
                    }
            ).Show();
        }
    }
}
