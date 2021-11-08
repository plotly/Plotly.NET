(**
// can't yet format YamlFrontmatter (["title: Line and scatter plots"; "category: Simple Charts"; "categoryindex: 3"; "index: 1"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# Line and scatter plots

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=02_0_line-scatter-plots.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/02_0_line-scatter-plots.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/02_0_line-scatter-plots.ipynb)

*Summary:* This example shows how to create line and point charts in F#.

let's first create some data for the purpose of creating example charts:


*)
open Plotly.NET 
  
let x  = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
let y = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
(**
A line or a point chart can be created using the `Chart.Line` and `Chart.Point` functions. 

## Chart.Line with LineStyle

The following example generates a line Plot containing X and Y values and applies a line style to it.

*)
let line1 =
    Chart.Line(
        x,y,
        Name="line",
        ShowMarkers=true,
        MarkerSymbol=StyleParam.MarkerSymbol.Square)    
    |> Chart.withLineStyle(Width=2.,Dash=StyleParam.DrawingStyle.Dot)(* output: 
<div id="1d25adde-af7c-4a05-a1cf-a04d6362ea9b" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_1d25addeaf7c4a05a1cfa04d6362ea9b = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","mode":"lines+markers","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"line":{"width":2.0,"dash":"dot"},"name":"line","marker":{"symbol":"1"}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('1d25adde-af7c-4a05-a1cf-a04d6362ea9b', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_1d25addeaf7c4a05a1cfa04d6362ea9b();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_1d25addeaf7c4a05a1cfa04d6362ea9b();
            }
</script>
*)
(**
## Pipelining into Chart.Line
The following example calls the `Chart.Line` method with a list of X and Y values as tuples. The snippet generates
values of a simple function, f(x)=x^2. The values of the function are generated for X ranging from 1 to 100. The chart generated is 
shown below.

*)
let line2 =
    // Drawing graph of a 'square' function 
    [ for x in 1.0 .. 100.0 -> (x, x ** 2.0) ]
    |> Chart.Line(* output: 
<div id="34ea21a1-94c0-42a1-b08b-957bd1ac5fab" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_34ea21a194c042a1b08b957bd1ac5fab = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","mode":"lines","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0,11.0,12.0,13.0,14.0,15.0,16.0,17.0,18.0,19.0,20.0,21.0,22.0,23.0,24.0,25.0,26.0,27.0,28.0,29.0,30.0,31.0,32.0,33.0,34.0,35.0,36.0,37.0,38.0,39.0,40.0,41.0,42.0,43.0,44.0,45.0,46.0,47.0,48.0,49.0,50.0,51.0,52.0,53.0,54.0,55.0,56.0,57.0,58.0,59.0,60.0,61.0,62.0,63.0,64.0,65.0,66.0,67.0,68.0,69.0,70.0,71.0,72.0,73.0,74.0,75.0,76.0,77.0,78.0,79.0,80.0,81.0,82.0,83.0,84.0,85.0,86.0,87.0,88.0,89.0,90.0,91.0,92.0,93.0,94.0,95.0,96.0,97.0,98.0,99.0,100.0],"y":[1.0,4.0,9.0,16.0,25.0,36.0,49.0,64.0,81.0,100.0,121.0,144.0,169.0,196.0,225.0,256.0,289.0,324.0,361.0,400.0,441.0,484.0,529.0,576.0,625.0,676.0,729.0,784.0,841.0,900.0,961.0,1024.0,1089.0,1156.0,1225.0,1296.0,1369.0,1444.0,1521.0,1600.0,1681.0,1764.0,1849.0,1936.0,2025.0,2116.0,2209.0,2304.0,2401.0,2500.0,2601.0,2704.0,2809.0,2916.0,3025.0,3136.0,3249.0,3364.0,3481.0,3600.0,3721.0,3844.0,3969.0,4096.0,4225.0,4356.0,4489.0,4624.0,4761.0,4900.0,5041.0,5184.0,5329.0,5476.0,5625.0,5776.0,5929.0,6084.0,6241.0,6400.0,6561.0,6724.0,6889.0,7056.0,7225.0,7396.0,7569.0,7744.0,7921.0,8100.0,8281.0,8464.0,8649.0,8836.0,9025.0,9216.0,9409.0,9604.0,9801.0,10000.0],"line":{},"marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('34ea21a1-94c0-42a1-b08b-957bd1ac5fab', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_34ea21a194c042a1b08b957bd1ac5fab();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_34ea21a194c042a1b08b957bd1ac5fab();
            }
</script>
*)
(**
## Spline charts

Spline charts interpolate the curves between single points of 
the chart to generate a smoother version of the line chart.

*)
let spline1 = Chart.Spline(x,y,Name="spline")    (* output: 
<div id="109ee7c7-3a34-4741-af38-181a669ddc7b" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_109ee7c73a344741af38181a669ddc7b = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","mode":"lines","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"name":"spline","line":{"shape":"spline"},"marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('109ee7c7-3a34-4741-af38-181a669ddc7b', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_109ee7c73a344741af38181a669ddc7b();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_109ee7c73a344741af38181a669ddc7b();
            }
</script>
*)
let spline2 = 
    Chart.Spline(
        x,y,
        Name="spline",
        Smoothing = 0.4
    )      
    (* output: 
<div id="85f50bcf-de2a-4205-811c-26c33557a429" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_85f50bcfde2a4205811c26c33557a429 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","mode":"lines","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"name":"spline","line":{"shape":"spline","smoothing":0.4},"marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('85f50bcf-de2a-4205-811c-26c33557a429', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_85f50bcfde2a4205811c26c33557a429();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_85f50bcfde2a4205811c26c33557a429();
            }
</script>
*)
(**
## Point chart with text label

The following example calls the `Chart.Point` function to generate a scatter Plot containing X and Y values.
Addtionally, text labels are added . 

If `TextPosition` is set the labels are drawn otherwise only shown when hovering over the points.

*)
let labels  = ["a";"b";"c";"d";"e";"f";"g";"h";"i";"j";]

let pointsWithLabels =
    Chart.Point(
        x,y,
        Name="points",
        Labels=labels,
        TextPosition=StyleParam.TextPosition.TopRight
    )    (* output: 
<div id="bfa08e1a-41df-47af-92a4-37ddebb0bf07" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_bfa08e1a41df47af92a437ddebb0bf07 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","mode":"markers+text","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"name":"points","marker":{},"text":["a","b","c","d","e","f","g","h","i","j"],"textposition":"top right"}];
            var layout = {};
            var config = {};
            Plotly.newPlot('bfa08e1a-41df-47af-92a4-37ddebb0bf07', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_bfa08e1a41df47af92a437ddebb0bf07();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_bfa08e1a41df47af92a437ddebb0bf07();
            }
</script>
*)

