(**
// can't yet format YamlFrontmatter (["title: Basics "; "category: General"; "categoryindex: 1"; "index: 1"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=00_0_basics.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/00_0_basics.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/00_0_basics.ipynb)

# Plotly.NET basics

_This section is WIP._

### Table of contents

- [GenericChart](#GenericChart)
- [Working with GenericCharts](#Working-with-GenericCharts)
    - [Dynamic object style](#Dynamic-object-style)

## GenericChart


Plotly.NET is a .NET wrapper for creation of [plotly charts]() written in F#. This means that, under the hood, all functionality creates JSON objects that can be rendered by plotly.

The central type that gets created by all Chart constructors is `GenericChart`, which itself represents either a single chart or a multi chart (as a Discriminate Union type). It looks like this:


*)
[<NoComparison>]
type GenericChart =
    | Chart of Trace * Layout * Config * DisplayOptions
    | MultiChart of Trace list * Layout * Config * DisplayOptions
(**
As you can see, a `GenericChart` consists of four top level objects - `Trace` (multiple of those in the case of a MultiChart) , `Layout`, `Config`, and `DisplayOptions`.

- `Trace` is in principle the representation of a dataset on a chart, including for example the data itself, color and shape of the visualization, etc.
- `Layout` is everything of the chart that is not dataset specifivc - e.g. the shape and style of axes, the chart title, etc.
- `Config` is an object that configures high level properties of the chart like making all chart elements editable or the tool bar on top
- `DisplayOptions` is an object that contains meta information about how the html document that contains the chart.

## Working with GenericCharts

### Dynamic object style

Plotly.NET has multiple abstraction layers to work with `GenericChart`s. The prime directive for all functions provided by this library is the construction of valid plotly JSON objects.
For this purpose, `Trace`, `Layout`, and `Config` (and many other internal objects) are inheriting from [`DynamicObj`](https://github.com/plotly/Plotly.NET/blob/dev/src/Plotly.NET/DynamicObj.fs),
an extension of `DynamicObject` which makes it possible to set arbitraryly named and typed properties of these objects via the `?` operator.

So if you want to set any kind of property on one of these objects you can do it in a very declarative way like this:

*)
let myTrace = Trace("scatter") // create a scatter trace
myTrace?x <- [0;1;2] // set the x property (the x dimension of the data)
myTrace?y <- [0;1;2] // set the y property (the y dimension of the data)

GenericChart.ofTraceObject myTrace // create a generic chart (layout and config are empty objects)
|> Chart.show
(**
lets have a look at the trace object that will be created. The relevant section of the html generated with Chart.Show is the following:

```javascript
var data = [{"type":"scatter","x":[0,1,2],"y":[0,1,2]}];
```


*)

