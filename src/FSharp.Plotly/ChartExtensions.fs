namespace FSharp.Plotly

open System
open System.IO

open GenericChart


/// Extensions methods for Charts supporting the fluent pipeline style 'Chart.WithXYZ(...)'.
[<AutoOpen>]
module ChartExtensions =

    open Trace
    //open StyleParam

    //open ChartExtensions

    //open StyleParam

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
 
         /// Set the axis anchor id the trace is belonging to
        static member withAxisAnchor(?X,?Y,?Z) =
            let idx   = if X.IsSome then Some (StyleParam.AxisAnchorId.X X.Value) else None
            let idy   = if Y.IsSome then Some (StyleParam.AxisAnchorId.Y Y.Value) else None
            let idz   = if Z.IsSome then Some (StyleParam.AxisAnchorId.Z Z.Value) else None
            
            (fun (ch:GenericChart) ->
                ch |> mapTrace (fun trace ->
                    trace 
                    |> TraceStyle.SetAxisAnchor(?X=idx,?Y=idy,?Z=idz)
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
        static member withX_Axis(xAxis:Axis.LinearAxis,?Id) =
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
                        let id = if Id.IsSome then StyleParam.AxisId.X Id.Value else StyleParam.AxisId.X 1
                        GenericChart.getLayout ch 
                        |> Layout.UpdateLinearAxisById(id,axis=xAxis)
                    GenericChart.setLayout layout ch
                | true  -> 
                    let layout =
                        Layout() 
                        |> Layout.style (Scene=Scene.init( xAxis=xAxis) )
                    GenericChart.addLayout layout ch
            )


         // Sets x-Axis of 2d and 3d- Charts
        static member withX_AxisStyle(title,?MinMax,?Showgrid,?Showline,?Side,?Overlaying,?Id,?Domain,?Position,?Anchor) =
            let range  = if MinMax.IsSome then Some (StyleParam.Range.MinMax (MinMax.Value)) else None
            let domain = if Domain.IsSome then Some (StyleParam.Range.MinMax (Domain.Value)) else None
            let xaxis  = Axis.LinearAxis.init(Title=title,?Range=range,?Showgrid=Showgrid,?Showline=Showline,
                                    ?Anchor=Anchor,?Side=Side,?Domain=domain,?Overlaying=Overlaying,?Position=Position)
            Chart.withX_Axis(xaxis,?Id=Id)


        // Sets y-Axis of 2d and 3d- Charts
        static member withY_Axis(yAxis:Axis.LinearAxis,?Id) =
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
                        let id = if Id.IsSome then StyleParam.AxisId.Y Id.Value else StyleParam.AxisId.Y 1
                        GenericChart.getLayout ch 
                        |> Layout.UpdateLinearAxisById(id,axis=yAxis)
                    GenericChart.setLayout layout ch
                | true  -> 
                    let layout =
                        Layout() 
                        |> Layout.style(Scene=Scene.init(yAxis=yAxis) )
                    GenericChart.addLayout layout ch
            )


         // Sets y-Axis of 3d- Charts
        static member withY_AxisStyle(title,?MinMax,?Showgrid,?Showline,?Side,?Overlaying,?Id,?Domain,?Position,?Anchor) =
            let range  = if MinMax.IsSome then Some (StyleParam.Range.MinMax (MinMax.Value)) else None
            let domain = if Domain.IsSome then Some (StyleParam.Range.MinMax (Domain.Value)) else None
            let yaxis  = Axis.LinearAxis.init(Title=title,?Range=range,?Showgrid=Showgrid,
                                    ?Showline=Showline,?Anchor=Anchor,?Side=Side,?Domain=domain,?Overlaying=Overlaying,?Position=Position)
            Chart.withY_Axis(yaxis,?Id=Id)                


        // Sets z-Axis of 3d- Charts
        static member withZ_Axis(zAxis:Axis.LinearAxis) =
            (fun (ch:GenericChart) ->
                let layout =
                    Layout() 
                    |> Layout.style(Scene=Scene.init(zAxis=zAxis) )
                GenericChart.addLayout layout ch
             )


