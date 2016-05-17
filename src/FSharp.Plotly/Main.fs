namespace FSharp.Plotly

open Gramar
open Newtonsoft.Json
open System

module HTML =

    let doc =
        """<head>
  <!-- Plotly.js -->
  <script src="https://cdn.plot.ly/plotly-latest.min.js"></script>
</head>

<body>
  [CHART]
</body>"""

    let chart =
        """<div id="[ID]" style="width: [WIDTH]px; height: [HEIGHT]px;"><!-- Plotly chart will be drawn inside this DIV --></div>
  <script>
    var data = [DATA];
    var layout = [LAYOUT];
    Plotly.newPlot('[ID]', data, layout);
  </script>"""

open System.IO

type PlotlyChart() =
    let guid = Guid.NewGuid().ToString()

    let mutable height = "500"
    let mutable width = "900"

    [<DefaultValue>]
    val mutable private traces: seq<Trace>

    [<DefaultValue>]
    val mutable private layout: Layout option

    [<DefaultValue>]
    val mutable private labels: seq<string> option

    let serializeTraces names (traces:seq<Trace>) =
        match names with
        | None -> traces
        | Some names ->            
            traces
            |> Seq.mapi (fun i trace ->
                trace.name <- Seq.nth i names
                trace)
        |> JsonConvert.SerializeObject

    member __.Plot(data:seq<#Trace>, ?Layout, ?Labels) =
        data
        |> Seq.map (fun trace -> trace :> Trace)
        |> fun traces -> __.traces <- traces
        __.layout <- Layout
        __.labels <- Labels

    member __.Show() =
        let tracesJson = serializeTraces __.labels __.traces
        let layoutJson =
            match __.layout with
            | None -> "\"\""
            | Some x -> JsonConvert.SerializeObject x
        let html =
            let chartMarkup =
                HTML.chart
                    .Replace("[ID]", guid)
                    .Replace("[WIDTH]", width)
                    .Replace("[HEIGHT]", height)
                    .Replace("[DATA]", tracesJson)
                    .Replace("[LAYOUT]", layoutJson)
            HTML.doc.Replace("[CHART]", chartMarkup)
        let tempPath = Path.GetTempPath()
        let file = sprintf "%s.html" guid
        let path = Path.Combine(tempPath, file)
        File.WriteAllText(path, html)
        System.Diagnostics.Process.Start(path) |> ignore

    member __.GetInlineHtml() =
        let tracesJson = serializeTraces __.labels __.traces
        let layoutJson =
            match __.layout with
            | None -> "\"\""
            | Some x -> JsonConvert.SerializeObject x
        HTML.chart
            .Replace("[ID]", guid)
            .Replace("[WIDTH]", width)
            .Replace("[HEIGHT]", height)
            .Replace("[DATA]", tracesJson)
            .Replace("[LAYOUT]", layoutJson)

    member __.WithWidth(widthValue: int) = width <- string widthValue

    member __.WithHeight(heightValue: int) = height <- string heightValue

    member __.WithLayout(layoutObj) = __.layout <- Some layoutObj

    member __.WithLabels(labels) = __.labels <- Some labels 

type key = IConvertible
type value = IConvertible

type Plotly =

    static member Plot(data:seq<#Trace>) = 
        let chart = PlotlyChart()
        chart.Plot data
        chart

    static member Plot(data) = 
        let chart = PlotlyChart()
        chart.Plot [data]
        chart

    static member Plot(data, layout) =
        let chart = PlotlyChart()
        chart.Plot(data, layout)
        chart

    static member Plot(data, layout) =
        let chart = PlotlyChart()
        chart.Plot([data], layout)
        chart

    static member Show(chart:PlotlyChart) = chart.Show()

    static member WithWidth width (chart:PlotlyChart) =
        chart.WithWidth width
        chart

    static member WithHeight height (chart:PlotlyChart) =
        chart.WithHeight height
        chart

    static member WithLayout layout (chart:PlotlyChart) =
        chart.WithLayout layout
        chart

    static member WithLabels labels (chart:PlotlyChart) =
        chart.WithLabels labels
        chart

type Plotly with

    static member Line(data:seq<#key * #value>) =
        let x = Seq.map fst data
        let y = Seq.map snd data
        let scatter = Scatter(x = x, y = y)
        Plotly.Plot [scatter]

    static member Line(data:seq<#seq<#key * #value>>) =
        let scatters =
            data
            |> Seq.map (fun series ->
                let x = Seq.map fst series
                let y = Seq.map snd series
                Scatter(x = x, y = y)
            )
        Plotly.Plot scatters

    static member Scatter(data:seq<#key * #value>) =
        let x = Seq.map fst data
        let y = Seq.map snd data
        let scatter = Scatter(x = x, y = y, mode = "markers")
        Plotly.Plot [scatter]

    static member Scatter(data:seq<#seq<#key * #value>>) =
        let scatters =
            data
            |> Seq.map (fun series ->
                let x = Seq.map fst series
                let y = Seq.map snd series
                Scatter(x = x, y = y, mode = "markers")
            )
        Plotly.Plot scatters

    static member Column(data:seq<#key * #value>) =
        let x = Seq.map fst data
        let y = Seq.map snd data
        let bar = Bar(x = x, y = y)
        Plotly.Plot [bar]

    static member Column(data:seq<#seq<#key * #value>>) =
        let bars =
            data
            |> Seq.mapi (fun i series ->
                let x = Seq.map fst series
                let y = Seq.map snd series
                Bar(x = x, y = y)
            )
        Plotly.Plot bars

    static member Bar(data:seq<#key * #value>) =
        let x = Seq.map fst data
        let y = Seq.map snd data
        let bar = Bar(x = y, y = x, orientation = "h")
        Plotly.Plot [bar]

    static member Bar(data:seq<#seq<#key * #value>>) =
        let bars =
            data
            |> Seq.mapi (fun i series ->
                let x = Seq.map fst series
                let y = Seq.map snd series
                Bar(x = y, y = x, orientation = "h")
            )
        Plotly.Plot bars

    static member Pie(data:seq<#key * #value>) =
        let x = Seq.map fst data
        let y = Seq.map snd data
        let pie = Pie(labels = x, values = y)
        Plotly.Plot [pie]

    static member Area(data:seq<#key * #value>) =
        let x = Seq.map fst data
        let y = Seq.map snd data
        let area = Scatter(x = x, y = y, fill = "tozeroy")
        Plotly.Plot [area]

    static member Area(data:seq<#seq<#key * #value>>) =
        let areas =
            data
            |> Seq.mapi (fun i series ->
                let x = Seq.map fst series
                let y = Seq.map snd series
                match i with
                | 0 -> Scatter(x = x, y = y, fill = "tozeroy")
                | _ -> Scatter(x = x, y = y, fill = "tonexty")
            )
        Plotly.Plot areas
