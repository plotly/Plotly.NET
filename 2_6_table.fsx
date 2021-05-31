(**
// can't yet format YamlFrontmatter (["title: Tables"; "category: Simple Charts"; "categoryindex: 3"; "index: 7"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# Tables

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=2_6_table.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/2_6_table.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/2_6_table.ipynb)

This example shows how to create tables in F#.

let's first create some data for the purpose of creating example charts:

*)
open Plotly.NET 
open Plotly.NET.StyleParam
  
let header = ["<b>RowIndex</b>";"A";"simple";"table"]
let rows = 
    [
     ["0";"I"     ;"am"     ;"a"]        
     ["1";"little";"example";"!"]       
    ]


let table1 = Chart.Table(header, rows)(* output: 
<div id="912c544a-3e34-44db-8ec4-7cdc6db005c5" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_912c544a3e3444db8ec47cdc6db005c5 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"table","header":{"values":["<b>RowIndex</b>","A","simple","table"]},"cells":{"values":[["0","1"],["I","little"],["am","example"],["a","!"]]}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('912c544a-3e34-44db-8ec4-7cdc6db005c5', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_912c544a3e3444db8ec47cdc6db005c5();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_912c544a3e3444db8ec47cdc6db005c5();
            }
</script>
*)
(**
A little bit of styling:
*)
let table2 =
    Chart.Table(
        header,
        rows,
        //sets global header alignment
        AlignHeader = [HorizontalAlign.Center],
        //sets alignment for each column separately 
        //(The last alignment is applied to all potential following columns)
        AlignCells  = [HorizontalAlign.Left;HorizontalAlign.Center;HorizontalAlign.Right],
        //sets global header color
        ColorHeader = "#45546a",    
        //sets specific color to each header column
        //ColorHeader=["#45546a";"#deebf7";"#45546a";"#deebf7"],    
        //sets global cell color
        //ColorRows = "#deebf7",
        //sets cell column colors
        ColorCells  = ["#deebf7";"lightgrey";"#deebf7";"lightgrey"],
        //sets cell row colors
        //ColorCells=[["#deebf7";"lightgrey"]],
        //sets font of header
        FontHeader  = Font.init(FontFamily.Courier_New, Size=12., Color="white"),      
        //sets the height of the header
        HeightHeader= 30.,
        //sets lines of header
        LineHeader  = Line.init(2.,"black"),                     
        ColumnWidth = [70;50;100;70],      
        //defines order of columns
        ColumnOrder = [1;2;3;4]                                  
        )(* output: 
<div id="853f4ae3-902a-4e88-b9e0-7f0f0a8fa0b2" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_853f4ae3902a4e88b9e07f0f0a8fa0b2 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"table","header":{"values":["<b>RowIndex</b>","A","simple","table"],"align":["center"],"height":30.0,"fill":{"color":"#45546a"},"line":{"color":"black","width":2.0},"font":{"family":"Courier New","size":12.0,"color":"white"}},"cells":{"values":[["0","1"],["I","little"],["am","example"],["a","!"]],"align":["left","center","right"],"fill":{"color":["#deebf7","lightgrey","#deebf7","lightgrey"]}},"columnwidth":[70,50,100,70],"columnorder":[1,2,3,4]}];
            var layout = {};
            var config = {};
            Plotly.newPlot('853f4ae3-902a-4e88-b9e0-7f0f0a8fa0b2', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_853f4ae3902a4e88b9e07f0f0a8fa0b2();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_853f4ae3902a4e88b9e07f0f0a8fa0b2();
            }
</script>
*)
(**
Value dependent cell coloring:
*)
let header2 = ["Identifier";"T0";"T1";"T2";"T3"]
let rowvalues = 
    [
     [10001.;0.2;2.0;4.0;5.0]
     [10002.;2.1;2.0;1.8;2.1]
     [10003.;4.5;3.0;2.0;2.5]
     [10004.;0.0;0.1;0.3;0.2]
     [10005.;1.0;1.6;1.8;2.2]
     [10006.;1.0;0.8;1.5;0.7]
     [10007.;2.0;2.0;2.1;1.9]
    ]
    |> Seq.sortBy (fun x -> x.[1])

//map color from value to hex representation
let mapColor min max value = 
    let proportion = 
        (255. * (value - min) / (max - min))
        |> int
    Colors.fromRgb 255 (255 - proportion) proportion
    |> Colors.toWebColor
    
//Assign a color to every cell seperately. Matrix must be transposed for correct orientation.
let cellcolor = 
     rowvalues
     |> Seq.map (fun row ->
        row 
        |> Seq.mapi (fun index value -> 
            if index = 0 then "white"
            else mapColor 0. 5. value
            )
        )
    |> Seq.transpose

