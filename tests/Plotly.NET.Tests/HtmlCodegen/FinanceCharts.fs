module Tests.FinanceCharts

open Expecto
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open Plotly.NET.GenericChart
open System

open TestUtils.HtmlCodegen

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

let ohlc1Chart = Chart.OHLC(stockTimeSeries = candles, UseDefaults = false)

let ohlc2Chart = 
    Chart.OHLC(stockTimeSeries = candles, ShowXAxisRangeSlider = false, UseDefaults = false)


[<Tests>]
let ``OHLC charts`` =
    testList "FinanceCharts.OHLC charts" [
        testCase "OHLC 1 data" ( fun () ->
            """var data = [{"type":"ohlc","x":["2020-01-17T13:40:00","2020-01-17T13:41:00","2020-01-17T13:42:00","2020-01-17T13:43:00","2020-01-17T13:44:00","2020-01-17T13:45:00","2020-01-17T13:46:00","2020-01-17T13:47:00","2020-01-17T13:48:00","2020-01-17T13:49:00","2020-01-17T13:50:00"],"close":[0.6888,0.68877,0.68886,0.68879,0.68874,0.68868,0.68883,0.68899,0.68889,0.68893,0.68891],"open":[0.68888,0.68883,0.68878,0.68886,0.68879,0.68875,0.68869,0.68883,0.68898,0.68889,0.68891],"high":[0.68888,0.68884,0.68889,0.68886,0.68879,0.68877,0.68887,0.68899,0.689,0.68893,0.68896],"low":[0.68879,0.68875,0.68878,0.68876,0.68873,0.68867,0.68869,0.68883,0.68885,0.68881,0.68886],"increasing":{"line":{}},"decreasing":{"line":{}}}];"""
            |> chartGeneratedContains ohlc1Chart
        );
        testCase "OHLC 1 layout" ( fun () ->
            """var layout = {"xaxis":{"rangeslider":{"yaxis":{}}}};"""
            |> chartGeneratedContains ohlc1Chart
        );
        testCase "OHLC 2 data" ( fun () ->
            """var data = [{"type":"ohlc","x":["2020-01-17T13:40:00","2020-01-17T13:41:00","2020-01-17T13:42:00","2020-01-17T13:43:00","2020-01-17T13:44:00","2020-01-17T13:45:00","2020-01-17T13:46:00","2020-01-17T13:47:00","2020-01-17T13:48:00","2020-01-17T13:49:00","2020-01-17T13:50:00"],"close":[0.6888,0.68877,0.68886,0.68879,0.68874,0.68868,0.68883,0.68899,0.68889,0.68893,0.68891],"open":[0.68888,0.68883,0.68878,0.68886,0.68879,0.68875,0.68869,0.68883,0.68898,0.68889,0.68891],"high":[0.68888,0.68884,0.68889,0.68886,0.68879,0.68877,0.68887,0.68899,0.689,0.68893,0.68896],"low":[0.68879,0.68875,0.68878,0.68876,0.68873,0.68867,0.68869,0.68883,0.68885,0.68881,0.68886],"increasing":{"line":{}},"decreasing":{"line":{}}}];"""
            |> chartGeneratedContains ohlc2Chart
        );
        testCase "OHLC 2 layout" ( fun () ->
            """var layout = {"xaxis":{"rangeslider":{"visible":false,"yaxis":{}}}};"""
            |> chartGeneratedContains ohlc2Chart
        );
    ]

let candles1Chart = Chart.Candlestick(stockTimeSeries = candles, UseDefaults = false)

let candles2Chart = 
    Chart.Candlestick(stockTimeSeries = candles, ShowXAxisRangeSlider = false, UseDefaults = false)


