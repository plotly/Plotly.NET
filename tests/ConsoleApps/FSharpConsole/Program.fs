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
let main args = 
    let x = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
    let y = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
    [
        Chart.Point(x = x, y = y, UseDefaults = false) 
        |> Chart.withYAxisStyle("This title must")
    
        Chart.Line(x = x, y = y, UseDefaults = false) 
        |> Chart.withYAxisStyle("be set on the",ZeroLine=false)
        
        Chart.Spline(x = x, y = y, UseDefaults = false) 
        |> Chart.withYAxisStyle("respective subplots",ZeroLine=false)
    ]
    |> Chart.SingleStack(Pattern = StyleParam.LayoutGridPattern.Coupled)
    //move xAxis to bottom and increase spacing between plots by using the withLayoutGridStyle function
    |> Chart.withLayoutGridStyle(XSide=StyleParam.LayoutGridXSide.Bottom,YGap= 0.1)
    |> Chart.withTitle("Hi i am the new SingleStackChart")
    |> Chart.withXAxisStyle("im the shared xAxis")
    |> Chart.show
    0