let table3 = Chart.Table(header2,rowvalues,ColorCells=cellcolor)(* output: 
<div id="e9ff8d3c-5495-4f22-92c1-a20eb617086e" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_e9ff8d3c54954f2292c1a20eb617086e = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"table","header":{"values":["Identifier","T0","T1","T2","T3"]},"cells":{"values":[[10004.0,10001.0,10005.0,10006.0,10007.0,10002.0,10003.0],[0.0,0.2,1.0,1.0,2.0,2.1,4.5],[0.1,2.0,1.6,0.8,2.0,2.0,3.0],[0.3,4.0,1.8,1.5,2.1,1.8,2.0],[0.2,5.0,2.2,0.7,1.9,2.1,2.5]],"fill":{"color":[["white","white","white","white","white","white","white"],["#FFFF00","#FFF50A","#FFCC33","#FFCC33","#FF9966","#FF946B","#FF1AE5"],["#FFFA05","#FF9966","#FFAE51","#FFD728","#FF9966","#FF9966","#FF6699"],["#FFF00F","#FF33CC","#FFA45B","#FFB34C","#FF946B","#FFA45B","#FF9966"],["#FFF50A","#FF00FF","#FF8F70","#FFDC23","#FF9F60","#FF946B","#FF807F"]]}}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('e9ff8d3c-5495-4f22-92c1-a20eb617086e', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_e9ff8d3c54954f2292c1a20eb617086e();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_e9ff8d3c54954f2292c1a20eb617086e();
            }
</script>
*)
(**
Sequence representation:

*)
let sequence =
        [
        "ATGAGACGTCGAGACTGATAGACGTCGATAGACGTCGATAGACCG"
        "ATAGACTCGTGATAGACGTCGATAGACGTCGATAGAGTATAGACC"
        "GTGATAGACGTCGAGAAGACGTCGATAGACGTCGATAGACGTCGA"
        "TAGAGATAGACGTCGATAGACCGTATAGAAGACGTCGATAGATAG"
        "ACGTCGATAGACCGTAGACGTCGATAGACGTCGATAGACCGT"
        ]
        |> String.concat ""

let elementsPerRow = 60

let headers = 
    [0..elementsPerRow] 
    |> Seq.map (fun x -> 
        if x%10=0 && x <> 0 then "|" 
        else ""
        )

let cells = 
    sequence
    |> Seq.chunkBySize elementsPerRow
    |> Seq.mapi (fun i x -> Seq.append [string (i * elementsPerRow)] (Seq.map string x))

let cellcolors =
    cells
    |> Seq.map (fun row -> 
        row 
        |> Seq.map (fun element -> 
            match element with
            //colors taken from DRuMS 
            //(http://biomodel.uah.es/en/model4/dna/atgc.htm)
            | "A" -> "#5050FF" 
            | "T" -> "#E6E600"
            | "G" -> "#00C000"
            | "C" -> "#E00000"
            | "U" -> "#B48100"
            | _   -> "white"
            )
        )
    |> Seq.transpose
    |> Seq.map (fun x -> Seq.append x (seq ["white"]))

let font = Font.init(FontFamily.Consolas,Size=14.)
let line = Line.init(0.,"white")
let chartwidth = 50. + 10. * float elementsPerRow

