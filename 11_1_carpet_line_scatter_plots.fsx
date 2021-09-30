(**
// can't yet format YamlFrontmatter (["title: Carpet line and scatter plots"; "category: Carpet Plots"; "categoryindex: 12"; "index: 1"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# Carpet charts

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=11_1_carpet_line_scatter_plots.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/11_1_carpet_line_scatter_plots.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/11_1_carpet_line_scatter_plots.ipynb)

*Summary:* This example shows how to create carpet charts in F#.

let's first create some data for the purpose of creating example charts:


*)
open Plotly.NET 
  
//carpet coordinate data
let a = [4.; 4.; 4.; 4.5; 4.5; 4.5; 5.; 5.; 5.; 6.; 6.; 6.]
let b = [1.; 2.; 3.; 1.; 2.; 3.; 1.; 2.; 3.; 1.; 2.; 3.]
let y = [2.; 3.5; 4.; 3.; 4.5; 5.; 5.5; 6.5; 7.5; 8.; 8.5; 10.]

//carpet plot data
let aData = [4.; 5.; 5.; 6.]
let bData = [1.; 1.; 2.; 3.]
let sizes = [5; 10; 15; 20]
(**
A carpet plot is any of a few different specific types of plot. The more common plot referred to as a carpet plot is one that illustrates the interaction between two or more independent variables and one or more dependent variables in a two-dimensional plot. 

Besides the ability to incorporate more variables, another feature that distinguishes a carpet plot from an equivalent contour plot or 3D surface plot is that a carpet plot can be used to more accurately interpolate data points. 

A conventional carpet plot can capture the interaction of up to three independent variables and three dependent variables and still be easily read and interpolated.

Carpet plots have common applications within areas such as material science for showing elastic modulus in laminates,and within aeronautics.

A carpet plot with two independent variables and one dependent variable is often called a cheater plot for the use of a phantom "cheater" axis instead of the horizontal axis. 

(https://en.wikipedia.org/wiki/Carpet_plot)

## Carpet Traces

In plotly, carpet plots are different to all other trace types in the regard that the coordinate system of the carpet is not set on the layout, but is itself a trace.

Use `Chart.Carpet` to define these `coordinate traces`. All carpets have a mandatory identifier, which will be used by other traces to define which carpet coordinate system to use.

*)
let carpet = Chart.Carpet("carpetIdentifier", A = a, B = b, Y = y)(* output: 
<div id="7f66a251-b753-40e9-ac74-eb19fe2ebfa9" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_7f66a251b75340e9ac74eb19fe2ebfa9 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"carpet","y":[2.0,3.5,4.0,3.0,4.5,5.0,5.5,6.5,7.5,8.0,8.5,10.0],"a":[4.0,4.0,4.0,4.5,4.5,4.5,5.0,5.0,5.0,6.0,6.0,6.0],"b":[1.0,2.0,3.0,1.0,2.0,3.0,1.0,2.0,3.0,1.0,2.0,3.0],"carpet":"carpetIdentifier"}];
            var layout = {};
            var config = {};
            Plotly.newPlot('7f66a251-b753-40e9-ac74-eb19fe2ebfa9', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_7f66a251b75340e9ac74eb19fe2ebfa9();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_7f66a251b75340e9ac74eb19fe2ebfa9();
            }
</script>
*)
(**
## Carpet point charts

use `Chart.PointCarpet` to create a point plot on the referenced carpet coordinate system:

*)
let carpetPoint = 
    [
        carpet
        Chart.PointCarpet(aData,bData,"carpetIdentifier", Name = "Point")
    ]
    |> Chart.combine(* output: 
<div id="cb9ffa90-b2ca-4030-91d3-db7117a5d9ce" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_cb9ffa90b2ca403091d3db7117a5d9ce = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"carpet","y":[2.0,3.5,4.0,3.0,4.5,5.0,5.5,6.5,7.5,8.0,8.5,10.0],"a":[4.0,4.0,4.0,4.5,4.5,4.5,5.0,5.0,5.0,6.0,6.0,6.0],"b":[1.0,2.0,3.0,1.0,2.0,3.0,1.0,2.0,3.0,1.0,2.0,3.0],"carpet":"carpetIdentifier"},{"type":"scattercarpet","name":"Point","mode":"markers","a":[4.0,5.0,5.0,6.0],"b":[1.0,1.0,2.0,3.0],"carpet":"carpetIdentifier","marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('cb9ffa90-b2ca-4030-91d3-db7117a5d9ce', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_cb9ffa90b2ca403091d3db7117a5d9ce();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_cb9ffa90b2ca403091d3db7117a5d9ce();
            }
