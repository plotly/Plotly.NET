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
<div id="513ff4a0-c697-43c9-94ca-cbfd309b7e73" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_513ff4a0c69743c994cacbfd309b7e73 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"mesh3d","x":[0.3500412983587204,0.1544899228748353,0.7539686685213673,0.42127620448417785,0.19643642762509939,0.23211118636285477,0.1764915102051997,0.43810811053873416,0.5699997970694675,0.5612290778948129,0.6654747443578554,0.07536526074417181,0.7811545146541459,0.16955508299616867,0.44403375473061285,0.5976386431593628,0.2677200349363126,0.9174513727973455,0.3915557960940319,0.9780564261498192,0.8611561199003627,0.24656372156299824,0.8492108820235408,0.8850482766912544,0.9847785509120573,0.1818237589587568,0.5319669542517359,0.9151499177865451,0.8197162248286028,0.740276071587706,0.7992578175846756,0.15798261256794566,0.3228694383627127,0.8718237340784742,0.21651594956243223,0.8040808838811149,0.14416318905733674,0.15027748940059799,0.43969280805424454,0.2724382878618493,0.360499279275769,0.833384368025411,0.3705957482431995,0.3978428958905129,0.40117867682184033,0.10993432398416769,0.19692930122694433,0.10870983689497683,0.9374713301367459,0.6611554383585022],"y":[0.448000530920923,0.3560792404953759,0.8241995460466479,0.4587438537081442,0.8947186059759551,0.10347757679572216,0.30527904085129454,0.8689203918301129,0.43649765357212056,0.014612668666342584,0.7001442321111189,0.2613415924186546,0.6183918857101314,0.8297237254817615,0.7619712603101373,0.5074921317899097,0.7524958223814591,0.9093307805756716,0.9530391334337365,0.639952870849498,0.45347545410202605,0.11744254553571462,0.4777585647431009,0.11911750823218259,0.6175571468740502,0.02777175187495153,0.8759679733197987,0.4513679861330278,0.483869599869414,0.8748442269278897,0.9848944577318125,0.4232571173567591,0.9776785876497992,0.15856078647010066,0.292275540666783,0.4431785770892997,0.3337830665212977,0.8641255846545685,0.9771051281025191,0.11303837276671005,0.4988018430298203,0.2752427972272238,0.7137798358284775,0.42508013938790196,0.5722940557507304,0.0991576868571144,0.21499248231527976,0.5408720227614381,0.6358716355803756,0.8936865450319306],"z":[0.35743850160270857,0.2875985206512727,0.15567070346124037,0.29751845928724785,0.20767998425647616,0.33055798538520836,0.878320675752275,0.7050820378144653,0.841186706834094,0.8669468541010036,0.22750960347592347,0.8539110547182668,0.3850507919606989,0.5616534266442309,0.02971821093453011,0.27688711475435973,0.2836630047688554,0.4598310992400307,0.5374481848149785,0.3187926832208376,0.17370906526861205,0.8883702377268906,0.9322256524731525,0.8400007606670264,0.14115102781967773,0.17823265687480228,0.40366270970723717,0.05267842535519899,0.5468234524814521,0.5183994600169358,0.8127792695596717,0.33509595055836067,0.8154963505526522,0.5901830548374835,0.517405725325181,0.6972959370805397,0.26758641389551874,0.6801601283625514,0.9508808022136245,0.9617175552815747,0.5648579013370247,0.6287010287068323,0.022938877820474504,0.1101582740015156,0.8855287692907866,0.6448907883115536,0.8901920052665249,0.15212640918424652,0.3953619284533718,0.2954069409963707],"flatshading":true,"contour":{"x":{"show":true},"y":{"show":true},"z":{"show":true}}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('513ff4a0-c697-43c9-94ca-cbfd309b7e73', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_513ff4a0c69743c994cacbfd309b7e73();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_513ff4a0c69743c994cacbfd309b7e73();
            }
</script>
*)

