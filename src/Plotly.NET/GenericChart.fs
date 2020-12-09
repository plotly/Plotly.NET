namespace Plotly.NET

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
        <script src="https://cdn.plot.ly/plotly-latest.min.js"></script>
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
        newScript.AppendLine("""<div id="[ID]" style="width: [WIDTH]px; height: [HEIGHT]px;"><!-- Plotly chart will be drawn inside this DIV --></div>""") |> ignore
        newScript.AppendLine("<script type=\"text/javascript\">") |> ignore
        newScript.AppendLine(@"
            var renderPlotly = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
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
                    renderPlotly();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly();
            }""") |> ignore
        newScript.AppendLine("</script>") |> ignore
        newScript.ToString()


    let description ="""<div class=container>
  <h3>[DESCRIPTIONHEADING]</h3>
  <p>[DESCRIPTIONTEXT]</p>
  </div>"""


    let staticChart =
        """<div id="[ID]" style="width: [WIDTH]px; height: [HEIGHT]px;display: none;"><!-- Plotly chart will be drawn inside this DIV --></div>

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

module ChartDescription =

    type Description =
        {
            Heading : string
            Text    : string
        }

    let toDescriptionHtml (d:Description) =
        HTML.description
            .Replace("[DESCRIPTIONHEADING]",d.Heading)
            .Replace("[DESCRIPTIONTEXT]",d.Text)

