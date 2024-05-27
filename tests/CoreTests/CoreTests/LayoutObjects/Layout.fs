module Tests.ConfigObjects.Layout

open Expecto
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.ConfigObjects
open DynamicObj

open TestUtils.Objects

let layout = 
    Layout.init(
        Title                   = Title.init(),
        ShowLegend              = true,
        Margin                  = Margin.init(),
        AutoSize                = true,
        Width                   = 1,
        Height                  = 1,
        Font                    = Font.init(),
        UniformText             = UniformText.init(),
        Separators              = ",",
        PaperBGColor            = Color.fromString("grey"),
        PlotBGColor             = Color.fromString("grey"),
        AutoTypeNumbers         = StyleParam.AutoTypeNumbers.Strict,
        Colorscale              = DefaultColorScales.init(),
        Colorway                = Color.fromColors [],
        ModeBar                 = ModeBar.init(),
        HoverMode               = StyleParam.HoverMode.X,
        ClickMode               = StyleParam.ClickMode.Event,
        DragMode                = StyleParam.DragMode.DrawRect,
        SelectDirection         = StyleParam.SelectDirection.Any,
        NewSelection            = NewSelection.init(),
        ActiveSelection         = ActiveSelection.init(),
        HoverDistance           = 1,
        SpikeDistance           = 1,
        Hoverlabel              = Hoverlabel.init(),
        Transition              = Transition.init(),
        DataRevision            = "lol",
        UIRevision              = "lol",
        EditRevision            = "lol",
        SelectRevision          = "lol",
        Template                = Layout.init(),
        Meta                    = "lol",
        Computed                = "lol",
        Grid                    = LayoutGrid.init(),
        Calendar                = StyleParam.Calendar.Discworld,
        NewShape                = NewShape.init(),
        MinReducedHeight        = 1,
        MinReducedWidth         = 1,
        ActiveShape             = ActiveShape.init(),
        HideSources             = true,
        ScatterGap              = 1,
        ScatterMode             = StyleParam.ScatterMode.Group,
        BarGap                  = 1,
        BarGroupGap             = 1,
        BarMode                 = StyleParam.BarMode.Group,
        BarNorm                 = StyleParam.BarNorm.Fraction,
        ExtendPieColors         = true,
        HiddenLabels            = ["lol"],
        PieColorWay             = Color.fromColors [],
        BoxGap                  = 1,
        BoxGroupGap             = 1,
        BoxMode                 = StyleParam.BoxMode.Group,
        ViolinGap               = 1,
        ViolinGroupGap          = 1,
        ViolinMode              = StyleParam.ViolinMode.Group,
        WaterfallGap            = 1,
        WaterfallGroupGap       = 1,
        WaterfallMode           = StyleParam.WaterfallMode.Group,
        FunnelGap               = 1,
        FunnelGroupGap          = 1,
        FunnelMode              = StyleParam.FunnelMode.Group,
        ExtendFunnelAreaColors  = true,
        FunnelAreaColorWay      = Color.fromColors [],
        ExtendSunBurstColors    = true,
        SunBurstColorWay        = Color.fromColors [],
        ExtendTreeMapColors     = true,
        TreeMapColorWay         = Color.fromColors [],
        ExtendIcicleColors      = true,
        IcicleColorWay          = Color.fromColors [],
        Annotations             = [],
        Shapes                  = [],
        Selections              = [],
        Images                  = [],
        Sliders                 = [],
        UpdateMenus             = []
    )

