(**
// can't yet format YamlFrontmatter (["title: Chart Templates"; "category: General"; "categoryindex: 1"; "index: 5"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# Chart Templates

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=00_4_templates.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/00_4_templates.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/00_4_templates.ipynb)

## Using premade templates

premade templates can be accessed via the `ChartTemplates` module. In fact, the `ChartTemplates.plotly` template is always active by default (see [global defaults](./005_defaults.html))

*)
open Plotly.NET

let lightMirrored = 
    Chart.Point([1,2])
    |> Chart.withTemplate ChartTemplates.lightMirrored(* output: 
<div id="ed55b257-669a-4ad1-be26-02756ee1e4e5"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_ed55b257669a4ad1be2602756ee1e4e5 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.6.3.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","mode":"markers","x":[1],"y":[2],"marker":{},"line":{}}];
            var layout = {"width":600,"height":600,"template":{"layout":{"paper_bgcolor":"white","plot_bgcolor":"white","xaxis":{"ticks":"inside","mirror":"all","showline":true,"zeroline":true},"yaxis":{"ticks":"inside","mirror":"all","showline":true,"zeroline":true}},"data":{}}};
            var config = {"responsive":true};
            Plotly.newPlot('ed55b257-669a-4ad1-be26-02756ee1e4e5', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_ed55b257669a4ad1be2602756ee1e4e5();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_ed55b257669a4ad1be2602756ee1e4e5();
            }
</script>
*)
(**
here are then contents of the template `plotly` which is used by default for all charts:


*)
open DynamicObj(* output: 
*)
ChartTemplates.plotly
|> DynObj.print
(**
## Creating custom templates

Chart Templates consist of a `Layout` object and a collection of `Trace` objects. Both are used to set default values for all possible styling options:

*)
open Plotly.NET.TraceObjects

let layoutTemplate = 
    Layout.init(
        Title = Title.init("I will always be there now!")
    )

let traceTemplates = 
    [
        Trace2D.initScatter(
            Trace2DStyle.Scatter(
                Marker = Marker.init(Symbol = StyleParam.MarkerSymbol.ArrowLeft, Size = 20)
            )
        )
    ]

let myTemplate = Template.init(layoutTemplate, traceTemplates)

let myTemplateExampleChart =
    Chart.Point([1,2])
    |> Chart.withTemplate myTemplate(* output: 
<div id="4c28c68f-268f-4384-bd54-f0f57cb14a28"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_4c28c68f268f4384bd54f0f57cb14a28 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.6.3.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","mode":"markers","x":[1],"y":[2],"marker":{},"line":{}}];
            var layout = {"width":600,"height":600,"template":{"layout":{"title":{"text":"I will always be there now!"}},"data":{"scatter":[{"marker":{"size":20,"symbol":"47"}}]}}};
            var config = {"responsive":true};
            Plotly.newPlot('4c28c68f-268f-4384-bd54-f0f57cb14a28', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_4c28c68f268f4384bd54f0f57cb14a28();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_4c28c68f268f4384bd54f0f57cb14a28();
            }
</script>
*)

