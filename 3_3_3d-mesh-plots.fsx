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
<div id="5b19644a-eb8f-412c-a09b-c15d6f86c6b9" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_5b19644aeb8f412ca09bc15d6f86c6b9 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"mesh3d","x":[0.04048804242186623,0.9534221463619834,0.02949282621475534,0.22882734110058628,0.6719199235885962,0.10322023141347814,0.24625844100781644,0.9030614005881648,0.06195017465481077,0.9478861680011667,0.59279539789669,0.25013178784872026,0.16332630308499854,0.11654580576184476,0.6440921968985778,0.12464436894498969,0.46738309574657266,0.575659494183799,0.034704085921265226,0.6987003491719721,0.6938227488164896,0.20555536551659712,0.8328757029179836,0.3410809139446732,0.15287823889072902,0.037472775689080716,0.34897485065691863,0.5570320498929509,0.1058065165326961,0.38862982317275824,0.42168369443234227,0.987686980975646,0.6051913092868362,0.13958456047791268,0.7908726501236076,0.7562163089198136,0.18668998739993664,0.13796731230708179,0.7937115495063884,0.45752200645279234,0.6122706246619442,0.4608442468852011,0.1095775664362952,0.0880127107203066,0.6941810281454497,0.052037867741676916,0.9044927572386772,0.7783983623508356,0.6106143522125735,0.4691654506461534],"y":[0.14579492208817738,0.43986186917864806,0.44515482310445736,0.07957873823101573,0.4238259817584539,0.8349326769052691,0.12054644344399983,0.6884119122700821,0.07594910220985725,0.6344471478995155,0.7542453807565594,0.6892263911148656,0.7972548840554686,0.6733203514820525,0.5262024735688243,0.605108416921044,0.644940478561884,0.023741742607085847,0.32567315563823707,0.8878758879787642,0.9379543815450531,0.32941578343949085,0.7819479446774106,0.5771820794684729,0.0864297245100279,0.23297850193128852,0.09597779908030192,0.744862992197677,0.6468998857992235,0.1008403711490521,0.13298001845040358,0.570576488306083,0.9464176976803773,0.6366410658865427,0.2428349010845809,0.9818218252536942,0.5425321578711887,0.5256125710558205,0.7157585787194588,0.9559399732183386,0.6356698654758138,0.4982780751298545,0.06201821009722455,0.15926440160687286,0.7032766256962328,0.9230442335470785,0.6635893628297325,0.4362572149542427,0.5618102371514823,0.08907261122440575],"z":[0.4070973891797929,0.8807510146315913,0.4527252067125985,0.7227384642338094,0.5312110691011004,0.8163791386486865,0.6579139245012374,0.8679727436359845,0.9931490137209878,0.19084747982716535,0.7389548778249672,0.3756834512463228,0.041512026470858616,0.9751087310608051,0.501467129449112,0.1836688924504765,0.7428086934344883,0.16061381816892598,0.43048545039747166,0.5443806483151301,0.0625762590498553,0.11932790750606354,0.30798316388762703,0.36973318241989855,0.2522060225029504,0.4396763064151985,0.26739757334226627,0.6226835430705377,0.87390545377224,0.16338549096294935,0.5693891391015561,0.6597205841260593,0.18305275504619478,0.5578272745748177,0.6937429819692592,0.2522290038188123,0.11785128159348447,0.2236792334465679,0.10542999678544235,0.42645576243589434,0.3239079007524568,0.6745594142352042,0.5324635573348326,0.5249110988922935,0.21698509539337135,0.259986414229491,0.4567660486589959,0.08690947903641941,0.657797272157761,0.5196077332457564],"flatshading":true,"contour":{"x":{"show":true},"y":{"show":true},"z":{"show":true}}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('5b19644a-eb8f-412c-a09b-c15d6f86c6b9', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_5b19644aeb8f412ca09bc15d6f86c6b9();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_5b19644aeb8f412ca09bc15d6f86c6b9();
            }
</script>
*)

