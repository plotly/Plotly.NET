(**
// can't yet format YamlFrontmatter (["title: Styling ternary layouts"; "category: Ternary Plots"; "categoryindex: 11"; "index: 2"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# Styling ternary layouts

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=10_1_styling_ternary_layouts.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/10_1_styling_ternary_layouts.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/10_1_styling_ternary_layouts.ipynb)

*Summary:* This example shows how to style polar layouts in F#.

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
Consider this combined ternary chart:

*)
let combinedTernary =
    [
        Chart.PointTernary(a,b,c)
        Chart.LineTernary(a,c,Sum = 10)
    ]
    
    |> Chart.combine(* output: 
<div id="e6dd76fa-4563-4a33-b058-42807a1a7123" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_e6dd76fa45634a33b05842807a1a7123 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatterternary","mode":"markers","a":[1,2,3,4,5,6,7],"b":[7,6,5,4,3,2,1],"c":[2,2,2,2,2,2,2],"marker":{}},{"type":"scatterternary","mode":"lines","a":[1,2,3,4,5,6,7],"b":[2,2,2,2,2,2,2],"sum":10,"line":{},"marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('e6dd76fa-4563-4a33-b058-42807a1a7123', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_e6dd76fa45634a33b05842807a1a7123();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_e6dd76fa45634a33b05842807a1a7123();
            }
</script>
*)
(**
## Styling the polar layout

Use the `Chart.withTernary` function and initialize a Ternary layout with the desired looks

*)
open Plotly.NET.LayoutObjects

let styledTernary = 
    combinedTernary
    |> Chart.withTernary(
        Ternary.init(
            AAxis = LinearAxis.init(Title = Title.init("A"), Color = Color.fromKeyword ColorKeyword.DarkOrchid),
            BAxis = LinearAxis.init(Title = Title.init("B"), Color = Color.fromKeyword ColorKeyword.DarkRed)
        )
    )(* output: 
<div id="adf195cd-701c-4351-aa4c-c95291c95935" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_adf195cd701c4351aa4cc95291c95935 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatterternary","mode":"markers","a":[1,2,3,4,5,6,7],"b":[7,6,5,4,3,2,1],"c":[2,2,2,2,2,2,2],"marker":{}},{"type":"scatterternary","mode":"lines","a":[1,2,3,4,5,6,7],"b":[2,2,2,2,2,2,2],"sum":10,"line":{},"marker":{}}];
            var layout = {"ternary":{"aaxis":{"color":"rgba(153, 50, 204, 1.0)","title":{"text":"A"}},"baxis":{"color":"rgba(139, 0, 0, 1.0)","title":{"text":"B"}}}};
            var config = {};
            Plotly.newPlot('adf195cd-701c-4351-aa4c-c95291c95935', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_adf195cd701c4351aa4cc95291c95935();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_adf195cd701c4351aa4cc95291c95935();
            }
</script>
*)
(**
## Styling A, B, and C Axes

You could pass these axes to `Chart.withTernary` as above, but for the case where you want to specifically set one axis, there are the `Chart.withAAxis`, `Chart.withBAxis`, `Chart.withCAxis` functions:

*)
let styledTernary2 =
    styledTernary
    |> Chart.withCAxis(LinearAxis.init(Title = Title.init("C"), Color = Color.fromKeyword ColorKeyword.DarkCyan))
    (* output: 
<div id="c8249184-e48a-43b2-b611-cc87c30c7b8d" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_c8249184e48a43b2b611cc87c30c7b8d = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatterternary","mode":"markers","a":[1,2,3,4,5,6,7],"b":[7,6,5,4,3,2,1],"c":[2,2,2,2,2,2,2],"marker":{}},{"type":"scatterternary","mode":"lines","a":[1,2,3,4,5,6,7],"b":[2,2,2,2,2,2,2],"sum":10,"line":{},"marker":{}}];
            var layout = {"ternary":{"aaxis":{"color":"rgba(153, 50, 204, 1.0)","title":{"text":"A"}},"baxis":{"color":"rgba(139, 0, 0, 1.0)","title":{"text":"B"}},"caxis":{"color":"rgba(0, 139, 139, 1.0)","title":{"text":"C"}}}};
            var config = {};
            Plotly.newPlot('c8249184-e48a-43b2-b611-cc87c30c7b8d', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_c8249184e48a43b2b611cc87c30c7b8d();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_c8249184e48a43b2b611cc87c30c7b8d();
            }
</script>
*)

