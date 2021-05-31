(**
// can't yet format YamlFrontmatter (["title: Parallel coordinates"; "category: Categorical Charts"; "categoryindex: 10"; "index: 2"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# Parallel coordinates

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=8_1_parallel-coords.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/8_1_parallel-coords.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/8_1_parallel-coords.ipynb)

*Summary:* This example shows how to create parallel coordinates plot in F#.

let's first create some data for the purpose of creating example charts:

*)
open Plotly.NET 

let data = 
    [
        "A",[1.;4.;3.4;0.7;]
        "B",[3.;1.5;1.7;2.3;]
        "C",[2.;4.;3.1;5.]
        "D",[4.;2.;2.;4.;]
    ]
(**
Parallel coordinates are a common way of visualizing high-dimensional geometry and analyzing multivariate data.
To show a set of points in an n-dimensional space, a backdrop is drawn consisting of n parallel lines, typically 
vertical and equally spaced. A point in n-dimensional space is represented as a polyline with vertices on the parallel axes; 
the position of the vertex on the i-th axis corresponds to the i-th coordinate of the point.
*)
let parcoords1 =
    Chart.ParallelCoord(data,Color="blue")(* output: 
<div id="0ade2f45-1f39-4a33-84c8-94c1436f5672" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_0ade2f451f394a3384c894c1436f5672 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"parcoords","dimensions":[{"values":[1.0,4.0,3.4,0.7],"label":"A"},{"values":[3.0,1.5,1.7,2.3],"label":"B"},{"values":[2.0,4.0,3.1,5.0],"label":"C"},{"values":[4.0,2.0,2.0,4.0],"label":"D"}],"line":{"color":"blue"}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('0ade2f45-1f39-4a33-84c8-94c1436f5672', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_0ade2f451f394a3384c894c1436f5672();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_0ade2f451f394a3384c894c1436f5672();
            }
</script>
*)
// Dynamic object version
let parcoords = 
    let v = [|
        Dimensions.init([|1.;4.;|],  
            StyleParam.Range.MinMax (1.,5.),StyleParam.Range.MinMax (1.,2.),Label="A");
        Dimensions.init([|3.;1.5;|], 
            StyleParam.Range.MinMax (1.,5.),Label="B",Tickvals=[|1.5;3.;4.;5.;|]);
        Dimensions.init([|2.;4.;|],  
            StyleParam.Range.MinMax (1.,5.),Label="C",Tickvals=[|1.;2.;4.;5.;|],
                TickText=[|"txt 1";"txt 2";"txt 4";"txt 5";|]);
        Dimensions.init([|4.;2.;|],  
            StyleParam.Range.MinMax (1.,5.),Label="D");
    |]

    let dyn = Trace("parcoords")

    dyn?dimensions <- v
    dyn?line <- Line.init(Color = "blue")

    dyn
    |> GenericChart.ofTraceObject(* output: 
<div id="d9a82f76-7801-4f1b-bde7-e03a5dc1ebbf" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_d9a82f7678014f1bbde7e03a5dc1ebbf = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"parcoords","dimensions":[{"values":[1.0,4.0],"range":[1.0,5.0],"constraintrange":[1.0,2.0],"label":"A"},{"values":[3.0,1.5],"range":[1.0,5.0],"label":"B","tickvals":[1.5,3.0,4.0,5.0]},{"values":[2.0,4.0],"range":[1.0,5.0],"label":"C","tickvals":[1.0,2.0,4.0,5.0],"ticktext":["txt 1","txt 2","txt 4","txt 5"]},{"values":[4.0,2.0],"range":[1.0,5.0],"label":"D"}],"line":{"color":"blue"}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('d9a82f76-7801-4f1b-bde7-e03a5dc1ebbf', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_d9a82f7678014f1bbde7e03a5dc1ebbf();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_d9a82f7678014f1bbde7e03a5dc1ebbf();
            }
</script>
*)

