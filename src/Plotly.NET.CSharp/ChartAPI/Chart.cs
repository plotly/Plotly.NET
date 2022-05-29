using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plotly.NET;

namespace Plotly.NET.CSharp
{
    public static class Chart
    {
        public static GenericChart.GenericChart Combine(IEnumerable<GenericChart.GenericChart> gCharts) => Plotly.NET.Chart.Combine(gCharts);

        public static GenericChart.GenericChart Invisible()  => Plotly.NET.Chart.Invisible();
    }
}
