(**
// can't yet format YamlFrontmatter (["title: Contour carpet plots"; "category: Carpet Plots"; "categoryindex: 12"; "index: 2"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# Contour carpet charts

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=11_2_contourcarpet_plots.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/11_2_contourcarpet_plots.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/11_2_contourcarpet_plots.ipynb)

*Summary:* This example shows how to create contour plots on carpets in F#.


*)
open Plotly.NET
open Plotly.NET.LayoutObjects

let contourCarpet = 
    [
        Chart.Carpet(
            "contour",
            A = [0.; 1.; 2.; 3.; 0.; 1.; 2.; 3.; 0.; 1.; 2.; 3.],
            B = [4.; 4.; 4.; 4.; 5.; 5.; 5.; 5.; 6.; 6.; 6.; 6.],
            X = [2.; 3.; 4.; 5.; 2.2; 3.1; 4.1; 5.1; 1.5; 2.5; 3.5; 4.5],
            Y = [1.; 1.4; 1.6; 1.75; 2.; 2.5; 2.7; 2.75; 3.; 3.5; 3.7; 3.75],
            AAxis = LinearAxis.initCarpet(
                TickPrefix = "a = ",
                Smoothing = 0.,
                MinorGridCount = 9,
                AxisType = StyleParam.AxisType.Linear
            ),
            BAxis = LinearAxis.initCarpet(
                TickPrefix = "b = ",
                Smoothing = 0.,
                MinorGridCount = 9,
                AxisType = StyleParam.AxisType.Linear
            ), 
            UseDefaults = false,
            Opacity = 0.75
        )    
        Chart.ContourCarpet(
            [1.; 1.96; 2.56; 3.0625; 4.; 5.0625; 1.; 7.5625; 9.; 12.25; 15.21; 14.0625],
            "contour",
            A = [0; 1; 2; 3; 0; 1; 2; 3; 0; 1; 2; 3],
            B = [4; 4; 4; 4; 5; 5; 5; 5; 6; 6; 6; 6], 
            UseDefaults = false,
            ContourLineColor = Color.fromKeyword White,
            ShowContourLabels = true
        )
    ]
    |> Chart.combine(* output: 
<div id="033b2552-95c5-4542-bba5-f596ca71a663"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_033b255295c54542bba5f596ca71a663 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.6.3.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"carpet","opacity":0.75,"x":[2.0,3.0,4.0,5.0,2.2,3.1,4.1,5.1,1.5,2.5,3.5,4.5],"y":[1.0,1.4,1.6,1.75,2.0,2.5,2.7,2.75,3.0,3.5,3.7,3.75],"a":[0.0,1.0,2.0,3.0,0.0,1.0,2.0,3.0,0.0,1.0,2.0,3.0],"b":[4.0,4.0,4.0,4.0,5.0,5.0,5.0,5.0,6.0,6.0,6.0,6.0],"aaxis":{"type":"linear","tickprefix":"a = ","minorgridcount":9,"smoothing":0.0},"baxis":{"type":"linear","tickprefix":"b = ","minorgridcount":9,"smoothing":0.0},"carpet":"contour"},{"type":"contourcarpet","z":[1.0,1.96,2.56,3.0625,4.0,5.0625,1.0,7.5625,9.0,12.25,15.21,14.0625],"a":[0,1,2,3,0,1,2,3,0,1,2,3],"b":[4,4,4,4,5,5,5,5,6,6,6,6],"line":{"color":"rgba(255, 255, 255, 1.0)"},"carpet":"contour","contours":{"showlabels":true}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('033b2552-95c5-4542-bba5-f596ca71a663', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_033b255295c54542bba5f596ca71a663();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_033b255295c54542bba5f596ca71a663();
            }
</script>
*)