[<Tests>]
let ``Layout json tests`` =
    testList "LayoutObjects.Layout JSON field tests" [
        testCase "title"                    (fun _ -> layout |> jsonFieldIsSetWith  "title"                  "{}")
        testCase "showlegend"               (fun _ -> layout |> jsonFieldIsSetWith  "showlegend"             "true")
        testCase "margin"                   (fun _ -> layout |> jsonFieldIsSetWith  "margin"                 "{}")
        testCase "autosize"                 (fun _ -> layout |> jsonFieldIsSetWith  "autosize"               "true")
        testCase "width"                    (fun _ -> layout |> jsonFieldIsSetWith  "width"                  "1")
        testCase "height"                   (fun _ -> layout |> jsonFieldIsSetWith  "height"                 "1")
        testCase "font"                     (fun _ -> layout |> jsonFieldIsSetWith  "font"                   "{}")
        testCase "uniformtext"              (fun _ -> layout |> jsonFieldIsSetWith  "uniformtext"            "{}")
        testCase "separators"               (fun _ -> layout |> jsonFieldIsSetWith  "separators"             "\",\"")
        testCase "paperbgcolor"             (fun _ -> layout |> jsonFieldIsSetWith  "paper_bgcolor"           "\"grey\"")
        testCase "plotbgcolor"              (fun _ -> layout |> jsonFieldIsSetWith  "plot_bgcolor"            "\"grey\"")
        testCase "autotypenumbers"          (fun _ -> layout |> jsonFieldIsSetWith  "autotypenumbers"        "\"strict\"")
        testCase "colorscale"               (fun _ -> layout |> jsonFieldIsSetWith  "colorscale"             "{}")
        testCase "colorway"                 (fun _ -> layout |> jsonFieldIsSetWith  "colorway"               "[]")
        testCase "modebar"                  (fun _ -> layout |> jsonFieldIsSetWith  "modebar"                "{}")
        testCase "hovermode"                (fun _ -> layout |> jsonFieldIsSetWith  "hovermode"              "\"x\"")
        testCase "clickmode"                (fun _ -> layout |> jsonFieldIsSetWith  "clickmode"              "\"event\"")
        testCase "dragmode"                 (fun _ -> layout |> jsonFieldIsSetWith  "dragmode"               "\"drawrect\"")
        testCase "selectdirection"          (fun _ -> layout |> jsonFieldIsSetWith  "selectdirection"        "\"any\"")
        testCase "newselection"             (fun _ -> layout |> jsonFieldIsSetWith  "newselection"           "{\"line\":{}}")
        testCase "activeselection"          (fun _ -> layout |> jsonFieldIsSetWith  "activeselection"        "{}")
        testCase "spikedistance"            (fun _ -> layout |> jsonFieldIsSetWith  "spikedistance"          "1")
        testCase "hoverdistance"            (fun _ -> layout |> jsonFieldIsSetWith  "hoverdistance"          "1")
        testCase "hoverlabel"               (fun _ -> layout |> jsonFieldIsSetWith  "hoverlabel"             "{}")
        testCase "transition"               (fun _ -> layout |> jsonFieldIsSetWith  "transition"             "{}")
        testCase "datarevision"             (fun _ -> layout |> jsonFieldIsSetWith  "datarevision"           "\"lol\"")
        testCase "uirevision"               (fun _ -> layout |> jsonFieldIsSetWith  "uirevision"             "\"lol\"")
        testCase "editrevision"             (fun _ -> layout |> jsonFieldIsSetWith  "editrevision"           "\"lol\"")
        testCase "selectrevision"           (fun _ -> layout |> jsonFieldIsSetWith  "selectrevision"         "\"lol\"")
        testCase "template"                 (fun _ -> layout |> jsonFieldIsSetWith  "template"               "{}")
        testCase "meta"                     (fun _ -> layout |> jsonFieldIsSetWith  "meta"                   "\"lol\"")
        testCase "computed"                 (fun _ -> layout |> jsonFieldIsSetWith  "computed"               "\"lol\"")
        testCase "grid"                     (fun _ -> layout |> jsonFieldIsSetWith  "grid"                   "{}")
        testCase "calendar"                 (fun _ -> layout |> jsonFieldIsSetWith  "calendar"               "\"discworld\"")
        testCase "newshape"                 (fun _ -> layout |> jsonFieldIsSetWith  "newshape"               "{}")
        testCase "minreducedheight"         (fun _ -> layout |> jsonFieldIsSetWith  "minreducedheight"       "1")
        testCase "minreducedwidth"          (fun _ -> layout |> jsonFieldIsSetWith  "minreducedwidth"        "1")
        testCase "activeshape"              (fun _ -> layout |> jsonFieldIsSetWith  "activeshape"            "{}")
        testCase "hidesources"              (fun _ -> layout |> jsonFieldIsSetWith  "hidesources"            "true")
        testCase "scattergap"               (fun _ -> layout |> jsonFieldIsSetWith  "scattergap"             "1.0")
        testCase "scattermode"              (fun _ -> layout |> jsonFieldIsSetWith  "scattermode"            "\"group\"")
        testCase "bargap"                   (fun _ -> layout |> jsonFieldIsSetWith  "bargap"                 "1.0")
        testCase "bargroupgap"              (fun _ -> layout |> jsonFieldIsSetWith  "bargroupgap"            "1.0")
        testCase "barmode"                  (fun _ -> layout |> jsonFieldIsSetWith  "barmode"                "\"group\"")
        testCase "barnorm"                  (fun _ -> layout |> jsonFieldIsSetWith  "barnorm"                "\"fraction\"")
        testCase "extendpiecolors"          (fun _ -> layout |> jsonFieldIsSetWith  "extendpiecolors"        "true")
        testCase "hiddenlabels"             (fun _ -> layout |> jsonFieldIsSetWith  "hiddenlabels"           "[\"lol\"]")
        testCase "piecolorway"              (fun _ -> layout |> jsonFieldIsSetWith  "piecolorway"            "[]")
        testCase "boxgap"                   (fun _ -> layout |> jsonFieldIsSetWith  "boxgap"                 "1.0")
        testCase "boxgroupgap"              (fun _ -> layout |> jsonFieldIsSetWith  "boxgroupgap"            "1.0")
        testCase "boxmode"                  (fun _ -> layout |> jsonFieldIsSetWith  "boxmode"                "\"group\"")
        testCase "violingap"                (fun _ -> layout |> jsonFieldIsSetWith  "violingap"              "1.0")
        testCase "violingroupgap"           (fun _ -> layout |> jsonFieldIsSetWith  "violingroupgap"         "1.0")
        testCase "violinmode"               (fun _ -> layout |> jsonFieldIsSetWith  "violinmode"             "\"group\"")
        testCase "waterfallgap"             (fun _ -> layout |> jsonFieldIsSetWith  "waterfallgap"           "1.0")
        testCase "waterfallgroupgap"        (fun _ -> layout |> jsonFieldIsSetWith  "waterfallgroupgap"      "1.0")
        testCase "waterfallmode"            (fun _ -> layout |> jsonFieldIsSetWith  "waterfallmode"          "\"group\"")
        testCase "funnelgap"                (fun _ -> layout |> jsonFieldIsSetWith  "funnelgap"              "1.0")
        testCase "funnelgroupgap"           (fun _ -> layout |> jsonFieldIsSetWith  "funnelgroupgap"         "1.0")
        testCase "funnelmode"               (fun _ -> layout |> jsonFieldIsSetWith  "funnelmode"             "\"group\"")
        testCase "extendfunnelareacolors"   (fun _ -> layout |> jsonFieldIsSetWith  "extendfunnelareacolors" "true")
        testCase "funnelareacolorway"       (fun _ -> layout |> jsonFieldIsSetWith  "funnelareacolorway"     "[]")
        testCase "extendsunburstcolors"     (fun _ -> layout |> jsonFieldIsSetWith  "extendsunburstcolors"   "true")
        testCase "sunburstcolorway"         (fun _ -> layout |> jsonFieldIsSetWith  "sunburstcolorway"       "[]")
        testCase "extendtreemapcolors"      (fun _ -> layout |> jsonFieldIsSetWith  "extendtreemapcolors"    "true")
        testCase "treemapcolorway"          (fun _ -> layout |> jsonFieldIsSetWith  "treemapcolorway"        "[]")
        testCase "extendiciclecolors"       (fun _ -> layout |> jsonFieldIsSetWith  "extendiciclecolors"     "true")
        testCase "iciclecolorway"           (fun _ -> layout |> jsonFieldIsSetWith  "iciclecolorway"         "[]")
        testCase "annotations"              (fun _ -> layout |> jsonFieldIsSetWith  "annotations"            "[]")
        testCase "shapes"                   (fun _ -> layout |> jsonFieldIsSetWith  "shapes"                 "[]")
        testCase "selections"               (fun _ -> layout |> jsonFieldIsSetWith  "selections"             "[]")
        testCase "images"                   (fun _ -> layout |> jsonFieldIsSetWith  "images"                 "[]")
        testCase "sliders"                  (fun _ -> layout |> jsonFieldIsSetWith  "sliders"                "[]")
        testCase "updatemenus"              (fun _ -> layout |> jsonFieldIsSetWith  "updatemenus"            "[]")
    ]



