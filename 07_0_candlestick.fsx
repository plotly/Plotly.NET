(**
// can't yet format YamlFrontmatter (["title: Candlestick Charts"; "category: Finance Charts"; "categoryindex: 8"; "index: 1"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# Candlestick Charts

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=07_0_candlestick.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/07_0_candlestick.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/07_0_candlestick.ipynb)

*Summary:* This example shows how to create candlestick charts in F#.

let's first create some data for the purpose of creating example charts:

*)
open Plotly.NET 
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects

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
<div id="449183ca-418f-4fa1-984c-efd2754258d2" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_449183ca418f4fa1984cefd2754258d2 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"candlestick","open":[0.68888,0.68883,0.68878,0.68886,0.68879,0.68875,0.68869,0.68883,0.68898,0.68889,0.68891],"high":[0.68888,0.68884,0.68889,0.68886,0.68879,0.68877,0.68887,0.68899,0.689,0.68893,0.68896],"low":[0.68879,0.68875,0.68878,0.68876,0.68873,0.68867,0.68869,0.68883,0.68885,0.68881,0.68886],"close":[0.6888,0.68877,0.68886,0.68879,0.68874,0.68868,0.68883,0.68899,0.68889,0.68893,0.68891],"x":["2020-01-17T13:40:00","2020-01-17T13:41:00","2020-01-17T13:42:00","2020-01-17T13:43:00","2020-01-17T13:44:00","2020-01-17T13:45:00","2020-01-17T13:46:00","2020-01-17T13:47:00","2020-01-17T13:48:00","2020-01-17T13:49:00","2020-01-17T13:50:00"],"xaxis":"x","yaxis":"y"}];
            var layout = {};
            var config = {};
            Plotly.newPlot('449183ca-418f-4fa1-984c-efd2754258d2', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_449183ca418f4fa1984cefd2754258d2();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_449183ca418f4fa1984cefd2754258d2();
            }
</script>
*)
(**
If you want to hide the rangeslider, use `withXAxisRangeSlider` and hide it:

*)
let rangeslider = RangeSlider.init(Visible=false)

let candles2 = 
    Chart.Candlestick candles
    |> Chart.withXAxisRangeSlider rangeslider(* output: 
<div id="08836cfb-cfb4-4bb1-9f20-1c27f26d537a" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_08836cfbcfb44bb19f201c27f26d537a = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"candlestick","open":[0.68888,0.68883,0.68878,0.68886,0.68879,0.68875,0.68869,0.68883,0.68898,0.68889,0.68891],"high":[0.68888,0.68884,0.68889,0.68886,0.68879,0.68877,0.68887,0.68899,0.689,0.68893,0.68896],"low":[0.68879,0.68875,0.68878,0.68876,0.68873,0.68867,0.68869,0.68883,0.68885,0.68881,0.68886],"close":[0.6888,0.68877,0.68886,0.68879,0.68874,0.68868,0.68883,0.68899,0.68889,0.68893,0.68891],"x":["2020-01-17T13:40:00","2020-01-17T13:41:00","2020-01-17T13:42:00","2020-01-17T13:43:00","2020-01-17T13:44:00","2020-01-17T13:45:00","2020-01-17T13:46:00","2020-01-17T13:47:00","2020-01-17T13:48:00","2020-01-17T13:49:00","2020-01-17T13:50:00"],"xaxis":"x","yaxis":"y"}];
            var layout = {"xaxis":{"rangeslider":{"visible":false,"yaxis":{}}}};
            var config = {};
            Plotly.newPlot('08836cfb-cfb4-4bb1-9f20-1c27f26d537a', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_08836cfbcfb44bb19f201c27f26d537a();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_08836cfbcfb44bb19f201c27f26d537a();
            }
</script>
*)

