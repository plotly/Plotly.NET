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
<div id="257a16cb-20e1-448a-bbc8-527efb9b38f2" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_257a16cb20e1448abbc8527efb9b38f2 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"violin","y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"x":["bin1","bin2","bin1","bin2","bin1","bin2","bin1","bin1","bin2","bin1"],"points":"all","marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('257a16cb-20e1-448a-bbc8-527efb9b38f2', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_257a16cb20e1448abbc8527efb9b38f2();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_257a16cb20e1448abbc8527efb9b38f2();
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
<div id="9492dee1-8445-4701-9096-da2e671c2dd3" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_9492dee1844547019096da2e671c2dd3 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"violin","y":["bin1","bin2","bin1","bin2","bin1","bin2","bin1","bin1","bin2","bin1"],"x":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"points":"all","jitter":0.1,"orientation":"h","meanline":{"visible":true},"marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('9492dee1-8445-4701-9096-da2e671c2dd3', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_9492dee1844547019096da2e671c2dd3();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_9492dee1844547019096da2e671c2dd3();
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
<div id="87393557-9918-4c80-a460-1b41272171a4" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_8739355799184c80a4601b41272171a4 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"violin","y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"x":"y","points":"all","jitter":0.1,"name":"bin1","marker":{}},{"type":"violin","y":[2.0,1.5,5.0,1.5,2.0,2.5,2.1,2.5,1.5,1.0,2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"x":"y'","points":"all","jitter":0.1,"name":"bin2","marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('87393557-9918-4c80-a460-1b41272171a4', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_8739355799184c80a4601b41272171a4();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_8739355799184c80a4601b41272171a4();
            }
</script>
*)

