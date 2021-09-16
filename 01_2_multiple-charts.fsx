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
<div id="31b55b85-bc89-48e4-be45-64ae604d9243" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_31b55b85bc8948e4be4564ae604d9243 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","mode":"lines","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"line":{},"name":"first","marker":{}},{"type":"scatter","mode":"lines","x":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"y":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"line":{},"name":"second","marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('31b55b85-bc89-48e4-be45-64ae604d9243', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_31b55b85bc8948e4be4564ae604d9243();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_31b55b85bc8948e4be4564ae604d9243();
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
<div id="ede28217-0037-48db-9fd3-a6c70b6c227e" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_ede28217003748db9fd3a6c70b6c227e = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","mode":"markers","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"name":"1,1","marker":{},"xaxis":"x","yaxis":"y"},{"type":"scatter","mode":"lines","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"line":{},"name":"1,2","marker":{},"xaxis":"x2","yaxis":"y2"},{"type":"scatter","mode":"lines","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"name":"2,1","line":{"shape":"spline"},"marker":{},"xaxis":"x3","yaxis":"y3"},{"type":"scatter","mode":"markers","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"name":"2,2","marker":{},"xaxis":"x4","yaxis":"y4"}];
            var layout = {"xaxis":{"title":{"text":"x1"}},"yaxis":{"title":{"text":"y1"}},"xaxis2":{"title":{"text":"x2"}},"yaxis2":{"title":{"text":"y2"}},"xaxis3":{"title":{"text":"x3"}},"yaxis3":{"title":{"text":"y3"}},"xaxis4":{"title":{"text":"x4"}},"yaxis4":{"title":{"text":"y4"}},"grid":{"rows":2,"columns":2,"pattern":"independent"}};
            var config = {};
            Plotly.newPlot('ede28217-0037-48db-9fd3-a6c70b6c227e', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_ede28217003748db9fd3a6c70b6c227e();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_ede28217003748db9fd3a6c70b6c227e();
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
<div id="c4f4374a-aa73-4bc6-a831-5298fb247ad1" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_c4f4374aaa734bc6a8315298fb247ad1 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","mode":"markers","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"name":"1,1","marker":{},"xaxis":"x","yaxis":"y"},{"type":"scatter","mode":"lines","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"line":{},"name":"1,2","marker":{},"xaxis":"x2","yaxis":"y2"},{"type":"scatter","mode":"lines","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"name":"2,1","line":{"shape":"spline"},"marker":{},"xaxis":"x3","yaxis":"y3"},{"type":"scatter","mode":"markers","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"name":"2,2","marker":{},"xaxis":"x4","yaxis":"y4"}];
            var layout = {"xaxis":{"title":{"text":"x1"}},"yaxis":{"title":{"text":"y1"}},"xaxis2":{"title":{"text":"x2"}},"yaxis2":{"title":{"text":"y2"}},"xaxis3":{"title":{"text":"x3"}},"yaxis3":{"title":{"text":"y3"}},"xaxis4":{"title":{"text":"x4"}},"yaxis4":{"title":{"text":"y4"}},"grid":{"rows":2,"columns":2,"pattern":"independent"}};
            var config = {};
            Plotly.newPlot('c4f4374a-aa73-4bc6-a831-5298fb247ad1', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_c4f4374aaa734bc6a8315298fb247ad1();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_c4f4374aaa734bc6a8315298fb247ad1();
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
<div id="69627a93-b3c6-4dac-adf2-ebcd470501a1" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_69627a93b3c64dacadf2ebcd470501a1 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","mode":"markers","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"name":"1,1","marker":{},"xaxis":"x","yaxis":"y"},{"type":null,"xaxis":"x2","yaxis":"y2"},{"type":"scatter","mode":"lines","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"name":"2,1","line":{"shape":"spline"},"marker":{},"xaxis":"x3","yaxis":"y3"},{"type":"scatter","mode":"markers","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"name":"2,2","marker":{},"xaxis":"x4","yaxis":"y4"}];
            var layout = {"xaxis":{"title":{"text":"x1"}},"yaxis":{"title":{"text":"y1"}},"xaxis2":{"showticklabels":false,"showline":false,"showgrid":false,"zeroline":false},"yaxis2":{"showticklabels":false,"showline":false,"showgrid":false,"zeroline":false},"xaxis3":{"title":{"text":"x3"}},"yaxis3":{"title":{"text":"y3"}},"xaxis4":{"title":{"text":"x4"}},"yaxis4":{"title":{"text":"y4"}},"grid":{"rows":2,"columns":2,"pattern":"independent"}};
            var config = {};
            Plotly.newPlot('69627a93-b3c6-4dac-adf2-ebcd470501a1', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_69627a93b3c64dacadf2ebcd470501a1();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_69627a93b3c64dacadf2ebcd470501a1();
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
<div id="6c8e5ccd-778e-415f-bd6c-03b86a5a0fe1" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_6c8e5ccd778e415fbd6c03b86a5a0fe1 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","mode":"markers","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"name":"1,1","marker":{},"xaxis":"x","yaxis":"y"},{"type":"scatter","mode":"lines","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"line":{},"name":"1,2","marker":{},"xaxis":"x2","yaxis":"y"},{"type":"scatter","mode":"lines","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"name":"2,1","line":{"shape":"spline"},"marker":{},"xaxis":"x","yaxis":"y2"},{"type":"scatter","mode":"markers","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"name":"2,2","marker":{},"xaxis":"x2","yaxis":"y2"}];
            var layout = {"xaxis":{"title":{"text":"x1"}},"yaxis":{"title":{"text":"y1"}},"xaxis2":{"title":{"text":"x2"}},"yaxis2":{"title":{"text":"y2"}},"xaxis3":{"title":{"text":"x3"}},"yaxis3":{"title":{"text":"y3"}},"xaxis4":{"title":{"text":"x4"}},"yaxis4":{"title":{"text":"y4"}},"grid":{"rows":2,"columns":2,"pattern":"coupled"}};
            var config = {};
            Plotly.newPlot('6c8e5ccd-778e-415f-bd6c-03b86a5a0fe1', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_6c8e5ccd778e415fbd6c03b86a5a0fe1();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_6c8e5ccd778e415fbd6c03b86a5a0fe1();
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
<div id="358f9891-51f2-4b98-9831-13305ed3b84b" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_358f989151f24b98983113305ed3b84b = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","mode":"markers","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"marker":{},"xaxis":"x","yaxis":"y"},{"type":"scatter","mode":"lines","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"line":{},"marker":{},"xaxis":"x","yaxis":"y2"},{"type":"scatter","mode":"lines","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"line":{"shape":"spline"},"marker":{},"xaxis":"x","yaxis":"y3"}];
            var layout = {"yaxis":{"title":{"text":"This title must"}},"xaxis":{"title":{"text":"im the shared xAxis"}},"xaxis2":{},"yaxis2":{"title":{"text":"be set on the"}},"xaxis3":{},"yaxis3":{"title":{"text":"respective subplots"}},"grid":{"rows":3,"columns":1,"pattern":"coupled","ygap":0.1},"title":{"text":"Hi i am the new SingleStackChart"}};
            var config = {};
            Plotly.newPlot('358f9891-51f2-4b98-9831-13305ed3b84b', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_358f989151f24b98983113305ed3b84b();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_358f989151f24b98983113305ed3b84b();
            }
</script>
*)

