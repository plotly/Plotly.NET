//#I "./bin/Debug"
#r "./bin/Debug/Newtonsoft.Json.dll"
#r "./bin/Debug/FSharp.Plotly.dll"


open FSharp.Plotly


let xValues = seq [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ] // 9.; 8.; 7.; 6.; 5.; 4.; 3.; 2.; 1.]
let yValues = seq [5.; 2.5; 5.; 7.5; 5.; 2.5; 7.5; 4.5; 5.5; 5.]
let yValues' = seq [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]



Chart.Point(xValues,yValues,Name="scattern")
|> Chart.withX_AxisStyle("x axis title") 
|> Chart.withY_AxisStyle("y axis title") 
|> Chart.Show




// Combinded Point and Line plot
[
    Chart.Point(xValues,yValues,Name="scattern");
    Chart.Line(xValues,yValues',Name="line")    
    |> Chart.withLineStyle(Width=1);
] 
|> Chart.Combine
|> Chart.Show


// Combinded range plot

Chart.Range(xValues,yValues,(yValues |> Seq.map (fun v -> v - 0.7)),(yValues |> Seq.map (fun v -> v + 0.7)),Name="A",Color="#FF0000",ShowMarkers=false)
//Chart.Point(xValues,yValues,Name="scattern",Color="#FF0000")
|> Chart.Show

[
    Chart.SplineRange(xValues,yValues,(yValues |> Seq.map (fun v -> v - 0.7)),(yValues |> Seq.map (fun v -> v + 0.7)),Name="A",Color="#FF0000",Smoothing=0.5);
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

let rownames = ["p3";"p2";"p1"]
let colnames = ["Tp0";"Tp30";"Tp60";"Tp160"]



let colorscaleValue = 
    //StyleOption.ColorScale.Electric
    StyleOption.ColorScale.Custom [(0.0,"#3D9970");(1.0,"#001f3f")]
    

Chart.HeatMap(matrix,colnames,rownames,Colorscale=colorscaleValue,Showscale=true)
|> Chart.withSize(700.,500.)
|> Chart.withMarginSize(left=200.)
|> Chart.Show



let values = [19; 26; 55;]
let labels = ["Residential"; "Non-Residential"; "Utility"]

Chart.Pie(values,labels)
|> Chart.withSize(500.,500.)
|> Chart.Show





System.IO.Path.GetTempPath()

open Newtonsoft.Json
let a =
    """{"Name":"Root","Children":[{"Name":"1","Children":[]},{"Name":"2","Children":[]}]}""" |> JsonConvert.DeserializeObject








let x = ["rep1";"rep1";"rep1";"rep1";"rep1";
         "rep2";"rep2";"rep2";"rep2";"rep2";
         "rep3";"rep3";"rep3";"rep3";"rep3";
        ]

let pAO1_WT = [3.5;3.6;3.7;3.8;3.7;
               3.3;3.2;3.3;3.2;3.5;
               3.5;3.6;3.7;3.8;3.7;]

let b =       [3.6;3.2;3.8;3.9;3.7;
               3.9;3.7;3.7;3.7;3.8;
               3.6;3.2;3.8;3.9;3.7;]

let c = [3.5;3.2;3.4;3.4;3.6;3.9;3.5;3.5;3.7;3.9;3.5;3.2;3.4;3.4;3.6;]

[
//Chart.BoxPlot(x= (x |> Seq.map (fun s -> "wt_" + s )),y=pAO1_WT,Jitter=0.3,Boxpoints= StyleOption.Boxpoints.Outliers);
//Chart.BoxPlot(x= (x |> Seq.map (fun s -> "mut1_" + s )),y=b,Jitter=0.3,Boxpoints= StyleOption.Boxpoints.Outliers);
//Chart.BoxPlot(x= (x |> Seq.map (fun s -> "mut2_" + s )),y=c,Jitter=0.3,Boxpoints= StyleOption.Boxpoints.Outliers);

Chart.BoxPlot(y=pAO1_WT,Jitter=0.3,Boxpoints= StyleOption.Boxpoints.Outliers);
Chart.BoxPlot(y=b,Jitter=0.3,Boxpoints= StyleOption.Boxpoints.Outliers);
Chart.BoxPlot(y=c,Jitter=0.3,Boxpoints= StyleOption.Boxpoints.Outliers);

]
|> Chart.Combine
|> Chart.Show

