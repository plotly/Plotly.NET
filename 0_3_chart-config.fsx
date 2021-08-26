(**
// can't yet format YamlFrontmatter (["title: Chart config"; "category: General"; "categoryindex: 1"; "index: 4"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# Chart config

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=0_3_chart-config.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/0_3_chart-config.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/0_3_chart-config.ipynb)

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
<div id="e2d8fc3b-0394-4f6e-a0a9-9a1956092b2b" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_e2d8fc3b03944f6ea0a99a1956092b2b = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","x":[1.0],"y":[2.0],"mode":"markers","marker":{}}];
            var layout = {};
            var config = {"toImageButtonOptions":{"format":"jpeg","filename":"mySvgChart","width":900.0,"height":600.0,"scale":10.0}};
            Plotly.newPlot('e2d8fc3b-0394-4f6e-a0a9-9a1956092b2b', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_e2d8fc3b03944f6ea0a99a1956092b2b();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_e2d8fc3b03944f6ea0a99a1956092b2b();
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
<div id="18c55f4d-c516-4464-95f7-c0b6bd13d70f" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_18c55f4dc516446495f7c0b6bd13d70f = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","x":[1.0],"y":[2.0],"mode":"markers","marker":{}}];
            var layout = {};
            var config = {"staticPlot":true};
            Plotly.newPlot('18c55f4d-c516-4464-95f7-c0b6bd13d70f', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_18c55f4dc516446495f7c0b6bd13d70f();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_18c55f4dc516446495f7c0b6bd13d70f();
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
<div id="d5019e33-670c-45e6-a3bb-a7cf0d123908" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_d5019e33670c45e6a3bba7cf0d123908 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","x":[1.0],"y":[2.0],"mode":"markers","marker":{}}];
            var layout = {};
            var config = {"editable":true,"edits":{"legendPosition":true,"axisTitleText":true,"legendText":true}};
            Plotly.newPlot('d5019e33-670c-45e6-a3bb-a7cf0d123908', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_d5019e33670c45e6a3bba7cf0d123908();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_d5019e33670c45e6a3bba7cf0d123908();
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
<div id="c7623121-a88d-408b-83d0-b1205d8a2661" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_c7623121a88d408b83d0b1205d8a2661 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","x":[1.0],"y":[2.0],"mode":"markers","marker":{}}];
            var layout = {};
            var config = {"responsive":true};
            Plotly.newPlot('c7623121-a88d-408b-83d0-b1205d8a2661', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_c7623121a88d408b83d0b1205d8a2661();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_c7623121a88d408b83d0b1205d8a2661();
            }
</script>
*)

