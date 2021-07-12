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
<div id="f8d63c90-335b-4d75-8121-f2ef4355e248" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_f8d63c90335b4d758121f2ef4355e248 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"pie","values":[19,26,55],"labels":["Residential","Non-Residential","Utility"],"marker":{},"text":["Residential","Non-Residential","Utility"]}];
            var layout = {};
            var config = {};
            Plotly.newPlot('f8d63c90-335b-4d75-8121-f2ef4355e248', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_f8d63c90335b4d758121f2ef4355e248();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_f8d63c90335b4d758121f2ef4355e248();
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
<div id="64864290-fb34-438c-9fb4-60612306df42" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_64864290fb34438c9fb460612306df42 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"pie","values":[19,26,55],"labels":["Residential","Non-Residential","Utility"],"textinfo":["Residential","Non-Residential","Utility"],"hole":0.3,"marker":{},"text":["Residential","Non-Residential","Utility"]}];
            var layout = {};
            var config = {};
            Plotly.newPlot('64864290-fb34-438c-9fb4-60612306df42', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_64864290fb34438c9fb460612306df42();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_64864290fb34438c9fb460612306df42();
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
<div id="e7951267-9c4e-47c9-81f7-f44d1e5d8279" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_e79512679c4e47c981f7f44d1e5d8279 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"sunburst","labels":["A","B","C","D","E"],"parents":["","","B","B",""],"values":[5.0,0.0,3.0,2.0,3.0],"text":["At","Bt","Ct","Dt","Et"],"marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('e7951267-9c4e-47c9-81f7-f44d1e5d8279', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_e79512679c4e47c981f7f44d1e5d8279();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_e79512679c4e47c981f7f44d1e5d8279();
            }
</script>
*)

