// this file was auto-generated using Plotly.NET.Codegen on 06.09.22 targeting Plotly.NET, Version=3.0.0.0, Culture=neutral, PublicKeyToken=c98c6d87097b7615.
// Do not edit this, as it will most likely be overwritten on the next codegen run.
// Instead, file an issue or target the codegen with your changes directly.
// Bugs that are not caused by wrong codegen are most likely not found in this file, but in the F# source this file is generated from.

namespace Plotly.NET.CSharp;

public static class Layout {
    public static Plotly.NET.Layout Init<a>(
        Optional<Plotly.NET.Title> Title = default,
        Optional<System.Boolean> ShowLegend = default,
        Optional<Plotly.NET.LayoutObjects.Legend> Legend = default,
        Optional<Plotly.NET.LayoutObjects.Margin> Margin = default,
        Optional<System.Boolean> AutoSize = default,
        Optional<System.Int32> Width = default,
        Optional<System.Int32> Height = default,
        Optional<Plotly.NET.Font> Font = default,
        Optional<Plotly.NET.LayoutObjects.UniformText> UniformText = default,
        Optional<System.String> Separators = default,
        Optional<Plotly.NET.Color> PaperBGColor = default,
        Optional<Plotly.NET.Color> PlotBGColor = default,
        Optional<Plotly.NET.StyleParam.AutoTypeNumbers> AutoTypeNumbers = default,
        Optional<Plotly.NET.LayoutObjects.DefaultColorScales> Colorscale = default,
        Optional<Plotly.NET.Color> Colorway = default,
        Optional<Plotly.NET.LayoutObjects.ModeBar> ModeBar = default,
        Optional<Plotly.NET.StyleParam.HoverMode> HoverMode = default,
        Optional<Plotly.NET.StyleParam.ClickMode> ClickMode = default,
        Optional<Plotly.NET.StyleParam.DragMode> DragMode = default,
        Optional<Plotly.NET.StyleParam.SelectDirection> SelectDirection = default,
        Optional<System.Int32> HoverDistance = default,
        Optional<System.Int32> SpikeDistance = default,
        Optional<Plotly.NET.LayoutObjects.Hoverlabel> Hoverlabel = default,
        Optional<Plotly.NET.LayoutObjects.Transition> Transition = default,
        Optional<System.String> DataRevision = default,
        Optional<System.String> UIRevision = default,
        Optional<System.String> EditRevision = default,
        Optional<System.String> SelectRevision = default,
        Optional<DynamicObj.DynamicObj> Template = default,
        Optional<System.String> Meta = default,
        Optional<System.String> Computed = default,
        Optional<Plotly.NET.LayoutObjects.LayoutGrid> Grid = default,
        Optional<Plotly.NET.StyleParam.Calendar> Calendar = default,
        Optional<Plotly.NET.LayoutObjects.Shape> NewShape = default,
        Optional<Plotly.NET.LayoutObjects.ActiveShape> ActiveShape = default,
        Optional<System.Boolean> HideSources = default,
        Optional<System.Double> BarGap = default,
        Optional<System.Double> BarGroupGap = default,
        Optional<Plotly.NET.StyleParam.BarMode> BarMode = default,
        Optional<Plotly.NET.StyleParam.BarNorm> BarNorm = default,
        Optional<System.Boolean> ExtendPieColors = default,
        Optional<System.Collections.Generic.IEnumerable<a>> HiddenLabels = default,
        Optional<Plotly.NET.Color> PieColorWay = default,
        Optional<System.Double> BoxGap = default,
        Optional<System.Double> BoxGroupGap = default,
        Optional<Plotly.NET.StyleParam.BoxMode> BoxMode = default,
        Optional<System.Double> ViolinGap = default,
        Optional<System.Double> ViolinGroupGap = default,
        Optional<Plotly.NET.StyleParam.ViolinMode> ViolinMode = default,
        Optional<System.Double> WaterfallGap = default,
        Optional<System.Double> WaterfallGroupGap = default,
        Optional<Plotly.NET.StyleParam.WaterfallMode> WaterfallMode = default,
        Optional<System.Double> FunnelGap = default,
        Optional<System.Double> FunnelGroupGap = default,
        Optional<Plotly.NET.StyleParam.FunnelMode> FunnelMode = default,
        Optional<System.Boolean> ExtendFunnelAreaColors = default,
        Optional<Plotly.NET.Color> FunnelAreaColorWay = default,
        Optional<System.Boolean> ExtendSunBurstColors = default,
        Optional<Plotly.NET.Color> SunBurstColorWay = default,
        Optional<System.Boolean> ExtendTreeMapColors = default,
        Optional<Plotly.NET.Color> TreeMapColorWay = default,
        Optional<System.Boolean> ExtendIcicleColors = default,
        Optional<Plotly.NET.Color> IcicleColorWay = default,
        Optional<System.Collections.Generic.IEnumerable<Plotly.NET.LayoutObjects.Annotation>> Annotations = default,
        Optional<System.Collections.Generic.IEnumerable<Plotly.NET.LayoutObjects.Shape>> Shapes = default,
        Optional<System.Collections.Generic.IEnumerable<Plotly.NET.LayoutObjects.LayoutImage>> Images = default,
        Optional<System.Collections.Generic.IEnumerable<Plotly.NET.LayoutObjects.Slider>> Sliders = default,
        Optional<System.Collections.Generic.IEnumerable<Plotly.NET.LayoutObjects.UpdateMenu>> UpdateMenus = default
    )
        where a: System.IConvertible
        =>
            Plotly.NET.Layout.init<a>(
                Title: Title.ToOption(),
                ShowLegend: ShowLegend.ToOption(),
                Legend: Legend.ToOption(),
                Margin: Margin.ToOption(),
                AutoSize: AutoSize.ToOption(),
                Width: Width.ToOption(),
                Height: Height.ToOption(),
                Font: Font.ToOption(),
                UniformText: UniformText.ToOption(),
                Separators: Separators.ToOption(),
                PaperBGColor: PaperBGColor.ToOption(),
                PlotBGColor: PlotBGColor.ToOption(),
                AutoTypeNumbers: AutoTypeNumbers.ToOption(),
                Colorscale: Colorscale.ToOption(),
                Colorway: Colorway.ToOption(),
                ModeBar: ModeBar.ToOption(),
                HoverMode: HoverMode.ToOption(),
                ClickMode: ClickMode.ToOption(),
                DragMode: DragMode.ToOption(),
                SelectDirection: SelectDirection.ToOption(),
                HoverDistance: HoverDistance.ToOption(),
                SpikeDistance: SpikeDistance.ToOption(),
                Hoverlabel: Hoverlabel.ToOption(),
                Transition: Transition.ToOption(),
                DataRevision: DataRevision.ToOption(),
                UIRevision: UIRevision.ToOption(),
                EditRevision: EditRevision.ToOption(),
                SelectRevision: SelectRevision.ToOption(),
                Template: Template.ToOption(),
                Meta: Meta.ToOption(),
                Computed: Computed.ToOption(),
                Grid: Grid.ToOption(),
                Calendar: Calendar.ToOption(),
                NewShape: NewShape.ToOption(),
                ActiveShape: ActiveShape.ToOption(),
                HideSources: HideSources.ToOption(),
                BarGap: BarGap.ToOption(),
                BarGroupGap: BarGroupGap.ToOption(),
                BarMode: BarMode.ToOption(),
                BarNorm: BarNorm.ToOption(),
                ExtendPieColors: ExtendPieColors.ToOption(),
                HiddenLabels: HiddenLabels.ToOption(),
                PieColorWay: PieColorWay.ToOption(),
                BoxGap: BoxGap.ToOption(),
                BoxGroupGap: BoxGroupGap.ToOption(),
                BoxMode: BoxMode.ToOption(),
                ViolinGap: ViolinGap.ToOption(),
                ViolinGroupGap: ViolinGroupGap.ToOption(),
                ViolinMode: ViolinMode.ToOption(),
                WaterfallGap: WaterfallGap.ToOption(),
                WaterfallGroupGap: WaterfallGroupGap.ToOption(),
                WaterfallMode: WaterfallMode.ToOption(),
                FunnelGap: FunnelGap.ToOption(),
                FunnelGroupGap: FunnelGroupGap.ToOption(),
                FunnelMode: FunnelMode.ToOption(),
                ExtendFunnelAreaColors: ExtendFunnelAreaColors.ToOption(),
                FunnelAreaColorWay: FunnelAreaColorWay.ToOption(),
                ExtendSunBurstColors: ExtendSunBurstColors.ToOption(),
                SunBurstColorWay: SunBurstColorWay.ToOption(),
                ExtendTreeMapColors: ExtendTreeMapColors.ToOption(),
                TreeMapColorWay: TreeMapColorWay.ToOption(),
                ExtendIcicleColors: ExtendIcicleColors.ToOption(),
                IcicleColorWay: IcicleColorWay.ToOption(),
                Annotations: Annotations.ToOption(),
                Shapes: Shapes.ToOption(),
                Images: Images.ToOption(),
                Sliders: Sliders.ToOption(),
                UpdateMenus: UpdateMenus.ToOption()
            );
    public static Plotly.NET.Layout Style<a>(
        this Plotly.NET.Layout obj,
        Optional<Plotly.NET.Title> Title = default,
        Optional<System.Boolean> ShowLegend = default,
        Optional<Plotly.NET.LayoutObjects.Legend> Legend = default,
        Optional<Plotly.NET.LayoutObjects.Margin> Margin = default,
        Optional<System.Boolean> AutoSize = default,
        Optional<System.Int32> Width = default,
        Optional<System.Int32> Height = default,
        Optional<Plotly.NET.Font> Font = default,
        Optional<Plotly.NET.LayoutObjects.UniformText> UniformText = default,
        Optional<System.String> Separators = default,
        Optional<Plotly.NET.Color> PaperBGColor = default,
        Optional<Plotly.NET.Color> PlotBGColor = default,
        Optional<Plotly.NET.StyleParam.AutoTypeNumbers> AutoTypeNumbers = default,
        Optional<Plotly.NET.LayoutObjects.DefaultColorScales> Colorscale = default,
        Optional<Plotly.NET.Color> Colorway = default,
        Optional<Plotly.NET.LayoutObjects.ModeBar> ModeBar = default,
        Optional<Plotly.NET.StyleParam.HoverMode> HoverMode = default,
        Optional<Plotly.NET.StyleParam.ClickMode> ClickMode = default,
        Optional<Plotly.NET.StyleParam.DragMode> DragMode = default,
        Optional<Plotly.NET.StyleParam.SelectDirection> SelectDirection = default,
        Optional<System.Int32> HoverDistance = default,
        Optional<System.Int32> SpikeDistance = default,
        Optional<Plotly.NET.LayoutObjects.Hoverlabel> Hoverlabel = default,
        Optional<Plotly.NET.LayoutObjects.Transition> Transition = default,
        Optional<System.String> DataRevision = default,
        Optional<System.String> UIRevision = default,
        Optional<System.String> EditRevision = default,
        Optional<System.String> SelectRevision = default,
        Optional<DynamicObj.DynamicObj> Template = default,
        Optional<System.String> Meta = default,
        Optional<System.String> Computed = default,
        Optional<Plotly.NET.LayoutObjects.LayoutGrid> Grid = default,
        Optional<Plotly.NET.StyleParam.Calendar> Calendar = default,
        Optional<Plotly.NET.LayoutObjects.Shape> NewShape = default,
        Optional<Plotly.NET.LayoutObjects.ActiveShape> ActiveShape = default,
        Optional<System.Boolean> HideSources = default,
        Optional<System.Double> BarGap = default,
        Optional<System.Double> BarGroupGap = default,
        Optional<Plotly.NET.StyleParam.BarMode> BarMode = default,
        Optional<Plotly.NET.StyleParam.BarNorm> BarNorm = default,
        Optional<System.Boolean> ExtendPieColors = default,
        Optional<System.Collections.Generic.IEnumerable<a>> HiddenLabels = default,
        Optional<Plotly.NET.Color> PieColorWay = default,
        Optional<System.Double> BoxGap = default,
        Optional<System.Double> BoxGroupGap = default,
        Optional<Plotly.NET.StyleParam.BoxMode> BoxMode = default,
        Optional<System.Double> ViolinGap = default,
        Optional<System.Double> ViolinGroupGap = default,
        Optional<Plotly.NET.StyleParam.ViolinMode> ViolinMode = default,
        Optional<System.Double> WaterfallGap = default,
        Optional<System.Double> WaterfallGroupGap = default,
        Optional<Plotly.NET.StyleParam.WaterfallMode> WaterfallMode = default,
        Optional<System.Double> FunnelGap = default,
        Optional<System.Double> FunnelGroupGap = default,
        Optional<Plotly.NET.StyleParam.FunnelMode> FunnelMode = default,
        Optional<System.Boolean> ExtendFunnelAreaColors = default,
        Optional<Plotly.NET.Color> FunnelAreaColorWay = default,
        Optional<System.Boolean> ExtendSunBurstColors = default,
        Optional<Plotly.NET.Color> SunBurstColorWay = default,
        Optional<System.Boolean> ExtendTreeMapColors = default,
        Optional<Plotly.NET.Color> TreeMapColorWay = default,
        Optional<System.Boolean> ExtendIcicleColors = default,
        Optional<Plotly.NET.Color> IcicleColorWay = default,
        Optional<System.Collections.Generic.IEnumerable<Plotly.NET.LayoutObjects.Annotation>> Annotations = default,
        Optional<System.Collections.Generic.IEnumerable<Plotly.NET.LayoutObjects.Shape>> Shapes = default,
        Optional<System.Collections.Generic.IEnumerable<Plotly.NET.LayoutObjects.LayoutImage>> Images = default,
        Optional<System.Collections.Generic.IEnumerable<Plotly.NET.LayoutObjects.Slider>> Sliders = default,
        Optional<System.Collections.Generic.IEnumerable<Plotly.NET.LayoutObjects.UpdateMenu>> UpdateMenus = default
    )
        where a: System.IConvertible
        =>
            Plotly.NET.Layout.style<a>(
                Title: Title.ToOption(),
                ShowLegend: ShowLegend.ToOption(),
                Legend: Legend.ToOption(),
                Margin: Margin.ToOption(),
                AutoSize: AutoSize.ToOption(),
                Width: Width.ToOption(),
                Height: Height.ToOption(),
                Font: Font.ToOption(),
                UniformText: UniformText.ToOption(),
                Separators: Separators.ToOption(),
                PaperBGColor: PaperBGColor.ToOption(),
                PlotBGColor: PlotBGColor.ToOption(),
                AutoTypeNumbers: AutoTypeNumbers.ToOption(),
                Colorscale: Colorscale.ToOption(),
                Colorway: Colorway.ToOption(),
                ModeBar: ModeBar.ToOption(),
                HoverMode: HoverMode.ToOption(),
                ClickMode: ClickMode.ToOption(),
                DragMode: DragMode.ToOption(),
                SelectDirection: SelectDirection.ToOption(),
                HoverDistance: HoverDistance.ToOption(),
                SpikeDistance: SpikeDistance.ToOption(),
                Hoverlabel: Hoverlabel.ToOption(),
                Transition: Transition.ToOption(),
                DataRevision: DataRevision.ToOption(),
                UIRevision: UIRevision.ToOption(),
                EditRevision: EditRevision.ToOption(),
                SelectRevision: SelectRevision.ToOption(),
                Template: Template.ToOption(),
                Meta: Meta.ToOption(),
                Computed: Computed.ToOption(),
                Grid: Grid.ToOption(),
                Calendar: Calendar.ToOption(),
                NewShape: NewShape.ToOption(),
                ActiveShape: ActiveShape.ToOption(),
                HideSources: HideSources.ToOption(),
                BarGap: BarGap.ToOption(),
                BarGroupGap: BarGroupGap.ToOption(),
                BarMode: BarMode.ToOption(),
                BarNorm: BarNorm.ToOption(),
                ExtendPieColors: ExtendPieColors.ToOption(),
                HiddenLabels: HiddenLabels.ToOption(),
                PieColorWay: PieColorWay.ToOption(),
                BoxGap: BoxGap.ToOption(),
                BoxGroupGap: BoxGroupGap.ToOption(),
                BoxMode: BoxMode.ToOption(),
                ViolinGap: ViolinGap.ToOption(),
                ViolinGroupGap: ViolinGroupGap.ToOption(),
                ViolinMode: ViolinMode.ToOption(),
                WaterfallGap: WaterfallGap.ToOption(),
                WaterfallGroupGap: WaterfallGroupGap.ToOption(),
                WaterfallMode: WaterfallMode.ToOption(),
                FunnelGap: FunnelGap.ToOption(),
                FunnelGroupGap: FunnelGroupGap.ToOption(),
                FunnelMode: FunnelMode.ToOption(),
                ExtendFunnelAreaColors: ExtendFunnelAreaColors.ToOption(),
                FunnelAreaColorWay: FunnelAreaColorWay.ToOption(),
                ExtendSunBurstColors: ExtendSunBurstColors.ToOption(),
                SunBurstColorWay: SunBurstColorWay.ToOption(),
                ExtendTreeMapColors: ExtendTreeMapColors.ToOption(),
                TreeMapColorWay: TreeMapColorWay.ToOption(),
                ExtendIcicleColors: ExtendIcicleColors.ToOption(),
                IcicleColorWay: IcicleColorWay.ToOption(),
                Annotations: Annotations.ToOption(),
                Shapes: Shapes.ToOption(),
                Images: Images.ToOption(),
                Sliders: Sliders.ToOption(),
                UpdateMenus: UpdateMenus.ToOption()
            ).Invoke(obj);
    public static Plotly.NET.Layout UpdateLinearAxisById(
        this Plotly.NET.Layout obj,
        Plotly.NET.StyleParam.SubPlotId id,
        Plotly.NET.LayoutObjects.LinearAxis axis
    )

