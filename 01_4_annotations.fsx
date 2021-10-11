(**
// can't yet format YamlFrontmatter (["title: Annotations"; "category: Chart Layout"; "categoryindex: 2"; "index: 5"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# Annotations

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=01_4_annotations.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/01_4_annotations.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/01_4_annotations.ipynb)


*Summary:* This example shows how to create Shapes and add them to the Charts in F#.

let's first create some data for the purpose of creating example charts:


*)
open Plotly.NET 
  
let x  = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
let y' = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
(**
use the `Annotation.init` function to generate a shape, and either the `Chart.withAnnotation` or the `Chart.withAnnotations` function to add
multiple annotations at once.


*)
open Plotly.NET.LayoutObjects

let a1 = Annotation.init (X=2.,Y=4.,Text = "Hi there!")
let a2 = Annotation.init (X=5.,Y=7.,Text="I am another annotation!",BGColor= Color.fromString "white",BorderColor= Color.fromString  "black")

let annotations =
    Chart.Line(x,y',Name="line")    
    |> Chart.withAnnotations([a1;a2])(* output: 
<div id="9b948b29-9a0e-492f-aa6d-e33eab2fa9ae" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_9b948b299a0e492faa6de33eab2fa9ae = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","mode":"lines","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"line":{},"name":"line","marker":{}}];
            var layout = {"annotations":[{"x":2.0,"y":4.0,"text":"Hi there!"},{"x":5.0,"y":7.0,"bgcolor":"white","bordercolor":"black","text":"I am another annotation!"}]};
            var config = {};
            Plotly.newPlot('9b948b29-9a0e-492f-aa6d-e33eab2fa9ae', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_9b948b299a0e492faa6de33eab2fa9ae();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_9b948b299a0e492faa6de33eab2fa9ae();
            }
</script>
*)

