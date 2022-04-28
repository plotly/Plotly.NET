(**
# Sankey charts

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=09_2_sankey.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/09_2_sankey.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/09_2_sankey.ipynb)

**Summary:** This example shows how to create sankey charts in F#.

Sankey charts are a visualization of multiple, linked graphs layed out linearly.
These are usually used to depict flow between nodes or stations.
To create Sankey, a set of nodes and links between them are required.
These are created using the provided Node and Link structures.

*)
open Plotly.NET

let sankey1 = 
    Chart.Sankey(
        nodeLabels = ["A1"; "A2"; "B1"; "B2"; "C1"; "C2"; "D1"],
        linkedNodeIds = [ // Edgelist, toupling sourceIndex => targetIndex of the link
            0,2
            0,3
            1,3
            2,4
            3,4
            3,5
            4,6
            5,6
        ],
        NodeOutlineColor = Color.fromKeyword Black,
        NodeOutlineWidth = 1.,
        linkValues = [8; 4; 2; 7; 3; 2; 5; 2],
        LinkColor = Color.fromColors [
            Color.fromHex "#828BFB"
            Color.fromHex "#828BFB"
            Color.fromHex "#F27762"
            Color.fromHex "#33D6AB"
            Color.fromHex "#BC82FB"
            Color.fromHex "#BC82FB"
            Color.fromHex "#FFB47B"
            Color.fromHex "#47DCF5"
        ],
        LinkOutlineColor = Color.fromKeyword Black,
        LinkOutlineWidth = 1.,
        UseDefaults = false
    )(* output: 
<div id="53932cb7-d933-4867-bc19-a32563549b20"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_53932cb7d9334867bc19a32563549b20 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.6.3.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"sankey","node":{"label":["A1","A2","B1","B2","C1","C2","D1"],"line":{"color":"rgba(0, 0, 0, 1.0)","width":1.0}},"link":{"color":["rgba(130, 139, 251, 1.0)","rgba(130, 139, 251, 1.0)","rgba(242, 119, 98, 1.0)","rgba(51, 214, 171, 1.0)","rgba(188, 130, 251, 1.0)","rgba(188, 130, 251, 1.0)","rgba(255, 180, 123, 1.0)","rgba(71, 220, 245, 1.0)"],"line":{"color":"rgba(0, 0, 0, 1.0)","width":1.0},"source":[0,0,1,2,3,3,4,5],"target":[2,3,3,4,4,5,6,6],"value":[8,4,2,7,3,2,5,2]}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('53932cb7-d933-4867-bc19-a32563549b20', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_53932cb7d9334867bc19a32563549b20();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_53932cb7d9334867bc19a32563549b20();
            }
</script>
*)

