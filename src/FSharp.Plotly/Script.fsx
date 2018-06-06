//#I "./bin/Debug"
//#r "./bin/Debug/netstandard2.0/Newtonsoft.Json.dll"
#r "./bin/Debug/netstandard2.0/FSharp.Plotly.dll"
#r "netstandard"

open FSharp.Plotly


let x = seq [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ] // 9.; 8.; 7.; 6.; 5.; 4.; 3.; 2.; 1.]
let y = seq [5.; 2.5; 5.; 7.5; 5.; 2.5; 7.5; 4.5; 5.5; 5.]
let y' = seq [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]

Chart.Spline(x,y',Name="spline")    
//|> Chart.withYError(Options.Error(Array=[1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]))


//|> Chart.withLineStyle(Width=2,Dash=StyleParam.DrawingStyle.Dot)
//|> Chart.withLineOption(Options.Line(Width=10))
//|> Chart.withX_AxisStyle("x axis title") 
//|> Chart.withY_AxisStyle("y axis title") 
//|> layoutJson
//|> GenericChart.toChartHtmlWithSize 500 500

//|> Chart.ShowAsImage StyleParam.ImageFormat.SVG 
|> Chart.ShowAsImage StyleParam.ImageFormat.SVG 








