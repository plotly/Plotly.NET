(**
// can't yet format YamlFrontmatter (["title: Multicharts and subplots"; "category: Chart Layout"; "categoryindex: 2"; "index: 3"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# Multicharts and subplots

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=01_2_multiple-charts.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/01_2_multiple-charts.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/01_2_multiple-charts.ipynb)

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
    |> Chart.combine

#if IPYNB
combinedChart
#endif // end cell with chart value in a notebook context(* output: 
<div id="6145167e-913b-47e8-90d3-9b39b23e4030" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_6145167e913b47e890d39b39b23e4030 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","mode":"lines","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"line":{},"name":"first","marker":{}},{"type":"scatter","mode":"lines","x":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"y":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"line":{},"name":"second","marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('6145167e-913b-47e8-90d3-9b39b23e4030', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_6145167e913b47e890d39b39b23e4030();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_6145167e913b47e890d39b39b23e4030();
            }
</script>
*)
(**
## Chart subplot grids

### Chart.Grid

`Chart.Grid` creates a subplot grid. There are two overloads:

You can either use Chart.Grid with a 1 dimensional sequence of Charts and specify the amount of rows and columns:


*)
//simple 2x2 subplot grid
let grid = 
    [
        Chart.Point(x,y,Name="1,1")
        |> Chart.withXAxisStyle "x1"
        |> Chart.withYAxisStyle "y1"    
        Chart.Line(x,y,Name="1,2")
        |> Chart.withXAxisStyle "x2"
        |> Chart.withYAxisStyle "y2"
        Chart.Spline(x,y,Name="2,1")
        |> Chart.withXAxisStyle "x3"
        |> Chart.withYAxisStyle "y3"    
        Chart.Point(x,y,Name="2,2")
        |> Chart.withXAxisStyle "x4"
        |> Chart.withYAxisStyle "y4"
    ]
    |> Chart.Grid(2,2)(* output: 
<div id="bbc0a7da-5e57-4ca5-895b-5a2dffd041b0" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_bbc0a7da5e574ca5895b5a2dffd041b0 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","mode":"markers","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"name":"1,1","marker":{},"xaxis":"x","yaxis":"y"},{"type":"scatter","mode":"lines","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"line":{},"name":"1,2","marker":{},"xaxis":"x2","yaxis":"y2"},{"type":"scatter","mode":"lines","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"name":"2,1","line":{"shape":"spline"},"marker":{},"xaxis":"x3","yaxis":"y3"},{"type":"scatter","mode":"markers","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"name":"2,2","marker":{},"xaxis":"x4","yaxis":"y4"}];
            var layout = {"xaxis":{"title":{"text":"x1"}},"yaxis":{"title":{"text":"y1"}},"xaxis2":{"title":{"text":"x2"}},"yaxis2":{"title":{"text":"y2"}},"xaxis3":{"title":{"text":"x3"}},"yaxis3":{"title":{"text":"y3"}},"xaxis4":{"title":{"text":"x4"}},"yaxis4":{"title":{"text":"y4"}},"grid":{"rows":2,"columns":2,"pattern":"independent"}};
            var config = {};
            Plotly.newPlot('bbc0a7da-5e57-4ca5-895b-5a2dffd041b0', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_bbc0a7da5e574ca5895b5a2dffd041b0();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_bbc0a7da5e574ca5895b5a2dffd041b0();
            }
</script>
*)
(**
or provide a 2-dimensional Chart sequence as input, the dimensions of the input will then be used to set the dimensions of the grid:

*)
//simple 2x2 subplot grid using a 2x2 2D chart sequence as input
let grid2 = 
    [
        [
            Chart.Point(x,y,Name="1,1")
            |> Chart.withXAxisStyle "x1"
            |> Chart.withYAxisStyle "y1"    
            Chart.Line(x,y,Name="1,2")
            |> Chart.withXAxisStyle "x2"
            |> Chart.withYAxisStyle "y2"
        ]
        [
            Chart.Spline(x,y,Name="2,1")
            |> Chart.withXAxisStyle "x3"
            |> Chart.withYAxisStyle "y3"    
            Chart.Point(x,y,Name="2,2")
            |> Chart.withXAxisStyle "x4"
            |> Chart.withYAxisStyle "y4"
        
        ]
    ]
    |> Chart.Grid()(* output: 
<div id="442101aa-5ff2-4be5-8656-1a8abb9ef5cb" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_442101aa5ff24be586561a8abb9ef5cb = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","mode":"markers","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"name":"1,1","marker":{},"xaxis":"x","yaxis":"y"},{"type":"scatter","mode":"lines","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"line":{},"name":"1,2","marker":{},"xaxis":"x2","yaxis":"y2"},{"type":"scatter","mode":"lines","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"name":"2,1","line":{"shape":"spline"},"marker":{},"xaxis":"x3","yaxis":"y3"},{"type":"scatter","mode":"markers","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"name":"2,2","marker":{},"xaxis":"x4","yaxis":"y4"}];
            var layout = {"xaxis":{"title":{"text":"x1"}},"yaxis":{"title":{"text":"y1"}},"xaxis2":{"title":{"text":"x2"}},"yaxis2":{"title":{"text":"y2"}},"xaxis3":{"title":{"text":"x3"}},"yaxis3":{"title":{"text":"y3"}},"xaxis4":{"title":{"text":"x4"}},"yaxis4":{"title":{"text":"y4"}},"grid":{"rows":2,"columns":2,"pattern":"independent"}};
            var config = {};
            Plotly.newPlot('442101aa-5ff2-4be5-8656-1a8abb9ef5cb', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_442101aa5ff24be586561a8abb9ef5cb();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_442101aa5ff24be586561a8abb9ef5cb();
            }
</script>
*)
(**
To leave cells of the grid empty, you have to fill it with dummy charts via `Chart.Invisible()`.
Pleas enote that when using a 2D sequence with unequal amounts of charts in the rows, the column amount will be set
to the row with the highest amount of charts, and the other rows will be filled by invisible charts to the right.

*)
//simple 2x2 subplot grid with an empty cell at position 1,2
let grid3 = 
    [
        Chart.Point(x,y,Name="1,1")
        |> Chart.withXAxisStyle "x1"
        |> Chart.withYAxisStyle "y1"    

        Chart.Invisible()

        Chart.Spline(x,y,Name="2,1")
        |> Chart.withXAxisStyle "x3"
        |> Chart.withYAxisStyle "y3"    

        Chart.Point(x,y,Name="2,2")
        |> Chart.withXAxisStyle "x4"
        |> Chart.withYAxisStyle "y4"
    ]
    |> Chart.Grid(2,2)(* output: 
<div id="a0dab4a4-0e83-4778-a750-5d4db15b4ac5" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_a0dab4a40e834778a7505d4db15b4ac5 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","mode":"markers","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"name":"1,1","marker":{},"xaxis":"x","yaxis":"y"},{"type":null,"xaxis":"x2","yaxis":"y2"},{"type":"scatter","mode":"lines","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"name":"2,1","line":{"shape":"spline"},"marker":{},"xaxis":"x3","yaxis":"y3"},{"type":"scatter","mode":"markers","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"name":"2,2","marker":{},"xaxis":"x4","yaxis":"y4"}];
            var layout = {"xaxis":{"title":{"text":"x1"}},"yaxis":{"title":{"text":"y1"}},"xaxis2":{"showticklabels":false,"showline":false,"showgrid":false,"zeroline":false},"yaxis2":{"showticklabels":false,"showline":false,"showgrid":false,"zeroline":false},"xaxis3":{"title":{"text":"x3"}},"yaxis3":{"title":{"text":"y3"}},"xaxis4":{"title":{"text":"x4"}},"yaxis4":{"title":{"text":"y4"}},"grid":{"rows":2,"columns":2,"pattern":"independent"}};
            var config = {};
            Plotly.newPlot('a0dab4a4-0e83-4778-a750-5d4db15b4ac5', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_a0dab4a40e834778a7505d4db15b4ac5();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_a0dab4a40e834778a7505d4db15b4ac5();
            }
