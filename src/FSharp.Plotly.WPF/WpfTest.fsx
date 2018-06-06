//#I "./bin/Debug"
//#r "./bin/Debug/netstandard2.0/Newtonsoft.Json.dll"
//#r @"D:\Source\FSharp.Plotly\packages\htmlagilitypack\1.8.4\HtmlAgilityPack.dll"
#r "./bin/Debug/netstandard2.0/FSharp.Plotly.dll"
#r "./bin/Debug/netstandard2.0/FSharp.Plotly.WPF.dll"
#r "netstandard"

open FSharp.Plotly
open FSharp.Plotly.WPF


let xValues = seq [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ] // 9.; 8.; 7.; 6.; 5.; 4.; 3.; 2.; 1.]
let yValues = seq [5.; 2.5; 5.; 7.5; 5.; 2.5; 7.5; 4.5; 5.5; 5.]
let yValues' = seq [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]


// Combinded Point and Line plot
[
    
    Chart.Point(xValues,yValues,Name="scattern");
    Chart.Line(xValues,yValues',Name="line")    
    |> Chart.withLineStyle(Width=1);
] 
|> Chart.Combine
//|> Chart.SaveImageAs StyleParam.ImageFormat.SVG "" 



