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
<div id="40354315-73a3-4e54-8945-5332f23e17a3" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_4035431573a34e5489455332f23e17a3 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[1.7547341407065904,1.0440387090407492,4.771191915390637,1.3555206329820308,2.5995077321303577,1.8186053886630598,1.8169619679995637,1.165672230378572,2.686723381367849,0.26636533404996865],"mode":"lines","fillcolor":"lightblue","showlegend":false,"line":{"width":0.0},"marker":{"color":"lightblue"}},{"type":"scatter","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.3233294847064325,2.3924213353974846,5.615513393476379,1.8260769994585202,3.0869986373404967,2.60194356325173,3.111799177067261,1.6737553883221725,3.9250133072142552,1.4198159516881295],"mode":"lines","fill":"tonexty","fillcolor":"lightblue","showlegend":false,"line":{"width":0.0},"marker":{"color":"lightblue"}},{"type":"scatter","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"mode":"lines+markers","fillcolor":"grey","line":{"color":"grey"},"marker":{"color":"grey"}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('40354315-73a3-4e54-8945-5332f23e17a3', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_4035431573a34e5489455332f23e17a3();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_4035431573a34e5489455332f23e17a3();
            }
</script>
*)

