(**
// can't yet format YamlFrontmatter (["title: Shapes"; "category: Chart Layout"; "categoryindex: 2"; "index: 4"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# Shapes

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=1_3_shapes.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/1_3_shapes.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/1_3_shapes.ipynb)

*Summary:* This example shows how to create Shapes and add them to the Charts in F#.

let's first create some data for the purpose of creating example charts:

*)
open Plotly.NET 
  
let x  = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
let y' = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
(**
use the `Shape.init` function to generate a shape, and either the `Chart.withShape` or the `Chart.withShapes` function to add
multiple shapes at once.

**Attention**: Adding a shape after you added a previous one currently removes the old one. This is a bug and will be fixed
*)
let s1 = Shape.init (StyleParam.ShapeType.Rectangle,2.,4.,3.,4.,Opacity=0.3,Fillcolor="#d3d3d3")
let s2 = Shape.init (StyleParam.ShapeType.Rectangle,5.,7.,3.,4.,Opacity=0.3,Fillcolor="#d3d3d3")

let shapes =
    Chart.Line(x,y',Name="line")    
    |> Chart.withShapes([s1;s2])
//|> Chart.withShape(Options.Shape(StyleOption.ShapeType.Rectangle,2.,4.,3.,4.,Opacity=0.3,Fillcolor="#d3d3d3"))(* output: 
<div id="0710409d-65e1-4bc2-aa90-0c6483d61c9a" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_0710409d65e14bc2aa900c6483d61c9a = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"mode":"lines","line":{},"name":"line","marker":{}}];
            var layout = {"shapes":[{"type":"rect","x0":2.0,"x1":4.0,"y0":3.0,"y1":4.0,"opacity":0.3,"fillcolor":"#d3d3d3"},{"type":"rect","x0":5.0,"x1":7.0,"y0":3.0,"y1":4.0,"opacity":0.3,"fillcolor":"#d3d3d3"}]};
            var config = {};
            Plotly.newPlot('0710409d-65e1-4bc2-aa90-0c6483d61c9a', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_0710409d65e14bc2aa900c6483d61c9a();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_0710409d65e14bc2aa900c6483d61c9a();
            }
</script>
*)

