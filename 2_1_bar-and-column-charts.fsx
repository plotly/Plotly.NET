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
<div id="f8d19891-2e0e-4104-a4ec-560f8feab12a" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_f8d198912e0e4104a4ec560f8feab12a = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"bar","x":["Product A","Product B","Product C"],"y":[20,14,23],"marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('f8d19891-2e0e-4104-a4ec-560f8feab12a', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_f8d198912e0e4104a4ec560f8feab12a();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_f8d198912e0e4104a4ec560f8feab12a();
            }
</script>
*)
(**
### Bar Charts
*)
let bar =
    Chart.Bar(keys,values)(* output: 
<div id="b59eb90a-629e-42bc-9b3e-0010f6da11cd" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_b59eb90a629e42bc9b3e0010f6da11cd = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"bar","x":[20,14,23],"y":["Product A","Product B","Product C"],"orientation":"h","marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('b59eb90a-629e-42bc-9b3e-0010f6da11cd', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_b59eb90a629e42bc9b3e0010f6da11cd();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_b59eb90a629e42bc9b3e0010f6da11cd();
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
    |> Chart.combine(* output: 
<div id="b54ade7e-ff81-48c3-93e5-62e7bb8e8244" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_b54ade7eff8148c393e562e7bb8e8244 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"bar","x":[20,14,23],"y":["Product A","Product B","Product C"],"orientation":"h","marker":{},"name":"old"},{"type":"bar","x":[8,21,13],"y":["Product A","Product B","Product C"],"orientation":"h","marker":{},"name":"new"}];
            var layout = {"barmode":"stack"};
            var config = {};
            Plotly.newPlot('b54ade7e-ff81-48c3-93e5-62e7bb8e8244', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_b54ade7eff8148c393e562e7bb8e8244();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_b54ade7eff8148c393e562e7bb8e8244();
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
    |> Chart.combine(* output: 
<div id="2801f7ca-3049-47d4-8de7-90da4526efb3" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_2801f7ca304947d48de790da4526efb3 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"bar","x":["Product A","Product B","Product C"],"y":[20,14,23],"marker":{},"name":"old"},{"type":"bar","x":["Product A","Product B","Product C"],"y":[8,21,13],"marker":{},"name":"new"}];
            var layout = {"barmode":"stack"};
            var config = {};
            Plotly.newPlot('2801f7ca-3049-47d4-8de7-90da4526efb3', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_2801f7ca304947d48de790da4526efb3();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_2801f7ca304947d48de790da4526efb3();
            }
</script>
*)