        =>
            Plotly.NET.Layout.updateLinearAxisById(
                id: id,
                axis: axis
            ).Invoke(obj);
    public static Plotly.NET.LayoutObjects.LinearAxis GetLinearAxisById(
        this Plotly.NET.Layout obj,
        Plotly.NET.StyleParam.SubPlotId id
    )

        =>
            Plotly.NET.Layout.getLinearAxisById(
                id: id
            ).Invoke(obj);
    public static Plotly.NET.Layout SetLinearAxis(
        this Plotly.NET.Layout obj,
        Plotly.NET.StyleParam.SubPlotId id,
        Plotly.NET.LayoutObjects.LinearAxis axis
    )

        =>
            Plotly.NET.Layout.setLinearAxis(
                id: id,
                axis: axis
            ).Invoke(obj);
    public static Plotly.NET.Layout UpdateSceneById(
        this Plotly.NET.Layout obj,
        Plotly.NET.StyleParam.SubPlotId id,
        Plotly.NET.LayoutObjects.Scene scene
    )

        =>
            Plotly.NET.Layout.updateSceneById(
                id: id,
                scene: scene
            ).Invoke(obj);
    public static Plotly.NET.LayoutObjects.Scene GetSceneById(
        this Plotly.NET.Layout obj,
        Plotly.NET.StyleParam.SubPlotId id
    )

