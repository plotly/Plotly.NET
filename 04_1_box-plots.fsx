(**
// can't yet format YamlFrontmatter (["title: BoxPlots"; "category: Distribution Charts"; "categoryindex: 5"; "index: 2"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# BoxPlots

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=04_1_box-plots.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/04_1_box-plots.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/04_1_box-plots.ipynb)

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
    Chart.BoxPlot(x,y,Jitter=0.1,BoxPoints=StyleParam.BoxPoints.All)(* output: 
<div id="20d347a7-ddc2-4f0d-a599-7e56d4bd1bcc" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_20d347a7ddc24f0da5997e56d4bd1bcc = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"box","x":["bin1","bin2","bin1","bin2","bin1","bin2","bin1","bin1","bin2","bin1"],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"boxpoints":"all","jitter":0.1,"marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('20d347a7-ddc2-4f0d-a599-7e56d4bd1bcc', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_20d347a7ddc24f0da5997e56d4bd1bcc();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_20d347a7ddc24f0da5997e56d4bd1bcc();
            }
</script>
*)
(**
By swapping x and y plus using `StyleParam.Orientation.Horizontal` we can flip the chart horizontaly.

*)
let box2 =
    Chart.BoxPlot(y,x,Jitter=0.1,BoxPoints=StyleParam.BoxPoints.All,Orientation=StyleParam.Orientation.Horizontal)(* output: 
<div id="c2a023f1-6d77-4b3d-953a-aae58e21cc61" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_c2a023f16d774b3d953aaae58e21cc61 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"box","x":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"y":["bin1","bin2","bin1","bin2","bin1","bin2","bin1","bin1","bin2","bin1"],"orientation":"h","boxpoints":"all","jitter":0.1,"marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('c2a023f1-6d77-4b3d-953a-aae58e21cc61', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_c2a023f16d774b3d953aaae58e21cc61();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_c2a023f16d774b3d953aaae58e21cc61();
            }
</script>
*)
(**
You can also produce a boxplot using the `Chart.Combine` syntax.

*)
let y' =  [2.; 1.5; 5.; 1.5; 2.; 2.5; 2.1; 2.5; 1.5; 1.;2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]

let box3 =
    [
        Chart.BoxPlot("y" ,y,Name="bin1",Jitter=0.1,BoxPoints=StyleParam.BoxPoints.All);
        Chart.BoxPlot("y'",y',Name="bin2",Jitter=0.1,BoxPoints=StyleParam.BoxPoints.All);
    ]
    |> Chart.combine(* output: 
<div id="dc57da7e-a4ad-4ce7-8961-273ed9c01613" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_dc57da7ea4ad4ce78961273ed9c01613 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"box","x":"y","y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"boxpoints":"all","jitter":0.1,"name":"bin1","marker":{}},{"type":"box","x":"y'","y":[2.0,1.5,5.0,1.5,2.0,2.5,2.1,2.5,1.5,1.0,2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"boxpoints":"all","jitter":0.1,"name":"bin2","marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('dc57da7e-a4ad-4ce7-8961-273ed9c01613', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_dc57da7ea4ad4ce78961273ed9c01613();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_dc57da7ea4ad4ce78961273ed9c01613();
            }
</script>
*)

