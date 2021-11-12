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
<div id="ccc637bd-479d-4e25-8d26-56e7f9c5429e"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_ccc637bd479d4e258d2656e7f9c5429e = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"mesh3d","x":[0.826394088951123,0.5078750753346248,0.6855246344048179,0.6270761232017894,0.03701794009516851,0.2628783310125015,0.2855335237856645,0.9001678823959864,0.05003919315060563,0.7843966497035681,0.7086362925863994,0.6220508481478555,0.8200278295297305,0.8862288440047897,0.0068048602001764165,0.02362796106544694,0.14443575271611836,0.047132527477635314,0.2535225023764756,0.7727639613546263,0.1381294197114787,0.5889553588763603,0.7909218970643924,0.987468935543424,0.7818936280821887,0.3122856935077746,0.3454810461706859,0.48513087513164194,0.42204675330875757,0.12758162064830847,0.13682232617252615,0.7115353335214477,0.39301898488449816,0.366983187090132,0.16752391269780878,0.028719895998351227,0.8875211276521539,0.969414803650889,0.5946741097581918,0.35244951087629867,0.4369374264203652,0.44075771953945875,0.4931995726624502,0.7475053569057516,0.36353553941638,0.7708881570822038,0.5055280618860982,0.43160236879792174,0.3849358430062122,0.10264584659721974],"y":[0.25111152057122044,0.8891217456614234,0.32610326322079786,0.1336092427995099,0.9447938557457151,0.2374387300747627,0.7169531782702325,0.698055698861394,0.8451824951196008,0.7247322465873939,0.9173972848418156,0.8004026486540226,0.47812112908722887,0.9224575725022971,0.647574323531042,0.9971009590649517,0.22903186326335737,0.4530446424395985,0.718704931306981,0.9780849642018252,0.13610683341329305,0.17502094906522936,0.4524584177194435,0.901072991500177,0.3358265349342611,0.69737170017202,0.09575578621391011,0.04341654015864085,0.6239333961270439,0.011005470999984756,0.8067576316216764,0.9138786773727642,0.10019503212542973,0.3194009067115378,0.876470100077088,0.24770058051110272,0.3854320703006499,0.2594097420849883,0.422189331344417,0.9300851826230461,0.31176671772811876,0.18946542879075995,0.12423230853128821,0.8699418631707979,0.43505222603448307,0.6365347777663426,0.9626365904522298,0.570742000160153,0.09993103337470956,0.3664345803514284],"z":[0.5418562938188465,0.05248341944649975,0.7128974374909408,0.40685087880438703,0.9665390131839267,0.07609057150599108,0.4366633279419799,0.4250302717206209,0.7977827078652487,0.24742215557369504,0.1416829438608526,0.6735366381115916,0.07412230273435,0.834177024119616,0.9179746149657176,0.003518607469051428,0.7002076165285929,0.15872022237569103,0.04598747242520911,0.3998737430199393,0.6116688887643017,0.9696221211783691,0.030855311095181533,0.7886197486839349,0.6663182464737064,0.9466414046225331,0.050788640533941165,0.5825165545486457,0.46602076546569393,0.6992917571679185,0.7347351097197901,0.525013786053757,0.9434855067839313,0.25749881577561556,0.4691491771811383,0.7542742121751765,0.20098123988182343,0.6933441533210427,0.3528618935276111,0.800379528571097,0.8110372525691228,0.9604017985800289,0.4616270342197395,0.17476717577072196,0.7884022387621935,0.6382300796165271,0.11534312605640996,0.29005528441167217,0.9519672482050803,0.4315336185654316],"flatshading":true,"contour":{"x":{"show":true},"y":{"show":true},"z":{"show":true}}}];
            var layout = {"width":600,"height":600,"template":{"layout":{"title":{"x":0.05},"font":{"color":"rgba(42, 63, 95, 1.0)"},"paper_bgcolor":"rgba(255, 255, 255, 1.0)","plot_bgcolor":"rgba(229, 236, 246, 1.0)","autotypenumbers":"strict","colorscale":{"diverging":[[0.0,"#8e0152"],[0.1,"#c51b7d"],[0.2,"#de77ae"],[0.3,"#f1b6da"],[0.4,"#fde0ef"],[0.5,"#f7f7f7"],[0.6,"#e6f5d0"],[0.7,"#b8e186"],[0.8,"#7fbc41"],[0.9,"#4d9221"],[1.0,"#276419"]],"sequential":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]],"sequentialminus":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]},"hovermode":"closest","hoverlabel":{"align":"left"},"coloraxis":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}},"geo":{"showland":true,"landcolor":"rgba(229, 236, 246, 1.0)","showlakes":true,"lakecolor":"rgba(255, 255, 255, 1.0)","subunitcolor":"rgba(255, 255, 255, 1.0)","bgcolor":"rgba(255, 255, 255, 1.0)"},"mapbox":{"style":"light"},"polar":{"bgcolor":"rgba(229, 236, 246, 1.0)","radialaxis":{"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","ticks":""},"angularaxis":{"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","ticks":""}},"scene":{"xaxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","gridwidth":2.0,"zerolinecolor":"rgba(255, 255, 255, 1.0)","backgroundcolor":"rgba(229, 236, 246, 1.0)","showbackground":true},"yaxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","gridwidth":2.0,"zerolinecolor":"rgba(255, 255, 255, 1.0)","backgroundcolor":"rgba(229, 236, 246, 1.0)","showbackground":true},"zaxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","gridwidth":2.0,"zerolinecolor":"rgba(255, 255, 255, 1.0)","backgroundcolor":"rgba(229, 236, 246, 1.0)","showbackground":true}},"ternary":{"aaxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)"},"baxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)"},"caxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)"},"bgcolor":"rgba(229, 236, 246, 1.0)"},"xaxis":{"title":{"standoff":15},"ticks":"","automargin":true,"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","zerolinecolor":"rgba(255, 255, 255, 1.0)","zerolinewidth":2.0},"yaxis":{"title":{"standoff":15},"ticks":"","automargin":true,"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","zerolinecolor":"rgba(255, 255, 255, 1.0)","zerolinewidth":2.0},"annotationdefaults":{"arrowcolor":"#2a3f5f","arrowhead":0,"arrowwidth":1},"shapedefaults":{"line":{"color":"rgba(42, 63, 95, 1.0)"}},"colorway":["rgba(99, 110, 250, 1.0)","rgba(239, 85, 59, 1.0)","rgba(0, 204, 150, 1.0)","rgba(171, 99, 250, 1.0)","rgba(255, 161, 90, 1.0)","rgba(25, 211, 243, 1.0)","rgba(255, 102, 146, 1.0)","rgba(182, 232, 128, 1.0)","rgba(255, 151, 255, 1.0)","rgba(254, 203, 82, 1.0)"]},"data":{"bar":[{"marker":{"line":{"color":"rgba(229, 236, 246, 1.0)","width":0.5},"pattern":{"fillmode":"overlay","size":10,"solidity":0.2}},"errorx":{"color":"rgba(42, 63, 95, 1.0)"},"errory":{"color":"rgba(42, 63, 95, 1.0)"}}],"barpolar":[{"marker":{"line":{"color":"rgba(229, 236, 246, 1.0)","width":0.5},"pattern":{"fillmode":"overlay","size":10,"solidity":0.2}}}],"carpet":[{"aaxis":{"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","endlinecolor":"rgba(42, 63, 95, 1.0)","minorgridcolor":"rgba(255, 255, 255, 1.0)","startlinecolor":"rgba(42, 63, 95, 1.0)"},"baxis":{"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","endlinecolor":"rgba(42, 63, 95, 1.0)","minorgridcolor":"rgba(255, 255, 255, 1.0)","startlinecolor":"rgba(42, 63, 95, 1.0)"}}],"choropleth":[{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}],"contour":[{"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]],"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}],"contourcarpet":[{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}],"heatmap":[{"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]],"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}],"heatmapgl":[{"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]],"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}],"histogram":[{"marker":{"pattern":{"fillmode":"overlay","size":10,"solidity":0.2}}}],"histogram2D":[{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"histogram2Dcontour":[{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"mesh3d":[{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}],"parcoords":[{"line":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"pie":[{"automargin":true}],"scatter":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"scatter3d":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}},"line":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"scattercarpet":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"scattergeo":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"scattergl":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"scattermapbox":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"scatterpolar":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"scatterpolargl":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"scatterternary":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}}}}],"surface":[{"colorbar":{"outlinewidth":0.0,"ticks":{"Case":"Empty"}},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}]}}};
            var config = {"responsive":true};
            Plotly.newPlot('ccc637bd-479d-4e25-8d26-56e7f9c5429e', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_ccc637bd479d4e258d2656e7f9c5429e();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_ccc637bd479d4e258d2656e7f9c5429e();
            }
</script>
*)