        =>
            Plotly.NET.Layout.getSceneById(
                id: id
            ).Invoke(obj);
    public static Plotly.NET.Layout SetScene(
        this Plotly.NET.Layout obj,
        Plotly.NET.StyleParam.SubPlotId id,
        Plotly.NET.LayoutObjects.Scene scene
    )

        =>
            Plotly.NET.Layout.setScene(
                id: id,
                scene: scene
            ).Invoke(obj);
    public static Plotly.NET.Layout UpdateGeoById(
        this Plotly.NET.Layout obj,
        Plotly.NET.StyleParam.SubPlotId id,
        Plotly.NET.LayoutObjects.Geo geo
    )

        =>
            Plotly.NET.Layout.updateGeoById(
                id: id,
                geo: geo
            ).Invoke(obj);
    public static Plotly.NET.LayoutObjects.Geo GetGeoById(
        this Plotly.NET.Layout obj,
        Plotly.NET.StyleParam.SubPlotId id
    )

        =>
            Plotly.NET.Layout.getGeoById(
                id: id
            ).Invoke(obj);
    public static Plotly.NET.Layout SetGeo(
        this Plotly.NET.Layout obj,
        Plotly.NET.StyleParam.SubPlotId id,
        Plotly.NET.LayoutObjects.Geo geo
    )

