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
                nRows: 10,
                nCols: 7,
                gCharts:
                    new GenericChart[]
                    {
                        //2D basic traces

                        //simple scatter derived
                        Chart.Combine(
                            new GenericChart []
                            {
                                Chart.Scatter<int, int, int>(
                                    x: new int [] { 1, 2, 3 },
                                    y: new int [] { 5, 3, 4 },
                                    mode: Mode.Markers,
                                    Name: "scatter",
                                    MultiText: new int [] { 3, 4 }
                                ),
                                Chart.Point<int,int,string>(
                                    x: new int [] { 1, 2, 3 },
                                    y: new int [] { 6, 4, 5 },
                                    Name: "point",
                                    Text: "hi"
                                ),
                                Chart.Line<int,int,string>(
                                    x: new int [] { 1, 2, 3 },
                                    y: new int [] { 7, 5, 6 },
                                    Name: "line"
                                ),
                                Chart.Spline<int,int,string>(
                                    x: new int [] { 1, 2, 3},
                                    y: new int [] { 8, 6, 7 },
                                    Name: "spline"
                                ),
                                Chart.Bubble<int,int,string>(
                                    x: new int [] { 1, 2, 3 },
                                    y: new int [] { 9, 7, 8 },
                                    sizes: new int [] { 10, 20, 30 },
                                    Name: "bubble"
                                )
                            }
                        ).WithTraceInfo(
                            LegendGroup: "simple-scatter-derived",
                            LegendGroupTitle: Plotly.NET.Title.init("simple scatter-derived traces")
                        ),

                        //extended scatter derived
                        Chart.Combine(
                            new GenericChart []
                            {
                                Chart.Range<int, int, string>(
                                    x: new int [] { 1, 2, 3 },
                                    y: new int [] { 5, 3, 4 },
                                    upper: new int [] { 6, 4, 5 },
                                    lower: new int [] { 4, 2, 3 },
                                    mode: Mode.Lines,
                                    Name: "range"
                                ),
                                Chart.Area<int,int,string>(
                                    x: new int [] { 1, 2},
                                    y: new int [] { 3, 1},
                                    Name: "area"
                                ),
                                Chart.SplineArea<int,int,string>(
                                    x: new int [] { 3, 4, 5},
                                    y: new int [] { 3, 1, 4},
                                    Name: "splinearea"
                                ),                                
                                Chart.StackedArea<int,int,string>(
                                    x: new int [] { 6, 7},
                                    y: new int [] { 3, 1},
                                    Name: "stacked area 1"
                                ),                                
                                Chart.StackedArea<int,int,string>(
                                    x: new int [] { 6, 7},
                                    y: new int [] { 3, 2},
                                    Name: "stacked area 2"
                                )
                            }
                        ).WithTraceInfo(
                            LegendGroup: "extended-scatter-derived",
                            LegendGroupTitle: Plotly.NET.Title.init("extended scatter-derived traces")
                        ),
                        Chart.Bar<int,string,string>(
                            values: new int [] { 1,2 },
                            Keys: new string [] { "first", "second"},
                            Name: "bar"
                        ),
                        Chart.Column<int,string,string>(
                            values: new int [] { 3,4 },
                            Keys: new string [] { "first", "second"},
                            Name: "column"
                        ),
                        Chart.Invisible(),
                        Chart.Invisible(),
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
                        Chart.Invisible(),

                        //2D Finance traces
                        Chart.OHLC<double,DateTime,string>(
                            open: new double [] {1.2, 2.7},
                            high: new double [] {1.8, 8.5},
                            low: new double []  {0.5, 0.1},
                            close: new double [] {1.1, 2.9},
                            x: new DateTime [] {DateTime.Parse("07/07/2021"), DateTime.Parse("07/07/2022") }
                        ).WithXAxisRangeSlider(
                            rangeSlider: Plotly.NET.LayoutObjects.RangeSlider.init(
                                Visible: false
                        )),
                        Chart.Candlestick<double,DateTime,string>(
                            open: new double [] {1.2, 2.7},
                            high: new double [] {1.8, 8.5},
                            low: new double []  {0.5, 0.1},
                            close: new double [] {1.1, 2.9},
                            x: new DateTime [] {DateTime.Parse("07/07/2021"), DateTime.Parse("07/07/2022") }
                        ).WithXAxisRangeSlider(
                            rangeSlider: Plotly.NET.LayoutObjects.RangeSlider.init(
                                Visible: false
                        )),
                        Chart.Waterfall<string, int, string>(
                            x: new string [] {"A", "B", "Net", "Purch", "Other", "Profit"},
                            y: new int [] {60, 80, 0, -40, -20, 0},
                            Measure: new Plotly.NET.StyleParam.WaterfallMeasure [] {
                                Plotly.NET.StyleParam.WaterfallMeasure.Relative,
                                Plotly.NET.StyleParam.WaterfallMeasure.Relative,
                                Plotly.NET.StyleParam.WaterfallMeasure.Total,
                                Plotly.NET.StyleParam.WaterfallMeasure.Relative,
                                Plotly.NET.StyleParam.WaterfallMeasure.Relative,
                                Plotly.NET.StyleParam.WaterfallMeasure.Total
                            }
                        ),
                        Chart.Funnel<double, string, string>(
                            x: new double [] { 1200, 909.4, 600.6, 300, 80 },
                            y: new string[] { "A", "B", "C", "D", "E"}
                        ),
                        Chart.Combine(
                            new GenericChart []
                            {
                                Chart.StackedFunnel<double, string, string>(
                                    x: new double [] { 1200, 909.4, 600.6, 300, 80 },
                                    y: new string[] { "A", "B", "C", "D", "E"}
                                ),
                                Chart.StackedFunnel<double, string, string>(
                                    x: new double [] { 1200, 909.4, 600.6, 300, 80 },
                                    y: new string[] { "A", "B", "C", "D", "E"}
                                ),
                            }
                        ),
                        Chart.FunnelArea<int, string, string>(
                            values: new int [] { 5, 4, 3, 2, 1 },
                            MultiText: new string[] { "A", "B", "C", "D", "E"}
                        ),
                        Chart.Indicator<double>(
                            value: 200,
                            mode: Plotly.NET.StyleParam.IndicatorMode.NumberDeltaGauge,
                            DeltaReference: 160
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
                        Chart.Invisible()
                    }
            )
            .WithSize(1400, 2000)
            .Show();
        }
    }
}
