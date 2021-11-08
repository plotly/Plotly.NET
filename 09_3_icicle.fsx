(**
// can't yet format YamlFrontmatter (["title: Icicle Charts"; "category: Categorical Charts"; "categoryindex: 10"; "index: 4"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# Icicle charts

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=09_3_icicle.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/09_3_icicle.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/09_3_icicle.ipynb)

*Summary:* This example shows how to create icicle charts in F#.

Icicle charts visualize hierarchical data using rectangular sectors that cascade from root to leaves in one of four directions: up, down, left, or right. 
Similar to Sunburst charts and Treemaps charts, the hierarchy is defined by labels and parents attributes. 
Click on one sector to zoom in/out, which also displays a pathbar on the top of your icicle. 
To zoom out, you can click the parent sector or click the pathbar as well.

*)
open Plotly.NET
open Plotly.NET.TraceObjects

let character   = ["Eve"; "Cain"; "Seth"; "Enos"; "Noam"; "Abel"; "Awan"; "Enoch"; "Azura"]
let parent      = [""; "Eve"; "Eve"; "Seth"; "Seth"; "Eve"; "Eve"; "Awan"; "Eve" ]

let icicle = 
    Chart.Icicle(
        character,
        parent,
        ShowScale = true,
        ColorScale = StyleParam.Colorscale.Viridis,
        TilingOrientation = StyleParam.Orientation.Vertical, // wether the icicles will grow in the vertical (up/down) or horizontal (left/right) direction
        TilingFlip = StyleParam.TilingFlip.Y, // flip in the Y direction (grow up instead of down)
        PathBarEdgeShape = StyleParam.PathbarEdgeShape.BackSlash
    )(* output: 
<div id="b6dcf22f-43d1-404a-9048-442b90bc14f9" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_b6dcf22f43d1404a9048442b90bc14f9 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"icicle","parents":["","Eve","Eve","Seth","Seth","Eve","Eve","Awan","Eve"],"labels":["Eve","Cain","Seth","Enos","Noam","Abel","Awan","Enoch","Azura"],"tiling":{"flip":"y","orientation":"v"},"pathbar":{"edgeshape":"\\"},"marker":{"colorscale":"Viridis","showscale":true}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('b6dcf22f-43d1-404a-9048-442b90bc14f9', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_b6dcf22f43d1404a9048442b90bc14f9();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_b6dcf22f43d1404a9048442b90bc14f9();
            }
</script>
*)