</script>
*)
(**
use `Pattern=StyleParam.LayoutGridPatter.Coupled` to use one shared x axis per column and one shared y axis per row. 
(Try zooming in the single subplots below)

*)
let grid4 =
    [
        Chart.Point(x,y,Name="1,1")
        |> Chart.withXAxisStyle "x1"
        |> Chart.withYAxisStyle "y1"    
        Chart.Line(x,y,Name="1,2")
        |> Chart.withXAxisStyle "x2"
        |> Chart.withYAxisStyle "y2"
        Chart.Spline(x,y,Name="2,1")
        |> Chart.withXAxisStyle "x3"
        |> Chart.withYAxisStyle "y3"    
        Chart.Point(x,y,Name="2,2")
        |> Chart.withXAxisStyle "x4"
        |> Chart.withYAxisStyle "y4"
    ]
    |> Chart.Grid(2,2,Pattern=StyleParam.LayoutGridPattern.Coupled)(* output: 
<div id="8aa3ffac-d8a9-42ed-bab0-d2d251e76ec9" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_8aa3ffacd8a942edbab0d2d251e76ec9 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","mode":"markers","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"name":"1,1","marker":{},"xaxis":"x","yaxis":"y"},{"type":"scatter","mode":"lines","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"line":{},"name":"1,2","marker":{},"xaxis":"x2","yaxis":"y"},{"type":"scatter","mode":"lines","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"name":"2,1","line":{"shape":"spline"},"marker":{},"xaxis":"x","yaxis":"y2"},{"type":"scatter","mode":"markers","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"name":"2,2","marker":{},"xaxis":"x2","yaxis":"y2"}];
            var layout = {"xaxis":{"title":{"text":"x1"}},"yaxis":{"title":{"text":"y1"}},"xaxis2":{"title":{"text":"x2"}},"yaxis2":{"title":{"text":"y2"}},"xaxis3":{"title":{"text":"x3"}},"yaxis3":{"title":{"text":"y3"}},"xaxis4":{"title":{"text":"x4"}},"yaxis4":{"title":{"text":"y4"}},"grid":{"rows":2,"columns":2,"pattern":"coupled"}};
            var config = {};
            Plotly.newPlot('8aa3ffac-d8a9-42ed-bab0-d2d251e76ec9', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_8aa3ffacd8a942edbab0d2d251e76ec9();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_8aa3ffacd8a942edbab0d2d251e76ec9();
            }
</script>
*)
(**
### Chart.SingleStack

The `Chart.SingleStack` function is a special version of Chart.Grid that creates only one column from a 1D input chart sequence.
It uses a shared x axis per default.

As with all grid charts, you can also use the Chart.withLayoutGridStyle to style subplot grids:


*)
let singleStack =
    [
        Chart.Point(x,y) 
        |> Chart.withYAxisStyle("This title must")

        Chart.Line(x,y) 
        |> Chart.withYAxisStyle("be set on the")
        
        Chart.Spline(x,y) 
        |> Chart.withYAxisStyle("respective subplots")
    ]
    |> Chart.SingleStack(Pattern= StyleParam.LayoutGridPattern.Coupled)
    //increase spacing between plots by using the withLayoutGridStyle function
    |> Chart.withLayoutGridStyle(YGap= 0.1)
    |> Chart.withTitle("Hi i am the new SingleStackChart")
    |> Chart.withXAxisStyle("im the shared xAxis")(* output: 
<div id="1b4bdb92-dd14-408b-ae41-5dbcb8c37df5" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_1b4bdb92dd14408bae415dbcb8c37df5 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","mode":"markers","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"marker":{},"xaxis":"x","yaxis":"y"},{"type":"scatter","mode":"lines","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"line":{},"marker":{},"xaxis":"x","yaxis":"y2"},{"type":"scatter","mode":"lines","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"line":{"shape":"spline"},"marker":{},"xaxis":"x","yaxis":"y3"}];
            var layout = {"yaxis":{"title":{"text":"This title must"}},"xaxis":{"title":{"text":"im the shared xAxis"}},"xaxis2":{},"yaxis2":{"title":{"text":"be set on the"}},"xaxis3":{},"yaxis3":{"title":{"text":"respective subplots"}},"grid":{"rows":3,"columns":1,"pattern":"coupled","ygap":0.1},"title":{"text":"Hi i am the new SingleStackChart"}};
            var config = {};
            Plotly.newPlot('1b4bdb92-dd14-408b-ae41-5dbcb8c37df5', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_1b4bdb92dd14408bae415dbcb8c37df5();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_1b4bdb92dd14408bae415dbcb8c37df5();
            }
