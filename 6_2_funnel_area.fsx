(**
// can't yet format YamlFrontmatter (["title: FunnelArea Charts"; "category: Finance Charts"; "categoryindex: 7"; "index: 3"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# FunnelArea Charts

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=6_2_funnel_area.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/6_2_funnel_area.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/6_2_funnel_area.ipynb)

*Summary:* This example shows how to create funnel area charts in F#.

let's first create some data for the purpose of creating example charts:
*)
let values = [|5; 4; 3; 2; 1|]
let text = [|"The 1st"; "The 2nd"; "The 3rd"; "The 4th"; "The 5th"|]
(**
FunnelArea charts visualize stages in a process using area-encoded trapezoids. 
This trace can be used to show data in a part-to-whole representation similar to a "pie" trace, 
wherein each item appears in a single stage. See also the the [Funnel](https://plotly.net//6_1_funnel.html) chart for a different approach 
to visualizing funnel data.
*)
open Plotly.NET 

let line = Line.init (Color="purple", Width=3.)

let funnelArea = 
    Chart.FunnelArea(Values=values, Text=text, Line=line)(* output: 
<div id="c313561d-929b-49a8-9750-1e0a3eeff231" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_c313561d929b49a897501e0a3eeff231 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"funnelarea","values":[5,4,3,2,1],"marker":{"line":{"color":"purple","width":3.0}},"domain":{},"text":["The 1st","The 2nd","The 3rd","The 4th","The 5th"]}];
            var layout = {};
            var config = {};
            Plotly.newPlot('c313561d-929b-49a8-9750-1e0a3eeff231', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_c313561d929b49a897501e0a3eeff231();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_c313561d929b49a897501e0a3eeff231();
            }
</script>
*)

