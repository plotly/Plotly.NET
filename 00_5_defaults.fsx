(**
// can't yet format YamlFrontmatter (["title: Global default values"; "category: General"; "categoryindex: 1"; "index: 6"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# Global default values

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=00_5_defaults.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/00_5_defaults.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/00_5_defaults.ipynb)

Plotly.NET provides mutable global default values in the `Defaults` module.

These values are always used in Chart generation. The default values are:

|Value name|Value|
|---|---|
| DefaultWidth | `600` |
| DefaultHeight | `600` |
| DefaultConfig | `Config.init(Responsive = true)` |
| DefaultDisplayOptions | `DisplayOptions.init()` |
| DefaultTemplate | `ChartTemplates.plotly` |

## Changing default values

The following code replaces the default template from the global defaults:

*)
open Plotly.NET

let before = Chart.Point([1,2])(* output: 
<div id="48481185-9ad2-454d-b8f1-528b4e6174eb"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_484811859ad2454db8f1528b4e6174eb = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","mode":"markers","x":[1],"y":[2],"marker":{}}];
            var layout = {"width":600,"height":600,"template":{"layout":{"paper_bgcolor":"white","plot_bgcolor":"white","xaxis":{"ticks":"inside","mirror":"all","showline":true,"zeroline":true},"yaxis":{"ticks":"inside","mirror":"all","showline":true,"zeroline":true}},"data":{}}};
            var config = {"responsive":true};
            Plotly.newPlot('48481185-9ad2-454d-b8f1-528b4e6174eb', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_484811859ad2454db8f1528b4e6174eb();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_484811859ad2454db8f1528b4e6174eb();
            }
</script>
*)
Defaults.DefaultTemplate <- ChartTemplates.lightMirrored

let after = Chart.Point([1,2])(* output: 
<div id="4ea972e6-cdda-4820-990f-3c376721cb92"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_4ea972e6cdda4820990f3c376721cb92 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","mode":"markers","x":[1],"y":[2],"marker":{}}];
            var layout = {"width":600,"height":600,"template":{"layout":{"paper_bgcolor":"white","plot_bgcolor":"white","xaxis":{"ticks":"inside","mirror":"all","showline":true,"zeroline":true},"yaxis":{"ticks":"inside","mirror":"all","showline":true,"zeroline":true}},"data":{}}};
            var config = {"responsive":true};
            Plotly.newPlot('4ea972e6-cdda-4820-990f-3c376721cb92', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_4ea972e6cdda4820990f3c376721cb92();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_4ea972e6cdda4820990f3c376721cb92();
            }
</script>
*)
(**
## Ignoring global defaults

All Chart functions have a `UseDefaults` argument, which when set to `false` will ignore all global defaults:

*)
let noDefaults = Chart.Point([1,2], UseDefaults = false)(* output: 
<div id="78429481-4024-4760-b96a-fa8432eaf258"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_7842948140244760b96afa8432eaf258 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","mode":"markers","x":[1],"y":[2],"marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('78429481-4024-4760-b96a-fa8432eaf258', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_7842948140244760b96afa8432eaf258();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_7842948140244760b96afa8432eaf258();
            }
</script>
*)