</script>
*)
(**
### Using subplots of different trace types in a grid

Chart.Grid does some internal magic to make sure that all trace types get their grid cell according to plotly.js's inner logic. 

The only thing you have to consider is, that when you are using nested combined charts, that these have to have the same trace type.

Otherwise, you can freely combine all charts with Chart.Grid:


*)
open Plotly.NET.LayoutObjects

let multipleTraceTypesGrid =
    [
        Chart.Point([1,2; 2,3])
        Chart.PointTernary([1,2,3; 2,3,4])
        Chart.Heatmap([[1; 2];[3; 4]], Showscale=false)
        Chart.Point3d([1,3,2])
        Chart.PointMapbox([1,2]) |> Chart.withMapbox(Mapbox.init(Style = StyleParam.MapboxStyle.OpenStreetMap))
        [
            // you can use nested combined charts, but they have to have the same trace type (Cartesian2D in this case)
            let y =  [2.; 1.5; 5.; 1.5; 2.; 2.5; 2.1; 2.5; 1.5; 1.;2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
            Chart.BoxPlot("y" ,y,Name="bin1",Jitter=0.1,Boxpoints=StyleParam.Boxpoints.All);
            Chart.BoxPlot("y'",y,Name="bin2",Jitter=0.1,Boxpoints=StyleParam.Boxpoints.All);
        ]
        |> Chart.combine
    ]
    |> Chart.Grid(2,3)
    |> Chart.withSize(1000,1000)(* output: 
<div id="32808a48-101c-4a8a-be59-21a69e44017e" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_32808a48101c4a8abe5921a69e44017e = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","mode":"markers","x":[1,2],"y":[2,3],"marker":{},"xaxis":"x","yaxis":"y"},{"type":"scatterternary","mode":"markers","a":[1,2],"b":[2,3],"c":[3,4],"marker":{},"subplot":"ternary2"},{"type":"heatmap","z":[[1,2],[3,4]],"showscale":false,"xaxis":"x3","yaxis":"y3"},{"type":"scatter3d","mode":"markers","x":[1],"y":[3],"z":[2],"line":{},"marker":{},"scene":"scene4"},{"type":"scattermapbox","mode":"markers","lon":[1],"lat":[2],"line":{},"marker":{},"subplot":"mapbox5"},{"type":"box","y":[2.0,1.5,5.0,1.5,2.0,2.5,2.1,2.5,1.5,1.0,2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"x":"y","boxpoints":"all","jitter":0.1,"name":"bin1","marker":{},"xaxis":"x6","yaxis":"y6"},{"type":"box","y":[2.0,1.5,5.0,1.5,2.0,2.5,2.1,2.5,1.5,1.0,2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"x":"y'","boxpoints":"all","jitter":0.1,"name":"bin2","marker":{},"xaxis":"x6","yaxis":"y6"}];
            var layout = {"xaxis":{},"yaxis":{},"ternary2":{"domain":{"row":0,"column":1}},"xaxis3":{},"yaxis3":{},"scene4":{"domain":{"row":1,"column":0}},"mapbox":{"style":"open-street-map","domain":{"row":1,"column":1}},"mapbox5":{"style":"open-street-map","domain":{"row":1,"column":1}},"xaxis6":{},"yaxis6":{},"grid":{"rows":2,"columns":3,"pattern":"independent"},"width":1000,"height":1000};
            var config = {};
            Plotly.newPlot('32808a48-101c-4a8a-be59-21a69e44017e', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_32808a48101c4a8abe5921a69e44017e();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_32808a48101c4a8abe5921a69e44017e();
            }
</script>
*)
    
(**
If you are not sure if traceTypes are compatible, look at the `TraceIDs`:

*)
let pointType = Chart.Point([1,2]) |> GenericChart.getTraceID(* output: 
<null>*)
[
     Chart.Point([1,2])
     Chart.PointTernary([1,2,3])
]
|> Chart.combine
|> GenericChart.getTraceID(* output: 
Multi*)
[
     Chart.Point([1,2])
     Chart.PointTernary([1,2,3])
]
|> Chart.combine
|> GenericChart.getTraceIDs(* output: 
[Cartesian2D; Ternary]*)

