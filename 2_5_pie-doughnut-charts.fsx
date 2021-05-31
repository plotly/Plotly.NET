(**
// can't yet format YamlFrontmatter (["title: Pie and doughnut Charts"; "category: Simple Charts"; "categoryindex: 3"; "index: 6"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# Pie and doughnut Charts

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=2_5_pie-doughnut-charts.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/2_5_pie-doughnut-charts.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/2_5_pie-doughnut-charts.ipynb)

*Summary:* This example shows how to create pie and doughnut charts in F#.

let's first create some data for the purpose of creating example charts:

*)
open Plotly.NET 
  
let values = [19; 26; 55;]
let labels = ["Residential"; "Non-Residential"; "Utility"]
(**
A pie, doughnut, or sunburst chart can be created using the `Chart.Pie`, `Chart.Doughnut`, and `Chart.Sunburst` functions.
When creating pie charts, it is usually desirable to provide both labels and values.

*)
let pie1 =
    Chart.Pie(values,labels)(* output: 
<div id="0a80de4a-8ce9-4076-9a18-a1f1e9b4de93" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_0a80de4a8ce940769a18a1f1e9b4de93 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"pie","values":[19,26,55],"labels":["Residential","Non-Residential","Utility"],"marker":{},"text":["Residential","Non-Residential","Utility"]}];
            var layout = {};
            var config = {};
            Plotly.newPlot('0a80de4a-8ce9-4076-9a18-a1f1e9b4de93', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_0a80de4a8ce940769a18a1f1e9b4de93();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_0a80de4a8ce940769a18a1f1e9b4de93();
            }
</script>
*)
let doughnut1 =
    Chart.Doughnut(
        values,
        labels,
        Hole=0.3,
        Textinfo=labels
    )(* output: 
<div id="8df9ca70-b266-4197-b242-5f73f02bb092" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_8df9ca70b2664197b2425f73f02bb092 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"pie","values":[19,26,55],"labels":["Residential","Non-Residential","Utility"],"textinfo":["Residential","Non-Residential","Utility"],"hole":0.3,"marker":{},"text":["Residential","Non-Residential","Utility"]}];
            var layout = {};
            var config = {};
            Plotly.newPlot('8df9ca70-b266-4197-b242-5f73f02bb092', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_8df9ca70b2664197b2425f73f02bb092();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_8df9ca70b2664197b2425f73f02bb092();
            }
</script>
*)
let sunburst1 =
    Chart.Sunburst(
        ["A";"B";"C";"D";"E"],
        ["";"";"B";"B";""],
        Values=[5.;0.;3.;2.;3.],
        Text=["At";"Bt";"Ct";"Dt";"Et"]
    )(* output: 
<div id="ab488be3-a895-46f2-b94d-75e55aa014f3" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_ab488be3a89546f2b94d75e55aa014f3 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"sunburst","labels":["A","B","C","D","E"],"parents":["","","B","B",""],"values":[5.0,0.0,3.0,2.0,3.0],"text":["At","Bt","Ct","Dt","Et"],"marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('ab488be3-a895-46f2-b94d-75e55aa014f3', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_ab488be3a89546f2b94d75e55aa014f3();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_ab488be3a89546f2b94d75e55aa014f3();
            }
</script>
*)