// Sets z-Axis style with ...
        static member withZ_AxisStyle(title,?MinMax,?Showgrid,?Showline,?Domain,?Anchor) =
            let range  = if MinMax.IsSome then Some (StyleParam.Range.MinMax (MinMax.Value)) else None
            let domain = if Domain.IsSome then Some (StyleParam.Range.MinMax (Domain.Value)) else None
            let zaxis  = Axis.LinearAxis.init(Title=title,?Range=range,?Showgrid=Showgrid,?Showline=Showline,?Anchor=Anchor,?Domain=domain)
            Chart.withZ_Axis(zaxis)


        //// Sets second x-Axis of 2d- Charts
        //static member withX_Axis2(xAxis2:Axis.LinearAxis) =
        //    (fun (ch:GenericChart) ->
        //            let layout =
        //                GenericChart.getLayout ch 
        //                |> Layout.style (xAxis2=xAxis2)
        //            GenericChart.setLayout layout ch
        //            )


        // // Sets second x-Axis of 2d- Charts
        //static member withX_Axis2Style(title,?MinMax,?Showgrid,?Showline) =
        //    let range = if MinMax.IsSome then Some (StyleParam.Range.MinMax (MinMax.Value)) else None
        //    let xaxis = Axis.LinearAxis.init(Title=title,?Range=range,?Showgrid=Showgrid,?Showline=Showline,Side=StyleParam.Side.Top)
        //    Chart.withX_Axis2(xaxis)


        //// Sets second y-Axis of 2d- Charts
        //static member withY_Axis2(yAxis2:Axis.LinearAxis) =
        //    (fun (ch:GenericChart) ->
        //            let layout =
        //                GenericChart.getLayout ch 
        //                |> Layout.style (yAxis2=yAxis2)
        //            GenericChart.setLayout layout ch
        //            )


        // // Sets second x-Axis of 2d- Charts
        //static member withY_Axis2Style(title,?MinMax,?Showgrid,?Showline) =
        //    let range = if MinMax.IsSome then Some (StyleParam.Range.MinMax (MinMax.Value)) else None
        //    let yaxis = Axis.LinearAxis.init(Title=title,?Range=range,?Showgrid=Showgrid,?Showline=Showline,Side=StyleParam.Side.Right)
        //    Chart.withY_Axis2(yaxis)


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
                    Margin.init ( ?Left=Left,?Right=Right,?Top=Top,?Bottom=Bottom,?Pad=Pad,?Autoexpand=Autoexpand )
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


        /// Create a combined chart with the given charts merged
        static member Stack (?Columns:int, ?Space) = 
            (fun (charts:#seq<GenericChart>) ->  

                let col = defaultArg Columns 2
                let len      = charts |> Seq.length
                let colWidth = 1. / float col
                let rowWidth = 
                    let tmp = float len / float col |> ceil
                    1. / tmp
                let space = 
                    let s = defaultArg Space 0.05
                    if s < 0. || s > 1. then 
                        printfn "Space should be between 0.0 - 1.0. Automaticaly set to default (0.05)"
                        0.05
                    else
                        s

                charts
                |> Seq.mapi (fun i ch ->
                    let colI,rowI,index = (i%col+1), (i/col+1),(i+1)
                    let xdomain = (colWidth * float (colI-1), (colWidth * float colI) - space ) 
                    let ydomain = (1. - ((rowWidth * float rowI) - space ),1. - (rowWidth * float (rowI-1)))
                    let xaxis,yaxis,layout = 
                        let layout = GenericChart.getLayout ch
                        let xName, yName = StyleParam.AxisId.X 1 |> StyleParam.AxisId.toString, StyleParam.AxisId.Y 1 |> StyleParam.AxisId.toString
                        match (layout.TryGetTypedValue<Axis.LinearAxis> xName),(layout.TryGetTypedValue<Axis.LinearAxis> yName) with
                        | Some x, Some y ->
                            // remove axis
                            DynObj.remove layout xName
                            DynObj.remove layout yName

                            x |> Axis.LinearAxis.style(Anchor=StyleParam.AxisAnchorId.Y index,Domain=StyleParam.Range.MinMax xdomain),
                            y |> Axis.LinearAxis.style(Anchor=StyleParam.AxisAnchorId.X index,Domain=StyleParam.Range.MinMax ydomain),
                            layout
                        | Some x, None -> 
                            // remove x - axis
                            DynObj.remove layout xName
                            x |> Axis.LinearAxis.style(Anchor=StyleParam.AxisAnchorId.Y index,Domain=StyleParam.Range.MinMax xdomain),
                            Axis.LinearAxis.init(Anchor=StyleParam.AxisAnchorId.X index,Domain=StyleParam.Range.MinMax ydomain),
                            layout
                        | None, Some y -> 
                            // remove y - axis
                            DynObj.remove layout yName
                            Axis.LinearAxis.init(Anchor=StyleParam.AxisAnchorId.Y index,Domain=StyleParam.Range.MinMax xdomain),
                            y |> Axis.LinearAxis.style(Anchor=StyleParam.AxisAnchorId.X index,Domain=StyleParam.Range.MinMax ydomain),
                            layout
                        | None, None ->
                            Axis.LinearAxis.init(Anchor=StyleParam.AxisAnchorId.Y index,Domain=StyleParam.Range.MinMax xdomain),
                            Axis.LinearAxis.init(Anchor=StyleParam.AxisAnchorId.X index,Domain=StyleParam.Range.MinMax ydomain),
                            layout

                    ch
                    |> GenericChart.setLayout layout
                    |> Chart.withAxisAnchor(X=index,Y=index) 
                    |> Chart.withX_Axis(xaxis,index)
                    |> Chart.withY_Axis(yaxis,index)
                    )

                |> Chart.Combine
                )


        /// Save chart as html single page
        static member SaveHtmlAs pathName (ch:GenericChart,?Verbose) =
            let html = GenericChart.toEmbeddedHTML ch
            let file = sprintf "%s.html" pathName // remove file extension
            File.WriteAllText(file, html)

            let verbose = defaultArg Verbose false
            if verbose then
                System.Diagnostics.Process.Start(file) |> ignore


        /// Show chart in browser
        static member ShowWithDescription (show : bool) (d : string) (ch:GenericChart) =
            let guid = Guid.NewGuid().ToString()
            let html = GenericChart.toEmbeddedHtmlWithDescription d ch
            let tempPath = Path.GetTempPath()
            let file = sprintf "%s.html" guid
            let path = Path.Combine(tempPath, file)
            File.WriteAllText(path, html)
            if show then System.Diagnostics.Process.Start(path) |> ignore


        /// Saves chart in a specified file name and shows it in the browser. The caller is responsible for full path / filename / extension.
        static member ShowFileWithDescription (show : bool) (fullFileName : string) (d : string) (ch:GenericChart) =
            let html = GenericChart.toEmbeddedHtmlWithDescription d ch
            File.WriteAllText(fullFileName, html)
            if show then System.Diagnostics.Process.Start(fullFileName) |> ignore


        /// Show chart in browser
        static member Show (ch:GenericChart) = Chart.ShowWithDescription true "" ch


        /// Show chart in browser
        static member ShowAsImage (format:StyleParam.ImageFormat) (ch:GenericChart) = 
            let guid = Guid.NewGuid().ToString()
            let html = GenericChart.toEmbeddedImage format ch
            let tempPath = Path.GetTempPath()
            let file = sprintf "%s.html" guid
            let path = Path.Combine(tempPath, file)
            File.WriteAllText(path, html)
            System.Diagnostics.Process.Start(path) |> ignore
