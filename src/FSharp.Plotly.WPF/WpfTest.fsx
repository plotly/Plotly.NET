//#I "./bin/Debug"
#r "./bin/Debug/Newtonsoft.Json.dll"
#r "./bin/Debug/FSharp.Plotly.dll"
#r "./bin/Debug/FSharp.Plotly.WPF.dll"

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
|> Chart.ShowWPF



