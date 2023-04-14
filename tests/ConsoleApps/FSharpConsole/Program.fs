open System
open Deedle
open System.IO
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open Plotly.NET.ConfigObjects
open DynamicObj
open Giraffe.ViewEngine
open Newtonsoft.Json

[<EntryPoint>]
let main argv =
    let x  = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
    let y' = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
    let s1 = 
        Shape.init(
            ShapeType=StyleParam.ShapeType.Rectangle,
            X0=2.,X1=4.,Y0=3.,Y1=4.,
            Opacity=0.3,
            FillColor=Color.fromHex "#d3d3d3",
            Label = ShapeLabel.init(Text="Rectangle")
        )
    let s2 = 
        Shape.init(
            ShapeType=StyleParam.ShapeType.Circle,
            X0=5.,X1=7.,Y0=3.,Y1=4.,
            Opacity=0.3,
            FillColor=Color.fromHex "#d3d3d3",
            Label = ShapeLabel.init(Text="Circle")
        )
    let s3 = 
        Shape.init(
            ShapeType=StyleParam.ShapeType.Line,
                X0=1.,X1=2.,Y0=1.,Y1=2.,
                Opacity=0.3,
                FillColor=Color.fromHex "#d3d3d3",
                Label = ShapeLabel.init(Text="Line")
        )
    let s4 = 
        Shape.init(
            ShapeType=StyleParam.ShapeType.SvgPath,
            Path=" M 3,7 L2,8 L2,9 L3,10, L4,10 L5,9 L5,8 L4,7 Z",
            Label = ShapeLabel.init(Text="SVGPath", TextAngle = StyleParam.TextAngle.Degrees 33)
        )
    Chart.Line(x = x,y = y',Name="line", UseDefaults = false)    
    |> Chart.withShapes([s1;s2;s3;s4])
    |> Chart.show
    0