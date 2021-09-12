namespace Plotly.NET

open DynamicObj
open Plotly.NET.LayoutObjects
open System
open System.Runtime.InteropServices

/// Layout 
type Layout() = 
    inherit ImmutableDynamicObj ()

    /// Init Layout type
    static member init
        (   
            [<Optional;DefaultParameterValue(null)>] ?Title                  : Title,
            [<Optional;DefaultParameterValue(null)>] ?ShowLegend             : bool,
            [<Optional;DefaultParameterValue(null)>] ?Legend                 : Legend,
            [<Optional;DefaultParameterValue(null)>] ?Margin                 : Margin,
            [<Optional;DefaultParameterValue(null)>] ?AutoSize               : bool,
            [<Optional;DefaultParameterValue(null)>] ?Width                  : int,
            [<Optional;DefaultParameterValue(null)>] ?Height                 : int,
            [<Optional;DefaultParameterValue(null)>] ?Font                   : Font,
            [<Optional;DefaultParameterValue(null)>] ?UniformText            : UniformText,
            [<Optional;DefaultParameterValue(null)>] ?Separators             : string,
            [<Optional;DefaultParameterValue(null)>] ?PaperBGColor           : Color,
            [<Optional;DefaultParameterValue(null)>] ?PlotBGColor            : Color,
            [<Optional;DefaultParameterValue(null)>] ?AutoTypeNumbers        : StyleParam.AutoTypeNumbers,
            [<Optional;DefaultParameterValue(null)>] ?Colorscale             : DefaultColorScales,
            [<Optional;DefaultParameterValue(null)>] ?Colorway               : Color,
            [<Optional;DefaultParameterValue(null)>] ?ModeBar                : ModeBar,
            [<Optional;DefaultParameterValue(null)>] ?HoverMode              : StyleParam.HoverMode,
            [<Optional;DefaultParameterValue(null)>] ?ClickMode              : StyleParam.ClickMode,
            [<Optional;DefaultParameterValue(null)>] ?DragMode               : StyleParam.DragMode,
            [<Optional;DefaultParameterValue(null)>] ?SelectDirection        : StyleParam.SelectDirection,
            [<Optional;DefaultParameterValue(null)>] ?HoverDistance          : int,
            [<Optional;DefaultParameterValue(null)>] ?SpikeDistance          : int,
            [<Optional;DefaultParameterValue(null)>] ?Hoverlabel             : Hoverlabel,
            [<Optional;DefaultParameterValue(null)>] ?Transition             : Transition,
            [<Optional;DefaultParameterValue(null)>] ?DataRevision           : string,
            [<Optional;DefaultParameterValue(null)>] ?UIRevision             : string,
            [<Optional;DefaultParameterValue(null)>] ?EditRevision           : string,
            [<Optional;DefaultParameterValue(null)>] ?SelectRevision         : string,
            [<Optional;DefaultParameterValue(null)>] ?Template               : ImmutableDynamicObj,
            [<Optional;DefaultParameterValue(null)>] ?Meta                   : string,
            [<Optional;DefaultParameterValue(null)>] ?Computed               : string,
            [<Optional;DefaultParameterValue(null)>] ?Grid                   : LayoutGrid,
            [<Optional;DefaultParameterValue(null)>] ?Calendar               : StyleParam.Calendar,
            [<Optional;DefaultParameterValue(null)>] ?NewShape               : Shape,
            [<Optional;DefaultParameterValue(null)>] ?ActiveShape            : ActiveShape,
            [<Optional;DefaultParameterValue(null)>] ?HideSources            : bool,
            [<Optional;DefaultParameterValue(null)>] ?BarGap                 : float, 
            [<Optional;DefaultParameterValue(null)>] ?BarGroupGap            : float,
            [<Optional;DefaultParameterValue(null)>] ?BarMode                : StyleParam.BarMode,
            [<Optional;DefaultParameterValue(null)>] ?BarNorm                : StyleParam.BarNorm,
            [<Optional;DefaultParameterValue(null)>] ?ExtendPieColors        : bool,
            [<Optional;DefaultParameterValue(null)>] ?HiddenLabels           : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?PieColorWay            : Color,
            [<Optional;DefaultParameterValue(null)>] ?BoxGap                 : float,
            [<Optional;DefaultParameterValue(null)>] ?BoxGroupGap            : float,
            [<Optional;DefaultParameterValue(null)>] ?BoxMode                : StyleParam.BoxMode,
            [<Optional;DefaultParameterValue(null)>] ?ViolinGap              : float,
            [<Optional;DefaultParameterValue(null)>] ?ViolinGroupGap         : float,
            [<Optional;DefaultParameterValue(null)>] ?ViolinMode             : StyleParam.ViolinMode,
            [<Optional;DefaultParameterValue(null)>] ?WaterfallGap           : float,
            [<Optional;DefaultParameterValue(null)>] ?WaterfallGroupGap      : float,
            [<Optional;DefaultParameterValue(null)>] ?WaterfallMode          : StyleParam.WaterfallMode,
            [<Optional;DefaultParameterValue(null)>] ?FunnelGap              : float,
            [<Optional;DefaultParameterValue(null)>] ?FunnelGroupGap         : float,
            [<Optional;DefaultParameterValue(null)>] ?FunnelMode             : StyleParam.FunnelMode,
            [<Optional;DefaultParameterValue(null)>] ?ExtendFunnelAreaColors : bool,
            [<Optional;DefaultParameterValue(null)>] ?FunnelAreaColorWay     : Color, 
            [<Optional;DefaultParameterValue(null)>] ?ExtendSunBurstColors   : bool,
            [<Optional;DefaultParameterValue(null)>] ?SunBurstColorWay       : Color,
            [<Optional;DefaultParameterValue(null)>] ?ExtendTreeMapColors    : bool,
            [<Optional;DefaultParameterValue(null)>] ?TreeMapColorWay        : Color,            
            [<Optional;DefaultParameterValue(null)>] ?ExtendIcicleColors     : bool,
            [<Optional;DefaultParameterValue(null)>] ?IcicleColorWay         : Color,
            [<Optional;DefaultParameterValue(null)>] ?Annotations            : seq<Annotation>,
            [<Optional;DefaultParameterValue(null)>] ?Shapes                 : seq<Shape>
        ) =
            Layout()
            |> Layout.style
                (
                   ?Title                  = Title                  ,
                   ?ShowLegend             = ShowLegend             ,
                   ?Legend                 = Legend                 ,
                   ?Margin                 = Margin                 ,
                   ?AutoSize               = AutoSize               ,
                   ?Width                  = Width                  ,
                   ?Height                 = Height                 ,
                   ?Font                   = Font                   ,
                   ?UniformText            = UniformText            ,
                   ?Separators             = Separators             ,
                   ?PaperBGColor           = PaperBGColor          ,
                   ?PlotBGColor            = PlotBGColor           ,
                   ?AutoTypeNumbers        = AutoTypeNumbers        ,
                   ?Colorscale             = Colorscale             ,
                   ?Colorway               = Colorway               ,
                   ?ModeBar                = ModeBar                ,
                   ?HoverMode              = HoverMode              ,
                   ?ClickMode              = ClickMode              ,
                   ?DragMode               = DragMode               ,
                   ?SelectDirection        = SelectDirection        ,
                   ?HoverDistance          = HoverDistance          ,
                   ?SpikeDistance          = SpikeDistance          ,
                   ?Hoverlabel             = Hoverlabel             ,
                   ?Transition             = Transition             ,
                   ?DataRevision           = DataRevision           ,
                   ?UIRevision             = UIRevision             ,
                   ?EditRevision           = EditRevision           ,
                   ?SelectRevision         = SelectRevision         ,
                   ?Template               = Template               ,
                   ?Meta                   = Meta                   ,
                   ?Computed               = Computed               ,
                   ?Grid                   = Grid                   ,
                   ?Calendar               = Calendar               ,
                   ?NewShape               = NewShape               ,
                   ?ActiveShape            = ActiveShape            ,
                   ?HideSources            = HideSources            ,
                   ?BarGap                 = BarGap                 ,
                   ?BarGroupGap            = BarGroupGap            ,
                   ?BarMode                = BarMode                ,
                   ?BarNorm                = BarNorm                ,
                   ?ExtendPieColors        = ExtendPieColors        ,
                   ?HiddenLabels           = HiddenLabels           ,
                   ?PieColorWay            = PieColorWay            ,
                   ?BoxGap                 = BoxGap                 ,
                   ?BoxGroupGap            = BoxGroupGap            ,
                   ?BoxMode                = BoxMode                ,
                   ?ViolinGap              = ViolinGap              ,
                   ?ViolinGroupGap         = ViolinGroupGap         ,
                   ?ViolinMode             = ViolinMode             ,
                   ?WaterfallGap           = WaterfallGap           ,
                   ?WaterfallGroupGap      = WaterfallGroupGap      ,
                   ?WaterfallMode          = WaterfallMode          ,
                   ?FunnelGap              = FunnelGap              ,
                   ?FunnelGroupGap         = FunnelGroupGap         ,
                   ?FunnelMode             = FunnelMode             ,
                   ?ExtendFunnelAreaColors = ExtendFunnelAreaColors ,
                   ?FunnelAreaColorWay     = FunnelAreaColorWay     ,
                   ?ExtendSunBurstColors   = ExtendSunBurstColors   ,
                   ?SunBurstColorWay       = SunBurstColorWay       ,
                   ?ExtendTreeMapColors    = ExtendTreeMapColors    ,
                   ?TreeMapColorWay        = TreeMapColorWay        ,
                   ?ExtendIcicleColors     = ExtendIcicleColors     ,
                   ?IcicleColorWay         = IcicleColorWay         ,
                   ?Annotations            = Annotations            ,
                   ?Shapes                 = Shapes
                )

    // Applies the styles to Layout()
    static member style
        (   
            [<Optional;DefaultParameterValue(null)>] ?Title                  : Title,
            [<Optional;DefaultParameterValue(null)>] ?ShowLegend             : bool,
            [<Optional;DefaultParameterValue(null)>] ?Legend                 : Legend,
            [<Optional;DefaultParameterValue(null)>] ?Margin                 : Margin,
            [<Optional;DefaultParameterValue(null)>] ?AutoSize               : bool,
            [<Optional;DefaultParameterValue(null)>] ?Width                  : int,
            [<Optional;DefaultParameterValue(null)>] ?Height                 : int,
            [<Optional;DefaultParameterValue(null)>] ?Font                   : Font,
            [<Optional;DefaultParameterValue(null)>] ?UniformText            : UniformText,
            [<Optional;DefaultParameterValue(null)>] ?Separators             : string,
            [<Optional;DefaultParameterValue(null)>] ?PaperBGColor           : Color,
            [<Optional;DefaultParameterValue(null)>] ?PlotBGColor            : Color,
            [<Optional;DefaultParameterValue(null)>] ?AutoTypeNumbers        : StyleParam.AutoTypeNumbers,
            [<Optional;DefaultParameterValue(null)>] ?Colorscale             : DefaultColorScales,
            [<Optional;DefaultParameterValue(null)>] ?Colorway               : Color,
            [<Optional;DefaultParameterValue(null)>] ?ModeBar                : ModeBar,
            [<Optional;DefaultParameterValue(null)>] ?HoverMode              : StyleParam.HoverMode,
            [<Optional;DefaultParameterValue(null)>] ?ClickMode              : StyleParam.ClickMode,
            [<Optional;DefaultParameterValue(null)>] ?DragMode               : StyleParam.DragMode,
            [<Optional;DefaultParameterValue(null)>] ?SelectDirection        : StyleParam.SelectDirection,
            [<Optional;DefaultParameterValue(null)>] ?HoverDistance          : int,
            [<Optional;DefaultParameterValue(null)>] ?SpikeDistance          : int,
            [<Optional;DefaultParameterValue(null)>] ?Hoverlabel             : Hoverlabel,
            [<Optional;DefaultParameterValue(null)>] ?Transition             : Transition,
            [<Optional;DefaultParameterValue(null)>] ?DataRevision           : string,
            [<Optional;DefaultParameterValue(null)>] ?UIRevision             : string,
            [<Optional;DefaultParameterValue(null)>] ?EditRevision           : string,
            [<Optional;DefaultParameterValue(null)>] ?SelectRevision         : string,
            [<Optional;DefaultParameterValue(null)>] ?Template               : ImmutableDynamicObj,
            [<Optional;DefaultParameterValue(null)>] ?Meta                   : string,
            [<Optional;DefaultParameterValue(null)>] ?Computed               : string,
            [<Optional;DefaultParameterValue(null)>] ?Grid                   : LayoutGrid,
            [<Optional;DefaultParameterValue(null)>] ?Calendar               : StyleParam.Calendar,
            [<Optional;DefaultParameterValue(null)>] ?NewShape               : Shape,
            [<Optional;DefaultParameterValue(null)>] ?ActiveShape            : ActiveShape,
            [<Optional;DefaultParameterValue(null)>] ?HideSources            : bool,
            [<Optional;DefaultParameterValue(null)>] ?BarGap                 : float, 
            [<Optional;DefaultParameterValue(null)>] ?BarGroupGap            : float,
            [<Optional;DefaultParameterValue(null)>] ?BarMode                : StyleParam.BarMode,
            [<Optional;DefaultParameterValue(null)>] ?BarNorm                : StyleParam.BarNorm,
            [<Optional;DefaultParameterValue(null)>] ?ExtendPieColors        : bool,
            [<Optional;DefaultParameterValue(null)>] ?HiddenLabels           : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?PieColorWay            : Color,
            [<Optional;DefaultParameterValue(null)>] ?BoxGap                 : float,
            [<Optional;DefaultParameterValue(null)>] ?BoxGroupGap            : float,
            [<Optional;DefaultParameterValue(null)>] ?BoxMode                : StyleParam.BoxMode,
            [<Optional;DefaultParameterValue(null)>] ?ViolinGap              : float,
            [<Optional;DefaultParameterValue(null)>] ?ViolinGroupGap         : float,
            [<Optional;DefaultParameterValue(null)>] ?ViolinMode             : StyleParam.ViolinMode,
            [<Optional;DefaultParameterValue(null)>] ?WaterfallGap           : float,
            [<Optional;DefaultParameterValue(null)>] ?WaterfallGroupGap      : float,
            [<Optional;DefaultParameterValue(null)>] ?WaterfallMode          : StyleParam.WaterfallMode, 
            [<Optional;DefaultParameterValue(null)>] ?FunnelGap              : float,
            [<Optional;DefaultParameterValue(null)>] ?FunnelGroupGap         : float,
            [<Optional;DefaultParameterValue(null)>] ?FunnelMode             : StyleParam.FunnelMode,
            [<Optional;DefaultParameterValue(null)>] ?ExtendFunnelAreaColors : bool,
            [<Optional;DefaultParameterValue(null)>] ?FunnelAreaColorWay     : Color, 
            [<Optional;DefaultParameterValue(null)>] ?ExtendSunBurstColors   : bool,
            [<Optional;DefaultParameterValue(null)>] ?SunBurstColorWay       : Color,
            [<Optional;DefaultParameterValue(null)>] ?ExtendTreeMapColors    : bool,
            [<Optional;DefaultParameterValue(null)>] ?TreeMapColorWay        : Color,            
            [<Optional;DefaultParameterValue(null)>] ?ExtendIcicleColors     : bool,
            [<Optional;DefaultParameterValue(null)>] ?IcicleColorWay         : Color,
            [<Optional;DefaultParameterValue(null)>] ?Annotations            : seq<Annotation>,
            [<Optional;DefaultParameterValue(null)>] ?Shapes                 : seq<Shape>
        ) =
            (fun (layout:Layout) -> 
                layout
                ++? ("title", Title)
                ++? ("showlegend", ShowLegend)
                ++? ("legend", Legend)
                ++? ("margin", Margin)
                ++? ("autosize", AutoSize)
                ++? ("width", Width)
                ++? ("height", Height)
                ++? ("font", Font)
                ++? ("uniformtext", UniformText)
                ++? ("separators", Separators)
                ++? ("paper_bgcolor", PaperBGColor)
                ++? ("plot_bgcolor", PlotBGColor)
                ++?? ("autotypenumbers", AutoTypeNumbers, StyleParam.AutoTypeNumbers.convert)
                ++? ("colorscale", Colorscale)
                ++? ("colorway", Colorway)
                ++? ("modebar", ModeBar)
                ++?? ("hovermode", HoverMode, StyleParam.HoverMode.convert)
                ++?? ("clickmode", ClickMode, StyleParam.ClickMode.convert)
                ++?? ("dragmode", DragMode, StyleParam.DragMode.convert)
                ++?? ("selectdirection", SelectDirection, StyleParam.SelectDirection.convert)
                ++? ("hoverdistance", HoverDistance)
                ++? ("spikedistance", SpikeDistance)
                ++? ("hoverlabel", Hoverlabel)
                ++? ("transition", Transition)
                ++? ("datarevision", DataRevision)
                ++? ("uirevision", UIRevision)
                ++? ("editrevision", EditRevision)
                ++? ("selectrevision", SelectRevision)
                ++? ("template", Template)
                ++? ("meta", Meta)
                ++? ("computed", Computed)
                ++? ("grid", Grid)
                ++?? ("calendar", Calendar, StyleParam.Calendar.convert)
                ++? ("newshape", NewShape)
                ++? ("activeshape", ActiveShape)
                ++? ("hidesources", HideSources)
                ++? ("bargap", BarGap)
                ++? ("bargroupgap", BarGroupGap)
                ++?? ("barmode", BarMode, StyleParam.BarMode.convert)
                ++?? ("barnorm", BarNorm, StyleParam.BarNorm.convert)
                ++? ("extendpiecolors", ExtendPieColors)
                ++? ("hiddenlabels", HiddenLabels)
                ++? ("piecolorway", PieColorWay)
                ++? ("boxgap", BoxGap)
                ++? ("boxgroupgap", BoxGroupGap)
                ++?? ("boxmode", BoxMode, StyleParam.BoxMode.convert)
                ++? ("violingap", ViolinGap)
                ++? ("violingroupgap", ViolinGroupGap)
                ++?? ("violinmode", ViolinMode, StyleParam.ViolinMode.convert)
                ++? ("waterfallgap", WaterfallGap)
                ++? ("waterfallgroupgap", WaterfallGroupGap)
                ++?? ("waterfallmode", WaterfallMode, StyleParam.WaterfallMode.convert)
                ++? ("funnelgap", FunnelGap)
                ++? ("funnelgroupgap", FunnelGroupGap)
                ++?? ("funnelmode", FunnelMode, StyleParam.FunnelMode.convert)
                ExtendFunnelAreaColors |> DynObj.setValueOpt layout "extendfunnelareacolors "
                ++? ("funnelareacolorway", FunnelAreaColorWay)
                ++? ("extendsunburstcolors", ExtendSunBurstColors)
                ++? ("sunburstcolorway", SunBurstColorWay)
                ++? ("extendtreemapcolors", ExtendTreeMapColors)
                ++? ("treemapcolorway", TreeMapColorWay)
                ++? ("extendiciclecolors", ExtendIcicleColors)
                ++? ("iciclecolorway", IcicleColorWay)
                ++? ("annotations", Annotations)
                ++? ("shapes", Shapes)

                layout
            )


    static member AddLinearAxis
        (   
            id   : StyleParam.SubPlotId,
            axis : LinearAxis
        ) =
            (fun (layout:Layout) -> 

                match id with
                | StyleParam.SubPlotId.XAxis _ | StyleParam.SubPlotId.YAxis _ ->
                    axis |> DynObj.setValue layout (StyleParam.SubPlotId.toString id)
                    layout

                | _ -> failwith $"{StyleParam.SubPlotId.toString id} is an invalid subplot id for setting a linear axis on layout"
            )

    // Updates the style of current axis with given AxisId
    static member UpdateLinearAxisById
        (   
            id   : StyleParam.SubPlotId,
            axis : LinearAxis
        ) =
            (fun (layout:Layout) -> 

                match id with
                | StyleParam.SubPlotId.XAxis _ | StyleParam.SubPlotId.YAxis _ ->

                    let axis' = 
                        match layout.TryGetValue (StyleParam.SubPlotId.toString id) with
                        | Some a -> DynObj.combine (unbox a) axis
                        | None  -> axis :>  ImmutableDynamicObj
                
                    axis'           |> DynObj.setValue layout (StyleParam.SubPlotId.toString id)

                    layout
                | _ -> failwith $"{StyleParam.SubPlotId.toString id} is an invalid subplot id for setting a linear axis on layout"
            )

    static member addScene 
        (
            id      : StyleParam.SubPlotId,
            scene   : Scene
        ) =
            (fun (layout:Layout) -> 
                scene |> DynObj.setValue layout (StyleParam.SubPlotId.toString id)
                layout
            )

    static member updateSceneById
        (
            id      : StyleParam.SubPlotId,
            scene   : Scene
        ) =
            (fun (layout:Layout) -> 
                let scene' = 
                    match layout.TryGetValue (StyleParam.SubPlotId.toString id) with
                    | Some a -> DynObj.combine (unbox a) scene
                    | None  -> scene :> ImmutableDynamicObj

                scene' |> DynObj.setValue layout (StyleParam.SubPlotId.toString id)
                layout
            )

    static member tryGetSceneById (id:StyleParam.SubPlotId) =
        (fun (layout:Layout) -> 
            layout.TryGetTypedValue<Scene>(StyleParam.SubPlotId.toString id)
        )
    
    static member AddGeo
        (   
            id   : StyleParam.SubPlotId,
            geo  : Geo
        ) =
            (fun (layout:Layout) -> 
                
                geo |> DynObj.setValue layout (StyleParam.SubPlotId.toString id)

                layout
            )

    // Updates the style of current geo map with given Id
    static member UpdateGeoById
        (   
           id   : StyleParam.SubPlotId,
           geo  : Geo
        ) =
            (fun (layout:Layout) -> 
                let geo' = 
                    match layout.TryGetValue (StyleParam.SubPlotId.toString id) with
                    | Some a -> DynObj.combine (unbox a) geo
                    | None  -> geo :> ImmutableDynamicObj

                geo' |> DynObj.setValue layout (StyleParam.SubPlotId.toString id)
                layout
            )

    static member AddMapbox
        (   
            id      : StyleParam.SubPlotId,
            mapbox  : Mapbox
        ) =
            (fun (layout:Layout) -> 
            
                mapbox |> DynObj.setValue layout (StyleParam.SubPlotId.toString id)

                layout
            )
            
    // Updates the style of current geo map with given Id
    static member UpdateMapboxById
        (   
           id       : StyleParam.SubPlotId,
           mapbox   : Mapbox
        ) =
            (fun (layout:Layout) -> 
                let mapbox' = 
                    match layout.TryGetValue (StyleParam.SubPlotId.toString id) with
                    | Some a -> DynObj.combine (unbox a) mapbox
                    | None  -> mapbox :> ImmutableDynamicObj

                mapbox' |> DynObj.setValue layout (StyleParam.SubPlotId.toString id)
                layout
            )

    static member tryGetPolarById (id:StyleParam.SubPlotId) =
        (fun (layout:Layout) -> 
            layout.TryGetTypedValue<Polar>(StyleParam.SubPlotId.toString id)
        )

    /// Updates the style of current polar object with given Id. 
    /// If there does not exist a polar object with the given id, sets it with the given polar object
    static member updatePolarById
        (   
           id       : StyleParam.SubPlotId,
           polar    : Polar
        ) =
            (fun (layout:Layout) -> 

                let polar' = 
                    match layout |> Layout.tryGetPolarById(id) with
                    | Some a  -> DynObj.combine (unbox a) polar
                    | None    -> polar :> ImmutableDynamicObj
                
                polar' |> DynObj.setValue layout (StyleParam.SubPlotId.toString id)

                layout
            )

    static member tryGetColorAxisById (id:StyleParam.SubPlotId) =
        (fun (layout:Layout) -> 
            layout.TryGetTypedValue<ColorAxis>(StyleParam.SubPlotId.toString id)
        )

    /// Updates the style of current ColorAxis object with given Id. 
    /// If there does not exist a ColorAxis object with the given id, sets it with the given ColorAxis object
    static member updateColorAxisById
        (   
           id       : StyleParam.SubPlotId,
           colorAxis: ColorAxis
        ) =
            (fun (layout:Layout) -> 

                let colorAxis' = 
                    match layout |> Layout.tryGetColorAxisById(id) with
                    | Some a  -> DynObj.combine (unbox a) colorAxis
                    | None    -> colorAxis :> ImmutableDynamicObj
                
                colorAxis' |> DynObj.setValue layout (StyleParam.SubPlotId.toString id)

                layout
            )

    static member SetLayoutGrid 
        (
            grid: LayoutGrid
        ) =
            (fun (layout:Layout) ->
                grid |> ++ ("grid", layout)
            )

    static member GetLayoutGrid 
        (
            grid: LayoutGrid
        ) =
            (fun (layout:Layout) ->
                grid |> ++ ("grid", layout)
            )

    static member setLegend(legend:Legend) =
        (fun (layout:Layout) -> 
            legend |> ++ ("legend", layout)
        )
