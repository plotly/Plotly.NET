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
<div id="fed834ef-3c74-468f-a885-a98f6f84556f" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_fed834ef3c74468fa885a98f6f84556f = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"mesh3d","x":[0.31170499804974766,0.9878874174262804,0.972427588409012,0.7644420330247106,0.28109550628862134,0.7790180755681443,0.06951837710548117,0.6442780679297997,0.12080672202669397,0.29647164572797324,0.551269653044301,0.31932117525456527,0.9265013867646927,0.3363326328510105,0.2633987363723101,0.6246459179672627,0.4810678569977488,0.7294097015305467,0.6613155336404757,0.21522060791739292,0.44708626458751327,0.08412111601052857,0.14733416733673502,0.7670494736018821,0.9546686387409775,0.5897920935367197,0.8026120335807149,0.6838163685443888,0.7302474727529322,0.5429527710857581,0.556773438377666,0.26103807951372027,0.7094007654624994,0.9333686986627843,0.7845687106179859,0.1301836884255445,0.8384600942202193,0.41698541139112105,0.668836810937541,0.47389737073047894,0.6847489940397203,0.831228664997606,0.9281777324751848,0.07544457869392102,0.8398109734243765,0.36938542796735907,0.9090033024125748,0.1899471605149783,0.5354716710445805,0.8419163249628229],"y":[0.08474261736718128,0.579577515171644,0.7430767890732162,0.45084432300685173,0.7246457886531231,0.2275838820392191,0.8405532500895454,0.2053781148071299,0.8097733942837331,0.6913034127519017,0.9764060419874294,0.38570200856109244,0.9140305951768675,0.5778539509409358,0.7396982073503072,0.29023157353058066,0.6099204097920659,0.9931326881019085,0.5517639222330246,0.13321504794676559,0.7861858237470434,0.06408244560662771,0.06057289059300576,0.18741816290999677,0.5304716138776725,0.6158575995899074,0.15594338353534387,0.071889588642814,0.9272385001775056,0.5852832107736186,0.6807887911241449,0.6126648730657366,0.14834469749980825,0.8883311477901094,0.4582101537185768,0.977195923206022,0.5179612904405041,0.25855644245564774,0.20872291000966117,0.5569848285787669,0.2896304383359991,0.6330819794130893,0.607212017107388,0.9775333981856393,0.4974913287430496,0.29904698547862796,0.9171980698207385,0.35032378153424887,0.3357463713436138,0.5495793998937958],"z":[0.7594650181752932,0.9158706143106663,0.6381832382819538,0.4022566230978149,0.05573050121577946,0.020660171760553573,0.5190046245786383,0.5556586261632194,0.9203727091291792,0.10878818906321572,0.07164049850387522,0.7686636614467314,0.2781396146296242,0.22449018351011452,0.010514621627756683,0.36374116892169284,0.2373573110612842,0.025699447386758143,0.11964379722235902,0.7625022841442852,0.7722702830900765,0.3513639673364181,0.7844097780922473,0.9947790936542578,0.8435846096107664,0.15310384433395408,0.4568704284992397,0.0830394924073664,0.6899268341669472,0.23142462839904457,0.6986595297691689,0.8056196020010951,0.7361432172992002,0.37765910028370986,0.8258181925983253,0.7649181768134786,0.9744816347837828,0.7460880744019933,0.8326006465743299,0.43754998195802325,0.45819129862738367,0.9623026642772847,0.3381837333264685,0.09993472094644547,0.4853443300748916,0.5209667768892677,0.3549423647834651,0.38272183359727346,0.9670187765578827,0.1337501598213567],"flatshading":true,"contour":{"x":{"show":true},"y":{"show":true},"z":{"show":true}}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('fed834ef-3c74-468f-a885-a98f6f84556f', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_fed834ef3c74468fa885a98f6f84556f();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_fed834ef3c74468fa885a98f6f84556f();
            }
</script>
*)

