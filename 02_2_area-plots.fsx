(**
// can't yet format YamlFrontmatter (["title: Area charts"; "category: Simple Charts"; "categoryindex: 3"; "index: 3"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# Area charts

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=02_2_area-plots.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/02_2_area-plots.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/02_2_area-plots.ipynb)

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
<div id="695c29ba-c793-4ae0-ae7d-a3e2b855b98f" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_695c29bac7934ae0ae7da3e2b855b98f = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","mode":"lines","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[5.0,2.5,5.0,7.5,5.0,2.5,7.5,4.5,5.5,5.0],"fill":"tozeroy","line":{},"marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('695c29ba-c793-4ae0-ae7d-a3e2b855b98f', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_695c29bac7934ae0ae7da3e2b855b98f();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_695c29bac7934ae0ae7da3e2b855b98f();
            }
</script>
*)
(**
### Area chart with a spline

*)
let area2 =
    Chart.SplineArea(x,y)(* output: 
<div id="5a5a5711-28d9-45bc-9d88-a70c45dae1d0" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_5a5a571128d945bc9d88a70c45dae1d0 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","mode":"lines","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[5.0,2.5,5.0,7.5,5.0,2.5,7.5,4.5,5.5,5.0],"fill":"tozeroy","line":{"shape":"spline"},"marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('5a5a5711-28d9-45bc-9d88-a70c45dae1d0', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_5a5a571128d945bc9d88a70c45dae1d0();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_5a5a571128d945bc9d88a70c45dae1d0();
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
<div id="9cc80cee-454f-4a49-9758-9a11a5d9aa00" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_9cc80cee454f4a4997589a11a5d9aa00 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","mode":"lines","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[5.0,2.5,5.0,7.5,5.0,2.5,7.5,4.5,5.5,5.0],"line":{},"marker":{},"stackgroup":"static"},{"type":"scatter","mode":"lines","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[5.0,5.5,4.5,7.5,2.5,5.0,7.5,5.0,2.5,5.0],"line":{},"marker":{},"stackgroup":"static"}];
            var layout = {};
            var config = {};
            Plotly.newPlot('9cc80cee-454f-4a49-9758-9a11a5d9aa00', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_9cc80cee454f4a4997589a11a5d9aa00();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_9cc80cee454f4a4997589a11a5d9aa00();
            }
</script>
*)

