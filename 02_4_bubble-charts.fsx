(**
// can't yet format YamlFrontmatter (["title: Bubble charts"; "category: Simple Charts"; "categoryindex: 3"; "index: 5"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# Bubble charts

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=02_4_bubble-charts.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/02_4_bubble-charts.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/02_4_bubble-charts.ipynb)

*Summary:* This example shows how to create bubble charts in F#.

let's first create some data for the purpose of creating example charts:

*)
open Plotly.NET 
  
let x = [2; 4; 6;]
let y = [4; 1; 6;]
let size = [19; 26; 55;]
(**
A bubble chart is a type of chart that displays three dimensions of data. Each entity with its triplet (x, y, size) 
of associated data is plotted as a disk. The first two values determine the disk's xy location and the 
third its size.


*)
let bubble1 = Chart.Bubble(x,y,size)(* output: 
<div id="ff13633b-b3d7-4445-8126-756820aa6ff6" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_ff13633bb3d744458126756820aa6ff6 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","mode":"markers","x":[2,4,6],"y":[4,1,6],"marker":{"size":[19,26,55]}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('ff13633b-b3d7-4445-8126-756820aa6ff6', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_ff13633bb3d744458126756820aa6ff6();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_ff13633bb3d744458126756820aa6ff6();
            }
</script>
*)

