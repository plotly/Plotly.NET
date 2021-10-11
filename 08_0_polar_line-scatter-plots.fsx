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
<div id="eefcfea8-a305-4306-8ba4-e3d2de6bb589" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_eefcfea8a30543068ba4e3d2de6bb589 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatterpolar","mode":"markers","r":[1,2,3,4,5,6,7],"theta":[0,45,90,135,200,320,184],"marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('eefcfea8-a305-4306-8ba4-e3d2de6bb589', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_eefcfea8a30543068ba4e3d2de6bb589();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_eefcfea8a30543068ba4e3d2de6bb589();
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
<div id="41976640-f902-4425-9782-586bba796f6b" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_41976640f90244259782586bba796f6b = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatterpolar","mode":"lines","r":[1,2,3,4,5,6,7],"theta":[0,45,90,135,200,320,184],"line":{"color":"purple","dash":"dashdot"},"marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('41976640-f902-4425-9782-586bba796f6b', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_41976640f90244259782586bba796f6b();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_41976640f90244259782586bba796f6b();
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
<div id="31b21828-704d-430d-ad6f-712f918cae16" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_31b21828704d430dad6f712f918cae16 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatterpolar","mode":"lines+markers+text","r":[1,2,3,4,5,6,7],"theta":[0,45,90,135,200,320,184],"line":{"shape":"spline"},"marker":{},"text":["one","two","three","four","five","six","seven"],"textposition":"top center"}];
            var layout = {};
            var config = {};
            Plotly.newPlot('31b21828-704d-430d-ad6f-712f918cae16', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_31b21828704d430dad6f712f918cae16();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_31b21828704d430dad6f712f918cae16();
            }
</script>
*)

