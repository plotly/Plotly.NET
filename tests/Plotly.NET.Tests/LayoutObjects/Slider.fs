module Tests.LayoutObjects.Slider

open Expecto
open Plotly.NET
open Plotly.NET.LayoutObjects

open TestUtils.LayoutObjects

let slider =
    Slider.init(
        Active=1,
        ActiveBgColor=Color.fromRGB 1 2 3,
        BgColor=Color.fromRGB 2 3 4,
        BorderColor=Color.fromRGB 3 4 5,
        BorderWidth=2,
        CurrentValue=SliderCurrentValue.init(
            Font=Font.init(StyleParam.FontFamily.Arial, Size=1., Color=Color.fromRGB 4 5 6),
            Offset=1,
            Prefix="prefix",
            Suffix="suffix",
            Visible=false,
            XAnchor=StyleParam.XAnchorPosition.Center
        ),
        Font=Font.init(StyleParam.FontFamily.Balto, Size=2., Color=Color.fromRGB 5 6 7),
        Len=0.4,
        LenMode=StyleParam.UnitMode.Fraction,
        MinorTickLen=6,
        Name="SliderName",
        Padding=Padding.init(1, 2, 3, 4),
        Steps=
            [SliderStep.init(
                Args=["visible", box(false); "title", box("stepTitle")],
                Execute=true,
                Label="stepLabel",
                Method=StyleParam.Method.Update,
                Name="stepName",
                TemplateItemName="stepTemplateItemName",
                Value="stepValue",
                Visible=true
            )],
        TemplateItemName="TemplateItemName",
        TickColor=Color.fromRGB 6 7 8,
        TickLen=7,
        TickWidth=8,
        Transition=Transition.init(        
            Duration=1,
            Easing=StyleParam.TransitionEasing.Back,
            Ordering=StyleParam.TransitionOrdering.LayoutFirst
        ),
        Visible=true,
        X=9,
        XAnchor=StyleParam.XAnchorPosition.Left,
        Y=10,
        YAnchor=StyleParam.YAnchorPosition.Middle
    )

[<Tests>]
let ``Slider tests`` =
    testList "LayoutObjects.Slider JSON field tests" [
        slider |> createJsonFieldTest "active" "1" 
        slider |> createJsonFieldTest "activebgcolor" "\"rgba(1, 2, 3, 1.0)\""
        slider |> createJsonFieldTest "bgcolor" "\"rgba(2, 3, 4, 1.0)\""
        slider |> createJsonFieldTest "bordercolor" "\"rgba(3, 4, 5, 1.0)\""
        slider |> createJsonFieldTest "borderwidth" "2"
        slider |> createJsonFieldTest "currentvalue" "{\"font\":{\"family\":\"Arial\",\"size\":1.0,\"color\":\"rgba(4, 5, 6, 1.0)\"},\"offset\":1,\"prefix\":\"prefix\",\"suffix\":\"suffix\",\"visible\":false,\"xanchor\":\"center\"}"
        slider |> createJsonFieldTest "font" "{\"family\":\"Balto\",\"size\":2.0,\"color\":\"rgba(5, 6, 7, 1.0)\"}"
        slider |> createJsonFieldTest "len" "0.4"
        slider |> createJsonFieldTest "lenmode" "\"fraction\""
        slider |> createJsonFieldTest "minorticklen" "6"
        slider |> createJsonFieldTest "name" "\"SliderName\""
        slider |> createJsonFieldTest "pad" "{\"b\":1,\"l\":2,\"r\":3,\"t\":4}"
        slider |> createJsonFieldTest "templateitemname" "\"TemplateItemName\""
        slider |> createJsonFieldTest "tickcolor" "\"rgba(6, 7, 8, 1.0)\""
        slider |> createJsonFieldTest "ticklen" "7"
        slider |> createJsonFieldTest "tickwidth" "8"
        slider |> createJsonFieldTest "transition" "{\"duration\":1,\"easing\":\"back\",\"ordering\":\"layout first\"}"
        slider |> createJsonFieldTest "visible" "true"
        slider |> createJsonFieldTest "x" "9"
        slider |> createJsonFieldTest "xanchor" "\"left\""
        slider |> createJsonFieldTest "y" "10"
        slider |> createJsonFieldTest "yanchor" "\"middle\""
        slider |> createJsonFieldTest "steps" "[{\"args\":[{\"visible\":false},{\"title\":\"stepTitle\"}],\"execute\":true,\"label\":\"stepLabel\",\"method\":\"update\",\"name\":\"stepName\",\"templateitemname\":\"stepTemplateItemName\",\"value\":\"stepValue\",\"visible\":true}]"
    ]