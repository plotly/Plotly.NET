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
<div id="7a08f145-29dd-4ed9-9b30-a8722a4cfc72" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_7a08f14529dd4ed99b30a8722a4cfc72 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"mesh3d","x":[0.6309743601041726,0.2682259866354177,0.5199531631171486,0.4250364394043742,0.41045214068631275,0.31754197753851393,0.11866900376913557,0.7633721426890102,0.8269237889102306,0.881614095010615,0.625386587169667,0.8143152104757332,0.5113139392395103,0.23692551266258838,0.5800166947674084,0.5016639495741874,0.34229440723652693,0.7362387584225455,0.6871870321627646,0.10466006729037504,0.9787927139451693,0.7221032105023522,0.4628950750748138,0.5465089467105032,0.8707779738450321,0.8154829166901684,0.07026341653906899,0.226742281218405,0.33950630544661836,0.7150320889032595,0.3758191477394752,0.9007909893527585,0.0570905618635428,0.6417055654533699,0.5104235706433764,0.4487305527779882,0.1019504406032853,0.5726402865595371,0.07481451149788429,0.33783104565824895,0.60070291701737,0.12420255091237023,0.40194933507682257,0.09562119939160589,0.3524426740372752,0.4195608694197428,0.006645866672809173,0.37561795784887764,0.19060422535548183,0.02388383542368367],"y":[0.6299136204784334,0.8058379747932022,0.7664218841895563,0.9711136375419394,0.2633517492857537,0.9088711496018205,0.8053309115606039,0.9734442164066454,0.5542584655593421,0.5949692239961444,0.24727856099944495,0.8919267225507306,0.4238658372423918,0.11189170000697099,0.5057949472711398,0.7245955978169085,0.7572246486121903,0.8696083737861404,0.726501942019212,0.13128614198942024,0.3997135089709021,0.7696541206769897,0.6614242469246612,0.3493559865045156,0.503957150273005,0.8545901630327991,0.3201538754255296,0.36727387568320796,0.19406627267322796,0.45121710442528923,0.8088370500173592,0.6946454586901913,0.03613805586292318,0.3156224700229347,0.08511846842482615,0.5699811729462729,0.13436910516320222,0.08597692432160346,0.3783538161676162,0.6015524210415559,0.6433996412173844,0.12850622419663996,0.018381821000195024,0.47984528750173994,0.09055248465880401,0.7087761944666394,0.7003367136699784,0.2900576350698516,0.5898262521204661,0.6278470762203667],"z":[0.6623362208075524,0.13703749288666878,0.6491160158296656,0.0593180833660616,0.6241703264527816,0.8602594998014437,0.144413727868541,0.41706589768504065,0.4671564872689343,0.4087615862529546,0.5887172741762908,0.4380570358773959,0.7793779437334174,0.1030413611340529,0.7861321739787851,0.5526331023092536,0.8557886666878074,0.10824336721945711,0.026773231582144848,0.9358137743248668,0.5902264926537063,0.6712477242905869,0.4912545576185242,0.12494952097765613,0.48788650077203594,0.27120728477426215,0.7512722996767947,0.18157895942292127,0.2588035018457116,0.7951809558063657,0.15425344936282068,0.030096240355678015,0.7774476235627419,0.5662191964528612,0.7888808836177368,0.6717995571306905,0.04552944286052577,0.9768199724968616,0.691452143570153,0.22485896862338248,0.4255674450777319,0.7173032074781616,0.6188204370526692,0.9695922299146617,0.012835146865265046,0.2053426053399884,0.34912828046322253,0.9153404598661421,0.6937131135229548,0.5379193823495504],"flatshading":true,"contour":{"x":{"show":true},"y":{"show":true},"z":{"show":true}}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('7a08f145-29dd-4ed9-9b30-a8722a4cfc72', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_7a08f14529dd4ed99b30a8722a4cfc72();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_7a08f14529dd4ed99b30a8722a4cfc72();
            }
</script>
*)

