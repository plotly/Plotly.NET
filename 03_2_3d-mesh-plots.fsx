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
<div id="bb32196d-2feb-4652-808a-28d6a8be0a0e" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_bb32196d2feb4652808a28d6a8be0a0e = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"mesh3d","x":[0.8132949316936056,0.39153903461598744,0.13652082166472487,0.27023241122729724,0.6969012528177823,0.92391778711412,0.2811648688657046,0.7710716322861014,0.5048575785499334,0.4482883924843224,0.29426905107417567,0.6234643043128142,0.04209290865906184,0.8543779169462519,0.3749630764941513,0.9036362464090978,0.13431338553052088,0.5226780225162758,0.13887705194711547,0.4367888832636126,0.46300738792075186,0.06488023934181791,0.37001290934626613,0.19185949032747163,0.1526520648750719,0.511852441593936,0.6279109207111927,0.7601068978012105,0.4574933594360451,0.055275190181692684,0.14965358476604038,0.2177604018793257,0.6281914900188295,0.9692063727272704,0.6302253327473185,0.47799900475796264,0.4358183841387827,0.8778376476270322,0.4172289666799963,0.5442790508010793,0.7663592355169166,0.6403358386086001,0.3690925707896671,0.8719904864542142,0.9362158910074345,0.39840383240878763,0.7957353493178894,0.16387945281522323,0.8085021515416457,0.4235182699856899],"y":[0.9167896816119504,0.411175012314308,0.05594492520016847,0.23054446244172028,0.2014355348429808,0.7484146923517877,0.021526125269721322,0.9446613313372533,0.11758034635222533,0.1850488112238463,0.2960068664029273,0.521057971064494,0.3135782728500563,0.4495823883682407,0.298634807718282,0.07650864919484995,0.9952728142939847,0.07288653593179142,0.22415258419893336,0.8969640717361886,0.46781786227031513,0.25647573790348865,0.10544905583627943,0.5945980011460362,0.670429647746696,0.8226715493121518,0.6957876685521508,0.49802242289205195,0.2556435993200371,0.7542482324662843,0.7161170922760466,0.4640314678959695,0.9516047462595649,0.0339750894503552,0.13848550856974232,0.7384785724517324,0.16181547667915722,0.3976470275771092,0.7677708378842896,0.8818106403955308,0.45647287948824133,0.49115705280152944,0.7602573012748068,0.23218015545615003,0.24827218439815202,0.24530126445242262,0.3267575657585438,0.9195101824214263,0.5733556787359322,0.8597072418125846],"z":[0.4031310181148029,0.722848813386098,0.9397268686162898,0.9115380798054571,0.9557004077153748,0.6603139437084616,0.3057259564780285,0.46134692405413225,0.5601148146950243,0.3787639855308291,0.05262702379963688,0.5235037023776694,0.6890177320172162,0.36333211388594105,0.4689317189477997,0.8319753985069578,0.5694532248049291,0.27960318339970114,0.3110968797984984,0.5601562352665497,0.9146931725156927,0.5976257867168755,0.3051156980475018,0.34234194380340255,0.4404911922479473,0.9766608094687856,0.4962184366286818,0.8732689003801294,0.3463258167478842,0.4251283832942733,0.49591398355360794,0.7762774861307244,0.9246667441561197,0.39593635750745254,0.3511172143514814,0.9932682788899486,0.5243045992796797,0.04006666645410781,0.0782746817349804,0.47817156486128065,0.43275261597370385,0.7004685526250249,0.8375322128820849,0.38900685235346055,0.8291836165958939,0.9329691771105719,0.8021393207843133,0.39692518738886584,0.7632484365083503,0.4162967858911943],"flatshading":true,"contour":{"x":{"show":true},"y":{"show":true},"z":{"show":true}}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('bb32196d-2feb-4652-808a-28d6a8be0a0e', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_bb32196d2feb4652808a28d6a8be0a0e();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_bb32196d2feb4652808a28d6a8be0a0e();
            }
</script>
*)

