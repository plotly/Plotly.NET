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
<div id="80aa0460-0d6a-4edf-97ee-5c7506a42c89" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_80aa04600d6a4edf97ee5c7506a42c89 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[5.0,2.5,5.0,7.5,5.0,2.5,7.5,4.5,5.5,5.0],"mode":"lines","fill":"tozeroy","line":{},"marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('80aa0460-0d6a-4edf-97ee-5c7506a42c89', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_80aa04600d6a4edf97ee5c7506a42c89();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_80aa04600d6a4edf97ee5c7506a42c89();
            }
</script>
*)
(**
### Area chart with a spline
*)
let area2 =
    Chart.SplineArea(x,y)(* output: 
<div id="3b3add99-1594-4dbf-b5ec-9e47dde6ce77" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_3b3add9915944dbfb5ec9e47dde6ce77 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[5.0,2.5,5.0,7.5,5.0,2.5,7.5,4.5,5.5,5.0],"mode":"lines","fill":"tozeroy","line":{"shape":"spline"},"marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('3b3add99-1594-4dbf-b5ec-9e47dde6ce77', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_3b3add9915944dbfb5ec9e47dde6ce77();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_3b3add9915944dbfb5ec9e47dde6ce77();
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
    |> Chart.Combine(* output: 
<div id="25463b47-3a14-49ba-a281-9f1bb91d231e" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_25463b473a1449baa2819f1bb91d231e = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[5.0,2.5,5.0,7.5,5.0,2.5,7.5,4.5,5.5,5.0],"mode":"lines","line":{},"marker":{},"stackgroup":"static"},{"type":"scatter","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[5.0,5.5,4.5,7.5,2.5,5.0,7.5,5.0,2.5,5.0],"mode":"lines","line":{},"marker":{},"stackgroup":"static"}];
            var layout = {};
            var config = {};
            Plotly.newPlot('25463b47-3a14-49ba-a281-9f1bb91d231e', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_25463b473a1449baa2819f1bb91d231e();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_25463b473a1449baa2819f1bb91d231e();
            }
</script>
*)

