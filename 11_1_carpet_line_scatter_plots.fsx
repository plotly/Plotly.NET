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
<div id="8e760029-d65f-447e-b679-7a3f9af2f92c" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_8e760029d65f447eb6797a3f9af2f92c = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"carpet","y":[2.0,3.5,4.0,3.0,4.5,5.0,5.5,6.5,7.5,8.0,8.5,10.0],"a":[4.0,4.0,4.0,4.5,4.5,4.5,5.0,5.0,5.0,6.0,6.0,6.0],"b":[1.0,2.0,3.0,1.0,2.0,3.0,1.0,2.0,3.0,1.0,2.0,3.0],"carpet":"carpetIdentifier"}];
            var layout = {};
            var config = {};
            Plotly.newPlot('8e760029-d65f-447e-b679-7a3f9af2f92c', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_8e760029d65f447eb6797a3f9af2f92c();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_8e760029d65f447eb6797a3f9af2f92c();
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
<div id="cd77e66a-34b9-433f-8d91-a4d6ec1826a2" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_cd77e66a34b9433f8d91a4d6ec1826a2 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"carpet","y":[2.0,3.5,4.0,3.0,4.5,5.0,5.5,6.5,7.5,8.0,8.5,10.0],"a":[4.0,4.0,4.0,4.5,4.5,4.5,5.0,5.0,5.0,6.0,6.0,6.0],"b":[1.0,2.0,3.0,1.0,2.0,3.0,1.0,2.0,3.0,1.0,2.0,3.0],"carpet":"carpetIdentifier"},{"type":"scattercarpet","name":"Point","mode":"markers","a":[4.0,5.0,5.0,6.0],"b":[1.0,1.0,2.0,3.0],"carpet":"carpetIdentifier","marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('cd77e66a-34b9-433f-8d91-a4d6ec1826a2', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_cd77e66a34b9433f8d91a4d6ec1826a2();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_cd77e66a34b9433f8d91a4d6ec1826a2();
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
<div id="f7475a09-da7e-4f12-a142-a411497487e6" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_f7475a09da7e4f12a142a411497487e6 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"carpet","y":[2.0,3.5,4.0,3.0,4.5,5.0,5.5,6.5,7.5,8.0,8.5,10.0],"a":[4.0,4.0,4.0,4.5,4.5,4.5,5.0,5.0,5.0,6.0,6.0,6.0],"b":[1.0,2.0,3.0,1.0,2.0,3.0,1.0,2.0,3.0,1.0,2.0,3.0],"carpet":"carpetIdentifier"},{"type":"scattercarpet","name":"Line","mode":"lines","a":[4.0,5.0,5.0,6.0],"b":[1.0,1.0,2.0,3.0],"carpet":"carpetIdentifier","marker":{},"line":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('f7475a09-da7e-4f12-a142-a411497487e6', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_f7475a09da7e4f12a142a411497487e6();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_f7475a09da7e4f12a142a411497487e6();
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
<div id="09437e7d-71d7-4e80-ba47-f06c0844a119" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_09437e7d71d74e80ba47f06c0844a119 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"carpet","y":[2.0,3.5,4.0,3.0,4.5,5.0,5.5,6.5,7.5,8.0,8.5,10.0],"a":[4.0,4.0,4.0,4.5,4.5,4.5,5.0,5.0,5.0,6.0,6.0,6.0],"b":[1.0,2.0,3.0,1.0,2.0,3.0,1.0,2.0,3.0,1.0,2.0,3.0],"carpet":"carpetIdentifier"},{"type":"scattercarpet","name":"Spline","mode":"lines","a":[4.0,5.0,5.0,6.0],"b":[1.0,1.0,2.0,3.0],"carpet":"carpetIdentifier","marker":{},"line":{"shape":"spline"}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('09437e7d-71d7-4e80-ba47-f06c0844a119', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_09437e7d71d74e80ba47f06c0844a119();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_09437e7d71d74e80ba47f06c0844a119();
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
<div id="b50bdfce-7b38-4090-81ba-1c067379499c" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_b50bdfce7b38409081ba1c067379499c = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"carpet","y":[2.0,3.5,4.0,3.0,4.5,5.0,5.5,6.5,7.5,8.0,8.5,10.0],"a":[4.0,4.0,4.0,4.5,4.5,4.5,5.0,5.0,5.0,6.0,6.0,6.0],"b":[1.0,2.0,3.0,1.0,2.0,3.0,1.0,2.0,3.0,1.0,2.0,3.0],"carpet":"carpetIdentifier"},{"type":"scattercarpet","name":"Bubble","mode":"markers","a":[4.0,5.0,5.0,6.0],"b":[1.0,1.0,2.0,3.0],"carpet":"carpetIdentifier","marker":{"size":[5,10,15,20]}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('b50bdfce-7b38-4090-81ba-1c067379499c', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_b50bdfce7b38409081ba1c067379499c();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_b50bdfce7b38409081ba1c067379499c();
            }
</script>
*)

