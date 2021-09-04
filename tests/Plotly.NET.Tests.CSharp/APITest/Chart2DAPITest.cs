using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Plotly.NET.Tests.CSharp.APITest
{
    public class Chart2DAPITest
    {
        private static readonly int[] x = new [] { 1, 2 };
        private static readonly int[] y = new [] { 1, 2 };
        private static readonly Tuple<int, int>[] xy = x.Zip(y).Select(c => new Tuple<int, int>(c.Item1, c.Item2)).ToArray();

        [Fact] public void Scatter1()
            => Chart2D.Chart.Scatter<int, int, int>(x, y, StyleParam.Mode.Lines);

        [Fact] public void Scatter2()
            => Chart2D.Chart.Scatter<int, int, int>(xy, StyleParam.Mode.Lines);

        [Fact] public void Point1()
            => Chart2D.Chart.Point<int, int, int>(x, y);

        [Fact] public void Point2()
            => Chart2D.Chart.Point<int, int, int>(xy);

        [Fact] public void Line1()
            => Chart2D.Chart.Line<int, int, int>(x, y);

        [Fact] public void Line2()
            => Chart2D.Chart.Line<int, int, int>(xy);
    }
}
