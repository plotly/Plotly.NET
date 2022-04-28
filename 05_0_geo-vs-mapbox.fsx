(**
# Mapbox Maps vs Geo Maps

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=05_0_geo-vs-mapbox.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/05_0_geo-vs-mapbox.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/05_0_geo-vs-mapbox.ipynb)

**Summary:** This introduction shows the differences between Geo and Mapbox based geographical charts.

Plotly and therefore Plotly.NET supports two different kinds of maps:

* **Mapbox maps** are tile-based maps. If your figure is created with a `Chart.*Mapbox` function or otherwise contains one or more traces of type `scattermapbox`,
`choroplethmapbox` or `densitymapbox`, the layout.mapbox object in your figure contains configuration information for the map itself.
  

* **Geo maps** are outline-based maps. If your figure is created with a `Chart.ScatterGeo,`Chart.PointGeo`,`Chart.LineGeo`or`Chart.Choropleth`function or
otherwise contains one or more traces of type`scattergeo`or`choropleth`, the layout.geo object in your figure contains configuration information for the map itself.
  

**This page documents Geo outline-based maps, and the [Mapbox Layers documentation]()(https://plotly.net//06**0**geo-vs-mapbox.html) describes how to configure Mapbox tile-based maps.**

## Physical Base Maps

Plotly Geo maps have a built-in base map layer composed of "physical" and "cultural" (i.e. administrative border) data from the Natural Earth Dataset.
Various lines and area fills can be shown or hidden, and their color and line-widths specified.
In the default plotly template, a map frame and physical features such as a coastal outline and filled land areas are shown, at a small-scale 1:110m resolution:

*)
open Plotly.NET

let baseMapOnly = 
    Chart.PointGeo(locations = []) // deliberately empty chart to show the base map only
    |> Chart.withMarginSize(0,0,0,0)(* output: 
<div id="675837b4-e262-48c5-86b3-26a112a10536"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_675837b4e26248c586b326a112a10536 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.6.3.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scattergeo","mode":"markers","locations":[],"marker":{},"line":{}}];
            var layout = {"width":600,"height":600,"template":{"layout":{"title":{"x":0.05},"font":{"color":"rgba(42, 63, 95, 1.0)"},"paper_bgcolor":"rgba(255, 255, 255, 1.0)","plot_bgcolor":"rgba(229, 236, 246, 1.0)","autotypenumbers":"strict","colorscale":{"diverging":[[0.0,"#8e0152"],[0.1,"#c51b7d"],[0.2,"#de77ae"],[0.3,"#f1b6da"],[0.4,"#fde0ef"],[0.5,"#f7f7f7"],[0.6,"#e6f5d0"],[0.7,"#b8e186"],[0.8,"#7fbc41"],[0.9,"#4d9221"],[1.0,"#276419"]],"sequential":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]],"sequentialminus":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]},"hovermode":"closest","hoverlabel":{"align":"left"},"coloraxis":{"colorbar":{"outlinewidth":0.0,"ticks":""}},"geo":{"showland":true,"landcolor":"rgba(229, 236, 246, 1.0)","showlakes":true,"lakecolor":"rgba(255, 255, 255, 1.0)","subunitcolor":"rgba(255, 255, 255, 1.0)","bgcolor":"rgba(255, 255, 255, 1.0)"},"mapbox":{"style":"light"},"polar":{"bgcolor":"rgba(229, 236, 246, 1.0)","radialaxis":{"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","ticks":""},"angularaxis":{"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","ticks":""}},"scene":{"xaxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","gridwidth":2.0,"zerolinecolor":"rgba(255, 255, 255, 1.0)","backgroundcolor":"rgba(229, 236, 246, 1.0)","showbackground":true},"yaxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","gridwidth":2.0,"zerolinecolor":"rgba(255, 255, 255, 1.0)","backgroundcolor":"rgba(229, 236, 246, 1.0)","showbackground":true},"zaxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","gridwidth":2.0,"zerolinecolor":"rgba(255, 255, 255, 1.0)","backgroundcolor":"rgba(229, 236, 246, 1.0)","showbackground":true}},"ternary":{"aaxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)"},"baxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)"},"caxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)"},"bgcolor":"rgba(229, 236, 246, 1.0)"},"xaxis":{"title":{"standoff":15},"ticks":"","automargin":true,"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","zerolinecolor":"rgba(255, 255, 255, 1.0)","zerolinewidth":2.0},"yaxis":{"title":{"standoff":15},"ticks":"","automargin":true,"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","zerolinecolor":"rgba(255, 255, 255, 1.0)","zerolinewidth":2.0},"annotationdefaults":{"arrowcolor":"#2a3f5f","arrowhead":0,"arrowwidth":1},"shapedefaults":{"line":{"color":"rgba(42, 63, 95, 1.0)"}},"colorway":["rgba(99, 110, 250, 1.0)","rgba(239, 85, 59, 1.0)","rgba(0, 204, 150, 1.0)","rgba(171, 99, 250, 1.0)","rgba(255, 161, 90, 1.0)","rgba(25, 211, 243, 1.0)","rgba(255, 102, 146, 1.0)","rgba(182, 232, 128, 1.0)","rgba(255, 151, 255, 1.0)","rgba(254, 203, 82, 1.0)"]},"data":{"bar":[{"marker":{"line":{"color":"rgba(229, 236, 246, 1.0)","width":0.5},"pattern":{"fillmode":"overlay","size":10,"solidity":0.2}},"error_x":{"color":"rgba(42, 63, 95, 1.0)"},"error_y":{"color":"rgba(42, 63, 95, 1.0)"}}],"barpolar":[{"marker":{"line":{"color":"rgba(229, 236, 246, 1.0)","width":0.5},"pattern":{"fillmode":"overlay","size":10,"solidity":0.2}}}],"carpet":[{"aaxis":{"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","endlinecolor":"rgba(42, 63, 95, 1.0)","minorgridcolor":"rgba(255, 255, 255, 1.0)","startlinecolor":"rgba(42, 63, 95, 1.0)"},"baxis":{"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","endlinecolor":"rgba(42, 63, 95, 1.0)","minorgridcolor":"rgba(255, 255, 255, 1.0)","startlinecolor":"rgba(42, 63, 95, 1.0)"}}],"choropleth":[{"colorbar":{"outlinewidth":0.0,"ticks":""},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"contour":[{"colorbar":{"outlinewidth":0.0,"ticks":""},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"contourcarpet":[{"colorbar":{"outlinewidth":0.0,"ticks":""}}],"heatmap":[{"colorbar":{"outlinewidth":0.0,"ticks":""},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"heatmapgl":[{"colorbar":{"outlinewidth":0.0,"ticks":""},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"histogram":[{"marker":{"pattern":{"fillmode":"overlay","size":10,"solidity":0.2}}}],"histogram2d":[{"colorbar":{"outlinewidth":0.0,"ticks":""},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"histogram2dcontour":[{"colorbar":{"outlinewidth":0.0,"ticks":""},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"mesh3d":[{"colorbar":{"outlinewidth":0.0,"ticks":""}}],"parcoords":[{"line":{"colorbar":{"outlinewidth":0.0,"ticks":""}}}],"pie":[{"automargin":true}],"scatter":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":""}}}],"scatter3d":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":""}},"line":{"colorbar":{"outlinewidth":0.0,"ticks":""}}}],"scattercarpet":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":""}}}],"scattergeo":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":""}}}],"scattergl":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":""}}}],"scattermapbox":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":""}}}],"scatterpolar":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":""}}}],"scatterpolargl":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":""}}}],"scatterternary":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":""}}}],"surface":[{"colorbar":{"outlinewidth":0.0,"ticks":""},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"table":[{"cells":{"fill":{"color":"rgba(235, 240, 248, 1.0)"},"line":{"color":"rgba(255, 255, 255, 1.0)"}},"header":{"fill":{"color":"rgba(200, 212, 227, 1.0)"},"line":{"color":"rgba(255, 255, 255, 1.0)"}}}]}},"margin":{"l":0,"r":0,"t":0,"b":0}};
            var config = {"responsive":true};
            Plotly.newPlot('675837b4-e262-48c5-86b3-26a112a10536', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_675837b4e26248c586b326a112a10536();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_675837b4e26248c586b326a112a10536();
            }
</script>
*)
(**
To control the features of the map, a `Geo` object is used that can be associtaed with a given chart using the `Chart.WithGeo` function.
Here is a map with all physical features enabled and styled, at a larger-scale 1:50m resolution:

*)
open Plotly.NET.LayoutObjects

let myGeo =
    Geo.init(
        Resolution=StyleParam.GeoResolution.R50,
        ShowCoastLines=true, 
        CoastLineColor=Color.fromString "RebeccaPurple",
        ShowLand=true, 
        LandColor=Color.fromString "LightGreen",
        ShowOcean=true, 
        OceanColor=Color.fromString "LightBlue",
        ShowLakes=true, 
        LakeColor=Color.fromString "Blue",
        ShowRivers=true, 
        RiverColor=Color.fromString "Blue"
    )

let moreFeaturesBaseMap =
    Chart.PointGeo(locations = [])
    |> Chart.withGeo myGeo
    |> Chart.withMarginSize(0,0,0,0)(* output: 
<div id="80c80857-3a38-446c-9343-4b480a496da8"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_80c808573a38446c93434b480a496da8 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.6.3.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scattergeo","mode":"markers","locations":[],"marker":{},"line":{}}];
            var layout = {"width":600,"height":600,"template":{"layout":{"title":{"x":0.05},"font":{"color":"rgba(42, 63, 95, 1.0)"},"paper_bgcolor":"rgba(255, 255, 255, 1.0)","plot_bgcolor":"rgba(229, 236, 246, 1.0)","autotypenumbers":"strict","colorscale":{"diverging":[[0.0,"#8e0152"],[0.1,"#c51b7d"],[0.2,"#de77ae"],[0.3,"#f1b6da"],[0.4,"#fde0ef"],[0.5,"#f7f7f7"],[0.6,"#e6f5d0"],[0.7,"#b8e186"],[0.8,"#7fbc41"],[0.9,"#4d9221"],[1.0,"#276419"]],"sequential":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]],"sequentialminus":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]},"hovermode":"closest","hoverlabel":{"align":"left"},"coloraxis":{"colorbar":{"outlinewidth":0.0,"ticks":""}},"geo":{"showland":true,"landcolor":"rgba(229, 236, 246, 1.0)","showlakes":true,"lakecolor":"rgba(255, 255, 255, 1.0)","subunitcolor":"rgba(255, 255, 255, 1.0)","bgcolor":"rgba(255, 255, 255, 1.0)"},"mapbox":{"style":"light"},"polar":{"bgcolor":"rgba(229, 236, 246, 1.0)","radialaxis":{"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","ticks":""},"angularaxis":{"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","ticks":""}},"scene":{"xaxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","gridwidth":2.0,"zerolinecolor":"rgba(255, 255, 255, 1.0)","backgroundcolor":"rgba(229, 236, 246, 1.0)","showbackground":true},"yaxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","gridwidth":2.0,"zerolinecolor":"rgba(255, 255, 255, 1.0)","backgroundcolor":"rgba(229, 236, 246, 1.0)","showbackground":true},"zaxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","gridwidth":2.0,"zerolinecolor":"rgba(255, 255, 255, 1.0)","backgroundcolor":"rgba(229, 236, 246, 1.0)","showbackground":true}},"ternary":{"aaxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)"},"baxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)"},"caxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)"},"bgcolor":"rgba(229, 236, 246, 1.0)"},"xaxis":{"title":{"standoff":15},"ticks":"","automargin":true,"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","zerolinecolor":"rgba(255, 255, 255, 1.0)","zerolinewidth":2.0},"yaxis":{"title":{"standoff":15},"ticks":"","automargin":true,"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","zerolinecolor":"rgba(255, 255, 255, 1.0)","zerolinewidth":2.0},"annotationdefaults":{"arrowcolor":"#2a3f5f","arrowhead":0,"arrowwidth":1},"shapedefaults":{"line":{"color":"rgba(42, 63, 95, 1.0)"}},"colorway":["rgba(99, 110, 250, 1.0)","rgba(239, 85, 59, 1.0)","rgba(0, 204, 150, 1.0)","rgba(171, 99, 250, 1.0)","rgba(255, 161, 90, 1.0)","rgba(25, 211, 243, 1.0)","rgba(255, 102, 146, 1.0)","rgba(182, 232, 128, 1.0)","rgba(255, 151, 255, 1.0)","rgba(254, 203, 82, 1.0)"]},"data":{"bar":[{"marker":{"line":{"color":"rgba(229, 236, 246, 1.0)","width":0.5},"pattern":{"fillmode":"overlay","size":10,"solidity":0.2}},"error_x":{"color":"rgba(42, 63, 95, 1.0)"},"error_y":{"color":"rgba(42, 63, 95, 1.0)"}}],"barpolar":[{"marker":{"line":{"color":"rgba(229, 236, 246, 1.0)","width":0.5},"pattern":{"fillmode":"overlay","size":10,"solidity":0.2}}}],"carpet":[{"aaxis":{"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","endlinecolor":"rgba(42, 63, 95, 1.0)","minorgridcolor":"rgba(255, 255, 255, 1.0)","startlinecolor":"rgba(42, 63, 95, 1.0)"},"baxis":{"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","endlinecolor":"rgba(42, 63, 95, 1.0)","minorgridcolor":"rgba(255, 255, 255, 1.0)","startlinecolor":"rgba(42, 63, 95, 1.0)"}}],"choropleth":[{"colorbar":{"outlinewidth":0.0,"ticks":""},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"contour":[{"colorbar":{"outlinewidth":0.0,"ticks":""},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"contourcarpet":[{"colorbar":{"outlinewidth":0.0,"ticks":""}}],"heatmap":[{"colorbar":{"outlinewidth":0.0,"ticks":""},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"heatmapgl":[{"colorbar":{"outlinewidth":0.0,"ticks":""},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"histogram":[{"marker":{"pattern":{"fillmode":"overlay","size":10,"solidity":0.2}}}],"histogram2d":[{"colorbar":{"outlinewidth":0.0,"ticks":""},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"histogram2dcontour":[{"colorbar":{"outlinewidth":0.0,"ticks":""},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"mesh3d":[{"colorbar":{"outlinewidth":0.0,"ticks":""}}],"parcoords":[{"line":{"colorbar":{"outlinewidth":0.0,"ticks":""}}}],"pie":[{"automargin":true}],"scatter":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":""}}}],"scatter3d":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":""}},"line":{"colorbar":{"outlinewidth":0.0,"ticks":""}}}],"scattercarpet":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":""}}}],"scattergeo":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":""}}}],"scattergl":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":""}}}],"scattermapbox":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":""}}}],"scatterpolar":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":""}}}],"scatterpolargl":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":""}}}],"scatterternary":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":""}}}],"surface":[{"colorbar":{"outlinewidth":0.0,"ticks":""},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"table":[{"cells":{"fill":{"color":"rgba(235, 240, 248, 1.0)"},"line":{"color":"rgba(255, 255, 255, 1.0)"}},"header":{"fill":{"color":"rgba(200, 212, 227, 1.0)"},"line":{"color":"rgba(255, 255, 255, 1.0)"}}}]}},"geo":{"resolution":"50","showcoastline":true,"coastlinecolor":"RebeccaPurple","showland":true,"landcolor":"LightGreen","showocean":true,"oceancolor":"LightBlue","showlakes":true,"lakecolor":"Blue","showrivers":true,"rivercolor":"Blue"},"margin":{"l":0,"r":0,"t":0,"b":0}};
            var config = {"responsive":true};
            Plotly.newPlot('80c80857-3a38-446c-9343-4b480a496da8', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_80c808573a38446c93434b480a496da8();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_80c808573a38446c93434b480a496da8();
            }
</script>
*)
(**
## Cultural Base Maps

In addition to physical base map features, a "cultural" base map is included which is composed of country borders and selected sub-country borders such as states.

**Note and disclaimer: cultural features are by definition subject to change, debate and dispute. Plotly includes data from Natural Earth "as-is" and defers to the Natural Earth policy regarding disputed borders which read:**

> Natural Earth Vector draws boundaries of countries according to defacto status. We show who actually controls the situation on the ground.
> 

Here is a map with only cultural features enabled and styled, at a 1:50m resolution, which includes only country boundaries. See below for country sub-unit cultural base map features:

*)
let countryGeo =
    Geo.init(
        Visible=false, 
        Resolution=StyleParam.GeoResolution.R50,
        ShowCountries=true, 
        CountryColor=Color.fromString "RebeccaPurple"
    )


let countryBaseMap =
    Chart.PointGeo(locations = [])
    |> Chart.withGeo countryGeo
    |> Chart.withMarginSize(0,0,0,0)(* output: 
<div id="08a744ab-8018-472e-a5de-5948ce4b469e"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_08a744ab8018472ea5de5948ce4b469e = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.6.3.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scattergeo","mode":"markers","locations":[],"marker":{},"line":{}}];
            var layout = {"width":600,"height":600,"template":{"layout":{"title":{"x":0.05},"font":{"color":"rgba(42, 63, 95, 1.0)"},"paper_bgcolor":"rgba(255, 255, 255, 1.0)","plot_bgcolor":"rgba(229, 236, 246, 1.0)","autotypenumbers":"strict","colorscale":{"diverging":[[0.0,"#8e0152"],[0.1,"#c51b7d"],[0.2,"#de77ae"],[0.3,"#f1b6da"],[0.4,"#fde0ef"],[0.5,"#f7f7f7"],[0.6,"#e6f5d0"],[0.7,"#b8e186"],[0.8,"#7fbc41"],[0.9,"#4d9221"],[1.0,"#276419"]],"sequential":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]],"sequentialminus":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]},"hovermode":"closest","hoverlabel":{"align":"left"},"coloraxis":{"colorbar":{"outlinewidth":0.0,"ticks":""}},"geo":{"showland":true,"landcolor":"rgba(229, 236, 246, 1.0)","showlakes":true,"lakecolor":"rgba(255, 255, 255, 1.0)","subunitcolor":"rgba(255, 255, 255, 1.0)","bgcolor":"rgba(255, 255, 255, 1.0)"},"mapbox":{"style":"light"},"polar":{"bgcolor":"rgba(229, 236, 246, 1.0)","radialaxis":{"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","ticks":""},"angularaxis":{"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","ticks":""}},"scene":{"xaxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","gridwidth":2.0,"zerolinecolor":"rgba(255, 255, 255, 1.0)","backgroundcolor":"rgba(229, 236, 246, 1.0)","showbackground":true},"yaxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","gridwidth":2.0,"zerolinecolor":"rgba(255, 255, 255, 1.0)","backgroundcolor":"rgba(229, 236, 246, 1.0)","showbackground":true},"zaxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","gridwidth":2.0,"zerolinecolor":"rgba(255, 255, 255, 1.0)","backgroundcolor":"rgba(229, 236, 246, 1.0)","showbackground":true}},"ternary":{"aaxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)"},"baxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)"},"caxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)"},"bgcolor":"rgba(229, 236, 246, 1.0)"},"xaxis":{"title":{"standoff":15},"ticks":"","automargin":true,"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","zerolinecolor":"rgba(255, 255, 255, 1.0)","zerolinewidth":2.0},"yaxis":{"title":{"standoff":15},"ticks":"","automargin":true,"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","zerolinecolor":"rgba(255, 255, 255, 1.0)","zerolinewidth":2.0},"annotationdefaults":{"arrowcolor":"#2a3f5f","arrowhead":0,"arrowwidth":1},"shapedefaults":{"line":{"color":"rgba(42, 63, 95, 1.0)"}},"colorway":["rgba(99, 110, 250, 1.0)","rgba(239, 85, 59, 1.0)","rgba(0, 204, 150, 1.0)","rgba(171, 99, 250, 1.0)","rgba(255, 161, 90, 1.0)","rgba(25, 211, 243, 1.0)","rgba(255, 102, 146, 1.0)","rgba(182, 232, 128, 1.0)","rgba(255, 151, 255, 1.0)","rgba(254, 203, 82, 1.0)"]},"data":{"bar":[{"marker":{"line":{"color":"rgba(229, 236, 246, 1.0)","width":0.5},"pattern":{"fillmode":"overlay","size":10,"solidity":0.2}},"error_x":{"color":"rgba(42, 63, 95, 1.0)"},"error_y":{"color":"rgba(42, 63, 95, 1.0)"}}],"barpolar":[{"marker":{"line":{"color":"rgba(229, 236, 246, 1.0)","width":0.5},"pattern":{"fillmode":"overlay","size":10,"solidity":0.2}}}],"carpet":[{"aaxis":{"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","endlinecolor":"rgba(42, 63, 95, 1.0)","minorgridcolor":"rgba(255, 255, 255, 1.0)","startlinecolor":"rgba(42, 63, 95, 1.0)"},"baxis":{"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","endlinecolor":"rgba(42, 63, 95, 1.0)","minorgridcolor":"rgba(255, 255, 255, 1.0)","startlinecolor":"rgba(42, 63, 95, 1.0)"}}],"choropleth":[{"colorbar":{"outlinewidth":0.0,"ticks":""},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"contour":[{"colorbar":{"outlinewidth":0.0,"ticks":""},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"contourcarpet":[{"colorbar":{"outlinewidth":0.0,"ticks":""}}],"heatmap":[{"colorbar":{"outlinewidth":0.0,"ticks":""},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"heatmapgl":[{"colorbar":{"outlinewidth":0.0,"ticks":""},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"histogram":[{"marker":{"pattern":{"fillmode":"overlay","size":10,"solidity":0.2}}}],"histogram2d":[{"colorbar":{"outlinewidth":0.0,"ticks":""},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"histogram2dcontour":[{"colorbar":{"outlinewidth":0.0,"ticks":""},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"mesh3d":[{"colorbar":{"outlinewidth":0.0,"ticks":""}}],"parcoords":[{"line":{"colorbar":{"outlinewidth":0.0,"ticks":""}}}],"pie":[{"automargin":true}],"scatter":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":""}}}],"scatter3d":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":""}},"line":{"colorbar":{"outlinewidth":0.0,"ticks":""}}}],"scattercarpet":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":""}}}],"scattergeo":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":""}}}],"scattergl":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":""}}}],"scattermapbox":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":""}}}],"scatterpolar":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":""}}}],"scatterpolargl":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":""}}}],"scatterternary":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":""}}}],"surface":[{"colorbar":{"outlinewidth":0.0,"ticks":""},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"table":[{"cells":{"fill":{"color":"rgba(235, 240, 248, 1.0)"},"line":{"color":"rgba(255, 255, 255, 1.0)"}},"header":{"fill":{"color":"rgba(200, 212, 227, 1.0)"},"line":{"color":"rgba(255, 255, 255, 1.0)"}}}]}},"geo":{"resolution":"50","visible":false,"showcountries":true,"countrycolor":"RebeccaPurple"},"margin":{"l":0,"r":0,"t":0,"b":0}};
            var config = {"responsive":true};
            Plotly.newPlot('08a744ab-8018-472e-a5de-5948ce4b469e', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_08a744ab8018472ea5de5948ce4b469e();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_08a744ab8018472ea5de5948ce4b469e();
            }
</script>
*)

