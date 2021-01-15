(*** hide ***)
#r "../bin/Plotly.NET/net5.0/Plotly.NET.dll"

(** 
# Shapes

*Summary:* This example shows how to create Shapes and add them to the Charts in F#.

let's first create some data for the purpose of creating example charts:

*)

open Plotly.NET 
  
let x  = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
let y' = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]

(**
use the `Shape.init` function to generate a shape, and either the `Chart.withShape` or the `Chart.withShapes` function to add
multiple shapes at once.

**Attention**: Adding a shape after you added a previous one currently removes the old one. This is a bug and will be fixed
*)

let s1 = Shape.init (StyleParam.ShapeType.Rectangle,2.,4.,3.,4.,Opacity=0.3,Fillcolor="#d3d3d3")
let s2 = Shape.init (StyleParam.ShapeType.Rectangle,5.,7.,3.,4.,Opacity=0.3,Fillcolor="#d3d3d3")

let shapes =
    Chart.Line(x,y',Name="line")    
    |> Chart.withShapes([s1;s2])
//|> Chart.withShape(Options.Shape(StyleOption.ShapeType.Rectangle,2.,4.,3.,4.,Opacity=0.3,Fillcolor="#d3d3d3"))

(***hide***)
shapes |> GenericChart.toChartHTML
(***include-it-raw***)

