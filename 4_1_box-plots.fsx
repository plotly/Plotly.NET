(**
// can't yet format YamlFrontmatter (["title: BoxPlots"; "category: Distribution Charts"; "categoryindex: 5"; "index: 2"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# BoxPlots

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=4_1_box-plots.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/4_1_box-plots.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/4_1_box-plots.ipynb)

*Summary:* This example shows how to create boxplot charts in F#.

let's first create some data for the purpose of creating example charts:
*)
open Plotly.NET 

let y =  [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
let x = ["bin1";"bin2";"bin1";"bin2";"bin1";"bin2";"bin1";"bin1";"bin2";"bin1"]
(**
A box plot or boxplot is a convenient way of graphically depicting groups of numerical data through their quartiles. 
Box plots may also have lines extending vertically from the boxes (whiskers) indicating variability outside the upper
and lower quartiles, hence the terms box-and-whisker plot and box-and-whisker diagram. 
Outliers may be plotted as individual points.
*)
let box1 =
    Chart.BoxPlot(x,y,Jitter=0.1,Boxpoints=StyleParam.Boxpoints.All)(* output: 
<div id="1a5b42bc-c5f5-4d6d-8c9e-b29e17d75086" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_1a5b42bcc5f54d6d8c9eb29e17d75086 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"box","y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"x":["bin1","bin2","bin1","bin2","bin1","bin2","bin1","bin1","bin2","bin1"],"boxpoints":"all","jitter":0.1,"marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('1a5b42bc-c5f5-4d6d-8c9e-b29e17d75086', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_1a5b42bcc5f54d6d8c9eb29e17d75086();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_1a5b42bcc5f54d6d8c9eb29e17d75086();
            }
</script>
*)
(**
By swapping x and y plus using `StyleParam.Orientation.Horizontal` we can flip the chart horizontaly.
*)
let box2 =
    Chart.BoxPlot(y,x,Jitter=0.1,Boxpoints=StyleParam.Boxpoints.All,Orientation=StyleParam.Orientation.Horizontal)(* output: 
<div id="abb2dd6a-4df5-4ed0-b5aa-5150e76dc414" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_abb2dd6a4df54ed0b5aa5150e76dc414 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"box","y":["bin1","bin2","bin1","bin2","bin1","bin2","bin1","bin1","bin2","bin1"],"x":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"boxpoints":"all","jitter":0.1,"orientation":"h","marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('abb2dd6a-4df5-4ed0-b5aa-5150e76dc414', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_abb2dd6a4df54ed0b5aa5150e76dc414();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_abb2dd6a4df54ed0b5aa5150e76dc414();
            }
</script>
*)
(**
You can also produce a boxplot using the `Chart.Combine` syntax.
*)
let y' =  [2.; 1.5; 5.; 1.5; 2.; 2.5; 2.1; 2.5; 1.5; 1.;2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]

let box3 =
    [
        Chart.BoxPlot("y" ,y,Name="bin1",Jitter=0.1,Boxpoints=StyleParam.Boxpoints.All);
        Chart.BoxPlot("y'",y',Name="bin2",Jitter=0.1,Boxpoints=StyleParam.Boxpoints.All);
    ]
    |> Chart.Combine(* output: 
<div id="7f964191-01de-4ab1-9c2a-a073053a4bd7" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_7f96419101de4ab19c2aa073053a4bd7 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"box","y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"x":"y","boxpoints":"all","jitter":0.1,"name":"bin1","marker":{}},{"type":"box","y":[2.0,1.5,5.0,1.5,2.0,2.5,2.1,2.5,1.5,1.0,2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"x":"y'","boxpoints":"all","jitter":0.1,"name":"bin2","marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('7f964191-01de-4ab1-9c2a-a073053a4bd7', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_7f96419101de4ab19c2aa073053a4bd7();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_7f96419101de4ab19c2aa073053a4bd7();
            }
</script>
*)

