(**
// can't yet format YamlFrontmatter (["title: Error bars"; "category: Chart Layout"; "categoryindex: 2"; "index: 2"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# Error bars

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=1_1_errorbars.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/1_1_errorbars.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/1_1_errorbars.ipynb)

*Summary:* This example shows how to add error bars to plots in F#.

let's first create some data for the purpose of creating example charts:

*)
open Plotly.NET

let x  = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
let y' = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
let xError = [|0.2;0.3;0.2;0.1;0.2;0.4;0.2;0.08;0.2;0.1;|]
let yError = [|0.3;0.2;0.1;0.4;0.2;0.4;0.1;0.18;0.02;0.2;|]
(**
To add error bars to a chart, use the `Chart.with*ErrorStyle` functions for either X, Y, or Z.
*)
let pointsWithErrorBars =
    Chart.Point(x,y',Name="points with errors")    
    |> Chart.withXErrorStyle (Array=xError,Symmetric=true)
    |> Chart.withYErrorStyle (Array=yError, Arrayminus = xError) // for negative error, use positive values in the `Arrayminus` argument (* output: 
<div id="22c9011f-abcc-4f51-81e2-23cb11c487a3" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_22c9011fabcc4f5181e223cb11c487a3 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"mode":"markers","name":"points with errors","marker":{},"error_x":{"symmetric":true,"array":[0.2,0.3,0.2,0.1,0.2,0.4,0.2,0.08,0.2,0.1]},"error_y":{"array":[0.3,0.2,0.1,0.4,0.2,0.4,0.1,0.18,0.02,0.2],"arrayminus":[0.2,0.3,0.2,0.1,0.2,0.4,0.2,0.08,0.2,0.1]}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('22c9011f-abcc-4f51-81e2-23cb11c487a3', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_22c9011fabcc4f5181e223cb11c487a3();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_22c9011fabcc4f5181e223cb11c487a3();
            }
</script>
*)

