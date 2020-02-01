(*** hide ***)
#r "netstandard"
#r @"../../lib/Formatting/FSharp.Plotly.dll"

(** 
# FSharp.Plotly: Tables

This example shows how to create tables in F#.


*)

open FSharp.Plotly 
open FSharp.Plotly.StyleParam
  
let header = ["RowIndex";"A";"simple";"table"]
let rows = 
    [
     ["0";"I";"am";"a"]        
     ["1";"little";"example";"!"]       
    ]

let table1 =
    Chart.Table(header, rows)



(***do-not-eval***)
table1 |> Chart.Show

(*** include-value:table1 ***)   

(**
A little bit of styling:
*)

let table2 =
    Chart.Table(
        header,
        rows,
        //sets global header alignment
        AlignHeader= [HorizontalAlign.Center],
        //sets alignment for each column separately (The last alignment is applied to all potential following columns)
        AlignCells= [HorizontalAlign.Left;HorizontalAlign.Center;HorizontalAlign.Right],
        //sets global header color
        ColorHeader="#45546a",    
        //sets single header color to each header column
        //ColorHeader=["#45546a";"#deebf7";"#45546a";"#deebf7"],    
        //sets global cell color
        //ColorRows="#deebf7",
        //sets single header color to each header column
        ColorCells=["#deebf7";"lightgrey";"#deebf7";"lightgrey"],
        //sets font of header
        FontHeader=Font.init(FontFamily.Courier_New, Size=12, Color="white"),      
        //sets the height of the header
        HeightHeader= 30.,
        //sets lines of header
        LineHeader=Line.init(2.,"black"),                     
        ColumnWidth=[70;50;100;70],      
        //defines order of columns
        ColumnOrder= [1;2;3;4]                                  
        )

(***do-not-eval***)
table2 |> Chart.Show

(*** include-value:table2 ***)

(**
FastA Representation

*)




