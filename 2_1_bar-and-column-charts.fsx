(**
// can't yet format YamlFrontmatter (["title: Bar and column charts"; "category: Simple Charts"; "categoryindex: 3"; "index: 2"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# Bar and column charts

[![Binder](https://plotly.github.io/Plotly.NET/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=2_1_bar-and-column-charts.ipynb)&emsp;
[![Script](https://plotly.github.io/Plotly.NET/img/badge-script.svg)](https://plotly.github.io/Plotly.NET/2_1_bar-and-column-charts.fsx)&emsp;
[![Notebook](https://plotly.github.io/Plotly.NET/img/badge-notebook.svg)](https://plotly.github.io/Plotly.NET/2_1_bar-and-column-charts.ipynb)

*Summary:* This example shows how to create bar and a column charts in F#.

let's first create some data for the purpose of creating example charts:
*)
open Plotly.NET 
  
let values = [20; 14; 23;]
let keys   = ["Product A"; "Product B"; "Product C";]
(**
A bar chart or bar graph is a chart that presents grouped data with rectangular bars with 
lengths proportional to the values that they represent. The bars can be plotted vertically
or horizontally. A vertical bar chart is called a column bar chart.

### Column Charts
*)
let column = Chart.Column(keys,values)(* output: 
<div id="48256bae-02cc-407a-bcc7-45c70238d041" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_48256bae02cc407abcc745c70238d041 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"bar","x":["Product A","Product B","Product C"],"y":[20,14,23],"marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('48256bae-02cc-407a-bcc7-45c70238d041', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_48256bae02cc407abcc745c70238d041();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_48256bae02cc407abcc745c70238d041();
            }
</script>
*)
(**
### Bar Charts
*)
let bar =
    Chart.Bar(keys,values)(* output: 
<div id="e3bc4e1e-564d-48b4-a46e-a5472b5667b8" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_e3bc4e1e564d48b4a46ea5472b5667b8 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"bar","x":[20,14,23],"y":["Product A","Product B","Product C"],"orientation":"h","marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('e3bc4e1e-564d-48b4-a46e-a5472b5667b8', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_e3bc4e1e564d48b4a46ea5472b5667b8();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_e3bc4e1e564d48b4a46ea5472b5667b8();
            }
</script>
*)
(**
## Stacked bar chart or column charts
The following example shows how to create a stacked bar chart by combining bar charts created by combining multiple `Chart.StackedBar` charts: 

### Stacked bar Charts
*)
let stackedBar =
    [
        Chart.StackedBar(keys,values,Name="old");
        Chart.StackedBar(keys,[8; 21; 13;],Name="new")
    ]
    |> Chart.Combine(* output: 
<div id="c622c665-69d1-4a9d-8ad5-4f2da431c38a" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_c622c66569d14a9d8ad54f2da431c38a = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"bar","x":[20,14,23],"y":["Product A","Product B","Product C"],"orientation":"h","marker":{},"name":"old"},{"type":"bar","x":[8,21,13],"y":["Product A","Product B","Product C"],"orientation":"h","marker":{},"name":"new"}];
            var layout = {"barmode":"stack"};
            var config = {};
            Plotly.newPlot('c622c665-69d1-4a9d-8ad5-4f2da431c38a', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_c622c66569d14a9d8ad54f2da431c38a();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_c622c66569d14a9d8ad54f2da431c38a();
            }
</script>
*)
(*
### Stacked bar Charts
*)

let stackedColumn =
    [
        Chart.StackedColumn(keys,values,Name="old");
        Chart.StackedColumn(keys,[8; 21; 13;],Name="new")
    ]
    |> Chart.Combine(* output: 
<div id="9d126f7a-d414-4305-9428-cdb2152ab53e" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_9d126f7ad41443059428cdb2152ab53e = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"bar","x":["Product A","Product B","Product C"],"y":[20,14,23],"marker":{},"name":"old"},{"type":"bar","x":["Product A","Product B","Product C"],"y":[8,21,13],"marker":{},"name":"new"}];
            var layout = {"barmode":"stack"};
            var config = {};
            Plotly.newPlot('9d126f7a-d414-4305-9428-cdb2152ab53e', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_9d126f7ad41443059428cdb2152ab53e();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_9d126f7ad41443059428cdb2152ab53e();
            }
</script>
*)

