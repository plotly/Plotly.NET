namespace FSharp.Plotly

open System
open Newtonsoft.Json

/// Module to represent a 3d-GenericChart
module GenericChart3d =
    // 'T when 'T :> ITrace
    type GenericChart3d =
        | Chart of ITrace3d * (Layout -> Layout) list option
        | MultiChart of ITrace3d list * (Layout -> Layout) list option


        
    let getTraces gChart =
        match gChart with
        | Chart (trace,_)       -> [trace]
        | MultiChart (traces,_) -> traces  

    let getLayouts gChart =
        let optOrDefault (_default:'t)  (v: 't option) =
            match v with
            | Some v' -> v'
            | None -> _default
        match gChart with
        | Chart (_,layout)      -> optOrDefault [] layout
        | MultiChart (_,layout) -> optOrDefault [] layout

  
    // Adds a Layout function to the GenericChart3d
    let addLayout layout gChart =
        match gChart with
        | Chart (trace,_)       -> 
            let l' = getLayouts gChart
            Chart (trace,Some (layout::l'))
        | MultiChart (traces,_) -> 
            let l' = getLayouts gChart
            MultiChart (traces, Some (layout::l'))
    
    // Adds multiple Layout functions to the GenericChart3d
    let addLayouts layouts gChart =
        match gChart with
        | Chart (trace,_)       -> 
            let l' = getLayouts gChart
            Chart (trace,Some (layouts@l'))
        | MultiChart (traces,_) -> 
            let l' = getLayouts gChart
            MultiChart (traces, Some (layouts@l'))

    // Combines two GenericChart3d
    let combine(gCharts:seq<GenericChart3d>) =
        let combineLayouts lLeft lRight = 
            match lLeft,lRight with
            | None, None -> None
            | None, Some _ -> lRight
            | Some _ , None -> lLeft
            | Some vL,Some vR -> Some (vL@vR)     
            
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
    
    let private materialzeLayout (layout:(Layout -> Layout) list) =
        let rec reduce fl v =
            match fl with
            | h::t -> reduce t (h v) 
            | [] -> v

        // Attention order ov layout functions is reverse
        let l' = layout |> List.rev
        reduce l' (Layout())

        

    /// Converts a GenericChart3d to it HTML representation
    let toChartHTML gChart =
        let guid = Guid.NewGuid().ToString()
        let tracesJson =
            getTraces gChart
            |> JsonConvert.SerializeObject 
        let layoutJson = 
            getLayouts gChart
            |> materialzeLayout
            |> JsonConvert.SerializeObject 

        let html =
            HTML.chart
                .Replace("style=\"width: [WIDTH]px; height: [HEIGHT]px;\"","")
                .Replace("[ID]", guid)                
                .Replace("[DATA]", tracesJson)
                .Replace("[LAYOUT]", layoutJson)
        html

    /// Converts a GenericChart3d to it HTML representation and set the size of the div 
    let toChartHtmlWithSize (width:int) (height:int) (gChart:GenericChart3d) =
        let guid = Guid.NewGuid().ToString()
        let tracesJson =
            getTraces gChart
            |> JsonConvert.SerializeObject 
        let layoutJson = 
            getLayouts gChart
            |> materialzeLayout
            |> JsonConvert.SerializeObject 

        let html =
            HTML.chart
                .Replace("[ID]", guid)
                .Replace("[WIDTH]", string width )
                .Replace("[HEIGHT]", string height)
                .Replace("[DATA]", tracesJson)
                .Replace("[LAYOUT]", layoutJson)
        html
        
    /// Converts a GenericChart3d to it HTML representation and embeds it into a html page
    let toEmbeddedHTML gChart =
        let html =
            let chartMarkup =
                toChartHTML gChart
            HTML.doc.Replace("[CHART]", chartMarkup)
        html


        
    /// Creates a new GenericChart whose traces are the results of applying the given function to each of the trace of the GenericChart.           
    let mapTrace f gChart =
        match gChart with
        | Chart (trace,layout)       -> Chart (f trace,layout)
        | MultiChart (traces,layout) -> MultiChart (traces |> List.map f,layout) 

    /// Creates a new GenericChart3d whose traces are the results of applying the given function to each of the trace of the GenericChart3d.
    /// The integer index passed to the function indicates the index (from 0) of element being transformed.           
    let mapiTrace f gChart =
        match gChart with
        | Chart (trace,layout)       -> Chart (f 0 trace,layout)
        | MultiChart (traces,layout) -> MultiChart (traces |> List.mapi f,layout) 

    /// Returns the number of traces within the GenericChart3d
    let countTrace gChart =
        match gChart with
        | Chart (_)             -> 1
        | MultiChart (traces,_) -> traces |> Seq.length
          
    /// Converts from a trace object and a layout object into GenericChart3d    
    let ofTrace3dObject trace layout =
        GenericChart.Chart(trace,Some [(fun _ -> layout)])
    
    /// Converts from a list of trace objects and a layout object into GenericChart3d
    let ofTrace3dObjects traces layout =
        GenericChart.MultiChart(traces,Some [(fun _ -> layout)])