[<Tests>]
let ``Candlestick charts`` =
    testList "FinanceCharts.Candlestick charts" [
        testCase "Candlestick 1 data" ( fun () ->
            """var data = [{"type":"candlestick","x":["2020-01-17T13:40:00","2020-01-17T13:41:00","2020-01-17T13:42:00","2020-01-17T13:43:00","2020-01-17T13:44:00","2020-01-17T13:45:00","2020-01-17T13:46:00","2020-01-17T13:47:00","2020-01-17T13:48:00","2020-01-17T13:49:00","2020-01-17T13:50:00"],"close":[0.6888,0.68877,0.68886,0.68879,0.68874,0.68868,0.68883,0.68899,0.68889,0.68893,0.68891],"open":[0.68888,0.68883,0.68878,0.68886,0.68879,0.68875,0.68869,0.68883,0.68898,0.68889,0.68891],"high":[0.68888,0.68884,0.68889,0.68886,0.68879,0.68877,0.68887,0.68899,0.689,0.68893,0.68896],"low":[0.68879,0.68875,0.68878,0.68876,0.68873,0.68867,0.68869,0.68883,0.68885,0.68881,0.68886],"increasing":{"line":{}},"decreasing":{"line":{}}}];"""
            |> chartGeneratedContains candles1Chart
        );
        testCase "Candlestick 1 layout" ( fun () ->
            """var layout = {"xaxis":{"rangeslider":{"yaxis":{}}}};"""
            |> chartGeneratedContains candles1Chart
        );
        testCase "Candlestick 2 data" ( fun () ->
            """var data = [{"type":"candlestick","x":["2020-01-17T13:40:00","2020-01-17T13:41:00","2020-01-17T13:42:00","2020-01-17T13:43:00","2020-01-17T13:44:00","2020-01-17T13:45:00","2020-01-17T13:46:00","2020-01-17T13:47:00","2020-01-17T13:48:00","2020-01-17T13:49:00","2020-01-17T13:50:00"],"close":[0.6888,0.68877,0.68886,0.68879,0.68874,0.68868,0.68883,0.68899,0.68889,0.68893,0.68891],"open":[0.68888,0.68883,0.68878,0.68886,0.68879,0.68875,0.68869,0.68883,0.68898,0.68889,0.68891],"high":[0.68888,0.68884,0.68889,0.68886,0.68879,0.68877,0.68887,0.68899,0.689,0.68893,0.68896],"low":[0.68879,0.68875,0.68878,0.68876,0.68873,0.68867,0.68869,0.68883,0.68885,0.68881,0.68886],"increasing":{"line":{}},"decreasing":{"line":{}}}];"""
            |> chartGeneratedContains candles2Chart
        );
        testCase "Candlestick 2 layout" ( fun () ->
            """var layout = {"xaxis":{"rangeslider":{"visible":false,"yaxis":{}}}};"""
            |> chartGeneratedContains candles2Chart
        );
    ]


let funnelChart =
    let y = [|"Sales person A"; "Sales person B"; "Sales person C"; "Sales person D"; "Sales person E"|]
    let x = [|1200.; 909.4; 600.6; 300.; 80.|]

    // Customize the connector lines used to connect the funnel bars
    let connectorLine = Line.init (Color=Color.fromString "royalblue", Dash=StyleParam.DrawingStyle.Dot, Width=3.)
    let connector = FunnelConnector.init(Line=connectorLine)
    
    // Customize the outline of the funnel bars
    let line = Line.init(Width=2.,Color=Color.fromString "3E4E88")
    
    Chart.Funnel (x = x, y = y,MarkerColor=Color.fromString "59D4E8", MarkerOutline=line, Connector=connector, UseDefaults = false)
    |> Chart.withMarginSize(Left=100)