        =>
            Plotly.NET.Layout.setGeo(
                id: id,
                geo: geo
            ).Invoke(obj);
    public static Plotly.NET.Layout UpdateMapboxById(
        this Plotly.NET.Layout obj,
        Plotly.NET.StyleParam.SubPlotId id,
        Plotly.NET.LayoutObjects.Mapbox mapbox
    )

        =>
            Plotly.NET.Layout.updateMapboxById(
                id: id,
                mapbox: mapbox
            ).Invoke(obj);
    public static Plotly.NET.LayoutObjects.Mapbox GetMapboxById(
        this Plotly.NET.Layout obj,
        Plotly.NET.StyleParam.SubPlotId id
    )

        =>
            Plotly.NET.Layout.getMapboxById(
                id: id
            ).Invoke(obj);
    public static Plotly.NET.Layout SetMapbox(
        this Plotly.NET.Layout obj,
        Plotly.NET.StyleParam.SubPlotId id,
        Plotly.NET.LayoutObjects.Mapbox mapbox
    )

        =>
            Plotly.NET.Layout.setMapbox(
                id: id,
                mapbox: mapbox
            ).Invoke(obj);
    public static Plotly.NET.Layout UpdatePolarById(
        this Plotly.NET.Layout obj,
        Plotly.NET.StyleParam.SubPlotId id,
        Plotly.NET.LayoutObjects.Polar polar
    )

