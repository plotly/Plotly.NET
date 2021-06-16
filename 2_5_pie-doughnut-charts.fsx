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
<div id="01915269-772f-49b8-84e3-cbc958a2194e" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_01915269772f49b884e3cbc958a2194e = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"pie","values":[19,26,55],"labels":["Residential","Non-Residential","Utility"],"marker":{},"text":["Residential","Non-Residential","Utility"]}];
            var layout = {};
            var config = {};
            Plotly.newPlot('01915269-772f-49b8-84e3-cbc958a2194e', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_01915269772f49b884e3cbc958a2194e();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_01915269772f49b884e3cbc958a2194e();
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
<div id="c5fd881e-9dec-4ff1-846e-d03159f7fc29" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_c5fd881e9dec4ff1846ed03159f7fc29 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"pie","values":[19,26,55],"labels":["Residential","Non-Residential","Utility"],"textinfo":["Residential","Non-Residential","Utility"],"hole":0.3,"marker":{},"text":["Residential","Non-Residential","Utility"]}];
            var layout = {};
            var config = {};
            Plotly.newPlot('c5fd881e-9dec-4ff1-846e-d03159f7fc29', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_c5fd881e9dec4ff1846ed03159f7fc29();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_c5fd881e9dec4ff1846ed03159f7fc29();
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
<div id="0ba79288-0955-4b1c-a906-b29749495fa2" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_0ba7928809554b1ca906b29749495fa2 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"sunburst","labels":["A","B","C","D","E"],"parents":["","","B","B",""],"values":[5.0,0.0,3.0,2.0,3.0],"text":["At","Bt","Ct","Dt","Et"],"marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('0ba79288-0955-4b1c-a906-b29749495fa2', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_0ba7928809554b1ca906b29749495fa2();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_0ba7928809554b1ca906b29749495fa2();
            }
</script>
*)

