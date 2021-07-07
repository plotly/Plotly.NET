(**
// can't yet format YamlFrontmatter (["title: 3D line charts"; "category: 3D Charts"; "categoryindex: 4"; "index: 2"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# 3D line charts

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=3_1_3d-line-plots.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/3_1_3d-line-plots.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/3_1_3d-line-plots.ipynb)

*Summary:* This example shows how to create three-dimensional scatter charts in F#.

let's first create some data for the purpose of creating example charts:
*)
open Plotly.NET 
open System
 
let c = [0. .. 0.5 .. 15.]

let x,y,z =  
    c
    |> List.map (fun i ->
        let i' = float i 
        let r = 10. * Math.Cos (i' / 10.)
        (r*Math.Cos i',r*Math.Sin i',i')
    )
    |> List.unzip3
(**
A Scatter3 chart shows a three-dimensional spinnable view of your data.
When using `Lines_Markers` as the mode of the chart, you additionally render a line between the points:
*)
let scatter3dLine = 
    Chart.Scatter3d(x,y,z,StyleParam.Mode.Lines_Markers)
    |> Chart.withX_AxisStyle("x-axis")
    |> Chart.withY_AxisStyle("y-axis")
    |> Chart.withZ_AxisStyle("z-axis")
    |> Chart.withSize(800.,800.)(* output: 
<div id="db2268b2-d3e9-44f1-a126-231804166541" style="width: 800px; height: 800px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_db2268b2d3e944f1a126231804166541 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter3d","x":[10.0,8.764858122060915,5.3760304484812105,0.699428991431538,-4.078516059742164,-7.762380006776013,-9.457759559629629,-8.796818588044248,-6.020456431562834,-1.8981046678556164,2.4893698743024015,6.041583606256742,7.924627339505819,7.774455867055686,5.766162492106399,2.5362920361842747,-1.0137084976470045,-3.9731770939413367,-5.663676531805762,-5.800381805436716,-4.533522819483132,-2.3661340757417872,0.020074794419808174,1.9742392407015044,3.0577702559255746,3.1462811058452385,2.427409510770794,1.302916035546942,0.23240834306912295,-0.42769357063721014,-0.5373819709641076],"y":[0.0,4.788263815209447,8.372671348444594,9.862941931402888,8.911720173488927,5.798670944701264,1.3481709304529075,-3.2951619221615798,-6.970612585921842,-8.802141619140079,-8.415352216177444,-6.014904288506064,-2.306115620213046,1.7125353726077581,5.024910671806752,6.86324142009979,6.892925283704576,5.269880365378672,2.561769585348826,-0.43714135926897707,-2.9393586065447344,-4.37711141115013,-4.535916791549611,-3.576112184549465,-1.9443135767963393,-0.2091277735131711,1.123941901777903,1.7603416439605064,1.6837070198341995,1.1265744325858227,0.4599954209124893],"z":[0.0,0.5,1.0,1.5,2.0,2.5,3.0,3.5,4.0,4.5,5.0,5.5,6.0,6.5,7.0,7.5,8.0,8.5,9.0,9.5,10.0,10.5,11.0,11.5,12.0,12.5,13.0,13.5,14.0,14.5,15.0],"mode":"lines+markers","line":{},"marker":{}}];
            var layout = {"scene":{"xaxis":{"title":"x-axis"},"yaxis":{"title":"y-axis"},"zaxis":{"title":"z-axis"}},"width":800.0,"height":800.0};
            var config = {};
            Plotly.newPlot('db2268b2-d3e9-44f1-a126-231804166541', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_db2268b2d3e944f1a126231804166541();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_db2268b2d3e944f1a126231804166541();
            }
</script>
*)