        =>
            Plotly.NET.Layout.updatePolarById(
                id: id,
                polar: polar
            ).Invoke(obj);
    public static Plotly.NET.LayoutObjects.Polar GetPolarById(
        this Plotly.NET.Layout obj,
        Plotly.NET.StyleParam.SubPlotId id
    )

        =>
            Plotly.NET.Layout.getPolarById(
                id: id
            ).Invoke(obj);
    public static Plotly.NET.Layout SetPolar(
        this Plotly.NET.Layout obj,
        Plotly.NET.StyleParam.SubPlotId id,
        Plotly.NET.LayoutObjects.Polar polar
    )

        =>
            Plotly.NET.Layout.setPolar(
                id: id,
                polar: polar
            ).Invoke(obj);
    public static Plotly.NET.Layout UpdateSmithById(
        this Plotly.NET.Layout obj,
        Plotly.NET.StyleParam.SubPlotId id,
        Plotly.NET.LayoutObjects.Smith smith
    )

        =>
            Plotly.NET.Layout.updateSmithById(
                id: id,
                smith: smith
            ).Invoke(obj);
    public static Plotly.NET.LayoutObjects.Smith GetSmithById(
        this Plotly.NET.Layout obj,
        Plotly.NET.StyleParam.SubPlotId id
    )

