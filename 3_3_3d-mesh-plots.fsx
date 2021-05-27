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
<div id="9c6e5ef8-ee98-48a5-a089-92974aaf332c" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_9c6e5ef8ee9848a5a08992974aaf332c = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"mesh3d","x":[0.942469206146183,0.694702046781174,0.6400049098953627,0.7245775683431782,0.6124411880096613,0.8593295146056122,0.7983176749191795,0.7989835859271621,0.6618160301175975,0.09881850336623309,0.26435185282693796,0.36200247908104327,0.1942913705456496,0.9339205328998718,0.5073250632301556,0.14234000544172712,0.3480992803108409,0.08759904098119542,0.918822471014607,0.11840949771851743,0.5507764632584418,0.5044146582970463,0.4785716712840701,0.2886133153404171,0.9522607265749298,0.4325144912267637,0.10358278551305775,0.5774149333952996,0.028992150458037925,0.8232405864741842,0.24207081098205913,0.6773599538381025,0.6087755517143643,0.9739376995591157,0.4343199648122862,0.5016080604407974,0.16260533787431444,0.7717851152512175,0.39083192189728466,0.29419469427978373,0.7676034680416823,0.6359854725357077,0.07097352578815702,0.04512051448464417,0.4134527069579124,0.5034725337771105,0.6784799735427275,0.12459729897072414,0.7623384146775763,0.2552837390710058],"y":[0.015031398746665287,0.13183174381583546,0.11160356975700872,0.4882899646127084,0.9538398035586997,0.43805454784913667,0.21613037549710384,0.3513915945549456,0.7723168417682484,0.17992669678289755,0.7557467290925546,0.22090274152387993,0.7699914354691242,0.8385754436434132,0.8567476923841739,0.5869918989888354,0.7532269273666791,0.22035367098653394,0.4996005680875855,0.005717002789358144,0.9797346675674127,0.5763141650596234,0.6967671190839108,0.6246277767348233,0.35080602967683505,0.9147909907227341,0.4334411325088894,0.4334511567994259,0.8751606083825048,0.44878819279781923,0.7540345176840362,0.9789854865423336,0.8150765187177232,0.7737084113870321,0.8082091877275189,0.11023906716622368,0.5657563840810937,0.12048558710165581,0.02009789600041597,0.9962654169631495,0.2854776849436935,0.8112137433193688,0.9994682734829692,0.2109052251143871,0.5384479651872291,0.5467007265178024,0.8659940370665835,0.2323980821447438,0.18837282210047024,0.826460807969077],"z":[0.7502456064104315,0.4581263025561936,0.6249967308831386,0.7566214118882182,0.27554907150359315,0.4387172336870419,0.4350646247319247,0.48697579302218547,0.13748393493587335,0.03904881283596568,0.004613415340247291,0.782679218697678,0.4762309861724409,0.32352864897042916,0.4258921790988614,0.7767612425502209,0.4058262228061567,0.9962830240820921,0.030366255915894293,0.7465086252179503,0.021235514907741695,0.6327413402650233,0.20025577498611796,0.503335151124436,0.7202393178456646,0.16852092424804388,0.5768458915766542,0.4858618939695237,0.08617981154759406,0.8041053031590326,0.04879695365615047,0.20104305036414558,0.24507833469895568,0.04869980041342778,0.6985425863873878,0.2959082151278426,0.353988755659195,0.058455106829505,0.4981593398834389,0.369491954040477,0.675174442434299,0.0787805910589083,0.9830016521657825,0.9810490831644503,0.9916520016229022,0.5027984662460157,0.3349827571469279,0.67593962451254,0.7850130460155257,0.7616867226370083],"flatshading":true,"contour":{"x":{"show":true},"y":{"show":true},"z":{"show":true}}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('9c6e5ef8-ee98-48a5-a089-92974aaf332c', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_9c6e5ef8ee9848a5a08992974aaf332c();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_9c6e5ef8ee9848a5a08992974aaf332c();
            }
</script>
*)

