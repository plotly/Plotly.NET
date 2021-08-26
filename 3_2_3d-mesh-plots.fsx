(**
// can't yet format YamlFrontmatter (["title: 3D Mesh plots"; "category: 3D Charts"; "categoryindex: 4"; "index: 3"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# 3D Mesh plots

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=3_2_3d-mesh-plots.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/3_2_3d-mesh-plots.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/3_2_3d-mesh-plots.ipynb)

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
<div id="0987ff30-b994-4876-81c3-02e1a460e494" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_0987ff30b994487681c302e1a460e494 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"mesh3d","x":[0.8031453484683975,0.0022281990396921516,0.980978301717424,0.4589473407058731,0.8306438298107329,0.04882906007060272,0.09339625718695868,0.348842101334055,0.406450002177828,0.9676638552768453,0.3982391750431802,0.5666960359395928,0.1689726911340713,0.5256066925477267,0.2550524879503308,0.08637857161759332,0.9871994773797689,0.5355148210821277,0.03898885428858402,0.49390424950695794,0.08027206923825297,0.6918270386251747,0.311447960935276,0.581339818696184,0.4944927815787926,0.047980008203526964,0.246771208591187,0.5024865355819866,0.9558801301549562,0.8468901728498238,0.23448564169671648,0.6523238493373263,0.15736516153317184,0.7726301638282045,0.7087520308367684,0.7604305859470882,0.9222359512570482,0.9657618771147737,0.6406588212776272,0.28409382807281514,0.6980973015064826,0.7686737146082677,0.3538040282920953,0.36303437704361713,0.46959275029115044,0.4497591901802268,0.8253071107088156,0.023834150761288662,0.13380683871629034,0.9349836907046771],"y":[0.9078443417827805,0.27722245933358675,0.1196199050730187,0.0680315052475927,0.8709774170401401,0.11131830984322276,0.6907802381044161,0.39963848302124,0.9644545591270806,0.7826638216072059,0.8020578514794157,0.590909721604972,0.3929619711790988,0.5595598293280042,0.7331782135801288,0.745915325705854,0.409330874406421,0.39634252730586683,0.8168546617109583,0.4946219020032426,0.16414262036054517,0.021437600264995173,0.8948559998045005,0.7548950262157689,0.7958069480004752,0.3115983546299852,0.3380230103330794,0.9484135838916589,0.11174706840503358,0.044733591398565836,0.2226728974947114,0.22293705782989834,0.3686796968656963,0.020896439450279084,0.9390458310670433,0.9572631823631298,0.5327039442643076,0.08933365628557915,0.9016527467880644,0.5974337209935457,0.06965034784267207,0.5225974682358082,0.0013073179876931561,0.8579949996704213,0.4820359765933994,0.10718757990151065,0.37571174342916897,0.7942441989640912,0.6298561634634883,0.7236774245852965],"z":[0.04042831577380575,0.42896458340294874,0.20697948905033037,0.6391849367130478,0.770841070344132,0.8864067415177853,0.3823664595290862,0.3647248788572498,0.2722245572471174,0.5593790624101549,0.7732952995101434,0.7423666542127573,0.2878914146162064,0.9197209677285146,0.5599909241124945,0.5791207936495174,0.2222300247392757,0.37206553172881973,0.6205139982609609,0.7759150312169991,0.2132113814415463,0.31999721812084186,0.4946897805178025,0.2194209407174126,0.42497155416057053,0.641545152124737,0.020130282277302017,0.03686100013407925,0.2728590496223695,0.6886193680989646,0.9358866112008163,0.5437788113689883,0.31855742042817053,0.3880696438197371,0.004305275624760089,0.7937083140917627,0.01595756877956799,0.7294947601526486,0.2500553691061471,0.05263908954925793,0.5748967228340436,0.1679790654070578,0.8171090990384617,0.3422736843779095,0.8241384214834023,0.3272836936299148,0.23470605361960178,0.08158635025917849,0.2980040755579267,0.9029151829438821],"flatshading":true,"contour":{"x":{"show":true},"y":{"show":true},"z":{"show":true}}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('0987ff30-b994-4876-81c3-02e1a460e494', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_0987ff30b994487681c302e1a460e494();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_0987ff30b994487681c302e1a460e494();
            }
</script>
*)

