# Sankey charts

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/categorical-charts/sankey.ipynb)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/categorical-charts/sankey.ipynb)

*Summary:* This example shows how to create sankey charts in F#.

Sankey charts are a visualization of multiple, linked graphs layed out linearly.
These are usually used to depict flow between nodes or stations.
To create Sankey, a set of nodes and links between them are required.
These are created using the provided Node and Link structures.

```fsharp
open Plotly.NET

let sankey1 =
    Chart.Sankey(
        nodeLabels = [ "A1"; "A2"; "B1"; "B2"; "C1"; "C2"; "D1" ],
        linkedNodeIds =
            [ // Edgelist, toupling sourceIndex => targetIndex of the link
              0, 2
              0, 3
              1, 3
              2, 4
              3, 4
              3, 5
              4, 6
              5, 6 ],
        NodeOutlineColor = Color.fromKeyword Black,
        NodeOutlineWidth = 1.,
        linkValues = [ 8; 4; 2; 7; 3; 2; 5; 2 ],
        LinkColor =
            Color.fromColors
                [ Color.fromHex "#828BFB"
                  Color.fromHex "#828BFB"
                  Color.fromHex "#F27762"
                  Color.fromHex "#33D6AB"
                  Color.fromHex "#BC82FB"
                  Color.fromHex "#BC82FB"
                  Color.fromHex "#FFB47B"
                  Color.fromHex "#47DCF5" ],
        LinkOutlineColor = Color.fromKeyword Black,
        LinkOutlineWidth = 1.,
        UseDefaults = false
    )
```

<div><div id="3ab34804-427e-4b12-bbec-78d8871ba3ff"><!-- Plotly chart will be drawn inside this DIV --></div><script type="text/javascript">var renderPlotly_3ab34804427e4b12bbec78d8871ba3ff = function() {
    var data = [{"type":"sankey","node":{"label":["A1","A2","B1","B2","C1","C2","D1"],"line":{"color":"rgba(0, 0, 0, 1.0)","width":1.0}},"link":{"color":["rgba(130, 139, 251, 1.0)","rgba(130, 139, 251, 1.0)","rgba(242, 119, 98, 1.0)","rgba(51, 214, 171, 1.0)","rgba(188, 130, 251, 1.0)","rgba(188, 130, 251, 1.0)","rgba(255, 180, 123, 1.0)","rgba(71, 220, 245, 1.0)"],"line":{"color":"rgba(0, 0, 0, 1.0)","width":1.0},"source":[0,0,1,2,3,3,4,5],"target":[2,3,3,4,4,5,6,6],"value":[8,4,2,7,3,2,5,2]}}];
    var layout = {};
    var config = {};
    Plotly.newPlot('3ab34804-427e-4b12-bbec-78d8871ba3ff', data, layout, config);
};
renderPlotly_3ab34804427e4b12bbec78d8871ba3ff();
</script></div>

## Node alignment

The `NodeAlign` parameter controls how nodes are aligned horizontally. The available options are
`Left`, `Right`, `Center`, and `Justify` (the default).

Use the `NodeAlign` parameter on `Chart.Sankey` to apply alignment via the convenience overload,
or pass `Align` to `SankeyNodes.init` directly when building nodes manually:

```fsharp
let sankeyAligned =
    Chart.Sankey(
        nodeLabels = [ "Source A"; "Source B"; "Sink" ],
        linkedNodeIds = [ 0, 2; 1, 2 ],
        linkValues = [ 8; 4 ],
        NodeAlign = StyleParam.SankeyNodeAlign.Left,
        UseDefaults = false
    )
```

<div><div id="0b0ce90b-ad53-4ed2-9fb2-3eedde48f784"><!-- Plotly chart will be drawn inside this DIV --></div><script type="text/javascript">var renderPlotly_0b0ce90bad534ed29fb23eedde48f784 = function() {
    var data = [{"type":"sankey","node":{"align":"left","label":["Source A","Source B","Sink"],"line":{}},"link":{"line":{},"source":[0,1],"target":[2,2],"value":[8,4]}}];
    var layout = {};
    var config = {};
    Plotly.newPlot('0b0ce90b-ad53-4ed2-9fb2-3eedde48f784', data, layout, config);
};
renderPlotly_0b0ce90bad534ed29fb23eedde48f784();
</script></div>
