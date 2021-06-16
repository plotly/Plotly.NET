(**
// can't yet format YamlFrontmatter (["title: Violin plots"; "category: Distribution Charts"; "categoryindex: 5"; "index: 3"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# Violin plots

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=4_2_violin-plots.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/4_2_violin-plots.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/4_2_violin-plots.ipynb)

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
<div id="c59a1394-6c31-4792-b869-7d122c22c2c1" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_c59a13946c314792b8697d122c22c2c1 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"violin","y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"x":["bin1","bin2","bin1","bin2","bin1","bin2","bin1","bin1","bin2","bin1"],"points":"all","marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('c59a1394-6c31-4792-b869-7d122c22c2c1', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_c59a13946c314792b8697d122c22c2c1();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_c59a13946c314792b8697d122c22c2c1();
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
<div id="80d75137-21ff-4170-8bcd-b01f0a783f69" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_80d7513721ff41708bcdb01f0a783f69 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"violin","y":["bin1","bin2","bin1","bin2","bin1","bin2","bin1","bin1","bin2","bin1"],"x":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"points":"all","jitter":0.1,"orientation":"h","meanline":{"visible":true},"marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('80d75137-21ff-4170-8bcd-b01f0a783f69', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_80d7513721ff41708bcdb01f0a783f69();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_80d7513721ff41708bcdb01f0a783f69();
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
<div id="06f2783c-b35f-4beb-958a-ab3289c09357" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_06f2783cb35f4beb958aab3289c09357 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"violin","y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"x":"y","points":"all","jitter":0.1,"name":"bin1","marker":{}},{"type":"violin","y":[2.0,1.5,5.0,1.5,2.0,2.5,2.1,2.5,1.5,1.0,2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"x":"y'","points":"all","jitter":0.1,"name":"bin2","marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('06f2783c-b35f-4beb-958a-ab3289c09357', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_06f2783cb35f4beb958aab3289c09357();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_06f2783cb35f4beb958aab3289c09357();
            }
</script>
*)

