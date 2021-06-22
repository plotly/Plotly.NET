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
<div id="d1fca62f-d810-410c-a4d2-f14cbeb84889" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_d1fca62fd810410ca4d2f14cbeb84889 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"bar","x":["Product A","Product B","Product C"],"y":[20,14,23],"marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('d1fca62f-d810-410c-a4d2-f14cbeb84889', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_d1fca62fd810410ca4d2f14cbeb84889();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_d1fca62fd810410ca4d2f14cbeb84889();
            }
</script>
*)
(**
### Bar Charts
*)
let bar =
    Chart.Bar(keys,values)(* output: 
<div id="df0b37ac-929a-42de-9e33-f2538b615928" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_df0b37ac929a42de9e33f2538b615928 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"bar","x":[20,14,23],"y":["Product A","Product B","Product C"],"orientation":"h","marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('df0b37ac-929a-42de-9e33-f2538b615928', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_df0b37ac929a42de9e33f2538b615928();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_df0b37ac929a42de9e33f2538b615928();
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
<div id="58e97670-d251-4209-9e5e-799369ed33de" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_58e97670d25142099e5e799369ed33de = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"bar","x":[20,14,23],"y":["Product A","Product B","Product C"],"orientation":"h","marker":{},"name":"old"},{"type":"bar","x":[8,21,13],"y":["Product A","Product B","Product C"],"orientation":"h","marker":{},"name":"new"}];
            var layout = {"barmode":"stack"};
            var config = {};
            Plotly.newPlot('58e97670-d251-4209-9e5e-799369ed33de', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_58e97670d25142099e5e799369ed33de();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_58e97670d25142099e5e799369ed33de();
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
<div id="356357fc-88d4-46a8-9b9d-b3ec73921163" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_356357fc88d446a89b9db3ec73921163 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"bar","x":["Product A","Product B","Product C"],"y":[20,14,23],"marker":{},"name":"old"},{"type":"bar","x":["Product A","Product B","Product C"],"y":[8,21,13],"marker":{},"name":"new"}];
            var layout = {"barmode":"stack"};
            var config = {};
            Plotly.newPlot('356357fc-88d4-46a8-9b9d-b3ec73921163', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_356357fc88d446a89b9db3ec73921163();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_356357fc88d446a89b9db3ec73921163();
            }
</script>
*)

