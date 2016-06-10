namespace FSharp.Plotly

open System
open System.IO
open StyleGramar
open ChartArea
open GenericChart

/// Extensions methods for Charts supporting the fluent pipeline style 'Chart.WithXYZ(...)'.
[<AutoOpen>]
module ChartExtensions =
    
    /// Provides a set of static methods for creating charts.
    type Chart with   
        
        // ####################### Apply to trace

        /// Set the name related properties of a trace
        static member withTraceName(?Name,?Showlegend,?Legendgroup,?Visible) =
            (fun (ch:GenericChart) ->                   
                ch |> mapiTrace (fun i trace -> 
                                   let naming i name = name |> Option.map (fun v -> if i = 0 then v else sprintf "%s_%i" v i)                                   
                                   trace |> Helpers.ApplyTraceStyles(trace.``type``,?name=(naming i Name),?showlegend=Showlegend,?legendgroup=Legendgroup,?visible=Visible))          
            )

        /// Set the name related properties of a trace
        // TODO
        static member withTraceInfo(?textinfo,?textinfoposition,?hoverinfo) =
            (fun (ch:GenericChart) ->                   
                ch |> mapiTrace (fun i trace -> 
                                   trace) // |> Helpers.ApplyTraceStyles())          
            )
        
        /// Apply styling to the Marker(s) of the chart as Object.
        static member withMarkerOption(marker:Marker) =
            (fun (ch:GenericChart) ->                                    
                ch |> mapTrace (fun gc -> 
                                    gc.set_marker marker
                                    gc)
            )
               
        /// Apply styling to the Marker(s) of the chart.
        static member withMarkerStyle(?Size,?Color,?Symbol,?Opacity) = 
            let marker = 
                Marker()                
                |> Helpers.ApplyMarkerStyles(?size=Size,?color=Color,?symbol=Symbol,?opacity=Opacity)
            
            Chart.withMarkerOption(marker)         
            
        /// Apply styling to the Line(s) of the chart as Object.
        static member withLineOption(line:Line) =
            (fun (ch:GenericChart) ->                   
                ch |> mapTrace (fun gc -> 
                                    gc.set_line line
                                    gc)
            )
               
        /// Apply styling to the Line(s) of the chart.
        static member withLineStyle(?Width,?Color,?Shape,?Dash,?Smoothing,?ColorScale) =
            let line = 
                Line()                
                |> Helpers.ApplyLineStyles(?width=Width,?color=Color,?shape=Shape,?dash=Dash,?smoothing=Smoothing,?colorScale=ColorScale)
            
            Chart.withLineOption(line)  



        // ####################### Apply to layout
        
        
        static member withX_AxisStyle(title) =
            (fun (ch:GenericChart) ->             
                let xaxis = 
                    Xaxis()                
                    |> Helpers.ApplyAxisStyles(title=title)
                let layout =
                    GenericChart.getLayout ch
                    |> Helpers.ApplyLayoutStyles(xaxis=xaxis)
                
                GenericChart.setLayout layout ch)   

        static member withY_AxisStyle(title) =
            (fun (ch:GenericChart) ->             
                let yaxis = 
                    Yaxis()                
                    |> Helpers.ApplyAxisStyles(title=title)
                let layout =
                    GenericChart.getLayout ch
                    |> Helpers.ApplyLayoutStyles(yaxis=yaxis)
                
                GenericChart.setLayout layout ch)               


        static member withLayout(layout:Layout) =
            (fun (ch:GenericChart) -> 
                GenericChart.setLayout layout ch)         

        static member withSize(width,heigth) =            
            (fun (ch:GenericChart) -> 
                let layout =
                    GenericChart.getLayout ch
                    |> Helpers.ApplyLayoutStyles(width=width,height=heigth)
                
                GenericChart.setLayout layout ch)   


        static member withMarginSize(?left,?right,?top,?bottom,?pad,?autoexpand) =        
            (fun (ch:GenericChart) ->                 
                let margin = 
                    (GenericChart.getLayout ch)
                        .marginOption                    
                    |> GenericChart.optOrDefault (Margin())                    
                    |> Helpers.ApplyMarginStyles(?left=left,?right=right,?top=top,?bottom=bottom,?pad=pad,?autoexpand=autoexpand)
                let layout =
                    GenericChart.getLayout ch
                    |> Helpers.ApplyLayoutStyles(margin=margin)
                
                GenericChart.setLayout layout ch)   

                



        // with Layout
        static member withError(layout:Layout) =
            (fun (ch:GenericChart) -> 
                GenericChart.setLayout layout ch)   



        // ####################### 
            
        static member Show (ch:GenericChart) = 
            let guid = Guid.NewGuid().ToString()
            let html = GenericChart.toEmbeddedHTML ch
            let tempPath = Path.GetTempPath()
            let file = sprintf "%s.html" guid
            let path = Path.Combine(tempPath, file)
            File.WriteAllText(path, html)
            System.Diagnostics.Process.Start(path) |> ignore