        =>
            Plotly.NET.Layout.getSmithById(
                id: id
            ).Invoke(obj);
    public static Plotly.NET.Layout SetSmith(
        this Plotly.NET.Layout obj,
        Plotly.NET.StyleParam.SubPlotId id,
        Plotly.NET.LayoutObjects.Smith smith
    )

        =>
            Plotly.NET.Layout.setSmith(
                id: id,
                smith: smith
            ).Invoke(obj);
    public static Plotly.NET.Layout UpdateColorAxisById(
        this Plotly.NET.Layout obj,
        Plotly.NET.StyleParam.SubPlotId id,
        Plotly.NET.LayoutObjects.ColorAxis colorAxis
    )

        =>
            Plotly.NET.Layout.updateColorAxisById(
                id: id,
                colorAxis: colorAxis
            ).Invoke(obj);
    public static Plotly.NET.LayoutObjects.ColorAxis GetColorAxisById(
        this Plotly.NET.Layout obj,
        Plotly.NET.StyleParam.SubPlotId id
    )

        =>
            Plotly.NET.Layout.getColorAxisById(
                id: id
            ).Invoke(obj);
    public static Plotly.NET.Layout SetColorAxis(
        this Plotly.NET.Layout obj,
        Plotly.NET.StyleParam.SubPlotId id,
        Plotly.NET.LayoutObjects.ColorAxis colorAxis
    )

