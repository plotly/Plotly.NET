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
<div id="85e6301c-3820-4df9-b1a8-05487a22de05" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_85e6301c38204df9b1a805487a22de05 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatterpolar","mode":"markers","r":[10000,20000,30000,40000,50000,60000,70000],"theta":[0,45,90,135,200,320,184],"name":"PointPolar","marker":{}},{"type":"scatterpolar","mode":"lines+markers","r":[50000,60000,70000,10000,20000,30000,40000],"theta":[0,45,90,135,200,320,184],"name":"LinePolar","line":{},"marker":{}},{"type":"scatterpolar","mode":"lines+markers","r":[30000,10000,50000,20000,80000,70000,50000],"theta":[0,45,90,135,200,320,184],"name":"SplinePolar","line":{"shape":"spline"},"marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('85e6301c-3820-4df9-b1a8-05487a22de05', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_85e6301c38204df9b1a805487a22de05();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_85e6301c38204df9b1a805487a22de05();
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
<div id="3839cb52-ad97-4804-8cdc-6e13ed83b916" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_3839cb52ad9748048cdc6e13ed83b916 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatterpolar","mode":"markers","r":[10000,20000,30000,40000,50000,60000,70000],"theta":[0,45,90,135,200,320,184],"name":"PointPolar","marker":{}},{"type":"scatterpolar","mode":"lines+markers","r":[50000,60000,70000,10000,20000,30000,40000],"theta":[0,45,90,135,200,320,184],"name":"LinePolar","line":{},"marker":{}},{"type":"scatterpolar","mode":"lines+markers","r":[30000,10000,50000,20000,80000,70000,50000],"theta":[0,45,90,135,200,320,184],"name":"SplinePolar","line":{"shape":"spline"},"marker":{}}];
            var layout = {"polar":{"sector":[0.0,270.0],"hole":0.1}};
            var config = {};
            Plotly.newPlot('3839cb52-ad97-4804-8cdc-6e13ed83b916', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_3839cb52ad9748048cdc6e13ed83b916();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_3839cb52ad9748048cdc6e13ed83b916();
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
<div id="1313ffcd-aac6-4382-b45b-df9524550c86" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_1313ffcdaac64382b45bdf9524550c86 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatterpolar","mode":"markers","r":[10000,20000,30000,40000,50000,60000,70000],"theta":[0,45,90,135,200,320,184],"name":"PointPolar","marker":{}},{"type":"scatterpolar","mode":"lines+markers","r":[50000,60000,70000,10000,20000,30000,40000],"theta":[0,45,90,135,200,320,184],"name":"LinePolar","line":{},"marker":{}},{"type":"scatterpolar","mode":"lines+markers","r":[30000,10000,50000,20000,80000,70000,50000],"theta":[0,45,90,135,200,320,184],"name":"SplinePolar","line":{"shape":"spline"},"marker":{}}];
            var layout = {"polar":{"sector":[0.0,270.0],"hole":0.1,"angularaxis":{"color":"darkblue"},"radialaxis":{"title":{"text":"Hi, i am the radial axis"},"color":"darkblue","separatethousands":true}}};
            var config = {};
            Plotly.newPlot('1313ffcd-aac6-4382-b45b-df9524550c86', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_1313ffcdaac64382b45bdf9524550c86();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_1313ffcdaac64382b45bdf9524550c86();
            }
</script>
*)

