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
<div id="2a7fe4e7-e546-4ae3-8da5-67137b3966bd" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_2a7fe4e7e5464ae38da567137b3966bd = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"mesh3d","x":[0.42965366664792115,0.14123616048192428,0.5816186860118149,0.04586821750079664,0.9289861642424884,0.8455451125491155,0.6479097486696717,0.30232260110896203,0.9707036209156288,0.4353489146732487,0.38206365955158306,0.7066889012729232,0.7933092414370315,0.9387151617271431,0.583330681819157,0.2711449834849429,0.6613510812918427,0.46326219312067246,0.7679278085790239,0.6947060053677792,0.3198879176377728,0.024048965435497914,0.9525391314889021,0.2959499635249143,0.542997708796988,0.44402419982665414,0.08223851773992112,0.6155291500573647,0.3366157106760031,0.1085119001141339,0.5479797695521171,0.17250477996305785,0.9782910328257322,0.6083572700658614,0.5772111739857174,0.3000065308529914,0.1448774114925775,0.4237501865363448,0.6979524924875947,0.47143040945354403,0.8410907703643156,0.01420910098320297,0.4613507541182222,0.1174760014365781,0.9099780972627821,0.4457766853486079,0.9409931665011649,0.47985211037092473,0.5938879473106414,0.6011510913265641],"y":[0.6334219671010142,0.03069525679140131,0.9451539027249226,0.5238978529925914,0.8544687772423349,0.40560470121242326,0.18869702899302218,0.2856687224869005,0.5028705087038086,0.4849619644158343,0.7633065948091944,0.03238059861230692,0.9657068904329589,0.8621917208014949,0.8873691451211316,0.20955887958852523,0.728397868447191,0.18495197137117012,0.3615039877414256,0.28332415096616564,0.12626757199236543,0.237600894755498,0.7653097006330778,0.2964973991254798,0.8536152350034636,0.30567881665456986,0.5626982113172757,0.835063130052324,0.38597186626213226,0.09722102344838018,0.5030310333254892,0.6023864073689964,0.021641202746723407,0.735464619349439,0.4750899330131197,0.5172845127607157,0.22735087723813527,0.45439317983314076,0.7538884928235265,0.1716064727732942,0.11130950185996923,0.8592086890056769,0.9208796778325362,0.21299052807176044,0.7081238146443497,0.8087101717520087,0.04850221055024406,0.5991590333167273,0.23010685631544647,0.7004192176742569],"z":[0.7173788169014169,0.7560411951299949,0.11834812262949912,0.31056379634447573,0.4748835193341987,0.3958210723455162,0.26538555615832354,0.6486565035994428,0.6702826179891278,0.5487899605877651,0.8429064898951475,0.3536338989406982,0.8996968562247682,0.4056494852554284,0.9819309310903451,0.160920187440198,0.010739395865583512,0.2302422710835199,0.3871017877883752,0.37008463236041583,0.98220800235039,0.27400468861405025,0.43106347854764365,0.18989751496813145,0.17201464910619643,0.26705888298668845,0.31672121692296173,0.5523191725613174,0.5883735844811302,0.04490506325145488,0.2571766061043258,0.9635391780005484,0.6049562737368775,0.6855526485878753,0.37984220654696327,0.7469898381954942,0.4840382847394972,0.7110774064022477,0.2605811000152403,0.0792688606676035,0.25189895660239225,0.5786943736386925,0.784110561844013,0.2050985322357614,0.32869998287814667,0.757675602919271,0.9595118327809087,0.5152301925771079,0.23105959698141534,0.5472036272041516],"flatshading":true,"contour":{"x":{"show":true},"y":{"show":true},"z":{"show":true}}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('2a7fe4e7-e546-4ae3-8da5-67137b3966bd', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_2a7fe4e7e5464ae38da567137b3966bd();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_2a7fe4e7e5464ae38da567137b3966bd();
            }
</script>
*)

