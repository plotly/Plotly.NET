namespace Plotly.NET

open System
open System.IO

open GenericChart
open System.Runtime.InteropServices
open System.Runtime.CompilerServices

/// Extensions methods for Charts supporting the fluent pipeline style 'Chart.WithXYZ(...)'.
[<AutoOpen>]

module ChartExtensions =

    ///Choose process to open plots with depending on OS. Thanks to @zyzhu for hinting at a solution (https://github.com/plotly/Plotly.NET/issues/31)
    let internal openOsSpecificFile path =
        if RuntimeInformation.IsOSPlatform(OSPlatform.Windows) then
            let psi = new System.Diagnostics.ProcessStartInfo(FileName = path, UseShellExecute = true)
            System.Diagnostics.Process.Start(psi) |> ignore
        elif RuntimeInformation.IsOSPlatform(OSPlatform.Linux) then
            System.Diagnostics.Process.Start("xdg-open", path) |> ignore
        elif RuntimeInformation.IsOSPlatform(OSPlatform.OSX) then
            System.Diagnostics.Process.Start("open", path) |> ignore
        else
            invalidOp "Not supported OS platform"

    open Trace

    /// Provides a set of static methods for creating charts.
    type Chart with

// ############################################################
// ####################### Apply to trace
        
        /// Set the name related properties of a trace
        [<CompiledName("WithTraceName")>]
        static member withTraceName
            (
                [<Optional;DefaultParameterValue(null)>] ?Name,
                [<Optional;DefaultParameterValue(null)>] ?Showlegend,
                [<Optional;DefaultParameterValue(null)>] ?Legendgroup,
                [<Optional;DefaultParameterValue(null)>] ?Visible
            ) =
                fun (ch:GenericChart) ->
                    ch |> mapiTrace (fun i trace ->
                        let naming i name = name |> Option.map (fun v -> if i = 0 then v else sprintf "%s_%i" v i)
                        trace 
                        |> TraceStyle.TraceInfo(?Name=(naming i Name),?Showlegend=Showlegend,?Legendgroup=Legendgroup,?Visible=Visible)
                    )

         /// Set the axis anchor id the trace is belonging to
        [<CompiledName("WithAxisAnchor")>]
        static member withAxisAnchor
            (
                [<Optional;DefaultParameterValue(null)>] ?X,
                [<Optional;DefaultParameterValue(null)>] ?Y,
                [<Optional;DefaultParameterValue(null)>] ?Z
            ) =
                let idx   = if X.IsSome then Some (StyleParam.AxisAnchorId.X X.Value) else None
                let idy   = if Y.IsSome then Some (StyleParam.AxisAnchorId.Y Y.Value) else None
                let idz   = if Z.IsSome then Some (StyleParam.AxisAnchorId.Z Z.Value) else None
            
                fun (ch:GenericChart) ->
                    ch |> mapTrace (fun trace ->
                        trace 
                        |> TraceStyle.SetAxisAnchor(?X=idx,?Y=idy,?Z=idz)
                    )
        [<CompiledName("WithAxisAnchor")>]
        static member withAxisAnchor
            (
                (ch:GenericChart),
                [<Optional;DefaultParameterValue(null)>] ?X,
                [<Optional;DefaultParameterValue(null)>] ?Y,
                [<Optional;DefaultParameterValue(null)>] ?Z
            ) =
                ch |> Chart.withAxisAnchor(?X=X,?Y=Y,?Z=Z)
  
        /// Apply styling to the Marker(s) of the chart as Object.
        [<CompiledName("WithMarker")>]
        static member withMarker(marker:Marker) =
            (fun (ch:GenericChart) ->
                ch |> mapTrace (TraceStyle.SetMarker(marker))
            )

        /// Apply styling to the Marker(s) of the chart.
        [<CompiledName("WithMarkerStyle")>]
        static member withMarkerStyle
            (
                [<Optional;DefaultParameterValue(null)>] ?Size,
                [<Optional;DefaultParameterValue(null)>] ?Color,
                [<Optional;DefaultParameterValue(null)>] ?Symbol,
                [<Optional;DefaultParameterValue(null)>] ?Opacity
            ) =
                let marker = 
                    Marker.init ( 
                        ?Size=Size,?Color=Color,?Symbol=Symbol,?Opacity=Opacity
                        )
                Chart.withMarker(marker)

        /// Apply styling to the Line(s) of the chart as Object.
        [<CompiledName("WithLine")>]
        static member withLine(line:Line) =
             (fun (ch:GenericChart) ->
                ch |> mapTrace (TraceStyle.SetLine(line))
            )

        /// Apply styling to the Line(s) of the chart.
        [<CompiledName("WithLineStyle")>]
        static member withLineStyle
            (
                [<Optional;DefaultParameterValue(null)>] ?Width,
                [<Optional;DefaultParameterValue(null)>] ?Color,
                [<Optional;DefaultParameterValue(null)>] ?Shape,
                [<Optional;DefaultParameterValue(null)>] ?Dash,
                [<Optional;DefaultParameterValue(null)>] ?Smoothing,
                [<Optional;DefaultParameterValue(null)>] ?Colorscale
            ) =
                let line =
                    Line.init (
                        ?Width=Width,?Color=Color,?Shape=Shape,?Dash=Dash,?Smoothing=Smoothing,?Colorscale=Colorscale)

                Chart.withLine(line)

        /// Apply styling to the xError(s) of the chart as Object
        [<CompiledName("WithXError")>]
        static member withXError(xError:Error) =
            (fun (ch:GenericChart) ->
                ch |> mapTrace (TraceStyle.SetErrorX(xError))
            ) 

        /// Apply styling to the xError(s) of the chart as Object
        [<CompiledName("WithXErrorStyle")>]
        static member withXErrorStyle
            (
                [<Optional;DefaultParameterValue(null)>] ?Array,
                [<Optional;DefaultParameterValue(null)>] ?Arrayminus,
                [<Optional;DefaultParameterValue(null)>] ?Symmetric,
                [<Optional;DefaultParameterValue(null)>] ?Color,
                [<Optional;DefaultParameterValue(null)>] ?Thickness,
                [<Optional;DefaultParameterValue(null)>] ?Width
            ) =
                let error = Error.init(?Array=Array,?Arrayminus=Arrayminus,?Symmetric=Symmetric,?Color=Color,?Thickness=Thickness,?Width=Width)
                Chart.withXError error

        /// Apply styling to the yError(s) of the chart as Object
        [<CompiledName("WithYError")>]
        static member withYError(yError:Error) =
            (fun (ch:GenericChart) ->
                ch |> mapTrace (TraceStyle.SetErrorY(yError))
            )

        /// Apply styling to the yError(s) of the chart as Object
        [<CompiledName("WithYErrorStyle")>]
        static member withYErrorStyle
            (
                [<Optional;DefaultParameterValue(null)>] ?Array,
                [<Optional;DefaultParameterValue(null)>] ?Arrayminus,
                [<Optional;DefaultParameterValue(null)>] ?Symmetric,
                [<Optional;DefaultParameterValue(null)>] ?Color,
                [<Optional;DefaultParameterValue(null)>] ?Thickness,
                [<Optional;DefaultParameterValue(null)>] ?Width
            ) =
                let error = Error.init(?Array=Array,?Arrayminus=Arrayminus,?Symmetric=Symmetric,?Color=Color,?Thickness=Thickness,?Width=Width)
                Chart.withYError error

        /// Apply styling to the zError(s) of the chart as Object
        [<CompiledName("WithZError")>]
        static member withZError(zError:Error) =
            (fun (ch:GenericChart) ->
                ch |> mapTrace (TraceStyle.SetErrorZ(zError))
            )
        
        /// Apply styling to the zError(s) of the chart as Object
        [<CompiledName("WithZErrorStyle")>]
        static member withZErrorStyle
            (
                [<Optional;DefaultParameterValue(null)>] ?Array,
                [<Optional;DefaultParameterValue(null)>] ?Arrayminus,
                [<Optional;DefaultParameterValue(null)>] ?Symmetric,
                [<Optional;DefaultParameterValue(null)>] ?Color,
                [<Optional;DefaultParameterValue(null)>] ?Thickness,
                [<Optional;DefaultParameterValue(null)>] ?Width
            ) =
                let error = Error.init(?Array=Array,?Arrayminus=Arrayminus,?Symmetric=Symmetric,?Color=Color,?Thickness=Thickness,?Width=Width)
                Chart.withZError error


