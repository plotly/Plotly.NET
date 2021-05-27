(**
// can't yet format YamlFrontmatter (["title: Windrose charts"; "category: Polar Charts"; "categoryindex: 9 "; "index: 2"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# Wind rose charts

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=7_1_windrose-charts.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/7_1_windrose-charts.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/7_1_windrose-charts.ipynb)

*Summary:* This example shows how to create wind rose charts in F#.

let's first create some data for the purpose of creating example charts:

*)
open Plotly.NET 
  
let r    = [77.5; 72.5; 70.0; 45.0; 22.5; 42.5; 40.0; 62.5]
let r'   = [57.5; 50.0; 45.0; 35.0; 20.0; 22.5; 37.5; 55.0]
let r''  = [40.0; 30.0; 30.0; 35.0; 7.5; 7.5; 32.5; 40.0]
let r''' = [20.0; 7.5; 15.0; 22.5; 2.5; 2.5; 12.5; 22.5]

let t = ["North"; "N-E"; "East"; "S-E"; "South"; "S-W"; "West"; "N-W"]
(**
A wind rose is a graphic tool used by meteorologists to give a succinct view 
of how wind speed and direction are typically distributed at a particular location.
*)
let windrose1 =
    [
        Chart.WindRose (r   ,t,Name="11-14 m/s")
        Chart.WindRose (r'  ,t,Name="8-11 m/s")
        Chart.WindRose (r'' ,t,Name="5-8 m/s")
        Chart.WindRose (r''',t,Name="< 5 m/s")
    ]
    |> Chart.Combine(* output: 
<div id="2449b40d-6663-401b-9a1e-cf86ab0e8eb3" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_2449b40d6663401b9a1ecf86ab0e8eb3 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"area","r":[77.5,72.5,70.0,45.0,22.5,42.5,40.0,62.5],"t":["North","N-E","East","S-E","South","S-W","West","N-W"],"name":"11-14 m/s","line":{},"marker":{}},{"type":"area","r":[57.5,50.0,45.0,35.0,20.0,22.5,37.5,55.0],"t":["North","N-E","East","S-E","South","S-W","West","N-W"],"name":"8-11 m/s","line":{},"marker":{}},{"type":"area","r":[40.0,30.0,30.0,35.0,7.5,7.5,32.5,40.0],"t":["North","N-E","East","S-E","South","S-W","West","N-W"],"name":"5-8 m/s","line":{},"marker":{}},{"type":"area","r":[20.0,7.5,15.0,22.5,2.5,2.5,12.5,22.5],"t":["North","N-E","East","S-E","South","S-W","West","N-W"],"name":"< 5 m/s","line":{},"marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('2449b40d-6663-401b-9a1e-cf86ab0e8eb3', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_2449b40d6663401b9a1ecf86ab0e8eb3();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_2449b40d6663401b9a1ecf86ab0e8eb3();
            }
</script>
*)

