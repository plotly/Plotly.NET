(**
// can't yet format YamlFrontmatter (["title: Pie and doughnut Charts"; "category: Simple Charts"; "categoryindex: 3"; "index: 6"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# Pie and doughnut Charts

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=02_5_pie-doughnut-charts.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/02_5_pie-doughnut-charts.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/02_5_pie-doughnut-charts.ipynb)

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
<div id="95d33635-71ce-40c2-aecc-ec76dcc9bf0c" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_95d3363571ce40c2aeccec76dcc9bf0c = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"pie","values":[19,26,55],"labels":["Residential","Non-Residential","Utility"],"marker":{},"text":["Residential","Non-Residential","Utility"]}];
            var layout = {};
            var config = {};
            Plotly.newPlot('95d33635-71ce-40c2-aecc-ec76dcc9bf0c', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_95d3363571ce40c2aeccec76dcc9bf0c();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_95d3363571ce40c2aeccec76dcc9bf0c();
            }
</script>
*)
let doughnut1 =
    Chart.Doughnut(
        values,
        labels,
        Hole=0.3,
        TextLabels=labels
    )(* output: 
<div id="33bc2e22-8f29-4823-b80d-d424790983bd" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_33bc2e228f294823b80dd424790983bd = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"pie","values":[19,26,55],"labels":["Residential","Non-Residential","Utility"],"text":["Residential","Non-Residential","Utility"],"hole":0.3,"marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('33bc2e22-8f29-4823-b80d-d424790983bd', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_33bc2e228f294823b80dd424790983bd();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_33bc2e228f294823b80dd424790983bd();
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
<div id="ab0d19e0-b061-42a0-8600-604d89c0ef77" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_ab0d19e0b06142a08600604d89c0ef77 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"sunburst","labels":["A","B","C","D","E"],"parents":["","","B","B",""],"values":[5.0,0.0,3.0,2.0,3.0],"text":["At","Bt","Ct","Dt","Et"],"marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('ab0d19e0-b061-42a0-8600-604d89c0ef77', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_ab0d19e0b06142a08600604d89c0ef77();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_ab0d19e0b06142a08600604d89c0ef77();
            }
</script>
*)

