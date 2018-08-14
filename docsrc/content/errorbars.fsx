(*** hide ***)
// This block of code is omitted in the generated HTML documentation. Use 
// it to define helpers that you do not want to show in the documentation.
#r "netstandard"
#r "../../bin/FSharp.Plotly/netstandard2.0/FSharp.Plotly.dll"
(**
Error bars
=============================

How to create plots in FSharp.Plotly and add error bars to it.

*)

open FSharp.Plotly

let x  = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
let y' = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]




(*** define-output:pointsWithErrorBars ***)
Chart.Point(x,y',Name="points with errors")    
|> Chart.withXErrorStyle (Array=[|0.2;0.3;0.2;0.1;0.2;0.4;0.2;0.08;0.2;0.1;|])
|> Chart.withYErrorStyle (Array=[|0.3;0.2;0.1;0.4;0.2;0.4;0.1;0.18;0.02;0.2;|])
(*** include-it:pointsWithErrorBars ***)




