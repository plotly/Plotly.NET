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
    |> GenericChart.ofTraceObject 
    (* output: 
<div id="1669342a-dd9f-49ca-958f-219355f61ca0" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_1669342add9f49ca958f219355f61ca0 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"mesh3d","x":[0.9801759519521966,0.40851702606702084,0.17165229291266404,0.18797299134916298,0.3212998906715307,0.41689023814019294,0.2008571416143594,0.9070177622637794,0.6120140154901957,0.4751868999913274,0.9233973906018759,0.13801877998654674,0.4275458838918926,0.46937853864830853,0.8084408216217723,0.7315528861859594,0.24368691222913885,0.8316569183169198,0.44200816398580006,0.5624000171955675,0.2037684434111083,0.7374182486615228,0.27645730985163586,0.5164167641272847,0.09461366994986947,0.9727868093050955,0.8391027263547772,0.7598270851931661,0.048882375959717846,0.3670795803736335,0.30392860449102177,0.6434999861025718,0.36372667661110253,0.7895959470372628,0.6386131097742418,0.9229807466841213,0.5468900602063583,0.7014342908288512,0.19322892473695283,0.19100227681500942,0.11827519075864702,0.9050304367696077,0.6204630078843156,0.06321622015126804,0.5680585799590026,0.8390786055657448,0.840171799454918,0.145732981686356,0.7020640721088574,0.19538181889587167],"y":[0.6465225264646683,0.9557904675397046,0.3714368452185005,0.86514296422952,0.16492013873761527,0.24275770329067375,0.13205971621538498,0.6552355287853794,0.09335932139929352,0.3485130813664352,0.5777875117854157,0.4410300564211933,0.8581353863040616,0.24493443511656227,0.1712582955003056,0.2798974044993042,0.7742921033754442,0.6379499368546298,0.8307654288740668,0.885460074937651,0.18466282597960104,0.5422526214002876,0.6384279935799669,0.25100588717079064,0.4441248264369205,0.29873800664150063,0.11695524077720719,0.21324108970036781,0.9483581841682821,0.2555350643841247,0.13261500985017746,0.6933697446684212,0.057763013084308715,0.8535005570638462,0.7205570539089651,0.3481381369513171,0.2720631408840712,0.49858371238158256,0.6246758082996475,0.395855406483568,0.7909210304687363,0.891654531420979,0.6080749694295576,0.8447158433705176,0.6132147650295937,0.6772451343374537,0.04689505046554611,0.3755285727677534,0.8919579246509625,0.2881611754596984],"z":[0.0647865021903005,0.2022218626002883,0.3149675528122892,0.8166039971712064,0.010718992916270622,0.10426990506438068,0.31736247395973766,0.12043095804770987,0.42101813779259945,0.8661821320961146,0.12580246251346658,0.9188186265150172,0.7068773446170973,0.8378242570151688,0.21589807151625776,0.8844177671169945,0.3832670433368846,0.004634829240215397,0.5243773812075971,0.8231201585489885,0.007834263615233015,0.2757083909938617,0.013274128554982194,0.4349100223904988,0.09453904446891465,0.2930082945586221,0.93417765197073,0.7937121502094493,0.6377911221411969,0.7668796920994668,0.25184295617595454,0.7414266680094538,0.3212831650494054,0.6601970087085837,0.19074856219382424,0.9303931472498892,0.378402191856132,0.24115901591310232,0.8427815641475755,0.6162871488445845,0.030775662991579467,0.15163218283636132,0.07756557458898312,0.7584936762035329,0.2700529439701014,0.8721024039537192,0.18477718680388164,0.7702507124143889,0.6288177718542599,0.7287969979125992],"flatshading":true,"contour":{"x":{"show":true},"y":{"show":true},"z":{"show":true}}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('1669342a-dd9f-49ca-958f-219355f61ca0', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_1669342add9f49ca958f219355f61ca0();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_1669342add9f49ca958f219355f61ca0();
            }
</script>
*)

