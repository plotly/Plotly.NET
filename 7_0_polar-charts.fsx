(**
// can't yet format YamlFrontmatter (["title: Polar charts"; "category: Polar Charts"; "categoryindex: 8"; "index: 1"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# Polar charts

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=7_0_polar-charts.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/7_0_polar-charts.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/7_0_polar-charts.ipynb)

*Summary:* This example shows how to create polar charts in F#.

let's first create some data for the purpose of creating example charts:

*)
open Plotly.NET 
  
let r  = [ 1; 2; 3; 4; 5; 6; 7;]
let r2 = [ 5; 6; 7; 1; 2; 3; 4;]
let r3 = [ 3; 1; 5; 2; 8; 7; 5;]

let t  = [0; 45; 90; 135; 200; 320; 184;]
(**
A polar chart is a graphical method of displaying multivariate data in the form of a two-dimensional chart 
of three or more quantitative variables represented on axes starting from the same point.
The relative position and angle of the axes is typically uninformative.
*)
let polar1 =
        [
            Chart.Polar(r,t,StyleParam.Mode.Markers,Name="1")
            Chart.Polar(r2,t,StyleParam.Mode.Markers,Name="2")
            Chart.Polar(r3,t,StyleParam.Mode.Markers,Name="3")
        ]
        |> Chart.Combine(* output: 
<div id="dab89a21-8247-4af5-a6d1-d30af7a8833c" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_dab89a2182474af5a6d1d30af7a8833c = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","mode":"markers","r":[1,2,3,4,5,6,7],"t":[0,45,90,135,200,320,184],"name":"1","line":{},"marker":{}},{"type":"scatter","mode":"markers","r":[5,6,7,1,2,3,4],"t":[0,45,90,135,200,320,184],"name":"2","line":{},"marker":{}},{"type":"scatter","mode":"markers","r":[3,1,5,2,8,7,5],"t":[0,45,90,135,200,320,184],"name":"3","line":{},"marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('dab89a21-8247-4af5-a6d1-d30af7a8833c', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_dab89a2182474af5a6d1d30af7a8833c();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_dab89a2182474af5a6d1d30af7a8833c();
            }
</script>
*)

