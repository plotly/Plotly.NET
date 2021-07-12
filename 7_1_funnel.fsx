(**
// can't yet format YamlFrontmatter (["title: Funnel Charts"; "category: Finance Charts"; "categoryindex: 7"; "index: 2"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# Funnel Charts

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=7_1_funnel.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/7_1_funnel.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/7_1_funnel.ipynb)

*Summary:* This example shows how to create funnel charts in F#.

let's first create some data for the purpose of creating example charts:
*)
let y = [|"Sales person A"; "Sales person B"; "Sales person C"; "Sales person D"; "Sales person E"|]
let x = [|1200.; 909.4; 600.6; 300.; 80.|]
(**
Funnel charts visualize stages in a process using length-encoded bars. This trace can be used to show data in either a part-to-whole 
representation wherein each item appears in a single stage, or in a "drop-off" representation wherein each item appears in each stage 
it traversed. See also the [FunnelArea](https://plotly.net//6_2_funnel_area.html) chart for a different approach to visualizing funnel data.
*)
open Plotly.NET 

// Customize the connector lines used to connect the funnel bars
let connectorLine = Line.init (Color="royalblue", Dash=StyleParam.DrawingStyle.Dot, Width=3.)
let connector = FunnelConnector.init(Line=connectorLine)

// Customize the outline of the funnel bars
let line = Line.init(Width=2.,Color="3E4E88")

// create a funnel chart using custom connectors and outlines
let funnel =
    Chart.Funnel (x,y,Color="59D4E8", Line=line, Connector=connector)
    |> Chart.withMarginSize(Left=100)(* output: 
<div id="1428d27b-a292-4520-8867-30f13e7d4c65" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_1428d27ba2924520886730f13e7d4c65 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"funnel","x":[1200.0,909.4,600.6,300.0,80.0],"y":["Sales person A","Sales person B","Sales person C","Sales person D","Sales person E"],"connector":{"line":{"color":"royalblue","width":3.0,"dash":"dot"}},"marker":{"color":"59D4E8","line":{"color":"3E4E88","width":2.0}}}];
            var layout = {"margin":{"l":100}};
            var config = {};
            Plotly.newPlot('1428d27b-a292-4520-8867-30f13e7d4c65', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_1428d27ba2924520886730f13e7d4c65();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_1428d27ba2924520886730f13e7d4c65();
            }
</script>
*)