let combined = 
    Layout.combine 
        (Layout.init(
            Annotations = [Annotation.init(Name = "first")],
            Shapes      = [Shape.init(Name = "first")],
            Selections  = [Selection.init(Name = "first")],
            Images      = [LayoutImage.init(Name = "first")],
            Sliders     = [Slider.init(Name = "first")],
            HiddenLabels= ["first"],
            UpdateMenus = [UpdateMenu.init(Name = "first")]
        )) 
        (Layout.init(
            Annotations = [Annotation.init(Name = "second")],
            Shapes      = [Shape.init(Name = "second")],
            Selections  = [Selection.init(Name = "second")],
            Images      = [LayoutImage.init(Name = "second")],
            Sliders     = [Slider.init(Name = "second")],
            HiddenLabels= ["second"],
            UpdateMenus = [UpdateMenu.init(Name = "second")]
        )) 

let expectedCombined = 
    Layout.init(
        Annotations = [Annotation.init(Name = "first"); Annotation.init(Name = "second")],
        Shapes      = [Shape.init(Name = "first"); Shape.init(Name = "second")],
        Selections  = [Selection.init(Name = "first"); Selection.init(Name = "second")],
        Images      = [LayoutImage.init(Name = "first"); LayoutImage.init(Name = "second")],
        Sliders     = [Slider.init(Name = "first"); Slider.init(Name = "second")],
        HiddenLabels= ["first"; "second"],
        UpdateMenus = [UpdateMenu.init(Name = "first"); UpdateMenu.init(Name = "second")]
    )

