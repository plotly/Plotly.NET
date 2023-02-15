namespace Plotly.NET

open DynamicObj
open System
open Newtonsoft.Json
open System.Runtime.CompilerServices
open Giraffe.ViewEngine

type HTML() =

    static member Doc(
        chart,
        plotlyCDN,
        ?AdditionalHeadTags,
        ?Description
    ) =
        let additionalHeadTags = defaultArg AdditionalHeadTags []
        let description = defaultArg Description []

        let plotlyScript = 
            script [_src plotlyCDN] []

        html [] [
            head [] [
                plotlyScript
                yield! additionalHeadTags
            ]
            body [] [
                yield! chart
                yield! description
            ]
        ]

    static member CreateChartHTML(
        data: string,
        layout: string,
        config: string
    ) =

        let scriptContent = """
var renderPlotly_[SCRIPTID] = function() {
    var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-[PLOTLYJS_VERSION].min'}}) || require;
    fsharpPlotlyRequire(['plotly'], function(Plotly) {
        var data = [DATA];
        var layout = [LAYOUT];
        var config = [CONFIG];
        Plotly.newPlot('[ID]', data, layout, config);
    });
};
if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
    var script = document.createElement("script");
    script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
    script.onload = function(){
        renderPlotly_[SCRIPTID]();
    };
    document.getElementsByTagName("head")[0].appendChild(script);
}
else {
    renderPlotly_[SCRIPTID]();
}
"""
        let guid = Guid.NewGuid().ToString()

        [
            div [_id guid] [comment "Plotly chart will be drawn inside this DIV"]
            script [_type "text/javascript"] [
                rawText (
                    scriptContent
                        .Replace("[PLOTLYJS_VERSION]",Globals.PLOTLYJS_VERSION)
                        .Replace("[SCRIPTID]",guid.Replace("-",""))
                        .Replace("[ID]",guid)
                        .Replace("[DATA]",data)
                        .Replace("[LAYOUT]",layout)
                        .Replace("[CONFIG]",config)
                )]
        ]
        
