(*** hide ***)
#r "netstandard"
#r "../../bin/Plotly.NET/netstandard2.0/Plotly.NET.dll"

(** 
# Plotly.NET: BoxPlot Charts

*Summary:* This example shows how to create boxplot charts in F#.

A box plot or boxplot is a convenient way of graphically depicting groups of numerical data through their quartiles. 
Box plots may also have lines extending vertically from the boxes (whiskers) indicating variability outside the upper
and lower quartiles, hence the terms box-and-whisker plot and box-and-whisker diagram. 
Outliers may be plotted as individual points.
*)

open Plotly.NET 
open Plotly.NET.StyleParam
  
let y =  [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
let x = ["bin1";"bin2";"bin1";"bin2";"bin1";"bin2";"bin1";"bin1";"bin2";"bin1"]
  
let box1 =
    Chart.BoxPlot(x,y,Jitter=0.1,Boxpoints=StyleParam.Boxpoints.All)

(***do-not-eval***)
box1 |> Chart.Show

(*** include-value:box1 ***)


(**
By swapping x and y plus using `StyleParam.Orientation.Horizontal` we can flip the chart horizontaly.
*)
let box2 =
    Chart.BoxPlot(y,x,Jitter=0.1,Boxpoints=StyleParam.Boxpoints.All,Orientation=StyleParam.Orientation.Horizontal)

(***do-not-eval***)
box2 |> Chart.Show

(*** include-value:box2 ***)

(**
You can also produce a boxplot using the `Chart.Combine` syntax.
*)

let y' =  [2.; 1.5; 5.; 1.5; 2.; 2.5; 2.1; 2.5; 1.5; 1.;2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]

let box3 =
    [
        Chart.BoxPlot("y" ,y,Name="bin1",Jitter=0.1,Boxpoints=StyleParam.Boxpoints.All);
        Chart.BoxPlot("y'",y',Name="bin2",Jitter=0.1,Boxpoints=StyleParam.Boxpoints.All);
    ]
    |> Chart.Combine

(***do-not-eval***)
box3 |> Chart.Show

(*** include-value:box3 ***)


