(**
// can't yet format YamlFrontmatter (["title: Polar bar charts"; "category: Polar Charts"; "categoryindex: 9 "; "index: 2"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# Polar bar charts

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=08_1_polar_bar_charts.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/08_1_polar_bar_charts.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/08_1_polar_bar_charts.ipynb)

*Summary:* This example shows how to create polar bar charts in F#.

let's first create some data for the purpose of creating example charts:


*)
open Plotly.NET 
  
let r   = [77.5; 72.5; 70.0; 45.0; 22.5; 42.5; 40.0; 62.5]
let r2  = [57.5; 50.0; 45.0; 35.0; 20.0; 22.5; 37.5; 55.0]
let r3  = [40.0; 30.0; 30.0; 35.0; 7.5; 7.5; 32.5; 40.0]
let r4  = [20.0; 7.5; 15.0; 22.5; 2.5; 2.5; 12.5; 22.5]

let t = ["North"; "N-E"; "East"; "S-E"; "South"; "S-W"; "West"; "N-W"]
(**
Polar bar charts plot data on a radial axis and a categorical angular axis. 

A common use case is the **windrose chart**.

A wind rose is a graphic tool used by meteorologists to give a succinct view 
of how wind speed and direction are typically distributed at a particular location.

*)
open Plotly.NET.LayoutObjects

let windrose1 =
    [
        Chart.BarPolar (r , t, Name="11-14 m/s")
        Chart.BarPolar (r2, t, Name="8-11 m/s")
        Chart.BarPolar (r3, t, Name="5-8 m/s")
        Chart.BarPolar (r4, t, Name="< 5 m/s")
    ]
    |> Chart.combine
    |> Chart.withAngularAxis(
        AngularAxis.init(
            CategoryOrder = StyleParam.CategoryOrder.Array,
            CategoryArray = (["East"; "N-E"; "North"; "N-W"; "West"; "S-W"; "South"; "S-E";]) // set the order of the categorical axis
        )
    )(* output: 
<div id="0194cea1-6382-43a3-84c4-d2a22e933c3a" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_0194cea1638243a384c4d2a22e933c3a = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"barpolar","r":[77.5,72.5,70.0,45.0,22.5,42.5,40.0,62.5],"theta":["North","N-E","East","S-E","South","S-W","West","N-W"],"name":"11-14 m/s","line":{},"marker":{}},{"type":"barpolar","r":[57.5,50.0,45.0,35.0,20.0,22.5,37.5,55.0],"theta":["North","N-E","East","S-E","South","S-W","West","N-W"],"name":"8-11 m/s","line":{},"marker":{}},{"type":"barpolar","r":[40.0,30.0,30.0,35.0,7.5,7.5,32.5,40.0],"theta":["North","N-E","East","S-E","South","S-W","West","N-W"],"name":"5-8 m/s","line":{},"marker":{}},{"type":"barpolar","r":[20.0,7.5,15.0,22.5,2.5,2.5,12.5,22.5],"theta":["North","N-E","East","S-E","South","S-W","West","N-W"],"name":"< 5 m/s","line":{},"marker":{}}];
            var layout = {"polar":{"angularaxis":{"categoryorder":"array","categoryarray":["East","N-E","North","N-W","West","S-W","South","S-E"]}}};
            var config = {};
            Plotly.newPlot('0194cea1-6382-43a3-84c4-d2a22e933c3a', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_0194cea1638243a384c4d2a22e933c3a();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_0194cea1638243a384c4d2a22e933c3a();
            }
</script>
*)

