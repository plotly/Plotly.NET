(**
// can't yet format YamlFrontmatter (["title: Range plots"; "category: Simple Charts"; "categoryindex: 3"; "index: 4"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# Range plots

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=02_3_range-plots.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/02_3_range-plots.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/02_3_range-plots.ipynb)

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
        Color = Color.fromString "grey",
        RangeColor = Color.fromString "lightblue")(* output: 
<div id="b2854ae6-0bba-449e-8dc4-f819a9eedfcd" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_b2854ae60bba449e8dc4f819a9eedfcd = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","mode":"lines","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[1.5303663520749502,0.5413959045155886,4.906717022837474,1.0254761634978822,2.3809827353716746,1.5868046344662106,2.1019216666938374,0.6763295154908344,2.7082197238729426,0.9780209804782741],"fillcolor":"lightblue","name":"lower","showlegend":false,"line":{"width":0.0},"marker":{"color":"lightblue"}},{"type":"scatter","mode":"lines","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.267306178001364,1.8560292200911928,5.467465744571512,1.8248687504440866,3.264025496441883,3.173289888386284,2.93260864747344,1.6457268121399575,4.028234999407192,1.6670751360557392],"fill":"tonexty","fillcolor":"lightblue","name":"upper","showlegend":false,"line":{"width":0.0},"marker":{"color":"lightblue"}},{"type":"scatter","mode":"lines+markers","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"fillcolor":"grey","line":{"color":"grey"},"marker":{"color":"grey"}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('b2854ae6-0bba-449e-8dc4-f819a9eedfcd', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_b2854ae60bba449e8dc4f819a9eedfcd();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_b2854ae60bba449e8dc4f819a9eedfcd();
            }
</script>
*)

