(**
// can't yet format YamlFrontmatter (["title: Layout images"; "category: Chart Layout"; "categoryindex: 2"; "index: 6"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# Annotations

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=01_5_layout_images.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/01_5_layout_images.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/01_5_layout_images.ipynb)


*Summary:* This example shows how to create Images and add them to the Charts in F#.

let's first create some data for the purpose of creating example charts:


*)
open Plotly.NET 
  
let x  = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
let y' = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
(**
use the `LayoutImage.init` function to generate an image, and either the `Chart.withLayoutImage` or the `Chart.withLayoutImages` function to add
multiple annotations at once.


*)
open Plotly.NET.LayoutObjects

let image = 
    LayoutImage.init(
        Source="https://fsharp.org/img/logo/fsharp.svg",
        XRef="x",
        YRef="y",
        X=0,
        Y=3,
        SizeX=2,
        SizeY=2,
        Sizing=StyleParam.LayoutImageSizing.Stretch,
        Opacity=0.5,
        Layer=StyleParam.Layer.Below
    )

let imageChart =
    Chart.Line(x,y',Name="line")    
    |> Chart.withLayoutImage(image)(* output: 
<div id="3ccca3ba-7bea-473c-8dc0-7d05edbb7111" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_3ccca3ba7bea473c8dc07d05edbb7111 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","mode":"lines","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"line":{},"name":"line","marker":{}}];
            var layout = {"images":[{"layer":"below","opacity":0.5,"sizex":2,"sizey":2,"sizing":"stretch","source":"https://fsharp.org/img/logo/fsharp.svg","x":0,"xref":"x","y":3,"yref":"y"}]};
            var config = {};
            Plotly.newPlot('3ccca3ba-7bea-473c-8dc0-7d05edbb7111', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_3ccca3ba7bea473c8dc07d05edbb7111();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_3ccca3ba7bea473c8dc07d05edbb7111();
            }
</script>
*)

