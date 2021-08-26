(**
// can't yet format YamlFrontmatter (["title: Styling polar layouts"; "category: Polar Charts"; "categoryindex: 9 "; "index: 3"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# Styling polar layouts

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=8_2_styling_polar_layouts.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/8_2_styling_polar_layouts.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/8_2_styling_polar_layouts.ipynb)

*Summary:* This example shows how to style polar layouts in F#.

let's first create some data for the purpose of creating example charts:
*)
open Plotly.NET

let r  = [ 1; 2; 3; 4; 5; 6; 7;] |> List.map ((*) 10000)
let r2 = [ 5; 6; 7; 1; 2; 3; 4;] |> List.map ((*) 10000)
let r3 = [ 3; 1; 5; 2; 8; 7; 5;] |> List.map ((*) 10000)

let t  = [0; 45; 90; 135; 200; 320; 184;]
(**
Consider this combined polar chart:
*)
let combinedPolar =
    [
        Chart.PointPolar(r,t,Name="PointPolar")
        Chart.LinePolar(r2,t,Name="LinePolar", ShowMarkers = true)
        Chart.SplinePolar(r3,t,Name="SplinePolar", ShowMarkers = true)
    ]
    
    |> Chart.combine(* output: 
<div id="3b696be7-620b-49e1-b1b9-633e7a9af29c" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_3b696be7620b49e1b1b9633e7a9af29c = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatterpolar","mode":"markers","r":[10000,20000,30000,40000,50000,60000,70000],"theta":[0,45,90,135,200,320,184],"name":"PointPolar","marker":{}},{"type":"scatterpolar","mode":"lines+markers","r":[50000,60000,70000,10000,20000,30000,40000],"theta":[0,45,90,135,200,320,184],"name":"LinePolar","line":{},"marker":{}},{"type":"scatterpolar","mode":"lines+markers","r":[30000,10000,50000,20000,80000,70000,50000],"theta":[0,45,90,135,200,320,184],"name":"SplinePolar","line":{"shape":"spline"},"marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('3b696be7-620b-49e1-b1b9-633e7a9af29c', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_3b696be7620b49e1b1b9633e7a9af29c();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_3b696be7620b49e1b1b9633e7a9af29c();
            }
</script>
*)
(**
## Styling the polar layout

Use the `Chart.withPolar` function and initialize a Polar layout with the desired looks
*)
let styledPolar = 
    combinedPolar
    |> Chart.withPolar(
        Polar.init(
            Sector= (0., 270.),
            Hole=0.1
        )
    )(* output: 
<div id="a066207b-6c1c-4351-b9c5-dd2c3a4f87cb" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_a066207b6c1c4351b9c5dd2c3a4f87cb = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatterpolar","mode":"markers","r":[10000,20000,30000,40000,50000,60000,70000],"theta":[0,45,90,135,200,320,184],"name":"PointPolar","marker":{}},{"type":"scatterpolar","mode":"lines+markers","r":[50000,60000,70000,10000,20000,30000,40000],"theta":[0,45,90,135,200,320,184],"name":"LinePolar","line":{},"marker":{}},{"type":"scatterpolar","mode":"lines+markers","r":[30000,10000,50000,20000,80000,70000,50000],"theta":[0,45,90,135,200,320,184],"name":"SplinePolar","line":{"shape":"spline"},"marker":{}}];
            var layout = {"polar":{"sector":[0.0,270.0],"hole":0.1}};
            var config = {};
            Plotly.newPlot('a066207b-6c1c-4351-b9c5-dd2c3a4f87cb', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_a066207b6c1c4351b9c5dd2c3a4f87cb();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_a066207b6c1c4351b9c5dd2c3a4f87cb();
            }
</script>
*)
(**
## Styling radial and angular axes

You could pass these axes to `Chart.withPolar`, but for the case where you want to specifically set the angular or radial axis, there are the `Chart.withAngularAxis` and `Chart.withRadialAxis` functions:
*)
let styledPolar2 =
    styledPolar
    |> Chart.withAngularAxis(
        Axis.AngularAxis.init(
            Color="darkblue"
        )
    )
    |> Chart.withRadialAxis(
        Axis.RadialAxis.init(
            Title = Title.init("Hi, i am the radial axis"),
            Color="darkblue",
            SeparateThousands = true
        )
    )(* output: 
<div id="8b71aec5-48b5-47ba-a521-eb63f8e7eaf5" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_8b71aec548b547baa521eb63f8e7eaf5 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatterpolar","mode":"markers","r":[10000,20000,30000,40000,50000,60000,70000],"theta":[0,45,90,135,200,320,184],"name":"PointPolar","marker":{}},{"type":"scatterpolar","mode":"lines+markers","r":[50000,60000,70000,10000,20000,30000,40000],"theta":[0,45,90,135,200,320,184],"name":"LinePolar","line":{},"marker":{}},{"type":"scatterpolar","mode":"lines+markers","r":[30000,10000,50000,20000,80000,70000,50000],"theta":[0,45,90,135,200,320,184],"name":"SplinePolar","line":{"shape":"spline"},"marker":{}}];
            var layout = {"polar":{"sector":[0.0,270.0],"hole":0.1,"angularaxis":{"color":"darkblue"},"radialaxis":{"title":{"text":"Hi, i am the radial axis"},"color":"darkblue","separatethousands":true}}};
            var config = {};
            Plotly.newPlot('8b71aec5-48b5-47ba-a521-eb63f8e7eaf5', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_8b71aec548b547baa521eb63f8e7eaf5();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_8b71aec548b547baa521eb63f8e7eaf5();
            }
</script>
*)

