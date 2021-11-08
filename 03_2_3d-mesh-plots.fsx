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
<div id="d7ebdf7a-3727-4e8c-beab-a07d5a750fc6" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_d7ebdf7a37274e8cbeaba07d5a750fc6 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"mesh3d","x":[0.051935993624821306,0.5379365661823826,0.14015051403089915,0.9510701196040353,0.6654894951104603,0.4180496113458879,0.783915773399135,0.8912304751068496,0.7391080412730147,0.326717326569705,0.42695263513687653,0.34066810940423425,0.344420974303233,0.9351206854614991,0.3738891200040882,0.05169404393606542,0.6188784714876108,0.701589040319244,0.22903643046926542,0.6208728899345142,0.6244786370659613,0.7702921604599301,0.6960393254161065,0.8528771502212049,0.23257819620546802,0.9745009243369572,0.8692346847938536,0.8917833691890275,0.5045263997765846,0.016340462032864086,0.6505118113246335,0.7314245224611017,0.6763330556807727,0.124737751262606,0.005762321877182611,0.8350362586020661,0.2513700370916026,0.5874890892708158,0.4024115472111905,0.07769069498297325,0.0635680109558478,0.4520063528101921,0.4911709555849298,0.8740542381415396,0.28944803042777256,0.7523636281268502,0.8350552268489521,0.41064764485258964,0.2359349551777984,0.009357055653518558],"y":[0.8522084568870293,0.6017718425028826,0.3850443351012861,0.5627074817021878,0.4455332734834092,0.28164383316489117,0.8418972407662763,0.28727336380969426,0.7184919233985674,0.6909885707735031,0.5488149265520345,0.8921324042101076,0.3867040753302649,0.7227675792401506,0.6762055152450713,0.6955281126757749,0.6643350537234615,0.21968322304062696,0.9293583635843166,0.5388528614020222,0.8003240068444628,0.03138938221679506,0.29917749310805347,0.15134573548629215,0.5573048789786663,0.17247228425576924,0.27912120487500036,0.8219850872745668,0.5634291197934324,0.48021456807861784,0.13944569748800514,0.4585870399412639,0.6558484140112291,0.4951693441230661,0.16413200514583476,0.04873996882175094,0.3463801873598156,0.113625573978585,0.6792044777791968,0.7241184887122915,0.9931390178357898,0.9640966732819084,0.8689971658722484,0.7114229764376874,0.5288757684309389,0.1714356067457402,0.06530227747992719,0.7684033763447792,0.19784872289646824,0.5939199177519977],"z":[0.0880285744033887,0.6153720038083251,0.48128928126827314,0.6970820937757762,0.20903304880905574,0.8208190746702343,0.30259434939482915,0.23369859961499395,0.005402602723521461,0.27306098922764,0.0025226282898907684,0.019912153491709453,0.7238442440162619,0.2382773553199495,0.5515428732854979,0.09022788661077054,0.23628399019887858,0.8915347312071988,0.5586355740943157,0.6274655464233204,0.34914792531595934,0.5507094797448765,0.5404787452614301,0.20523987487202505,0.5457138435662323,0.8362273335625545,0.16239221634454662,0.587754516670366,0.6224699670553533,0.3858692722329261,0.10717000677584206,0.5107178285302212,0.6241363643780986,0.9695092020414346,0.39218599367522916,0.5240736936796799,0.9772977586729907,0.9587663202354527,0.28613629531401036,0.3433129304756005,0.7461456194269218,0.1126815877448216,0.10822297125506353,0.40614348855155685,0.7215958604224006,0.9732268643440803,0.24025242926564647,0.630719810552299,0.15988010315218945,0.4386478818201683],"flatshading":true,"contour":{"x":{"show":true},"y":{"show":true},"z":{"show":true}}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('d7ebdf7a-3727-4e8c-beab-a07d5a750fc6', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_d7ebdf7a37274e8cbeaba07d5a750fc6();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_d7ebdf7a37274e8cbeaba07d5a750fc6();
            }
</script>
*)

