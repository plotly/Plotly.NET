(*** hide ***)
#r "../../bin/Newtonsoft.Json.dll"
#r "../../bin/FSharp.Plotly.dll"

(** 
# FSharp.Plotly: Line and Scatter Charts

*Summary:* This example shows how to create line and point charts in F#.

A line or a point chart can be created using the `Chart.Line` and `Chart.Point` methods. 


## Chart.Line with LineStyle
The following example generates Line Plot containing X and Y values. 
*)

open FSharp.Plotly 
  
let x  = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
let y' = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
  
(*** define-output:line1 ***)
Chart.Line(x,y',Name="line")    
|> Chart.withLineStyle(Width=2,Dash=StyleOption.DrawingStyle.Dot)
(*** include-it:line1 ***)

(** 

## Pipelining into Chart.Line
The following example calls the `Chart.Line` method with a list of X and Y values as tuples. The snippet generates
values of a simple function, f(x)=x^2. The values of the function are generated for X ranging from 1 to 100. The chart generated is 
shown below.
*)

(*** define-output:sq ***)
// Drawing graph of a 'square' function 
[ for x in 1.0 .. 100.0 -> (x, x ** 2.0) ]
|> Chart.Line
(*** include-it:sq ***)
|> Chart.Show
