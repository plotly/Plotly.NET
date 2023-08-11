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
#r "nuget: Newtonsoft.JSON, 13.0.1"
#r "nuget: DynamicObj, 2.0.0"
#r "nuget: Giraffe.ViewEngine.StrongName, 2.0.0-alpha1"
#r "../../src/Plotly.NET/bin/Release/netstandard2.0/Plotly.NET.dll"

Plotly.NET.Defaults.DefaultDisplayOptions <-
    Plotly.NET.DisplayOptions.init (PlotlyJSReference = Plotly.NET.PlotlyJSReference.NoReference)

(*** condition: ipynb ***)
#if IPYNB
#r "nuget: Plotly.NET, {{fsdocs-package-version}}"
#r "nuget: Plotly.NET.Interactive, {{fsdocs-package-version}}"
#endif // IPYNB

(** 
# Tables

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

This example shows how to create tables in F#.

Let's first create some data for the purpose of creating example charts:

*)

open Plotly.NET
open Plotly.NET.StyleParam


let table1 =
    Chart.Table(
        headerValues = [ "<b>RowIndex</b>"; "A"; "simple"; "table" ],
        cellsValues = [ [ "0"; "I"; "am"; "a" ]; [ "1"; "little"; "example"; "!" ] ]
    )



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
    let header = [ "<b>RowIndex</b>"; "A"; "simple"; "table" ]
    let rows = [ [ "0"; "I"; "am"; "a" ]; [ "1"; "little"; "example"; "!" ] ]

    Chart.Table(
        headerValues = header,
        cellsValues = rows,
        HeaderAlign = StyleParam.HorizontalAlign.Center,
        CellsMultiAlign =
            [ StyleParam.HorizontalAlign.Left
              StyleParam.HorizontalAlign.Center
              StyleParam.HorizontalAlign.Right ],
        HeaderFillColor = Color.fromString "#45546a",
        CellsFillColor =
            Color.fromColors
                [ Color.fromString "#deebf7"
                  Color.fromString "lightgrey"
                  Color.fromString "#deebf7"
                  Color.fromString "lightgrey" ],
        HeaderHeight = 30,
        HeaderOutlineColor = Color.fromString "black",
        HeaderOutlineWidth = 2.,
        MultiColumnWidth = [ 70.; 50.; 100.; 70. ],
        ColumnOrder = [ 1; 2; 3; 4 ]
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

let table3 =
    let header2 = [ "Identifier"; "T0"; "T1"; "T2"; "T3" ]

    let rowvalues =
        [ [ 10001.; 0.2; 2.0; 4.0; 5.0 ]
          [ 10002.; 2.1; 2.0; 1.8; 2.1 ]
          [ 10003.; 4.5; 3.0; 2.0; 2.5 ]
          [ 10004.; 0.0; 0.1; 0.3; 0.2 ]
          [ 10005.; 1.0; 1.6; 1.8; 2.2 ]
          [ 10006.; 1.0; 0.8; 1.5; 0.7 ]
          [ 10007.; 2.0; 2.0; 2.1; 1.9 ] ]
        |> Seq.sortBy (fun x -> x.[1])

    //map color from value to hex representation
    let mapColor min max value =
        let proportion = (255. * (value - min) / (max - min)) |> int
        Color.fromRGB 255 (255 - proportion) proportion

    //Assign a color to every cell seperately. Matrix must be transposed for correct orientation.
    let cellcolor =
        rowvalues
        |> Seq.map (fun row ->
            row
            |> Seq.mapi (fun index value ->
                if index = 0 then
                    Color.fromString "white"
                else
                    mapColor 0. 5. value))
        |> Seq.transpose
        |> Seq.map Color.fromColors
        |> Color.fromColors

    Chart.Table(headerValues = header2, cellsValues = rowvalues, CellsFillColor = cellcolor)

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

let table4 =
    let sequence =
        [ "ATGAGACGTCGAGACTGATAGACGTCGATAGACGTCGATAGACCG"
          "ATAGACTCGTGATAGACGTCGATAGACGTCGATAGAGTATAGACC"
          "GTGATAGACGTCGAGAAGACGTCGATAGACGTCGATAGACGTCGA"
          "TAGAGATAGACGTCGATAGACCGTATAGAAGACGTCGATAGATAG"
          "ACGTCGATAGACCGTAGACGTCGATAGACGTCGATAGACCGT" ]
        |> String.concat ""

    let elementsPerRow = 60

    let headers =
        [ 0..elementsPerRow ]
        |> Seq.map (fun x -> if x % 10 = 0 && x <> 0 then "|" else "")

    let cells =
        sequence
        |> Seq.chunkBySize elementsPerRow
        |> Seq.mapi (fun i x -> Seq.append [ string (i * elementsPerRow) ] (Seq.map string x))

    let cellcolors =
        cells
        |> Seq.map (fun row ->
            row
            |> Seq.map (fun element ->
                match element with
                //colors taken from DRuMS
                //(http://biomodel.uah.es/en/model4/dna/atgc.htm)
                | "A" -> Color.fromString "#5050FF"
                | "T" -> Color.fromString "#E6E600"
                | "G" -> Color.fromString "#00C000"
                | "C" -> Color.fromString "#E00000"
                | "U" -> Color.fromString "#B48100"
                | _ -> Color.fromString "white"))
        |> Seq.transpose
        |> Seq.map (fun x -> Seq.append x (seq [ Color.fromString "white" ]))
        |> Seq.map Color.fromColors
        |> Color.fromColors

    let line = Line.init (Width = 0., Color = Color.fromString "white")
    let chartwidth = 50 + 10 * elementsPerRow

    Chart.Table(
        headerValues = headers,
        cellsValues = cells,
        CellsOutline = line,
        HeaderOutline = line,
        CellsHeight = 20,
        MultiColumnWidth = [ 50.; 10. ],
        CellsMultiAlign = [ StyleParam.HorizontalAlign.Right; StyleParam.HorizontalAlign.Center ],
        CellsFillColor = cellcolors,
        UseDefaults = false
    )
    |> Chart.withSize (Width = chartwidth)
    |> Chart.withTitle "Sequence A"

(*** condition: ipynb ***)
#if IPYNB
table4
#endif // IPYNB

(***hide***)
table4 |> GenericChart.toChartHTML
(***include-it-raw***)
