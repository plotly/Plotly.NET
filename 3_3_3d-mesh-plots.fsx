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
<div id="83bfd8e0-1ebb-4e2c-83e9-07877866533d" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_83bfd8e01ebb4e2c83e907877866533d = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"mesh3d","x":[0.7041359584332145,0.002591059078737655,0.023236517339589317,0.6740079911770336,0.3902401227458567,0.2095021667003176,0.33494149117495003,0.49057399737209734,0.6870371842230844,0.8723256857471194,0.9846831546093724,0.9695349796533281,0.7055497014455263,0.11195358406377658,0.41422678828901927,0.7312995231390463,0.7471347436062687,0.4297595589560268,0.8809372414280369,0.2999455986078575,0.7420500948755304,0.4799479695409294,0.10656424477070768,0.8313092881959441,0.6495380572274039,0.2270857404112284,0.4210017954097138,0.2620184911703777,0.9136191284813076,0.1399532617721489,0.9782457388836172,0.4870534937302831,0.6788820534380535,0.8545611965724086,0.05960495027695081,0.5443445171901697,0.26519722410719715,0.5755378275995785,0.09657211792495667,0.9205314889180155,0.9777443180688398,0.8560091819874985,0.04519767176601927,0.6078523707612662,0.70702331266693,0.9360014716796584,0.6752367148526184,0.013665264478728765,0.2474140870605661,0.5055752776123468],"y":[0.8251275521820074,0.09518473320416396,0.014378005645413885,0.5797053163776664,0.6750804584822993,0.22418798889228514,0.89602681430803,0.19192722914364527,0.024469933949629746,0.1631543823346283,0.7885003712906038,0.07292300000457233,0.5769548688907897,0.5470839224509354,0.8940799468635022,0.49762966087908933,0.29065292621527467,0.8509885048731176,0.052348633786825756,0.8698822710988495,0.46610229903184913,0.17159691600669033,0.3331874410310702,0.9604057525100214,0.32220128053901775,0.8860409128880319,0.43475029777491014,0.4987118740094415,0.12428597552901412,0.7135365855477455,0.55184902555861,0.407336530930985,0.014604404109811599,0.4080438508689608,0.3148257095901415,0.8830610056794532,0.4726754880848692,0.09917673706038703,0.17948073809010942,0.8354169613846657,0.6483177028821399,0.07326999496355187,0.5510678936499487,0.9334177355903284,0.13203111762741168,0.9048213180642675,0.27905431309670875,0.49811374931508384,0.713772423897764,0.2093936517878406],"z":[0.6453485454643837,0.8242482099795008,0.961316630691903,0.3775318159617166,0.03947297858049766,0.653530636175317,0.7619972921730938,0.05397225313539256,0.25750403583864867,0.7890395455942674,0.789437691117375,0.39731494029858844,0.06764125361463114,0.31093334840188425,0.6113053567760184,0.3811638403596188,0.05831859589476073,0.16891101802182898,0.2322582128607939,0.011018941184048978,0.024954172794220117,0.19147618915488765,0.6715077667830083,0.2169316724021601,0.2215645682167097,0.3928323040682973,0.6205290223567416,0.3997697054407418,0.8283746348826097,0.41737996247475034,0.6069865997913231,0.9366365484598262,0.7849394501116777,0.9148923237411736,0.06818804008336181,0.7276008155791093,0.446019900239082,0.637072588148095,0.36857087228846314,0.6612950734148245,0.12106371350635947,0.41870323494947664,0.8416727012217383,0.3904411924958421,0.04597927026729066,0.25100276258355136,0.005628741348920736,0.24013454524806446,0.32211237881431,0.7508672772677929],"flatshading":true,"contour":{"x":{"show":true},"y":{"show":true},"z":{"show":true}}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('83bfd8e0-1ebb-4e2c-83e9-07877866533d', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_83bfd8e01ebb4e2c83e907877866533d();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_83bfd8e01ebb4e2c83e907877866533d();
            }
</script>
*)

