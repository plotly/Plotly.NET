module Tests.FinanceCharts

open Expecto
open Plotly.NET
open TestUtils
open Plotly.NET.GenericChart
open System

let candles =
    [|("2020-01-17T13:40:00", 0.68888, 0.68888, 0.68879, 0.6888);
      ("2020-01-17T13:41:00", 0.68883, 0.68884, 0.68875, 0.68877);
      ("2020-01-17T13:42:00", 0.68878, 0.68889, 0.68878, 0.68886);
      ("2020-01-17T13:43:00", 0.68886, 0.68886, 0.68876, 0.68879);
      ("2020-01-17T13:44:00", 0.68879, 0.68879, 0.68873, 0.68874);
      ("2020-01-17T13:45:00", 0.68875, 0.68877, 0.68867, 0.68868);
      ("2020-01-17T13:46:00", 0.68869, 0.68887, 0.68869, 0.68883);
      ("2020-01-17T13:47:00", 0.68883, 0.68899, 0.68883, 0.68899);
      ("2020-01-17T13:48:00", 0.68898, 0.689, 0.68885, 0.68889);
      ("2020-01-17T13:49:00", 0.68889, 0.68893, 0.68881, 0.68893);
      ("2020-01-17T13:50:00", 0.68891, 0.68896, 0.68886, 0.68891);
    |]
    |> Array.map (fun (d,o,h,l,c)->System.DateTime.Parse d, StockData.Create(o,h,l,c))

let candles1Chart = Chart.Candlestick candles


let candles2Chart = 
    let rangeslider = RangeSlider.init(Visible=false)
    Chart.Candlestick candles
    |> Chart.withX_AxisRangeSlider rangeslider

[<Tests>]
let ``Candlestick charts`` =
    testList "FinanceCharts.Candlestick charts" [
        testCase "Finance 1 data" ( fun () ->
            "var data = [{\"type\":\"candlestick\",\"open\":[0.68888,0.68883,0.68878,0.68886,0.68879,0.68875,0.68869,0.68883,0.68898,0.68889,0.68891],\"high\":[0.68888,0.68884,0.68889,0.68886,0.68879,0.68877,0.68887,0.68899,0.689,0.68893,0.68896],\"low\":[0.68879,0.68875,0.68878,0.68876,0.68873,0.68867,0.68869,0.68883,0.68885,0.68881,0.68886],\"close\":[0.6888,0.68877,0.68886,0.68879,0.68874,0.68868,0.68883,0.68899,0.68889,0.68893,0.68891],\"x\":[\"2020-01-17T13:40:00\",\"2020-01-17T13:41:00\",\"2020-01-17T13:42:00\",\"2020-01-17T13:43:00\",\"2020-01-17T13:44:00\",\"2020-01-17T13:45:00\",\"2020-01-17T13:46:00\",\"2020-01-17T13:47:00\",\"2020-01-17T13:48:00\",\"2020-01-17T13:49:00\",\"2020-01-17T13:50:00\"],\"xaxis\":\"x\",\"yaxis\":\"y\"}];"
            |> chartGeneratedContains candles1Chart
        );
        testCase "Finance 1 layout" ( fun () ->
            emptyLayout candles1Chart
        );
        testCase "Finance 2 data" ( fun () ->
            "var data = [{\"type\":\"candlestick\",\"open\":[0.68888,0.68883,0.68878,0.68886,0.68879,0.68875,0.68869,0.68883,0.68898,0.68889,0.68891],\"high\":[0.68888,0.68884,0.68889,0.68886,0.68879,0.68877,0.68887,0.68899,0.689,0.68893,0.68896],\"low\":[0.68879,0.68875,0.68878,0.68876,0.68873,0.68867,0.68869,0.68883,0.68885,0.68881,0.68886],\"close\":[0.6888,0.68877,0.68886,0.68879,0.68874,0.68868,0.68883,0.68899,0.68889,0.68893,0.68891],\"x\":[\"2020-01-17T13:40:00\",\"2020-01-17T13:41:00\",\"2020-01-17T13:42:00\",\"2020-01-17T13:43:00\",\"2020-01-17T13:44:00\",\"2020-01-17T13:45:00\",\"2020-01-17T13:46:00\",\"2020-01-17T13:47:00\",\"2020-01-17T13:48:00\",\"2020-01-17T13:49:00\",\"2020-01-17T13:50:00\"],\"xaxis\":\"x\",\"yaxis\":\"y\"}];"
            |> chartGeneratedContains candles2Chart
        );
        testCase "Finance 2 layout" ( fun () ->
            "var layout = {\"xaxis\":{\"rangeslider\":{\"visible\":false,\"yaxis\":{}}}};"
            |> chartGeneratedContains candles2Chart
        );
    ]


let funnelChart =
    let y = [|"Sales person A"; "Sales person B"; "Sales person C"; "Sales person D"; "Sales person E"|]
    let x = [|1200.; 909.4; 600.6; 300.; 80.|]

    // Customize the connector lines used to connect the funnel bars
    let connectorLine = Line.init (Color="royalblue", Dash=StyleParam.DrawingStyle.Dot, Width=3.)
    let connector = FunnelConnector.init(Line=connectorLine)
    
    // Customize the outline of the funnel bars
    let line = Line.init(Width=2.,Color="3E4E88")
    
    Chart.Funnel (x,y,Color="59D4E8", Line=line, Connector=connector)
    |> Chart.withMarginSize(Left=100)

[<Tests>]
let ``Funnel charts`` =
    testList "FinanceCharts.Funnel charts" [
        testCase "Funnel data" ( fun () ->
            "var data = [{\"type\":\"funnel\",\"x\":[1200.0,909.4,600.6,300.0,80.0],\"y\":[\"Sales person A\",\"Sales person B\",\"Sales person C\",\"Sales person D\",\"Sales person E\"],\"connector\":{\"line\":{\"color\":\"royalblue\",\"width\":3.0,\"dash\":\"dot\"}},\"marker\":{\"color\":\"59D4E8\",\"line\":{\"color\":\"3E4E88\",\"width\":2.0}}}];"
            |> chartGeneratedContains funnelChart
        );
        testCase "Funnel layout" ( fun () ->
            "var layout = {\"margin\":{\"l\":100}};"
            |> chartGeneratedContains funnelChart
        );
    ]



let funnelArea = 
    let values = [|5; 4; 3; 2; 1|]
    let text = [|"The 1st"; "The 2nd"; "The 3rd"; "The 4th"; "The 5th"|]
    let line = Line.init (Color="purple", Width=3.)
    Chart.FunnelArea(Values=values, Text=text, Line=line)

[<Tests>]
let ``Funnel area charts`` =
    testList "FinanceCharts.Funnel area charts" [
        testCase "Funnel area data" ( fun () ->
            "var data = [{\"type\":\"funnelarea\",\"values\":[5,4,3,2,1],\"marker\":{\"line\":{\"color\":\"purple\",\"width\":3.0}},\"domain\":{},\"text\":[\"The 1st\",\"The 2nd\",\"The 3rd\",\"The 4th\",\"The 5th\"]}];"
            |> chartGeneratedContains funnelArea
        );
        testCase "Funnel area layout" ( fun () ->
            emptyLayout funnelArea
        );
    ]