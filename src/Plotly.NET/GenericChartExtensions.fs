namespace Plotly.NET

open System
open System.IO

open GenericChart
open ChartDescription
open System.Runtime.InteropServices
open System.Runtime.CompilerServices

///Extension methods for providing a Plotly.NET fluent interface pattern for C#
[<Extension>]
module GenericChartExtensions =

    type GenericChart with
        
        [<CompiledName("WithTraceName")>]
        [<Extension>]
        member this.WithTraceName
            (
                [<Optional;DefaultParameterValue(null)>] ?Name,
                [<Optional;DefaultParameterValue(null)>] ?Showlegend,
                [<Optional;DefaultParameterValue(null)>] ?Legendgroup,
                [<Optional;DefaultParameterValue(null)>] ?Visible
            ) =
                this |> Chart.withTraceName(?Name=Name,?Showlegend=Showlegend,?Legendgroup=Legendgroup,?Visible=Visible)

        /// Set the axis anchor id the trace is belonging to
        [<CompiledName("WithAxisAnchor")>]
        [<Extension>]
        member this.WithAxisAnchor
            (
                [<Optional;DefaultParameterValue(null)>] ?X,
                [<Optional;DefaultParameterValue(null)>] ?Y,
                [<Optional;DefaultParameterValue(null)>] ?Z
            ) =
                let idx   = if X.IsSome then Some (StyleParam.AxisAnchorId.X X.Value) else None
                let idy   = if Y.IsSome then Some (StyleParam.AxisAnchorId.Y Y.Value) else None
                let idz   = if Z.IsSome then Some (StyleParam.AxisAnchorId.Z Z.Value) else None
    
                this 
                |> mapTrace (fun trace ->
                    trace 
                    |> Trace.TraceStyle.SetAxisAnchor(?X=idx,?Y=idy,?Z=idz)
                )

        /// Apply styling to the Marker(s) of the chart as Object.
        [<CompiledName("WithMarker")>]
        [<Extension>]
        member this.WithMarker(marker:Marker) =
            this |> mapTrace (Trace.TraceStyle.SetMarker(marker))

        /// Apply styling to the Marker(s) of the chart.
        [<CompiledName("WithMarkerStyle")>]
        [<Extension>]
        member this.WithMarkerStyle
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
                this |>  Chart.withMarker(marker)

        /// Apply styling to the Line(s) of the chart as Object.
        [<CompiledName("WithLine")>]
        [<Extension>]
        member this.WithLine(line:Line) =
             this |> mapTrace (Trace.TraceStyle.SetLine(line))

        /// Apply styling to the Line(s) of the chart.
        [<CompiledName("WithLineStyle")>]
        [<Extension>]
        member this.WithLineStyle
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

                this |> Chart.withLine(line)

        /// Apply styling to the xError(s) of the chart as Object
        [<CompiledName("WithXError")>]
        [<Extension>]
        member this.WithXError(xError:Error) =
            this |> mapTrace (Trace.TraceStyle.SetErrorX(xError))
            
        /// Apply styling to the xError(s) of the chart as Object
        [<CompiledName("WithXErrorStyle")>]
        [<Extension>]
        member this.WithXErrorStyle
            (
                [<Optional;DefaultParameterValue(null)>] ?Array,
                [<Optional;DefaultParameterValue(null)>] ?Arrayminus,
                [<Optional;DefaultParameterValue(null)>] ?Symmetric,
                [<Optional;DefaultParameterValue(null)>] ?Color,
                [<Optional;DefaultParameterValue(null)>] ?Thickness,
                [<Optional;DefaultParameterValue(null)>] ?Width
            ) =
                let error = Error.init(?Array=Array,?Arrayminus=Arrayminus,?Symmetric=Symmetric,?Color=Color,?Thickness=Thickness,?Width=Width)
                this |> Chart.withXError error

        /// Apply styling to the yError(s) of the chart as Object
        [<CompiledName("WithYError")>]
        [<Extension>]
        member this.WithYError(yError:Error) =
            this |> mapTrace (Trace.TraceStyle.SetErrorY(yError))
            
        /// Apply styling to the yError(s) of the chart as Object
        [<CompiledName("WithYErrorStyle")>]
        [<Extension>]
        member this.WithYErrorStyle
            (
                [<Optional;DefaultParameterValue(null)>] ?Array,
                [<Optional;DefaultParameterValue(null)>] ?Arrayminus,
                [<Optional;DefaultParameterValue(null)>] ?Symmetric,
                [<Optional;DefaultParameterValue(null)>] ?Color,
                [<Optional;DefaultParameterValue(null)>] ?Thickness,
                [<Optional;DefaultParameterValue(null)>] ?Width
            ) =
                let error = Error.init(?Array=Array,?Arrayminus=Arrayminus,?Symmetric=Symmetric,?Color=Color,?Thickness=Thickness,?Width=Width)
                this |> Chart.withYError error

        /// Apply styling to the zError(s) of the chart as Object
        [<CompiledName("WithZError")>]
        [<Extension>]
        member this.WithZError(zError:Error) =
            this |> mapTrace (Trace.TraceStyle.SetErrorZ(zError))
            

        /// Apply styling to the zError(s) of the chart as Object
        [<CompiledName("WithZErrorStyle")>]
        [<Extension>]
        member this.WithZErrorStyle
            (
                [<Optional;DefaultParameterValue(null)>] ?Array,
                [<Optional;DefaultParameterValue(null)>] ?Arrayminus,
                [<Optional;DefaultParameterValue(null)>] ?Symmetric,
                [<Optional;DefaultParameterValue(null)>] ?Color,
                [<Optional;DefaultParameterValue(null)>] ?Thickness,
                [<Optional;DefaultParameterValue(null)>] ?Width
            ) =
                let error = Error.init(?Array=Array,?Arrayminus=Arrayminus,?Symmetric=Symmetric,?Color=Color,?Thickness=Thickness,?Width=Width)
                this |> Chart.withZError error


        // ############################################################
        // ####################### Apply to layout

        // Sets x-Axis of 2d and 3d- Charts
        [<CompiledName("WithX_Axis")>]
        [<Extension>]
        member this.WithX_Axis(xAxis:Axis.LinearAxis,[<Optional;DefaultParameterValue(null)>] ?Id) =

            let contains3d =
                this 
                |> existsTrace (fun t ->
                    match t with
                    | :? Trace3d -> true
                    | _ -> false)

            match contains3d with
            | false -> 
                let layout =
                    let id = if Id.IsSome then StyleParam.AxisId.X Id.Value else StyleParam.AxisId.X 1
                    GenericChart.getLayout this
                    |> Layout.UpdateLinearAxisById(id,axis=xAxis)
                GenericChart.setLayout layout this
            | true  -> 
                let layout =
                    Layout() 
                    |> Layout.style (Scene=Scene.init( xAxis=xAxis) )
                GenericChart.addLayout layout this

        // Sets x-Axis of 2d and 3d- Charts
        [<CompiledName("WithX_AxisStyle")>]
        [<Extension>]
        member this.WithX_AxisStyle(title,
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
            this |> Chart.withX_Axis(xaxis,?Id=Id)

        /// Sets the range slider for the xAxis
        [<CompiledName("WithX_AxisRangeSlider")>]
        [<Extension>]
        member this.WithX_AxisRangeSlider(rangeSlider:RangeSlider,
                [<Optional;DefaultParameterValue(null)>] ?Id) =
            let xaxis  = Axis.LinearAxis.init(RangeSlider = rangeSlider)
            this |> Chart.withX_Axis(xaxis,?Id=Id)

        // Sets y-Axis of 2d and 3d- Charts
        [<CompiledName("WithY_Axis")>]
        [<Extension>]
        member this.WithY_Axis(yAxis:Axis.LinearAxis,[<Optional;DefaultParameterValue(null)>] ?Id) =
            
            let contains3d =
                this 
                |> existsTrace (fun t -> 
                    match t with
                    | :? Trace3d -> true
                    | _ -> false)

            match contains3d with
            | false -> 
                let layout =
                    let id = if Id.IsSome then StyleParam.AxisId.Y Id.Value else StyleParam.AxisId.Y 1
                    GenericChart.getLayout this 
                    |> Layout.UpdateLinearAxisById(id,axis=yAxis)
                GenericChart.setLayout layout this
            | true  -> 
                let layout =
                    Layout() 
                    |> Layout.style(Scene=Scene.init(yAxis=yAxis) )
                GenericChart.addLayout layout this

         // Sets y-Axis of 3d- Charts
        [<CompiledName("WithY_AxisStyle")>]
        [<Extension>]
        member this.WithY_AxisStyle(title,
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
            this |> Chart.withY_Axis(yaxis,?Id=Id)                


        // Sets z-Axis of 3d- Charts
        [<CompiledName("WithZ_Axis")>]
        [<Extension>]
        member this.WithZ_Axis(zAxis:Axis.LinearAxis) =
            let layout =
                Layout() 
                |> Layout.style(Scene=Scene.init(zAxis=zAxis))
            GenericChart.addLayout layout this
             


        // Sets z-Axis style with ...
        [<CompiledName("WithZ_AxisStyle")>]
        [<Extension>]
        member this.WithZ_AxisStyle(title,
                [<Optional;DefaultParameterValue(null)>] ?MinMax,
                [<Optional;DefaultParameterValue(null)>] ?Showgrid,
                [<Optional;DefaultParameterValue(null)>] ?Showline,
                [<Optional;DefaultParameterValue(null)>] ?Domain,
                [<Optional;DefaultParameterValue(null)>] ?Anchor) =
            let range  = if MinMax.IsSome then Some (StyleParam.Range.MinMax (MinMax.Value)) else None
            let domain = if Domain.IsSome then Some (StyleParam.Range.MinMax (Domain.Value)) else None
            let zaxis  = Axis.LinearAxis.init(Title=title,?Range=range,?Showgrid=Showgrid,?Showline=Showline,?Anchor=Anchor,?Domain=domain)
            this |> Chart.withZ_Axis(zaxis)

        [<CompiledName("WithColorBar")>]
        [<Extension>]
        member this.withColorBar(colorbar:Colorbar) =
            this
            |> GenericChart.mapTrace(fun t ->
                colorbar |> DynObj.setValue t "colorbar" 
                t
            )

        [<CompiledName("WithColorbar")>]
        [<Extension>]
        member this.WithColorBarStyle(title,
                [<Optional;DefaultParameterValue(null)>] ?TitleSide: StyleParam.Side,
                [<Optional;DefaultParameterValue(null)>] ?TitleFont: Font,
                [<Optional;DefaultParameterValue(null)>] ?Length,
                [<Optional;DefaultParameterValue(null)>] ?OutlineColor,
                [<Optional;DefaultParameterValue(null)>] ?BorderColor,
                [<Optional;DefaultParameterValue(null)>] ?BGColor) =
            let colorbar = Colorbar.init(Title=title,?Titleside=TitleSide,?Titlefont=TitleFont,?Len = Length,?Outlinecolor=OutlineColor,?Bgcolor=BGColor,?Bordercolor=BorderColor)
            this |> Chart.withColorBar(colorbar)
        
        // Set the Layout options of a Chart
        [<CompiledName("WithLayout")>]
        [<Extension>]
        member this.WithLayout(layout:Layout) =
            GenericChart.addLayout layout this

        // Set the LayoutGrid options of a Chart
        [<CompiledName("WithLayoutGrid")>]
        [<Extension>]
        member this.WithLayoutGrid(layoutGrid:LayoutGrid) =
            let layout = 
                GenericChart.getLayout this
                |> Layout.SetLayoutGrid layoutGrid 
            GenericChart.setLayout layout this

        // Set the LayoutGrid options of a Chart
        [<CompiledName("WithLegend")>]
        member this.WithLegend(legend:Legend) =
            let layout = 
                GenericChart.getLayout this
                |> Layout.setLegend legend 
            GenericChart.setLayout layout this

        /// Sets a map for the given chart (will only work with traces supporting geo, e.g. choropleth, scattergeo)
        [<CompiledName("WithMap")>]
        [<Extension>]
        member this.WithMap(map:Geo,[<Optional;DefaultParameterValue(null)>] ?Id ) =
            let layout =
                let id = defaultArg Id 1
                GenericChart.getLayout this
                |> Layout.UpdateMapById(id,map)
            GenericChart.setLayout layout this
            

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
        [<Extension>]
        member this.WithMapStyle([<Optional;DefaultParameterValue(null)>] ?Id,
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
                ) in
            let id = defaultArg Id 1 in
            this |> Chart.withMap(map,id)

        [<CompiledName("WithMapProjection")>]
        [<Extension>]
        member this.WithMapProjection(projectionType : StyleParam.GeoProjectionType,
             [<Optional;DefaultParameterValue(null)>]?Rotation ,
             [<Optional;DefaultParameterValue(null)>]?Parallels,
             [<Optional;DefaultParameterValue(null)>]?Scale    ,
             [<Optional;DefaultParameterValue(null)>]?Id
            ) =
                let projection = 
                    GeoProjection.init(
                        projectionType  = projectionType,
                        ?Rotation       = Rotation      ,
                        ?Parallels      = Parallels     ,
                        ?Scale          = Scale        
                    )

                let map = Geo.init(Projection     = projection)
                let id = defaultArg Id 1
                this |> Chart.withMap(map,id)
            

        // Set the LayoutGrid options of a Chart
        [<CompiledName("WithLayoutGridStyle")>]
        [<Extension>]
        member this.WithLayoutGridStyle([<Optional;DefaultParameterValue(null)>]?SubPlots   : StyleParam.AxisId [] [],
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

                let layout = GenericChart.getLayout this in
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
                    ) in
                let updatedLayout = layout |> Layout.SetLayoutGrid updatedGrid in
                GenericChart.setLayout updatedLayout this

        [<CompiledName("WithConfig")>]
        [<Extension>]
        member this.WithConfig (config:Config) =
            GenericChart.setConfig config this

        [<CompiledName("WithAnnotations")>]
        [<Extension>]
        member this.WithAnnotations(annotations:seq<Annotation>) =
            this
            |> GenericChart.mapLayout 
                (Layout.style (Annotations = annotations))

        // Set the title of a Chart
        [<CompiledName("WithTitle")>]
        [<Extension>]
        member this.WithTitle(title,[<Optional;DefaultParameterValue(null)>] ?Titlefont) =
            let layout =
                Layout() 
                |> Layout.style(Title=title,?Titlefont=Titlefont)
            GenericChart.addLayout layout this

        // Set showLegend of a Chart
        [<CompiledName("WithLegend")>]
        [<Extension>]
        member this.WithLegend(showlegend) =
            let layout =
                Layout() 
                |> Layout.style(Showlegend=showlegend)
            GenericChart.addLayout layout this

        // Set the size of a Chart
        [<CompiledName("WithSize")>]
        [<Extension>]
        member this.WithSize(width,height) =
            let layout = 
                GenericChart.getLayout this
                |> Layout.style (Width=width,Height=height)
            GenericChart.setLayout layout this
            
        // Set the margin of a Chart
        [<CompiledName("WithMargin")>]
        [<Extension>]
        member this.WithMargin(margin:Margin) =
            let layout =
                GenericChart.getLayout this 
                |> Layout.style (Margin=margin)
            GenericChart.setLayout layout this

        // Set the margin of a Chart
        [<CompiledName("WithMarginSize")>]
        [<Extension>]
        member this.WithMarginSize
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
                this |> Chart.withMargin(margin)

        [<CompiledName("WithTemplate")>]
        [<Extension>]
        member this.WithTemplate(template: Template) =
            this
            |> GenericChart.mapLayout (fun l ->
                template |> DynObj.setValue l "template"
                l
            )

        // TODO: Include withLegend & withLegendStyle

            //Specifies the shape type to be drawn. If "line", a line is drawn from (`x0`,`y0`) to (`x1`,`y1`) If "circle", a circle is drawn from 
            //((`x0`+`x1`)/2, (`y0`+`y1`)/2)) with radius (|(`x0`+`x1`)/2 - `x0`|, |(`y0`+`y1`)/2 -`y0`)|) If "rect", a rectangle is drawn linking 
            //(`x0`,`y0`), (`x1`,`y0`), (`x1`,`y1`), (`x0`,`y1`), (`x0`,`y0`)  
        [<CompiledName("WithShape")>]
        [<Extension>]
        member this.WithShape(shape:Shape) =
            let layout = 
                GenericChart.getLayout this
                |> Layout.style (Shapes=[shape])
            GenericChart.setLayout layout this

        [<CompiledName("WithShapes")>]
        [<Extension>]
        member this.WithShapes(shapes:Shape seq) =
            let layout = 
                GenericChart.getLayout this
                |> Layout.style (Shapes=shapes)
            GenericChart.setLayout layout this

        /// Save chart as html single page
        [<CompiledName("SaveHtmlAs")>]
        [<Extension>]
        member this.SaveHtmlAs (pathName:string, [<Optional;DefaultParameterValue(null)>] ?Verbose) =
            Chart.SaveHtmlAs pathName this

        /// Saves chart in a specified file name. The caller is responsible for full path / filename / extension.
        [<CompiledName("SaveHtmlWithDescriptionAs")>]
        [<Extension>]
        member this.SaveHtmlWithDescriptionAs 
            (   
                pathName : string, 
                description : Description, 
                [<Optional;DefaultParameterValue(null)>] ?Verbose
            ) =
                Chart.SaveHtmlWithDescriptionAs pathName description this

        /// Show chart in browser
        [<CompiledName("ShowWithDescription")>]
        [<Extension>]
        member this.ShowWithDescription (description : Description) =
            Chart.ShowWithDescription description this

        /// Show chart in browser
        [<CompiledName("Show")>]
        [<Extension>]
        member this.Show() = this |> Chart.Show

        /// Show chart in browser
        [<CompiledName("ShowAsImage")>]
        [<Extension>]
        member this.ShowAsImage (format:StyleParam.ImageFormat) = 
            this |> Chart.ShowAsImage format

    