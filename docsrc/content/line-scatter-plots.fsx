(*** hide ***)
#r "netstandard"
#r "../../bin/FSharp.Plotly/netstandard2.0/FSharp.Plotly.dll"

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
Chart.Line(x,y',Name="line",ShowMarkers=true,MarkerSymbol=StyleParam.Symbol.Square)    
|> Chart.withLineStyle(Width=2,Dash=StyleParam.DrawingStyle.Dot)
(*** include-it:line1 ***)

(** 

## Pipelining into Chart.Line
The following example calls the `Chart.Line` method with a list of X and Y values as tuples. The snippet generates
values of a simple function, f(x)=x^2. The values of the function are generated for X ranging from 1 to 100. The chart generated is 
shown below.
*)

(*** define-output:line2 ***)
// Drawing graph of a 'square' function 
[ for x in 1.0 .. 100.0 -> (x, x ** 2.0) ]
|> Chart.Line
(*** include-it:line2 ***)



(*** define-output:line3 ***)
Chart.Spline(x,y',Name="spline")    
|> Chart.withLineStyle(Width=2,Dash=StyleParam.DrawingStyle.Dot)
|> Chart.withLineStyle(Width=6,Dash=StyleParam.DrawingStyle.Dot)
(*** include-it:line3 ***)
|> Chart.Show

(** 

## Point chart with text label
The following example calls the `Chart.Point` method to generate a Scattern Plot containing X and Y values plus text labels. 
If `TextPosition` is set the labels are drawn otherwise only shown when hovering over the points.

*)


let l  = ["a";"b";"c";"d";"e";"f";"g";"h";"i";"j";]

(*** define-output:pointsWithLabels ***)
Chart.Point(x,y',Name="points",Labels=l,TextPosition=StyleParam.TextPosition.TopRight)    
(*** include-it:pointsWithLabels ***)





(*** define-output:pointsWithErrorBars ***)
Chart.Point(x,y',Name="points with errors")    
|> Chart.withXErrorStyle (Array=[|0.2;0.3;0.2;0.1;0.2;0.4;0.2;0.08;0.2;0.1;|])
|> Chart.withYErrorStyle (Array=[|0.3;0.2;0.1;0.4;0.2;0.4;0.1;0.18;0.02;0.2;|])
(*** include-it:pointsWithErrorBars ***)


