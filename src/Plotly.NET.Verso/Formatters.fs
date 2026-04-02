namespace Plotly.NET.Verso

open Plotly.NET

module Formatters =

    /// Converts a GenericChart to its HTML representation for display in Verso notebook environments.
    /// Uses RequireJS to dynamically load plotly.js from CDN with a fallback that loads RequireJS itself if not present.
    let toVersoHTML gChart =
        gChart
        |> Chart.withDisplayOptionsStyle (
            PlotlyJSReference = Require $"https://cdn.plot.ly/plotly-{Globals.PLOTLYJS_VERSION}.min"
        )
        |> GenericChart.toChartHTML

    /// Converts a GenericChart to a fully self-contained HTML document with plotly.js embedded inline (~3MB).
    /// Works completely offline without internet access.
    let toVersoHTMLOffline gChart =
        gChart
        |> Chart.withDisplayOptionsStyle (PlotlyJSReference = Full)
        |> GenericChart.toEmbeddedHTML
