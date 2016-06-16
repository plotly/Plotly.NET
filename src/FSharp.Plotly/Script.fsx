//#I "./bin/Debug"
#r "./bin/Debug/Newtonsoft.Json.dll"
#r "./bin/Debug/FSharp.Plotly.dll"


open FSharp.Plotly


let xValues = seq [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ] // 9.; 8.; 7.; 6.; 5.; 4.; 3.; 2.; 1.]
let yValues = seq [5.; 2.5; 5.; 7.5; 5.; 2.5; 7.5; 4.5; 5.5; 5.]
let yValues' = seq [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]


Chart.Scatter(xValues,yValues,StyleOption.Mode.Lines_Markers,Name="scattern")//,MarkerSymbol=StyleOption.Symbol.Square,Dash=StyleOption.DrawingStyle.Dot)

|> Chart.withLineOption(Options.Line(Width=10))
|> Chart.withX_AxisStyle("x axis title") 
|> Chart.withY_AxisStyle("y axis title") 
//|> layoutJson
//|> GenericChart.toChartHtmlWithSize 500 500
|> Chart.Show














