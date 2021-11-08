(**
// can't yet format YamlFrontmatter (["title: Tables"; "category: Simple Charts"; "categoryindex: 3"; "index: 7"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# Tables

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=02_6_table.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/02_6_table.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/02_6_table.ipynb)

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
<div id="a36248c5-31aa-48ee-b2c9-80a7d3d1c266" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_a36248c531aa48eeb2c980a7d3d1c266 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"table","header":{"values":["<b>RowIndex</b>","A","simple","table"]},"cells":{"values":[["0","1"],["I","little"],["am","example"],["a","!"]]}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('a36248c5-31aa-48ee-b2c9-80a7d3d1c266', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_a36248c531aa48eeb2c980a7d3d1c266();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_a36248c531aa48eeb2c980a7d3d1c266();
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
        ColorHeader = Color.fromString "#45546a",    
        //sets specific color to each header column
        //ColorHeader=["#45546a";"#deebf7";"#45546a";"#deebf7"],    
        //sets global cell color
        //ColorRows = "#deebf7",
        //sets cell column colors
        ColorCells  = Color.fromColors [
            Color.fromString "#deebf7"
            Color.fromString "lightgrey"
            Color.fromString "#deebf7"
            Color.fromString "lightgrey"
        ],
        //sets cell row colors
        //ColorCells=[["#deebf7";"lightgrey"]],
        //sets font of header
        FontHeader  = Font.init(FontFamily.Courier_New, Size=12., Color=Color.fromString "white"),      
        //sets the height of the header
        HeightHeader= 30.,
        //sets lines of header
        LineHeader  = Line.init(2.,Color.fromString "black"),                     
        ColumnWidth = [70;50;100;70],      
        //defines order of columns
        ColumnOrder = [1;2;3;4]                                  
        )(* output: 
<div id="aa837275-a73f-4afa-89a0-e09281169d05" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_aa837275a73f4afa89a0e09281169d05 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"table","header":{"values":["<b>RowIndex</b>","A","simple","table"],"align":["center"],"height":30.0,"fill":{"color":"#45546a"},"line":{"color":"black","width":2.0},"font":{"family":"Courier New","size":12.0,"color":"white"}},"cells":{"values":[["0","1"],["I","little"],["am","example"],["a","!"]],"align":["left","center","right"],"fill":{"color":["#deebf7","lightgrey","#deebf7","lightgrey"]}},"columnwidth":[70,50,100,70],"columnorder":[1,2,3,4]}];
            var layout = {};
            var config = {};
            Plotly.newPlot('aa837275-a73f-4afa-89a0-e09281169d05', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_aa837275a73f4afa89a0e09281169d05();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_aa837275a73f4afa89a0e09281169d05();
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
    Color.fromRGB 255 (255 - proportion) proportion
    
//Assign a color to every cell seperately. Matrix must be transposed for correct orientation.
let cellcolor = 
     rowvalues
     |> Seq.map (fun row ->
        row 
        |> Seq.mapi (fun index value -> 
            if index = 0 then Color.fromString "white"
            else mapColor 0. 5. value
            )
        )
    |> Seq.transpose
    |> Seq.map Color.fromColors
    |> Color.fromColors

let table3 = Chart.Table(header2,rowvalues,ColorCells=cellcolor)(* output: 
<div id="3570495d-67b6-451e-8222-579a40ba7402" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_3570495d67b6451e8222579a40ba7402 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"table","header":{"values":["Identifier","T0","T1","T2","T3"]},"cells":{"values":[[10004.0,10001.0,10005.0,10006.0,10007.0,10002.0,10003.0],[0.0,0.2,1.0,1.0,2.0,2.1,4.5],[0.1,2.0,1.6,0.8,2.0,2.0,3.0],[0.3,4.0,1.8,1.5,2.1,1.8,2.0],[0.2,5.0,2.2,0.7,1.9,2.1,2.5]],"fill":{"color":[["white","white","white","white","white","white","white"],["rgba(255, 255, 0, 1.0)","rgba(255, 245, 10, 1.0)","rgba(255, 204, 51, 1.0)","rgba(255, 204, 51, 1.0)","rgba(255, 153, 102, 1.0)","rgba(255, 148, 107, 1.0)","rgba(255, 26, 229, 1.0)"],["rgba(255, 250, 5, 1.0)","rgba(255, 153, 102, 1.0)","rgba(255, 174, 81, 1.0)","rgba(255, 215, 40, 1.0)","rgba(255, 153, 102, 1.0)","rgba(255, 153, 102, 1.0)","rgba(255, 102, 153, 1.0)"],["rgba(255, 240, 15, 1.0)","rgba(255, 51, 204, 1.0)","rgba(255, 164, 91, 1.0)","rgba(255, 179, 76, 1.0)","rgba(255, 148, 107, 1.0)","rgba(255, 164, 91, 1.0)","rgba(255, 153, 102, 1.0)"],["rgba(255, 245, 10, 1.0)","rgba(255, 0, 255, 1.0)","rgba(255, 143, 112, 1.0)","rgba(255, 220, 35, 1.0)","rgba(255, 159, 96, 1.0)","rgba(255, 148, 107, 1.0)","rgba(255, 128, 127, 1.0)"]]}}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('3570495d-67b6-451e-8222-579a40ba7402', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_3570495d67b6451e8222579a40ba7402();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_3570495d67b6451e8222579a40ba7402();
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
            | "A" -> Color.fromHex "#5050FF" 
            | "T" -> Color.fromHex "#E6E600"
            | "G" -> Color.fromHex "#00C000"
            | "C" -> Color.fromHex "#E00000"
            | "U" -> Color.fromHex "#B48100"
            | _   -> Color.fromString "white"
            )
        )
    |> Seq.transpose
    |> Seq.map (fun x -> Seq.append x (seq [Color.fromString "white"]))
    |> Seq.map Color.fromColors
    |> Color.fromColors

let font = Font.init(FontFamily.Consolas,Size=14.)
let line = Line.init(0.,Color.fromString "white")
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
<div id="f47c410b-4386-443c-b7bb-166d6d80c630" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_f47c410b4386443cb7bb166d6d80c630 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"table","header":{"values":["","","","","","","","","","","|","","","","","","","","","","|","","","","","","","","","","|","","","","","","","","","","|","","","","","","","","","","|","","","","","","","","","","|"],"line":{"color":"white","width":0.0},"font":{"family":"Consolas","size":14.0}},"cells":{"values":[["0","60","120","180"],["A","A","G","A"],["T","C","T","C"],["G","G","C","G"],["A","T","G","T"],["G","C","A","C"],["A","G","T","G"],["C","A","A","A"],["G","T","G","T"],["T","A","A","A"],["C","G","C","G"],["G","A","G","A"],["A","C","T","C"],["G","G","C","C"],["A","T","G","G"],["C","C","A","T"],["T","G","T","A"],["G","A","A","G"],["A","T","G","A"],["T","A","A","C"],["A","G","G","G"],["G","A","A","T"],["A","G","T","C"],["C","T","A","G"],["G","A","G","A"],["T","T","A","T"],["C","A","C","A"],["G","G","G","G"],["A","A","T","A"],["T","C","C","C"],["A","C","G","G"],["G","G","A","T"],["A","T","T","C"],["C","G","A","G"],["G","A","G","A"],["T","T","A","T"],["C","A","C","A"],["G","G","C","G"],["A","A","G","A"],["T","C","T","C"],["A","G","A","C"],["G","T","T","G"],["A","C","A","T"],["C","G","G"],["C","A","A"],["G","G","A"],["A","A","G"],["T","A","A"],["A","G","C"],["G","A","G"],["A","C","T"],["C","G","C"],["T","T","G"],["C","C","A"],["G","G","T"],["T","A","A"],["G","T","G"],["A","A","A"],["T","G","T"],["A","A","A"],["G","C","G"]],"align":["right","center"],"height":20.0,"fill":{"color":[["white","white","white","white","white"],["rgba(80, 80, 255, 1.0)","rgba(80, 80, 255, 1.0)","rgba(0, 192, 0, 1.0)","rgba(80, 80, 255, 1.0)","white"],["rgba(230, 230, 0, 1.0)","rgba(224, 0, 0, 1.0)","rgba(230, 230, 0, 1.0)","rgba(224, 0, 0, 1.0)","white"],["rgba(0, 192, 0, 1.0)","rgba(0, 192, 0, 1.0)","rgba(224, 0, 0, 1.0)","rgba(0, 192, 0, 1.0)","white"],["rgba(80, 80, 255, 1.0)","rgba(230, 230, 0, 1.0)","rgba(0, 192, 0, 1.0)","rgba(230, 230, 0, 1.0)","white"],["rgba(0, 192, 0, 1.0)","rgba(224, 0, 0, 1.0)","rgba(80, 80, 255, 1.0)","rgba(224, 0, 0, 1.0)","white"],["rgba(80, 80, 255, 1.0)","rgba(0, 192, 0, 1.0)","rgba(230, 230, 0, 1.0)","rgba(0, 192, 0, 1.0)","white"],["rgba(224, 0, 0, 1.0)","rgba(80, 80, 255, 1.0)","rgba(80, 80, 255, 1.0)","rgba(80, 80, 255, 1.0)","white"],["rgba(0, 192, 0, 1.0)","rgba(230, 230, 0, 1.0)","rgba(0, 192, 0, 1.0)","rgba(230, 230, 0, 1.0)","white"],["rgba(230, 230, 0, 1.0)","rgba(80, 80, 255, 1.0)","rgba(80, 80, 255, 1.0)","rgba(80, 80, 255, 1.0)","white"],["rgba(224, 0, 0, 1.0)","rgba(0, 192, 0, 1.0)","rgba(224, 0, 0, 1.0)","rgba(0, 192, 0, 1.0)","white"],["rgba(0, 192, 0, 1.0)","rgba(80, 80, 255, 1.0)","rgba(0, 192, 0, 1.0)","rgba(80, 80, 255, 1.0)","white"],["rgba(80, 80, 255, 1.0)","rgba(224, 0, 0, 1.0)","rgba(230, 230, 0, 1.0)","rgba(224, 0, 0, 1.0)","white"],["rgba(0, 192, 0, 1.0)","rgba(0, 192, 0, 1.0)","rgba(224, 0, 0, 1.0)","rgba(224, 0, 0, 1.0)","white"],["rgba(80, 80, 255, 1.0)","rgba(230, 230, 0, 1.0)","rgba(0, 192, 0, 1.0)","rgba(0, 192, 0, 1.0)","white"],["rgba(224, 0, 0, 1.0)","rgba(224, 0, 0, 1.0)","rgba(80, 80, 255, 1.0)","rgba(230, 230, 0, 1.0)","white"],["rgba(230, 230, 0, 1.0)","rgba(0, 192, 0, 1.0)","rgba(230, 230, 0, 1.0)","rgba(80, 80, 255, 1.0)","white"],["rgba(0, 192, 0, 1.0)","rgba(80, 80, 255, 1.0)","rgba(80, 80, 255, 1.0)","rgba(0, 192, 0, 1.0)","white"],["rgba(80, 80, 255, 1.0)","rgba(230, 230, 0, 1.0)","rgba(0, 192, 0, 1.0)","rgba(80, 80, 255, 1.0)","white"],["rgba(230, 230, 0, 1.0)","rgba(80, 80, 255, 1.0)","rgba(80, 80, 255, 1.0)","rgba(224, 0, 0, 1.0)","white"],["rgba(80, 80, 255, 1.0)","rgba(0, 192, 0, 1.0)","rgba(0, 192, 0, 1.0)","rgba(0, 192, 0, 1.0)","white"],["rgba(0, 192, 0, 1.0)","rgba(80, 80, 255, 1.0)","rgba(80, 80, 255, 1.0)","rgba(230, 230, 0, 1.0)","white"],["rgba(80, 80, 255, 1.0)","rgba(0, 192, 0, 1.0)","rgba(230, 230, 0, 1.0)","rgba(224, 0, 0, 1.0)","white"],["rgba(224, 0, 0, 1.0)","rgba(230, 230, 0, 1.0)","rgba(80, 80, 255, 1.0)","rgba(0, 192, 0, 1.0)","white"],["rgba(0, 192, 0, 1.0)","rgba(80, 80, 255, 1.0)","rgba(0, 192, 0, 1.0)","rgba(80, 80, 255, 1.0)","white"],["rgba(230, 230, 0, 1.0)","rgba(230, 230, 0, 1.0)","rgba(80, 80, 255, 1.0)","rgba(230, 230, 0, 1.0)","white"],["rgba(224, 0, 0, 1.0)","rgba(80, 80, 255, 1.0)","rgba(224, 0, 0, 1.0)","rgba(80, 80, 255, 1.0)","white"],["rgba(0, 192, 0, 1.0)","rgba(0, 192, 0, 1.0)","rgba(0, 192, 0, 1.0)","rgba(0, 192, 0, 1.0)","white"],["rgba(80, 80, 255, 1.0)","rgba(80, 80, 255, 1.0)","rgba(230, 230, 0, 1.0)","rgba(80, 80, 255, 1.0)","white"],["rgba(230, 230, 0, 1.0)","rgba(224, 0, 0, 1.0)","rgba(224, 0, 0, 1.0)","rgba(224, 0, 0, 1.0)","white"],["rgba(80, 80, 255, 1.0)","rgba(224, 0, 0, 1.0)","rgba(0, 192, 0, 1.0)","rgba(0, 192, 0, 1.0)","white"],["rgba(0, 192, 0, 1.0)","rgba(0, 192, 0, 1.0)","rgba(80, 80, 255, 1.0)","rgba(230, 230, 0, 1.0)","white"],["rgba(80, 80, 255, 1.0)","rgba(230, 230, 0, 1.0)","rgba(230, 230, 0, 1.0)","rgba(224, 0, 0, 1.0)","white"],["rgba(224, 0, 0, 1.0)","rgba(0, 192, 0, 1.0)","rgba(80, 80, 255, 1.0)","rgba(0, 192, 0, 1.0)","white"],["rgba(0, 192, 0, 1.0)","rgba(80, 80, 255, 1.0)","rgba(0, 192, 0, 1.0)","rgba(80, 80, 255, 1.0)","white"],["rgba(230, 230, 0, 1.0)","rgba(230, 230, 0, 1.0)","rgba(80, 80, 255, 1.0)","rgba(230, 230, 0, 1.0)","white"],["rgba(224, 0, 0, 1.0)","rgba(80, 80, 255, 1.0)","rgba(224, 0, 0, 1.0)","rgba(80, 80, 255, 1.0)","white"],["rgba(0, 192, 0, 1.0)","rgba(0, 192, 0, 1.0)","rgba(224, 0, 0, 1.0)","rgba(0, 192, 0, 1.0)","white"],["rgba(80, 80, 255, 1.0)","rgba(80, 80, 255, 1.0)","rgba(0, 192, 0, 1.0)","rgba(80, 80, 255, 1.0)","white"],["rgba(230, 230, 0, 1.0)","rgba(224, 0, 0, 1.0)","rgba(230, 230, 0, 1.0)","rgba(224, 0, 0, 1.0)","white"],["rgba(80, 80, 255, 1.0)","rgba(0, 192, 0, 1.0)","rgba(80, 80, 255, 1.0)","rgba(224, 0, 0, 1.0)","white"],["rgba(0, 192, 0, 1.0)","rgba(230, 230, 0, 1.0)","rgba(230, 230, 0, 1.0)","rgba(0, 192, 0, 1.0)","white"],["rgba(80, 80, 255, 1.0)","rgba(224, 0, 0, 1.0)","rgba(80, 80, 255, 1.0)","rgba(230, 230, 0, 1.0)","white"],["rgba(224, 0, 0, 1.0)","rgba(0, 192, 0, 1.0)","rgba(0, 192, 0, 1.0)","white"],["rgba(224, 0, 0, 1.0)","rgba(80, 80, 255, 1.0)","rgba(80, 80, 255, 1.0)","white"],["rgba(0, 192, 0, 1.0)","rgba(0, 192, 0, 1.0)","rgba(80, 80, 255, 1.0)","white"],["rgba(80, 80, 255, 1.0)","rgba(80, 80, 255, 1.0)","rgba(0, 192, 0, 1.0)","white"],["rgba(230, 230, 0, 1.0)","rgba(80, 80, 255, 1.0)","rgba(80, 80, 255, 1.0)","white"],["rgba(80, 80, 255, 1.0)","rgba(0, 192, 0, 1.0)","rgba(224, 0, 0, 1.0)","white"],["rgba(0, 192, 0, 1.0)","rgba(80, 80, 255, 1.0)","rgba(0, 192, 0, 1.0)","white"],["rgba(80, 80, 255, 1.0)","rgba(224, 0, 0, 1.0)","rgba(230, 230, 0, 1.0)","white"],["rgba(224, 0, 0, 1.0)","rgba(0, 192, 0, 1.0)","rgba(224, 0, 0, 1.0)","white"],["rgba(230, 230, 0, 1.0)","rgba(230, 230, 0, 1.0)","rgba(0, 192, 0, 1.0)","white"],["rgba(224, 0, 0, 1.0)","rgba(224, 0, 0, 1.0)","rgba(80, 80, 255, 1.0)","white"],["rgba(0, 192, 0, 1.0)","rgba(0, 192, 0, 1.0)","rgba(230, 230, 0, 1.0)","white"],["rgba(230, 230, 0, 1.0)","rgba(80, 80, 255, 1.0)","rgba(80, 80, 255, 1.0)","white"],["rgba(0, 192, 0, 1.0)","rgba(230, 230, 0, 1.0)","rgba(0, 192, 0, 1.0)","white"],["rgba(80, 80, 255, 1.0)","rgba(80, 80, 255, 1.0)","rgba(80, 80, 255, 1.0)","white"],["rgba(230, 230, 0, 1.0)","rgba(0, 192, 0, 1.0)","rgba(230, 230, 0, 1.0)","white"],["rgba(80, 80, 255, 1.0)","rgba(80, 80, 255, 1.0)","rgba(80, 80, 255, 1.0)","white"],["rgba(0, 192, 0, 1.0)","rgba(224, 0, 0, 1.0)","rgba(0, 192, 0, 1.0)","white"]]},"line":{"color":"white","width":0.0},"font":{"family":"Consolas","size":14.0}},"columnwidth":[50,10]}];
            var layout = {"width":650,"height":-2147483648,"title":{"text":"Sequence A"}};
            var config = {};
            Plotly.newPlot('f47c410b-4386-443c-b7bb-166d6d80c630', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_f47c410b4386443cb7bb166d6d80c630();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_f47c410b4386443cb7bb166d6d80c630();
            }
</script>
*)

