(**
// can't yet format YamlFrontmatter (["title: Tables"; "category: Simple Charts"; "categoryindex: 3"; "index: 7"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# Tables

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=02_6_table.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/02_6_table.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/02_6_table.ipynb)

This example shows how to create tables in F#.

let's first create some data for the purpose of creating example charts:


*)
open Plotly.NET 
open Plotly.NET.StyleParam
  
let header = ["<b>RowIndex</b>";"A";"simple";"table"]
let rows = 
    [
     ["0";"I"     ;"am"     ;"a"]        
     ["1";"little";"example";"!"]       
    ]


let table1 = Chart.Table(header, rows)(* output: 
<div id="2e038992-a290-4b3a-a0fa-f9927b533039"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_2e038992a2904b3aa0faf9927b533039 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"table","header":{"values":["<b>RowIndex</b>","A","simple","table"]},"cells":{"values":[["0","1"],["I","little"],["am","example"],["a","!"]]}}];
            var layout = {"width":600,"height":600,"template":{"layout":{"title":{"x":0.05},"font":{"color":"rgba(42, 63, 95, 1.0)"},"paper_bgcolor":"rgba(255, 255, 255, 1.0)","plot_bgcolor":"rgba(229, 236, 246, 1.0)","autotypenumbers":"strict","colorscale":{"diverging":[[0.0,"#8e0152"],[0.1,"#c51b7d"],[0.2,"#de77ae"],[0.3,"#f1b6da"],[0.4,"#fde0ef"],[0.5,"#f7f7f7"],[0.6,"#e6f5d0"],[0.7,"#b8e186"],[0.8,"#7fbc41"],[0.9,"#4d9221"],[1.0,"#276419"]],"sequential":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]],"sequentialminus":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]},"hovermode":"closest","hoverlabel":{"align":"left"},"coloraxis":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}},"geo":{"showland":true,"landcolor":"rgba(229, 236, 246, 1.0)","showlakes":true,"lakecolor":"rgba(255, 255, 255, 1.0)","subunitcolor":"rgba(255, 255, 255, 1.0)","bgcolor":"rgba(255, 255, 255, 1.0)"},"mapbox":{"style":"light"},"polar":{"bgcolor":"rgba(229, 236, 246, 1.0)","radialaxis":{"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","ticks":""},"angularaxis":{"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","ticks":""}},"scene":{"xaxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","gridwidth":2.0,"zerolinecolor":"rgba(255, 255, 255, 1.0)","backgroundcolor":"rgba(229, 236, 246, 1.0)","showbackground":true},"yaxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","gridwidth":2.0,"zerolinecolor":"rgba(255, 255, 255, 1.0)","backgroundcolor":"rgba(229, 236, 246, 1.0)","showbackground":true},"zaxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","gridwidth":2.0,"zerolinecolor":"rgba(255, 255, 255, 1.0)","backgroundcolor":"rgba(229, 236, 246, 1.0)","showbackground":true}},"ternary":{"aaxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)"},"baxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)"},"caxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)"},"bgcolor":"rgba(229, 236, 246, 1.0)"},"xaxis":{"title":{"standoff":15},"ticks":"","automargin":true,"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","zerolinecolor":"rgba(255, 255, 255, 1.0)","zerolinewidth":2.0},"yaxis":{"title":{"standoff":15},"ticks":"","automargin":true,"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","zerolinecolor":"rgba(255, 255, 255, 1.0)","zerolinewidth":2.0},"annotationdefaults":{"arrowcolor":"#2a3f5f","arrowhead":0,"arrowwidth":1},"shapedefaults":{"line":{"color":"rgba(42, 63, 95, 1.0)"}},"colorway":["rgba(99, 110, 250, 1.0)","rgba(239, 85, 59, 1.0)","rgba(0, 204, 150, 1.0)","rgba(171, 99, 250, 1.0)","rgba(255, 161, 90, 1.0)","rgba(25, 211, 243, 1.0)","rgba(255, 102, 146, 1.0)","rgba(182, 232, 128, 1.0)","rgba(255, 151, 255, 1.0)","rgba(254, 203, 82, 1.0)"]},"data":{"bar":[{"marker":{"line":{"color":"rgba(229, 236, 246, 1.0)","width":0.5},"pattern":{"fillmode":"overlay","size":10,"solidity":0.2}},"errorx":{"color":"rgba(42, 63, 95, 1.0)"},"errory":{"color":"rgba(42, 63, 95, 1.0)"}}],"barpolar":[{"marker":{"line":{"color":"rgba(229, 236, 246, 1.0)","width":0.5},"pattern":{"fillmode":"overlay","size":10,"solidity":0.2}}}],"carpet":[{"aaxis":{"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","endlinecolor":"rgba(42, 63, 95, 1.0)","minorgridcolor":"rgba(255, 255, 255, 1.0)","startlinecolor":"rgba(42, 63, 95, 1.0)"},"baxis":{"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","endlinecolor":"rgba(42, 63, 95, 1.0)","minorgridcolor":"rgba(255, 255, 255, 1.0)","startlinecolor":"rgba(42, 63, 95, 1.0)"}}],"choropleth":[{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}],"contour":[{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"contourcarpet":[{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}],"heatmap":[{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"heatmapgl":[{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"histogram":[{"marker":{"pattern":{"fillmode":"overlay","size":10,"solidity":0.2}}}],"histogram2d":[{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"histogram2dcontour":[{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"mesh3d":[{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}],"parcoords":[{"line":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"pie":[{"automargin":true}],"scatter":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"scatter3d":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}},"line":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"scattercarpet":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"scattergeo":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"scattergl":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"scattermapbox":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"scatterpolar":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"scatterpolargl":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"scatterternary":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"surface":[{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}]}}};
            var config = {"responsive":true};
            Plotly.newPlot('2e038992-a290-4b3a-a0fa-f9927b533039', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_2e038992a2904b3aa0faf9927b533039();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_2e038992a2904b3aa0faf9927b533039();
            }
</script>
*)
(**
A little bit of styling:

*)
let table2 =
    Chart.Table(
        header,
        rows,
        //sets global header alignment
        AlignHeader = [HorizontalAlign.Center],
        //sets alignment for each column separately 
        //(The last alignment is applied to all potential following columns)
        AlignCells  = [HorizontalAlign.Left;HorizontalAlign.Center;HorizontalAlign.Right],
        //sets global header color
        ColorHeader = Color.fromString "#45546a",    
        //sets specific color to each header column
        //ColorHeader=["#45546a";"#deebf7";"#45546a";"#deebf7"],    
        //sets global cell color
        //ColorRows = "#deebf7",
        //sets cell column colors
        ColorCells  = Color.fromColors [
            Color.fromString "#deebf7"
            Color.fromString "lightgrey"
            Color.fromString "#deebf7"
            Color.fromString "lightgrey"
        ],
        //sets cell row colors
        //ColorCells=[["#deebf7";"lightgrey"]],
        //sets font of header
        FontHeader  = Font.init(FontFamily.Courier_New, Size=12., Color=Color.fromString "white"),      
        //sets the height of the header
        HeightHeader= 30.,
        //sets lines of header
        LineHeader  = Line.init(2.,Color.fromString "black"),                     
        ColumnWidth = [70;50;100;70],      
        //defines order of columns
        ColumnOrder = [1;2;3;4]                                  
        )(* output: 
<div id="db6fd188-3725-44bf-aaf7-efda4155fa1d"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_db6fd188372544bfaaf7efda4155fa1d = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"table","header":{"values":["<b>RowIndex</b>","A","simple","table"],"align":["center"],"height":30.0,"fill":{"color":"#45546a"},"line":{"color":"black","width":2.0},"font":{"family":"Courier New","size":12.0,"color":"white"}},"cells":{"values":[["0","1"],["I","little"],["am","example"],["a","!"]],"align":["left","center","right"],"fill":{"color":["#deebf7","lightgrey","#deebf7","lightgrey"]}},"columnwidth":[70,50,100,70],"columnorder":[1,2,3,4]}];
            var layout = {"width":600,"height":600,"template":{"layout":{"title":{"x":0.05},"font":{"color":"rgba(42, 63, 95, 1.0)"},"paper_bgcolor":"rgba(255, 255, 255, 1.0)","plot_bgcolor":"rgba(229, 236, 246, 1.0)","autotypenumbers":"strict","colorscale":{"diverging":[[0.0,"#8e0152"],[0.1,"#c51b7d"],[0.2,"#de77ae"],[0.3,"#f1b6da"],[0.4,"#fde0ef"],[0.5,"#f7f7f7"],[0.6,"#e6f5d0"],[0.7,"#b8e186"],[0.8,"#7fbc41"],[0.9,"#4d9221"],[1.0,"#276419"]],"sequential":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]],"sequentialminus":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]},"hovermode":"closest","hoverlabel":{"align":"left"},"coloraxis":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}},"geo":{"showland":true,"landcolor":"rgba(229, 236, 246, 1.0)","showlakes":true,"lakecolor":"rgba(255, 255, 255, 1.0)","subunitcolor":"rgba(255, 255, 255, 1.0)","bgcolor":"rgba(255, 255, 255, 1.0)"},"mapbox":{"style":"light"},"polar":{"bgcolor":"rgba(229, 236, 246, 1.0)","radialaxis":{"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","ticks":""},"angularaxis":{"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","ticks":""}},"scene":{"xaxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","gridwidth":2.0,"zerolinecolor":"rgba(255, 255, 255, 1.0)","backgroundcolor":"rgba(229, 236, 246, 1.0)","showbackground":true},"yaxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","gridwidth":2.0,"zerolinecolor":"rgba(255, 255, 255, 1.0)","backgroundcolor":"rgba(229, 236, 246, 1.0)","showbackground":true},"zaxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","gridwidth":2.0,"zerolinecolor":"rgba(255, 255, 255, 1.0)","backgroundcolor":"rgba(229, 236, 246, 1.0)","showbackground":true}},"ternary":{"aaxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)"},"baxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)"},"caxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)"},"bgcolor":"rgba(229, 236, 246, 1.0)"},"xaxis":{"title":{"standoff":15},"ticks":"","automargin":true,"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","zerolinecolor":"rgba(255, 255, 255, 1.0)","zerolinewidth":2.0},"yaxis":{"title":{"standoff":15},"ticks":"","automargin":true,"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","zerolinecolor":"rgba(255, 255, 255, 1.0)","zerolinewidth":2.0},"annotationdefaults":{"arrowcolor":"#2a3f5f","arrowhead":0,"arrowwidth":1},"shapedefaults":{"line":{"color":"rgba(42, 63, 95, 1.0)"}},"colorway":["rgba(99, 110, 250, 1.0)","rgba(239, 85, 59, 1.0)","rgba(0, 204, 150, 1.0)","rgba(171, 99, 250, 1.0)","rgba(255, 161, 90, 1.0)","rgba(25, 211, 243, 1.0)","rgba(255, 102, 146, 1.0)","rgba(182, 232, 128, 1.0)","rgba(255, 151, 255, 1.0)","rgba(254, 203, 82, 1.0)"]},"data":{"bar":[{"marker":{"line":{"color":"rgba(229, 236, 246, 1.0)","width":0.5},"pattern":{"fillmode":"overlay","size":10,"solidity":0.2}},"errorx":{"color":"rgba(42, 63, 95, 1.0)"},"errory":{"color":"rgba(42, 63, 95, 1.0)"}}],"barpolar":[{"marker":{"line":{"color":"rgba(229, 236, 246, 1.0)","width":0.5},"pattern":{"fillmode":"overlay","size":10,"solidity":0.2}}}],"carpet":[{"aaxis":{"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","endlinecolor":"rgba(42, 63, 95, 1.0)","minorgridcolor":"rgba(255, 255, 255, 1.0)","startlinecolor":"rgba(42, 63, 95, 1.0)"},"baxis":{"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","endlinecolor":"rgba(42, 63, 95, 1.0)","minorgridcolor":"rgba(255, 255, 255, 1.0)","startlinecolor":"rgba(42, 63, 95, 1.0)"}}],"choropleth":[{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}],"contour":[{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"contourcarpet":[{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}],"heatmap":[{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"heatmapgl":[{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"histogram":[{"marker":{"pattern":{"fillmode":"overlay","size":10,"solidity":0.2}}}],"histogram2d":[{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"histogram2dcontour":[{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"mesh3d":[{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}],"parcoords":[{"line":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"pie":[{"automargin":true}],"scatter":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"scatter3d":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}},"line":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"scattercarpet":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"scattergeo":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"scattergl":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"scattermapbox":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"scatterpolar":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"scatterpolargl":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"scatterternary":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"surface":[{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}]}}};
            var config = {"responsive":true};
            Plotly.newPlot('db6fd188-3725-44bf-aaf7-efda4155fa1d', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_db6fd188372544bfaaf7efda4155fa1d();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_db6fd188372544bfaaf7efda4155fa1d();
            }
</script>
*)
(**
Value dependent cell coloring:

*)
let header2 = ["Identifier";"T0";"T1";"T2";"T3"]
let rowvalues = 
    [
     [10001.;0.2;2.0;4.0;5.0]
     [10002.;2.1;2.0;1.8;2.1]
     [10003.;4.5;3.0;2.0;2.5]
     [10004.;0.0;0.1;0.3;0.2]
     [10005.;1.0;1.6;1.8;2.2]
     [10006.;1.0;0.8;1.5;0.7]
     [10007.;2.0;2.0;2.1;1.9]
    ]
    |> Seq.sortBy (fun x -> x.[1])

//map color from value to hex representation
let mapColor min max value = 
    let proportion = 
        (255. * (value - min) / (max - min))
        |> int
    Color.fromRGB 255 (255 - proportion) proportion
    
//Assign a color to every cell seperately. Matrix must be transposed for correct orientation.
let cellcolor = 
     rowvalues
     |> Seq.map (fun row ->
        row 
        |> Seq.mapi (fun index value -> 
            if index = 0 then Color.fromString "white"
            else mapColor 0. 5. value
            )
        )
    |> Seq.transpose
    |> Seq.map Color.fromColors
    |> Color.fromColors

let table3 = Chart.Table(header2,rowvalues,ColorCells=cellcolor)(* output: 
<div id="aa9f5e5e-ecea-4da9-a315-ad8b0728a678"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_aa9f5e5eecea4da9a315ad8b0728a678 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"table","header":{"values":["Identifier","T0","T1","T2","T3"]},"cells":{"values":[[10004.0,10001.0,10005.0,10006.0,10007.0,10002.0,10003.0],[0.0,0.2,1.0,1.0,2.0,2.1,4.5],[0.1,2.0,1.6,0.8,2.0,2.0,3.0],[0.3,4.0,1.8,1.5,2.1,1.8,2.0],[0.2,5.0,2.2,0.7,1.9,2.1,2.5]],"fill":{"color":[["white","white","white","white","white","white","white"],["rgba(255, 255, 0, 1.0)","rgba(255, 245, 10, 1.0)","rgba(255, 204, 51, 1.0)","rgba(255, 204, 51, 1.0)","rgba(255, 153, 102, 1.0)","rgba(255, 148, 107, 1.0)","rgba(255, 26, 229, 1.0)"],["rgba(255, 250, 5, 1.0)","rgba(255, 153, 102, 1.0)","rgba(255, 174, 81, 1.0)","rgba(255, 215, 40, 1.0)","rgba(255, 153, 102, 1.0)","rgba(255, 153, 102, 1.0)","rgba(255, 102, 153, 1.0)"],["rgba(255, 240, 15, 1.0)","rgba(255, 51, 204, 1.0)","rgba(255, 164, 91, 1.0)","rgba(255, 179, 76, 1.0)","rgba(255, 148, 107, 1.0)","rgba(255, 164, 91, 1.0)","rgba(255, 153, 102, 1.0)"],["rgba(255, 245, 10, 1.0)","rgba(255, 0, 255, 1.0)","rgba(255, 143, 112, 1.0)","rgba(255, 220, 35, 1.0)","rgba(255, 159, 96, 1.0)","rgba(255, 148, 107, 1.0)","rgba(255, 128, 127, 1.0)"]]}}}];
            var layout = {"width":600,"height":600,"template":{"layout":{"title":{"x":0.05},"font":{"color":"rgba(42, 63, 95, 1.0)"},"paper_bgcolor":"rgba(255, 255, 255, 1.0)","plot_bgcolor":"rgba(229, 236, 246, 1.0)","autotypenumbers":"strict","colorscale":{"diverging":[[0.0,"#8e0152"],[0.1,"#c51b7d"],[0.2,"#de77ae"],[0.3,"#f1b6da"],[0.4,"#fde0ef"],[0.5,"#f7f7f7"],[0.6,"#e6f5d0"],[0.7,"#b8e186"],[0.8,"#7fbc41"],[0.9,"#4d9221"],[1.0,"#276419"]],"sequential":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]],"sequentialminus":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]},"hovermode":"closest","hoverlabel":{"align":"left"},"coloraxis":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}},"geo":{"showland":true,"landcolor":"rgba(229, 236, 246, 1.0)","showlakes":true,"lakecolor":"rgba(255, 255, 255, 1.0)","subunitcolor":"rgba(255, 255, 255, 1.0)","bgcolor":"rgba(255, 255, 255, 1.0)"},"mapbox":{"style":"light"},"polar":{"bgcolor":"rgba(229, 236, 246, 1.0)","radialaxis":{"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","ticks":""},"angularaxis":{"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","ticks":""}},"scene":{"xaxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","gridwidth":2.0,"zerolinecolor":"rgba(255, 255, 255, 1.0)","backgroundcolor":"rgba(229, 236, 246, 1.0)","showbackground":true},"yaxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","gridwidth":2.0,"zerolinecolor":"rgba(255, 255, 255, 1.0)","backgroundcolor":"rgba(229, 236, 246, 1.0)","showbackground":true},"zaxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","gridwidth":2.0,"zerolinecolor":"rgba(255, 255, 255, 1.0)","backgroundcolor":"rgba(229, 236, 246, 1.0)","showbackground":true}},"ternary":{"aaxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)"},"baxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)"},"caxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)"},"bgcolor":"rgba(229, 236, 246, 1.0)"},"xaxis":{"title":{"standoff":15},"ticks":"","automargin":true,"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","zerolinecolor":"rgba(255, 255, 255, 1.0)","zerolinewidth":2.0},"yaxis":{"title":{"standoff":15},"ticks":"","automargin":true,"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","zerolinecolor":"rgba(255, 255, 255, 1.0)","zerolinewidth":2.0},"annotationdefaults":{"arrowcolor":"#2a3f5f","arrowhead":0,"arrowwidth":1},"shapedefaults":{"line":{"color":"rgba(42, 63, 95, 1.0)"}},"colorway":["rgba(99, 110, 250, 1.0)","rgba(239, 85, 59, 1.0)","rgba(0, 204, 150, 1.0)","rgba(171, 99, 250, 1.0)","rgba(255, 161, 90, 1.0)","rgba(25, 211, 243, 1.0)","rgba(255, 102, 146, 1.0)","rgba(182, 232, 128, 1.0)","rgba(255, 151, 255, 1.0)","rgba(254, 203, 82, 1.0)"]},"data":{"bar":[{"marker":{"line":{"color":"rgba(229, 236, 246, 1.0)","width":0.5},"pattern":{"fillmode":"overlay","size":10,"solidity":0.2}},"errorx":{"color":"rgba(42, 63, 95, 1.0)"},"errory":{"color":"rgba(42, 63, 95, 1.0)"}}],"barpolar":[{"marker":{"line":{"color":"rgba(229, 236, 246, 1.0)","width":0.5},"pattern":{"fillmode":"overlay","size":10,"solidity":0.2}}}],"carpet":[{"aaxis":{"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","endlinecolor":"rgba(42, 63, 95, 1.0)","minorgridcolor":"rgba(255, 255, 255, 1.0)","startlinecolor":"rgba(42, 63, 95, 1.0)"},"baxis":{"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","endlinecolor":"rgba(42, 63, 95, 1.0)","minorgridcolor":"rgba(255, 255, 255, 1.0)","startlinecolor":"rgba(42, 63, 95, 1.0)"}}],"choropleth":[{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}],"contour":[{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"contourcarpet":[{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}],"heatmap":[{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"heatmapgl":[{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"histogram":[{"marker":{"pattern":{"fillmode":"overlay","size":10,"solidity":0.2}}}],"histogram2d":[{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"histogram2dcontour":[{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"mesh3d":[{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}],"parcoords":[{"line":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"pie":[{"automargin":true}],"scatter":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"scatter3d":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}},"line":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"scattercarpet":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"scattergeo":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"scattergl":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"scattermapbox":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"scatterpolar":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"scatterpolargl":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"scatterternary":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"surface":[{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}]}}};
            var config = {"responsive":true};
            Plotly.newPlot('aa9f5e5e-ecea-4da9-a315-ad8b0728a678', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_aa9f5e5eecea4da9a315ad8b0728a678();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_aa9f5e5eecea4da9a315ad8b0728a678();
            }
</script>
*)
(**
Sequence representation:


*)
let sequence =
        [
        "ATGAGACGTCGAGACTGATAGACGTCGATAGACGTCGATAGACCG"
        "ATAGACTCGTGATAGACGTCGATAGACGTCGATAGAGTATAGACC"
        "GTGATAGACGTCGAGAAGACGTCGATAGACGTCGATAGACGTCGA"
        "TAGAGATAGACGTCGATAGACCGTATAGAAGACGTCGATAGATAG"
        "ACGTCGATAGACCGTAGACGTCGATAGACGTCGATAGACCGT"
        ]
        |> String.concat ""

let elementsPerRow = 60

let headers = 
    [0..elementsPerRow] 
    |> Seq.map (fun x -> 
        if x%10=0 && x <> 0 then "|" 
        else ""
        )

let cells = 
    sequence
    |> Seq.chunkBySize elementsPerRow
    |> Seq.mapi (fun i x -> Seq.append [string (i * elementsPerRow)] (Seq.map string x))

let cellcolors =
    cells
    |> Seq.map (fun row -> 
        row 
        |> Seq.map (fun element -> 
            match element with
            //colors taken from DRuMS 
            //(http://biomodel.uah.es/en/model4/dna/atgc.htm)
            | "A" -> Color.fromHex "#5050FF" 
            | "T" -> Color.fromHex "#E6E600"
            | "G" -> Color.fromHex "#00C000"
            | "C" -> Color.fromHex "#E00000"
            | "U" -> Color.fromHex "#B48100"
            | _   -> Color.fromString "white"
            )
        )
    |> Seq.transpose
    |> Seq.map (fun x -> Seq.append x (seq [Color.fromString "white"]))
    |> Seq.map Color.fromColors
    |> Color.fromColors

let font = Font.init(FontFamily.Consolas,Size=14.)
let line = Line.init(0.,Color.fromString "white")
let chartwidth = 50. + 10. * float elementsPerRow

let table4 =
    Chart.Table(
        headers,
        cells,
        LineCells   = line,
        LineHeader  = line,
        HeightCells = 20.,
        FontHeader  = font,
        FontCells   = font,
        ColumnWidth = [50;10],
        AlignCells  = [HorizontalAlign.Right;HorizontalAlign.Center],
        ColorCells  = cellcolors
        )
    |> Chart.withSize(chartwidth,nan)
    |> Chart.withTitle "Sequence A"(* output: 
<div id="159dbde1-dcd0-4035-b78f-b3d11a5a73eb"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_159dbde1dcd04035b78fb3d11a5a73eb = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"table","header":{"values":["","","","","","","","","","","|","","","","","","","","","","|","","","","","","","","","","|","","","","","","","","","","|","","","","","","","","","","|","","","","","","","","","","|"],"line":{"color":"white","width":0.0},"font":{"family":"Consolas","size":14.0}},"cells":{"values":[["0","60","120","180"],["A","A","G","A"],["T","C","T","C"],["G","G","C","G"],["A","T","G","T"],["G","C","A","C"],["A","G","T","G"],["C","A","A","A"],["G","T","G","T"],["T","A","A","A"],["C","G","C","G"],["G","A","G","A"],["A","C","T","C"],["G","G","C","C"],["A","T","G","G"],["C","C","A","T"],["T","G","T","A"],["G","A","A","G"],["A","T","G","A"],["T","A","A","C"],["A","G","G","G"],["G","A","A","T"],["A","G","T","C"],["C","T","A","G"],["G","A","G","A"],["T","T","A","T"],["C","A","C","A"],["G","G","G","G"],["A","A","T","A"],["T","C","C","C"],["A","C","G","G"],["G","G","A","T"],["A","T","T","C"],["C","G","A","G"],["G","A","G","A"],["T","T","A","T"],["C","A","C","A"],["G","G","C","G"],["A","A","G","A"],["T","C","T","C"],["A","G","A","C"],["G","T","T","G"],["A","C","A","T"],["C","G","G"],["C","A","A"],["G","G","A"],["A","A","G"],["T","A","A"],["A","G","C"],["G","A","G"],["A","C","T"],["C","G","C"],["T","T","G"],["C","C","A"],["G","G","T"],["T","A","A"],["G","T","G"],["A","A","A"],["T","G","T"],["A","A","A"],["G","C","G"]],"align":["right","center"],"height":20.0,"fill":{"color":[["white","white","white","white","white"],["rgba(80, 80, 255, 1.0)","rgba(80, 80, 255, 1.0)","rgba(0, 192, 0, 1.0)","rgba(80, 80, 255, 1.0)","white"],["rgba(230, 230, 0, 1.0)","rgba(224, 0, 0, 1.0)","rgba(230, 230, 0, 1.0)","rgba(224, 0, 0, 1.0)","white"],["rgba(0, 192, 0, 1.0)","rgba(0, 192, 0, 1.0)","rgba(224, 0, 0, 1.0)","rgba(0, 192, 0, 1.0)","white"],["rgba(80, 80, 255, 1.0)","rgba(230, 230, 0, 1.0)","rgba(0, 192, 0, 1.0)","rgba(230, 230, 0, 1.0)","white"],["rgba(0, 192, 0, 1.0)","rgba(224, 0, 0, 1.0)","rgba(80, 80, 255, 1.0)","rgba(224, 0, 0, 1.0)","white"],["rgba(80, 80, 255, 1.0)","rgba(0, 192, 0, 1.0)","rgba(230, 230, 0, 1.0)","rgba(0, 192, 0, 1.0)","white"],["rgba(224, 0, 0, 1.0)","rgba(80, 80, 255, 1.0)","rgba(80, 80, 255, 1.0)","rgba(80, 80, 255, 1.0)","white"],["rgba(0, 192, 0, 1.0)","rgba(230, 230, 0, 1.0)","rgba(0, 192, 0, 1.0)","rgba(230, 230, 0, 1.0)","white"],["rgba(230, 230, 0, 1.0)","rgba(80, 80, 255, 1.0)","rgba(80, 80, 255, 1.0)","rgba(80, 80, 255, 1.0)","white"],["rgba(224, 0, 0, 1.0)","rgba(0, 192, 0, 1.0)","rgba(224, 0, 0, 1.0)","rgba(0, 192, 0, 1.0)","white"],["rgba(0, 192, 0, 1.0)","rgba(80, 80, 255, 1.0)","rgba(0, 192, 0, 1.0)","rgba(80, 80, 255, 1.0)","white"],["rgba(80, 80, 255, 1.0)","rgba(224, 0, 0, 1.0)","rgba(230, 230, 0, 1.0)","rgba(224, 0, 0, 1.0)","white"],["rgba(0, 192, 0, 1.0)","rgba(0, 192, 0, 1.0)","rgba(224, 0, 0, 1.0)","rgba(224, 0, 0, 1.0)","white"],["rgba(80, 80, 255, 1.0)","rgba(230, 230, 0, 1.0)","rgba(0, 192, 0, 1.0)","rgba(0, 192, 0, 1.0)","white"],["rgba(224, 0, 0, 1.0)","rgba(224, 0, 0, 1.0)","rgba(80, 80, 255, 1.0)","rgba(230, 230, 0, 1.0)","white"],["rgba(230, 230, 0, 1.0)","rgba(0, 192, 0, 1.0)","rgba(230, 230, 0, 1.0)","rgba(80, 80, 255, 1.0)","white"],["rgba(0, 192, 0, 1.0)","rgba(80, 80, 255, 1.0)","rgba(80, 80, 255, 1.0)","rgba(0, 192, 0, 1.0)","white"],["rgba(80, 80, 255, 1.0)","rgba(230, 230, 0, 1.0)","rgba(0, 192, 0, 1.0)","rgba(80, 80, 255, 1.0)","white"],["rgba(230, 230, 0, 1.0)","rgba(80, 80, 255, 1.0)","rgba(80, 80, 255, 1.0)","rgba(224, 0, 0, 1.0)","white"],["rgba(80, 80, 255, 1.0)","rgba(0, 192, 0, 1.0)","rgba(0, 192, 0, 1.0)","rgba(0, 192, 0, 1.0)","white"],["rgba(0, 192, 0, 1.0)","rgba(80, 80, 255, 1.0)","rgba(80, 80, 255, 1.0)","rgba(230, 230, 0, 1.0)","white"],["rgba(80, 80, 255, 1.0)","rgba(0, 192, 0, 1.0)","rgba(230, 230, 0, 1.0)","rgba(224, 0, 0, 1.0)","white"],["rgba(224, 0, 0, 1.0)","rgba(230, 230, 0, 1.0)","rgba(80, 80, 255, 1.0)","rgba(0, 192, 0, 1.0)","white"],["rgba(0, 192, 0, 1.0)","rgba(80, 80, 255, 1.0)","rgba(0, 192, 0, 1.0)","rgba(80, 80, 255, 1.0)","white"],["rgba(230, 230, 0, 1.0)","rgba(230, 230, 0, 1.0)","rgba(80, 80, 255, 1.0)","rgba(230, 230, 0, 1.0)","white"],["rgba(224, 0, 0, 1.0)","rgba(80, 80, 255, 1.0)","rgba(224, 0, 0, 1.0)","rgba(80, 80, 255, 1.0)","white"],["rgba(0, 192, 0, 1.0)","rgba(0, 192, 0, 1.0)","rgba(0, 192, 0, 1.0)","rgba(0, 192, 0, 1.0)","white"],["rgba(80, 80, 255, 1.0)","rgba(80, 80, 255, 1.0)","rgba(230, 230, 0, 1.0)","rgba(80, 80, 255, 1.0)","white"],["rgba(230, 230, 0, 1.0)","rgba(224, 0, 0, 1.0)","rgba(224, 0, 0, 1.0)","rgba(224, 0, 0, 1.0)","white"],["rgba(80, 80, 255, 1.0)","rgba(224, 0, 0, 1.0)","rgba(0, 192, 0, 1.0)","rgba(0, 192, 0, 1.0)","white"],["rgba(0, 192, 0, 1.0)","rgba(0, 192, 0, 1.0)","rgba(80, 80, 255, 1.0)","rgba(230, 230, 0, 1.0)","white"],["rgba(80, 80, 255, 1.0)","rgba(230, 230, 0, 1.0)","rgba(230, 230, 0, 1.0)","rgba(224, 0, 0, 1.0)","white"],["rgba(224, 0, 0, 1.0)","rgba(0, 192, 0, 1.0)","rgba(80, 80, 255, 1.0)","rgba(0, 192, 0, 1.0)","white"],["rgba(0, 192, 0, 1.0)","rgba(80, 80, 255, 1.0)","rgba(0, 192, 0, 1.0)","rgba(80, 80, 255, 1.0)","white"],["rgba(230, 230, 0, 1.0)","rgba(230, 230, 0, 1.0)","rgba(80, 80, 255, 1.0)","rgba(230, 230, 0, 1.0)","white"],["rgba(224, 0, 0, 1.0)","rgba(80, 80, 255, 1.0)","rgba(224, 0, 0, 1.0)","rgba(80, 80, 255, 1.0)","white"],["rgba(0, 192, 0, 1.0)","rgba(0, 192, 0, 1.0)","rgba(224, 0, 0, 1.0)","rgba(0, 192, 0, 1.0)","white"],["rgba(80, 80, 255, 1.0)","rgba(80, 80, 255, 1.0)","rgba(0, 192, 0, 1.0)","rgba(80, 80, 255, 1.0)","white"],["rgba(230, 230, 0, 1.0)","rgba(224, 0, 0, 1.0)","rgba(230, 230, 0, 1.0)","rgba(224, 0, 0, 1.0)","white"],["rgba(80, 80, 255, 1.0)","rgba(0, 192, 0, 1.0)","rgba(80, 80, 255, 1.0)","rgba(224, 0, 0, 1.0)","white"],["rgba(0, 192, 0, 1.0)","rgba(230, 230, 0, 1.0)","rgba(230, 230, 0, 1.0)","rgba(0, 192, 0, 1.0)","white"],["rgba(80, 80, 255, 1.0)","rgba(224, 0, 0, 1.0)","rgba(80, 80, 255, 1.0)","rgba(230, 230, 0, 1.0)","white"],["rgba(224, 0, 0, 1.0)","rgba(0, 192, 0, 1.0)","rgba(0, 192, 0, 1.0)","white"],["rgba(224, 0, 0, 1.0)","rgba(80, 80, 255, 1.0)","rgba(80, 80, 255, 1.0)","white"],["rgba(0, 192, 0, 1.0)","rgba(0, 192, 0, 1.0)","rgba(80, 80, 255, 1.0)","white"],["rgba(80, 80, 255, 1.0)","rgba(80, 80, 255, 1.0)","rgba(0, 192, 0, 1.0)","white"],["rgba(230, 230, 0, 1.0)","rgba(80, 80, 255, 1.0)","rgba(80, 80, 255, 1.0)","white"],["rgba(80, 80, 255, 1.0)","rgba(0, 192, 0, 1.0)","rgba(224, 0, 0, 1.0)","white"],["rgba(0, 192, 0, 1.0)","rgba(80, 80, 255, 1.0)","rgba(0, 192, 0, 1.0)","white"],["rgba(80, 80, 255, 1.0)","rgba(224, 0, 0, 1.0)","rgba(230, 230, 0, 1.0)","white"],["rgba(224, 0, 0, 1.0)","rgba(0, 192, 0, 1.0)","rgba(224, 0, 0, 1.0)","white"],["rgba(230, 230, 0, 1.0)","rgba(230, 230, 0, 1.0)","rgba(0, 192, 0, 1.0)","white"],["rgba(224, 0, 0, 1.0)","rgba(224, 0, 0, 1.0)","rgba(80, 80, 255, 1.0)","white"],["rgba(0, 192, 0, 1.0)","rgba(0, 192, 0, 1.0)","rgba(230, 230, 0, 1.0)","white"],["rgba(230, 230, 0, 1.0)","rgba(80, 80, 255, 1.0)","rgba(80, 80, 255, 1.0)","white"],["rgba(0, 192, 0, 1.0)","rgba(230, 230, 0, 1.0)","rgba(0, 192, 0, 1.0)","white"],["rgba(80, 80, 255, 1.0)","rgba(80, 80, 255, 1.0)","rgba(80, 80, 255, 1.0)","white"],["rgba(230, 230, 0, 1.0)","rgba(0, 192, 0, 1.0)","rgba(230, 230, 0, 1.0)","white"],["rgba(80, 80, 255, 1.0)","rgba(80, 80, 255, 1.0)","rgba(80, 80, 255, 1.0)","white"],["rgba(0, 192, 0, 1.0)","rgba(224, 0, 0, 1.0)","rgba(0, 192, 0, 1.0)","white"]]},"line":{"color":"white","width":0.0},"font":{"family":"Consolas","size":14.0}},"columnwidth":[50,10]}];
            var layout = {"width":650,"height":-2147483648,"template":{"layout":{"title":{"x":0.05},"font":{"color":"rgba(42, 63, 95, 1.0)"},"paper_bgcolor":"rgba(255, 255, 255, 1.0)","plot_bgcolor":"rgba(229, 236, 246, 1.0)","autotypenumbers":"strict","colorscale":{"diverging":[[0.0,"#8e0152"],[0.1,"#c51b7d"],[0.2,"#de77ae"],[0.3,"#f1b6da"],[0.4,"#fde0ef"],[0.5,"#f7f7f7"],[0.6,"#e6f5d0"],[0.7,"#b8e186"],[0.8,"#7fbc41"],[0.9,"#4d9221"],[1.0,"#276419"]],"sequential":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]],"sequentialminus":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]},"hovermode":"closest","hoverlabel":{"align":"left"},"coloraxis":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}},"geo":{"showland":true,"landcolor":"rgba(229, 236, 246, 1.0)","showlakes":true,"lakecolor":"rgba(255, 255, 255, 1.0)","subunitcolor":"rgba(255, 255, 255, 1.0)","bgcolor":"rgba(255, 255, 255, 1.0)"},"mapbox":{"style":"light"},"polar":{"bgcolor":"rgba(229, 236, 246, 1.0)","radialaxis":{"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","ticks":""},"angularaxis":{"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","ticks":""}},"scene":{"xaxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","gridwidth":2.0,"zerolinecolor":"rgba(255, 255, 255, 1.0)","backgroundcolor":"rgba(229, 236, 246, 1.0)","showbackground":true},"yaxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","gridwidth":2.0,"zerolinecolor":"rgba(255, 255, 255, 1.0)","backgroundcolor":"rgba(229, 236, 246, 1.0)","showbackground":true},"zaxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","gridwidth":2.0,"zerolinecolor":"rgba(255, 255, 255, 1.0)","backgroundcolor":"rgba(229, 236, 246, 1.0)","showbackground":true}},"ternary":{"aaxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)"},"baxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)"},"caxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)"},"bgcolor":"rgba(229, 236, 246, 1.0)"},"xaxis":{"title":{"standoff":15},"ticks":"","automargin":true,"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","zerolinecolor":"rgba(255, 255, 255, 1.0)","zerolinewidth":2.0},"yaxis":{"title":{"standoff":15},"ticks":"","automargin":true,"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","zerolinecolor":"rgba(255, 255, 255, 1.0)","zerolinewidth":2.0},"annotationdefaults":{"arrowcolor":"#2a3f5f","arrowhead":0,"arrowwidth":1},"shapedefaults":{"line":{"color":"rgba(42, 63, 95, 1.0)"}},"colorway":["rgba(99, 110, 250, 1.0)","rgba(239, 85, 59, 1.0)","rgba(0, 204, 150, 1.0)","rgba(171, 99, 250, 1.0)","rgba(255, 161, 90, 1.0)","rgba(25, 211, 243, 1.0)","rgba(255, 102, 146, 1.0)","rgba(182, 232, 128, 1.0)","rgba(255, 151, 255, 1.0)","rgba(254, 203, 82, 1.0)"]},"data":{"bar":[{"marker":{"line":{"color":"rgba(229, 236, 246, 1.0)","width":0.5},"pattern":{"fillmode":"overlay","size":10,"solidity":0.2}},"errorx":{"color":"rgba(42, 63, 95, 1.0)"},"errory":{"color":"rgba(42, 63, 95, 1.0)"}}],"barpolar":[{"marker":{"line":{"color":"rgba(229, 236, 246, 1.0)","width":0.5},"pattern":{"fillmode":"overlay","size":10,"solidity":0.2}}}],"carpet":[{"aaxis":{"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","endlinecolor":"rgba(42, 63, 95, 1.0)","minorgridcolor":"rgba(255, 255, 255, 1.0)","startlinecolor":"rgba(42, 63, 95, 1.0)"},"baxis":{"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","endlinecolor":"rgba(42, 63, 95, 1.0)","minorgridcolor":"rgba(255, 255, 255, 1.0)","startlinecolor":"rgba(42, 63, 95, 1.0)"}}],"choropleth":[{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}],"contour":[{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"contourcarpet":[{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}],"heatmap":[{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"heatmapgl":[{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"histogram":[{"marker":{"pattern":{"fillmode":"overlay","size":10,"solidity":0.2}}}],"histogram2d":[{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"histogram2dcontour":[{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"mesh3d":[{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}],"parcoords":[{"line":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"pie":[{"automargin":true}],"scatter":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"scatter3d":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}},"line":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"scattercarpet":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"scattergeo":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"scattergl":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"scattermapbox":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"scatterpolar":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"scatterpolargl":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"scatterternary":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"surface":[{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}]}},"title":{"text":"Sequence A"}};
            var config = {"responsive":true};
            Plotly.newPlot('159dbde1-dcd0-4035-b78f-b3d11a5a73eb', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_159dbde1dcd04035b78fb3d11a5a73eb();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_159dbde1dcd04035b78fb3d11a5a73eb();
            }
</script>
*)

