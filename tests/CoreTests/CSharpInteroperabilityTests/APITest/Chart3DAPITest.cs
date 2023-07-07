using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Plotly.NET.Tests.CSharp.APITest
{
    public class Chart3DAPITest
    {
        private static readonly int[] x = new[] { 1, 2 };
        private static readonly int[] y = new[] { 1, 2 };
        private static readonly int[] z = new[] { 1, 2 };
        private static readonly Tuple<int, int, int>[] xyz = x.Zip(y).Zip(z).Select(c => new Tuple<int, int, int>(c.Item1.First, c.Item1.Second, c.Item2)).ToArray();

        [Fact] public void Scatter3d1()
            => Chart3D.Chart.Scatter3D<int, int, int, int>(x, y, z, StyleParam.Mode.Lines);
    }
}
