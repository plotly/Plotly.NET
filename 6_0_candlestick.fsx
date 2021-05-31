(**
// can't yet format YamlFrontmatter (["title: Candlestick Charts"; "category: Finance Charts"; "categoryindex: 7"; "index: 1"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# Candlestick Charts

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=6_0_candlestick.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/6_0_candlestick.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/6_0_candlestick.ipynb)

*Summary:* This example shows how to create candlestick charts in F#.

let's first create some data for the purpose of creating example charts:
*)
open Plotly.NET 

let candles =
    [|("2020-01-17T13:40:00", 0.68888, 0.68888, 0.68879, 0.6888);
      ("2020-01-17T13:41:00", 0.68883, 0.68884, 0.68875, 0.68877);
      ("2020-01-17T13:42:00", 0.68878, 0.68889, 0.68878, 0.68886);
      ("2020-01-17T13:43:00", 0.68886, 0.68886, 0.68876, 0.68879);
      ("2020-01-17T13:44:00", 0.68879, 0.68879, 0.68873, 0.68874);
      ("2020-01-17T13:45:00", 0.68875, 0.68877, 0.68867, 0.68868);
      ("2020-01-17T13:46:00", 0.68869, 0.68887, 0.68869, 0.68883);
      ("2020-01-17T13:47:00", 0.68883, 0.68899, 0.68883, 0.68899);
      ("2020-01-17T13:48:00", 0.68898, 0.689, 0.68885, 0.68889);
      ("2020-01-17T13:49:00", 0.68889, 0.68893, 0.68881, 0.68893);
      ("2020-01-17T13:50:00", 0.68891, 0.68896, 0.68886, 0.68891);
    |]
    |> Array.map (fun (d,o,h,l,c)->System.DateTime.Parse d, StockData.Create(o,h,l,c))
(**
A candlestick chart is useful for plotting stock prices over time. A candle
is a group of high, open, close and low values over a period of time, e.g. 1 minute, 5 minute, hour, day, etc..
The x-axis is usually dateime values and y is a sequence of candle structures.
*)
let candles1 = Chart.Candlestick candles(* output: 
<div id="d13dec8b-0ac1-47c6-aefe-927200b9ed67" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_d13dec8b0ac147c6aefe927200b9ed67 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"candlestick","open":[0.68888,0.68883,0.68878,0.68886,0.68879,0.68875,0.68869,0.68883,0.68898,0.68889,0.68891],"high":[0.68888,0.68884,0.68889,0.68886,0.68879,0.68877,0.68887,0.68899,0.689,0.68893,0.68896],"low":[0.68879,0.68875,0.68878,0.68876,0.68873,0.68867,0.68869,0.68883,0.68885,0.68881,0.68886],"close":[0.6888,0.68877,0.68886,0.68879,0.68874,0.68868,0.68883,0.68899,0.68889,0.68893,0.68891],"x":["2020-01-17T13:40:00","2020-01-17T13:41:00","2020-01-17T13:42:00","2020-01-17T13:43:00","2020-01-17T13:44:00","2020-01-17T13:45:00","2020-01-17T13:46:00","2020-01-17T13:47:00","2020-01-17T13:48:00","2020-01-17T13:49:00","2020-01-17T13:50:00"],"xaxis":"x","yaxis":"y"}];
            var layout = {};
            var config = {};
            Plotly.newPlot('d13dec8b-0ac1-47c6-aefe-927200b9ed67', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_d13dec8b0ac147c6aefe927200b9ed67();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_d13dec8b0ac147c6aefe927200b9ed67();
            }
</script>
*)
(**
If you want to hide the rangeslider, use `withX_AxisRangeSlider` and hide it:
*)
let rangeslider = RangeSlider.init(Visible=false)

let candles2 = 
    Chart.Candlestick candles
    |> Chart.withX_AxisRangeSlider rangeslider(* output: 
<div id="67994f0f-b28a-4c80-b236-ea194cc5509f" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_67994f0fb28a4c80b236ea194cc5509f = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"candlestick","open":[0.68888,0.68883,0.68878,0.68886,0.68879,0.68875,0.68869,0.68883,0.68898,0.68889,0.68891],"high":[0.68888,0.68884,0.68889,0.68886,0.68879,0.68877,0.68887,0.68899,0.689,0.68893,0.68896],"low":[0.68879,0.68875,0.68878,0.68876,0.68873,0.68867,0.68869,0.68883,0.68885,0.68881,0.68886],"close":[0.6888,0.68877,0.68886,0.68879,0.68874,0.68868,0.68883,0.68899,0.68889,0.68893,0.68891],"x":["2020-01-17T13:40:00","2020-01-17T13:41:00","2020-01-17T13:42:00","2020-01-17T13:43:00","2020-01-17T13:44:00","2020-01-17T13:45:00","2020-01-17T13:46:00","2020-01-17T13:47:00","2020-01-17T13:48:00","2020-01-17T13:49:00","2020-01-17T13:50:00"],"xaxis":"x","yaxis":"y"}];
            var layout = {"xaxis":{"rangeslider":{"visible":false,"yaxis":{}}}};
            var config = {};
            Plotly.newPlot('67994f0f-b28a-4c80-b236-ea194cc5509f', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_67994f0fb28a4c80b236ea194cc5509f();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_67994f0fb28a4c80b236ea194cc5509f();
            }
</script>
*)

