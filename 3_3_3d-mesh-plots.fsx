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
<div id="e5298bd9-3035-493a-a02d-6eeb9f0df970" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_e5298bd93035493aa02d6eeb9f0df970 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"mesh3d","x":[0.40372035484934243,0.5296250886887429,0.5487060949898819,0.47882504131590253,0.5187084830918854,0.10482224594094895,0.588915293844843,0.36613040248217543,0.6897676199161297,0.871374252658046,0.17258679781695213,0.8714335890819475,0.7964568607492637,0.146481407874488,0.7733185569631488,0.6247546154189644,0.9262439366086591,0.27120916045792826,0.3926859816502249,0.2636970431840499,0.890582261090438,0.6583248961988487,0.16365207366815399,0.08739709345968305,0.4720971297808444,0.13486622187069908,0.9988278057420755,0.006304378624215899,0.7817294047129012,0.576618316386183,0.4634196341333071,0.4178856752896149,0.05261330634942898,0.5858130760424831,0.0990123050748428,0.27183693613476906,0.5934843847497759,0.44135901631850705,0.9076732079999862,0.385496883366954,0.3968598932944517,0.6069247967595816,0.48794396058094874,0.36501963220770456,0.4624821313016499,0.2059017644291286,0.5235767930390205,0.5266948088662209,0.5932634959897322,0.7699925577128272],"y":[0.42828855823180106,0.4643706555778024,0.01655727253135167,0.6258154481769611,0.1428524507874867,0.7453954586504937,0.3659730150205889,0.4613090015301988,0.006727911535058129,0.38384226122118636,0.10599444019887337,0.582610915220627,0.5844009977692742,0.11314930352994675,0.40795461852473885,0.7547011225273372,0.8188202827325185,0.21064378470678058,0.04746910279964521,0.5014816208283797,0.03127023066918842,0.48488492029015207,0.36353595245794207,0.007189098283270886,0.8668371498895983,0.2836574643308564,0.17038093561789996,0.7986324414604494,0.6249149621580331,0.2661953653517158,0.6112894288316786,0.4721329968758547,0.4130408826344837,0.011736847000074036,0.14832975815438187,0.9990489785555047,0.40132840275826326,0.42679785817246785,0.4429606252549964,0.35361684642434904,0.9058639211141802,0.1321753832195771,0.4346311047834489,0.5238309467787998,0.2795024431680806,0.8142489780738247,0.022523798990307282,0.37479465705100196,0.9570650136829657,0.7077810087743127],"z":[0.3870814816966101,0.3129330083322399,0.4792257060665757,0.09178187516135251,0.7387223270436387,0.943403637941649,0.10083470311986036,0.009368174248080782,0.758978298287363,0.8591949864566303,0.5750145230325938,0.5673405735601394,0.8363940393721657,0.7405325461833424,0.7725528323895078,0.6338614433230187,0.16957003258614337,0.5726641507692003,0.9648195453755648,0.4089056399692342,0.353372719769074,0.39202242456005065,0.7676831594517842,0.6938522563752961,0.5956176997141995,0.8990948474496113,0.05025381550670313,0.8397050056791422,0.7276866551151903,0.05258817181577355,0.26113366534054916,0.795586278566898,0.8415674277774838,0.9171339533837205,0.8791138836551057,0.2983564204994386,0.992907290809279,0.3212590074731312,0.27301451995643533,0.20492612021273288,0.8982142754356444,0.3919602285101825,0.6678195598851049,0.5837656387983662,0.7786023233917553,0.3385233475540408,0.2957813438474114,0.6940985586001065,0.751278114389292,0.645640999845062],"flatshading":true,"contour":{"x":{"show":true},"y":{"show":true},"z":{"show":true}}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('e5298bd9-3035-493a-a02d-6eeb9f0df970', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_e5298bd93035493aa02d6eeb9f0df970();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_e5298bd93035493aa02d6eeb9f0df970();
            }
</script>
*)

