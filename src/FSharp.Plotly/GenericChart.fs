namespace FSharp.Plotly

open System
open Newtonsoft.Json

/// HTML template for Plotly.js 
module HTML =

    let doc =
        """<!DOCTYPE html>
                    <html>
        <head>
  <!-- Plotly.js -->
  <meta http-equiv="X-UA-Compatible" content="IE=11" >
  <script src="https://cdn.plot.ly/plotly-latest.min.js"></script>
</head>

<body>
  [CHART]
</body>
</html>"""

    let chart =
        """<div id="[ID]" style="width: [WIDTH]px; height: [HEIGHT]px;"><!-- Plotly chart will be drawn inside this DIV --></div>        
  <script>
    var data = [DATA];
    var layout = [LAYOUT];
    Plotly.newPlot('[ID]', data, layout);
  </script>"""

    let staticChart =
        """<div id="[ID]" style="width: [WIDTH]px; height: [HEIGHT]px;display: none;"><!-- Plotly chart will be drawn inside this DIV --></div>        
  
  <img id="jpg-export"></img>
  
  <script>
    var d3 = Plotly.d3;
    var img_jpg= d3.select('#jpg-export');
    var data = [DATA];
    var layout = [LAYOUT];
    Plotly.newPlot('[ID]', data, layout)
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
module GenericChart =
    
    open Trace
    
    type GenericChart =
        | Chart of Trace * Layout
        | MultiChart of Trace list * Layout


        
    let getTraces gChart =
        match gChart with
        | Chart (trace,_)       -> [trace]
        | MultiChart (traces,_) -> traces  

    let getLayout gChart =
        match gChart with
        | Chart (_,layout)      -> layout
        | MultiChart (_,layout) -> layout

    let setLayout layout gChart =
        match gChart with
        | Chart (t,_)      -> Chart (t,layout)
        | MultiChart (t,_) -> MultiChart (t,layout)



    // Adds a Layout function to the GenericChart
    let addLayout layout gChart =
        match gChart with
        | Chart (trace,l')       -> 
            Chart (trace, (DynObj.combine l' layout |> unbox) )
        | MultiChart (traces,l')       -> 
            MultiChart (traces, (DynObj.combine l' layout |> unbox))
    
    // // Adds multiple Layout functions to the GenericChart
    // let addLayouts layouts gChart =
    //     match gChart with
    //     | Chart (trace,_)       -> 
    //         let l' = getLayouts gChart
    //         Chart (trace,Some (layouts@l'))
    //     | MultiChart (traces,_) -> 
    //         let l' = getLayouts gChart
    //         MultiChart (traces, Some (layouts@l'))

    // Combines two GenericChart
    let combine(gCharts:seq<GenericChart>) =
        let combineLayouts (first:Layout) (second:Layout) = 
            DynObj.combine first second |> unbox
                
            
        gCharts
        |> Seq.reduce (fun acc elem ->
            match acc,elem with
            | MultiChart (traces,l1),Chart (trace,l2)         -> 
                MultiChart (List.append traces [trace], combineLayouts l1 l2)
            | MultiChart (traces1,l1),MultiChart (traces2,l2) -> 
                MultiChart (List.append traces1 traces2,combineLayouts l1 l2)
            | Chart (trace1,l1),Chart (trace2,l2)             -> 
                MultiChart ([trace1;trace2],combineLayouts l1 l2)
            | Chart (trace,l1),MultiChart (traces,l2)         -> 
                MultiChart (List.append [trace] traces ,combineLayouts l1 l2)
                        ) 
    
    // let private materialzeLayout (layout:(Layout -> Layout) list) =
    //     let rec reduce fl v =
    //         match fl with
    //         | h::t -> reduce t (h v) 
    //         | [] -> v

    //     // Attention order ov layout functions is reverse
    //     let l' = layout |> List.rev
    //     reduce l' (Layout())

        

    /// Converts a GenericChart to it HTML representation
    let toChartHTML gChart =
        let guid = Guid.NewGuid().ToString()
        let tracesJson =
            getTraces gChart
            |> JsonConvert.SerializeObject 
        let layoutJson = 
            getLayout gChart
            |> JsonConvert.SerializeObject 

        let html =
            HTML.chart
                //.Replace("style=\"width: [WIDTH]px; height: [HEIGHT]px;\"","style=\"width: 600px; height: 600px;\"")
                .Replace("[WIDTH]", string 600 )
                .Replace("[HEIGHT]", string 600)
                .Replace("[ID]", guid)                
                .Replace("[DATA]", tracesJson)
                .Replace("[LAYOUT]", layoutJson)
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

        let html =
            HTML.chart
                .Replace("[ID]", guid)
                .Replace("[WIDTH]", string width )
                .Replace("[HEIGHT]", string height)
                .Replace("[DATA]", tracesJson)
                .Replace("[LAYOUT]", layoutJson)
        html
        
    /// Converts a GenericChart to it HTML representation and embeds it into a html page
    let toEmbeddedHTML gChart =
        let html =
            let chartMarkup =
                toChartHTML gChart
            HTML.doc.Replace("[CHART]", chartMarkup)
        html


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
        html

    /// Converts a GenericChart to an image and embeds it into a html page
    let toEmbeddedImage (format:StyleParam.ImageFormat) gChart =
        let html =
            let chartMarkup =
                toChartImage format gChart
            HTML.doc.Replace("[CHART]", chartMarkup)
        html

        
    /// Creates a new GenericChart whose traces are the results of applying the given function to each of the trace of the GenericChart.           
    let mapTrace f gChart =
        match gChart with
        | Chart (trace,layout)       -> Chart (f trace,layout)
        | MultiChart (traces,layout) -> MultiChart (traces |> List.map f,layout) 

    /// Creates a new GenericChart whose traces are the results of applying the given function to each of the trace of the GenericChart.
    /// The integer index passed to the function indicates the index (from 0) of element being transformed.           
    let mapiTrace f gChart =
        match gChart with
        | Chart (trace,layout)       -> Chart (f 0 trace,layout)
        | MultiChart (traces,layout) -> MultiChart (traces |> List.mapi f,layout) 

    /// Returns the number of traces within the GenericChart
    let countTrace gChart =
        match gChart with
        | Chart (_)             -> 1
        | MultiChart (traces,_) -> traces |> Seq.length

    /// Creates a new GenericChart whose traces are the results of applying the given function to each of the trace of the GenericChart.           
    let existsTrace (f:Trace->bool) gChart =
        match gChart with
        | Chart (trace,_)       -> f trace 
        | MultiChart (traces,_) -> traces |> List.exists f
          
    /// Converts from a trace object and a layout object into GenericChart    
    let ofTraceObject trace = //layout =
        GenericChart.Chart(trace, Layout() )
    
    /// Converts from a list of trace objects and a layout object into GenericChart
    let ofTraceObjects traces = // layout =
        GenericChart.MultiChart(traces, Layout() )