// ############################################################
// ####################### Apply to layout
        
        // Sets x-Axis of 2d and 3d- Charts
        [<CompiledName("WithX_Axis")>]
        static member withX_Axis(xAxis:Axis.LinearAxis,[<Optional;DefaultParameterValue(null)>] ?Id) =
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
        [<CompiledName("WithX_AxisStyle")>]
        static member withX_AxisStyle(title,
                [<Optional;DefaultParameterValue(null)>] ?MinMax,
                [<Optional;DefaultParameterValue(null)>] ?Showgrid,
                [<Optional;DefaultParameterValue(null)>] ?Showline,
                [<Optional;DefaultParameterValue(null)>] ?Side,
                [<Optional;DefaultParameterValue(null)>] ?Overlaying,
                [<Optional;DefaultParameterValue(null)>] ?Id,
                [<Optional;DefaultParameterValue(null)>] ?Domain,
                [<Optional;DefaultParameterValue(null)>] ?Position,
                [<Optional;DefaultParameterValue(null)>] ?Zeroline,
                [<Optional;DefaultParameterValue(null)>] ?Anchor) =
            let range  = if MinMax.IsSome then Some (StyleParam.Range.MinMax (MinMax.Value)) else None
            let domain = if Domain.IsSome then Some (StyleParam.Range.MinMax (Domain.Value)) else None
            let xaxis  = Axis.LinearAxis.init(Title=title,?Range=range,?Showgrid=Showgrid,?Showline=Showline,
                                    ?Anchor=Anchor,?Side=Side,?Domain=domain,?Overlaying=Overlaying,?Position=Position,?Zeroline=Zeroline)
            Chart.withX_Axis(xaxis,?Id=Id)

        /// Sets the range slider for the xAxis
        [<CompiledName("WithX_AxisRangeSlider")>]
        static member withX_AxisRangeSlider(rangeSlider:RangeSlider,
                [<Optional;DefaultParameterValue(null)>] ?Id) =
            let xaxis  = Axis.LinearAxis.init(RangeSlider = rangeSlider)
            Chart.withX_Axis(xaxis,?Id=Id)

        // Sets y-Axis of 2d and 3d- Charts
        [<CompiledName("WithY_Axis")>]
        static member withY_Axis(yAxis:Axis.LinearAxis,[<Optional;DefaultParameterValue(null)>] ?Id) =
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
        [<CompiledName("WithY_AxisStyle")>]
        static member withY_AxisStyle(title,
                [<Optional;DefaultParameterValue(null)>] ?MinMax,
                [<Optional;DefaultParameterValue(null)>] ?Showgrid,
                [<Optional;DefaultParameterValue(null)>] ?Showline,
                [<Optional;DefaultParameterValue(null)>] ?Side,
                [<Optional;DefaultParameterValue(null)>] ?Overlaying,
                [<Optional;DefaultParameterValue(null)>] ?Id,
                [<Optional;DefaultParameterValue(null)>] ?Domain,
                [<Optional;DefaultParameterValue(null)>] ?Position,
                [<Optional;DefaultParameterValue(null)>] ?Zeroline,
                [<Optional;DefaultParameterValue(null)>] ?Anchor) =
            let range  = if MinMax.IsSome then Some (StyleParam.Range.MinMax (MinMax.Value)) else None
            let domain = if Domain.IsSome then Some (StyleParam.Range.MinMax (Domain.Value)) else None
            let yaxis  = Axis.LinearAxis.init(Title=title,?Range=range,?Showgrid=Showgrid,
                                    ?Showline=Showline,?Anchor=Anchor,?Side=Side,?Domain=domain,?Overlaying=Overlaying,?Position=Position,?Zeroline=Zeroline)
            Chart.withY_Axis(yaxis,?Id=Id)                


        // Sets z-Axis of 3d- Charts
        [<CompiledName("WithZ_Axis")>]
        static member withZ_Axis(zAxis:Axis.LinearAxis) =
            (fun (ch:GenericChart) ->
                let layout =
                    Layout() 
                    |> Layout.style(Scene=Scene.init(zAxis=zAxis) )
                GenericChart.addLayout layout ch
             )


        // Sets z-Axis style with ...
        [<CompiledName("WithZ_AxisStyle")>]
        static member withZ_AxisStyle(title,
                [<Optional;DefaultParameterValue(null)>] ?MinMax,
                [<Optional;DefaultParameterValue(null)>] ?Showgrid,
                [<Optional;DefaultParameterValue(null)>] ?Showline,
                [<Optional;DefaultParameterValue(null)>] ?Domain,
                [<Optional;DefaultParameterValue(null)>] ?Anchor) =
            let range  = if MinMax.IsSome then Some (StyleParam.Range.MinMax (MinMax.Value)) else None
            let domain = if Domain.IsSome then Some (StyleParam.Range.MinMax (Domain.Value)) else None
            let zaxis  = Axis.LinearAxis.init(Title=title,?Range=range,?Showgrid=Showgrid,?Showline=Showline,?Anchor=Anchor,?Domain=domain)
            Chart.withZ_Axis(zaxis)

        [<CompiledName("WithColorBar")>]
        static member withColorBar(colorbar:Colorbar) =
            (fun (ch:GenericChart) ->
                ch
                |> GenericChart.mapTrace(fun t ->
                    colorbar |> DynObj.setValue t "colorbar" 
                    t
                )
            )

        
        [<CompiledName("withColorbar")>]
        static member withColorBarStyle(title,
                [<Optional;DefaultParameterValue(null)>] ?TitleSide: StyleParam.Side,
                [<Optional;DefaultParameterValue(null)>] ?TitleFont: Font,
                [<Optional;DefaultParameterValue(null)>] ?Length,
                [<Optional;DefaultParameterValue(null)>] ?OutlineColor,
                [<Optional;DefaultParameterValue(null)>] ?BorderColor,
                [<Optional;DefaultParameterValue(null)>] ?BGColor) =
            let colorbar = Colorbar.init(Title=title,?Titleside=TitleSide,?Titlefont=TitleFont,?Len = Length,?Outlinecolor=OutlineColor,?Bgcolor=BGColor,?Bordercolor=BorderColor)
            Chart.withColorBar(colorbar)
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
        [<CompiledName("WithLayout")>]
        static member withLayout(layout:Layout) =
            (fun (ch:GenericChart) -> 
                GenericChart.addLayout layout ch) 

        // Set the LayoutGrid options of a Chart
        [<CompiledName("WithLayoutGrid")>]
        static member withLayoutGrid(layoutGrid:LayoutGrid) =
            (fun (ch:GenericChart) -> 
                let layout = 
                    GenericChart.getLayout ch
                    |> Layout.SetLayoutGrid layoutGrid 
                GenericChart.setLayout layout ch) 

        // Set the LayoutGrid options of a Chart
        [<CompiledName("WithLegend")>]
        static member withLegend(legend:Legend) =
            (fun (ch:GenericChart) -> 
                let layout = 
                    GenericChart.getLayout ch
                    |> Layout.setLegend legend 
                GenericChart.setLayout layout ch) 

        /// Sets a map for the given chart (will only work with traces supporting geo, e.g. choropleth, scattergeo)
        [<CompiledName("WithMap")>]
        static member withMap(map:Geo,[<Optional;DefaultParameterValue(null)>] ?Id ) =
            (fun (ch:GenericChart) ->
                let layout =
                    let id = defaultArg Id 1
                    GenericChart.getLayout ch 
                    |> Layout.UpdateMapById(id,map)
                GenericChart.setLayout layout ch
            )

        /// Sets the map style for the given chart (will only work with traces supporting geo, e.g. choropleth, scattergeo)
        ///
        /// Parameters      :
        ///
        /// FitBounds       : Determines if and how this subplot's view settings are auto-computed to fit trace data
        ///
        /// Resolution      : Sets the resolution of the base layers
        ///
        /// Scope           : Set the scope of the map.
        ///
        /// Projection      : Determines the type of projection used to display the map
        ///
        /// Center          : Sets the (lon,lat) coordinates of the map's center. By default, the map's longitude center lies at the middle of the longitude range for scoped projection and above `projection.rotation.lon` otherwise. For all projection types, the map's latitude center lies at the middle of the latitude range by default.
        ///
        /// Visible         : Wether or not the base layers are visible
        ///
        /// Domain          : The domain of this geo subplot
        ///
        /// ShowCoastLine   : Sets whether or not the coastlines are drawn.
        ///
        /// CoastLineColor  : Sets the coastline color.
        ///
        /// CoastLineWidth  : Sets the coastline stroke width (in px).
        ///
        /// ShowLand        : Sets whether or not land masses are filled in color.
        ///
        /// LandColor       : Sets the land mass color.
        ///
        /// ShowOcean       : Sets whether or not oceans are filled in color.
        ///
        /// OceanColor      : Sets the ocean color
        ///
        /// ShowLakes       : Sets whether or not lakes are drawn.
        ///
        /// LakeColor       : Sets the color of the lakes.
        ///
        /// ShowRivers      : Sets whether or not rivers are drawn.
        ///
        /// RiverColor      : Sets color of the rivers.
        ///
        /// RiverWidth      : Sets the stroke width (in px) of the rivers.
        ///
        /// ShowCountries   : Sets whether or not country boundaries are drawn.
        ///
        /// CountryColor    : Sets line color of the country boundaries.
        ///
        /// CountryWidth    : Sets line width (in px) of the country boundaries.
        ///
        /// ShowSubunits    : Sets whether or not boundaries of subunits within countries (e.g. states, provinces) are drawn.
        ///
        /// SubunitColor    : Sets the color of the subunits boundaries.
        ///
        /// SubunitWidth    : Sets the stroke width (in px) of the subunits boundaries.
        ///
        /// ShowFrame       : Sets whether or not a frame is drawn around the map.
        ///
        /// FrameColor      : Sets the color the frame.
        ///
        /// FrameWidth      : Sets the stroke width (in px) of the frame.
        ///
        /// BgColor         : Set the background color of the map
        ///
        /// LatAxis         : Sets the latitudinal axis for this geo trace
        ///
        /// LonAxis         : Sets the longitudinal axis for this geo trace
        [<CompiledName("WithMapStyle")>]
        static member withMapStyle([<Optional;DefaultParameterValue(null)>] ?Id,
            [<Optional;DefaultParameterValue(null)>]?FitBounds       : StyleParam.GeoFitBounds,
            [<Optional;DefaultParameterValue(null)>]?Resolution      : StyleParam.GeoResolution,
            [<Optional;DefaultParameterValue(null)>]?Scope           : StyleParam.GeoScope,
            [<Optional;DefaultParameterValue(null)>]?Projection      : GeoProjection,
            [<Optional;DefaultParameterValue(null)>]?Center          : (float*float),
            [<Optional;DefaultParameterValue(null)>]?Visible         : bool,
            [<Optional;DefaultParameterValue(null)>]?Domain          : Domain,
            [<Optional;DefaultParameterValue(null)>]?ShowCoastLines  : bool,
            [<Optional;DefaultParameterValue(null)>]?CoastLineColor,
            [<Optional;DefaultParameterValue(null)>]?CoastLineWidth  : float,
            [<Optional;DefaultParameterValue(null)>]?ShowLand        : bool,
            [<Optional;DefaultParameterValue(null)>]?LandColor,
            [<Optional;DefaultParameterValue(null)>]?ShowOcean       : bool,
            [<Optional;DefaultParameterValue(null)>]?OceanColor,
            [<Optional;DefaultParameterValue(null)>]?ShowLakes       : bool,
            [<Optional;DefaultParameterValue(null)>]?LakeColor,
            [<Optional;DefaultParameterValue(null)>]?ShowRivers      : bool,
            [<Optional;DefaultParameterValue(null)>]?RiverColor,
            [<Optional;DefaultParameterValue(null)>]?RiverWidth      : float,
            [<Optional;DefaultParameterValue(null)>]?ShowCountries   : bool,
            [<Optional;DefaultParameterValue(null)>]?CountryColor,
            [<Optional;DefaultParameterValue(null)>]?CountryWidth    : float,
            [<Optional;DefaultParameterValue(null)>]?ShowSubunits    : bool,
            [<Optional;DefaultParameterValue(null)>]?SubunitColor,
            [<Optional;DefaultParameterValue(null)>]?SubunitWidth    : float,
            [<Optional;DefaultParameterValue(null)>]?ShowFrame       : bool,
            [<Optional;DefaultParameterValue(null)>]?FrameColor,
            [<Optional;DefaultParameterValue(null)>]?FrameWidth      : float,
            [<Optional;DefaultParameterValue(null)>]?BgColor,
            [<Optional;DefaultParameterValue(null)>]?LatAxis         : Axis.LinearAxis,
            [<Optional;DefaultParameterValue(null)>]?LonAxis         : Axis.LinearAxis
        ) =
            (fun (ch:GenericChart) ->
                
                let map = 
                    Geo.init(
                        ?FitBounds      = FitBounds     ,
                        ?Resolution     = Resolution    ,
                        ?Scope          = Scope         ,
                        ?Projection     = Projection    ,
                        ?Center         = Center        ,
                        ?Visible        = Visible       ,
                        ?Domain         = Domain        ,
                        ?ShowCoastLines = ShowCoastLines,
                        ?CoastLineColor = CoastLineColor,
                        ?CoastLineWidth = CoastLineWidth,
                        ?ShowLand       = ShowLand      ,
                        ?LandColor      = LandColor     ,
                        ?ShowOcean      = ShowOcean     ,
                        ?OceanColor     = OceanColor    ,
                        ?ShowLakes      = ShowLakes     ,
                        ?LakeColor      = LakeColor     ,
                        ?ShowRivers     = ShowRivers    ,
                        ?RiverColor     = RiverColor    ,
                        ?RiverWidth     = RiverWidth    ,
                        ?ShowCountries  = ShowCountries ,
                        ?CountryColor   = CountryColor  ,
                        ?CountryWidth   = CountryWidth  ,
                        ?ShowSubunits   = ShowSubunits  ,
                        ?SubunitColor   = SubunitColor  ,
                        ?SubunitWidth   = SubunitWidth  ,
                        ?ShowFrame      = ShowFrame     ,
                        ?FrameColor     = FrameColor    ,
                        ?FrameWidth     = FrameWidth    ,
                        ?BgColor        = BgColor       ,
                        ?LatAxis        = LatAxis       ,
                        ?LonAxis        = LonAxis       
                    )
                let id = defaultArg Id 1
                ch |> Chart.withMap(map,id)
            )

        [<CompiledName("WithMapProjection")>]
        static member withMapProjection(projectionType : StyleParam.GeoProjectionType,
             [<Optional;DefaultParameterValue(null)>]?Rotation ,
             [<Optional;DefaultParameterValue(null)>]?Parallels,
             [<Optional;DefaultParameterValue(null)>]?Scale    ,
             [<Optional;DefaultParameterValue(null)>]?Id
            ) =
            (fun (ch:GenericChart) ->

                let projection = 
                    GeoProjection.init(
                        projectionType  = projectionType,
                        ?Rotation       = Rotation      ,
                        ?Parallels      = Parallels     ,
                        ?Scale          = Scale        
                    )

                let map = Geo.init(Projection     = projection)
                let id = defaultArg Id 1
                ch |> Chart.withMap(map,id)
            )

        // Set the LayoutGrid options of a Chart
        [<CompiledName("WithLayoutGridStyle")>]
        static member withLayoutGridStyle([<Optional;DefaultParameterValue(null)>]?SubPlots   : StyleParam.AxisId [] [],
            [<Optional;DefaultParameterValue(null)>]?XAxes      : StyleParam.AxisId [],
            [<Optional;DefaultParameterValue(null)>]?YAxes      : StyleParam.AxisId [],
            [<Optional;DefaultParameterValue(null)>]?Rows       : int,
            [<Optional;DefaultParameterValue(null)>]?Columns    : int,
            [<Optional;DefaultParameterValue(null)>]?RowOrder   : StyleParam.LayoutGridRowOrder,
            [<Optional;DefaultParameterValue(null)>]?Pattern    : StyleParam.LayoutGridPattern,
            [<Optional;DefaultParameterValue(null)>]?XGap       : float,
            [<Optional;DefaultParameterValue(null)>]?YGap       : float,
            [<Optional;DefaultParameterValue(null)>]?Domain     : Domain,
            [<Optional;DefaultParameterValue(null)>]?XSide      : StyleParam.LayoutGridXSide,
            [<Optional;DefaultParameterValue(null)>]?YSide      : StyleParam.LayoutGridYSide
        ) =
            (fun (ch:GenericChart) -> 
                let layout = GenericChart.getLayout ch
                let updatedGrid =   
                    let currentGrid = 
                        match layout.TryGetTypedValue<LayoutGrid> "grid" with
                        | Some grid -> grid
                        | None -> LayoutGrid()
                    currentGrid
                    |> LayoutGrid.style(
                        ?SubPlots    = SubPlots,
                        ?XAxes       = XAxes   ,
                        ?YAxes       = YAxes   ,
                        ?Rows        = Rows    ,
                        ?Columns     = Columns ,
                        ?RowOrder    = RowOrder,
                        ?Pattern     = Pattern ,
                        ?XGap        = XGap    ,
                        ?YGap        = YGap    ,
                        ?Domain      = Domain  ,
                        ?XSide       = XSide   ,
                        ?YSide       = YSide   
                    )
                let updatedLayout = layout |> Layout.SetLayoutGrid updatedGrid
                GenericChart.setLayout updatedLayout ch) 

        [<CompiledName("WithConfig")>]
        static member withConfig (config:Config) =
            (fun (ch:GenericChart) ->
                GenericChart.setConfig config ch)
        
        [<CompiledName("WithAnnotations")>]
        static member withAnnotations(annotations:seq<Annotation>) =
            (fun (ch:GenericChart) -> 
                ch
                |> GenericChart.mapLayout 
                    (Layout.style (Annotations = annotations)))

        // Set the title of a Chart
        [<CompiledName("WithTitle")>]
        static member withTitle(title,[<Optional;DefaultParameterValue(null)>] ?Titlefont) =
            (fun (ch:GenericChart) ->
                let layout =
                    Layout() 
                    |> Layout.style(Title=title,?Titlefont=Titlefont)
                GenericChart.addLayout layout ch
             )  


        // Set showLegend of a Chart
        [<CompiledName("WithLegend")>]
        static member withLegend(showlegend) =
            (fun (ch:GenericChart) ->
                let layout =
                    Layout() 
                    |> Layout.style(Showlegend=showlegend)
                GenericChart.addLayout layout ch
             )  

        
        // Set the size of a Chart
        [<CompiledName("WithSize")>]
        static member withSize(width,height) =
            (fun (ch:GenericChart) -> 
                let layout = 
                    GenericChart.getLayout ch
                    |> Layout.style (Width=width,Height=height)
                GenericChart.setLayout layout ch
            )

        // Set the margin of a Chart
        [<CompiledName("WithMargin")>]
        static member withMargin(margin:Margin) =
            (fun (ch:GenericChart) ->
                let layout =
                    GenericChart.getLayout ch 
                    |> Layout.style (Margin=margin)
                GenericChart.setLayout layout ch)   

        // Set the margin of a Chart
        [<CompiledName("WithMarginSize")>]
        static member withMarginSize
            (
                [<Optional;DefaultParameterValue(null)>] ?Left,
                [<Optional;DefaultParameterValue(null)>] ?Right,
                [<Optional;DefaultParameterValue(null)>] ?Top,
                [<Optional;DefaultParameterValue(null)>] ?Bottom,
                [<Optional;DefaultParameterValue(null)>] ?Pad,
                [<Optional;DefaultParameterValue(null)>] ?Autoexpand
            ) =                       
                let margin = 
                    Margin.init ( ?Left=Left,?Right=Right,?Top=Top,?Bottom=Bottom,?Pad=Pad,?Autoexpand=Autoexpand )
                Chart.withMargin(margin)

        [<CompiledName("WithTemplate")>]
        static member withTemplate(template: Template) =
            (fun (ch:GenericChart) ->
                ch
                |> GenericChart.mapLayout (fun l ->
                    template |> DynObj.setValue l "template"
                    l
                    )
            )

        // TODO: Include withLegend & withLegendStyle

    //Specifies the shape type to be drawn. If "line", a line is drawn from (`x0`,`y0`) to (`x1`,`y1`) If "circle", a circle is drawn from 
    //((`x0`+`x1`)/2, (`y0`+`y1`)/2)) with radius (|(`x0`+`x1`)/2 - `x0`|, |(`y0`+`y1`)/2 -`y0`)|) If "rect", a rectangle is drawn linking 
    //(`x0`,`y0`), (`x1`,`y0`), (`x1`,`y1`), (`x0`,`y1`), (`x0`,`y0`)  
        [<CompiledName("WithShape")>]
        static member withShape(shape:Shape) =
            (fun (ch:GenericChart) ->
                let layout = 
                    GenericChart.getLayout ch
                    |> Layout.style (Shapes=[shape])
                GenericChart.setLayout layout ch)


        [<CompiledName("WithShapes")>]
        static member withShapes(shapes:Shape seq) =
            (fun (ch:GenericChart) ->
                let layout = 
                    GenericChart.getLayout ch
                    |> Layout.style (Shapes=shapes)
                GenericChart.setLayout layout ch)


        // ####################### 
        /// Create a combined chart with the given charts merged
        [<CompiledName("Combine")>]
        static member Combine(gCharts:seq<GenericChart>) =
            GenericChart.combine gCharts

        ///Creates a Grid containing the given plots as subplots with the dimensions of the input (amount of columns equal to the largest inner sequence).
        ///
        ///Parameters:
        ///
        ///sharedAxes   : Wether the subplots share one xAxis per column and one yAxis per row or not. (default:TopToBottom)
        ///
        ///rowOrder     : the order in which the rows of the grid will be rendered (default:false)
        /// 
        ///xGap         : The space between columns of the grid relative to the x dimension of the grid
        ///
        ///yGap         : The space between rows of the grid relative to the y dimension of the grid
        ///
        ///Use Chart.withLayoutGridStyle to further style the grid object contained in the returned chart.
        [<CompiledName("Grid")>]
        static member Grid ((gCharts:seq<#seq<GenericChart>>),
            [<Optional;DefaultParameterValue(false)>]?sharedAxes:bool,
            [<Optional;DefaultParameterValue(null)>]?rowOrder:StyleParam.LayoutGridRowOrder,
            [<Optional;DefaultParameterValue(0.05)>] ?xGap,
            [<Optional;DefaultParameterValue(0.05)>] ?yGap
            ) =

            let sharedAxes = defaultArg sharedAxes false
            let rowOrder = defaultArg rowOrder StyleParam.LayoutGridRowOrder.TopToBottom
            let xGap = defaultArg xGap 0.05
            let yGap = defaultArg yGap 0.05

            let nRows = Seq.length gCharts
            let nCols = gCharts |> Seq.maxBy Seq.length |> Seq.length
            let pattern = if sharedAxes then StyleParam.LayoutGridPattern.Coupled else StyleParam.LayoutGridPattern.Independent

            let generateDomainRanges (count:int) (gap:float) =
                [|0. .. (1. / (float count)) .. 1.|]
                |> fun doms -> 
                    doms
                    |> Array.windowed 2
                    |> Array.mapi (fun i x -> 
                        if i = 0 then
                            x.[0], (x.[1] - (gap / 2.))
                        elif i = (doms.Length - 1) then
                           (x.[0] + (gap / 2.)),x.[1]
                        else
                           (x.[0] + (gap / 2.)) , (x.[1] - (gap / 2.))
                    )

            let yDomains = generateDomainRanges nRows yGap
            let xDomains = generateDomainRanges nCols xGap

            gCharts
            |> Seq.mapi (fun rowIndex row ->
                row |> Seq.mapi (fun colIndex gChart ->
                    let xdomain = xDomains.[colIndex]
                    let ydomain = yDomains.[rowIndex]

                    let newXIndex, newYIndex =
                        (if sharedAxes then colIndex + 1 else ((nRows * rowIndex) + (colIndex + 1))),
                        (if sharedAxes then rowIndex + 1 else ((nRows * rowIndex) + (colIndex + 1)))


                    let xaxis,yaxis,layout = 
                        let layout = GenericChart.getLayout gChart
                        let xAxisName, yAxisName = StyleParam.AxisId.X 1 |> StyleParam.AxisId.toString, StyleParam.AxisId.Y 1 |> StyleParam.AxisId.toString
                
                        let updateXAxis index domain axis = 
                            axis |> Axis.LinearAxis.style(Anchor=StyleParam.AxisAnchorId.X index,Domain=StyleParam.Range.MinMax domain)
                
                        let updateYAxis index domain axis = 
                            axis |> Axis.LinearAxis.style(Anchor=StyleParam.AxisAnchorId.Y index,Domain=StyleParam.Range.MinMax domain)
                        match (layout.TryGetTypedValue<Axis.LinearAxis> xAxisName),(layout.TryGetTypedValue<Axis.LinearAxis> yAxisName) with
                        | Some x, Some y ->
                            // remove axis
                            DynObj.remove layout xAxisName
                            DynObj.remove layout yAxisName

                            x |> updateXAxis newXIndex xdomain,
                            y |> updateYAxis newYIndex ydomain,
                            layout

                        | Some x, None -> 
                            // remove x - axis
                            DynObj.remove layout xAxisName

                            x |> updateXAxis newXIndex xdomain,
                            Axis.LinearAxis.init(Anchor=StyleParam.AxisAnchorId.Y newYIndex ,Domain=StyleParam.Range.MinMax ydomain),
                            layout

                        | None, Some y -> 
                            // remove y - axis
                            DynObj.remove layout yAxisName

                            Axis.LinearAxis.init(Anchor=StyleParam.AxisAnchorId.X newXIndex,Domain=StyleParam.Range.MinMax xdomain),
                            y |> updateYAxis newYIndex ydomain,
                            layout
                        | None, None ->
                            Axis.LinearAxis.init(Anchor=StyleParam.AxisAnchorId.X newXIndex,Domain=StyleParam.Range.MinMax xdomain),
                            Axis.LinearAxis.init(Anchor=StyleParam.AxisAnchorId.Y newYIndex,Domain=StyleParam.Range.MinMax ydomain),
                            layout

                    gChart
                    |> GenericChart.setLayout layout
                    |> Chart.withAxisAnchor(X=newXIndex,Y=newYIndex) 
                    |> Chart.withX_Axis(xaxis,newXIndex)
                    |> Chart.withY_Axis(yaxis,newYIndex)
                )
            )
            |> Seq.map Chart.Combine
            |> Chart.Combine
            |> Chart.withLayoutGrid(
                LayoutGrid.init(
                    Rows=nRows,Columns=nCols,XGap= xGap,YGap= yGap,Pattern=pattern,RowOrder=rowOrder
                )
            )
        
        ///Creates a chart stack from the input charts by stacking them on top of each other starting from the first chart.
        ///
        ///Parameters:
        ///
        ///sharedAxis   : wether the stack has a shared x axis (default:true)
        [<CompiledName("SingleStack")>]
        static member SingleStack (charts:#seq<GenericChart>,
            [<Optional;DefaultParameterValue(true)>] ?sharedXAxis:bool) =
            
            let sharedAxis = defaultArg sharedXAxis true
            let singleCol = seq {
                    for i = 0 to ((Seq.length charts) - 1) do
                        yield seq {Seq.item i charts}
                }
            Chart.Grid(gCharts = singleCol, sharedAxes = sharedAxis, rowOrder = StyleParam.LayoutGridRowOrder.BottomToTop)

        /// Create a combined chart with the given charts merged
        [<Obsolete("Use Chart.Grid for multi column grid charts or singleStack for one-column stacked charts.")>]
        [<CompiledName("Stack")>]
        static member Stack ( [<Optional;DefaultParameterValue(null)>] ?Columns:int, 
                [<Optional;DefaultParameterValue(null)>] ?Space) = 
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

                let contains3d ch =
                    ch 
                    |> existsTrace (fun t -> 
                        match t with
                        | :? Trace3d -> true
                        | _ -> false)

                charts
                |> Seq.mapi (fun i ch ->
                    let colI,rowI,index = (i%col+1), (i/col+1),(i+1)
                    let xdomain = (colWidth * float (colI-1), (colWidth * float colI) - space ) 
                    let ydomain = (1. - ((rowWidth * float rowI) - space ),1. - (rowWidth * float (rowI-1)))

                    if contains3d ch then
                        let sceneName = sprintf "scene%i" (i+1)

                        let scene =
                            Scene.init (
                                Domain =
                                    Domain.init(X = StyleParam.Range.MinMax xdomain,Y= StyleParam.Range.MinMax ydomain)
                            )
                        let layout = 
                            GenericChart.getLayout ch
                            |> Layout.AddScene (
                                    sceneName, 
                                    scene
                                )
                        ch
                        |> mapTrace 
                            (fun t -> 
                                t?scene <- sceneName
                                t
                            )
                        |> GenericChart.setLayout layout
                        //|> Chart.withAxisAnchor(X=index,Y=index) 
                    else

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
        
// ############################################################
// ####################### Apply to DisplayOptions

        /// Show chart in browser
        [<CompiledName("WithDescription")>]
        static member WithDescription (description:ChartDescription) (ch:GenericChart) = 
            ch 
            |> mapDisplayOptions (DisplayOptions.style(Description=description))


        /// Adds the given additional script tags on the chart's DisplayOptions.
        [<CompiledName("WithAdditionalScriptTags")>]
        static member WithAdditionalScriptTags (additionalScriptTags:seq<string>) (ch:GenericChart) = 
            ch 
            |> mapDisplayOptions ( fun d ->
                let tags = d.TryGetTypedValue<seq<string>>("AdditionalScriptTags")
                let newTags =
                    tags
                    |> Option.map (fun tags -> seq{yield! tags; yield! additionalScriptTags})
                    |> Option.defaultValue additionalScriptTags
                d |> DisplayOptions.style(AdditionalScriptTags=newTags)
            )

        /// Sets the given additional script tags on the chart's DisplayOptions.
        [<CompiledName("WithScriptTags")>]
        static member WithScriptTags (scriptTags:seq<string>) (ch:GenericChart) = 
            ch 
            |> mapDisplayOptions (DisplayOptions.style(AdditionalScriptTags=scriptTags))

        
        /// Adds the necessary script tags to render tex strings to the chart's DisplayOptions
        [<CompiledName("WithMathTex")>]
        static member WithMathTex ([<Optional;DefaultParameterValue(true)>]?AppendTags:bool) = 
            let tags = [
                """<script type="text/x-mathjax-config;executed=true">MathJax.Hub.Config({tex2jax: {inlineMath: [['$','$'], ['\\(','\\)']], processEscapes: true}});</script>"""
                """<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/mathjax/2.7.5/MathJax.js?config=TeX-AMS-MML_HTMLorMML%2CSafe.js&ver=4.1"></script>"""
            ]
            (fun (ch:GenericChart) ->
            
                if (AppendTags |> Option.defaultValue true) then
                    ch |> Chart.WithAdditionalScriptTags tags
                else
                    ch |> Chart.WithScriptTags tags
            )

        /// Save chart as html single page
        [<CompiledName("SaveHtmlAs")>]
        static member SaveHtmlAs pathName (ch:GenericChart,[<Optional;DefaultParameterValue(null)>] ?Verbose) =
            let html = GenericChart.toEmbeddedHTML ch
            let file = sprintf "%s.html" pathName // remove file extension
            File.WriteAllText(file, html)

            let verbose = defaultArg Verbose false
            if verbose then
                file |> openOsSpecificFile

        /// Show chart in browser
        [<CompiledName("Show")>]
        static member Show (ch:GenericChart) = 
            let guid = Guid.NewGuid().ToString()
            let html = GenericChart.toEmbeddedHTML ch
            let tempPath = Path.GetTempPath()
            let file = sprintf "%s.html" guid
            let path = Path.Combine(tempPath, file)
            File.WriteAllText(path, html)
            path |> openOsSpecificFile

        /// Show chart in browser
        [<CompiledName("ShowAsImage")>]
        static member ShowAsImage (format:StyleParam.ImageFormat) (ch:GenericChart) = 
            let guid = Guid.NewGuid().ToString()
            let html = GenericChart.toEmbeddedImage format ch
            let tempPath = Path.GetTempPath()
            let file = sprintf "%s.html" guid
            let path = Path.Combine(tempPath, file)
            File.WriteAllText(path, html)
            path |> openOsSpecificFile