let table4 =
    Chart.Table(
        headers,
        cells,
        LineCells   = line,
        LineHeader  = line,
        HeightCells = 20.,
        FontHeader  = font,
        FontCells   = font,
        ColumnWidth = [50;10],
        AlignCells  = [HorizontalAlign.Right;HorizontalAlign.Center],
        ColorCells  = cellcolors
        )
    |> Chart.withSize(chartwidth,nan)
    |> Chart.withTitle "Sequence A"(* output: 
<div id="04eb9105-a6a5-415a-9a72-53d3d270a4fd" style="width: 650px; height: NaNpx;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_04eb9105a6a5415a9a7253d3d270a4fd = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"table","header":{"values":["","","","","","","","","","","|","","","","","","","","","","|","","","","","","","","","","|","","","","","","","","","","|","","","","","","","","","","|","","","","","","","","","","|"],"line":{"color":"white","width":0.0},"font":{"family":"Consolas","size":14.0}},"cells":{"values":[["0","60","120","180"],["A","A","G","A"],["T","C","T","C"],["G","G","C","G"],["A","T","G","T"],["G","C","A","C"],["A","G","T","G"],["C","A","A","A"],["G","T","G","T"],["T","A","A","A"],["C","G","C","G"],["G","A","G","A"],["A","C","T","C"],["G","G","C","C"],["A","T","G","G"],["C","C","A","T"],["T","G","T","A"],["G","A","A","G"],["A","T","G","A"],["T","A","A","C"],["A","G","G","G"],["G","A","A","T"],["A","G","T","C"],["C","T","A","G"],["G","A","G","A"],["T","T","A","T"],["C","A","C","A"],["G","G","G","G"],["A","A","T","A"],["T","C","C","C"],["A","C","G","G"],["G","G","A","T"],["A","T","T","C"],["C","G","A","G"],["G","A","G","A"],["T","T","A","T"],["C","A","C","A"],["G","G","C","G"],["A","A","G","A"],["T","C","T","C"],["A","G","A","C"],["G","T","T","G"],["A","C","A","T"],["C","G","G"],["C","A","A"],["G","G","A"],["A","A","G"],["T","A","A"],["A","G","C"],["G","A","G"],["A","C","T"],["C","G","C"],["T","T","G"],["C","C","A"],["G","G","T"],["T","A","A"],["G","T","G"],["A","A","A"],["T","G","T"],["A","A","A"],["G","C","G"]],"align":["right","center"],"height":20.0,"fill":{"color":[["white","white","white","white","white"],["#5050FF","#5050FF","#00C000","#5050FF","white"],["#E6E600","#E00000","#E6E600","#E00000","white"],["#00C000","#00C000","#E00000","#00C000","white"],["#5050FF","#E6E600","#00C000","#E6E600","white"],["#00C000","#E00000","#5050FF","#E00000","white"],["#5050FF","#00C000","#E6E600","#00C000","white"],["#E00000","#5050FF","#5050FF","#5050FF","white"],["#00C000","#E6E600","#00C000","#E6E600","white"],["#E6E600","#5050FF","#5050FF","#5050FF","white"],["#E00000","#00C000","#E00000","#00C000","white"],["#00C000","#5050FF","#00C000","#5050FF","white"],["#5050FF","#E00000","#E6E600","#E00000","white"],["#00C000","#00C000","#E00000","#E00000","white"],["#5050FF","#E6E600","#00C000","#00C000","white"],["#E00000","#E00000","#5050FF","#E6E600","white"],["#E6E600","#00C000","#E6E600","#5050FF","white"],["#00C000","#5050FF","#5050FF","#00C000","white"],["#5050FF","#E6E600","#00C000","#5050FF","white"],["#E6E600","#5050FF","#5050FF","#E00000","white"],["#5050FF","#00C000","#00C000","#00C000","white"],["#00C000","#5050FF","#5050FF","#E6E600","white"],["#5050FF","#00C000","#E6E600","#E00000","white"],["#E00000","#E6E600","#5050FF","#00C000","white"],["#00C000","#5050FF","#00C000","#5050FF","white"],["#E6E600","#E6E600","#5050FF","#E6E600","white"],["#E00000","#5050FF","#E00000","#5050FF","white"],["#00C000","#00C000","#00C000","#00C000","white"],["#5050FF","#5050FF","#E6E600","#5050FF","white"],["#E6E600","#E00000","#E00000","#E00000","white"],["#5050FF","#E00000","#00C000","#00C000","white"],["#00C000","#00C000","#5050FF","#E6E600","white"],["#5050FF","#E6E600","#E6E600","#E00000","white"],["#E00000","#00C000","#5050FF","#00C000","white"],["#00C000","#5050FF","#00C000","#5050FF","white"],["#E6E600","#E6E600","#5050FF","#E6E600","white"],["#E00000","#5050FF","#E00000","#5050FF","white"],["#00C000","#00C000","#E00000","#00C000","white"],["#5050FF","#5050FF","#00C000","#5050FF","white"],["#E6E600","#E00000","#E6E600","#E00000","white"],["#5050FF","#00C000","#5050FF","#E00000","white"],["#00C000","#E6E600","#E6E600","#00C000","white"],["#5050FF","#E00000","#5050FF","#E6E600","white"],["#E00000","#00C000","#00C000","white"],["#E00000","#5050FF","#5050FF","white"],["#00C000","#00C000","#5050FF","white"],["#5050FF","#5050FF","#00C000","white"],["#E6E600","#5050FF","#5050FF","white"],["#5050FF","#00C000","#E00000","white"],["#00C000","#5050FF","#00C000","white"],["#5050FF","#E00000","#E6E600","white"],["#E00000","#00C000","#E00000","white"],["#E6E600","#E6E600","#00C000","white"],["#E00000","#E00000","#5050FF","white"],["#00C000","#00C000","#E6E600","white"],["#E6E600","#5050FF","#5050FF","white"],["#00C000","#E6E600","#00C000","white"],["#5050FF","#5050FF","#5050FF","white"],["#E6E600","#00C000","#E6E600","white"],["#5050FF","#5050FF","#5050FF","white"],["#00C000","#E00000","#00C000","white"]]},"line":{"color":"white","width":0.0},"font":{"family":"Consolas","size":14.0}},"columnwidth":[50,10]}];
            var layout = {"width":650.0,"height":"NaN","title":"Sequence A"};
            var config = {};
            Plotly.newPlot('04eb9105-a6a5-415a-9a72-53d3d270a4fd', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_04eb9105a6a5415a9a7253d3d270a4fd();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_04eb9105a6a5415a9a7253d3d270a4fd();
            }
</script>
*)

