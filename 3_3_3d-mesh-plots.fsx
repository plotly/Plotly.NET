(**
// can't yet format YamlFrontmatter (["title: 3D Mesh plots"; "category: 3D Charts"; "categoryindex: 4"; "index: 4"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# 3D Mesh plots

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=3_3_3d-mesh-plots.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/3_3_3d-mesh-plots.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/3_3_3d-mesh-plots.ipynb)

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


let mesh3d =
    Trace3d.initMesh3d 
        (fun mesh3d ->
            mesh3d?x <- a
            mesh3d?y <- b
            mesh3d?z <- c
            mesh3d?flatshading <- true
            mesh3d?contour <- Contours.initXyz(Show=true)
            mesh3d
            )
    |> GenericChart.ofTraceObject 
    (* output: 
<div id="3f6f568c-2e83-452f-b586-09aaa8725b85" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_3f6f568c2e83452fb58609aaa8725b85 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"mesh3d","x":[0.7243078265917989,0.8022304106514111,0.3273541151207658,0.46679529569428196,0.03196941876410014,0.5455531601540526,0.31661386383539714,0.3430150367054227,0.5220601905705687,0.6206762933268567,0.37413615238579745,0.6980919715473857,0.7414475487272476,0.17524890097568227,0.6470602781730985,0.11563233757188186,0.7698894887091078,0.4187452236277728,0.36225439857796504,0.9905638098672795,0.4864153282187951,0.6117189603912266,0.00816233922176172,0.8607216784081988,0.9611005512816369,0.64300442284113,0.9458532407627689,0.12414226127981313,0.21133199018022603,0.013060208416106276,0.2581539709391789,0.5900478058448284,0.6854843607570438,0.7789216124354497,0.8462879517331198,0.7128526003625489,0.9793671131969276,0.47412092353874863,0.6219218976897756,0.3891209277273719,0.0822109193923934,0.3637401528487635,0.6667555666839498,0.5921248442456708,0.26129340671994417,0.0948368804970928,0.5179135308218717,0.8348561110137291,0.5139920024732091,0.9785617180068799],"y":[0.8031768825851273,0.7555261183322994,0.7430918238792065,0.534713931630698,0.32360153567213634,0.11258886620057228,0.7940680714296494,0.466632436712567,0.5056947444126451,0.3889649959229701,0.5996999193912838,0.192471602555584,0.13168304652519666,0.5089999821544625,0.3625223223876778,0.784088346540969,0.012607610790341912,0.962525936291798,0.3289609492425625,0.9342076778105496,0.13626522437495422,0.29576856517035915,0.7968233259379972,0.9731334708505932,0.9083528904748861,0.12267517537003159,0.944963393707277,0.41603749497609094,0.5994282716882546,0.866263670784544,0.1250908920192583,0.11099712974903972,0.6101502588066041,0.23277027217334614,0.20988332583097896,0.5026278526068795,0.8469559819656219,0.15077042912634575,0.4553200767633133,0.7336990855325475,0.9187845289328995,0.5127346764843607,0.9684261791261035,0.2329569017668054,0.7894210083360882,0.8897393168368094,0.2320571063235668,0.15775558452948724,0.22960252185799299,0.4772050601789751],"z":[0.08222926970675087,0.5553875945300737,0.5058951617711667,0.5797843246626595,0.8422964936319257,0.5074083174147682,0.9587027923943022,0.7699583530286133,0.6263610411558119,0.20092636030210478,0.16762547249329532,0.3780305764535584,0.8672041650243123,0.639431073628101,0.2638741039037118,0.488702789642244,0.5823213437489799,0.8989127743518505,0.2991166563234835,0.8598944697807983,0.9371323645753471,0.8618371816639961,0.5072058595284847,0.595261863710015,0.015423148877650103,0.6235305478905936,0.32734238604425564,0.5638664241711918,0.18371246251450501,0.018613573638076697,0.8906180690464648,0.7872078091777898,0.18643497311809798,0.12222321150927953,0.7840344010777932,0.5697032974891846,0.6051019679778731,0.030365934143944614,0.39047377854142046,0.7024750084162108,0.5439250602125772,0.07699762893700862,0.5244093879705338,0.2543937164612085,0.5660736130392522,0.540753952479341,0.6455305114600484,0.3289951054980024,0.9690827978630936,0.30071821869384413],"flatshading":true,"contour":{"x":{"show":true},"y":{"show":true},"z":{"show":true}}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('3f6f568c-2e83-452f-b586-09aaa8725b85', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_3f6f568c2e83452fb58609aaa8725b85();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_3f6f568c2e83452fb58609aaa8725b85();
            }
</script>
*)

