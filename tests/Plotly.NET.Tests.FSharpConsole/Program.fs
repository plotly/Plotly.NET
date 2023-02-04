// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open DynamicObj

// Define a function to construct a message to print
let from whom =
    sprintf "from %s" whom

[<EntryPoint>]
let main argv =
    
    let x  = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
    let y' = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
    let s1 = Shape.init (ShapeType=StyleParam.ShapeType.Rectangle,X0=2.,X1=4.,Y0=3.,Y1=4.,Opacity=0.3,FillColor=Color.fromHex "#d3d3d3")
    let s2 = Shape.init (ShapeType=StyleParam.ShapeType.Rectangle,X0=5.,X1=7.,Y0=3.,Y1=4.,Opacity=0.3,FillColor=Color.fromHex "#d3d3d3")
    Chart.Line(x,y',Name="line", UseDefaults = false)    
    |> Chart.withShapes([s1;s2])
    |> Chart.show
    
    0