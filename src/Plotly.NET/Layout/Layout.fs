namespace Plotly.NET

open DynamicObj
open Plotly.NET.LayoutObjects
open System

/// Layout 
type Layout() = 
    inherit DynamicObj ()

    /// Init Layout type
    static member init
        (   
            ?Title                  : Title,
            ?ShowLegend             : bool,
            ?Legend                 : Legend,
            ?Margin                 : Margin,
            ?AutoSize               : bool,
            ?Width                  : int,
            ?Height                 : int,
            ?Font                   : Font,
            ?UniformText            : UniformText,
            ?Separators             : string,
            ?PaperBGColor           : string,
            ?PlotBGColor            : string,
            ?AutoTypeNumbers        : StyleParam.AutoTypeNumbers,
            ?Colorscale             : DefaultColorScales,
            ?Colorway               : seq<string>,
            ?ModeBar                : ModeBar,
            ?HoverMode              : StyleParam.HoverMode,
            ?ClickMode              : StyleParam.ClickMode,
            ?DragMode               : StyleParam.DragMode,
            ?SelectDirection        : StyleParam.SelectDirection,
            ?HoverDistance          : int,
            ?SpikeDistance          : int,
            ?Hoverlabel             : Hoverlabel,
            ?Transition             : Transition,
            ?DataRevision           : string,
            ?UIRevision             : string,
            ?EditRevision           : string,
            ?SelectRevision         : string,
            ?Template               : DynamicObj,
            ?Meta                   : string,
            ?Computed               : string,
            ?Grid                   : LayoutGrid,
            ?Calendar               : StyleParam.Calendar,
            ?NewShape               : Shape,
            ?ActiveShape            : ActiveShape,
            ?HideSources            : bool,
            ?BarGap                 : float, 
            ?BarGroupGap            : float,
            ?BarMode                : StyleParam.BarMode,
            ?BarNorm                : StyleParam.BarNorm,
            ?ExtendPieColors        : bool,
            ?HiddenLabels           : seq<#IConvertible>,
            ?PieColorWay            : seq<string>,
            ?BoxGap                 : float,
            ?BoxGroupGap            : float,
            ?BoxMode                : StyleParam.BoxMode,
            ?ViolinGap              : float,
            ?ViolinGroupGap         : float,
            ?ViolinMode             : StyleParam.ViolinMode,
            ?WaterfallGap           : float,
            ?WaterfallGroupGap      : float,
            ?WaterfallMode          : StyleParam.WaterfallMode,
            ?FunnelGap              : float,
            ?FunnelGroupGap         : float,
            ?FunnelMode             : StyleParam.FunnelMode,
            ?ExtendFunnelAreaColors : bool,
            ?FunnelAreaColorWay     : seq<string>, 
            ?ExtendSunBurstColors   : bool,
            ?SunBurstColorWay       : seq<string>,
            ?ExtendTreeMapColors    : bool,
            ?TreeMapColorWay        : seq<string>,            
            ?ExtendIcicleColors     : bool,
            ?IcicleColorWay         : seq<string>,
            ?Annotations            : seq<Annotation>,
            ?Shapes                 : seq<Shape>
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
            ?Title                  : Title,
            ?ShowLegend             : bool,
            ?Legend                 : Legend,
            ?Margin                 : Margin,
            ?AutoSize               : bool,
            ?Width                  : int,
            ?Height                 : int,
            ?Font                   : Font,
            ?UniformText            : UniformText,
            ?Separators             : string,
            ?PaperBGColor           : string,
            ?PlotBGColor            : string,
            ?AutoTypeNumbers        : StyleParam.AutoTypeNumbers,
            ?Colorscale             : DefaultColorScales,
            ?Colorway               : seq<string>,
            ?ModeBar                : ModeBar,
            ?HoverMode              : StyleParam.HoverMode,
            ?ClickMode              : StyleParam.ClickMode,
            ?DragMode               : StyleParam.DragMode,
            ?SelectDirection        : StyleParam.SelectDirection,
            ?HoverDistance          : int,
            ?SpikeDistance          : int,
            ?Hoverlabel             : Hoverlabel,
            ?Transition             : Transition,
            ?DataRevision           : string,
            ?UIRevision             : string,
            ?EditRevision           : string,
            ?SelectRevision         : string,
            ?Template               : DynamicObj,
            ?Meta                   : string,
            ?Computed               : string,
            ?Grid                   : LayoutGrid,
            ?Calendar               : StyleParam.Calendar,
            ?NewShape               : Shape,
            ?ActiveShape            : ActiveShape,
            ?HideSources            : bool,
            ?BarGap                 : float, 
            ?BarGroupGap            : float,
            ?BarMode                : StyleParam.BarMode,
            ?BarNorm                : StyleParam.BarNorm,
            ?ExtendPieColors        : bool,
            ?HiddenLabels           : seq<#IConvertible>,
            ?PieColorWay            : seq<string>,
            ?BoxGap                 : float,
            ?BoxGroupGap            : float,
            ?BoxMode                : StyleParam.BoxMode,
            ?ViolinGap              : float,
            ?ViolinGroupGap         : float,
            ?ViolinMode             : StyleParam.ViolinMode,
            ?WaterfallGap           : float,
            ?WaterfallGroupGap      : float,
            ?WaterfallMode          : StyleParam.WaterfallMode, 
            ?FunnelGap              : float,
            ?FunnelGroupGap         : float,
            ?FunnelMode             : StyleParam.FunnelMode,
            ?ExtendFunnelAreaColors : bool,
            ?FunnelAreaColorWay     : seq<string>, 
            ?ExtendSunBurstColors   : bool,
            ?SunBurstColorWay       : seq<string>,
            ?ExtendTreeMapColors    : bool,
            ?TreeMapColorWay        : seq<string>,            
            ?ExtendIcicleColors     : bool,
            ?IcicleColorWay         : seq<string>,
            ?Annotations            : seq<Annotation>,
            ?Shapes                 : seq<Shape>
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