        =>
            Plotly.NET.Layout.setColorAxis(
                id: id,
                colorAxis: colorAxis
            ).Invoke(obj);
    public static Plotly.NET.Layout UpdateTernaryById(
        this Plotly.NET.Layout obj,
        Plotly.NET.StyleParam.SubPlotId id,
        Plotly.NET.LayoutObjects.Ternary ternary
    )

        =>
            Plotly.NET.Layout.updateTernaryById(
                id: id,
                ternary: ternary
            ).Invoke(obj);
    public static Plotly.NET.LayoutObjects.Ternary GetTernaryById(
        this Plotly.NET.Layout obj,
        Plotly.NET.StyleParam.SubPlotId id
    )

        =>
            Plotly.NET.Layout.getTernaryById(
                id: id
            ).Invoke(obj);
    public static Plotly.NET.Layout SetTernary(
        this Plotly.NET.Layout obj,
        Plotly.NET.StyleParam.SubPlotId id,
        Plotly.NET.LayoutObjects.Ternary ternary
    )

        =>
            Plotly.NET.Layout.setTernary(
                id: id,
                ternary: ternary
            ).Invoke(obj);
    public static Plotly.NET.LayoutObjects.LayoutGrid GetLayoutGrid(
        this Plotly.NET.Layout obj,
        Plotly.NET.Layout layout
    )

        =>
            Plotly.NET.Layout.getLayoutGrid(
                layout: layout
            );
    public static Plotly.NET.Layout SetLayoutGrid(
        this Plotly.NET.Layout obj,
        Plotly.NET.LayoutObjects.LayoutGrid layoutGrid
    )

        =>
            Plotly.NET.Layout.setLayoutGrid(
                layoutGrid: layoutGrid
            ).Invoke(obj);
    public static Plotly.NET.Layout UpdateLayoutGrid(
        this Plotly.NET.Layout obj,
        Plotly.NET.LayoutObjects.LayoutGrid layoutGrid
    )

        =>
            Plotly.NET.Layout.updateLayoutGrid(
                layoutGrid: layoutGrid
            ).Invoke(obj);
    public static Plotly.NET.LayoutObjects.Legend GetLegend(
        this Plotly.NET.Layout obj,
        Plotly.NET.Layout layout
    )

        =>
            Plotly.NET.Layout.getLegend(
                layout: layout
            );
    public static Plotly.NET.Layout SetLegend(
        this Plotly.NET.Layout obj,
        Plotly.NET.LayoutObjects.Legend legend
    )

        =>
            Plotly.NET.Layout.setLegend(
                legend: legend
            ).Invoke(obj);
    public static Plotly.NET.Layout UpdateLegend(
        this Plotly.NET.Layout obj,
        Plotly.NET.LayoutObjects.Legend legend
    )

        =>
            Plotly.NET.Layout.updateLegend(
                legend: legend
            ).Invoke(obj);
}