(**
// can't yet format YamlFrontmatter (["title: 3D Mesh plots"; "category: 3D Charts"; "categoryindex: 4"; "index: 3"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# 3D Mesh plots

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=03_2_3d-mesh-plots.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/03_2_3d-mesh-plots.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/03_2_3d-mesh-plots.ipynb)

*Summary:* This example shows how to create 3D-Mesh charts in F#.

let's first create some data for the purpose of creating example charts:

*)
open System
open Plotly.NET 


//---------------------- Generate linearly spaced vector ----------------------
let linspace (min,max,n) = 
    if n <= 2 then failwithf "n needs to be larger then 2"
    let bw = float (max - min) / (float n - 1.)
    Array.init n (fun i -> min + (bw * float i))
    //[|min ..bw ..max|]

//---------------------- Create example data ----------------------
let size = 100
let x = linspace(-2. * Math.PI, 2. * Math.PI, size)
let y = linspace(-2. * Math.PI, 2. * Math.PI, size)

let f x y = - (5. * x / (x**2. + y**2. + 1.) )

let z = 
    Array.init size (fun i -> 
        Array.init size (fun j -> 
            f x.[j] y.[i] 
        )
    )

let rnd = System.Random()
let a = Array.init 50 (fun _ -> rnd.NextDouble())
let b = Array.init 50 (fun _ -> rnd.NextDouble())
let c = Array.init 50 (fun _ -> rnd.NextDouble())

open Plotly.NET.TraceObjects

