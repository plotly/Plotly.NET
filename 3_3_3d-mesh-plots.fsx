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
<div id="fd1e4dd7-55d4-4572-81a2-b02180bb57fb" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_fd1e4dd755d4457281a2b02180bb57fb = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"mesh3d","x":[0.2831251487522969,0.7173395923885235,0.517964313979244,0.842611940969998,0.3838779825642137,0.7581569346404434,0.8407512800026458,0.3964242028987148,0.7343802422910837,0.4262562093447224,0.4042148591970163,0.23515429125873105,0.6714055047703001,0.3734195737044418,0.926923330839222,0.5159299208391132,0.4241854326912134,0.7936947219044411,0.7293381335816058,0.28323005991206973,0.6295888510670461,0.9240025602858526,0.21072264910243574,0.6567298852171423,0.2883587308639468,0.32953144252744104,0.4350151496171091,0.7990492544132514,0.3738271549222186,0.903390087607964,0.12038253998401693,0.16483841052504183,0.5851671679807674,0.569626913671208,0.6049335788027074,0.12187063839373674,0.16291564244912735,0.6099895884329405,0.6674799824447744,0.9588072928408194,0.948852078034008,0.7151570756524601,0.8811529296828214,0.044513381572679325,0.7143142412948954,0.670519600934591,0.5029091548653828,0.044176144545979866,0.44261934582265994,0.6234390775782238],"y":[0.8524808286933605,0.5715519993433505,0.09303366862844381,0.3785454385814003,0.053847275699417704,0.35912258846644435,0.5066169432860878,0.8612344287621018,0.5542532101060511,0.05434654003677263,0.32314178502333435,0.0417020255893944,0.022597047976496185,0.8309901546831197,0.3058736693607055,0.23937644867197444,0.6499871232779637,0.10177859109909208,0.7684859949017344,0.8050526924454853,0.3530142783899858,0.814195844258273,0.12621473945966677,0.7705308407407864,0.3343779818780618,0.914431775414586,0.04284963060303108,0.16620926752975643,0.9424156439222469,0.6178391299293559,0.8266222876620583,0.3908390050711292,0.3564299085905915,0.7503880773439948,0.05090925891460351,0.5488305406406664,0.07180474189659801,0.2066217293993671,0.5157796379717904,0.24581099033626308,0.6152536951076489,0.30168121368702555,0.0557363783268893,0.6131334424080017,0.6356655078174851,0.9071500524446136,0.6925600276759639,0.05016277499970178,0.7386397122119738,0.47493779262292096],"z":[0.020532477656627295,0.4011305637662907,0.2756901496442455,0.6375666533771747,0.27042479918823803,0.03828498443508753,0.4453372598836838,0.3225028278876575,0.04416745670333852,0.13941550028483174,0.31627295786341325,0.3404076757563314,0.9188187848398549,0.9364140801766953,0.22772425237471436,0.9323027799522051,0.685272116998803,0.2722089706325014,0.7800808957685161,0.7570431287200391,0.16757170677537644,0.4433653938785965,0.5859989531273018,0.5226750045654713,0.1897989973378363,0.05133306470296023,0.7584594659313837,0.513081297051665,0.1348653329233012,0.42722792943344823,0.221871747738622,0.9926868556033293,0.42756955531778257,0.46747785129932584,0.5973066522727286,0.42549172389576756,0.11514885542688372,0.7188632552134168,0.4799632781557568,0.012624274479515979,0.10349328075698264,0.7493019140089405,0.16245427269602858,0.3763641376869586,0.9295380324728498,0.2748460193513176,0.38286242884717064,0.11932229815019402,0.3854091900332874,0.70336272786528],"flatshading":true,"contour":{"x":{"show":true},"y":{"show":true},"z":{"show":true}}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('fd1e4dd7-55d4-4572-81a2-b02180bb57fb', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_fd1e4dd755d4457281a2b02180bb57fb();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_fd1e4dd755d4457281a2b02180bb57fb();
            }
</script>
*)