/// Module to represent a GenericChart
[<Extension>]
module GenericChart =

    type Figure =
        {
            [<JsonProperty("data")>]
            Data: Trace list
            [<JsonProperty("layout")>]
            Layout: Layout
            [<JsonProperty("frames")>]
            Frames: Frame list
        }
        static member create data layout =
            {
                Data = data
                Layout = layout
                Frames = []
            }

    //TO-DO refactor as type with static members to remove verbose top namespace from 'GenericChart.GenericChart'
    type GenericChart =
        | Chart of Trace * Layout * Config * DisplayOptions
        | MultiChart of Trace list * Layout * Config * DisplayOptions

    let toFigure (gChart: GenericChart) =
        match gChart with
        | Chart (trace, layout, _, _) -> Figure.create [ trace ] layout
        | MultiChart (traces, layout, _, _) -> Figure.create traces layout

    let fromFigure (fig: Figure) =
        let traces = fig.Data
        let layout = fig.Layout

        if traces.Length <> 1 then
            MultiChart(traces, layout, Defaults.DefaultConfig, Defaults.DefaultDisplayOptions)
        else
            Chart(traces.[0], layout, Defaults.DefaultConfig, Defaults.DefaultDisplayOptions)

    let getTraces gChart =
        match gChart with
        | Chart (trace, _, _, _) -> [ trace ]
        | MultiChart (traces, _, _, _) -> traces

    let getLayout gChart =
        match gChart with
        | Chart (_, layout, _, _) -> layout
        | MultiChart (_, layout, _, _) -> layout

    let setLayout layout gChart =
        match gChart with
        | Chart (t, _, c, d) -> Chart(t, layout, c, d)
        | MultiChart (t, _, c, d) -> MultiChart(t, layout, c, d)

    // Adds a Layout function to the GenericChart
    let addLayout layout gChart =
        match gChart with
        | Chart (trace, l', c, d) -> Chart(trace, (Layout.combine l' layout), c, d)
        | MultiChart (traces, l', c, d) -> MultiChart(traces, (Layout.combine l' layout), c, d)

    /// Returns a tuple containing the width and height of a GenericChart's layout if the property is set, otherwise returns None
    let tryGetLayoutSize gChart =
        let layout = getLayout gChart
        layout.TryGetTypedValue<int> "width", layout.TryGetTypedValue<int> "height"

    let getConfig gChart =
        match gChart with
        | Chart (_, _, c, _) -> c
        | MultiChart (_, _, c, _) -> c

    let setConfig config gChart =
        match gChart with
        | Chart (t, l, _, d) -> Chart(t, l, config, d)
        | MultiChart (t, l, _, d) -> MultiChart(t, l, config, d)

    let addConfig config gChart =
        match gChart with
        | Chart (trace, l, c', d) -> Chart(trace, l, (Config.combine c' config), d)
        | MultiChart (traces, l, c', d) -> MultiChart(traces, l, (Config.combine c' config), d)

    let getDisplayOptions gChart =
        match gChart with
        | Chart (_, _, _, d) -> d
        | MultiChart (_, _, _, d) -> d

    let setDisplayOptions displayOpts gChart =
        match gChart with
        | Chart (t, l, c, _) -> Chart(t, l, c, displayOpts)
        | MultiChart (t, l, c, _) -> MultiChart(t, l, c, displayOpts)

    let addDisplayOptions displayOpts gChart =
        match gChart with
        | Chart (t, l, c, d') -> Chart(t, l, c, (DisplayOptions.combine d' displayOpts))
        | MultiChart (t, l, c, d') -> MultiChart(t, l, c, (DisplayOptions.combine d' displayOpts))

    // // Adds multiple Layout functions to the GenericChart
    // let addLayouts layouts gChart =
    //     match gChart with
    //     | Chart (trace,_) ->
    //         let l' = getLayouts gChart
    //         Chart (trace,Some (layouts@l'))
    //     | MultiChart (traces,_) ->
    //         let l' = getLayouts gChart
    //         MultiChart (traces, Some (layouts@l'))

    open Plotly.NET.LayoutObjects
    // Combines two GenericChart

    let combine (gCharts: seq<GenericChart>) =
        // temporary hard fix for some props, see https://github.com/CSBiology/DynamicObj/issues/11

        gCharts
        |> Seq.reduce (fun acc elem ->
            match acc, elem with
            | MultiChart (traces, l1, c1, d1), Chart (trace, l2, c2, d2) ->
                MultiChart(
                    List.append traces [ trace ],
                    Layout.combine l1 l2,
                    Config.combine c1 c2,
                    DisplayOptions.combine d1 d2
                )
            | MultiChart (traces1, l1, c1, d1), MultiChart (traces2, l2, c2, d2) ->
                MultiChart(
                    List.append traces1 traces2,
                    Layout.combine l1 l2,
                    Config.combine c1 c2,
                    DisplayOptions.combine d1 d2
                )
            | Chart (trace1, l1, c1, d1), Chart (trace2, l2, c2, d2) ->
                MultiChart([ trace1; trace2 ], Layout.combine l1 l2, Config.combine c1 c2, DisplayOptions.combine d1 d2)
            | Chart (trace, l1, c1, d1), MultiChart (traces, l2, c2, d2) ->
                MultiChart(
                    List.append [ trace ] traces,
                    Layout.combine l1 l2,
                    Config.combine c1 c2,
                    DisplayOptions.combine d1 d2
                ))

    let toChartHTMLNodes gChart =
        let tracesJson =
            let traces = getTraces gChart
            JsonConvert.SerializeObject(traces, Globals.JSON_CONFIG)

        let layoutJson =
            let layout = getLayout gChart
            JsonConvert.SerializeObject(layout, Globals.JSON_CONFIG)

        let configJson =
            let config = getConfig gChart
            JsonConvert.SerializeObject(config, Globals.JSON_CONFIG)

        let displayOpts = getDisplayOptions gChart

        div [] [
            yield! HTML.CreateChartHTML(
                tracesJson,
                layoutJson,
                configJson
            )
            yield! displayOpts |> DisplayOptions.getDescription
        ]

    let toChartHTML gChart =
        gChart
        |> toChartHTMLNodes
        |> RenderView.AsString.htmlNode

    /// Converts a GenericChart to it HTML representation and embeds it into a html page.
    let toEmbeddedHTML gChart =
        
        let tracesJson =
            let traces = getTraces gChart
            JsonConvert.SerializeObject(traces, Globals.JSON_CONFIG)

        let layoutJson =
            let layout = getLayout gChart
            JsonConvert.SerializeObject(layout, Globals.JSON_CONFIG)

        let configJson =
            let config = getConfig gChart
            JsonConvert.SerializeObject(config, Globals.JSON_CONFIG)

        let displayOpts = getDisplayOptions gChart

        let additionalHeadTags = (displayOpts |> DisplayOptions.getAdditionalHeadTags)

        let description = (displayOpts |> DisplayOptions.getDescription)

        let plotlyCDN = (displayOpts |> DisplayOptions.getPlotlyCDN)

        HTML.Doc(
            chart = HTML.CreateChartHTML(
                tracesJson,
                layoutJson,
                configJson
            ),
            plotlyCDN = plotlyCDN,
            AdditionalHeadTags = additionalHeadTags,
            Description = description
        )
        |> RenderView.AsString.htmlDocument

    /// Creates a new GenericChart whose traces are the results of applying the given function to each of the trace of the GenericChart.
    let mapTrace f gChart =
        match gChart with
        | Chart (trace, layout, config, displayOpts) -> Chart(f trace, layout, config, displayOpts)
        | MultiChart (traces, layout, config, displayOpts) ->
            MultiChart(traces |> List.map f, layout, config, displayOpts)

    /// Creates a new GenericChart whose traces are the results of applying the given function to each of the trace of the GenericChart.
    /// The integer index passed to the function indicates the index (from 0) of element being transformed.
    let mapiTrace f gChart =
        match gChart with
        | Chart (trace, layout, config, displayOpts) -> Chart(f 0 trace, layout, config, displayOpts)
        | MultiChart (traces, layout, config, displayOpts) ->
            MultiChart(traces |> List.mapi f, layout, config, displayOpts)

    /// Returns the number of traces within the GenericChart
    let countTrace gChart =
        match gChart with
        | Chart (_) -> 1
        | MultiChart (traces, _, _, _) -> traces |> Seq.length

    /// Returns true if the given chart contains a trace for which the predicate function returns true
    let existsTrace (predicate: Trace -> bool) gChart =
        match gChart with
        | Chart (trace, _, _, _) -> predicate trace
        | MultiChart (traces, _, _, _) -> traces |> List.exists predicate

    /// Converts from a trace object and a layout object into GenericChart. If useDefaults = true, also sets the default Chart properties found in `Defaults`
    let ofTraceObject (useDefaults: bool) trace = //layout =
        if useDefaults then
            // copy default instances so we can safely manipulate the respective objects of the created chart without changing global default objects
            let defaultConfig = Config()
            Defaults.DefaultConfig.CopyDynamicPropertiesTo defaultConfig

            let defaultDisplayOpts = DisplayOptions()
            Defaults.DefaultDisplayOptions.CopyDynamicPropertiesTo defaultDisplayOpts

            let defaultTemplate = Template()
            Defaults.DefaultTemplate.CopyDynamicPropertiesTo defaultTemplate

            GenericChart.Chart(
                trace,
                Layout.init (
                    Width = Defaults.DefaultWidth, // no need to copy these, as they are primitives
                    Height = Defaults.DefaultHeight, // no need to copy these, as they are primitives
                    Template = (defaultTemplate :> DynamicObj)
                ),
                defaultConfig,
                defaultDisplayOpts
            )
        else
            GenericChart.Chart(trace, Layout(), Config(), DisplayOptions.initCDNOnly())

    /// Converts from a list of trace objects and a layout object into GenericChart. If useDefaults = true, also sets the default Chart properties found in `Defaults`
    let ofTraceObjects (useDefaults: bool) traces = // layout =
        if useDefaults then
            // copy default instances so we can safely manipulate the respective objects of the created chart without changing global default objects
            let defaultConfig = Config()
            Defaults.DefaultConfig.CopyDynamicPropertiesTo defaultConfig

            let defaultDisplayOpts = DisplayOptions()
            Defaults.DefaultDisplayOptions.CopyDynamicPropertiesTo defaultDisplayOpts

            let defaultTemplate = Template()
            Defaults.DefaultTemplate.CopyDynamicPropertiesTo defaultTemplate

            GenericChart.MultiChart(
                traces,
                Layout.init (
                    Width = Defaults.DefaultWidth,
                    Height = Defaults.DefaultHeight,
                    Template = (defaultTemplate :> DynamicObj)
                ),
                defaultConfig,
                defaultDisplayOpts

            )
        else
            GenericChart.MultiChart(traces, Layout(), Config(), DisplayOptions.initCDNOnly())

    ///
    let mapLayout f gChart =
        match gChart with
        | Chart (trace, layout, config, displayOpts) -> Chart(trace, f layout, config, displayOpts)
        | MultiChart (traces, layout, config, displayOpts) -> MultiChart(traces, f layout, config, displayOpts)

    ///
    let mapConfig f gChart =
        match gChart with
        | Chart (trace, layout, config, displayOpts) -> Chart(trace, layout, f config, displayOpts)
        | MultiChart (traces, layout, config, displayOpts) -> MultiChart(traces, layout, f config, displayOpts)

    ///
    let mapDisplayOptions f gChart =
        match gChart with
        | Chart (trace, layout, config, displayOpts) -> Chart(trace, layout, config, f displayOpts)
        | MultiChart (traces, layout, config, displayOpts) -> MultiChart(traces, layout, config, f displayOpts)

    /// returns a single TraceID (when all traces of the charts are of the same type), or traceID.Multi if the chart contains traces of multiple different types
    let getTraceID gChart =
        match gChart with
        | Chart (trace, _, _, _) -> TraceID.ofTrace trace
        | MultiChart (traces, layout, config, displayOpts) -> TraceID.ofTraces traces

    /// returns a list of TraceIDs representing the types of all traces contained in the chart.
    let getTraceIDs gChart =
        match gChart with
        | Chart (trace, _, _, _) -> [ TraceID.ofTrace trace ]
        | MultiChart (traces, _, _, _) -> traces |> List.map TraceID.ofTrace
