// Learn more about F# at http://fsharp.org. See the 'F# Tutorial' project
// for more guidance on F# programming.
#r @"C:\Users\Muehlhaus\Source\FSharp.Plotly\packages\Newtonsoft.Json.8.0.3\lib\net40\Newtonsoft.Json.dll"

#load "Text.fs"
#load "Gramar.fs"
#load "GenericTrace.fs"
#load "GenericChart.fs"
#load "Chart.fs"

open FSharp.Plotly
open Gramar

let xValues = seq [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ] // 9.; 8.; 7.; 6.; 5.; 4.; 3.; 2.; 1.]
let yValues = seq [5.; 2.5; 5.; 7.5; 5.; 2.5; 7.5; 4.5; 5.5; 5.]
let yValues' = seq [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]

[
Chart.Point([1;2;3;4],[1;2;3;4],Name="A");
//|> Chart.withLineStyle(Width=1);
Chart.Bar([1;2;3;4],[6;2;7;4],Name="B")    
] 
|> Chart.Combine
|> Chart.Show


[
Chart.Range(xValues,yValues,(yValues |> Seq.map (fun v -> v - 0.7)),(yValues |> Seq.map (fun v -> v + 0.7)),Name="A");
Chart.Range(xValues,yValues',(yValues' |> Seq.map (fun v -> v - 0.3)),(yValues' |> Seq.map (fun v -> v + 0.3)),Name="B");
]
|> Chart.Combine
|> Chart.Show


Chart.BoxPlot(["HAllo";"HAllo";"HAllo";"HAllo"],[4;2;3;4],Jitter=0.3,Boxpoints="all")
|> Chart.Show


