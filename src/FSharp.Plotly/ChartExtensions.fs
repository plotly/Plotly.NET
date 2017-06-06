namespace FSharp.Plotly

open System
open System.IO

open GenericChart


/// Extensions methods for Charts supporting the fluent pipeline style 'Chart.WithXYZ(...)'.
[<AutoOpen>]
module ChartExtensions =
    
    open Trace

    /// Provides a set of static methods for creating charts.
    type Chart with   

// ############################################################       
// ####################### Apply to trace

        /// Set the name related properties of a trace
        static member withTraceName(?Name,?Showlegend,?Legendgroup,?Visible) =
            (fun (ch:GenericChart) ->                   
                ch |> mapiTrace (fun i trace -> 
                    let naming i name = name |> Option.map (fun v -> if i = 0 then v else sprintf "%s_%i" v i)                                   
                    trace 
                    |> TraceStyle.TraceInfo(?Name=(naming i Name),?Showlegend=Showlegend,?Legendgroup=Legendgroup,?Visible=Visible)
                )
            )
        
        /// Apply styling to the Marker(s) of the chart as Object.
        static member withMarker(marker:Marker) =
            (fun (ch:GenericChart) ->                   
                ch |> mapTrace (TraceStyle.SetMarker(marker))
            )
               
        /// Apply styling to the Marker(s) of the chart.
        static member withMarkerStyle(?Size,?Color,?Symbol,?Opacity) = 
            let marker = 
                Marker.init ( 
                    ?Size=Size,?Color=Color,?Symbol=Symbol,?Opacity=Opacity
                    )           
            Chart.withMarker(marker)         
            
        /// Apply styling to the Line(s) of the chart as Object.
        static member withLine(line:Line) =
             (fun (ch:GenericChart) ->                   
                ch |> mapTrace (TraceStyle.SetLine(line))
            )
               
        /// Apply styling to the Line(s) of the chart.
        static member withLineStyle(?Width,?Color,?Shape,?Dash,?Smoothing,?Colorscale) =
            let line = 
                Line.init (
                    ?Width=Width,?Color=Color,?Shape=Shape,?Dash=Dash,?Smoothing=Smoothing,?Colorscale=Colorscale)
                                 
            Chart.withLine(line)  

        /// Apply styling to the xError(s) of the chart as Object
        static member withXError(xError:Error) =
            (fun (ch:GenericChart) ->                   
                ch |> mapTrace (TraceStyle.SetErrorX(xError))                                    
            ) 

        /// Apply styling to the xError(s) of the chart as Object
        static member withXErrorStyle(?Array,?Arrayminus,?Symmetric,?Color,?Thickness,?Width) =
            let error = Error.init(?Array=Array,?Arrayminus=Arrayminus,?Symmetric=Symmetric,?Color=Color,?Thickness=Thickness,?Width=Width)
            Chart.withXError error

        /// Apply styling to the yError(s) of the chart as Object 
        static member withYError(yError:Error) =
            (fun (ch:GenericChart) ->                   
                ch |> mapTrace (TraceStyle.SetErrorY(yError))                                    
            )

        /// Apply styling to the yError(s) of the chart as Object 
        static member withYErrorStyle(?Array,?Arrayminus,?Symmetric,?Color,?Thickness,?Width) =
            let error = Error.init(?Array=Array,?Arrayminus=Arrayminus,?Symmetric=Symmetric,?Color=Color,?Thickness=Thickness,?Width=Width)
            Chart.withYError error

        /// Apply styling to the zError(s) of the chart as Object
        static member withZError(zError:Error) =
            (fun (ch:GenericChart) ->                   
                ch |> mapTrace (TraceStyle.SetErrorZ(zError))                                    
            )
        
        /// Apply styling to the zError(s) of the chart as Object
        static member withZErrorStyle(?Array,?Arrayminus,?Symmetric,?Color,?Thickness,?Width) =
            let error = Error.init(?Array=Array,?Arrayminus=Arrayminus,?Symmetric=Symmetric,?Color=Color,?Thickness=Thickness,?Width=Width)
            Chart.withZError error


