namespace Plotly.NET

open DynamicObj
open Plotly.NET.LayoutObjects
open System
open System.Runtime.InteropServices

/// Layout 
type Layout() = 
    inherit DynamicObj ()

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
            [<Optional;DefaultParameterValue(null)>] ?Template               : DynamicObj,
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
            [<Optional;DefaultParameterValue(null)>] ?Shapes                 : seq<Shape>,
            [<Optional;DefaultParameterValue(null)>] ?Images                 : seq<LayoutImage>,
            [<Optional;DefaultParameterValue(null)>] ?Sliders                : seq<Slider>
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
                   ?Shapes                 = Shapes                 ,
                   ?Images                 = Images                 ,
                   ?Sliders                = Sliders
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
            [<Optional;DefaultParameterValue(null)>] ?Template               : DynamicObj,
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
            [<Optional;DefaultParameterValue(null)>] ?Shapes                 : seq<Shape>,
            [<Optional;DefaultParameterValue(null)>] ?Images                 : seq<LayoutImage>,
            [<Optional;DefaultParameterValue(null)>] ?Sliders                : seq<Slider>
        ) =
            (fun (layout:Layout) -> 
                
                Title                  |> DynObj.setValueOpt layout "title"
                ShowLegend             |> DynObj.setValueOpt layout "showlegend"
                Legend                 |> DynObj.setValueOpt layout "legend"
                Margin                 |> DynObj.setValueOpt layout "margin"
                AutoSize               |> DynObj.setValueOpt layout "autosize"
                Width                  |> DynObj.setValueOpt layout "width"
                Height                 |> DynObj.setValueOpt layout "height"
                Font                   |> DynObj.setValueOpt layout "font"
                UniformText            |> DynObj.setValueOpt layout "uniformtext"
                Separators             |> DynObj.setValueOpt layout "separators"
                PaperBGColor           |> DynObj.setValueOpt layout "paper_bgcolor"
                PlotBGColor            |> DynObj.setValueOpt layout "plot_bgcolor"
                AutoTypeNumbers        |> DynObj.setValueOptBy layout "autotypenumbers" StyleParam.AutoTypeNumbers.convert
                Colorscale             |> DynObj.setValueOpt layout "colorscale"
                Colorway               |> DynObj.setValueOpt layout "colorway"
                ModeBar                |> DynObj.setValueOpt layout "modebar"
                HoverMode              |> DynObj.setValueOptBy layout "hovermode" StyleParam.HoverMode.convert
                ClickMode              |> DynObj.setValueOptBy layout "clickmode" StyleParam.ClickMode.convert
                DragMode               |> DynObj.setValueOptBy layout "dragmode" StyleParam.DragMode.convert
                SelectDirection        |> DynObj.setValueOptBy layout "selectdirection" StyleParam.SelectDirection.convert
                HoverDistance          |> DynObj.setValueOpt layout "hoverdistance"
                SpikeDistance          |> DynObj.setValueOpt layout "spikedistance"
                Hoverlabel             |> DynObj.setValueOpt layout "hoverlabel"
                Transition             |> DynObj.setValueOpt layout "transition"
                DataRevision           |> DynObj.setValueOpt layout "datarevision"
                UIRevision             |> DynObj.setValueOpt layout "uirevision"
                EditRevision           |> DynObj.setValueOpt layout "editrevision"
                SelectRevision         |> DynObj.setValueOpt layout "selectrevision"
                Template               |> DynObj.setValueOpt layout "template"
                Meta                   |> DynObj.setValueOpt layout "meta"
                Computed               |> DynObj.setValueOpt layout "computed"
                Grid                   |> DynObj.setValueOpt layout "grid"
                Calendar               |> DynObj.setValueOptBy layout "calendar" StyleParam.Calendar.convert
                NewShape               |> DynObj.setValueOpt layout "newshape"
                ActiveShape            |> DynObj.setValueOpt layout "activeshape"
                HideSources            |> DynObj.setValueOpt layout "hidesources"
                BarGap                 |> DynObj.setValueOpt layout "bargap"
                BarGroupGap            |> DynObj.setValueOpt layout "bargroupgap"
                BarMode                |> DynObj.setValueOptBy layout "barmode" StyleParam.BarMode.convert
                BarNorm                |> DynObj.setValueOptBy layout "barnorm" StyleParam.BarNorm.convert
                ExtendPieColors        |> DynObj.setValueOpt layout "extendpiecolors"
                HiddenLabels           |> DynObj.setValueOpt layout "hiddenlabels"
                PieColorWay            |> DynObj.setValueOpt layout "piecolorway"
                BoxGap                 |> DynObj.setValueOpt layout "boxgap"
                BoxGroupGap            |> DynObj.setValueOpt layout "boxgroupgap"
                BoxMode                |> DynObj.setValueOptBy layout "boxmode" StyleParam.BoxMode.convert
                ViolinGap              |> DynObj.setValueOpt layout "violingap"
                ViolinGroupGap         |> DynObj.setValueOpt layout "violingroupgap"
                ViolinMode             |> DynObj.setValueOptBy layout "violinmode" StyleParam.ViolinMode.convert
                WaterfallGap           |> DynObj.setValueOpt layout "waterfallgap"
                WaterfallGroupGap      |> DynObj.setValueOpt layout "waterfallgroupgap"
                WaterfallMode          |> DynObj.setValueOptBy layout "waterfallmode" StyleParam.WaterfallMode.convert
                FunnelGap              |> DynObj.setValueOpt layout "funnelgap"
                FunnelGroupGap         |> DynObj.setValueOpt layout "funnelgroupgap"
                FunnelMode             |> DynObj.setValueOptBy layout "funnelmode" StyleParam.FunnelMode.convert
                ExtendFunnelAreaColors |> DynObj.setValueOpt layout "extendfunnelareacolors "
                FunnelAreaColorWay     |> DynObj.setValueOpt layout "funnelareacolorway"
                ExtendSunBurstColors   |> DynObj.setValueOpt layout "extendsunburstcolors"
                SunBurstColorWay       |> DynObj.setValueOpt layout "sunburstcolorway"
                ExtendTreeMapColors    |> DynObj.setValueOpt layout "extendtreemapcolors"
                TreeMapColorWay        |> DynObj.setValueOpt layout "treemapcolorway"
                ExtendIcicleColors     |> DynObj.setValueOpt layout "extendiciclecolors"
                IcicleColorWay         |> DynObj.setValueOpt layout "iciclecolorway"
                Annotations            |> DynObj.setValueOpt layout "annotations"
                Shapes                 |> DynObj.setValueOpt layout "shapes"
                Images                 |> DynObj.setValueOpt layout "images"
                Sliders                |> DynObj.setValueOpt layout "sliders"

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
                        | None  -> axis :>  DynamicObj
                
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
                    | None  -> scene :> DynamicObj

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
                    | None  -> geo :> DynamicObj

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
                    | None  -> mapbox :> DynamicObj

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
                    | None    -> polar :> DynamicObj
                
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
                    | None    -> colorAxis :> DynamicObj
                
                colorAxis' |> DynObj.setValue layout (StyleParam.SubPlotId.toString id)

                layout
            )

    static member tryGetTernaryById (id:StyleParam.SubPlotId) =
        (fun (layout:Layout) -> 
            layout.TryGetTypedValue<Ternary>(StyleParam.SubPlotId.toString id)
        )

    /// Updates the style of current polar object with given Id. 
    /// If there does not exist a polar object with the given id, sets it with the given polar object
    static member updateTernaryById
        (   
           id       : StyleParam.SubPlotId,
           ternary  : Ternary
        ) =
            (fun (layout:Layout) -> 

                let ternary' = 
                    match layout |> Layout.tryGetTernaryById(id) with
                    | Some a  -> DynObj.combine (unbox a) ternary
                    | None    -> ternary :> DynamicObj
                
                ternary' |> DynObj.setValue layout (StyleParam.SubPlotId.toString id)

                layout
            )

    static member SetLayoutGrid 
        (
            grid: LayoutGrid
        ) =
            (fun (layout:Layout) ->
                grid |> DynObj.setValue layout "grid"
                layout
            )

    static member GetLayoutGrid 
        (
            grid: LayoutGrid
        ) =
            (fun (layout:Layout) ->
                grid |> DynObj.setValue layout "grid"
                layout
            )

    static member setLegend(legend:Legend) =
        (fun (layout:Layout) -> 
            legend |> DynObj.setValue layout "legend"
            layout
        )
