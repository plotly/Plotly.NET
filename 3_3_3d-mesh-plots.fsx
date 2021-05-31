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
<div id="3661c43c-fb92-4984-be34-f5c1bebdcbce" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_3661c43cfb924984be34f5c1bebdcbce = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"mesh3d","x":[0.8521814839226107,0.19914336837788268,0.4172228469593557,0.5635192322374877,0.3837226188665827,0.9700197870703506,0.22305888925821468,0.4012926618574619,0.8200687108654848,0.47962667396274705,0.7165210436640871,0.01770254365061528,0.5742988966285711,0.45520294059775906,0.022816817752465985,0.3019884425690344,0.35613266814320005,0.9001098656561737,0.6042625492458523,0.5109219171623336,0.21276518526150154,0.7770693003093215,0.7155045758539367,0.09659987320033828,0.9454655791378885,0.5543890747029283,0.41238668114523713,0.9709526151283423,0.49241748288852044,0.7302215438011203,0.1093818941662935,0.8608417631410257,0.8094043311706764,0.14314483159368152,0.4887916336249521,0.9189846408176164,0.7405180995075582,0.9168221074700459,0.17075998018065466,0.47616398403242416,0.1019734936309855,0.8519155298601443,0.17532163121519687,0.33977595453140136,0.8302921284131204,0.47663372358150485,0.06055967419434324,0.5392637278601824,0.752341357410113,0.14671161591387893],"y":[0.013862811501074029,0.6280011453796184,0.23747425164909766,0.4337848017149534,0.7959528825226951,0.07511218361328924,0.48363879252394604,0.3206229737590174,0.6180536530995991,0.8293335441636543,0.5576331059251135,0.25210627412987235,0.9088751789689414,0.08984716706436462,0.37024477979645354,0.8556792805230614,0.20829821247993885,0.4311540650348896,0.966411306972807,0.10383217693484956,0.5614703430614761,0.4393105606731542,0.729349885475519,0.12809856521342813,0.4089484235313481,0.36084965540135727,0.6017476690941247,0.37572862132253526,0.2663077447872179,0.4688318555563837,0.4938294005085851,0.8731229532850547,0.2186112577182293,0.3457058669746415,0.7163587323000462,0.48138074878667514,0.623367511491928,0.375619529455723,0.3471919490709863,0.4136794500116629,0.4353458482936704,0.4198951257485408,0.2987684543704467,0.34142643601700035,0.9185308781073107,0.8498672195011131,0.9430403508912029,0.08547446415083225,0.9695311747349478,0.974612847890059],"z":[0.268335511101566,0.6294056091594535,0.5728524208873754,0.6485091804752635,0.5852412728524028,0.5745522508279198,0.8986512599040993,0.10937568643566951,0.024836378183605325,0.43510322712133787,0.47336451451916456,0.10791017120141078,0.054315228971799474,0.14922179754321546,0.33550414365506925,0.6845101526400588,0.033495016411643014,0.5631693119942999,0.37348843476431837,0.8888640310097784,0.2323117690311334,0.8326786830242159,0.08396211596390331,0.552731856961144,0.6684863286411792,0.14157521731293538,0.1405421063027075,0.38792344945851875,0.20956768710611745,0.559081204030235,0.4178093045101544,0.5162732049432924,0.40619744658758744,0.291694896897159,0.20049634445481762,0.8644237913491315,0.3002705323976793,0.5701020772429658,0.7604645941222388,0.14180648147212643,0.5827294888825759,0.5139918250562585,0.3507831512721177,0.9120887219496484,0.9403149354924983,0.3274356770922596,0.3655798967767413,0.14954665682723126,0.00592229236193108,0.23402072546725194],"flatshading":true,"contour":{"x":{"show":true},"y":{"show":true},"z":{"show":true}}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('3661c43c-fb92-4984-be34-f5c1bebdcbce', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_3661c43cfb924984be34f5c1bebdcbce();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_3661c43cfb924984be34f5c1bebdcbce();
            }
</script>
*)

