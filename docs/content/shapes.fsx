(*** side ***)
#r "../../bin/Newtonsoft.Json.dll"
#r "../../bin/FSharp.Plotly.dll"

(** 
# FSharp.Plotly: Shapes

*Summary:* This example shows how to create Shapes and add them to the Charts in F#.

*)

open FSharp.Plotly 
  
let x  = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
let y' = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]

let s1 = 
    Shape.init 
        ( Shape.style
            ( StyleParam.ShapeType.Rectangle,2.,4.,3.,4.,Opacity=0.3,Fillcolor="#d3d3d3" ) 
        )
let s2 = 
    Shape.init 
        ( Shape.style
            ( StyleParam.ShapeType.Rectangle,5.,7.,3.,4.,Opacity=0.3,Fillcolor="#d3d3d3" )
        )
(*** define-output:line1 ***)
Chart.Line(x,y',Name="line")    
//|> Chart.withShape(Options.Shape(StyleParam.ShapeType.Rectangle,2.,4.,3.,4.,Opacity=0.3,Fillcolor="#d3d3d3"))
|> Chart.withShapes([s1;s2])
(*** include-it:line1 ***)