</script>
*)
(**
## Carpet line charts

use `Chart.LineCarpet` to create a line plot on the referenced carpet coordinate system:

*)
let carpetLine = 
    [
        carpet
        Chart.LineCarpet(aData,bData,"carpetIdentifier",Name = "Line")
    ]
    |> Chart.combine(* output: 
<div id="c32fd3d4-0c54-48a4-a80a-135f821c8dc7" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_c32fd3d40c5448a4a80a135f821c8dc7 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"carpet","y":[2.0,3.5,4.0,3.0,4.5,5.0,5.5,6.5,7.5,8.0,8.5,10.0],"a":[4.0,4.0,4.0,4.5,4.5,4.5,5.0,5.0,5.0,6.0,6.0,6.0],"b":[1.0,2.0,3.0,1.0,2.0,3.0,1.0,2.0,3.0,1.0,2.0,3.0],"carpet":"carpetIdentifier"},{"type":"scattercarpet","name":"Line","mode":"lines","a":[4.0,5.0,5.0,6.0],"b":[1.0,1.0,2.0,3.0],"carpet":"carpetIdentifier","marker":{},"line":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('c32fd3d4-0c54-48a4-a80a-135f821c8dc7', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_c32fd3d40c5448a4a80a135f821c8dc7();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_c32fd3d40c5448a4a80a135f821c8dc7();
            }
</script>
*)
(**
## Carpet Spline charts

use `Chart.LineCarpet` to create a spline plot on the referenced carpet coordinate system:

*)
let carpetSpline = 
    [
        carpet
        Chart.SplineCarpet(aData,bData,"carpetIdentifier",Name = "Spline")
    ]
    |> Chart.combine(* output: 
<div id="4109173a-99e3-486a-8eb0-5abad12160a4" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_4109173a99e3486a8eb05abad12160a4 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"carpet","y":[2.0,3.5,4.0,3.0,4.5,5.0,5.5,6.5,7.5,8.0,8.5,10.0],"a":[4.0,4.0,4.0,4.5,4.5,4.5,5.0,5.0,5.0,6.0,6.0,6.0],"b":[1.0,2.0,3.0,1.0,2.0,3.0,1.0,2.0,3.0,1.0,2.0,3.0],"carpet":"carpetIdentifier"},{"type":"scattercarpet","name":"Spline","mode":"lines","a":[4.0,5.0,5.0,6.0],"b":[1.0,1.0,2.0,3.0],"carpet":"carpetIdentifier","marker":{},"line":{"shape":"spline"}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('4109173a-99e3-486a-8eb0-5abad12160a4', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_4109173a99e3486a8eb05abad12160a4();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_4109173a99e3486a8eb05abad12160a4();
            }
</script>
*)
(**
## Carpet bubble charts

use `Chart.LineCarpet` to create a bubble plot on the referenced carpet coordinate system:

*)
let carpetBubble = 
    [
        carpet
        Chart.BubbleCarpet((Seq.zip3 aData bData sizes),"carpetIdentifier",Name = "Bubble")
    ]
    |> Chart.combine(* output: 
<div id="1cf32bf0-8e69-4a64-a4ed-ca71b933da53" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_1cf32bf08e694a64a4edca71b933da53 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"carpet","y":[2.0,3.5,4.0,3.0,4.5,5.0,5.5,6.5,7.5,8.0,8.5,10.0],"a":[4.0,4.0,4.0,4.5,4.5,4.5,5.0,5.0,5.0,6.0,6.0,6.0],"b":[1.0,2.0,3.0,1.0,2.0,3.0,1.0,2.0,3.0,1.0,2.0,3.0],"carpet":"carpetIdentifier"},{"type":"scattercarpet","name":"Bubble","mode":"markers","a":[4.0,5.0,5.0,6.0],"b":[1.0,1.0,2.0,3.0],"carpet":"carpetIdentifier","marker":{"size":[5,10,15,20]}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('1cf32bf0-8e69-4a64-a4ed-ca71b933da53', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_1cf32bf08e694a64a4edca71b933da53();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_1cf32bf08e694a64a4edca71b933da53();
            }
</script>
*)

