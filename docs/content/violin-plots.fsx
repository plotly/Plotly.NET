(*** hide ***)
#r "../../bin/Newtonsoft.Json.dll"
#r "../../bin/FSharp.Plotly.dll"

(** 
# FSharp.Plotly: BoxPlot Charts

*Summary:* This example shows how to create boxplot charts in F#.

A box plot or boxplot is a convenient way of graphically depicting groups of numerical data through their quartiles. 
Box plots may also have lines extending vertically from the boxes (whiskers) indicating variability outside the upper
and lower quartiles, hence the terms box-and-whisker plot and box-and-whisker diagram. 
Outliers may be plotted as individual points.
*)

open FSharp.Plotly 
open FSharp.Plotly.StyleParam
  
let y =  [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
let x = ["bin1";"bin2";"bin1";"bin2";"bin1";"bin2";"bin1";"bin1";"bin2";"bin1"]
 
 
(*** define-output:violin1 ***)
Chart.Violin (x,y,Points=StyleParam.Jitterpoints.All)
(*** include-it:violin1 ***)   



(**
By swapping x and y plus using `StyleParam.Orientation.Horizontal` we can flip the chart horizontaly.
*)
(*** define-output:violin2 ***)
Chart.Violin (y,x,Jitter=0.1,Points=StyleParam.Jitterpoints.All,Orientation=StyleParam.Orientation.Horizontal)
(*** include-it:violin2 ***)



(**
You can also produce a boxplot using the `Chart.Combine` syntax.
*)

let y' =  [2.; 1.5; 5.; 1.5; 2.; 2.5; 2.1; 2.5; 1.5; 1.;2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]

(*** define-output:violin3 ***)
[
    Chart.Violin ("y" ,y,Name="bin1",Jitter=0.1,Points=StyleParam.Jitterpoints.All);
    Chart.Violin ("y'",y',Name="bin2",Jitter=0.1,Points=StyleParam.Jitterpoints.All);
]
|> Chart.Combine
(*** include-it:violin3 ***)   