[<Tests>]
let ``Layout combine API tests`` =
    testList "LayoutObjects.Layout API" [
        testCase "combine Annotations" (fun _ -> 
            Expect.sequenceEqual 
                (combined.TryGetTypedValue<seq<Annotation>>("annotations")).Value
                (expectedCombined.TryGetTypedValue<seq<Annotation>>("annotations")).Value
                "Layout.combine did not return the correct object"
        )         
        testCase "combine Shapes" (fun _ -> 
            Expect.sequenceEqual 
                (combined.TryGetTypedValue<seq<Shape>>("shapes")).Value
                (expectedCombined.TryGetTypedValue<seq<Shape>>("shapes")).Value
                "Layout.combine did not return the correct object"
        )        
        testCase "combine Selections" (fun _ -> 
            Expect.sequenceEqual 
                (combined.TryGetTypedValue<seq<Selection>>("selections")).Value
                (expectedCombined.TryGetTypedValue<seq<Selection>>("selections")).Value
                "Layout.combine did not return the correct object"
        )         
        testCase "combine Images" (fun _ -> 
            Expect.sequenceEqual 
                (combined.TryGetTypedValue<seq<LayoutImage>>("images")).Value
                (expectedCombined.TryGetTypedValue<seq<LayoutImage>>("images")).Value
                "Layout.combine did not return the correct object"
        )
        testCase "combine Sliders" (fun _ -> 
            Expect.sequenceEqual 
                (combined.TryGetTypedValue<seq<Slider>>("sliders")).Value
                (expectedCombined.TryGetTypedValue<seq<Slider>>("sliders")).Value
                "Layout.combine did not return the correct object"
        )         
        testCase "combine HiddenLabels" (fun _ -> 
            Expect.sequenceEqual 
                (combined.TryGetTypedValue<seq<string>>("hiddenlabels")).Value
                (expectedCombined.TryGetTypedValue<seq<string>>("hiddenlabels")).Value
                "Layout.combine did not return the correct object"
        )         
        testCase "combine UpdateMenus" (fun _ -> 
            Expect.sequenceEqual 
                (combined.TryGetTypedValue<seq<UpdateMenu>>("updatemenus")).Value
                (expectedCombined.TryGetTypedValue<seq<UpdateMenu>>("updatemenus")).Value
                "Layout.combine did not return the correct object"
        )
    ]

