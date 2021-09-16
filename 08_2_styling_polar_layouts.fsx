(**
// can't yet format YamlFrontmatter (["title: Styling polar layouts"; "category: Polar Charts"; "categoryindex: 9 "; "index: 3"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# Styling polar layouts

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=08_2_styling_polar_layouts.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/08_2_styling_polar_layouts.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/08_2_styling_polar_layouts.ipynb)

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
<div id="3a1f3db0-8456-4b02-83b2-f3922cc39da3" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_3a1f3db084564b0283b2f3922cc39da3 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatterpolar","mode":"markers","r":[10000,20000,30000,40000,50000,60000,70000],"theta":[0,45,90,135,200,320,184],"name":"PointPolar","marker":{}},{"type":"scatterpolar","mode":"lines+markers","r":[50000,60000,70000,10000,20000,30000,40000],"theta":[0,45,90,135,200,320,184],"name":"LinePolar","line":{},"marker":{}},{"type":"scatterpolar","mode":"lines+markers","r":[30000,10000,50000,20000,80000,70000,50000],"theta":[0,45,90,135,200,320,184],"name":"SplinePolar","line":{"shape":"spline"},"marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('3a1f3db0-8456-4b02-83b2-f3922cc39da3', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_3a1f3db084564b0283b2f3922cc39da3();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_3a1f3db084564b0283b2f3922cc39da3();
            }
</script>
*)
(**
## Styling the polar layout

Use the `Chart.withPolar` function and initialize a Polar layout with the desired looks

*)
open Plotly.NET.LayoutObjects

let styledPolar = 
    combinedPolar
    |> Chart.withPolar(
        Polar.init(
            Sector= (0., 270.),
            Hole=0.1
        )
    )(* output: 
<div id="f56af922-9db1-4d7c-8f81-584a8dfcec0b" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_f56af9229db14d7c8f81584a8dfcec0b = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatterpolar","mode":"markers","r":[10000,20000,30000,40000,50000,60000,70000],"theta":[0,45,90,135,200,320,184],"name":"PointPolar","marker":{}},{"type":"scatterpolar","mode":"lines+markers","r":[50000,60000,70000,10000,20000,30000,40000],"theta":[0,45,90,135,200,320,184],"name":"LinePolar","line":{},"marker":{}},{"type":"scatterpolar","mode":"lines+markers","r":[30000,10000,50000,20000,80000,70000,50000],"theta":[0,45,90,135,200,320,184],"name":"SplinePolar","line":{"shape":"spline"},"marker":{}}];
            var layout = {"polar":{"sector":[0.0,270.0],"hole":0.1}};
            var config = {};
            Plotly.newPlot('f56af922-9db1-4d7c-8f81-584a8dfcec0b', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_f56af9229db14d7c8f81584a8dfcec0b();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_f56af9229db14d7c8f81584a8dfcec0b();
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
        AngularAxis.init(
            Color=Color.fromString "darkblue"
        )
    )
    |> Chart.withRadialAxis(
        RadialAxis.init(
            Title = Title.init("Hi, i am the radial axis"),
            Color=Color.fromString "darkblue",
            SeparateThousands = true
        )
    )(* output: 
<div id="c66ab1aa-7875-4b4e-b6bb-b52e11372260" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_c66ab1aa78754b4eb6bbb52e11372260 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatterpolar","mode":"markers","r":[10000,20000,30000,40000,50000,60000,70000],"theta":[0,45,90,135,200,320,184],"name":"PointPolar","marker":{}},{"type":"scatterpolar","mode":"lines+markers","r":[50000,60000,70000,10000,20000,30000,40000],"theta":[0,45,90,135,200,320,184],"name":"LinePolar","line":{},"marker":{}},{"type":"scatterpolar","mode":"lines+markers","r":[30000,10000,50000,20000,80000,70000,50000],"theta":[0,45,90,135,200,320,184],"name":"SplinePolar","line":{"shape":"spline"},"marker":{}}];
            var layout = {"polar":{"sector":[0.0,270.0],"hole":0.1,"angularaxis":{"color":"darkblue"},"radialaxis":{"title":{"text":"Hi, i am the radial axis"},"color":"darkblue","separatethousands":true}}};
            var config = {};
            Plotly.newPlot('c66ab1aa-7875-4b4e-b6bb-b52e11372260', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_c66ab1aa78754b4eb6bbb52e11372260();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_c66ab1aa78754b4eb6bbb52e11372260();
            }
</script>
*)

