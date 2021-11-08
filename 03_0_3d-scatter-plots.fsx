(**
// can't yet format YamlFrontmatter (["title: 3D point and line charts"; "category: 3D Charts"; "categoryindex: 4"; "index: 1"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# 3D point plots

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=03_0_3d-scatter-plots.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/03_0_3d-scatter-plots.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/03_0_3d-scatter-plots.ipynb)

*Summary:* This example shows how to create three-dimensional point and line charts in F#.

A Scatter3d chart report shows a three-dimensional spinnable view of your data

*)
open Plotly.NET 
  
let point3d = 
    Chart.Point3d(
        [1,3,2; 6,5,4; 7,9,8],
        Labels = ["A"; "B"; "C"],
        TextPosition = StyleParam.TextPosition.BottomCenter
    )
    |> Chart.withXAxisStyle("my x-axis", Id=StyleParam.SubPlotId.Scene 1) // in contrast to 2D plots, x and y axes of 3D charts have to be set via the scene object
    |> Chart.withYAxisStyle("my y-axis", Id=StyleParam.SubPlotId.Scene 1) // in contrast to 2D plots, x and y axes of 3D charts have to be set via the scene object
    |> Chart.withZAxisStyle("my z-axis")
    |> Chart.withSize(800.,800.)(* output: 
<div id="6ecb468e-6cf3-4093-a560-c90094fd630f" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_6ecb468e6cf34093a560c90094fd630f = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter3d","mode":"markers+text","x":[1,6,7],"y":[3,5,9],"z":[2,4,8],"line":{},"marker":{},"text":["A","B","C"],"textposition":"bottom center"}];
            var layout = {"scene":{"xaxis":{"title":{"text":"my x-axis"}},"yaxis":{"title":{"text":"my y-axis"}},"zaxis":{"title":{"text":"my z-axis"}}},"width":800,"height":800};
            var config = {};
            Plotly.newPlot('6ecb468e-6cf3-4093-a560-c90094fd630f', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_6ecb468e6cf34093a560c90094fd630f();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_6ecb468e6cf34093a560c90094fd630f();
            }
</script>
*)
(**
# 3D Line plots

*)
let line3d = 
    Chart.Line3d(
        [1,3,2; 6,5,4; 7,9,8],
        Labels = ["A"; "B"; "C"],
        TextPosition = StyleParam.TextPosition.BottomCenter,
        ShowMarkers = true
    )(* output: 
<div id="696cf859-a653-41f6-a199-80290c2525ff" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_696cf859a65341f6a19980290c2525ff = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter3d","mode":"lines+markers+text","x":[1,6,7],"y":[3,5,9],"z":[2,4,8],"line":{},"marker":{},"text":["A","B","C"],"textposition":"bottom center"}];
            var layout = {};
            var config = {};
            Plotly.newPlot('696cf859-a653-41f6-a199-80290c2525ff', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_696cf859a65341f6a19980290c2525ff();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_696cf859a65341f6a19980290c2525ff();
            }
</script>
*)
(**
# 3D Bubble plots

*)
let bubble3d =
    Chart.Bubble3d(
        [1,3,2; 6,5,4; 7,9,8],
        [10;20;30],
        Labels = ["A"; "B"; "C"],
        TextPosition = StyleParam.TextPosition.BottomCenter
    )(* output: 
<div id="9a8013b9-ad3e-457d-a7b8-54dbf8bfebdd" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_9a8013b9ad3e457da7b854dbf8bfebdd = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter3d","mode":"markers+text","x":[1,6,7],"y":[3,5,9],"z":[2,4,8],"marker":{"size":[10,20,30]},"text":["A","B","C"],"textposition":"bottom center"}];
            var layout = {};
            var config = {};
            Plotly.newPlot('9a8013b9-ad3e-457d-a7b8-54dbf8bfebdd', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_9a8013b9ad3e457da7b854dbf8bfebdd();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_9a8013b9ad3e457da7b854dbf8bfebdd();
            }
</script>
*)

