module Tests.DistributionCharts

open Expecto
open Plotly.NET
open TestUtils
open Plotly.NET.GenericChart
open System

let histoChart =
    let rnd = System.Random(5)
    let x = [for i=0 to 500 do yield rnd.NextDouble() ]
    x
    |> Chart.Histogram
    |> Chart.withSize(500., 500.)

[<Tests>]
let ``Histogram charts`` =
    testList "DistributionCharts.Histogram charts" [
        testCase "Histo data" ( fun () ->
            // the string is too big to be here fully.
            [
                "var data = [{\"type\":\"histogram\",\"x\":[0.33836984091362443,0.2844184475412678,0.2629626417825756,0.6253758443637638,0.46346185284827923,0.9283738280312968,0.1463105539541275,0.9505998873853124,0.5961332552116985"
                "0.7608672612164483,0.8280196519699039,0.040246858280267035,0.0017312127173557937],\"marker\":{}}];"
            ]
            |> chartGeneratedContainsList histoChart
        );
        testCase "Histo layout" ( fun () ->
            "var layout = {\"width\":500.0,\"height\":500.0};"
            |> chartGeneratedContains histoChart
        );
    ]

let box1Chart =
    let y =  [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
    let x = ["bin1";"bin2";"bin1";"bin2";"bin1";"bin2";"bin1";"bin1";"bin2";"bin1"]
    Chart.BoxPlot(x,y,Jitter=0.1,Boxpoints=StyleParam.Boxpoints.All)

let box2Chart =
    let y =  [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
    let x = ["bin1";"bin2";"bin1";"bin2";"bin1";"bin2";"bin1";"bin1";"bin2";"bin1"]
    Chart.BoxPlot(y,x,Jitter=0.1,Boxpoints=StyleParam.Boxpoints.All,Orientation=StyleParam.Orientation.Horizontal)

let box3Chart =
    let y =  [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
    let y' =  [2.; 1.5; 5.; 1.5; 2.; 2.5; 2.1; 2.5; 1.5; 1.;2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
    [
        Chart.BoxPlot("y" ,y,Name="bin1",Jitter=0.1,Boxpoints=StyleParam.Boxpoints.All);
        Chart.BoxPlot("y'",y',Name="bin2",Jitter=0.1,Boxpoints=StyleParam.Boxpoints.All);
    ]
    |> Chart.Combine

[<Tests>]
let ``Box charts`` =
    testList "DistributionCharts.Box charts" [
        testCase "Box1 data" ( fun () ->
            "var data = [{\"type\":\"box\",\"y\":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],\"x\":[\"bin1\",\"bin2\",\"bin1\",\"bin2\",\"bin1\",\"bin2\",\"bin1\",\"bin1\",\"bin2\",\"bin1\"],\"boxpoints\":\"all\",\"jitter\":0.1,\"marker\":{}}];"
            |> chartGeneratedContains box1Chart
        );
        testCase "Box1 layout" ( fun () ->
            emptyLayout box1Chart
        );
        testCase "Box2 data" ( fun () ->
            "var data = [{\"type\":\"box\",\"y\":[\"bin1\",\"bin2\",\"bin1\",\"bin2\",\"bin1\",\"bin2\",\"bin1\",\"bin1\",\"bin2\",\"bin1\"],\"x\":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],\"boxpoints\":\"all\",\"jitter\":0.1,\"orientation\":\"h\",\"marker\":{}}];"
            |> chartGeneratedContains box2Chart
        );
        testCase "Box2 layout" ( fun () ->
            emptyLayout box2Chart
        );
        testCase "Box3 data" ( fun () ->
            "var data = [{\"type\":\"box\",\"y\":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],\"x\":\"y\",\"boxpoints\":\"all\",\"jitter\":0.1,\"name\":\"bin1\",\"marker\":{}},{\"type\":\"box\",\"y\":[2.0,1.5,5.0,1.5,2.0,2.5,2.1,2.5,1.5,1.0,2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],\"x\":\"y'\",\"boxpoints\":\"all\",\"jitter\":0.1,\"name\":\"bin2\",\"marker\":{}}];"
            |> chartGeneratedContains box3Chart
        );
        testCase "Box3 layout" ( fun () ->
            emptyLayout box3Chart
        );
    ]