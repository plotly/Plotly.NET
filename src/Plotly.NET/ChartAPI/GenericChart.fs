namespace Plotly.NET

open DynamicObj
open System
open Newtonsoft.Json
open System.Runtime.CompilerServices

/// HTML template for Plotly.js
module HTML =

    let doc =
        """
<!DOCTYPE html>
<html>
    <head>
        <!-- Plotly.js -->
        <meta http-equiv="X-UA-Compatible" content="IE=11" >
        <script src="https://cdn.plot.ly/plotly-2.4.2.min.js"></script>
        [ADDITIONAL_HEAD_TAGS]
        <style>
        .container {
          padding-right: 25px;
          padding-left: 25px;
          margin-right: 0 auto;
          margin-left: 0 auto;
        }
        @media (min-width: 768px) {
          .container {
            width: 750px;
          }
        }
        @media (min-width: 992px) {
          .container {
            width: 970px;
          }
        }
        @media (min-width: 1200px) {
          .container {
            width: 1170px;
          }
        }
        </style>
    </head>
    <body>
      [CHART]
      [DESCRIPTION]
    </body>
</html>"""


  //  let chart =
  //      """<div id="[ID]" style="width: [WIDTH]px; height: [HEIGHT]px;"><!-- Plotly chart will be drawn inside this DIV --></div>
  //<script>
  //  var data = [DATA];
  //  var layout = [LAYOUT];
  //  var config = [CONFIG];
  //  Plotly.newPlot('[ID]', data, layout, config);
  //</script>"""
    let chart =
        let newScript = new System.Text.StringBuilder()
        newScript.AppendLine("""<div id="[ID]"><!-- Plotly chart will be drawn inside this DIV --></div>""") |> ignore
        newScript.AppendLine("<script type=\"text/javascript\">") |> ignore
        newScript.AppendLine(@"
            var renderPlotly_[SCRIPTID] = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.4.2.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {")  |> ignore
        newScript.AppendLine(@"
            var data = [DATA];
            var layout = [LAYOUT];
            var config = [CONFIG];
            Plotly.newPlot('[ID]', data, layout, config);")  |> ignore
        newScript.AppendLine("""});
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
            }""") |> ignore
        newScript.AppendLine("</script>") |> ignore
        newScript.ToString()


    let staticChart =
        """<div id="[ID]" style="display: none;"><!-- Plotly chart will be drawn inside this DIV --></div>

  <img id="jpg-export"></img>

  <script>
    var d3 = Plotly.d3;
    var img_jpg= d3.select('#jpg-export');
    var data = [DATA];
    var layout = [LAYOUT];
    var config = [CONFIG];
    Plotly.newPlot('[ID]', data, layout, config)
    // static image in jpg format

    .then(
        function(gd)
         {
          Plotly.toImage(gd,{format:'[IMAGEFORMAT]',height: [HEIGHT],width: [WIDTH]})
             .then(
                function(url)
             {
                 img_jpg.attr("src", url);

             }
             )
        });
  </script>"""


/// Module to represent a GenericChart
[<Extension>]
module GenericChart =

    
    let internal jsonConfig = JsonSerializerSettings()
    jsonConfig.ReferenceLoopHandling <- ReferenceLoopHandling.Serialize

    type Figure =
        {
            [<JsonProperty("data")>]
            Data: Trace list
            [<JsonProperty("layout")>]
            Layout: Layout
            [<JsonProperty("frames")>]
            Frames: Frame list
        }
        static member create data layout = {Data = data; Layout = layout; Frames=[]}

    //TO-DO refactor as type with static members to remove verbose top namespace from 'GenericChart.GenericChart'
    type GenericChart =
        | Chart of Trace * Layout * Config * DisplayOptions
        | MultiChart of Trace list * Layout * Config * DisplayOptions

    let toFigure (gChart:GenericChart) =
        match gChart with
        | Chart (trace,layout,_,_) -> Figure.create [trace] layout
        | MultiChart (traces,layout,_,_) -> Figure.create traces layout

    let fromFigure (fig:Figure) =
        let traces = fig.Data
        let layout = fig.Layout
        if traces.Length <> 1 then
            MultiChart (traces,layout,Config(), DisplayOptions())
        else
            Chart (traces.[0], layout, Config(), DisplayOptions())

    let getTraces gChart =
        match gChart with
        | Chart (trace,_,_,_)       -> [trace]
        | MultiChart (traces,_,_,_) -> traces

    let getLayout gChart =
        match gChart with
        | Chart (_,layout,_,_)      -> layout
        | MultiChart (_,layout,_,_) -> layout

    let setLayout layout gChart =
        match gChart with
        | Chart (t,_,c,d)      -> Chart (t,layout,c,d)
        | MultiChart (t,_,c,d) -> MultiChart (t,layout,c,d)

    // Adds a Layout function to the GenericChart
    let addLayout layout gChart =
        match gChart with
        | Chart (trace,l', c, d) ->
            Chart (trace, (DynObj.combine l' layout |> unbox), c, d )
        | MultiChart (traces, l', c, d) ->
            MultiChart (traces, (DynObj.combine l' layout |> unbox), c, d)

    /// Returns a tuple containing the width and height of a GenericChart's layout if the property is set, otherwise returns None
    let tryGetLayoutSize gChart =
        let layout = getLayout gChart

        layout.TryGetTypedValue<int> "width",
        layout.TryGetTypedValue<int> "height"

    let getConfig gChart =
        match gChart with
        | Chart (_,_,c,_)      -> c
        | MultiChart (_,_,c,_) -> c

    let setConfig config gChart =
        match gChart with
        | Chart (t,l,_,d)      -> Chart (t,l,config,d)
        | MultiChart (t,l,_,d) -> MultiChart (t,l,config,d)

    let getDisplayOptions gChart =
        match gChart with
        | Chart (_,_,_,d)      -> d
        | MultiChart (_,_,_,d) -> d

    let setDisplayOptions displayOpts gChart =
        match gChart with
        | Chart (t,l,c,_)      -> Chart (t,l,c,displayOpts)
        | MultiChart (t,l,c,_) -> MultiChart (t,l,c,displayOpts)

    // // Adds multiple Layout functions to the GenericChart
    // let addLayouts layouts gChart =
    //     match gChart with
    //     | Chart (trace,_) ->
    //         let l' = getLayouts gChart
    //         Chart (trace,Some (layouts@l'))
    //     | MultiChart (traces,_) ->
    //         let l' = getLayouts gChart
    //         MultiChart (traces, Some (layouts@l'))

    // Combines two GenericChart
    let combine(gCharts:seq<GenericChart>) =
        let combineLayouts (first:Layout) (second:Layout) =
            DynObj.combine first second |> unbox

        let combineConfigs (first:Config) (second:Config) =
            DynObj.combine first second |> unbox

        let combineDisplayOptions (first:DisplayOptions) (second:DisplayOptions) =
            DynObj.combine first second |> unbox

        gCharts
        |> Seq.reduce (fun acc elem ->
            match acc,elem with
            | MultiChart (traces, l1, c1, d1),Chart (trace, l2, c2, d2)         ->
                MultiChart (List.append traces [trace], combineLayouts l1 l2, combineConfigs c1 c2, combineDisplayOptions d1 d2)
            | MultiChart (traces1,l1,c1,d1),MultiChart (traces2,l2,c2,d2) ->
                MultiChart (List.append traces1 traces2,combineLayouts l1 l2, combineConfigs c1 c2, combineDisplayOptions d1 d2)
            | Chart (trace1,l1,c1,d1),Chart (trace2,l2,c2,d2)             ->
                MultiChart ([trace1;trace2],combineLayouts l1 l2, combineConfigs c1 c2, combineDisplayOptions d1 d2)
            | Chart (trace,l1,c1,d1),MultiChart (traces,l2,c2,d2)         ->
                MultiChart (List.append [trace] traces ,combineLayouts l1 l2, combineConfigs c1 c2, combineDisplayOptions d1 d2)
                        )

    // let private materialzeLayout (layout:(Layout -> Layout) list) =
    //     let rec reduce fl v =
    //         match fl with
    //         | h::t -> reduce t (h v)
    //         | [] -> v

    //     // Attention order ov layout functions is reverse
    //     let l' = layout |> List.rev
    //     reduce l' (Layout())


    /// Converts a GenericChart to it HTML representation. The div layer has a default size of 600 if not specified otherwise.
    let toChartHTML gChart =
        let guid = Guid.NewGuid().ToString()
        let tracesJson =
            let traces = getTraces gChart
            JsonConvert.SerializeObject(traces, jsonConfig)
        let layoutJson =
            let layout = getLayout gChart
            JsonConvert.SerializeObject(layout, jsonConfig)
        let configJson =
            let config = getConfig gChart
            JsonConvert.SerializeObject(config, jsonConfig)

        let displayOpts = getDisplayOptions gChart

        let dims = tryGetLayoutSize gChart

        let width,height =  
            let w,h = tryGetLayoutSize gChart
            w |> Option.defaultValue 600,
            h |> Option.defaultValue 600


        HTML.chart
            //.Replace("style=\"width: [WIDTH]px; height: [HEIGHT]px;\"","style=\"width: 600px; height: 600px;\"")
            .Replace("[WIDTH]", string width)
            .Replace("[HEIGHT]", string height)
            .Replace("[ID]", guid)
            .Replace("[SCRIPTID]", guid.Replace("-",""))
            .Replace("[DATA]", tracesJson)
            .Replace("[LAYOUT]", layoutJson)
            .Replace("[CONFIG]", configJson)
            |> DisplayOptions.replaceHtmlPlaceholders displayOpts







    /// Converts a GenericChart to it HTML representation and set the size of the div
    let toChartHtmlWithSize (width:int) (height:int) (gChart:GenericChart) =
        let guid = Guid.NewGuid().ToString()
        let tracesJson =
            let traces = getTraces gChart
            JsonConvert.SerializeObject(traces, jsonConfig)
        let layoutJson =
            let layout = getLayout gChart
            JsonConvert.SerializeObject(layout, jsonConfig)
        let configJson =
            let config = getConfig gChart
            JsonConvert.SerializeObject(config, jsonConfig)

        let displayOpts = getDisplayOptions gChart

       
        HTML.chart
            .Replace("[ID]", guid)
            .Replace("[WIDTH]", string width )
            .Replace("[HEIGHT]", string height)
            .Replace("[DATA]", tracesJson)
            .Replace("[LAYOUT]", layoutJson)
            .Replace("[CONFIG]", configJson)
            |> DisplayOptions.replaceHtmlPlaceholders displayOpts

    /// Converts a GenericChart to it HTML representation and embeds it into a html page.
    let toEmbeddedHTML gChart =
        let chartMarkup =
            toChartHTML gChart

        let displayOpts = getDisplayOptions gChart

        HTML.doc
            .Replace("[CHART]", chartMarkup)
            |> DisplayOptions.replaceHtmlPlaceholders displayOpts

    /// Converts a GenericChart to its Image representation
    let toChartImage (format:StyleParam.ImageFormat) gChart =
        let guid = Guid.NewGuid().ToString()
        let tracesJson =
            let traces = getTraces gChart
            JsonConvert.SerializeObject(traces, jsonConfig)
        let layoutJson =
            let layout = getLayout gChart
            JsonConvert.SerializeObject(layout, jsonConfig)

        let html =
            HTML.staticChart
                //.Replace("style=\"width: [WIDTH]px; height: [HEIGHT]px;\"","style=\"width: 600px; height: 600px;\"")
                .Replace("[WIDTH]", string 600 )
                .Replace("[HEIGHT]", string 600)
                .Replace("[ID]", guid)
                .Replace("[DATA]", tracesJson)
                .Replace("[LAYOUT]", layoutJson)
                .Replace("[IMAGEFORMAT]",format.ToString().ToLower())
                .Replace("[CONFIG]","{}")
        html

    /// Converts a GenericChart to an image and embeds it into a html page
    let toEmbeddedImage (format:StyleParam.ImageFormat) gChart =
        let html =
            let chartMarkup =
                toChartImage format gChart
            HTML.doc
                .Replace("[CHART]", chartMarkup)
                .Replace("[CONFIG]","{}")
        html


    /// Creates a new GenericChart whose traces are the results of applying the given function to each of the trace of the GenericChart.
    let mapTrace f gChart =
        match gChart with
        | Chart (trace, layout, config, displayOpts)       -> Chart (f trace, layout, config, displayOpts)
        | MultiChart (traces, layout, config, displayOpts) -> MultiChart (traces |> List.map f, layout, config, displayOpts)

    /// Creates a new GenericChart whose traces are the results of applying the given function to each of the trace of the GenericChart.
    /// The integer index passed to the function indicates the index (from 0) of element being transformed.
    let mapiTrace f gChart =
        match gChart with
        | Chart (trace, layout, config, displayOpts)       -> Chart (f 0 trace, layout, config, displayOpts)
        | MultiChart (traces, layout, config, displayOpts) -> MultiChart (traces |> List.mapi f, layout, config, displayOpts)

    /// Returns the number of traces within the GenericChart
    let countTrace gChart =
        match gChart with
        | Chart (_)             -> 1
        | MultiChart (traces,_,_,_) -> traces |> Seq.length

    /// Returns true if the given chart contains a trace for which the predicate function returns true
    let existsTrace (predicate: Trace -> bool) gChart =
        match gChart with
        | Chart (trace,_,_,_)       -> predicate trace
        | MultiChart (traces,_,_,_) -> traces |> List.exists predicate

    /// Converts from a trace object and a layout object into GenericChart. If useDefaults = true, also sets the default Chart properties found in `Defaults`
    let ofTraceObject (useDefaults:bool) trace = //layout =
        if useDefaults then 
            GenericChart.Chart(
                trace, 
                Layout.init(
                    Width = Defaults.DefaultWidth, 
                    Height = Defaults.DefaultHeight, 
                    Template = (Defaults.DefaultTemplate :> DynamicObj)
                ), 
                Defaults.DefaultConfig, 
                Defaults.DefaultDisplayOptions
            )
        else 
            GenericChart.Chart(trace, Layout(), Config(), DisplayOptions())

    /// Converts from a list of trace objects and a layout object into GenericChart. If useDefaults = true, also sets the default Chart properties found in `Defaults`
    let ofTraceObjects (useDefaults:bool) traces = // layout =
        if useDefaults then 
            GenericChart.MultiChart(
                traces, 
                Layout.init(
                    Width = Defaults.DefaultWidth, 
                    Height = Defaults.DefaultHeight, 
                    Template = (Defaults.DefaultTemplate :> DynamicObj)
                ), 
                Defaults.DefaultConfig, 
                Defaults.DefaultDisplayOptions
            )
        else 
            GenericChart.MultiChart(traces, Layout(), Config(), DisplayOptions())

    ///
    let mapLayout f gChart =
        match gChart with
        | Chart (trace, layout, config, displayOpts)       -> Chart (trace,f layout,config, displayOpts)
        | MultiChart (traces, layout, config, displayOpts) -> MultiChart (traces,f layout,config, displayOpts)
        
    ///
    let mapConfig f gChart =
        match gChart with
        | Chart (trace, layout, config, displayOpts)       -> Chart (trace, layout, f config, displayOpts)
        | MultiChart (traces, layout, config, displayOpts) -> MultiChart (traces, layout, f config, displayOpts)

    ///
    let mapDisplayOptions f gChart =
        match gChart with
        | Chart (trace, layout, config, displayOpts)       -> Chart (trace, layout, config, f displayOpts)
        | MultiChart (traces, layout, config, displayOpts) -> MultiChart (traces,layout,config, f displayOpts)

    /// returns a single TraceID (when all traces of the charts are of the same type), or traceID.Multi if the chart contains traces of multiple different types
    let getTraceID gChart =
        match gChart with
        | Chart (trace, _, _, _)       -> TraceID.ofTrace trace
        | MultiChart (traces, layout, config, displayOpts) -> TraceID.ofTraces traces
        
    /// returns a list of TraceIDs representing the types of all traces contained in the chart.
    let getTraceIDs gChart =
        match gChart with
        | Chart (trace, _, _, _)       -> [TraceID.ofTrace trace]
        | MultiChart (traces, _, _, _) -> traces |> List.map TraceID.ofTrace
