namespace Plotly.NET.Interactive

open Plotly.NET

module Formatters =

    /// Converts a GenericChart to it's HTML representation and embeds it in a div element, together with the chart description for display in notebook environments.
    let toInteractiveHTML gChart =
        gChart
        |> Chart.withDisplayOptionsStyle (
            PlotlyJSReference = Require $"https://cdn.plot.ly/plotly-{Globals.PLOTLYJS_VERSION}.min"
        )
        |> GenericChart.toChartHTML
