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
<div id="6364f458-f596-4847-9ecc-0808d5488bc8" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_6364f458f59648479ecc0808d5488bc8 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"mesh3d","x":[0.06255405771664999,0.07359451804011805,0.2297300385449687,0.48141526453262906,0.22583391527916952,0.7756620835399545,0.5676097113488288,0.9685649429301568,0.8294928128968425,0.21572307088213186,0.9432514430690796,0.2673516065195909,0.6816237991124502,0.3427053109475902,0.5398653031046806,0.5393095489308748,0.7017055860262856,0.7810369989746423,0.618463419200137,0.9895258741404516,0.4190945035866902,0.7458350601353846,0.07248673917375818,0.3711494972795013,0.2875969509070725,0.5538804594212586,0.20509019503606957,0.35355697914657974,0.7045073479900636,0.4570323650059441,0.3524950842151861,0.46108697702227486,0.4123487404605135,0.6618055383031283,0.02482929128447049,0.7850952911121283,0.5710370994969444,0.8087445533875118,0.050291314278864914,0.5983554062425882,0.4081846044436957,0.32334947601116704,0.7595836453882902,0.6898476568469069,0.29327112356818796,0.4802467918397145,0.9855944677188967,0.07924347374553023,0.2621530747330529,0.909683445426488],"y":[0.04926291110425392,0.23380765655720964,0.5974913866247477,0.8586132642154644,0.9848841088753585,0.3167189975812654,0.001107778866359861,0.8585805412654675,0.19381831362555657,0.6719534558579109,0.5705718885038848,0.214052732202249,0.2640575949400932,0.37246044789089844,0.8632279866669458,0.4821644660468048,0.8550028660590774,0.01981826080932201,0.3178760196631197,0.7547700119925523,0.9682724494339304,0.8929610326387738,0.7307456846957774,0.02010801295754873,0.5813412696967559,0.09574502757552314,0.9862514147470944,0.38263908232685134,0.0778783737113133,0.807350159067358,0.5682859917023619,0.12584672129053937,0.09140390441352683,0.7948239025635756,0.40776945390169017,0.11868742765797648,0.8635955903975272,0.5537354762450492,0.6769214294277697,0.7081102937032051,0.7839875122457685,0.7124565582314769,0.6149262397619553,0.378337858420954,0.027783517738703415,0.19413187224144668,0.05929188107107388,0.3871231974973917,0.8266196701799611,0.8111066575213832],"z":[0.6252439257806371,0.9657762069095747,0.7613674540824106,0.5073830627405006,0.9414109959925576,0.1563018784654801,0.5030619718614323,0.5773833736671988,0.27727199451870843,0.8891390812998354,0.33046758283417094,0.6184686965395085,0.7807021675541541,0.3864681545581986,0.10366746415554894,0.4447251672133455,0.12264882778872216,0.4692336923765176,0.9646909939892082,0.7445405590089692,0.6185688756492775,0.30126738981402823,0.3428968313815523,0.6097657259599146,0.9707824997467839,0.25581589120245346,0.2780347928768186,0.3524078262748233,0.9923244952188454,0.38720939745530925,0.03645314650444926,0.5991282172497028,0.5560194121468902,0.26677171618993006,0.18210623328672082,0.6025097847927873,0.36447926720812884,0.5840208416730263,0.853412906571018,0.25146757543621007,0.6156254557965442,0.2862122167303284,0.2764634817263407,0.7877823481279344,0.37764271086903417,0.16551881570625995,0.9317543906773228,0.22845808520375663,0.27467039426540507,0.5830583505253579],"flatshading":true,"contour":{"x":{"show":true},"y":{"show":true},"z":{"show":true}}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('6364f458-f596-4847-9ecc-0808d5488bc8', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_6364f458f59648479ecc0808d5488bc8();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_6364f458f59648479ecc0808d5488bc8();
            }
</script>
*)