// ############################################################
// ####################### Apply to layout
        
        // Sets x-Axis of 2d and 3d- Charts
        static member withX_Axis(xAxis:Axis.LinearAxis) =       
            (fun (ch:GenericChart) ->                                 
                let contains3d =
                    ch 
                    |> existsTrace (fun t -> 
                        match t with
                        | :? Trace3d -> true
                        | _ -> false)

                match contains3d with
                | false -> 
                    let layout =
                        GenericChart.getLayout ch 
                        |> Layout.style (xAxis=xAxis)
                    GenericChart.setLayout layout ch
                | true  -> 
                    let layout =
                        Layout() 
                        |> Layout.style (Scene=Scene.init( xAxis=xAxis) )
                    GenericChart.addLayout layout ch
            )
                    
                             
        
         // Sets x-Axis of 2d and 3d- Charts
        static member withX_AxisStyle(title,?MinMax,?Showgrid,?Showline) =                    
            let range = if MinMax.IsSome then Some (StyleParam.RangeValues.MinMax (MinMax.Value)) else None
            let xaxis = Axis.LinearAxis.init(Title=title,?Range=range,?Showgrid=Showgrid,?Showline=Showline)
            Chart.withX_Axis(xaxis)
            

        // Sets y-Axis of 2d and 3d- Charts
        static member withY_Axis(yAxis:Axis.LinearAxis) =       
            (fun (ch:GenericChart) ->                                 
                let contains3d =
                    ch 
                    |> existsTrace (fun t -> 
                        match t with
                        | :? Trace3d -> true
                        | _ -> false)

                match contains3d with
                | false -> 
                    let layout =
                        GenericChart.getLayout ch 
                        |> Layout.style(yAxis=yAxis)
                    GenericChart.setLayout layout ch
                | true  -> 
                    let layout =
                        Layout() 
                        |> Layout.style(Scene=Scene.init(yAxis=yAxis) )
                    GenericChart.addLayout layout ch
            )
        
         // Sets y-Axis of 3d- Charts
        static member withY_AxisStyle(title,?MinMax,?Showgrid,?Showline) =
            let range = if MinMax.IsSome then Some (StyleParam.RangeValues.MinMax (MinMax.Value)) else None
            let yaxis = Axis.LinearAxis.init(Title=title,?Range=range,?Showgrid=Showgrid,?Showline=Showline)
            Chart.withY_Axis(yaxis)                



        //// Sets z-Axis of 3d- Charts
        //static member withZ_Axis(zAxis:Axis.LinearAxis) =       
        //    (fun (ch:GenericChart) ->                                  
        //        let layout =
        //            Layout() 
        //            |> Layout.style(Scene=Scene.init(Scene.style (zAxis=zAxis) ))
        //        GenericChart.addLayout layout ch
        //     )
        
        //// Sets z-Axis style with ... 
        //static member withZ_AxisStyle(title,?MinMax,?Showgrid) =
        //    let range = if MinMax.IsSome then Some (StyleParam.RangeValues.MinMax (MinMax.Value)) else None
        //    let zaxis = Axis.LinearAxis.init(Axis.LinearAxis.LinearAxis(Title=title,?Range=range,?Showgrid=Showgrid))
        //    Chart.withZ_Axis(zaxis)                



        // Set the Layout options of a Chart
        static member withLayout(layout:Layout) =
            (fun (ch:GenericChart) -> 
                GenericChart.addLayout layout ch)         


        // Set the title of a Chart
        static member withTitle(title,?Titlefont) =
            (fun (ch:GenericChart) ->                                  
                let layout =
                    Layout() 
                    |> Layout.style(Title=title,?Titlefont=Titlefont)
                GenericChart.addLayout layout ch
             )  


        // Set showLegend of a Chart
        static member withLegend(showlegend) =
            (fun (ch:GenericChart) ->                                  
                let layout =
                    Layout() 
                    |> Layout.style(Showlegend=showlegend)
                GenericChart.addLayout layout ch
             )  

        
        // Set the size of a Chart
        static member withSize(width,heigth) =            
            (fun (ch:GenericChart) -> 
                let layout = 
                    GenericChart.getLayout ch
                    |> Layout.style (Width=width,Height=heigth)
                GenericChart.setLayout layout ch
            )

        // Set the margin of a Chart
        static member withMargin(margin:Margin) =        
            (fun (ch:GenericChart) ->                 
                let layout =
                    GenericChart.getLayout ch 
                    |> Layout.style (Margin=margin)
                GenericChart.setLayout layout ch)   

        // Set the margin of a Chart
        static member withMarginSize(?Left,?Right,?Top,?Bottom,?Pad,?Autoexpand) =                       
                let margin = 
                    Margin.init (Margin.style (?Left=Left,?Right=Right,?Top=Top,?Bottom=Bottom,?Pad=Pad,?Autoexpand=Autoexpand))
                Chart.withMargin(margin) 

                

        // TODO: Include withLegend & withLegendStyle

    //Specifies the shape type to be drawn. If "line", a line is drawn from (`x0`,`y0`) to (`x1`,`y1`) If "circle", a circle is drawn from 
    //((`x0`+`x1`)/2, (`y0`+`y1`)/2)) with radius (|(`x0`+`x1`)/2 - `x0`|, |(`y0`+`y1`)/2 -`y0`)|) If "rect", a rectangle is drawn linking 
    //(`x0`,`y0`), (`x1`,`y0`), (`x1`,`y1`), (`x0`,`y1`), (`x0`,`y0`)  
        static member withShape(shape:Shape) =
            (fun (ch:GenericChart) ->                 
                let layout = 
                    GenericChart.getLayout ch
                    |> Layout.style (Shapes=[shape])
                GenericChart.setLayout layout ch)  

        static member withShapes(shapes:Shape seq) =
            (fun (ch:GenericChart) ->                 
                let layout = 
                    GenericChart.getLayout ch
                    |> Layout.style (Shapes=shapes)
                GenericChart.setLayout layout ch)  



        // ####################### 
        /// Create a combined chart with the given charts merged   
        static member Combine(gCharts:seq<GenericChart>) =
            GenericChart.combine gCharts

        /// Save chart as html single page
        static member SaveHtmlAs pathName (ch:GenericChart) =                                     
            let html = GenericChart.toEmbeddedHTML ch
            let file = sprintf "%s.html" pathName // remove file extension
            File.WriteAllText(file, html)
            System.Diagnostics.Process.Start(file) |> ignore


        /// Show chart in browser            
        static member Show (ch:GenericChart) = 
            let guid = Guid.NewGuid().ToString()
            let html = GenericChart.toEmbeddedHTML ch
            let tempPath = Path.GetTempPath()
            let file = sprintf "%s.html" guid
            let path = Path.Combine(tempPath, file)
            File.WriteAllText(path, html)
            System.Diagnostics.Process.Start(path) |> ignore


