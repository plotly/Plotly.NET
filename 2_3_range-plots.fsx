(**
// can't yet format YamlFrontmatter (["title: Range plots"; "category: Simple Charts"; "categoryindex: 3"; "index: 4"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# Range plots

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=2_3_range-plots.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/2_3_range-plots.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/2_3_range-plots.ipynb)

*Summary:* This example shows how to create Range plot charts in F#.

let's first create some data for the purpose of creating example charts:

*)
open Plotly.NET 

let rnd = System.Random()

let x  = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
let y = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]

let yUpper = y |> List.map (fun v -> v + rnd.NextDouble())
let yLower = y |> List.map (fun v -> v - rnd.NextDouble())
(**
A range plot is commonly used to indicate some property of data that lies in a certain range around a central value,
for example the range of all predictions from different models, scattering around a central tendency.
*)
let range1 =
    Chart.Range(
        x,y,yUpper,yLower,
        StyleParam.Mode.Lines_Markers,
        Color="grey",
        RangeColor="lightblue")(* output: 
<div id="d1bb9b2b-ad82-4316-b7bc-ce7ef0624338" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_d1bb9b2bad824316b7bcce7ef0624338 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[1.9972994448604526,1.2424523479968554,4.874685567279665,1.3489362899441906,2.29795410078855,1.5952859237302495,2.3876193207165315,1.4763111765386123,3.1716919116078373,0.3906142159321412],"mode":"lines","fillcolor":"lightblue","name":"lower","showlegend":false,"line":{"width":0.0},"marker":{"color":"lightblue"}},{"type":"scatter","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.6005284411835152,1.903285507300536,5.716725723686035,1.789787334059266,3.116923973484395,2.612120894301739,3.0374582132964667,2.2184352263428435,4.310031001367621,1.6291431908631433],"mode":"lines","fill":"tonexty","fillcolor":"lightblue","name":"upper","showlegend":false,"line":{"width":0.0},"marker":{"color":"lightblue"}},{"type":"scatter","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"mode":"lines+markers","fillcolor":"grey","line":{"color":"grey"},"marker":{"color":"grey"}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('d1bb9b2b-ad82-4316-b7bc-ce7ef0624338', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_d1bb9b2bad824316b7bcce7ef0624338();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_d1bb9b2bad824316b7bcce7ef0624338();
            }
</script>
*)

