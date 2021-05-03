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
<div id="12d8f18e-1b0a-4a27-bac3-097144ce302b" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_12d8f18e1b0a4a27bac3097144ce302b = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"bar","x":["Product A","Product B","Product C"],"y":[20,14,23],"marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('12d8f18e-1b0a-4a27-bac3-097144ce302b', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_12d8f18e1b0a4a27bac3097144ce302b();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_12d8f18e1b0a4a27bac3097144ce302b();
            }
</script>
*)
(**
### Bar Charts
*)
let bar =
    Chart.Bar(keys,values)(* output: 
<div id="6028aba2-752d-471a-bf8c-f6a815911f96" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_6028aba2752d471abf8cf6a815911f96 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"bar","x":[20,14,23],"y":["Product A","Product B","Product C"],"orientation":"h","marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('6028aba2-752d-471a-bf8c-f6a815911f96', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_6028aba2752d471abf8cf6a815911f96();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_6028aba2752d471abf8cf6a815911f96();
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
<div id="0146a026-3038-478f-8645-f24cd9fd9187" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_0146a0263038478f8645f24cd9fd9187 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"bar","x":[20,14,23],"y":["Product A","Product B","Product C"],"orientation":"h","marker":{},"name":"old"},{"type":"bar","x":[8,21,13],"y":["Product A","Product B","Product C"],"orientation":"h","marker":{},"name":"new"}];
            var layout = {"barmode":"stack"};
            var config = {};
            Plotly.newPlot('0146a026-3038-478f-8645-f24cd9fd9187', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_0146a0263038478f8645f24cd9fd9187();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_0146a0263038478f8645f24cd9fd9187();
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
<div id="06f9df56-7efc-4a4d-822d-b533f030ad7e" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_06f9df567efc4a4d822db533f030ad7e = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"bar","x":["Product A","Product B","Product C"],"y":[20,14,23],"marker":{},"name":"old"},{"type":"bar","x":["Product A","Product B","Product C"],"y":[8,21,13],"marker":{},"name":"new"}];
            var layout = {"barmode":"stack"};
            var config = {};
            Plotly.newPlot('06f9df56-7efc-4a4d-822d-b533f030ad7e', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_06f9df567efc4a4d822db533f030ad7e();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_06f9df567efc4a4d822db533f030ad7e();
            }
</script>
*)

