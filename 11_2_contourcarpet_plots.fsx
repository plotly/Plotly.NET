(**
// can't yet format YamlFrontmatter (["title: Contour carpet plots"; "category: Carpet Plots"; "categoryindex: 12"; "index: 2"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# Contour carpet charts

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=11_2_contourcarpet_plots.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/11_2_contourcarpet_plots.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/11_2_contourcarpet_plots.ipynb)

*Summary:* This example shows how to create contour plots on carpets in F#.


*)
open Plotly.NET
open Plotly.NET.LayoutObjects

let contourCarpet = 
    [
        Chart.Carpet(
            "contour",
            A = [0.; 1.; 2.; 3.; 0.; 1.; 2.; 3.; 0.; 1.; 2.; 3.],
            B = [4.; 4.; 4.; 4.; 5.; 5.; 5.; 5.; 6.; 6.; 6.; 6.],
            X = [2.; 3.; 4.; 5.; 2.2; 3.1; 4.1; 5.1; 1.5; 2.5; 3.5; 4.5],
            Y = [1.; 1.4; 1.6; 1.75; 2.; 2.5; 2.7; 2.75; 3.; 3.5; 3.7; 3.75],
            AAxis = LinearAxis.initCarpet(
                TickPrefix = "a = ",
                Smoothing = 0.,
                MinorGridCount = 9,
                AxisType = StyleParam.AxisType.Linear
            ),
            BAxis = LinearAxis.initCarpet(
                TickPrefix = "b = ",
                Smoothing = 0.,
                MinorGridCount = 9,
                AxisType = StyleParam.AxisType.Linear
            )
        )    
        Chart.ContourCarpet(
            "contour",
            [1.; 1.96; 2.56; 3.0625; 4.; 5.0625; 1.; 7.5625; 9.; 12.25; 15.21; 14.0625],
            A = [0; 1; 2; 3; 0; 1; 2; 3; 0; 1; 2; 3],
            B = [4; 4; 4; 4; 5; 5; 5; 5; 6; 6; 6; 6]
        )
    ]
    |> Chart.combine(* output: 
<div id="343a962f-0d89-4009-8253-794644f4913c"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_343a962f0d8940098253794644f4913c = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"carpet","x":[2.0,3.0,4.0,5.0,2.2,3.1,4.1,5.1,1.5,2.5,3.5,4.5],"y":[1.0,1.4,1.6,1.75,2.0,2.5,2.7,2.75,3.0,3.5,3.7,3.75],"a":[0.0,1.0,2.0,3.0,0.0,1.0,2.0,3.0,0.0,1.0,2.0,3.0],"b":[4.0,4.0,4.0,4.0,5.0,5.0,5.0,5.0,6.0,6.0,6.0,6.0],"aaxis":{"type":"linear","tickprefix":"a = ","minorgridcount":9,"smoothing":0.0},"baxis":{"type":"linear","tickprefix":"b = ","minorgridcount":9,"smoothing":0.0},"carpet":"contour"},{"type":"contourcarpet","z":[1.0,1.96,2.56,3.0625,4.0,5.0625,1.0,7.5625,9.0,12.25,15.21,14.0625],"a":[0,1,2,3,0,1,2,3,0,1,2,3],"b":[4,4,4,4,5,5,5,5,6,6,6,6],"carpet":"contour","line":{}}];
            var layout = {"width":600,"height":600,"template":{"layout":{"title":{"x":0.05},"font":{"color":"rgba(42, 63, 95, 1.0)"},"paper_bgcolor":"rgba(255, 255, 255, 1.0)","plot_bgcolor":"rgba(229, 236, 246, 1.0)","autotypenumbers":"strict","colorscale":{"diverging":[[0.0,"#8e0152"],[0.1,"#c51b7d"],[0.2,"#de77ae"],[0.3,"#f1b6da"],[0.4,"#fde0ef"],[0.5,"#f7f7f7"],[0.6,"#e6f5d0"],[0.7,"#b8e186"],[0.8,"#7fbc41"],[0.9,"#4d9221"],[1.0,"#276419"]],"sequential":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]],"sequentialminus":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]},"hovermode":"closest","hoverlabel":{"align":"left"},"coloraxis":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}},"geo":{"showland":true,"landcolor":"rgba(229, 236, 246, 1.0)","showlakes":true,"lakecolor":"rgba(255, 255, 255, 1.0)","subunitcolor":"rgba(255, 255, 255, 1.0)","bgcolor":"rgba(255, 255, 255, 1.0)"},"mapbox":{"style":"light"},"polar":{"bgcolor":"rgba(229, 236, 246, 1.0)","radialaxis":{"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","ticks":""},"angularaxis":{"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","ticks":""}},"scene":{"xaxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","gridwidth":2.0,"zerolinecolor":"rgba(255, 255, 255, 1.0)","backgroundcolor":"rgba(229, 236, 246, 1.0)","showbackground":true},"yaxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","gridwidth":2.0,"zerolinecolor":"rgba(255, 255, 255, 1.0)","backgroundcolor":"rgba(229, 236, 246, 1.0)","showbackground":true},"zaxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","gridwidth":2.0,"zerolinecolor":"rgba(255, 255, 255, 1.0)","backgroundcolor":"rgba(229, 236, 246, 1.0)","showbackground":true}},"ternary":{"aaxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)"},"baxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)"},"caxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)"},"bgcolor":"rgba(229, 236, 246, 1.0)"},"xaxis":{"title":{"standoff":15},"ticks":"","automargin":true,"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","zerolinecolor":"rgba(255, 255, 255, 1.0)","zerolinewidth":2.0},"yaxis":{"title":{"standoff":15},"ticks":"","automargin":true,"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","zerolinecolor":"rgba(255, 255, 255, 1.0)","zerolinewidth":2.0},"annotationdefaults":{"arrowcolor":"#2a3f5f","arrowhead":0,"arrowwidth":1},"shapedefaults":{"line":{"color":"rgba(42, 63, 95, 1.0)"}},"colorway":["rgba(99, 110, 250, 1.0)","rgba(239, 85, 59, 1.0)","rgba(0, 204, 150, 1.0)","rgba(171, 99, 250, 1.0)","rgba(255, 161, 90, 1.0)","rgba(25, 211, 243, 1.0)","rgba(255, 102, 146, 1.0)","rgba(182, 232, 128, 1.0)","rgba(255, 151, 255, 1.0)","rgba(254, 203, 82, 1.0)"]},"data":{"bar":[{"marker":{"line":{"color":"rgba(229, 236, 246, 1.0)","width":0.5},"pattern":{"fillmode":"overlay","size":10,"solidity":0.2}},"errorx":{"color":"rgba(42, 63, 95, 1.0)"},"errory":{"color":"rgba(42, 63, 95, 1.0)"}}],"barpolar":[{"marker":{"line":{"color":"rgba(229, 236, 246, 1.0)","width":0.5},"pattern":{"fillmode":"overlay","size":10,"solidity":0.2}}}],"carpet":[{"aaxis":{"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","endlinecolor":"rgba(42, 63, 95, 1.0)","minorgridcolor":"rgba(255, 255, 255, 1.0)","startlinecolor":"rgba(42, 63, 95, 1.0)"},"baxis":{"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","endlinecolor":"rgba(42, 63, 95, 1.0)","minorgridcolor":"rgba(255, 255, 255, 1.0)","startlinecolor":"rgba(42, 63, 95, 1.0)"}}],"choropleth":[{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}],"contour":[{"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]],"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}],"contourcarpet":[{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}],"heatmap":[{"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]],"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}],"heatmapgl":[{"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]],"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}],"histogram":[{"marker":{"pattern":{"fillmode":"overlay","size":10,"solidity":0.2}}}],"histogram2D":[{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"histogram2Dcontour":[{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"mesh3d":[{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}],"parcoords":[{"line":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"pie":[{"automargin":true}],"scatter":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"scatter3d":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}},"line":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"scattercarpet":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"scattergeo":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"scattergl":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"scattermapbox":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"scatterpolar":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"scatterpolargl":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"scatterternary":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"surface":[{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}]}}};
            var config = {"responsive":true};
            Plotly.newPlot('343a962f-0d89-4009-8253-794644f4913c', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_343a962f0d8940098253794644f4913c();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_343a962f0d8940098253794644f4913c();
            }
</script>
*)

