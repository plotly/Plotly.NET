namespace Plotly.NET.Interactive

open Plotly.NET
open Plotly.NET.GenericChart

module Formatters =

    let interactiveDoc =
        """
<div>
    [CHART]
    [DESCRIPTION]
</div    
"""

    /// Converts a GenericChart to it's HTML representation and embeds it in a div element, together with the chart description for display in notebook environments.
    let toInteractiveHTML gChart =
        let chartMarkup = toChartHTML gChart
        let displayOpts = getDisplayOptions gChart

        interactiveDoc.Replace("[CHART]", chartMarkup) |> DisplayOptions.replaceHtmlPlaceholders displayOpts
