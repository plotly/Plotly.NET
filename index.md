# Plotly.NET

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/index.ipynb)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/index.ipynb)

Plotly.NET provides functions for generating and rendering plotly.js charts in **.NET** programming languages 📈🚀.

**This documentation page is almost exclusively for the core F# API of Plotly.NET.**

It should be easy to translate them into C#. However, as work on the idiomatic C# API progresses, we will provide native C# docs as well.

### Table of contents

* [Installation](#Installation)

  * [For applications and libraries](#For-applications-and-libraries)
  
  * [For scripting](#For-scripting)
  
  * [For dotnet interactive notebooks](#For-dotnet-interactive-notebooks)
  

* [Overview](#Overview)

  * [Basics](#Basics)
  
    * [Initializing a chart](#Initializing-a-chart)
    
    * [Styling a chart](#Styling-a-chart)
    
    * [Displaying a chart](#Displaying-a-chart)
    
  
  * [Comparison: Usage in F# and C#](#Comparison-Usage-in-F-and-C)
  
    * [Functional pipeline style in F#](#Functional-pipeline-style-in-F)
    
    * [Fluent interface style in C#](#Fluent-interface-style-in-C)
    
    * [Declarative style in F# using the underlying `DynamicObj`](#Declarative-style-in-F-using-the-underlying)
    
    * [Declarative style in C# using the underlying `DynamicObj`](#Declarative-style-in-C-using-the-underlying)
    
  

* [Contributing and copyright](#Contributing-and-copyright)

# Installation

Plotly.NET consists of multiple packages. The two main ones are:

* Plotly.NET [![](https://img.shields.io/nuget/vpre/Plotly.NET)](https://www.nuget.org/packages/Plotly.NET/), the core API written in F#.

* Plotly.NET.CSharp [![](https://img.shields.io/nuget/vpre/Plotly.NET.CSharp)](https://www.nuget.org/packages/Plotly.NET.CSharp/), native C# bindings that make the usage of Plotly.NET more idiomatic from C#. This is work in progress. Missing charts and/or styling must be done via the core API.

### For applications and libraries

Plotly.NET packages are available on NuGet to plug into your favorite package manager.

* dotnet CLI
  

  dotnet add package Plotly.NET --version 6.0.0
  

* paket CLI
  

  paket add Plotly.NET --version 6.0.0
  

* package manager

 `shell
 Install-Package Plotly.NET -Version {{fsdocs-package-version}}`

 Or add the package reference directly to your `.*proj` file:

 `<PackageReference Include="Plotly.NET" Version="{{fsdocs-package-version}}" />`

### For scripting

You can include the package via an inline package reference:

#r "nuget: Plotly.NET, 6.0.0"

### For dotnet interactive notebooks

You can use the same inline package reference as in scripts, but as an additional goodie
the interactive extensions for dotnet interactive have you covered for seamless chart rendering:

#r "nuget: Plotly.NET.Interactive, 6.0.0"

*Note*:

Due to the currently fast development cycles of .NET Interactive, there might be increments in their versioning that render the current version of Plotly.NET.Interactive incompatible (example [here](https://github.com/plotly/Plotly.NET/issues/67)).

If the interactive extension does not work, please file an issue and we will try to get it running again as soon as possible.

A possible fix for this is the inclusion of Dotnet.Interactive preview package sources. To use these, add the following lines before referencing Plotly.NET.Interactive:

#i "nuget:https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet5/nuget/v3/index.json"
#i "nuget:https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet-tools/nuget/v3/index.json"

# Overview

## Basics

The general, high-level API of Plotly.NET implements the following visualization flow:

* **initialize** a `GenericChart` object from the data you want to visualize by using the respective `Chart.*` function, optionally setting some specific style parameters

* further **style** the chart with fine-grained control, e.g. by setting axis titles, tick intervals, etc.

* **display** (in the browser or as cell result in a notebook) or save the chart

### Initializing a chart

The `Chart` module contains a lot of functions named after the type of chart they will create, e.g.
`Chart.Point` will create a point chart, `Chart.Scatter3d` wil create a 3D scatter chart, and so on.

The respective functions all contain specific arguments, but they all have in common that the first
mandatory arguments are the data to visualize.

Example: The first two arguments of the `Chart.Point` function are the x and y data. You can therefore initialize a point chart like this:

```fsharp
open Plotly.NET
let xData = [ 0. .. 10. ]
let yData = [ 0. .. 10. ]
let myFirstChart = Chart.Point(xData, yData)
```

### Styling a chart

Styling functions are generally the `Chart.with*` naming convention. The following styling example does:

* set the chart title via `Chart.withTitle`

* set the x axis title and removes the gridline from the axis via `Chart.withXAxisStyle`

* set the y axis title and removes the gridline from the axis via `Chart.withYAxisStyle`

```fsharp
let myFirstStyledChart =
    Chart.Point(xData, yData)
    |> Chart.withTitle "Hello world!"
    |> Chart.withXAxisStyle ("xAxis")
    |> Chart.withYAxisStyle ("yAxis")
```

**Attention:** Styling functions mutate 😈 the input chart, therefore possibly affecting bindings to intermediary results.
We recommend creating a single chart for each workflow to prevent unexpected results.

### Displaying a chart in the browser

The `Chart.Show` function will open a browser window and render the input chart there. When working in a notebook context, after
[referencing Plotly.NET.Interactive](#For-dotnet-interactive-notebooks), the function is not necessary, just end the cell with the value of the chart.

```fsharp
myFirstChart |> Chart.show
```

Should render this chart in your browser:

<div><div id="32861973-6994-4a92-8148-682d5fa8d0e8"><!-- Plotly chart will be drawn inside this DIV --></div><script type="text/javascript">var renderPlotly_3286197369944a928148682d5fa8d0e8 = function() {
    var data = [{"type":"scatter","mode":"markers","x":[0.0,1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[0.0,1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"marker":{},"line":{}}];
    var layout = {"width":600,"height":600,"template":{"layout":{"title":{"x":0.05},"font":{"color":"rgba(42, 63, 95, 1.0)"},"paper_bgcolor":"rgba(255, 255, 255, 1.0)","plot_bgcolor":"rgba(229, 236, 246, 1.0)","autotypenumbers":"strict","colorscale":{"diverging":[[0.0,"#8e0152"],[0.1,"#c51b7d"],[0.2,"#de77ae"],[0.3,"#f1b6da"],[0.4,"#fde0ef"],[0.5,"#f7f7f7"],[0.6,"#e6f5d0"],[0.7,"#b8e186"],[0.8,"#7fbc41"],[0.9,"#4d9221"],[1.0,"#276419"]],"sequential":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]],"sequentialminus":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]},"hovermode":"closest","hoverlabel":{"align":"left"},"coloraxis":{"colorbar":{"outlinewidth":0.0,"ticks":""}},"geo":{"showland":true,"landcolor":"rgba(229, 236, 246, 1.0)","showlakes":true,"lakecolor":"rgba(255, 255, 255, 1.0)","subunitcolor":"rgba(255, 255, 255, 1.0)","bgcolor":"rgba(255, 255, 255, 1.0)"},"mapbox":{"style":"light"},"polar":{"bgcolor":"rgba(229, 236, 246, 1.0)","radialaxis":{"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","ticks":""},"angularaxis":{"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","ticks":""}},"scene":{"xaxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","gridwidth":2.0,"zerolinecolor":"rgba(255, 255, 255, 1.0)","backgroundcolor":"rgba(229, 236, 246, 1.0)","showbackground":true},"yaxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","gridwidth":2.0,"zerolinecolor":"rgba(255, 255, 255, 1.0)","backgroundcolor":"rgba(229, 236, 246, 1.0)","showbackground":true},"zaxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","gridwidth":2.0,"zerolinecolor":"rgba(255, 255, 255, 1.0)","backgroundcolor":"rgba(229, 236, 246, 1.0)","showbackground":true}},"ternary":{"aaxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)"},"baxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)"},"caxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)"},"bgcolor":"rgba(229, 236, 246, 1.0)"},"xaxis":{"title":{"standoff":15},"ticks":"","automargin":"height+width+left+right+top+bottom","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","zerolinecolor":"rgba(255, 255, 255, 1.0)","zerolinewidth":2.0},"yaxis":{"title":{"standoff":15},"ticks":"","automargin":"height+width+left+right+top+bottom","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","zerolinecolor":"rgba(255, 255, 255, 1.0)","zerolinewidth":2.0},"annotationdefaults":{"arrowcolor":"#2a3f5f","arrowhead":0,"arrowwidth":1},"shapedefaults":{"line":{"color":"rgba(42, 63, 95, 1.0)"}},"colorway":["rgba(99, 110, 250, 1.0)","rgba(239, 85, 59, 1.0)","rgba(0, 204, 150, 1.0)","rgba(171, 99, 250, 1.0)","rgba(255, 161, 90, 1.0)","rgba(25, 211, 243, 1.0)","rgba(255, 102, 146, 1.0)","rgba(182, 232, 128, 1.0)","rgba(255, 151, 255, 1.0)","rgba(254, 203, 82, 1.0)"]},"data":{"bar":[{"type":"bar","marker":{"line":{"color":"rgba(229, 236, 246, 1.0)","width":0.5},"pattern":{"fillmode":"overlay","size":10,"solidity":0.2}},"error_x":{"color":"rgba(42, 63, 95, 1.0)"},"error_y":{"color":"rgba(42, 63, 95, 1.0)"}}],"barpolar":[{"type":"barpolar","marker":{"line":{"color":"rgba(229, 236, 246, 1.0)","width":0.5},"pattern":{"fillmode":"overlay","size":10,"solidity":0.2}}}],"carpet":[{"type":"carpet","aaxis":{"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","endlinecolor":"rgba(42, 63, 95, 1.0)","minorgridcolor":"rgba(255, 255, 255, 1.0)","startlinecolor":"rgba(42, 63, 95, 1.0)"},"baxis":{"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","endlinecolor":"rgba(42, 63, 95, 1.0)","minorgridcolor":"rgba(255, 255, 255, 1.0)","startlinecolor":"rgba(42, 63, 95, 1.0)"}}],"choropleth":[{"type":"choropleth","colorbar":{"outlinewidth":0.0,"ticks":""},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"contour":[{"type":"contour","colorbar":{"outlinewidth":0.0,"ticks":""},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"contourcarpet":[{"type":"contourcarpet","colorbar":{"outlinewidth":0.0,"ticks":""}}],"heatmap":[{"type":"heatmap","colorbar":{"outlinewidth":0.0,"ticks":""},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"heatmapgl":[{"type":"heatmapgl","colorbar":{"outlinewidth":0.0,"ticks":""},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"histogram":[{"type":"histogram","marker":{"pattern":{"fillmode":"overlay","size":10,"solidity":0.2}}}],"histogram2d":[{"type":"histogram2d","colorbar":{"outlinewidth":0.0,"ticks":""},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"histogram2dcontour":[{"type":"histogram2dcontour","colorbar":{"outlinewidth":0.0,"ticks":""},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"mesh3d":[{"type":"mesh3d","colorbar":{"outlinewidth":0.0,"ticks":""}}],"parcoords":[{"type":"parcoords","line":{"colorbar":{"outlinewidth":0.0,"ticks":""}}}],"pie":[{"type":"pie","automargin":true}],"scatter":[{"type":"scatter","marker":{"colorbar":{"outlinewidth":0.0,"ticks":""}}}],"scatter3d":[{"type":"scatter3d","marker":{"colorbar":{"outlinewidth":0.0,"ticks":""}},"line":{"colorbar":{"outlinewidth":0.0,"ticks":""}}}],"scattercarpet":[{"type":"scattercarpet","marker":{"colorbar":{"outlinewidth":0.0,"ticks":""}}}],"scattergeo":[{"type":"scattergeo","marker":{"colorbar":{"outlinewidth":0.0,"ticks":""}}}],"scattergl":[{"type":"scattergl","marker":{"colorbar":{"outlinewidth":0.0,"ticks":""}}}],"scattermapbox":[{"type":"scattermapbox","marker":{"colorbar":{"outlinewidth":0.0,"ticks":""}}}],"scatterpolar":[{"type":"scatterpolar","marker":{"colorbar":{"outlinewidth":0.0,"ticks":""}}}],"scatterpolargl":[{"type":"scatterpolargl","marker":{"colorbar":{"outlinewidth":0.0,"ticks":""}}}],"scatterternary":[{"type":"scatterternary","marker":{"colorbar":{"outlinewidth":0.0,"ticks":""}}}],"surface":[{"type":"surface","colorbar":{"outlinewidth":0.0,"ticks":""},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"table":[{"type":"table","cells":{"fill":{"color":"rgba(235, 240, 248, 1.0)"},"line":{"color":"rgba(255, 255, 255, 1.0)"}},"header":{"fill":{"color":"rgba(200, 212, 227, 1.0)"},"line":{"color":"rgba(255, 255, 255, 1.0)"}}}]}}};
    var config = {"responsive":true};
    Plotly.newPlot('32861973-6994-4a92-8148-682d5fa8d0e8', data, layout, config);
};
renderPlotly_3286197369944a928148682d5fa8d0e8();
</script></div>

```fsharp
myFirstStyledChart |> Chart.show
```

And here is what happened after applying the styles from above:

<div><div id="db69a167-4348-4e90-8ff6-fbc35c71b777"><!-- Plotly chart will be drawn inside this DIV --></div><script type="text/javascript">var renderPlotly_db69a16743484e908ff6fbc35c71b777 = function() {
    var data = [{"type":"scatter","mode":"markers","x":[0.0,1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[0.0,1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"marker":{},"line":{}}];
    var layout = {"width":600,"height":600,"template":{"layout":{"title":{"x":0.05},"font":{"color":"rgba(42, 63, 95, 1.0)"},"paper_bgcolor":"rgba(255, 255, 255, 1.0)","plot_bgcolor":"rgba(229, 236, 246, 1.0)","autotypenumbers":"strict","colorscale":{"diverging":[[0.0,"#8e0152"],[0.1,"#c51b7d"],[0.2,"#de77ae"],[0.3,"#f1b6da"],[0.4,"#fde0ef"],[0.5,"#f7f7f7"],[0.6,"#e6f5d0"],[0.7,"#b8e186"],[0.8,"#7fbc41"],[0.9,"#4d9221"],[1.0,"#276419"]],"sequential":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]],"sequentialminus":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]},"hovermode":"closest","hoverlabel":{"align":"left"},"coloraxis":{"colorbar":{"outlinewidth":0.0,"ticks":""}},"geo":{"showland":true,"landcolor":"rgba(229, 236, 246, 1.0)","showlakes":true,"lakecolor":"rgba(255, 255, 255, 1.0)","subunitcolor":"rgba(255, 255, 255, 1.0)","bgcolor":"rgba(255, 255, 255, 1.0)"},"mapbox":{"style":"light"},"polar":{"bgcolor":"rgba(229, 236, 246, 1.0)","radialaxis":{"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","ticks":""},"angularaxis":{"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","ticks":""}},"scene":{"xaxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","gridwidth":2.0,"zerolinecolor":"rgba(255, 255, 255, 1.0)","backgroundcolor":"rgba(229, 236, 246, 1.0)","showbackground":true},"yaxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","gridwidth":2.0,"zerolinecolor":"rgba(255, 255, 255, 1.0)","backgroundcolor":"rgba(229, 236, 246, 1.0)","showbackground":true},"zaxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","gridwidth":2.0,"zerolinecolor":"rgba(255, 255, 255, 1.0)","backgroundcolor":"rgba(229, 236, 246, 1.0)","showbackground":true}},"ternary":{"aaxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)"},"baxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)"},"caxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)"},"bgcolor":"rgba(229, 236, 246, 1.0)"},"xaxis":{"title":{"standoff":15},"ticks":"","automargin":"height+width+left+right+top+bottom","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","zerolinecolor":"rgba(255, 255, 255, 1.0)","zerolinewidth":2.0},"yaxis":{"title":{"standoff":15},"ticks":"","automargin":"height+width+left+right+top+bottom","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","zerolinecolor":"rgba(255, 255, 255, 1.0)","zerolinewidth":2.0},"annotationdefaults":{"arrowcolor":"#2a3f5f","arrowhead":0,"arrowwidth":1},"shapedefaults":{"line":{"color":"rgba(42, 63, 95, 1.0)"}},"colorway":["rgba(99, 110, 250, 1.0)","rgba(239, 85, 59, 1.0)","rgba(0, 204, 150, 1.0)","rgba(171, 99, 250, 1.0)","rgba(255, 161, 90, 1.0)","rgba(25, 211, 243, 1.0)","rgba(255, 102, 146, 1.0)","rgba(182, 232, 128, 1.0)","rgba(255, 151, 255, 1.0)","rgba(254, 203, 82, 1.0)"]},"data":{"bar":[{"type":"bar","marker":{"line":{"color":"rgba(229, 236, 246, 1.0)","width":0.5},"pattern":{"fillmode":"overlay","size":10,"solidity":0.2}},"error_x":{"color":"rgba(42, 63, 95, 1.0)"},"error_y":{"color":"rgba(42, 63, 95, 1.0)"}}],"barpolar":[{"type":"barpolar","marker":{"line":{"color":"rgba(229, 236, 246, 1.0)","width":0.5},"pattern":{"fillmode":"overlay","size":10,"solidity":0.2}}}],"carpet":[{"type":"carpet","aaxis":{"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","endlinecolor":"rgba(42, 63, 95, 1.0)","minorgridcolor":"rgba(255, 255, 255, 1.0)","startlinecolor":"rgba(42, 63, 95, 1.0)"},"baxis":{"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","endlinecolor":"rgba(42, 63, 95, 1.0)","minorgridcolor":"rgba(255, 255, 255, 1.0)","startlinecolor":"rgba(42, 63, 95, 1.0)"}}],"choropleth":[{"type":"choropleth","colorbar":{"outlinewidth":0.0,"ticks":""},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"contour":[{"type":"contour","colorbar":{"outlinewidth":0.0,"ticks":""},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"contourcarpet":[{"type":"contourcarpet","colorbar":{"outlinewidth":0.0,"ticks":""}}],"heatmap":[{"type":"heatmap","colorbar":{"outlinewidth":0.0,"ticks":""},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"heatmapgl":[{"type":"heatmapgl","colorbar":{"outlinewidth":0.0,"ticks":""},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"histogram":[{"type":"histogram","marker":{"pattern":{"fillmode":"overlay","size":10,"solidity":0.2}}}],"histogram2d":[{"type":"histogram2d","colorbar":{"outlinewidth":0.0,"ticks":""},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"histogram2dcontour":[{"type":"histogram2dcontour","colorbar":{"outlinewidth":0.0,"ticks":""},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"mesh3d":[{"type":"mesh3d","colorbar":{"outlinewidth":0.0,"ticks":""}}],"parcoords":[{"type":"parcoords","line":{"colorbar":{"outlinewidth":0.0,"ticks":""}}}],"pie":[{"type":"pie","automargin":true}],"scatter":[{"type":"scatter","marker":{"colorbar":{"outlinewidth":0.0,"ticks":""}}}],"scatter3d":[{"type":"scatter3d","marker":{"colorbar":{"outlinewidth":0.0,"ticks":""}},"line":{"colorbar":{"outlinewidth":0.0,"ticks":""}}}],"scattercarpet":[{"type":"scattercarpet","marker":{"colorbar":{"outlinewidth":0.0,"ticks":""}}}],"scattergeo":[{"type":"scattergeo","marker":{"colorbar":{"outlinewidth":0.0,"ticks":""}}}],"scattergl":[{"type":"scattergl","marker":{"colorbar":{"outlinewidth":0.0,"ticks":""}}}],"scattermapbox":[{"type":"scattermapbox","marker":{"colorbar":{"outlinewidth":0.0,"ticks":""}}}],"scatterpolar":[{"type":"scatterpolar","marker":{"colorbar":{"outlinewidth":0.0,"ticks":""}}}],"scatterpolargl":[{"type":"scatterpolargl","marker":{"colorbar":{"outlinewidth":0.0,"ticks":""}}}],"scatterternary":[{"type":"scatterternary","marker":{"colorbar":{"outlinewidth":0.0,"ticks":""}}}],"surface":[{"type":"surface","colorbar":{"outlinewidth":0.0,"ticks":""},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"table":[{"type":"table","cells":{"fill":{"color":"rgba(235, 240, 248, 1.0)"},"line":{"color":"rgba(255, 255, 255, 1.0)"}},"header":{"fill":{"color":"rgba(200, 212, 227, 1.0)"},"line":{"color":"rgba(255, 255, 255, 1.0)"}}}]}},"title":{"text":"Hello world!"},"xaxis":{"title":{"text":"xAxis"}},"yaxis":{"title":{"text":"yAxis"}}};
    var config = {"responsive":true};
    Plotly.newPlot('db69a167-4348-4e90-8ff6-fbc35c71b777', data, layout, config);
};
renderPlotly_db69a16743484e908ff6fbc35c71b777();
</script></div>

### Displaying a chart in a notebook cell output

In a notebook context, you usually have (at least when running on a Jupyter server like Binder) no access to the browser on the machine where plotly runs on.
That's why you can render charts directly in the cell output. Just end the cell with the chart value:

```fsharp
let xData' = [ 0. .. 10. ]
let yData' = [ 0. .. 10. ]
Chart.Point(xData', yData')
```

Here is the styled chart:

```fsharp
Chart.Point(xData, yData)
|> Chart.withTitle "Hello world!"
|> Chart.withXAxisStyle ("xAxis")
|> Chart.withYAxisStyle ("yAxis")
```

## Comparison: Usage in F# and C#

One of the main design points of Plotly.NET is to provide support for multiple flavors of chart generation. Here are two examples in different styles and languages that create equivalent charts:

### Functional pipeline style in F#:

```fsharp
[ (1, 5); (2, 10) ]
|> Chart.Point
|> Chart.withTraceInfo (Name = "Hello from F#")
|> Chart.withYAxisStyle (TitleText = "xAxis")
|> Chart.withXAxisStyle (TitleText = "yAxis")
```

### Fluent interface style in C#:

This example uses the high-level native C# bindings for Plotly.NET that are provided by the `Plotly.NET.CSharp` package.

using System;
using Plotly.NET.CSharp;

Chart.Point<double, double, string>(
    x: new double[] { 1, 2 }, 
    y: new double[] { 5, 10 }
)
.WithTraceInfo("Hello from C#", ShowLegend: true)
.WithXAxisStyle<double, double, string>(Title: Plotly.NET.Title.init("xAxis"))
.WithYAxisStyle<double, double, string>(Title: Plotly.NET.Title.init("yAxis"))
.Show();

### Declarative style in F# using the underlying `DynamicObj`:

This API is the most low-level and closest to the original plotly.js syntax. Make sure to spell dynamic members exactly as they are used in the plotly.js json schema.

```fsharp
open Plotly.NET.LayoutObjects

let xAxis =
    let tmp = LinearAxis()
    tmp?title <- "xAxis"
    tmp?showgrid <- false
    tmp?showline <- true
    tmp

let yAxis =
    let tmp = LinearAxis()
    tmp?title <- "yAxis"
    tmp?showgrid <- false
    tmp?showline <- true
    tmp

let layout =
    let tmp = Layout()
    tmp?xaxis <- xAxis
    tmp?yaxis <- yAxis
    tmp?showlegend <- true
    tmp

let trace =
    let tmp = Trace("scatter")
    tmp?x <- [ 1; 2 ]
    tmp?y <- [ 5; 10 ]
    tmp?mode <- "markers"
    tmp?name <- "Hello from F#"
    tmp

GenericChart.ofTraceObject true trace |> GenericChart.setLayout layout
```

### Declarative style in C# using the underlying `DynamicObj`:

Note that this works only when using the Plotly.NET core API, as the C# bindings only target the high level API.

using System;
using Plotly.NET;
using Plotly.NET.LayoutObjects;

double[] x = new double[] { 1, 2 };
double[] y = new double[] { 5, 10 };

LinearAxis xAxis = new LinearAxis();
xAxis.SetProperty("title", "xAxis");
xAxis.SetProperty("showgrid", false);
xAxis.SetProperty("showline", true);

LinearAxis yAxis = new LinearAxis();
yAxis.SetProperty("title", "yAxis");
yAxis.SetProperty("showgrid", false);
yAxis.SetProperty("showline", true);

Layout layout = new Layout();
layout.SetProperty("xaxis", xAxis);
layout.SetProperty("yaxis", yAxis);
layout.SetProperty("showlegend", true);

Trace trace = new Trace("scatter");
trace.SetProperty("x", x);
trace.SetProperty("y", y);
trace.SetProperty("mode", "markers");
trace.SetProperty("name", "Hello from C#");

GenericChart
    .ofTraceObject(true, trace)
    .WithLayout(layout)
    .Show();

# Contributing and copyright

The project is hosted on [GitHub](https://github.com/plotly/Plotly.NET) where you can [report issues](https://github.com/plotly/Plotly.NET/issues), fork
the project and submit pull requests. If you're adding a new public API, please also
consider adding [samples](https://github.com/plotly/Plotly.NET/tree/dev/docs) that can be turned into a documentation. You might
also want to read the [library design notes](https://github.com/plotly/Plotly.NET/blob/dev/README.md) to understand how it works.

The library is available under the OSI-approved MIT license which allows modification and
redistribution for both commercial and non-commercial purposes. For more information, see the
[License file](https://github.com/plotly/Plotly.NET/blob/dev/LICENSE) in the GitHub repository.
