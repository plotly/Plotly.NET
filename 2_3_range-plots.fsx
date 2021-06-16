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
<div id="acf59d26-e6f2-499f-8d14-be0b95f32a33" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_acf59d26e6f2499f8d14be0b95f32a33 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[1.964870299196276,0.8224493723001561,4.996293976435575,1.1879822973571637,2.598617805912447,2.4232661588691484,2.1831276243008335,0.5189939104109043,2.9730419970457636,0.7727024582087539],"mode":"lines","fillcolor":"lightblue","name":"lower","showlegend":false,"line":{"width":0.0},"marker":{"color":"lightblue"}},{"type":"scatter","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.5062162980931886,2.1024740364414054,5.4989395539737025,2.3949992637592366,3.6603866525275572,3.1957419871798445,3.101349444874259,2.479765435205663,3.9852167635621583,1.2447161801367608],"mode":"lines","fill":"tonexty","fillcolor":"lightblue","name":"upper","showlegend":false,"line":{"width":0.0},"marker":{"color":"lightblue"}},{"type":"scatter","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"mode":"lines+markers","fillcolor":"grey","line":{"color":"grey"},"marker":{"color":"grey"}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('acf59d26-e6f2-499f-8d14-be0b95f32a33', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_acf59d26e6f2499f8d14be0b95f32a33();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_acf59d26e6f2499f8d14be0b95f32a33();
            }
</script>
*)

