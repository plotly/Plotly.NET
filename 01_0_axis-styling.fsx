(**
// can't yet format YamlFrontmatter (["title: Axis styling"; "category: Chart Layout"; "categoryindex: 2"; "index: 1"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# Axis styling

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=01_0_axis-styling.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/01_0_axis-styling.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/01_0_axis-styling.ipynb)

*Summary:* This example shows how to style chart axes in F#.

let's first create some data for the purpose of creating example charts:

*)
open Plotly.NET 
  
let x = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
let y = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
let y' = y |> List.map (fun y -> y * 2.) |> List.rev
(**
## Single axis styling

To style a specific axis of a plot, use the respective `Chart.with*_AxisStyle` function:


*)
let plot1 =
    Chart.Point(x,y)
    |> Chart.withXAxisStyle ("X axis title", MinMax = (-1.,10.))
    |> Chart.withYAxisStyle ("Y axis title", MinMax = (-1.,10.))(* output: 
<div id="888b42b3-f762-4e43-baee-80003b31800d" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_888b42b3f7624e43baee80003b31800d = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","mode":"markers","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"marker":{}}];
            var layout = {"xaxis":{"title":{"text":"X axis title"},"range":[-1.0,10.0]},"yaxis":{"title":{"text":"Y axis title"},"range":[-1.0,10.0]}};
            var config = {};
            Plotly.newPlot('888b42b3-f762-4e43-baee-80003b31800d', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_888b42b3f7624e43baee80003b31800d();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_888b42b3f7624e43baee80003b31800d();
            }
</script>
*)
(**
for even more fine-grained control, initialize a new axis and replace the old one of the plot with ````.
The following example creates two mirrored axes with inside ticks, one of them with a log scale:

*)
open Plotly.NET.LayoutObjects // this namespace contains all object abstractions for layout styling

let mirroredXAxis =
    LinearAxis.init(
        Title = Title.init(Text="Mirrored axis"),
        ShowLine = true,
        Mirror = StyleParam.Mirror.AllTicks,
        ShowGrid = false,
        Ticks = StyleParam.TickOptions.Inside
    )

let mirroredLogYAxis = 
    LinearAxis.init(
        Title = Title.init(Text="Log axis"),
        AxisType = StyleParam.AxisType.Log,
        ShowLine = true,
        Mirror = StyleParam.Mirror.AllTicks,
        ShowGrid = false,
        Ticks = StyleParam.TickOptions.Inside
    )

let plot2 =
    Chart.Point(x,y)
    |> Chart.withXAxis mirroredXAxis
    |> Chart.withYAxis mirroredLogYAxis(* output: 
<div id="5c784fd5-6212-4298-b4f1-a46c6055bea2" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_5c784fd562124298b4f1a46c6055bea2 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","mode":"markers","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"marker":{}}];
            var layout = {"xaxis":{"title":{"text":"Mirrored axis"},"ticks":"inside","mirror":"allticks","showline":true,"showgrid":false},"yaxis":{"title":{"text":"Log axis"},"type":"log","ticks":"inside","mirror":"allticks","showline":true,"showgrid":false}};
            var config = {};
            Plotly.newPlot('5c784fd5-6212-4298-b4f1-a46c6055bea2', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_5c784fd562124298b4f1a46c6055bea2();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_5c784fd562124298b4f1a46c6055bea2();
            }
</script>
*)
(**
## Multiple axes

Assign different axis anchors to subplots to map them to different axes.

### Multiple axes on different sides of the chart

The following example first creates a multichart containing two plots with different axis anchors.
Subsequently, multiple axes with the respective anchors are added to the plot. 
Note that the same can be done as above, defining axes beforehand.


*)
let anchoredAt1 =
    Chart.Line (x,y,Name="anchor 1")
        |> Chart.withAxisAnchor(Y=1)

let anchoredAt2 =
     Chart.Line (x,y',Name="anchor 2")
        |> Chart.withAxisAnchor(Y=2)

let twoXAxes1 = 
    [
       anchoredAt1
       anchoredAt2
    ]
    |> Chart.combine
    |> Chart.withYAxisStyle(
        "axis 1",
        Side=StyleParam.Side.Left,
        Id=StyleParam.SubPlotId.YAxis 1
    )
    |> Chart.withYAxisStyle(
        "axis2",
        Side=StyleParam.Side.Right,
        Id=StyleParam.SubPlotId.YAxis 2,
        Overlaying=StyleParam.LinearAxisId.Y 1
    )
        (* output: 
<div id="c6db9a9f-f64a-47d5-a2d8-b34e36806f8e" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_c6db9a9ff64a47d5a2d8b34e36806f8e = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","mode":"lines","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"line":{},"name":"anchor 1","marker":{},"yaxis":"y"},{"type":"scatter","mode":"lines","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,7.0,3.0,5.0,5.0,6.0,3.0,10.0,3.0,4.0],"line":{},"name":"anchor 2","marker":{},"yaxis":"y2"}];
            var layout = {"yaxis":{"title":{"text":"axis 1"},"side":"left"},"yaxis2":{"title":{"text":"axis2"},"side":"right","overlaying":"y"}};
            var config = {};
            Plotly.newPlot('c6db9a9f-f64a-47d5-a2d8-b34e36806f8e', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_c6db9a9ff64a47d5a2d8b34e36806f8e();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_c6db9a9ff64a47d5a2d8b34e36806f8e();
            }
</script>
*)
(**
### Multiple axes on the same side of the chart

Analogous to above, but move the whole plot to the right by adjusting its domain, and then add a second axis to the left:


*)
let twoXAxes2 =
    [
        anchoredAt1
        anchoredAt2
    ]
    |> Chart.combine
    |> Chart.withYAxisStyle(
            "first y-axis",
            ShowLine=true
            )
    |> Chart.withXAxisStyle(
        "x-axis",
        Domain=(0.3, 1.0) // moves the first axis and the whole plot to the right
    ) 
    |> Chart.withYAxisStyle(
        "second y-axis",
        Side=StyleParam.Side.Left,
        Id=StyleParam.SubPlotId.YAxis 2,
        Overlaying=StyleParam.LinearAxisId.Y 1,
        Position=0.10, // position the axis beteen the leftmost edge and the firt axis at 0.3
        //Anchor=StyleParam.AxisAnchorId.Free,
        ShowLine=true
    )(* output: 
<div id="9fd53333-5f6c-404b-899d-b3e1f4ccc23b" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_9fd533335f6c404b899db3e1f4ccc23b = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","mode":"lines","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"line":{},"name":"anchor 1","marker":{},"yaxis":"y"},{"type":"scatter","mode":"lines","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,7.0,3.0,5.0,5.0,6.0,3.0,10.0,3.0,4.0],"line":{},"name":"anchor 2","marker":{},"yaxis":"y2"}];
            var layout = {"yaxis":{"title":{"text":"first y-axis"},"side":"left","showline":true},"yaxis2":{"title":{"text":"second y-axis"},"side":"left","overlaying":"y","showline":true,"position":0.1},"xaxis":{"title":{"text":"x-axis"},"domain":[0.3,1.0]}};
            var config = {};
            Plotly.newPlot('9fd53333-5f6c-404b-899d-b3e1f4ccc23b', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_9fd533335f6c404b899db3e1f4ccc23b();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_9fd533335f6c404b899db3e1f4ccc23b();
            }
</script>
*)

