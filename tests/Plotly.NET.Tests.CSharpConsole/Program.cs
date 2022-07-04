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
                nRows: 9,
                nCols: 6,
                gCharts:
                    new GenericChart[]
                    {
                        //2D basic traces
                        Chart.Scatter(
                            x: new int [] { 1, 2 },
                            y: new int [] { 3, 4 },
                            mode: Mode.Markers,
                            MultiText: new int [] { 3, 4 }
                        ),
                        Chart.Point<int,int,string>(
                            x: new int [] { 5, 6 },
                            y: new int [] { 7, 8 }
                        ),
                        Chart.Line<int,int,string>(
                            x: new int [] { 9, 10 },
                            y: new int [] { 11, 12 }
                        ),
                        Chart.Bar<int,string,string>(
                            values: new int [] { 1,2 },
                            Keys: new string [] { "first", "second"}
                        ),
                        Chart.Column<int,string,string>(
                            values: new int [] { 3,4 },
                            Keys: new string [] { "first", "second"}
                        ),
                        Chart.Invisible(),

                        //2D distributions
                        Chart.Histogram<int,int,int>(
                            X: new int [] { 1,2,2,2,3,4,5,5 },
                            MultiText: new int [] { 1,2,3,4,5,6,7}
                        ),
                        Chart.Histogram2D<int,int,int>(
                           x: new int [] { 1,2,2,2,3,4,5,5 },
                           y: new int [] { 1,2,2,2,3,4,5,5 },
                           ShowScale: false
                        ),
                        Chart.BoxPlot<int,int,string>(
                            X: new int [] { 1,2,2,2,3,4,5,5 }
                        ),
                        Chart.Violin<int,int,string>(
                            X: new int [] { 1,2,2,2,3,4,5,5 }
                        ),
                        Chart.Histogram2DContour<int,int,int>(
                           x: new int [] { 1,2,2,2,3,4,5,5 },
                           y: new int [] { 1,2,2,2,3,4,5,5 },
                           ShowScale: false
                        ),
                        Chart.PointDensity<int,int>(
                           x: new int [] { 1,2,2,2,3,4,5,5 },
                           y: new int [] { 1,2,2,2,3,4,5,5 },
                           ShowScale: false
                        ),

                        //3D traces
                        Chart.Scatter3D<int,int,int,string>(
                            x: new int[] { 12, 13 },
                            y: new int [] { 13, 14 },
                            z: new int [] { 14, 15 },
                            mode: Mode.Markers
                        ),
                        Chart.Invisible(),
                        Chart.Invisible(),
                        Chart.Invisible(),
                        Chart.Invisible(),
                        Chart.Invisible(),

                        //polar traces
                        Chart.ScatterPolar<int,int,string>(
                            theta: new int [] { 1, 2 },
                            r: new int [] { 3, 4 },
                            mode: Mode.Markers
                        ),
                        Chart.Invisible(),
                        Chart.Invisible(),
                        Chart.Invisible(),
                        Chart.Invisible(),
                        Chart.Invisible(),

                        //geo/mapbox traces
                        Chart.ScatterGeo<int,int,string>(
                            longitudes: new int [] { 1, 2 },
                            latitudes: new int [] { 3, 4 },
                            mode: Mode.Markers
                        ),
                        Chart.Invisible(),
                        Chart.Invisible(),
                        Chart.Invisible(),
                        Chart.Invisible(),
                        Chart.DensityMapbox<int,int,int,string>(
                            longitudes: new int [] { 1,2,2,2,3,4,5,5 },
                            latitudes:  new int [] { 1,2,2,2,3,4,5,5 },
                            ShowScale: false
                        ).WithMaboxStyle(
                            Style: MapboxStyle.OpenStreetMap
                        ),
                        
                        //ternary traces
                        Chart.ScatterTernary<int,int,int,IConvertible,string>(
                            A: new int [] { 1, 2 },
                            B: new int [] { 3, 4 },
                            C: new int [] { 5, 6 }
                        ),
                        Chart.Invisible(),
                        Chart.Invisible(),
                        Chart.Invisible(),
                        Chart.Invisible(),
                        Chart.Invisible(),

                        //carpet traces
                        Chart.Carpet<double,double,double,double,double,double>(
                            carpetId: "testCarpet",
                            A: new double [] {4.0, 4.0, 4.0, 4.5, 4.5, 4.5, 5.0, 5.0, 5.0, 6.0, 6.0, 6.0},
                            B: new double [] {1.0, 2.0, 3.0, 1.0, 2.0, 3.0, 1.0, 2.0, 3.0, 1.0, 2.0, 3.0},
                            Y: new double [] {2.0, 3.5, 4.0, 3.0, 4.5, 5.0, 5.5, 6.5, 7.5, 8.0, 8.5, 10.0}
                        ),
                        Chart.Invisible(),
                        Chart.Invisible(),
                        Chart.Invisible(),
                        Chart.Invisible(),
                        Chart.Combine(
                            new GenericChart []
                            {
                                Chart.Carpet<double,double,double,double,double,double>(
                                    carpetId: "contour",
                                    A: new double [] { 0.0, 1.0, 2.0, 3.0, 0.0, 1.0, 2.0, 3.0, 0.0, 1.0, 2.0, 3.0},
                                    B: new double[] { 4.0, 4.0, 4.0, 4.0, 5.0, 5.0, 5.0, 5.0, 6.0, 6.0, 6.0, 6.0},
                                    X: new double[] { 2.0, 3.0, 4.0, 5.0, 2.2, 3.1, 4.1, 5.1, 1.5, 2.5, 3.5, 4.5},
                                    Y: new double [] { 1.0, 1.4, 1.6, 1.75, 2.0, 2.5, 2.7, 2.75, 3.0, 3.5, 3.7, 3.75}
                                ),
                                Chart.ContourCarpet<double,int,int,string>(
                                    z: new double [] { 1.0, 1.96, 2.56, 3.0625, 4.0, 5.0625, 1.0, 7.5625, 9.0, 12.25, 15.21, 14.0625 },
                                    carpetAnchorId: "contour",
                                    A: new int [] { 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3},
                                    B: new int[] { 4, 4, 4, 4, 5, 5, 5, 5, 6, 6, 6, 6},
                                    ShowScale: false
                                )
                            }
                        ),

                        //domain traces
                        Chart.Pie<double,string,string>(
                            values: new double [] {1,2,3,4},
                            Labels: new string [] {"soos", "saas", "fiif", "leel"}
                        ),
                        Chart.Invisible(),
                        Chart.Invisible(),
                        Chart.Invisible(),
                        Chart.Invisible(),
                        Chart.Invisible(),

                        //smith traces
                        Chart.ScatterSmith<double,double,string>(
                            real: new double [] {1,2,3,4},
                            imag: new double [] {1,2,3,4},
                            mode: Mode.Markers
                        ),
                        Chart.Invisible(),
                        Chart.Invisible(),
                        Chart.Invisible(),
                        Chart.Invisible(),
                        Chart.Invisible(),
                    }
            )
                .WithSize(1000, 1800)
                .Show();
        }
    }
}
