//#I "./bin/Debug"
#r "./bin/Debug/Newtonsoft.Json.dll"
#r "./bin/Debug/FSharp.Plotly.dll"


open FSharp.Plotly


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
|> Chart.Show


// Combinded range plot

[
    Chart.Range(xValues,yValues,(yValues |> Seq.map (fun v -> v - 0.7)),(yValues |> Seq.map (fun v -> v + 0.7)),Name="A");
    Chart.Range(xValues,yValues',(yValues' |> Seq.map (fun v -> v - 0.3)),(yValues' |> Seq.map (fun v -> v + 0.3)),Name="B");
]
|> Chart.Combine
|> Chart.Show


// BoxPlot example

Chart.BoxPlot(["bin1";"bin2";"bin1";"bin2";"bin1";"bin2";"bin1";"bin1";"bin2";"bin1"],yValues',Jitter=0.3,Boxpoints=StyleOption.Boxpoints.Outliers)
|> Chart.Show

Chart.BoxPlot(x=yValues,Jitter=0.3,Boxpoints= StyleOption.Boxpoints.Outliers)
|> Chart.Show

Chart.BoxPlot(y=yValues,Jitter=0.3,Boxpoints=StyleOption.Boxpoints.Suspectedoutliers)
|> Chart.Show



// Heatmap example

let matrix =
    [[1.;1.5;0.7;2.7];
    [2.;0.5;1.2;1.4];
    [0.1;2.6;2.4;3.0];]

let rownames = ["p1";"p2";"p3"]
let colnames = ["Tp0";"Tp30";"Tp60";"Tp160"]



let colorscaleValue = 
    //StyleOption.ColorScale.Electric
    StyleOption.ColorScale.Custom [(0.0,"#3D9970");(1.0,"#001f3f")]
    

Chart.HeatMap(matrix,colnames,rownames,Colorscale=colorscaleValue,Showscale=true)
|> Chart.Show





