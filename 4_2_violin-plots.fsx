(**
// can't yet format YamlFrontmatter (["title: Violin plots"; "category: Distribution Charts"; "categoryindex: 5"; "index: 3"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# Violin plots

[![Binder](https://plotly.github.io/Plotly.NET/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=4_2_violin-plots.ipynb)&emsp;
[![Script](https://plotly.github.io/Plotly.NET/img/badge-script.svg)](https://plotly.github.io/Plotly.NET/4_2_violin-plots.fsx)&emsp;
[![Notebook](https://plotly.github.io/Plotly.NET/img/badge-notebook.svg)](https://plotly.github.io/Plotly.NET/4_2_violin-plots.ipynb)

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
        Points=StyleParam.Jitterpoints.All
    )(* output: 
<div id="3fec9e4c-8c6e-4ef5-871c-35345f512136" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_3fec9e4c8c6e4ef5871c35345f512136 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"violin","y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"x":["bin1","bin2","bin1","bin2","bin1","bin2","bin1","bin1","bin2","bin1"],"points":"all","marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('3fec9e4c-8c6e-4ef5-871c-35345f512136', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_3fec9e4c8c6e4ef5871c35345f512136();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_3fec9e4c8c6e4ef5871c35345f512136();
            }
</script>
*)
(**
By swapping x and y plus using `StyleParam.Orientation.Horizontal` we can flip the chart horizontaly.
*)
let violin2 =
    Chart.Violin(
        y,x,
        Jitter=0.1,
        Points=StyleParam.Jitterpoints.All,
        Orientation=StyleParam.Orientation.Horizontal,
        Meanline=Meanline.init(Visible=true)
    )(* output: 
<div id="a009af05-82af-4250-b1c7-b71f6a7d1a73" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_a009af0582af4250b1c7b71f6a7d1a73 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"violin","y":["bin1","bin2","bin1","bin2","bin1","bin2","bin1","bin1","bin2","bin1"],"x":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"points":"all","jitter":0.1,"orientation":"h","meanline":{"visible":true},"marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('a009af05-82af-4250-b1c7-b71f6a7d1a73', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_a009af0582af4250b1c7b71f6a7d1a73();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_a009af0582af4250b1c7b71f6a7d1a73();
            }
</script>
*)
(**
You can also produce a violin plot using the `Chart.Combine` syntax.
*)
let y' =  [2.; 1.5; 5.; 1.5; 2.; 2.5; 2.1; 2.5; 1.5; 1.;2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]

let violin3 =
    [
        Chart.Violin ("y" ,y,Name="bin1",Jitter=0.1,Points=StyleParam.Jitterpoints.All);
        Chart.Violin ("y'",y',Name="bin2",Jitter=0.1,Points=StyleParam.Jitterpoints.All);
    ]
    |> Chart.Combine(* output: 
<div id="181ae95a-71d4-4a74-a8df-329c75e4c72a" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_181ae95a71d44a74a8df329c75e4c72a = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"violin","y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"x":"y","points":"all","jitter":0.1,"name":"bin1","marker":{}},{"type":"violin","y":[2.0,1.5,5.0,1.5,2.0,2.5,2.1,2.5,1.5,1.0,2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"x":"y'","points":"all","jitter":0.1,"name":"bin2","marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('181ae95a-71d4-4a74-a8df-329c75e4c72a', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_181ae95a71d44a74a8df329c75e4c72a();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_181ae95a71d44a74a8df329c75e4c72a();
            }
</script>
*)

