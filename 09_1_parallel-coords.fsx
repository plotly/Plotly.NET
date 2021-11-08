(**
// can't yet format YamlFrontmatter (["title: Parallel coordinates"; "category: Categorical Charts"; "categoryindex: 10"; "index: 2"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# Parallel coordinates

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=09_1_parallel-coords.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/09_1_parallel-coords.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/09_1_parallel-coords.ipynb)

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
    Chart.ParallelCoord(data,Color=Color.fromString "blue")(* output: 
<div id="1228ae39-3e38-4ec8-858b-5b4f3601fd9f" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_1228ae393e384ec8858b5b4f3601fd9f = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"parcoords","dimensions":[{"values":[1.0,4.0,3.4,0.7],"label":"A"},{"values":[3.0,1.5,1.7,2.3],"label":"B"},{"values":[2.0,4.0,3.1,5.0],"label":"C"},{"values":[4.0,2.0,2.0,4.0],"label":"D"}],"line":{"color":"blue"}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('1228ae39-3e38-4ec8-858b-5b4f3601fd9f', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_1228ae393e384ec8858b5b4f3601fd9f();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_1228ae393e384ec8858b5b4f3601fd9f();
            }
</script>
*)
open Plotly.NET.TraceObjects

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
    dyn?line <- Line.init(Color=Color.fromString "blue")

    dyn
    |> GenericChart.ofTraceObject(* output: 
<div id="d51a024f-cd2f-4e90-82a7-e06ce66590da" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_d51a024fcd2f4e9082a7e06ce66590da = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"parcoords","dimensions":[{"values":[1.0,4.0],"range":[1.0,5.0],"constraintrange":[1.0,2.0],"label":"A"},{"values":[3.0,1.5],"range":[1.0,5.0],"label":"B","tickvals":[1.5,3.0,4.0,5.0]},{"values":[2.0,4.0],"range":[1.0,5.0],"label":"C","tickvals":[1.0,2.0,4.0,5.0],"ticktext":["txt 1","txt 2","txt 4","txt 5"]},{"values":[4.0,2.0],"range":[1.0,5.0],"label":"D"}],"line":{"color":"blue"}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('d51a024f-cd2f-4e90-82a7-e06ce66590da', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_d51a024fcd2f4e9082a7e06ce66590da();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_d51a024fcd2f4e9082a7e06ce66590da();
            }
</script>
*)

