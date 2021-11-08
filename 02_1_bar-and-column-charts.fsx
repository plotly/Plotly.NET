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
<div id="ddd14886-9424-411d-8aff-7c27c5c1e777" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_ddd148869424411d8aff7c27c5c1e777 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"bar","x":["Product A","Product B","Product C"],"y":[20,14,23],"orientation":"v","marker":{"pattern":{}}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('ddd14886-9424-411d-8aff-7c27c5c1e777', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_ddd148869424411d8aff7c27c5c1e777();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_ddd148869424411d8aff7c27c5c1e777();
            }
</script>
*)
(**
### Bar Charts

*)
let bar =
    Chart.Bar(values,keys)(* output: 
<div id="f6eb5d65-e6a1-4833-a404-1d466341243d" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_f6eb5d65e6a14833a4041d466341243d = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"bar","x":[20,14,23],"y":["Product A","Product B","Product C"],"orientation":"h","marker":{"pattern":{}}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('f6eb5d65-e6a1-4833-a404-1d466341243d', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_f6eb5d65e6a14833a4041d466341243d();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_f6eb5d65e6a14833a4041d466341243d();
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
<div id="7e41c3d6-9e08-47d5-b53a-2a0a5fcfa437" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_7e41c3d69e0847d5b53a2a0a5fcfa437 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"bar","name":"old","x":[20,14,23],"y":["Product A","Product B","Product C"],"orientation":"h","marker":{"pattern":{}}},{"type":"bar","name":"new","x":[8,21,13],"y":["Product A","Product B","Product C"],"orientation":"h","marker":{"pattern":{}}}];
            var layout = {"barmode":"stack"};
            var config = {};
            Plotly.newPlot('7e41c3d6-9e08-47d5-b53a-2a0a5fcfa437', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_7e41c3d69e0847d5b53a2a0a5fcfa437();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_7e41c3d69e0847d5b53a2a0a5fcfa437();
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
<div id="8d8e9526-2752-4924-9c34-2cf334441233" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_8d8e9526275249249c342cf334441233 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"bar","name":"old","x":["Product A","Product B","Product C"],"y":[20,14,23],"orientation":"v","marker":{"pattern":{}}},{"type":"bar","name":"new","x":["Product A","Product B","Product C"],"y":[8,21,13],"orientation":"v","marker":{"pattern":{}}}];
            var layout = {"barmode":"stack"};
            var config = {};
            Plotly.newPlot('8d8e9526-2752-4924-9c34-2cf334441233', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_8d8e9526275249249c342cf334441233();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_8d8e9526275249249c342cf334441233();
            }
</script>
*)

