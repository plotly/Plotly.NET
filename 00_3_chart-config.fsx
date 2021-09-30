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
<div id="eed97db9-3380-48fe-8122-22c4fb66b81f" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_eed97db9338048fe812222c4fb66b81f = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","mode":"markers","x":[1.0],"y":[2.0],"marker":{}}];
            var layout = {};
            var config = {"toImageButtonOptions":{"format":"jpeg","filename":"mySvgChart","width":900.0,"height":600.0,"scale":10.0}};
            Plotly.newPlot('eed97db9-3380-48fe-8122-22c4fb66b81f', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_eed97db9338048fe812222c4fb66b81f();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_eed97db9338048fe812222c4fb66b81f();
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
<div id="189fc905-5714-49e2-bcbb-27a999dbbe16" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_189fc905571449e2bcbb27a999dbbe16 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","mode":"markers","x":[1.0],"y":[2.0],"marker":{}}];
            var layout = {};
            var config = {"staticPlot":true};
            Plotly.newPlot('189fc905-5714-49e2-bcbb-27a999dbbe16', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_189fc905571449e2bcbb27a999dbbe16();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_189fc905571449e2bcbb27a999dbbe16();
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
<div id="5a9bbb87-15f7-4f5c-94ff-b88a2766893f" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_5a9bbb8715f74f5c94ffb88a2766893f = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","mode":"markers","x":[1.0],"y":[2.0],"marker":{}}];
            var layout = {};
            var config = {"editable":true,"edits":{"legendPosition":true,"axisTitleText":true,"legendText":true}};
            Plotly.newPlot('5a9bbb87-15f7-4f5c-94ff-b88a2766893f', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_5a9bbb8715f74f5c94ffb88a2766893f();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_5a9bbb8715f74f5c94ffb88a2766893f();
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
<div id="2ca9020f-b428-4e6a-95da-2254f5738e91" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_2ca9020fb4284e6a95da2254f5738e91 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","mode":"markers","x":[1.0],"y":[2.0],"marker":{}}];
            var layout = {};
            var config = {"responsive":true};
            Plotly.newPlot('2ca9020f-b428-4e6a-95da-2254f5738e91', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_2ca9020fb4284e6a95da2254f5738e91();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_2ca9020fb4284e6a95da2254f5738e91();
            }
</script>
*)

