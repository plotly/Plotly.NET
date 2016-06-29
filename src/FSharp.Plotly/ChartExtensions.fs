namespace FSharp.Plotly

open System
open System.IO

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
                                   match trace with
                                   | :? ITraceInfo as traceinfo ->
                                            let naming i name = name |> Option.map (fun v -> if i = 0 then v else sprintf "%s_%i" v i)                                   
                                            traceinfo 
                                            |> Options.ITraceInfo(?Name=(naming i Name),?Showlegend=Showlegend,?Legendgroup=Legendgroup,?Visible=Visible)
                                            :?> ITrace
                                   | _ -> trace 
                                 )
            )
        
        /// Apply styling to the Marker(s) of the chart as Object.
        static member withMarkerOption(marker:MarkerOptions) =
            (fun (ch:GenericChart) ->                   
                ch |> mapTrace (fun trace ->                                     
                                    match trace with
                                    | :? IMarker as mTrace -> 
                                        mTrace
                                        |> Options.IMarker(marker)  :?> ITrace 
                                    | _        -> trace 
                               )
            )
               
        /// Apply styling to the Marker(s) of the chart.
        static member withMarkerStyle(?Size,?Color,?Symbol,?Opacity) = 
            let marker = Options.Marker(?Size=Size,?Color=Color,?Symbol=Symbol,?Opacity=Opacity)            
            Chart.withMarkerOption(marker)         
            
        /// Apply styling to the Line(s) of the chart as Object.
        static member withLineOption(line:LineOptions) =
            (fun (ch:GenericChart) ->                   
                ch |> mapTrace (fun trace ->                                     
                                    match trace with
                                    | :? ILine as lineTrace -> 
                                        lineTrace
                                        |> Options.ILine(line)  :?> ITrace 
                                    | _        -> trace 
                               )
            )
               
        /// Apply styling to the Line(s) of the chart.
        static member withLineStyle(?Width,?Color,?Shape,?Dash,?Smoothing,?ColorScale) =
            let line = Options.Line(?Width=Width,?Color=Color,?Shape=Shape,?Dash=Dash,?Smoothing=Smoothing,?ColorScale=ColorScale)            
            Chart.withLineOption(line)  

        /// Apply styling to the xError(s) of the chart as Object (if member exists else it is ignored).
        static member withXError(xError:ErrorOptions) =
            (fun (ch:GenericChart) ->                   
                ch |> mapTrace (fun trace ->                                     
                                    ApplyHelper.tryUpdatePropertyValueFromName trace "error_x" xError |> ignore
                                    trace
                               )
            )

        /// Apply styling to the yError(s) of the chart as Object (if member exists else it is ignored).
        static member withYError(yError:ErrorOptions) =
            (fun (ch:GenericChart) ->                   
                ch |> mapTrace (fun trace ->                                     
                                    ApplyHelper.tryUpdatePropertyValueFromName trace "error_y" yError |> ignore
                                    trace
                               )
            )

        /// Apply styling to the zError(s) of the chart as Object (if member exists else it is ignored).
        static member withZError(zError:ErrorOptions) =
            (fun (ch:GenericChart) ->                   
                ch |> mapTrace (fun trace ->                                     
                                    ApplyHelper.tryUpdatePropertyValueFromName trace "error_z" zError |> ignore
                                    trace
                               )
            )


        // ####################### Apply to layout
        
        // Sets x-Axis of 2d and 3d- Charts
        static member withX_Axis(xAxis:AxisOptions) =       
            (fun (ch:GenericChart) ->                                 
                let contains3d =
                    ch 
                    |> existsTrace (fun t -> 
                        match t with
                        | :? ITrace3d -> true
                        | _ -> false)

                match contains3d with
                | false -> 
                    let layout = 
                        Options.Layout(xAxis=xAxis)
                    GenericChart.addLayout layout ch
                | true  -> 
                    let layout = 
                        Options.Layout(Scene=Options.Scene(xAxis=xAxis))
                    GenericChart.addLayout layout ch
            )
                    
                             
        
        // Sets x-Axis of 2d and 3d- Charts
        static member withX_AxisStyle(title,?MinMax) =                    
            let range = if MinMax.IsSome then Some (StyleOption.RangeValues.MinMax (MinMax.Value)) else None
            let xaxis = Options.Axis(Title=title,?Range=range)
            Chart.withX_Axis(xaxis) 
            

        // Sets y-Axis of 2d and 3d- Charts
        static member withY_Axis(yAxis:AxisOptions) =       
            (fun (ch:GenericChart) ->                                 
                let contains3d =
                    ch 
                    |> existsTrace (fun t -> 
                        match t with
                        | :? ITrace3d -> true
                        | _ -> false)

                match contains3d with
                | false -> 
                    let layout = 
                        Options.Layout(yAxis=yAxis)
                    GenericChart.addLayout layout ch
                | true  -> 
                    let layout = 
                        Options.Layout(Scene=Options.Scene(yAxis=yAxis))
                    GenericChart.addLayout layout ch
            )
        
        // Sets y-Axis of 3d- Charts
        static member withY_AxisStyle(title,?MinMax) =
            let range = if MinMax.IsSome then Some (StyleOption.RangeValues.MinMax (MinMax.Value)) else None
            let yaxis = Options.Axis(Title=title,?Range=range)
            Chart.withY_Axis(yaxis)                



        // Sets z-Axis of 3d- Charts
        static member withZ_Axis(zAxis:AxisOptions) =       
            (fun (ch:GenericChart) ->                                  
                let layout = 
                    Options.Layout(Scene=Options.Scene(zAxis=zAxis))
                GenericChart.addLayout layout ch
            )
        
        // Sets z-Axis of 3d- Charts
        static member withZ_AxisStyle(title,?MinMax) =
            let range = if MinMax.IsSome then Some (StyleOption.RangeValues.MinMax (MinMax.Value)) else None
            let zaxis = Options.Axis(Title=title,?Range=range)
            Chart.withZ_Axis(zaxis)                








        // Set the Layout options of a Chart
        static member withLayout(layout:LayoutOptions) =
            (fun (ch:GenericChart) -> 
                GenericChart.addLayout layout ch)         
        
        // Set the size of a Chart
        static member withSize(width,heigth) =            
            (fun (ch:GenericChart) -> 
                let layout = Options.Layout(Width=width,Height=heigth)
                GenericChart.addLayout layout ch)  

        // Set the margin of a Chart
        static member withMargin(margin:MarginOptions) =        
            (fun (ch:GenericChart) ->                 
                let layout = Options.Layout(Margin=margin)
                GenericChart.addLayout layout ch)   

        // Set the margin of a Chart
        static member withMarginSize(?Left,?Right,?Top,?Bottom,?Pad,?Autoexpand) =                       
                let margin = Options.Margin(?Left=Left,?Right=Right,?Top=Top,?Bottom=Bottom,?Pad=Pad,?Autoexpand=Autoexpand)
                Chart.withMargin(margin) 

                

        // TODO: Include withLegend & withLegendStyle

        // TODO: Include withError

        // TODO: Include withShapes



        // ####################### 
        /// Create a combined chart with the given charts merged   
        static member Combine(gCharts:seq<GenericChart>) =
            GenericChart.combine gCharts
        
        /// Show chart in browser            
        static member Show (ch:GenericChart) = 
            let guid = Guid.NewGuid().ToString()
            let html = GenericChart.toEmbeddedHTML ch
            let tempPath = Path.GetTempPath()
            let file = sprintf "%s.html" guid
            let path = Path.Combine(tempPath, file)
            File.WriteAllText(path, html)
            System.Diagnostics.Process.Start(path) |> ignore

