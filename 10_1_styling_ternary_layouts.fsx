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
<div id="93e344dc-b053-49bc-99bf-bce0e01b5c7b" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_93e344dcb05349bc99bfbce0e01b5c7b = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatterternary","mode":"markers","a":[1,2,3,4,5,6,7],"b":[7,6,5,4,3,2,1],"c":[2,2,2,2,2,2,2],"marker":{}},{"type":"scatterternary","mode":"lines","a":[1,2,3,4,5,6,7],"b":[2,2,2,2,2,2,2],"sum":10,"line":{},"marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('93e344dc-b053-49bc-99bf-bce0e01b5c7b', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_93e344dcb05349bc99bfbce0e01b5c7b();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_93e344dcb05349bc99bfbce0e01b5c7b();
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
<div id="c30f95fe-bca9-492a-b737-0ae8553562dd" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_c30f95febca9492ab7370ae8553562dd = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatterternary","mode":"markers","a":[1,2,3,4,5,6,7],"b":[7,6,5,4,3,2,1],"c":[2,2,2,2,2,2,2],"marker":{}},{"type":"scatterternary","mode":"lines","a":[1,2,3,4,5,6,7],"b":[2,2,2,2,2,2,2],"sum":10,"line":{},"marker":{}}];
            var layout = {"ternary":{"aaxis":{"color":"rgba(153, 50, 204, 1.0)","title":{"text":"A"}},"baxis":{"color":"rgba(139, 0, 0, 1.0)","title":{"text":"B"}}}};
            var config = {};
            Plotly.newPlot('c30f95fe-bca9-492a-b737-0ae8553562dd', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_c30f95febca9492ab7370ae8553562dd();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_c30f95febca9492ab7370ae8553562dd();
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
<div id="38e453d3-d5e0-49e8-83fb-28d35f6a173f" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_38e453d3d5e049e883fb28d35f6a173f = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatterternary","mode":"markers","a":[1,2,3,4,5,6,7],"b":[7,6,5,4,3,2,1],"c":[2,2,2,2,2,2,2],"marker":{}},{"type":"scatterternary","mode":"lines","a":[1,2,3,4,5,6,7],"b":[2,2,2,2,2,2,2],"sum":10,"line":{},"marker":{}}];
            var layout = {"ternary":{"aaxis":{"color":"rgba(153, 50, 204, 1.0)","title":{"text":"A"}},"baxis":{"color":"rgba(139, 0, 0, 1.0)","title":{"text":"B"}},"caxis":{"color":"rgba(0, 139, 139, 1.0)","title":{"text":"C"}}}};
            var config = {};
            Plotly.newPlot('38e453d3-d5e0-49e8-83fb-28d35f6a173f', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_38e453d3d5e049e883fb28d35f6a173f();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_38e453d3d5e049e883fb28d35f6a173f();
            }
</script>
*)

