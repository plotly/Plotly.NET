(**
// can't yet format YamlFrontmatter (["title: Bar and column charts"; "category: Simple Charts"; "categoryindex: 3"; "index: 2"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# Bar and column charts

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=2_1_bar-and-column-charts.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/2_1_bar-and-column-charts.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/2_1_bar-and-column-charts.ipynb)

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
<div id="2d26b4e0-df6a-4ef4-b854-81b7c935d2eb" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_2d26b4e0df6a4ef4b85481b7c935d2eb = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"bar","x":["Product A","Product B","Product C"],"y":[20,14,23],"marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('2d26b4e0-df6a-4ef4-b854-81b7c935d2eb', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_2d26b4e0df6a4ef4b85481b7c935d2eb();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_2d26b4e0df6a4ef4b85481b7c935d2eb();
            }
</script>
*)
(**
### Bar Charts
*)
let bar =
    Chart.Bar(keys,values)(* output: 
<div id="0b27d9a1-ba6c-4f27-899a-52ca210057bc" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_0b27d9a1ba6c4f27899a52ca210057bc = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"bar","x":[20,14,23],"y":["Product A","Product B","Product C"],"orientation":"h","marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('0b27d9a1-ba6c-4f27-899a-52ca210057bc', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_0b27d9a1ba6c4f27899a52ca210057bc();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_0b27d9a1ba6c4f27899a52ca210057bc();
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
<div id="275a7ed9-65e1-4bf9-8ac1-1619515613c2" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_275a7ed965e14bf98ac11619515613c2 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"bar","x":[20,14,23],"y":["Product A","Product B","Product C"],"orientation":"h","marker":{},"name":"old"},{"type":"bar","x":[8,21,13],"y":["Product A","Product B","Product C"],"orientation":"h","marker":{},"name":"new"}];
            var layout = {"barmode":"stack"};
            var config = {};
            Plotly.newPlot('275a7ed9-65e1-4bf9-8ac1-1619515613c2', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_275a7ed965e14bf98ac11619515613c2();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_275a7ed965e14bf98ac11619515613c2();
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
<div id="e1736b72-2d25-41cd-b61b-32215b15e8e7" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_e1736b722d2541cdb61b32215b15e8e7 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"bar","x":["Product A","Product B","Product C"],"y":[20,14,23],"marker":{},"name":"old"},{"type":"bar","x":["Product A","Product B","Product C"],"y":[8,21,13],"marker":{},"name":"new"}];
            var layout = {"barmode":"stack"};
            var config = {};
            Plotly.newPlot('e1736b72-2d25-41cd-b61b-32215b15e8e7', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_e1736b722d2541cdb61b32215b15e8e7();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_e1736b722d2541cdb61b32215b15e8e7();
            }
</script>
*)

