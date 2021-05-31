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
<div id="3c00222c-d7e5-450a-9e38-49a8b873e848" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_3c00222cd7e5450a9e3849a8b873e848 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"mesh3d","x":[0.7217530280918596,0.024006493866446658,0.05946874760997889,0.7249038846813626,0.44378430742946656,0.24219452088800936,0.8403073408828616,0.6452461628454021,0.8686547800286928,0.9479032265711125,0.5543459572616712,0.8432823716864374,0.4804099395314278,0.12715918623244352,0.7282241060064286,0.3218376093180094,0.8774624829541251,0.3043161073254031,0.8340266686091323,0.07725362716114784,0.1056235274791827,0.7418080166642591,0.7781375957551122,0.13715251355299377,0.1981203547670135,0.9043780290076406,0.11354459920597477,0.006444989706596821,0.011569280648403466,0.08557839183396584,0.16774322426307164,0.14360002900641414,0.35167785703748367,0.19243383183723028,0.9070334117426693,0.9008396258115953,0.5693715976408551,0.5683496080191571,0.4675400273257587,0.5838940272032721,0.48716792440375684,0.6942977885223449,0.13715302578041005,0.4446452550797934,0.42227827078768904,0.24809204705436344,0.7694008777706888,0.5016712404329662,0.9612791701039668,0.49698402336658165],"y":[0.7786934952152397,0.24192991677761538,0.3959044438767733,0.6403931549938364,0.8764376141486865,0.9799450114276004,0.2458688981113345,0.9223162340569852,0.5267835299143491,0.5394062784218259,0.1286499216820346,0.8338623511762648,0.6336768821969986,0.7830763881947269,0.7801600023080408,0.4107459282552572,0.4916045146489537,0.2879761076941975,0.22012577448977427,0.8273844801948333,0.7524660116771543,0.30911287493496803,0.8367760799996443,0.2501326414058603,0.590085702757391,0.41132573895683777,0.6046549908838491,0.3334923406753188,0.7148742427653048,0.9500283077126501,0.1349771512369519,0.6118733587730086,0.04516581960263002,0.5145852572818218,0.30688489661872614,0.9258133074854562,0.7476955851296408,0.7112847020436472,0.3159962176885438,0.9270884003150689,0.6549707277002608,0.64705536358387,0.04156607810480803,0.9281337489039329,0.4552441055212375,0.6533055732274919,0.06062090632534628,0.3540766375856831,0.6644852527717525,0.011532342532431867],"z":[0.7564875324054098,0.4814247700764913,0.2815454659431919,0.13389468990913345,0.7445180116894273,0.4695806202802717,0.40515383677797107,0.14577180247091306,0.050307452236445366,0.46511187519184866,0.3752900205437513,0.9123765574360158,0.20744199129168037,0.5767552222016991,0.40442912718487395,0.516776562909026,0.7886965315736348,0.11909162491517683,0.4761914915760008,0.8543466948225846,0.6630503431256164,0.7803198126053065,0.9719798900056537,0.29303737417470543,0.17241375249457255,0.1054106480932844,0.26754679683015997,0.9086423310957115,0.7948885358846227,0.9367801295298991,0.3507048326314915,0.250578353298166,0.6690070879035662,0.7033419002328729,0.19354077530724031,0.6535523811604605,0.3303278928298167,0.9112711296934966,0.7700672455923945,0.8373042763384545,0.5206594707074852,0.6019237826587277,0.660977249807202,0.8508843424966952,0.5517983797713175,0.7425941702642451,0.43961337229218955,0.464810855903109,0.5237046217190588,0.9384675426122115],"flatshading":true,"contour":{"x":{"show":true},"y":{"show":true},"z":{"show":true}}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('3c00222c-d7e5-450a-9e38-49a8b873e848', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_3c00222cd7e5450a9e3849a8b873e848();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_3c00222cd7e5450a9e3849a8b873e848();
            }
</script>
*)

