(**
// can't yet format YamlFrontmatter (["title: Chart config"; "category: General"; "categoryindex: 1"; "index: 4"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# Chart config

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=00_3_chart-config.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/00_3_chart-config.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/00_3_chart-config.ipynb)

`Config` is an object that configures high level properties of the chart like making all chart elements editable or the tool bar on top

## Image button options

Options for chart export can be set in the config at `ToImageButtonOptions`:

  - Three file formats for chart exports are supported (SVG, PNG, JPEG) and can be set as `Format`. 

  - A predefined name for the downloaded chart can be set at `Filename`. 

  - The dimensions of the downloaded chart are set at `Width` and `Height`.

  - The `Scale` defines the size of the exported svg.

The settings do not apply for the html document containing the chart but for charts that are exported by clicking the camera icon in the menu bar.


*)
open Plotly.NET
open Plotly.NET.ConfigObjects

let svgConfig =
    Config.init (
        ToImageButtonOptions = ToImageButtonOptions.init(
            Format = StyleParam.ImageFormat.JPEG,
            Filename = "mySvgChart",
            Width = 900.,
            Height = 600.,
            Scale = 10.
        )
    )

let svgButtonChart = 
    Chart.Point([(1.,2.)])
    |> Chart.withConfig svgConfig(* output: 
<div id="48137044-2962-459a-ad3b-a8833faf8647" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_481370442962459aad3ba8833faf8647 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","mode":"markers","x":[1.0],"y":[2.0],"marker":{}}];
            var layout = {};
            var config = {"toImageButtonOptions":{"format":"jpeg","filename":"mySvgChart","width":900.0,"height":600.0,"scale":10.0}};
            Plotly.newPlot('48137044-2962-459a-ad3b-a8833faf8647', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_481370442962459aad3ba8833faf8647();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_481370442962459aad3ba8833faf8647();
            }
</script>
*)
(**
## Static plots

To create a static plot that has no hoverable elements, use `StaticPlot=true` on the Config:


*)
let staticConfig = Config.init(StaticPlot=true)

let staticPlot =
    Chart.Point([(1.,2.)])
    |> Chart.withConfig staticConfig(* output: 
<div id="32b4be47-76fb-45f5-b423-39db55277804" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_32b4be4776fb45f5b42339db55277804 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","mode":"markers","x":[1.0],"y":[2.0],"marker":{}}];
            var layout = {};
            var config = {"staticPlot":true};
            Plotly.newPlot('32b4be47-76fb-45f5-b423-39db55277804', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_32b4be4776fb45f5b42339db55277804();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_32b4be4776fb45f5b42339db55277804();
            }
</script>
*)
(**
## Editable charts

You can define fields that can be edited on the chart by setting `Editable = true` on the config, optionally explicitly setting the editable parts via `EditableAnnotations`


*)
let editableConfig = 
    Config.init(
        Editable = true,
        EditableAnnotations = [
            StyleParam.AnnotationEditOptions.LegendPosition
            StyleParam.AnnotationEditOptions.AxisTitleText
            StyleParam.AnnotationEditOptions.LegendText
        ]
    )

let editablePlot =
    Chart.Point([(1.,2.)])
    |> Chart.withConfig editableConfig(* output: 
<div id="80c39fe0-e9b7-46fb-85e5-b5e1e87e7d1e" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_80c39fe0e9b746fb85e5b5e1e87e7d1e = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","mode":"markers","x":[1.0],"y":[2.0],"marker":{}}];
            var layout = {};
            var config = {"editable":true,"edits":{"legendPosition":true,"axisTitleText":true,"legendText":true}};
            Plotly.newPlot('80c39fe0-e9b7-46fb-85e5-b5e1e87e7d1e', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_80c39fe0e9b746fb85e5b5e1e87e7d1e();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_80c39fe0e9b746fb85e5b5e1e87e7d1e();
            }
</script>
*)
(**
## Responsive charts

To create a chart that is reponsive to its container size, use `Responsive=true` on the Config:

(try resizing the window)

*)
let responsiveConfig = Config.init(Responsive=true)

let responsivePlot =
    Chart.Point([(1.,2.)])
    |> Chart.withConfig responsiveConfig(* output: 
<div id="ae4e5bfe-3622-451f-b015-2afa5b0526a8" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_ae4e5bfe3622451fb0152afa5b0526a8 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","mode":"markers","x":[1.0],"y":[2.0],"marker":{}}];
            var layout = {};
            var config = {"responsive":true};
            Plotly.newPlot('ae4e5bfe-3622-451f-b015-2afa5b0526a8', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_ae4e5bfe3622451fb0152afa5b0526a8();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_ae4e5bfe3622451fb0152afa5b0526a8();
            }
</script>
*)

