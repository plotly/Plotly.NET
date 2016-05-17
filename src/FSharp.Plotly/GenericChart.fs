namespace FSharp.Plotly

open System
open Newtonsoft.Json


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

module GenericChart =

    type GenericChart =
        | Chart of Trace * Layout option
        | MultiChart  of seq<Trace> * Layout option
        //member width 
        //member height 

        
    let getTraces gChart =
        match gChart with
        | Chart (trace,_)       -> seq [trace]
        | MultiChart (traces,_) -> traces  

    let getLayout gChart =
        match gChart with
        | Chart (_,layout)      -> match layout with
                                   | Some l -> l 
                                   | None -> Layout()
        | MultiChart (_,layout) -> match layout with
                                   | Some l -> l 
                                   | None -> Layout() 
        
    let toHTML gChart =
        let guid = Guid.NewGuid().ToString()
        let tracesJson =
            getTraces gChart
            |> JsonConvert.SerializeObject 
        let layoutJson = 
            getLayout gChart
            |> JsonConvert.SerializeObject 

        let html =
            let chartMarkup =
                HTML.chart
                    .Replace("[ID]", guid)
                    .Replace("[WIDTH]", "900")
                    .Replace("[HEIGHT]", "500")
                    .Replace("[DATA]", tracesJson)
                    .Replace("[LAYOUT]", layoutJson)
            HTML.doc.Replace("[CHART]", chartMarkup)
        html
        
                
    let map f gChart =
        match gChart with
        | Chart (trace,layout)       -> Chart (f trace,layout)
        | MultiChart (traces,layout) -> MultiChart (traces |> Seq.map f,layout) 

    let setLayout layout gChart =
        match gChart with
        | Chart (trace,_)       -> Chart (trace,Some layout)
        | MultiChart (traces,_) -> MultiChart (traces,Some layout)             


        // Combines two layouts
        // if a value is set in l1 and l2, value in l2 is taken
    let combine' (l1:Layout option) (l2:Layout option) =
        let l1 = if l1.IsSome then l1.Value else Layout()
        let l2 = if l2.IsSome then l2.Value else Layout()
        l1.fontOption          <- if l2.ShouldSerializefont() then l2.fontOption else l1.fontOption
        l1.titleOption         <- if l2.ShouldSerializetitle() then l2.titleOption else l1.titleOption
        l1.titlefontOption     <- if l2.ShouldSerializetitlefont() then l2.titlefontOption else l1.titlefontOption 
        l1.autosizeOption      <- if l2.ShouldSerializeautosize() then l2.autosizeOption else l1.autosizeOption 
        l1.widthOption         <- if l2.ShouldSerializewidth() then l2.widthOption else l1.widthOption 
        l1.heightOption        <- if l2.ShouldSerializeheight() then l2.heightOption else l1.heightOption
        l1.marginOption        <- if l2.ShouldSerializemargin() then l2.marginOption else l1.marginOption 
        l1.paper_bgcolorOption <- if l2.ShouldSerializepaper_bgcolor() then l2.paper_bgcolorOption else l1.paper_bgcolorOption 
        l1.plot_bgcolorOption  <- if l2.ShouldSerializeplot_bgcolor() then l2.plot_bgcolorOption else l1.plot_bgcolorOption 
        l1.separatorsOption    <- if l2.ShouldSerializeseparators() then l2.separatorsOption else l1.separatorsOption 
        l1.hidesourcesOption   <- if l2.ShouldSerializehidesources() then l2.hidesourcesOption else l1.hidesourcesOption 
        l1.smithOption         <- if l2.ShouldSerializesmith() then l2.smithOption else l1.smithOption 
        l1.showlegendOption    <- if l2.ShouldSerializeshowlegend() then l2.showlegendOption else l1.showlegendOption 
        l1.dragmodeOption      <- if l2.ShouldSerializedragmode() then l2.dragmodeOption else l1.dragmodeOption 
        l1.hovermodeOption     <- if l2.ShouldSerializehovermode() then l2.hovermodeOption else l1.hovermodeOption 
        l1.xaxisOption         <- if l2.ShouldSerializexaxis() then l2.xaxisOption else l1.xaxisOption 
        l1.xaxis1Option        <- if l2.ShouldSerializexaxis1() then l2.xaxis1Option else l1.xaxis1Option  
        l1.xaxis2Option        <- if l2.ShouldSerializexaxis2() then l2.xaxis2Option else l1.xaxis2Option 
        l1.yaxisOption         <- if l2.ShouldSerializeyaxis() then l2.yaxisOption else l1.yaxisOption 
        l1.yaxis2Option        <- if l2.ShouldSerializeyaxis2() then l2.yaxis2Option else l1.yaxis2Option  
        //l1.sceneOption         <- if l2.ShouldSerializescene() then l2.sceneOption else l1.sceneOption  
        l1.geoOption           <- if l2.ShouldSerializegeo() then l2.geoOption else l1.geoOption 
        l1.legendOption        <- if l2.ShouldSerializelegend() then l2.legendOption else l1.legendOption  
        l1.annotationsOption   <- if l2.ShouldSerializeannotations() then l2.annotationsOption else l1.annotationsOption 
        l1.shapesOption        <- if l2.ShouldSerializeshapes() then l2.shapesOption else l1.shapesOption 
        l1.radialaxisOption    <- if l2.ShouldSerializeradialaxis() then l2.radialaxisOption else l1.radialaxisOption  
        l1.angularaxisOption   <- if l2.ShouldSerializeangularaxis() then l2.angularaxisOption else l1.angularaxisOption 
        l1.directionOption     <- if l2.ShouldSerializedirection() then l2.directionOption else l1.directionOption
        l1.orientationOption   <- if l2.ShouldSerializeorientation() then l2.orientationOption else l1.orientationOption
        l1.barmodeOption       <- if l2.ShouldSerializebarmode() then l2.barmodeOption else l1.barmodeOption
        l1.bargapOption        <- if l2.ShouldSerializebargap() then l2.bargapOption else l1.bargapOption
    
        Some l1


    // Combines two layouts
    // if a value is set in chart and layout, value in layout is taken
    let combineLayout layout gChart =
        match gChart with
        | Chart (trace,l1)       -> Chart (trace, combine' l1 (Some layout))
        | MultiChart (traces,l1) -> MultiChart (traces, combine' l1 (Some layout))


    let combine (gCharts:seq<GenericChart>) =
        gCharts
        |> Seq.reduce (fun acc elem ->
                            match acc,elem with
                            | MultiChart (traces,l1),Chart (trace,l2)         -> MultiChart (Seq.append traces [trace], combine' l1 l2)
                            | MultiChart (traces1,l1),MultiChart (traces2,l2) -> MultiChart (Seq.append traces1 traces2,combine' l1 l2)
                            | Chart (trace1,l1),Chart (trace2,l2)             -> MultiChart ([trace1;trace2],combine' l1 l2)
                            | Chart (trace,l1),MultiChart (traces,l2)         -> MultiChart (Seq.append [trace] traces ,combine' l1 l2)
                        ) 


