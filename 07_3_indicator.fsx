(**
// can't yet format YamlFrontmatter (["title: Indicator Charts"; "category: Finance Charts"; "categoryindex: 7"; "index: 4"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# Indicator Charts

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=07_3_indicator.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/07_3_indicator.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/07_3_indicator.ipynb)

*Summary:* This example shows how to create indicator charts in F#.

Indicator Charts visualize the evolution of a value compared to a reference value, optionally inside a range.

There are different types of indicator charts, depending on the `IndicatorMode` used in chart generation:

- `Delta`/`Number` (and combinations) simply shows if the value is increasing or decreasing compared to the reference
- Any combination of the above with `Gauge` adds a customizable gauge that indicates where the value lies inside a given range.

*)
open Plotly.NET 
open Plotly.NET.TraceObjects
open Plotly.NET.LayoutObjects

let allIndicatorTypes =
    [
        Chart.Indicator(
            120., StyleParam.IndicatorMode.NumberDeltaGauge,
            Title = "Bullet gauge",
            DeltaReference = 90.,
            Range = StyleParam.Range.MinMax(-200., 200.),
            GaugeShape = StyleParam.IndicatorGaugeShape.Bullet,
            ShowGaugeAxis = false,
            Domain  = Domain.init(Row = 0, Column = 0)
        )
        Chart.Indicator(
            200., StyleParam.IndicatorMode.NumberDeltaGauge,
            Title = "Angular gauge",
            Delta = IndicatorDelta.init(Reference=160),
            Range = StyleParam.Range.MinMax(0., 250.),
            Domain = Domain.init(Row = 0, Column = 1)
        )
        Chart.Indicator(
            300., StyleParam.IndicatorMode.NumberDelta,
            Title = "number and delta",
            DeltaReference = 90.,
            Domain  = Domain.init(Row = 1, Column = 0)
        )        
        Chart.Indicator(
            40., StyleParam.IndicatorMode.Delta,
            Title = "delta",
            DeltaReference = 90.,
            Domain  = Domain.init(Row = 1, Column = 1)
        )
    ]
    |> Chart.combine
    |> Chart.withLayoutGridStyle(Rows = 2, Columns = 2)
    |> Chart.withMarginSize(Left = 200)(* output: 
<div id="ca7f7288-cccc-423f-8cd1-0a362265199d" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_ca7f7288cccc423f8cd10a362265199d = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"indicator","title":"Bullet gauge","mode":"number+delta+gauge","value":120.0,"domain":{"row":0,"column":0},"delta":{"reference":90.0},"gauge":{"axis":{"visible":false,"range":[-200.0,200.0]},"shape":"bullet"}},{"type":"indicator","title":"Angular gauge","mode":"number+delta+gauge","value":200.0,"domain":{"row":0,"column":1},"delta":{"reference":160},"gauge":{"axis":{"range":[0.0,250.0]}}},{"type":"indicator","title":"number and delta","mode":"number+delta","value":300.0,"domain":{"row":1,"column":0},"delta":{"reference":90.0},"gauge":{"axis":{}}},{"type":"indicator","title":"delta","mode":"delta","value":40.0,"domain":{"row":1,"column":1},"delta":{"reference":90.0},"gauge":{"axis":{}}}];
            var layout = {"grid":{"rows":2,"columns":2},"margin":{"l":200}};
            var config = {};
            Plotly.newPlot('ca7f7288-cccc-423f-8cd1-0a362265199d', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_ca7f7288cccc423f8cd10a362265199d();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_ca7f7288cccc423f8cd10a362265199d();
            }
</script>
*)

