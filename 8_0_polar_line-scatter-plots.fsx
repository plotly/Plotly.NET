(**
// can't yet format YamlFrontmatter (["title: Polar line and scatter plots"; "category: Polar Charts"; "categoryindex: 8"; "index: 1"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# Polar charts

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=8_0_polar_line-scatter-plots.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/8_0_polar_line-scatter-plots.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/8_0_polar_line-scatter-plots.ipynb)

*Summary:* This example shows how to create polar charts in F#.

let's first create some data for the purpose of creating example charts:

*)
open Plotly.NET 
  
// radial coordinates
let radial  = [ 1; 2; 3; 4; 5; 6; 7;]

// angular coordinates
let theta  = [0; 45; 90; 135; 200; 320; 184;]
(**
A polar chart is a graphical method of displaying multivariate data in the form of a two-dimensional chart 
of three or more quantitative variables represented on axes starting from the same point.

The relative position and angle of the axes is typically uninformative.

In Polar Charts, a series is represented by a closed curve that connects points in the polar coordinate system. 
Each data point is determined by the distance from the pole (the radial coordinate) and the angle from the fixed direction (the angular coordinate).

## Polar point charts

use `Chart.PointPolar` to create a polar plot that displays points on a polar coordinate system:
*)
let pointPolar = Chart.PointPolar(radial,theta)(* output: 
<div id="43a01d81-07a5-4c74-8965-ec56d52710e5" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_43a01d8107a54c748965ec56d52710e5 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatterpolar","mode":"markers","r":[1,2,3,4,5,6,7],"theta":[0,45,90,135,200,320,184],"marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('43a01d81-07a5-4c74-8965-ec56d52710e5', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_43a01d8107a54c748965ec56d52710e5();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_43a01d8107a54c748965ec56d52710e5();
            }
</script>
*)
(**
## Polar line charts

use `Chart.LinePolar` to create a polar plot that displays a line connecting input the data on a polar coordinate system.

You can for example change the line style using `Chart.withLineStyle`
*)
let linePolar = 
    Chart.LinePolar(radial,theta)
    |> Chart.withLineStyle(Color="purple",Dash=StyleParam.DrawingStyle.DashDot)(* output: 
<div id="8d3a0613-7685-4013-a68c-6ac1d564fe8a" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_8d3a061376854013a68c6ac1d564fe8a = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatterpolar","mode":"lines","r":[1,2,3,4,5,6,7],"theta":[0,45,90,135,200,320,184],"line":{"color":"purple","dash":"dashdot"},"marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('8d3a0613-7685-4013-a68c-6ac1d564fe8a', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_8d3a061376854013a68c6ac1d564fe8a();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_8d3a061376854013a68c6ac1d564fe8a();
            }
</script>
*)
(**
## Polar Spline charts

use `Chart.SpinePolar` to create a polar plot that displays a smoothed line connecting input the data on a polar coordinate system.

As for all other plots above, You can for example add labels to each datum:
*)
let splinePolar = 
    Chart.SplinePolar(
        radial,
        theta,
        Labels=["one";"two";"three";"four";"five";"six";"seven"],
        TextPosition=StyleParam.TextPosition.TopCenter,
        ShowMarkers=true
    )(* output: 
<div id="b30c5373-1e3a-47b3-9698-62d4262e1334" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_b30c53731e3a47b3969862d4262e1334 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatterpolar","mode":"lines+markers+text","r":[1,2,3,4,5,6,7],"theta":[0,45,90,135,200,320,184],"line":{"shape":"spline"},"marker":{},"text":["one","two","three","four","five","six","seven"],"textposition":"top center"}];
            var layout = {};
            var config = {};
            Plotly.newPlot('b30c5373-1e3a-47b3-9698-62d4262e1334', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_b30c53731e3a47b3969862d4262e1334();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_b30c53731e3a47b3969862d4262e1334();
            }
</script>
*)

