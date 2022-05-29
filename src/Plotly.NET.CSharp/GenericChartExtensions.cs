using Plotly.NET;

namespace Plotly.NET.CSharp
{
    public static class GenericChartExtensions
    {
        public static Layout GetLayout(this GenericChart.GenericChart gChart) => GenericChart.getLayout(gChart);

        public static Trace [] GetTraces(this GenericChart.GenericChart gChart) => GenericChart.getTraces(gChart).ToArray();

        /// <summary>
        /// Saves the given Chart as html file at the given path (.html file extension is added if not present).
        /// Optionally opens the generated file in the browser.
        /// </summary>
        /// <param name="path">The path to save the chart html at.</param>
        /// <param name="OpenInBrowser">Wether or not to open the generated file in the browser (default: false)</param>
        public static void SaveHtml(
            this GenericChart.GenericChart gChart,
            string path,
            bool? OpenInBrowser
        ) =>
            Plotly.NET.Chart.SaveHtml(
                path: path,
                OpenInBrowser: OpenInBrowser
            ).Invoke(gChart);

        /// <summary>
        /// Saves the given chart as a temporary html file and opens it in the browser.
        /// </summary>
        /// <param name="ch">The chart to show in the browser</param>
        public static void Show(this GenericChart.GenericChart gChart) => Plotly.NET.Chart.Show(gChart);

        /// <summary>
        /// Sets trace information on the given chart.
        /// </summary>
        /// <param name="Name">Sets the name of the chart's trace(s). When the chart is a multichart (it contains multiple traces), the name is suffixed by '_%i' where %i is the index of the trace.</param>
        /// <param name="Visible">Wether or not the chart's traces are visible</param>
        /// <param name="ShowLegend">Determines whether or not item(s) corresponding to this chart's trace(s) is/are shown in the legend.</param>
        /// <param name="LegendRank">Sets the legend rank for the chart's trace(s). Items and groups with smaller ranks are presented on top/left side while with `"reversed" `legend.traceorder` they are on bottom/right side. The default legendrank is 1000, so that you can use ranks less than 1000 to place certain items before all unranked items, and ranks greater than 1000 to go after all unranked items.</param>
        /// <param name="LegendGroup">Sets the legend group for the chart's trace(s). Traces part of the same legend group hide/show at the same time when toggling legend items.</param>
        /// <param name="LegendGroupTitle">Sets the title for the chart's trace legend group </param>
        public static GenericChart.GenericChart WithTraceInfo(
            this GenericChart.GenericChart gChart,
            string? Name,
            StyleParam.Visible? Visible,
            bool? ShowLegend,
            int? LegendRank,
            string? LegendGroup,
            Title? LegendGroupTitle
        ) =>
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