/// Module to represent a GenericChart
[<Extension>]
module GenericChart =

    open Trace
    open ChartDescription

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
        | Chart of Trace * Layout * Config
        | MultiChart of Trace list * Layout * Config

    let toFigure (gChart:GenericChart) =
        match gChart with
        | Chart (trace,layout,_) -> Figure.create [trace] layout
        | MultiChart (traces,layout,_) -> Figure.create traces layout

    let fromFigure (fig:Figure) =
        let traces = fig.Data
        let layout = fig.Layout
        if traces.Length <> 1 then
            MultiChart (traces,layout,Config())
        else
            Chart (traces.[0], layout, Config())

    let getTraces gChart =
        match gChart with
        | Chart (trace,_,_)       -> [trace]
        | MultiChart (traces,_,_) -> traces

    let getLayout gChart =
        match gChart with
        | Chart (_,layout,_)      -> layout
        | MultiChart (_,layout,_) -> layout

    let setLayout layout gChart =
        match gChart with
        | Chart (t,_,c)      -> Chart (t,layout,c)
        | MultiChart (t,_,c) -> MultiChart (t,layout,c)

    // Adds a Layout function to the GenericChart
    let addLayout layout gChart =
        match gChart with
        | Chart (trace,l',c) ->
            Chart (trace, (DynObj.combine l' layout |> unbox),c )
        | MultiChart (traces,l',c) ->
            MultiChart (traces, (DynObj.combine l' layout |> unbox),c)


    /// Returns a tuple containing the width and height of a GenericChart's layout if the property is set, otherwise returns None
    let tryGetLayoutSize gChart =
        let layout = getLayout gChart
        let width,height =
            layout.TryGetTypedValue<float> "width",
            layout.TryGetTypedValue<float> "height"
        match (width,height) with
        |(Some w, Some h) -> Some (w,h)
        |_ -> None

    let getConfig gChart =
        match gChart with
        | Chart (_,_,c)      -> c
        | MultiChart (_,_,c) -> c

    let setConfig config gChart =
        match gChart with
        | Chart (t,l,_)      -> Chart (t,l,config)
        | MultiChart (t,l,_) -> MultiChart (t,l,config)

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

        gCharts
        |> Seq.reduce (fun acc elem ->
            match acc,elem with
            | MultiChart (traces,l1,c1),Chart (trace,l2,c2)         ->
                MultiChart (List.append traces [trace], combineLayouts l1 l2, combineConfigs c1 c2)
            | MultiChart (traces1,l1,c1),MultiChart (traces2,l2,c2) ->
                MultiChart (List.append traces1 traces2,combineLayouts l1 l2, combineConfigs c1 c2)
            | Chart (trace1,l1,c1),Chart (trace2,l2,c2)             ->
                MultiChart ([trace1;trace2],combineLayouts l1 l2, combineConfigs c1 c2)
            | Chart (trace,l1,c1),MultiChart (traces,l2,c2)         ->
                MultiChart (List.append [trace] traces ,combineLayouts l1 l2, combineConfigs c1 c2)
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
            getTraces gChart
            |> JsonConvert.SerializeObject
        let layoutJson =
            getLayout gChart
            |> JsonConvert.SerializeObject
        let configJson =
            getConfig gChart
            |> JsonConvert.SerializeObject

        let dims = tryGetLayoutSize gChart
        let width,height =
            match dims with
            |Some (w,h) -> w,h
            |None -> 600., 600.

        let html =
            HTML.chart
                //.Replace("style=\"width: [WIDTH]px; height: [HEIGHT]px;\"","style=\"width: 600px; height: 600px;\"")
                .Replace("[WIDTH]", string width)
                .Replace("[HEIGHT]", string height)
                .Replace("[ID]", guid)
                .Replace("[DATA]", tracesJson)
                .Replace("[LAYOUT]", layoutJson)
                .Replace("[CONFIG]", configJson)
        html

    /// Converts a GenericChart to it HTML representation and set the size of the div
    let toChartHtmlWithSize (width:int) (height:int) (gChart:GenericChart) =
        let guid = Guid.NewGuid().ToString()
        let tracesJson =
            getTraces gChart
            |> JsonConvert.SerializeObject
        let layoutJson =
            getLayout gChart
            |> JsonConvert.SerializeObject
        let configJson =
            getConfig gChart
            |> JsonConvert.SerializeObject

        let html =
            HTML.chart
                .Replace("[ID]", guid)
                .Replace("[WIDTH]", string width )
                .Replace("[HEIGHT]", string height)
                .Replace("[DATA]", tracesJson)
                .Replace("[LAYOUT]", layoutJson)
                .Replace("[CONFIG]", configJson)
        html


    let toEmbeddedHtmlWithDescription (description:Description) gChart =
        let chartMarkup =
            toChartHTML gChart

        let descriptionMarkup =
            toDescriptionHtml description

        HTML.doc
            .Replace("[CHART]", chartMarkup)
            .Replace("[DESCRIPTION]", descriptionMarkup)


    /// Converts a GenericChart to it HTML representation and embeds it into a html page.
    let toEmbeddedHTML gChart =
        let chartMarkup =
            toChartHTML gChart

        HTML.doc
            .Replace("[CHART]", chartMarkup)
            .Replace("[DESCRIPTION]", "")

    /// Converts a GenericChart to its Image representation
    let toChartImage (format:StyleParam.ImageFormat) gChart =
        let guid = Guid.NewGuid().ToString()
        let tracesJson =
            getTraces gChart
            |> JsonConvert.SerializeObject
        let layoutJson =
            getLayout gChart
            |> JsonConvert.SerializeObject

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
        | Chart (trace,layout,config)       -> Chart (f trace,layout,config)
        | MultiChart (traces,layout,config) -> MultiChart (traces |> List.map f,layout,config)

    /// Creates a new GenericChart whose traces are the results of applying the given function to each of the trace of the GenericChart.
    /// The integer index passed to the function indicates the index (from 0) of element being transformed.
    let mapiTrace f gChart =
        match gChart with
        | Chart (trace,layout,config)       -> Chart (f 0 trace,layout,config)
        | MultiChart (traces,layout,config) -> MultiChart (traces |> List.mapi f,layout,config)

    /// Returns the number of traces within the GenericChart
    let countTrace gChart =
        match gChart with
        | Chart (_)             -> 1
        | MultiChart (traces,_,_) -> traces |> Seq.length

    /// Creates a new GenericChart whose traces are the results of applying the given function to each of the trace of the GenericChart.
    let existsTrace (f:Trace->bool) gChart =
        match gChart with
        | Chart (trace,_,_)       -> f trace
        | MultiChart (traces,_,_) -> traces |> List.exists f

    /// Converts from a trace object and a layout object into GenericChart
    let ofTraceObject trace = //layout =
        GenericChart.Chart(trace, Layout(), Config())

    /// Converts from a list of trace objects and a layout object into GenericChart
    let ofTraceObjects traces = // layout =
        GenericChart.MultiChart(traces, Layout(), Config())

    let mapLayout f gChart =
        match gChart with
        | Chart (trace,layout,config)       -> Chart (trace,f layout,config)
        | MultiChart (traces,layout,config) -> MultiChart (traces,f layout,config)
