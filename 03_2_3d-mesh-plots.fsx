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
<div id="f4004d99-a700-4189-92cb-46d981de3caa" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_f4004d99a700418992cb46d981de3caa = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"mesh3d","x":[0.5331660483652567,0.629523916463146,0.3377146107785937,0.8875942681392628,0.0531033515246135,0.04702351104795165,0.3812407326797213,0.7552787739575276,0.19277252405545325,0.040868364759193906,0.6222983592293683,0.9414782416734278,0.4258309143715682,0.935282274584883,0.8866071938009035,0.6260937450575147,0.03583798978283908,0.6944896442324341,0.5440493610427013,0.5923515984752922,0.7262458264484284,0.07899649538053037,0.8277913126292598,0.029201126671024192,0.9476595776843184,0.6381727525210813,0.23802680114192273,0.9968786821686098,0.9842545268983834,0.9103343444458835,0.6239628352336413,0.4689549014293379,0.2467457224832595,0.17468409434644697,0.9041796675437035,0.09073286880307499,0.3499078281921837,0.5603458204122008,0.1645037169402948,0.19884460614940366,0.17059698476018242,0.8476654690912299,0.6282700955068088,0.7786928293195985,0.021816508388992635,0.6598631193208803,0.870711486260738,0.5700365582341499,0.05959698374364385,0.9361376273148403],"y":[0.9757997384182177,0.9809876419515291,0.6097558092371355,0.005151146559580763,0.01096299756828835,0.4541695529847264,0.8017326038338861,0.30851348410756957,0.9399346904549444,0.41493059900353224,0.8089967099060289,0.38436205051111155,0.7710242470591442,0.2824381796095698,0.41690552952555265,0.15334345780003045,0.6947325191901682,0.25114682002512123,0.031102607041179484,0.7958743249978285,0.27618591686533106,0.47549216937063826,0.5299859272921392,0.34520475489329766,0.4217546137151097,0.8785803573571985,0.4507263998737216,0.04909848330966126,0.007384618282031556,0.28779645836343826,0.7674612662603433,0.6679902429077729,0.9372816984249659,0.048116899583543135,0.9345346060276658,0.6429751932821121,0.8591990921922024,0.24159457592367872,0.1637210967781586,0.4500101145589771,0.28900026496918885,0.041394344084614114,0.6204111299572564,0.7495731179367626,0.38984789624337474,0.7862349342490709,0.07664122203208563,0.34583191589723894,0.3617872997940459,0.8684730505889622],"z":[0.965130600130712,0.6195646662356168,0.5389339511929704,0.26372265874581535,0.6599517104495092,0.5003075690475793,0.45100171465938993,0.2645510543438378,0.583396532844471,0.1323826402110898,0.003443153111004808,0.7526341205242248,0.301128865825538,0.6521382320915061,0.647469332743189,0.14100646699825603,0.4470803520861456,0.722907347475601,0.347903573581904,0.7739303362434405,0.2941443656078281,0.45313794326648954,0.08742572324696263,0.5810924924822024,0.5068740600286397,0.23479157278071697,0.8550810394133819,0.7804128093553767,0.9553568586499229,0.6355196794660388,0.801939135325113,0.10489448397648264,0.6873111835156154,0.13891156769306937,0.32266585823272625,0.14789660002472652,0.1290562917148025,0.6735590396791505,0.38816518913403397,0.43422703698008647,0.1919734786227222,0.5946480378483646,0.6581980430792077,0.031338456567068795,0.4465669614479723,0.536366144444964,0.7402654782590761,0.9682728978657503,0.10210378519357359,0.2488414292451187],"flatshading":true,"contour":{"x":{"show":true},"y":{"show":true},"z":{"show":true}}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('f4004d99-a700-4189-92cb-46d981de3caa', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_f4004d99a700418992cb46d981de3caa();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_f4004d99a700418992cb46d981de3caa();
            }
</script>
*)

