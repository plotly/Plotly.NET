(*** hide ***)
#r "netstandard"
#r "../../bin/Plotly.NET/netstandard2.0/Plotly.NET.dll"

(** 
# Plotly.NET: Shapes

*Summary:* This example shows how to create Shapes and add them to the Charts in F#.

*)

open Plotly.NET 
  
let x  = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
let y' = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]

let s1 = Shape.init (StyleParam.ShapeType.Rectangle,2.,4.,3.,4.,Opacity=0.3,Fillcolor="#d3d3d3")
let s2 = Shape.init (StyleParam.ShapeType.Rectangle,5.,7.,3.,4.,Opacity=0.3,Fillcolor="#d3d3d3")
let shapes =
    Chart.Line(x,y',Name="line")    
    |> Chart.withShapes([s1;s2])
//|> Chart.withShape(Options.Shape(StyleOption.ShapeType.Rectangle,2.,4.,3.,4.,Opacity=0.3,Fillcolor="#d3d3d3"))

(***do-not-eval***)
shapes |> Chart.Show

(*** include-value:shapes ***)

