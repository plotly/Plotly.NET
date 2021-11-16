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
    Chart.ParallelCoord(data,Color=Color.fromString "blue", UseDefaults = false)(* output: 
<div id="6c1f6643-6cef-4759-b80c-13df221b1d8d"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_6c1f66436cef4759b80c13df221b1d8d = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"parcoords","dimensions":[{"label":"A","values":[1.0,4.0,3.4,0.7],"axis":{}},{"label":"B","values":[3.0,1.5,1.7,2.3],"axis":{}},{"label":"C","values":[2.0,4.0,3.1,5.0],"axis":{}},{"label":"D","values":[4.0,2.0,2.0,4.0],"axis":{}}],"line":{"color":"blue"}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('6c1f6643-6cef-4759-b80c-13df221b1d8d', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_6c1f66436cef4759b80c13df221b1d8d();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_6c1f66436cef4759b80c13df221b1d8d();
            }
</script>
*)
open Plotly.NET.TraceObjects

// Dynamic object version

let parcoords = 
    let v = [|
        Dimension.initParallel(
            Values = [|1.;4.;|],  
            Range = StyleParam.Range.MinMax (1.,5.),
            ConstraintRange = StyleParam.Range.MinMax (1.,2.),
            Label="A");
        Dimension.initParallel(
            Values = [|3.;1.5;|], 
            Range = StyleParam.Range.MinMax (1.,5.),
            Label="B",
            Tickvals=[|1.5;3.;4.;5.;|]);
        Dimension.initParallel(
            Values = [|2.;4.;|],  
            Range = StyleParam.Range.MinMax (1.,5.),
            Label= "C",
            Tickvals=[|1.;2.;4.;5.;|],
            TickText=[|"txt 1";"txt 2";"txt 4";"txt 5";|]);
        Dimension.initParallel(
            Values = [|4.;2.;|],  
            Range = StyleParam.Range.MinMax (1.,5.),
            Label="D");
    |]

    let dyn = Trace("parcoords")

    dyn?dimensions <- v
    dyn?line <- Line.init(Color =Color.fromString "blue")

    dyn
    |> GenericChart.ofTraceObject false(* output: 
<div id="6c24d408-6900-4041-8c6c-144d925de443"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_6c24d408690040418c6c144d925de443 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"parcoords","dimensions":[{"label":"A","values":[1.0,4.0],"constraintrange":[1.0,2.0],"range":[1.0,5.0],"axis":{}},{"label":"B","values":[3.0,1.5],"range":[1.0,5.0],"tickvals":[1.5,3.0,4.0,5.0],"axis":{}},{"label":"C","values":[2.0,4.0],"range":[1.0,5.0],"ticktext":["txt 1","txt 2","txt 4","txt 5"],"tickvals":[1.0,2.0,4.0,5.0],"axis":{}},{"label":"D","values":[4.0,2.0],"range":[1.0,5.0],"axis":{}}],"line":{"color":"blue"}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('6c24d408-6900-4041-8c6c-144d925de443', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_6c24d408690040418c6c144d925de443();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_6c24d408690040418c6c144d925de443();
            }
</script>
*)

