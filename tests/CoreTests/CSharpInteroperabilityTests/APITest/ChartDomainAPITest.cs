using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Plotly.NET.Tests.CSharp.APITest
{
    public class ChartDomainAPITest
    {
        public int[][] xofy = new [] { new [] { 1, 2 }, new [] { 1, 2 } };
        private static readonly int[] x = new[] { 1, 2 };
        private static readonly int[] y = new[] { 1, 2 };

        [Fact]
        public void Table()
            => ChartDomain.Chart.Table<int[], int, int[], int>(xofy, xofy);
    }
}
