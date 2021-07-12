(**
// can't yet format YamlFrontmatter (["title: Multicharts and subplots"; "category: Chart Layout"; "categoryindex: 2"; "index: 3"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# Multicharts and subplots

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=1_2_multiple-charts.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/1_2_multiple-charts.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/1_2_multiple-charts.ipynb)

*Summary:* This example shows how to create charts with multiple subplots in F#.

let's first create some data for the purpose of creating example charts:

*)
open Plotly.NET 
  
let x = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
let y = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
(**
## Combining charts

`Chart.Combine` takes a sequence of charts, and attempts to combine their layouts to 
produce a composite chart with one layout containing all traces of the input:

*)
let combinedChart = 
    [
        Chart.Line(x,y,Name="first")
        Chart.Line(y,x,Name="second")
    ]
    |> Chart.Combine

#if IPYNB
combinedChart
#endif // end cell with chart value in a notebook context(* output: 
<div id="13eea1c9-5fc0-4d6a-8fee-2bad2652447d" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_13eea1c95fc04d6a8fee2bad2652447d = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"mode":"lines","line":{},"name":"first","marker":{}},{"type":"scatter","x":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"y":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"mode":"lines","line":{},"name":"second","marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('13eea1c9-5fc0-4d6a-8fee-2bad2652447d', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_13eea1c95fc04d6a8fee2bad2652447d();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_13eea1c95fc04d6a8fee2bad2652447d();
            }
</script>
*)
(**
## Chart subplot grids

### Chart.Grid

`Chart.Grid` takes a 2D input sequence of charts and creates a subplot grid 
with the dimensions (outerlength,(max (innerLengths))

*)
//simple 3x3 subplot grid
let grid = 
    Chart.Grid(
        [
            [Chart.Line(x,y); Chart.Line(x,y); Chart.Line(x,y)]
            [Chart.Point(x,y); Chart.Point(x,y); Chart.Point(x,y)]
            [Chart.Spline(x,y); Chart.Spline(x,y); Chart.Spline(x,y)]
        ]
    )(* output: 
<div id="7747c3f0-9f01-47d2-9f91-f3e4bd2274cb" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_7747c3f09f0147d29f91f3e4bd2274cb = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"mode":"lines","line":{},"marker":{},"xaxis":"x","yaxis":"y"},{"type":"scatter","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"mode":"lines","line":{},"marker":{},"xaxis":"x2","yaxis":"y2"},{"type":"scatter","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"mode":"lines","line":{},"marker":{},"xaxis":"x3","yaxis":"y3"},{"type":"scatter","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"mode":"markers","marker":{},"xaxis":"x4","yaxis":"y4"},{"type":"scatter","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"mode":"markers","marker":{},"xaxis":"x5","yaxis":"y5"},{"type":"scatter","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"mode":"markers","marker":{},"xaxis":"x6","yaxis":"y6"},{"type":"scatter","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"mode":"lines","line":{"shape":"spline"},"marker":{},"xaxis":"x7","yaxis":"y7"},{"type":"scatter","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"mode":"lines","line":{"shape":"spline"},"marker":{},"xaxis":"x8","yaxis":"y8"},{"type":"scatter","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"mode":"lines","line":{"shape":"spline"},"marker":{},"xaxis":"x9","yaxis":"y9"}];
            var layout = {"xaxis":{"anchor":"x","domain":[0.0,0.3083333333333333]},"yaxis":{"anchor":"y","domain":[0.0,0.3083333333333333]},"xaxis2":{"anchor":"x2","domain":[0.35833333333333334,0.6416666666666666]},"yaxis2":{"anchor":"y2","domain":[0.0,0.3083333333333333]},"xaxis3":{"anchor":"x3","domain":[0.6916666666666667,0.975]},"yaxis3":{"anchor":"y3","domain":[0.0,0.3083333333333333]},"xaxis4":{"anchor":"x4","domain":[0.0,0.3083333333333333]},"yaxis4":{"anchor":"y4","domain":[0.35833333333333334,0.6416666666666666]},"xaxis5":{"anchor":"x5","domain":[0.35833333333333334,0.6416666666666666]},"yaxis5":{"anchor":"y5","domain":[0.35833333333333334,0.6416666666666666]},"xaxis6":{"anchor":"x6","domain":[0.6916666666666667,0.975]},"yaxis6":{"anchor":"y6","domain":[0.35833333333333334,0.6416666666666666]},"xaxis7":{"anchor":"x7","domain":[0.0,0.3083333333333333]},"yaxis7":{"anchor":"y7","domain":[0.6916666666666667,0.975]},"xaxis8":{"anchor":"x8","domain":[0.35833333333333334,0.6416666666666666]},"yaxis8":{"anchor":"y8","domain":[0.6916666666666667,0.975]},"xaxis9":{"anchor":"x9","domain":[0.6916666666666667,0.975]},"yaxis9":{"anchor":"y9","domain":[0.6916666666666667,0.975]},"grid":{"rows":3,"columns":3,"roworder":"top to bottom","pattern":"independent","xgap":0.05,"ygap":0.05}};
            var config = {};
            Plotly.newPlot('7747c3f0-9f01-47d2-9f91-f3e4bd2274cb', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_7747c3f09f0147d29f91f3e4bd2274cb();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_7747c3f09f0147d29f91f3e4bd2274cb();
            }
