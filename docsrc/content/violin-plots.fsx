(*** hide ***)
#r "netstandard"
#r "../../bin/FSharp.Plotly/netstandard2.0/FSharp.Plotly.dll"

(** 
# FSharp.Plotly: Violin plot Charts

*Summary:* This example shows how to create violin plot charts in F#.

A violin plot is a method of plotting numeric data. It is similar to box plot with a rotated kernel density plot 
on each side. The violin plot is similar to box plots, except that they also show the probability density of the 
data at different values.

*)

open FSharp.Plotly 
open FSharp.Plotly.StyleParam
  
let y =  [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
let x = ["bin1";"bin2";"bin1";"bin2";"bin1";"bin2";"bin1";"bin1";"bin2";"bin1"]
 
 
let violin1 =
    Chart.Violin (x,y,Points=StyleParam.Jitterpoints.All)

(***do-not-eval***)
violin1 |> Chart.Show

(*** include-value:violin1 ***)   

(**
By swapping x and y plus using `StyleParam.Orientation.Horizontal` we can flip the chart horizontaly.
*)
let violin2 =
    Chart.Violin (y,x,Jitter=0.1,Points=StyleParam.Jitterpoints.All,Orientation=StyleParam.Orientation.Horizontal,Meanline=Meanline.init(Visible=true))

(***do-not-eval***)
violin2 |> Chart.Show

(*** include-value:violin2 ***)

(**
You can also produce a violin plot using the `Chart.Combine` syntax.
*)

let y' =  [2.; 1.5; 5.; 1.5; 2.; 2.5; 2.1; 2.5; 1.5; 1.;2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]

let violin3 =
    [
        Chart.Violin ("y" ,y,Name="bin1",Jitter=0.1,Points=StyleParam.Jitterpoints.All);
        Chart.Violin ("y'",y',Name="bin2",Jitter=0.1,Points=StyleParam.Jitterpoints.All);
    ]
    |> Chart.Combine

(***do-not-eval***)
violin3 |> Chart.Show

(*** include-value:violin3 ***)   


