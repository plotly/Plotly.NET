(**
// can't yet format YamlFrontmatter (["title: Axis styling"; "category: Chart Layout"; "categoryindex: 2"; "index: 1"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# Axis styling

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=1_0_axis-styling.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/1_0_axis-styling.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/1_0_axis-styling.ipynb)

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
<div id="a31c029f-55e1-479e-a878-40996ebbc133" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_a31c029f55e1479ea87840996ebbc133 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"mode":"markers","marker":{}}];
            var layout = {"xaxis":{"title":{"text":"X axis title"},"range":[-1.0,10.0]},"yaxis":{"title":{"text":"Y axis title"},"range":[-1.0,10.0]}};
            var config = {};
            Plotly.newPlot('a31c029f-55e1-479e-a878-40996ebbc133', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_a31c029f55e1479ea87840996ebbc133();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_a31c029f55e1479ea87840996ebbc133();
            }
</script>
*)
(**
for even more fine-grained control, initialize a new axis and replace the old one of the plot with ````.
The following example creates two mirrored axes with inside ticks, one of them with a log scale:
*)
let mirroredXAxis =
    Axis.LinearAxis.init(
        Title = Title.init(Text="Mirrored axis"),
        ShowLine = true,
        Mirror = StyleParam.Mirror.AllTicks,
        ShowGrid = false,
        Ticks = StyleParam.TickOptions.Inside
    )

let mirroredLogYAxis = 
    Axis.LinearAxis.init(
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
<div id="ba72326d-a66f-4651-a0fb-98a424620fab" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_ba72326da66f4651a0fb98a424620fab = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"mode":"markers","marker":{}}];
            var layout = {"xaxis":{"title":{"text":"Mirrored axis"},"ticks":"inside","mirror":"allticks","showline":true,"showgrid":false},"yaxis":{"title":{"text":"Log axis"},"axistype":"log","ticks":"inside","mirror":"allticks","showline":true,"showgrid":false}};
            var config = {};
            Plotly.newPlot('ba72326d-a66f-4651-a0fb-98a424620fab', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_ba72326da66f4651a0fb98a424620fab();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_ba72326da66f4651a0fb98a424620fab();
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
<div id="ea764891-2185-4823-8b55-e7cb8670ffe8" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_ea764891218548238b55e7cb8670ffe8 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"mode":"lines","line":{},"name":"anchor 1","marker":{},"yaxis":"y"},{"type":"scatter","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,7.0,3.0,5.0,5.0,6.0,3.0,10.0,3.0,4.0],"mode":"lines","line":{},"name":"anchor 2","marker":{},"yaxis":"y2"}];
            var layout = {"yaxis":{"title":{"text":"axis 1"},"side":"left"},"yaxis2":{"title":{"text":"axis2"},"side":"right","overlaying":"y"}};
            var config = {};
            Plotly.newPlot('ea764891-2185-4823-8b55-e7cb8670ffe8', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_ea764891218548238b55e7cb8670ffe8();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_ea764891218548238b55e7cb8670ffe8();
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
<div id="ad550ae3-a64d-4ec3-88de-915d99ccf4b1" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_ad550ae3a64d4ec388de915d99ccf4b1 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"mode":"lines","line":{},"name":"anchor 1","marker":{},"yaxis":"y"},{"type":"scatter","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,7.0,3.0,5.0,5.0,6.0,3.0,10.0,3.0,4.0],"mode":"lines","line":{},"name":"anchor 2","marker":{},"yaxis":"y2"}];
            var layout = {"yaxis":{"title":{"text":"first y-axis"},"side":"left","showline":true},"yaxis2":{"title":{"text":"second y-axis"},"side":"left","overlaying":"y","showline":true,"position":0.1},"xaxis":{"title":{"text":"x-axis"},"domain":[0.3,1.0]}};
            var config = {};
            Plotly.newPlot('ad550ae3-a64d-4ec3-88de-915d99ccf4b1', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_ad550ae3a64d4ec388de915d99ccf4b1();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_ad550ae3a64d4ec388de915d99ccf4b1();
            }
</script>
*)

