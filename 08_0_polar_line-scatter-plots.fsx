(**
// can't yet format YamlFrontmatter (["title: Polar line and scatter plots"; "category: Polar Charts"; "categoryindex: 8"; "index: 1"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# Polar charts

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=08_0_polar_line-scatter-plots.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/08_0_polar_line-scatter-plots.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/08_0_polar_line-scatter-plots.ipynb)

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
<div id="71696002-dd05-4fbb-a3dc-93186f79f9fc" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_71696002dd054fbba3dc93186f79f9fc = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatterpolar","mode":"markers","r":[1,2,3,4,5,6,7],"theta":[0,45,90,135,200,320,184],"marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('71696002-dd05-4fbb-a3dc-93186f79f9fc', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_71696002dd054fbba3dc93186f79f9fc();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_71696002dd054fbba3dc93186f79f9fc();
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
    |> Chart.withLineStyle(Color=Color.fromString "purple",Dash=StyleParam.DrawingStyle.DashDot)(* output: 
<div id="e3b5a728-415d-4483-baf3-f8f2293c2586" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_e3b5a728415d4483baf3f8f2293c2586 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatterpolar","mode":"lines","r":[1,2,3,4,5,6,7],"theta":[0,45,90,135,200,320,184],"line":{"color":"purple","dash":"dashdot"},"marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('e3b5a728-415d-4483-baf3-f8f2293c2586', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_e3b5a728415d4483baf3f8f2293c2586();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_e3b5a728415d4483baf3f8f2293c2586();
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
<div id="3847615e-58ee-441f-96d7-e1649930100b" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_3847615e58ee441f96d7e1649930100b = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatterpolar","mode":"lines+markers+text","r":[1,2,3,4,5,6,7],"theta":[0,45,90,135,200,320,184],"line":{"shape":"spline"},"marker":{},"text":["one","two","three","four","five","six","seven"],"textposition":"top center"}];
            var layout = {};
            var config = {};
            Plotly.newPlot('3847615e-58ee-441f-96d7-e1649930100b', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_3847615e58ee441f96d7e1649930100b();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_3847615e58ee441f96d7e1649930100b();
            }
</script>
*)