let subplotLayout = 
    let l = Layout.init()
    l?xaxis <- LinearAxis.init()
    l?xaxis2 <- LinearAxis.init()
    l?yaxis <- LinearAxis.init()
    l?yaxis2 <- LinearAxis.init()
    l?scene <- Scene.init()
    l?scene2 <- Scene.init()
    l?geo <- Geo.init()
    l?geo2 <- Geo.init()
    l?mapbox <- Mapbox.init()
    l?mapbox2 <- Mapbox.init()
    l?polar <- Polar.init()
    l?polar2 <- Polar.init()
    l?smith <- Smith.init()
    l?smith2 <- Smith.init()
    l?coloraxis <- ColorAxis.init()
    l?coloraxis2 <- ColorAxis.init()
    l?ternary <- Ternary.init()
    l?ternary2 <- Ternary.init()
    l?legend <- Legend.init()
    l?legend2 <- Legend.init()
    l

[<Tests>]
let ``Layout subplot API tests`` =
    testList "LayoutObjects.Layout API" [
        testCase "subplots getXAxes" (fun _ -> 
            Expect.sequenceEqual
                (Layout.getXAxes subplotLayout)
                ["xaxis", LinearAxis.init(); "xaxis2", LinearAxis.init();]
                "did not return correct collection of subplots"
        )
        testCase "subplots getYAxes" (fun _ ->
            Expect.sequenceEqual
                (Layout.getYAxes subplotLayout)
                ["yaxis", LinearAxis.init(); "yaxis2", LinearAxis.init();]
                "did not return correct collection of subplots"
        )
        testCase "subplots getScenes" (fun _ ->
            Expect.sequenceEqual
                (Layout.getScenes subplotLayout)
                ["scene", Scene.init(); "scene2", Scene.init();]
                "did not return correct collection of subplots"
        )
        testCase "subplots getGeos" (fun _ ->
            Expect.sequenceEqual
                (Layout.getGeos subplotLayout)
                ["geo", Geo.init(); "geo2", Geo.init();]
                "did not return correct collection of subplots"
        )
        testCase "subplots getMapboxes" (fun _ ->
            Expect.sequenceEqual
                (Layout.getMapboxes subplotLayout)
                ["mapbox", Mapbox.init(); "mapbox2", Mapbox.init();]
                "did not return correct collection of subplots"
        )
        testCase "subplots getPolars" (fun _ ->
            Expect.sequenceEqual
                (Layout.getPolars subplotLayout)
                ["polar", Polar.init(); "polar2", Polar.init();]
                "did not return correct collection of subplots"
        )
        testCase "subplots getSmiths" (fun _ ->
            Expect.sequenceEqual
                (Layout.getSmiths subplotLayout)
                ["smith", Smith.init(); "smith2", Smith.init();]
                "did not return correct collection of subplots"
        )
        testCase "subplots getColorAxes" (fun _ ->
            Expect.sequenceEqual
                (Layout.getColorAxes subplotLayout)
                ["coloraxis", ColorAxis.init(); "coloraxis2", ColorAxis.init();]
                "did not return correct collection of subplots"
        )
        testCase "subplots getTernaries" (fun _ ->
            Expect.sequenceEqual
                (Layout.getTernaries subplotLayout)
                ["ternary", Ternary.init(); "ternary2", Ternary.init();]
                "did not return correct collection of subplots"
        )
        testCase "subplots getLegends" (fun _ ->
            Expect.sequenceEqual
                (Layout.getLegends subplotLayout)
                ["legend", Legend.init(); "legend2", Legend.init();]
                "did not return correct collection of subplots"
        )
    ]