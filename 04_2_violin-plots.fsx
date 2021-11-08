(**
// can't yet format YamlFrontmatter (["title: Violin plots"; "category: Distribution Charts"; "categoryindex: 5"; "index: 3"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# Violin plots

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=04_2_violin-plots.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/04_2_violin-plots.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/04_2_violin-plots.ipynb)

*Summary:* This example shows how to create violin plot charts in F#.

let's first create some data for the purpose of creating example charts:


*)
open Plotly.NET 
  
let y =  [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
let x = ["bin1";"bin2";"bin1";"bin2";"bin1";"bin2";"bin1";"bin1";"bin2";"bin1"]
(**
A violin plot is a method of plotting numeric data. It is similar to box plot with a rotated kernel density plot 
on each side. The violin plot is similar to box plots, except that they also show the probability density of the 
data at different values.

*)
let violin1 =
    Chart.Violin (
        x,y,
        Points=StyleParam.JitterPoints.All
    )(* output: 
<div id="a90be2bd-16fa-4276-b9d1-5991a0975543" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_a90be2bd16fa4276b9d15991a0975543 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"violin","x":["bin1","bin2","bin1","bin2","bin1","bin2","bin1","bin1","bin2","bin1"],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"box":{},"points":"all","marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('a90be2bd-16fa-4276-b9d1-5991a0975543', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_a90be2bd16fa4276b9d15991a0975543();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_a90be2bd16fa4276b9d15991a0975543();
            }
</script>
*)
(**
By swapping x and y plus using `StyleParam.Orientation.Horizontal` we can flip the chart horizontaly.

*)
open Plotly.NET.TraceObjects

let violin2 =
    Chart.Violin(
        y,x,
        Jitter=0.1,
        Points=StyleParam.JitterPoints.All,
        Orientation=StyleParam.Orientation.Horizontal,
        MeanLine=MeanLine.init(Visible=true)
    )(* output: 
<div id="3cf6b372-5a2a-4f48-8115-c3431d618f62" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_3cf6b3725a2a4f488115c3431d618f62 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"violin","x":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"y":["bin1","bin2","bin1","bin2","bin1","bin2","bin1","bin1","bin2","bin1"],"orientation":"h","box":{},"jitter":0.1,"meanline":{"visible":true},"points":"all","marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('3cf6b372-5a2a-4f48-8115-c3431d618f62', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_3cf6b3725a2a4f488115c3431d618f62();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_3cf6b3725a2a4f488115c3431d618f62();
            }
</script>
*)
(**
You can also produce a violin plot using the `Chart.Combine` syntax.

*)
let y' =  [2.; 1.5; 5.; 1.5; 2.; 2.5; 2.1; 2.5; 1.5; 1.;2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]

let violin3 =
    [
        Chart.Violin ("y" ,y,Name="bin1",Jitter=0.1,Points=StyleParam.JitterPoints.All);
        Chart.Violin ("y'",y',Name="bin2",Jitter=0.1,Points=StyleParam.JitterPoints.All);
    ]
    |> Chart.combine(* output: 
<div id="84d039a7-cd13-4f71-a28c-31dfd92a869d" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_84d039a7cd134f71a28c31dfd92a869d = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"violin","name":"bin1","x":"y","y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"box":{},"jitter":0.1,"points":"all","marker":{}},{"type":"violin","name":"bin2","x":"y'","y":[2.0,1.5,5.0,1.5,2.0,2.5,2.1,2.5,1.5,1.0,2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"box":{},"jitter":0.1,"points":"all","marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('84d039a7-cd13-4f71-a28c-31dfd92a869d', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_84d039a7cd134f71a28c31dfd92a869d();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_84d039a7cd134f71a28c31dfd92a869d();
            }
</script>
*)