let mesh3d =
    Trace3D.initMesh3d 
        (fun mesh3d ->
            mesh3d?x <- a
            mesh3d?y <- b
            mesh3d?z <- c
            mesh3d?flatshading <- true
            mesh3d?contour <- Contours.initXyz(Show=true)
            mesh3d
            )
    |> GenericChart.ofTraceObject true
    (* output: 
<div id="f6429d6d-958e-4bd5-b111-545878d4071c"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_f6429d6d958e4bd5b111545878d4071c = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"mesh3d","x":[0.6746785979220501,0.5290231897568097,0.09134588704488633,0.5784493904687975,0.9780025222135933,0.724574840524382,0.41540676399020393,0.6532117433825734,0.7317411759160111,0.8690273146515503,0.060690089521456825,0.6158932382376233,0.25404379827405,0.12285903723902858,0.19268477727761302,0.994570742834096,0.07773770673827107,0.3655933658603321,0.9034111503237758,0.8706071316225317,0.45930600349110207,0.7192774412112591,0.029440944617862397,0.4536346730241301,0.31835418917784297,0.1384178674092349,0.2629491710862475,0.9360922812850536,0.00047342045214426864,0.9994851933661139,0.7076696053664,0.23129217948612302,0.48504664094974315,0.9538238750614277,0.7204789358988936,0.6616757584776003,0.7881266122717498,0.580890989180537,0.9397821745528423,0.30049354754541346,0.5630048584193611,0.5246149750025247,0.37773655046529553,0.242924263638577,0.3559542925598379,0.13337279004852964,0.692971088799595,0.2899638047333698,0.5146038480071148,0.8994321318767744],"y":[0.7959305665717388,0.005318119697291013,0.9667056088405689,0.30086285431240156,0.6719030301872307,0.4787920667906257,0.4232905772908818,0.35673992802714827,0.3244609360490618,0.8990587769355315,0.004535482660366297,0.9081528320593781,0.2854430807375241,0.4520449704384467,0.9127016871354785,0.8793048265128429,0.23524122966039973,0.6327732746873205,0.9469009901983428,0.4464980261059578,0.7289194835994632,0.552193167507515,0.0994033810617575,0.13708585642839177,0.5737232034045281,0.9309676480366118,0.7565463246042493,0.3159642296735311,0.24524578800647856,0.1664784966462337,0.33328607638925767,0.8423534554890688,0.0989548303613933,0.6852309976756527,0.09862666629562478,0.07409328370525581,0.740612091458255,0.8198713800910413,0.7709664898617021,0.9688471309092115,0.5244288591793611,0.25009354405770534,0.4057755249970555,0.6076322736328685,0.15926838253728626,0.33839176483357414,0.519741424242953,0.11757207324964247,0.7493654665563796,0.6835535496387586],"z":[0.07064397343199391,0.4076187005769911,0.5663969572972211,0.22218327481986277,0.11766836506617051,0.08707310723554229,0.5129340935125979,0.8944727938014327,0.7357814152928751,0.3131562714369974,0.8007833073439856,0.6234524743258095,0.2681358510173538,0.24093110754709202,0.44864465696610956,0.23802421670308938,0.1741115918655195,0.5138183814602164,0.5597932072119333,0.8803391062112934,0.19089879931050868,0.11419301004224258,0.5967163146060337,0.40906040122155374,0.4734589793799492,0.8705758792407937,0.4876932379946157,0.046657462167488006,0.9506274713423636,0.875505608640602,0.889289006132313,0.3433040905774225,0.818299360021824,0.9148992508104921,0.5453094626790128,0.3718582684729367,0.8170926261286188,0.21102903884073299,0.45856921312507604,0.8535062479592241,0.4468238081089274,0.9441424424713853,0.04454464508340039,0.7236808067304251,0.9620657401547934,0.4658310965588094,0.9989839936508288,0.09535436196489722,0.2588596780293445,0.7206674829939267],"flatshading":true,"contour":{"x":{"show":true},"y":{"show":true},"z":{"show":true}}}];
            var layout = {"width":600,"height":600,"template":{"layout":{"title":{"x":0.05},"font":{"color":"rgba(42, 63, 95, 1.0)"},"paper_bgcolor":"rgba(255, 255, 255, 1.0)","plot_bgcolor":"rgba(229, 236, 246, 1.0)","autotypenumbers":"strict","colorscale":{"diverging":[[0.0,"#8e0152"],[0.1,"#c51b7d"],[0.2,"#de77ae"],[0.3,"#f1b6da"],[0.4,"#fde0ef"],[0.5,"#f7f7f7"],[0.6,"#e6f5d0"],[0.7,"#b8e186"],[0.8,"#7fbc41"],[0.9,"#4d9221"],[1.0,"#276419"]],"sequential":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]],"sequentialminus":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]},"hovermode":"closest","hoverlabel":{"align":"left"},"coloraxis":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}},"geo":{"showland":true,"landcolor":"rgba(229, 236, 246, 1.0)","showlakes":true,"lakecolor":"rgba(255, 255, 255, 1.0)","subunitcolor":"rgba(255, 255, 255, 1.0)","bgcolor":"rgba(255, 255, 255, 1.0)"},"mapbox":{"style":"light"},"polar":{"bgcolor":"rgba(229, 236, 246, 1.0)","radialaxis":{"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","ticks":""},"angularaxis":{"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","ticks":""}},"scene":{"xaxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","gridwidth":2.0,"zerolinecolor":"rgba(255, 255, 255, 1.0)","backgroundcolor":"rgba(229, 236, 246, 1.0)","showbackground":true},"yaxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","gridwidth":2.0,"zerolinecolor":"rgba(255, 255, 255, 1.0)","backgroundcolor":"rgba(229, 236, 246, 1.0)","showbackground":true},"zaxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","gridwidth":2.0,"zerolinecolor":"rgba(255, 255, 255, 1.0)","backgroundcolor":"rgba(229, 236, 246, 1.0)","showbackground":true}},"ternary":{"aaxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)"},"baxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)"},"caxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)"},"bgcolor":"rgba(229, 236, 246, 1.0)"},"xaxis":{"title":{"standoff":15},"ticks":"","automargin":true,"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","zerolinecolor":"rgba(255, 255, 255, 1.0)","zerolinewidth":2.0},"yaxis":{"title":{"standoff":15},"ticks":"","automargin":true,"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","zerolinecolor":"rgba(255, 255, 255, 1.0)","zerolinewidth":2.0},"annotationdefaults":{"arrowcolor":"#2a3f5f","arrowhead":0,"arrowwidth":1},"shapedefaults":{"line":{"color":"rgba(42, 63, 95, 1.0)"}},"colorway":["rgba(99, 110, 250, 1.0)","rgba(239, 85, 59, 1.0)","rgba(0, 204, 150, 1.0)","rgba(171, 99, 250, 1.0)","rgba(255, 161, 90, 1.0)","rgba(25, 211, 243, 1.0)","rgba(255, 102, 146, 1.0)","rgba(182, 232, 128, 1.0)","rgba(255, 151, 255, 1.0)","rgba(254, 203, 82, 1.0)"]},"data":{"bar":[{"marker":{"line":{"color":"rgba(229, 236, 246, 1.0)","width":0.5},"pattern":{"fillmode":"overlay","size":10,"solidity":0.2}},"errorx":{"color":"rgba(42, 63, 95, 1.0)"},"errory":{"color":"rgba(42, 63, 95, 1.0)"}}],"barpolar":[{"marker":{"line":{"color":"rgba(229, 236, 246, 1.0)","width":0.5},"pattern":{"fillmode":"overlay","size":10,"solidity":0.2}}}],"carpet":[{"aaxis":{"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","endlinecolor":"rgba(42, 63, 95, 1.0)","minorgridcolor":"rgba(255, 255, 255, 1.0)","startlinecolor":"rgba(42, 63, 95, 1.0)"},"baxis":{"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","endlinecolor":"rgba(42, 63, 95, 1.0)","minorgridcolor":"rgba(255, 255, 255, 1.0)","startlinecolor":"rgba(42, 63, 95, 1.0)"}}],"choropleth":[{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}],"contour":[{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"contourcarpet":[{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}],"heatmap":[{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"heatmapgl":[{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"histogram":[{"marker":{"pattern":{"fillmode":"overlay","size":10,"solidity":0.2}}}],"histogram2d":[{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"histogram2dcontour":[{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"mesh3d":[{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}],"parcoords":[{"line":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"pie":[{"automargin":true}],"scatter":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"scatter3d":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}},"line":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"scattercarpet":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"scattergeo":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"scattergl":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"scattermapbox":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"scatterpolar":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"scatterpolargl":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"scatterternary":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"surface":[{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}]}}};
            var config = {"responsive":true};
            Plotly.newPlot('f6429d6d-958e-4bd5-b111-545878d4071c', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_f6429d6d958e4bd5b111545878d4071c();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_f6429d6d958e4bd5b111545878d4071c();
            }
</script>
*)

