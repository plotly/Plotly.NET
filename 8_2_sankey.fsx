(**
// can't yet format YamlFrontmatter (["title: Sankey Charts"; "category: Categorical Charts"; "categoryindex: 10"; "index: 3"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# Sankey charts

[![Binder](https://plotly.github.io/Plotly.NET/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=8_2_sankey.ipynb)&emsp;
[![Script](https://plotly.github.io/Plotly.NET/img/badge-script.svg)](https://plotly.github.io/Plotly.NET/8_2_sankey.fsx)&emsp;
[![Notebook](https://plotly.github.io/Plotly.NET/img/badge-notebook.svg)](https://plotly.github.io/Plotly.NET/8_2_sankey.ipynb)

*Summary:* This example shows how to create sankey charts in F#.

Sankey charts are a visualization of multiple, linked graphs layed out linearly. 
These are usually used to depict flow between nodes or stations.
To create Sankey, a set of nodes and links between them are required. 
These are created using the provided Node and Link structures.
*)
open Plotly.NET 

// create nodes
let n1 = Node.Create("a",color="Black")
let n2 = Node.Create("b",color="Red")
let n3 = Node.Create("c",color="Purple")
let n4 = Node.Create("d",color="Green")
let n5 = Node.Create("e",color="Orange")

// create links between nodes
let link1 = Link.Create(n1,n2,value=1.0)
let link2 = Link.Create(n2,n3,value=2.0)
let link3 = Link.Create(n1,n5,value=1.3)
let link4 = Link.Create(n4,n5,value=1.5)
let link5 = Link.Create(n3,n5,value=0.5)

let sankey1 = 
    Chart.Sankey(
        [n1;n2;n3;n4;n5],
        [link1;link2;link3;link4;link5]
    )
    |> Chart.withTitle "Sankey Sample"(* output: 
<div id="d0fefea1-bcd6-4a30-b7e5-7b5f95b22365" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_d0fefea1bcd64a30b7e57b5f95b22365 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"sankey","node":{"label":["a","b","c","d","e"],"color":["Black","Red","Purple","Green","Orange"]},"link":{"source":[0,1,0,3,2],"target":[1,2,4,4,4],"value":[1.0,2.0,1.3,1.5,0.5]}}];
            var layout = {"title":"Sankey Sample"};
            var config = {};
            Plotly.newPlot('d0fefea1-bcd6-4a30-b7e5-7b5f95b22365', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_d0fefea1bcd64a30b7e57b5f95b22365();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_d0fefea1bcd64a30b7e57b5f95b22365();
            }
</script>
*)

