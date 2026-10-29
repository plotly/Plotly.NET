# Chart Templates

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/general/templates.ipynb)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/general/templates.ipynb)

## Using premade templates

Premade templates can be accessed via the `ChartTemplates` module. In fact, the `ChartTemplates.plotly` template is always active by default (see [global defaults](./00_5_defaults.html))

```fsharp
open Plotly.NET

let lightMirrored =
    Chart.Point(xy = [ 1, 2 ]) |> Chart.withTemplate ChartTemplates.lightMirrored
```

<div><div id="af720f13-e932-48d2-8bd1-10dcbefedd81"><!-- Plotly chart will be drawn inside this DIV --></div><script type="text/javascript">var renderPlotly_af720f13e93248d28bd110dcbefedd81 = function() {
    var data = [{"type":"scatter","mode":"markers","x":[1],"y":[2],"marker":{},"line":{}}];
    var layout = {"width":600,"height":600,"template":{"layout":{"paper_bgcolor":"white","plot_bgcolor":"white","xaxis":{"ticks":"inside","mirror":"all","showline":true,"zeroline":true},"yaxis":{"ticks":"inside","mirror":"all","showline":true,"zeroline":true}},"data":{}}};
    var config = {"responsive":true};
    Plotly.newPlot('af720f13-e932-48d2-8bd1-10dcbefedd81', data, layout, config);
};
renderPlotly_af720f13e93248d28bd110dcbefedd81();
</script></div>

Here are the contents of the template `plotly` which is used by default for all charts: [https://github.com/plotly/Plotly.NET/blob/6e28decca64441320d8cffab5bcfee664b118c36/src/Plotly.NET/Templates/ChartTemplates.fs#L163-L665](https://github.com/plotly/Plotly.NET/blob/6e28decca64441320d8cffab5bcfee664b118c36/src/Plotly.NET/Templates/ChartTemplates.fs#L163-L665)

## Creating custom templates

Chart Templates consist of a `Layout` object and a collection of `Trace` objects. Both are used to set default values for all possible styling options:

```fsharp
open Plotly.NET.TraceObjects

let layoutTemplate =
    Layout.init (Title = Title.init ("I will always be there now!"))

let traceTemplates =
    [ Trace2D.initScatter (
          Trace2DStyle.Scatter(Marker = Marker.init (Symbol = StyleParam.MarkerSymbol.ArrowLeft, Size = 20))
      ) ]

let myTemplate = Template.init (layoutTemplate, traceTemplates)

let myTemplateExampleChart =
    Chart.Point(xy = [ 1, 2 ]) |> Chart.withTemplate myTemplate
```

<div><div id="b2a43af9-e34c-4b94-a824-ed78623cccc7"><!-- Plotly chart will be drawn inside this DIV --></div><script type="text/javascript">var renderPlotly_b2a43af9e34c4b94a824ed78623cccc7 = function() {
    var data = [{"type":"scatter","mode":"markers","x":[1],"y":[2],"marker":{},"line":{}}];
    var layout = {"width":600,"height":600,"template":{"layout":{"title":{"text":"I will always be there now!"}},"data":{"scatter":[{"type":"scatter","marker":{"size":20,"symbol":"47"}}]}}};
    var config = {"responsive":true};
    Plotly.newPlot('b2a43af9-e34c-4b94-a824-ed78623cccc7', data, layout, config);
};
renderPlotly_b2a43af9e34c4b94a824ed78623cccc7();
</script></div>
