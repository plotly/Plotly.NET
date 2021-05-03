(**
// can't yet format YamlFrontmatter (["title: 3D Mesh plots"; "category: 3D Charts"; "categoryindex: 4"; "index: 4"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# 3D Mesh plots

[![Binder](https://plotly.github.io/Plotly.NET/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=3_3_3d-mesh-plots.ipynb)&emsp;
[![Script](https://plotly.github.io/Plotly.NET/img/badge-script.svg)](https://plotly.github.io/Plotly.NET/3_3_3d-mesh-plots.fsx)&emsp;
[![Notebook](https://plotly.github.io/Plotly.NET/img/badge-notebook.svg)](https://plotly.github.io/Plotly.NET/3_3_3d-mesh-plots.ipynb)

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
<div id="3bdfbd4b-a1a8-4ca5-b93a-48b498d39867" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_3bdfbd4ba1a84ca5b93a48b498d39867 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"mesh3d","x":[0.07837243009282854,0.8451130240434376,0.10545164211907035,0.8544456986032639,0.26372577122586116,0.20079875327683927,0.9022218072331613,0.16465616420128204,0.13604042871670818,0.6399177134222899,0.04841274630670098,0.923833474947062,0.2091016295408372,0.9045257637763982,0.5551142141013938,0.2090867511970395,0.11378324037128279,0.5566398718192428,0.9162927753833554,0.3327981589049092,0.614082847542168,0.012996315496506317,0.8043778500540079,0.3220382301705136,0.9037169427162581,0.5254278702314141,0.7748048118198313,0.15895108094390067,0.17679376209936745,0.9867731318747499,0.7223809872392476,0.654930223084488,0.10272234403655042,0.04432019174300143,0.18519549033846497,0.9124267692269882,0.19961587022972102,0.6848568942792979,0.7234761499443446,0.5994747316462335,0.600220232084496,0.18466982114346223,0.7388336210226797,0.9731059623756939,0.25001809571404854,0.5059359304168894,0.07216863384105668,0.15140550311254594,0.5562829997186935,0.44669247346310526],"y":[0.19947711108228058,0.36291387973488953,0.14112514962494613,0.7748170079546128,0.591970315013067,0.06537611459632223,0.040735173989429684,0.7834134119485567,0.9507287558870058,0.738297900994447,0.425993941457008,0.7432707262892605,0.9878624021019146,0.14926729684195822,0.9175367261830423,0.39348252322221294,0.8211111309105117,0.16478143779783577,0.7193302734379332,0.6426874448744057,0.00947088096731849,0.42892634609198493,0.8331637218748982,0.31681804373712186,0.7325779268204132,0.4294130263987058,0.27416269447382663,0.831271887678314,0.07202013445646509,0.39778101229936863,0.4532592363903575,0.6233993087072853,0.6026680812252071,0.7301012886362622,0.7872960207924694,0.3594671075043581,0.513805073459542,0.32790533608193756,0.45234987672993443,0.11981937574214273,0.8716915952375586,0.41620245828116426,0.7341281383922921,0.9851782489498976,0.1734807901892256,0.8569495057952355,0.19680741904154767,0.5895663241807214,0.055569236192651666,0.8565355724918357],"z":[0.6848247995063778,0.9073871960432209,0.43207522967461276,0.9135955548442879,0.4372215924957868,0.7705507649902956,0.5297501578599914,0.8243071058878243,0.04223908113419967,0.16255728861436122,0.7912134201224956,0.20946328631111574,0.7113932774920917,0.5529477435876372,0.28503866460408955,0.8025946327497226,0.14060264506405343,0.2577611134656524,0.3619712760494888,0.5580696186786842,0.879677449762671,0.4932057948285741,0.7124315610679014,0.5995108976957905,0.7709958496368471,0.5932684226861542,0.6947982076996929,0.8479854729250006,0.14333725354789628,0.8756284210251777,0.23260560735715816,0.6845963702931052,0.7757026514856623,0.21548456196462948,0.7129562127929908,0.5458720403471365,0.1913240790326726,0.6890725263809192,0.29287969614047543,0.01674525580217375,0.8297169496443667,0.6894979675717177,0.2856662549477379,0.2897925881155732,0.32860595561964717,0.6622283089264428,0.7048091807890726,0.18118039480465484,0.700139584345808,0.370886157439503],"flatshading":true,"contour":{"x":{"show":true},"y":{"show":true},"z":{"show":true}}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('3bdfbd4b-a1a8-4ca5-b93a-48b498d39867', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_3bdfbd4ba1a84ca5b93a48b498d39867();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_3bdfbd4ba1a84ca5b93a48b498d39867();
            }
</script>
*)

