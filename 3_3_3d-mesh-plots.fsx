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
<div id="121f5820-5d8a-416b-813b-31dd67b57f7b" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_121f58205d8a416b813b31dd67b57f7b = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"mesh3d","x":[0.6710546564641663,0.3790051612905251,0.2549621864477928,0.37887420196965066,0.4092156423298715,0.8306987727203866,0.9702230193513552,0.753458826222205,0.8354411231518915,0.12393685156662802,0.5138545811706476,0.06822683246258034,0.38437513186800065,0.8961139250994259,0.41859387625874667,0.8277130750136976,0.7265439930961206,0.18379621123140502,0.8517480314950217,0.4844391185252178,0.24846913490838796,0.8209978271373537,0.04136935437161911,0.9026707084396252,0.214657295129568,0.014250340878148722,0.2286470160952988,0.7089531243354795,0.8658745074020114,0.7547879134094286,0.4675534523406781,0.24305246921398327,0.7661742585553668,0.6190900107003237,0.9721933305134034,0.3470692985444652,0.09032552926350643,0.053249077896237874,0.9209202802371794,0.07182735021776862,0.23163097967935306,0.5328631440796252,0.30720319566652327,0.7786380223830408,0.04935055507782407,0.692315706839932,0.7422445210359266,0.5508954872148556,0.0913671432488445,0.35409195551373623],"y":[0.14443449589630333,0.835641879046169,0.16485836690517996,0.4421779939169893,0.5335390062693223,0.8500568293268126,0.33763580691890593,0.35229147800816757,0.1642169068400827,0.39496530145172276,0.6020517566250878,0.2612698950158758,0.8875843188201935,0.08065320974246283,0.65638339922595,0.2708021119566644,0.3020525739072136,0.765285121167677,0.9239205945860225,0.07152457771428143,0.7373875457501913,0.6732949151998828,0.2628759309942256,0.779920681277253,0.2528081388458647,0.7156059908287628,0.5137946314708305,0.26273133198857834,0.8533201533618011,0.522341588289636,0.27200581984222205,0.6777515288804432,0.617585981086635,0.5117825518882753,0.6103534175131253,0.631911573294509,0.07819410230880329,0.3239962646383775,0.08555100443100137,0.12213650118659088,0.00943349162555928,0.7380340512553388,0.8890321710561552,0.5259549787854566,0.4697755935926808,0.9703610846634773,0.6452788252594317,0.22654998592406045,0.12225462315709079,0.7785484431211597],"z":[0.3902631329327184,0.9769593998682496,0.6269748926288331,0.019842565534563067,0.616704409763545,0.47113958069642053,0.5727659480519435,0.3849376856279269,0.18936985507112455,0.8179330154405595,0.3362621978559821,0.0749044749303276,0.49897132464636645,0.6418753185504467,0.12295948160950071,0.9243002277446446,0.6436839139292407,0.37580176693191836,0.47029979222933754,0.024471825931440958,0.19260800964786112,0.978056309268836,0.6797341167366757,0.8017840933994316,0.062091086088722144,0.9993534944948523,0.7842627441437275,0.736920952208769,0.3101450876845723,0.28244705418238747,0.07032716556933111,0.28724464554677004,0.14047670883148755,0.07477171024064147,0.13207845535691756,0.29504641997397246,0.050776636251610066,0.597743415552072,0.8950781421247302,0.13921383681670477,0.059145625242565586,0.6932564166808763,0.1346264095672529,0.26761798899044187,0.7858743033306088,0.9345290166952317,0.2390627266089724,0.2471568525057085,0.4029954971759559,0.5454753658480362],"flatshading":true,"contour":{"x":{"show":true},"y":{"show":true},"z":{"show":true}}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('121f5820-5d8a-416b-813b-31dd67b57f7b', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_121f58205d8a416b813b31dd67b57f7b();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_121f58205d8a416b813b31dd67b57f7b();
            }
</script>
*)

