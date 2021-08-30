(**
---
title: Tables
category: Simple Charts
categoryindex: 3
index: 7
---
*)

(*** hide ***)

(*** condition: prepare ***)
#r "nuget: Newtonsoft.JSON, 12.0.3"
#r "nuget: DynamicObj"
#r "../bin/Plotly.NET/netstandard2.0/Plotly.NET.dll"

(*** condition: ipynb ***)
#if IPYNB
#r "nuget: Plotly.NET, {{fsdocs-package-version}}"
#r "nuget: Plotly.NET.Interactive, {{fsdocs-package-version}}"
#endif // IPYNB

(** 
# Tables

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath={{fsdocs-source-basename}}.ipynb)&emsp;
[![Script]({{root}}img/badge-script.svg)]({{root}}{{fsdocs-source-basename}}.fsx)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

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


let table1 = Chart.Table(header, rows)

(*** condition: ipynb ***)
#if IPYNB
table1
#endif // IPYNB

(***hide***)
table1 |> GenericChart.toChartHTML
(***include-it-raw***)

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
        FontHeader  = Font.init(FontFamily.Courier_New, Size=12., Color=Color.ColorString "white"),      
        //sets the height of the header
        HeightHeader= 30.,
        //sets lines of header
        LineHeader  = Line.init(2.,Color.ColorString "black"),                     
        ColumnWidth = [70;50;100;70],      
        //defines order of columns
        ColumnOrder = [1;2;3;4]                                  
        )

(*** condition: ipynb ***)
#if IPYNB
table2
#endif // IPYNB

(***hide***)
table2 |> GenericChart.toChartHTML
(***include-it-raw***)

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
    RGB.fromRgb 255 (255 - proportion) proportion
    |> RGB.toWebColor
    
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

let table3 = Chart.Table(header2,rowvalues,ColorCells=cellcolor)

(*** condition: ipynb ***)
#if IPYNB
table3
#endif // IPYNB

(***hide***)
table3 |> GenericChart.toChartHTML
(***include-it-raw***)


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
let line = Line.init(0.,Color.ColorString "white")
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
    |> Chart.withTitle "Sequence A"

(*** condition: ipynb ***)
#if IPYNB
table4
#endif // IPYNB

(***hide***)
table4 |> GenericChart.toChartHTML
(***include-it-raw***)


