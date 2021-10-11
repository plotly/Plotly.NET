(**
// can't yet format YamlFrontmatter (["title: Ternary line and scatter plots"; "category: Ternary Plots"; "categoryindex: 11"; "index: 1"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# Ternary charts

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=10_0_ternary_line_scatter_plots.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/10_0_ternary_line_scatter_plots.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/10_0_ternary_line_scatter_plots.ipynb)

*Summary:* This example shows how to create ternary charts in F#.

let's first create some data for the purpose of creating example charts:


*)
open Plotly.NET 
  
// a coordinates
let a  = [ 1; 2; 3; 4; 5; 6; 7;]

// b coordinates
let b  = a |> List.rev

//c
let c  = [ 2; 2; 2; 2; 2; 2; 2;]
(**
A Ternary plot is a barycentric plot on three variables which sum to a constant.

It graphically depicts the ratios of the three variables as positions in an equilateral triangle. 

It is used in physical chemistry, petrology, mineralogy, metallurgy, and other physical sciences to show the compositions of systems composed of three species. 
In population genetics, a triangle plot of genotype frequencies is called a de Finetti diagram. In game theory, it is often called a simplex plot.

Ternary plots are tools for analyzing compositional data in the three-dimensional case.

## Ternary point charts

use `Chart.PointTernary` to create a ternary plot that displays points on a ternary coordinate system:

*)
let ternaryPoint = Chart.PointTernary(a,b,c)(* output: 
<div id="28e235e5-d42b-4d64-bd0d-7d1eda96bcf3" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_28e235e5d42b4d64bd0d7d1eda96bcf3 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatterternary","mode":"markers","a":[1,2,3,4,5,6,7],"b":[7,6,5,4,3,2,1],"c":[2,2,2,2,2,2,2],"marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('28e235e5-d42b-4d64-bd0d-7d1eda96bcf3', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_28e235e5d42b4d64bd0d7d1eda96bcf3();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_28e235e5d42b4d64bd0d7d1eda96bcf3();
            }
</script>
*)
(**
## Ternary line charts

use `Chart.LineTernary` to create a ternary plot that displays a line connecting input the data on a ternary coordinate system:

As values on ternary plots sum to a constant, you can omit one dimension ofd the data by providing that sum.

You can also for example change the line style using `Chart.withLineStyle`

*)
let lineTernary = 
    Chart.LineTernary(a,b,Sum = 10)
    |> Chart.withLineStyle(Color=Color.fromString "purple",Dash=StyleParam.DrawingStyle.DashDot)(* output: 
<div id="729e3462-0dc1-40e2-b9b1-02b9262c83e7" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_729e34620dc140e2b9b102b9262c83e7 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatterternary","mode":"lines","a":[1,2,3,4,5,6,7],"b":[7,6,5,4,3,2,1],"sum":10,"line":{"color":"purple","dash":"dashdot"},"marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('729e3462-0dc1-40e2-b9b1-02b9262c83e7', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_729e34620dc140e2b9b102b9262c83e7();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_729e34620dc140e2b9b102b9262c83e7();
            }
</script>
*)