</script>
*)
(**
use `sharedAxis=true` to use one shared x axis per column and one shared y axis per row. 
(Try zooming in the single subplots below)
*)
let grid2 =
    Chart.Grid(
        [
            [Chart.Line(x,y); Chart.Line(x,y); Chart.Line(x,y)]
            [Chart.Point(x,y); Chart.Point(x,y); Chart.Point(x,y)]
            [Chart.Spline(x,y); Chart.Spline(x,y); Chart.Spline(x,y)]
        ],
        sharedAxes=true
    )
    |> Chart.withLayoutGridStyle(
        XSide = StyleParam.LayoutGridXSide.Bottom
    )(* output: 
<div id="e61ba95e-3cfe-4d68-a343-891b2554ae0b" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_e61ba95e3cfe4d68a343891b2554ae0b = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"mode":"lines","line":{},"marker":{},"xaxis":"x","yaxis":"y"},{"type":"scatter","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"mode":"lines","line":{},"marker":{},"xaxis":"x2","yaxis":"y"},{"type":"scatter","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"mode":"lines","line":{},"marker":{},"xaxis":"x3","yaxis":"y"},{"type":"scatter","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"mode":"markers","marker":{},"xaxis":"x","yaxis":"y2"},{"type":"scatter","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"mode":"markers","marker":{},"xaxis":"x2","yaxis":"y2"},{"type":"scatter","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"mode":"markers","marker":{},"xaxis":"x3","yaxis":"y2"},{"type":"scatter","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"mode":"lines","line":{"shape":"spline"},"marker":{},"xaxis":"x","yaxis":"y3"},{"type":"scatter","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"mode":"lines","line":{"shape":"spline"},"marker":{},"xaxis":"x2","yaxis":"y3"},{"type":"scatter","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"mode":"lines","line":{"shape":"spline"},"marker":{},"xaxis":"x3","yaxis":"y3"}];
            var layout = {"xaxis":{"anchor":"x","domain":[0.0,0.3083333333333333]},"yaxis":{"anchor":"y","domain":[0.0,0.3083333333333333]},"xaxis2":{"anchor":"x2","domain":[0.35833333333333334,0.6416666666666666]},"xaxis3":{"anchor":"x3","domain":[0.6916666666666667,0.975]},"yaxis2":{"anchor":"y2","domain":[0.35833333333333334,0.6416666666666666]},"yaxis3":{"anchor":"y3","domain":[0.6916666666666667,0.975]},"grid":{"rows":3,"columns":3,"roworder":"top to bottom","pattern":"coupled","xgap":0.05,"ygap":0.05,"xside":"bottom"}};
            var config = {};
            Plotly.newPlot('e61ba95e-3cfe-4d68-a343-891b2554ae0b', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_e61ba95e3cfe4d68a343891b2554ae0b();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_e61ba95e3cfe4d68a343891b2554ae0b();
            }
</script>
*)
(**
### Chart.SingleStack

The `Chart.SingleStack` function is a special version of Chart.Grid that creates only one column from a 1D input chart sequence.
It uses a shared x axis per default. You can also use the Chart.withLayoutGridStyle to further style subplot grids:

*)
let singleStack =
    [
        Chart.Point(x,y) 
        |> Chart.withY_AxisStyle("This title must")

        Chart.Line(x,y) 
        |> Chart.withY_AxisStyle("be set on the",Zeroline=false)
        
        Chart.Spline(x,y) 
        |> Chart.withY_AxisStyle("respective subplots",Zeroline=false)
    ]
    |> Chart.SingleStack
    //move xAxis to bottom and increase spacing between plots by using the withLayoutGridStyle function
    |> Chart.withLayoutGridStyle(XSide=StyleParam.LayoutGridXSide.Bottom,YGap= 0.1)
    |> Chart.withTitle("Hi i am the new SingleStackChart")
    |> Chart.withX_AxisStyle("im the shared xAxis")(* output: 
<div id="6b3ad997-68a1-45b6-9213-fad6381ed911" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_6b3ad99768a145b69213fad6381ed911 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"mode":"markers","marker":{},"xaxis":"x","yaxis":"y"},{"type":"scatter","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"mode":"lines","line":{},"marker":{},"xaxis":"x","yaxis":"y2"},{"type":"scatter","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"mode":"lines","line":{"shape":"spline"},"marker":{},"xaxis":"x","yaxis":"y3"}];
            var layout = {"xaxis":{"anchor":"x","domain":[0.0,0.975],"title":"im the shared xAxis"},"yaxis":{"title":"This title must","anchor":"y","domain":[0.0,0.3083333333333333]},"yaxis2":{"title":"be set on the","zeroline":false,"anchor":"y2","domain":[0.35833333333333334,0.6416666666666666]},"yaxis3":{"title":"respective subplots","zeroline":false,"anchor":"y3","domain":[0.6916666666666667,0.975]},"grid":{"rows":3,"columns":1,"roworder":"bottom to top","pattern":"coupled","xgap":0.05,"ygap":0.1,"xside":"bottom"},"title":"Hi i am the new SingleStackChart"};
            var config = {};
            Plotly.newPlot('6b3ad997-68a1-45b6-9213-fad6381ed911', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_6b3ad99768a145b69213fad6381ed911();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_6b3ad99768a145b69213fad6381ed911();
            }
</script>
*)

