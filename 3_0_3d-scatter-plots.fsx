(**
// can't yet format YamlFrontmatter (["title: 3D Scatter charts"; "category: 3D Charts"; "categoryindex: 4"; "index: 1"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# 3D Scatter charts

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=3_0_3d-scatter-plots.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/3_0_3d-scatter-plots.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/3_0_3d-scatter-plots.ipynb)

*Summary:* This example shows how to create three-dimensional scatter charts in F#.

A Scatter3d chart report shows a three-dimensional spinnable view of your data
*)
open Plotly.NET 
  
let x = [19; 26; 55;]
let y = [19; 26; 55;]
let z = [19; 26; 55;]

let scatter3d = 
    Chart.Scatter3d(x,y,z,StyleParam.Mode.Markers)
    |> Chart.withX_AxisStyle("my x-axis")
    |> Chart.withY_AxisStyle("my y-axis")
    |> Chart.withZ_AxisStyle("my z-axis")
    |> Chart.withSize(800.,800.)(* output: 
<div id="62c573de-2fb8-4768-b313-b636b8958db0" style="width: 800px; height: 800px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_62c573de2fb84768b313b636b8958db0 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter3d","x":[19,26,55],"y":[19,26,55],"z":[19,26,55],"mode":"markers","line":{},"marker":{}}];
            var layout = {"scene":{"xaxis":{"title":"my x-axis"},"yaxis":{"title":"my y-axis"},"zaxis":{"title":"my z-axis"}},"width":800.0,"height":800.0};
            var config = {};
            Plotly.newPlot('62c573de-2fb8-4768-b313-b636b8958db0', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_62c573de2fb84768b313b636b8958db0();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_62c573de2fb84768b313b636b8958db0();
            }
</script>
*)

