(**
// can't yet format YamlFrontmatter (["title: Area charts"; "category: Simple Charts"; "categoryindex: 3"; "index: 3"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# Area charts

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=2_2_area-plots.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/2_2_area-plots.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/2_2_area-plots.ipynb)

*Summary:* This example shows how to create area charts, area charts with splines, and stackes area charts in F#.

let's first create some data for the purpose of creating example charts:

*)
open Plotly.NET 
  
let x  = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
let y  = [5.; 2.5; 5.; 7.5; 5.; 2.5; 7.5; 4.5; 5.5; 5.]
(**
An area chart or area graph displays graphically quantitive data. It is based on the line chart.
The area between axis and line are commonly emphasized with colors, textures and hatchings.

### Simple area chart
*)
let area1 = Chart.Area(x,y)(* output: 
<div id="ed00dd8a-7cd5-4914-b0da-f110b5cfc92d" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_ed00dd8a7cd54914b0daf110b5cfc92d = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[5.0,2.5,5.0,7.5,5.0,2.5,7.5,4.5,5.5,5.0],"mode":"lines","fill":"tozeroy","line":{},"marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('ed00dd8a-7cd5-4914-b0da-f110b5cfc92d', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_ed00dd8a7cd54914b0daf110b5cfc92d();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_ed00dd8a7cd54914b0daf110b5cfc92d();
            }
</script>
*)
(**
### Area chart with a spline
*)
let area2 =
    Chart.SplineArea(x,y)(* output: 
<div id="fd097c67-d636-4ed0-afb8-cbca79f9ee24" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_fd097c67d6364ed0afb8cbca79f9ee24 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[5.0,2.5,5.0,7.5,5.0,2.5,7.5,4.5,5.5,5.0],"mode":"lines","fill":"tozeroy","line":{"shape":"spline"},"marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('fd097c67-d636-4ed0-afb8-cbca79f9ee24', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_fd097c67d6364ed0afb8cbca79f9ee24();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_fd097c67d6364ed0afb8cbca79f9ee24();
            }
</script>
*)
(**
### Stacked Area chart
*)
let stackedArea =
    [
        Chart.StackedArea(x,y)
        Chart.StackedArea(x,y |> Seq.rev)
    ]
    |> Chart.combine(* output: 
<div id="c9802b57-8060-4c32-a78a-56e574092502" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_c9802b5780604c32a78a56e574092502 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[5.0,2.5,5.0,7.5,5.0,2.5,7.5,4.5,5.5,5.0],"mode":"lines","line":{},"marker":{},"stackgroup":"static"},{"type":"scatter","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[5.0,5.5,4.5,7.5,2.5,5.0,7.5,5.0,2.5,5.0],"mode":"lines","line":{},"marker":{},"stackgroup":"static"}];
            var layout = {};
            var config = {};
            Plotly.newPlot('c9802b57-8060-4c32-a78a-56e574092502', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_c9802b5780604c32a78a56e574092502();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_c9802b5780604c32a78a56e574092502();
            }
</script>
*)

