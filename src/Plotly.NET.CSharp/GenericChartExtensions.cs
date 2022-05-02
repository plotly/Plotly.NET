using Plotly.NET;

namespace Plotly.NET.CSharp
{
    public static class GenericChartExtensions
    {
        public static Layout GetLayout(this GenericChart.GenericChart gChart)
        {
            return GenericChart.getLayout(gChart);
        }

        public static Trace [] GetTraces(this GenericChart.GenericChart gChart)
        {
            return GenericChart.getTraces(gChart).ToArray();
        }

        public static GenericChart.GenericChart WithTraceInfo(
            this GenericChart.GenericChart gChart,
            string? Name,
            StyleParam.Visible? Visible,
            bool? ShowLegend,
            int? LegendRank,
            string? LegendGroup,
            Title? LegendGroupTitle
        )
        {
            return
                Plotly.NET.Chart.WithTraceInfo(
                    Name: Name,
                    Visible: Visible,
                    ShowLegend: ShowLegend,
                    LegendRank: LegendRank,
                    LegendGroup: LegendGroup,
                    LegendGroupTitle: LegendGroupTitle
                ).Invoke(gChart);
        }
    }
}