[<Tests>]
let ``Funnel charts`` =
    testList "FinanceCharts.Funnel charts" [
        testCase "Funnel data" ( fun () ->
            """var data = [{"type":"funnel","x":[1200.0,909.4,600.6,300.0,80.0],"y":["Sales person A","Sales person B","Sales person C","Sales person D","Sales person E"],"marker":{"color":"59D4E8","line":{"color":"3E4E88","width":2.0}},"connector":{"line":{"color":"royalblue","width":3.0,"dash":"dot"}}}];"""
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
    let line = Line.init (Color=Color.fromString "purple", Width=3.)
    Chart.FunnelArea(values=values, MultiText=text, SectionOutline=line, UseDefaults = false)


let funnelAreaStyled =
    let values = [|5; 4; 3|]
    let labels = [|"The 1st"; "The 2nd"; "The 3rd"|]

    Chart.FunnelArea(
        values = values,
        Labels = labels,
        MultiText = labels,
        SectionColors = [
            Color.fromKeyword Aqua
            Color.fromKeyword Salmon
            Color.fromKeyword Tan
        ],
        SectionOutlineColor = Color.fromKeyword Black,
        SectionOutlineWidth = 2.,
        AspectRatio = 0.75,
        BaseRatio = 0.1,
        UseDefaults = false
    )


[<Tests>]
let ``Funnel area charts`` =
    testList "FinanceCharts.Funnel area charts" [
        testCase "Funnel area data" ( fun () ->
            """var data = [{"type":"funnelarea","values":[5,4,3,2,1],"text":["The 1st","The 2nd","The 3rd","The 4th","The 5th"],"marker":{"line":{"color":"purple","width":3.0}}}];"""
            |> chartGeneratedContains funnelArea
        );
        testCase "Funnel area layout" ( fun () ->
            emptyLayout funnelArea
        );        
        testCase "Funnel area styled data" ( fun () ->
            """var data = [{"type":"funnelarea","values":[5,4,3],"labels":["The 1st","The 2nd","The 3rd"],"text":["The 1st","The 2nd","The 3rd"],"marker":{"colors":["rgba(0, 255, 255, 1.0)","rgba(250, 128, 114, 1.0)","rgba(210, 180, 140, 1.0)"],"line":{"color":"rgba(0, 0, 0, 1.0)","width":2.0}},"aspectratio":0.75,"baseratio":0.1}];"""
            |> chartGeneratedContains funnelAreaStyled
        );
        testCase "Funnel area styled layout" ( fun () ->
            emptyLayout funnelAreaStyled
        );
    ]

let indicators =
    [
        ChartDomain.Chart.Indicator(
            value = 200., 
            mode = StyleParam.IndicatorMode.NumberDeltaGauge,
            Delta   = IndicatorDelta.init(Reference=160),
            Range   = StyleParam.Range.MinMax(0., 250.),
            Domain  = Domain.init(Row = 0, Column = 0), 
            UseDefaults = false
        )
        Chart.Indicator(
            value = 120, 
            mode = StyleParam.IndicatorMode.NumberDeltaGauge,
            DeltaReference = 90,
            Range = StyleParam.Range.MinMax(-200., 200.),
            GaugeShape = StyleParam.IndicatorGaugeShape.Bullet,
            ShowGaugeAxis = false,
            Domain  = Domain.init(Row = 0, Column = 1), 
            UseDefaults = false
        )
        Chart.Indicator(
            value = "300", 
            mode = StyleParam.IndicatorMode.NumberDelta,
            DeltaReference = 90.,
            Domain  = Domain.init(Row = 1, Column = 0), 
            UseDefaults = false
        )        
        Chart.Indicator(
            value = 40., 
            mode = StyleParam.IndicatorMode.Delta,
            DeltaReference = 90.,
            Domain  = Domain.init(Row = 1, Column = 1), 
            UseDefaults = false
        )
    ]
    |> Chart.combine
    |> Chart.withLayoutGridStyle(Rows = 2, Columns = 2)


[<Tests>]
let ``Indicator charts`` =
    testList "FinanceCharts.Indicator charts" [
        testCase "Indicator data" ( fun () ->
            """var data = [{"type":"indicator","mode":"number+delta+gauge","value":200.0,"domain":{"row":0,"column":0},"delta":{"reference":160},"gauge":{"axis":{"range":[0.0,250.0]}}},{"type":"indicator","mode":"number+delta+gauge","value":120,"domain":{"row":0,"column":1},"delta":{"reference":90},"gauge":{"axis":{"visible":false,"range":[-200.0,200.0]},"shape":"bullet"}},{"type":"indicator","mode":"number+delta","value":"300","domain":{"row":1,"column":0},"delta":{"reference":90.0},"gauge":{"axis":{}}},{"type":"indicator","mode":"delta","value":40.0,"domain":{"row":1,"column":1},"delta":{"reference":90.0},"gauge":{"axis":{}}}];"""
            |> chartGeneratedContains indicators
        );
        testCase "Indicator layout" ( fun () ->
            """var layout = {"grid":{"rows":2,"columns":2}};"""
            |> chartGeneratedContains indicators
        );
    ]