(**
// can't yet format YamlFrontmatter (["title: Bar and column charts"; "category: Simple Charts"; "categoryindex: 3"; "index: 2"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# Bar and column charts

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=02_1_bar-and-column-charts.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/02_1_bar-and-column-charts.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/02_1_bar-and-column-charts.ipynb)

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
let column = Chart.Column(values,keys)(* output: 
<div id="98e108d3-422f-4728-916b-e41205c006ab" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_98e108d3422f4728916be41205c006ab = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"bar","x":["Product A","Product B","Product C"],"y":[20,14,23],"orientation":"v","marker":{"pattern":{}}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('98e108d3-422f-4728-916b-e41205c006ab', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_98e108d3422f4728916be41205c006ab();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_98e108d3422f4728916be41205c006ab();
            }
</script>
*)
(**
### Bar Charts

*)
let bar =
    Chart.Bar(values,keys)(* output: 
<div id="d3246d9b-8694-4bdd-b555-bfbe270093f1" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_d3246d9b86944bddb555bfbe270093f1 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"bar","x":[20,14,23],"y":["Product A","Product B","Product C"],"orientation":"h","marker":{"pattern":{}}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('d3246d9b-8694-4bdd-b555-bfbe270093f1', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_d3246d9b86944bddb555bfbe270093f1();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_d3246d9b86944bddb555bfbe270093f1();
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
        Chart.StackedBar(values,keys,Name="old");
        Chart.StackedBar([8; 21; 13;],keys,Name="new")
    ]
    |> Chart.combine(* output: 
<div id="9a65de00-c756-404a-acae-f84c2eed9296" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_9a65de00c756404aacaef84c2eed9296 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"bar","name":"old","x":[20,14,23],"y":["Product A","Product B","Product C"],"orientation":"h","marker":{"pattern":{}}},{"type":"bar","name":"new","x":[8,21,13],"y":["Product A","Product B","Product C"],"orientation":"h","marker":{"pattern":{}}}];
            var layout = {"barmode":"stack"};
            var config = {};
            Plotly.newPlot('9a65de00-c756-404a-acae-f84c2eed9296', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_9a65de00c756404aacaef84c2eed9296();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_9a65de00c756404aacaef84c2eed9296();
            }
</script>
*)
(*
### Stacked bar Charts
*)

let stackedColumn =
    [
        Chart.StackedColumn(values,keys,Name="old");
        Chart.StackedColumn([8; 21; 13;],keys,Name="new")
    ]
    |> Chart.combine(* output: 
<div id="a57f8177-1503-4a12-9c30-9c4adb85b487" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_a57f817715034a129c309c4adb85b487 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"bar","name":"old","x":["Product A","Product B","Product C"],"y":[20,14,23],"orientation":"v","marker":{"pattern":{}}},{"type":"bar","name":"new","x":["Product A","Product B","Product C"],"y":[8,21,13],"orientation":"v","marker":{"pattern":{}}}];
            var layout = {"barmode":"stack"};
            var config = {};
            Plotly.newPlot('a57f8177-1503-4a12-9c30-9c4adb85b487', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_a57f817715034a129c309c4adb85b487();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_a57f817715034a129c309c4adb85b487();
            }
</script>
*)

